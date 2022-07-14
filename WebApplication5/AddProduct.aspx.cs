using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;

namespace WebApplication5
{
    public partial class AddProduct : System.Web.UI.Page
    {
        public static String CS = ConfigurationManager.ConnectionStrings["MedicineDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //when page first time run then this code will execute
                BindBrand();
                BindCategory();
                BindGender();
                //BindrptrSize();

                ddlSubCategory.Enabled = false;
                ddlGender.Enabled = false;
            }
        }

        private void BindGender()
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from tblGender with(nolock)", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    ddlGender.DataSource = dt;
                    ddlGender.DataTextField = "GenderName";
                    ddlGender.DataValueField = "GenderID";
                    ddlGender.DataBind();
                    ddlGender.Items.Insert(0, new ListItem("-Select-", "0"));
                }

            }
        }

        private void BindCategory()
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from tblCategory", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    ddlCategory.DataSource = dt;
                    ddlCategory.DataTextField = "CatName";
                    ddlCategory.DataValueField = "CatID";
                    ddlCategory.DataBind();
                    ddlCategory.Items.Insert(0, new ListItem("-Select-", "0"));
                }

            }
        }

        private void BindBrand()
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from tblBrands", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    ddlBrand.DataSource = dt;
                    ddlBrand.DataTextField = "Name";
                    ddlBrand.DataValueField = "BrandID";
                    ddlBrand.DataBind();
                    ddlBrand.Items.Insert(0, new ListItem("-Select-", "0"));
                }

            }

        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertProducts", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PName",txtProductName.Text);
                cmd.Parameters.AddWithValue("@PPrice",txtprice.Text);
                cmd.Parameters.AddWithValue("@PSellPrice", txtsellPrice.Text);
                cmd.Parameters.AddWithValue("@PBrandID", ddlBrand.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@PCategoryId", ddlCategory.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@PSubCatId", ddlSubCategory.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@PGender", ddlGender.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@PDescription", txtDescription.Text);
                cmd.Parameters.AddWithValue("@PProductDetails", txtPDetail.Text);
                cmd.Parameters.AddWithValue("@PMaterialCare", txtMatCare.Text);
                if(chFD.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@FreeDelivery", 1.ToString());
                }
                else
                {
                    cmd.Parameters.AddWithValue("@FreeDelivery", 0.ToString());
                }

                if (ch07Ret.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@07DayRet", 1.ToString());
                }
                else
                {
                    cmd.Parameters.AddWithValue("@07DayRet", 0.ToString());
                }

                if (chCOD.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@COD", 1.ToString());
                }
                else
                {
                    cmd.Parameters.AddWithValue("@COD", 0.ToString());
                }

                con.Open();
                Int64 PID = Convert.ToInt64(cmd.ExecuteScalar());

                //insert size quantity
                for(int i=0; i<cblSize.Items.Count;i++)
                {
                    if (cblSize.Items[i].Selected == true)
                    {
                        Int64 SizeID = Convert.ToInt64(cblSize.Items[i].Value);
                        int Quantity = Convert.ToInt32(txtQuantity.Text);

                        SqlCommand cmd2 = new SqlCommand("insert into tblProductSizeQuantity values('" + PID + "','" + SizeID + "', '" + Quantity + "')", con);
                        cmd2.ExecuteNonQuery();
                        
                    }
                }

                //insert and upload image
                if (fuImg01.HasFile)
                {   

                    string SavePath= Server.MapPath("~/Images/ProductImages/") + PID;
                    if (!Directory.Exists(SavePath ))
                    {
                        Directory.CreateDirectory(SavePath);
                    }
                    string Extension = Path.GetExtension(fuImg01.PostedFile.FileName);
                    fuImg01.SaveAs(SavePath + "\\" + txtProductName.Text.ToString().Trim() + "01");

                    SqlCommand cmd3 = new SqlCommand("insert into tblProductImages values('" + PID + "','" + txtProductName.Text.ToString().Trim() + "01"+ "', '" + Extension + "')", con);
                    cmd3.ExecuteNonQuery();
                }
 

                
            }
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSubCategory.Enabled = true;
            int MainCategoryID = Convert.ToInt32(ddlCategory.SelectedItem.Value);

            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from tblSubCategory where MainCatID='" + ddlCategory.SelectedItem.Value + "'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    ddlSubCategory.DataSource = dt;
                    ddlSubCategory.DataTextField = "SubCatName";
                    ddlSubCategory.DataValueField = "SubCatID";
                    ddlSubCategory.DataBind();
                    ddlSubCategory.Items.Insert(0, new ListItem("-Select-", "0"));
                }

            }
        }

        protected void ddlGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from tblSizes where BrandId='" + ddlBrand.SelectedItem.Value + "' and CategoryID='" + ddlCategory.SelectedItem.Value + "' and SubCategoryId='" + ddlSubCategory.SelectedItem.Value + "' and GenderId='" + ddlGender.SelectedItem.Value + "' ", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    cblSize.DataSource = dt;
                    cblSize.DataTextField = "SizeName";
                    cblSize.DataValueField = "SizeID";
                    cblSize.DataBind();
                    
                }

            }
        }

        protected void ddlSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSubCategory.SelectedIndex != 0)
            {
                ddlGender.Enabled = true;
            }
            else
            {
                ddlGender.Enabled = false;
            }
        }
    }
}