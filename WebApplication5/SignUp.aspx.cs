using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.HtmlControls;

namespace WebApplication5

{
    

    public partial class SignUp : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtsignup_Click(object sender, EventArgs e)
        {
            if (isformvalid())
            {
               
                
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MedicineDB"].ConnectionString))
                    {
                        con.Open();
                
                SqlCommand cmd = new SqlCommand("insert into Users(Username,Password,Email,Name,UserType)values ('" + txtUname.Text + "','" + txtPass.Text + "','" + txtEmail.Text + "','" + txtName.Text + "', 'User')", con);
                        cmd.ExecuteNonQuery();

                        Response.Write("<script>alert('Registration Successfully Done');</script>");
                    clr();
                        con.Close();
                    LblMsg.Text = "Registration Successfully Done";
                    LblMsg.ForeColor = System.Drawing.Color.Green;
                    
                    }
                Response.Redirect("~/SignIn.aspx");

            }

            else
            {
                Response.Write("<script>alert('Registration Failed');</script>");
                LblMsg.Text = "All Fields Are Mandatory";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

private bool isformvalid()
        {
            
            
                if (txtUname.Text == " ")
                {
                    Response.Write("<script>alert('Username not valid');</script>");
                txtUname.Focus();
                    return false;
                }
                else if (txtPass.Text == "")
                {
                    Response.Write("<script>alert('Password not valid');</script>");
                txtPass.Focus();
                    return false;
                }
                else if (txtPass.Text != txtCPass.Text)
                {
                    Response.Write("<script>alert('Confirm password not valid');</script>");
                txtCPass.Focus();
                    return false;
                }
                else if (txtEmail.Text == "")
                {
                    Response.Write("<script>alert('Email not valid');</script>");
                txtEmail.Focus();
                    return false;
                }
                else if (txtName.Text == "")
                {
                    Response.Write("<script>alert('Name not valid');</script>");
                txtName.Focus();
                    return false;
                }

                return true;
            } 
        
        private void clr()
        {
            txtName.Text = string.Empty;
            txtPass.Text = string.Empty;
            txtUname.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtCPass.Text = string.Empty;
        }
        

    }
}



