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

        private void button1_Click(object sender, EventArgs e)
        {

            TextBox taskName = new TextBox();
            taskName.Location = new Point(label1.Location.X, label1.Location.Y + 10 + (taskCount + 1) * 50);
            taskName.Size = new Size(200, 23);
            DateTimePicker taskDate = new DateTimePicker();
            taskDate.Location = new Point(label2.Location.X - label2.Size.Width, label2.Location.Y + 10 + (taskCount + 1) * 50);
            taskDate.Name = "Due Date";
            taskDate.Size = new Size(200, 23);

            Controls.Add(taskName);
            Controls.Add(taskDate);

            taskCount++;
        }
    }
}