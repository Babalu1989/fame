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
using System.Security.Cryptography;
using System.Text;

public partial class frmdoenload : System.Web.UI.Page
{
    public static string nas_ip = "\\" + "\\10.125.65.127\\prm";
    //public static string nas_ip =  "\\10.125.65.127\\upload";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TextBox1.Text = Request.Params[0].ToString();
            deleteOldFiles();
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.close()</script>");
    }
    void deleteOldFiles()
    {
        string sl = "";
        sl = Server.MapPath("Dtdocs");
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(TextBox1.Text.Trim()))
        {
            string abcd = "<script>alert('No File to Download');</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "abc", abcd);
            return;
        }
        if (string.IsNullOrEmpty(txtpassword.Text.Trim()))
        {
            string abcd = "<script>alert('Enter password to decrypt file');</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "abc", abcd);
            txtpassword.Focus();
            return;
        }
        string sl = "";
        string outfile = TextBox1.Text.Trim()+".cry";
        sl = Server.MapPath("Dtdocs\\");
        if (File.Exists(sl + outfile))
        {
            File.Delete(sl + outfile);
            File.Copy(nas_ip + "\\depts\\" + Request.Params[1].ToString() + "\\" + outfile, sl + outfile);
        }
        else
        {
            File.Copy(nas_ip + "\\depts\\" + Request.Params[1].ToString() + "\\" + outfile, sl + outfile);
        }
        sl = sl + outfile;
        DecryptFile(txtpassword.Text, nas_ip + "\\depts\\" + Request.Params[1].ToString() + "\\" + outfile, sl, TextBox1.Text);
    }
    private void DecryptFile(string password,string originalpath, string serverpath,string f_name)
    {
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

            FileStream fsCrypt = new FileStream(originalpath, FileMode.Open);

            RijndaelManaged RMCrypto = new RijndaelManaged();

            CryptoStream cs = new CryptoStream(fsCrypt,
                RMCrypto.CreateDecryptor(key, key),
                CryptoStreamMode.Read);

            FileStream fsOut = new FileStream(serverpath.Substring(0,serverpath.Length-4), FileMode.Create);

            int data;
            while ((data = cs.ReadByte()) != -1)
                fsOut.WriteByte((byte)data);

            fsOut.Close();
            cs.Close();
            fsCrypt.Close();
            fsOut.Dispose();
            cs.Dispose();
            fsCrypt.Dispose();

            FileStream livestream = new FileStream(serverpath.Substring(0, serverpath.Length - 4), FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[(int)livestream.Length];
            livestream.Read(buffer, 0, (int)livestream.Length);
            livestream.Close();
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Length", buffer.Length.ToString());
            Response.AddHeader("Content-Disposition", "attachment; filename=" + f_name.ToString());
            Response.BinaryWrite(buffer);
            Response.End();
            Response.Clear();
            Response.End();          

            
        }
        catch(Exception ex)
        {
            Response.Write(serverpath.Substring(0, serverpath.Length - 4) + ex.Message);
        }
    }
}
