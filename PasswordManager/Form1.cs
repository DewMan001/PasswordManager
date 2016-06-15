using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PasswordManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            //making a string variable
            string connectionString;
            //and putting the connection string into that variable
            connectionString = "server=223.27.22.124;user id=JBAdmin;password=0UFj2r*85cH3u#efFXgK;database=041402192_manpass";

            //running the pipeline from the application into the server
            MySqlConnection pipeLine = new MySqlConnection(connectionString);

            //making a new data set to put our data in
            DataSet bucketOfWater = new DataSet();

            try
            {
                //opening the connection
                pipeLine.Open();

                //the full string which shall be spoken to the server
                string speechBubble;

                //making a string for the service name
                string serviceName;
                //and putting the text from the service name text box into it
                serviceName = txt_ServiceName.Text;
                
                //making a string for the username
                string userName;
                //and putting the text of the username into it
                userName = txt_Username.Text;
                
                //making a string for the user password
                string userPass;
                //and putting the text from the user password into it


                speechBubble = "INSERT INTO `account`(`ServiceName`, `AccountUName`, `AccountPWord`) VALUES ([value-2],[value-3],[value-4])"

                //an adapter to talk to the server
                MySqlDataAdapter squawkBox = new MySqlDataAdapter();
            }
        }
    }
}
