using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;

namespace TailorX
{
    public partial class Form1 : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source = WADEY; Initial Catalog = tailor_db; Integrated Security = True");

        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                

                string mobil_No, productType, c_Name, addr, dates, descrip, delivery_date, order_status;
                float price, t_price, t_paid, t_due;
                int quantity;


                mobil_No = mobNo.Text;
                productType = pro_type.Text;
                c_Name = custName.Text;
                addr = addrName.Text;
                dates = order_date.Text;
                descrip = description.Text;
                order_status = order_type.Text;
                delivery_date = d_date.Text;

                price = float.Parse(priceAmount.Text);
                quantity = int.Parse(quantity_no.Text);
                t_price = float.Parse(totalPrice.Text);
                t_paid = float.Parse(paid.Text);
                t_due = float.Parse(due.Text);



                if (mobNo.Text != "")
                {


                    string orderSt = "insert into tailor values('" + mobil_No + "','" + productType + "','" + c_Name + "','" + addr + "','" + dates + "','" + descrip + "','" + price + "','" + quantity + "','" + t_price + "','" + t_paid + "','" + t_due + "','" + delivery_date + "','" + order_status + "')";

                    SqlDataAdapter orderInsert = new SqlDataAdapter(orderSt, con);
                    DataTable dtOrder = new DataTable();
                    orderInsert.Fill(dtOrder);
                    MessageBox.Show("Order Complete SuccessFully");

                    mobNo.Text = string.Empty;
                    pro_type.Text = string.Empty;
                    custName.Text = string.Empty;
                    addrName.Text = string.Empty;
                    order_date.Text = string.Empty;
                    description.Text = string.Empty;
                    priceAmount.Text = "0.0";
                    quantity_no.Text = "0";
                    totalPrice.Text = "0.0";
                    paid.Text = "0.0";
                    due.Text = "0.0";
                    d_date.Text = string.Empty;
                    order_type.Text = string.Empty;
                }            
                else
                {

                    MessageBox.Show("Please Fill the Mobile Number ");
                }             
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void button6_Click(object sender, EventArgs e)
        {

            float price ;
            int quantity;
            price = float.Parse(priceAmount.Text);
            quantity = int.Parse(quantity_no.Text);
            totalPrice.Text = (price * quantity).ToString();
      
        }

