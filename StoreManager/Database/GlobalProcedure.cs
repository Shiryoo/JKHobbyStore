﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Media.Media3D;
using Bunifu.UI.WinForms;
using CustomComponents;
using LiveCharts.WinForms;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Mozilla;
using ReaLTaiizor.Util;
using StoreObjects;
using LiveCharts.Wpf;
using LiveCharts;
using Mysqlx.Crud;
using System.Xml.Linq;
using System.IO;
using Org.BouncyCastle.Asn1.X509;

namespace StoreManagerDb
{
    public class GlobalProcedure
    {
        public string servername;
        public string databasename;
        public string username;
        public string password;
        public string port;

        public MySqlConnection conStoreManager;
        public MySqlCommand sqlCommand;
        public string strConnection;

        // packages and classes
        public MySqlDataAdapter sqlAdapter;
        public DataTable datStoreMgr;

        private static int V_Logged_Staff_Id = 1;
        private static string loggedStaffRole = "Admin";

        public int LoggedStaffId { get { return V_Logged_Staff_Id; }  }
        public string LoggedStaffRole { get { return loggedStaffRole; } }
        public bool EnableDebugging {  get; set; }
       

        public bool FncConnectToDatabase()
        {

            this.EnableDebugging = false;

            try
            {
                servername = "localhost";
                databasename = "store_manager_db";
                username = "root";
                password = "1234";
                port = "3306";

                strConnection = "Server=" + servername + ";" +
                    "Database=" + databasename + ";" +
                    "User=" + username + ";" +
                    "Password=" + password + ";" +
                    "Port=" + port + ";" +
                    "Convert Zero Datetime=true";

                conStoreManager = new MySqlConnection(strConnection);
                sqlCommand = new MySqlCommand(strConnection, conStoreManager);
                //Debug.WriteLine("db connected");
                if (conStoreManager.State == ConnectionState.Closed)
                {
                    sqlCommand.Connection = conStoreManager;
                    conStoreManager.Open();
                    return true;
                }
                else
                {
                    conStoreManager.Close();
                    return false;
                }
            }catch (Exception err)
            {
                MessageBox.Show("Error Message" + err.Message);
            }
            return false;
        }

