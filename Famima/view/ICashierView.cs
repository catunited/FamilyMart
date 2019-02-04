using Famima.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Famima.view
{
    public interface ICashierView
    {
        void SetController(IController controller);
        void ClearList();
        void AddItemToList(item item);
        void RemoveItemFromList(int id);
        void Check();
        void LoadItemsToDropList(List<item> list);
        void LoadPrice(double price, double discountPrice);
    }
}
