using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsXpoExample {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            LoadingDatabaseConnection();
        }

        /// <summary>
        /// It does load database connection.
        /// </summary>
        public static void LoadingDatabaseConnection() {
            try {
                // Database connection string properties.
                var server = @"ALBERTO-PC\SQL";
                var dbUser = "testUser";
                var dbPassword = "123456789";
                var dbName = "XpoTestDatabase";

                // It does create the database connection and bring back the unit of work that will be used.
                var connection = MSSqlConnectionProvider.GetConnectionString(server, dbUser, dbPassword, dbName);
                var dataLayerLocal = XpoDefault.GetDataLayer(connection, AutoCreateOption.DatabaseAndSchema);
                var unitOfWork = new UnitOfWork(dataLayerLocal);

                unitOfWork.Connect();

                // It does update database structure.
                unitOfWork.UpdateSchema();

                // It does create a new user.
                var user = new User(unitOfWork);
                user.UserName = "AlbertoZavala";
                user.Password = "qwerty";

                // It does persist new user data in datbase.
                unitOfWork.CommitChanges();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
