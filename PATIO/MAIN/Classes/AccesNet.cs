using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using PATIO.ADMIN.Classes;
using PATIO.CAPA.Classes;
using PATIO.OMEGA.Classes;
using WeifenLuo.WinFormsUI.Docking;

namespace PATIO.MAIN.Classes
{
    public class AccesNet
    {
        public ClassePHP cls;
        public ClasseCAPA clsCAPA;
        public ClasseOMEGA clsOMEGA;
        public ClasseADMIN clsADMIN;
        public ClasseMAIN clsMAIN;

        public string CheminBase;
        public string CheminTemp;
        public Utilisateur user_appli;
        public bool user_admin = false;
        public frmMain Main;
        public DockPanel DP;

        public List<Attribut> ListeAttribut = new List<Attribut>();
        public List<table_valeur> ListeTableValeur = new List<table_valeur>();
        public List<Parametre> ListeParametre = new List<Parametre>();
        public List<Droit> ListeDroit = new List<Droit>();

        public ctrlConsole Console;

        public Fonctions fonc = new Fonctions();

        public List<Element> Liste_Element = new List<Element>();
        public List<dElement> Liste_dElement = new List<dElement>();
        public List<Lien> ListeLien = new List<Lien>();

        public DataSet SnExport;

        //Types CAPA
        public TypeElement type_PLAN = new TypeElement("PLA", 0);
        public TypeElement type_OBJECTIF = new TypeElement("OBJ", 1);
        public TypeElement type_ACTION = new TypeElement("ACT", 2);
        public TypeElement type_INDICATEUR = new TypeElement("IND", 3);
        public TypeElement type_UTILISATEUR = new TypeElement("USR", 4);
        public TypeElement type_GROUPE = new TypeElement("GRP", 5);
        public TypeElement type_PROJET = new TypeElement("PRJ", 6);
        public TypeElement type_PORTEUR = new TypeElement("PRT", 7);

        public TypeElement type_PROCESSUS = new TypeElement("PRO", 10);

        //Type OMEGA
        public TypeElement type_FICHE = new TypeElement("FIC", 100);
        public TypeElement type_LIGNE = new TypeElement("LIG", 101);
        public TypeElement type_DECISION = new TypeElement("DEC", 102);
        public TypeElement type_ECHEANCE = new TypeElement("ECH", 103);
        public TypeElement type_LIQUIDATION = new TypeElement("LIQ", 104);
        public TypeElement type_ORDREPAIEMENT = new TypeElement("ORD", 105);
        public TypeElement type_BUDGET_ENVELOPPE = new TypeElement("ENV", 106);
        public TypeElement type_BUDGET = new TypeElement("BUD", 107);
        public TypeElement type_BUDGET_LIGNE = new TypeElement("BLG", 108);
        public TypeElement type_BUDGET_VERSION = new TypeElement("BVR", 109);
        public TypeElement type_BUDGET_PERIODE = new TypeElement("BPE", 110);
        public TypeElement type_BUDGET_OPERATION = new TypeElement("OPE", 111);
        public TypeElement type_BUDGET_VIREMENT = new TypeElement("VIR", 112);
        public TypeElement type_BUDGET_NOMENCLATURE = new TypeElement("NMC", 113);

        public TypeElement type_ASSOCIATION = new TypeElement("ASS", 114);

        public TypeElement type_MODELEDOC = new TypeElement("MDL", 200);

        public List<TypeElement> ListeTypeElement = new List<TypeElement>();

        public AccesNet()
        {
        }

        public Boolean Initialiser()
        {
            {
                //Création et initialisation de classe d'interfaçage avec la base de données
                cls = new ClassePHP();
                cls.Trace = true; //Active le traçage des requêtes pour le débuggage
                cls.Chemin = CheminTemp;
                cls.Console = Console;
                if (!cls.Initialiser()) { return false; }
                CheminBase = cls.CheminBase;

                //Création et initialisation de la classe de gestion des données OMEGA
                clsCAPA = new ClasseCAPA();
                clsCAPA.Acces = this;
                clsCAPA.Console = Console;

                //Création et initialisation de la classe de gestion des données OMEGA
                clsOMEGA = new ClasseOMEGA();
                clsOMEGA.Acces = this;
                clsOMEGA.Console = Console;

                //Création et initialisation de la classe de gestion des données ADMIN
                clsADMIN = new ClasseADMIN();
                clsADMIN.Acces = this;
                clsADMIN.Console = Console;

                //Création et initialisation de la classe de gestion des données MAIN
                clsMAIN = new ClasseMAIN();
                clsMAIN.Acces = this;
                clsMAIN.Console = Console;
            }

            Nettoyer(); //Corrige automatiquement les bugs possibles

            //Corriger_tv();
            Charger_ListeTableValeur();
            Charger_ListeParametre();
            Charger_ListeAttribut();
            Charger_ListeTypeElement();

            Charger_Element();
            Charger_Lien();

            Remplir_ListeElement(type_UTILISATEUR, "");
            return true;
        }

        /// <summary>
        /// Création de la liste avec l'ensemble des types d'objets gérés
        /// </summary>
        void Charger_ListeTypeElement()
        {
            ListeTypeElement = new List<TypeElement>();
            ListeTypeElement.Add(type_ACTION);
            ListeTypeElement.Add(type_PLAN);
            ListeTypeElement.Add(type_OBJECTIF);
            ListeTypeElement.Add(type_INDICATEUR);

            ListeTypeElement.Add(type_UTILISATEUR);
            ListeTypeElement.Add(type_GROUPE);

            ListeTypeElement.Add(type_PROJET);
            ListeTypeElement.Add(type_PROCESSUS);

            ListeTypeElement.Add(type_PORTEUR);

            ListeTypeElement.Add(type_BUDGET_ENVELOPPE);
            ListeTypeElement.Add(type_BUDGET);
            ListeTypeElement.Add(type_BUDGET_LIGNE);
            ListeTypeElement.Add(type_BUDGET_PERIODE);
            ListeTypeElement.Add(type_BUDGET_VERSION);
            ListeTypeElement.Add(type_BUDGET_OPERATION);
            ListeTypeElement.Add(type_BUDGET_NOMENCLATURE);
            ListeTypeElement.Add(type_BUDGET_VIREMENT);

            /*ListeTypeElement.Add(type_FICHE);
            ListeTypeElement.Add(type_LIGNE);
            ListeTypeElement.Add(type_DECISION);
            ListeTypeElement.Add(type_ECHEANCE);
            ListeTypeElement.Add(type_LIQUIDATION);
            ListeTypeElement.Add(type_ORDREPAIEMENT);*/

            ListeTypeElement.Add(type_MODELEDOC);

            //**************************************************************************************
            //L'ajout de type nécessite la modification des procédures suivantes dans ce fichier :
            //   - Controler_Attributs
            //   - Construire_Element
            //   - Trouver_Element
            //**************************************************************************************

            //Recherche des identifiants affectés à l'environnement
            foreach (TypeElement tp in ListeTypeElement)
             {
                 tp.Acces = this;
                 if (!tp.Trouver()) { Créer_TypeElement(tp); }
                 Controler_Attributs(tp);
                 Console.Ajouter(tp.Code + " : " + tp.ID);
             }
         }

         /// <summary>
         /// Créer un type d'élément inexistant dans la base de données
         /// </summary>
         /// <param name="tp"></param>
         void Créer_TypeElement(TypeElement tp)
         {
             //Création du type élément
             TypeElement tp_new = new TypeElement(tp.Code, tp.ID.ToString(), "");
             tp_new.Acces = this;
             tp_new.Ajouter();
             Console.Ajouter("Element " + tp.Code + " créé");
         }

