using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;


namespace CoffeeShopLayer.Repository
{
    
    class OrderRepository
    {
        public DataTable ShowOrder()
        {

            string conn = @"Server=BRINTA-PC; Database=CoffeeShop; Integrated Security=true";
            SqlConnection sqlConn = new SqlConnection(conn);
            string command = @"select * from Item";
            SqlCommand sqlCommand = new SqlCommand(command, sqlConn);
            sqlConn.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            sqlConn.Close();
            return dataTable;


        }
        public DataTable SearchOrder(string searchName)
        {

            string conn = @"Server=BRINTA-PC; Database=CoffeeShop; Integrated Security=true";
            SqlConnection sqlConn = new SqlConnection(conn);
            string command = @"select * from Item where Name='" + searchName + "'";
            SqlCommand sqlCommand = new SqlCommand(command, sqlConn);
            sqlConn.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);


            sqlConn.Close();

            return dataTable;
        }
        public bool AddInfo(string name,int price)
        {
            
                
                string connectionString = @"Server=BRINTA-PC; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                string commandString = @"insert into Item values('" + name + "' ," + price + " )";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
                sqlConnection.Open();
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    return true;
                }

                sqlConnection.Close();
            






            return false;
        }
        public bool UpdateItem(string name,int price, int id)
        {


            string conn = @"Server=BRINTA-PC; Database=CoffeeShop; Integrated Security=true";
            SqlConnection sqlConn = new SqlConnection(conn);
            string command = @"update Item set Name='" + name + "',Price= "+price+" where ID=" + id + "";
            SqlCommand sqlCommand = new SqlCommand(command, sqlConn);
            sqlConn.Open();
            bool isExecuted = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
            if (isExecuted)
            {
                string command2 = @"select * from Item where Name='" + name + "'";
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

        public bool DeleteItem(int id)
        {
            string conn = @"Server=BRINTA-PC; Database=CoffeeShop; Integrated Security=true";
            SqlConnection sqlConn = new SqlConnection(conn);
            string command = @"delete from Item where ID=" + id + "";
            SqlCommand sqlCommand = new SqlCommand(command, sqlConn);
            sqlConn.Open();
            int isExecuted=sqlCommand.ExecuteNonQuery();
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
