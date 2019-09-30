using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopLayer.Repository
{
    class CustomerRepository
    {
        public bool AddInfo(string name, string contact, string address, string item, int quantity)
        {
            if (item == "Hot")
                {
                    int totalPrice = quantity * 120;
                    string connectionString = @"Server=BRINTA-PC; Database=CoffeeShop; Integrated Security=True";
                    SqlConnection sqlConnection = new SqlConnection(connectionString);
                    string commandString = @"insert into Customer values('" + name + "' ,'" + contact + "','" + address + "','" + item + "'," + quantity + "," + totalPrice + " )";
                    SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
                    sqlConnection.Open();
                    int isExecuted = sqlCommand.ExecuteNonQuery();
                    if (isExecuted > 0)
                    {
                        return true;
                    }

                    sqlConnection.Close();
                }




            
            
            return false;
        }
        public DataTable ShowCustomer()
        {
           
                string conn = @"Server=BRINTA-PC; Database=CoffeeShop; Integrated Security=true";
                SqlConnection sqlConn = new SqlConnection(conn);
                string command = @"select * from Customer";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConn);
                sqlConn.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                sqlConn.Close();
                return dataTable;
            
            
        }
        public bool UpdateCustomer(string name, string contact, string address, string item, int quantity, int id)
        {

            
                string conn = @"Server=BRINTA-PC; Database=CoffeeShop; Integrated Security=true";
                SqlConnection sqlConn = new SqlConnection(conn);
                string command = @"update Customer set Name='" + name + "',Contact='" + contact + "',Address='" + address + "',Item='" + item + "',Quantity=" + quantity + " where ID=" + id + "";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConn);
                sqlConn.Open();
                bool isExecuted = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                if (isExecuted)
                {
                    string command2 = @"select * from Customer where Name='" + name + "'";
                    SqlCommand sqlCommand2 = new SqlCommand(command2, sqlConn);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand2);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    // customerDataGridView.DataSource = dataTable;

                }
                else
                {
                    // MessageBox.Show("Can Not Update");
                }
                sqlConn.Close();
            
            
            return false;
        }
        public DataTable SearchCustomer(string searchName)
        {

            string conn = @"Server=BRINTA-PC; Database=CoffeeShop; Integrated Security=true";
            SqlConnection sqlConn = new SqlConnection(conn);
            string command = @"select * from Customer where Name='" + searchName + "'";
            SqlCommand sqlCommand = new SqlCommand(command, sqlConn);
            sqlConn.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            
            sqlConn.Close();

            return dataTable;
        }
        public bool DeleteCustomer(int id)
        {
            string conn = @"Server=BRINTA-PC; Database=CoffeeShop; Integrated Security=true";
            SqlConnection sqlConn = new SqlConnection(conn);
            string command = @"delete from Customer where ID=" + id + "";
            SqlCommand sqlCommand = new SqlCommand(command, sqlConn);
            sqlConn.Open();
            int isExecuted = sqlCommand.ExecuteNonQuery();
            if (isExecuted > 0)
            {
                return true;
            }
            else
            {

            }
            sqlConn.Close();
            return false;
        }
    }
}
