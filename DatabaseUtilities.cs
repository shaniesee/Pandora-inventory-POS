using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.IO;
using ADOX;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Pandora_Product_Inventory_System
{
    public static class DatabaseUtilities
    {
        private const string EXAMPLEDB = "InventoryDatabase.mdb";
        private const string CONNECTION_STRING = @"Provider=Microsoft Jet 4.0 OLE DB Provider;Data Source = " + EXAMPLEDB + ";";

        public static void CreateDatabase()
        {
            try
            {
                // Check if the database exists
                if (!File.Exists(EXAMPLEDB))
                {
                    // Create a catalog object
                    CatalogClass cat = new CatalogClass();

                    // Create the database
                    cat.Create(CONNECTION_STRING);
                    MessageBox.Show("Database Created Successfully", "Library Administration System", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // create database tables in the database
                    CreateTables();

                    //cleanup
                    cat = null;
                }
                else
                {
                    MessageBox.Show("The database already exists", "Library Administration System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Library Administration System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private static void CreateTables()
        {
            string _sSqlString;

            _sSqlString = "CREATE TABLE Product("
                                                  +"ProductIdNo AUTOINCREMENT,"
                                                  +"ProductCategoryID SHORT,"
                                                  +"ProdctName CHAR(40),"
                                                  +"ProductCategory CHAR(20),"
                                                  +"Price CURRENCY,"
                                                  +"MetalType VARCHAR(10),"
                                                  +"UnitsInStock NUMERIC(4),"
                                                  +"PRIMARY KEY(ProductIdNo)"
                                                  +")";
            ExecuteSqlNonQuery(_sSqlString);

            // create student table
            _sSqlString = "CREATE TABLE CustomerProfile("
                                               +"CustomerIdNo INT,"
                                               +"CustomerEmail VARCHAR(50),"
                                               +"FirstName VARCHAR(40),"
                                               +"Surname VARCHAR(40),"
                                               +"Gender CHAR(1),"
                                               +"MemberCategory VARCHAR (10),"
                                               +"MetalId SHORT,"
                                               +"FavouriteCategory VARCHAR(20),"
                                               +"PRIMARY KEY(CustomerIdNo)"
                                               +")";
            ExecuteSqlNonQuery(_sSqlString);

            _sSqlString = "CREATE TABLE Staff("
                                            +"StaffIdNo INT,"
                                            +"StaffFirstName VARCHAR(40),"
                                            +"StaffSurname VARCHAR(40),"
                                            +"DateOfBirth DATETIME,"
                                            +"PRIMARY KEY(StaffIDNo)"
                                            +")";

            ExecuteSqlNonQuery(_sSqlString);

            // create loan table
            _sSqlString = "CREATE TABLE Sales("
                                              +"TransactionIdNo AUTOINCREMENT,"
                                              +"CustomerIdNo INT,"
                                              +"StaffIdNo INT,"
                                              +"TransactionDetails DATETIME,"
                                              +"PaymentMethod CHAR(1),"
                                              +"PRIMARY KEY(TransactionIdNo)"
                                              +")";
            ExecuteSqlNonQuery(_sSqlString);

      

           

            

        }

        private static void ExecuteSqlNonQuery(String sSqlString)
        {
            try
            {
                OleDbConnection cnn = new OleDbConnection(CONNECTION_STRING);
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand(sSqlString, cnn);
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Library Administration System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
    
    }

