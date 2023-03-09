using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Net;

public partial class user_cretion : System.Web.UI.Page
{
    public static int rowindex = 0;
    public static string inactive = "";
    public static string  sattime="";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"].ToString() == null)
        {
            Response.Redirect("login.aspx");
        }
        Label3.Text = " Welcome :: " + Session["user"].ToString();
        Label4.Text = " Login Time :: " + Session["login_time"].ToString();
        //Label4.Text = "Login Time :: " + Session["Time"].ToString();
        
        if (!IsPostBack)
        {
            txtcontactno.Attributes.Add("onkeydown", "return blockChar(event);");
            btn_refresh_Click(sender, e);
            loadxmldata();
        }

    }
    public void loadxmldata()
    {
        DataSet mydata = new DataSet();
        mydata.ReadXml(Server.MapPath(@"app_data/sap_login.xml"));

        if (mydata.Tables.Count > 0)
        {
            this.GridView1.DataSource = mydata;
            this.GridView1.DataBind();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if ((GridView1).Rows[i].Cells[3].Text == "admin")
                {
                    (GridView1).Rows[i].Visible = false;
                }
            }
        }
    
    }
    

    protected void btn_save_Click(object sender, EventArgs e)
    {
        if (txtempname.Text=="")
        {
            Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('Please, enter the Employee Name!!')</script>");
            txtempname.BackColor = System.Drawing.Color.LightYellow;
            txtempname.Focus();
            return;
        }
        if (txtempcode.Text=="")
        {
            Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('Please, enter the Employee Code!!')</script>");
            txtempcode.BackColor = System.Drawing.Color.LightYellow;
            txtempcode.Focus();
            return;
        }
        if (txtloginid.Text=="")
        {
            Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('Please, enter your Login ID!!')</script>");
            txtloginid.BackColor = System.Drawing.Color.LightYellow;
            txtloginid.Focus();
            return;
        }
        if (txtcontactno.Text=="")
        {
            Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('Contact No. must be of 10 Digits!!')</script>");
            txtcontactno.BackColor = System.Drawing.Color.LightYellow;
            txtcontactno.Focus();
            return;
        }
        if (ddl_module.SelectedItem.Text == "-Select-")
        {
            Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('Please, Select the Folder Name!!')</script>");
            ddl_module.BackColor = System.Drawing.Color.LightYellow;
            ddl_module.Focus();
            return;
        }
        if (ddl_level.SelectedItem.Text == "-Select-")
        {
            Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('Please, Select the User Level!!')</script>");
            ddl_level.BackColor = System.Drawing.Color.LightYellow;
            ddl_level.Focus();
            return;
        }
        
        try
        {
            XmlDocument sap = new XmlDocument();
            sap.Load(Server.MapPath(@"app_data/sap_login.xml"));
            XmlElement new_user = sap.CreateElement("new_user");
            XmlElement USER_ID = sap.CreateElement("USER_ID");
            XmlElement USER_NAME = sap.CreateElement("USER_NAME");
            XmlElement PASSWORD = sap.CreateElement("PASSWORD");
            XmlElement USER_LEVEL = sap.CreateElement("USER_LEVEL");
            XmlElement EMP_NO = sap.CreateElement("EMP_NO");
            XmlElement ISACTIVE = sap.CreateElement("ISACTIVE");
            XmlElement ENTRY_DATE = sap.CreateElement("ENTRY_DATE");
            XmlElement LAST_LOGIN_DATE = sap.CreateElement("LAST_LOGIN_DATE");
            XmlElement CREATED_BY = sap.CreateElement("CREATED_BY");
            XmlElement ISLOGGED = sap.CreateElement("ISLOGGED");
            XmlElement LAST_LOGIN_IP = sap.CreateElement("LAST_LOGIN_IP");
            XmlElement MODULE = sap.CreateElement("MODULE");
            XmlElement EMAIL_ID = sap.CreateElement("EMAIL_ID");
            XmlElement CONTACT_NO = sap.CreateElement("CONTACT_NO");

            USER_ID.InnerText = this.txtloginid.Text.ToString();
            USER_NAME.InnerText = this.txtempname.Text.ToString();
            PASSWORD.InnerText = "12345678";
            USER_LEVEL.InnerText = this.ddl_level.SelectedValue.ToString();
            EMP_NO.InnerText = this.txtempcode.Text.ToString();
            ISACTIVE.InnerText = "N";
            ENTRY_DATE.InnerText = System.DateTime.Now.ToShortDateString();
            LAST_LOGIN_DATE.InnerText = "";
            CREATED_BY.InnerText = "";
            ISLOGGED.InnerText = "N";
            MODULE.InnerText = this.ddl_module.SelectedItem.Text.ToString();
            EMAIL_ID.InnerText = this.txtmailid.Text.ToString();
            CONTACT_NO.InnerText = this.txtcontactno.Text.ToString();

            new_user.AppendChild(USER_ID);
            new_user.AppendChild(USER_NAME);
            new_user.AppendChild(PASSWORD);
            new_user.AppendChild(USER_LEVEL);
            new_user.AppendChild(EMP_NO);
            new_user.AppendChild(ISACTIVE);
            new_user.AppendChild(ENTRY_DATE);
            new_user.AppendChild(LAST_LOGIN_DATE);
            new_user.AppendChild(CREATED_BY);
            new_user.AppendChild(ISLOGGED);
            new_user.AppendChild(MODULE);
            new_user.AppendChild(EMAIL_ID);
            new_user.AppendChild(CONTACT_NO);

            sap.DocumentElement.AppendChild(new_user);
            sap.Save(Server.MapPath(@"app_data/sap_login.xml"));
            Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('User Created Successfully !!')</script>");
        }
        catch
        {
            Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('User not Created, Error in connecting with Database !!')</script>");
        }
        finally
        {
            loadxmldata();
            btn_refresh_Click(sender, e);
        }
    }
    protected void btn_refresh_Click(object sender, EventArgs e)
    {
        txtempname.Text = "";
        txtempcode.Text = "";
        txtloginid.Text = "";
        ddl_level.SelectedIndex=0;
        txtmailid.Text = "";
        txtcontactno.Text = "";
        ddl_module.SelectedIndex = 0;
        //RangeValidator1.Visible = false;
        btn_save.Enabled = true;
        btn_update.Enabled = false;
        btn_block.Text = "Block User";
        btn_block.Enabled = false;
        btn_pwd.Enabled = false;

    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "editing")
        {
            btn_block.Enabled = true;
            btn_update.Enabled = true;
            btn_save.Enabled = false;
            btn_pwd.Enabled = true;
            rowindex = int.Parse(e.CommandArgument.ToString());
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(Server.MapPath(@"App_Data\sap_login.xml"));
            XmlNodeList xmlnodelist = xmldoc.DocumentElement.ChildNodes;
            XmlNode xmlnode = xmlnodelist.Item(int.Parse(e.CommandArgument.ToString()));
            this.txtloginid.Text = xmlnode["USER_ID"].InnerText;
            this.txtempname.Text= xmlnode["USER_NAME"].InnerText;
            this.ddl_level.SelectedIndex = ddl_level.Items.IndexOf(ddl_level.Items.FindByText(xmlnode["USER_LEVEL"].InnerText));
            this.txtempcode.Text = xmlnode["EMP_NO"].InnerText;
            this.ddl_module.SelectedIndex = ddl_module.Items.IndexOf(ddl_module.Items.FindByText(xmlnode["MODULE"].InnerText));
            this.txtmailid.Text = xmlnode["EMAIL_ID"].InnerText;
            this.txtcontactno.Text = xmlnode["CONTACT_NO"].InnerText;
            inactive = xmlnode["ISACTIVE"].InnerText;
            if (inactive == "Y")
            {
                btn_block.Text = "Unblock User";
            }
            else
            {
                btn_block.Text = "Block User";
            }  
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btn_update_Click(object sender, EventArgs e)
    {
        try
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(Server.MapPath(@"App_Data\sap_login.xml"));
            XmlNode xmlnode = xmldoc.DocumentElement.ChildNodes.Item(rowindex);
            xmlnode["USER_ID"].InnerText = this.txtloginid.Text.ToString();
            xmlnode["USER_NAME"].InnerText = this.txtempname.Text.ToString();
            xmlnode["USER_LEVEL"].InnerText = this.ddl_level.SelectedValue.ToString();
            xmlnode["EMP_NO"].InnerText = this.txtempcode.Text.ToString();
            xmlnode["MODULE"].InnerText = this.ddl_module.SelectedItem.Text.ToString();
            xmlnode["EMAIL_ID"].InnerText = this.txtmailid.Text.ToString();
            xmlnode["CONTACT_NO"].InnerText = this.txtcontactno.Text.ToString();
            xmldoc.Save(Server.MapPath(@"App_Data\sap_login.xml"));
            Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('User Updated Successfully !!')</script>");
        }
        catch(Exception ex)
        {
            Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('User not Updated, Error in connecting with Database !!')</script>");
        }
        finally
        {
            loadxmldata();
            btn_refresh_Click(sender, e);
        }
    }
    protected void btn_block_Click(object sender, EventArgs e)
    {
        try
        {
            string msg = "";
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(Server.MapPath(@"App_Data\sap_login.xml"));
            XmlNode xmlnode = xmldoc.DocumentElement.ChildNodes.Item(rowindex);
            if (inactive == "Y")
            {
                xmlnode["ISACTIVE"].InnerText = "N";
                msg = "User Unblocked Successfully!!";
            }
            else
            {
                xmlnode["ISACTIVE"].InnerText = "Y";
                msg = "User Blocked Successfully!!";
            }
            xmldoc.Save(Server.MapPath(@"App_Data\sap_login.xml"));
            Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('" + msg + "')</script>");
        }
        catch
        {
            Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('Error in Connection with Database !!!')</script>");
        }
        finally
        {
            loadxmldata();
            btn_refresh_Click(sender, e);
        }
    }
    protected void btn_pwd_Click(object sender, EventArgs e)
    {
        try
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(Server.MapPath(@"App_Data\sap_login.xml"));
            XmlNode xmlnode = xmldoc.DocumentElement.ChildNodes.Item(rowindex);
            xmlnode["PASSWORD"].InnerText = "12345678";
            xmldoc.Save(Server.MapPath(@"App_Data\sap_login.xml"));
            Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('Password Reset Successfully !!')</script>");
        }
        catch
        {
            Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('Cannot Reset Password, Error in Connection with Database!!')</script>");
        }
        finally
        {
            loadxmldata();
            btn_refresh_Click(sender, e);
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Default3.aspx");
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
    }
}
