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
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Net;
using System.Data.OleDb;

public partial class Default3 : System.Web.UI.Page
{
    static string currentRoot;
    static string maxvalue = "";
    //public static string nas_ip="\\"+"\\10.125.66.13\\finance";
    public static string nas_ip = "\\" + "\\10.125.65.127\\prm";
    OleDbConnection ocon = new OleDbConnection("Provider=MSDAORA.1; User ID=image; Password=image; Data Source=ebstest;");
   // OleDbConnection ocon = new OleDbConnection(NDS.conn());
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
            if (Request.QueryString["CODE"] == "1")
            {
                currentRoot = RetrievePathOfFolderToDisplay();
                litLocation.Text = "PATH :  " + currentRoot.Replace(nas_ip, ":");
                GridView2.DataSource = FileSystemToDataTableDetails(currentRoot);
                GridView2.DataBind();
                txtFolder.Visible = false;
                Button1.Visible = false;
                fupTest.Visible = false;
                btnUpload.Visible = false;
            }
            else
            {
                txtFolder.Visible = false;
                Button1.Visible = false;
                fupTest.Visible = false;
                btnUpload.Visible = false;
                currentRoot = RetrievePathOfFolderToDisplay();
                litLocation.Text = "PATH :  " + currentRoot.Replace(nas_ip, ":");
                try
                {
                    if (litLocation.Text == "PATH :  :" && Session["user"].ToString().ToUpper() != "ADMIN")
                    {
                        LinkButton3.Visible = false;
                        ImageButton1.Visible = false;
                        table_search.Visible = false;
                        LinkButton4.Visible = false;

                    }
                    else if (Session["USER_LEVEL"].ToString().ToUpper() == "ADMIN")
                    {
                        
                        if (litLocation.Text == "PATH :  :")
                        {
                            LinkButton3.Visible = false;
                            ImageButton1.Visible = false;
                            LinkButton2.Visible = false;


                                                       
                        }
                        else
                        {
                            
                            LinkButton3.Visible = false;
                            ImageButton1.Visible = true;
                            LinkButton2.Visible = true;
                           
                        }
                        LinkButton4.Visible = true;
                        
                        table_search.Visible = true;
                        //current_folder();
                    }
                    else
                    {
                        //if (currentRoot.ToString() != "\\\\10.125.66.13\\finance/FINANCE")
                        if (currentRoot.ToString() != "\\\\10.125.67.168\\upload/FINANCE")
                        {
                            if (currentRoot.ToString().ToUpper().Contains(Session["department"].ToString().ToUpper()))
                            {
                                {
                                    LinkButton3.Visible = false;
                                    LinkButton2.Visible = true;
                                    table_search.Visible = true;
                                    LinkButton4.Visible = false;
                                }
                                ImageButton1.Visible = true;
                            }
                            else
                            {
                                //Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('You are not authorized to view this folder!!')</script>");
                                Label5.Visible = true;
                                LinkButton4.Visible = false;
                                //MakeUpOneLevelLink(currentRoot);
                                return;
                            }
                        }
                        else
                        {
                            Label5.Visible = false;
                            LinkButton4.Visible = false;
                            LinkButton2.Visible = false;
                        }

                    }
                    GridView2.DataSource = FileSystemToDataTable(currentRoot);
                    GridView2.DataBind();
                    if (GridView2.Rows.Count == 0)
                    {
                        Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('Folder is empty!!')</script>");
                        return;
                    }
                   

                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('" + ex.ToString() + "')</script>");
                }
            }
        }
    }
    private string RetrievePathOfFolderToDisplay()
    {
        string localpath = Request.QueryString["local"];
        if (localpath == null)
            return nas_ip;
        else
            return Server.UrlDecode(localpath);
    }

    public DataTable FileSystemToDataTableDetails(string directory)
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(directory);
        FileInfo fileinfo = new FileInfo(directory);
        DataTable filesystem = new DataTable();
        filesystem.Columns.Add(new DataColumn("Name"));
        filesystem.Columns.Add(new DataColumn("Image"));
        DataRow dataRow = filesystem.NewRow();
        if (directoryInfo.Extension == "")
        {
            dataRow["Image"] = "folder";
            dataRow["Name"] = "Created on : " + directoryInfo.CreationTime + "   Last Updated Time : " + directoryInfo.LastWriteTime;
        }
        else
        {
            string uploadedby = "";
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(Server.MapPath(@"App_Data\sap_file.xml"));
            for (int i = 0; i < xmldoc.DocumentElement.ChildNodes.Count; i++)
            {
                XmlNode xmlnode = xmldoc.DocumentElement.ChildNodes.Item(i);
                if ((xmlnode["DIR_PATH"].InnerText + "/" + xmlnode["F_FILENAME"].InnerText) == directory)
                {
                    uploadedby = xmlnode["UPLOADED_BY"].InnerText;
                }
            }
            dataRow["Image"] = "file";
            dataRow["Name"] = "Created on : " + fileinfo.CreationTime + "   Last Updated Time : " + fileinfo.LastWriteTime + "   Size : " + fileinfo.Length / 1000 + "KB" ;
        }
            filesystem.Rows.Add(dataRow);
        return filesystem;
    }
    public string current_folder()
    {
        if (Session["USER_LEVEL"].ToString().ToUpper() == "ADMIN")
        {  
            if (GridView2.Rows.Count > 0)
            {
                for (int i = 0; i < GridView2.Rows.Count; i++)
                {
                    (GridView2).Rows[i].Cells[4].FindControl("ImageButton2").Visible = true;
                }
            }
              
        }
        else
        {
            
            string right = "";
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(Server.MapPath(@"App_Data\sap_folder.xml"));
            for (int i = 0; i < xmldoc.DocumentElement.ChildNodes.Count; i++)
            {
                XmlNode xmlnode = xmldoc.DocumentElement.ChildNodes.Item(i);
                if (xmlnode["DIR_NAME"].InnerText.ToUpper() == Session["department"].ToString().ToUpper())
                {
                    string ab = xmlnode["P_DIR_NAME"].InnerText + "/" + xmlnode["DIR_NAME"].InnerText;

                    if (ab.ToString().Contains(Session["department"].ToString().ToUpper()) || litLocation.Text.Contains(Session["department"].ToString().ToUpper()))
                    {
                        LinkButton4.Visible = false;
                        LinkButton3.Visible = false;
                        LinkButton2.Visible = true;
                    }
                    else
                    {
                        LinkButton4.Visible = false;
                        LinkButton3.Visible = false;
                        LinkButton2.Visible = false;

                    }  
               }
            }
            if (GridView2.Rows.Count > 0)
            {
                for (int i = 0; i < GridView2.Rows.Count; i++)
                {
                    (GridView2).Rows[i].Cells[4].FindControl("ImageButton2").Visible = false;
                }
            }
           return "RO";
        }
        return "RO";
    }

    public void SET_RIGHT(string rights)
    {
        if (rights == "RO")
        {
            LinkButton2.Visible = false;
            LinkButton3.Visible = false;
            LinkButton4.Visible = false;
        }
        if (rights == "RW")
        {
            LinkButton3.Visible = false;
            LinkButton2.Visible = true;
            if (Session["USER_LEVEL"].ToString().ToUpper() == "ADMIN")
            {
                LinkButton4.Visible = true;
                LinkButton2.Visible = true;
                LinkButton3.Visible = false;
                //table_search.Visible = true;

            }
            else
            {
                LinkButton4.Visible = false;
                //LinkButton2.Visible = false;
            }
        }
        if (rights == "VW")
        {
            LinkButton2.Visible = false;
            LinkButton3.Visible = false;
            LinkButton4.Visible = false;
        }


    }

    public DataTable FileSystemToDataTable(string directory)
    {
       // File_Upload_system.NAS.map_drive();
        DirectoryInfo directoryInfo = new DirectoryInfo(directory);
            
        DataTable filesystem = new DataTable();
        filesystem.Columns.Add(new DataColumn("Name"));
        filesystem.Columns.Add(new DataColumn("Image"));
        foreach (FileSystemInfo fileSystemInfo in directoryInfo.GetFileSystemInfos())
        {
            if (fileSystemInfo.Name.ToUpper() != "RECYCLE BIN")
            {
                DataRow dataRow = filesystem.NewRow();
                dataRow["Name"] = fileSystemInfo.Name;
                if (fileSystemInfo.Extension == "")
                    dataRow["Image"] = "folder";
                else
                    dataRow["Image"] = "file";
                filesystem.Rows.Add(dataRow);
            }
        }
        return filesystem;
    }
    private string GetPreviousFolder(string path)
    {
        int posOfLastSlash = path.LastIndexOf("/");
        if (posOfLastSlash < 0)
            return nas_ip;
        string stripped = path.Remove(posOfLastSlash);
        return stripped;
    }
    private void MakeUpOneLevelLink(string currentFolder)
    {
        string previousFolder = GetPreviousFolder(currentFolder);
        if (previousFolder != "")
        {
            Response.Redirect("default3.aspx?local=" +Server.UrlEncode(previousFolder));
            LiteralControl br = new LiteralControl("<br/>");
        }
    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    private void GetData()
    {
        GridView2.DataSource = this.Data;
        GridView2.DataBind();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Row obj = new Row();
        this.Data.Add(obj);
        this.GetData();
    }

    private List<Row> Data
    {
        get
        {
            if (this.ViewState["Data"] == null)
            {
                this.ViewState["Data"] = new List<Row>();
            }
            return this.ViewState["Data"] as List<Row>;
        }
    }
    protected void btnNewFolder_Click(object sender, EventArgs e)
    {
        if (GridView2.Rows.Count > 0)
        {
            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                if (Data.Count < GridView2.Rows.Count)
                {
                    Row obj = new Row();
                    this.Data.Add(obj);
                    
                }
               
                this.Data[i].Name = ((HyperLink)GridView2.Rows[i].FindControl("HyperLink2")).Text;
            }            
       }
        try
        {
            if (String.IsNullOrEmpty(txtFolder.Text.Trim()))
            {
                Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('Pls,enter a valid folder name !!')</script>");
                return;
            }
            string folderLocation = RetrievePathOfFolderToDisplay();
            string fullPath = folderLocation + "\\" + txtFolder.Text;
            Directory.CreateDirectory(fullPath);
            GridView2.DataSource = FileSystemToDataTable(currentRoot);
            GridView2.DataBind();
            
            XmlDocument sap = new XmlDocument();
            sap.Load(Server.MapPath("app_data/sap_folder.xml"));
            XmlElement new_folder = sap.CreateElement("new_folder");
            XmlElement DIR_ID = sap.CreateElement("DIR_ID");
            XmlElement DIR_NAME = sap.CreateElement("DIR_NAME");
            XmlElement P_DIR_ID = sap.CreateElement("P_DIR_ID");
            XmlElement P_DIR_NAME = sap.CreateElement("P_DIR_NAME");
            //XmlElement RIGHT_PM = sap.CreateElement("RIGHT_PM");
            //XmlElement RIGHT_VW = sap.CreateElement("RIGHT_VW");
            DIR_ID.InnerText = "";
            DIR_NAME.InnerText =txtFolder.Text.ToString().ToUpper().Trim();
            P_DIR_ID.InnerText = "";
            P_DIR_NAME.InnerText = folderLocation.ToString().Trim();
            new_folder.AppendChild(DIR_ID);
            new_folder.AppendChild(DIR_NAME);
            new_folder.AppendChild(P_DIR_ID);
            new_folder.AppendChild(P_DIR_NAME);
            sap.DocumentElement.AppendChild(new_folder);
            sap.Save(Server.MapPath("app_data/sap_folder.xml"));
            Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('Folder Created Succesfully !!')</script>");
        }
        catch
        {
            Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('Problem Connecting with NAS, Pls Try later !!')</script>");
        }
        finally
        {
            txtFolder.Text = "";
        }
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex >= 0)
        {
           if (Request.QueryString["CODE"] == "1")
            {
                ((HyperLink)e.Row.FindControl("HyperLink2")).Enabled = false;
                ((HyperLink)e.Row.FindControl("HyperLink2")).Font.Bold = true;
                ((HyperLink)e.Row.FindControl("HyperLink3")).Text = "";
                ((HyperLink)e.Row.FindControl("HyperLink1")).Text = "";
               ((ImageButton)e.Row.FindControl("ImageButton2")).Visible = false;
                if (((Label)e.Row.FindControl("Label2")).Text == "folder")
                {
                    ((Image)e.Row.FindControl("Image1")).ImageUrl = "images/folder.png";
                }
                else
                {
                    string image = "icons/";
                    string ext = Path.GetExtension(currentRoot).ToLower();
                    if (ext == ".txt")
                        image += "icon_txt.gif";
                    else if (ext == ".doc")
                        image += "icon_doc.gif";
                    else if (ext == ".xls")
                        image += "icon_xls.gif";
                    else if (ext == ".ppt")
                        image += "icon_ppt.gif";
                    else if (ext == ".pdf")
                        image += "icon_pdf.gif";
                    else if (ext == ".zip")
                        image += "icon_zip.gif";
                    else if (ext == ".gif" || ext == ".jpg" || ext == ".wmf" || ext == ".png")
                        image += "icon_jpg.gif";
                    else if (ext == ".mpeg" || ext == ".mpg" || ext == ".mp3" || ext == ".3gp" || ext == ".mp4" || ext == ".dat")
                        image += "icon_video.gif";
                    else if (ext == ".html" || ext == ".htm")
                        image += "icon_html.gif";
                    else
                        image += "icon_none.gif";
                   ((Image)e.Row.FindControl("Image1")).ImageUrl = image;
                }
            }
            else
            {

                if (((Label)e.Row.FindControl("Label2")).Text == "folder")
                {
                    ((Image)e.Row.FindControl("Image1")).ImageUrl = "images/folder.png";
                    ((HyperLink)e.Row.FindControl("HyperLink2")).NavigateUrl = "Default3.aspx?local=" + Server.UrlEncode(currentRoot + "/" + ((HyperLink)e.Row.FindControl("HyperLink2")).Text);
                    ((HyperLink)e.Row.FindControl("HyperLink3")).Text = "";
                    ((HyperLink)e.Row.FindControl("HyperLink1")).NavigateUrl = "Default3.aspx?CODE=1&local=" + Server.UrlEncode(currentRoot + "/" + ((HyperLink)e.Row.FindControl("HyperLink2")).Text);
                }

                else
                {
                   
                    ((HyperLink)e.Row.FindControl("HyperLink1")).Text = "History";
                    ((HyperLink)e.Row.FindControl("HyperLink2")).NavigateUrl = currentRoot.ToString() + "\\" + ((HyperLink)e.Row.FindControl("HyperLink2")).Text.ToString();
                    ((HyperLink)e.Row.FindControl("HyperLink2")).Target = "_blank";
                    ((HyperLink)e.Row.FindControl("HyperLink1")).NavigateUrl = "Default3.aspx?CODE=1&local=" + Server.UrlEncode(currentRoot + "/" + ((HyperLink)e.Row.FindControl("HyperLink2")).Text);

                    string image = "icons/";
                    string ext = Path.GetExtension(((HyperLink)e.Row.FindControl("HyperLink2")).Text).ToLower();
                    if (ext == ".txt")
                        image += "icon_txt.gif";
                    else if (ext == ".doc")
                        image += "icon_doc.gif";
                    else if (ext == ".xls")
                        image += "icon_xls.gif";
                    else if (ext == ".ppt")
                        image += "icon_ppt.gif";
                    else if (ext == ".pdf")
                        image += "icon_pdf.gif";
                    else if (ext == ".zip")
                        image += "icon_zip.gif";
                    else if (ext == ".gif" || ext == ".jpg" || ext == ".wmf" || ext == ".png")
                        image += "icon_jpg.gif";
                    else if (ext == ".mpeg" || ext == ".mpg" || ext == ".mp3" || ext == ".3gp" || ext == ".mp4" || ext == ".dat")
                        image += "icon_video.gif";
                    else if (ext == ".html" || ext == ".htm")

                        image += "icon_html.gif";
                    else
                        image += "icon_none.gif";
                    ((Image)e.Row.FindControl("Image1")).ImageUrl = image;
                }
                if (Session["USER_LEVEL"].ToString().ToUpper() == "ADMIN")
                {
                    ((ImageButton)e.Row.FindControl("ImageButton2")).Visible = true;
                }
                else
                {
                    ((ImageButton)e.Row.FindControl("ImageButton2")).Visible = false;
                }
            }
        }
    }
    public void getserialno(string parent,string child)
    {
        string strcon = "";
        
        //string serial = "";
        
        //int i = 0;
        strcon = "SELECT '"+parent+"'||'"+child+"'||TO_CHAR(SYSDATE,'ddmmyy')||LPAD(TO_CHAR(NVL(TO_NUMBER(MAX(SUBSTR(NVL(f_serial,0),13))),0)+1),5,'0') ID FROM  sap_file  WHERE SUBSTR(f_serial,0,3)='"+parent+"' AND SUBSTR(f_serial,4,3)='"+child+"' AND SUBSTR(f_serial,7,6)=TO_CHAR(SYSDATE,'ddmmyy')";
        OleDbCommand cmd = new OleDbCommand(strcon, ocon);
        ocon.Open();
        OleDbDataReader odr = cmd.ExecuteReader();
        while (odr.Read())
        {
            maxvalue = odr["ID"].ToString().Trim();
        }
        ocon.Close();
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        //if 
        if (GridView2.Rows.Count > 0)
        {
            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                if (Data.Count < GridView2.Rows.Count)
                {
                    Row obj = new Row();
                    this.Data.Add(obj);
                }
                this.Data[i].Name = ((HyperLink)GridView2.Rows[i].FindControl("HyperLink2")).Text;
                this.Data[i].Image = ((Label)GridView2.Rows[i].FindControl("Label2")).Text;
            }
        }
        try
        {
            string path = RetrievePathOfFolderToDisplay();
            if (fupTest.HasFile)
            {
                string fullname = path + "\\" + fupTest.FileName.Replace(' ', '_');
                if (Path.GetExtension(fullname) == ".zip")
                {
                    Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('ZIP files are not allowed to upload here,,Upload Cancelled!!')</script>");
                    return;
                }
              
                if (System.IO.File.Exists(fullname))
                {
                   Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('File Already Exists, Upload Cancelled !!')</script>");
                }
                
                 else
                {
                    
                    fupTest.SaveAs(fullname);
                    string docid = txt_sapno.Text.ToString();
                    Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert( 'File Uploaded Successfully!!!****DocumentID is " + docid.ToString() + "')</script>");
                    //string strmsg = "File Uploaded Successfully!!!\r\n "+"  DocumentID is " + docid.ToString() + "";
                    //Page.RegisterStartupScript("onClick", "<script language=JavaScript>onClick(" + strmsg + ");</script>");
                    
                    GridView2.DataSource = FileSystemToDataTable(currentRoot);
                    GridView2.DataBind();
                    string childfolder = RetrievePathOfFolderToDisplay().ToString().Substring(RetrievePathOfFolderToDisplay().LastIndexOf('/')+1);
                    string parentfolderpath = RetrievePathOfFolderToDisplay().ToString().Substring(0,RetrievePathOfFolderToDisplay().LastIndexOf('/'));
                    string parentfolder = parentfolderpath.ToString().Substring(parentfolderpath.ToString().LastIndexOf('\\')+1);
                    if (parentfolder.Contains("/"))
                    {
                        parentfolder = parentfolderpath.ToString().Substring(parentfolderpath.ToString().LastIndexOf('/') + 1);
                    }
                    getserialno(parentfolder.ToString().Substring(0,3).ToUpper(), childfolder.ToString().Substring(0, 3).ToUpper());
                    System.IO.FileInfo fi = new FileInfo(fullname);
                    string str = "";
                    str = "insert into sap_file(F_FILENAME,F_SIZE,F_SERIAL,F_TYPE,DIR_ID,DIR_PATH,UPLOADED_BY,UPLOAD_TIME,LAST_UPDATE_BY,LAST_UPDATE_DATE)";
                    str = str + "values('" + fupTest.FileName.Replace(' ', '-') + "','" + Convert.ToString(fi.Length / 1000) + "','" + maxvalue.ToString() + "','" + fi.Extension.ToString() + "','"+docid.ToString()+"','" + fullname.ToString() + "','" + Session["user"].ToString() + "'";
                    str = str + ",'"+System.DateTime.Now.ToShortTimeString()+"','','')";
                    ocon.Open();
                    OleDbCommand cmd = new OleDbCommand(str,ocon);
                    cmd.ExecuteNonQuery();
                    ocon.Close();
                    
                }
            }
            else
            {
                labMessage.Text = "File was not specified";
            }
        }
        catch(Exception ex)
        {
            Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('Problem Connecting with NAS, Pls Try later !!')</script>");
        }
        finally
        {
            txtFolder.Text = "";
         //   File_Upload_system.NAS.unmap_drive();
            GridView2.DataSource = FileSystemToDataTable(currentRoot);
            GridView2.DataBind();
            current_folder();
            
        }
    
    }
    [Serializable()]
    public class Row
    {
        private string _txt1;
        private string _img1;

        public string Name
        {
            get { return _txt1; }
            set { _txt1 = value; }
        }
        public string Image
        { 
          get {return _img1;}
          set { _img1 = value; }
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        MakeUpOneLevelLink(currentRoot);
    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       if (e.CommandName == "del")
        {
            if (((Label)GridView2.Rows[int.Parse(e.CommandArgument.ToString())].FindControl("Label2")).Text == "folder")
            {
                try
                {
                    string name = ((HyperLink)GridView2.Rows[int.Parse(e.CommandArgument.ToString())].FindControl("HyperLink2")).Text;
                    Directory.Move(currentRoot + "\\" + name, nas_ip + "\\recycle bin" + "\\" + name + "_" + System.DateTime.Now.ToShortDateString().Replace('/', '_') + "_" + System.DateTime.Now.ToShortTimeString().Replace(':', '_').Replace(' ', '_'));
                    XmlDocument sap = new XmlDocument();
                    sap.Load(Server.MapPath(@"App_Data\sap_folder.xml"));
                    for (int i = 0; i < sap.DocumentElement.ChildNodes.Count; i++)
                    {
                        XmlNode xmlnode = sap.DocumentElement.ChildNodes.Item(i);
                        if (xmlnode["DIR_NAME"].InnerText.ToUpper() == name.ToString().ToUpper())
                        {
                            sap.DocumentElement.RemoveChild(xmlnode);
                            //xmlnode.RemoveAll();
                        }
                    }
                    sap.Save(Server.MapPath(@"app_data/sap_folder.xml"));


                    Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('Folder deleted Successfully !!')</script>");
                }
                catch
                {
                    Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('Problem Connecting with NAS, Pls Try later !!')</script>");
                }
                finally
                {
                    txtFolder.Text = "";
                }
            }
            else
            {
                try
                {
                    string name = ((HyperLink)GridView2.Rows[int.Parse(e.CommandArgument.ToString())].FindControl("HyperLink2")).Text;
                    string fname = Path.GetFileNameWithoutExtension(currentRoot + "\\" + name).ToLower();
                    string ext = Path.GetExtension(currentRoot + "\\" + name).ToLower();
                    File.Move(currentRoot + "\\" + name, nas_ip + "\\recycle bin" + "\\" + fname + "_" + System.DateTime.Now.ToShortDateString().Replace('/', '_') + "_" + System.DateTime.Now.ToShortTimeString().Replace(':', '_').Replace(' ', '_') + ext);
                    File.Delete(currentRoot + "\\" + name);
                    Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('File deleted Successfully !!')</script>");
                }
                catch(Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('Problem Connecting with NAS, Pls Try later !!')</script>");
                }
                finally
                {
                    txtFolder.Text = "";
                }
            }
            GridView2.DataSource = FileSystemToDataTable(currentRoot);
            GridView2.DataBind();
            current_folder();
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Response.Redirect("user_cretion.aspx");
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        txtFolder.Visible = true;
        Button1.Visible = true;
        TABLE1.Visible = true;
        fupTest.Visible = false;
        txt_sapno.Visible = false;
        btnUpload.Visible = false;
        GridView1.Visible = false;
        table_search.Visible = false;
        txt_search.Text = "";
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        TABLE1.Visible = false;
        txtFolder.Visible = false;
        Button1.Visible = false;
        fupTest.Visible = true;
        fupTest.Focus();
        txt_sapno.Visible = true;
        btnUpload.Visible = true;
        GridView1.Visible = false;
        table_search.Visible = false;
        txt_search.Text = "";
    }
    protected void lk_pwd_Click(object sender, EventArgs e)
    {
        Response.Redirect("chnge_pwd.aspx");
    }
    protected void HyperLink2_DataBinding(object sender, EventArgs e)
    {
       
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {

    }
    //protected void btn_search_Click(object sender, EventArgs e)
    //{
    //    string strsearch = "";
    //    if (Session["USER_LEVEL"].ToString().ToUpper() == "ADMIN")
    //    {
    //        strsearch = "SELECT F_FILENAME,DIR_PATH,(UPLOADED_BY)\"Uploaded By\",TO_Char(DATEUPLOADED,'dd-Mon-yyyy')\"Uploaded On\",(DIR_ID)\"Document ID\",(F_serial)\"Application ID\" from sap_file where (upper(F_SERIAL) like('%" + txt_search.Text.ToUpper().ToString() + "%') or upper(F_FILENAME) like '%" + txt_search.Text.ToUpper().ToString().Replace(' ', '_') + "%') or (upper(DIR_ID) like('%" + txt_search.Text.ToUpper().ToString() + "%'))";
    //    }
    //    else
    //    {
    //        strsearch = "SELECT F_FILENAME,DIR_PATH,(UPLOADED_BY)\"Uploaded By\",TO_Char(DATEUPLOADED,'dd-Mon-yyyy')\"Uploaded On\",(DIR_ID)\"Document ID\",(F_serial)\"Application ID\" from sap_file where Uploaded_By='" + Session["user"].ToString() + "' and (upper(F_SERIAL) like('%" + txt_search.Text.ToUpper().ToString() + "%') or upper(F_FILENAME) like '%" + txt_search.Text.ToUpper().ToString().Replace(' ', '_') + "%') or (upper(DIR_ID) like('%" + txt_search.Text.ToUpper().ToString() + "%')) ";
    //    }
    //        ocon.Open();
    //    OleDbDataAdapter da = new OleDbDataAdapter(strsearch, ocon);
    //    DataSet ds = new DataSet();
    //    da.Fill(ds, "SAP_FILE");
    //    GridView1.DataSource = ds;
    //    GridView1.DataBind();
    //    ocon.Close();
    //    if (GridView1.Rows.Count == 0)
    //    {
    //            Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('Requested File Not Found!!!')</script>");
    //            txt_search.Text = "";
    //    }
        


    //}
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
        if (e.Row.RowType.ToString() != "Header" && e.Row.RowType.ToString() != "Footer")
        {
            ((HyperLink)e.Row.FindControl("HyperLink4")).Text = e.Row.Cells[1].Text.ToString();
            ((HyperLink)e.Row.FindControl("HyperLink4")).NavigateUrl = e.Row.Cells[2].Text.ToString();//.Replace(nas_ip," ");
        }
    }


    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        Response.Redirect("up_details.aspx");
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        if (txt_search.Text == "")
        {
            Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('Pls, Enter a valid search Option!!!')</script>");
            txt_search.Focus();
            return;
        }
        string strsearch = "";
        if (Session["USER_LEVEL"].ToString().ToUpper() == "ADMIN")
        {
            strsearch = "SELECT F_FILENAME,DIR_PATH,(UPLOADED_BY)\"Uploaded By\",TO_Char(DATEUPLOADED,'dd-Mon-yyyy')\"Uploaded On\",(DIR_ID)\"Document ID\",(F_serial)\"Application ID\" from sap_file where (upper(F_SERIAL) like('%" + txt_search.Text.ToUpper().ToString() + "%') or upper(F_FILENAME) like '%" + txt_search.Text.ToUpper().ToString().Replace(' ', '_') + "%') or (upper(DIR_ID) like('%" + txt_search.Text.ToUpper().ToString() + "%'))";
        }
        else
        {
            strsearch = "SELECT F_FILENAME,DIR_PATH,(UPLOADED_BY)\"Uploaded By\",TO_Char(DATEUPLOADED,'dd-Mon-yyyy')\"Uploaded On\",(DIR_ID)\"Document ID\",(F_serial)\"Application ID\" from sap_file where Uploaded_By='" + Session["user"].ToString() + "' and (upper(F_SERIAL) like('%" + txt_search.Text.ToUpper().ToString() + "%') or upper(F_FILENAME) like '%" + txt_search.Text.ToUpper().ToString().Replace(' ', '_') + "%') or (upper(DIR_ID) like('%" + txt_search.Text.ToUpper().ToString() + "%')) ";
        }
        ocon.Open();
        OleDbDataAdapter da = new OleDbDataAdapter(strsearch, ocon);
        DataSet ds = new DataSet();
        da.Fill(ds, "SAP_FILE");
        GridView1.DataSource = ds;
        GridView1.DataBind();
        ocon.Close();
        if (GridView1.Rows.Count == 0)
        {
            Page.ClientScript.RegisterStartupScript(typeof(Page), "12", "<script>alert('Requested File Not Found!!!')</script>");
            txt_search.Text = "";
        }



    }
   
}