        /// <summary>
        /// Vérifie si l'attribut existe
        /// </summary>
        /// <param name="tp"></param>
         void Controler_Attributs(TypeElement tp)
         {
            if (tp == type_PLAN)
             {
                Plan plan = new Plan();
                foreach (string code in plan.ListeAttribut)
                {
                    if (!Trouver_Attribut_ID(tp, code)) { Ajouter_Attribut(tp, code, code); }
                }
             }
            if (tp == type_OBJECTIF)
            {
            Objectif objectif = new Objectif();
            foreach (string code in objectif.ListeAttribut)
            {
                if (!Trouver_Attribut_ID(tp, code)) { Ajouter_Attribut(tp, code, code); }
            }
        }
            if (tp == type_ACTION)
            {
            CAPA.Classes.Action action = new CAPA.Classes.Action();
            foreach (string code in action.ListeAttribut)
            {
                if (!Trouver_Attribut_ID(tp, code)) { Ajouter_Attribut(tp, code, code); }
            }
        }
            if (tp == type_INDICATEUR)
            {
            Indicateur indicateur = new Indicateur();
            foreach (string code in indicateur.ListeAttribut)
            {
                if (!Trouver_Attribut_ID(tp, code)) { Ajouter_Attribut(tp, code, code); }
            }
        }
            if (tp == type_UTILISATEUR)
             {
                Utilisateur utilisateur = new Utilisateur();
                foreach (string code in utilisateur.ListeAttribut)
                {
                    if (!Trouver_Attribut_ID(tp, code)) { Ajouter_Attribut(tp, code, code); }
                }
            }
            if (tp == type_GROUPE)
            {
                Groupe groupe = new Groupe();
                foreach (string code in groupe.ListeAttribut)
                {
                    if (!Trouver_Attribut_ID(tp, code)) { Ajouter_Attribut(tp, code, code); }
                }
            }
            if (tp == type_PROJET)
            {
                Projet projet = new Projet();
                foreach (string code in projet.ListeAttribut)
                {
                    if (!Trouver_Attribut_ID(tp, code)) { Ajouter_Attribut(tp, code, code); }
                    else { Console.Ajouter("Attribut trouvé " + code); }
                }
            }
            if (tp == type_PROCESSUS)
            {
                Process processus = new Process();
                foreach (string code in processus.ListeAttribut)
                {
                    if (!Trouver_Attribut_ID(tp, code)) { Ajouter_Attribut(tp, code, code); }
                }
            }
            if (tp == type_BUDGET_ENVELOPPE)
             {
                Budget_Enveloppe bg = new Budget_Enveloppe();
                foreach (string code in bg.ListeAttribut)
                {
                    if (!Trouver_Attribut_ID(tp, code)) { Ajouter_Attribut(tp, code, code); }
                }
            }
            if (tp == type_BUDGET)
            {
            Budget bg = new Budget();
            foreach (string code in bg.ListeAttribut)
            {
                if (!Trouver_Attribut_ID(tp, code)) { Ajouter_Attribut(tp, code, code); }
            }
        }
            if (tp == type_BUDGET_LIGNE)
            {
            Budget_Ligne bg = new Budget_Ligne();
            foreach (string code in bg.ListeAttribut)
            {
                if (!Trouver_Attribut_ID(tp, code)) { Ajouter_Attribut(tp, code, code); }
            }
        }
            if (tp == type_BUDGET_VERSION)
            {
            Budget_Version bg = new Budget_Version();
            foreach (string code in bg.ListeAttribut)
            {
                if (!Trouver_Attribut_ID(tp, code)) { Ajouter_Attribut(tp, code, code); }
            }
        }
            if (tp == type_BUDGET_PERIODE)
            {
                Budget_Periode bg = new Budget_Periode();
                foreach (string code in bg.ListeAttribut)
                {
                    if (!Trouver_Attribut_ID(tp, code)) { Ajouter_Attribut(tp, code, code); }
                }
            }
            if (tp == type_BUDGET_OPERATION)
             {
                Budget_Operation bg = new Budget_Operation();
                foreach (string code in bg.ListeAttribut)
                {
                    if (!Trouver_Attribut_ID(tp, code)) { Ajouter_Attribut(tp, code, code); }
                }
            }
            if (tp == type_BUDGET_NOMENCLATURE)
             {
                Budget_Nomenclature bg = new Budget_Nomenclature();
                foreach (string code in bg.ListeAttribut)
                {
                    if (!Trouver_Attribut_ID(tp, code)) { Ajouter_Attribut(tp, code, code); }
                }
            }
            if (tp == type_BUDGET_VIREMENT)
             {
                Budget_Virement bg = new Budget_Virement();
                foreach (string code in bg.ListeAttribut)
                {
                    if (!Trouver_Attribut_ID(tp, code)) { Ajouter_Attribut(tp, code, code); }
                }
            }
            if (tp == type_FICHE)
            {
                Fiche elm = new Fiche();
                foreach (string code in elm.ListeAttribut)
                {
                    if (!Trouver_Attribut_ID(tp, code)) { Ajouter_Attribut(tp, code, code); }
                }
            }
            if (tp == type_LIGNE)
            {
                Fiche_Ligne elm = new Fiche_Ligne();
                foreach (string code in elm.ListeAttribut)
                {
                    if (!Trouver_Attribut_ID(tp, code)) { Ajouter_Attribut(tp, code, code); }
                }
            }
            if (tp == type_DECISION)
            {
                Decision elm = new Decision();
                foreach (string code in elm.ListeAttribut)
                {
                    if (!Trouver_Attribut_ID(tp, code)) { Ajouter_Attribut(tp, code, code); }
                }
            }
            if (tp == type_ECHEANCE)
            {
                Echeance elm = new Echeance();
                foreach (string code in elm.ListeAttribut)
                {
                    if (!Trouver_Attribut_ID(tp, code)) { Ajouter_Attribut(tp, code, code); }
                }
            }
            if (tp == type_LIQUIDATION)
            {
                Liquidation elm = new Liquidation();
                foreach (string code in elm.ListeAttribut)
                {
                    if (!Trouver_Attribut_ID(tp, code)) { Ajouter_Attribut(tp, code, code); }
                }
            }
            if (tp == type_ORDREPAIEMENT)
            {
                OrdrePaiement elm = new OrdrePaiement();
                foreach (string code in elm.ListeAttribut)
                {
                    if (!Trouver_Attribut_ID(tp, code)) { Ajouter_Attribut(tp, code, code); }
                }
            }

            if (tp == type_MODELEDOC)
            {
                ModeleDoc elm = new ModeleDoc();
                foreach (string code in elm.ListeAttribut)
                {
                    if (!Trouver_Attribut_ID(tp, code)) { Ajouter_Attribut(tp, code, code); }
                }
            }
        }

        /// <summary>
        /// Ajout un attribut définissant un élément
        /// </summary>
        /// <param name="typeelement"></param>
        /// <param name="Code"></param>
        /// <param name="Libelle"></param>
        void Ajouter_Attribut(TypeElement typeelement, string Code, string Libelle )
         {
            Attribut att = new Attribut();
            att.Acces = this;
            att.Code = Code;
            att.Libelle = Libelle;
            att.Element_Type = typeelement.ID;
            att.Ajouter();
            ListeAttribut.Add(att);
         }

         /// <summary>
         //Intègre l'ensemble des éléments en mémoire
         //Evite de faire un appel récurrent
         /// </summary>
         public void Charger_Element()
         {
             string sql = "";

             Liste_Element = new List<Element>();
             Liste_dElement = new List<dElement>();
             ListeLien = new List<Lien>();

             //ELEMENT
             sql = "SELECT * FROM element";
             DataSet Sn = cls.ContenuRequete(sql);

             if (cls.NbLignes == 0) { return; }

             foreach (DataRow r in Sn.Tables["dataset"].Rows)
             {
                 Element e = new Element();
                 e.ID = int.Parse(r["id"].ToString());
                 e.Element_Type = int.Parse(r["element_type"].ToString());
                 e.Code = r["code"].ToString();
                 e.Libelle = r["libelle"].ToString();
                 e.Type_Element = int.Parse(r["type_element"].ToString());
                 e.Actif = (r["actif"].ToString() == "1");

                 Liste_Element.Add(e);
             }

             //Recherche des détails des éléments DELEMENT
             sql = "SELECT * FROM delement";

             //DataSet DSn = cls.ContenuTable("delement");
             DataSet DSn = cls.ContenuRequete(sql);
             foreach (DataRow r in DSn.Tables["dataset"].Rows)
             {
                 dElement de = new dElement();
                 de.ID = int.Parse(r["id"].ToString());
                 de.Element_ID = int.Parse(r["element_id"].ToString());
                 de.Attribut_ID = int.Parse(r["attribut_id"].ToString());
                 de.Attribut_Code = r["attribut_code"].ToString();
                 de.Valeur = r["Valeur"].ToString();
                 Liste_dElement.Add(de);
             }

             //Rattachement des détails aux éléments principaux
             foreach (Element e in Liste_Element)
             {
                 foreach (dElement d in Liste_dElement)
                 {
                     if (e.ID == d.Element_ID) { e.Liste.Add(d); }
                 }
             }
         }

         /// <summary>
         /// Procédure de chargement de la liste des liens
         /// </summary>
         public void Charger_Lien(Boolean InclusSysteme=true)
         {
             //LIEN
             string sql = "SELECT * FROM lien";
             if(!InclusSysteme) { sql += " WHERE Element0_Code <>'SYSTEME'"; }

             DataSet SnLien = cls.ContenuRequete(sql);

            if (cls.NbLignes == 0) { return; }

            foreach (DataRow r in SnLien.Tables["dataset"].Rows)
            {
                Lien l = new Lien();
                l.ID = int.Parse(r["id"].ToString());
                l.Element0_Type = int.Parse(r["Element0_Type"].ToString());
                l.Element0_Code = r["Element0_Code"].ToString();
                l.Element0_ID = int.Parse(r["Element0_ID"].ToString());
                l.Element1_Type = int.Parse(r["Element1_Type"].ToString());
                l.Element1_Code = r["Element1_Code"].ToString();
                l.Element1_ID = int.Parse(r["Element1_ID"].ToString());
                l.Element2_Type = int.Parse(r["Element2_Type"].ToString());
                l.Element2_Code = r["Element2_Code"].ToString();
                l.Element2_ID = int.Parse(r["Element2_ID"].ToString());
                l.ordre = int.Parse(r["ordre"].ToString());
                l.complement = r["complement"].ToString();
                ListeLien.Add(l);
            }
        }

        /// <summary>
        /// Ajoute un élément dans la base de données
        /// </summary>
        /// <param name="typeelement"></param>
        /// <param name="objet"></param>
        /// <returns></returns>
        public int Ajouter_Element(TypeElement typeelement, Classe_Modele objet)
        {
            int id = 0;

            /*Console.Ajouter("[Création Element (Type :" + typeelement.Code + " , " + objet.Libelle + ")]");
            Console.Ajouter("DEB--> Nb Liste_Element : " + Liste_Element.Count);
            Console.Ajouter("DEB--> Nb Liste_dElement : " + Liste_dElement.Count);*/
            Element e = new Element(); //Création de l'ossature de l'élément représentant l'objet
            e.Acces = this;
            e.Element_Type = typeelement.ID;

            //Ajout des informations principales et complémentaires
            e = objet.Déconstruire();
            e.Acces = this;
            id = e.Enregistrer(); //Pb l'affectation de l'ID à Element_ID ne se fait pas
            Console.Ajouter("CREATION ELEMENT ID = " + id.ToString());

            //Ajoute les informations aux listes de gestion
            Liste_Element.Add(e);

            foreach(dElement d in e.Liste)
            {
                d.Element_ID = e.ID; //Correction du Pb
                Liste_dElement.Add(d);
            }

            //Console.Ajouter("FIN--> Nb Liste_Element : " + Liste_Element.Count);
            //Console.Ajouter("FIN--> Nb Liste_dElement : " + Liste_dElement.Count);

            return id;
        }

        //Ajout d'un détail d'élément
        public void Ajouter_dElement(dElement d)
        {
            Liste_dElement.Add(d);

            //Application à l'élément associé
            foreach (Element e in Liste_Element)
            {
                if (e.ID == d.Element_ID)
                {
                    e.Liste.Add(d);
                    return;
                }
            }
        }

        //Ajout d'un lien
        public void Ajouter_Lien(Lien l)
        {
            ListeLien.Add(l);
        }

