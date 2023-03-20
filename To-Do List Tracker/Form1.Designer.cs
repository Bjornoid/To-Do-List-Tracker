namespace To_Do_List_Tracker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            button1 = new Button();
            label2 = new Label();
            label4 = new Label();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Green;
            label1.Location = new Point(211, 35);
            label1.Name = "label1";
            label1.Size = new Size(94, 32);
            label1.TabIndex = 0;
            label1.Text = "TO-DO:";
            // 
            // button1
            // 
            button1.Location = new Point(691, 73);
            button1.Name = "button1";
            button1.Size = new Size(105, 23);
            button1.TabIndex = 1;
            button1.Text = " + Add Task";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.Red;
            label2.Location = new Point(1096, 35);
            label2.Name = "label2";
            label2.Size = new Size(105, 32);
            label2.TabIndex = 2;
            label2.Text = "Do-Date";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.DarkOrange;
            label4.Location = new Point(562, 25);
            label4.Name = "label4";
            label4.Size = new Size(285, 45);
            label4.TabIndex = 3;
            label4.Text = "TO-DO List Tracker";
            // 
            // button2
            // 
            button2.Location = new Point(691, 102);
            button2.Name = "button2";
            button2.Size = new Size(105, 23);
            button2.TabIndex = 4;
            button2.Text = "- Remove Task";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(596, 73);
            button3.Name = "button3";
            button3.Size = new Size(89, 23);
            button3.TabIndex = 5;
            button3.Text = "+ Add Details";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(596, 102);
            button4.Name = "button4";
            button4.Size = new Size(89, 23);
            button4.TabIndex = 6;
            button4.Text = ">View Details";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1530, 650);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "TO-DO List Tracker";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Label label2;
        private Label label4;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}