using System.Text.Json.Serialization;

namespace Domain.Models
{

   
    public class Periode
    {
       
            public Guid Id { get; set; }
            public DateTime DatePlanning { get; set; }
            public string? Type { get; set; }
            public int NbrJ { get; set; }
            public Guid FkPlanning { get; set; }
            [JsonIgnore]
             public FichePlanning? FichePlanning { get; set; }
        

    }
}