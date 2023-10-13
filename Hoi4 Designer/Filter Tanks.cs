using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using Microsoft.Win32;

namespace Hoi4_Designer
{
    public partial class Filter_Tanks : Form
    {
        Tank_Designer tankData = new Tank_Designer();
        Tank[] allTanks;
        bool isUpdating = false;
        List<Tank> filteredTanks = new List<Tank>();
        public Filter_Tanks()
        {
            InitializeComponent();
            chassisSelect.DisplayMember = "Name";
            chassisSelect.ValueMember = null;
            chassisSelect.DataSource = tankData.chassis;
            chassisList.DisplayMember = "Name";
            chassisList.ValueMember = null;
            foreach (ListBox listBox in moduleLayoutPanel.Controls.OfType<ListBox>())
            {
                listBox.DisplayMember = "Name";
                listBox.ValueMember = null;
            }
        }

        private void Filter_Tanks_Load(object sender, EventArgs e)
        {
            FileLocation.SetInstallLocation();
            armFilter.Text = "Armour";
            brkFilter.Text = "Breakthrough";
            icFilter.Text = "Build Cost";
            defFilter.Text = "Defence";
            fuelFilter.Text = "Fuel Usage";
            hardAFilter.Text = "Hard Attack";
            hardFilter.Text = "Hardness";
            pirFilter.Text = "Piercing";
            relFilter.Text = "Reliability";
            softAFilter.Text = "Soft Attack";
            speedFilter.Text = "Top Speed";
        }

        private void addChassis_Click(object sender, EventArgs e)
        {
            ChassisSetup newChassis = new ChassisSetup();
            newChassis.chassis = (Chassis)chassisSelect.SelectedItem;
            newChassis.Name = newChassis.chassis.Name;
            chassisList.Items.Add(newChassis);
            analysisLabel.Visible = true;
            chassisList.Visible = true;
        }

        private void chassisList_SelectedIndexChanged_1(object sender, EventArgs e)
        {//Fill out the module selections
            masterLayoutPanel.Visible = true;
            ChassisSetup setup = (ChassisSetup)chassisList.SelectedItem;
            Chassis curChassis = setup.chassis;
            isUpdating = true;
            turretSelect.DataSource = curChassis.slots.SingleOrDefault(s=> s.Name == "turret_type_slot").GetModules(tankData.modules, (curChassis.slots),(int)maxYear.Value);
            gunSelect.DataSource = curChassis.slots.SingleOrDefault(s => s.Name == "main_armament_slot").GetModules(tankData.modules, (curChassis.slots), (int)maxYear.Value);
            suspensionSelect.DataSource = curChassis.slots.SingleOrDefault(s => s.Name == "suspension_type_slot").GetModules(tankData.modules, (curChassis.slots), (int)maxYear.Value);
            armourSelect.DataSource = curChassis.slots.SingleOrDefault(s => s.Name == "armor_type_slot").GetModules(tankData.modules, (curChassis.slots), (int)maxYear.Value);
            engineSelect.DataSource = curChassis.slots.SingleOrDefault(s => s.Name == "engine_type_slot").GetModules(tankData.modules, (curChassis.slots), (int)maxYear.Value);
            specialSelect.DataSource = curChassis.slots.SingleOrDefault(s => s.Name == "special_type_slot_1").GetModules(tankData.modules, (curChassis.slots), (int)maxYear.Value);
            foreach (ListBox listBox in moduleLayoutPanel.Controls.OfType<ListBox>())
            {
                listBox.Height = listBox.ItemHeight * Math.Min(10, listBox.Items.Count + 1);
            }
            //Now select the current modules
            setListSelected(turretSelect, setup.turrets);
            setListSelected(gunSelect, setup.guns);
            setListSelected(suspensionSelect, setup.suspension);
            setListSelected(armourSelect, setup.armours);
            setListSelected(engineSelect, setup.engines);
            setListSelected(specialSelect, setup.specials);
            isUpdating = false;
            moduleLabel.Visible = true;
            getTanksButton.Visible = true;
            getTanksLabel.Visible = true;
            moduleLayoutPanel.Visible = true;
        }
        private void setListSelected(ListBox list,List<Module> setup)
        {
            if (setup != null)
            {
                for (int i = 0; i < list.Items.Count; i++)
                {
                    list.SetSelected(i, setup.Contains(list.Items[i]));
                }
            }
        }
        private void updateChassisModules()
        {
            if (!isUpdating)
            {
                ((ChassisSetup)chassisList.SelectedItem).turrets = turretSelect.SelectedItems.Cast<Module>().ToList();
                ((ChassisSetup)chassisList.SelectedItem).guns = gunSelect.SelectedItems.Cast<Module>().ToList();
                ((ChassisSetup)chassisList.SelectedItem).suspension = suspensionSelect.SelectedItems.Cast<Module>().ToList();
                ((ChassisSetup)chassisList.SelectedItem).armours = armourSelect.SelectedItems.Cast<Module>().ToList();
                ((ChassisSetup)chassisList.SelectedItem).engines = engineSelect.SelectedItems.Cast<Module>().ToList();
                ((ChassisSetup)chassisList.SelectedItem).specials = specialSelect.SelectedItems.Cast<Module>().ToList();
            }
        }