        //Suppression d'un élément, de ses détails et de ses liens
        public void Supprimer_Element(TypeElement typeelement, Classe_Modele obj)
        {
            Element e = new Element();
            e.Acces = this;

            e.Element_Type = typeelement.ID;
            e.ID = obj.ID;
            e.Supprimer();

            //Suppression des listes de référence
            List<dElement> Liste = new List<dElement>();
            foreach (dElement d in Liste_dElement) { if (d.Element_ID != e.ID) { Liste.Add(d); } }
            Liste_dElement = Liste;

            foreach (Element el in Liste_Element)
            {
                if (el.ID == e.ID) { Liste_Element.Remove(el); break; }
            }

            //Supprime les liens faisant référence à cet objet
            List<Lien> lLien = new List<Lien>();
            foreach (Lien l in ListeLien)
            {
                if ((l.Element0_ID != e.ID)
                    && (l.Element1_ID != e.ID)
                    && (l.Element2_ID != e.ID)) { lLien.Add(l); }
            }
            ListeLien = lLien;
        }
  
        //Suppression d'un détail d'élément
        public void Supprimer_dElement(dElement d)
        {
            Liste_dElement.Remove(d);

            //Application à l'élément associé
            foreach(Element e in Liste_Element)
            {
                if(e.ID == d.Element_ID)
                { foreach(dElement dl in e.Liste)
                    {
                        if(dl.ID == d.ID) { e.Liste.Remove(dl); return; }
                    }
                }
            }
        }

        //Suppression d'un lien
        public void Supprimer_Lien(Lien l)
        {
            l.Acces = this;
            l.Supprimer();

            ListeLien.Remove(l);
        }

        //Vérifie l'existence d'un objet de type défini en fonction de son code
        public Boolean Existe_Element(TypeElement typeelement, string attribut_recherche, string code)
        {
            //int typeelement_id = Trouver_TableValeur_Code("TYPE_ELEMENT", typeelement.Code).ID;

            foreach (Element e in Liste_Element)
            {
                if (e.Element_Type == typeelement.ID)
                   //if (e.Element_Type == typeelement_id)
                    {
                        switch (attribut_recherche)
                    {
                        case "CODE":
                            {
                                if (e.Code == code) { return true; }
                                break;
                            }
                        case "ID":
                            {
                                if (e.ID == int.Parse(code)) { return true; }
                                break;
                            }
                    }
                }
            }

            return false;
        }

        //Trouve l'élément selon le type et le Code recherchés et renvoie l'élément
        public Boolean Existe_Lien(TypeElement typeelement0, int Element0_ID, int Element1_ID, int Element2_ID)
        {
            List<Lien> Liste = Remplir_ListeLien_Niv0(typeelement0, Element0_ID.ToString());

            foreach (Lien l in Liste)
            {
                if (l.Element0_ID == Element0_ID && l.Element1_ID == Element1_ID && l.Element2_ID == Element2_ID) { return true; }
            }
            return false;
        }

        //Trouve l'élément selon le type et l'id recherchés et renvoie l'élément
        public object Trouver_Element_new(TypeElement typeelement, int id)
        {
            List<Element> Liste = new List<Element>();

            foreach (Element e in Liste_Element)
            {
                if (e.ID == id)
                {
                    Liste.Add(e);
                }
            }
            return Construire_Element(typeelement, Liste);
        }

        public Classe_Modele Trouver_Element(TypeElement typeelement, int id)
        {
            List<Element> Liste = new List<Element>();

            foreach (Element e in Liste_Element)
            {
                if (e.ID == id)
                {
                    Liste.Add(e);
                    if (typeelement == type_PLAN) { return ((List<Plan>)Construire_Element(typeelement, Liste))[0]; }
                    if (typeelement == type_OBJECTIF) { return ((List<Objectif>)Construire_Element(typeelement, Liste))[0]; }
                    if (typeelement == type_ACTION) { return ((List<PATIO.CAPA.Classes.Action>)Construire_Element(typeelement, Liste))[0]; }
                    if (typeelement == type_INDICATEUR) { return ((List<Indicateur>)Construire_Element(typeelement, Liste))[0]; }
                    if (typeelement == type_UTILISATEUR) { return ((List<Utilisateur>)Construire_Element(typeelement, Liste))[0]; }
                    if (typeelement == type_GROUPE) { return ((List<Groupe>)Construire_Element(typeelement, Liste))[0]; }

                    if (typeelement == type_PROJET) { return ((List<Projet>)Construire_Element(typeelement, Liste))[0]; }
                    if (typeelement == type_PROCESSUS) { return ((List<Process>)Construire_Element(typeelement, Liste))[0]; }
                    if (typeelement == type_PORTEUR) { return ((List<Porteur>)Construire_Element(typeelement, Liste))[0]; }

                    if (typeelement == type_BUDGET_ENVELOPPE) { return ((List<Budget_Enveloppe>)Construire_Element(typeelement, Liste))[0]; }
                    if (typeelement == type_BUDGET) { return ((List<Budget>)Construire_Element(typeelement, Liste))[0]; }
                    if (typeelement == type_BUDGET_PERIODE) { return ((List<Budget_Periode>)Construire_Element(typeelement, Liste))[0]; }
                    if (typeelement == type_BUDGET_LIGNE) { return ((List<Budget_Ligne>)Construire_Element(typeelement, Liste))[0]; }
                    if (typeelement == type_BUDGET_VERSION) { return ((List<Budget_Version>)Construire_Element(typeelement, Liste))[0]; }
                    if (typeelement == type_BUDGET_NOMENCLATURE) { return ((List<Budget_Nomenclature>)Construire_Element(typeelement, Liste))[0]; }
                    if (typeelement == type_BUDGET_OPERATION) { return ((List<Budget_Operation>)Construire_Element(typeelement, Liste))[0]; }
                    if (typeelement == type_BUDGET_VIREMENT) { return ((List<Budget_Virement>)Construire_Element(typeelement, Liste))[0]; }

                    if (typeelement == type_MODELEDOC) { return ((List<ModeleDoc>)Construire_Element(typeelement, Liste))[0]; }

                    //****** AJOUTER ICI le code de retour de la liste : Copie/Coller + 2 modifications
                }
            }

            MessageBox.Show("[ERREUR] Elément non trouvé : " + typeelement + ", id=" + id.ToString());
            return null;
        }

        //Trouve l'élément selon le type et le Code recherchés et renvoie l'élément
        public Object Trouver_Element(TypeElement typeelement, string Code)
        {
            foreach (Element e in Liste_Element)
            {
                if (e.Code == Code) { return e; }
            }
            return null;
        }

        //Trouve l'élément selon l'id recherché et renvoie l'élément
        public Element Trouver_Element(int id)
        {
            foreach (Element e in Liste_Element)
            {
                if (e.ID == id)
                {
                    return e;
                }
            }

            return null;
        }

        //Charge la liste des attributs dans une liste
        public void Charger_ListeAttribut()
        {
            ListeAttribut = new List<Attribut>();

            string sql;
            sql = "SELECT * FROM attribut";
            sql += " ORDER BY libelle";
            DataSet Sn = cls.ContenuRequete(sql);

            if (cls.NbLignes == 0) { return; }

            foreach (DataRow r in Sn.Tables["dataset"].Rows)
            {
                Attribut att = new Attribut();
                att.ID = int.Parse(r["id"].ToString());
                att.Code = r["Code"].ToString();
                att.Libelle = r["Libelle"].ToString();
                att.Element_Type = int.Parse(r["Element_Type"].ToString());
                att.ATT_6PO = r["att_6po"].ToString();

                ListeAttribut.Add(att);
            }
        }

        //Charche la liste des tables de valeurs dans une liste
        public void Charger_ListeTableValeur()
        {
            ListeTableValeur = new List<table_valeur>();

            string sql;
            sql = "SELECT * FROM table_valeur";
            sql += " ORDER BY nom, code";
            DataSet Sn = cls.ContenuRequete(sql);

            SnExport = Sn; //Pour une utilisation externe

            if (cls.NbLignes == 0) { return; }

            foreach (DataRow r in Sn.Tables["dataset"].Rows)
            {
                table_valeur tv = new table_valeur();
                tv.ID = int.Parse(r["id"].ToString());
                tv.Nom = r["nom"].ToString();
                tv.Code = r["code"].ToString();
                tv.Valeur = r["valeur"].ToString();
                tv.Valeur6PO = r["valeur_6po"].ToString();

                ListeTableValeur.Add(tv);
            }
        }

        //Charge la liste des attributs dans une liste
        public void Charger_ListeParametre()
        {
            ListeParametre = new List<Parametre>();

            string sql;
            sql = "SELECT * FROM parametre";
            sql += " ORDER BY code";

            DataSet Sn = cls.ContenuRequete(sql);

            if (cls.NbLignes == 0) { return; }

            foreach (DataRow r in Sn.Tables["dataset"].Rows)
            {
                Parametre p = new Parametre();
                p.ID = int.Parse(r["id"].ToString());
                p.Code = r["code"].ToString();
                p.Valeur = r["valeur"].ToString();

                ListeParametre.Add(p);
            }
        }

        //Charge la liste des droits dans une liste
        public void Charger_ListeDroit()
        {
            ListeDroit = new List<Droit>();

            string sql;
            sql = "SELECT * FROM droit";
            sql += " WHERE actif=1";
            sql += " AND user_id=" + user_appli.ID;
            sql += " ORDER BY code";

            DataSet Sn = cls.ContenuRequete(sql);

            if (cls.NbLignes == 0) { return; }

            foreach (DataRow r in Sn.Tables["dataset"].Rows)
            {
                Droit p = new Droit();
                p.ID = int.Parse(r["id"].ToString());
                p.user_id = int.Parse( r["user_id"].ToString());
                p.Code = r["code"].ToString();
                p.datedeb = r["datedeb"].ToString();
                p.datefin = r["datefin"].ToString();
                p.actif = (r["actif"].ToString()=="1");

                ListeDroit.Add(p);
            }
        }

