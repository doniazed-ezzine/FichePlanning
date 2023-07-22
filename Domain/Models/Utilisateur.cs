using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class Utilisateur
    {
        public Guid Id { get; set; }
        public string? NomPrenom { get; set; }
        public string? Matricule { get; set; }
        public bool IsActif { get; set; }
        public string? Role { get; set; }

        public Guid FkFonction { get; set; }
        [JsonIgnore]
        public Fonction? Fonction { get; set; }
        [JsonIgnore]
        public ICollection<FichePlanning>? FichePlannings { get; set; }
    }
}