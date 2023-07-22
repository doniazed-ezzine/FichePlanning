using System.Text.Json.Serialization;

namespace Domain.Models
{


    public class FichePlanning
    {
        public Guid  Id { get; set; }
        public string? Audite { get; set; }
        public string? Evaluation { get; set; }

        public bool IsActif { get; set; }
        public Guid FkFiliale { get; set; }
        [JsonIgnore]
        public Filiale? Filiale { get; set; }

        public Guid FkUtilisateur { get; set; }
        [JsonIgnore]
        public Utilisateur? Utilisateur { get; set; }
        

        public ICollection<Periode>? Periodes { get; set; }
    }

}