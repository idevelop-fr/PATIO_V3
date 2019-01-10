using System;
using PATIO.MAIN.Classes;
using System.Collections.Generic;

namespace PATIO.OMEGA.Classes
{
    public class Budget_Virement : Classe_Modele, IComparable<Budget_Virement>
    {
        public TypeFlux Type_Flux { get; set; } = TypeFlux.Dépenses;
        public TypeMontant Type_Montant { get; set; } = TypeMontant.AE;
        public TypeVirement Type_Virement { get; set; } = TypeVirement.Normal;

        public int Periode { get; set; }

        public int Enveloppe_Src { get; set; }
        public int Budget_ORG_Src { get; set; }
        public int Budget_GEO_Src { get; set; }
        public int Compte_ID_Src { get; set; }

        public int Enveloppe_Dest { get; set; }
        public int Budget_ORG_Dest { get; set; }
        public int Budget_GEO_Dest { get; set; }
        public int Compte_ID_Dest { get; set; }

        public string DateDemande { get; set; }
        public string DateEffet { get; set; }
        public double Montant { get; set; }
        public string Commentaire { get; set; }

        public bool Validé { get; set; } = false;

        Fonctions fct = new Fonctions();

        //Variables d'affichage
        public string DateDemande_Afficher
        {
            get { return string.Format("{0:dd/MM/yyyy}", fct.ConvertiStringToDate(DateDemande)); }
        }

        public string DateEffet_Afficher
        {
            get { return string.Format("{0:dd/MM/yyyy}", fct.ConvertiStringToDate(DateDemande)); }
        }

        public string Enveloppe_Src_Afficher
        {
            get
            {
                return Acces.Trouver_Element(Acces.type_BUDGET_ENVELOPPE, Enveloppe_Src).Libelle;
            }
        }

        public string Budget_ORG_Src_Afficher
        {
            get
            {
                List<table_valeur> Liste = Acces.Remplir_ListeTableValeur("BUDGET_ORG");
                foreach (table_valeur tv in Liste)
                {
                    if (tv.ID == Budget_ORG_Src) { return tv.Valeur; }
                }
                return "";
            }
        }

        public string Budget_GEO_Src_Afficher
        {
            get
            {
                List<table_valeur> Liste = Acces.Remplir_ListeTableValeur("BUDGET_GEO");
                foreach (table_valeur tv in Liste)
                {
                    if (tv.ID == Budget_GEO_Src) { return tv.Valeur; }
                }
                return "";
            }
        }

        public string Compte_Code_Src_Afficher
        {
            get
            {
                Budget_Nomenclature Ncl = (Budget_Nomenclature)Acces.Trouver_Element(Acces.type_BUDGET_NOMENCLATURE, Compte_ID_Src);
                return Ncl.Code;
            }
        }

        public string Enveloppe_Dest_Afficher
        {
            get
            {
                return Acces.Trouver_Element(Acces.type_BUDGET_ENVELOPPE, Enveloppe_Dest).Libelle;
            }
        }

         public string Budget_ORG_Dest_Afficher
        {
            get
            {
                List<table_valeur> Liste = Acces.Remplir_ListeTableValeur("BUDGET_ORG");
                foreach (table_valeur tv in Liste)
                {
                    if (tv.ID == Budget_ORG_Dest) { return tv.Valeur; }
                }
                return "";
            }
        }

        public string Budget_GEO_Dest_Afficher
        {
            get
            {
                List<table_valeur> Liste = Acces.Remplir_ListeTableValeur("BUDGET_GEO");
                foreach (table_valeur tv in Liste)
                {
                    if (tv.ID == Budget_GEO_Dest) { return tv.Valeur; }
                }
                return "";
            }
        }

        public string Compte_Code_Dest_Afficher
        {
            get
            {
                Budget_Nomenclature Ncl = (Budget_Nomenclature)Acces.Trouver_Element(Acces.type_BUDGET_NOMENCLATURE, Compte_ID_Dest);
                return Ncl.Code;
            }
        }

        public string Validé_Afficher
        {
            get
            {
                return (Validé ? "OUI":"NON") ;
            }
        }

        public Budget_Virement()
        {
            DateDemande = fct.ConvertiDateToString(DateTime.Now);
            DateEffet = fct.ConvertiDateToString(DateTime.Now);

            ListeAttribut = new string[] {"PERIODE", "TYPE_FLUX", "TYPE_VIREMENT", "TYPE_MONTANT",
                                         "COMPTE_ID_SRC", "BUDGET_ORG_SRC", "BUDGET_GEO_SRC","ENVELOPPE_SRC",
                                         "COMPTE_ID_DEST", "BUDGET_ORG_DEST", "BUDGET_GEO_DEST","ENVELOPPE_DEST",
                                         "DATE_DEMANDE", "DATE_EFFET", "MONTANT", "COMMENTAIRE",
                                        };
        }