        private void getTanksButton_Click(object sender, EventArgs e)
        {//Take all the selected Modules and create all the possible tanks from them
            //for now this only works with a single chassis
            //First create arrays from each of the slots 
            progressBar1.Visible = true;
            int maxTanks = 0;
            int chassisMax = chassisList.Items.Count;
            int[] chassis = new int[chassisMax];
            int[][] suspensions = new int[chassisMax][];
            int[][] armours = new int[chassisMax][];
            int[][] engines = new int[chassisMax][];
            byte[][,] turretGuns = new byte[chassisMax][,];
            byte[][,] specials = new byte[chassisMax][,];
            int[] specialMax = new int[chassisMax];
            for (int i = 0; i < chassisMax;i++)
            {
                ChassisSetup setup = (ChassisSetup)chassisList.Items[i];
                // Create the array for the special slots
                specialMax[i] = 0;
                byte[,] specialCodes = new byte[99999, 4];
                Thread spcThread = new Thread(() =>
                {
                    specials[i] = SpecialModules(specialSelect.SelectedItems.Cast<Module>().ToList(), new byte[99999, 4], 4, ref specialMax[i]);
                });
                spcThread.Start();
                chassis[i] = setup.chassis.ID;
                suspensions[i] = setup.suspension.Select(m => m.ID).ToArray();
                armours[i] = setup.armours.Select(m => m.ID).ToArray();
                engines[i] = setup.engines.Select(m => m.ID).ToArray();

                //Create the array for the turret& gun combos
                turretGuns[i] = TurretGuns(turretSelect.SelectedItems.Cast<Module>().ToList(), gunSelect.SelectedItems.Cast<Module>().ToList(), (Chassis)chassisSelect.SelectedItem);
                spcThread.Join();
                maxTanks += (turretGuns[i].Length / 2) * suspensions[i].Length * armours[i].Length * engines[i].Length * specialMax[i];
            }
            allTanks = new Tank[maxTanks];
            //Now loop through each slot, creating a tank for each possible variant
            int p = 0;
            for(int c = 0; c < chassisMax; c++)
            {                     
                for (int g = 0; g < (turretGuns[c].Length / 2); g++)
                {
                    for (int s = 0; s < suspensions[c].Length; s++)
                    {
                        for (int a = 0; a < armours[c].Length; a++)
                        {
                            for (int en = 0; en < engines[c].Length; en++)
                            {
                                for (int sp = 0; sp < specialMax[c]; sp++)
                                {
                                    allTanks[p] = new Tank
                                    {
                                        ChassisID = (byte)chassis[c],
                                        TurretID = (byte)turretGuns[c][g, 0],
                                        GunID = (byte)turretGuns[c][g, 1],
                                        SuspensionID = (byte)suspensions[c][s],
                                        ArmourID = (byte)armours[c][a],
                                        EngineID = (byte)engines[c][en],
                                        Spc1ID = specials[c][sp, 0],
                                        Spc2ID = specials[c][sp, 1],
                                        Spc3ID = specials[c][sp, 2],
                                        Spc4ID = specials[c][sp, 3]
                                    };
                                    allTanks[p].SetStats(tankData);
                                    p++;
                                }
                                progressBar1.Value = (int)(((float)p*100F) / (float)maxTanks);
                            }
                        }
                    }
                }
            }
            Tank_Count.Visible = true;
            Tank_Count.Text = maxTanks.ToString() + " tanks found";
            GetStatMinMax(allTanks);
            progressBar1.Visible = false;
            filterLayoutPanel.Visible = true;
            filterLabel.Visible = true;
            Filter_Tanks_Button.Visible = true;
            filterButtonLabel.Visible = true;
            showCheapest.Visible = true;
            cheapestButtonLabel.Visible = true;
            this.Refresh();
        }
        byte[,] TurretGuns(List<Module> turrets, List<Module> guns, Chassis chassis)
        {//Go through the turrets and get a list of the guns that can be fitted to each
            byte[,] TempTurrets = new byte[9999, 2];
            int tCount = 0;
            foreach (Module turret in turrets)
            {
                List<string> turretGuns = new List<string>();
                if (turret.Allowed.Find(s => s.Name == "main_armament_slot") != null)
                {
                    turretGuns = turret.Allowed.Find(s => s.Name == "main_armament_slot").Allowed;
                }

                foreach (Module gun in guns)
                {
                    if (gun.Category == "tank_small_main_armament" || turretGuns.Contains(gun.Category))
                    {
                        TempTurrets[tCount, 0] = (byte)turret.ID;
                        TempTurrets[tCount, 1] = (byte)gun.ID;
                        tCount++;
                    }
                }
            }
            byte[,] turretGunArray = new byte[tCount, 2];
            for(int i = 0; i < tCount; i++)
            {
                turretGunArray[i, 0] = TempTurrets[i, 0];
                turretGunArray[i, 1] = TempTurrets[i, 1];
            }
            return turretGunArray;
        }

