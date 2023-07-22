using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class PeriodeDTO { 
   public Guid Id { get; set; }
    public DateTime DatePlanning { get; set; }
    public string? Type { get; set; }
    public int NbrJ { get; set; }
    public Guid FkPlanning { get; set; }
        //Planning
        public Guid FkUtilisateur { get; set; }
        public string? NomPrenom { get; set; }
        public string? Matricule { get; set; }
        public string? Role { get; set; }
        public Guid FkFonction { get; set; }
        public string? Fonction { get; set; }
        public Guid FkFiliale { get; set; }
        public string? Filiale { get; set; }
        public string? Code { get; set; }
        public string? Secteur { get; set; }

        public string? Audite { get; set; }
        public string? Evaluation { get; set; }
        public int Mois { get; set; }
        public int Annee { get; set; }


    }
}
