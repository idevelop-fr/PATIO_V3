using System;
using PATIO.MAIN.Classes;
using System.Windows.Forms;

namespace PATIO.OMEGA.Classes
{
    public class Budget_Version : Classe_Modele, IComparable<Budget_Version>
    {
        public int Enveloppe { get; set; }
        public int Budget_ID { get; set; }
        public int TypeBudget { get; set; }
        public int Periode { get; set; }
        public string DateDeb { get; set; }
        public string DateFin { get; set; }

        public bool VersionTravail { get; set; } = true;
        public bool ReferenceBudget { get; set; } = false;

        Fonctions fct = new Fonctions();

        public Budget_Version()
        {
            ListeAttribut = new string[] {"ENVELOPPE", "BUDGET_ID", "PERIODE",
                                         "DATE_DEB", "DATE_FIN", "VERSION_TRAVAIL", "REFERENCE_BUDGET",
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
            TypeBudget = e.Type_Element;

            foreach (dElement d in e.Liste)
            {
                if (d.Element_ID == ID)
                {
                    if (d.Attribut_Code == "ENVELOPPE") { Enveloppe = int.Parse(d.Valeur); }
                    if (d.Attribut_Code == "BUDGET_ID") { Budget_ID = int.Parse(d.Valeur); }
                    if (d.Attribut_Code == "PERIODE") { Periode = int.Parse(d.Valeur); }
                    if (d.Attribut_Code == "DATE_DEB") { DateDeb = d.Valeur; }
                    if (d.Attribut_Code == "DATE_FIN") { DateFin = d.Valeur; }
                    if (d.Attribut_Code == "VERSION_TRAVAIL") { VersionTravail = (d.Valeur == "1"); }
                    if (d.Attribut_Code == "REFERENCE_BUDGET") { ReferenceBudget = (d.Valeur == "1"); }
                }
            }

            return true;
        }

        //Transforme un groupe sous la forme Element, dElement
        public override Element Déconstruire()
        {
            Element e = new Element();
            dElement d;
            string CodeAttribut = "";
            TypeElement type = Acces.type_BUDGET_VERSION;

            e.ID = ID;
            e.Code = Code;
            e.Libelle = Libelle;
            e.Element_Type = type.ID;
            e.Type_Element = TypeBudget;
            e.Actif = Actif;

            //Enveloppe
            {
                CodeAttribut = "ENVELOPPE";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, Enveloppe.ToString());
                e.Liste.Add(d);
            }

            //Budget ID
            {
                CodeAttribut = "BUDGET_ID";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, Budget_ID.ToString());
                e.Liste.Add(d);
            }

            //Période
            {
                CodeAttribut = "PERIODE";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, Periode.ToString());
                e.Liste.Add(d);
            }

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

            //Version de travail
            {
                CodeAttribut = "VERSION_TRAVAIL";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, (VersionTravail?"1":"0"));
                e.Liste.Add(d);
            }

            //Référence budgétaire
            {
                CodeAttribut = "REFERENCE_BUDGET";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, (ReferenceBudget ? "1" : "0"));
                e.Liste.Add(d);
            }
            return e;
        }

        //Comparateur par défaut
        public int CompareTo(Budget_Version p)
        {
            if (p is null) { return 1; }
            else { return (this.Code.CompareTo(p.Code)); }
        }
    }
}
