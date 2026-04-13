using System.Drawing;

namespace MassIndex_calculator
{
    partial class AddPerson
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
            this.AgeBox = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.FirstNameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LastNameBox = new System.Windows.Forms.TextBox();
            this.SavePersonButton = new System.Windows.Forms.Button();
            this.FInitialsBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AgeBox)).BeginInit();
            this.SuspendLayout();
            // 
            // AgeBox
            // 
            this.AgeBox.Location = new System.Drawing.Point(145, 176);
            this.AgeBox.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.AgeBox.Minimum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.AgeBox.Name = "AgeBox";
            this.AgeBox.Size = new System.Drawing.Size(146, 22);
            this.AgeBox.TabIndex = 32;
            this.AgeBox.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.AgeBox.ValueChanged += new System.EventHandler(this.AgeBox_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(205, 157);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 16);
            this.label13.TabIndex = 31;
            this.label13.Text = "age";
            // 
            // FirstNameBox
            // 
            this.FirstNameBox.Location = new System.Drawing.Point(145, 100);
            this.FirstNameBox.Name = "FirstNameBox";
            this.FirstNameBox.Size = new System.Drawing.Size(146, 22);
            this.FirstNameBox.TabIndex = 33;
            this.FirstNameBox.TextChanged += new System.EventHandler(this.FirstNameBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(189, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 34;
            this.label1.Text = "FirstName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(335, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 36;
            this.label2.Text = "LastName";
            // 
            // LastNameBox
            // 
            this.LastNameBox.Location = new System.Drawing.Point(297, 100);
            this.LastNameBox.Name = "LastNameBox";
            this.LastNameBox.Size = new System.Drawing.Size(139, 22);
            this.LastNameBox.TabIndex = 35;
            this.LastNameBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // SavePersonButton
            // 
            this.SavePersonButton.Location = new System.Drawing.Point(338, 176);
            this.SavePersonButton.Name = "SavePersonButton";
            this.SavePersonButton.Size = new System.Drawing.Size(243, 61);
            this.SavePersonButton.TabIndex = 37;
            this.SavePersonButton.Text = "Save person";
            this.SavePersonButton.UseVisualStyleBackColor = true;
            this.SavePersonButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // FInitialsBox
            // 
            this.FInitialsBox.Location = new System.Drawing.Point(442, 100);
            this.FInitialsBox.Name = "FInitialsBox";
            this.FInitialsBox.Size = new System.Drawing.Size(139, 22);
            this.FInitialsBox.TabIndex = 38;
            this.FInitialsBox.TextChanged += new System.EventHandler(this.FInitialsBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(469, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 16);
            this.label3.TabIndex = 39;
            this.label3.Text = "Father Initials";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.label4.Location = new System.Drawing.Point(127, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 35);
            this.label4.TabIndex = 40;
            this.label4.Text = "Minimum age: 18 \r\n (values below will be corrected)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FInitialsBox);
            this.Controls.Add(this.SavePersonButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LastNameBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FirstNameBox);
            this.Controls.Add(this.AgeBox);
            this.Controls.Add(this.label13);
            this.Name = "AddPerson";
            this.Text = "AddPerson";
            this.Load += new System.EventHandler(this.AddPerson_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AgeBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown AgeBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox FirstNameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LastNameBox;
        private System.Windows.Forms.Button SavePersonButton;
        private System.Windows.Forms.TextBox FInitialsBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}