        //Charge la liste des utilisateurs PILOTE dans une liste
        public List<Utilisateur> Remplir_ListeUtilisateurPilote()
        {
            List<Utilisateur> Liste = new List<Utilisateur>();

            List<Utilisateur> ListeUtilisateur = (List<Utilisateur>)Remplir_ListeElement(type_UTILISATEUR, "");

            foreach (Utilisateur user in ListeUtilisateur)
            {
                if (user.TypeLicence == TypeLicence.PILOTE) { Liste.Add(user); }
            }
            Liste.Sort();

            return Liste;
        }

        //Trouve un utilisateur selon identifiant et renvoie l'objet
        public Utilisateur Trouver_Utilisateur(int id)
        {
            Utilisateur utilisateur = null;

            List<Utilisateur> ListeUtilisateur = (List<Utilisateur>)Remplir_ListeElement(type_UTILISATEUR, "");

            foreach (Utilisateur user in ListeUtilisateur)
            {
                if (user.ID == id)
                {
                    utilisateur = user;
                    break;
                }
            }

            return utilisateur;
        }

        //Trouve un utilisateurselon identifiant et renvoie l'objet
        public Utilisateur Trouver_Utilisateur(string Code)
        {
            Utilisateur utilisateur = null;

            List<Utilisateur> ListeUtilisateur = (List<Utilisateur>)Remplir_ListeElement(type_UTILISATEUR, "");

            foreach (Utilisateur user in ListeUtilisateur)
            {
                if (user.Code == Code)
                {
                    utilisateur = user;
                    break;
                }
            }

            return utilisateur;
        }

        public Utilisateur Trouver_Utilisateur_old(string Code)
        {
            Utilisateur utilisateur = null;

            List<Utilisateur> ListeUtilisateur = (List<Utilisateur>)Remplir_ListeElement(type_UTILISATEUR, "");

            foreach (Utilisateur user in ListeUtilisateur)
            {
                if (user.Code == Code)
                {
                    utilisateur = user;
                    break;
                }
            }

            return utilisateur;
        }

        //Charge l'ensemble des informations relatives à l'élément
        public object Remplir_ListeElement(TypeElement typeelement, int ID, Boolean Actif = false)
        {
            List<Element> Liste = new List<Element>();

            foreach (Element e in Liste_Element)
            {
                if (e.Element_Type == typeelement.ID && e.ID == ID)
                {
                    Boolean ok1 = (e.ID == ID);
                    bool ok2 = (Actif) ? e.Actif : true;
                    if (ok1 && ok2) { Liste.Add(e); }
                }
            }

            //Construction des objets de gestion à partir des éléments*/
            return Construire_Element(typeelement, Liste);
        }

        //Charge l'ensemble des informations relatives à l'élément
        public object Remplir_ListeElement(TypeElement typeelement, string code, Boolean Actif = false)
        {
            List<Element> Liste = new List<Element>();
            foreach (Element e in Liste_Element)
            {
                if (e.Element_Type == typeelement.ID)
                {
                    Boolean ok1 = (code.Length > 0) ? (e.Code == code) : true;
                    bool ok2 = (Actif) ? e.Actif : true;
                    if (ok1 && ok2) { Liste.Add(e);}
                }
            }

            return Construire_Element(typeelement, Liste);
        }

        public Object Construire_Element(TypeElement typeelement, List<Element> Liste)
        {
            bool ok = false;
            List<Plan> ListePlan = new List<Plan>();
            List<Objectif> ListeObjectif = new List<Objectif>();
            List<PATIO.CAPA.Classes.Action> ListeAction = new List<PATIO.CAPA.Classes.Action>();
            List<Indicateur> ListeIndicateur = new List<Indicateur>();
            List<Utilisateur> ListeUtilisateur = new List<Utilisateur>();
            List<Groupe> ListeGroupe = new List<Groupe>();

            List<Projet> ListeProjet = new List<Projet>();
            List<Process> ListeProcessus = new List<Process>();
            List<Porteur> ListePorteur = new List<Porteur>();

            List<Budget_Enveloppe> ListeBudgetEnveloppe = new List<Budget_Enveloppe>();
            List<Budget> ListeBudget = new List<Budget>();
            List<Budget_Periode> ListeBudget_Periode = new List<Budget_Periode>();
            List<Budget_Ligne> ListeBudget_Ligne = new List<Budget_Ligne>();
            List<Budget_Nomenclature> ListeBudget_Nomenclature = new List<Budget_Nomenclature>();
            List<Budget_Version> ListeBudget_Version = new List<Budget_Version>();
            List<Budget_Operation> ListeBudget_Operation = new List<Budget_Operation>();
            List<Budget_Virement> ListeBudget_Virement = new List<Budget_Virement>();

            List<ModeleDoc> ListeModeleDoc = new List<ModeleDoc>();
            //************ AJOUTER ICI la liste de réception des éléments

            foreach (Element e in Liste)
            {
                if (typeelement == type_PLAN)
                {
                    Plan elm = new Plan() { Acces = this, };
                    elm.Construire(e);
                    ListePlan.Add(elm);
                    ok = true;
                }
                if (typeelement == type_OBJECTIF)
                {
                    Objectif elm = new Objectif() { Acces = this, };
                    elm.Construire(e);
                    ListeObjectif.Add(elm); ;
                    ok = true;
                }
                if (typeelement == type_ACTION)
                {
                    PATIO.CAPA.Classes.Action elm = new PATIO.CAPA.Classes.Action() { Acces = this, };
                    elm.Construire(e);
                    ListeAction.Add(elm);
                    ok = true;
                }
                if (typeelement == type_INDICATEUR)
                {
                    Indicateur elm = new Indicateur() { Acces = this, };
                    elm.Construire(e);
                    ListeIndicateur.Add(elm);
                    ok = true;
                }
                if (typeelement == type_UTILISATEUR)
                {
                    Utilisateur elm = new Utilisateur() { Acces = this, };
                    elm.Construire(e);
                    ListeUtilisateur.Add(elm);
                    ok = true;
                }
                if (typeelement == type_GROUPE)
                {
                    Groupe elm = new Groupe() { Acces = this };
                    elm.Construire(e);
                    ListeGroupe.Add(elm);
                    ok = true;
                }
                if (typeelement == type_PROJET)
                {
                    Projet elm = new Projet() { Acces = this };
                    elm.Construire(e);
                    ListeProjet.Add(elm);
                    ok = true;
                }
                if (typeelement == type_PROCESSUS)
                {
                    Process elm = new Process() { Acces = this };
                    elm.Construire(e);
                    ListeProcessus.Add(elm);
                    ok = true;
                }
                if (typeelement == type_PORTEUR)
                {
                    Porteur elm = new Porteur() { Acces = this };
                    elm.Construire(e);
                    ListePorteur.Add(elm);
                    ok = true;
                }
                if (typeelement == type_BUDGET_ENVELOPPE)
                {
                    Budget_Enveloppe elm = new Budget_Enveloppe() { Acces = this };
                    elm.Construire(e);
                    ListeBudgetEnveloppe.Add(elm);
                    ok = true;
                }
                if (typeelement == type_BUDGET)
                {
                    Budget elm = new Budget() { Acces = this };
                    elm.Construire(e);
                    ListeBudget.Add(elm);
                    ok = true;
                }
                if (typeelement == type_BUDGET_PERIODE)
                {
                    Budget_Periode elm = new Budget_Periode() { Acces = this };
                    elm.Construire(e);
                    ListeBudget_Periode.Add(elm);
                    ok = true;
                }
                if (typeelement == type_BUDGET_LIGNE)
                {
                    Budget_Ligne elm = new Budget_Ligne() { Acces = this };
                    elm.Construire(e);
                    ListeBudget_Ligne.Add(elm);
                    ok = true;
                }
                if (typeelement == type_BUDGET_NOMENCLATURE)
                {
                    Budget_Nomenclature elm = new Budget_Nomenclature() { Acces = this };
                    elm.Construire(e);
                    ListeBudget_Nomenclature.Add(elm);
                    ok = true;
                }
                if (typeelement == type_BUDGET_VERSION)
                {
                    Budget_Version elm = new Budget_Version() { Acces = this };
                    elm.Construire(e);
                    ListeBudget_Version.Add(elm);
                    ok = true;
                }
                if (typeelement == type_BUDGET_OPERATION)
                {
                    Budget_Operation elm = new Budget_Operation() { Acces = this };
                    elm.Construire(e);
                    ListeBudget_Operation.Add(elm);
                    ok = true;
                }
                if (typeelement == type_BUDGET_VIREMENT)
                {
                    Budget_Virement elm = new Budget_Virement() { Acces = this };
                    elm.Construire(e);
                    ListeBudget_Virement.Add(elm);
                    ok = true;
                }
                if (typeelement == type_MODELEDOC)
                {
                    ModeleDoc elm = new ModeleDoc() { Acces = this };
                    elm.Construire(e);
                    ListeModeleDoc.Add(elm);
                    ok = true;
                }
                //******* AJOUTER ICI le bloc de conversion
            }

            //Tri de la liste et renvoi de l'objet de type LIST
            if (typeelement == type_PLAN) { ListePlan.Sort(); return ListePlan; }
            if (typeelement == type_OBJECTIF) { ListeObjectif.Sort(); return ListeObjectif; }
            if (typeelement == type_ACTION) { ListeAction.Sort(); return ListeAction; }
            if (typeelement == type_INDICATEUR) { ListeIndicateur.Sort(); return ListeIndicateur; }
            if (typeelement == type_UTILISATEUR) { ListeUtilisateur.Sort(); return ListeUtilisateur; }
            if (typeelement == type_GROUPE) { ListeGroupe.Sort(); return ListeGroupe; }

            if (typeelement == type_PROJET) { ListeProjet.Sort(); return ListeProjet; }
            if (typeelement == type_PROCESSUS) { ListeProcessus.Sort(); return ListeProcessus; }
            if (typeelement == type_PORTEUR) { ListePorteur.Sort(); return ListePorteur; }

            if (typeelement == type_BUDGET_ENVELOPPE) { ListeBudgetEnveloppe.Sort(); return ListeBudgetEnveloppe; }
            if (typeelement == type_BUDGET) { ListeBudget.Sort(); return ListeBudget; }
            if (typeelement == type_BUDGET_PERIODE) { ListeBudget_Periode.Sort(); return ListeBudget_Periode; }
            if (typeelement == type_BUDGET_LIGNE) { ListeBudget_Ligne.Sort(); return ListeBudget_Ligne; }
            if (typeelement == type_BUDGET_NOMENCLATURE) { ListeBudget_Nomenclature.Sort(); return ListeBudget_Nomenclature; }
            if (typeelement == type_BUDGET_VERSION) { ListeBudget_Version.Sort(); return ListeBudget_Version; }
            if (typeelement == type_BUDGET_OPERATION) { ListeBudget_Operation.Sort(); return ListeBudget_Operation; }
            if (typeelement == type_BUDGET_VIREMENT) { ListeBudget_Virement.Sort(); return ListeBudget_Virement; }

            if (typeelement == type_MODELEDOC) { ListeModeleDoc.Sort(); return ListeModeleDoc; }

            //***** AJOUTER ICI la partie pour renvoyer la liste d'éléments

            MessageBox.Show("Type element " + typeelement.Code + " non trouvé !");
            return null;
        }

