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
using System.Collections.ObjectModel;

[assembly: CLSCompliant(true)]
namespace WaterAnalyticsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class WaterAnalytics : IWaterAnalytics,IDisposable
    {

        #region Private Properties

        static string connectionStr = ConfigurationManager.ConnectionStrings["WaterAnalytics"].ConnectionString;
        SqlConnection connection = null;
        SqlCommand command = null;
        int isAuth=0;
        DataTable dt = null;
        IndividualAddress obj = null;
        SqlDataAdapter daDetails = null;
        int result=0;
        Collection<WaterQuant> myList = null;
        Collection<WaterQuantLocation> waterQuantLocationList = null;
        Collection<LocationDetails> locationDetailsList = null;
        Collection<GroundWaterDetail> groundWaterList = null;
        Collection<ZoneDetails> zoneDetailsList = null;

        #endregion

        #region Service Method Implementation

        /// <summary>
        /// Function to check if the user is authenticated
        /// </summary>
        /// <param name="UserId">User id entered in ui</param>
        /// <param name="password">Password entered in ui</param>
        /// <returns>Returns 1 for Individual, 2 for Govt and 0 if its not Authenticated</returns>
        public int IsAuthenticated(int UserId, string password)
        {             
            try
            {
                connection = new SqlConnection(connectionStr);
                command = new SqlCommand("AuthenticateUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserId", UserId);
                command.Parameters.AddWithValue("@Passwrd", password);
                connection.Open();
                isAuth = Convert.ToInt32(command.ExecuteScalar());
            }
            catch(Exception ex)
            {
                throw new FaultException("Error in authentication: "+ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return isAuth;
        }

        /// <summary>
        /// Function to get user profile data
        /// </summary>
        /// <param name="sensorId">sensor id for the logged in user</param>
        /// <returns>User Profile data</returns>
        public IndividualAddress GetDetails(int sensorId)
        {
            try
            {
                dt = new DataTable();
                obj = new IndividualAddress();
                command = new SqlCommand("GetDetails", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@sensorid", sensorId);
                connection.Open();
                daDetails = new SqlDataAdapter(command);
                daDetails.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    obj.Name = Convert.ToString(dt.Rows[0]["Ind_Name"]);
                    obj.LocationName = Convert.ToString(dt.Rows[0]["Location_Name"]);
                    obj.Description = Convert.ToString(dt.Rows[0]["Local_Desc"]);
                    obj.Email = Convert.ToString(dt.Rows[0]["Email"]);
                    obj.NoOfPeople = Convert.ToInt16(dt.Rows[0]["NoOfPeople"]);
                }
            }
            catch (Exception ex)
            {
                throw new FaultException("Error in getting details: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return obj;
         }

        /// <summary>
        /// Function to update user profile data
        /// </summary>
        /// <param name="UserID">user id to be updated</param>
        /// <param name="Name">name to be updated</param>
        /// <param name="email">email to be updated</param>
        /// <param name="noOfPeople">noOfPeople to be updated</param>
        /// <returns></returns>
        public int UpdateDetails(int UserID,string Name,string email,int noOfPeople)
        {
            try
            {
                dt = new DataTable();
                command = new SqlCommand("UpdateDetails", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserID", UserID);
                command.Parameters.AddWithValue("@IndName", Name);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@NoOfPeople", noOfPeople);
                connection.Open();
                result = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new FaultException("Error in updating details: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return result;                 
        }

        /// <summary>
        /// Function to get water quantity by user id
        /// </summary>
        /// <param name="UserID">user id for which water quantity is requested</param>
        /// <param name="ind">0=Hourly, 1=Daily, 2=Weekly, 3=Monthly, 4=Yearly</param>
        /// <param name="from">From Date</param>
        /// <param name="to">To Date</param>
        /// <returns></returns>
        public Collection<WaterQuant> GetWaterQuantByUserId(int UserID, int ind, DateTime from, DateTime To)
        {
            try
            {
                dt = new DataTable();
                command = new SqlCommand("GetWaterQuantByUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserID", UserID);
                command.Parameters.AddWithValue("@indicator", ind);
                command.Parameters.AddWithValue("@starttime", from);
                command.Parameters.AddWithValue("@endtime", To);
                connection.Open();
                daDetails = new SqlDataAdapter(command);
                daDetails.Fill(dt);
                myList = (Collection<WaterQuant>)DataFiller.ConvertTo<WaterQuant>(dt);
            }
            catch (Exception ex)
            {
                throw new FaultException("Error in getting water quantity by user id: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return myList;
        }

        /// <summary>
        /// Function to get water quantity by location
        /// </summary>
        /// <param name="Location">Selected location</param>
        /// <param name="ind">0=Hourly, 1=Daily, 2=Weekly, 3=Monthly, 4=Yearly</param>
        /// <param name="from">From Date</param>
        /// <param name="to">To Date</param>
        /// <returns></returns>
        public Collection<WaterQuantLocation> GetWaterQuantByLocation(string Location, int ind, DateTime from, DateTime to)
        {
            try
            {
                dt = new DataTable();
                command = new SqlCommand("GetWaterQuantByLocation", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Location", Location);
                command.Parameters.AddWithValue("@indicator", ind);
                command.Parameters.AddWithValue("@starttime", from);
                command.Parameters.AddWithValue("@endtime", to);

                connection.Open();
                daDetails = new SqlDataAdapter(command);
                daDetails.Fill(dt);

                waterQuantLocationList = (Collection<WaterQuantLocation>)DataFiller.ConvertTo<WaterQuantLocation>(dt);
            }
            catch (Exception ex)
            {
                throw new FaultException("Error in getting water quantity by location: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return waterQuantLocationList;
        }

        /// <summary>
        /// Function to get water quant per person
        /// </summary>
        /// <param name="UserId">user id selected</param>
        /// <param name="ind">0=Hourly, 1=Daily, 2=Weekly, 3=Monthly, 4=Yearly</param>
        /// <param name="from">From Date</param>
        /// <param name="to">To Date</param>
        /// <returns></returns>
        public Collection<WaterQuant> GetWaterQuantPerPerson(int UserID, int ind, DateTime from, DateTime to)
        {
            try
            {
                dt = new DataTable();
                command = new SqlCommand("GetWaterQuantperPersonByUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserID", UserID);
                command.Parameters.AddWithValue("@indicator", ind);
                command.Parameters.AddWithValue("@starttime", from);
                command.Parameters.AddWithValue("@endtime", to);

                connection.Open();
                SqlDataAdapter daDetails = new SqlDataAdapter(command);
                daDetails.Fill(dt);

                myList = (Collection<WaterQuant>)DataFiller.ConvertTo<WaterQuant>(dt);

            }
            catch (Exception ex)
            {
                throw new FaultException("Error in getting water quantity per person: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return myList;
        }

        /// <summary>
        /// Function to get all locations
        /// </summary>
        /// <returns></returns>
        public Collection<LocationDetails> GetAllLocation()
        {
            try
            {
                dt = new DataTable();
                obj = new IndividualAddress();
                command = new SqlCommand("GetAllLocation", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                daDetails = new SqlDataAdapter(command);
                daDetails.Fill(dt);

                locationDetailsList = (Collection<LocationDetails>)DataFiller.ConvertTo<LocationDetails>(dt);

            }
            catch (Exception ex)
            {
                throw new FaultException("Error in getting all locations: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return locationDetailsList;
        }

        /// <summary>
        /// Fucntion to get water quantity per person for a specific location
        /// </summary>
        /// <param name="Location">Location selected</param>
       /// <param name="ind">0=Hourly, 1=Daily, 2=Weekly, 3=Monthly, 4=Yearly</param>
        /// <param name="from">From Date</param>
        /// <param name="to">To Date</param>
        /// <returns>Water quantity list</returns>
        public Collection<WaterQuantLocation> GetWaterQuantPerPersonArea(string Location, int ind, DateTime from, DateTime to)
       {
           try
           {
               dt = new DataTable();
               command = new SqlCommand("GetWaterQuantByLocationPerPerson", connection);
               command.CommandType = CommandType.StoredProcedure;
               command.Parameters.AddWithValue("@Location", Location);
               command.Parameters.AddWithValue("@indicator", ind);
               command.Parameters.AddWithValue("@starttime", from);
               command.Parameters.AddWithValue("@endtime", to);

               connection.Open();
               daDetails = new SqlDataAdapter(command);
               daDetails.Fill(dt);

               waterQuantLocationList = (Collection<WaterQuantLocation>)DataFiller.ConvertTo<WaterQuantLocation>(dt);
           }
           catch (Exception ex)
           {
               throw new FaultException("Error in getting water quantity per person for a specific location: " + ex.Message);
           }
           finally
           {
               connection.Close();
           }
           return waterQuantLocationList;
       }

        /// <summary>
        /// Function to get ground water by location
        /// </summary>
        /// <param name="Location">Location selected</param>
        /// <param name="from">From Date</param>
        /// <param name="to">To Date</param>
        /// <returns></returns>
        public Collection<GroundWaterDetail> GetGroundWaterByLocation(string Location, int from, int to)
       {
           try
           {
               dt = new DataTable();
               command = new SqlCommand("GetGroundWaterByLocation", connection);
               command.CommandType = CommandType.StoredProcedure;
               command.Parameters.AddWithValue("@Location", Location);
               command.Parameters.AddWithValue("@starttime", from);
               command.Parameters.AddWithValue("@endtime", to);

               connection.Open();
               daDetails = new SqlDataAdapter(command);
               daDetails.Fill(dt);

               groundWaterList = (Collection<GroundWaterDetail>)DataFiller.ConvertTo<GroundWaterDetail>(dt);
           }
           catch (Exception ex)
           {
               throw new FaultException("Error in getting ground water by location: " + ex.Message);
           }
           finally
           {
               connection.Close();
           }
           return groundWaterList;
       }

        /// <summary>
        /// Function to get data by zone for pie chart
        /// </summary>
        /// <param name="from">From Date</param>
        /// <param name="to">To Date</param>
        /// <returns></returns>
        public Collection<ZoneDetails> GetDataByZone(DateTime from, DateTime to)
       {
           try
           {
               dt = new DataTable();
               command = new SqlCommand("GetDataByZone", connection);
               command.CommandType = CommandType.StoredProcedure;
               command.Parameters.AddWithValue("@stime", from);
               command.Parameters.AddWithValue("@etime", to);

               connection.Open();
               daDetails = new SqlDataAdapter(command);
               daDetails.Fill(dt);

               zoneDetailsList = (Collection<ZoneDetails>)DataFiller.ConvertTo<ZoneDetails>(dt);

           }
           catch (Exception ex)
           {
               throw new FaultException("Error in getting data by zone for pie chart: " + ex.Message);
           }
           finally
           {
               connection.Close();
           }
           return zoneDetailsList;
       }

        #endregion

        #region IDisposable Methods

        protected virtual void Dispose(bool disposing)
       {
           if (disposing)
           {               
               connection.Close();
               daDetails.Dispose();
               dt.Dispose();
               command.Dispose();
           }           
       }

       public void Dispose()
       {
           Dispose(true);
           GC.SuppressFinalize(this);
       }

        #endregion

    }
}
