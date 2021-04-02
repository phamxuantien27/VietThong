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
    /// Summary description for WebService2
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    static class Connection2
    {
        static string ConnectionString = @"Data Source=DESKTOP-TD6J3OH\SQLEXPRESS;Initial Catalog=HTGiamSat;Integrated Security=True";
        public static SqlConnection conn = new SqlConnection(ConnectionString);
    }
    public class WebService2 : System.Web.Services.WebService
    {

        [WebMethod]
        public DataTable ViTri(string bienso)
        {
            DataTable result = new DataTable("Vitri");
            string strCommand = @"select ThoiGianQua,ViTri.ViTri,Camera.ViTri from Car,NhanDien,Camera,ViTri where Car.BienSo = NhanDien.BienSo and NhanDien.Camera_ID = Camera.ID and ViTri.ID=Camera.ViTri and Car.BienSo='" + bienso + "'";
            SqlCommand command = new SqlCommand(strCommand, Connection.conn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(result);
            adapter.Dispose();
            return result;
        }
    }
}
