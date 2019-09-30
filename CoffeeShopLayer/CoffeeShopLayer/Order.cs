using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;


using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeShopLayer.Bill;

namespace CoffeeShopLayer
{
    
    public partial class Order : Form
    {
        OrderManager _orderManager = new OrderManager();
        public Order()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            DataTable isSearch = _orderManager.SearchOrder(nameTextBox.Text);
            if (isSearch.Rows.Count > 0)
            {

                //  customerDataGridView.DataSource = _customerManager.SearchCustomer(searchTextBox.Text);
                MessageBox.Show("Item Name Exists");
            }


            else
            {
                bool isAdded = _orderManager.AddInfo(nameTextBox.Text, Convert.ToInt32(priceTextBox.Text));
                MessageBox.Show("Saved");
            }
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            try
            {
                orderDataGridView.DataSource = _orderManager.ShowOrder();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            DataTable isSearch = _orderManager.SearchOrder(searchTextBox.Text);
            if (isSearch.Rows.Count > 0)
            {

                orderDataGridView.DataSource = _orderManager.SearchOrder(searchTextBox.Text);
                MessageBox.Show("Data Found");
            }
            else
            {
                MessageBox.Show("No Data Found");
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                bool isUpdated = _orderManager.UpdateItem(nameTextBox.Text, Convert.ToInt32(priceTextBox.Text), Convert.ToInt32(idTextBox.Text));
                orderDataGridView.DataSource = _orderManager.ShowOrder();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
            
        }
        
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                bool isDeleted = _orderManager.DeleteItem(Convert.ToInt32(idTextBox.Text));
                if (isDeleted)
                {
                    MessageBox.Show("Deleted");
                }
                else
                {
                    MessageBox.Show("No Data Found");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