        private void button7_Click(object sender, EventArgs e)
        {
            float  t_price, t_paid;
            t_price = float.Parse(totalPrice.Text);
            t_paid = float.Parse(paid.Text);
            due.Text = (t_price - t_paid).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                mobNo.Text = string.Empty;
                pro_type.Text = string.Empty;
                custName.Text = string.Empty;
                addrName.Text = string.Empty;
                order_date.Text = string.Empty;
                description.Text = string.Empty;
                priceAmount.Text = "0.0";
                quantity_no.Text = "0";
                totalPrice.Text = "0.0";
                paid.Text = "0.0";
                due.Text = "0.0";
                d_date.Text = string.Empty;
                order_type.Text = string.Empty;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           

        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                
                con.Open();
                string str = "select * from tailor where mobile_No = '" + mobNo.Text + "' and  product_type = '" + pro_type.Text + "' ";
                SqlCommand cmd = new SqlCommand(str, con);

                SqlDataReader dr = cmd.ExecuteReader();

                

                if (dr.Read())
                {
                    custName.Text = dr[2].ToString();
                    addrName.Text = dr[3].ToString();
                    order_date.Text = dr[4].ToString();
                    description.Text = dr[5].ToString();
                    priceAmount.Text = dr[6].ToString();
                    quantity_no.Text = dr[7].ToString();
                    totalPrice.Text = dr[8].ToString();
                    paid.Text = dr[9].ToString();
                    due.Text = dr[10].ToString();
                    d_date.Text = dr[11].ToString();
                    order_type.Text = dr[12].ToString();

                    
                }
                else
                {
                   
                }
                
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                string mobil_No, productType, c_Name, addr, dates, descrip, delivery_date, order_status;
                float price, t_price, t_paid, t_due;
                int quantity;

                // Initialize Variable 
                
                mobil_No = mobNo.Text;
                productType = pro_type.Text;
                c_Name = custName.Text;
                addr = addrName.Text;
                dates = order_date.Text;
                descrip = description.Text;
                order_status = order_type.Text;
                delivery_date = d_date.Text;
                price = float.Parse(priceAmount.Text);
                quantity = int.Parse(quantity_no.Text);
                t_price = float.Parse(totalPrice.Text);
                t_paid = float.Parse(paid.Text);
                t_due = float.Parse(due.Text);

                if (mobNo.Text != "")
                {
                    string orderSt = "update tailor set mobile_no='" + mobil_No + "',product_type='" + productType + "',customerName='" + c_Name + "',addr='" + addr + "',order_date='" + dates + "',description='" + descrip + "',price='" + price + "',quantity='" + quantity + "',total_price='" + t_price + "',paid='" + t_paid + "',due='" + t_due + "',delivery_date='" + delivery_date + "',order_process='" + order_status + "'" +
                        "where mobile_No = '" + mobNo.Text + "' and  product_type = '" + pro_type.Text + "' ";

                    SqlDataAdapter orderInsert = new SqlDataAdapter(orderSt, con);
                    DataTable dtOrder = new DataTable();
                    orderInsert.Fill(dtOrder);
                    MessageBox.Show("Order Update SuccessFully");

                    // Initialize variable

                    mobNo.Text = string.Empty;
                    pro_type.Text = string.Empty;
                    custName.Text = string.Empty;
                    addrName.Text = string.Empty;
                    order_date.Text = string.Empty;
                    description.Text = string.Empty;
                    priceAmount.Text = "0.0";
                    quantity_no.Text = "0";
                    totalPrice.Text = "0.0";
                    paid.Text = "0.0";
                    due.Text = "0.0";
                    d_date.Text = string.Empty;
                    order_type.Text = string.Empty;

                }
                else
                {

                    MessageBox.Show("Please Fill the Mobile Number ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void pro_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Close();

            try
            {
                con.Open();
                string str = "select * from tailor where mobile_No = '" + mobNo.Text + "' and  product_type = '" + pro_type.Text + "' ";
                SqlCommand cmd = new SqlCommand(str, con);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read() && dr[1].ToString() !="")
                {
                    custName.Text = dr[2].ToString();
                    addrName.Text = dr[3].ToString();
                    order_date.Text = dr[4].ToString();
                    description.Text = dr[5].ToString();
                    priceAmount.Text = dr[6].ToString();
                    quantity_no.Text = dr[7].ToString();
                    totalPrice.Text = dr[8].ToString();
                    paid.Text = dr[9].ToString();
                    due.Text = dr[10].ToString();
                    d_date.Text = dr[11].ToString();
                    order_type.Text = dr[12].ToString();

                }
                else
                {
                   // MessageBox.Show("Porduct Order Could not found !!!");

                    custName.Text = string.Empty;
                    addrName.Text = string.Empty;
                    order_date.Text = string.Empty;
                    description.Text = string.Empty;
                    priceAmount.Text = "0.0";
                    quantity_no.Text = "0";
                    totalPrice.Text = "0.0";
                    paid.Text = "0.0";
                    due.Text = "0.0";
                    d_date.Text = string.Empty;
                    order_type.Text = string.Empty;
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void quantity_no_ValueChanged(object sender, EventArgs e)
        {
            try
            {              
                float price;
                int quantity;
                price = float.Parse(priceAmount.Text);
                quantity = int.Parse(quantity_no.Text);
                totalPrice.Text = (price * quantity).ToString();               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void paid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                float t_price, t_paid;
                t_price = float.Parse(totalPrice.Text);
                t_paid = float.Parse(paid.Text);
                due.Text = (t_price - t_paid).ToString();

                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mobNo_TextChanged(object sender, EventArgs e)
        {
            con.Close();
            try
            {
                
                    con.Open();

                    string str = "select * from tailor where mobile_No = '" + mobNo.Text + "' ";
                    SqlCommand cmd = new SqlCommand(str, con);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read() && mobNo.Text.Length > 10)
                    {

                   /* if ( )
                    {*/

                        pro_type.Text = dr[1].ToString();
                    //}
                    
                    }
                else
                {
                    pro_type.Text = string.Empty;
                    custName.Text = string.Empty;
                    addrName.Text = string.Empty;
                    order_date.Text = string.Empty;
                    description.Text = string.Empty;
                    priceAmount.Text = "0.0";
                    quantity_no.Text = "0";
                    totalPrice.Text = "0.0";
                    paid.Text = "0.0";
                    due.Text = "0.0";
                    d_date.Text = string.Empty;
                    order_type.Text = string.Empty;
                }

                dr.Close();
                con.Close();
              
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float price;
                int quantity;
                price = float.Parse(priceAmount.Text);
                quantity = int.Parse(quantity_no.Text);
                totalPrice.Text = (price * quantity).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //con.Close();
            try
            {
                // Delete row code 

                con.Open();
                string str = "delete from tailor where mobile_No = '" + mobNo.Text + "' and  product_type = '" + pro_type.Text + "' ";
                SqlCommand cmd = new SqlCommand(str, con);

                SqlDataReader dr = cmd.ExecuteReader();

                if (mobNo.Text != "")
                {

                    MessageBox.Show("Order Delete Successfully");

                    //Blank or empty field code 

                    mobNo.Text = string.Empty;
                    pro_type.Text = string.Empty;
                    custName.Text = string.Empty;
                    addrName.Text = string.Empty;
                    order_date.Text = string.Empty;
                    description.Text = string.Empty;
                    priceAmount.Text = "0.0";
                    quantity_no.Text = "0";
                    totalPrice.Text = "0.0";
                    paid.Text = "0.0";
                    due.Text = "0.0";
                    d_date.Text = string.Empty;
                    order_type.Text = string.Empty;

                }
                else
                {
                    MessageBox.Show("Error : Mobile Number Field is Empty !!!");
                }


                dr.Close();
                con.Close();
            }

            
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            con.Close();
        }

        private void checkOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check incomeplete orders 
            
            checkOrders chkOrders = new checkOrders();
            chkOrders.Show();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Close();
            try
            {

                con.Open();

                // Show Incomplete Orders 

                string inOrders = "select product_type,customerName,price,quantity,paid,due,total_price from tailor where mobile_no = '" + mobNo.Text + "' and  product_type = '" + pro_type.Text + "' ";

                List<printOrderDetails> list = con.Query<printOrderDetails>(inOrders, CommandType.Text).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
