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
            this.SectorsLegendPanelIgnoredLabel = new System.Windows.Forms.Label();
            this.SectorsLegendPanelBaseLabel = new System.Windows.Forms.Label();
            this.SectorsLegendPanelRightLabel = new System.Windows.Forms.Label();
            this.SectorsLegendPanelRightMiddleLabel = new System.Windows.Forms.Label();
            this.SectorsLegendPanelLeftMiddleLabel = new System.Windows.Forms.Label();
            this.SectorsLegendPanelLeftLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BuildingDataLegendPanel = new System.Windows.Forms.Panel();
            this.BuildingDataLegendPanelUserHeightLabel = new System.Windows.Forms.Label();
            this.BuildingDataLegendPanelIgnoredLabel = new System.Windows.Forms.Label();
            this.BuildingDataLegendPanelBaseLabel = new System.Windows.Forms.Label();
            this.BuildingDataLegendPanelDefaultHeightLabel = new System.Windows.Forms.Label();
            this.BuildingDataLegendPanelBuildingFloorsLabel = new System.Windows.Forms.Label();
            this.BuildingDataLegendPanelHeightLabel = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.SectorsCheckBox = new System.Windows.Forms.CheckBox();
            this.FacadeDirectionDescriptionLabel = new System.Windows.Forms.Label();
            this.FacadeDirectionLabel = new System.Windows.Forms.Label();
            this.DefaultBuildingFloorHeightTextBox = new System.Windows.Forms.TextBox();
            this.DefaultBuildingFloorHeightLabel = new System.Windows.Forms.Label();
            this.ManualSelectionButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SelectionModeLabel = new System.Windows.Forms.Label();
            this.ResetButton = new System.Windows.Forms.Button();
            this.AdjustDefaultBuildingHeightButton = new System.Windows.Forms.Button();
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
            this.SectorsLegendPanel.Controls.Add(this.SectorsLegendPanelIgnoredLabel);
            this.SectorsLegendPanel.Controls.Add(this.SectorsLegendPanelBaseLabel);
            this.SectorsLegendPanel.Controls.Add(this.SectorsLegendPanelRightLabel);
            this.SectorsLegendPanel.Controls.Add(this.SectorsLegendPanelRightMiddleLabel);
            this.SectorsLegendPanel.Controls.Add(this.SectorsLegendPanelLeftMiddleLabel);
            this.SectorsLegendPanel.Controls.Add(this.SectorsLegendPanelLeftLabel);
            this.SectorsLegendPanel.Controls.Add(this.label2);
            resources.ApplyResources(this.SectorsLegendPanel, "SectorsLegendPanel");
            this.SectorsLegendPanel.Name = "SectorsLegendPanel";
            // 
            // SectorsLegendPanelIgnoredLabel
            // 
            resources.ApplyResources(this.SectorsLegendPanelIgnoredLabel, "SectorsLegendPanelIgnoredLabel");
            this.SectorsLegendPanelIgnoredLabel.BackColor = System.Drawing.Color.DarkGray;
            this.SectorsLegendPanelIgnoredLabel.Name = "SectorsLegendPanelIgnoredLabel";
            // 
            // SectorsLegendPanelBaseLabel
            // 
            resources.ApplyResources(this.SectorsLegendPanelBaseLabel, "SectorsLegendPanelBaseLabel");
            this.SectorsLegendPanelBaseLabel.BackColor = System.Drawing.Color.CornflowerBlue;
            this.SectorsLegendPanelBaseLabel.Name = "SectorsLegendPanelBaseLabel";
            // 
            // SectorsLegendPanelRightLabel
            // 
            resources.ApplyResources(this.SectorsLegendPanelRightLabel, "SectorsLegendPanelRightLabel");
            this.SectorsLegendPanelRightLabel.BackColor = System.Drawing.Color.LightCoral;
            this.SectorsLegendPanelRightLabel.Name = "SectorsLegendPanelRightLabel";
            // 
            // SectorsLegendPanelRightMiddleLabel
            // 
            resources.ApplyResources(this.SectorsLegendPanelRightMiddleLabel, "SectorsLegendPanelRightMiddleLabel");
            this.SectorsLegendPanelRightMiddleLabel.BackColor = System.Drawing.Color.Orchid;
            this.SectorsLegendPanelRightMiddleLabel.Name = "SectorsLegendPanelRightMiddleLabel";
            // 
            // SectorsLegendPanelLeftMiddleLabel
            // 
            resources.ApplyResources(this.SectorsLegendPanelLeftMiddleLabel, "SectorsLegendPanelLeftMiddleLabel");
            this.SectorsLegendPanelLeftMiddleLabel.BackColor = System.Drawing.Color.SkyBlue;
            this.SectorsLegendPanelLeftMiddleLabel.Name = "SectorsLegendPanelLeftMiddleLabel";
            // 
            // SectorsLegendPanelLeftLabel
            // 
            resources.ApplyResources(this.SectorsLegendPanelLeftLabel, "SectorsLegendPanelLeftLabel");
            this.SectorsLegendPanelLeftLabel.BackColor = System.Drawing.Color.LightGreen;
            this.SectorsLegendPanelLeftLabel.Name = "SectorsLegendPanelLeftLabel";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // BuildingDataLegendPanel
            // 
            this.BuildingDataLegendPanel.Controls.Add(this.BuildingDataLegendPanelUserHeightLabel);
            this.BuildingDataLegendPanel.Controls.Add(this.BuildingDataLegendPanelIgnoredLabel);
            this.BuildingDataLegendPanel.Controls.Add(this.BuildingDataLegendPanelBaseLabel);
            this.BuildingDataLegendPanel.Controls.Add(this.BuildingDataLegendPanelDefaultHeightLabel);
            this.BuildingDataLegendPanel.Controls.Add(this.BuildingDataLegendPanelBuildingFloorsLabel);
            this.BuildingDataLegendPanel.Controls.Add(this.BuildingDataLegendPanelHeightLabel);
            this.BuildingDataLegendPanel.Controls.Add(this.label13);
            resources.ApplyResources(this.BuildingDataLegendPanel, "BuildingDataLegendPanel");
            this.BuildingDataLegendPanel.Name = "BuildingDataLegendPanel";
            // 
            // BuildingDataLegendPanelUserHeightLabel
            // 
            resources.ApplyResources(this.BuildingDataLegendPanelUserHeightLabel, "BuildingDataLegendPanelUserHeightLabel");
            this.BuildingDataLegendPanelUserHeightLabel.BackColor = System.Drawing.Color.Khaki;
            this.BuildingDataLegendPanelUserHeightLabel.Name = "BuildingDataLegendPanelUserHeightLabel";
            // 
            // BuildingDataLegendPanelIgnoredLabel
            // 
            resources.ApplyResources(this.BuildingDataLegendPanelIgnoredLabel, "BuildingDataLegendPanelIgnoredLabel");
            this.BuildingDataLegendPanelIgnoredLabel.BackColor = System.Drawing.Color.DarkGray;
            this.BuildingDataLegendPanelIgnoredLabel.Name = "BuildingDataLegendPanelIgnoredLabel";
            // 
            // BuildingDataLegendPanelBaseLabel
            // 
            resources.ApplyResources(this.BuildingDataLegendPanelBaseLabel, "BuildingDataLegendPanelBaseLabel");
            this.BuildingDataLegendPanelBaseLabel.BackColor = System.Drawing.Color.CornflowerBlue;
            this.BuildingDataLegendPanelBaseLabel.Name = "BuildingDataLegendPanelBaseLabel";
            // 
            // BuildingDataLegendPanelDefaultHeightLabel
            // 
            resources.ApplyResources(this.BuildingDataLegendPanelDefaultHeightLabel, "BuildingDataLegendPanelDefaultHeightLabel");
            this.BuildingDataLegendPanelDefaultHeightLabel.BackColor = System.Drawing.Color.LightCoral;
            this.BuildingDataLegendPanelDefaultHeightLabel.Name = "BuildingDataLegendPanelDefaultHeightLabel";
            // 
            // BuildingDataLegendPanelBuildingFloorsLabel
            // 
            resources.ApplyResources(this.BuildingDataLegendPanelBuildingFloorsLabel, "BuildingDataLegendPanelBuildingFloorsLabel");
            this.BuildingDataLegendPanelBuildingFloorsLabel.BackColor = System.Drawing.Color.SandyBrown;
            this.BuildingDataLegendPanelBuildingFloorsLabel.Name = "BuildingDataLegendPanelBuildingFloorsLabel";
            // 
            // BuildingDataLegendPanelHeightLabel
            // 
            resources.ApplyResources(this.BuildingDataLegendPanelHeightLabel, "BuildingDataLegendPanelHeightLabel");
            this.BuildingDataLegendPanelHeightLabel.BackColor = System.Drawing.Color.LightGreen;
            this.BuildingDataLegendPanelHeightLabel.Name = "BuildingDataLegendPanelHeightLabel";
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
            this.SelectionModeLabel.Click += new System.EventHandler(this.SelectionModeLabel_Click);
            // 
            // ResetButton
            // 
            resources.ApplyResources(this.ResetButton, "ResetButton");
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // AdjustDefaultBuildingHeightButton
            // 
            resources.ApplyResources(this.AdjustDefaultBuildingHeightButton, "AdjustDefaultBuildingHeightButton");
            this.AdjustDefaultBuildingHeightButton.Name = "AdjustDefaultBuildingHeightButton";
            this.AdjustDefaultBuildingHeightButton.UseVisualStyleBackColor = true;
            this.AdjustDefaultBuildingHeightButton.Click += new System.EventHandler(this.AdjustDefaultBuildingHeightButton_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.SearchButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AdjustDefaultBuildingHeightButton);
            this.Controls.Add(this.ResetButton);
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
            this.Controls.Add(this.SectorsLegendPanel);
            this.Controls.Add(this.BuildingDataLegendPanel);
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
        private System.Windows.Forms.Label SectorsLegendPanelBaseLabel;
        private System.Windows.Forms.Label SectorsLegendPanelRightLabel;
        private System.Windows.Forms.Label SectorsLegendPanelRightMiddleLabel;
        private System.Windows.Forms.Label SectorsLegendPanelLeftMiddleLabel;
        private System.Windows.Forms.Label SectorsLegendPanelLeftLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel BuildingDataLegendPanel;
        private System.Windows.Forms.Label BuildingDataLegendPanelBaseLabel;
        private System.Windows.Forms.Label BuildingDataLegendPanelDefaultHeightLabel;
        private System.Windows.Forms.Label BuildingDataLegendPanelBuildingFloorsLabel;
        private System.Windows.Forms.Label BuildingDataLegendPanelHeightLabel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox SectorsCheckBox;
        private System.Windows.Forms.Label BuildingDataLegendPanelIgnoredLabel;
        private System.Windows.Forms.Label SectorsLegendPanelIgnoredLabel;
        private System.Windows.Forms.Label FacadeDirectionDescriptionLabel;
        private System.Windows.Forms.Label FacadeDirectionLabel;
        private System.Windows.Forms.TextBox DefaultBuildingFloorHeightTextBox;
        private System.Windows.Forms.Label DefaultBuildingFloorHeightLabel;
        private System.Windows.Forms.Button ManualSelectionButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label SelectionModeLabel;
        private System.Windows.Forms.Label BuildingDataLegendPanelUserHeightLabel;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Button AdjustDefaultBuildingHeightButton;
    }
}

