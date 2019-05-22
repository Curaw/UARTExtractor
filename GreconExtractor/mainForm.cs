using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GreconExtractor
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            dgvTable.Rows.Add("1427523462145","7355608", "275");
            dgvTable.Rows.Add("1427523462146","7355608", "278");
            dgvTable.Rows.Add("1427523462147", "7355608", "290");
            dgvTable.Rows.Add("1427523462255", "4438759", "275");
            dgvTable.Rows.Add("1427523462256", "4438759", "275");
            dgvTable.Rows.Add("1427523462257", "4438759", "275");
            dgvTable.Rows.Add("1427523462257", "4438759", "302");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            svDialog.Filter = "CSV-File|*.csv";
            svDialog.Title = "Save CSV-File";

            if (svDialog.ShowDialog() == DialogResult.OK)
            {
                string path = svDialog.FileName;
                var csv = new StringBuilder();
                
                //Hier ueber die Tabelle iterieren
                foreach (DataGridViewRow row in dgvTable.Rows)
                {
                    for(int i = 0; i < row.Cells.Count; i++) {
                        csv.Append(row.Cells[i].Value);
                        csv.Append(";");
                    }
                    csv.Append(Environment.NewLine);
                }
                System.IO.File.WriteAllText(path, csv.ToString());
                MessageBox.Show(this,"Saved successfully to: \n" + path,"Saving Table",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            //using (var sp = new System.IO.Ports.SerialPort("COM11", 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One))
            using (var sp = new System.IO.Ports.SerialPort("COM7", 9600, System.IO.Ports.Parity.None, 8,System.IO.Ports.StopBits.One))
            {
                sp.Open();
                var readData = sp.ReadLine();
                Console.WriteLine(readData);
            }
        }
    }
}
