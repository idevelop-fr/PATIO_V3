using System;
using PATIO.MAIN.Classes;
using System.Windows.Forms;

namespace PATIO.OMEGA.Classes
{
    public class Budget_Enveloppe : Classe_Modele, IComparable<Budget_Enveloppe>
    {
        public TypeEnveloppe TypeEnveloppe { get; set; }

        public Budget_Enveloppe()
        {
            ListeAttribut = new string[] { };
        }

        public override bool Construire(Element e)
        {
            ID = e.ID;
            Code = e.Code;
            Libelle = e.Libelle.Replace("''", "'");
            Element_Type = e.Element_Type;
            Type_Element =e.Type_Element;
            Actif = e.Actif;

            /*foreach (dElement d in e.Liste)
            {
                if (d.Element_ID == ID)
                {
                    if (d.Attribut_Code == "BUDGET_ID") { Budget_ID = int.Parse(d.Valeur); }
                    if (d.Attribut_Code == "PERIODE") { Periode = int.Parse(d.Valeur); }
                    if (d.Attribut_Code == "DATE_DEB") { DateDeb = d.Valeur; }
                    if (d.Attribut_Code == "DATE_FIN") { DateFin = d.Valeur; }
                    if (d.Attribut_Code == "VERSION_TRAVAIL") { VersionTravail = (d.Valeur == "1"); }
                    if (d.Attribut_Code == "STATUT_REFERENCE") {Statut_Reference = (d.Valeur == "1"); }
                }
            }*/

            return true;
        }

        //Transforme un groupe sous la forme Element, dElement
        public override Element Déconstruire()
        {
            Element e = new Element();
            dElement d;
            //string CodeAttribut = "";
            int type = Acces.type_BUDGET_ENVELOPPE.ID;

            e.ID = ID;
            e.Code = Code;
            e.Libelle = Libelle;
            e.Element_Type = type;
            e.Type_Element = (int)TypeEnveloppe;
            e.Actif = Actif;

            /*
            //Budget ID
            {
                CodeAttribut = "BUDGET_ID";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(type, CodeAttribut).ID, CodeAttribut, Budget_ID.ToString());
                e.Liste.Add(d);
            }

            //Période
            {
                CodeAttribut = "PERIODE";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(type, CodeAttribut).ID, CodeAttribut, Periode.ToString());
                e.Liste.Add(d);
            }

            //Date deb
            {
                CodeAttribut = "DATE_DEB";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(type, CodeAttribut).ID, CodeAttribut, DateDeb);
                e.Liste.Add(d);
            }

            //Date Fin
            {
                CodeAttribut = "DATE_FIN";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(type, CodeAttribut).ID, CodeAttribut, DateFin);
                e.Liste.Add(d);
            }

            //Version 
            //if (VersionTravail != null)
            {
                CodeAttribut = "VERSION_TRAVAIL";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(type, CodeAttribut).ID, CodeAttribut, (VersionTravail?"1":"0"));
                e.Liste.Add(d);
            }

            //Statut référence 
            {
                CodeAttribut = "STATUT_REFERENCE";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(type, CodeAttribut).ID, CodeAttribut, (Statut_Reference ? "1" : "0"));
                e.Liste.Add(d);
            }
            */
            return e;
        }

        //Comparateur par défaut
        public int CompareTo(Budget_Enveloppe p)
        {
            if (p is null) { return 1; }
            else { return (this.Code.CompareTo(p.Code)); }
        }
    }
}
