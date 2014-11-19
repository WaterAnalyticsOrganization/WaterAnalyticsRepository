using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Collections.ObjectModel;

namespace WaterAnalyticsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IWaterAnalytics
    {

        [OperationContract]
        int IsAuthenticated(int userId,string password);       

        [OperationContract]
        List<WaterQuant> GetWaterQuantByUserId(int UserID, int ind, DateTime from, DateTime To);

        [OperationContract]
        List<WaterQuantLocation> GetWaterQuantByLocation(string Location, int ind, DateTime from, DateTime to);

        [OperationContract]
        List<WaterQuant> GetWaterQuantPerPerson(int UserID, int ind, DateTime from, DateTime to);

        [OperationContract]
        List<LocationDetails> GetAllLocation();

        [OperationContract]
        List<WaterQuantLocation> GetWaterQuantPerPersonArea(string Area, int ind, DateTime from, DateTime to);

        [OperationContract]
        int UpdateDetails(int UserID, string Name, string email, int noOfPeople);

        [OperationContract]
        IndividualAddress GetDetails(int sensorId);

         [OperationContract]
        List<ZoneDetails> GetDataByZone(DateTime from, DateTime to);

         [OperationContract]
         List<GroundWaterDetail> GetGroundWaterByLocation(string Location, int from, int to);

         [OperationContract]
         List<AlertObject> GetDefaultedUsers(string Location, DateTime from, DateTime to);

         [OperationContract]
         Decimal GetWaterLimit();

         [OperationContract]
         int UpdateWaterLimit(Decimal limit);
    }

    [DataContract]
    public class AlertObject
    {       
        int userId;
        string name;
        string locationName;       
        int defaultedCount;

        [DataMember]
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string LocationName
        {
            get { return locationName; }
            set { locationName = value; }
        }       

        [DataMember]
        public int DefaultedCount
        {
            get { return defaultedCount; }
            set { defaultedCount = value; }
        }
    }

    [DataContract]
    public class ConfigEntry
    {
        int  configID;
        Decimal quantity;
        String insertUser;
        DateTime insertTime;       

        [DataMember]
        public int ConfigID
        {
            get { return configID; }
            set { configID = value; }
        }

        [DataMember]
        public Decimal Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        [DataMember]
        public String InsertUser
        {
            get { return insertUser; }
            set { insertUser = value; }
        }

        [DataMember]
        public DateTime InsertTime
        {
            get { return insertTime; }
            set { insertTime = value; }
        }

    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class IndividualAddress
    {
        string sensorId;
        string name;
        string locationName;
        string localDesc;
        int noOfPeople;
        string email;

        [DataMember]
        public string SensorId
        {
            get { return sensorId; }
            set { sensorId = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string LocationName
        {
            get { return locationName; }
            set { locationName = value; }
        }

        [DataMember]
        public string Description
        {
            get { return localDesc; }
            set { localDesc = value; }
        }

        [DataMember]
        public int NoOfPeople
        {
            get { return noOfPeople; }
            set { noOfPeople = value; }
        }

        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }

    [DataContract]
    public class WaterQuant
    {
        DateTime stime;
        int userId;
        decimal quantity;

        [DataMember]
        public DateTime Stime
        {
            get { return stime; }
            set { stime = value; }
        }

        [DataMember]
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        [DataMember]
        public decimal Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
    }

    [DataContract]
    public class WaterQuantLocation
    {
        DateTime stime;
        string locationName;
        decimal quantity;

        [DataMember]
        public DateTime Stime
        {
            get { return stime; }
            set { stime = value; }
        }

        [DataMember]
        public string LocationName
        {
            get { return locationName; }
            set { locationName = value; }
        }

        [DataMember]
        public decimal Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
    }

    [DataContract]
    public class LocationDetails
    {
       int locationid;
       string locationName;

        [DataMember]
        public int Location_Id
        {
            get { return locationid; }
            set { locationid = value; }
        }

        [DataMember]
        public string Location_name
        {
            get { return locationName; }
            set { locationName = value; }
        }
     }

    [DataContract]
    public class GroundWaterDetail
    {

        DateTime stime;
        string locationName;
        decimal quantity;

        [DataMember]
        public DateTime Stime
        {
            get { return stime; }
            set { stime = value; }
        }

        [DataMember]
        public string Location_name
        {
            get { return locationName; }
            set { locationName = value; }
        }

        [DataMember]
        public decimal Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
    }

    [DataContract]
    public class ZoneDetails
    {
        string region;
        decimal quantity;

        [DataMember]
        public string Region
        {
            get { return region; }
            set { region = value; }
        }
       
        [DataMember]
        public decimal Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
    }

}
