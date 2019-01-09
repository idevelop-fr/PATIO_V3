using System;
using PATIO.MAIN.Classes;
using System.Windows.Forms;

namespace PATIO.OMEGA.Classes
{
    public class Budget_Periode : Classe_Modele, IComparable<Budget_Periode>
    {
        public TypePeriode TypePeriode { get; set; }
        public string DateDeb { get; set; }
        public string DateFin { get; set; }

        public Budget_Periode()
        {
            ListeAttribut = new string[] {"DATE_DEB", "DATE_FIN"
                                        };
        }

        public override bool Construire(Element e)
        {
            ID = e.ID;
            Code = e.Code;
            Libelle = e.Libelle.Replace("''", "'");
            Element_Type = e.Element_Type;
            Type_Element = e.Type_Element;
            Actif = e.Actif;

            foreach (dElement d in e.Liste)
            {
                if (d.Element_ID == ID)
                {
                    if (d.Attribut_Code == "DATE_DEB") { DateDeb = d.Valeur; }
                    if (d.Attribut_Code == "DATE_FIN") { DateFin = d.Valeur; }
                }
            }

            return true;
        }

        //Transforme un groupe sous la forme Element, dElement
        public override Element Déconstruire()
        {
            TypeElement type = Acces.type_BUDGET_PERIODE;

            Element e = new Element();
            dElement d;
            string CodeAttribut = "";

            e.ID = ID;
            e.Code = Code;
            e.Libelle = Libelle;
            e.Element_Type = type.ID;
            e.Type_Element = (int) TypePeriode ;
            e.Actif = Actif;

            //Date deb
            {
                CodeAttribut = "DATE_DEB";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, DateDeb);
                e.Liste.Add(d);
            }

            //Date Fin
            {
                CodeAttribut = "DATE_FIN";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, DateFin);
                e.Liste.Add(d);
            }

            return e;
        }

        //Comparateur par défaut
        public int CompareTo(Budget_Periode p)
        {
            if (p is null) { return 1; }
            else { return (this.Code.CompareTo(p.Code)); }
        }
    }
}
