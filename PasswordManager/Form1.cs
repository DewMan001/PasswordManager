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
            connectionString = "server=223.27.22.124;user id=JBAdmin001;password=0UFj2r*85cH3u#efFXgK;database=041402192_manpass";

            //running the pipeline from the application into the server
            MySqlConnection pipeLine = new MySqlConnection(connectionString);

            //making a new data set to put our data in
            DataSet bucketOfWater = new DataSet();

            try
            {
                //opening the connection
                pipeLine.Open();

                //clearing out the data grid view
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();

                //the full string which shall be spoken to the server
                string speechBubble;

                //making a string for the service name
                string serviceName;
                //and putting the text from the service name text box into it
                serviceName = "'" + txt_ServiceName.Text + "'";
                
                //making a string for the username
                string userName;
                //and putting the text of the username into it
                userName = "'" + txt_Username.Text + "'";
                
                //making a string for the user password
                string userPass;
                //and putting the text from the user password into it
                userPass = "'" + txt_Password.Text + "'";

                //making a string to act as the SQL command
                speechBubble = "INSERT INTO `account`(`ServiceName`, `AccountUName`, `AccountPWord`) VALUES (" + serviceName + "," + userName + "," + userPass + ")";

                //making a new MySqlConnection object, and putting the connectionString into it.
                MySqlConnection connection = new MySqlConnection(connectionString);

                //string speechBubble2;
                //speechBubble2 = "INSERT INTO `account`(`ServiceName`, `AccountUName`, `AccountPWord`) VALUES ('dickbutt','dick@butt.com','buttdick')";

                MySqlCommand commandLine = new MySqlCommand(speechBubble, connection);
                connection.Open();
                commandLine.ExecuteNonQuery();
                connection.Close();

                //now pulling that data back out
                MySqlDataAdapter pullBack = new MySqlDataAdapter("SELECT * FROM `account`", connectionString);

                //filling the bucket with water
                pullBack.Fill(bucketOfWater);

                //putting the data into the data grid view

                for (int count = 0; count <= bucketOfWater.Tables[0].Rows.Count - 1; count++)
                {
                    this.dataGridView1.Rows.Add(
                    bucketOfWater.Tables[0].Rows[count].ItemArray[0].ToString(),
                    bucketOfWater.Tables[0].Rows[count].ItemArray[1].ToString(),
                    bucketOfWater.Tables[0].Rows[count].ItemArray[2].ToString(),
                    bucketOfWater.Tables[0].Rows[count].ItemArray[3].ToString()
                    );

                }
            }

            catch (MySqlException error)
            {
                MessageBox.Show("Connection Unsuccessful \n \n" + error.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
