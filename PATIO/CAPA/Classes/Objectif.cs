using System;
using System.Collections.Generic;
using PATIO.MAIN.Classes;
using PATIO.ADMIN.Classes;

namespace PATIO.CAPA.Classes
{
    public class Objectif : Classe_Modele, IComparable<Objectif>
    {
        public string Description { get; set; }
        public TypeObjectif TypeObjectif { get; set; }

        public Utilisateur Pilote { get; set; }
        public int Statut { get; set; }
        //public Statut Statut { get; set; }
        public DateTime DateDebut { get; set; } = DateTime.Now;
        public DateTime DateFin { get; set; } = DateTime.Now;

        public Meteo Meteo { get; set; }
        public TxAvancement TxAvancement { get; set; }

        public string AnalyseQualitative { get; set; }

        public List<int> Role_6PO_CoPilote;
        public List<int> Role_6PO_Manager;
        public List<int> Role_6PO_Consultation;

        public String _type { get; set; } = "";
        public String _codeplan { get; set; } = "";
        public String _axe { get; set; } = "";
        public String _os { get; set; } = "";
        public String _og { get; set; } = "";
        public String _op { get; set; } = "";
        public String _cpl { get; set; } = "";

        //Onglet Indicateur
        public List<string> Indicateur_Valeurs;

        public Objectif()
        {
            Role_6PO_CoPilote = new List<int>();
            Role_6PO_Manager = new List<int>();
            Role_6PO_Consultation = new List<int>();
            Indicateur_Valeurs = new List<string>();

            ListeAttribut = new string[] {"DESCRIPTION", "PILOTE", "STATUT", "DATE_DEBUT", "DATE_FIN",
                                         "METEO", "TX_AVANCEMENT", "ANALYSE_QUALITATIVE", "ROLE_6PO_COPILOTE",
                                         "ROLE_6PO_MANAGER", "ROLE_6PO_CONSULTATION", "INDICATEUR_VALEUR",
                                         "_TYPE", "CODE_PLAN", "_AXE", "_OS", "_OG", "_OP", "_CPL"};
        }

        //Construction de l'objectif à partir des éléments
        public override bool Construire(Element e)
        {
            ID = e.ID;
            Code = e.Code;
            Libelle = e.Libelle.Replace("'''", "'");
            TypeObjectif = (TypeObjectif)e.Type_Element;
            Actif = e.Actif;

            foreach (dElement d in e.Liste)
            {
                if (d.Element_ID == ID)
                {
                    d.Valeur = d.Valeur.Replace("'''", "'");
                    if (d.Attribut_Code == "DESCRIPTION") { Description = d.Valeur; }
                    if (d.Attribut_Code == "PILOTE") { Pilote = Acces.Trouver_Utilisateur(int.Parse(d.Valeur)); }
                    if (d.Attribut_Code == "STATUT") { Statut = int.Parse(d.Valeur); }
                    if (d.Attribut_Code == "DATE_DEBUT") { DateDebut = DateTime.Parse(d.Valeur); }
                    if (d.Attribut_Code == "DATE_FIN") { DateFin = DateTime.Parse(d.Valeur); }
                    if (d.Attribut_Code == "METEO") { Meteo = (Meteo)int.Parse(d.Valeur); }
                    if (d.Attribut_Code == "TX_AVANCEMENT") { TxAvancement = (TxAvancement)int.Parse(d.Valeur); }
                    if (d.Attribut_Code == "ANALYSE_QUALITATIVE") { AnalyseQualitative = d.Valeur; }
                    if (d.Attribut_Code == "ROLE_6PO_COPILOTE") { Role_6PO_CoPilote.Add(int.Parse(d.Valeur)); }
                    if (d.Attribut_Code == "ROLE_6PO_MANAGER") { Role_6PO_Manager.Add(int.Parse(d.Valeur)); }
                    if (d.Attribut_Code == "ROLE_6PO_CONSULTATION") { Role_6PO_Consultation.Add(int.Parse(d.Valeur)); }
                    if (d.Attribut_Code == "INDICATEUR_VALEUR") { Indicateur_Valeurs.Add(d.Valeur); }

                    if (d.Attribut_Code == "_TYPE") { _type = d.Valeur; }
                    if (d.Attribut_Code == "_CODEPLAN") { _codeplan = d.Valeur; }
                    if (d.Attribut_Code == "_AXE") { _axe = d.Valeur; }
                    if (d.Attribut_Code == "_OS") { _os = d.Valeur; }
                    if (d.Attribut_Code == "_OG") { _og = d.Valeur; }
                    if (d.Attribut_Code == "_OP") { _op = d.Valeur; }
                    if (d.Attribut_Code == "_CPL") { _cpl = d.Valeur; }

                }
            }

            return true;
        }

