using System;
using System.IO;
using System.Reflection;
using System.Security.Permissions;
using System.Windows.Forms;
using ClassLibrary1;

namespace WindowsFormsApp1
{
    [SecurityPermission(SecurityAction.Demand, Unrestricted = true)]
    public partial class FormTestLoadingAssembly : Form
    {
        public FormTestLoadingAssembly()
        {
            InitializeComponent();

            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }

        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            Assembly _return;

            var path = $@"{Environment.CurrentDirectory}\Repository";

            using (var fileStream = new FileStream($@"{path}\{args.Name.Split(',')[0]}.dll", FileMode.Open))
            using (var reader = new BinaryReader(fileStream))
            {
                _return =
                    AppDomain.CurrentDomain.Load(reader.ReadBytes(Convert.ToInt32(fileStream.Length)));
            }

            return _return;
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            //DynamicClass dc = new DynamicClass();
            //MessageBox.Show("Message: " + dc.Message);

            textBoxResult.Text = Diten.Test.TestAssembly.GetTest();
            Text = Class1.GetTest();
        }
    }
}