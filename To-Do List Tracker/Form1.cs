using System.DirectoryServices;
using System.Windows.Forms;

namespace To_Do_List_Tracker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int taskCount = 0;
        private int secondTaskCount = 0;
        private Button confirm = new Button();
        private Button cancel = new Button();
        NumericUpDown taskNumber = new NumericUpDown();
        List<List<Control>> tasks = new List<List<Control>>();
        private void button1_Click(object sender, EventArgs e)
        {
            TextBox taskName = new TextBox();
            DateTimePicker taskDate = new DateTimePicker();
            Label taskLabel = new Label();
            Label dateLabel = new Label();

            if (secondTaskCount >= 11)
            {
                MessageBox.Show("To-Do List full, finish or remove a task first.", "List Full!");
                return;
            }
            else if (taskCount >= 11)
            {
                taskLabel.AutoSize = true;
                taskLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
                taskLabel.ForeColor = Color.Black;
                taskLabel.Location = new Point(290, label1.Location.Y + 10 + (secondTaskCount + 1) * 50);
                taskLabel.Name = "taskLabel";
                taskLabel.Size = new Size(20, 32);
                taskLabel.Text = (taskCount + 1).ToString();
                dateLabel.AutoSize = true;
                dateLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
                dateLabel.ForeColor = Color.Black;
                dateLabel.Location = new Point(label2.Location.X + 70, label1.Location.Y + 10 + (secondTaskCount + 1) * 50);
                dateLabel.Name = "dateLabel";
                dateLabel.Size = new Size(20, 32);
                dateLabel.Text = (taskCount + 1).ToString();
                taskName.Location = new Point(320, label1.Location.Y + 10 + (secondTaskCount + 1) * 50);
                taskName.Size = new Size(200, 23);
                taskDate.Location = new Point(label2.Location.X + 100, label2.Location.Y + 10 + (secondTaskCount + 1) * 50);
                taskDate.Name = "Due Date";
                taskDate.Size = new Size(200, 23);
                secondTaskCount++;
            }
            else
            {
                taskLabel.AutoSize = true;
                taskLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
                taskLabel.ForeColor = Color.Black;
                taskLabel.Location = new Point(45, label1.Location.Y + 10 + (taskCount + 1) * 50);
                taskLabel.Name = "taskLabel";
                taskLabel.Size = new Size(18, 18);
                taskLabel.Text = (taskCount + 1).ToString();
                dateLabel.AutoSize = true;
                dateLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
                dateLabel.ForeColor = Color.Black;
                dateLabel.Location = new Point(label2.Location.X - 230, label1.Location.Y + 10 + (taskCount + 1) * 50);
                dateLabel.Name = "dateLabel";
                dateLabel.Size = new Size(20, 32);
                dateLabel.Text = (taskCount + 1).ToString();
                taskName.Location = new Point(75, label1.Location.Y + 10 + (taskCount + 1) * 50);
                taskName.Size = new Size(200, 23);
                taskDate.Location = new Point(label2.Location.X - 200, label2.Location.Y + 10 + (taskCount + 1) * 50);
                taskDate.Name = "Due Date";
                taskDate.Size = new Size(200, 23);
            }

            Controls.Add(dateLabel);
            Controls.Add(taskLabel);
            Controls.Add(taskName);
            Controls.Add(taskDate);
            List<Control> tList = new List<Control>();
            tList.Add(dateLabel);
            tList.Add(taskDate);
            tList.Add(taskName);
            tList.Add(taskLabel);
            tasks.Add(tList);

            taskCount++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            taskNumber.Location = new Point(button2.Location.X + 125, button2.Location.Y);
            taskNumber.Size = new Size( 40, 32);
            taskNumber.Name = "Task Select";
            taskNumber.Maximum = 22;
            taskNumber.Minimum = 1;
            taskNumber.ValueChanged += TaskNumber_ValueChanged;
            //taskNumber.Show();


            confirm.Location = new Point(taskNumber.Location.X - 20, taskNumber.Location.Y + 30);
            confirm.Name = "Confirm";
            confirm.Size = new Size(60, 23);
            confirm.Text = "Confirm";
            confirm.UseVisualStyleBackColor = true;
            confirm.Click += confirm_click;

            cancel.Location = new Point(confirm.Location.X, confirm.Location.Y + 30);
            cancel.Name = "Cancel";
            cancel.Size = new Size(60, 23);
            cancel.Text = "Cancel";
            cancel.UseVisualStyleBackColor = true;
            cancel.Click += Cancel_Click;

            Controls.Add(taskNumber);
            Controls.Add(confirm);
            Controls.Add(cancel);
        }

        private void Cancel_Click(object? sender, EventArgs e)
        {
            Controls.Remove(taskNumber);
            Controls.Remove(confirm);
            Controls.Remove(cancel);
        }

        private void TaskNumber_ValueChanged(object? sender, EventArgs e)
        {
            taskNumber.Value = taskNumber.Value;
        }

        private void confirm_click(object? sender, EventArgs e)
        { 
            
            int index = (int)taskNumber.Value - 1;
            if (index >= taskCount)
            {
                MessageBox.Show("Needs to be an ACTIVE TO-DO number.", "Invalid To-Do number");
                return;
            }
            foreach (Control control in tasks[index]) 
            {
                Controls.Remove(control);
            }
            Controls.Remove(taskNumber);
            Controls.Remove(confirm);
            Controls.Remove(cancel);
        }
    }
}