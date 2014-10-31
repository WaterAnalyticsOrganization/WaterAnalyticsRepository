using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace WaterAnalyticsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class WaterAnalytics : IWaterAnalytics
    {

        static string connectionStr = ConfigurationManager.ConnectionStrings["WaterAnalytics"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionStr);

        public int isAuthenticated(int UserId, string password)
        {
            int isAuth;
            SqlCommand command = new SqlCommand("AuthenticateUser", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@UserId", UserId);
            command.Parameters.AddWithValue("@Passwrd", password);
            connection.Open();
            isAuth = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return isAuth;
        }

        public IndAddress getDetails(int sensorId)
        {

            DataTable dt = new DataTable();
            IndAddress obj = new IndAddress();
            SqlCommand command = new SqlCommand("GetDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@sensorid", sensorId);
           connection.Open();
           SqlDataAdapter daDetails = new SqlDataAdapter(command);
            daDetails.Fill(dt);

           if (dt.Rows.Count > 0)
           {
               obj.Name = Convert.ToString(dt.Rows[0]["Ind_Name"]);
               obj.LocationName = Convert.ToString(dt.Rows[0]["Location_Name"]);
               obj.Description = Convert.ToString(dt.Rows[0]["Local_Desc"]);
               obj.Email = Convert.ToString(dt.Rows[0]["Email"]);
               obj.NoOfPeople = Convert.ToInt16(dt.Rows[0]["NoOfPeople"]);
            }
           
            connection.Close();
            return obj;
         }

        public int UpdateDetails(int UserID,string Name,string email,int noOfPeople)
        {
            int result;
            DataTable dt = new DataTable();
            IndAddress obj = new IndAddress();
            SqlCommand command = new SqlCommand("UpdateDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@IndName", Name);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@NoOfPeople", noOfPeople);
            connection.Open();
            result = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return result;                 
        }

        public List<WaterQuant> getWaterQuantByUserId(int UserID, int ind, DateTime from, DateTime to)
        {
            DataTable dt = new DataTable();
            IndAddress obj = new IndAddress();
            SqlCommand command = new SqlCommand("GetWaterQuantByUser", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@indicator", ind);
            command.Parameters.AddWithValue("@starttime", from);
            command.Parameters.AddWithValue("@endtime", to);

            connection.Open();
            SqlDataAdapter daDetails = new SqlDataAdapter(command);
            daDetails.Fill(dt);

            List<WaterQuant> myList = (List<WaterQuant>)DataFiller.ConvertTo<WaterQuant>(dt);

            return myList;
        }

        public List<WaterQuantLocation> getWaterQuantByLocation(string Location, int ind, DateTime from, DateTime to)
        {
            DataTable dt = new DataTable();
            IndAddress obj = new IndAddress();
            SqlCommand command = new SqlCommand("GetWaterQuantByLocation", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Location", Location);
            command.Parameters.AddWithValue("@indicator", ind);
            command.Parameters.AddWithValue("@starttime", from);
            command.Parameters.AddWithValue("@endtime", to);

            connection.Open();
            SqlDataAdapter daDetails = new SqlDataAdapter(command);
            daDetails.Fill(dt);

            List<WaterQuantLocation> myList = (List<WaterQuantLocation>)DataFiller.ConvertTo<WaterQuantLocation>(dt);

            return myList;
        }


        public List<WaterQuant> getWaterQuantPerPerson(int UserId, int ind, DateTime from, DateTime to)
        {
            DataTable dt = new DataTable();
            IndAddress obj = new IndAddress();
            SqlCommand command = new SqlCommand("GetWaterQuantperPersonByUser", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@UserID", UserId);
            command.Parameters.AddWithValue("@indicator", ind);
            command.Parameters.AddWithValue("@starttime", from);
            command.Parameters.AddWithValue("@endtime", to);

            connection.Open();
            SqlDataAdapter daDetails = new SqlDataAdapter(command);
            daDetails.Fill(dt);

            List<WaterQuant> myList = (List<WaterQuant>)DataFiller.ConvertTo<WaterQuant>(dt);

            return myList;
        }
       
       
    }
}
