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
using ADOX;
using System.Linq.Expressions;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.CompilerServices;

namespace Pandora_Product_Inventory_System
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
        }
        private const string db = "LogInInfo.mdf";
        private const string CONNECTION_STRING = @"Provider=Microsoft Jet 4.0 OLE DB Provider;Data Source = " + db + ";";
        
        
        private void checkBoxPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPass.Checked == false)
                txtPass.UseSystemPasswordChar = true;
            else
                txtPass.UseSystemPasswordChar = false;
        }

        private void lblClear_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtPass.Clear();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                Application.Exit();
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


       

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" || txtPass.Text == "")
            {
                MessageBox.Show("Please provide a VALID UserName and Password.");
                return;
            }

            if (txtUserName.Text == "username" && txtPass.Text == "password")
            {
                MainMenu f2 = new MainMenu();
                this.Hide();
                f2.Show();
            }
            
            else
            {
                MessageBox.Show("Login Failed!");
            }

        }

       
    }
    }
