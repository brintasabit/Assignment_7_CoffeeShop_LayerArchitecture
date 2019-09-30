using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using CoffeeShopLayer.Repository;
namespace CoffeeShopLayer.Bill
{
    class OrderManager
    {
        OrderRepository _orderRepository = new OrderRepository();
        public DataTable ShowOrder()
        {
            return _orderRepository.ShowOrder();
        }
        public DataTable SearchOrder(string searchName)
        {
            return _orderRepository.SearchOrder(searchName);
        }
        public bool AddInfo(string name, int price)
        {
            return _orderRepository.AddInfo(name,price);
        }
        public bool UpdateItem(string name, int price, int id)
        {
            return _orderRepository.UpdateItem(name, price, id);
        }
        public bool DeleteItem(int id)
        {
            return _orderRepository.DeleteItem(id);
        }
    }
}
