
namespace Hoi4_Designer
{
    partial class Filter_Tanks
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.specialSelect = new System.Windows.Forms.ListBox();
            this.engineSelect = new System.Windows.Forms.ListBox();
            this.suspensionSelect = new System.Windows.Forms.ListBox();
            this.armourSelect = new System.Windows.Forms.ListBox();
            this.gunSelect = new System.Windows.Forms.ListBox();
            this.turretSelect = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chassisSelect = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.addChassis = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.chassisList = new System.Windows.Forms.ListBox();
            this.getTanksButton = new System.Windows.Forms.Button();
            this.Tank_Count = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Filter_Tanks_Button = new System.Windows.Forms.Button();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.MaxSpdPt = new System.Windows.Forms.NumericUpDown();
            this.MaxArmPt = new System.Windows.Forms.NumericUpDown();
            this.filterLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.softAFilter = new Hoi4_Designer.StatFilter();
            this.hardAFilter = new Hoi4_Designer.StatFilter();
            this.pirFilter = new Hoi4_Designer.StatFilter();
            this.armFilter = new Hoi4_Designer.StatFilter();
            this.relFilter = new Hoi4_Designer.StatFilter();
            this.speedFilter = new Hoi4_Designer.StatFilter();
            this.brkFilter = new Hoi4_Designer.StatFilter();
            this.defFilter = new Hoi4_Designer.StatFilter();
            this.fuelFilter = new Hoi4_Designer.StatFilter();
            this.icFilter = new Hoi4_Designer.StatFilter();
            this.hardFilter = new Hoi4_Designer.StatFilter();
            this.maxYear = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxSpdPt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxArmPt)).BeginInit();
            this.filterLayoutPanel.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxYear)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Modules";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Turret";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Gun";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.specialSelect, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.engineSelect, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.suspensionSelect, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.armourSelect, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.gunSelect, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.turretSelect, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(330, 603);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // specialSelect
            // 
            this.specialSelect.FormattingEnabled = true;
            this.specialSelect.Location = new System.Drawing.Point(83, 833);
            this.specialSelect.Name = "specialSelect";
            this.specialSelect.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.specialSelect.Size = new System.Drawing.Size(238, 160);
            this.specialSelect.TabIndex = 9;
            this.specialSelect.SelectedValueChanged += new System.EventHandler(this.module_SelectedValueChanged);
            // 
            // engineSelect
            // 
            this.engineSelect.FormattingEnabled = true;
            this.engineSelect.Location = new System.Drawing.Point(83, 667);
            this.engineSelect.Name = "engineSelect";
            this.engineSelect.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.engineSelect.Size = new System.Drawing.Size(238, 160);
            this.engineSelect.TabIndex = 9;
            this.engineSelect.SelectedValueChanged += new System.EventHandler(this.module_SelectedValueChanged);
            // 
            // suspensionSelect
            // 
            this.suspensionSelect.FormattingEnabled = true;
            this.suspensionSelect.Location = new System.Drawing.Point(83, 501);
            this.suspensionSelect.Name = "suspensionSelect";
            this.suspensionSelect.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.suspensionSelect.Size = new System.Drawing.Size(238, 160);
            this.suspensionSelect.TabIndex = 9;
            this.suspensionSelect.SelectedValueChanged += new System.EventHandler(this.module_SelectedValueChanged);
            // 
            // armourSelect
            // 
            this.armourSelect.FormattingEnabled = true;
            this.armourSelect.Location = new System.Drawing.Point(83, 335);
            this.armourSelect.Name = "armourSelect";
            this.armourSelect.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.armourSelect.Size = new System.Drawing.Size(238, 160);
            this.armourSelect.TabIndex = 9;
            this.armourSelect.SelectedValueChanged += new System.EventHandler(this.module_SelectedValueChanged);
            // 
            // gunSelect
            // 
            this.gunSelect.FormattingEnabled = true;
            this.gunSelect.Location = new System.Drawing.Point(83, 169);
            this.gunSelect.Name = "gunSelect";
            this.gunSelect.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.gunSelect.Size = new System.Drawing.Size(238, 160);
            this.gunSelect.TabIndex = 9;
            this.gunSelect.SelectedValueChanged += new System.EventHandler(this.module_SelectedValueChanged);
            // 
            // turretSelect
            // 
            this.turretSelect.FormattingEnabled = true;
            this.turretSelect.Location = new System.Drawing.Point(83, 3);
            this.turretSelect.Name = "turretSelect";
            this.turretSelect.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.turretSelect.Size = new System.Drawing.Size(238, 160);
            this.turretSelect.TabIndex = 9;
            this.turretSelect.SelectedValueChanged += new System.EventHandler(this.module_SelectedValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 830);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Special";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 664);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Engine";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 498);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Suspension";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 332);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Armour";
            // 
            // chassisSelect
            // 
            this.chassisSelect.FormattingEnabled = true;
            this.chassisSelect.Location = new System.Drawing.Point(126, 51);
            this.chassisSelect.Name = "chassisSelect";
            this.chassisSelect.Size = new System.Drawing.Size(112, 21);
            this.chassisSelect.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Chassis";
            // 
            // addChassis
            // 
            this.addChassis.Location = new System.Drawing.Point(244, 51);
            this.addChassis.Name = "addChassis";
            this.addChassis.Size = new System.Drawing.Size(69, 36);
            this.addChassis.TabIndex = 11;
            this.addChassis.Text = "Add To Analysis";
            this.addChassis.UseVisualStyleBackColor = true;
            this.addChassis.Click += new System.EventHandler(this.addChassis_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(316, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Chassis to analyse";
            // 
            // chassisList
            // 
            this.chassisList.FormattingEnabled = true;
            this.chassisList.Location = new System.Drawing.Point(319, 51);
            this.chassisList.Name = "chassisList";
            this.chassisList.Size = new System.Drawing.Size(197, 56);
            this.chassisList.TabIndex = 13;
            this.chassisList.SelectedIndexChanged += new System.EventHandler(this.chassisList_SelectedIndexChanged_1);
            // 
            // getTanksButton
            // 
            this.getTanksButton.Location = new System.Drawing.Point(544, 54);
            this.getTanksButton.Name = "getTanksButton";
            this.getTanksButton.Size = new System.Drawing.Size(89, 36);
            this.getTanksButton.TabIndex = 14;
            this.getTanksButton.Text = "Get all possible Tanks";
            this.getTanksButton.UseVisualStyleBackColor = true;
            this.getTanksButton.Click += new System.EventHandler(this.getTanksButton_Click);
            // 
            // Tank_Count
            // 
            this.Tank_Count.AutoSize = true;
            this.Tank_Count.Location = new System.Drawing.Point(541, 97);
            this.Tank_Count.Name = "Tank_Count";
            this.Tank_Count.Size = new System.Drawing.Size(35, 13);
            this.Tank_Count.TabIndex = 15;
            this.Tank_Count.Text = "label9";
            this.Tank_Count.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(601, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(557, 603);
            this.dataGridView1.TabIndex = 79;
            // 
            // Filter_Tanks_Button
            // 
            this.Filter_Tanks_Button.Location = new System.Drawing.Point(640, 54);
            this.Filter_Tanks_Button.Name = "Filter_Tanks_Button";
            this.Filter_Tanks_Button.Size = new System.Drawing.Size(89, 36);
            this.Filter_Tanks_Button.TabIndex = 80;
            this.Filter_Tanks_Button.Text = "Filter Results";
            this.Filter_Tanks_Button.UseVisualStyleBackColor = true;
            this.Filter_Tanks_Button.Click += new System.EventHandler(this.Filter_Tanks_Button_Click);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(772, 54);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(93, 13);
            this.label43.TabIndex = 91;
            this.label43.Text = "Max Speed Points";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(887, 54);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(95, 13);
            this.label44.TabIndex = 92;
            this.label44.Text = "Max Armour Points";
            // 
            // MaxSpdPt
            // 
            this.MaxSpdPt.Location = new System.Drawing.Point(775, 70);
            this.MaxSpdPt.Name = "MaxSpdPt";
            this.MaxSpdPt.Size = new System.Drawing.Size(43, 20);
            this.MaxSpdPt.TabIndex = 93;
            // 
            // MaxArmPt
            // 
            this.MaxArmPt.Location = new System.Drawing.Point(890, 70);
            this.MaxArmPt.Name = "MaxArmPt";
            this.MaxArmPt.Size = new System.Drawing.Size(43, 20);
            this.MaxArmPt.TabIndex = 94;
            // 
            // filterLayoutPanel
            // 
            this.filterLayoutPanel.Controls.Add(this.softAFilter);
            this.filterLayoutPanel.Controls.Add(this.hardAFilter);
            this.filterLayoutPanel.Controls.Add(this.pirFilter);
            this.filterLayoutPanel.Controls.Add(this.armFilter);
            this.filterLayoutPanel.Controls.Add(this.relFilter);
            this.filterLayoutPanel.Controls.Add(this.speedFilter);
            this.filterLayoutPanel.Controls.Add(this.brkFilter);
            this.filterLayoutPanel.Controls.Add(this.defFilter);
            this.filterLayoutPanel.Controls.Add(this.fuelFilter);
            this.filterLayoutPanel.Controls.Add(this.icFilter);
            this.filterLayoutPanel.Controls.Add(this.hardFilter);
            this.filterLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.filterLayoutPanel.Location = new System.Drawing.Point(339, 3);
            this.filterLayoutPanel.Name = "filterLayoutPanel";
            this.filterLayoutPanel.Size = new System.Drawing.Size(256, 603);
            this.filterLayoutPanel.TabIndex = 106;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.filterLayoutPanel, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.dataGridView1, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(21, 123);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1161, 609);
            this.tableLayoutPanel2.TabIndex = 107;
            // 
            // softAFilter
            // 
            this.softAFilter.Location = new System.Drawing.Point(3, 3);
            this.softAFilter.Name = "softAFilter";
            this.softAFilter.Size = new System.Drawing.Size(121, 94);
            this.softAFilter.TabIndex = 95;
            // 
            // hardAFilter
            // 
            this.hardAFilter.Location = new System.Drawing.Point(3, 103);
            this.hardAFilter.Name = "hardAFilter";
            this.hardAFilter.Size = new System.Drawing.Size(121, 94);
            this.hardAFilter.TabIndex = 96;
            // 
            // pirFilter
            // 
            this.pirFilter.Location = new System.Drawing.Point(3, 203);
            this.pirFilter.Name = "pirFilter";
            this.pirFilter.Size = new System.Drawing.Size(121, 94);
            this.pirFilter.TabIndex = 97;
            // 
            // armFilter
            // 
            this.armFilter.Location = new System.Drawing.Point(3, 303);
            this.armFilter.Name = "armFilter";
            this.armFilter.Size = new System.Drawing.Size(121, 94);
            this.armFilter.TabIndex = 98;
            // 
            // relFilter
            // 
            this.relFilter.Location = new System.Drawing.Point(3, 403);
            this.relFilter.Name = "relFilter";
            this.relFilter.Size = new System.Drawing.Size(121, 94);
            this.relFilter.TabIndex = 99;
            // 
            // speedFilter
            // 
            this.speedFilter.Location = new System.Drawing.Point(3, 503);
            this.speedFilter.Name = "speedFilter";
            this.speedFilter.Size = new System.Drawing.Size(121, 94);
            this.speedFilter.TabIndex = 100;
            // 
            // brkFilter
            // 
            this.brkFilter.Location = new System.Drawing.Point(130, 3);
            this.brkFilter.Name = "brkFilter";
            this.brkFilter.Size = new System.Drawing.Size(121, 94);
            this.brkFilter.TabIndex = 101;
            // 
            // defFilter
            // 
            this.defFilter.Location = new System.Drawing.Point(130, 103);
            this.defFilter.Name = "defFilter";
            this.defFilter.Size = new System.Drawing.Size(121, 94);
            this.defFilter.TabIndex = 102;
            // 
            // fuelFilter
            // 
            this.fuelFilter.Location = new System.Drawing.Point(130, 203);
            this.fuelFilter.Name = "fuelFilter";
            this.fuelFilter.Size = new System.Drawing.Size(121, 94);
            this.fuelFilter.TabIndex = 103;
            // 
            // icFilter
            // 
            this.icFilter.Location = new System.Drawing.Point(130, 303);
            this.icFilter.Name = "icFilter";
            this.icFilter.Size = new System.Drawing.Size(121, 94);
            this.icFilter.TabIndex = 104;
            // 
            // hardFilter
            // 
            this.hardFilter.Location = new System.Drawing.Point(130, 403);
            this.hardFilter.Name = "hardFilter";
            this.hardFilter.Size = new System.Drawing.Size(121, 94);
            this.hardFilter.TabIndex = 105;
            // 
            // maxYear
            // 
            this.maxYear.Location = new System.Drawing.Point(24, 52);
            this.maxYear.Maximum = new decimal(new int[] {
            1945,
            0,
            0,
            0});
            this.maxYear.Minimum = new decimal(new int[] {
            1936,
            0,
            0,
            0});
            this.maxYear.Name = "maxYear";
            this.maxYear.Size = new System.Drawing.Size(45, 20);
            this.maxYear.TabIndex = 108;
            this.maxYear.Value = new decimal(new int[] {
            1936,
            0,
            0,
            0});
            this.maxYear.ValueChanged += new System.EventHandler(this.maxYear_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 109;
            this.label9.Text = "Max Year";
            // 
            // Filter_Tanks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 732);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.maxYear);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.MaxArmPt);
            this.Controls.Add(this.MaxSpdPt);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.Filter_Tanks_Button);
            this.Controls.Add(this.Tank_Count);
            this.Controls.Add(this.getTanksButton);
            this.Controls.Add(this.chassisList);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.addChassis);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chassisSelect);
            this.Controls.Add(this.label1);
            this.Name = "Filter_Tanks";
            this.Text = "Filter_Tanks";
            this.Load += new System.EventHandler(this.Filter_Tanks_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxSpdPt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxArmPt)).EndInit();
            this.filterLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.maxYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox turretSelect;
        private System.Windows.Forms.ListBox specialSelect;
        private System.Windows.Forms.ListBox engineSelect;
        private System.Windows.Forms.ListBox suspensionSelect;
        private System.Windows.Forms.ListBox armourSelect;
        private System.Windows.Forms.ListBox gunSelect;
        private System.Windows.Forms.ComboBox chassisSelect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addChassis;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox chassisList;
        private System.Windows.Forms.Button getTanksButton;
        private System.Windows.Forms.Label Tank_Count;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Filter_Tanks_Button;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.NumericUpDown MaxSpdPt;
        private System.Windows.Forms.NumericUpDown MaxArmPt;
        private StatFilter softAFilter;
        private StatFilter hardAFilter;
        private StatFilter pirFilter;
        private StatFilter armFilter;
        private StatFilter relFilter;
        private StatFilter speedFilter;
        private StatFilter brkFilter;
        private StatFilter defFilter;
        private StatFilter fuelFilter;
        private StatFilter icFilter;
        private StatFilter hardFilter;
        private System.Windows.Forms.FlowLayoutPanel filterLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.NumericUpDown maxYear;
        private System.Windows.Forms.Label label9;
    }
}