using System;
using PATIO.MAIN.Classes;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PATIO.OMEGA.Classes
{
    public class Budget_Ligne : Classe_Modele, IComparable<Budget_Ligne>
    {
        public ctrlConsole Console;
        public int Budget_ID { get; set; }
        public int Enveloppe { get; set; }
        public int Budget_ORG { get; set; }
        public int Budget_GEO { get; set; }
        public int Periode { get; set; }
        public string DateDeb { get; set; }
        public string DateFin { get; set; }

        public TypeFlux TypeFlux { get; set; } = TypeFlux.Dépenses;
        public TypeMontant TypeMontant { get; set; } = TypeMontant.CP;

        public bool Limitatif { get; set; } = false;

        public List<int> ListeCompte { get; set; }

        public Budget_Ligne()
        {
            ListeCompte = new List<int>();
            ListeAttribut = new string[]{"BUDGET_ID", "ENVELOPPE", "BUDGET_ORG",
                                         "BUDGET_GEO", "PERIODE", "DATE_DEB", "DATE_FIN",
                                         "LIMITATIF", "TYPE_MONTANT", "COMPTE",
                                        };
        }

        public override bool Construire(Element e)
        {
            ID = e.ID;
            Code = e.Code;
            Libelle = e.Libelle.Replace("''", "'");
            Element_Type = e.Element_Type;
            Type_Element = e.Type_Element;
            TypeFlux = (TypeFlux)e.Type_Element;
            Actif = e.Actif;

            foreach (dElement d in e.Liste)
            {
                if (d.Element_ID == ID)
                {
                    if (d.Attribut_Code == "BUDGET_ID") { Budget_ID = int.Parse(d.Valeur); }
                    if (d.Attribut_Code == "ENVELOPPE") { Enveloppe = int.Parse(d.Valeur); }
                    if (d.Attribut_Code == "BUDGET_ORG") { Budget_ORG = int.Parse(d.Valeur); }
                    if (d.Attribut_Code == "BUDGET_GEO") { Budget_GEO = int.Parse(d.Valeur); }
                    if (d.Attribut_Code == "PERIODE") { Periode =int.Parse(d.Valeur); }
                    if (d.Attribut_Code == "DATE_DEB") { DateDeb = d.Valeur; }
                    if (d.Attribut_Code == "DATE_FIN") { DateFin = d.Valeur; }
                    if (d.Attribut_Code == "LIMITATIF") { Limitatif = (d.Valeur == "1"); }
                    if (d.Attribut_Code == "TYPE_MONTANT") { TypeMontant = (TypeMontant)int.Parse(d.Valeur); }
                    //if (d.Attribut_Code == "TYPE_FLUX") { TypeFlux = (TypeFlux)int.Parse(d.Valeur); }
                    if (d.Attribut_Code == "COMPTE") { ListeCompte.Add(int.Parse(d.Valeur)); }
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
            TypeElement type = Acces.type_BUDGET_LIGNE;

            e.ID = ID;
            e.Element_Type = type.ID;
            e.Code = Code;
            e.Libelle = Libelle;
            e.Type_Element = (int)TypeFlux;
            e.Actif = Actif;

            //Budget ID
            {
                CodeAttribut = "BUDGET_ID";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, Budget_ID.ToString());
                e.Liste.Add(d);
            }

            //Type Enveloppe
            {
                CodeAttribut = "ENVELOPPE";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, Enveloppe.ToString());
                e.Liste.Add(d);
            }

            //Budget organisation
            {
                CodeAttribut = "BUDGET_ORG";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, Budget_ORG.ToString());
                e.Liste.Add(d);
            }

            //Budget géographique
            {
                CodeAttribut = "BUDGET_GEO";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, Budget_GEO.ToString());
                e.Liste.Add(d);
            }

            //Période
            {
                CodeAttribut = "PERIODE";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, Periode.ToString());
                e.Liste.Add(d);
            }

            //Date début
            {
                CodeAttribut = "DATE_DEB";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, DateDeb);
                e.Liste.Add(d);
            }

            //Date fin
            {
                CodeAttribut = "DATE_FIN";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, DateFin);
                e.Liste.Add(d);
            }

            //Limitatif 
            {
                CodeAttribut = "LIMITATIF";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, (Limitatif?"1":"0"));
                e.Liste.Add(d);
            }

            //Type Montant
            {
                CodeAttribut = "TYPE_MONTANT";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, ((int)TypeMontant).ToString());
                e.Liste.Add(d);
            }

            /*//Type Flux
            {
                CodeAttribut = "TYPE_FLUX";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, ((int)TypeFlux).ToString());
                e.Liste.Add(d);
            }*/

            //Liste des comptes 
            {
                CodeAttribut = "COMPTE";
                foreach (int k in ListeCompte)
                {
                    d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, k.ToString());
                    e.Liste.Add(d);
                }
            }

            return e;
        }

        //Comparateur par défaut
        public int CompareTo(Budget_Ligne p)
        {
            if (p is null) { return 1; }
            else { return (this.Code.CompareTo(p.Code)); }
        }
    }
}