        //Permet de modifier la valeur d'activation des éléments
        public void Modifier_Element(TypeElement typeelement, int ID, Boolean Actif)
        {
            //Mise à jour de la base
            string sql;
            sql = "UPDATE element SET actif='" + (Actif ? "1" : "0") + "'";
            sql += " WHERE element_type ='" + typeelement.ID + "'";
            sql += " AND id='" + ID + "'";

            cls.Execute(sql);

            //Application aux éléments chargés

            foreach (Element e in Liste_Element)
            {
                if (e.ID == ID && e.Element_Type == typeelement.ID) { e.Actif = Actif; break; }
            }
        }

        //Remplit la liste avec les détail des éléments
        public List<dElement> Remplir_ListedElement()
        {
            return Liste_dElement;
        }

        /// <summary>
        /// Charge la liste des liens pour un ensemble défini (ex  plan)
        /// </summary>
        /// <param name="element_type"></param>
        /// <param name="element_id"></param>
        /// <returns></returns>
        public List<Lien> Remplir_ListeLien_Niv0(TypeElement element_type, string element_id = "")
        {
            List<Lien> Liste = new List<Lien>();

            foreach (Lien l in ListeLien)
            {
                if (l.Element0_Type == element_type.ID)
                {
                    if (element_type.ID > 0)
                    {
                        if (l.Element0_ID == int.Parse(element_id)) { Liste.Add(l); }
                    }
                    else { Liste.Add(l); }
                }
            }

            return Liste;
        }

        /// <summary>
        /// Charge la liste des liens pour un sous-ensemble défini (ex  action-projet)
        /// </summary>
        /// <param name="element_type"></param>
        /// <param name="element_id"></param>
        /// <returns></returns>
        public List<Lien> Remplir_ListeLien_Niv1(TypeElement element_type, string element_id = "")
        {
            List<Lien> Liste = new List<Lien>();

            foreach (Lien l in ListeLien)
            {
                if (l.Element1_Type == element_type.ID)
                {
                    if (element_type.ID > 0)
                    {
                        if (l.Element1_ID == int.Parse(element_id)) { Liste.Add(l); }
                    }
                    else { Liste.Add(l); }
                }
            }

            return Liste;
        }

        //Charge la liste des liens pour un ensemble défini (ex  plan) dont le type niveau 1 et 2 sont identiques
        public List<Lien> Remplir_ListeLienSYSTEME(TypeElement element_type, string Element1_ID = "", string Element2_ID = "")
        {
            List<Lien> Liste = new List<Lien>();

            foreach (Lien l in ListeLien)
            {
                if (l.Element0_Type == Trouver_TableValeur_Code("TYPE_ELEMENT", type_PLAN.Code).ID && l.Element0_ID == 1)
                {
                    if (l.Element1_Type == element_type.ID && l.Element2_Type == element_type.ID)
                    {
                        Boolean ok1 = (Element1_ID.Length > 0) ? l.Element1_ID == int.Parse(Element1_ID) : true;
                        Boolean ok2 = (Element2_ID.Length > 0) ? l.Element2_ID == int.Parse(Element2_ID) : true;

                        if (ok1 && ok2) { Liste.Add(l); }
                    }
                    //else { Liste.Add(l); }
                }
            }

            return Liste;
        }

        //Charge la liste des liens ayant comme parent l'id de l'élément passé
        public Lien Donner_LienParent(int id)
        {
            foreach (Lien l in ListeLien)
            {
                if (l.ID == id) { return l; }
            }

            return null;
        }

        //Enregistre un élement
        public void Enregistrer(TypeElement typeelement, Classe_Modele obj)
        {
            //bool ok = false;
            Element e = new Element() { Acces = this, };
            e.Element_Type = typeelement.ID;

            //Le principe de la déconstruction est de mettre sous la forme 
            // Element - dElement les informations contenues dans chaque objet
            // La mise à jour va modifier les informations principales et
            // mettre à jour les informations secondaires si elles sont différentes.
                
            e = obj.Déconstruire();
            e.Acces = this;
            e.MettreAJour();

           // if (!ok) { MessageBox.Show("Enregistrement de l'élément non codé"); }

            //Actualise la liste de référence principale
            foreach (Element el in Liste_Element)
            {
                if (el.ID == e.ID)
                {
                    //Mise à jour des informations principales
                    Liste_Element.Remove(el);
                    Liste_Element.Add(e);

                    //Mise à jour des détails de l'élement dans la liste de référence
                    foreach (dElement del in el.Liste)
                    {
                        if (del.Element_ID == e.ID) { Liste_dElement.Remove(del); }
                    }

                    foreach (dElement d in e.Liste) { Liste_dElement.Add(d); }
                    break;
                }
            }
        }
    
        //Trouve l'ID d'un attribut dans la liste selon son code
        public bool Trouver_Attribut_ID(TypeElement typeelement, string code = "", string valeur = "")
        {
            foreach (Attribut att in ListeAttribut)
            {
                if (att.Element_Type == typeelement.ID && att.Code == code)
                {
                    return true;
                }
            }

            return false;
        }

        //Trouve le libellé d'un attribut dans la liste selon son code
        public string Trouver_Attribut_Libelle(string code = "")
        {
            string libelle = "";

            foreach (Attribut att in ListeAttribut)
            {
                if (att.Code == code)
                {
                    libelle = att.Libelle;
                    break;
                }
            }

            //if(ID==0) { Console.Ajouter("L'attribut [" + code + "] de type " + typeelement + " non trouvé");  }
            return libelle;
        }

        //Trouve un attribut par son ID
        public Attribut Trouver_Attribut(int ID)
        {
            foreach (Attribut att in ListeAttribut)
            {
                if (att.ID == ID)
                {
                    return att;
                }
            }

            return null;
        }

        public Attribut Trouver_Attribut(TypeElement typeElement, string Code)
        {
            foreach (Attribut att in ListeAttribut)
            {
                if (att.Element_Type == typeElement.ID && att.Code == Code)
                {
                    return att;
                }
            }

            return new Attribut();
        }

        //Trouve un paramètre par son ID
        public Parametre Trouver_Parametre(int ID)
        {
            foreach (Parametre p in ListeParametre)
            {
                if (p.ID == ID)
                {
                    return p;
                }
            }

            return null;
        }

        //Trouve un paramètre par son ID
        public Parametre Trouver_Parametre(string Code)
        {
            foreach (Parametre p in ListeParametre)
            {
                if (p.Code == Code)
                {
                    return p;
                }
            }

            return null;
        }

        //Trouve l'attribut 6PO d'un attribut dans la liste selon son code
        public string Trouver_Attribut_6PO(TypeElement typeelement, string code = "")
        {
            string att6po = "";

            foreach (Attribut att in ListeAttribut)
            {
                if (att.Element_Type == typeelement.ID && att.Code == code)
                {
                    att6po = att.ATT_6PO;
                    break;
                }
            }

            return att6po;
        }

        //Trouve l'ID dans une table de valeur correspondant au nom et à la valeur indiqués
        public int Trouver_TableValeur_ID(string nom, string valeur)
        {
            int ID = 0;

            foreach (table_valeur tv in ListeTableValeur)
            {
                if (tv.Nom == nom && tv.Valeur == valeur)
                {
                    ID = tv.ID;
                    break;
                }
            }

            return ID;
        }

        //Trouve une table de valeur par son ID
        public table_valeur Trouver_TableValeur(int id)
        {
            foreach (table_valeur tv in ListeTableValeur)
            {
                if (tv.ID == id)
                {
                    return tv;
                }
            }

            return null;
        }

        //Trouve l'ID dans une table de valeur correspondant au nom et à la valeur indiqués
        public table_valeur Trouver_TableValeur_Code(string nom, string Code)
        {
            foreach (table_valeur tv in ListeTableValeur)
            {
                if (tv.Nom == nom && tv.Code == Code)
                {
                    return tv;
                }
            }

            MessageBox.Show("Code non trouvé : " + Code + " pour " + nom);
            return new table_valeur();
        }

        //Trouve le TypeElement par le code de l'élément
        public TypeElement Trouver_Type_Element(string Code)
        {
            foreach (TypeElement tp in ListeTypeElement)
            {
                if (tp.Code == Code) { return tp; }
            }

            MessageBox.Show("Code non trouvé : " + Code);
            return new TypeElement();
        }

        //Trouve le TypeElement pat l'ID de l'élément
        public TypeElement Trouver_Type_Element(int id)
        {
            foreach (TypeElement tp in ListeTypeElement)
            {
                if (tp.ID == id) { return tp; }
            }

            MessageBox.Show("Code non trouvé : " + id);
            return new TypeElement();
        }

