using System;
using System.Windows.Forms;

namespace Main
{
    public partial class UserControl11 : UserControl
    {
        public UserControl11()
        {
            InitializeComponent();
            
        }

        private void timer9_Tick(object sender, EventArgs e)
        {
           
        }

        private void UserControl11_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            if (!comboBox1.Items.Contains("item"))
            {
                //do something here to add a value to combobox
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
    }
}
