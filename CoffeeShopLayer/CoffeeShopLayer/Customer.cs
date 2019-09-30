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
    public partial class Customer : Form
    {
        Order order = new Order();
        CustomerManager _customerManager = new CustomerManager();
        public Customer()
        {
            InitializeComponent();
        }
        
        private void AddButton_Click(object sender, EventArgs e)
        {
            
            DataTable isSearch = _customerManager.SearchCustomer(nameTextBox.Text);
            if (isSearch.Rows.Count > 0)
            {

              //  customerDataGridView.DataSource = _customerManager.SearchCustomer(searchTextBox.Text);
                MessageBox.Show("Name Exists");
            }
            
            
            else 
            {
                bool isAdded = _customerManager.AddInfo(nameTextBox.Text, contactTextBox.Text, addressTextBox.Text, itemComboBox.Text, Convert.ToInt32(quantityTextBox.Text));
                MessageBox.Show("Saved");
            }
           /* else
            {
                MessageBox.Show("Not Saved");
            }*/
        }
        
        private void ShowButton_Click(object sender, EventArgs e)
        {
            customerDataGridView.DataSource = _customerManager.ShowCustomer();
        }
       
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            bool isUpdated=_customerManager.UpdateCustomer(nameTextBox.Text, contactTextBox.Text, addressTextBox.Text, itemComboBox.Text, Convert.ToInt32(quantityTextBox.Text),Convert.ToInt32(idTextBox.Text));
            customerDataGridView.DataSource = _customerManager.ShowCustomer();
        }

       
        private void SearchButton_Click(object sender, EventArgs e)
        {
            // bool isSearch =Convert.ToBoolean( _customerManager.SearchCustomer(searchTextBox.Text));
            DataTable isSearch = _customerManager.SearchCustomer(searchTextBox.Text);
            if (isSearch.Rows.Count>0)
            {
                
                customerDataGridView.DataSource = _customerManager.SearchCustomer(searchTextBox.Text);
                MessageBox.Show("Data Found");
            }
              else
            {
                MessageBox.Show("No Data Found");
            }
           
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                bool isDeleted = _customerManager.DeleteCustomer(Convert.ToInt32(idTextBox.Text));
                if (isDeleted)
                {
                    MessageBox.Show("Deleted");
                }
                else
                {
                    MessageBox.Show("No Data Found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ItemButton_Click(object sender, EventArgs e)
        {
            if (order.IsDisposed)
            {
                order = new Order();
            }
            //itemCoffeeShop.MdiParent = this;
            order.Show();
            order.BringToFront();
        }
    }
}
