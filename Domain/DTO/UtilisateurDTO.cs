using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class UtilisateurDTO
    {
        public Guid Id { get; set; }
        public string? NomPrenom { get; set; }
        public string? Matricule { get; set; }
        public bool IsActif { get; set; }
        public string? Role { get; set; }

        public Guid FkFonction { get; set; }
        public string? Fonction { get; set; }
    }
    }
