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

namespace Pandora_Product_Inventory_System
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            customiseDesign();
        }

        

        private void Logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogInForm f1 = new LogInForm();
            f1.Show();
        }

        

        private void button5_Click(object sender, EventArgs e)
        {
            LogInForm f1 = new LogInForm();
            this.Hide();
            f1.Show();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            DatabaseUtilities.CreateDatabase();
           
        }
        #region panelSlide
        private void customiseDesign()
        {
            panelSubProducts.Visible = false;
            panelSubRecords.Visible = false;
            panelSubStock.Visible = false;
        }

        private void hideSubMenus()
        {
            if (panelSubProducts.Visible==true)
                panelSubProducts.Visible = false;
            if (panelSubRecords.Visible==true)
                panelSubRecords.Visible = false;
            if (panelSubStock.Visible==true)
                panelSubStock.Visible = false;
        }

        private void showSubMenus(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hideSubMenus();
                submenu.Visible = true;
            }
            else
                submenu.Visible = false;
        }
        #endregion panelSlide

        private void btnDashboard_Click(object sender, EventArgs e)
        {

        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            showSubMenus(panelSubProducts);
        }

        private void btnProductList_Click(object sender, EventArgs e)
        {
            hideSubMenus();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            hideSubMenus(); 
        }

        private void btnCollections_Click(object sender, EventArgs e)
        {
            hideSubMenus();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            showSubMenus(panelSubRecords);
        }

        private void btnStockEntry_Click(object sender, EventArgs e)
        {
            hideSubMenus();
        }

        private void btnStockAdjustment_Click(object sender, EventArgs e)
        {
            hideSubMenus();
        }

        private void btnSalesRecords_Click(object sender, EventArgs e)
        {
            showSubMenus(panelSubStock);
        }

        private void btnSalesHistory_Click(object sender, EventArgs e)
        {
            hideSubMenus();
        }

        private void btnPOSRecord_Click(object sender, EventArgs e)
        {
            hideSubMenus();
        }
    }

}
