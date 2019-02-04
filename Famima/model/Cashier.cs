using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Famima;

namespace Famima
{
    public interface DiscountBehaviour
    {
        double Discount(List<item> items);
    }

    public abstract class ComboDiscount : DiscountBehaviour
    {
        public int[] Ids
        {
            get => _ids;
            set
            {
                if (value != null)
                    _ids = value;
            }
        }

        public int[] Quantities
        {
            get => _quantities;
            set
            {
                if (value != null)
                {
                    Boolean fine = true;
                    foreach (int quan in value)
                    {
                        if (quan <= 0)
                        {
                            fine = false;
                            break;
                        }
                    }
                    if (fine)
                        _quantities = value;
                }
            }
        }
        private int[] _ids;
        private int[] _quantities;

        public double Discount(List<item> items)
        {
            if (items == null) return 0;
            if(_quantities == null || _ids == null) return 0;
            if (_quantities.Length != _ids.Length) return 0;
            List<item> matchedItems = new List<item>();
            foreach (int id in _ids)
            {
                foreach (item item in items)
                    if (item.id == id)
                    {
                        matchedItems.Add(item);
                    }
            }
            if (matchedItems.Count < _ids.Length) return 0;
            int minSet = matchedItems[0].quantity / _quantities[0];
            for (int index = 1; index < _quantities.Length; index++)
            {
                int currentSet = matchedItems[index].quantity / _quantities[index];
                if (currentSet < minSet) minSet = currentSet;
            }
            double discountPrice = applyDiscount(matchedItems, minSet);
            
            return discountPrice;
        }

        public abstract double applyDiscount(List<item> matchedItems, int minSet);
    
    }

    public class PercentComboDiscount : ComboDiscount
    {
        public int Percent
        {
            get
            {
                return _percent;
            }
            set
            {
                if (value >= 0 && value <= 100)
                    _percent = value;
            }
        }
        private int _percent;

        public override double applyDiscount(List<item> matchedItems, int minSet)
        {
            double discountPrice = 0;
            double totalPrice = 0;
            for (int index = 0; index < Quantities.Length; index++)
            {
                totalPrice += (matchedItems[index].price * Quantities[index]) * minSet;
            }
            discountPrice = totalPrice * _percent / 100;
            return discountPrice;
        }
    }

    public class PriceComboDiscount : ComboDiscount
    {
        public int Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (value >= 0)
                    _price = value;
            }
        }
        
        private int _price;

        public override double applyDiscount(List<item> matchedItems, int minSet)
        {
            double discountPrice = minSet * _price;
            return discountPrice;
        }
    }

    public class PercentDiscount : DiscountBehaviour
    {
        private int _itemId;
        public int ItemId
        {
            get
            {
                return _itemId;
            }
            set
            {
                if (value >= 0)
                    _itemId = value;
            }
        }
        private int _percent;
        public int Percent
        {
            get
            {
                return _percent;
            }
            set
            {
                if (value >= 0 && value <= 100)
                    _percent = value;
            }
        }

        public double Discount(List<item> items)
        {
            if (items == null) return 0;
            double discountPrice = 0;
            foreach (item item in items)
            {
                if (item.id == _itemId)
                {
                    discountPrice = (item.price * item.quantity) * (_percent) / 100;
                    break;
                }
            }
            return discountPrice;
        }
    }

    public class PriceDiscount : DiscountBehaviour
    {
        private int _itemId;
        public int ItemId
        {
            get
            {
                return _itemId;
            }
            set
            {
                if (value >= 0)
                    _itemId = value;
            }
        }
        private int _price;
        public int Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (value >= 0)
                    _price = value;
            }
        }

        public double Discount(List<item> items)
        {
            if (items == null) return 0;
            double discountPrice = 0;
            foreach (item item in items)
            {
                if (item.id == _itemId)
                {
                    discountPrice += _price;
                    break;
                }
            }
            return discountPrice;
        }
    }

    public class Cashier
    {
        private static Cashier _cashier;
        private List<DiscountBehaviour> _discounts;
        public List<item> Items { get; set; }

        private Cashier()
        {
            _discounts = new List<DiscountBehaviour>();
        }

        public static Cashier GetInstance()
        {
            if (_cashier == null)_cashier = new Cashier();
            return _cashier;
        }

        public void ClearDiscounts()
        {
            _discounts = new List<DiscountBehaviour>();
        }

        public void AddDiscount(DiscountBehaviour discount)
        {
            if (discount == null) return;
            _discounts.Add(discount);
        }

        public double GetTotalPrice()
        {
            if (Items == null) return 0;
            double totalPrice = 0;
            foreach(item item in Items)
            {
                totalPrice += item.price * item.quantity;
            }
            return totalPrice;
        }

        public double GetDiscountPrice()
        {
            double totalDiscount = 0;
            foreach (DiscountBehaviour discountBehaviour in _discounts)
            {
                totalDiscount += discountBehaviour.Discount(Items);
            }
            return totalDiscount;
        }
    }
}

    