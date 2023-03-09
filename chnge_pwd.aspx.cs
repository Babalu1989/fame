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

public partial class chnge_pwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"].ToString() == null)
        {
            Response.Redirect("login.aspx");
        }
        txt_old.Focus();
        Label3.Text = " Welcome :: " + Session["user"].ToString();
        Label4.Text = " Login Time :: " + Session["login_time"].ToString();
        if (!IsPostBack)
        {
            
        }
        if (Session["PWD"].ToString() == "12345678")
        {
            ImageButton1.Visible = false;
        }
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(txt_old.Text))
        {
            Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('Please Enter Your Old Password !!')</script>");
            txt_old.BackColor = System.Drawing.Color.LightYellow;
            txt_old.Focus();
            return;
        }
        if (String.IsNullOrEmpty(txt_new.Text))
        {
            Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('Please Enter Your New Password!!')</script>");
            txt_new.BackColor = System.Drawing.Color.LightYellow;
            txt_new.Focus();
            return;
        }
        if ( txt_new.Text.Length < 8)
        {
            Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('New Password must be of 8 digits!!')</script>");
            txt_new.BackColor = System.Drawing.Color.LightYellow;
            txt_new.Focus();
            return;
        }
        if (String.IsNullOrEmpty(txt_conf.Text))
        {
            Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('Please Enter Confirm Password !!')</script>");
            txt_conf.BackColor = System.Drawing.Color.LightYellow;
            txt_conf.Focus();
            return;
        }
        if (txt_new.Text != txt_conf.Text)
        {
            Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('New Password & Confirm Password Should be Same!!')</script>");
            txt_conf.BackColor = System.Drawing.Color.LightYellow;
            txt_conf.Focus();
            return;
        }
        XmlDocument xmldoc = new XmlDocument();
        xmldoc.Load(Server.MapPath(@"App_Data\sap_login.xml"));
        for (int i = 0; i < xmldoc.DocumentElement.ChildNodes.Count; i++)
        {
            XmlNode xmlnode = xmldoc.DocumentElement.ChildNodes.Item(i);
            if (xmlnode["USER_ID"].InnerText == Session["user"].ToString())
            {
                if (xmlnode["PASSWORD"].InnerText == txt_old.Text.ToString())
                {
                    if (txt_new.Text != "12345678")
                    {
                        xmlnode["PASSWORD"].InnerText = this.txt_new.Text.ToString();
                        xmldoc.Save(Server.MapPath(@"App_Data\sap_login.xml"));
                        Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('Password Changed Successfully !!')</script>");
                        //Response.Redirect("default3.aspx");
                        ImageButton1.Visible = true;
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('Invalid Password !!')</script>");
                    //txt_pwd.Text = "";
                }
            }

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
    public void mess()
    {
        Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('Password Changed Successfully !!')</script>");
        return;
    }
}
