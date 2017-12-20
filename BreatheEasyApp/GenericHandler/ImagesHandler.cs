//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data;
//using System.Data.SqlClient;
//using System.IO;
//using System.Linq;
//using System.Web;

//namespace BreatheEasyApp.GenericHandler
//{
//    public class ImagesHandler : IHttpHandler
//    {
//        public void ProcessRequest(HttpContext context)
//        {
//            Int32 empno;
//            if (context.Request.QueryString["id"] != null)
//                empno = Convert.ToInt32(context.Request.QueryString["id"]);
//            else
//                throw new ArgumentException("No parameter specified");

//            context.Response.ContentType = "image/png";
//            Stream strm = GetImage(empno);
//            byte[] buffer = new byte[4096];
//            int byteSeq = strm.Read(buffer, 0, 4096);

//            while (byteSeq > 0)
//            {
//                context.Response.OutputStream.Write(buffer, 0, byteSeq);
//                byteSeq = strm.Read(buffer, 0, 4096);
//            }
//        }

//        public Stream GetImage(int id)
//        {
//            string conn = ConfigurationManager.ConnectionStrings["Data Source=DESKTOP-UK9JTFR;Initial Catalog=BreatheEasy;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework"].ConnectionString;
//            SqlConnection connection = new SqlConnection(conn);
//            string sql = "SELECT Image FROM Image WHERE ImageID = @ID";
//            SqlCommand cmd = new SqlCommand(sql, connection);
//            cmd.CommandType = CommandType.Text;
//            cmd.Parameters.AddWithValue("@ID", id);
//            connection.Open();
//            object img = cmd.ExecuteScalar();
//            try
//            {
//                return new MemoryStream((byte[])img);
//            }
//            catch
//            {
//                return null;
//            }
//            finally
//            {
//                connection.Close();
//            }
//        }

//        public bool IsReusable
//        {
//            get
//            {
//                return false;
//            }
//        }
//    }
//}