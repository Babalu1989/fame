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
using System.Data.OleDb;

public partial class up_details : System.Web.UI.Page
{
    OleDbConnection ocon = new OleDbConnection("Provider=MSDAORA.1; User ID=image; Password=image; Data Source=ebstest");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"].ToString() == null)
        {
            Response.Redirect("login.aspx");
        }
        Label3.Text = " Welcome :: " + Session["user"].ToString();
        Label4.Text = " Login Time :: " + Session["login_time"].ToString();
        if (!IsPostBack)
        {
            //bind();
        }
    }
    public void bind()
    {
        
        string strselect = "";
        if (Session["user"].ToString().ToUpper() == "ADMIN")
        {
            strselect = "SELECT F_FILENAME,f_serial,dir_id,UPLOADED_BY,TO_char(DATEUPLOADED,'dd/MM/yyyy')DATEUPLOADED FROM sap_file where TO_CHAR(DATEUPLOADED,'dd/MM/yyyy') LIKE ('" + txt_date.Text + "%')";
        }
        else
        {
            strselect = "SELECT F_FILENAME,f_serial,dir_id,UPLOADED_BY,TO_char(DATEUPLOADED,'dd/MM/yyyy')DATEUPLOADED FROM sap_file where TO_CHAR(DATEUPLOADED,'dd/MM/yyyy') LIKE ('" + txt_date.Text + "%') and UPLOADED_BY = '" + Session["user"].ToString() + "'  ";
        }
            ocon.Open();
        OleDbDataAdapter da = new OleDbDataAdapter(strselect, ocon);
        DataSet ds = new DataSet();
        da.Fill(ds, "SAP_FILE");
        GridView1.DataSource = ds;
        GridView1.DataBind();
        ocon.Close();
       
    }
    //protected void btn_search_Click(object sender, EventArgs e)
    //{
       
    //}
    protected void btn_search_Click1(object sender, EventArgs e)
    {
        bind();
        Label2.Visible = true;
        Label2.Text="Total Files Found:: " +GridView1.Rows.Count.ToString();
          if (GridView1.Rows.Count == 0)
          {
              Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('No Record Exists For Selected Date!!!')</script>");
              return;
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
