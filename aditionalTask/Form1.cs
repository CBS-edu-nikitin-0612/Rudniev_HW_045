using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aditionalTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fileName;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                fileName = openFileDialog.FileName;
            else
                return;

            AppDomain domainForSelectAssembly = AppDomain.CreateDomain("domainForSelectAssembly");

            var checkedItems = checkedListBox.CheckedItems;
            Zone[] hostEvidence = new Zone[checkedItems.Count];
            for (int i = 0; i < checkedItems.Count; i++)
            {
                switch (checkedItems[i].ToString())
                {
                    case "MyComputer":
                        hostEvidence[i] = new Zone(SecurityZone.MyComputer);
                        break;
                    case "Intranet":
                        hostEvidence[i] = new Zone(SecurityZone.Intranet);
                        break;
                    case "Trusted":
                        hostEvidence[i] = new Zone(SecurityZone.Trusted);
                        break;
                    case "Internet":
                        hostEvidence[i] = new Zone(SecurityZone.Internet);
                        break;
                    case "Untrusted":
                        hostEvidence[i] = new Zone(SecurityZone.Untrusted);
                        break;
                }
            }
            Evidence evidence = new Evidence(hostEvidence, null);
            try
            {
                //domainForSelectAssembly.ExecuteAssembly(fileName, evidence);
                domainForSelectAssembly.ExecuteAssembly(fileName);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

            
        }
    }
}
