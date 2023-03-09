using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;

/// <summary>
/// Summary description for DbFunction
/// </summary>
/// 
namespace  USEPMS
{
    public class DbFunction
    {

        static OleDbConnection ocon = new OleDbConnection(NDS.conn());
        OleDbTransaction dbtrans;
        OleDbCommand dbcommand ;
        OleDbDataAdapter da;
        DataSet ds;
        DataTable dt;
        public DbFunction()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        //For Begin a Transaction
        public void dbbegintrans()
        {
            if (ocon.State == ConnectionState.Closed)
            {
                ocon.Open();
            }
            dbtrans = ocon.BeginTransaction();
        }

        //For Transaction Commit
        public void dbcommittrans()
        {
            try
            {
                if (ocon.State == ConnectionState.Closed)
                {
                    ocon.Open();
                }
                dbtrans.Commit();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }
        //for transaction rollback
        public void dbrollback()
        {
            try
            {
                if (ocon.State == ConnectionState.Closed)
                {
                    ocon.Open();
                }
                dbtrans.Rollback();
            }
            finally
            {
                if (ocon.State == ConnectionState.Open)
                {
                    ocon.Close();

                }
            }
        }
        public DataTable dmlgetquery(string sql)
        {

            try
            {
                if (ocon.State == ConnectionState.Closed)
                {
                    ocon.Open();

                }
                dbcommand = new OleDbCommand();
                dbcommand.Connection = ocon;
                da = new OleDbDataAdapter();
                da.SelectCommand = dbcommand;
                dt = null;
                dt = new DataTable();
                dbcommand.CommandType = CommandType.Text;
                dbcommand.CommandText = sql;
                dbcommand.Transaction = dbtrans;
                da.Fill(dt);

                return dt;
            }
            finally
            {
                if (ocon.State == ConnectionState.Open)
                {
                    ocon.Close();

                }
            }
        }
        public bool dmlsinglequery(string sql)
        {
            try
            {
               if (ocon.State == ConnectionState.Closed)
               {
                    ocon.Open();
               }
                dbcommand = new OleDbCommand(sql, ocon);
                dbcommand.Transaction = dbtrans;
                dbcommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