        //Trouve l'élément tv dans une table de valeur correspondant au nom et à la valeur indiqués
        public string Trouver_TableValeur_Valeur(string nom, string Valeur, string attribut="CODE")
        {
            foreach (table_valeur tv in ListeTableValeur)
            {
                if (tv.Nom == nom && tv.Valeur == Valeur)
                {
                    switch(attribut)
                    {
                        case "CODE": return tv.Code;
                        case "ID": return tv.ID.ToString(); 
                        case "6PO": return tv.Valeur6PO;
                    }
                }
            }

            return "";
        }

        //Trouve la valeur associée dans 6PO
        public string Trouver_TableValeur_6PO(string nom, int ID)
        {
            foreach (table_valeur tv in ListeTableValeur)
            {
                if (tv.Nom == nom && tv.ID == ID)
                {
                    return tv.Valeur6PO;
                }
            }

            return "";
        }

        public string Trouver_TableValeur_6PO(string nom, string valeur)
        {
            foreach (table_valeur tv in ListeTableValeur)
            {
                if (tv.Nom == nom && tv.Valeur == valeur)
                {
                    return tv.Valeur6PO;
                }
            }

            return "";
        }

        //Donne le niveau et la valeur associée dans 6PO
        public void Donner_TableValeur_6PO(string nom_debut, string valeur, ref string nom_fin, ref string niveau, ref string valeurNiveau)
        {
            foreach (table_valeur tv in ListeTableValeur)
            {
                if (tv.Nom.Contains(nom_debut) && tv.ID == int.Parse(valeur))
                {
                    nom_fin = tv.Nom;
                    niveau = tv.Code;
                    valeurNiveau = tv.Valeur6PO;
                    break;
                }
            }
        }

        //Mise à jour de la liste des détails (récupération des id des détails
        public void Actualiser_dElement(int ID)
        {
            string sql = "";

            List<dElement> Liste = new List<dElement>();

            foreach (dElement d in Liste_dElement)
            {
                if (d.Element_ID != ID) { Liste.Add(d); }
            }

            //Recherche des éléments en base pour avoir l'ID
            sql = "SELECT * FROM delement";
            sql += " WHERE element_id='" + ID + "'";
            DataSet Sn = cls.ContenuRequete(sql);

            if (cls.NbLignes > 0)
            {
                foreach (DataRow r in Sn.Tables["dataset"].Rows)
                {
                    dElement d = new dElement();
                    d.ID = int.Parse(r["id"].ToString());
                    d.Element_ID = int.Parse(r["element_id"].ToString());
                    d.Attribut_ID = int.Parse(r["attribut_id"].ToString());
                    d.Attribut_Code = r["attribut_code"].ToString();
                    d.Valeur = r["valeur"].ToString();
                    Liste.Add(d);
                }
            }
            Liste_dElement = Liste;
        }

        //Renvoie la valeur d'un paramètre
        public string Donner_ValeurParametre(string Code)
        {
            foreach (Parametre p in ListeParametre)
            {
                if (p.Code == Code) { return p.Valeur; }
            }

            return null;
        }

        //retourne la liste des valeurs pour une table de valeurs précise
        public List<table_valeur> Remplir_ListeTableValeur(string nom)
        {
            Charger_ListeTableValeur();
            List<table_valeur> Liste = new List<table_valeur>();

            foreach (table_valeur a in ListeTableValeur)
            {
                if (a.Nom == nom)
                {
                    Liste.Add(a);
                }
            }
            Liste.Sort();
            return Liste;
        }

        //Retourne la liste des différentes tables de valeurs
        public List<string> Remplir_ListeTableValeurNom(string ordre = "ASC")
        {
            List<string> Liste = new List<string>();

            string sql;

            sql = "SELECT DISTINCT nom FROM table_valeur";
            sql += (ordre == "ASC") ? " ORDER BY 1" : " ORDER BY 1 DESC";
            DataSet Sn = cls.ContenuRequete(sql);
            foreach (DataRow r in Sn.Tables["dataset"].Rows)
            {
                Liste.Add(r[0].ToString());
            }
            return Liste;
        }

        //Renvoie la la liste des actions dont un utilisateur est membre
        public List<PATIO.CAPA.Classes.Action> Donner_ListeActionMembre(int id_user)
        {
            List<PATIO.CAPA.Classes.Action> Liste = new List<PATIO.CAPA.Classes.Action>();
            Attribut att = Trouver_Attribut(type_ACTION, "EQUIPE");
            int attribut_id = att.ID;

            foreach (dElement d in Liste_dElement)
            {
                if (d.Valeur == id_user.ToString() && d.Attribut_ID == attribut_id)
                {
                    PATIO.CAPA.Classes.Action a1 = (PATIO.CAPA.Classes.Action)Trouver_Element(type_ACTION, d.Element_ID);
                    Boolean ok = false;
                    foreach (PATIO.CAPA.Classes.Action a0 in Liste)
                    { if (a1.ID == a0.ID) { ok = true; break; } }
                    if (!ok) { Liste.Add(a1); }
                }
            }

            return Liste;
        }

        //Renvoie la liste des utilisateurs ayant un rôle (aus ens 6PO) pour un objet de gestion
        //Co-pilote, manager, consultation
        public List<Utilisateur> Donner_ListeEquipeMembre(int element_id, string Role)
        {
            List<Utilisateur> Liste = new List<Utilisateur>();

            foreach (dElement d in Liste_dElement)
            {
                if (d.Element_ID == (int)element_id && d.Attribut_Code == Role)
                {
                    Utilisateur u1 = (Utilisateur)Trouver_Element(type_UTILISATEUR, int.Parse(d.Valeur));
                    Liste.Add(u1);
                }
            }
            return Liste;
        }

        public void Sauvegarder_local()
        {
            string fichier;
            DataSet Sn;

            //Répertoire
            if (!System.IO.Directory.Exists(CheminTemp + "\\Save")) { System.IO.Directory.CreateDirectory(CheminTemp + "\\Save"); }

            //Fichier Element
            fichier = CheminTemp + "\\Save\\element.xml";
            if (System.IO.File.Exists(fichier)) { System.IO.File.Delete(fichier); }
            Sn = cls.ContenuRequete("SELECT * FROM element");
            Sn.WriteXml(fichier);

            //Fichier dElement
            fichier = CheminTemp + "\\Save\\delement.xml";
            if (System.IO.File.Exists(fichier)) { System.IO.File.Delete(fichier); }
            Sn = cls.ContenuRequete("SELECT * FROM delement");
            Sn.WriteXml(fichier);

            //Fichier Lien
            fichier = CheminTemp + "\\Save\\lien.xml";
            if (System.IO.File.Exists(fichier)) { System.IO.File.Delete(fichier); }
            Sn = cls.ContenuRequete("SELECT * FROM lien");
            Sn.WriteXml(fichier);

            //Fichier Attriut
            fichier = CheminTemp + "\\Save\\attribut.xml";
            if (System.IO.File.Exists(fichier)) { System.IO.File.Delete(fichier); }
            Sn = cls.ContenuRequete("SELECT * FROM attribut");
            Sn.WriteXml(fichier);

            //Fichier Table de Valeur
            fichier = CheminTemp + "\\Save\\table_valeur.xml";
            if (System.IO.File.Exists(fichier)) { System.IO.File.Delete(fichier); }
            Sn = cls.ContenuRequete("SELECT * FROM table_valeur");
            Sn.WriteXml(fichier);

            //Fichier Parametre
            fichier = CheminTemp + "\\Save\\parametre.xml";
            if (System.IO.File.Exists(fichier)) { System.IO.File.Delete(fichier); }
            Sn = cls.ContenuRequete("SELECT * FROM parametre");
            Sn.WriteXml(fichier);
        }

        public void MettreAJour_dElement(int element_id, string valeur_prec, string valeur_suiv, string attribut_code, int attribut_id)
        {
            string sql;

            //Suppression de l'ancienne valeur
            if (valeur_prec.Length > 0)
            {
                sql = "DELETE FROM delement";
                sql += " WHERE element_id='" + element_id + "'";
                sql += " AND attribut_code='" + attribut_code + "'";
                sql += " AND valeur='" + valeur_prec + "'";
                cls.Execute(sql);
            }

            //Insertion de la nouvelle valeur
            sql = "INSERT INTO delement(element_id, attribut_id, attribut_code, valeur) VALUES (";
            sql += "'" + element_id + "',";
            sql += "'" + attribut_id + "',";
            sql += "'" + attribut_code + "',";
            sql += "'" + valeur_suiv + "')";
            cls.Execute(sql);

            int id = 0;
            sql = "SELECT id FROM delement";
            sql += " WHERE element_id='" + element_id + "'";
            sql += " AND attribut_code='" + attribut_code + "'";
            sql += " AND valeur='" + valeur_suiv + "'";
            DataSet sn = cls.ContenuRequete(sql);
            if (cls.NbLignes > 0) { id = int.Parse(sn.Tables["dataset"].Rows[0][0].ToString()); }
            else { MessageBox.Show("Problème avec l'id"); }

            //Construction du nouveau dElement
            dElement d_new = new dElement();
            d_new.ID = id;
            d_new.Element_ID = element_id;
            d_new.Attribut_ID = attribut_id;
            d_new.Attribut_Code = attribut_code;
            d_new.Valeur = valeur_suiv;

            //Application sur Element
            foreach (Element e in Liste_Element)
            {
                if (e.ID == element_id)
                {
                    foreach (dElement d in e.Liste)
                    {
                        if (d.Attribut_Code == attribut_code && d.Valeur == valeur_prec)
                        { e.Liste.Remove(d); break; }
                    }
                    e.Liste.Add(d_new);
                    break;
                }
            }

            //Application sur la liste dElement
            foreach (dElement d in Liste_dElement)
            {
                if (d.Element_ID == element_id && d.Attribut_Code == attribut_code && d.Valeur == valeur_prec)
                { Liste_dElement.Remove(d); break; }
            }
            Liste_dElement.Add(d_new);
        }

