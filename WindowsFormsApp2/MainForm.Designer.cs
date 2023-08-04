namespace WindowsFormsApp2
{
    partial class MainForm
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
            this.SearchButton = new System.Windows.Forms.Button();
            this.LatitudeTextBox = new System.Windows.Forms.MaskedTextBox();
            this.LatitudeLabel = new System.Windows.Forms.Label();
            this.LongitudeLabel = new System.Windows.Forms.Label();
            this.AddressLabel = new System.Windows.Forms.Label();
            this.ZoomInButton = new System.Windows.Forms.Button();
            this.ZoomOutButton = new System.Windows.Forms.Button();
            this.LongitudeTextBox = new System.Windows.Forms.MaskedTextBox();
            this.MaskButton = new System.Windows.Forms.Button();
            this.RadiusLabel = new System.Windows.Forms.Label();
            this.DefaultFloorHeightLabel = new System.Windows.Forms.Label();
            this.DefaultBuildingHeightLabel = new System.Windows.Forms.Label();
            this.RadiusTextBox = new System.Windows.Forms.TextBox();
            this.DefaultFloorHeightTextBox = new System.Windows.Forms.TextBox();
            this.DefaultBuildingHeightTextBox = new System.Windows.Forms.TextBox();
            this.AddressTextBox = new System.Windows.Forms.TextBox();
            this.East_SouthEastTextBox = new System.Windows.Forms.TextBox();
            this.East_SouthEastLabel = new System.Windows.Forms.Label();
            this.SouthEast_SouthLabel = new System.Windows.Forms.Label();
            this.SouthEast_SouthTextBox = new System.Windows.Forms.TextBox();
            this.South_SouthWestLabel = new System.Windows.Forms.Label();
            this.South_SouthWestTextBox = new System.Windows.Forms.TextBox();
            this.SouthWest_WestLabel = new System.Windows.Forms.Label();
            this.SouthWest_WestTextBox = new System.Windows.Forms.TextBox();
            this.Map = new GMap.NET.WindowsForms.GMapControl();
            this.BuildingDataRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.DirectionRadioButton = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(753, 8);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(113, 34);
            this.SearchButton.TabIndex = 1;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // LatitudeTextBox
            // 
            this.LatitudeTextBox.Location = new System.Drawing.Point(92, 45);
            this.LatitudeTextBox.Name = "LatitudeTextBox";
            this.LatitudeTextBox.Size = new System.Drawing.Size(240, 22);
            this.LatitudeTextBox.TabIndex = 2;
            // 
            // LatitudeLabel
            // 
            this.LatitudeLabel.AutoSize = true;
            this.LatitudeLabel.Location = new System.Drawing.Point(18, 48);
            this.LatitudeLabel.Name = "LatitudeLabel";
            this.LatitudeLabel.Size = new System.Drawing.Size(57, 16);
            this.LatitudeLabel.TabIndex = 4;
            this.LatitudeLabel.Text = "Latitude:";
            // 
            // LongitudeLabel
            // 
            this.LongitudeLabel.AutoSize = true;
            this.LongitudeLabel.Location = new System.Drawing.Point(18, 89);
            this.LongitudeLabel.Name = "LongitudeLabel";
            this.LongitudeLabel.Size = new System.Drawing.Size(66, 16);
            this.LongitudeLabel.TabIndex = 5;
            this.LongitudeLabel.Text = "Longitude";
            this.LongitudeLabel.Click += new System.EventHandler(this.LongitudeLabel_Click);
            // 
            // AddressLabel
            // 
            this.AddressLabel.AutoSize = true;
            this.AddressLabel.Location = new System.Drawing.Point(17, 9);
            this.AddressLabel.Name = "AddressLabel";
            this.AddressLabel.Size = new System.Drawing.Size(58, 16);
            this.AddressLabel.TabIndex = 7;
            this.AddressLabel.Text = "Address";
            // 
            // ZoomInButton
            // 
            this.ZoomInButton.Location = new System.Drawing.Point(21, 130);
            this.ZoomInButton.Name = "ZoomInButton";
            this.ZoomInButton.Size = new System.Drawing.Size(93, 28);
            this.ZoomInButton.TabIndex = 8;
            this.ZoomInButton.Text = "Zoom in";
            this.ZoomInButton.UseVisualStyleBackColor = true;
            this.ZoomInButton.Click += new System.EventHandler(this.ZoomInButton_Click);
            // 
            // ZoomOutButton
            // 
            this.ZoomOutButton.Location = new System.Drawing.Point(20, 164);
            this.ZoomOutButton.Name = "ZoomOutButton";
            this.ZoomOutButton.Size = new System.Drawing.Size(93, 28);
            this.ZoomOutButton.TabIndex = 9;
            this.ZoomOutButton.Text = "Zoom out";
            this.ZoomOutButton.UseVisualStyleBackColor = true;
            this.ZoomOutButton.Click += new System.EventHandler(this.ZoomOutButton_Click);
            // 
            // LongitudeTextBox
            // 
            this.LongitudeTextBox.Location = new System.Drawing.Point(90, 83);
            this.LongitudeTextBox.Name = "LongitudeTextBox";
            this.LongitudeTextBox.Size = new System.Drawing.Size(240, 22);
            this.LongitudeTextBox.TabIndex = 3;
            // 
            // MaskButton
            // 
            this.MaskButton.Location = new System.Drawing.Point(753, 48);
            this.MaskButton.Name = "MaskButton";
            this.MaskButton.Size = new System.Drawing.Size(113, 34);
            this.MaskButton.TabIndex = 10;
            this.MaskButton.Text = "Mask";
            this.MaskButton.UseVisualStyleBackColor = true;
            this.MaskButton.Click += new System.EventHandler(this.MaskButton_Click);
            // 
            // RadiusLabel
            // 
            this.RadiusLabel.AutoSize = true;
            this.RadiusLabel.Location = new System.Drawing.Point(595, 54);
            this.RadiusLabel.Name = "RadiusLabel";
            this.RadiusLabel.Size = new System.Drawing.Size(50, 16);
            this.RadiusLabel.TabIndex = 12;
            this.RadiusLabel.Text = "Radius";
            // 
            // DefaultFloorHeightLabel
            // 
            this.DefaultFloorHeightLabel.AutoSize = true;
            this.DefaultFloorHeightLabel.Location = new System.Drawing.Point(12, 502);
            this.DefaultFloorHeightLabel.Name = "DefaultFloorHeightLabel";
            this.DefaultFloorHeightLabel.Size = new System.Drawing.Size(117, 16);
            this.DefaultFloorHeightLabel.TabIndex = 14;
            this.DefaultFloorHeightLabel.Text = "Default floor height";
            // 
            // DefaultBuildingHeightLabel
            // 
            this.DefaultBuildingHeightLabel.AutoSize = true;
            this.DefaultBuildingHeightLabel.Location = new System.Drawing.Point(12, 535);
            this.DefaultBuildingHeightLabel.Name = "DefaultBuildingHeightLabel";
            this.DefaultBuildingHeightLabel.Size = new System.Drawing.Size(138, 16);
            this.DefaultBuildingHeightLabel.TabIndex = 16;
            this.DefaultBuildingHeightLabel.Text = "Default building height";
            // 
            // RadiusTextBox
            // 
            this.RadiusTextBox.Location = new System.Drawing.Point(651, 51);
            this.RadiusTextBox.Name = "RadiusTextBox";
            this.RadiusTextBox.Size = new System.Drawing.Size(79, 22);
            this.RadiusTextBox.TabIndex = 17;
            this.RadiusTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // DefaultFloorHeightTextBox
            // 
            this.DefaultFloorHeightTextBox.Location = new System.Drawing.Point(159, 499);
            this.DefaultFloorHeightTextBox.Name = "DefaultFloorHeightTextBox";
            this.DefaultFloorHeightTextBox.Size = new System.Drawing.Size(134, 22);
            this.DefaultFloorHeightTextBox.TabIndex = 18;
            this.DefaultFloorHeightTextBox.TextChanged += new System.EventHandler(this.DefaultFloorHeightTextBox_TextChanged);
            // 
            // DefaultBuildingHeightTextBox
            // 
            this.DefaultBuildingHeightTextBox.Location = new System.Drawing.Point(159, 529);
            this.DefaultBuildingHeightTextBox.Name = "DefaultBuildingHeightTextBox";
            this.DefaultBuildingHeightTextBox.Size = new System.Drawing.Size(134, 22);
            this.DefaultBuildingHeightTextBox.TabIndex = 19;
            this.DefaultBuildingHeightTextBox.TextChanged += new System.EventHandler(this.DefaultBuildingHeightTextBox_TextChanged);
            // 
            // AddressTextBox
            // 
            this.AddressTextBox.Location = new System.Drawing.Point(90, 8);
            this.AddressTextBox.Name = "AddressTextBox";
            this.AddressTextBox.Size = new System.Drawing.Size(640, 22);
            this.AddressTextBox.TabIndex = 20;
            // 
            // East_SouthEastTextBox
            // 
            this.East_SouthEastTextBox.Location = new System.Drawing.Point(732, 151);
            this.East_SouthEastTextBox.Name = "East_SouthEastTextBox";
            this.East_SouthEastTextBox.Size = new System.Drawing.Size(134, 22);
            this.East_SouthEastTextBox.TabIndex = 21;
            // 
            // East_SouthEastLabel
            // 
            this.East_SouthEastLabel.AutoSize = true;
            this.East_SouthEastLabel.Location = new System.Drawing.Point(739, 130);
            this.East_SouthEastLabel.Name = "East_SouthEastLabel";
            this.East_SouthEastLabel.Size = new System.Drawing.Size(99, 16);
            this.East_SouthEastLabel.TabIndex = 25;
            this.East_SouthEastLabel.Text = "East-SouthEast";
            // 
            // SouthEast_SouthLabel
            // 
            this.SouthEast_SouthLabel.AutoSize = true;
            this.SouthEast_SouthLabel.Location = new System.Drawing.Point(739, 192);
            this.SouthEast_SouthLabel.Name = "SouthEast_SouthLabel";
            this.SouthEast_SouthLabel.Size = new System.Drawing.Size(106, 16);
            this.SouthEast_SouthLabel.TabIndex = 27;
            this.SouthEast_SouthLabel.Text = "SouthEast-South";
            // 
            // SouthEast_SouthTextBox
            // 
            this.SouthEast_SouthTextBox.Location = new System.Drawing.Point(732, 213);
            this.SouthEast_SouthTextBox.Name = "SouthEast_SouthTextBox";
            this.SouthEast_SouthTextBox.Size = new System.Drawing.Size(134, 22);
            this.SouthEast_SouthTextBox.TabIndex = 26;
            // 
            // South_SouthWestLabel
            // 
            this.South_SouthWestLabel.AutoSize = true;
            this.South_SouthWestLabel.Location = new System.Drawing.Point(739, 258);
            this.South_SouthWestLabel.Name = "South_SouthWestLabel";
            this.South_SouthWestLabel.Size = new System.Drawing.Size(110, 16);
            this.South_SouthWestLabel.TabIndex = 29;
            this.South_SouthWestLabel.Text = "South-SouthWest";
            // 
            // South_SouthWestTextBox
            // 
            this.South_SouthWestTextBox.Location = new System.Drawing.Point(732, 279);
            this.South_SouthWestTextBox.Name = "South_SouthWestTextBox";
            this.South_SouthWestTextBox.Size = new System.Drawing.Size(134, 22);
            this.South_SouthWestTextBox.TabIndex = 28;
            // 
            // SouthWest_WestLabel
            // 
            this.SouthWest_WestLabel.AutoSize = true;
            this.SouthWest_WestLabel.Location = new System.Drawing.Point(739, 325);
            this.SouthWest_WestLabel.Name = "SouthWest_WestLabel";
            this.SouthWest_WestLabel.Size = new System.Drawing.Size(107, 16);
            this.SouthWest_WestLabel.TabIndex = 31;
            this.SouthWest_WestLabel.Text = "SouthWest-West";
            // 
            // SouthWest_WestTextBox
            // 
            this.SouthWest_WestTextBox.Location = new System.Drawing.Point(732, 346);
            this.SouthWest_WestTextBox.Name = "SouthWest_WestTextBox";
            this.SouthWest_WestTextBox.Size = new System.Drawing.Size(134, 22);
            this.SouthWest_WestTextBox.TabIndex = 30;
            // 
            // Map
            // 
            this.Map.Bearing = 0F;
            this.Map.CanDragMap = true;
            this.Map.EmptyTileColor = System.Drawing.Color.Navy;
            this.Map.GrayScaleMode = false;
            this.Map.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.Map.LevelsKeepInMemory = 5;
            this.Map.Location = new System.Drawing.Point(12, 117);
            this.Map.MarkersEnabled = true;
            this.Map.MaxZoom = 2;
            this.Map.MinZoom = 2;
            this.Map.MouseWheelZoomEnabled = true;
            this.Map.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.Map.Name = "Map";
            this.Map.NegativeMode = false;
            this.Map.PolygonsEnabled = true;
            this.Map.RetryLoadTile = 0;
            this.Map.RoutesEnabled = true;
            this.Map.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.Map.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.Map.ShowTileGridLines = false;
            this.Map.Size = new System.Drawing.Size(702, 346);
            this.Map.TabIndex = 0;
            this.Map.Zoom = 0D;
            this.Map.Load += new System.EventHandler(this.Map_Load);
            // 
            // BuildingDataRadioButton
            // 
            this.BuildingDataRadioButton.AutoSize = true;
            this.BuildingDataRadioButton.Location = new System.Drawing.Point(732, 430);
            this.BuildingDataRadioButton.Name = "BuildingDataRadioButton";
            this.BuildingDataRadioButton.Size = new System.Drawing.Size(141, 20);
            this.BuildingDataRadioButton.TabIndex = 33;
            this.BuildingDataRadioButton.TabStop = true;
            this.BuildingDataRadioButton.Text = "Used building data";
            this.BuildingDataRadioButton.UseVisualStyleBackColor = true;
            this.BuildingDataRadioButton.CheckedChanged += new System.EventHandler(this.BuildingDataRadioButton_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(729, 374);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 16);
            this.label1.TabIndex = 34;
            this.label1.Text = "Color buildings by";
            // 
            // DirectionRadioButton
            // 
            this.DirectionRadioButton.AutoSize = true;
            this.DirectionRadioButton.Checked = true;
            this.DirectionRadioButton.Location = new System.Drawing.Point(732, 404);
            this.DirectionRadioButton.Name = "DirectionRadioButton";
            this.DirectionRadioButton.Size = new System.Drawing.Size(81, 20);
            this.DirectionRadioButton.TabIndex = 35;
            this.DirectionRadioButton.TabStop = true;
            this.DirectionRadioButton.Text = "Direction";
            this.DirectionRadioButton.UseVisualStyleBackColor = true;
            this.DirectionRadioButton.CheckedChanged += new System.EventHandler(this.DirectionRadioButton_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(681, 469);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(210, 113);
            this.panel1.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Legend";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LightGreen;
            this.label3.Location = new System.Drawing.Point(10, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Green - East-SouthEast";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.SkyBlue;
            this.label4.Location = new System.Drawing.Point(10, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Aqua - SouthEast-South";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Orchid;
            this.label5.Location = new System.Drawing.Point(10, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Magenta: South-SouthWest";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.LightCoral;
            this.label6.Location = new System.Drawing.Point(10, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Red: SouthWest-West";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label7.Location = new System.Drawing.Point(10, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "Blue - Base building";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.SearchButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 586);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DirectionRadioButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BuildingDataRadioButton);
            this.Controls.Add(this.SouthWest_WestLabel);
            this.Controls.Add(this.SouthWest_WestTextBox);
            this.Controls.Add(this.South_SouthWestLabel);
            this.Controls.Add(this.South_SouthWestTextBox);
            this.Controls.Add(this.SouthEast_SouthLabel);
            this.Controls.Add(this.SouthEast_SouthTextBox);
            this.Controls.Add(this.East_SouthEastLabel);
            this.Controls.Add(this.East_SouthEastTextBox);
            this.Controls.Add(this.AddressTextBox);
            this.Controls.Add(this.DefaultBuildingHeightTextBox);
            this.Controls.Add(this.DefaultFloorHeightTextBox);
            this.Controls.Add(this.RadiusTextBox);
            this.Controls.Add(this.DefaultBuildingHeightLabel);
            this.Controls.Add(this.DefaultFloorHeightLabel);
            this.Controls.Add(this.RadiusLabel);
            this.Controls.Add(this.MaskButton);
            this.Controls.Add(this.ZoomOutButton);
            this.Controls.Add(this.ZoomInButton);
            this.Controls.Add(this.AddressLabel);
            this.Controls.Add(this.LongitudeLabel);
            this.Controls.Add(this.LatitudeLabel);
            this.Controls.Add(this.LongitudeTextBox);
            this.Controls.Add(this.LatitudeTextBox);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.Map);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.MaskedTextBox LatitudeTextBox;
        private System.Windows.Forms.Label LatitudeLabel;
        private System.Windows.Forms.Label LongitudeLabel;
        private System.Windows.Forms.Label AddressLabel;
        private System.Windows.Forms.Button ZoomInButton;
        private System.Windows.Forms.Button ZoomOutButton;
        private System.Windows.Forms.MaskedTextBox LongitudeTextBox;
        private System.Windows.Forms.Button MaskButton;
        private System.Windows.Forms.Label RadiusLabel;
        private System.Windows.Forms.Label DefaultFloorHeightLabel;
        private System.Windows.Forms.Label DefaultBuildingHeightLabel;
        private System.Windows.Forms.TextBox RadiusTextBox;
        private System.Windows.Forms.TextBox DefaultFloorHeightTextBox;
        private System.Windows.Forms.TextBox DefaultBuildingHeightTextBox;
        private System.Windows.Forms.TextBox AddressTextBox;
        private System.Windows.Forms.TextBox East_SouthEastTextBox;
        private System.Windows.Forms.Label East_SouthEastLabel;
        private System.Windows.Forms.Label SouthEast_SouthLabel;
        private System.Windows.Forms.TextBox SouthEast_SouthTextBox;
        private System.Windows.Forms.Label South_SouthWestLabel;
        private System.Windows.Forms.TextBox South_SouthWestTextBox;
        private System.Windows.Forms.Label SouthWest_WestLabel;
        private System.Windows.Forms.TextBox SouthWest_WestTextBox;
        private GMap.NET.WindowsForms.GMapControl Map;
        private System.Windows.Forms.RadioButton BuildingDataRadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton DirectionRadioButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

