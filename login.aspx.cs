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

public partial class _Default : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        txt_userid.Focus();
    }
    protected void btn_login_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(txt_userid.Text))
        {
            Page.ClientScript.RegisterStartupScript(typeof(Page),"12", "<script>alert('Please Enter Valid User Name !!')</script>");
            txt_userid.BackColor = System.Drawing.Color.LightYellow;
            txt_userid.Focus();
            return;
        }
        if (String.IsNullOrEmpty(txt_pwd.Text))
        {
            Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('Please Enter Valid Password !!')</script>");
            txt_pwd.BackColor = System.Drawing.Color.LightYellow;
            txt_pwd.Focus();
            return;
        }
        XmlDocument xmldoc = new XmlDocument();
        xmldoc.Load(Server.MapPath(@"App_Data\sap_login.xml"));
        for (int i = 0; i < xmldoc.DocumentElement.ChildNodes.Count; i++)
        {
            XmlNode xmlnode = xmldoc.DocumentElement.ChildNodes.Item(i);
            if ((xmlnode["USER_ID"].InnerText.ToUpper() == txt_userid.Text.ToString().ToUpper())) //&& (xmlnode["ISACTIVE"].InnerText == "N"))
            {
                //if (xmlnode["ISACTIVE"].InnerText == "N")
                //{
                if (xmlnode["ISACTIVE"].InnerText == "Y")
                {
                    Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('User is Blocked,Contact to Admin!!')</script>");
                    return;
                }
                    if (xmlnode["PASSWORD"].InnerText.ToUpper() == txt_pwd.Text.ToString().ToUpper())
                    {
                        Session["user"] = txt_userid.Text.ToString();
                        Session["login_time"] = System.DateTime.Now.ToShortTimeString();
                        Session["USER_LEVEL"] = xmlnode["USER_LEVEL"].InnerText;
                        Session["department"] = xmlnode["MODULE"].InnerText;
                        Session["PWD"] = xmlnode["PASSWORD"].InnerText;
                        if (xmlnode["PASSWORD"].InnerText.ToUpper() != "12345678")
                        {
                            Response.Redirect("default3.aspx");
                        }
                        else
                        {
                            Response.Redirect("chnge_pwd.aspx");
                        }

                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('Invalid Password !!')</script>");
                        txt_pwd.Text = "";
                    }
                //}
                //else
                //{
                //    Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('User Is Blocked,Contact to Admin!!!')</script>");
                    
                //}
            }

        }
        Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('Invalid User Name !!')</script>");
        txt_userid.Text = "";
        txt_pwd.Text = "";
       
    }
    protected void lnkfame_Click(object sender, EventArgs e)
    {
        Response.Redirect("default.aspx");
    }
}
