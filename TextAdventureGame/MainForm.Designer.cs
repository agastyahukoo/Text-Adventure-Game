namespace TextAdventureGame
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
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtPlayerInput = new CustomTextBox();
            this.customRichTextBox1 = new CustomRichTextBox();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Black;
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(676, 630);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(129, 39);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtPlayerInput
            // 
            this.txtPlayerInput.BackColor = System.Drawing.Color.Black;
            this.txtPlayerInput.Font = new System.Drawing.Font("Courier New", 10F);
            this.txtPlayerInput.ForeColor = System.Drawing.Color.White;
            this.txtPlayerInput.Location = new System.Drawing.Point(21, 639);
            this.txtPlayerInput.Name = "txtPlayerInput";
            this.txtPlayerInput.Size = new System.Drawing.Size(384, 23);
            this.txtPlayerInput.TabIndex = 2;
            this.txtPlayerInput.Text = "Enter your commands here...";
            // 
            // customRichTextBox1
            // 
            this.customRichTextBox1.BackColor = System.Drawing.Color.Black;
            this.customRichTextBox1.Font = new System.Drawing.Font("Courier New", 10F);
            this.customRichTextBox1.ForeColor = System.Drawing.Color.White;
            this.customRichTextBox1.Location = new System.Drawing.Point(12, 12);
            this.customRichTextBox1.Name = "customRichTextBox1";
            this.customRichTextBox1.ReadOnly = true;
            this.customRichTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.customRichTextBox1.Size = new System.Drawing.Size(793, 604);
            this.customRichTextBox1.TabIndex = 1;
            this.customRichTextBox1.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(820, 681);
            this.Controls.Add(this.txtPlayerInput);
            this.Controls.Add(this.customRichTextBox1);
            this.Controls.Add(this.btnSubmit);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quest of the Enchanted Amulet";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubmit;
        private CustomRichTextBox customRichTextBox1;
        private CustomTextBox txtPlayerInput;
    }
}

