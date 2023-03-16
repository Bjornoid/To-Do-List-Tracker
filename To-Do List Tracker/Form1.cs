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

        private void button1_Click(object sender, EventArgs e)
        {
            TextBox taskName = new TextBox();
            DateTimePicker taskDate = new DateTimePicker();
            Label taskLabel = new Label();
            Label dateLabel = new Label();

            if (taskCount >= 11)
            {
                taskLabel.AutoSize = true;
                taskLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
                taskLabel.ForeColor = Color.Black;
                taskLabel.Location = new Point(275, label1.Location.Y + 10 + (secondTaskCount + 1) * 50);
                taskLabel.Name = "taskLabel";
                taskLabel.Size = new Size(20, 32);
                taskLabel.Text = (taskCount + 1).ToString();
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
                taskLabel.Location = new Point(5, label1.Location.Y + 10 + (taskCount + 1) * 50);
                taskLabel.Name = "taskLabel";
                taskLabel.Size = new Size(18, 18);
                taskLabel.Text = (taskCount + 1).ToString();
                taskName.Location = new Point(40, label1.Location.Y + 10 + (taskCount + 1) * 50);
                taskName.Size = new Size(200, 23);
                taskDate.Location = new Point(label2.Location.X - 200, label2.Location.Y + 10 + (taskCount + 1) * 50);
                taskDate.Name = "Due Date";
                taskDate.Size = new Size(200, 23);
            }

            Controls.Add(taskLabel);
            Controls.Add(taskName);
            Controls.Add(taskDate);

            taskCount++;
        }
    }
}