        public override bool Construire(Element e)
        {
            ID = e.ID;
            Code = e.Code;
            Libelle = e.Libelle.Replace("'''", "'");
            Type_Virement = (TypeVirement)e.Type_Element;
            Actif = e.Actif;
            Element_Type = Acces.type_BUDGET_VIREMENT.ID;

            foreach (dElement d in e.Liste)
            {
                if (d.Element_ID == ID)
                {
                    if (d.Attribut_Code == "PERIODE") { Periode = int.Parse(d.Valeur); }
                    if (d.Attribut_Code == "TYPE_FLUX") { Type_Flux = (TypeFlux) int.Parse(d.Valeur); }
                    if (d.Attribut_Code == "TYPE_MONTANT") { Type_Montant = (TypeMontant) int.Parse(d.Valeur); }
                    if (d.Attribut_Code == "COMPTE_ID_SRC") { Compte_ID_Src = int.Parse(d.Valeur); }
                    if (d.Attribut_Code == "BUDGET_ORG_SRC") { Budget_ORG_Src = int.Parse(d.Valeur); }
                    if (d.Attribut_Code == "BUDGET_GEO_SRC") { Budget_GEO_Src = int.Parse(d.Valeur); }
                    if (d.Attribut_Code == "ENVELOPPE_SRC") { Enveloppe_Src = int.Parse(d.Valeur); }
                    if (d.Attribut_Code == "COMPTE_ID_DEST") { Compte_ID_Dest = int.Parse(d.Valeur); }
                    if (d.Attribut_Code == "BUDGET_ORG_DEST") { Budget_ORG_Dest = int.Parse(d.Valeur); }
                    if (d.Attribut_Code == "BUDGET_GEO_DEST") { Budget_GEO_Dest = int.Parse(d.Valeur); }
                    if (d.Attribut_Code == "ENVELOPPE_DEST") { Enveloppe_Dest = int.Parse(d.Valeur); }

                    if (d.Attribut_Code == "DATE_DEMANDE") { DateDemande = d.Valeur; }
                    if (d.Attribut_Code == "DATE_EFFET") { DateEffet = d.Valeur; }
                    if (d.Attribut_Code == "MONTANT") { Montant = double.Parse( d.Valeur); }
                    if (d.Attribut_Code == "COMMENTAIRE") { Commentaire = d.Valeur; }

                    if (d.Attribut_Code == "VALIDE") { Validé = (d.Valeur == "1"); }
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
            TypeElement type = Acces.type_BUDGET_VIREMENT;

            e.ID = ID;
            e.Code = Code;
            e.Libelle = Libelle;
            e.Element_Type = type.ID;
            e.Type_Element = (int)Type_Virement;
            e.Actif = Actif;

            //Période
            {
                CodeAttribut = "PERIODE";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, Periode.ToString());
                e.Liste.Add(d);
            }

            //TypeFlux
            {
                CodeAttribut = "TYPE_FLUX";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, ((int)Type_Flux).ToString());
                e.Liste.Add(d);
            }

            //TYpeMontant
            {
                CodeAttribut = "TYPE_MONTANT";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, ((int)Type_Montant).ToString());
                e.Liste.Add(d);
            }

            //Enveloppe Source
            {
                CodeAttribut = "ENVELOPPE_SRC";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, Enveloppe_Src.ToString());
                e.Liste.Add(d);
            }

            //Budget GEO Source
            {
                CodeAttribut = "BUDGET_ORG_SRC";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, Budget_ORG_Src.ToString());
                e.Liste.Add(d);
            }

            //Budget GEO Source
            {
                CodeAttribut = "BUDGET_GEO_SRC";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, Budget_GEO_Src.ToString());
                e.Liste.Add(d);
            }

            //Compte ID Source
            {
                CodeAttribut = "COMPTE_ID_SRC";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, Compte_ID_Src.ToString());
                e.Liste.Add(d);
            }

            //Enveloppe Destination
            {
                CodeAttribut = "ENVELOPPE_DEST";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, Enveloppe_Dest.ToString());
                e.Liste.Add(d);
            }

            //Budget GEO Destination
            {
                CodeAttribut = "BUDGET_ORG_DEST";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, Budget_ORG_Dest.ToString());
                e.Liste.Add(d);
            }

            //Budget GEO Destination
            {
                CodeAttribut = "BUDGET_GEO_DEST";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, Budget_GEO_Dest.ToString());
                e.Liste.Add(d);
            }

            //Compte ID Destination
            {
                CodeAttribut = "COMPTE_ID_DEST";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, Compte_ID_Dest.ToString());
                e.Liste.Add(d);
            }

            //Date de la demande
            {
                CodeAttribut = "DATE_DEMANDE";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, DateDemande);
                e.Liste.Add(d);
            }

            //Date d'effet
            {
                CodeAttribut = "DATE_EFFET";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, DateEffet);
                e.Liste.Add(d);
            }

            //Montant
            {
                CodeAttribut = "MONTANT";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, Montant.ToString());
                e.Liste.Add(d);
            }

            //Commentaire
            {
                CodeAttribut = "COMMENTAIRE";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, Commentaire);
                e.Liste.Add(d);
            }

            //Validé
            {
                CodeAttribut = "VALIDE";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, (Validé?"1":"0"));
                e.Liste.Add(d);
            }

            return e;
        }

        //Comparateur par défaut
        public int CompareTo(Budget_Virement p)
        {
            if (p is null) { return 1; }
            else { return (this.Libelle.CompareTo(p.Libelle)); }
        }
    }
}