        public void ProcAddStaff(string p_first_name, string p_last_name, DateTime p_birth_date, string p_gender, string p_email_address, string p_mobile_no, string p_username, string p_password, string p_role_type)
        {

            int v_role_id = FncGetRoleId(p_role_type);

            if(FncGetStaffIdByUsername(p_username) > 0)
            {
                MessageBox.Show("Username is already in use");
                return;
            }

            if(FncStaffExists(p_first_name, p_last_name))
            {
                MessageBox.Show("Staff already exists");
                return;
            }

            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;
                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_add_staff"; // Stored procedure name
                gProcCmd.CommandType = CommandType.StoredProcedure;

                // Adding the parameters with SQL naming convention
                gProcCmd.Parameters.AddWithValue("p_first_name", p_first_name);
                gProcCmd.Parameters.AddWithValue("p_last_name", p_last_name);
                gProcCmd.Parameters.AddWithValue("p_birth_date", p_birth_date);
                gProcCmd.Parameters.AddWithValue("p_gender", p_gender);
                gProcCmd.Parameters.AddWithValue("p_email_address", p_email_address);
                gProcCmd.Parameters.AddWithValue("p_mobile_no", p_mobile_no);
                gProcCmd.Parameters.AddWithValue("p_username", p_username);
                gProcCmd.Parameters.AddWithValue("p_password", p_password);
                gProcCmd.Parameters.AddWithValue("p_role_id", v_role_id);

                // Execute the stored procedure
                gProcCmd.ExecuteNonQuery();
                
                if(EnableDebugging)
                    MessageBox.Show("Staff member added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            ClearData(); // Cleans up data after execution
        }

        public List<Staff> ProcSelectStaff()
        {
            List<Staff> staffList = new List<Staff>();

            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;
                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_select_staff"; // Stored procedure name
                gProcCmd.CommandType = CommandType.StoredProcedure;

                using (MySqlDataReader reader = gProcCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Assuming the view_staff returns the columns in the expected order
                        int id = reader.GetInt32("id");
                        string firstName = reader.GetString("first_name");
                        string lastName = reader.GetString("last_name");
                        DateTime birthDate = reader.GetDateTime("birth_date");
                        string gender = reader.GetString("gender");
                        string emailAddress = reader.IsDBNull(reader.GetOrdinal("email_address")) ? null : reader.GetString("email_address");
                        string mobileNum = reader.IsDBNull(reader.GetOrdinal("mobile_no")) ? null : reader.GetString("mobile_no");
                        string username = reader.GetString("username");
                        string password = reader.GetString("password");
                        string roleType = reader.GetString("role_type");

                        // Create a new Staff object and add it to the list
                        Staff staffMember = new Staff(id, firstName, lastName, birthDate,
                                                      gender, emailAddress, mobileNum,
                                                      username, password, roleType);
                        staffList.Add(staffMember);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            return staffList;
        }


        public void ProcUpdateStaffById(int p_id, string p_first_name, string p_last_name, DateTime p_birth_date,
                                  string p_gender, string p_email_address, string p_mobile_no,
                                  string p_username, string p_password, string p_role_type)
        {

            if(p_id != FncGetStaffIdByUsername(p_username))
            {
                MessageBox.Show("Username is already in use");
                return;
            }

            int v_role_id = FncGetRoleId(p_role_type);

            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;
                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_update_staff_by_id"; // Stored procedure name
                gProcCmd.CommandType = CommandType.StoredProcedure;

                // Adding input parameters
                gProcCmd.Parameters.AddWithValue("p_id", p_id);
                gProcCmd.Parameters.AddWithValue("p_first_name", p_first_name);
                gProcCmd.Parameters.AddWithValue("p_last_name", p_last_name);
                gProcCmd.Parameters.AddWithValue("p_birth_date", p_birth_date);
                gProcCmd.Parameters.AddWithValue("p_gender", p_gender);
                gProcCmd.Parameters.AddWithValue("p_email_address", p_email_address);
                gProcCmd.Parameters.AddWithValue("p_mobile_no", p_mobile_no);
                gProcCmd.Parameters.AddWithValue("p_username", p_username);
                gProcCmd.Parameters.AddWithValue("p_password", p_password);
                gProcCmd.Parameters.AddWithValue("p_role_id", v_role_id);

                // Execute the stored procedure
                gProcCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        public void ProcDeleteStaffById(int p_id)
        {
            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;
                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_delete_staff_by_id"; // Stored procedure name
                gProcCmd.CommandType = CommandType.StoredProcedure;

                // Adding input parameter
                gProcCmd.Parameters.AddWithValue("p_id", p_id);

                // Execute the stored procedure
                gProcCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }


        public bool FncStaffExists(string p_first_name, string p_last_name)
        {
            bool staffExists = false;

            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;
                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_staff_exists"; // Stored procedure name
                gProcCmd.CommandType = CommandType.StoredProcedure;

                // Adding input parameters
                gProcCmd.Parameters.AddWithValue("p_first_name", p_first_name);
                gProcCmd.Parameters.AddWithValue("p_last_name", p_last_name);

                // Execute the stored procedure and retrieve the result
                using (MySqlDataReader reader = gProcCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        staffExists = reader.GetInt32("staff_exists") == 1; // Check if staff exists
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            return staffExists;
        }


        public int FncGetRoleId(string p_role)
        {
            int roleId = -1;

            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;
                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_get_role_id"; // Stored procedure name
                gProcCmd.CommandType = CommandType.StoredProcedure;

                // Adding input parameter
                gProcCmd.Parameters.AddWithValue("p_role", p_role);

                // Execute the stored procedure and retrieve the result
                using (MySqlDataReader reader = gProcCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        roleId = reader.GetInt32("id"); // Get the id column from the result
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            return roleId;
        }


        private int FncGetStaffIdByUsername(string p_username)
        {
            int staffId = -1;

            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;
                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_get_staff_id_by_username"; // Stored procedure name
                gProcCmd.CommandType = CommandType.StoredProcedure;

                // Adding input parameter
                gProcCmd.Parameters.AddWithValue("p_username", p_username);

                // Execute the stored procedure and retrieve the result
                using (MySqlDataReader reader = gProcCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        staffId = reader.GetInt32("staff_id");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            return staffId;
        }


        private int FncGetTotalRecords()
        {
            return this.datStoreMgr.Rows.Count;
        }

        private void ClearData()
        {
            this.sqlAdapter.Dispose();
            this.datStoreMgr.Dispose();
        }

        public List<Item> FncGetProducts()
        {

            List<Item> list = new List<Item>();

            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;

                this.sqlAdapter = new MySqlDataAdapter();
                this.datStoreMgr = new DataTable();

                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_select_all_prod_cashier";
                gProcCmd.CommandType = CommandType.StoredProcedure;
                this.sqlAdapter.SelectCommand = this.sqlCommand;
                this.datStoreMgr.Clear();
                this.sqlAdapter.Fill(this.datStoreMgr);

                if (this.datStoreMgr.Rows.Count > 0)
                {
                    DataTable dataTable = this.datStoreMgr;
                    int row = 0;
                    int totalRecords = FncGetTotalRecords();

                    while (!(totalRecords - 1 < row))
                    {

                        int id = int.Parse(dataTable.Rows[row]["id"].ToString());
                        int itemCode = int.Parse(dataTable.Rows[row]["item_code"].ToString());
                        string itemName = dataTable.Rows[row]["item_name"].ToString();
                        double price = double.Parse(dataTable.Rows[row]["price"].ToString());
                        double costPerItem = double.Parse(dataTable.Rows[row]["cost_per_item"].ToString());
                        string size = dataTable.Rows[row]["size"].ToString();
                        string type = dataTable.Rows[row]["type"].ToString();
                        int currentStocks = int.Parse(dataTable.Rows[row]["current_stocks"].ToString());
                        string imgLocation = dataTable.Rows[row]["img_name"].ToString();

                        Item item = new Item(id, itemCode, itemName, price, costPerItem, size, type, currentStocks, imgLocation);
                        list.Add(item);

                        row++;
                    }

                }
                else
                {
                    MessageBox.Show("No data");
                }

                ClearData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return list;

        }

        public List<Item> FncGetFilteredProducts(string p_name, string p_size, string p_type, string order)
        {
            List<Item> list = new List<Item>();

            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;

                this.sqlAdapter = new MySqlDataAdapter();
                this.datStoreMgr = new DataTable();

                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_select_filtered_prod_cashier";
                gProcCmd.CommandType = CommandType.StoredProcedure;

                // Add parameters
                gProcCmd.Parameters.AddWithValue("@p_name", p_name);
                gProcCmd.Parameters.AddWithValue("@p_size", p_size);
                gProcCmd.Parameters.AddWithValue("@p_type", p_type);
                gProcCmd.Parameters.AddWithValue("@p_order", order);

                this.sqlAdapter.SelectCommand = gProcCmd;
                this.datStoreMgr.Clear();
                this.sqlAdapter.Fill(this.datStoreMgr);

                if (this.datStoreMgr.Rows.Count > 0)
                {
                    DataTable dataTable = this.datStoreMgr;
                    int row = 0;
                    int totalRecords = FncGetTotalRecords();

                    while (row < totalRecords)
                    {
                        int id = int.Parse(dataTable.Rows[row]["id"].ToString());
                        int itemCode = int.Parse(dataTable.Rows[row]["item_code"].ToString());
                        string itemName = dataTable.Rows[row]["item_name"].ToString();
                        double price = double.Parse(dataTable.Rows[row]["price"].ToString());
                        double costPerItem = double.Parse(dataTable.Rows[row]["cost_per_item"].ToString());
                        string size = dataTable.Rows[row]["size"].ToString();
                        string type = dataTable.Rows[row]["type"].ToString();
                        int currentStocks = int.Parse(dataTable.Rows[row]["current_stocks"].ToString());
                        string imgLocation = dataTable.Rows[row]["img_name"].ToString();

                        Item item = new Item(id, itemCode, itemName, price, costPerItem, size, type, currentStocks, imgLocation);
                        list.Add(item);

                        row++;
                    }
                }
                else
                {
                    //MessageBox.Show("No data");
                }

                ClearData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return list;
        }

        public void ProcAddTaxRate(double p_rate)
        {
            try
            {
                if (this.FncConnectToDatabase())
                {
                    MySqlCommand gProcCmd = this.sqlCommand;

                    // Set up the stored procedure
                    gProcCmd.Parameters.Clear();
                    gProcCmd.CommandText = "proc_add_tax_rate";
                    gProcCmd.CommandType = CommandType.StoredProcedure;

                    // Add the parameter for the tax rate
                    gProcCmd.Parameters.AddWithValue("@p_rate", p_rate);

                    // Execute the stored procedure
                    gProcCmd.ExecuteNonQuery();

                    // Optionally, you can close the connection here if you don't need it open
                    conStoreManager.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void ProcRestock(string p_item_name, double p_price, double p_cost_per_item, string p_size, string p_type, string p_supplier_name, int p_qty)
        {
            int v_item_id = FncGetItemId(p_item_name, p_price, p_cost_per_item, p_size, p_type, p_supplier_name);
            int v_supplier_id = FncGetSupplierId(p_supplier_name);

            if(v_item_id == -1)
            {
                string v_img_name = FncGetItemImageByItemName(p_item_name);

                MessageBox.Show("Item description does not exist.\nAdding new Item");
                ProcAddItem(p_item_name, p_size, p_type, p_price, p_cost_per_item, v_img_name, p_supplier_name, 5);
                v_item_id = FncGetItemId(p_item_name, p_price, p_cost_per_item, p_size, p_type, p_supplier_name);
                //return;
            }

            v_supplier_id = FncGetSupplierId(p_supplier_name);

            ProcRestockItem(v_item_id, p_qty);
            ProcAddInventoryAdded(v_item_id, p_qty, p_cost_per_item, v_supplier_id, V_Logged_Staff_Id);

            if (EnableDebugging) MessageBox.Show("Item restocked successfuly");
        }

        public string FncGetItemImageByItemName(string p_item_name)
        {
            string imgName = null;

            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;

                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_get_item_image_by_item_name"; // Name of the stored procedure
                gProcCmd.CommandType = CommandType.StoredProcedure;

                // Add parameters
                gProcCmd.Parameters.AddWithValue("@p_item_name", p_item_name);

                // Execute and get result
                imgName = Convert.ToString(gProcCmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving item image: " + ex.Message);
            }

            return imgName;
        }


        public void ProcAddInventoryAdded(int p_item_id, int p_qty_added, double p_cost_per_item, int p_supplier_id, int p_staff_id)
        {
            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;

                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_add_inventory_added";
                gProcCmd.CommandType = CommandType.StoredProcedure;

                // Add parameters
                gProcCmd.Parameters.AddWithValue("@p_item_id", p_item_id);
                gProcCmd.Parameters.AddWithValue("@p_qty_added", p_qty_added);
                gProcCmd.Parameters.AddWithValue("@p_cost_per_item", p_cost_per_item);
                gProcCmd.Parameters.AddWithValue("@p_supplier_id", p_supplier_id);
                gProcCmd.Parameters.AddWithValue("@p_staff_id", p_staff_id);

                // Execute the stored procedure
                gProcCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private int FncGetItemId(string p_item_name, double p_price, double p_cost_per_item, string p_size, string p_type, string p_supplier_name)
        {
            int v_item_id = -1;

            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;

                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_get_item_id";
                gProcCmd.CommandType = CommandType.StoredProcedure;

                // Add parameters
                gProcCmd.Parameters.AddWithValue("@p_item_name", p_item_name);
                gProcCmd.Parameters.AddWithValue("@p_price", p_price);
                gProcCmd.Parameters.AddWithValue("@p_cost_per_item", p_cost_per_item);
                gProcCmd.Parameters.AddWithValue("@p_size", p_size);
                gProcCmd.Parameters.AddWithValue("@p_type", p_type);
                gProcCmd.Parameters.AddWithValue("@p_supplier_name", p_supplier_name);

                // Execute and get the result
                var result = gProcCmd.ExecuteScalar();

                // Check if result is not null and assign it to itemId
                if (result != null)
                {
                    v_item_id = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return v_item_id;
        }

        private void ProcRestockItem(int p_id, int p_qty)
        {
            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;

                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_restock_item";
                gProcCmd.CommandType = CommandType.StoredProcedure;

                // Add parameters
                gProcCmd.Parameters.AddWithValue("@p_id", p_id);
                gProcCmd.Parameters.AddWithValue("@p_qty", p_qty);

                // Execute the procedure
                gProcCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        public List<Item> FncGetItems()
        {
            List<Item> list = new List<Item>();

            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;

                this.sqlAdapter = new MySqlDataAdapter();
                this.datStoreMgr = new DataTable();

                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proce_select_all_items"; // Updated procedure name
                gProcCmd.CommandType = CommandType.StoredProcedure;
                this.sqlAdapter.SelectCommand = this.sqlCommand;
                this.datStoreMgr.Clear();
                this.sqlAdapter.Fill(this.datStoreMgr);

                if (this.datStoreMgr.Rows.Count > 0)
                {
                    DataTable dataTable = this.datStoreMgr;
                    int row = 0;
                    int totalRecords = dataTable.Rows.Count;

                    while (row < totalRecords)
                    {
                        int id = int.Parse(dataTable.Rows[row]["id"].ToString());
                        int itemCode = int.Parse(dataTable.Rows[row]["item_code"].ToString());
                        string itemName = dataTable.Rows[row]["item_name"].ToString();
                        double price = double.Parse(dataTable.Rows[row]["price"].ToString());
                        double costPerItem = double.Parse(dataTable.Rows[row]["cost_per_item"].ToString());
                        string size = dataTable.Rows[row]["size"].ToString();
                        string type = dataTable.Rows[row]["type"].ToString();
                        int currentStocks = int.Parse(dataTable.Rows[row]["current_stocks"].ToString());
                        int restockThreshold = int.Parse(dataTable.Rows[row]["restock_threshold"].ToString());
                        string supplierName = dataTable.Rows[row]["supplier_name"].ToString();
                        string imgLocation = dataTable.Rows[row]["img_name"].ToString();

                        // Use the constructor with the correct parameters
                        Item item = new Item(id, itemCode, itemName, price, costPerItem, size, type, currentStocks, restockThreshold, supplierName, imgLocation);
                        list.Add(item);

                        row++;
                    }
                }
                else
                {
                    MessageBox.Show("No data");
                }

                ClearData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return list;
        }

        public List<Item> FncGetFilteredItems(string pItemName)
        {
            List<Item> itemList = new List<Item>();

            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;

                this.sqlAdapter = new MySqlDataAdapter();
                this.datStoreMgr = new DataTable();

                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_select_filtered_items"; // Updated procedure name
                gProcCmd.CommandType = CommandType.StoredProcedure;

                // Add the parameter for item_name
                gProcCmd.Parameters.AddWithValue("p_item_name", pItemName);

                this.sqlAdapter.SelectCommand = gProcCmd;
                this.datStoreMgr.Clear();
                this.sqlAdapter.Fill(this.datStoreMgr);

                if (this.datStoreMgr.Rows.Count > 0)
                {
                    foreach (DataRow row in this.datStoreMgr.Rows)
                    {
                        int id = int.Parse(row["id"].ToString());
                        int itemCode = int.Parse(row["item_code"].ToString());
                        string itemName = row["item_name"].ToString();
                        double price = double.Parse(row["price"].ToString());
                        double costPerItem = double.Parse(row["cost_per_item"].ToString());
                        string size = row["size"].ToString();
                        string type = row["type"].ToString();
                        int currentStocks = int.Parse(row["current_stocks"].ToString());
                        int restockThreshold = int.Parse(row["restock_threshold"].ToString());
                        string supplierName = row["supplier_name"].ToString();
                        string imgLocation = row["img_name"].ToString();

                        // Create a new Item object using the constructor
                        Item item = new Item(id, itemCode, itemName, price, costPerItem, size, type, currentStocks, restockThreshold, supplierName, imgLocation);
                        itemList.Add(item);
                    }
                }
                else
                {
                    //MessageBox.Show("No data found.");
                }

                ClearData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return itemList;
        }

        public List<StoreOrder> FncGetOrders()
        {
            List<StoreOrder> orders = new List<StoreOrder>();

            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;

                this.sqlAdapter = new MySqlDataAdapter();
                this.datStoreMgr = new DataTable();

                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_select_order"; 
                gProcCmd.CommandType = CommandType.StoredProcedure;

                this.sqlAdapter.SelectCommand = gProcCmd;
                this.datStoreMgr.Clear();
                this.sqlAdapter.Fill(this.datStoreMgr);

                if (this.datStoreMgr.Rows.Count > 0)
                {
                    foreach (DataRow row in this.datStoreMgr.Rows)
                    {
                        int id = int.Parse(row["id"].ToString());
                        string invoiceNumber = row["invoice_number"].ToString();
                        double totalPrice = double.Parse(row["total_price"].ToString());
                        double subtotal = double.Parse(row["subtotal"].ToString());
                        double vat = double.Parse(row["vat"].ToString());
                        double taxRate = double.Parse(row["tax_rate"].ToString());
                        DateTime date = DateTime.Parse(row["date"].ToString());
                        string staffName = row["staff_name"].ToString();

                        // Create a new StoreOrder object using the constructor
                        StoreOrder order = new StoreOrder(id, invoiceNumber, totalPrice, subtotal, vat, taxRate, date, staffName);
                        orders.Add(order);
                    }
                }
                else
                {
                    // No data found
                    MessageBox.Show("No orders found.");
                }

                ClearData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return orders;
        }


        public int FncGetStaffId(string p_username, string p_password)
        {
            int v_staff_id = -1; // Default value if not found

            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;

                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_get_staff_id"; // Name of the stored procedure
                gProcCmd.CommandType = CommandType.StoredProcedure;

                // Add parameters
                gProcCmd.Parameters.AddWithValue("@p_username", p_username);
                gProcCmd.Parameters.AddWithValue("@p_password", p_password);

                // Execute and get the result
                var result = gProcCmd.ExecuteScalar();

                // Check if result is not null and assign it to v_staff_id
                if (result != null)
                {
                    v_staff_id = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving staff ID: " + ex.Message);
            }

            loggedStaffRole = FncGetStaffRoleById(v_staff_id);

            return v_staff_id; // Returns the staff ID or -1 if not found
        }



        public string[] FncGetDistinctSizes()
        {

            string[] sizes = null;

            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;

                this.sqlAdapter = new MySqlDataAdapter();
                this.datStoreMgr = new DataTable();

                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_select_distinct_sizes";
                gProcCmd.CommandType = CommandType.StoredProcedure;
                this.sqlAdapter.SelectCommand = this.sqlCommand;
                this.datStoreMgr.Clear();
                this.sqlAdapter.Fill(this.datStoreMgr);

                

                

                if (this.datStoreMgr.Rows.Count > 0)
                {

                    DataTable dataTable = this.datStoreMgr;
                    int row = 0;
                    int totalRecords = FncGetTotalRecords();
                    sizes = new string[totalRecords];

                    while (!(totalRecords - 1 < row))
                    {

                        sizes[row] = dataTable.Rows[row]["size"].ToString();

                        row++;
                    }

                }
                else
                {
                    MessageBox.Show("No data");
                }

                ClearData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return sizes;

        }

        private int FncGetLatestOrderId()
        {
            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;

                this.sqlAdapter = new MySqlDataAdapter();
                this.datStoreMgr = new DataTable();

                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_get_latest_order_id";
                gProcCmd.CommandType = CommandType.StoredProcedure;
                this.sqlAdapter.SelectCommand = this.sqlCommand;
                this.datStoreMgr.Clear();
                this.sqlAdapter.Fill(this.datStoreMgr);


                DataTable dataTable = this.datStoreMgr;

                ClearData();

                return int.Parse(dataTable.Rows[0]["id"].ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 1;
            }
        }

        private void ProcAddOrder()
        {
            MySqlCommand gProcCmd = this.sqlCommand;
            int v_tax_rate_id = FncGetLatestTaxRateId();

            try
            {
                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_add_order";
                gProcCmd.CommandType = CommandType.StoredProcedure;
                gProcCmd.Parameters.AddWithValue("@p_tax_rate_id", v_tax_rate_id);
                gProcCmd.Parameters.AddWithValue("@p_staff_id", V_Logged_Staff_Id);
                gProcCmd.ExecuteNonQuery();
                if (EnableDebugging) MessageBox.Show("Order saved successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ProcAddOrderProduct(int p_order_id, int p_product_id, int p_quantity, double p_cost_per_item, double p_price_per_item)
        {
            MySqlCommand gProcCmd = this.sqlCommand;

            try
            {
                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_add_order_product";
                gProcCmd.CommandType = CommandType.StoredProcedure;

                gProcCmd.Parameters.AddWithValue("@p_order_id", p_order_id);
                gProcCmd.Parameters.AddWithValue("@p_product_id", p_product_id);
                gProcCmd.Parameters.AddWithValue("@p_quantity", p_quantity);
                gProcCmd.Parameters.AddWithValue("@p_cost_per_item", p_cost_per_item);
                gProcCmd.Parameters.AddWithValue("@p_price_per_item", p_price_per_item);

                gProcCmd.ExecuteNonQuery();
                if (EnableDebugging) MessageBox.Show("Order saved successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private bool FncItemExists(string p_item_name, double p_price, double p_cost_per_item, string p_size, string p_type, string p_supplier_name)
        {
            bool v_exists = false;

            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;

                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_item_exists";
                gProcCmd.CommandType = CommandType.StoredProcedure;

                // Add parameters
                gProcCmd.Parameters.AddWithValue("@p_item_name", p_item_name);
                gProcCmd.Parameters.AddWithValue("@p_price", p_price);
                gProcCmd.Parameters.AddWithValue("@p_cost_per_item", p_cost_per_item);
                gProcCmd.Parameters.AddWithValue("@p_size", p_size);
                gProcCmd.Parameters.AddWithValue("@p_type", p_type);
                gProcCmd.Parameters.AddWithValue("@p_supplier_name", p_supplier_name);

                // Execute and get result
                int v_result = Convert.ToInt32(gProcCmd.ExecuteScalar());

                // If the count is greater than 0, the item exists
                v_exists = (v_result > 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return v_exists;
        }

        public List<InventoryLogEntry> FncGetInventoryLog()
        {
            List<InventoryLogEntry> log = new List<InventoryLogEntry>();

            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;

                this.sqlAdapter = new MySqlDataAdapter();
                this.datStoreMgr = new DataTable();

                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_select_inventory_log";
                gProcCmd.CommandType = CommandType.StoredProcedure;

                this.sqlAdapter.SelectCommand = gProcCmd;
                this.datStoreMgr.Clear();
                this.sqlAdapter.Fill(this.datStoreMgr);

                if (this.datStoreMgr.Rows.Count > 0)
                {
                    DataTable dataTable = this.datStoreMgr;
                    int row = 0;
                    int totalRecords = FncGetTotalRecords();

                    while (row < totalRecords)
                    {

                        string itemName = dataTable.Rows[row]["item_name"].ToString();
                        int quantity = int.Parse(dataTable.Rows[row]["quantity removed/added"].ToString());
                        DateTime date = DateTime.Parse(dataTable.Rows[row]["date"].ToString());
                        string supplierOrInvoice = dataTable.Rows[row]["supplier/invoice"].ToString();
                        string staffName = dataTable.Rows[row]["staff_name"].ToString();

                        InventoryLogEntry logEntry = new InventoryLogEntry(itemName, quantity, date, supplierOrInvoice, staffName);
                        log.Add(logEntry);

                        row++;
                    }
                }
                else
                {
                    //MessageBox.Show("No data");
                }

                ClearData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return log;
        }

        public void ProcAddItem(string p_item_name, string p_size, string p_type, double p_price, double p_cost_per_item, string p_img_name, string p_supplier, int p_restock_threshold)
        {
            int v_type_id;
            int v_supplier_id = -1;
            int v_item_id;

            v_type_id = FncGetTypeId(p_type);

            if(FncItemExists(p_item_name, p_price, p_cost_per_item, p_size, p_type, p_supplier))
            {
                MessageBox.Show("Item already exists\nCanceling new product");
                return;
            }

            if(!FncSupplierExists(p_supplier)) 
            {
                ProcAddSupplier(p_supplier);
            }

            v_supplier_id = FncGetSupplierId(p_supplier);

            ProcAddItemToInventory(p_item_name, p_size, v_type_id, p_cost_per_item, p_img_name, v_supplier_id, p_restock_threshold);

            v_item_id = FncGetLatestItemId();
            
            ProcAddProduct(v_item_id, p_price);

        }

        private void ProcAddItemToInventory(string p_item_name, string p_size, int p_type_id, double p_cost_per_item, string p_img_name, int p_supplier_id, int p_restock_threshold)
        {
            MySqlCommand gProcCmd = this.sqlCommand;

            try
            {
                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_add_item";
                gProcCmd.CommandType = CommandType.StoredProcedure;

                // Add parameters for the stored procedure
                gProcCmd.Parameters.AddWithValue("@p_item_name", p_item_name);
                gProcCmd.Parameters.AddWithValue("@p_size", p_size);
                gProcCmd.Parameters.AddWithValue("@p_type_id", p_type_id);
                gProcCmd.Parameters.AddWithValue("@p_cost_per_item", p_cost_per_item);
                gProcCmd.Parameters.AddWithValue("@p_img_name", p_img_name);
                gProcCmd.Parameters.AddWithValue("@p_supplier_id", p_supplier_id);
                gProcCmd.Parameters.AddWithValue("@p_restock_threshold", p_restock_threshold);

                // Execute the stored procedure
                gProcCmd.ExecuteNonQuery();

                if (EnableDebugging)
                    MessageBox.Show("Item added successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);  // Display the exception message for debugging
            }
        }

        private void ProcAddProduct(int p_inventory_id, double p_price)
        {
            MySqlCommand gProcCmd = this.sqlCommand;

            try
            {
                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_add_product";
                gProcCmd.CommandType = CommandType.StoredProcedure;

                // Add parameters for the stored procedure
                gProcCmd.Parameters.AddWithValue("@p_inventory_id", p_inventory_id);
                gProcCmd.Parameters.AddWithValue("@p_price", p_price);

                // Execute the stored procedure
                gProcCmd.ExecuteNonQuery();

                if (EnableDebugging)
                    MessageBox.Show("Product added successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);  // Display the exception message for debugging
            }
        }

        private void ProcAddSupplier(string p_supplier_name)
        {
            MySqlCommand gProcCmd = this.sqlCommand;

            try
            {
                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_add_supplier";
                gProcCmd.CommandType = CommandType.StoredProcedure;

                // Add parameter for supplier name
                gProcCmd.Parameters.AddWithValue("@p_supplier_name", p_supplier_name);

                // Execute the stored procedure
                gProcCmd.ExecuteNonQuery();

                if (EnableDebugging)
                    MessageBox.Show("Supplier added successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);  // Display the exception message for debugging
            }
        }

        private bool FncSupplierExists(string p_supplier_name)
        {
            MySqlCommand gProcCmd = this.sqlCommand;
            bool supplierExists = false;

            try
            {
                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_supplier_exists";
                gProcCmd.CommandType = CommandType.StoredProcedure;

                // Add input parameter for supplier name
                gProcCmd.Parameters.AddWithValue("@p_supplier_name", p_supplier_name);

                // Execute the command and retrieve the result
                object result = gProcCmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    int exists = Convert.ToInt32(result);
                    supplierExists = (exists == 1);  // If 1, supplier exists
                }

                if (EnableDebugging)
                    MessageBox.Show("Supplier exists: " + supplierExists);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);  // Display the exception message for debugging
            }

            return supplierExists;
        }


        private int FncGetSupplierId(string p_supplier_name)
        {
            MySqlCommand gProcCmd = this.sqlCommand;
            int supplierId = 0;

            try
            {
                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_get_supplier_id";
                gProcCmd.CommandType = CommandType.StoredProcedure;

                // Add parameter for supplier name
                gProcCmd.Parameters.AddWithValue("@p_supplier_name", p_supplier_name);

                // Execute the command and retrieve the result
                object result = gProcCmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    supplierId = Convert.ToInt32(result);
                }

                if (EnableDebugging)
                    MessageBox.Show("Supplier ID: " + supplierId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);  // Display the exception message for debugging
            }

            return supplierId;
        }

        private int FncGetTypeId(string p_type)
        {
            MySqlCommand gProcCmd = this.sqlCommand;
            int typeId = -1;  // Default value in case the type is not found

            try
            {
                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_get_type_id";
                gProcCmd.CommandType = CommandType.StoredProcedure;

                // Add input parameter for product type
                gProcCmd.Parameters.AddWithValue("@p_type", p_type);

                // Execute the stored procedure and get the result
                object result = gProcCmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    typeId = Convert.ToInt32(result);  // Assign the returned id to typeId
                }

                if (EnableDebugging)
                    MessageBox.Show("Type ID: " + typeId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);  // Display the exception message for debugging
            }

            return typeId;  // Return the retrieved type ID or -1 if not found
        }


        private int FncGetLatestItemId()
        {
            MySqlCommand gProcCmd = this.sqlCommand;
            int latestItemId = 0;

            try
            {
                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_get_latest_item_id";
                gProcCmd.CommandType = CommandType.StoredProcedure;

                // Execute the command and retrieve the result
                object result = gProcCmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    latestItemId = Convert.ToInt32(result);
                }

                if (EnableDebugging)
                    MessageBox.Show("Latest Item ID: " + latestItemId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);  // Display the exception message for debugging
            }

            return latestItemId;
        }

        private int FncGetLatestTaxRateId()
        {
            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;

                this.sqlAdapter = new MySqlDataAdapter();
                this.datStoreMgr = new DataTable();

                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_get_latest_tax_rate_id";
                gProcCmd.CommandType = CommandType.StoredProcedure;
                this.sqlAdapter.SelectCommand = this.sqlCommand;
                this.datStoreMgr.Clear();
                this.sqlAdapter.Fill(this.datStoreMgr);


                DataTable dataTable = this.datStoreMgr;

                ClearData();

                return int.Parse(dataTable.Rows[0]["id"].ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 1;
            }
        }

        private void ProcInitializeOrderTotal(int p_order_id)
        {
            MySqlCommand gProcCmd = this.sqlCommand;

            try
            {
                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_init_order_total";
                gProcCmd.CommandType = CommandType.StoredProcedure;

                gProcCmd.Parameters.AddWithValue("@p_id", p_order_id);

                gProcCmd.ExecuteNonQuery();
                if (EnableDebugging) MessageBox.Show("Order saved successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Order failed to update");
            }
        }

        public void ProcCheckout(List<CartItem> cartItems)
        {
            int v_order_id;

            ProcAddOrder();

            v_order_id = FncGetLatestOrderId();

            for(int i = 0; i < cartItems.Count; i++)
            {
                CartItem cartItem = cartItems[i];
                int v_item_code = cartItems[i].ItemCode;
                int v_product_id = cartItem.Id;
                int v_quantity = cartItem.Qty;
                double v_cost_per_item = cartItem.CostPerItem;
                double v_price_per_item = cartItem.Price;

                ProcAddOrderProduct(v_order_id, v_product_id, v_quantity, v_cost_per_item, v_price_per_item);
                ProcDecreaseItemStock(v_item_code, v_order_id, v_quantity, V_Logged_Staff_Id);
            }

            ProcInitializeOrderTotal(v_order_id);

            //TODO add init order proc
        }

        public void ProcDeleteItemById(int p_item_id)
        {
            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;

                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_delete_item_by_id"; // Name of the stored procedure
                gProcCmd.CommandType = CommandType.StoredProcedure;

                // Add parameters
                gProcCmd.Parameters.AddWithValue("@p_item_id", p_item_id);

                // Execute the stored procedure
                gProcCmd.ExecuteNonQuery();
                
                if(EnableDebugging)
                    MessageBox.Show("Item deleted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting item: " + ex.Message);
            }
        }


        public void ProcEditItemById(int p_item_id, string p_item_name, string p_size, string p_type, string p_img_name, int p_restock_threshold, double p_new_price)
        {

            int v_type_id = FncGetTypeId(p_type);

            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;

                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_edit_item_by_id"; // Name of the stored procedure
                gProcCmd.CommandType = CommandType.StoredProcedure;

                // Add parameters
                gProcCmd.Parameters.AddWithValue("@p_item_id", p_item_id);
                gProcCmd.Parameters.AddWithValue("@p_item_name", p_item_name);
                gProcCmd.Parameters.AddWithValue("@p_size", p_size);
                gProcCmd.Parameters.AddWithValue("@p_type_id", v_type_id);
                gProcCmd.Parameters.AddWithValue("@p_img_name", p_img_name);
                gProcCmd.Parameters.AddWithValue("@p_restock_threshold", p_restock_threshold);

                // Execute the stored procedure
                gProcCmd.ExecuteNonQuery();
                
                if(EnableDebugging)
                    MessageBox.Show("Item updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating item: " + ex.Message);
            }

            ProcEditProductPriceById(p_item_id, p_new_price);

        }


        private void ProcEditProductPriceById(int p_item_id, double p_new_price)
        {
            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;

                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_edit_product_price_by_id"; // Name of the stored procedure
                gProcCmd.CommandType = CommandType.StoredProcedure;

                // Add parameters
                gProcCmd.Parameters.AddWithValue("@p_item_id", p_item_id);
                gProcCmd.Parameters.AddWithValue("@p_new_price", p_new_price);

                // Execute the stored procedure
                gProcCmd.ExecuteNonQuery();

                if(EnableDebugging)
                    MessageBox.Show("Product price updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating product price: " + ex.Message);
            }
        }


        public void ProcDecreaseItemStock(int p_item_code, int p_qty_removed)
        {
            MySqlCommand gProcCmd = this.sqlCommand;

            try
            {
                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_add_inventory_removed";
                gProcCmd.CommandType = CommandType.StoredProcedure;

                gProcCmd.Parameters.AddWithValue("@p_item_code", p_item_code);
                gProcCmd.Parameters.AddWithValue("@p_order_id", null);
                gProcCmd.Parameters.AddWithValue("@p_qty_removed", p_qty_removed);
                gProcCmd.Parameters.AddWithValue("@p_staff_id", V_Logged_Staff_Id);

                gProcCmd.ExecuteNonQuery();

                if (EnableDebugging) MessageBox.Show("Item stock removed successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ProcDecreaseItemStock(int p_item_code, int p_order_id, int p_qty_removed, int staff_id)
        {
            MySqlCommand gProcCmd = this.sqlCommand;

            try
            {
                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_add_inventory_removed";
                gProcCmd.CommandType = CommandType.StoredProcedure;

                gProcCmd.Parameters.AddWithValue("@p_item_code", p_item_code);
                gProcCmd.Parameters.AddWithValue("@p_order_id", p_order_id);
                gProcCmd.Parameters.AddWithValue("@p_qty_removed", p_qty_removed);
                gProcCmd.Parameters.AddWithValue("@p_staff_id", staff_id);

                gProcCmd.ExecuteNonQuery();

                if (EnableDebugging) MessageBox.Show("Item removed successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ProcDecreaseItemStock(int p_item_id, int p_qty_removed, int staff_id)
        {
            MySqlCommand gProcCmd = this.sqlCommand;

            try
            {
                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_add_inventory_removed";
                gProcCmd.CommandType = CommandType.StoredProcedure;


                gProcCmd.ExecuteNonQuery();
                if (EnableDebugging) MessageBox.Show("Order saved successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public double FncGetLatestTaxRate()
        {
            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;

                this.sqlAdapter = new MySqlDataAdapter();
                this.datStoreMgr = new DataTable();

                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_get_latest_tax_rate";
                gProcCmd.CommandType = CommandType.StoredProcedure;
                this.sqlAdapter.SelectCommand = this.sqlCommand;
                this.datStoreMgr.Clear();
                this.sqlAdapter.Fill(this.datStoreMgr);


                DataTable dataTable = this.datStoreMgr;

                ClearData();

                return double.Parse(dataTable.Rows[0]["rate"].ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0.0;
            }
        }

        public double FncTotalSales()
        {
            
            
            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;

                this.sqlAdapter = new MySqlDataAdapter();
                this.datStoreMgr = new DataTable();


                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_get_total_sales";
                gProcCmd.CommandType = CommandType.StoredProcedure;
                this.sqlAdapter.SelectCommand = this.sqlCommand;
                this.datStoreMgr.Clear();
                this.sqlAdapter.Fill(this.datStoreMgr);


                DataTable dataTable = this.datStoreMgr;

                ClearData();





                return double.Parse(dataTable.Rows[0]["total_sales"].ToString()); 

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0.0;
            }
            
        }
        public int FncTotalOrder()
        {
           

            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;

                this.sqlAdapter = new MySqlDataAdapter();
                this.datStoreMgr = new DataTable();


                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_get_total_order";
                gProcCmd.CommandType = CommandType.StoredProcedure;
                this.sqlAdapter.SelectCommand = this.sqlCommand;
                this.datStoreMgr.Clear();
                this.sqlAdapter.Fill(this.datStoreMgr);


                DataTable dataTable = this.datStoreMgr;

                ClearData();
                    


                 

                return Int32.Parse(dataTable.Rows[0]["order_id"].ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
        public void productSold()
        {

        }
        public void totalCustomer()
        {

        }
       /* public void productSold()
        {

        }*/
        public void totalIncome()
        {

        }

        public void ProcAddCmbProductSoldItems(ComboBox cmb)
        {
            int rowCount = 0;
            int row = 0;

            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;

                this.sqlAdapter = new MySqlDataAdapter();
                this.datStoreMgr = new DataTable();

                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_get_item_name";
                gProcCmd.CommandType = CommandType.StoredProcedure;
                this.sqlAdapter.SelectCommand = this.sqlCommand;
                this.datStoreMgr.Clear();
                this.sqlAdapter.Fill(this.datStoreMgr);

                DataTable dataTable = this.datStoreMgr;
                if (dataTable.Rows.Count > 0)
                {
                     rowCount = dataTable.Rows.Count;
                    while (dataTable.Rows.Count - 1 < rowCount)
                    {

                        cmb.Items.Add(dataTable.Rows[row]["item_name"].ToString());
                         

                        row++;
                    }
                }
                
            }
            catch (Exception ex)
            {
               
            }
        }

        public void ProcGetProductSoldCount(string itemName, BunifuLabel lbl)
        {
            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;

                this.sqlAdapter = new MySqlDataAdapter();
                this.datStoreMgr = new DataTable();

                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_get_product_order_count";
                gProcCmd.CommandType = CommandType.StoredProcedure;
                this.sqlAdapter.SelectCommand = this.sqlCommand;
                gProcCmd.Parameters.AddWithValue("@p_name", itemName);
                this.datStoreMgr.Clear();
                this.sqlAdapter.Fill(this.datStoreMgr);

                DataTable dataTable = this.datStoreMgr;
                if (dataTable.Rows.Count <= 0)
                {
                    lbl.Text = "0";
                }
                else
                {
                    lbl.Text = dataTable.Rows[0]["orders"].ToString();
                }
               

            }
            catch (Exception ex)
            {
                
            }
        }

        public string[] FncGetProductTypes()
        {
            List<string> productTypes = new List<string>();

            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;

                gProcCmd.Parameters.Clear();

                gProcCmd.CommandText = "proc_select_product_type";
                gProcCmd.CommandType = CommandType.StoredProcedure;

                this.sqlAdapter = new MySqlDataAdapter(gProcCmd);
                this.datStoreMgr = new DataTable();

                this.sqlAdapter.Fill(this.datStoreMgr);

                if (this.datStoreMgr.Rows.Count > 0)
                {
                    foreach (DataRow row in this.datStoreMgr.Rows)
                    {
                        productTypes.Add(row["type"].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("No product types found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return productTypes.ToArray();
        }


        public void ProcGetProductSales(string itemName, BunifuLabel lbl)
        {
            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;

                this.sqlAdapter = new MySqlDataAdapter();
                this.datStoreMgr = new DataTable();

                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_get_product_order_count";
                gProcCmd.CommandType = CommandType.StoredProcedure;
                this.sqlAdapter.SelectCommand = this.sqlCommand;
                gProcCmd.Parameters.AddWithValue("@p_name", itemName);
                this.datStoreMgr.Clear();
                this.sqlAdapter.Fill(this.datStoreMgr);

                DataTable dataTable = this.datStoreMgr;
                if (dataTable.Rows.Count <= 0)
                {
                    lbl.Text = "0";
                }
                else
                {
                    string formatted = String.Format("{0:###,###.00}", dataTable.Rows[0]["product_sales"]);
                    lbl.Text = "₱" + formatted;
                }


            }
            catch (Exception ex)
            {

            }
        }

        public string FncGetCurrentSales()
        {
            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;

                this.sqlAdapter = new MySqlDataAdapter();
                this.datStoreMgr = new DataTable();

                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_get_current_sales";
                gProcCmd.CommandType = CommandType.StoredProcedure;
                this.sqlAdapter.SelectCommand = this.sqlCommand;
              
                this.datStoreMgr.Clear();
                this.sqlAdapter.Fill(this.datStoreMgr);

                DataTable dataTable = this.datStoreMgr;
                return dataTable.Rows[0]["sales"].ToString();
             

            }
            catch (Exception ex)
            {
                return "No sales available to report yet";
            }
        }

        public void ProcGetTotalCustomers(BunifuLabel lbl)
        {
            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;

                this.sqlAdapter = new MySqlDataAdapter();
                this.datStoreMgr = new DataTable();

                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_get_total_customers";
                gProcCmd.CommandType = CommandType.StoredProcedure;
                this.sqlAdapter.SelectCommand = this.sqlCommand;

                this.datStoreMgr.Clear();
                this.sqlAdapter.Fill(this.datStoreMgr);

                DataTable dataTable = this.datStoreMgr;
                if (dataTable.Rows.Count <= 0)
                {
                    lbl.Text = "0";
                }
                else
                {
                    lbl.Text = dataTable.Rows[0]["id"].ToString();
                }


            }
            catch (Exception ex)
            {

            }
        }

        public string FncGetCurrentCustomers()
        {
            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;

                this.sqlAdapter = new MySqlDataAdapter();
                this.datStoreMgr = new DataTable();

                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_get_current_customers";
                gProcCmd.CommandType = CommandType.StoredProcedure;
                this.sqlAdapter.SelectCommand = this.sqlCommand;

                this.datStoreMgr.Clear();
                this.sqlAdapter.Fill(this.datStoreMgr);

                DataTable dataTable = this.datStoreMgr;

                return dataTable.Rows[0]["customers"].ToString();

            }
            catch (Exception ex)
            {
                return "No customers available to report yet";
            }
        }

        public string FncGetTotalCustomers()
        {
            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;

                this.sqlAdapter = new MySqlDataAdapter();
                this.datStoreMgr = new DataTable();

                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_get_total_customers";
                gProcCmd.CommandType = CommandType.StoredProcedure;
                this.sqlAdapter.SelectCommand = this.sqlCommand;

                this.datStoreMgr.Clear();
                this.sqlAdapter.Fill(this.datStoreMgr);

                DataTable dataTable = this.datStoreMgr;
                if (dataTable.Rows.Count <= 0)
                {
                    return "0";
                }
                else
                {
                    return dataTable.Rows[0]["id"].ToString();
                }


            }
            catch (Exception ex)
            {
                return "0";
            }
        }
        public void ProcGetTopProducts(BunifuLabel lbl, int row, PictureBox icon)
        {
            
            try
            {
                string product_type;
                MySqlCommand gProcCmd = this.sqlCommand;

                this.sqlAdapter = new MySqlDataAdapter();
                this.datStoreMgr = new DataTable();

                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_get_top_products";
                gProcCmd.CommandType = CommandType.StoredProcedure;
                this.sqlAdapter.SelectCommand = this.sqlCommand;

                this.datStoreMgr.Clear();
                this.sqlAdapter.Fill(this.datStoreMgr);

                DataTable dataTable = this.datStoreMgr;


                lbl.Text = dataTable.Rows[row]["item_name"].ToString();
                product_type = dataTable.Rows[row]["type_id"].ToString();

                string appDirectory, imagePath;
                appDirectory = AppDomain.CurrentDomain.BaseDirectory;
                imagePath = Path.Combine(appDirectory, "Resources", "shoes2.png");
                icon.Image = Image.FromFile(imagePath);
                icon.SizeMode = PictureBoxSizeMode.Zoom;


                switch (product_type) 
                {
                    case "1":

                        imagePath = Path.Combine(appDirectory, "Resources", "shoes2.png");
                        icon.Image = Image.FromFile(imagePath);
                        icon.SizeMode = PictureBoxSizeMode.Zoom; 
                        break;
                    case "2":

                        imagePath = Path.Combine(appDirectory, "Resources", "jacket.png");
                        icon.Image = Image.FromFile(imagePath);
                        icon.SizeMode = PictureBoxSizeMode.Zoom;
                        break;
                    case "3":

                        imagePath = Path.Combine(appDirectory, "Resources", "shirt.png");
                        icon.Image = Image.FromFile(imagePath);
                        icon.SizeMode = PictureBoxSizeMode.Zoom;
                        break;
                    case "4":

                        imagePath = Path.Combine(appDirectory, "Resources", "shorts.png");
                        icon.Image = Image.FromFile(imagePath);
                        icon.SizeMode = PictureBoxSizeMode.Zoom;
                        break;
                    case "5":

                        imagePath = Path.Combine(appDirectory, "Resources", "cap.png");
                        icon.Image = Image.FromFile(imagePath);
                        icon.SizeMode = PictureBoxSizeMode.Zoom;
                        break;
                    case "6":

                        imagePath = Path.Combine(appDirectory, "Resources", "bag.png");
                        icon.Image = Image.FromFile(imagePath);
                        icon.SizeMode = PictureBoxSizeMode.Zoom;
                        break;
                    case "7":

                        imagePath = Path.Combine(appDirectory, "Resources", "sock.png");
                        icon.Image = Image.FromFile(imagePath);
                        icon.SizeMode = PictureBoxSizeMode.Zoom;
                        break;
                    case "8":

                        imagePath = Path.Combine(appDirectory, "Resources", "tanktop.png");
                        icon.Image = Image.FromFile(imagePath);
                        icon.SizeMode = PictureBoxSizeMode.Zoom;
                        break;
                    case "9":

                        imagePath = Path.Combine(appDirectory, "Resources", "accessories.png");
                        icon.Image = Image.FromFile(imagePath);
                        icon.SizeMode = PictureBoxSizeMode.Zoom;
                        break;
                    case "10":

                        imagePath = Path.Combine(appDirectory, "Resources", "pants.png");
                        icon.Image = Image.FromFile(imagePath);
                        icon.SizeMode = PictureBoxSizeMode.Zoom;
                        break;
                    case "11":

                        imagePath = Path.Combine(appDirectory, "Resources", "others.png");
                        icon.Image = Image.FromFile(imagePath);
                        icon.SizeMode = PictureBoxSizeMode.Zoom;
                        break;
                }



            }
            catch (Exception ex)
            {

            }
        }

        public string FncGetTopProducts(int row)
        {

            try
            {
                
                MySqlCommand gProcCmd = this.sqlCommand;

                this.sqlAdapter = new MySqlDataAdapter();
                this.datStoreMgr = new DataTable();

                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_get_top_products";
                gProcCmd.CommandType = CommandType.StoredProcedure;
                this.sqlAdapter.SelectCommand = this.sqlCommand;

                this.datStoreMgr.Clear();
                this.sqlAdapter.Fill(this.datStoreMgr);

                DataTable dataTable = this.datStoreMgr;


                return  dataTable.Rows[row]["item_name"].ToString();
                
            }
            catch
            {
                return "N/A";
            }
        }


                public string addDefaultProductToProductSoldSales()
        {
            MySqlCommand gProcCmd = this.sqlCommand;

            this.sqlAdapter = new MySqlDataAdapter();
            this.datStoreMgr = new DataTable();

            gProcCmd.Parameters.Clear();
            gProcCmd.CommandText = "proc_get_top_products";
            gProcCmd.CommandType = CommandType.StoredProcedure;
            this.sqlAdapter.SelectCommand = this.sqlCommand;

            this.datStoreMgr.Clear();
            this.sqlAdapter.Fill(this.datStoreMgr);

            DataTable dataTable = this.datStoreMgr;


            return dataTable.Rows[0]["item_name"].ToString();

        }

        public List<String> FncGetLast30DaysSales()
        {
            int rowCount = 0;
            int row = 0;
            
            List<string> sales = new List<string>();


            MySqlCommand gProcCmd = this.sqlCommand;

            this.sqlAdapter = new MySqlDataAdapter();
            this.datStoreMgr = new DataTable();

            gProcCmd.Parameters.Clear();
            gProcCmd.CommandText = "proc_get_last_30_days_sales";
            gProcCmd.CommandType = CommandType.StoredProcedure;
            this.sqlAdapter.SelectCommand = this.sqlCommand;

            this.datStoreMgr.Clear();
            this.sqlAdapter.Fill(this.datStoreMgr);

            DataTable dataTable = this.datStoreMgr;



            try
            {

                if (dataTable.Rows.Count > 0)
                {
                    rowCount = dataTable.Rows.Count;
                   
                    while (row < rowCount )
                    {


                        sales.Add(dataTable.Rows[row]["sales"].ToString());

                        row++;
                    }
                }
                return sales;
            }

            catch
            {
                
                return sales;
            }
            

        }

        public List<String> FncGetLast15DaysSales()
        {
            int rowCount = 0;
            int row = 0;

            List<string> sales = new List<string>();


            MySqlCommand gProcCmd = this.sqlCommand;

            this.sqlAdapter = new MySqlDataAdapter();
            this.datStoreMgr = new DataTable();

            gProcCmd.Parameters.Clear();
            gProcCmd.CommandText = "proc_get_last_15_days_sales";
            gProcCmd.CommandType = CommandType.StoredProcedure;
            this.sqlAdapter.SelectCommand = this.sqlCommand;

            this.datStoreMgr.Clear();
            this.sqlAdapter.Fill(this.datStoreMgr);

            DataTable dataTable = this.datStoreMgr;



            try
            {

                if (dataTable.Rows.Count > 0)
                {
                    rowCount = dataTable.Rows.Count;
                   
                    while (row < rowCount)
                    {


                        sales.Add(dataTable.Rows[row]["sales"].ToString());

                        row++;
                    }
                }
                return sales;
            }

            catch
            {

                return sales;
            }




        }

        public List<String> FncGetLast7DaysSales()
        {
            int rowCount = 0;
            int row = 0;

            List<string> sales = new List<string>();


            MySqlCommand gProcCmd = this.sqlCommand;

            this.sqlAdapter = new MySqlDataAdapter();
            this.datStoreMgr = new DataTable();

            gProcCmd.Parameters.Clear();
            gProcCmd.CommandText = "proc_get_last_7_days_sales";
            gProcCmd.CommandType = CommandType.StoredProcedure;
            this.sqlAdapter.SelectCommand = this.sqlCommand;

            this.datStoreMgr.Clear();
            this.sqlAdapter.Fill(this.datStoreMgr);

            DataTable dataTable = this.datStoreMgr;



            try
            {

                if (dataTable.Rows.Count > 0)
                {
                    rowCount = dataTable.Rows.Count;
                   
                    while (row < rowCount)
                    {


                        sales.Add(dataTable.Rows[row]["sales"].ToString());

                        row++;
                    }
                }
                return sales;
            }

            catch
            {

                return sales;
            }




        }



        public List<String> FncGetLast30Days()
        {
            int rowCount = 0;
            int row = 0;

            List<string> date = new List<string>();


            MySqlCommand gProcCmd = this.sqlCommand;

            this.sqlAdapter = new MySqlDataAdapter();
            this.datStoreMgr = new DataTable();

            gProcCmd.Parameters.Clear();
            gProcCmd.CommandText = "proc_get_last_30_days_sales";
            gProcCmd.CommandType = CommandType.StoredProcedure;
            this.sqlAdapter.SelectCommand = this.sqlCommand;

            this.datStoreMgr.Clear();
            this.sqlAdapter.Fill(this.datStoreMgr);

            DataTable dataTable = this.datStoreMgr;

            try
            {

                if (dataTable.Rows.Count > 0)
                {
                    rowCount = dataTable.Rows.Count;
                   
                    while (row < rowCount)
                    {


                        date.Add(dataTable.Rows[row]["formatDate"].ToString());

                        row++;
                    }
                }
                return date;
            }

            catch
            {

                return date;
            }

        }
        public List<String> FncGetLast15Days()
        {
            int rowCount = 0;
            int row = 0;

            List<string> date = new List<string>();


            MySqlCommand gProcCmd = this.sqlCommand;

            this.sqlAdapter = new MySqlDataAdapter();
            this.datStoreMgr = new DataTable();

            gProcCmd.Parameters.Clear();
            gProcCmd.CommandText = "proc_get_last_15_days_sales";
            gProcCmd.CommandType = CommandType.StoredProcedure;
            this.sqlAdapter.SelectCommand = this.sqlCommand;

            this.datStoreMgr.Clear();
            this.sqlAdapter.Fill(this.datStoreMgr);

            DataTable dataTable = this.datStoreMgr;

            try
            {

                if (dataTable.Rows.Count > 0)
                {
                    rowCount = dataTable.Rows.Count;
                   
                    while (row < rowCount)
                    {


                        date.Add(dataTable.Rows[row]["formatDate"].ToString());

                        row++;
                    }
                }
                return date;
            }

            catch
            {

                return date;
            }

        }

        public List<String> FncGetLast7Days()
        {
            int rowCount = 0;
            int row = 0;

            List<string> date = new List<string>();


            MySqlCommand gProcCmd = this.sqlCommand;

            this.sqlAdapter = new MySqlDataAdapter();
            this.datStoreMgr = new DataTable();

            gProcCmd.Parameters.Clear();
            gProcCmd.CommandText = "proc_get_last_7_days_sales";
            gProcCmd.CommandType = CommandType.StoredProcedure;
            this.sqlAdapter.SelectCommand = this.sqlCommand;

            this.datStoreMgr.Clear();
            this.sqlAdapter.Fill(this.datStoreMgr);

            DataTable dataTable = this.datStoreMgr;

            try
            {

                if (dataTable.Rows.Count > 0)
                {
                    rowCount = dataTable.Rows.Count;
                   
                    while (row < rowCount)
                    {


                        date.Add(dataTable.Rows[row]["formatDate"].ToString());

                        row++;
                    }
                }
                return date;
            }

            catch
            {

                return date;
            }

        }

        public string FncGetMonth()
        {
            MySqlCommand gProcCmd = this.sqlCommand;

            this.sqlAdapter = new MySqlDataAdapter();
            this.datStoreMgr = new DataTable();

            gProcCmd.Parameters.Clear();
            gProcCmd.CommandText = "proc_get_current_month";
            gProcCmd.CommandType = CommandType.StoredProcedure;
            this.sqlAdapter.SelectCommand = this.sqlCommand;

            this.datStoreMgr.Clear();
            this.sqlAdapter.Fill(this.datStoreMgr);

            DataTable dataTable = this.datStoreMgr;

           return dataTable.Rows[0]["CurrentMonth"].ToString();

        }

        public List<String> FncGetLast30DaysCustomers()
        {
            int rowCount = 0;
            int row = 0;

            List<string> customers = new List<string>();


            MySqlCommand gProcCmd = this.sqlCommand;

            this.sqlAdapter = new MySqlDataAdapter();
            this.datStoreMgr = new DataTable();

            gProcCmd.Parameters.Clear();
            gProcCmd.CommandText = "proc_get_last_30_days_sales";
            gProcCmd.CommandType = CommandType.StoredProcedure;
            this.sqlAdapter.SelectCommand = this.sqlCommand;

            this.datStoreMgr.Clear();
            this.sqlAdapter.Fill(this.datStoreMgr);

            DataTable dataTable = this.datStoreMgr;



            try
            {

                if (dataTable.Rows.Count > 0)
                {
                    rowCount = dataTable.Rows.Count;
                    
                    while (row < rowCount)
                    {


                        customers.Add(dataTable.Rows[row]["customers"].ToString());

                        row++;
                    }
                }
                return customers;
            }catch
            {

                return customers;
            }




        }

        public string FncGetStaffRoleById(int p_id)
        {
            string roleType = null;

            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;

                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_get_staff_role_by_id";
                gProcCmd.CommandType = CommandType.StoredProcedure;

                gProcCmd.Parameters.AddWithValue("@p_id", p_id);

                var result = gProcCmd.ExecuteScalar();

                if (result != null)
                {
                    roleType = result.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving staff role: " + ex.Message);
            }

            return roleType;
        }


            


        public List<String> FncGetLast15DaysCustomers()
        {
            int rowCount = 0;
            int row = 0;

            List<string> customers = new List<string>();


            MySqlCommand gProcCmd = this.sqlCommand;

            this.sqlAdapter = new MySqlDataAdapter();
            this.datStoreMgr = new DataTable();

            gProcCmd.Parameters.Clear();
            gProcCmd.CommandText = "proc_get_last_15_days_sales";
            gProcCmd.CommandType = CommandType.StoredProcedure;
            this.sqlAdapter.SelectCommand = this.sqlCommand;

            this.datStoreMgr.Clear();
            this.sqlAdapter.Fill(this.datStoreMgr);

            DataTable dataTable = this.datStoreMgr;



            try
            {

                if (dataTable.Rows.Count > 0)
                {
                    rowCount = dataTable.Rows.Count;
                    
                    while (row < rowCount)
                    {


                        customers.Add(dataTable.Rows[row]["customers"].ToString());

                        row++;
                    }
                }
                return customers;
            }

            catch
            {

                return customers;
            }




        }

        public List<String> FncGetLast7DaysCustomers()
        {
            int rowCount = 0;
            int row = 0;

            List<string> customers = new List<string>();


            MySqlCommand gProcCmd = this.sqlCommand;

            this.sqlAdapter = new MySqlDataAdapter();
            this.datStoreMgr = new DataTable();

            gProcCmd.Parameters.Clear();
            gProcCmd.CommandText = "proc_get_last_7_days_sales";
            gProcCmd.CommandType = CommandType.StoredProcedure;
            this.sqlAdapter.SelectCommand = this.sqlCommand;

            this.datStoreMgr.Clear();
            this.sqlAdapter.Fill(this.datStoreMgr);

            DataTable dataTable = this.datStoreMgr;



            try
            {

                if (dataTable.Rows.Count > 0)
                {
                    rowCount = dataTable.Rows.Count;
                    
                    while (row < rowCount)
                    {


                        customers.Add(dataTable.Rows[row]["customers"].ToString());

                        row++;
                    }
                }
                return customers;
            }

            catch
            {

                return customers;
            }

        }

        public void ProcGetSalesPercentageDifference(BunifuLabel lbl)
        {
            double percentage;
            try
            {

                MySqlCommand gProcCmd = this.sqlCommand;

                this.sqlAdapter = new MySqlDataAdapter();
                this.datStoreMgr = new DataTable();

                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_get_sales_today_yesterday_percentage_difference";
                gProcCmd.CommandType = CommandType.StoredProcedure;
                this.sqlAdapter.SelectCommand = this.sqlCommand;

                this.datStoreMgr.Clear();
                this.sqlAdapter.Fill(this.datStoreMgr);

                DataTable dataTable = this.datStoreMgr;


                percentage = double.Parse(dataTable.Rows[0]["Percentage_Change"].ToString());

                if (percentage > 0)
                {
                    lbl.ForeColor = Color.Green;
                    lbl.Text = (percentage + "% sales from yesterday");
                }
                else if (percentage < 0)
                {
                    lbl.ForeColor = Color.Red;
                    lbl.Text = (percentage + "% sales from yesterday");
                }
            }
            catch
            {
                lbl.ForeColor= Color.Green;
                lbl.Text = "0% sales from yesterday";
            }


        }

        public void ProcGetCustomersPercentageDifference(BunifuLabel lbl)
        {
            try
            {
                double percentage;

                MySqlCommand gProcCmd = this.sqlCommand;

                this.sqlAdapter = new MySqlDataAdapter();
                this.datStoreMgr = new DataTable();

                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_get_customers_today_yesterday_percentage_difference";
                gProcCmd.CommandType = CommandType.StoredProcedure;
                this.sqlAdapter.SelectCommand = this.sqlCommand;

                this.datStoreMgr.Clear();
                this.sqlAdapter.Fill(this.datStoreMgr);

                DataTable dataTable = this.datStoreMgr;

                percentage = double.Parse(dataTable.Rows[0]["Percentage_Change"].ToString());

                if (percentage > 0)
                {
                    lbl.ForeColor = Color.Green;
                    lbl.Text = (percentage + "% customers from yesterday");
                }
                else if (percentage < 0)
                {
                    lbl.ForeColor = Color.Red;
                    lbl.Text = (percentage + "% customers from yesterday");
                }
                else
                {
                    lbl.ForeColor = Color.Green;
                    lbl.Text = ("0% customers from yesterday");
                }
            
            }
            catch
            {
                lbl.ForeColor = Color.Green;
                lbl.Text = ("0% customers from yesterday");
            }


        }


    }
}