        //Modifie les dates pour l'ensemble des éléments d'un plan
        public void Modifier_Dates_Plan(Plan plan)
        {
            List<Lien> Liste = Remplir_ListeLien_Niv0(type_PLAN, plan.ID.ToString());

            //Objectif
            List<Objectif> ListeObj =(List<Objectif>) Remplir_ListeElement(type_OBJECTIF, "");

            foreach (Lien l in Liste)
            {
                foreach (Objectif obj in ListeObj)
                {
                    if(l.Element2_ID == obj.ID && obj.Code.Contains(plan.Abrege))
                    {
                        obj.DateDebut = plan.DateDebut;
                        obj.DateFin = plan.DateFin;
                        Enregistrer(type_OBJECTIF, obj);
                        break;
                    }
                }
            }

            //Action
            List<PATIO.CAPA.Classes.Action> ListeAction = (List<PATIO.CAPA.Classes.Action>)Remplir_ListeElement(type_ACTION, "");

            foreach (Lien l in Liste)
            {
                foreach (PATIO.CAPA.Classes.Action action in ListeAction)
                {
                    if (l.Element2_ID == action.ID && action.Code.Contains(plan.Abrege))
                    {
                        action.DateDebut = plan.DateDebut;
                        action.DateFin = plan.DateFin;
                        Enregistrer(type_ACTION, action);
                        break;
                    }
                }
            }
        }

        public Boolean Supprimer_dElement(int element_id, int attribut_id)
        {
            string sql;

            sql = "DELETE FROM delement";
            sql += " WHERE element_id='" + element_id + "'";
            sql += " AND attribut_id='" + attribut_id + "'";

            this.cls.Execute(sql);
            if (this.cls.erreur.Length > 0) { return false; }

            return true;
        }

        /// <summary>
        /// Renvoie une chaîne de caractère contenant les valeurs des indices de table de valeurs
        /// </summary>
        /// <param name="Liste"></param> Liste des indices de table de valeurs
        /// <param name="nom_tv"></param> nom de la table de valeurs
        /// <param name="valeur"></param> permet de retourner la valeur correspondante (cas des tables multiples)
        /// <param name="raccourci"></param> permet d'iniquer de couper les valeurs retournées au séparateur :
        /// <returns></returns>
        public string Donner_Chaine_Liste(List<int> Liste, string nom_tv, string valeur="", Boolean raccourci=false)
        {
            string Texte = "";

            foreach (table_valeur tv in this.Remplir_ListeTableValeur(nom_tv))
            {
                Boolean ok = false;
                foreach (int k in Liste)
                {
                    if (tv.ID == k)
                    {
                        if(valeur.Length>0)
                        { if(tv.Nom == valeur) { ok = true; break; }}
                        else { ok = true; break; }
                    }
                }
                if (ok)
                {
                    string val_final = tv.Valeur;
                    if(raccourci) { val_final = val_final.Split(':')[0].Trim(); }
                    Texte += ((Texte.Length > 0) ? ", " : "") + val_final;
                }
            }
            return Texte;
        }

        /// </summary>
        /// <param name="Liste"></param> Liste des indices de table de valeurs
        /// <param name="nom_tv"></param> nom de la table de valeurs
        /// <param name="valeur"></param> permet de retourner la valeur correspondante (cas des tables multiples)
        /// <param name="raccourci"></param> permet d'iniquer de couper les valeurs retournées au séparateur :
        /// <returns></returns>
        public string Donner_Chaine_Liste_Utilisateur(List<int> Liste)
        {
            string Texte = "";

            foreach (Utilisateur user in (List<Utilisateur>) this.Remplir_ListeElement(type_UTILISATEUR,""))
            {
                foreach (int k in Liste)
                {
                    if (user.ID == k)
                    {
                        Texte += ((Texte.Length > 0) ? ", " : "") + user.Nom + " " + user.Prenom;
                    }
                }
            }
            return Texte;
        }

        public Boolean Exister_Valeur(List<int> Liste, string nom_tv, string valeur, string code, Boolean ToutesValeurs = false)
        {
            foreach (table_valeur tv in this.Remplir_ListeTableValeur(nom_tv))
            {
                foreach (int k in Liste)
                {
                    if (tv.ID == k)
                    {
                        if (ToutesValeurs) { return true; }
                        if (valeur.Length > 0 && tv.Valeur == valeur) { return true; }
                        if (code.Length > 0 && tv.Code == code) { return true; }
                    }
                }
            }
            return false;
        }

        public void Nettoyer()
        {
            string sql;

            //Supprime les liens PARENT=ENFANT
            sql = "DELETE FROM Lien WHERE Element1_ID = Element2_ID";
            this.cls.Execute(sql);
        }

        /// <summary>
        /// Retourne la liste des liens affectant un élément
        /// </summary>
        /// <param name="id_element"></param> Identifiant de l'élément
        /// <returns></returns>
        public List<Lien> Remplir_ListeLienDirection(int id_direction, Boolean pilote, Boolean associe)
        {
            List<int> ListeElement = new List<int>();

            //Recherche des éléments concernés
            foreach (dElement d in Liste_dElement)
            {
                if (d.Attribut_Code == "DIRECTION_PILOTE" && d.Valeur == id_direction.ToString() && pilote)
                {
                    if (ListeElement.IndexOf(d.Element_ID) < 0) { ListeElement.Add(d.Element_ID); }
                }

                if (d.Attribut_Code == "DIRECTION_ASSOCIE" && d.Valeur == id_direction.ToString() && associe)
                {
                    if (ListeElement.IndexOf(d.Element_ID) < 0) { ListeElement.Add(d.Element_ID); }
                }
            }

            List<Lien> lLiens = new List<Lien>();
            lLiens = this.Remplir_ListeLienElement(ListeElement);

            return lLiens;
        }

        /// <summary>
        /// Retourne la liste des liens affectant un élément
        /// </summary>
        /// <param name="id_territoire"></param> Identifiant du territoire
        /// <returns></returns>
        public List<Lien> Remplir_ListeLienTerritoire(int id_territoire)
        {
            List<int> ListeElement = new List<int>();

            //Recherche des éléments concernés
            foreach (dElement d in Liste_dElement)
            {
                if (d.Attribut_Code == "TSANTE" && d.Valeur == id_territoire.ToString())
                {
                    if (ListeElement.IndexOf(d.Element_ID) < 0) { ListeElement.Add(d.Element_ID); }
                }
            }

            List<Lien> lLiens = new List<Lien>();
            lLiens = this.Remplir_ListeLienElement(ListeElement);

            return lLiens;
        }

        /// <summary>
        /// Retourne la liste des liens affectant un élément
        /// </summary>
        /// <param name="id_territoire"></param> Identifiant du territoire
        /// <returns></returns>
        public List<Lien> Remplir_ListeLienRelationPriorité(string id_territoire)
        {
            List<int> ListeElement = new List<int>();

            List<table_valeur> tv = this.Remplir_ListeTableValeur(id_territoire);

            //Recherche des éléments concernés
            foreach (dElement d in Liste_dElement)
            {
                foreach (table_valeur tvv in tv)
                {
                    if (d.Attribut_Code == "PRIORITE_CTS" && d.Valeur == tvv.ID.ToString())
                    {
                        if (ListeElement.IndexOf(d.Element_ID) < 0) { ListeElement.Add(d.Element_ID); }
                    }
                }
            }

            List<Lien> lLiens = new List<Lien>();
            lLiens = this.Remplir_ListeLienElement(ListeElement);

            return lLiens;
        }

        /// <summary>
        /// Retourne les liens affectant les ID passés en paramètre
        /// </summary>
        /// <param name="id_element"></param>
        /// <returns></returns>
        public List<Lien> Remplir_ListeLienElement(List<int> Liste)
        {
            string chaine = "";

            foreach(int e in Liste)
            {
                chaine += ((chaine.Length > 0) ? "," : "") + e.ToString();
            }
            if(chaine.Length == 0) { return null; }

            List<Lien> lLien = new List<Lien>();
            string sql;

            sql = "SELECT * FROM lien";
            sql += " WHERE (Element0_ID in (" + chaine + ")";
            sql += " OR Element1_ID in (" + chaine + ")";
            sql += " OR Element2_ID in (" + chaine + "))";
            sql += " AND Element0_Code <> 'SYSTEME'"; // hormis les liens système
            DataSet Sn = cls.ContenuRequete(sql);
            if (cls.NbLignes == 0) { return lLien; }

            foreach (DataRow r in Sn.Tables["dataset"].Rows)
            {
                Lien l = new Lien();
                l.ID = int.Parse(r["id"].ToString());
                l.Element0_ID = int.Parse(r["Element0_ID"].ToString());
                l.Element0_Type = int.Parse(r["Element0_Type"].ToString());
                l.Element0_Code = r["Element0_Code"].ToString();
                l.Element1_ID = int.Parse(r["Element1_ID"].ToString());
                l.Element1_Type = int.Parse(r["Element1_Type"].ToString());
                l.Element1_Code = r["Element1_Code"].ToString();
                l.Element2_ID = int.Parse(r["Element2_ID"].ToString());
                l.Element2_Type = int.Parse(r["Element2_Type"].ToString());
                l.Element2_Code = r["Element2_Code"].ToString();
                l.ordre = int.Parse(r["ordre"].ToString());
                l.complement = r["complement"].ToString();

                if (lLien.IndexOf(l) < 0) { lLien.Add(l); }
            }

            return lLien;
        }

        /// <summary>
        /// Procédure d'export du contenu d'une liste de liens vers un fichier texte
        /// </summary>
        /// <param name="Liste"></param>
        public void Exporter_Lien(List<Lien> Liste)
        {
            string fichier = CheminTemp + "\\Fichiers\\liens.txt";
            string Texte = "";

            foreach(Lien l in Liste)
            {
                Texte += l.ID.ToString() + "\t";
                Texte += l.Element0_Type.ToString() + "\t";
                Texte += l.Element0_ID.ToString() + "\t";
                Texte += l.Element0_Code.ToString() + "\t";
                Texte += l.Element1_Type.ToString() + "\t";
                Texte += l.Element1_ID.ToString() + "\t";
                Texte += l.Element1_Code.ToString() + "\t";
                Texte += l.Element2_Type.ToString() + "\t";
                Texte += l.Element2_ID.ToString() + "\t";
                Texte += l.Element2_Code.ToString() + "\t";
                Texte += l.ordre.ToString() + "\t";
                Texte += l.complement.ToString() + "\t";

                string ordrelien = l.Element0_Type.ToString()
                           + l.Element1_Type.ToString()
                           + l.Element2_Type.ToString()
                           + l.Element0_Code + l.Element1_Code
                           + string.Format("{0,5:X5}", l.ordre);
                Texte += ordrelien + "\n";
            }

            System.IO.File.WriteAllText(fichier, Texte);

        }

