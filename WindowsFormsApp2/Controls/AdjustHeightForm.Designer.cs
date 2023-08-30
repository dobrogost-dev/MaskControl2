namespace WindowsFormsApp2.Controls
{
    partial class AdjustHeightForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdjustHeightForm));
            this.ChoosingHeightLabel = new System.Windows.Forms.Label();
            this.ChoosingHeightTextBox = new System.Windows.Forms.TextBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ChoosingHeightLabel
            // 
            resources.ApplyResources(this.ChoosingHeightLabel, "ChoosingHeightLabel");
            this.ChoosingHeightLabel.Name = "ChoosingHeightLabel";
            // 
            // ChoosingHeightTextBox
            // 
            resources.ApplyResources(this.ChoosingHeightTextBox, "ChoosingHeightTextBox");
            this.ChoosingHeightTextBox.Name = "ChoosingHeightTextBox";
            this.ChoosingHeightTextBox.TextChanged += new System.EventHandler(this.ChoosingHeightTextBox_TextChanged);
            // 
            // CancelButton
            // 
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
            // ResetButton
            // 
            resources.ApplyResources(this.ResetButton, "ResetButton");
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // AdjustHeightForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ChoosingHeightTextBox);
            this.Controls.Add(this.ChoosingHeightLabel);
            this.Name = "AdjustHeightForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ChoosingHeightLabel;
        private System.Windows.Forms.TextBox ChoosingHeightTextBox;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Button ResetButton;
    }
}