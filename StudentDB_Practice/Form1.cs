namespace StudentDB_Practice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var userForm = new UsersPanel();
            userForm.ShowDialog();
        }
    }
}