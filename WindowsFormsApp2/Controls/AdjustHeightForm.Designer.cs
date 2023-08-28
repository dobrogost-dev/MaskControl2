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
            this.ChoosingHeightLabel = new System.Windows.Forms.Label();
            this.ChoosingHeightTextBox = new System.Windows.Forms.TextBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ChoosingHeightLabel
            // 
            this.ChoosingHeightLabel.AutoSize = true;
            this.ChoosingHeightLabel.Location = new System.Drawing.Point(12, 22);
            this.ChoosingHeightLabel.Name = "ChoosingHeightLabel";
            this.ChoosingHeightLabel.Size = new System.Drawing.Size(168, 16);
            this.ChoosingHeightLabel.TabIndex = 0;
            this.ChoosingHeightLabel.Text = "Height of selected building:";
            // 
            // ChoosingHeightTextBox
            // 
            this.ChoosingHeightTextBox.Location = new System.Drawing.Point(186, 22);
            this.ChoosingHeightTextBox.Name = "ChoosingHeightTextBox";
            this.ChoosingHeightTextBox.Size = new System.Drawing.Size(55, 22);
            this.ChoosingHeightTextBox.TabIndex = 1;
            this.ChoosingHeightTextBox.TextChanged += new System.EventHandler(this.ChoosingHeightTextBox_TextChanged);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(31, 60);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(79, 35);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(139, 60);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(79, 35);
            this.ConfirmButton.TabIndex = 3;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // AdjustHeightForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 109);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ChoosingHeightTextBox);
            this.Controls.Add(this.ChoosingHeightLabel);
            this.Name = "AdjustHeightForm";
            this.Text = "AdjustHeightForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ChoosingHeightLabel;
        private System.Windows.Forms.TextBox ChoosingHeightTextBox;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button ConfirmButton;
    }
}