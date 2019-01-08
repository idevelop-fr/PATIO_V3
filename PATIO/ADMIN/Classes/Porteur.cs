using System;
using PATIO.MAIN.Classes;

namespace PATIO.ADMIN.Classes
{
    public class Porteur : Classe_Modele, IComparable<Porteur>
    {
        public int TypePorteur { get; set; }
        public String SIREN { get; set; }
        public String SIRET { get; set; }
        public String Mail { get; set; }

        public Porteur()
        {
            ListeAttribut = new string[] {"SIREN", "SIRET", "MAIL", };
        }

        //Construit l'utilisateur à partir des informations de l'élément
        public override bool Construire(Element e)
        {
            ID = e.ID;
            Code = e.Code;
            Libelle = e.Libelle.Replace("'''", "'");
            TypePorteur = e.Type_Element;
            Actif = e.Actif;

            foreach (dElement d in e.Liste)
            {
                d.Valeur = d.Valeur.Replace("'''", "'");
                if (d.Attribut_Code == "SIREN") { SIREN = d.Valeur; }
                if (d.Attribut_Code == "SIRET") { SIRET = d.Valeur; }
                if (d.Attribut_Code == "MAIL") { Mail = d.Valeur; }
            }

            return true;
        }

        //Transforme un utilisateur sous la forme Element, dElement
        public override Element Déconstruire()
        {
            Element e = new Element();
            dElement d;
            TypeElement type = Acces.type_PORTEUR;

            e.ID = ID;
            e.Element_Type = type.ID;
            e.Code = Code;
            e.Libelle = Libelle;
            e.Type_Element = TypePorteur;
            e.Actif = Actif;

            string CodeAttribut = "";
            if (SIREN.Length > 0)
            {
                CodeAttribut = "SIREN";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, SIREN);
                e.Liste.Add(d);
            }

            {
                CodeAttribut = "SIRET";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, SIRET);
                e.Liste.Add(d);
            }

            if (Mail.Length > 0)
            {
                CodeAttribut = "MAIL";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, Mail);
                e.Liste.Add(d);
            }

            return e;
        }

        //Comparateur par défaut
        public int CompareTo(Porteur p)
        {
            if (p is null) { return 1; }
            else { return (this.Libelle.CompareTo(p.Libelle)); }
        }
    }
}
