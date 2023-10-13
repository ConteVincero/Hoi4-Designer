using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Hoi4_Designer
{
    class Tank_Designer
    {
        public List<Module> modules;
        public List<Chassis> chassis = new List<Chassis>();
        public List<Chassis> archtypes = new List<Chassis>();

        public Tank_Designer()
        {
            modules = GetModules();
            GetChassis();
            setYears();
        }
        public List<Module> GetModules()
        {
            //string Module_File = Hoi4_Designer.Properties.Resources.GamePath + "common/units/equipment/modules/00_tank_modules.txt";
            string Module_File = FileLocation.installLocation + "common/units/equipment/modules/00_tank_modules.txt";
            //Parse the Module File
            StreamReader Modulereader = File.OpenText(Module_File);
            string Line;
            List<Module> Modules = new List<Module>();
            Module newModule = new Module("Empty");
            Modules.Add(newModule);
            while ((Line = Modulereader.ReadLine()) != null)
            {
                //Check if it's the start of a new class
                if (Line.IndexOf("{")!= -1 && Line.Substring(0, 1) == "\t" && Line.Substring(1, 1) != "\t")
                {
                    //Start reading the data
                    Module New_Module = new Module();
                    New_Module.Limit = -1;
                    New_Module.Name = Break_Line(Line).Name;
                    while ((Line = Remove_Tabs(Modulereader.ReadLine())) != "}")
                    {
                        try
                        {
                            switch (Break_Line(Line).Name)
                            {
                                case "abbreviation":
                                    New_Module.Abbreviation = Break_Line(Line).Stringval;
                                    break;
                                case "category":
                                    New_Module.Category = Break_Line(Line).Stringval;
                                    break;
                                case "xp_cost":
                                    New_Module.XP_Cost = int.Parse(Break_Line(Line).Stringval);
                                    break;
                                case "add_stats":
                                    while ((Line = Remove_Tabs(Modulereader.ReadLine())) != "}")
                                    {
                                        split_Line break_ = Break_Line(Line);
                                        if (break_.Name != "")
                                        {
                                            New_Module.Stats.Add(new Stat
                                            {
                                                Name = Break_Line(Line).Name,
                                                Add_Val = float.Parse(Break_Line(Line).Stringval)
                                            });
                                        }
                                    }
                                    break;
                                case "multiply_stats":
                                    if (!Break_Line(Line).Stringval.Contains("}"))
                                    {
                                        while ((Line = Remove_Tabs(Modulereader.ReadLine())) != "}")
                                        {
                                            split_Line break_ = Break_Line(Line);
                                            if (break_.Name != "")
                                            {
                                                New_Module.Stats.Add(new Stat
                                                {
                                                    Name = Break_Line(Line).Name,
                                                    Mult_Val = float.Parse(Break_Line(Line).Stringval)
                                                });
                                            }
                                        }
                                    }
                                    break;
                                case "allowed_module_categories":
                                    if (!Break_Line(Line).Stringval.Contains("}"))
                                    {
                                        while ((Line = Remove_Tabs(Modulereader.ReadLine())) != "}")
                                        {//First get the slot name
                                            split_Line split = Break_Line(Line);
                                            if (split.Stringval == "{")
                                            {
                                                Slot slot = new Slot();
                                                slot.Name = split.Name;
                                                while ((Line = Remove_Tabs(Modulereader.ReadLine())) != "}")
                                                {
                                                    slot.Allowed.Add(Line);
                                                }
                                                New_Module.Allowed.Add(slot);
                                            }
                                        }
                                    }
                                    break;
                                default:
                                    {
                                        if (Line.Contains("{") && !Line.Contains("}"))
                                        {
                                            while ((Line = Remove_Tabs(Modulereader.ReadLine())) != "}") { }
                                        }
                                        break;
                                    }
                            }
                        }
                        catch { }
                    }
                    if (New_Module.Abbreviation != "")
                    {
                        New_Module.ID = Modules.Count();
                        Modules.Add(New_Module);
                    }
                }

            }
            string Chassis_File = FileLocation.installLocation + "common/units/equipment/tank_chassis.txt";
            //Parse the Chassis file to get the limits
            StreamReader Chassis_reader = File.OpenText(Chassis_File);
            while ((Line = Chassis_reader.ReadLine()) != null)
            { 
                if (Break_Line(Line).Name == "module_count_limit")
                {//If the line is a module count limit, then the next two lines will have the module name and the limits
                    string Mod_Name = Break_Line(Chassis_reader.ReadLine()).Stringval;
                    Line = Chassis_reader.ReadLine();
                    int Limit;
                    if (int.TryParse(Break_Line(Line).Stringval,out Limit) == true)
                    {
                        foreach(Module module in Modules.Where(m => m.Category == Mod_Name || m.Name == Mod_Name))
                        {
                            module.Limit = Math.Max(Limit - 1, module.Limit);
                        }
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Unable to Parse: " + Break_Line(Line).Stringval);
                    }
                }
            }
            //Now set all untouched modules to limit 999
            foreach (Module module1 in Modules.Where(m => m.Limit == -1))
            {
                module1.Limit = 999;
            }
            return Modules;
        }

        public void GetChassis()
        {// Go through the chassis file and create a list of all the chassis
            string Chassis_File = FileLocation.installLocation + "common/units/equipment/tank_chassis.txt";
            //Parse the Chassis file to get the limits
            StreamReader Chassis_reader = File.OpenText(Chassis_File);
            string Line;
            int level = 0;
            while ((Line = Chassis_reader.ReadLine()) != null)
            {
                if (Break_Line(Line).Stringval == "{" && Break_Line(Line).Name != "equipments")
                {
                    //Now go line by line through the equpiment adding its stats to the equipment entry
                    Chassis newChassis = new Chassis();
                    newChassis.Name = Break_Line(Line).Name;
                    while ((Line = Remove_Tabs(Chassis_reader.ReadLine())) != "}")
                    {
                        split_Line split = Break_Line(Line);
                        switch (split.Name)
                        {
                            case "year":
                                //newChassis.Year = Convert.ToInt32(split.Stringval);
                                break;
                            case "is_archetype":
                                newChassis.Archtype = split.Stringval == "yes";
                                break;
                            case "abbreviation":
                                newChassis.Abbreviation = split.Stringval;
                                break;
                            case "archetype":
                                newChassis.ArchName = split.Stringval;
                                break;
                            case "module_slots":
                                if (split.Stringval != "inherit")
                                {
                                    while ((Line = Remove_Tabs(Chassis_reader.ReadLine())) != "}")
                                    {//If it's a module shot, then go and see if it's required, and what modules will fit
                                        split_Line SlotSplit = Break_Line(Line);
                                        if (SlotSplit.Name != "")
                                        {
                                            Slot slot = SetSlots(Chassis_reader);
                                            slot.Name = SlotSplit.Name;
                                            newChassis.slots.Add(slot);
                                        }
                                    }
                                }
                                else
                                {//If this is not an archtype, then copy the stats over
                                    List<Stat> newStats = archtypes.Find(m => m.Name == newChassis.ArchName).Stats;
                                    newChassis.Stats = newStats.ConvertAll(s => s.Clone());
                                }
                                break;
                            case "fuel_consumption": 
                            case "maximum_speed":
                            case "build_cost_ic":
                            case "reliability":
                            case "hardness":
                            case "armor_value":
                                //check to see if there is a stat with that name and overrite it, otherwise add it
                                int pos = newChassis.Stats.FindIndex(s => s.Name == split.Name);
                                if (pos == -1)
                                {
                                    newChassis.Stats.Add(new Stat
                                    {
                                        Name = split.Name,
                                        Add_Val = float.Parse(split.Stringval)
                                    });
                                }
                                else
                                {
                                    newChassis.Stats[pos].Add_Val = float.Parse(split.Stringval);
                                }
                                break;
                            default:
                                if (split.Stringval == "{")
                                {
                                    int level2 = 0;
                                    while ((Line = Remove_Tabs(Chassis_reader.ReadLine())) != "}" || level2 != 0)
                                    {
                                        split_Line split1 = Break_Line(Line);
                                        if (Line == "}")
                                        {
                                            level2--;
                                        }
                                        else if (split1.Stringval == "{")
                                        {
                                            level2++;
                                        }
                                    }
                                }
                                break;
                        }
                    }
                    if (newChassis.Archtype)
                    {
                        archtypes.Add(newChassis);
                    }
                    else
                    {
                        newChassis.ID = chassis.Count;
                        newChassis.slots = archtypes.FindLast(m => m.Name == newChassis.ArchName).slots;
                        chassis.Add(newChassis);
                    }
                }
            }
        }
        void setYears()
        {//Go through the research files and update the year scores for chassis and modules
            string researchDir = FileLocation.installLocation + "common\\technologies";
            DirectoryInfo info = new DirectoryInfo(researchDir);
            foreach(FileInfo file in info.GetFiles())
            {
                //Parse the Chassis file to get the limits
                StreamReader Chassis_reader = File.OpenText(file.FullName);
                string Line;
                string sLine;
                int level = 0;
                List<string> foundChassis = new List<string>();
                List<string> foundModules = new List<string>();
                int year = 1936;
                bool equiptFlag = false;
                bool modFlag = false;
                //Go through line by line to find the information
                while ((sLine = Chassis_reader.ReadLine()) != null)
                {
                    Line = Remove_Tabs(sLine);
                    //Debug.WriteLine(Line);
                    if (level == 2)
                    {
                        switch (Line)
                        {
                            case string a when Line.Contains("enable_equipments"):
                                //level++;
                                equiptFlag = true;
                                //while ((Line = Remove_Tabs(Chassis_reader.ReadLine())) != "}")
                                //{
                                //    foundChassis.Add(Line);
                                //}
                                break;
                            case string b when Line.Contains("enable_equipment_modules"):
                                //level++;
                                modFlag = true;
                                //while ((Line = Remove_Tabs(Chassis_reader.ReadLine())) != "}")
                                //{
                                //    foundModules.Add(Line);
                                //}
                                break;
                            case string c when Line.Contains("start_year"):
                                year = int.Parse(Break_Line(Line).Stringval);
                                break;
                        }
                    }
                    if (Line.Contains('{') || Line.Contains("}"))
                    {
                        if (Line.Contains('{'))
                        {
                            level++;
                            if (level == 2)
                            {
                                year = 1936;
                                foundChassis.Clear();
                                foundModules.Clear();
                            }
                        }
                        if (Line.Contains("}"))
                        {
                            level--;
                            if (level == 1)
                            {
                                foreach (Chassis chassis in chassis.Where(c => foundChassis.Contains(c.Name)))
                                {
                                    chassis.Year = Math.Min(chassis.Year, year);
                                }
                                foreach (Module module in modules.Where(c => foundModules.Contains(c.Name)))
                                {
                                    module.Year = Math.Min(module.Year, year);
                                }
                            }
                            if(level == 2)
                            {
                                equiptFlag = false;
                                modFlag = false;
                            }
                        }
                    }
                    else if (level == 3)
                    {
                        if (equiptFlag)
                        {
                            foundChassis.Add(Line);
                        }
                        if (modFlag)
                        {
                            foundModules.Add(Line);
                        }
                    }
                }
            }
        }
        Slot SetSlots(StreamReader Chassis_reader)
        {//Goes through the slot and sets what can be added to it.
            string Line;
            Slot slot = new Slot();
            while ((Line = Remove_Tabs(Chassis_reader.ReadLine())) != "}")
            {
                split_Line split = Break_Line(Line);
                switch (split.Name)
                {
                    case "required":
                        slot.Required = split.Stringval == "yes";
                        break;
                    case "allowed_module_categories":
                        while ((Line = Remove_Tabs(Chassis_reader.ReadLine())) != "}")
                        {
                            //Line = Remove_Tabs(Chassis_reader.ReadLine());
                            slot.Allowed.Add(Line);
                        }
                        break;
                }
            }
            return slot;
        }
        split_Line Break_Line (string Line)
        {// Breaks up a line from a Paradox file into parts before and after the = sign
            //first remove any comments
            Line = (Line.Split('#'))[0];
            string[] Parts = Line.Split('=','<','>');
            split_Line Line_parts = new split_Line();
            Line_parts.Name = Parts[0].Trim();
            if (Parts.Length > 1)
            {
                Line_parts.Stringval = (Parts[1].Replace("\t", "")).Trim(new char[]{' ','"'});
            }            
            return Line_parts;
        }
        class split_Line
        {
            public string Name;
            public string Stringval;
        }
        string Remove_Tabs(string text)
        {
            if (text is null)
            {
                return "";
            }
            else
            {
                return text.Replace("\t", "");
            }
        }
    }
    [DebuggerDisplay("{Name,nq}")]
    class Chassis
    {//Basic Chassis
        public int ID { get; set; }
        public string Abbreviation { get; set; }
        public string Name { get; set; }
        public int Year { get; set; } = 1950;
        public bool Archtype { get; set; }
        public string ArchName { get; set; }
        public List<Stat> Stats { get; set; } = new List<Stat>();
        public List<Slot> slots { get; set; } = new List<Slot>();
    }
    [DebuggerDisplay("{Name,nq}")]
    class Slot
    {
        public string Name { get; set; }
        public bool Required { get; set; }
        public List<string> Allowed { get; set; } = new List<string>();
        public List<Module> modules { get; set; } = new List<Module>();
        public List<Module> GetModules(List<Module> modules,List<Slot> slots,int maxYear)
        {//Select all the modules that are allowed in a slot
            List<Module> slotModules = new List<Module>();
            foreach (Module module in modules) 
            { 
                if (Allowed.Contains(module.Category) && module.Year <= maxYear)
                {//If the module is allowed, modify the allowed module in other slots. This is for things like special guns in turrets
                    foreach(Slot slot in module.Allowed)
                    {//Find the slot in the list
                        Slot mainSlot = slots.Find(m => m.Name == slot.Name);
                        foreach(string newAllowed in slot.Allowed)
                        {
                            if (!mainSlot.Allowed.Contains(newAllowed))
                            {
                                mainSlot.Allowed.Add(newAllowed);
                            }
                        }
                    }
                    //Then add the module to the list
                    slotModules.Add(module);
                }
            }
            if (!Required)
            {
                slotModules.Add(modules.Find(m => m.Name == "Empty"));
            }
            return slotModules;
        }
    }
    [DebuggerDisplay("{Name,nq}{Limit}")]
    class Module
    {
        public int ID { get; set; }
        public string Name { get; set; } = "";
        public string Abbreviation { get; set; } = "";
        public string Category { get; set; } = "";
        public List<Stat> Stats { get; set; } = new List<Stat>();
        public int Limit { get; set; }
        public int XP_Cost { get; set; }
        public List<Slot> Allowed { get; set; } = new List<Slot>();
        public int Year { get; set; } = 1950;


        public Module()
        {
            ID = 0;
            Name = "";
            Abbreviation = "";
            Category = "";
            Limit = 0;
            XP_Cost = 0;
        }
        public Module(string name)
        {
            ID = 0;
            Name = name;
            Abbreviation = "";
            Category = "";
            Limit = 999;
            XP_Cost = 0;
        }
        public Module Clone()
        {
            return new Module
            {
                ID = ID,
                Name = Name,
                Abbreviation = Abbreviation,
                Category = Category,
                Stats = Stats,
                Limit = Limit,
                XP_Cost = XP_Cost,
                Year = Year
            };
        }
    }

    public interface ICloneable<T>
    {
        T Clone();
    }

    [DebuggerDisplay("{Name,nq} {Add_Val} {Mult_Val}")]
    public class Stat
    {
        public string Name { get; set; }
        public float Add_Val { get; set; }
        public float Mult_Val { get; set; }

        public Stat Clone()
        {
            Stat newCopy = new Stat();
            newCopy.Name = Name;
            newCopy.Add_Val = Add_Val;
            newCopy.Mult_Val = Mult_Val;
            return newCopy;
        }
    }
}
