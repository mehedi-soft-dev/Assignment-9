using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomerInfo.Manager;
using CustomerInfo.Model;

namespace CustomerInfo
{
    public partial class Home : Form
    {
        private int selectedID;

        CustomerManager _customerManager = new CustomerManager();

        public Home()
        {
            InitializeComponent();
            districtComboBox.DataSource = _customerManager.ComboDistricts();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (addButton.Text == "Add")
                {
                    if (String.IsNullOrEmpty(codeTextBox.Text))
                    {
                        codeErrorLabel.Text = "* Please Enter Code";
                        return;
                    }
                    else
                    {
                        codeErrorLabel.Text = "";
                    }

                    if (codeTextBox.TextLength != 4)
                    {
                        codeErrorLabel.Text = "* Must be 4 Charecter";
                        return;
                    }
                    else
                    {
                        codeErrorLabel.Text = "";
                    }

                    if (!_customerManager.IsCodeUniqe(codeTextBox.Text))
                    {
                        codeErrorLabel.Text = "Code Already Exist";
                        return;
                    }
                    else
                    {
                        codeErrorLabel.Text = "";
                    }

                    if (String.IsNullOrEmpty(nameTextBox.Text))
                    {
                        nameErrorLabel.Text = "* Please Enter a Name";
                        return;
                    }
                    else
                    {
                        nameErrorLabel.Text = "";
                    }

                    if (String.IsNullOrEmpty(contactTextBox.Text))
                    {
                        contactErrorLabel.Text = "* Please Enter a Valid Mobile Number";
                        return;
                    }
                    else
                    {
                        contactErrorLabel.Text = "";
                    }

                    if (String.IsNullOrEmpty(contactTextBox.Text))
                    {
                        contactErrorLabel.Text = "* Please Enter a Valid Mobile Number";
                        return;
                    }
                    else
                    {
                        contactErrorLabel.Text = "";
                    }

                    if (contactTextBox.TextLength != 11)
                    {
                        contactErrorLabel.Text = "Enter Valid Mobile No(11 digit)";
                        return;
                    }
                    else
                    {
                        contactErrorLabel.Text = "";
                    }

                    if (!_customerManager.IsContactUniqe(contactTextBox.Text))
                    {
                        contactErrorLabel.Text = "Contact Number Already Exist";
                        return;
                    }
                    else
                    {
                        contactErrorLabel.Text = "";
                    }

                    if (Convert.ToInt32(districtComboBox.SelectedValue) == 0)
                    {
                        districtErrorLabel.Text = "* Please Select District";
                        return;
                    }
                    else
                    {
                        districtErrorLabel.Text = "";
                    }

                    Customer customer = new Customer();

                    customer.Code = codeTextBox.Text;
                    customer.Name = nameTextBox.Text;
                    customer.Contact = contactTextBox.Text;
                    customer.Address = addressTextBox.Text;
                    customer.DistrictId = Convert.ToInt32(districtComboBox.SelectedValue);

                    if (_customerManager.AddCustomer(customer))
                    {
                        MessageBox.Show("Data Saved Successfully..!!");
                    }
                    else
                    {
                        MessageBox.Show("Not Saved..!!");
                    }
                }

                else
                {
                    if (String.IsNullOrEmpty(codeTextBox.Text))
                    {
                        codeErrorLabel.Text = "* Please Enter Code";
                        return;
                    }
                    else
                    {
                        codeErrorLabel.Text = "";
                    }

                    if (codeTextBox.TextLength != 4)
                    {
                        codeErrorLabel.Text = "* Must be 4 Charecter";
                        return;
                    }
                    else
                    {
                        codeErrorLabel.Text = "";
                    }

                    if (String.IsNullOrEmpty(nameTextBox.Text))
                    {
                        nameErrorLabel.Text = "* Please Enter a Name";
                        return;
                    }
                    else
                    {
                        nameErrorLabel.Text = "";
                    }

                    if (String.IsNullOrEmpty(contactTextBox.Text))
                    {
                        contactErrorLabel.Text = "* Please Enter a Valid Mobile Number";
                        return;
                    }
                    else
                    {
                        contactErrorLabel.Text = "";
                    }

                    if (contactTextBox.TextLength != 11)
                    {
                        contactErrorLabel.Text = "Enter Valid Mobile No(11 digit)";
                        return;
                    }
                    else
                    {
                        contactErrorLabel.Text = "";
                    }

                    if (Convert.ToInt32(districtComboBox.SelectedValue) == 0)
                    {
                        districtErrorLabel.Text = "* Please Select District";
                        return;
                    }
                    else
                    {
                        districtErrorLabel.Text = "";
                    }

                    Customer customer = new Customer();

                    customer.ID = selectedID;
                    customer.Code = codeTextBox.Text;
                    customer.Name = nameTextBox.Text;
                    customer.Contact = contactTextBox.Text;
                    customer.Address = addressTextBox.Text;
                    customer.DistrictId = Convert.ToInt32(districtComboBox.SelectedValue);

                    if (_customerManager.UpdateCustomer(customer))
                    {
                        addButton.Text = "Add";
                        MessageBox.Show("Updated Successfully..!!");
                    }
                    else
                    {
                        MessageBox.Show("Not Updated..!!");
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void showAllButton_Click(object sender, EventArgs e)
        {
            ClearErrorLabel();

            if (_customerManager.Display().Count > 0)
            {
                showDataGridView.DataSource = _customerManager.Display();
            }
            else
            {
                MessageBox.Show("No Data Found...!");
            }
        }

        private void showDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.showDataGridView.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
        }

        private void showDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow dataGridViewRow = showDataGridView.Rows[e.RowIndex];

                codeTextBox.Text = dataGridViewRow.Cells[1].Value.ToString();
                nameTextBox.Text = dataGridViewRow.Cells[2].Value.ToString();
                contactTextBox.Text = dataGridViewRow.Cells[3].Value.ToString();
                addressTextBox.Text = dataGridViewRow.Cells[4].Value.ToString();

                districtComboBox.Text = dataGridViewRow.Cells[5].Value.ToString();

                addButton.Text = "Update";

                selectedID = Convert.ToInt32(dataGridViewRow.Cells[0].Value);

            }
        }

        private void ClearErrorLabel()
        {
            codeErrorLabel.Text = "";
            nameErrorLabel.Text = "";
            contactErrorLabel.Text = "";
            districtErrorLabel.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearErrorLabel();

            Customer customer = new Customer();
            customer.Code = codeTextBox.Text;

            if (_customerManager.SearchCustomerByCode(customer).Count > 0)
            {
                showDataGridView.DataSource = _customerManager.SearchCustomerByCode(customer);
            }
            else
            {
                MessageBox.Show("No Data Found...!");
            }
        }
    }
}
