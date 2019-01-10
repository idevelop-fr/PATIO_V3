using System;
using PATIO.MAIN.Classes;
using System.Collections.Generic;

namespace PATIO.OMEGA.Classes
{
    public class Budget_Operation : Classe_Modele, IComparable<Budget_Operation>
    {
        public TypeFlux Type_Flux { get; set; } = TypeFlux.Dépenses;

        public int Type_Operation { get; set; }

        public int Enveloppe { get; set; }
        public int Periode { get; set; }
        public int Budget_ORG { get; set; }
        public int Budget_GEO { get; set; }
        public int Compte_ID { get; set; }

        public string DateOperation { get; set; }
        public TypeMontant Type_Montant { get; set; } = TypeMontant.AE;
        public double Montant { get; set; }
        public string Commentaire { get; set; }

        public int Virement_ID { get; set; }

        //Variables d'affichage
        public string Date_Afficher
        { get { return string.Format("{0:dd/MM/yyyy}", fct.ConvertiStringToDate(DateOperation)); } }

        public string Budget_ORG_Afficher
        {
            get
            {
                List<table_valeur> Liste = Acces.Remplir_ListeTableValeur("BUDGET_ORG");
                foreach(table_valeur tv in Liste)
                {
                    if(tv.ID == Budget_ORG) { return tv.Valeur; }
                }
                return "";
            }
        }

        public string Budget_GEO_Afficher
        {
            get
            {
                List<table_valeur> Liste = Acces.Remplir_ListeTableValeur("BUDGET_GEO");
                foreach (table_valeur tv in Liste)
                {
                    if (tv.ID == Budget_GEO) { return tv.Valeur; }
                }
                return "";
            }
        }

        public string Compte_Code_Afficher
        {
            get
            {
                Budget_Nomenclature Ncl =(Budget_Nomenclature) Acces.Trouver_Element(Acces.type_BUDGET_NOMENCLATURE, Compte_ID);
                return Ncl.Code;
            }
        }

        public string Compte_Libelle_Afficher
        {
            get
            {
                Budget_Nomenclature Ncl = (Budget_Nomenclature)Acces.Trouver_Element(Acces.type_BUDGET_NOMENCLATURE, Compte_ID);
                return Ncl.Libelle;
            }
        }

        Fonctions fct = new Fonctions();

        public Budget_Operation()
        {
            ListeAttribut = new string[] {"ENVELOPPE", "PERIODE", "TYPE_FLUX",
                                         "COMPTE_ID", "BUDGET_ORG", "BUDGET_GEO",
                                         "DATE_OPERATION", "TYPE_OPERATION",
                                         "TYPE_MONTANT", "MONTANT",
                                         "COMMENTAIRE", "VIREMENT_ID",
                                        };
        }

        public override bool Construire(Element e)
        {
            ID = e.ID;
            Code = e.Code;
            Libelle = e.Libelle.Replace("''", "'");
            Element_Type = e.Type_Element;
            Actif = e.Actif;
            Type_Flux = (TypeFlux) e.Type_Element;

            foreach (dElement d in e.Liste)
            {
                if (d.Element_ID == ID)
                {
                    if (d.Attribut_Code == "ENVELOPPE") { Enveloppe = int.Parse(d.Valeur); }
                    if (d.Attribut_Code == "DATE_OPERATION") { DateOperation = d.Valeur; }
                    if (d.Attribut_Code == "TYPE_OPERATION") { Type_Operation = int.Parse(d.Valeur); }
                    if (d.Attribut_Code == "BUDGET_ID") { Budget_ORG = int.Parse(d.Valeur); }
                    if (d.Attribut_Code == "BUDGET_ORG") { Budget_ORG = int.Parse(d.Valeur); }
                    if (d.Attribut_Code == "BUDGET_GEO") { Budget_GEO = int.Parse(d.Valeur); }

                    if (d.Attribut_Code == "PERIODE") { Periode = int.Parse(d.Valeur); }

                    if (d.Attribut_Code == "COMPTE_ID") { Compte_ID = int.Parse(d.Valeur); }
                    if (d.Attribut_Code == "MONTANT") { Montant = (double.Parse(d.Valeur)); }
                    if (d.Attribut_Code == "TYPE_MONTANT") { Type_Montant = (TypeMontant) int.Parse(d.Valeur); }
                    if (d.Attribut_Code == "COMMENTAIRE") { Commentaire = d.Valeur; }

                    if (d.Attribut_Code == "VIREMENT_ID") { Virement_ID = int.Parse(d.Valeur); }
                }
            }

            return true;
        }

        //Transforme un groupe sous la forme Element, dElement
        public override  Element Déconstruire()
        {
            Element e = new Element();
            dElement d;
            string CodeAttribut = "";
            TypeElement type = Acces.type_BUDGET_OPERATION;

            e.ID = ID;
            e.Element_Type = type.ID;
            e.Code = Code;
            e.Libelle = Libelle;
            e.Type_Element = (int)Type_Flux;
            e.Actif = Actif;

            //Type Enveloppe
            {
                CodeAttribut = "ENVELOPPE";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, Enveloppe.ToString());
                e.Liste.Add(d);
            }

            //Période
            {
                CodeAttribut = "PERIODE";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, Periode.ToString());
                e.Liste.Add(d);
            }

            //Date opération
            {
                CodeAttribut = "DATE_OPERATION";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, DateOperation);
                e.Liste.Add(d);
            }


            //Type opération
            {
                CodeAttribut = "TYPE_OPERATION";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, Type_Operation.ToString());
                e.Liste.Add(d);
            }

            //Budget ORG
            {
                CodeAttribut = "BUDGET_ORG";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, Budget_ORG.ToString());
                e.Liste.Add(d);
            }

            //Budget GEO
            {
                CodeAttribut = "BUDGET_GEO";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, Budget_GEO.ToString());
                e.Liste.Add(d);
            }

            //Compte ID
            {
                CodeAttribut = "COMPTE_ID";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, Compte_ID.ToString());
                e.Liste.Add(d);
            }

            //Montant
            {
                CodeAttribut = "MONTANT";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, Montant.ToString());
                e.Liste.Add(d);
            }

            //Type Flux
            {
                CodeAttribut = "TYPE_FLUX";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, ((int)Type_Flux).ToString());
                e.Liste.Add(d);
            }

            //Type monatnt
            {
                CodeAttribut = "TYPE_MONTANT";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, ((int)Type_Montant).ToString());
                e.Liste.Add(d);
            }

            //Commentaire
            {
                CodeAttribut = "COMMENTAIRE";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, Commentaire);
                e.Liste.Add(d);
            }

            //Virement ID
            {
                CodeAttribut = "VIREMENT_ID";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, Virement_ID.ToString());
                e.Liste.Add(d);
            }
            return e;
        }

        //Comparateur par défaut
        public int CompareTo(Budget_Operation p)
        {
            if (p is null) { return 1; }
            else { return (this.Libelle.CompareTo(p.Libelle)); }
        }
    }
}
