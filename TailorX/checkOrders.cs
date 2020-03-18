using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using System.Configuration;

namespace TailorX
{
    public partial class checkOrders : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = WADEY; Initial Catalog = tailor_db; Integrated Security = True");
        public checkOrders()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            con.Close();
            try
            {

                con.Open();
              
                // Show Incomplete Orders 

                string inOrders = "select mobile_no,product_type,customerName,order_date,delivery_date,total_price,paid,due,order_process from tailor where order_date between '" + fromDate.Text + "' and  '" + toDate.Text + "' ";
               
                showOrderListBindingSource.DataSource = con.Query<showOrderList>(inOrders,  CommandType.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Back button press 
            this.Close();
            /*Form1 showForm = new Form1();
            showForm.Show();*/
        }

      
    }
}