        byte[,] SpecialModules(List<Module> modules, byte[,] moduleCodes, byte limit, ref int mPoint)
        {//recursive function that generates a list of all possible module combinations
            List<Module> tempModules = modules.ConvertAll(m => m.Clone());
            foreach (Module module in tempModules)
            {
                moduleCodes[mPoint, 4 - limit] = (byte)module.ID;
                module.Limit -= 1;
                if (limit > 1)
                {
                    moduleCodes = SpecialModules(tempModules.FindAll(m => m.Limit > 0), moduleCodes, (byte)(limit-1), ref mPoint);
                }
                else
                {
                    mPoint += 1;
                    moduleCodes[mPoint, 0] = moduleCodes[mPoint - 1, 0];
                    moduleCodes[mPoint, 1] = moduleCodes[mPoint - 1, 1];
                    moduleCodes[mPoint, 2] = moduleCodes[mPoint - 1, 2];
                }
                module.Limit = 0;
            }
            return moduleCodes;
        }
        void GetStatMinMax(Tank[] tanks)
        {//Set the Min and max for each stat in the filters
            float[,] MaxMin = new float[11, 2];
            for (int j = 0; j < 11; j++) { MaxMin[j, 1] = 999; }
            for (int i = 0; i < tanks.Length; i++)
            {
                MaxMin[0, 0] = Math.Max(MaxMin[0, 0], tanks[i].Arm);
                MaxMin[0, 1] = Math.Min(MaxMin[0, 1], tanks[i].Arm);
                MaxMin[1, 0] = Math.Max(MaxMin[1, 0], tanks[i].Breakthrough);
                MaxMin[1, 1] = Math.Min(MaxMin[1, 1], tanks[i].Breakthrough);
                MaxMin[2, 0] = Math.Max(MaxMin[2, 0], tanks[i].Build_Cost);
                MaxMin[2, 1] = Math.Min(MaxMin[2, 1], tanks[i].Build_Cost);
                MaxMin[3, 0] = Math.Max(MaxMin[3, 0], tanks[i].Defence);
                MaxMin[3, 1] = Math.Min(MaxMin[3, 1], tanks[i].Defence);
                MaxMin[4, 0] = Math.Max(MaxMin[4, 0], tanks[i].Fuel_Consumption);
                MaxMin[4, 1] = Math.Min(MaxMin[4, 1], tanks[i].Fuel_Consumption);
                MaxMin[5, 0] = Math.Max(MaxMin[5, 0], tanks[i].HardA);
                MaxMin[5, 1] = Math.Min(MaxMin[5, 1], tanks[i].HardA);
                MaxMin[6, 0] = Math.Max(MaxMin[6, 0], tanks[i].Hardness);
                MaxMin[6, 1] = Math.Min(MaxMin[6, 1], tanks[i].Hardness);
                MaxMin[7, 0] = Math.Max(MaxMin[7, 0], tanks[i].Piercing);
                MaxMin[7, 1] = Math.Min(MaxMin[7, 1], tanks[i].Piercing);
                MaxMin[8, 0] = Math.Max(MaxMin[8, 0], tanks[i].Reliability);
                MaxMin[8, 1] = Math.Min(MaxMin[8, 1], tanks[i].Reliability);
                MaxMin[9, 0] = Math.Max(MaxMin[9, 0], tanks[i].SoftA);
                MaxMin[9, 1] = Math.Min(MaxMin[9, 1], tanks[i].SoftA);
                MaxMin[10, 0] = Math.Max(MaxMin[10, 0], tanks[i].Speed);
                MaxMin[10, 1] = Math.Min(MaxMin[10, 1], tanks[i].Speed);
            }
            armFilter.setMaxMin(MaxMin[0, 0], MaxMin[0, 1]);
            brkFilter.setMaxMin(MaxMin[1, 0], MaxMin[1, 1]);
            icFilter.setMaxMin(MaxMin[2, 0], MaxMin[2, 1]);
            defFilter.setMaxMin(MaxMin[3, 0], MaxMin[3, 1]);
            fuelFilter.setMaxMin(MaxMin[4, 0], MaxMin[4, 1]);
            hardAFilter.setMaxMin(MaxMin[5, 0], MaxMin[5, 1]);
            hardFilter.setMaxMin(MaxMin[6, 0], MaxMin[6, 1]);
            pirFilter.setMaxMin(MaxMin[7, 0], MaxMin[7, 1]);
            relFilter.setMaxMin(MaxMin[8, 0], MaxMin[8, 1]);
            softAFilter.setMaxMin(MaxMin[9, 0], MaxMin[9, 1]);
            speedFilter.setMaxMin(MaxMin[10, 0], MaxMin[10, 1]);
            this.Refresh();
        }

