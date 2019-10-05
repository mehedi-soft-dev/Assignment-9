using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using CustomerInfo.Model;

namespace CustomerInfo.Repository
{
    public class CustomerRepository
    {
        public bool AddCustomer(Customer customer)
        {
            string sqlString = @"Server=MH-PC\SQLEXPRESS; Database=CustomerInformation; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(sqlString);

            string commandString = @"INSERT INTO Customers (Code, Name, Contact, Address, DistrictId) VALUES('"+customer.Code+"', '"+customer.Name+"', '"+customer.Contact+"', '"+customer.Address+"', '"+customer.DistrictId+"')";
            SqlCommand sqlCommand = new SqlCommand(commandString,sqlConnection);

            sqlConnection.Open();

            int isAdded = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            if (isAdded > 0)
                return true;
            else
                return false;
        }

        public bool UpdateCustomer(Customer customer)
        {
            string sqlString = @"Server=MH-PC\SQLEXPRESS; Database=CustomerInformation; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(sqlString);

            string commandString = @"UPDATE Customers SET Code = '"+customer.Code+"', Name = '"+customer.Name+"', Contact = '"+customer.Contact+"', Address = '"+customer.Address+"', DistrictId = "+customer.DistrictId+" WHERE ID = "+customer.ID+" ";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            int isUpdated = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            if (isUpdated > 0)
                return true;
            else
                return false;
        }

        public List<District> ComboDistricts()
        {
            List<District> districts = new List<District>();

            string sqlString = @"Server=MH-PC\SQLEXPRESS; Database=CustomerInformation; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(sqlString);

            string commandString = @"SELECT ID, Name FROM Districts";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                District district = new District();

                district.ID=Convert.ToInt32(sqlDataReader["ID"]);
                district.Name = sqlDataReader["Name"].ToString();

                districts.Add(district);
            }

            sqlConnection.Close();

            District dis = new District();
            dis.ID = 0;
            dis.Name = "-SELECT-";
            districts.Insert(0, dis);

            return districts;
        }

        public List<ViewCustomer> Display()
        {
            List<ViewCustomer> viewCustomers = new List<ViewCustomer>();

            string sqlString = @"Server=MH-PC\SQLEXPRESS; Database=CustomerInformation; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(sqlString);

            string commandString = @"SELECT * FROM CustomerDetailsView";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                //Customer customer = new Customer();

                //customer.ID = Convert.ToInt32(sqlDataReader["ID"]);
                //customer.Code = sqlDataReader["Code"].ToString();
                //customer.Name = sqlDataReader["Name"].ToString();
                //customer.Contact = sqlDataReader["Contact"].ToString();
                //customer.Address = sqlDataReader["District"].ToString();
                //customer.DistrictId = Convert.ToInt32(sqlDataReader["DistrictId"]);

                //customers.Add(customer);

                ViewCustomer viewCustomer = new ViewCustomer();
                
                viewCustomer.ID = Convert.ToInt32(sqlDataReader["ID"]);
                viewCustomer.Code = sqlDataReader["Code"].ToString();
                viewCustomer.Name = sqlDataReader["Name"].ToString();
                viewCustomer.Contact = sqlDataReader["Contact"].ToString();
                viewCustomer.Address = sqlDataReader["Address"].ToString();
                viewCustomer.District = sqlDataReader["District"].ToString();

                viewCustomers.Add(viewCustomer);
            }

            sqlConnection.Close();

            return viewCustomers;
        }

        public bool IsCodeUniqe(string code)
        {
            string sqlString = @"Server=MH-PC\SQLEXPRESS; Database=CustomerInformation; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(sqlString);

            string commandString = @"SELECT * FROM Customers WHERE Code = '"+code+"'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            int flag = 0;
            while (sqlDataReader.Read())
            {
                flag = 1;
                break;
            }

            sqlConnection.Close();

            if (flag == 0)
                return true;
            else
                return false;
        }

        public bool IsContactUniqe(string contact)
        {
            string sqlString = @"Server=MH-PC\SQLEXPRESS; Database=CustomerInformation; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(sqlString);

            string commandString = @"SELECT * FROM Customers WHERE Contact = '" + contact + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            int flag = 0;
            while (sqlDataReader.Read())
            {
                flag = 1;
                break;
            }

            sqlConnection.Close();

            if (flag == 0)
                return true;
            else
                return false;
        }

        public List<Customer> SearchCustomerByCode(Customer cus)
        {
            List<Customer> customers = new List<Customer>();

            string sqlString = @"Server=MH-PC\SQLEXPRESS; Database=CustomerInformation; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(sqlString);

            string commandString = @"SELECT * FROM Customers WHERE Code = '"+cus.Code+"'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Customer customer = new Customer();

                customer.ID = Convert.ToInt32(sqlDataReader["ID"]);
                customer.Code = sqlDataReader["Code"].ToString();
                customer.Name = sqlDataReader["Name"].ToString();
                customer.Contact = sqlDataReader["Contact"].ToString();
                customer.Address = sqlDataReader["Address"].ToString();
                customer.DistrictId = Convert.ToInt32(sqlDataReader["DistrictId"]);

                customers.Add(customer);
            }

            sqlConnection.Close();

            return customers;
        }
    }
}
