using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PATIO.OMEGA.Classes
{
    public class ClasseRapport
    {
        public List<Ligne> Liste = new List<Ligne>();

        public class Ligne
        {
            public string Budget { get; set; }
            public string Recette_AE { get; set; }
            public string Dépense_AE { get; set; }
            public string Recette_CP { get; set; }
            public string Dépense_CP { get; set; }
        }
    }

}
