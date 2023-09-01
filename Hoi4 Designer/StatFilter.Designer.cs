
namespace Hoi4_Designer
{
    partial class StatFilter
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.maxActive = new System.Windows.Forms.CheckBox();
            this.maxVal = new System.Windows.Forms.NumericUpDown();
            this.minVal = new System.Windows.Forms.NumericUpDown();
            this.minActive = new System.Windows.Forms.CheckBox();
            this.maxDisp = new System.Windows.Forms.Label();
            this.minDisp = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.maxVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minVal)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(3, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Max";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Min";
            // 
            // maxActive
            // 
            this.maxActive.AutoSize = true;
            this.maxActive.Location = new System.Drawing.Point(6, 29);
            this.maxActive.Name = "maxActive";
            this.maxActive.Size = new System.Drawing.Size(48, 17);
            this.maxActive.TabIndex = 3;
            this.maxActive.Text = "Filter";
            this.maxActive.UseVisualStyleBackColor = true;
            this.maxActive.CheckedChanged += new System.EventHandler(this.maxActive_CheckedChanged);
            // 
            // maxVal
            // 
            this.maxVal.DecimalPlaces = 1;
            this.maxVal.Location = new System.Drawing.Point(68, 29);
            this.maxVal.Name = "maxVal";
            this.maxVal.Size = new System.Drawing.Size(47, 20);
            this.maxVal.TabIndex = 4;
            this.maxVal.ValueChanged += new System.EventHandler(this.maxVal_ValueChanged);
            // 
            // minVal
            // 
            this.minVal.DecimalPlaces = 1;
            this.minVal.Location = new System.Drawing.Point(68, 64);
            this.minVal.Name = "minVal";
            this.minVal.Size = new System.Drawing.Size(47, 20);
            this.minVal.TabIndex = 6;
            this.minVal.ValueChanged += new System.EventHandler(this.minVal_ValueChanged);
            // 
            // minActive
            // 
            this.minActive.AutoSize = true;
            this.minActive.Location = new System.Drawing.Point(6, 64);
            this.minActive.Name = "minActive";
            this.minActive.Size = new System.Drawing.Size(48, 17);
            this.minActive.TabIndex = 5;
            this.minActive.Text = "Filter";
            this.minActive.UseVisualStyleBackColor = true;
            this.minActive.CheckedChanged += new System.EventHandler(this.minActive_CheckedChanged);
            // 
            // maxDisp
            // 
            this.maxDisp.AutoSize = true;
            this.maxDisp.Location = new System.Drawing.Point(65, 13);
            this.maxDisp.Name = "maxDisp";
            this.maxDisp.Size = new System.Drawing.Size(27, 13);
            this.maxDisp.TabIndex = 7;
            this.maxDisp.Text = "Max";
            this.maxDisp.Visible = false;
            // 
            // minDisp
            // 
            this.minDisp.AutoSize = true;
            this.minDisp.Location = new System.Drawing.Point(65, 48);
            this.minDisp.Name = "minDisp";
            this.minDisp.Size = new System.Drawing.Size(27, 13);
            this.minDisp.TabIndex = 8;
            this.minDisp.Text = "Max";
            this.minDisp.Visible = false;
            // 
            // StatFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.minDisp);
            this.Controls.Add(this.maxDisp);
            this.Controls.Add(this.minVal);
            this.Controls.Add(this.minActive);
            this.Controls.Add(this.maxVal);
            this.Controls.Add(this.maxActive);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameLabel);
            this.Name = "StatFilter";
            this.Size = new System.Drawing.Size(150, 94);
            this.Load += new System.EventHandler(this.StatFilter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.maxVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minVal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox maxActive;
        private System.Windows.Forms.NumericUpDown maxVal;
        private System.Windows.Forms.NumericUpDown minVal;
        private System.Windows.Forms.CheckBox minActive;
        private System.Windows.Forms.Label maxDisp;
        private System.Windows.Forms.Label minDisp;
    }
}
