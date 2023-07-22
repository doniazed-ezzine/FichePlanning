using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Fonction
    {
        public Guid Id { get; set; }
        public string? Label { get; set; }

        public ICollection<Utilisateur>? Utilisateurs { get; set; }
        
    }
}
