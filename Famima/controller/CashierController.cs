using Famima.view;
//using Famima.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Famima.controller
{

    public class CashierController: IController
    {
        public ICashierView View { get; set; }
        public List<item> Items { get; set; }
        public Cashier Cashier { get; set; }

        public CashierController(ICashierView view, List<item> items)
        {
            View = view;
            Items = items;
            view.SetController(this);
            Cashier = Cashier.GetInstance();
        }

        public void Check(List<item> items)
        {
            Cashier cashier = Cashier.GetInstance();
            cashier.Items = items;
            double totalPrice = cashier.GetTotalPrice();
            double discountPrice = cashier.GetDiscountPrice();
            foreach(item item in items)
            {
                item.decreaseItemQuantity(item);
            }
            View.LoadItemsToDropList(item.all());
            View.LoadPrice(totalPrice, discountPrice);
        }

        public void LoadView()
        {
            View.LoadItemsToDropList(Items);
            View.ClearList();
        }
    }
}
