using System;
using System.Configuration.Internal;
using System.DirectoryServices;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace To_Do_List_Tracker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Dictionary<int, string> toDoListTasks = new Dictionary<int, string>(20);

        private string task, date;
        private int taskNumber;
        private TextBox tempBox;
        private DateTimePicker tempDate;
        private Button confirm;
        private Button cancel;

        private void button1_Click(object sender, EventArgs e)
        {
            tempBox = new TextBox();
            tempBox.Location = new Point(label1.Location.X, label1.Location.Y + 45);
            tempBox.Size = new Size(200, 32);
            tempBox.TextChanged += TempBox_TextChanged;
            tempDate = new DateTimePicker();
            tempDate.Location = new Point(label2.Location.X - 50, label2.Location.Y + 45);
            tempDate.Size = new Size(200, 32);
            tempDate.TextChanged += TempDate_TextChanged;
            confirm = new Button();
            confirm.Location = new Point(button1.Location.X + 115, button1.Location.Y);
            confirm.Size = new Size(60, 23);
            confirm.Text = "Confirm";
            confirm.Click += Confirm_Click;
            cancel = new Button();
            cancel.Location = new Point(button1.Location.X + 115, button1.Location.Y + 32);
            cancel.Size = new Size(60, 23);
            cancel.Text = "Cancel";
            cancel.Click += Cancel_Click;

            label1.Show();
            label2.Show();
            Controls.Add(tempBox);
            Controls.Add(tempDate);
            Controls.Add(confirm);
            Controls.Add(cancel);
        }

        private void Confirm_Click(object? sender, EventArgs e)
        {
            taskNumber = toDoListTasks.Count + 1;
            toDoListTasks[taskNumber] = task + date;
            DisplayTasks();
            Controls.Remove(tempBox);
            Controls.Remove(tempDate);
            Controls.Remove(confirm);
            Controls.Remove(cancel);
            label1.Hide();
            label2.Hide();
        }

        private void Cancel_Click(object? sender, EventArgs e)
        {
            Controls.Remove(tempBox);
            Controls.Remove(tempDate);
            Controls.Remove(confirm);
            Controls.Remove(cancel);
            label1.Hide();
            label2.Hide();
        }

        private void TempDate_TextChanged(object? sender, EventArgs e)
        {
            date = tempDate.Text;
        }

        private void TempBox_TextChanged(object? sender, EventArgs e)
        {
            task = tempBox.Text + " by ";
        }

        private void DisplayTasks()
        {
            for (int i = 1; i <= toDoListTasks.Count; i++)
            {
                TextBox taskBox = new TextBox();
                taskBox.Location = new Point(label1.Location.X - 100, label1.Location.Y + 100 + (i * 40));
                taskBox.Size = new Size(300, 32);
                taskBox.AppendText(i.ToString() + " : " + toDoListTasks[i]);



                Controls.Add(taskBox);
            }
        }
    }
}