using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;

namespace Pandora_Product_Inventory_System
{
    public  partial class AddCollection : Form
    {
        public AddCollection()
        {
            InitializeComponent();
        }

        private void pBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Are you sure you want to save this collection?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string sCollectionName = txtBoxCollection.Text;
                    string _sSqlString = "INSERT INTO Collection(CollectionName)" + "Values('" + sCollectionName + "')";
                    DatabaseUtilities.ExecuteSqlNonQuery(_sSqlString);
                    MessageBox.Show("Record has been successfuly saved.", "POS");

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
