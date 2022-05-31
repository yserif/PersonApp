using Person.DB;

namespace Person.WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var personDb = new PersonDBContext();
            var personList=personDb.People.ToList();
            dataGridView1.DataSource = personList;
            dataGridView1.Refresh();
        }
    }
}