        //Transforme un objectif sous la forme Element, dElement
        public override Element Déconstruire()
        {
            Element e = new Element();
            dElement d;

            e.ID = ID;
            e.Element_Type =Acces.type_OBJECTIF.ID;
            e.Code = Code;
            e.Libelle = Libelle;
            e.Type_Element=(int) TypeObjectif;
            e.Actif = Actif;

            string CodeAttribut = "";
            if (!(Pilote is null))
            {
                CodeAttribut = "PILOTE";
                d = new dElement(ID, Acces.Trouver_Attribut(Acces.type_OBJECTIF, CodeAttribut).ID, CodeAttribut, Pilote.ID.ToString());
                e.Liste.Add(d);
            }

            {
                CodeAttribut = "TYPE";
                d = new dElement(ID, Acces.Trouver_Attribut(Acces.type_OBJECTIF, CodeAttribut).ID, CodeAttribut, ((int)TypeObjectif).ToString());
                e.Liste.Add(d);
            }

            if (!(Description is null))
            {
                CodeAttribut = "DESCRIPTION";
                d = new dElement(ID, Acces.Trouver_Attribut(Acces.type_OBJECTIF, CodeAttribut).ID, CodeAttribut, Description);
                e.Liste.Add(d);
            }

            {
                CodeAttribut = "STATUT";
                d = new dElement(ID, Acces.Trouver_Attribut(Acces.type_OBJECTIF, CodeAttribut).ID, CodeAttribut, ((int)Statut).ToString());
                e.Liste.Add(d);
            }

            {
                CodeAttribut = "DATE_DEBUT";
                d = new dElement(ID, Acces.Trouver_Attribut(Acces.type_OBJECTIF, CodeAttribut).ID, CodeAttribut, string.Format("{0:dd/MM/yyyy}", DateDebut));
                e.Liste.Add(d);
            }

            {
                CodeAttribut = "DATE_FIN";
                d = new dElement(ID, Acces.Trouver_Attribut(Acces.type_OBJECTIF, CodeAttribut).ID, CodeAttribut, string.Format("{0:dd/MM/yyyy}", DateFin));
                e.Liste.Add(d);
            }

            {
                CodeAttribut = "METEO";
                d = new dElement(ID, Acces.Trouver_Attribut(Acces.type_OBJECTIF, CodeAttribut).ID, CodeAttribut, ((int)Meteo).ToString());
                e.Liste.Add(d);
            }

            {
                CodeAttribut = "TX_AVANCEMENT";
                d = new dElement(ID, Acces.Trouver_Attribut(Acces.type_OBJECTIF, CodeAttribut).ID, CodeAttribut, ((int)TxAvancement).ToString());
                e.Liste.Add(d);
            }

            if (!(AnalyseQualitative is null))
            {
                CodeAttribut = "ANALYSE_QUALITATIVE";
                d = new dElement(ID, Acces.Trouver_Attribut(Acces.type_OBJECTIF, CodeAttribut).ID, CodeAttribut, AnalyseQualitative);
                e.Liste.Add(d);
            }

            CodeAttribut = "ROLE_6PO_COPILOTE";
            foreach (int k in Role_6PO_CoPilote)
            {
                d = new dElement(ID, Acces.Trouver_Attribut(Acces.type_ACTION, CodeAttribut).ID, CodeAttribut, k.ToString());
                e.Liste.Add(d);
            }

            CodeAttribut = "ROLE_6PO_MANAGER";
            foreach (int k in Role_6PO_Manager)
            {
                d = new dElement(ID, Acces.Trouver_Attribut(Acces.type_ACTION, CodeAttribut).ID, CodeAttribut, k.ToString());
                e.Liste.Add(d);
            }

            CodeAttribut = "ROLE_6PO_CONSULTATION";
            foreach (int k in Role_6PO_Consultation)
            {
                d = new dElement(ID, Acces.Trouver_Attribut(Acces.type_ACTION, CodeAttribut).ID, CodeAttribut, k.ToString());
                e.Liste.Add(d);
            }

            {
                CodeAttribut = "_TYPE";
                d = new dElement(ID, Acces.Trouver_Attribut(Acces.type_OBJECTIF, CodeAttribut).ID, CodeAttribut, _type);
                e.Liste.Add(d);
            }

            {
                CodeAttribut = "_CODEPLAN";
                d = new dElement(ID, Acces.Trouver_Attribut(Acces.type_OBJECTIF, CodeAttribut).ID, CodeAttribut, _codeplan);
                e.Liste.Add(d);
            }

            {
                CodeAttribut = "_AXE";
                d = new dElement(ID, Acces.Trouver_Attribut(Acces.type_OBJECTIF, CodeAttribut).ID, CodeAttribut, _axe);
                e.Liste.Add(d);
            }

            {
                CodeAttribut = "_OS";
                d = new dElement(ID, Acces.Trouver_Attribut(Acces.type_OBJECTIF, CodeAttribut).ID, CodeAttribut, _os);
                e.Liste.Add(d);
            }

            {
                CodeAttribut = "_OG";
                d = new dElement(ID, Acces.Trouver_Attribut(Acces.type_OBJECTIF, CodeAttribut).ID, CodeAttribut, _og);
                e.Liste.Add(d);
            }

            {
                CodeAttribut = "_OP";
                d = new dElement(ID, Acces.Trouver_Attribut(Acces.type_OBJECTIF, CodeAttribut).ID, CodeAttribut, _op);
                e.Liste.Add(d);
            }

            {
                CodeAttribut = "_CPL";
                d = new dElement(ID, Acces.Trouver_Attribut(Acces.type_OBJECTIF, CodeAttribut).ID, CodeAttribut, _cpl);
                e.Liste.Add(d);
            }

            CodeAttribut = "INDICATEUR_VALEUR";
            foreach (string k in Indicateur_Valeurs)
            {
                d = new dElement(ID, Acces.Trouver_Attribut(Acces.type_ACTION, CodeAttribut).ID, CodeAttribut, k);
                e.Liste.Add(d);
            }

            return e;
        }

        //Comparateur par défaut
        public int CompareTo(Objectif p)
        {
            if (p is null) { return 1; }
            else { return (this.Libelle.CompareTo(p.Libelle)); }
        }
    }
}
