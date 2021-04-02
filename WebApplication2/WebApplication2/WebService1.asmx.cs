using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication2
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    static class Connection
    {
        static string ConnectionString = @"Data Source=DESKTOP-TD6J3OH\SQLEXPRESS;Initial Catalog=HTGiamSat;Integrated Security=True";
        public static SqlConnection conn = new SqlConnection(ConnectionString);
    }
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        //public string HelloWorld()
        //{
        //    return "Hello World";
        //}
        public DataTable Camera(string ID)
        {
            DataTable result = new DataTable("sinhvien");
            string strCommand = @"select NhanDien.BienSo from Camera,NhanDien where Camera.ID=NhanDien.Camera_ID and Camera.ID='" + ID + "'";
            SqlCommand command = new SqlCommand(strCommand, Connection.conn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(result);
            adapter.Dispose();
            return result;
        }
        
    }
}