        /// <summary>
        /// Permet de créer l'arborescence globale
        /// puis de supprimer les noeuds non inclus
        /// </summary>
        public TreeNode Donner_ArbreGlobal()
        {
            TreeNode NodG = new TreeNode();

            //On charge la liste globale des liens, correspond à l'ensemble des éléments utilisés
            Charger_Lien(false); //On ne prend pas les liens organisant les liens du système (intra-élément)
            ListeLien.Sort();

            //Phase 1 : Plan (element0)
            foreach(Lien l in ListeLien)
            {
                if(l.Element0_Type == type_PLAN.ID && l.Element0_Code != "SYSTEME")
                {
                    if (NodG.Nodes.Find(l.Element0_ID.ToString(), true).Length == 0)
                    {
                        Plan plan = (Plan)Trouver_Element(type_PLAN, l.Element0_ID);

                        if (plan != null)
                        {
                            TreeNode nd = new TreeNode();
                            nd.Text = plan.Libelle;
                            nd.Name = plan.ID.ToString();
                            nd.Tag = "0";
                            nd.ToolTipText = nd.Name;
                            nd.ToolTipText = "0";
                            nd.Tag = l;
                            NodG.Nodes.Add(nd);
                        }
                    }
                }
            }

            //Phase 2 : Objectifs (element2 de type Objectif)
            foreach (Lien l in ListeLien)
            {
                if (l.Element2_Type == type_OBJECTIF.ID && l.Element0_Code != "SYSTEME")
                {
                    if (NodG.Nodes.Find(l.Element2_ID.ToString(), true).Length == 0)
                    {
                        Objectif obj = (Objectif)Trouver_Element(type_OBJECTIF, l.Element2_ID);

                        TreeNode nd = new TreeNode();
                        nd.Text = obj.Libelle;
                        nd.Name = obj.ID.ToString();
                        nd.Tag = "0";
                        nd.ToolTipText = nd.Name;
                        nd.ToolTipText = "0";
                        nd.Tag = l;

                        //Recherche du parent
                        TreeNode[] nod = NodG.Nodes.Find(l.Element1_ID.ToString(), true);
                        if (nod.Length > 0) { nod[0].Nodes.Add(nd); }
                        //else { MessageBox.Show("Non trouvé " + l.Element1_ID); }
                    }
                }
            }

            //Phase 3 : Actions (element2 de type Action)
            foreach (Lien l in ListeLien)
            {
                if (l.Element2_Type == type_ACTION.ID && l.Element0_Code != "SYSTEME")
                {
                    if (NodG.Nodes.Find(l.Element2_ID.ToString(), true).Length == 0)
                    {
                        PATIO.CAPA.Classes.Action action = (PATIO.CAPA.Classes.Action)Trouver_Element(type_ACTION, l.Element2_ID);

                        if (action != null)
                        {
                            TreeNode nd = new TreeNode();
                            nd.Text = action.Libelle;
                            nd.Name = action.ID.ToString();
                            nd.Tag = "0";
                            nd.ToolTipText = nd.Name;
                            nd.ToolTipText = "0";
                            nd.Tag = l;

                            //Recherche du parent
                            TreeNode[] nod = NodG.Nodes.Find(l.Element1_ID.ToString(), true);
                            if (nod.Length > 0) { nod[0].Nodes.Add(nd); }
                        }
                    }
                }
            }

            return NodG; //Retourne l'arbre avec en premiers noeuds la liste des plans construits
        }

        /// <summary>
        /// Procédure permettant d'avoir la liste des noeus finaux (sans enfant) d'un arbre
        /// </summary>
        /// <param name="Nod"></param> Noeud à traiter
        /// <param name="Liste"></param> Liste des noeuds finaux
        public void Donner_ListeNoeudFinaux(TreeNode Nod,ref List<TreeNode> Liste)
        {
            //Le noeud n'a pas d'enfant (=final) -> on l'ajoute à la liste
            if (Nod.Nodes.Count == 0) { Liste.Add(Nod); }
            else
            {
                //Le noeud a des enfants -> on les parcoure (récursivité)
                foreach (TreeNode nd in Nod.Nodes) { Donner_ListeNoeudFinaux(nd, ref Liste); }
            }
        }

        /// <summary>
        /// Procédure d'exclusion d'un arbre des noeuds à inclure
        /// </summary>
        /// <param name="NodG"></param>
        /// <param name="Liste"></param>
        /// <returns></returns>
        public TreeNode Exclure_Arbre(TreeNode NodG, List<Lien> Liste, ref List<Lien> ListeLien)
        {
            TreeNode Nd = new TreeNode();
            List<TreeNode> ListeInclus = new List<TreeNode>();

            //Inclusion des noeuds correspondant aux éléments utilisés par les liens
            foreach(Lien l in Liste)
            {
                TreeNode[] nod = NodG.Nodes.Find(l.Element2_ID.ToString(),true);

                foreach(TreeNode nod1 in nod)
                {
                    nod1.Tag = "1";
                    nod1.ToolTipText = "1";
                    EtendreInclusion(nod1);
                    ListeInclus.Add(nod1);
                    ListeLien.Add(l);
                }

                if(nod.Length == 0) { Console.Ajouter("[X] Lien non inclus : " + l.Element2_ID.ToString()); }
            }

            //Recherche des noeuds finaux (noeuds sans enfant)
            List<TreeNode> ListeNoeud = new List<TreeNode>();
            Donner_ListeNoeudFinaux(NodG,ref ListeNoeud);

            //Exclusion des noeuds non identifiés comme inclus
            ExclureNoeud(ref NodG, ListeInclus, ListeNoeud);

            return Nd;
        }

        /// <summary>
        /// Etend la sélectiondu noeud à ses parents successifs
        /// </summary>
        /// <param name="Nod"></param>
        void EtendreInclusion(TreeNode Nod)
        {
            if (Nod == null) { return; }
            if (Nod.Parent == null) { return; }
            if (Nod.Parent.Tag != null)
            {
                if (Nod.Parent.Tag.ToString() == "1") { return; }
            }
            else { Nod.Parent.Tag = "0"; }

            try
            {
                Lien l = (Lien)Nod.Parent.Tag;
                Boolean ok = false;
                foreach (Lien l1 in ListeLien) { if (l == l1) { ok = true; break; } }
                if (!ok) { ListeLien.Add(l); }
            }
            catch { }
            Nod.Parent.Tag = "1";
            Nod.Parent.ToolTipText = "1";
            EtendreInclusion(Nod.Parent);
        }

        /// <summary>
        /// Supprime les noeuds de l'arbre
        /// </summary>
        /// <param name="Nod"></param> Arbre à traiter
        /// <param name="ListeInclus"></param> Liste des noeuds à inclure
        /// <param name="ListeNoeud"></param> Liste globale des noeufs finaux (sans enfant)
        void ExclureNoeud(ref TreeNode Nod, List<TreeNode> ListeInclus, List<TreeNode> ListeNoeud)
        {
            foreach(TreeNode nd1 in ListeNoeud)
            {
                //Recherche si le noeud fait partie des noeuds inclus
                Boolean ok = false;
                foreach(TreeNode nd2 in ListeInclus)
                {
                    if(nd1 == nd2) { ok = true; break; }
                }

                //Le noeud ne fait pas partie des inclus donc on le supprime et on remonte ses parents pour les enlever aussi si Tag=0
                if (!ok)
                {
                    nd1.ToolTipText = "X";
                    if (nd1.Parent != null)
                    {
                        if (nd1.Parent.Tag.ToString() == "0") { EtendreExclusion(ref Nod, nd1.Parent); }
                    }
                    Nod.Nodes.Remove(nd1);
                }
            }

            int n = 0;
            do
            {
                n = 0;
                foreach (TreeNode nd in Nod.Nodes)
                {
                    SupprimeNoeud(ref Nod, nd, ref n);
                }
                Console.Ajouter("[N] " + n);
                //if (n == 0) { break; }
            } while (n > 0);
        }

        void SupprimeNoeud(ref TreeNode NodG, TreeNode Nod, ref int n)
        {
            if(Nod == null) { return; }

            if (Nod.Tag.ToString() != "1")
            {
                n++;
                NodG.Nodes.Remove(Nod);
            }

            foreach (TreeNode nd in Nod.Nodes) { SupprimeNoeud(ref NodG, nd, ref n); }
        }

        /// <summary>
        /// Exclut le noeud et poursuit avec son noeud parent
        /// </summary>
        /// <param name="Nod"></param>
        void EtendreExclusion(ref TreeNode NodG, TreeNode Nod)
        {
            if (Nod != null)
            {
                if (Nod.Tag.ToString() == "0")
                {
                    Nod.ToolTipText = "X";
                    if (Nod.Parent != null)
                    {
                        if (Nod.Parent.Tag.ToString() == "0") { EtendreExclusion(ref NodG, Nod.Parent); }
                    }
                    NodG.Nodes.Remove(Nod);
                }
            }
        }

        public void Trouver_User_Admin()
        {
            user_admin = (user_appli.TypeUtilisateur == TypeUtilisateur.ADMINISTRATEUR);
        }

        Boolean DonneDroit(int typeelement, int id_element, Utilisateur user)
        {
            if(user.TypeUtilisateur==TypeUtilisateur.ADMINISTRATEUR) { return true; }

            int mdate = int.Parse(string.Format("0:yyyymmdd", DateTime.Now));

            foreach(Droit d in ListeDroit)
            {
                if((typeelement.ToString() + ":" + id_element.ToString() == d.Code) &&
                    (int.Parse(d.datedeb)<= mdate) && (int.Parse(d.datefin) >= mdate))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
