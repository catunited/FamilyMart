using Famima.controller;
using Famima.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Famima
{
    public partial class Form1 : Form, ICashierView
    {
        IController _controller;
        List<item> _items;
        public Form1()
        {
            InitializeComponent();
        }

        static readonly int _id = 0;
        static readonly int _name = 1;
        static readonly int _quantity = 2;
        static readonly int _price = 3;
        static readonly int _totalPrice = 4;


        public void AddItemToList(item item)
        {
            string[] row = { item.id+"", item.name, item.quantity + "", item.price+"", (item.price * item.quantity) + "" };
            foreach(ListViewItem i in itemListView.Items)
            {
                if(i.SubItems[_id].Text.Equals(item.id + ""))
                {
                    double newPrice = double.Parse(i.SubItems[_totalPrice].Text) + (item.price * item.quantity);
                    int newQuantity = int.Parse(i.SubItems[_quantity].Text) + item.quantity;
                    if(newQuantity > quantityUpDown.Maximum)
                    {
                        newQuantity = int.Parse(quantityUpDown.Maximum.ToString());
                        newPrice = item.price*newQuantity;
                    }
                    i.SubItems[_totalPrice].Text = newPrice+"";
                    i.SubItems[_quantity].Text = newQuantity+"";        
                    return;
                }
            }
            var listViewItem = new ListViewItem(row);
            itemListView.Items.Add(listViewItem);
        }

        public void Check()
        {
            List<item> itemsForChecking = new List<item>();
            foreach (ListViewItem listItem in itemListView.Items)
            {
                item item = new item();
                item.id = int.Parse(listItem.SubItems[_id].Text);
                item.name = listItem.SubItems[_name].Text;
                item.price = double.Parse(listItem.SubItems[_price].Text);
                item.quantity = int.Parse(listItem.SubItems[_quantity].Text);
                itemsForChecking.Add(item);
            }
            _controller.Check(itemsForChecking);
        }

        public void ClearList()
        {
            itemListView.Items.Clear();
        }

        public void LoadItemsToDropList(List<item> items)
        {
            if (items == null) return;
            _items = items;
            var bindingList = new BindingList<item>(items);
            itemComboBox.DataSource = bindingList;
        }

        public void RemoveItemFromList(int id)
        {
            foreach(ListViewItem item in itemListView.Items)
            {
                if(item.SubItems[_id].Text.Equals(id + ""))
                {
                    itemListView.Items.Remove(item);
                    break;
                }
            }
        }

        public void SetController(IController controller)
        {
            _controller = controller;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            quantityUpDown.Minimum = 1;
        }

        private void itemListView_DoubleClick(object sender, EventArgs e)
        {
            if (itemListView.SelectedItems.Count > 0)
            {
                ListViewItem item = itemListView.SelectedItems[0];
                int itemId = int.Parse(item.SubItems[_id].Text);
                if(MessageBox.Show("Remove this item?", "Confirm message",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == DialogResult.Yes){
                    RemoveItemFromList(itemId);
                }
            }
        }

        private void addItemBtn_Click(object sender, EventArgs e)
        {
            string itemName = itemComboBox.SelectedValue.ToString();
            int quantity = (int) quantityUpDown.Value;
            item item = new item();
            item.name = itemName;
            item.quantity = quantity;
            foreach(item i in _items)
            {
                if(i.name.Equals(item.name))
                {
                    item.id = i.id;
                    item.price = i.price;
                    AddItemToList(item);
                    break;
                }
            }
            quantityUpDown.Value = 1;
        }

        private void setQuantityMaxValue(int max)
        {
            quantityUpDown.Maximum = max;
        }

        private void itemComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_items == null) return;
            string itemName = itemComboBox.SelectedValue.ToString();
            foreach(item item in _items)
            {
                if (item.name.Equals(itemName))
                {
                    setQuantityMaxValue(item.quantity);
                    break;
                }
            }
        }

        private void checkBtn_Click(object sender, EventArgs e)
        {
            this.Check();
        }

        private void clearTableBtn_Click(object sender, EventArgs e)
        {
            ClearList();
        }

        public void LoadPrice(double price, double discountPrice)
        {
            MessageBox.Show("Total price: "+price+"\n"+
                "Discount: " + discountPrice+"\n"+
                "Must pay: "+ (price - discountPrice));
        }
    }
}
