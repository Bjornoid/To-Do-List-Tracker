using Microsoft.VisualBasic;
using System;
using System.CodeDom;
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

        private Dictionary<int, string> toDoListTasks = new Dictionary<int, string>();
        private List<string> details = new List<string>(36);
        private string filePath = "";

        private RichTextBox detailText = new RichTextBox();
        private Label addDetails = new Label();
        private List<int> removed = new List<int>();
        private string task = "";
        private string date = "";
        private int taskNumber = 0;
        private int toRemove = 0;
        private int detailsIndex = 0;
        private TextBox tempBox;
        private DateTimePicker tempDate;
        private Button confirm;
        private Button cancel;
        private Label taskToRemove;
        private Label detailsNum;
        private ListBox numberPicker;
        private Button close = new Button();

        private void button1_Click(object sender, EventArgs e)
        {
            if (Controls.Contains(confirm))
                Controls.Remove(confirm);
            if (Controls.Contains(cancel))
                Controls.Remove(cancel);
            if (Controls.Contains(detailsNum))
                Controls.Remove(detailsNum);
            if (Controls.Contains(numberPicker))
                Controls.Remove(numberPicker);
            if (Controls.Contains(taskToRemove))
                Controls.Remove(taskToRemove);
            if (Controls.Contains(tempBox))
                Controls.Remove(tempBox);
            if (Controls.Contains(tempDate))
                Controls.Remove(tempDate);
            if (Controls.Contains(detailText))
                Controls.Remove(detailText);
            if (Controls.Contains(addDetails))
                Controls.Remove(addDetails);
            if (Controls.Contains(close))
                Controls.Remove(close);
            if (toDoListTasks.Count == 36)
            {
                MessageBox.Show("To-Do List Full, Finish or Remove a To-Do first.", "List Full");
                return;
            }
            tempBox = new TextBox();
            tempBox.Size = new Size(200, 32);
            tempBox.TextChanged += TempBox_TextChanged;
            tempBox.Location = new Point(label1.Location.X, label1.Location.Y + 45);
            tempDate = new DateTimePicker();
            tempDate.Size = new Size(200, 32);
            tempDate.TextChanged += TempDate_TextChanged;
            tempDate.Location = new Point(label2.Location.X - 50, label2.Location.Y + 45);
            confirm = new Button();
            confirm.Size = new Size(60, 23);
            confirm.Text = "Confirm";
            confirm.Click += Confirm_Click;
            cancel = new Button();
            cancel.Size = new Size(60, 23);
            cancel.Text = "Cancel";
            cancel.Click += Cancel_Click;
            confirm.Location = new Point(button1.Location.X + 115, button1.Location.Y);
            cancel.Location = new Point(button1.Location.X + 115, button1.Location.Y + 32);
            label1.Show();
            label2.Show();
            Controls.Add(tempBox);
            Controls.Add(tempDate);
            Controls.Add(confirm);
            Controls.Add(cancel);
        }

        private void Confirm_Click(object? sender, EventArgs e)
        {
            if (removed.Count > 0)
            {
                int lowest = removed[0];
                foreach (int num in removed)
                {
                    if (num < lowest)
                    {
                        lowest = num;
                    }
                }
                taskNumber = lowest;
                removed.Remove(lowest);
            }
            else
            {
                taskNumber = toDoListTasks.Count + 1;
            }
            if (date.Equals(""))
            {
                string month = "";
                switch (DateTime.Today.Month)
                {
                    case 1:
                        month = "January";
                        break;
                    case 2:
                        month = "February";
                        break;
                    case 3:
                        month = "March";
                        break;
                    case 4:
                        month = "April";
                        break;
                    case 5:
                        month = "May";
                        break;
                    case 6:
                        month = "June";
                        break;
                    case 7:
                        month = "July";
                        break;
                    case 8:
                        month = "August";
                        break;
                    case 9:
                        month = "September";
                        break;
                    case 10:
                        month = "October";
                        break;
                    case 11:
                        month = "November";
                        break;
                    case 12:
                        month = "December";
                        break;
                }
                date = DateTime.Today.DayOfWeek.ToString() + ", " + month + " " + DateTime.Today.Day.ToString() + ", " + DateTime.Today.Year.ToString();
            }
            toDoListTasks[taskNumber] = task + date;
            details.Add("No Details Yet");
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
                taskBox.Size = new Size(300, 32);
                if (!toDoListTasks.ContainsKey(i))
                {
                    continue;
                }
                
                taskBox.AppendText(i.ToString() + " : " + toDoListTasks[i]);
                if (i < 13)
                {
                    taskBox.Location = new Point(label1.Location.X - 100, label1.Location.Y + 100 + (i * 40));

                }
                else if (i < 25)
                {
                    taskBox.Location = new Point(button2.Location.X - 85, button2.Location.Y + 33 + (i - 12) * 40);
                }
                else
                {
                    taskBox.Location = new Point(label2.Location.X - 80, label2.Location.Y + 100 + (i - 24) * 40);
                }

                Controls.Add(taskBox);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Controls.Contains(confirm))
                Controls.Remove(confirm);
            if (Controls.Contains(cancel))
                Controls.Remove(cancel);
            if (Controls.Contains(tempBox))
                Controls.Remove(tempBox);
            if (Controls.Contains(tempDate))
                Controls.Remove(tempDate);
            if (Controls.Contains(numberPicker))
                Controls.Remove(numberPicker);
            if (Controls.Contains(detailsNum))
                Controls.Remove(detailsNum);
            if (Controls.Contains(detailText))
                Controls.Remove(detailText);
            if (Controls.Contains(addDetails))
                Controls.Remove(addDetails);
            if (toDoListTasks.Count == 0) { return; }
            taskToRemove = new Label();
            taskToRemove.Text = "Task# to remove: ";
            taskToRemove.Location = new Point(button2.Location.X - 40, button2.Location.Y + 40);
            taskToRemove.Size = new Size(100, 32);
            taskToRemove.AutoSize = true;
            numberPicker = new ListBox();
            numberPicker.Location = new Point(taskToRemove.Location.X + 100, taskToRemove.Location.Y);
            numberPicker.Size = new Size(40, 40);
            for (int i = 1; i <= toDoListTasks.Count + removed.Count; i++)
            {
                if (removed.Contains(i))
                    continue;
                numberPicker.Items.Add(i);
            }
            numberPicker.SelectedIndexChanged += NumberPicker_SelectedIndexChanged;
            confirm = new Button();
            confirm.Size = new Size(60, 23);
            confirm.Text = "Confirm";
            confirm.Click += Confirm_Click1;
            cancel = new Button();
            cancel.Size = new Size(60, 23);
            cancel.Text = "Cancel";
            cancel.Click += Cancel_Click1;
            confirm.Location = new Point(button1.Location.X + 115, button1.Location.Y);
            cancel.Location = new Point(button1.Location.X + 115, button1.Location.Y + 32);

            Controls.Add(taskToRemove);
            Controls.Add(numberPicker);
            Controls.Add(cancel);
            Controls.Add(confirm);
        }

        private void NumberPicker_SelectedIndexChanged(object? sender, EventArgs e)
        {
            numberPicker.SelectedIndex = numberPicker.SelectedIndex;
        }

        private void Cancel_Click1(object? sender, EventArgs e)
        {
            Controls.Remove(numberPicker);
            Controls.Remove(taskToRemove);
            Controls.Remove(confirm);
            Controls.Remove(cancel);
            label1.Hide();
            label2.Hide();
        }

        private void Confirm_Click1(object? sender, EventArgs e)
        {
            toRemove = (int)numberPicker.SelectedIndex + 1;
            toDoListTasks.Remove(toRemove);

            foreach (Control c in Controls)
            {
                if (c.Text.StartsWith(toRemove.ToString()))
                {
                    Controls.Remove(c);
                }
            }
            removed.Add(toRemove);

            DisplayTasks();

            Controls.Remove(numberPicker);
            Controls.Remove(taskToRemove);
            Controls.Remove(confirm);
            Controls.Remove(cancel);
            label1.Hide();
            label2.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Hide();
            label2.Hide();
            if (Controls.Contains(confirm))
                Controls.Remove(confirm);
            if (Controls.Contains(cancel))
                Controls.Remove(cancel);
            if (Controls.Contains(tempBox))
                Controls.Remove(tempBox);
            if (Controls.Contains(tempDate))
                Controls.Remove(tempDate);
            if (Controls.Contains(numberPicker))
                Controls.Remove(numberPicker);
            if (Controls.Contains(detailsNum))
                Controls.Remove(detailsNum);
            if (Controls.Contains(detailText))
                Controls.Remove(detailText);
            if (Controls.Contains(addDetails))
                Controls.Remove(addDetails);
            if (toDoListTasks.Count == 0) { return; }
            detailsNum = new Label();
            detailsNum.Text = "Task Number: ";
            detailsNum.Location = new Point(button2.Location.X - 40, button2.Location.Y + 40);
            detailsNum.Size = new Size(100, 32);
            detailsNum.AutoSize = true;
            numberPicker = new ListBox();
            numberPicker.Location = new Point(detailsNum.Location.X + 100, detailsNum.Location.Y);
            numberPicker.Size = new Size(40, 40);
            for (int i = 1; i <= toDoListTasks.Count + removed.Count; i++)
            {
                if (removed.Contains(i))
                    continue;
                numberPicker.Items.Add(i);
            }
            numberPicker.SelectedIndex = 0;
            numberPicker.SelectedIndexChanged += NumberPicker_SelectedIndexChanged;
            detailText = new RichTextBox();
            detailText.Location = new Point(label1.Location.X, label1.Location.Y - 10);
            detailText.Size = new Size(200, 150);
            addDetails = new Label();
            addDetails.Text = "Add Details: ";
            addDetails.Location = new Point(detailText.Location.X - 80, detailText.Location.Y);
            addDetails.Size = new Size(60, 32);
            addDetails.AutoSize = true;
            confirm = new Button();
            confirm.Size = new Size(60, 23);
            confirm.Text = "Confirm";
            confirm.Click += Confirm_Click2;
            cancel = new Button();
            cancel.Size = new Size(60, 23);
            cancel.Text = "Cancel";
            cancel.Click += Cancel_Click2;
            confirm.Location = new Point(button1.Location.X + 115, button1.Location.Y);
            cancel.Location = new Point(button1.Location.X + 115, button1.Location.Y + 32);

            Controls.Add(addDetails);
            Controls.Add(detailText);
            Controls.Add(detailsNum);
            Controls.Add(numberPicker);
            Controls.Add(cancel);
            Controls.Add(confirm);
        }

        private void Confirm_Click2(object? sender, EventArgs e)
        {
            detailsIndex = (int)numberPicker.SelectedIndex;
            details[detailsIndex] = detailText.Text;
            Controls.Remove(addDetails);
            Controls.Remove(numberPicker);
            Controls.Remove(detailText);
            Controls.Remove(detailsNum);
            Controls.Remove(confirm);
            Controls.Remove(cancel);
        }

        private void Cancel_Click2(object? sender, EventArgs e)
        {
            Controls.Remove(addDetails);
            Controls.Remove(numberPicker);
            Controls.Remove(detailText);
            Controls.Remove(detailsNum);
            Controls.Remove(confirm);
            Controls.Remove(cancel);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Hide();
            label2.Hide();
            if (Controls.Contains(confirm))
                Controls.Remove(confirm);
            if (Controls.Contains(cancel))
                Controls.Remove(cancel);
            if (Controls.Contains(tempBox))
                Controls.Remove(tempBox);
            if (Controls.Contains(tempDate))
                Controls.Remove(tempDate);
            if (Controls.Contains(numberPicker))
                Controls.Remove(numberPicker);
            if (Controls.Contains(detailsNum))
                Controls.Remove(detailsNum);
            if (Controls.Contains(detailText))
                Controls.Remove(detailText);
            if (Controls.Contains(addDetails))
                Controls.Remove(addDetails);
            if (toDoListTasks.Count == 0) { return; }
            detailsNum = new Label();
            detailsNum.Text = "Task Number: ";
            detailsNum.Location = new Point(button2.Location.X - 40, button2.Location.Y + 40);
            detailsNum.Size = new Size(100, 32);
            detailsNum.AutoSize = true;
            confirm = new Button();
            confirm.Size = new Size(60, 23);
            confirm.Text = "Confirm";
            confirm.Click += Confirm_Click3; ;
            cancel = new Button();
            cancel.Size = new Size(60, 23);
            cancel.Text = "Cancel";
            cancel.Click += Cancel_Click2;
            confirm.Location = new Point(button1.Location.X + 115, button1.Location.Y);
            cancel.Location = new Point(button1.Location.X + 115, button1.Location.Y + 32);
            numberPicker = new ListBox();
            numberPicker.Location = new Point(detailsNum.Location.X + 100, detailsNum.Location.Y);
            numberPicker.Size = new Size(40, 40);
            for (int i = 1; i <= toDoListTasks.Count + removed.Count; i++)
            {
                if (removed.Contains(i))
                    continue;
                numberPicker.Items.Add(i);
            }
            numberPicker.SelectedIndex = 0;
            numberPicker.SelectedIndexChanged += NumberPicker_SelectedIndexChanged;

            Controls.Add(detailsNum);
            Controls.Add(numberPicker);
            Controls.Add(cancel);
            Controls.Remove(close);
            Controls.Add(confirm);
        }

        private void Confirm_Click3(object? sender, EventArgs e)
        {
            detailText = new RichTextBox();
            detailText.Location = new Point(label1.Location.X, label1.Location.Y - 10);
            detailText.Size = new Size(200, 150);
            detailText.Text = details[(int)numberPicker.SelectedIndex];
            
            addDetails = new Label();
            addDetails.Text = "Details: ";
            addDetails.Location = new Point(detailText.Location.X - 80, detailText.Location.Y);
            addDetails.Size = new Size(60, 32);
            addDetails.AutoSize = true;
            Controls.Add(detailText);
            Controls.Add(addDetails);
            close = new Button();
            close.Text = "Close";
            close.Location = new Point(addDetails.Location.X, addDetails.Location.Y + 50);
            close.Size = new Size(60, 32);
            close.Click += Close_Click;
            Controls.Add(close);

            Controls.Remove(numberPicker);
            Controls.Remove(detailsNum);
            Controls.Remove(confirm);
            Controls.Remove(cancel);
        }

        private void Close_Click(object? sender, EventArgs e)
        {
            Controls.Remove(close);
            Controls.Remove(detailText);
            Controls.Remove(addDetails);
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveAs = new SaveFileDialog();
            saveAs.Filter = "To-Do List Text Files (*.txt) | *.txt";
            if (saveAs.ShowDialog() == DialogResult.Cancel) { return; }
            filePath = saveAs.FileName;
            File.WriteAllText(filePath, "");
            
            for (int i = 1; i <= toDoListTasks.Count; i++)
            {
                if (details[i - 1] == "" || details[i - 1] == "No Details Yet" || details[i - 1] == null) 
                {
                    File.AppendAllText(filePath, toDoListTasks[i] + "~");
                }
                else
                    File.AppendAllText(filePath, toDoListTasks[i] + ".");
                
                File.AppendAllText(filePath, details[i - 1] + "~");
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "To-Do List Text Files (*.txt) | *.txt";
            if (open.ShowDialog() == DialogResult.Cancel) { return; }
            filePath = open.FileName;

            StreamReader sr = new StreamReader(filePath);

            for (int i = 1; i <= toDoListTasks.Count; i++)
            {
                foreach (Control c in Controls)
                {
                    if ( c.Text.StartsWith(i.ToString())) 
                    {
                        Controls.Remove(c);
                    }
                }
            }
            toDoListTasks.Clear();
            string taskAndDate = "";
            int count = 0;
            char temp = ' ';
            int taskNumber = 0;
            string detail = "";
            
            while (!sr.EndOfStream)
            {
                if (count == 0)
                {
                    temp = (char)sr.Read();
                    if (temp == '.')
                    {

                        count++;
                        toDoListTasks[taskNumber + 1] = taskAndDate;
                        taskAndDate = "";
                        continue;
                    }
                    else if (temp == '~')
                    {
                        count = 0;
                        toDoListTasks[taskNumber + 1] = taskAndDate;
                        details[taskNumber] = "No Details Yet";
                        taskNumber++;
                        taskAndDate = "";
                        continue;
                    }
                    else
                        taskAndDate += temp;
                }
                else if (count == 1) 
                {
                    temp = (char)sr.Read();
                    if (temp == '~')
                    {
                        count = 0;
                        details.Insert(taskNumber, detail);
                        taskNumber++;
                        detail = "";
                        continue;
                    }
                    detail += temp;
                }
            }
            DisplayTasks();
        }
    }
}