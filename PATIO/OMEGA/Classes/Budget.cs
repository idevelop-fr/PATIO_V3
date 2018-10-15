using System;
using PATIO.Modules;

namespace PATIO.OMEGA.Classes
{
    public class Budget
    {
        public AccesNet Acces;
        public int ID { get; set; }
        public String Code { get; set; }
        public String Libelle { get; set; }

        public TypeEnveloppe TypeEnveloppe { get; set; }
        public TypeBudget TypeBudget { get; set; }

        public int Exercice { get; set; }
        public bool Actif { get; set; } = true;
        public bool VersionTravail { get; set; } = false;

        public string code { get; set; }

        public void Construire(Element e)
        {
            ID = e.ID;
            Code = e.Code;
            Libelle = e.Libelle.Replace("'''", "'");
            TypeBudget = (TypeBudget)e.Type_Element;
            Actif = e.Actif;

            
            foreach (dElement d in e.Liste)
            {
                if (d.Element_ID == ID)
                {
                    if (d.Attribut_Code == "TYPE_ENVELOPPE") { TypeEnveloppe = (TypeEnveloppe)(int.Parse(d.Valeur)); }
                    if (d.Attribut_Code == "TYPE_BUDGET") { TypeBudget = (TypeBudget)(int.Parse(d.Valeur)); }
                    if (d.Attribut_Code == "VERSION_TRAVAIL") { VersionTravail = (d.Valeur == "1"); }

                }
            }
        }

        //Transforme un groupe sous la forme Element, dElement
        public Element Déconstruire()
        {
            Element e = new Element();
            dElement d;
            string CodeAttribut = "";

            e.ID = ID;
            e.Element_Type = Acces.type_GROUPE.id;
            e.Code = Code;
            e.Libelle = Libelle;
            e.Type_Element = (int)TypeBudget;
            e.Actif = Actif;

            //Type Enveloppe
            //if (TypeEnveloppe != null)
            {
                CodeAttribut = "TYPE_ENVELOPPE";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut,TypeEnveloppe.ToString());
                e.Liste.Add(d);
            }

            //Type Budget
            {
                CodeAttribut = "TYPE_BUDGET";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, TypeBudget.ToString());
                e.Liste.Add(d);
            }

            //Version 
            //if (VersionTravail != null)
            {
                CodeAttribut = "VERSION_TRAVAIL";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, (VersionTravail?"1":"0"));
                e.Liste.Add(d);
            }
            return e;
        }

        //Comparateur par défaut
        public int CompareTo(Budget p)
        {
            if (p is null) { return 1; }
            else { return (this.Libelle.CompareTo(p.Libelle)); }
        }
    }
}
