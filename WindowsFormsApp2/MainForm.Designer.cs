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
            this.Map = new GMap.NET.WindowsForms.GMapControl();
            this.SearchButton = new System.Windows.Forms.Button();
            this.LatitudeTextBox = new System.Windows.Forms.MaskedTextBox();
            this.LongitudeTextBox = new System.Windows.Forms.MaskedTextBox();
            this.LatitudeLabel = new System.Windows.Forms.Label();
            this.LongitudeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Map
            // 
            this.Map.Bearing = 0F;
            this.Map.CanDragMap = true;
            this.Map.EmptyTileColor = System.Drawing.Color.Navy;
            this.Map.GrayScaleMode = false;
            this.Map.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.Map.LevelsKeepInMemory = 5;
            this.Map.Location = new System.Drawing.Point(375, 22);
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
            this.Map.Size = new System.Drawing.Size(348, 295);
            this.Map.TabIndex = 0;
            this.Map.Zoom = 0D;
            this.Map.Load += new System.EventHandler(this.gMapControl1_Load);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(69, 345);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(228, 75);
            this.SearchButton.TabIndex = 1;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // LatitudeTextBox
            // 
            this.LatitudeTextBox.Location = new System.Drawing.Point(83, 149);
            this.LatitudeTextBox.Name = "LatitudeTextBox";
            this.LatitudeTextBox.Size = new System.Drawing.Size(214, 22);
            this.LatitudeTextBox.TabIndex = 2;
            // 
            // LongitudeTextBox
            // 
            this.LongitudeTextBox.Location = new System.Drawing.Point(83, 232);
            this.LongitudeTextBox.Name = "LongitudeTextBox";
            this.LongitudeTextBox.Size = new System.Drawing.Size(214, 22);
            this.LongitudeTextBox.TabIndex = 3;
            // 
            // LatitudeLabel
            // 
            this.LatitudeLabel.AutoSize = true;
            this.LatitudeLabel.Location = new System.Drawing.Point(83, 121);
            this.LatitudeLabel.Name = "LatitudeLabel";
            this.LatitudeLabel.Size = new System.Drawing.Size(57, 16);
            this.LatitudeLabel.TabIndex = 4;
            this.LatitudeLabel.Text = "Latitude:";
            // 
            // LongitudeLabel
            // 
            this.LongitudeLabel.AutoSize = true;
            this.LongitudeLabel.Location = new System.Drawing.Point(83, 213);
            this.LongitudeLabel.Name = "LongitudeLabel";
            this.LongitudeLabel.Size = new System.Drawing.Size(66, 16);
            this.LongitudeLabel.TabIndex = 5;
            this.LongitudeLabel.Text = "Longitude";
            this.LongitudeLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LongitudeLabel);
            this.Controls.Add(this.LatitudeLabel);
            this.Controls.Add(this.LongitudeTextBox);
            this.Controls.Add(this.LatitudeTextBox);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.Map);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl Map;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.MaskedTextBox LatitudeTextBox;
        private System.Windows.Forms.MaskedTextBox LongitudeTextBox;
        private System.Windows.Forms.Label LatitudeLabel;
        private System.Windows.Forms.Label LongitudeLabel;
    }
}

