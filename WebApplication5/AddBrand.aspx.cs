using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Data;

namespace WebApplication5
{
    public partial class AddBrand : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindBrandRepeater();
            }
        }

        private void BindBrandRepeater()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MedicineDB"].ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand("Select * from tblBrands",con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        rptrBrands.DataSource = dt;
                        rptrBrands.DataBind();
                    }
                }

            }
        }

        protected void btnAddBrand_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MedicineDB"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("insert into tblBrands(Name)values ('" + txtBrand.Text + "')", con);
                cmd.ExecuteNonQuery();

                Response.Write("<script>alert('Brand Added Successfully');</script>");
                txtBrand.Text = string.Empty;

                con.Close();
                //LblMsg.Text = "Registration Successfully Done";
                //LblMsg.ForeColor = System.Drawing.Color.Green;
                txtBrand.Focus();

            }
        }
    }
}