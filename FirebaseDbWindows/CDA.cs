using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;
using System.Collections;

/// <summary>
/// Summary description for CDA
/// </summary>
public class CDA
{
    Hashtable connTable = new Hashtable();
    SqlConnection myConnection = null;
    SqlCommand cmd = null;
    SqlDataAdapter adapter = null;
    DataSet ds = null;

    public CDA()
    {
        connTable.Add("WAPDB", "Data Source=192.168.10.21;Initial Catalog=Partner_Basket;User ID=sa;Password=theviggo#11;");

        
    }
    public string RawConnectionStr()
    {
        const string ConStr = "Data Source=192.168.10.17;Initial Catalog=GP_URL_CMS;User ID=sa;Password=theviggo;";
        return ConStr;
    }

    public SqlDataReader getList(string query, string dbName)
    {

        myConnection = new SqlConnection(connTable[dbName].ToString());
        SqlCommand cmd = new SqlCommand(query, myConnection);
        SqlDataReader dr;
        myConnection.Open();
        dr = cmd.ExecuteReader();
        cmd = null;
        return dr;

    }

    public string ExecuteNonQuery(string query, string dbName)
    {
        string rValue;
        myConnection = new SqlConnection(connTable[dbName].ToString());
        try
        {
            cmd = new SqlCommand(query, myConnection);
            myConnection.Open();
            rValue = cmd.ExecuteNonQuery().ToString();
            if (rValue != "-1")
                return rValue;

            //return "OK";
            else throw new Exception();
        }
        catch (Exception ex)
        {
            return ex.Message.ToString();
        }
        finally
        {
            myConnection.Close();
            cmd = null;
            myConnection = null;
            query = null;
        }
    }

    public object getSingleValue(string query, string dbName)
    {
        //setting = ConfigurationManager.ConnectionStrings[dbName];
        myConnection = new SqlConnection(connTable[dbName].ToString());

        try
        {
            cmd = new SqlCommand(query, myConnection);
            myConnection.Open();
            object retValue = cmd.ExecuteScalar();
            return retValue;
        }
        catch (Exception ex)
        {
            return (object)ex.Message.ToString();
        }
        finally
        {
            myConnection.Close();
            cmd = null;
            myConnection = null;
            query = null;
            dbName = null;
        }
    }

    public DataSet GetDataSet(string query, string dbName)
    {

        myConnection = new SqlConnection(connTable[dbName].ToString());

        ds = new DataSet();

        try
        {
            cmd = new SqlCommand(query, myConnection);
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
                return ds;
            else
                return null;

        }
        catch (Exception ex)
        {
            return null;
        }
        finally
        {
            adapter = null;
            cmd = null;
            myConnection = null;
            query = null;
        }
    }
}
