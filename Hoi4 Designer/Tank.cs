using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoi4_Designer
{
    //This contains all the extra classes used to filter the tanks
    class Tank
    {//This is one tank, its module IDs, and its stats
        public byte ChassisID { get; set; }
        public byte TurretID { get; set; }
        public byte GunID { get; set; }
        public byte SuspensionID { get; set; }
        public byte EngineID { get; set; }
        public byte ArmourID { get; set; }
        public byte Spc1ID { get; set; }
        public byte Spc2ID { get; set; }
        public byte Spc3ID { get; set; }
        public byte Spc4ID { get; set; }
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
            speedPt.Add(new Stat { Name = "maximum_speed", Add_Val = 0.1F });
            speedPt.Add(new Stat { Name = "reliability", Mult_Val = -0.015F });
            speedPt.Add(new Stat { Name = "fuel_consumption", Add_Val = 0.05F });
            speedPt.Add(new Stat { Name = "build_cost_ic", Add_Val = 0.1F });


            List<Stat> armourPt = new List<Stat>();
            armourPt.Add(new Stat { Name = "breakthrough", Add_Val = 1.25F });
            armourPt.Add(new Stat { Name = "maximum_speed", Add_Val = -0.1F });
            armourPt.Add(new Stat { Name = "armor_value", Add_Val = 2.5F });
            armourPt.Add(new Stat { Name = "reliability", Mult_Val = -0.015F });
            armourPt.Add(new Stat { Name = "build_cost_ic", Add_Val = 0.2F });

            List<Stat> stats = new List<Stat>();
            stats.AddRange(tankData.chassis[ChassisID].Stats);
            stats.AddRange(tankData.modules[ArmourID].Stats);
            stats.AddRange(tankData.modules[EngineID].Stats);
            stats.AddRange(tankData.modules[GunID].Stats);
            stats.AddRange(tankData.modules[SuspensionID].Stats);
            stats.AddRange(tankData.modules[TurretID].Stats);
            stats.AddRange(tankData.modules[Spc1ID].Stats);
            stats.AddRange(tankData.modules[Spc2ID].Stats);
            stats.AddRange(tankData.modules[Spc3ID].Stats);
            stats.AddRange(tankData.modules[Spc4ID].Stats);

            List<Stat> modStats = new List<Stat>();
            for (int i = 0; i < Math.Max(EngPt, ArmPt); i++)
            {
                if (i < EngPt) { modStats.AddRange(speedPt); }
                if (i < ArmPt) { modStats.AddRange(armourPt); }
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
            float addVal = curStat.Sum(s => s.Add_Val) + curModStat.Sum(s => s.Add_Val);
            //Now calculate two different multipliers, one for regular stats, and another for mod stats
            float multVal = curStat.Sum(s => s.Mult_Val);
            float modMultVal = curModStat.Sum(s => s.Mult_Val);
            return addVal + (addVal * multVal) + (addVal * modMultVal);
        }
        public Stat getStatVals(Tank_Designer tankData, string statName)
        {
            //Returns the value of a specific stat from a tank.
            Stat newStat = new Stat();

            List<Stat> stats = new List<Stat>();
            stats.AddRange(tankData.chassis[ChassisID].Stats.Where(s => s.Name == statName));
            stats.AddRange(tankData.modules[ArmourID].Stats.Where(s => s.Name == statName));
            stats.AddRange(tankData.modules[EngineID].Stats.Where(s => s.Name == statName));
            stats.AddRange(tankData.modules[GunID].Stats.Where(s => s.Name == statName));
            stats.AddRange(tankData.modules[SuspensionID].Stats.Where(s => s.Name == statName));
            stats.AddRange(tankData.modules[TurretID].Stats.Where(s => s.Name == statName));
            stats.AddRange(tankData.modules[Spc1ID].Stats.Where(s => s.Name == statName));
            stats.AddRange(tankData.modules[Spc2ID].Stats.Where(s => s.Name == statName));
            stats.AddRange(tankData.modules[Spc3ID].Stats.Where(s => s.Name == statName));
            stats.AddRange(tankData.modules[Spc4ID].Stats.Where(s => s.Name == statName));

            newStat.Add_Val = stats.Sum(s => s.Add_Val);
            newStat.Mult_Val = stats.Sum(s => s.Mult_Val);
            return newStat;
        }
        public NamedTank ToNamed(Tank_Designer tankData)
        {
            NamedTank newTank = new NamedTank();
            newTank.Chassis = TrimName(tankData.chassis[ChassisID].Name);
            newTank.Turret = TrimName(tankData.modules[TurretID].Name);
            newTank.Gun = TrimName(tankData.modules[GunID].Name);
            newTank.Suspension = TrimName(tankData.modules[SuspensionID].Name);
            newTank.Engine = TrimName(tankData.modules[EngineID].Name);
            newTank.Armour = TrimName(tankData.modules[ArmourID].Name);
            newTank.Spc1 = TrimName(tankData.modules[Spc1ID].Name);
            newTank.Spc2 = TrimName(tankData.modules[Spc2ID].Name);
            newTank.Spc3 = TrimName(tankData.modules[Spc3ID].Name);
            newTank.Spc4 = TrimName(tankData.modules[Spc4ID].Name);
            newTank.ArmPt = ArmPt;
            newTank.EngPt = EngPt;
            newTank.SoftA = SoftA;
            newTank.HardA = HardA;
            newTank.Arm = Arm;
            newTank.Fuel_Consumption = Fuel_Consumption;
            newTank.Speed = Speed;
            newTank.Build_Cost = Build_Cost;
            newTank.Reliability = Reliability;
            newTank.Hardness = Hardness;
            newTank.Piercing = Piercing;
            newTank.Breakthrough = Breakthrough;
            newTank.Defence = Defence;

            return newTank;
        }
        string TrimName(String oldName)
        {
            string Name = oldName.Replace("tank_", "");
            Name = Name.Replace("_", " ");
            return Name;
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

    class NamedTankList<NamedTank> : BindingList<NamedTank>
    {//Apparently you need to do this to get sorting to work. Why can't it just be simple.
        protected override bool SupportsSortingCore
        {
            get { return true; }
        }
    }

    class ChassisSetup
    {//Contains all the possible modules for a tank
        public string Name { get; set; }
        public Chassis chassis { get; set; }
        public List<Module> turrets { get; set; }
        public List<Module> guns { get; set; }
        public List<Module> suspension { get; set; }
        public List<Module> engines { get; set; }
        public List<Module> armours { get; set; }
        public List<Module> specials { get; set; }

    }
}
