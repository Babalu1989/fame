using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Text;

public class NDS
{
    public static string str = "";
    public NDS()
    {
        
    }
    public static bool IsNumeric(object value)
    {
        try
        {
            Double i = Convert.ToDouble(value.ToString());
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }  
   
    public static void ClearControls(Control control)
    {
        for (int i = control.Controls.Count - 1; i >= 0; i--)
        {
            ClearControls(control.Controls[i]);
        }

        if (!(control is TableCell))
        {
            if (control.GetType().GetProperty("SelectedItem") != null)
            {
                LiteralControl literal = new LiteralControl();
                control.Parent.Controls.Add(literal);
                try
                {
                    literal.Text = (string)control.GetType().GetProperty("SelectedItem").GetValue(control, null);
                }
                catch
                {
                }
                control.Parent.Controls.Remove(control);
            }
            else
                if (control.GetType().GetProperty("Text") != null)
                {
                    LiteralControl literal = new LiteralControl();
                    control.Parent.Controls.Add(literal);
                    literal.Text = (string)control.GetType().GetProperty("Text").GetValue(control, null);
                    control.Parent.Controls.Remove(control);
                }
        }
        return;
    }

    public static string conn()
    {

        string database = "";
        string user_id = "";
        string pass = "";

        Cryptograph crp = new Cryptograph();
        HttpServerUtility myServer = HttpContext.Current.Server;

        //string vs = myServer.MapPath("IT-OPR.ini");
        string vs = AppDomain.CurrentDomain.BaseDirectory + "PRM.ini";


        // ASSING KEY TO CONNECT DATABASE.

        string PW_KEY = "@!*fdfsfd+}|@";  // Enter Key Below Function Also...


        user_id = crp.Decrypt(NDSINI.GetINI(vs, "IMSPRM", crp.Encrypt("dbuserid", PW_KEY), "?"), PW_KEY);
        pass = crp.Decrypt(NDSINI.GetINI(vs, "IMSPRM", crp.Encrypt("dbuserpwd", PW_KEY), "?"), PW_KEY);
        database = crp.Decrypt(NDSINI.GetINI(vs, "IMSPRM", crp.Encrypt("dbconn", PW_KEY), "?"), PW_KEY);// Put user code to initialize the page here

        string str = "Provider=MSDAORA.1; User ID=" + user_id + "; Password=" + pass + "; Data Source=" + database + ";";
        return str;
    }
}




