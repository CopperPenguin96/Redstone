namespace Block_Editor
{
	partial class Form1
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
			this.components = new System.ComponentModel.Container();
			this.lboBlockList = new System.Windows.Forms.ListBox();
			this.btnAddNew = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.gboBlockEditor = new System.Windows.Forms.GroupBox();
			this.chkBaseType = new System.Windows.Forms.CheckBox();
			this.lblBase = new System.Windows.Forms.Label();
			this.cboBaseType = new System.Windows.Forms.ComboBox();
			this.btnReset = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.txtTranslationKey = new System.Windows.Forms.TextBox();
			this.lblTranslationKey = new System.Windows.Forms.Label();
			this.txtID = new System.Windows.Forms.TextBox();
			this.lblID = new System.Windows.Forms.Label();
			this.gboCraftRecipe = new System.Windows.Forms.GroupBox();
			this.btnDeleteRecipe = new System.Windows.Forms.Button();
			this.btnAddRecipe = new System.Windows.Forms.Button();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.lblRecipe = new System.Windows.Forms.Label();
			this.btnSpot9 = new System.Windows.Forms.Button();
			this.btnSpot8 = new System.Windows.Forms.Button();
			this.btnSpot7 = new System.Windows.Forms.Button();
			this.btnSpot6 = new System.Windows.Forms.Button();
			this.btnSpot5 = new System.Windows.Forms.Button();
			this.btnSpot4 = new System.Windows.Forms.Button();
			this.btnSpot3 = new System.Windows.Forms.Button();
			this.btnSpot2 = new System.Windows.Forms.Button();
			this.btnSpot1 = new System.Windows.Forms.Button();
			this.cboLavaFlam = new System.Windows.Forms.CheckBox();
			this.cboFlammable = new System.Windows.Forms.CheckBox();
			this.cboTransparent = new System.Windows.Forms.CheckBox();
			this.cboLum = new System.Windows.Forms.CheckBox();
			this.numHardness = new System.Windows.Forms.NumericUpDown();
			this.lblHardness = new System.Windows.Forms.Label();
			this.numBlast = new System.Windows.Forms.NumericUpDown();
			this.lblBlast = new System.Windows.Forms.Label();
			this.gboToolRequired = new System.Windows.Forms.GroupBox();
			this.radHand = new System.Windows.Forms.RadioButton();
			this.radAxe = new System.Windows.Forms.RadioButton();
			this.radPickaxe = new System.Windows.Forms.RadioButton();
			this.radShovel = new System.Windows.Forms.RadioButton();
			this.radHoe = new System.Windows.Forms.RadioButton();
			this.gboBreakingTimes = new System.Windows.Forms.GroupBox();
			this.numGolden = new System.Windows.Forms.NumericUpDown();
			this.lblGolden = new System.Windows.Forms.Label();
			this.numNetherite = new System.Windows.Forms.NumericUpDown();
			this.lblNetherite = new System.Windows.Forms.Label();
			this.numDiamond = new System.Windows.Forms.NumericUpDown();
			this.lblDiamond = new System.Windows.Forms.Label();
			this.numIron = new System.Windows.Forms.NumericUpDown();
			this.lblIron = new System.Windows.Forms.Label();
			this.numStone = new System.Windows.Forms.NumericUpDown();
			this.lblStone = new System.Windows.Forms.Label();
			this.numWood = new System.Windows.Forms.NumericUpDown();
			this.lblWood = new System.Windows.Forms.Label();
			this.numDefault = new System.Windows.Forms.NumericUpDown();
			this.lblDefaultTime = new System.Windows.Forms.Label();
			this.numStackableCount = new System.Windows.Forms.NumericUpDown();
			this.lblCount = new System.Windows.Forms.Label();
			this.cboStackable = new System.Windows.Forms.CheckBox();
			this.txtName = new System.Windows.Forms.TextBox();
			this.lblName = new System.Windows.Forms.Label();
			this.gboBlockEditor.SuspendLayout();
			this.gboCraftRecipe.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numHardness)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numBlast)).BeginInit();
			this.gboToolRequired.SuspendLayout();
			this.gboBreakingTimes.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numGolden)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numNetherite)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numDiamond)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numIron)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numStone)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numWood)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numDefault)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numStackableCount)).BeginInit();
			this.SuspendLayout();
			// 
			// lboBlockList
			// 
			this.lboBlockList.FormattingEnabled = true;
			this.lboBlockList.Location = new System.Drawing.Point(13, 9);
			this.lboBlockList.Name = "lboBlockList";
			this.lboBlockList.Size = new System.Drawing.Size(156, 537);
			this.lboBlockList.TabIndex = 0;
			this.lboBlockList.SelectedIndexChanged += new System.EventHandler(this.lboBlockList_SelectedIndexChanged);
			// 
			// btnAddNew
			// 
			this.btnAddNew.Location = new System.Drawing.Point(176, 9);
			this.btnAddNew.Name = "btnAddNew";
			this.btnAddNew.Size = new System.Drawing.Size(75, 23);
			this.btnAddNew.TabIndex = 1;
			this.btnAddNew.Text = "Add";
			this.btnAddNew.UseVisualStyleBackColor = true;
			this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Location = new System.Drawing.Point(257, 9);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(75, 23);
			this.btnEdit.TabIndex = 2;
			this.btnEdit.Text = "Edit";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(338, 9);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(75, 23);
			this.btnDelete.TabIndex = 3;
			this.btnDelete.Text = "Delete";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 1;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// gboBlockEditor
			// 
			this.gboBlockEditor.Controls.Add(this.chkBaseType);
			this.gboBlockEditor.Controls.Add(this.lblBase);
			this.gboBlockEditor.Controls.Add(this.cboBaseType);
			this.gboBlockEditor.Controls.Add(this.btnReset);
			this.gboBlockEditor.Controls.Add(this.btnAdd);
			this.gboBlockEditor.Controls.Add(this.txtTranslationKey);
			this.gboBlockEditor.Controls.Add(this.lblTranslationKey);
			this.gboBlockEditor.Controls.Add(this.txtID);
			this.gboBlockEditor.Controls.Add(this.lblID);
			this.gboBlockEditor.Controls.Add(this.gboCraftRecipe);
			this.gboBlockEditor.Controls.Add(this.cboLavaFlam);
			this.gboBlockEditor.Controls.Add(this.cboFlammable);
			this.gboBlockEditor.Controls.Add(this.cboTransparent);
			this.gboBlockEditor.Controls.Add(this.cboLum);
			this.gboBlockEditor.Controls.Add(this.numHardness);
			this.gboBlockEditor.Controls.Add(this.lblHardness);
			this.gboBlockEditor.Controls.Add(this.numBlast);
			this.gboBlockEditor.Controls.Add(this.lblBlast);
			this.gboBlockEditor.Controls.Add(this.gboToolRequired);
			this.gboBlockEditor.Controls.Add(this.gboBreakingTimes);
			this.gboBlockEditor.Controls.Add(this.numStackableCount);
			this.gboBlockEditor.Controls.Add(this.lblCount);
			this.gboBlockEditor.Controls.Add(this.cboStackable);
			this.gboBlockEditor.Controls.Add(this.txtName);
			this.gboBlockEditor.Controls.Add(this.lblName);
			this.gboBlockEditor.Location = new System.Drawing.Point(176, 39);
			this.gboBlockEditor.Name = "gboBlockEditor";
			this.gboBlockEditor.Size = new System.Drawing.Size(510, 507);
			this.gboBlockEditor.TabIndex = 4;
			this.gboBlockEditor.TabStop = false;
			// 
			// chkBaseType
			// 
			this.chkBaseType.AutoSize = true;
			this.chkBaseType.Location = new System.Drawing.Point(160, 41);
			this.chkBaseType.Name = "chkBaseType";
			this.chkBaseType.Size = new System.Drawing.Size(77, 17);
			this.chkBaseType.TabIndex = 31;
			this.chkBaseType.Text = "Base Type";
			this.chkBaseType.UseVisualStyleBackColor = true;
			// 
			// lblBase
			// 
			this.lblBase.AutoSize = true;
			this.lblBase.Location = new System.Drawing.Point(8, 42);
			this.lblBase.Name = "lblBase";
			this.lblBase.Size = new System.Drawing.Size(31, 13);
			this.lblBase.TabIndex = 30;
			this.lblBase.Text = "Base";
			// 
			// cboBaseType
			// 
			this.cboBaseType.FormattingEnabled = true;
			this.cboBaseType.Location = new System.Drawing.Point(49, 39);
			this.cboBaseType.Name = "cboBaseType";
			this.cboBaseType.Size = new System.Drawing.Size(107, 21);
			this.cboBaseType.TabIndex = 29;
			this.cboBaseType.SelectedIndexChanged += new System.EventHandler(this.cboBaseType_SelectedIndexChanged);
			// 
			// btnReset
			// 
			this.btnReset.Location = new System.Drawing.Point(69, 368);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(75, 23);
			this.btnReset.TabIndex = 28;
			this.btnReset.Text = "Reset";
			this.btnReset.UseVisualStyleBackColor = true;
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(150, 368);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 23);
			this.btnAdd.TabIndex = 27;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// txtTranslationKey
			// 
			this.txtTranslationKey.Location = new System.Drawing.Point(92, 319);
			this.txtTranslationKey.Name = "txtTranslationKey";
			this.txtTranslationKey.Size = new System.Drawing.Size(133, 20);
			this.txtTranslationKey.TabIndex = 26;
			// 
			// lblTranslationKey
			// 
			this.lblTranslationKey.AutoSize = true;
			this.lblTranslationKey.Location = new System.Drawing.Point(28, 322);
			this.lblTranslationKey.Name = "lblTranslationKey";
			this.lblTranslationKey.Size = new System.Drawing.Size(58, 13);
			this.lblTranslationKey.TabIndex = 25;
			this.lblTranslationKey.Text = "Trans. Key";
			// 
			// txtID
			// 
			this.txtID.Location = new System.Drawing.Point(92, 293);
			this.txtID.Name = "txtID";
			this.txtID.Size = new System.Drawing.Size(133, 20);
			this.txtID.TabIndex = 24;
			// 
			// lblID
			// 
			this.lblID.AutoSize = true;
			this.lblID.Location = new System.Drawing.Point(28, 296);
			this.lblID.Name = "lblID";
			this.lblID.Size = new System.Drawing.Size(18, 13);
			this.lblID.TabIndex = 23;
			this.lblID.Text = "ID";
			// 
			// gboCraftRecipe
			// 
			this.gboCraftRecipe.Controls.Add(this.btnDeleteRecipe);
			this.gboCraftRecipe.Controls.Add(this.btnAddRecipe);
			this.gboCraftRecipe.Controls.Add(this.numericUpDown1);
			this.gboCraftRecipe.Controls.Add(this.lblRecipe);
			this.gboCraftRecipe.Controls.Add(this.btnSpot9);
			this.gboCraftRecipe.Controls.Add(this.btnSpot8);
			this.gboCraftRecipe.Controls.Add(this.btnSpot7);
			this.gboCraftRecipe.Controls.Add(this.btnSpot6);
			this.gboCraftRecipe.Controls.Add(this.btnSpot5);
			this.gboCraftRecipe.Controls.Add(this.btnSpot4);
			this.gboCraftRecipe.Controls.Add(this.btnSpot3);
			this.gboCraftRecipe.Controls.Add(this.btnSpot2);
			this.gboCraftRecipe.Controls.Add(this.btnSpot1);
			this.gboCraftRecipe.Location = new System.Drawing.Point(243, 265);
			this.gboCraftRecipe.Name = "gboCraftRecipe";
			this.gboCraftRecipe.Size = new System.Drawing.Size(251, 236);
			this.gboCraftRecipe.TabIndex = 22;
			this.gboCraftRecipe.TabStop = false;
			this.gboCraftRecipe.Text = "Craft Recipe";
			this.gboCraftRecipe.Enter += new System.EventHandler(this.gboCraftRecipe_Enter);
			// 
			// btnDeleteRecipe
			// 
			this.btnDeleteRecipe.Location = new System.Drawing.Point(192, 25);
			this.btnDeleteRecipe.Name = "btnDeleteRecipe";
			this.btnDeleteRecipe.Size = new System.Drawing.Size(48, 23);
			this.btnDeleteRecipe.TabIndex = 36;
			this.btnDeleteRecipe.Text = "Delete";
			this.btnDeleteRecipe.UseVisualStyleBackColor = true;
			this.btnDeleteRecipe.Click += new System.EventHandler(this.btnDeleteRecipe_Click);
			// 
			// btnAddRecipe
			// 
			this.btnAddRecipe.Location = new System.Drawing.Point(97, 25);
			this.btnAddRecipe.Name = "btnAddRecipe";
			this.btnAddRecipe.Size = new System.Drawing.Size(48, 23);
			this.btnAddRecipe.TabIndex = 34;
			this.btnAddRecipe.Text = "Add";
			this.btnAddRecipe.UseVisualStyleBackColor = true;
			this.btnAddRecipe.Click += new System.EventHandler(this.btnAddRecipe_Click);
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(53, 29);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(31, 20);
			this.numericUpDown1.TabIndex = 33;
			this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
			// 
			// lblRecipe
			// 
			this.lblRecipe.AutoSize = true;
			this.lblRecipe.Location = new System.Drawing.Point(6, 31);
			this.lblRecipe.Name = "lblRecipe";
			this.lblRecipe.Size = new System.Drawing.Size(41, 13);
			this.lblRecipe.TabIndex = 32;
			this.lblRecipe.Text = "Recipe";
			// 
			// btnSpot9
			// 
			this.btnSpot9.Location = new System.Drawing.Point(171, 170);
			this.btnSpot9.Name = "btnSpot9";
			this.btnSpot9.Size = new System.Drawing.Size(75, 49);
			this.btnSpot9.TabIndex = 8;
			this.btnSpot9.Text = "{Empty}";
			this.btnSpot9.UseVisualStyleBackColor = true;
			this.btnSpot9.Click += new System.EventHandler(this.btnSpot1_Click);
			// 
			// btnSpot8
			// 
			this.btnSpot8.Location = new System.Drawing.Point(90, 170);
			this.btnSpot8.Name = "btnSpot8";
			this.btnSpot8.Size = new System.Drawing.Size(75, 49);
			this.btnSpot8.TabIndex = 7;
			this.btnSpot8.Text = "{Empty}";
			this.btnSpot8.UseVisualStyleBackColor = true;
			this.btnSpot8.Click += new System.EventHandler(this.btnSpot1_Click);
			// 
			// btnSpot7
			// 
			this.btnSpot7.Location = new System.Drawing.Point(9, 170);
			this.btnSpot7.Name = "btnSpot7";
			this.btnSpot7.Size = new System.Drawing.Size(75, 49);
			this.btnSpot7.TabIndex = 6;
			this.btnSpot7.Text = "{Empty}";
			this.btnSpot7.UseVisualStyleBackColor = true;
			this.btnSpot7.Click += new System.EventHandler(this.btnSpot1_Click);
			// 
			// btnSpot6
			// 
			this.btnSpot6.Location = new System.Drawing.Point(171, 118);
			this.btnSpot6.Name = "btnSpot6";
			this.btnSpot6.Size = new System.Drawing.Size(75, 49);
			this.btnSpot6.TabIndex = 5;
			this.btnSpot6.Text = "{Empty}";
			this.btnSpot6.UseVisualStyleBackColor = true;
			this.btnSpot6.Click += new System.EventHandler(this.btnSpot1_Click);
			// 
			// btnSpot5
			// 
			this.btnSpot5.Location = new System.Drawing.Point(90, 118);
			this.btnSpot5.Name = "btnSpot5";
			this.btnSpot5.Size = new System.Drawing.Size(75, 49);
			this.btnSpot5.TabIndex = 4;
			this.btnSpot5.Text = "Spot 5";
			this.btnSpot5.UseVisualStyleBackColor = true;
			this.btnSpot5.Click += new System.EventHandler(this.btnSpot1_Click);
			// 
			// btnSpot4
			// 
			this.btnSpot4.Location = new System.Drawing.Point(9, 118);
			this.btnSpot4.Name = "btnSpot4";
			this.btnSpot4.Size = new System.Drawing.Size(75, 49);
			this.btnSpot4.TabIndex = 3;
			this.btnSpot4.Text = "Spot 4";
			this.btnSpot4.UseVisualStyleBackColor = true;
			this.btnSpot4.Click += new System.EventHandler(this.btnSpot1_Click);
			// 
			// btnSpot3
			// 
			this.btnSpot3.Location = new System.Drawing.Point(171, 63);
			this.btnSpot3.Name = "btnSpot3";
			this.btnSpot3.Size = new System.Drawing.Size(75, 49);
			this.btnSpot3.TabIndex = 2;
			this.btnSpot3.Text = "{Empty}";
			this.btnSpot3.UseVisualStyleBackColor = true;
			this.btnSpot3.Click += new System.EventHandler(this.btnSpot1_Click);
			// 
			// btnSpot2
			// 
			this.btnSpot2.Location = new System.Drawing.Point(90, 63);
			this.btnSpot2.Name = "btnSpot2";
			this.btnSpot2.Size = new System.Drawing.Size(75, 49);
			this.btnSpot2.TabIndex = 1;
			this.btnSpot2.Text = "Spot 2";
			this.btnSpot2.UseVisualStyleBackColor = true;
			this.btnSpot2.Click += new System.EventHandler(this.btnSpot1_Click);
			// 
			// btnSpot1
			// 
			this.btnSpot1.Location = new System.Drawing.Point(9, 63);
			this.btnSpot1.Name = "btnSpot1";
			this.btnSpot1.Size = new System.Drawing.Size(75, 49);
			this.btnSpot1.TabIndex = 0;
			this.btnSpot1.Text = "Spot 1";
			this.btnSpot1.UseVisualStyleBackColor = true;
			this.btnSpot1.Click += new System.EventHandler(this.btnSpot1_Click);
			// 
			// cboLavaFlam
			// 
			this.cboLavaFlam.AutoSize = true;
			this.cboLavaFlam.Location = new System.Drawing.Point(326, 242);
			this.cboLavaFlam.Name = "cboLavaFlam";
			this.cboLavaFlam.Size = new System.Drawing.Size(103, 17);
			this.cboLavaFlam.TabIndex = 21;
			this.cboLavaFlam.Text = "Lava Flammable";
			this.cboLavaFlam.UseVisualStyleBackColor = true;
			// 
			// cboFlammable
			// 
			this.cboFlammable.AutoSize = true;
			this.cboFlammable.Location = new System.Drawing.Point(251, 242);
			this.cboFlammable.Name = "cboFlammable";
			this.cboFlammable.Size = new System.Drawing.Size(76, 17);
			this.cboFlammable.TabIndex = 20;
			this.cboFlammable.Text = "Flammable";
			this.cboFlammable.UseVisualStyleBackColor = true;
			// 
			// cboTransparent
			// 
			this.cboTransparent.AutoSize = true;
			this.cboTransparent.Location = new System.Drawing.Point(326, 219);
			this.cboTransparent.Name = "cboTransparent";
			this.cboTransparent.Size = new System.Drawing.Size(83, 17);
			this.cboTransparent.TabIndex = 19;
			this.cboTransparent.Text = "Transparent";
			this.cboTransparent.UseVisualStyleBackColor = true;
			// 
			// cboLum
			// 
			this.cboLum.AutoSize = true;
			this.cboLum.Location = new System.Drawing.Point(251, 219);
			this.cboLum.Name = "cboLum";
			this.cboLum.Size = new System.Drawing.Size(69, 17);
			this.cboLum.TabIndex = 18;
			this.cboLum.Text = "Luminant";
			this.cboLum.UseVisualStyleBackColor = true;
			// 
			// numHardness
			// 
			this.numHardness.DecimalPlaces = 1;
			this.numHardness.Location = new System.Drawing.Point(340, 193);
			this.numHardness.Name = "numHardness";
			this.numHardness.Size = new System.Drawing.Size(147, 20);
			this.numHardness.TabIndex = 17;
			// 
			// lblHardness
			// 
			this.lblHardness.AutoSize = true;
			this.lblHardness.Location = new System.Drawing.Point(248, 195);
			this.lblHardness.Name = "lblHardness";
			this.lblHardness.Size = new System.Drawing.Size(52, 13);
			this.lblHardness.TabIndex = 16;
			this.lblHardness.Text = "Hardness";
			// 
			// numBlast
			// 
			this.numBlast.DecimalPlaces = 1;
			this.numBlast.Location = new System.Drawing.Point(340, 167);
			this.numBlast.Name = "numBlast";
			this.numBlast.Size = new System.Drawing.Size(147, 20);
			this.numBlast.TabIndex = 15;
			// 
			// lblBlast
			// 
			this.lblBlast.AutoSize = true;
			this.lblBlast.Location = new System.Drawing.Point(248, 169);
			this.lblBlast.Name = "lblBlast";
			this.lblBlast.Size = new System.Drawing.Size(86, 13);
			this.lblBlast.TabIndex = 14;
			this.lblBlast.Text = "Blast Resistance";
			this.lblBlast.Click += new System.EventHandler(this.label1_Click);
			// 
			// gboToolRequired
			// 
			this.gboToolRequired.Controls.Add(this.radHand);
			this.gboToolRequired.Controls.Add(this.radAxe);
			this.gboToolRequired.Controls.Add(this.radPickaxe);
			this.gboToolRequired.Controls.Add(this.radShovel);
			this.gboToolRequired.Controls.Add(this.radHoe);
			this.gboToolRequired.Location = new System.Drawing.Point(243, 17);
			this.gboToolRequired.Name = "gboToolRequired";
			this.gboToolRequired.Size = new System.Drawing.Size(244, 142);
			this.gboToolRequired.TabIndex = 13;
			this.gboToolRequired.TabStop = false;
			this.gboToolRequired.Text = "Required Type To Break";
			// 
			// radHand
			// 
			this.radHand.AutoSize = true;
			this.radHand.Location = new System.Drawing.Point(8, 20);
			this.radHand.Name = "radHand";
			this.radHand.Size = new System.Drawing.Size(51, 17);
			this.radHand.TabIndex = 10;
			this.radHand.TabStop = true;
			this.radHand.Text = "Hand";
			this.radHand.UseVisualStyleBackColor = true;
			// 
			// radAxe
			// 
			this.radAxe.AutoSize = true;
			this.radAxe.Location = new System.Drawing.Point(8, 44);
			this.radAxe.Name = "radAxe";
			this.radAxe.Size = new System.Drawing.Size(43, 17);
			this.radAxe.TabIndex = 11;
			this.radAxe.TabStop = true;
			this.radAxe.Text = "Axe";
			this.radAxe.UseVisualStyleBackColor = true;
			// 
			// radPickaxe
			// 
			this.radPickaxe.AutoSize = true;
			this.radPickaxe.Location = new System.Drawing.Point(8, 68);
			this.radPickaxe.Name = "radPickaxe";
			this.radPickaxe.Size = new System.Drawing.Size(63, 17);
			this.radPickaxe.TabIndex = 12;
			this.radPickaxe.TabStop = true;
			this.radPickaxe.Text = "Pickaxe";
			this.radPickaxe.UseVisualStyleBackColor = true;
			// 
			// radShovel
			// 
			this.radShovel.AutoSize = true;
			this.radShovel.Location = new System.Drawing.Point(8, 116);
			this.radShovel.Name = "radShovel";
			this.radShovel.Size = new System.Drawing.Size(58, 17);
			this.radShovel.TabIndex = 14;
			this.radShovel.TabStop = true;
			this.radShovel.Text = "Shovel";
			this.radShovel.UseVisualStyleBackColor = true;
			// 
			// radHoe
			// 
			this.radHoe.AutoSize = true;
			this.radHoe.Location = new System.Drawing.Point(8, 92);
			this.radHoe.Name = "radHoe";
			this.radHoe.Size = new System.Drawing.Size(45, 17);
			this.radHoe.TabIndex = 13;
			this.radHoe.TabStop = true;
			this.radHoe.Text = "Hoe";
			this.radHoe.UseVisualStyleBackColor = true;
			// 
			// gboBreakingTimes
			// 
			this.gboBreakingTimes.Controls.Add(this.numGolden);
			this.gboBreakingTimes.Controls.Add(this.lblGolden);
			this.gboBreakingTimes.Controls.Add(this.numNetherite);
			this.gboBreakingTimes.Controls.Add(this.lblNetherite);
			this.gboBreakingTimes.Controls.Add(this.numDiamond);
			this.gboBreakingTimes.Controls.Add(this.lblDiamond);
			this.gboBreakingTimes.Controls.Add(this.numIron);
			this.gboBreakingTimes.Controls.Add(this.lblIron);
			this.gboBreakingTimes.Controls.Add(this.numStone);
			this.gboBreakingTimes.Controls.Add(this.lblStone);
			this.gboBreakingTimes.Controls.Add(this.numWood);
			this.gboBreakingTimes.Controls.Add(this.lblWood);
			this.gboBreakingTimes.Controls.Add(this.numDefault);
			this.gboBreakingTimes.Controls.Add(this.lblDefaultTime);
			this.gboBreakingTimes.Location = new System.Drawing.Point(10, 66);
			this.gboBreakingTimes.Name = "gboBreakingTimes";
			this.gboBreakingTimes.Size = new System.Drawing.Size(227, 214);
			this.gboBreakingTimes.TabIndex = 12;
			this.gboBreakingTimes.TabStop = false;
			this.gboBreakingTimes.Text = "Breaking Times";
			// 
			// numGolden
			// 
			this.numGolden.DecimalPlaces = 2;
			this.numGolden.Location = new System.Drawing.Point(95, 174);
			this.numGolden.Name = "numGolden";
			this.numGolden.Size = new System.Drawing.Size(120, 20);
			this.numGolden.TabIndex = 13;
			// 
			// lblGolden
			// 
			this.lblGolden.AutoSize = true;
			this.lblGolden.Location = new System.Drawing.Point(7, 176);
			this.lblGolden.Name = "lblGolden";
			this.lblGolden.Size = new System.Drawing.Size(41, 13);
			this.lblGolden.TabIndex = 12;
			this.lblGolden.Text = "Golden";
			// 
			// numNetherite
			// 
			this.numNetherite.DecimalPlaces = 2;
			this.numNetherite.Location = new System.Drawing.Point(95, 148);
			this.numNetherite.Name = "numNetherite";
			this.numNetherite.Size = new System.Drawing.Size(120, 20);
			this.numNetherite.TabIndex = 11;
			// 
			// lblNetherite
			// 
			this.lblNetherite.AutoSize = true;
			this.lblNetherite.Location = new System.Drawing.Point(7, 150);
			this.lblNetherite.Name = "lblNetherite";
			this.lblNetherite.Size = new System.Drawing.Size(50, 13);
			this.lblNetherite.TabIndex = 10;
			this.lblNetherite.Text = "Netherite";
			// 
			// numDiamond
			// 
			this.numDiamond.DecimalPlaces = 2;
			this.numDiamond.Location = new System.Drawing.Point(95, 122);
			this.numDiamond.Name = "numDiamond";
			this.numDiamond.Size = new System.Drawing.Size(120, 20);
			this.numDiamond.TabIndex = 9;
			// 
			// lblDiamond
			// 
			this.lblDiamond.AutoSize = true;
			this.lblDiamond.Location = new System.Drawing.Point(7, 124);
			this.lblDiamond.Name = "lblDiamond";
			this.lblDiamond.Size = new System.Drawing.Size(49, 13);
			this.lblDiamond.TabIndex = 8;
			this.lblDiamond.Text = "Diamond";
			// 
			// numIron
			// 
			this.numIron.DecimalPlaces = 2;
			this.numIron.Location = new System.Drawing.Point(95, 96);
			this.numIron.Name = "numIron";
			this.numIron.Size = new System.Drawing.Size(120, 20);
			this.numIron.TabIndex = 7;
			// 
			// lblIron
			// 
			this.lblIron.AutoSize = true;
			this.lblIron.Location = new System.Drawing.Point(7, 98);
			this.lblIron.Name = "lblIron";
			this.lblIron.Size = new System.Drawing.Size(25, 13);
			this.lblIron.TabIndex = 6;
			this.lblIron.Text = "Iron";
			// 
			// numStone
			// 
			this.numStone.DecimalPlaces = 2;
			this.numStone.Location = new System.Drawing.Point(95, 70);
			this.numStone.Name = "numStone";
			this.numStone.Size = new System.Drawing.Size(120, 20);
			this.numStone.TabIndex = 5;
			// 
			// lblStone
			// 
			this.lblStone.AutoSize = true;
			this.lblStone.Location = new System.Drawing.Point(7, 72);
			this.lblStone.Name = "lblStone";
			this.lblStone.Size = new System.Drawing.Size(35, 13);
			this.lblStone.TabIndex = 4;
			this.lblStone.Text = "Stone";
			// 
			// numWood
			// 
			this.numWood.DecimalPlaces = 2;
			this.numWood.Location = new System.Drawing.Point(95, 44);
			this.numWood.Name = "numWood";
			this.numWood.Size = new System.Drawing.Size(120, 20);
			this.numWood.TabIndex = 3;
			// 
			// lblWood
			// 
			this.lblWood.AutoSize = true;
			this.lblWood.Location = new System.Drawing.Point(7, 46);
			this.lblWood.Name = "lblWood";
			this.lblWood.Size = new System.Drawing.Size(36, 13);
			this.lblWood.TabIndex = 2;
			this.lblWood.Text = "Wood";
			// 
			// numDefault
			// 
			this.numDefault.DecimalPlaces = 2;
			this.numDefault.Location = new System.Drawing.Point(95, 18);
			this.numDefault.Name = "numDefault";
			this.numDefault.Size = new System.Drawing.Size(120, 20);
			this.numDefault.TabIndex = 1;
			// 
			// lblDefaultTime
			// 
			this.lblDefaultTime.AutoSize = true;
			this.lblDefaultTime.Location = new System.Drawing.Point(7, 20);
			this.lblDefaultTime.Name = "lblDefaultTime";
			this.lblDefaultTime.Size = new System.Drawing.Size(41, 13);
			this.lblDefaultTime.TabIndex = 0;
			this.lblDefaultTime.Text = "Default";
			// 
			// numStackableCount
			// 
			this.numStackableCount.Enabled = false;
			this.numStackableCount.Location = new System.Drawing.Point(162, 344);
			this.numStackableCount.Name = "numStackableCount";
			this.numStackableCount.Size = new System.Drawing.Size(63, 20);
			this.numStackableCount.TabIndex = 4;
			// 
			// lblCount
			// 
			this.lblCount.AutoSize = true;
			this.lblCount.Location = new System.Drawing.Point(121, 346);
			this.lblCount.Name = "lblCount";
			this.lblCount.Size = new System.Drawing.Size(35, 13);
			this.lblCount.TabIndex = 3;
			this.lblCount.Text = "Count";
			// 
			// cboStackable
			// 
			this.cboStackable.AutoSize = true;
			this.cboStackable.Location = new System.Drawing.Point(31, 345);
			this.cboStackable.Name = "cboStackable";
			this.cboStackable.Size = new System.Drawing.Size(85, 17);
			this.cboStackable.TabIndex = 2;
			this.cboStackable.Text = "Is Stackable";
			this.cboStackable.UseVisualStyleBackColor = true;
			this.cboStackable.CheckedChanged += new System.EventHandler(this.cboStackable_CheckedChanged);
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(49, 17);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(188, 20);
			this.txtName.TabIndex = 1;
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(7, 20);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(35, 13);
			this.lblName.TabIndex = 0;
			this.lblName.Text = "Name";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(698, 560);
			this.Controls.Add(this.gboBlockEditor);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.btnAddNew);
			this.Controls.Add(this.lboBlockList);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.gboBlockEditor.ResumeLayout(false);
			this.gboBlockEditor.PerformLayout();
			this.gboCraftRecipe.ResumeLayout(false);
			this.gboCraftRecipe.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numHardness)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numBlast)).EndInit();
			this.gboToolRequired.ResumeLayout(false);
			this.gboToolRequired.PerformLayout();
			this.gboBreakingTimes.ResumeLayout(false);
			this.gboBreakingTimes.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numGolden)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numNetherite)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numDiamond)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numIron)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numStone)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numWood)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numDefault)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numStackableCount)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox lboBlockList;
		private System.Windows.Forms.Button btnAddNew;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.GroupBox gboBlockEditor;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.CheckBox cboStackable;
		private System.Windows.Forms.NumericUpDown numStackableCount;
		private System.Windows.Forms.Label lblCount;
		private System.Windows.Forms.GroupBox gboToolRequired;
		private System.Windows.Forms.RadioButton radHand;
		private System.Windows.Forms.RadioButton radAxe;
		private System.Windows.Forms.RadioButton radPickaxe;
		private System.Windows.Forms.RadioButton radShovel;
		private System.Windows.Forms.RadioButton radHoe;
		private System.Windows.Forms.GroupBox gboBreakingTimes;
		private System.Windows.Forms.Label lblDefaultTime;
		private System.Windows.Forms.NumericUpDown numGolden;
		private System.Windows.Forms.Label lblGolden;
		private System.Windows.Forms.NumericUpDown numNetherite;
		private System.Windows.Forms.Label lblNetherite;
		private System.Windows.Forms.NumericUpDown numDiamond;
		private System.Windows.Forms.Label lblDiamond;
		private System.Windows.Forms.NumericUpDown numIron;
		private System.Windows.Forms.Label lblIron;
		private System.Windows.Forms.NumericUpDown numStone;
		private System.Windows.Forms.Label lblStone;
		private System.Windows.Forms.NumericUpDown numWood;
		private System.Windows.Forms.Label lblWood;
		private System.Windows.Forms.NumericUpDown numDefault;
		private System.Windows.Forms.NumericUpDown numBlast;
		private System.Windows.Forms.Label lblBlast;
		private System.Windows.Forms.NumericUpDown numHardness;
		private System.Windows.Forms.Label lblHardness;
		private System.Windows.Forms.CheckBox cboTransparent;
		private System.Windows.Forms.CheckBox cboLum;
		private System.Windows.Forms.CheckBox cboFlammable;
		private System.Windows.Forms.CheckBox cboLavaFlam;
		private System.Windows.Forms.GroupBox gboCraftRecipe;
		private System.Windows.Forms.Button btnSpot9;
		private System.Windows.Forms.Button btnSpot8;
		private System.Windows.Forms.Button btnSpot7;
		private System.Windows.Forms.Button btnSpot6;
		private System.Windows.Forms.Button btnSpot5;
		private System.Windows.Forms.Button btnSpot4;
		private System.Windows.Forms.Button btnSpot3;
		private System.Windows.Forms.Button btnSpot2;
		private System.Windows.Forms.Button btnSpot1;
		private System.Windows.Forms.TextBox txtID;
		private System.Windows.Forms.Label lblID;
		private System.Windows.Forms.TextBox txtTranslationKey;
		private System.Windows.Forms.Label lblTranslationKey;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.ComboBox cboBaseType;
		private System.Windows.Forms.Label lblBase;
		private System.Windows.Forms.CheckBox chkBaseType;
		private System.Windows.Forms.Label lblRecipe;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Button btnAddRecipe;
		private System.Windows.Forms.Button btnDeleteRecipe;
	}
}

