using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hoi4_Designer
{
    public partial class Form1 : Form
    {
        List<Label> labels = new List<Label>();
        List<ComboBox> slotSelect = new List<ComboBox>();
        Tank_Designer tank;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tank = new Tank_Designer();
            tank.modules = tank.GetModules();
            tank.GetChassis();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = null;
            comboBox1.DataSource = tank.chassis;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Chassis chassis = (Chassis)comboBox1.SelectedItem;
            for(int i = 0; i<chassis.slots.Count;i++)
            {//Add the controls for these displays
                if (i>= slotSelect.Count)
                {
                    Label newLabel = new Label();
                    newLabel.Location = new Point { X = 50, Y = 50 * i + 50 };
                    newLabel.Width = 200;
                    newLabel.Height = 20;
                    this.Controls.Add(newLabel);
                    ComboBox comboBox = new ComboBox();
                    comboBox.Location = new Point { X = 50, Y = 50 * i + 70 };
                    comboBox.Width = 300;
                    this.Controls.Add(comboBox);
                    labels.Add(newLabel);
                    slotSelect.Add(comboBox);
                }
                labels[i].Text = chassis.slots[i].Name;
                slotSelect[i].DisplayMember = "Name";
                slotSelect[i].ValueMember = null;
                slotSelect[i].DataSource = chassis.slots[i].GetModules(tank.modules,chassis.slots, 2000);
            }

        }
        List<NamedVal> getStats()
        {
            //Gets a list of all the stats and their value
            //Gets all the stats from the chassis & Modules
            List<Stat> stats = new List<Stat>();
            List<NamedVal> vals = new List<NamedVal>();
            stats.AddRange(((Chassis)comboBox1.SelectedItem).Stats);
            foreach (ComboBox module in slotSelect)
            {
                stats.AddRange(((Module)module.SelectedItem).Stats);
            }
            //Now get the types of stat present
            List<String> names = stats.Select(s => s.Name).Distinct().ToList();
            //Now go through each value, and do the maths
            foreach (string name in names)
            {
                NamedVal val = new NamedVal();
                val.Name = name;
                //Get a list of Stats with that name
                List<Stat> curStat = stats.FindAll(s => s.Name.Contains(name));
                float addVal = curStat.Sum(s => s.Add_Val);
                float multVal = curStat.Sum(s => s.Mult_Val);
                val.Val = addVal * (multVal + 1);
                vals.Add(val);
            }
            return vals;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = getStats();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void filterTanksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Filter_Tanks filter_Tanks = new Filter_Tanks();
            filter_Tanks.Show();
        }
    }
    struct NamedVal
    {
        public string Name { get; set; }
        public float Val { get; set; }
    }
}
