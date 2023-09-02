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
    public partial class StatFilter : UserControl
    {
        public bool FilterMax;
        public bool FilterMin;
        public float Max;
        public float Min;
        public StatFilter()
        {
            InitializeComponent();
        }

        private void StatFilter_Load(object sender, EventArgs e)
        {
            nameLabel.Text = Name;
        }

        public bool checkVal(float Val)
        {//Check so see if the value is in range
            return (!FilterMax || Val <= Max) && (!FilterMin || Val >= Min);
        }

        public void setMaxMin(float maxVal, float minVal)
        {
            maxDisp.Text = maxVal.ToString();
            maxDisp.Visible = true;
            minDisp.Text = minVal.ToString();
            minDisp.Visible = true;
        }

        private void maxVal_ValueChanged(object sender, EventArgs e)
        {
            if (FilterMax)
            {
                Max = (float)maxVal.Value;
            }
        }

        private void minVal_ValueChanged(object sender, EventArgs e)
        {
            if (FilterMin)
            {
                Min = (float)minVal.Value;
            }
        }

        private void maxActive_CheckedChanged(object sender, EventArgs e)
        {
            FilterMax = maxActive.Checked;
            if (!FilterMax)
            {
                Max = float.MaxValue;
            }
            else
            {
                Max = (float)maxVal.Value;
            }
        }

        private void minActive_CheckedChanged(object sender, EventArgs e)
        {
            FilterMin = minActive.Checked;
            if (!FilterMin)
            {
                Min = float.MinValue;
            }
            else
            {
                Min = (float)minVal.Value;
            }
        }
    }
}
