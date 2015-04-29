using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SupermarketKata
{
    /// <summary>
    /// The inital / main form of the application
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Main form constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        // Run on form load (once)
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadSKUs(); // loads the SKU keys into the 'select sku' combo box
            tbTotalPrice.Text = "0"; // set initial total price to 0 (no items added yet)
        }

        #region Event Handlers

        // Event handler for the 'Start Over' button
        // Clears total price and the added items list
        private void btnStartOver_Click(object sender, EventArgs e)
        {
            dgvItems.Rows.Clear();
            tbTotalPrice.Text = "0";
        }

        // Update price comment when selecting an SKU
        private void cbSKU_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbItemPrice.Text = SKULoigic.GetSKUPriceComment(cbSKU.SelectedItem.ToString());
        }

        // Add an item to the items list, making sure to add the correct promotion prices if any and update
        // the total price
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbSKU.SelectedItem == null)
            {
                MessageBox.Show("You must select an SKU before you can add it to the list.", "Add SKU Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // This block checks if the item is already in the list, if it is then increment the quanity
                // otherwise add a new now

                bool inList = false;

                foreach (DataGridViewRow row in dgvItems.Rows)
                {
                    // discount first row (headers) or an empty row (possibly last row)
                    if (row.Cells[0].Value != null)
                    {
                        // if we find a matching item in the list...
                        if (row.Cells[0].Value.ToString() == cbSKU.SelectedItem.ToString())
                        {
                            inList = true;
                            
                            // increment quantity
                            row.Cells[1].Value = (Convert.ToString(Convert.ToInt32(row.Cells[1].Value.ToString()) + 1));

                            // work out price, accounting for promotional offers
                            row.Cells[2].Value = SKULoigic.GetSKUPrice(cbSKU.SelectedItem.ToString(),
                                Convert.ToInt32(row.Cells[1].Value.ToString()));
                        }
                    }
                }

                // simply add a new row with a quantity of 1

                if (!inList)
                    dgvItems.Rows.Add(cbSKU.SelectedItem.ToString(), "1", SKULoigic.GetSKUPrice(cbSKU.SelectedItem.ToString(), 1));

                tbTotalPrice.Text = "0";

                // calculate total price by iterating through total price of each item and its quanity in the data grid view

                foreach (DataGridViewRow row in dgvItems.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        tbTotalPrice.Text = Convert.ToString(Convert.ToInt32(tbTotalPrice.Text) + 
                            Convert.ToInt32(row.Cells[2].Value.ToString()));
                    }
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Loads the SKU keys using the SKULogic class, containing a method to retrieve these values from the resources file
        /// The resources file is acting as a database for quickness of development
        /// </summary>
        private void LoadSKUs()
        {
            cbSKU.Items.AddRange(SKULoigic.GetSKUs().ToArray());
        }

        #endregion
    }
}
