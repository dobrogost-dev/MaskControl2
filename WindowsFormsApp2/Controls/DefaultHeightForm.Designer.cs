namespace WindowsFormsApp2
{
    partial class DefaultHeightForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DefaultHeightForm));
            this.FacadeDirectionLabel = new System.Windows.Forms.Label();
            this.DefaultLeftBuildingHeightTextBox = new System.Windows.Forms.TextBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.DefaultLeftMiddleBuildingHeightTextBox = new System.Windows.Forms.TextBox();
            this.DefaultRightMiddleBuildingHeightTextBox = new System.Windows.Forms.TextBox();
            this.DefaultRightBuildingHeightTextBox = new System.Windows.Forms.TextBox();
            this.InformationLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // FacadeDirectionLabel
            // 
            resources.ApplyResources(this.FacadeDirectionLabel, "FacadeDirectionLabel");
            this.FacadeDirectionLabel.Name = "FacadeDirectionLabel";
            // 
            // DefaultLeftBuildingHeightTextBox
            // 
            this.DefaultLeftBuildingHeightTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.DefaultLeftBuildingHeightTextBox, "DefaultLeftBuildingHeightTextBox");
            this.DefaultLeftBuildingHeightTextBox.Name = "DefaultLeftBuildingHeightTextBox";
            this.DefaultLeftBuildingHeightTextBox.TextChanged += new System.EventHandler(this.DefaultLeftBuildingHeightTextBox_TextChanged);
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.CancelButton, "CancelButton");
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ConfirmButton
            // 
            resources.ApplyResources(this.ConfirmButton, "ConfirmButton");
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // DefaultLeftMiddleBuildingHeightTextBox
            // 
            this.DefaultLeftMiddleBuildingHeightTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.DefaultLeftMiddleBuildingHeightTextBox, "DefaultLeftMiddleBuildingHeightTextBox");
            this.DefaultLeftMiddleBuildingHeightTextBox.Name = "DefaultLeftMiddleBuildingHeightTextBox";
            this.DefaultLeftMiddleBuildingHeightTextBox.TextChanged += new System.EventHandler(this.DefaultLeftMiddleBuildingHeightTextBox_TextChanged);
            // 
            // DefaultRightMiddleBuildingHeightTextBox
            // 
            this.DefaultRightMiddleBuildingHeightTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.DefaultRightMiddleBuildingHeightTextBox, "DefaultRightMiddleBuildingHeightTextBox");
            this.DefaultRightMiddleBuildingHeightTextBox.Name = "DefaultRightMiddleBuildingHeightTextBox";
            this.DefaultRightMiddleBuildingHeightTextBox.TextChanged += new System.EventHandler(this.DefaultRightMiddleBuildingHeightTextBox_TextChanged);
            // 
            // DefaultRightBuildingHeightTextBox
            // 
            this.DefaultRightBuildingHeightTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.DefaultRightBuildingHeightTextBox, "DefaultRightBuildingHeightTextBox");
            this.DefaultRightBuildingHeightTextBox.Name = "DefaultRightBuildingHeightTextBox";
            this.DefaultRightBuildingHeightTextBox.TextChanged += new System.EventHandler(this.DefaultRightBuildingHeightTextBox_TextChanged);
            // 
            // InformationLabel
            // 
            resources.ApplyResources(this.InformationLabel, "InformationLabel");
            this.InformationLabel.Name = "InformationLabel";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApp2.Properties.Resources.masqueLontain2;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // DefaultHeightForm
            // 
            this.AcceptButton = this.ConfirmButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelButton;
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InformationLabel);
            this.Controls.Add(this.DefaultRightBuildingHeightTextBox);
            this.Controls.Add(this.DefaultRightMiddleBuildingHeightTextBox);
            this.Controls.Add(this.DefaultLeftMiddleBuildingHeightTextBox);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.FacadeDirectionLabel);
            this.Controls.Add(this.DefaultLeftBuildingHeightTextBox);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DefaultHeightForm";
            this.ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label FacadeDirectionLabel;
        private System.Windows.Forms.TextBox DefaultLeftBuildingHeightTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.TextBox DefaultLeftMiddleBuildingHeightTextBox;
        private System.Windows.Forms.TextBox DefaultRightMiddleBuildingHeightTextBox;
        private System.Windows.Forms.TextBox DefaultRightBuildingHeightTextBox;
        private System.Windows.Forms.Label InformationLabel;
        private System.Windows.Forms.Label label1;
    }
}