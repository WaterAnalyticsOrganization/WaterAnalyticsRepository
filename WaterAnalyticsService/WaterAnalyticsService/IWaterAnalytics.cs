using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WaterAnalyticsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IWaterAnalytics
    {

        [OperationContract]
        int isAuthenticated(int userId,string password);

        //[OperationContract]
        //WaterQuant getWaterQuant(string stime, DateTime from, DateTime to);

        [OperationContract]
        List<WaterQuant> getWaterQuantByUserId(int UserID, int ind, DateTime from, DateTime to);

        [OperationContract]
        List<WaterQuantLocation> getWaterQuantByLocation(string Location, int ind, DateTime from, DateTime to);

        [OperationContract]
        List<WaterQuant> getWaterQuantPerPerson(int UserID, int ind, DateTime from, DateTime to);

        [OperationContract]
        List<LocationDetails> getAllLocation();
        
        //[OperationContract]
        //WaterQuant getWaterQuantPerPersonArea(string Area, string stime, DateTime from, DateTime to);

        [OperationContract]
        int UpdateDetails(int UserID, string Name, string email, int noOfPeople);

        [OperationContract]
        IndAddress getDetails(int sensorId);
        
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class IndAddress
    {
        string sensorID;
        string name;
        string locationName;
        string localDesc;
        int noOfPeople;
        string email;

        [DataMember]
        public string SensorID
        {
            get { return sensorID; }
            set { sensorID = value; }
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

}
