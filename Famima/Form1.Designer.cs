namespace Famima
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.itemComboBox = new System.Windows.Forms.ComboBox();
            this.addItemBtn = new System.Windows.Forms.Button();
            this.quantityUpDown = new System.Windows.Forms.NumericUpDown();
            this.clearTableBtn = new System.Windows.Forms.Button();
            this.checkBtn = new System.Windows.Forms.Button();
            this.itemListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.quantityUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // itemComboBox
            // 
            this.itemComboBox.FormattingEnabled = true;
            this.itemComboBox.Location = new System.Drawing.Point(12, 40);
            this.itemComboBox.Name = "itemComboBox";
            this.itemComboBox.Size = new System.Drawing.Size(140, 20);
            this.itemComboBox.TabIndex = 0;
            this.itemComboBox.SelectedIndexChanged += new System.EventHandler(this.itemComboBox_SelectedIndexChanged);
            // 
            // addItemBtn
            // 
            this.addItemBtn.Location = new System.Drawing.Point(231, 37);
            this.addItemBtn.Name = "addItemBtn";
            this.addItemBtn.Size = new System.Drawing.Size(93, 23);
            this.addItemBtn.TabIndex = 1;
            this.addItemBtn.Text = "Add";
            this.addItemBtn.UseVisualStyleBackColor = true;
            this.addItemBtn.Click += new System.EventHandler(this.addItemBtn_Click);
            // 
            // quantityUpDown
            // 
            this.quantityUpDown.Location = new System.Drawing.Point(158, 40);
            this.quantityUpDown.Name = "quantityUpDown";
            this.quantityUpDown.Size = new System.Drawing.Size(67, 19);
            this.quantityUpDown.TabIndex = 3;
            // 
            // clearTableBtn
            // 
            this.clearTableBtn.Location = new System.Drawing.Point(12, 264);
            this.clearTableBtn.Name = "clearTableBtn";
            this.clearTableBtn.Size = new System.Drawing.Size(90, 23);
            this.clearTableBtn.TabIndex = 5;
            this.clearTableBtn.Text = "Clear";
            this.clearTableBtn.UseVisualStyleBackColor = true;
            this.clearTableBtn.Click += new System.EventHandler(this.clearTableBtn_Click);
            // 
            // checkBtn
            // 
            this.checkBtn.Location = new System.Drawing.Point(231, 264);
            this.checkBtn.Name = "checkBtn";
            this.checkBtn.Size = new System.Drawing.Size(90, 23);
            this.checkBtn.TabIndex = 6;
            this.checkBtn.Text = "Check";
            this.checkBtn.UseVisualStyleBackColor = true;
            this.checkBtn.Click += new System.EventHandler(this.checkBtn_Click);
            // 
            // itemListView
            // 
            this.itemListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.itemListView.Location = new System.Drawing.Point(12, 95);
            this.itemListView.Name = "itemListView";
            this.itemListView.Size = new System.Drawing.Size(309, 152);
            this.itemListView.TabIndex = 7;
            this.itemListView.UseCompatibleStateImageBehavior = false;
            this.itemListView.View = System.Windows.Forms.View.Details;
            this.itemListView.DoubleClick += new System.EventHandler(this.itemListView_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 41;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Quantity";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Price x1";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Total price";
            this.columnHeader5.Width = 83;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 319);
            this.Controls.Add(this.itemListView);
            this.Controls.Add(this.checkBtn);
            this.Controls.Add(this.clearTableBtn);
            this.Controls.Add(this.quantityUpDown);
            this.Controls.Add(this.addItemBtn);
            this.Controls.Add(this.itemComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Family Mart";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.quantityUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox itemComboBox;
        private System.Windows.Forms.Button addItemBtn;
        private System.Windows.Forms.NumericUpDown quantityUpDown;
        private System.Windows.Forms.Button clearTableBtn;
        private System.Windows.Forms.Button checkBtn;
        private System.Windows.Forms.ListView itemListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}

