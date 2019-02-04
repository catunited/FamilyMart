using Famima.controller;
using Famima.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Famima
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Form1 view = new Form1();
            List<item> items = item.all();

            CashierController controller = new CashierController(view, items);
            controller.Cashier.ClearDiscounts();

            PercentComboDiscount comboDiscount = new PercentComboDiscount();
            comboDiscount.Ids = new int[] { 0, 2, 3 };
            comboDiscount.Quantities = new int[] { 2, 1, 1 };
            comboDiscount.Percent = 40; //40%
            controller.Cashier.AddDiscount(comboDiscount);

            PriceComboDiscount comboDiscount1 = new PriceComboDiscount();
            comboDiscount1.Ids = new int[] { 0, 2 };
            comboDiscount1.Quantities = new int[] { 1, 1 };
            comboDiscount1.Price = 5000; //VND
            controller.Cashier.AddDiscount(comboDiscount1);

            PercentDiscount discount = new PercentDiscount();
            discount.ItemId = 3;
            discount.Percent = 10; //10%
            //controller.Cashier.AddDiscount(discount);

            PriceDiscount discount1 = new PriceDiscount();
            discount1.ItemId = 2;
            discount1.Price = 4000; //VND
            //controller.Cashier.AddDiscount(discount1);

            controller.LoadView();
            view.ShowDialog();
            
        }
    }
}
