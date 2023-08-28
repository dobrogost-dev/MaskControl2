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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
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
            this.RadiusTextBox = new System.Windows.Forms.TextBox();
            this.AddressTextBox = new System.Windows.Forms.TextBox();
            this.MaskLeftResult = new System.Windows.Forms.TextBox();
            this.MaskLeftLabel = new System.Windows.Forms.Label();
            this.MaskLeftMiddleLabel = new System.Windows.Forms.Label();
            this.MaskLeftMiddleResult = new System.Windows.Forms.TextBox();
            this.MaskRightMiddleLabel = new System.Windows.Forms.Label();
            this.MaskRightMiddleResult = new System.Windows.Forms.TextBox();
            this.MaskRightLabel = new System.Windows.Forms.Label();
            this.MaskRightResult = new System.Windows.Forms.TextBox();
            this.Map = new GMap.NET.WindowsForms.GMapControl();
            this.BuildingDataRadioButton = new System.Windows.Forms.RadioButton();
            this.ColorBuildingsByLabel = new System.Windows.Forms.Label();
            this.DirectionRadioButton = new System.Windows.Forms.RadioButton();
            this.SectorsLegendPanel = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BuildingDataLegendPanel = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.SectorsCheckBox = new System.Windows.Forms.CheckBox();
            this.FacadeDirectionDescriptionLabel = new System.Windows.Forms.Label();
            this.FacadeDirectionLabel = new System.Windows.Forms.Label();
            this.DefaultBuildingFloorHeightTextBox = new System.Windows.Forms.TextBox();
            this.DefaultBuildingFloorHeightLabel = new System.Windows.Forms.Label();
            this.ManualSelectionButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SelectionModeLabel = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.SectorsLegendPanel.SuspendLayout();
            this.BuildingDataLegendPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SearchButton
            // 
            resources.ApplyResources(this.SearchButton, "SearchButton");
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_ClickAsync);
            // 
            // LatitudeTextBox
            // 
            resources.ApplyResources(this.LatitudeTextBox, "LatitudeTextBox");
            this.LatitudeTextBox.Name = "LatitudeTextBox";
            // 
            // LatitudeLabel
            // 
            resources.ApplyResources(this.LatitudeLabel, "LatitudeLabel");
            this.LatitudeLabel.Name = "LatitudeLabel";
            // 
            // LongitudeLabel
            // 
            resources.ApplyResources(this.LongitudeLabel, "LongitudeLabel");
            this.LongitudeLabel.Name = "LongitudeLabel";
            // 
            // AddressLabel
            // 
            resources.ApplyResources(this.AddressLabel, "AddressLabel");
            this.AddressLabel.Name = "AddressLabel";
            // 
            // ZoomInButton
            // 
            resources.ApplyResources(this.ZoomInButton, "ZoomInButton");
            this.ZoomInButton.Name = "ZoomInButton";
            this.ZoomInButton.UseVisualStyleBackColor = true;
            this.ZoomInButton.Click += new System.EventHandler(this.ZoomInButton_Click);
            // 
            // ZoomOutButton
            // 
            resources.ApplyResources(this.ZoomOutButton, "ZoomOutButton");
            this.ZoomOutButton.Name = "ZoomOutButton";
            this.ZoomOutButton.UseVisualStyleBackColor = true;
            this.ZoomOutButton.Click += new System.EventHandler(this.ZoomOutButton_Click);
            // 
            // LongitudeTextBox
            // 
            resources.ApplyResources(this.LongitudeTextBox, "LongitudeTextBox");
            this.LongitudeTextBox.Name = "LongitudeTextBox";
            // 
            // MaskButton
            // 
            resources.ApplyResources(this.MaskButton, "MaskButton");
            this.MaskButton.Name = "MaskButton";
            this.MaskButton.UseVisualStyleBackColor = true;
            this.MaskButton.Click += new System.EventHandler(this.MaskButton_Click);
            // 
            // RadiusLabel
            // 
            resources.ApplyResources(this.RadiusLabel, "RadiusLabel");
            this.RadiusLabel.Name = "RadiusLabel";
            // 
            // RadiusTextBox
            // 
            resources.ApplyResources(this.RadiusTextBox, "RadiusTextBox");
            this.RadiusTextBox.Name = "RadiusTextBox";
            this.RadiusTextBox.TextChanged += new System.EventHandler(this.RadiusTextBox_TextChanged);
            // 
            // AddressTextBox
            // 
            resources.ApplyResources(this.AddressTextBox, "AddressTextBox");
            this.AddressTextBox.Name = "AddressTextBox";
            // 
            // MaskLeftResult
            // 
            resources.ApplyResources(this.MaskLeftResult, "MaskLeftResult");
            this.MaskLeftResult.Name = "MaskLeftResult";
            // 
            // MaskLeftLabel
            // 
            resources.ApplyResources(this.MaskLeftLabel, "MaskLeftLabel");
            this.MaskLeftLabel.Name = "MaskLeftLabel";
            // 
            // MaskLeftMiddleLabel
            // 
            resources.ApplyResources(this.MaskLeftMiddleLabel, "MaskLeftMiddleLabel");
            this.MaskLeftMiddleLabel.Name = "MaskLeftMiddleLabel";
            // 
            // MaskLeftMiddleResult
            // 
            resources.ApplyResources(this.MaskLeftMiddleResult, "MaskLeftMiddleResult");
            this.MaskLeftMiddleResult.Name = "MaskLeftMiddleResult";
            // 
            // MaskRightMiddleLabel
            // 
            resources.ApplyResources(this.MaskRightMiddleLabel, "MaskRightMiddleLabel");
            this.MaskRightMiddleLabel.Name = "MaskRightMiddleLabel";
            // 
            // MaskRightMiddleResult
            // 
            resources.ApplyResources(this.MaskRightMiddleResult, "MaskRightMiddleResult");
            this.MaskRightMiddleResult.Name = "MaskRightMiddleResult";
            // 
            // MaskRightLabel
            // 
            resources.ApplyResources(this.MaskRightLabel, "MaskRightLabel");
            this.MaskRightLabel.Name = "MaskRightLabel";
            // 
            // MaskRightResult
            // 
            resources.ApplyResources(this.MaskRightResult, "MaskRightResult");
            this.MaskRightResult.Name = "MaskRightResult";
            // 
            // Map
            // 
            this.Map.Bearing = 0F;
            this.Map.CanDragMap = true;
            this.Map.EmptyTileColor = System.Drawing.Color.Navy;
            this.Map.GrayScaleMode = false;
            this.Map.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.Map.LevelsKeepInMemory = 5;
            resources.ApplyResources(this.Map, "Map");
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
            this.Map.Zoom = 0D;
            // 
            // BuildingDataRadioButton
            // 
            resources.ApplyResources(this.BuildingDataRadioButton, "BuildingDataRadioButton");
            this.BuildingDataRadioButton.Name = "BuildingDataRadioButton";
            this.BuildingDataRadioButton.TabStop = true;
            this.BuildingDataRadioButton.UseVisualStyleBackColor = true;
            this.BuildingDataRadioButton.CheckedChanged += new System.EventHandler(this.BuildingDataRadioButton_CheckedChanged);
            // 
            // ColorBuildingsByLabel
            // 
            resources.ApplyResources(this.ColorBuildingsByLabel, "ColorBuildingsByLabel");
            this.ColorBuildingsByLabel.Name = "ColorBuildingsByLabel";
            // 
            // DirectionRadioButton
            // 
            resources.ApplyResources(this.DirectionRadioButton, "DirectionRadioButton");
            this.DirectionRadioButton.Checked = true;
            this.DirectionRadioButton.Name = "DirectionRadioButton";
            this.DirectionRadioButton.TabStop = true;
            this.DirectionRadioButton.UseVisualStyleBackColor = true;
            this.DirectionRadioButton.CheckedChanged += new System.EventHandler(this.DirectionRadioButton_CheckedChanged);
            // 
            // SectorsLegendPanel
            // 
            this.SectorsLegendPanel.Controls.Add(this.label14);
            this.SectorsLegendPanel.Controls.Add(this.label7);
            this.SectorsLegendPanel.Controls.Add(this.label6);
            this.SectorsLegendPanel.Controls.Add(this.label5);
            this.SectorsLegendPanel.Controls.Add(this.label4);
            this.SectorsLegendPanel.Controls.Add(this.label3);
            this.SectorsLegendPanel.Controls.Add(this.label2);
            resources.ApplyResources(this.SectorsLegendPanel, "SectorsLegendPanel");
            this.SectorsLegendPanel.Name = "SectorsLegendPanel";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.BackColor = System.Drawing.Color.DarkGray;
            this.label14.Name = "label14";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.LightCoral;
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.Color.Orchid;
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.SkyBlue;
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.LightGreen;
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // BuildingDataLegendPanel
            // 
            this.BuildingDataLegendPanel.Controls.Add(this.label15);
            this.BuildingDataLegendPanel.Controls.Add(this.label11);
            this.BuildingDataLegendPanel.Controls.Add(this.label8);
            this.BuildingDataLegendPanel.Controls.Add(this.label9);
            this.BuildingDataLegendPanel.Controls.Add(this.label10);
            this.BuildingDataLegendPanel.Controls.Add(this.label12);
            this.BuildingDataLegendPanel.Controls.Add(this.label13);
            resources.ApplyResources(this.BuildingDataLegendPanel, "BuildingDataLegendPanel");
            this.BuildingDataLegendPanel.Name = "BuildingDataLegendPanel";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.BackColor = System.Drawing.Color.DarkGray;
            this.label11.Name = "label11";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label8.Name = "label8";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.BackColor = System.Drawing.Color.LightCoral;
            this.label9.Name = "label9";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.BackColor = System.Drawing.Color.SandyBrown;
            this.label10.Name = "label10";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.BackColor = System.Drawing.Color.LightGreen;
            this.label12.Name = "label12";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // SectorsCheckBox
            // 
            resources.ApplyResources(this.SectorsCheckBox, "SectorsCheckBox");
            this.SectorsCheckBox.Name = "SectorsCheckBox";
            this.SectorsCheckBox.UseVisualStyleBackColor = true;
            this.SectorsCheckBox.CheckedChanged += new System.EventHandler(this.DirectionLinesCheckBox_CheckedChanged);
            // 
            // FacadeDirectionDescriptionLabel
            // 
            resources.ApplyResources(this.FacadeDirectionDescriptionLabel, "FacadeDirectionDescriptionLabel");
            this.FacadeDirectionDescriptionLabel.Name = "FacadeDirectionDescriptionLabel";
            // 
            // FacadeDirectionLabel
            // 
            resources.ApplyResources(this.FacadeDirectionLabel, "FacadeDirectionLabel");
            this.FacadeDirectionLabel.Name = "FacadeDirectionLabel";
            // 
            // DefaultBuildingFloorHeightTextBox
            // 
            resources.ApplyResources(this.DefaultBuildingFloorHeightTextBox, "DefaultBuildingFloorHeightTextBox");
            this.DefaultBuildingFloorHeightTextBox.Name = "DefaultBuildingFloorHeightTextBox";
            this.DefaultBuildingFloorHeightTextBox.TextChanged += new System.EventHandler(this.DefaultBuildingFloorHeightTextBox_TextChanged);
            // 
            // DefaultBuildingFloorHeightLabel
            // 
            resources.ApplyResources(this.DefaultBuildingFloorHeightLabel, "DefaultBuildingFloorHeightLabel");
            this.DefaultBuildingFloorHeightLabel.Name = "DefaultBuildingFloorHeightLabel";
            // 
            // ManualSelectionButton
            // 
            resources.ApplyResources(this.ManualSelectionButton, "ManualSelectionButton");
            this.ManualSelectionButton.Name = "ManualSelectionButton";
            this.ManualSelectionButton.UseVisualStyleBackColor = true;
            this.ManualSelectionButton.Click += new System.EventHandler(this.ManualSelectionButton_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // SelectionModeLabel
            // 
            resources.ApplyResources(this.SelectionModeLabel, "SelectionModeLabel");
            this.SelectionModeLabel.Name = "SelectionModeLabel";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.BackColor = System.Drawing.Color.Khaki;
            this.label15.Name = "label15";
            // 
            // MainForm
            // 
            this.AcceptButton = this.SearchButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SelectionModeLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ManualSelectionButton);
            this.Controls.Add(this.DefaultBuildingFloorHeightTextBox);
            this.Controls.Add(this.DefaultBuildingFloorHeightLabel);
            this.Controls.Add(this.FacadeDirectionLabel);
            this.Controls.Add(this.FacadeDirectionDescriptionLabel);
            this.Controls.Add(this.SectorsCheckBox);
            this.Controls.Add(this.DirectionRadioButton);
            this.Controls.Add(this.ColorBuildingsByLabel);
            this.Controls.Add(this.BuildingDataRadioButton);
            this.Controls.Add(this.MaskRightLabel);
            this.Controls.Add(this.MaskRightResult);
            this.Controls.Add(this.MaskRightMiddleLabel);
            this.Controls.Add(this.MaskRightMiddleResult);
            this.Controls.Add(this.MaskLeftMiddleLabel);
            this.Controls.Add(this.MaskLeftMiddleResult);
            this.Controls.Add(this.MaskLeftLabel);
            this.Controls.Add(this.MaskLeftResult);
            this.Controls.Add(this.AddressTextBox);
            this.Controls.Add(this.RadiusTextBox);
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
            this.Controls.Add(this.BuildingDataLegendPanel);
            this.Controls.Add(this.SectorsLegendPanel);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SectorsLegendPanel.ResumeLayout(false);
            this.SectorsLegendPanel.PerformLayout();
            this.BuildingDataLegendPanel.ResumeLayout(false);
            this.BuildingDataLegendPanel.PerformLayout();
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
        private System.Windows.Forms.TextBox RadiusTextBox;
        private System.Windows.Forms.TextBox AddressTextBox;
        private System.Windows.Forms.TextBox MaskLeftResult;
        private System.Windows.Forms.Label MaskLeftLabel;
        private System.Windows.Forms.Label MaskLeftMiddleLabel;
        private System.Windows.Forms.TextBox MaskLeftMiddleResult;
        private System.Windows.Forms.Label MaskRightMiddleLabel;
        private System.Windows.Forms.TextBox MaskRightMiddleResult;
        private System.Windows.Forms.Label MaskRightLabel;
        private System.Windows.Forms.TextBox MaskRightResult;
        private GMap.NET.WindowsForms.GMapControl Map;
        private System.Windows.Forms.RadioButton BuildingDataRadioButton;
        private System.Windows.Forms.Label ColorBuildingsByLabel;
        private System.Windows.Forms.RadioButton DirectionRadioButton;
        private System.Windows.Forms.Panel SectorsLegendPanel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel BuildingDataLegendPanel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox SectorsCheckBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label FacadeDirectionDescriptionLabel;
        private System.Windows.Forms.Label FacadeDirectionLabel;
        private System.Windows.Forms.TextBox DefaultBuildingFloorHeightTextBox;
        private System.Windows.Forms.Label DefaultBuildingFloorHeightLabel;
        private System.Windows.Forms.Button ManualSelectionButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label SelectionModeLabel;
        private System.Windows.Forms.Label label15;
    }
}

