using System;
using System.Drawing;
using System.Windows.Forms;
using String = Diten.String;

namespace WindowsFormsApp1
{
    public partial class FormTestDBModule : Form
    {
        public FormTestDBModule()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dt = new String("sdfsdfs vb sdfsdfs dhgftdfgj sdfsdfs dsdfsdfsdf", FontStyle.Bold);
            dt.Save();
        }
    }
}