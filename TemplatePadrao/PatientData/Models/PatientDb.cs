using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientData.Models
{
    // Slide 96.2
    public class PatientDb
    {
        public static IMongoCollection<Patient> Open() {
            var client = new MongoClient("mongodb://localhost");
            var db = client.GetDatabase("PatientDB");
            return db.GetCollection<Patient>("Patients");
        }
    }
}