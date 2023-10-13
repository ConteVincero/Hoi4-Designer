
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Filter_Tanks));
            this.moduleLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.moduleLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
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
            this.chassisLabel = new System.Windows.Forms.Label();
            this.addChassis = new System.Windows.Forms.Button();
            this.analysisLabel = new System.Windows.Forms.Label();
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
            this.masterLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.filterLabel = new System.Windows.Forms.Label();
            this.maxYear = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.showCheapest = new System.Windows.Forms.Button();
            this.getTanksLabel = new System.Windows.Forms.Label();
            this.filterButtonLabel = new System.Windows.Forms.Label();
            this.cheapestButtonLabel = new System.Windows.Forms.Label();
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
            this.moduleLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxSpdPt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxArmPt)).BeginInit();
            this.filterLayoutPanel.SuspendLayout();
            this.masterLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxYear)).BeginInit();
            this.SuspendLayout();
            // 
            // moduleLabel
            // 
            this.moduleLabel.AutoSize = true;
            this.moduleLabel.Location = new System.Drawing.Point(3, 0);
            this.moduleLabel.MaximumSize = new System.Drawing.Size(300, 30);
            this.moduleLabel.Name = "moduleLabel";
            this.moduleLabel.Size = new System.Drawing.Size(289, 26);
            this.moduleLabel.TabIndex = 0;
            this.moduleLabel.Text = "4. Select the modules that you want to be able to include in your designs for tha" +
    "t chassis";
            this.moduleLabel.Visible = false;
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
            this.label3.Location = new System.Drawing.Point(3, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Gun";
            // 
            // moduleLayoutPanel
            // 
            this.moduleLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.moduleLayoutPanel.AutoScroll = true;
            this.moduleLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.moduleLayoutPanel.ColumnCount = 2;
            this.moduleLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.moduleLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.moduleLayoutPanel.Controls.Add(this.specialSelect, 1, 5);
            this.moduleLayoutPanel.Controls.Add(this.engineSelect, 1, 4);
            this.moduleLayoutPanel.Controls.Add(this.suspensionSelect, 1, 3);
            this.moduleLayoutPanel.Controls.Add(this.armourSelect, 1, 2);
            this.moduleLayoutPanel.Controls.Add(this.gunSelect, 1, 1);
            this.moduleLayoutPanel.Controls.Add(this.turretSelect, 1, 0);
            this.moduleLayoutPanel.Controls.Add(this.label7, 0, 5);
            this.moduleLayoutPanel.Controls.Add(this.label6, 0, 4);
            this.moduleLayoutPanel.Controls.Add(this.label3, 0, 1);
            this.moduleLayoutPanel.Controls.Add(this.label10, 0, 0);
            this.moduleLayoutPanel.Controls.Add(this.label4, 0, 3);
            this.moduleLayoutPanel.Controls.Add(this.label5, 0, 2);
            this.moduleLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.moduleLayoutPanel.Location = new System.Drawing.Point(3, 33);
            this.moduleLayoutPanel.Name = "moduleLayoutPanel";
            this.moduleLayoutPanel.RowCount = 6;
            this.moduleLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.moduleLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.moduleLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.moduleLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.moduleLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.moduleLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.moduleLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.moduleLayoutPanel.Size = new System.Drawing.Size(330, 573);
            this.moduleLayoutPanel.TabIndex = 7;
            this.moduleLayoutPanel.Visible = false;
            // 
            // specialSelect
            // 
            this.specialSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.specialSelect.FormattingEnabled = true;
            this.specialSelect.Location = new System.Drawing.Point(83, 261);
            this.specialSelect.Name = "specialSelect";
            this.specialSelect.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.specialSelect.Size = new System.Drawing.Size(244, 43);
            this.specialSelect.TabIndex = 9;
            this.specialSelect.SelectedValueChanged += new System.EventHandler(this.module_SelectedValueChanged);
            // 
            // engineSelect
            // 
            this.engineSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.engineSelect.FormattingEnabled = true;
            this.engineSelect.Location = new System.Drawing.Point(83, 212);
            this.engineSelect.Name = "engineSelect";
            this.engineSelect.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.engineSelect.Size = new System.Drawing.Size(244, 43);
            this.engineSelect.TabIndex = 9;
            this.engineSelect.SelectedValueChanged += new System.EventHandler(this.module_SelectedValueChanged);
            // 
            // suspensionSelect
            // 
            this.suspensionSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.suspensionSelect.FormattingEnabled = true;
            this.suspensionSelect.Location = new System.Drawing.Point(83, 163);
            this.suspensionSelect.Name = "suspensionSelect";
            this.suspensionSelect.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.suspensionSelect.Size = new System.Drawing.Size(244, 43);
            this.suspensionSelect.TabIndex = 9;
            this.suspensionSelect.SelectedValueChanged += new System.EventHandler(this.module_SelectedValueChanged);
            // 
            // armourSelect
            // 
            this.armourSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.armourSelect.FormattingEnabled = true;
            this.armourSelect.Location = new System.Drawing.Point(83, 114);
            this.armourSelect.Name = "armourSelect";
            this.armourSelect.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.armourSelect.Size = new System.Drawing.Size(244, 43);
            this.armourSelect.TabIndex = 9;
            this.armourSelect.SelectedValueChanged += new System.EventHandler(this.module_SelectedValueChanged);
            // 
            // gunSelect
            // 
            this.gunSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gunSelect.FormattingEnabled = true;
            this.gunSelect.Location = new System.Drawing.Point(83, 65);
            this.gunSelect.Name = "gunSelect";
            this.gunSelect.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.gunSelect.Size = new System.Drawing.Size(244, 43);
            this.gunSelect.TabIndex = 9;
            this.gunSelect.SelectedValueChanged += new System.EventHandler(this.module_SelectedValueChanged);
            // 
            // turretSelect
            // 
            this.turretSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.turretSelect.FormattingEnabled = true;
            this.turretSelect.Location = new System.Drawing.Point(83, 3);
            this.turretSelect.Name = "turretSelect";
            this.turretSelect.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.turretSelect.Size = new System.Drawing.Size(244, 56);
            this.turretSelect.TabIndex = 9;
            this.turretSelect.SelectedValueChanged += new System.EventHandler(this.module_SelectedValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 258);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Special";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Engine";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Suspension";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Armour";
            // 
            // chassisSelect
            // 
            this.chassisSelect.FormattingEnabled = true;
            this.chassisSelect.Location = new System.Drawing.Point(81, 52);
            this.chassisSelect.Name = "chassisSelect";
            this.chassisSelect.Size = new System.Drawing.Size(126, 21);
            this.chassisSelect.TabIndex = 9;
            // 
            // chassisLabel
            // 
            this.chassisLabel.AutoSize = true;
            this.chassisLabel.Location = new System.Drawing.Point(78, 9);
            this.chassisLabel.MaximumSize = new System.Drawing.Size(200, 0);
            this.chassisLabel.Name = "chassisLabel";
            this.chassisLabel.Size = new System.Drawing.Size(185, 26);
            this.chassisLabel.TabIndex = 10;
            this.chassisLabel.Text = "2. Select each Chassis you want and click Add To Analysis";
            // 
            // addChassis
            // 
            this.addChassis.Location = new System.Drawing.Point(213, 51);
            this.addChassis.Name = "addChassis";
            this.addChassis.Size = new System.Drawing.Size(69, 36);
            this.addChassis.TabIndex = 11;
            this.addChassis.Text = "Add To Analysis";
            this.addChassis.UseVisualStyleBackColor = true;
            this.addChassis.Click += new System.EventHandler(this.addChassis_Click);
            // 
            // analysisLabel
            // 
            this.analysisLabel.AutoSize = true;
            this.analysisLabel.Location = new System.Drawing.Point(290, 9);
            this.analysisLabel.MaximumSize = new System.Drawing.Size(200, 0);
            this.analysisLabel.Name = "analysisLabel";
            this.analysisLabel.Size = new System.Drawing.Size(198, 26);
            this.analysisLabel.TabIndex = 12;
            this.analysisLabel.Text = "3. Click on each item in the Analysis List and select the modules";
            this.analysisLabel.Visible = false;
            // 
            // chassisList
            // 
            this.chassisList.FormattingEnabled = true;
            this.chassisList.Location = new System.Drawing.Point(291, 51);
            this.chassisList.Name = "chassisList";
            this.chassisList.Size = new System.Drawing.Size(197, 56);
            this.chassisList.TabIndex = 13;
            this.chassisList.Visible = false;
            this.chassisList.SelectedIndexChanged += new System.EventHandler(this.chassisList_SelectedIndexChanged_1);
            // 
            // getTanksButton
            // 
            this.getTanksButton.Location = new System.Drawing.Point(495, 54);
            this.getTanksButton.Name = "getTanksButton";
            this.getTanksButton.Size = new System.Drawing.Size(89, 36);
            this.getTanksButton.TabIndex = 14;
            this.getTanksButton.Text = "Get all Tanks";
            this.getTanksButton.UseVisualStyleBackColor = true;
            this.getTanksButton.Visible = false;
            this.getTanksButton.Click += new System.EventHandler(this.getTanksButton_Click);
            // 
            // Tank_Count
            // 
            this.Tank_Count.AutoSize = true;
            this.Tank_Count.Location = new System.Drawing.Point(590, 60);
            this.Tank_Count.Name = "Tank_Count";
            this.Tank_Count.Size = new System.Drawing.Size(63, 13);
            this.Tank_Count.TabIndex = 15;
            this.Tank_Count.Text = "tanks found";
            this.Tank_Count.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(601, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(588, 573);
            this.dataGridView1.TabIndex = 79;
            this.dataGridView1.Visible = false;
            // 
            // Filter_Tanks_Button
            // 
            this.Filter_Tanks_Button.Location = new System.Drawing.Point(701, 54);
            this.Filter_Tanks_Button.Name = "Filter_Tanks_Button";
            this.Filter_Tanks_Button.Size = new System.Drawing.Size(89, 36);
            this.Filter_Tanks_Button.TabIndex = 80;
            this.Filter_Tanks_Button.Text = "Filter Results";
            this.Filter_Tanks_Button.UseVisualStyleBackColor = true;
            this.Filter_Tanks_Button.Visible = false;
            this.Filter_Tanks_Button.Click += new System.EventHandler(this.Filter_Tanks_Button_Click);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(3, 39);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(93, 13);
            this.label43.TabIndex = 91;
            this.label43.Text = "Max Speed Points";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(3, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(95, 13);
            this.label44.TabIndex = 92;
            this.label44.Text = "Max Armour Points";
            // 
            // MaxSpdPt
            // 
            this.MaxSpdPt.Location = new System.Drawing.Point(3, 55);
            this.MaxSpdPt.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.MaxSpdPt.Name = "MaxSpdPt";
            this.MaxSpdPt.Size = new System.Drawing.Size(43, 20);
            this.MaxSpdPt.TabIndex = 93;
            this.MaxSpdPt.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // MaxArmPt
            // 
            this.MaxArmPt.Location = new System.Drawing.Point(3, 16);
            this.MaxArmPt.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.MaxArmPt.Name = "MaxArmPt";
            this.MaxArmPt.Size = new System.Drawing.Size(43, 20);
            this.MaxArmPt.TabIndex = 94;
            this.MaxArmPt.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // filterLayoutPanel
            // 
            this.filterLayoutPanel.Controls.Add(this.label44);
            this.filterLayoutPanel.Controls.Add(this.MaxArmPt);
            this.filterLayoutPanel.Controls.Add(this.label43);
            this.filterLayoutPanel.Controls.Add(this.MaxSpdPt);
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
            this.filterLayoutPanel.Location = new System.Drawing.Point(339, 33);
            this.filterLayoutPanel.Name = "filterLayoutPanel";
            this.filterLayoutPanel.Size = new System.Drawing.Size(256, 573);
            this.filterLayoutPanel.TabIndex = 106;
            this.filterLayoutPanel.Visible = false;
            // 
            // masterLayoutPanel
            // 
            this.masterLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.masterLayoutPanel.ColumnCount = 3;
            this.masterLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.masterLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.masterLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.masterLayoutPanel.Controls.Add(this.filterLayoutPanel, 1, 1);
            this.masterLayoutPanel.Controls.Add(this.dataGridView1, 2, 1);
            this.masterLayoutPanel.Controls.Add(this.moduleLayoutPanel, 0, 1);
            this.masterLayoutPanel.Controls.Add(this.moduleLabel, 0, 0);
            this.masterLayoutPanel.Controls.Add(this.filterLabel, 1, 0);
            this.masterLayoutPanel.Location = new System.Drawing.Point(0, 123);
            this.masterLayoutPanel.Name = "masterLayoutPanel";
            this.masterLayoutPanel.RowCount = 2;
            this.masterLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.masterLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.masterLayoutPanel.Size = new System.Drawing.Size(1192, 609);
            this.masterLayoutPanel.TabIndex = 107;
            this.masterLayoutPanel.Visible = false;
            // 
            // filterLabel
            // 
            this.filterLabel.AutoSize = true;
            this.filterLabel.Location = new System.Drawing.Point(339, 0);
            this.filterLabel.MaximumSize = new System.Drawing.Size(250, 30);
            this.filterLabel.Name = "filterLabel";
            this.filterLabel.Size = new System.Drawing.Size(245, 26);
            this.filterLabel.TabIndex = 113;
            this.filterLabel.Text = "6. Apply filters to the results by selecting what filter you want (max/min) and a" +
    "dding a value";
            this.filterLabel.Visible = false;
            // 
            // maxYear
            // 
            this.maxYear.Location = new System.Drawing.Point(15, 51);
            this.maxYear.Maximum = new decimal(new int[] {
            1950,
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
            this.label9.Location = new System.Drawing.Point(8, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 109;
            this.label9.Text = "1. Set Year";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(495, 97);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(687, 23);
            this.progressBar1.TabIndex = 110;
            this.progressBar1.Visible = false;
            // 
            // showCheapest
            // 
            this.showCheapest.Location = new System.Drawing.Point(899, 54);
            this.showCheapest.Name = "showCheapest";
            this.showCheapest.Size = new System.Drawing.Size(89, 36);
            this.showCheapest.TabIndex = 111;
            this.showCheapest.Text = "Display Cheapest";
            this.showCheapest.UseVisualStyleBackColor = true;
            this.showCheapest.Visible = false;
            this.showCheapest.Click += new System.EventHandler(this.showCheapest_Click);
            // 
            // getTanksLabel
            // 
            this.getTanksLabel.AutoSize = true;
            this.getTanksLabel.Location = new System.Drawing.Point(492, 9);
            this.getTanksLabel.MaximumSize = new System.Drawing.Size(200, 0);
            this.getTanksLabel.Name = "getTanksLabel";
            this.getTanksLabel.Size = new System.Drawing.Size(200, 39);
            this.getTanksLabel.TabIndex = 112;
            this.getTanksLabel.Text = "5. Once you\'ve finished selecting modules, click Get all Tanks to generate the de" +
    "signs";
            this.getTanksLabel.Visible = false;
            // 
            // filterButtonLabel
            // 
            this.filterButtonLabel.AutoSize = true;
            this.filterButtonLabel.Location = new System.Drawing.Point(698, 9);
            this.filterButtonLabel.MaximumSize = new System.Drawing.Size(200, 0);
            this.filterButtonLabel.Name = "filterButtonLabel";
            this.filterButtonLabel.Size = new System.Drawing.Size(192, 26);
            this.filterButtonLabel.TabIndex = 113;
            this.filterButtonLabel.Text = "7. Once you\'ve added or updated your filters, click to filter the results";
            this.filterButtonLabel.Visible = false;
            // 
            // cheapestButtonLabel
            // 
            this.cheapestButtonLabel.AutoSize = true;
            this.cheapestButtonLabel.Location = new System.Drawing.Point(896, 9);
            this.cheapestButtonLabel.MaximumSize = new System.Drawing.Size(200, 0);
            this.cheapestButtonLabel.Name = "cheapestButtonLabel";
            this.cheapestButtonLabel.Size = new System.Drawing.Size(171, 26);
            this.cheapestButtonLabel.TabIndex = 114;
            this.cheapestButtonLabel.Text = "8. Click to show the cheapest 100 designs";
            this.cheapestButtonLabel.Visible = false;
            // 
            // softAFilter
            // 
            this.softAFilter.Location = new System.Drawing.Point(3, 81);
            this.softAFilter.Name = "softAFilter";
            this.softAFilter.Size = new System.Drawing.Size(121, 94);
            this.softAFilter.TabIndex = 95;
            this.softAFilter.Text = "label1";
            // 
            // hardAFilter
            // 
            this.hardAFilter.Location = new System.Drawing.Point(3, 181);
            this.hardAFilter.Name = "hardAFilter";
            this.hardAFilter.Size = new System.Drawing.Size(121, 94);
            this.hardAFilter.TabIndex = 96;
            this.hardAFilter.Text = "label1";
            // 
            // pirFilter
            // 
            this.pirFilter.Location = new System.Drawing.Point(3, 281);
            this.pirFilter.Name = "pirFilter";
            this.pirFilter.Size = new System.Drawing.Size(121, 94);
            this.pirFilter.TabIndex = 97;
            this.pirFilter.Text = "label1";
            // 
            // armFilter
            // 
            this.armFilter.Location = new System.Drawing.Point(3, 381);
            this.armFilter.Name = "armFilter";
            this.armFilter.Size = new System.Drawing.Size(121, 94);
            this.armFilter.TabIndex = 98;
            this.armFilter.Text = "label1";
            // 
            // relFilter
            // 
            this.relFilter.Location = new System.Drawing.Point(130, 3);
            this.relFilter.Name = "relFilter";
            this.relFilter.Size = new System.Drawing.Size(121, 94);
            this.relFilter.TabIndex = 99;
            this.relFilter.Text = "label1";
            // 
            // speedFilter
            // 
            this.speedFilter.Location = new System.Drawing.Point(130, 103);
            this.speedFilter.Name = "speedFilter";
            this.speedFilter.Size = new System.Drawing.Size(121, 94);
            this.speedFilter.TabIndex = 100;
            this.speedFilter.Text = "label1";
            // 
            // brkFilter
            // 
            this.brkFilter.Location = new System.Drawing.Point(130, 203);
            this.brkFilter.Name = "brkFilter";
            this.brkFilter.Size = new System.Drawing.Size(121, 94);
            this.brkFilter.TabIndex = 101;
            this.brkFilter.Text = "label1";
            // 
            // defFilter
            // 
            this.defFilter.Location = new System.Drawing.Point(130, 303);
            this.defFilter.Name = "defFilter";
            this.defFilter.Size = new System.Drawing.Size(121, 94);
            this.defFilter.TabIndex = 102;
            this.defFilter.Text = "label1";
            // 
            // fuelFilter
            // 
            this.fuelFilter.Location = new System.Drawing.Point(130, 403);
            this.fuelFilter.Name = "fuelFilter";
            this.fuelFilter.Size = new System.Drawing.Size(121, 94);
            this.fuelFilter.TabIndex = 103;
            this.fuelFilter.Text = "label1";
            // 
            // icFilter
            // 
            this.icFilter.Location = new System.Drawing.Point(257, 3);
            this.icFilter.Name = "icFilter";
            this.icFilter.Size = new System.Drawing.Size(121, 94);
            this.icFilter.TabIndex = 104;
            this.icFilter.Text = "label1";
            // 
            // hardFilter
            // 
            this.hardFilter.Location = new System.Drawing.Point(257, 103);
            this.hardFilter.Name = "hardFilter";
            this.hardFilter.Size = new System.Drawing.Size(121, 94);
            this.hardFilter.TabIndex = 105;
            this.hardFilter.Text = "label1";
            // 
            // Filter_Tanks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 732);
            this.Controls.Add(this.cheapestButtonLabel);
            this.Controls.Add(this.filterButtonLabel);
            this.Controls.Add(this.getTanksLabel);
            this.Controls.Add(this.showCheapest);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.maxYear);
            this.Controls.Add(this.masterLayoutPanel);
            this.Controls.Add(this.Filter_Tanks_Button);
            this.Controls.Add(this.Tank_Count);
            this.Controls.Add(this.getTanksButton);
            this.Controls.Add(this.chassisList);
            this.Controls.Add(this.analysisLabel);
            this.Controls.Add(this.addChassis);
            this.Controls.Add(this.chassisLabel);
            this.Controls.Add(this.chassisSelect);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Filter_Tanks";
            this.Text = "Tank Design and Filtering";
            this.Load += new System.EventHandler(this.Filter_Tanks_Load);
            this.moduleLayoutPanel.ResumeLayout(false);
            this.moduleLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxSpdPt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxArmPt)).EndInit();
            this.filterLayoutPanel.ResumeLayout(false);
            this.filterLayoutPanel.PerformLayout();
            this.masterLayoutPanel.ResumeLayout(false);
            this.masterLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label moduleLabel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel moduleLayoutPanel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox turretSelect;
        private System.Windows.Forms.ListBox engineSelect;
        private System.Windows.Forms.ListBox suspensionSelect;
        private System.Windows.Forms.ListBox armourSelect;
        private System.Windows.Forms.ListBox gunSelect;
        private System.Windows.Forms.ComboBox chassisSelect;
        private System.Windows.Forms.Label chassisLabel;
        private System.Windows.Forms.Button addChassis;
        private System.Windows.Forms.Label analysisLabel;
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
        private System.Windows.Forms.TableLayoutPanel masterLayoutPanel;
        private System.Windows.Forms.NumericUpDown maxYear;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button showCheapest;
        private System.Windows.Forms.ListBox specialSelect;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label getTanksLabel;
        private System.Windows.Forms.Label filterLabel;
        private System.Windows.Forms.Label filterButtonLabel;
        private System.Windows.Forms.Label cheapestButtonLabel;
    }
}