        private void Filter_Tanks_Button_Click(object sender, EventArgs e)
        {//go through the array of tanks and display only the ones that meet the criteria
            //Stopwatch stopwatch = Stopwatch.StartNew();
            filteredTanks = new List<Tank>();
            string lockName = "Lock";
            Parallel.ForEach(allTanks, tank =>
              {
                //First check the armour and speed to see if you need to add points
                //Armour first coz if affects speed
                if (CheckArmour(ref tank)
                      && CheckSpeed(ref tank)
                      && relFilter.checkVal(tank.Reliability)
                      && brkFilter.checkVal(tank.Breakthrough)
                      && icFilter.checkVal(tank.Build_Cost)
                      && defFilter.checkVal(tank.Defence)
                      && fuelFilter.checkVal(tank.Fuel_Consumption)
                      && hardAFilter.checkVal(tank.HardA)
                      && hardFilter.checkVal(tank.Hardness)
                      && pirFilter.checkVal(tank.Piercing)
                      && softAFilter.checkVal(tank.SoftA)
                      )
                  {
                      lock (lockName)
                      {
                          filteredTanks.Add(tank);
                      }
                  }
              });
            //stopwatch.Stop();
            Console.Beep();
            MessageBox.Show("Filtering Complete, " + filteredTanks.Count.ToString() + " tanks found");
            Tank_Count.Text = filteredTanks.Count.ToString() + " tanks found";
            if (filteredTanks.Count > 0)
            {
                GetStatMinMax(filteredTanks.ToArray());
                if (filteredTanks.Count < 500)
                {
                    displayGridData(filteredTanks);
                }
                else { dataGridView1.Visible = false; }
            }

        }
        bool CheckArmour(ref Tank tank)
        {//First calculate the number of armour points required
            //source for the equation == trust me bro
            Stat armStat = tank.getStatVals(tankData, "armor_value");
            //byte armPt = (byte)(Math.Max(Math.Ceiling(((armFilter.Min / armStat.Add_Val) - (1 + armStat.Mult_Val)) / 0.085),0)); No longer works ;(
            byte armPt = (byte)Math.Max(Math.Ceiling(((armFilter.Min / (armStat.Mult_Val+1)) - armStat.Add_Val) / 2.5), 0);
            //Now see if the number is allowed
            if (armPt<= MaxArmPt.Value)
            {
                //Then calculate the new stats with this value
                tank.ArmPt = armPt;
                tank.SetStats(tankData);
                return true;
            }
            return false;
        }
        bool CheckSpeed(ref Tank tank)
        {//First calculate the number of speed points required
            //source for the equation == trust me bro
            Stat spdStat = tank.getStatVals(tankData, "maximum_speed");
            //byte spdPt = (byte)(Math.Max(Math.Ceiling(((speedFilter.Min / spdStat.Add_Val) - (1 + spdStat.Mult_Val)-(-0.05*tank.ArmPt)) / 0.1),0)); No longer works ;(
            byte spdPt = (byte)Math.Max(Math.Ceiling(((speedFilter.Min / (spdStat.Mult_Val+1)) - (spdStat.Add_Val-tank.ArmPt*0.1)) / 0.1), 0);
            //Now see if the number is allowed
            if (spdPt <= MaxSpdPt.Value)
            {
                //Then calculate the new stats with this value
                tank.EngPt = spdPt;
                tank.SetStats(tankData);
                return true;
            }
            return false;
        }

