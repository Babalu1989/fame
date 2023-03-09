using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Text;
using System.Xml;
using System.Net;




public partial class _Default : System.Web.UI.Page 
{
    static string fn = "";
    public static string nas_ip = "\\" + "\\10.125.65.127\\prm";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
    
        }
        else
        {
            bindDrop();
            deleteOldFiles();
        }
        
        
    }
    void bindDrop()
    {
        ddldept.Items.Clear();
        DataSet mydata = new DataSet();
        mydata.ReadXml(Server.MapPath("app_data/sap_folder.xml"));
        ddldept.Items.Add("-Select-");
        try
        {
            for (int i = 0; i < mydata.Tables[0].Rows.Count; i++)
            {
                ddldept.Items.Add(mydata.Tables[0].Rows[i][1].ToString());
            }
        }
        catch
        {

        }
    }
    void deleteOldFiles()
    {
        string sl = "";
        sl =Server.MapPath("Dtdocs");
        DirectoryInfo Dir = new DirectoryInfo(sl);
        FileInfo[] Files;
        Files = Dir.GetFiles();
        //FileInfo F;
        foreach (FileInfo F in Files)
        {
            //if (DateTime.Now > F.LastWriteTime.AddDays(1))
            //{
            try
            {
                F.Delete();
            }
            catch
            {

            }
            //}
        }
    }
    string GetFileSize(int length)
    {
        string a = Convert.ToString(Math.Round(Convert.ToDouble(length/1024),2));
        if (Convert.ToDouble(a) / 1024 >= 1)
            return Convert.ToString(Math.Round(Convert.ToDouble(a) / 1024, 2)) + " MB";
        else
            return a + " KB";
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.close()</script>");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.open('help.aspx',null,'left=200,top=150,height=400,width=500,status=no,resizable=no,scrollbars=yes,toolbar=no,location=no,menubar=no')</script>");
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (FileUpload1.PostedFile.ToString() == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "123", "<script>alert('Browse a File to Upload')</script>");
            return;
        }
        if (ddldept.SelectedItem.Text == "-Select-")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "123", "<script>alert('Select a Dept. for which file is to be uploaded.')</script>");
            ddldept.Focus();
            return;
        }
        if (string.IsNullOrEmpty(txtpassword.Text))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "123", "<script>alert('Enter Password.')</script>");
            txtpassword.Focus();
            return;
        }
        string s = FileUpload1.PostedFile.FileName.ToString();
        Label1.Text = GetFileSize(FileUpload1.PostedFile.ContentLength);
        string sl = "";
        fn = System.IO.Path.GetFileName(FileUpload1.FileName.ToString()).Replace(" ", "");
        //sl = Server.MapPath("Dtdocs\\" + fn);
        sl = Server.MapPath("Dtdocs\\");
            


        FileInfo fi = new FileInfo(s);
        if (FileUpload1.PostedFile.ContentLength > 26325123)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "123", "<script>alert('File Attached should be less than 25Mb.')</script>");
            return;
        }
        else if (fi.Extension.ToUpper() == ".DOC" || fi.Extension.ToUpper() == ".XLS" || fi.Extension.ToUpper() == ".PPT" || fi.Extension.ToUpper() == ".PPS" || fi.Extension.ToUpper() == ".PDF" || fi.Extension.ToUpper() == ".ZIP" || fi.Extension.ToUpper() == ".TXT" || fi.Extension.ToUpper() == ".RAR" || fi.Extension.ToUpper() == ".JPG" || fi.Extension.ToUpper() == ".GIF")
        {
            if (File.Exists("\\\\10.125.65.127\\prm\\depts\\" + ddldept.SelectedItem.Text + "\\" + FileUpload1.FileName + ".cry"))
            {
               
            }
            else
            {

                //EncryptFile(txtpassword.Text.ToString(), FileUpload1.FileName, FileUpload1.PostedFile.FileName, Server.MapPath("dtdocs\\"));

                try
                {
                    if(File.Exists(Server.MapPath("dtdocs\\"+FileUpload1.FileName.Replace(" ", ""))))
                    {
                        File.Delete(Server.MapPath("dtdocs\\"+FileUpload1.FileName.Replace(" ", "")));
                    }
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("dtdocs\\"+FileUpload1.FileName.Replace(" ", "")));
                    if (File.Exists("\\\\10.125.65.127\\prm\\depts\\" + ddldept.SelectedItem.Text + "\\" + FileUpload1.FileName.Replace(" ", "")))
                    {
                        string abcd1 = "<script>alert('File Already Exists.');</script>";
                        ClientScript.RegisterStartupScript(this.GetType(), "abc", abcd1);
                        return;
                    }
                    File.Copy(Server.MapPath("dtdocs\\"+FileUpload1.FileName.Replace(" ", "")), "\\\\10.125.65.127\\prm\\depts\\" + ddldept.SelectedItem.Text + "\\" + FileUpload1.FileName.Replace(" ", ""));
                    string abcd = "<script>alert('File SuccessFully Uploaded');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "abc", abcd);
                    ClientScript.RegisterStartupScript(this.GetType(), "123", "<script>location.href = 'mailto:?Body=http://10.125.65.127/prm/depts/" + ddldept.SelectedItem.Text + "/" + FileUpload1.FileName.Replace(" ", "") + "';</script>");
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
                        
                                
            }
            
            
            //----------------------------------------------- for testing ----------------------------------
                 //Response.Write("http:10.125.65.127/prm/depts/" + ddldept.SelectedItem.Text + "/" + FileUpload1.FileName.Replace(" ", ""));
            //ClientScript.RegisterStartupScript(this.GetType(), "123", "<script>location.href = 'mailto:?Body=http://10.125.65.127/prm/depts/" + ddldept.SelectedItem.Text + "/" + FileUpload1.FileName.Replace(" ", "")+"';</script>");

            //------------------------------------------------ for live ------------------------------------
            

            //Response.Write("<script>window.open('http://10.125.65.127/prm/depts/" + ddldept.SelectedItem.Text + "/" + FileUpload1.FileName.Replace(" ", "") + "')</script>");
            

            //txtpassword.Text = "";
            //ClientScript.RegisterStartupScript(this.GetType(), "123", "<script>location.href = 'mailto:?Body=http://10.125.64.30/dtdocs/" + fn.ToString() + "';</script>");
            //string path = "http://10.125.65.127/dms1/frmdownload.aspx%3Ffid=" + fn + "%26fod=" + ddldept.SelectedItem.Text;
            //ClientScript.RegisterStartupScript(this.GetType(), "123", "<script>location.href = 'mailto:?Body=" + path + "';</script>");
            return;
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "123", "<script>alert('You can Upload only (Doc,Xls,Pdf,PPT,PPS,ZIP,TXT,RAR,JPG,GIF) files.')</script>");
            return;
        }

    }



    private void EncryptFile(string password, string file, string pathofFile, string pathtopaste)
    {
        string f_name = "";
        f_name = file.Replace(" ","") + ".cry";
        try
        {
            if (password.Length > 8)
                password = password.Substring(0, 8);
            else if (password.Length < 8)
            {
                int add = 8 - password.Length;
                for (int i = 0; i < add; i++)
                    password = password + i;
            }
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] key = UE.GetBytes(password);

            //string cryptFile = f_name;
            FileStream fsCrypt = new FileStream(pathtopaste + "\\" + f_name, FileMode.Create);

            RijndaelManaged RMCrypto = new RijndaelManaged();

            CryptoStream cs = new CryptoStream(fsCrypt,
                RMCrypto.CreateEncryptor(key, key),
                CryptoStreamMode.Write);

            FileStream fsIn = new FileStream(pathofFile, FileMode.Open);

            int data;
            while ((data = fsIn.ReadByte()) != -1)
                cs.WriteByte((byte)data);

            fsIn.Close();
            cs.Close();
            fsCrypt.Close();
            try
            {
                //File.Copy(pathtopaste + cryptFile, nas_ip + "\\depts\\" + ddldept.SelectedItem.Text + "\\" + cryptFile);
            }
            catch (Exception e)
            {
                //Response.Write(e.Message.ToString());
            }
            //File.Move(pathtopaste + cryptFile, nas_ip + "\\depts\\"+ddldept.SelectedItem.Text+"\\" + cryptFile);

            //uploadFileUsingFTP(nas_ip + "\\depts\\" + ddldept.SelectedItem.Text + "\\" + cryptFile, pathtopaste + cryptFile, "srikant", "rahul");

        }
        catch (Exception e)
        {
            //Response.Write(e.Message);
        }
    }
    protected void lnkadmin_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
    }

    public void uploadFileUsingFTP(string CompleteFTPPath ,string CompleteLocalPath , string UName , string PWD )
    {
        //'Create a FTP Request Object and Specfiy a Complete Path 
         //Dim reqObj As FtpWebRequest = WebRequest.Create(CompleteFTPPath)
       WebRequest  reqObj =   WebRequest.Create("ftp:"+CompleteFTPPath);
       

        //'Call A FileUpload Method of FTP Request Object
         //reqObj.Method = WebRequestMethods.Ftp.UploadFile
        reqObj.Method = WebRequestMethods.Ftp.UploadFile;

        //'If you want to access Resourse Protected You need to give User Name      and PWD
         //reqObj.Credentials = New NetworkCredential(UName, PWD)
        reqObj.Credentials = new NetworkCredential(UName,PWD);

        //'FileStream object read file from Local Drive
         //Dim streamObj As FileStream = File.OpenRead(CompleteLocalPath)
        FileStream streamObj = File.Open(CompleteFTPPath,FileMode.Open);

        //'Store File in Buffer
        // Dim buffer(streamObj.Length) As Byte
        byte[] b = new byte[streamObj.Length + 1]; 
        //'Read File from Buffer
         //streamObj.Read(buffer, 0, buffer.Length)
        streamObj.Read(b,0,b.Length);

        //'Close FileStream Object Set its Value to nothing
         streamObj.Close();
         streamObj = null;

        //'Upload File to ftp://localHost/ set its object to nothing
        // reqObj.GetRequestStream().Write(buffer, 0, buffer.Length)
        reqObj.GetRequestStream().Write(b,0,b.Length);

        reqObj = null;
        
    }

 



}
