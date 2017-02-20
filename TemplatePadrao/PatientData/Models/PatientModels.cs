using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace PatientData.Models
{ 
    // Slide 96.2
    public class Patient
    {
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }
        public ICollection<Medication> Medications { get; set; }
        public ICollection<Ailment> Ailments { get; set; }

    }

    public class Medication {
        public int Doses { get; set; }
        public string Name { get; set; }
    }

    public class Ailment
    {
        public string Name { get; set; }
    }
}