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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.DefaultLeftMiddleBuildingHeightTextBox = new System.Windows.Forms.TextBox();
            this.DefaultRightMiddleBuildingHeightTextBox = new System.Windows.Forms.TextBox();
            this.DefaultRightBuildingHeightTextBox = new System.Windows.Forms.TextBox();
            this.InformationLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // FacadeDirectionLabel
            // 
            this.FacadeDirectionLabel.AutoSize = true;
            this.FacadeDirectionLabel.Location = new System.Drawing.Point(558, 130);
            this.FacadeDirectionLabel.Name = "FacadeDirectionLabel";
            this.FacadeDirectionLabel.Size = new System.Drawing.Size(0, 16);
            this.FacadeDirectionLabel.TabIndex = 53;
            // 
            // DefaultLeftBuildingHeightTextBox
            // 
            this.DefaultLeftBuildingHeightTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DefaultLeftBuildingHeightTextBox.Location = new System.Drawing.Point(12, 295);
            this.DefaultLeftBuildingHeightTextBox.Name = "DefaultLeftBuildingHeightTextBox";
            this.DefaultLeftBuildingHeightTextBox.Size = new System.Drawing.Size(81, 22);
            this.DefaultLeftBuildingHeightTextBox.TabIndex = 51;
            this.DefaultLeftBuildingHeightTextBox.Visible = false;
            this.DefaultLeftBuildingHeightTextBox.TextChanged += new System.EventHandler(this.DefaultLeftBuildingHeightTextBox_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApp2.Properties.Resources.masqueLontain2;
            this.pictureBox1.Location = new System.Drawing.Point(1, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(692, 349);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 60;
            this.pictureBox1.TabStop = false;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(190, 349);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(109, 37);
            this.CancelButton.TabIndex = 61;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(393, 349);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(109, 37);
            this.ConfirmButton.TabIndex = 62;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // DefaultLeftMiddleBuildingHeightTextBox
            // 
            this.DefaultLeftMiddleBuildingHeightTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DefaultLeftMiddleBuildingHeightTextBox.Location = new System.Drawing.Point(218, 152);
            this.DefaultLeftMiddleBuildingHeightTextBox.Name = "DefaultLeftMiddleBuildingHeightTextBox";
            this.DefaultLeftMiddleBuildingHeightTextBox.Size = new System.Drawing.Size(81, 22);
            this.DefaultLeftMiddleBuildingHeightTextBox.TabIndex = 63;
            this.DefaultLeftMiddleBuildingHeightTextBox.Visible = false;
            this.DefaultLeftMiddleBuildingHeightTextBox.TextChanged += new System.EventHandler(this.DefaultLeftMiddleBuildingHeightTextBox_TextChanged);
            // 
            // DefaultRightMiddleBuildingHeightTextBox
            // 
            this.DefaultRightMiddleBuildingHeightTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DefaultRightMiddleBuildingHeightTextBox.Location = new System.Drawing.Point(393, 124);
            this.DefaultRightMiddleBuildingHeightTextBox.Name = "DefaultRightMiddleBuildingHeightTextBox";
            this.DefaultRightMiddleBuildingHeightTextBox.Size = new System.Drawing.Size(81, 22);
            this.DefaultRightMiddleBuildingHeightTextBox.TabIndex = 64;
            this.DefaultRightMiddleBuildingHeightTextBox.Visible = false;
            this.DefaultRightMiddleBuildingHeightTextBox.TextChanged += new System.EventHandler(this.DefaultRightMiddleBuildingHeightTextBox_TextChanged);
            // 
            // DefaultRightBuildingHeightTextBox
            // 
            this.DefaultRightBuildingHeightTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DefaultRightBuildingHeightTextBox.Location = new System.Drawing.Point(597, 206);
            this.DefaultRightBuildingHeightTextBox.Name = "DefaultRightBuildingHeightTextBox";
            this.DefaultRightBuildingHeightTextBox.Size = new System.Drawing.Size(81, 22);
            this.DefaultRightBuildingHeightTextBox.TabIndex = 65;
            this.DefaultRightBuildingHeightTextBox.Visible = false;
            this.DefaultRightBuildingHeightTextBox.TextChanged += new System.EventHandler(this.DefaultRightBuildingHeightTextBox_TextChanged);
            // 
            // InformationLabel
            // 
            this.InformationLabel.AutoSize = true;
            this.InformationLabel.Location = new System.Drawing.Point(9, 9);
            this.InformationLabel.MaximumSize = new System.Drawing.Size(650, 0);
            this.InformationLabel.Name = "InformationLabel";
            this.InformationLabel.Size = new System.Drawing.Size(607, 32);
            this.InformationLabel.TabIndex = 66;
            this.InformationLabel.Text = resources.GetString("InformationLabel.Text");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 16);
            this.label1.TabIndex = 67;
            this.label1.Text = "Default building heights for sectors:";
            // 
            // DefaultHeightForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 390);
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
            this.Name = "DefaultHeightForm";
            this.ShowIcon = false;
            this.Text = "Missing building heights";
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