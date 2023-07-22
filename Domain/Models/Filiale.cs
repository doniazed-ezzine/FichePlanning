using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Models
{
    public class Filiale
    {
        public Guid Id { get; set; }
        public string? Label { get; set; }
        public string? Code { get; set; }
        public string? Secteur { get; set; }

        
        public ICollection<FichePlanning>? FichePlannings { get; set; }
    }
 







}
