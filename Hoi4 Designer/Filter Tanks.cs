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

namespace Hoi4_Designer
{
    public partial class Filter_Tanks : Form
    {
        Tank_Designer tankData = new Tank_Designer();
        Tank[] allTanks;
        bool isUpdating = false;
        public Filter_Tanks()
        {
            InitializeComponent();
            chassisSelect.DisplayMember = "Name";
            chassisSelect.ValueMember = null;
            chassisSelect.DataSource = tankData.chassis;
            chassisList.DisplayMember = "Name";
            chassisList.ValueMember = null;
            foreach (ListBox listBox in tableLayoutPanel1.Controls.OfType<ListBox>())
            {
                listBox.DisplayMember = "Name";
                listBox.ValueMember = null;
            }
        }

        private void Filter_Tanks_Load(object sender, EventArgs e)
        {
        }

        private void addChassis_Click(object sender, EventArgs e)
        {
            ChassisSetup newChassis = new ChassisSetup();
            newChassis.chassis = (Chassis)chassisSelect.SelectedItem;
            newChassis.Name = newChassis.chassis.Name;
            chassisList.Items.Add(newChassis);
        }

        private void chassisList_SelectedIndexChanged_1(object sender, EventArgs e)
        {//Fill out the module selections
            ChassisSetup setup = (ChassisSetup)chassisList.SelectedItem;
            Chassis curChassis = setup.chassis;
            isUpdating = true;
            turretSelect.DataSource = curChassis.slots[1].GetModules(tankData.modules, (curChassis.slots),(int)maxYear.Value);
            gunSelect.DataSource = curChassis.slots[0].GetModules(tankData.modules, (curChassis.slots), (int)maxYear.Value);
            suspensionSelect.DataSource = curChassis.slots[2].GetModules(tankData.modules, (curChassis.slots), (int)maxYear.Value);
            armourSelect.DataSource = curChassis.slots[3].GetModules(tankData.modules, (curChassis.slots), (int)maxYear.Value);
            engineSelect.DataSource = curChassis.slots[4].GetModules(tankData.modules, (curChassis.slots), (int)maxYear.Value);
            specialSelect.DataSource = curChassis.slots[5].GetModules(tankData.modules, (curChassis.slots), (int)maxYear.Value);
            foreach (ListBox listBox in tableLayoutPanel1.Controls.OfType<ListBox>())
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
                chassis[i] = setup.chassis.ID;
                suspensions[i] = setup.suspension.Select(m => m.ID).ToArray();
                armours[i] = setup.armours.Select(m => m.ID).ToArray();
                engines[i] = setup.engines.Select(m => m.ID).ToArray();

                //Create the array for the turret& gun combos
                turretGuns[i] = TurretGuns(turretSelect.SelectedItems.Cast<Module>().ToList(), gunSelect.SelectedItems.Cast<Module>().ToList(), (Chassis)chassisSelect.SelectedItem);
                // Create the array for the special slots
                specialMax[i] = 0;
                byte[,] specialCodes = SpecialModules(specialSelect.SelectedItems.Cast<Module>().ToList(), new byte[99999, 4], 4, ref specialMax[i]);
                specials[i] = new byte[specialMax[i], 4];
                for (int j = 0; j < specialMax[i]; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        specials[i][j, k] = specialCodes[j, k];
                    }
                }
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
                                        Chassis = (byte)chassis[c],
                                        Turret = (byte)turretGuns[c][g, 0],
                                        Gun = (byte)turretGuns[c][g, 1],
                                        Suspension = (byte)suspensions[c][s],
                                        Armour = (byte)armours[c][a],
                                        Engine = (byte)engines[c][en],
                                        Spc1 = specials[c][sp, 0],
                                        Spc2 = specials[c][sp, 1],
                                        Spc3 = specials[c][sp, 2],
                                        Spc4 = specials[c][sp, 3]
                                    };
                                    allTanks[p].SetStats(tankData);
                                    p++;
                                }
                            }
                        }
                    }
                }
            }
            Tank_Count.Visible = true;
            Tank_Count.Text = maxTanks.ToString() + " tanks found";
            GetStatMinMax(allTanks);
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

            List<Tank> filteredTanks = new List<Tank>();
            Parallel.ForEach(allTanks, tank =>
              {
                //First check the armour and speed to see if you need to add points
                //Armour first coz if affects speed
                if (UpdateArmour(ref tank)
                      && UpdateSpeed(ref tank)
                      && brkFilter.checkVal(tank.Breakthrough)
                      && icFilter.checkVal(tank.Build_Cost)
                      && defFilter.checkVal(tank.Defence)
                      && fuelFilter.checkVal(tank.Fuel_Consumption)
                      && hardAFilter.checkVal(tank.HardA)
                      && hardFilter.checkVal(tank.Hardness)
                      && pirFilter.checkVal(tank.Piercing)
                      && relFilter.checkVal(tank.Reliability)
                      && softAFilter.checkVal(tank.SoftA)
                      )
                  {
                      filteredTanks.Add(tank);
                  }
              });
            MessageBox.Show("Filtering Complete");
            Tank_Count.Text = filteredTanks.Count.ToString() + " tanks found";
            if (filteredTanks.Count > 0)
            {
                GetStatMinMax(filteredTanks.ToArray());
                if (filteredTanks.Count < 100)
                {
                    List<NamedTank> namedTanks = new List<NamedTank>();
                    foreach(Tank tank in filteredTanks)
                    {
                        namedTanks.Add(tank.ToNamed(tankData));
                    }
                    dataGridView1.DataSource = namedTanks;
                    foreach(DataGridViewColumn column in dataGridView1.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.Automatic;
                    }
                }
            }

        }
        bool UpdateArmour(ref Tank tank)
        {
            while (tank.Arm < armFilter.Min)
            {
                byte orgPt = tank.ArmPt;
                tank.ArmPt++;
                if (tank.ArmPt > MaxArmPt.Value)
                {
                    tank.ArmPt = orgPt;
                    tank.SetStats(tankData);
                    return false;
                }
                tank.SetStats(tankData);
            }
            return true;

        }
        bool UpdateSpeed(ref Tank tank)
        {
            while (tank.Speed < speedFilter.Min)
            {
                byte orgPt = tank.EngPt;
                tank.EngPt++;
                if (tank.EngPt > MaxArmPt.Value)
                {
                    tank.EngPt = orgPt;
                    tank.SetStats(tankData);
                    return false;
                }
                tank.SetStats(tankData);
            }
            return true;
        }


        class Tank
        {//This is one tank, its module IDs, and its stats
            public byte Chassis { get; set; }
            public byte Turret { get; set; }
            public byte Gun { get; set; }
            public byte Suspension { get; set; }
            public byte Engine { get; set; }
            public byte Armour { get; set; }
            public byte Spc1 { get; set; }
            public byte Spc2 { get; set; }
            public byte Spc3 { get; set; }
            public byte Spc4 { get; set; }
            public byte EngPt { get; set; }
            public byte ArmPt { get; set; }
            //Now the Stats
            public float SoftA { get; set; }
            public float HardA { get; set; }
            public float Arm { get; set; }
            public float Fuel_Consumption { get; set; }
            public float Speed { get; set; }
            public float Build_Cost { get; set; }
            public float Reliability { get; set; }
            public float Hardness { get; set; }
            public float Piercing { get; set; }
            public float Breakthrough { get; set; }
            public float Defence { get; set; }

            public void SetStats(Tank_Designer tankData)
            {//calculate the stats for a specific tank

                List<Stat> speedPt = new List<Stat>();
                speedPt.Add(new Stat { Name = "maximum_speed", Mult_Val = 0.1F });
                speedPt.Add(new Stat { Name = "reliability", Mult_Val = -0.015F });
                speedPt.Add(new Stat { Name = "fuel_consumption", Add_Val = 0.05F });
                speedPt.Add(new Stat { Name = "build_cost_ic", Add_Val = 0.1F });


                List<Stat> armourPt = new List<Stat>();
                armourPt.Add(new Stat { Name = "breakthrough", Add_Val = 1.2F });
                armourPt.Add(new Stat { Name = "maximum_speed", Mult_Val = -0.05F });
                armourPt.Add(new Stat { Name = "armor_value", Mult_Val = 0.085F });
                armourPt.Add(new Stat { Name = "reliability", Mult_Val = -0.015F });
                armourPt.Add(new Stat { Name = "build_cost_ic", Add_Val = 0.2F });

                List<Stat> stats = new List<Stat>();
                stats.AddRange(tankData.chassis[Chassis].Stats);
                stats.AddRange(tankData.modules[Armour].Stats);
                stats.AddRange(tankData.modules[Engine].Stats);
                stats.AddRange(tankData.modules[Gun].Stats);
                stats.AddRange(tankData.modules[Suspension].Stats);
                stats.AddRange(tankData.modules[Turret].Stats);
                stats.AddRange(tankData.modules[Spc1].Stats);
                stats.AddRange(tankData.modules[Spc2].Stats);
                stats.AddRange(tankData.modules[Spc3].Stats);
                stats.AddRange(tankData.modules[Spc4].Stats);

                List<Stat> modStats = new List<Stat>();
                for (int i = 0; i < Math.Max(EngPt, ArmPt); i++)
                {
                    if (i < EngPt) { modStats.AddRange(speedPt); }
                    if (i < ArmPt){ modStats.AddRange(armourPt); }
                }
                SoftA = sumStat(stats, modStats, "soft_attack");
                Arm = sumStat(stats, modStats, "armor_value");
                Breakthrough = sumStat(stats, modStats, "breakthrough");
                Build_Cost = sumStat(stats, modStats, "build_cost_ic");
                Defence = sumStat(stats, modStats, "defense");
                Fuel_Consumption = sumStat(stats, modStats, "fuel_consumption");
                HardA = sumStat(stats, modStats, "hard_attack");
                Hardness = sumStat(stats, modStats, "hardness");
                Piercing = sumStat(stats, modStats, "ap_attack");
                Reliability = sumStat(stats, modStats, "reliability");
                Speed = sumStat(stats, modStats, "maximum_speed");
            }
            static float sumStat(List<Stat> stats, List<Stat> modStats, string name)
            {//Returns the value of a stat with a given name
                List<Stat> curStat = stats.FindAll(s => s.Name.Contains(name));
                List<Stat> curModStat = modStats.FindAll(s => s.Name.Contains(name));
                //First add all the addittives
                float addVal = curStat.Sum(s => s.Add_Val) + curModStat.Sum(s=> s.Add_Val);
                //Now calculate two different multipliers, one for regular stats, and another for mod stats
                float multVal = curStat.Sum(s => s.Mult_Val);
                float modMultVal = curModStat.Sum(s => s.Mult_Val);
                return addVal + (addVal * multVal) + (addVal * modMultVal );
            }
            public NamedTank ToNamed(Tank_Designer tankData)
            {
                NamedTank newTank = new NamedTank();
                newTank.Chassis = tankData.chassis[Chassis].Name; 
                newTank.Turret = tankData.modules[Turret].Name;
                newTank.Gun = tankData.modules[Gun].Name;
                newTank.Suspension = tankData.modules[Suspension].Name;
                newTank.Engine = tankData.modules[Engine].Name;
                newTank.Armour = tankData.modules[Armour].Name;
                newTank.Spc1 = tankData.modules[Spc1].Name;
                newTank.Spc2 = tankData.modules[Spc2].Name;
                newTank.Spc3 = tankData.modules[Spc3].Name;
                newTank.Spc4 = tankData.modules[Spc4].Name;
                newTank.ArmPt = ArmPt;
                newTank.EngPt = EngPt;
                newTank.SoftA = SoftA;
                newTank.HardA = HardA;
                newTank.Arm = Arm;
                newTank.Fuel_Consumption=Fuel_Consumption;
                newTank.Speed = Speed;
                newTank.Build_Cost = Build_Cost;
                newTank.Reliability = Reliability;
                newTank.Hardness = Hardness;
                newTank.Piercing = Piercing;
                newTank.Breakthrough = Breakthrough;
                newTank.Defence = Defence;

                return newTank;
            }
        }
        class NamedTank
        {//Similar to Tank, but with names. Used for Display Only
            public string Chassis { get; set; }
            public string Turret { get; set; }
            public string Gun { get; set; }
            public string Suspension { get; set; }
            public string Engine { get; set; }
            public string Armour { get; set; }
            public string Spc1 { get; set; }
            public string Spc2 { get; set; }
            public string Spc3 { get; set; }
            public string Spc4 { get; set; }
            public byte EngPt { get; set; }
            public byte ArmPt { get; set; }
            //Now the Stats
            public float SoftA { get; set; }
            public float HardA { get; set; }
            public float Arm { get; set; }
            public float Fuel_Consumption { get; set; }
            public float Speed { get; set; }
            public float Build_Cost { get; set; }
            public float Reliability { get; set; }
            public float Hardness { get; set; }
            public float Piercing { get; set; }
            public float Breakthrough { get; set; }
            public float Defence { get; set; }

        }

        class ChassisSetup
        {//Contains all the possible modules for a tank
            public string Name { get; set; }
            public Chassis chassis { get; set; }
            public List<Module> turrets { get; set; }
            public List<Module> guns { get; set; }
            public List<Module> suspension { get; set; }
            public List<Module> engines{ get; set; }
            public List<Module> armours { get; set; }
            public List<Module> specials { get; set; }

        }

        private void module_SelectedValueChanged(object sender, EventArgs e)
        {
            updateChassisModules();
        }

        private void maxYear_ValueChanged(object sender, EventArgs e)
        {
            chassisSelect.DataSource = tankData.chassis.Where(c => c.Year < maxYear.Value+1).ToList();
        }
    }
}