        private void module_SelectedValueChanged(object sender, EventArgs e)
        {
            updateChassisModules();
        }

        private void maxYear_ValueChanged(object sender, EventArgs e)
        {
            chassisSelect.DataSource = tankData.chassis.Where(c => c.Year < maxYear.Value+1).ToList();
            chassisSelect.Visible = true;
            MaxSpdPt.Value = 4;
            MaxArmPt.Value = 4;
            if (maxYear.Value < 1934)
            {
                MaxSpdPt.Value = 4;
                MaxArmPt.Value = 4;
            }
            else if (maxYear.Value < 1938)
            {
                MaxSpdPt.Value = 9;
                MaxArmPt.Value = 9;
            }
            else if (maxYear.Value < 1941)
            {
                MaxSpdPt.Value = 14;
                MaxArmPt.Value = 14;
            }
            else if (maxYear.Value < 1944)
            {
                MaxSpdPt.Value = 17;
                MaxArmPt.Value = 17;
            }
            else
            {
                MaxSpdPt.Value = 20;
                MaxArmPt.Value = 20;
            }
        }

        private void showCheapest_Click(object sender, EventArgs e)
        {
            displayGridData(filteredTanks.OrderBy(t => t.Build_Cost).Take(100).ToList());
        }
        private void displayGridData(List<Tank> tanks)
        {
            BindingList<NamedTank> namedTanks = new BindingList<NamedTank>();
            //List<NamedTank> namedTanks = new List<NamedTank>();
            foreach (Tank tank in tanks)
            {
                namedTanks.Add(tank.ToNamed(tankData));
            }
            dataGridView1.DataSource = namedTanks;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
            dataGridView1.Visible = true;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}