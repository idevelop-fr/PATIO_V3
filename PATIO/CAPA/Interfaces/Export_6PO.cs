using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;
using PATIO.CAPA.Classes;
using PATIO.MAIN.Classes;
using System.Windows.Forms;
using System.IO;
using WeifenLuo.WinFormsUI.Docking;
using PATIO.ADMIN.Classes;

namespace PATIO.CAPA.Interfaces
{
    public class Export_6PO
    {
        public AccesNet Acces;
        public ctrlConsole Console;
        public DockPanel DP;

        public string Chemin;
        public Plan plan;
        public List<Lien> listeLien;

        List<Objectif> lObj = new List<Objectif>();
        Microsoft.Office.Interop.Excel.Application app;
        public string Texte_Resultat = "";

        class LigneTV
        {
            public LigneTV(string code, string libelle)
            {
                Code = code;
                Libelle = libelle;
            }
            public string Code;
            public string Libelle;
        }

        //Exportation de l'ensemble des éléments d'un plan
        public void Exporter6PO(bool modif=false)
        {
            DateTime d1 = DateTime.Now;

            //Création de l'application Excel
            app = new Microsoft.Office.Interop.Excel.Application();
            app.DisplayAlerts = false;

            Console.Ajouter("Export du plan...");
            Console.Ajouter(plan.NiveauPlan.ToString());

            Texte_Resultat = "EXPORTATION 6PO" + "\r\n";
            Texte_Resultat += "Plan d'actions : " + plan.Libelle + "\r\n";

            //Extraction des liens
            listeLien = Acces.Remplir_ListeLien_Niv0(Acces.type_PLAN, plan.ID.ToString());

            //Exportation de la hiérarchie
            Texte_Resultat += "### Export de la hoérarchie ###" + "\r\n";
            switch (plan.NiveauPlan)
            {
                case NiveauPlan.Niveau_2:
                    {
                        Texte_Resultat += "Plan de niveau 2 : pas de fichier de structure" + "\r\n";
                        //Pas d'export de la hiérarchie de plan
                        //ExportPlan_N2();
                        break;
                    }
                case NiveauPlan.Niveau_3:
                    {
                        Texte_Resultat += "Plan de niveau 3 : fichier de structure créé" + "\r\n";
                        Console.Ajouter("->Plan niveau 3");
                        ExportPlan_N3();
                        break;
                    }
                case NiveauPlan.Niveau_4:
                    {
                        Texte_Resultat += "Plan de niveau 4 : fichier de structure créé" + "\r\n";
                        Console.Ajouter("->Plan niveau 4");
                        ExportPlan_N4();
                        break;
                    }
                case NiveauPlan.Niveau_5:
                    {
                        Texte_Resultat += "Plan de niveau 5 : fichier de structure créé" + "\r\n";
                        Console.Ajouter("->Plan niveau 5");
                        ExportPlan_N5();
                        break;
                    }
            }

            //Exportation des objectifs
            Console.Ajouter("->Export des objectifs...");
            Texte_Resultat += "### Export des objectifs ###" + "\r\n";
            ExportObjectif(modif);

            //Exportation des actions
            Console.Ajouter("->Export des actions...");
            Texte_Resultat += "### Export des actions ###" + "\r\n";
            ExportAction(modif);

            //Exportation des utilisateurs
            Texte_Resultat += "### Export des utilisateurs ###" + "\r\n";
            Console.Ajouter("->Export des utilisateurs...");
            ExportUtilisateur();

            //Exportation des tables de valeurs -> référentiels
            if (MessageBox.Show("Voulez-vous exporter les tables de valeurs ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Texte_Resultat += "### Export des tables de valeurs ###" + "\r\n";
                Console.Ajouter("->Export des tables de valeurs...");
                ExportTableValeur();
            }

            Console.Ajouter("...Fin Export Plan");
            DateTime d2 = DateTime.Now;
            Texte_Resultat += "### Fin de l'export ###" + "\r\n";
            Texte_Resultat += "Temps : " + string.Format("{0:ss}",d2-d1) + "\r\n";
            //Afficher_Resultat();

            //Fermeture de l'application Excel
            app.Quit();
            app = null;
        }

        //Exportation de la hiérarchie de niveau 2 (inexistante avec l'évolution des sous-actions
        void ExportPlan_N2()
        {
            var fichier = Chemin + "\\Fichiers\\" + "PLAN-" + plan.Code;
            Console.Ajouter("->Cible : " + fichier);

            app.Workbooks.Add();

            Workbooks wk = app.Workbooks;
            Workbook wb = app.ActiveWorkbook;
            Worksheet ws = wb.Sheets[1];
            Range r;
            int n = 1;
            int niveau = 2;

            //Renommage de la feuille 1
            ws.Name = "Hiérarchies";

            //Entêtes
            for (int i = 0; i < niveau; i++)
            {
                r = ws.Cells[n, 3 * i + 1];
                r.Value = "Libelle_VN";
                r = ws.Cells[n, 3 * i + 2];
                r.Value = "Code_VN";
                r = ws.Cells[n, 3 * i + 3];
                r.Value = "Description_VN";
            }

            //Ligne explicative
            n++;
            for (int i = 1; i < niveau; i++)
            {
                r = ws.Cells[n, 3 * i + 1];
                r.Value = "Niveau " + i + "/" + niveau;
                r = ws.Cells[n, 3 * i + 2];
                r.Value = "HIER_PLAN_" + niveau + "NIV_" + i;
            }
            r = ws.Cells[n, 1];
            r.Value = "Plan/Programme";

            //Liste des objectifs de 1er niveau
            Console.Ajouter("->Nb lignes :" + listeLien.Count.ToString());
            foreach (var l in listeLien)
            {
                if (l.element2_type == Acces.type_OBJECTIF.ID && l.element1_type == Acces.type_PLAN.ID)
                {
                    Objectif Obj =(Objectif) Acces.Trouver_Element(Acces.type_OBJECTIF, l.element2_id);

                    n++;
                    r = ws.Cells[n, 1];
                    r.Value = Obj.Libelle;
                    r = ws.Cells[n, 2];
                    r.Value = Obj.Code;

                    lObj.Add(Obj);
                }
            }

            File.Delete(fichier + ".xlsx");

            wb.SaveAs(fichier);

            wb.Close(false);
            wk.Close();
            app.Quit();
        }

        //Exportation de la hiérarchie de niveau 3
        //Il y a 2 niveaux d'objectifs : l'un est intégré à la hiérachie de plan
        void ExportPlan_N3()
        {
            var fichier = Chemin + "\\Fichiers\\" + "PLAN-" + plan.Code;
            Console.Ajouter("->Cible : " + fichier);

            app.Workbooks.Add();

            Workbooks wk = app.Workbooks;
            Workbook wb = app.ActiveWorkbook;
            Worksheet ws = wb.Sheets[1];
            Range r;
            int n = 1;
            int niveau = 3;

            //Renommage de la feuille 1
            ws.Name = "Hiérarchies";

            //Entêtes
            for (int i = 0; i < niveau; i++)
            {
                r = ws.Cells[n, 3 * i + 1];
                r.Value = "Libelle_VN";
                r = ws.Cells[n, 3 * i + 2];
                r.Value = "Code_VN";
                r = ws.Cells[n, 3 * i + 3];
                r.Value = "Description_VN";
            }

            //Ligne explicative
            n++;
            for (int i = 1; i < niveau; i++)
            {
                r = ws.Cells[n, 3 * i + 1];
                r.Value = "Niveau " + i + "/" + niveau;
                r = ws.Cells[n, 3 * i + 2];
                r.Value = "HIER_PLAN_" + niveau + "NIV_" + i;
            }
            r = ws.Cells[n, 1];
            r.Value = "Plan/Programme";

            //Liste des objectifs de 1er niveau
            Console.Ajouter("->Nb lignes :" + listeLien.Count.ToString());
            int k = 0;
            foreach (var l in listeLien)
            {
                //On cherche un objectif (element2_type) qui n'est pas un objectif opérationnel
                //et le parent de l'objectif est le plan
                if (l.element1_type == Acces.type_PLAN.ID && l.element2_type == Acces.type_OBJECTIF.ID)
                {
                    Objectif Obj = (Objectif)Acces.Trouver_Element(Acces.type_OBJECTIF, l.element2_id);

                    if (Obj.TypeObjectif != TypeObjectif.OPERATIONNEL)
                    {
                        n++;
                        r = ws.Cells[n, 1];
                        r.Value = Obj.Libelle;
                        r = ws.Cells[n, 2];
                        r.Value = Obj.Code;

                        lObj.Add(Obj);
                        k++;
                    }
                }
            }
            Texte_Resultat += "Nb objectifs : " + k + "\r\n";

            File.Delete(fichier + ".xlsx");

            File.Delete(fichier);

            wb.SaveAs(fichier);

            wb.Close();
            wk.Close();
        }

        //Exportation de la hiérarchie de niveau 4
        //Il y a 3 niveaux d'objectifs : les 2 premiers sont intégrés à la hiérachie de plan
        void ExportPlan_N4()
        {
            var fichier = Chemin + "\\Fichiers\\" + "PLAN-" + plan.Code;
            Console.Ajouter("->Cible : " + fichier);

            app.Workbooks.Add();

            Workbooks wk = app.Workbooks;
            Workbook wb = app.ActiveWorkbook;
            Worksheet ws = wb.Sheets[1];
            Range r;
            int n = 1;
            int niveau = 4;

            //Renommage de la feuille 1
            ws.Name = "Hiérarchies";

            //Entêtes
            for (int i = 0; i < niveau; i++)
            {
                r = ws.Cells[n, 3 * i + 1];
                r.Value = "Libelle_VN";
                r = ws.Cells[n, 3 * i + 2];
                r.Value = "Code_VN";
                r = ws.Cells[n, 3 * i + 3];
                r.Value = "Description_VN";
            }

            //Ligne explicative
            n++;
            for (int i = 1; i < niveau; i++)
            {
                r = ws.Cells[n, 3 * i + 1];
                r.Value = "Niveau " + i + "/" + niveau;
                r = ws.Cells[n, 3 * i + 2];
                r.Value = "HIER_PLAN_" + niveau + "NIV_" + i;
            }
            r = ws.Cells[n, 1];
            r.Value = "Plan/Programme";

            //Liste des objectifs de 1er niveau et 2ème niveau
            Console.Ajouter("->Nb lignes : " + listeLien.Count.ToString());

            int k = 0;
            foreach (var l in listeLien)
            {
                //l'élément principal est un objectif ainsi que son parent
                if (l.element1_type == Acces.type_OBJECTIF.ID && l.element2_type == Acces.type_OBJECTIF.ID)
                {
                    Objectif Obj2 = (Objectif)Acces.Trouver_Element(Acces.type_OBJECTIF, l.element2_id);

                    //On exclut les objectifs opérationnels sensés correspondre au niveau Objectif de 6PO
                    if (Obj2.TypeObjectif != TypeObjectif.OPERATIONNEL)
                    {
                        Objectif Obj1 = (Objectif)Acces.Trouver_Element(Acces.type_OBJECTIF, l.element1_id); //Parent
                        n++;
                        r = ws.Cells[n, 1];
                        r.Value = Obj1.Libelle;
                        r = ws.Cells[n, 2];
                        r.Value = Obj1.Code;

                        r = ws.Cells[n, 4];
                        r.Value = Obj2.Libelle;
                        r = ws.Cells[n, 5];
                        r.Value = Obj2.Code;

                        lObj.Add(Obj2);
                        k++;
                    }
                }
                Texte_Resultat += "Nb objectifs : " + k + "\r\n";
            }

            File.Delete(fichier + ".xlsx");
            wb.SaveAs(fichier);

            wb.Close();
            wk.Close();
        }

        //Exportation de la hiérarchie de niveau 5
        void ExportPlan_N5()
        {
            var fichier = Chemin + "\\Fichiers\\" + "PLAN-" + plan.Code;
            Console.Ajouter("->Cible : " + fichier);

            app.Workbooks.Add();

            Workbooks wk = app.Workbooks;
            Workbook wb = app.ActiveWorkbook;
            Worksheet ws = wb.Sheets[1];
            Range r;
            int n = 1;
            int niveau = 5;

            //Renommage de la feuille 1
            ws.Name = "Hiérarchies";

            //Entêtes
            for (int i = 0; i < niveau; i++)
            {
                r = ws.Cells[n, 3 * i + 1];
                r.Value = "Libelle_VN";
                r = ws.Cells[n, 3 * i + 2];
                r.Value = "Code_VN";
                r = ws.Cells[n, 3 * i + 3];
                r.Value = "Description_VN";
            }

            //Ligne explicative
            n++;
            for (int i = 1; i < niveau; i++)
            {
                r = ws.Cells[n, 3 * i + 1];
                r.Value = "Niveau " + i + "/" + niveau;
                r = ws.Cells[n, 3 * i + 2];
                r.Value = "HIER_PLAN_" + niveau + "NIV_" + i;
            }
            r = ws.Cells[n, 1];
            r.Value = "Plan/Programme";

            //Liste des objectifs de 1er niveau et 2ème niveau
            Console.Ajouter("->Nb lignes : " + listeLien.Count.ToString());
            int k = 0;
            foreach (var l1 in listeLien)
            {
                if (l1.element2_type == Acces.type_OBJECTIF.ID
                    && l1.element1_type == Acces.type_PLAN.ID)
                {
                    Objectif Obj1 = (Objectif) Acces.Trouver_Element(Acces.type_OBJECTIF,l1.element2_id);
                    lObj.Add(Obj1);

                    foreach (var l2 in listeLien)
                    {
                        if (l2.element1_id == l1.element2_id 
                            && l2.element1_type == Acces.type_OBJECTIF.ID
                            && l2.element2_type == Acces.type_OBJECTIF.ID)
                        {
                            Objectif Obj2 =(Objectif) Acces.Trouver_Element(Acces.type_OBJECTIF,l2.element2_id);

                            n++;
                            r = ws.Cells[n, 1];
                            r.Value = Obj1.Libelle;
                            r = ws.Cells[n, 2];
                            r.Value = Obj1.Code;
                            r = ws.Cells[n, 4];
                            r.Value = Obj2.Libelle;
                            r = ws.Cells[n, 5];
                            r.Value = Obj2.Code;

                            lObj.Add(Obj2);
                            k++;
                        }
                    }
                }
                Texte_Resultat += "Nb objectifs : " + k + "\r\n";
            }

            File.Delete(fichier + ".xlsx");

            wb.SaveAs(fichier);

            wb.Close();
            wk.Close();
        }

        //Exportation de la liste des objectifs d'un plan -> Il s'agit de la liste des actions
        void ExportObjectif(bool modif)
        {
            var fichier = Chemin + "\\Fichiers\\" + "OBJ-" + plan.Code;

            Workbooks wk = app.Workbooks;
            Workbook wb = app.Workbooks.Add();

            //Création des feuilles
            int nb_feuilles = wb.Sheets.Count;

            Worksheet ws1 = wb.Sheets.Add(); ws1.Name = "ACT-";
            Worksheet ws2 = wb.Sheets.Add(After: ws1); ws2.Name = "RAT-" + ((modif) ? "-DIFF" : "");
            Worksheet ws3 = wb.Sheets.Add(After: ws2); ws3.Name = "EQU-" + ((modif) ? "-DIFF" : "");
            Worksheet ws4 = wb.Sheets.Add(After: ws3); ws4.Name = "ATT-";
            Worksheet ws5 = wb.Sheets.Add(After: ws4); ws5.Name = "PLA-";
            Worksheet ws6 = wb.Sheets.Add(After: ws5); ws6.Name = "IND-";
            Worksheet ws7 = wb.Sheets.Add(After: ws6); ws7.Name = "IND-PLAN";

            //Suppression des feuilles déjà existantes
            for (var i = nb_feuilles + 7; i > 7; i--) 
            {
                Worksheet w = wb.Sheets[i];
                w.Delete();
            }

            Range r;
            int n1 = 1; int n2 = 1; int n3 = 1; int n4 = 1;
            //int n5 = 1;
            int n6 = 1; int n7 = 1;
            List<Objectif> Liste = new List<Objectif>();

            //Création des entêtes
            Entete_Objectif(ws1);
            Entete_Objectif(ws2);
            Entete_Objectif(ws3);
            Entete_Objectif(ws4);
            Entete_Objectif(ws5);
            Entete_Objectif(ws6);
            Entete_Objectif(ws7);

            //Détermine le niveau le plus faible d'objectif
            int type_objectif = 0;
            foreach(var l in listeLien)
            {
                if(l.element2_type == Acces.type_OBJECTIF.ID)
                {
                    Objectif Obj = (Objectif)Acces.Trouver_Element(Acces.type_OBJECTIF, l.element2_id);
                    if (Obj != null)
                    {
                        if ((int)Obj.TypeObjectif > type_objectif) { type_objectif = (int)Obj.TypeObjectif; }
                    }
                }
            }

            //Liste des objectifs n'ayant pas été intégrés dans la structure
            //Onglet ACT + RAT
            int k = 0;
            foreach (var l in listeLien)
            {
                if (l.element2_type == Acces.type_OBJECTIF.ID)
                    //if (l.element1_type == Acces.type_OBJECTIF && l.element2_type == Acces.type_ACTION)
                {
                    //PATIO.CAPA.Classes.Action action = (PATIO.CAPA.Classes.Action)Acces.Trouver_Element(Acces.type_ACTION, l.element2_id);
                    Objectif Obj = (Objectif)Acces.Trouver_Element(Acces.type_OBJECTIF, l.element2_id);
                    Objectif Obj2 =(Objectif) Acces.Trouver_Element(Acces.type_OBJECTIF, l.element1_id);

                    if(Obj == null) { goto Suite; }
                    if ((int) Obj.TypeObjectif != type_objectif) { goto Suite; }
                    //if (Obj.TypeObjectif != TypeObjectif.OPERATIONNEL) { goto Suite; }

                    //Onglet 1: ACT-
                    n1++;
                    r = ws1.Cells[n1, 1];
                    r.Value = Obj.Code;
                    r = ws1.Cells[n1, 2];
                    r.Value = Obj.Libelle.Substring(0, System.Math.Min(Obj.Libelle.Length, 250));
                    r = ws1.Cells[n1, 3];
                    try { r.Value = Obj.Pilote.Code; } catch { }
                    r = ws1.Cells[n1, 4];
                    r.Value = Acces.Trouver_TableValeur_6PO("STATUT", (int) Obj.Statut); //"A débuter";
                    r = ws1.Cells[n1, 5];
                    r.Value = string.Format("{0:dd/MM/yyyy}", Obj.DateDebut);
                    r = ws1.Cells[n1, 6];
                    r.Value = string.Format("{0:dd/MM/yyyy}", Obj.DateFin);
                    r = ws1.Cells[n1, 7];
                    try { r.Value = Obj.Description.Substring(0, System.Math.Min(Obj.Description.Length, 1500)); } catch { }
                    r = ws1.Cells[n1, 8];
                    r.Value = Obj2.Code;

                    Liste.Add(Obj); //Ajout de l'objectif pour la suite de l'export
                    k++;
                    //Onglet 2 : RAT- A priori cet onglet ne sert pas pour les objectifs
                    n2++;
                    /*r = ws2.Cells[n2, 1];
                    r.Value = action.Code;
                    r = ws2.Cells[n2, 2];
                    r.Value = "HIER_HDF";
                    r = ws2.Cells[n2, 3];
                    r.Value = "REGION";
                    r = ws2.Cells[n2, 4];
                    r.Value = "REGION";*/
                    Suite:;
                }
            }
            Texte_Resultat += "Nb Objectifs : " + k + "\r\n";

            //Onglet RAT : complément avec les référentiels
            Texte_Resultat += "--> Rattachements des objectifs" + "\r\n";
            AjouteRattachementObjectif(Liste, ref n2, ref ws2);

            //Onglet EQU : Equipe
            Texte_Resultat += "--> Equipe projets des objectifs" + "\r\n";
            AjouteEquipeObjectif(Liste, ref n3, ref ws3);

            //Onglet ATT : Attributs
            Texte_Resultat += "--> Attributs des objectifs" + "\r\n";
            AjouteAttributObjectif(Liste, ref n4, ref ws4);

            //Onglet IND : Indicateurs
            Texte_Resultat += "--> Indicateurs des objectifs" + "\r\n";
            AjouteIndicateurObjectif(Liste, ref n6, ref ws6, "IND");

            //Onglet IND-PLAN : Indicateurs
            AjouteIndicateurObjectif(Liste, ref n7, ref ws7, "IND-PLAN");

            if (File.Exists(fichier + ".xls")) { File.Delete(fichier + ".xls"); }

            wb.SaveAs(fichier + ".xls");
            wb.SaveAs(fichier + ".xls", XlFileFormat.xlExcel8);

            wb.Close();
            wk.Close();
        }

        //Ajoute les éléments relatifs aux attributs
        void AjouteAttributObjectif(List<Objectif> Liste, ref int n, ref Worksheet ws)
        {
            int k = 0;
            Range r;
            foreach (Objectif obj in Liste)
            {
                Element e = new Element() { Acces = Acces, };
                e = obj.Déconstruire();

                foreach (dElement d in e.Liste)
                {
                    string attribut = Acces.Trouver_Attribut_6PO(Acces.type_ACTION, d.Attribut_Code);
                    string valeur = Acces.Trouver_TableValeur_6PO(d.Attribut_Code, d.Valeur);

                    if (!(d.Valeur is null))
                    {
                        if (valeur.Length == 0)
                        {
                            if (d.Valeur.Length == 0)
                            { attribut = ""; } //Sans valeur on n'ajoute pas
                            else
                            {
                                switch (attribut)
                                {
                                    case "CHEF_DE_PROJET":
                                        {
                                            Utilisateur user = (Utilisateur)Acces.Trouver_Element(Acces.type_UTILISATEUR, int.Parse(d.Valeur));
                                            valeur = user.Code;
                                            if (valeur.Contains("[")) { valeur = ""; }
                                            break;
                                        }

                                    default:
                                        {
                                            valeur = d.Valeur;
                                            break;
                                        }
                                }
                            }
                        }

                        if (attribut.Length > 0 && valeur.Length > 0)
                        {
                            n++;
                            r = ws.Cells[n, 1];
                            r.Value = obj.Code;
                            r = ws.Cells[n, 2];
                            r.Value = attribut;
                            r = ws.Cells[n, 3];
                            r.Value = valeur; //Afficher la valeur de la table des valeurs correspondante
                            k++;
                        }
                    }
                }
            }
            Texte_Resultat += "Nb Attributs : " + k + "\r\n";
        }

        //Ajoute les informations relatives à l'équipe
        void AjouteEquipeObjectif(List<Objectif> Liste, ref int n, ref Worksheet ws)
        {
            int k = 0;
            Range r;
            List<Utilisateur> Liste_Membre = new List<Utilisateur>();
            foreach (Objectif obj in Liste)
            {
                //Co-pilote
                Liste_Membre = Acces.Donner_ListeEquipeMembre(obj.ID, "ROLE_6PO_COPILOTE");
                foreach (Utilisateur u in Liste_Membre)
                {
                    n++;
                    r = ws.Cells[n, 1];
                    r.Value = obj.Code;
                    r = ws.Cells[n, 2];
                    r.Value = "Co-Pilote";
                    r = ws.Cells[n, 3];
                    r.Value = u.Code;
                    k++;
                }

                //Manager
                Liste_Membre = Acces.Donner_ListeEquipeMembre(obj.ID, "ROLE_6PO_MANAGER");
                foreach (Utilisateur u in Liste_Membre)
                {
                    n++;
                    r = ws.Cells[n, 1];
                    r.Value = obj.Code;
                    r = ws.Cells[n, 2];
                    r.Value = "Manager";
                    r = ws.Cells[n, 3];
                    r.Value = u.Code;
                    k++;
                }

                //Consultation
                Liste_Membre = Acces.Donner_ListeEquipeMembre(obj.ID, "ROLE_6PO_CONSULTATION");
                foreach (Utilisateur u in Liste_Membre)
                {
                    n++;
                    r = ws.Cells[n, 1];
                    r.Value = obj.Code;
                    r = ws.Cells[n, 2];
                    r.Value = "Consultation";
                    r = ws.Cells[n, 3];
                    r.Value = u.Code;
                    k++;
                }
            }
            Texte_Resultat += "Nb Membres de l'équipe : " + k + "\r\n";
        }

        //Ajoute les rattachements aux référentiels
        void AjouteRattachementObjectif(List<Objectif> Liste, ref int n, ref Worksheet ws)
        {
            Texte_Resultat += "Nb Rattachements : non utilisé" + "\r\n";
            /*
            foreach (Objectif obj in Liste)
            {
                Element e = new Element() { Acces = Acces, };
                e = obj.Déconstruire();

                Console.Ajouter("[OBJECTIF] " + obj.Code);
                foreach (dElement d in e.Liste)
                {
                    string hierarchie = "";
                    string Niveau = "";
                    string ValeurNiveau = "";
                    Console.Ajouter("[-->] " + d.Attribut_Code);

                    //Traitement de chaque référentiel
                    switch (d.Attribut_Code)
                    {
                        case "ANALYSE_QUALITATIVE":
                            {
                                n++;
                                hierarchie = "PUBLIC_CIBLE";
                                Niveau = hierarchie;
                                ValeurNiveau = Acces.Trouver_TableValeur_6PO(hierarchie, d.Valeur);
                                break;
                            }
                    }

                    //Ajout des informations dans le fichier
                    if (ValeurNiveau.Trim().Length > 0)
                    {
                        Range r;
                        r = ws.Cells[n, 1];
                        r.Value = obj.Code;
                        r = ws.Cells[n, 2];
                        r.Value = hierarchie; //Hiérarchie
                        r = ws.Cells[n, 3];
                        r.Value = Niveau; //Niveau
                        r = ws.Cells[n, 4];
                        r.Value = ValeurNiveau; //Valeur de niveau
                    }
                }
            }*/
        }

        //Export de la liste des actions d'un plan -> Il s'agit de la liste des opérations
        void ExportAction(bool modif)
        {
            string fichier =Chemin + "\\Fichiers\\" + "ACT-" + plan.Code;

            Workbooks wk = app.Workbooks;
            Workbook wb = app.Workbooks.Add();

            //Création des feuilles
            int nb_feuilles = wb.Sheets.Count;

            Worksheet ws1 = wb.Sheets.Add(); ws1.Name = "PRJ-";
            Worksheet ws2 = wb.Sheets.Add(After: ws1); ws2.Name = "RAT-" + ((modif) ? "-DIFF" : "");
            Worksheet ws3 = wb.Sheets.Add(After: ws2); ws3.Name = "EQU-" + ((modif) ? "-DIFF" : "");
            Worksheet ws4 = wb.Sheets.Add(After: ws3); ws4.Name = "ATT-";
            Worksheet ws5 = wb.Sheets.Add(After: ws4); ws5.Name = "PLA-";
            Worksheet ws6 = wb.Sheets.Add(After: ws5); ws6.Name = "IND-";
            Worksheet ws7 = wb.Sheets.Add(After: ws6); ws7.Name = "IND-PLAN";

            //Suppression des feuilles déjà existantes
            for (var i = nb_feuilles + 7; i > 7; i--) 
            {
                Worksheet w = wb.Sheets[i];
                w.Delete();
            }

            Range r;
            int n1 = 1; int n2 = 1; int n3 = 1; int n4 = 1;
            //int n5 = 1;
            int n6 = 1; int n7 = 1;

            List<PATIO.CAPA.Classes.Action> Liste = new List<PATIO.CAPA.Classes.Action>();

            //Création des entêtes
            {
                Entete_Action(ws1);
                Entete_Action(ws2);
                Entete_Action(ws3);
                Entete_Action(ws4);
                Entete_Action(ws5);
                Entete_Action(ws6);
                Entete_Action(ws7);
            }

            //Détermine les paramètres de rattachement
            string Niveau = ""; string ValeurNiveau = "";
            Donner_NiveauValeur6PO(plan, ref Niveau, ref ValeurNiveau);

            //Liste des objectifs n'ayant pas été intégrés dans la structure
            //Onglet PRJ + RAT
            int k_action = 0;
            int k_ope = 0;
            foreach (var l in listeLien)
            {
                if (l.element2_type == Acces.type_ACTION.ID)
                    //if (l.element1_type == Acces.type_ACTION && l.element2_type == Acces.type_ACTION)
                {
                    PATIO.CAPA.Classes.Action action1 = (PATIO.CAPA.Classes.Action)Acces.Trouver_Element(Acces.type_ACTION, l.element1_id);
                    PATIO.CAPA.Classes.Action action2 =(PATIO.CAPA.Classes.Action) Acces.Trouver_Element(Acces.type_ACTION, l.element2_id);

                    if(action2 is null) { MessageBox.Show("id lien : " + l.ID.ToString(), "Action 2 null"); }
                    //Onglet 1: ACT-
                    n1++;
                    r = ws1.Cells[n1, 1];
                    r.Value = action2.Code;
                    r = ws1.Cells[n1, 2];
                    r.Value = action2.Libelle.Substring(0, System.Math.Min(action2.Libelle.Length, 250));
                    r = ws1.Cells[n1, 3];
                    try { r.Value = action2.Pilote.Code; } catch { }
                    r = ws1.Cells[n1, 4];
                    r.Value = Acces.Trouver_TableValeur_6PO("STATUT",(int) action2.Statut);// "A débuter";// action.Statut.ToString().Replace("_", " ");
                    r = ws1.Cells[n1, 5];
                    r.Value = string.Format("{0:dd/MM/yyyy}", action2.DateDebut);
                    r = ws1.Cells[n1, 6];
                    r.Value = string.Format("{0:dd/MM/yyyy}", action2.DateFin);
                    r = ws1.Cells[n1, 7];
                    try { r.Value = action2.Description.Substring(0, System.Math.Min(action2.Description.Length, 1500)); } catch { }
                    // Le code indiqué à cet endroit entraîne la créaton des liens Actions Parent-Enfant
                    r = ws1.Cells[n1, 8];
                    if (action2.TypeAction == TypeAction.OPERATION) { r.Value = action1.Code; }

                    Liste.Add(action2); //Liste utilisée pour la suite de l'export

                    //Onglet 2 : RAT- A priori cet onglet ne sert pas pour les objectif
                    //Cas d'une opération => rattachement à l'objectif et non à l'action
                    string rattache = "";
                    if(action2.TypeAction == TypeAction.OPERATION)
                    {
                        k_ope++;
                        foreach(Lien lr in listeLien)
                        {
                            if(lr.element2_id == action1.ID)
                            {
                                rattache = lr.element1_code;
                                break;
                            }
                        }
                    }
                    else
                    {
                        k_action++;
                        rattache = action1.Code;
                    }

                    n2++;
                    r = ws2.Cells[n2, 1];
                    r.Value = action2.Code;
                    r = ws2.Cells[n2, 2];
                    r.Value = Niveau;
                    r = ws2.Cells[n2, 3];
                    r.Value = ValeurNiveau; 
                    r = ws2.Cells[n2, 4];
                    r.Value = rattache; 
                }
            }
            Texte_Resultat += "Nb Actions : " + k_action + "\r\n";
            Texte_Resultat += "Nb Opérations : " + k_ope + "\r\n";

            //Onglet RAT : complément avec les référentiels
            Texte_Resultat += "--> Rattachements des actions" + "\r\n";
            AjouteRattachementAction(Liste, ref n2, ref ws2);

            //Onglet EQU : Equipe
            Texte_Resultat += "--> Equipes des actions" + "\r\n";
            AjouteEquipeAction(Liste, ref n3, ref ws3);

            //Onglet ATT : Attributs
            Texte_Resultat += "--> Attributs des actions" + "\r\n";
            AjouteAttributAction(Liste, ref n4, ref ws4);

            //Onglet IND : Indicateurs
            Texte_Resultat += "--> Indicateurs des actions" + "\r\n";
            AjouteIndicateurAction(Liste, ref n6, ref ws6, "IND");

            //Onglet IND-PLAN : Indicateurs
            AjouteIndicateurAction(Liste, ref n7, ref ws7, "IND-PLAN");

            if (File.Exists(fichier + ".xls")) { File.Delete(fichier + ".xls"); }

            wb.SaveAs(fichier + ".xls");
            wb.SaveAs(fichier + ".xls", XlFileFormat.xlExcel8);

            wb.Close();
            wk.Close();
        }

        //Ajoute les éléments relatifs aux attributs
        void AjouteAttributAction(List<PATIO.CAPA.Classes.Action> Liste, ref int n, ref Worksheet ws)
        {
            int k = 0;
            Range r;
            foreach (PATIO.CAPA.Classes.Action action in Liste)
            {
                Element e = new Element() { Acces = Acces, };
                e = action.Déconstruire();

                foreach (dElement d in e.Liste)
                {
                    string attribut = Acces.Trouver_Attribut_6PO(Acces.type_ACTION, d.Attribut_Code);
                    string valeur = Acces.Trouver_TableValeur_6PO(d.Attribut_Code, d.Valeur);

                    if (d.Valeur != null)
                    {
                        if (valeur.Length == 0)
                        {
                            if (d.Valeur.Length == 0)
                            { attribut = ""; } //Sans valeur on n'ajoute pas
                            else
                            {
                                switch(attribut)
                                {
                                    case "CHEF_DE_PROJET":
                                        {
                                            Utilisateur user = (Utilisateur)Acces.Trouver_Element(Acces.type_UTILISATEUR, int.Parse(d.Valeur));
                                            valeur = user.Code;
                                            if (valeur.Contains("[")) { valeur = ""; }
                                            break;
                                        }

                                    default:
                                        {
                                            valeur = d.Valeur;
                                            break;
                                        }
                                }
                            }
                        }

                        if (attribut.Length > 0 && valeur.Length>0 )
                        {
                            n++;
                            r = ws.Cells[n, 1];
                            r.Value = action.Code;
                            r = ws.Cells[n, 2];
                            r.Value = attribut;
                            r = ws.Cells[n, 3];
                            r.Value = valeur; //Afficher la valeur de la table des valeurs correspondante
                            k++;
                        }
                    }
                }
            }
            Texte_Resultat += "Nb Attributs : " + k + "\r\n";

        }

        //Ajoute les informations relatives à l'équipe
        void AjouteEquipeAction(List<PATIO.CAPA.Classes.Action> Liste, ref int n, ref Worksheet ws)
        {
            int k = 0;
            Range r;
            List<Utilisateur> Liste_Membre = new List<Utilisateur>();
            foreach (PATIO.CAPA.Classes.Action action in Liste)
            {
                //Co-pilote
                Liste_Membre = Acces.Donner_ListeEquipeMembre(action.ID, "ROLE_6PO_COPILOTE");
                foreach (Utilisateur u in Liste_Membre)
                {
                    n++;
                    r = ws.Cells[n, 1];
                    r.Value = action.Code;
                    r = ws.Cells[n, 2];
                    r.Value = "Co-Pilote";
                    r = ws.Cells[n, 3];
                    r.Value = u.Code;
                    k++;
                }

                //Manager
                Liste_Membre = Acces.Donner_ListeEquipeMembre(action.ID, "ROLE_6PO_MANAGER");
                foreach (Utilisateur u in Liste_Membre)
                {
                    n++;
                    r = ws.Cells[n, 1];
                    r.Value = action.Code;
                    r = ws.Cells[n, 2];
                    r.Value = "Manager";
                    r = ws.Cells[n, 3];
                    r.Value = u.Code;
                    k++;
                }

                //Consultation
                Liste_Membre = Acces.Donner_ListeEquipeMembre(action.ID, "ROLE_6PO_CONSULTATION");
                foreach (Utilisateur u in Liste_Membre)
                {
                    n++;
                    r = ws.Cells[n, 1];
                    r.Value = action.Code;
                    r = ws.Cells[n, 2];
                    r.Value = "Consultation";
                    r = ws.Cells[n, 3];
                    r.Value = u.Code;
                    k++;
                }
            }
            Texte_Resultat += "Nb Membres de l'équipe : " + k + "\r\n";
        }

        //Ajoute les rattachements aux référentiels
        void AjouteRattachementAction(List<PATIO.CAPA.Classes.Action> Liste, ref int n, ref Worksheet ws)
        {
            int k = 0;
            foreach (PATIO.CAPA.Classes.Action action in Liste)
            {
                Element e = new Element() { Acces = Acces, };
                e = action.Déconstruire();

                Console.Ajouter("[ACTION] " + action.Code);
                foreach (dElement d in e.Liste)
                {
                    string hierarchie = "";
                    string Niveau = "";
                    string ValeurNiveau = "";
                    Console.Ajouter("[-->] " + d.Attribut_Code);

                    //Traitement de chaque référentiel
                    switch (d.Attribut_Code)
                    {
                        case "PUBLIC_CIBLE":
                            {
                                hierarchie = "PUBLIC_CIBLE";
                                Niveau = hierarchie;
                                ValeurNiveau = Acces.Trouver_TableValeur_6PO(hierarchie, int.Parse(d.Valeur));
                                break;
                            }

                        case "ACTEUR_SANTE":
                            {
                                hierarchie = "ACTEUR_SANTE";
                                Niveau = hierarchie;
                                ValeurNiveau = Acces.Trouver_TableValeur_6PO(hierarchie, int.Parse(d.Valeur));
                                break;
                            }

                        case "LEVIER":
                            {
                                hierarchie = "LEVIER";
                                Niveau = hierarchie;
                                ValeurNiveau = Acces.Trouver_TableValeur_6PO(hierarchie, int.Parse(d.Valeur));
                                break;
                            }

                        case "PARTENAIRE_INSTITU":
                            {
                                hierarchie = "PARTENAIRE_INSTITU";
                                Niveau = hierarchie;
                                ValeurNiveau = Acces.Trouver_TableValeur_6PO("PARTENAIRE_INSTITU", int.Parse(d.Valeur));
                                break;
                            }

                        case "PARTENAIRE_USAGER":
                            {
                                hierarchie = "PARTENAIRE_USAGER";
                                Niveau = hierarchie;
                                ValeurNiveau = Acces.Trouver_TableValeur_6PO("PARTENAIRE_USAGER", int.Parse(d.Valeur));
                                break;
                            }

                        case "ANNEE_MO":
                            {
                                hierarchie = "ANNEE_MO";
                                Niveau = hierarchie;
                                ValeurNiveau = Acces.Trouver_TableValeur_6PO(hierarchie, int.Parse(d.Valeur));
                                break;
                            }

                        case "DIRECTION_PILOTE":
                            {
                                hierarchie = "DIRECTION_PILOTE";
                                Niveau = hierarchie;
                                ValeurNiveau = Acces.Trouver_TableValeur_6PO("DIRECTION_METIER", int.Parse(d.Valeur));
                                break;
                            }

                        case "DIRECTION_ASSOCIE":
                            {
                                hierarchie = "DIRECTION_ASSOCIE";
                                Niveau = hierarchie;
                                ValeurNiveau = Acces.Trouver_TableValeur_6PO("DIRECTION_METIER", int.Parse(d.Valeur));
                                break;
                            }

                        case "LIEN_PLAN":
                            {
                                hierarchie = "LIEN_PLAN";
                                Niveau = hierarchie;
                                ValeurNiveau = Acces.Trouver_TableValeur_6PO(hierarchie, int.Parse(d.Valeur));
                                break;
                            }

                        case "LIEN_PARCOURS":
                            {
                                hierarchie = "PARCOURS";
                                Niveau = hierarchie;
                                ValeurNiveau = Acces.Trouver_TableValeur_6PO(hierarchie, int.Parse(d.Valeur));
                                break;
                            }

                        case "LIEN_SECTEUR":
                            {
                                hierarchie = "SECTEUR";
                                Niveau = hierarchie;
                                ValeurNiveau = Acces.Trouver_TableValeur_6PO(hierarchie, int.Parse(d.Valeur));
                                break;
                            }

                        case "TSANTE":
                            {
                                hierarchie = "TSANTE";
                                Niveau = hierarchie;
                                ValeurNiveau = Acces.Trouver_TableValeur_6PO(hierarchie, int.Parse(d.Valeur));
                                break;
                            }

                        case "STRUCTURE_PORTEUSE":
                            {
                                hierarchie = "STRUCTURE_PORTEUSE";
                                Niveau = hierarchie;
                                ValeurNiveau = Acces.Trouver_TableValeur_6PO(hierarchie, int.Parse(d.Valeur));
                                break;
                            }

                        case "PRIORITE_CTS":
                            {
                                hierarchie = "PRIO_CTS";
                                Acces.Donner_TableValeur_6PO(hierarchie, d.Valeur, ref hierarchie, ref Niveau, ref ValeurNiveau);
                                Niveau = hierarchie;
                                break;
                            }
                    }

                    //Ajout des informations dans le fichier
                    if (ValeurNiveau.Trim().Length > 0)
                    {
                        n++;
                        Range r;
                        r = ws.Cells[n, 1];
                        r.Value = action.Code;
                        r = ws.Cells[n, 2];
                        r.Value = hierarchie; //Hiérarchie
                        r = ws.Cells[n, 3];
                        r.Value = Niveau; //Niveau
                        r = ws.Cells[n, 4];
                        r.Value = ValeurNiveau; //Valeur de niveau
                        k++;
                    }
                }
            }
            Texte_Resultat += "Nb Rattachements : " + k + "\r\n";
        }

        //Ajoute les indicateurs rattachés à un objectif
        void AjouteIndicateurObjectif(List<Objectif> Liste, ref int n, ref Worksheet ws, string Onglet)
        {
            int k = 0;
            foreach (Objectif objectif in Liste)
            {
                foreach (Lien l in listeLien)
                {
                    if (l.element1_id == objectif.ID && l.element2_type == Acces.type_INDICATEUR.ID)
                    {
                        Indicateur ind = (Indicateur)Acces.Trouver_Element(Acces.type_INDICATEUR, l.element2_id);
                        n++;
                        Range r;
                        r = ws.Cells[n, 1];
                        r.Value = objectif.Code;
                        r = ws.Cells[n, 2];
                        r.Value = ""; //WP
                        r = ws.Cells[n, 3];
                        r.Value = Acces.Trouver_TableValeur_6PO("INDICATEUR_TYPE", (int)ind.Type); //Type
                        r = ws.Cells[n, 4];
                        r.Value = ind.Code; // Code indicateur
                        r = ws.Cells[n, 5];
                        r.Value = ind.Libelle; // Libellé indicateur
                        r = ws.Cells[n, 6];
                        r.Value = Acces.Trouver_TableValeur_6PO("INDICATEUR_GENRE", (int)ind.Genre); // Genre
                        r = ws.Cells[n, 7];
                        r.Value = Acces.Trouver_TableValeur_6PO("INDICATEUR_CATEGORIE", (int)ind.Categorie); // Catégorie
                        r = ws.Cells[n, 8];
                        r.Value = Acces.Trouver_TableValeur_6PO("INDICATEUR_REPARTITION", (int)ind.Repartition); // Répartition; // Répartition
                        r = ws.Cells[n, 9];
                        r.Value = ""; // Valeur référence
                        r = ws.Cells[n, 10];
                        r.Value = ""; // Valeur cible
                        r = ws.Cells[n, 11];
                        r.Value = ""; // Période
                        r = ws.Cells[n, 12];
                        r.Value = ""; // Réalisé ou Cible selon la valeur de la variable Onglet passé en paramètre
                        k++;
                    }
                }
            }
            Texte_Resultat += "Nb Indicateurs : " + k + "\r\n";
        }

        //Ajoute les indicateurs rattachés à une action
        void AjouteIndicateurAction(List<PATIO.CAPA.Classes.Action> Liste, ref int n, ref Worksheet ws, string Onglet)
        {
            int k = 0;
            foreach (PATIO.CAPA.Classes.Action action in Liste)
            {
                foreach(Lien l in listeLien)
                {
                    if(l.element1_id==action.ID && l.element2_type == Acces.type_INDICATEUR.ID)
                    {
                        Indicateur ind = (Indicateur)Acces.Trouver_Element(Acces.type_INDICATEUR, l.element2_id);
                        n++;
                        Range r;
                        r = ws.Cells[n, 1];
                        r.Value = action.Code;
                        r = ws.Cells[n, 2];
                        r.Value = ""; //WP
                        r = ws.Cells[n, 3];
                        r.Value = Acces.Trouver_TableValeur_6PO("INDICATEUR_TYPE", (int)ind.Type); //Type
                        r = ws.Cells[n, 4];
                        r.Value = ind.Code; // Code indicateur
                        r = ws.Cells[n, 5];
                        r.Value = ind.Libelle; // Libellé indicateur
                        r = ws.Cells[n, 6];
                        r.Value = Acces.Trouver_TableValeur_6PO("INDICATEUR_GENRE", (int)ind.Genre); // Genre
                        r = ws.Cells[n, 7];
                        r.Value = Acces.Trouver_TableValeur_6PO("INDICATEUR_CATEGORIE", (int)ind.Categorie); // Catégorie
                        r = ws.Cells[n, 8];
                        r.Value = Acces.Trouver_TableValeur_6PO("INDICATEUR_REPARTITION", (int)ind.Repartition); // Répartition; // Répartition
                        r = ws.Cells[n, 9];
                        r.Value = ""; // Valeur référence
                        r = ws.Cells[n, 10];
                        r.Value = ""; // Valeur cible
                        r = ws.Cells[n, 11];
                        r.Value = ""; // Période
                        r = ws.Cells[n, 12];
                        r.Value = ""; // Réalisé ou Cible selon la valeur de la variable Onglet passé en paramètre
                        k++;
                    }
                }
            }
            Texte_Resultat += "Nb Indicateurs : " + k + "\r\n";
        }

        //Donne les informations techniques pour l'export des actions en fonction du niveau du plan
        void Donner_NiveauValeur6PO(Plan plan, ref string niveau, ref string valeur)
        {
            switch (plan.NiveauPlan)
            {
                case NiveauPlan.Niveau_2:
                    {
                        niveau = "HIER_PLAN_2NIV";
                        valeur = "HIER_PLAN_2NIV_1";

                        break;
                    }
                case NiveauPlan.Niveau_3:
                    {
                        niveau = "HIER_PLAN_3NIV";
                        valeur = "HIER_PLAN_3NIV_2";

                        break;
                    }
                case NiveauPlan.Niveau_4:
                    {
                        niveau = "HIER_PLAN_4NIV";
                        valeur = "HIER_PLAN_4NIV_3";

                        break;
                    }
                case NiveauPlan.Niveau_5:
                    {
                        niveau = "HIER_PLAN_5NIV";
                        valeur = "HIER_PLAN_5NIV_4";

                        break;
                    }
            }
        }

        //Création des entêtes pour l'export Objectif
        void Entete_Objectif(Worksheet ws)
        {
            Range r;
            int n1 = 1; int n = 1; int n3 = 1; int n4 = 1;
            /*int n5 = 1;*/
            int n6 = 1; int n7 = 1;

            //Entêtes Onglet 1 : ACT-
            switch (ws.Name)
            {
                case "ACT-":
                    {
                        r = ws.Cells[n1, 1];
                        r.Value = "Code objectif";
                        r = ws.Cells[n1, 2];
                        r.Value = "Libellé objectif";
                        r = ws.Cells[n1, 3];
                        r.Value = "Pilote";
                        r = ws.Cells[n1, 4];
                        r.Value = "Statut";
                        r = ws.Cells[n1, 5];
                        r.Value = "Date de début";
                        r = ws.Cells[n1, 6];
                        r.Value = "Date de fin";
                        r = ws.Cells[n1, 7];
                        r.Value = "Description";
                        r = ws.Cells[n1, 8];
                        r.Value = "Niveau de rattachement du Plan";
                        break;
                    }

                case "RAT-":
                    {
                        //Entêtes Onglet 2 : RAT-
                        r = ws.Cells[n, 1];
                        r.Value = "Code objectif";
                        r = ws.Cells[n, 2];
                        r.Value = "Hiérarchief";
                        r = ws.Cells[n, 3];
                        r.Value = "Niveau";
                        r = ws.Cells[n, 4];
                        r.Value = "Valeur Niveau";
                        break;
                    }

                case "EQU-":
                    {
                        //Entêtes Onglet 3 : EQU-
                        r = ws.Cells[n3, 1];
                        r.Value = "Code objectif";
                        r = ws.Cells[n3, 2];
                        r.Value = "Rôle";
                        r = ws.Cells[n3, 3];
                        r.Value = "Nom";
                        break;
                    }

                case "ATT-":
                    {
                        //Entêtes Onglet 4 : ATT-
                        r = ws.Cells[n4, 1];
                        r.Value = "Code objectif";
                        r = ws.Cells[n4, 2];
                        r.Value = "Attribut";
                        r = ws.Cells[n4, 3];
                        r.Value = "Valeur";
                        break;
                    }

                case "PLA-":
                    {
                        //Entêtes Onglet 5 : PLA-
                        break;
                    }

                case "IND-":
                    {
                        //Entêtes Onglet 6
                        r = ws.Cells[n6, 1];
                        r.Value = "Code objectif";
                        r = ws.Cells[n6, 2];
                        r.Value = "WP";
                        r = ws.Cells[n6, 3];
                        r.Value = "TYPE";
                        r = ws.Cells[n6, 4];
                        r.Value = "Code Résultat";
                        r = ws.Cells[n6, 5];
                        r.Value = "Libellé";
                        r = ws.Cells[n6, 6];
                        r.Value = "Genre";
                        r = ws.Cells[n6, 7];
                        r.Value = "Catégorie";
                        r = ws.Cells[n6, 8];
                        r.Value = "Répartition";
                        r = ws.Cells[n6, 9];
                        r.Value = "Référence";
                        r = ws.Cells[n6, 10];
                        r.Value = "Cible finale";
                        r = ws.Cells[n6, 11];
                        r.Value = "Période";
                        r = ws.Cells[n6, 12];
                        r.Value = "Réalisé";
                        break;
                    }

                case "IND-PLAN":
                    {
                        //Entêtes Onglet 7
                        r = ws.Cells[n7, 1];
                        r.Value = "Code objectif";
                        r = ws.Cells[n7, 2];
                        r.Value = "Code phase";
                        r = ws.Cells[n7, 3];
                        r.Value = "TYPE";
                        r = ws.Cells[n7, 4];
                        r.Value = "Code Résultat";
                        r = ws.Cells[n7, 5];
                        r.Value = "Libellé";
                        r = ws.Cells[n7, 6];
                        r.Value = "Genre";
                        r = ws.Cells[n7, 7];
                        r.Value = "Catégorie";
                        r = ws.Cells[n7, 8];
                        r.Value = "Répartition";
                        r = ws.Cells[n7, 9];
                        r.Value = "Référence";
                        r = ws.Cells[n7, 10];
                        r.Value = "Cible finale";
                        r = ws.Cells[n7, 11];
                        r.Value = "Période";
                        r = ws.Cells[n7, 12];
                        r.Value = "Cible";
                        break;
                    }
            }
        }

        //Création des entêtes pour l'export Action
        void Entete_Action(Worksheet ws)
        {
            Range r;
            int n1 = 1; int n = 1; int n3 = 1; int n4 = 1;
            /*int n5 = 1;*/ int n6 = 1; int n7 = 1;

            //Entêtes Onglet 1 : ACT-
            switch (ws.Name)
            {
                case "PRJ-":
                    {
                        r = ws.Cells[n1, 1];
                        r.Value = "Code";
                        r = ws.Cells[n1, 2];
                        r.Value = "Libellé";
                        r = ws.Cells[n1, 3];
                        r.Value = "Pilote";
                        r = ws.Cells[n1, 4];
                        r.Value = "Statut";
                        r = ws.Cells[n1, 5];
                        r.Value = "Date de début";
                        r = ws.Cells[n1, 6];
                        r.Value = "Date de fin";
                        r = ws.Cells[n1, 7];
                        r.Value = "Description";
                        r = ws.Cells[n1, 8];
                        r.Value = "Niveau de rattachement";
                        break;
                    }
                case "RAT-":
                    {
                        //Entêtes Onglet 2 : RAT-
                        r = ws.Cells[n, 1];
                        r.Value = "Code";
                        r = ws.Cells[n, 2];
                        r.Value = "Hiérarchie";
                        r = ws.Cells[n, 3];
                        r.Value = "Niveau";
                        r = ws.Cells[n, 4];
                        r.Value = "Valeur Niveau";
                        break;
                    }
                case "EQU-":
                    {
                        //Entêtes Onglet 3 : EQU-
                        r = ws.Cells[n3, 1];
                        r.Value = "Code";
                        r = ws.Cells[n3, 2];
                        r.Value = "Rôle";
                        r = ws.Cells[n3, 3];
                        r.Value = "Nom";
                        break;
                    }
                case "ATT-":
                    {
                        //Entêtes Onglet 4 : ATT-
                        r = ws.Cells[n4, 1];
                        r.Value = "Code";
                        r = ws.Cells[n4, 2];
                        r.Value = "Attribut";
                        r = ws.Cells[n4, 3];
                        r.Value = "Valeur";
                        break;
                    }

                case "PLA-":
                    {
                        //Entêtes Onglet 5 : PLA-
                        break;
                    }

                case "IND-":
                    {
                        //Entêtes Onglet 6 : IND-
                        r = ws.Cells[n6, 1];
                        r.Value = "Code";
                        r = ws.Cells[n6, 2];
                        r.Value = "Code phase";
                        r = ws.Cells[n6, 3];
                        r.Value = "TYPE";
                        r = ws.Cells[n6, 4];
                        r.Value = "Code indicateur";
                        r = ws.Cells[n6, 5];
                        r.Value = "Libellé indicateur";
                        r = ws.Cells[n6, 6];
                        r.Value = "Genre";
                        r = ws.Cells[n6, 7];
                        r.Value = "Catégorie";
                        r = ws.Cells[n6, 8];
                        r.Value = "Code Répartition";
                        r = ws.Cells[n6, 9];
                        r.Value = "Valeur Référence";
                        r = ws.Cells[n6, 10];
                        r.Value = "Valeur Cible finale";
                        r = ws.Cells[n6, 11];
                        r.Value = "Période";
                        r = ws.Cells[n6, 12];
                        r.Value = "Réalisé";
                        break;
                    }
                case "IND-PLAN":
                    {
                        //Entêtes Onglet 7 : IND-PLAN
                        r = ws.Cells[n7, 1];
                        r.Value = "Code";
                        r = ws.Cells[n7, 2];
                        r.Value = "Code phase";
                        r = ws.Cells[n7, 3];
                        r.Value = "TYPE";
                        r = ws.Cells[n7, 4];
                        r.Value = "Code indicateur";
                        r = ws.Cells[n7, 5];
                        r.Value = "Libellé indicateur";
                        r = ws.Cells[n7, 6];
                        r.Value = "Genre";
                        r = ws.Cells[n7, 7];
                        r.Value = "Catégorie";
                        r = ws.Cells[n7, 8];
                        r.Value = "Code Répartition";
                        r = ws.Cells[n7, 9];
                        r.Value = "Valeur Référence";
                        r = ws.Cells[n7, 10];
                        r.Value = "Valeur Cible finale";
                        r = ws.Cells[n7, 11];
                        r.Value = "Période";
                        r = ws.Cells[n7, 12];
                        r.Value = "Cible";
                        break;
                    }
            }
        }

        //Exprt de la liste des utilisateurs Pilote
        void ExportUtilisateur()
        {
            var fichier = Chemin + "\\Fichiers\\" + "USER";
            Console.Ajouter("->Cible : " + fichier);

            app.Workbooks.Add();

            Workbooks wk = app.Workbooks;
            Workbook wb = app.ActiveWorkbook;
            Worksheet ws = wb.Sheets[1];
            Range r;
            int n = 1;

            //Renommage de la feuille 1
            ws.Name = "utilisateurs";

            //Entêtes
            r = ws.Cells[n, 1];
            r.Value = "code";
            r = ws.Cells[n, 2];
            r.Value = "Prénom";
            r = ws.Cells[n, 3];
            r.Value = "Nom";
            r = ws.Cells[n, 4];
            r.Value = "email";
            r = ws.Cells[n, 5];
            r.Value = "Genre";

            //Liste des objectifs de 1er niveau
            Console.Ajouter("->Nb lignes :" + listeLien.Count.ToString());
            List<Utilisateur> ListeUtilisateur =(List<Utilisateur>) Acces.Remplir_ListeElement(Acces.type_UTILISATEUR, "");
            int k = 0;

            foreach (Utilisateur l in ListeUtilisateur)
            {
                if (l.Actif)
                {
                    n++;
                    r = ws.Cells[n, 1];
                    r.Value = l.Code ;
                    r = ws.Cells[n, 2];
                    r.Value = l.Prenom;
                    r = ws.Cells[n, 3];
                    r.Value = l.Nom;
                    r = ws.Cells[n, 4];
                    r.Value = l.Mail;
                    k++;
                }
            }
            Texte_Resultat += "Nb Utilisateurs : " + k + "\r\n";

            if (File.Exists(fichier + ".xls")) {
                try { File.Delete(fichier + ".xls"); } catch { } }

            wb.SaveAs(fichier + ".xls");
            wb.SaveAs(fichier + ".xls", XlFileFormat.xlExcel8);

            wb.Close();
            wk.Close();
        }

        void ExportTableValeur()
        {
            Workbooks wk = app.Workbooks;

            foreach (string tv in Acces.Remplir_ListeTableValeurNom("DESC"))
            {
                //Recherche du libellé
                string libelle = Acces.Trouver_Attribut_Libelle(tv);

                //if(libelle.Length ==0) { MessageBox.Show("Libellé de l'attribut " + tv + " non trouvé"); }

                if (!(Directory.Exists(Chemin + "\\Fichiers\\TV\\")))
                { Directory.CreateDirectory(Chemin + "\\Fichiers\\TV\\"); }

                if (!(Directory.Exists(Chemin + "\\Fichiers\\TV\\SAVE\\")))
                { Directory.CreateDirectory(Chemin + "\\Fichiers\\TV\\SAVE\\"); }

                if (!(Directory.Exists(Chemin + "\\Fichiers\\TV\\DIFF\\")))
                { Directory.CreateDirectory(Chemin + "\\Fichiers\\TV\\DIFF\\"); }

                string fichier = Chemin + "\\Fichiers\\TV\\" + "TV-" + tv;

                Workbook wb = app.Workbooks.Add();

                //Création des feuilles
                int nb_feuilles = wb.Sheets.Count;

                Range r;
                int n = 0;
                Worksheet ws = wb.Sheets.Add(); ws.Name = tv;
                n = 0;
                //Entêtes
                {
                    n++;
                    r = ws.Cells[n, 1];
                    r.Value = "Libelle_VN";
                    r = ws.Cells[n, 2];
                    r.Value = "Code_VN";
                    r = ws.Cells[n, 3];
                    r.Value = "Description_VN";
                    n++;
                    r = ws.Cells[n, 1];
                    r.Value = libelle;
                    r = ws.Cells[n, 2];
                    r.Value = tv;
                }

                //Insertion des données
                foreach (table_valeur ltv in Acces.Remplir_ListeTableValeur(tv))
                {
                    n++;
                    r = ws.Cells[n, 1];
                    r.Value = ltv.Valeur;
                    r = ws.Cells[n, 2];
                    r.Value = ltv.Valeur6PO;
                }

                //Suppression des feuilles déjà existantes
                n = wb.Sheets.Count;
                for (var i = 0; i < nb_feuilles; i++)
                {
                    Worksheet w = wb.Sheets[n-i];
                    w.Delete();
                }

                if (File.Exists(fichier + ".xls"))
                {
                    //Sauvegarde de la version précédente
                    string fichierdest = Chemin + "\\Fichiers\\TV\\SAVE\\" + "TV-" + tv + ".xls";
                    if (File.Exists(fichierdest))
                    { 
                        string fichiercopie = Chemin + "\\Fichiers\\TV\\SAVE\\" + "TV-" + tv + "-" + string.Format("{0:yyyyMMddHHmmss}", DateTime.Now) + ".xls";
                        File.Copy(fichierdest, fichiercopie);
                        File.Delete(fichierdest);
                    }
                    File.Copy(fichier + ".xls", fichierdest);
                    File.Delete(fichier + ".xls");
                }

                wb.SaveAs(fichier + ".xls");
                wb.SaveAs(fichier + ".xls", XlFileFormat.xlExcel8);

                wb.Close();
            }
            wk.Close();

            Comparer_Table_Valeur();
        }

        void Comparer_Table_Valeur()
        {
            Workbooks wk = app.Workbooks;
            Range r;

            string repert_Src = Chemin + "\\Fichiers\\TV\\";
            string repert_Cible = Chemin + "\\Fichiers\\TV\\SAVE\\";
            string repert_Diff = Chemin + "\\Fichiers\\TV\\DIFF\\";

            //Détermine si le différentiel est en ajout ou en remplace
            if (Directory.GetFiles(repert_Diff, "*.xls").Length > 0)
            {
                if (MessageBox.Show("Des fichiers différentiels existent. Voulez-vous les supprimer (si NON ils seront complétés) ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (string file in Directory.GetFiles(repert_Diff, "*.xls"))
                    {
                        File.Delete(file);
                    }
                }
            }

            //Balaye chaque fichier de valeur exporté
            foreach (string file_Src in Directory.GetFiles(repert_Src, "*.xls"))
            {
                string Libelle_Variable = "";
                string Code_Variable = "";

                //Lecture du premier fichier
                Workbook wb_Src = app.Workbooks.Open(file_Src);
                Worksheet ws_Src = wb_Src.Sheets[1];
                List<LigneTV> liste_Src = new List<LigneTV>();

                r = ws_Src.Cells[2, 1];
                Libelle_Variable = r.Value2;
                r = ws_Src.Cells[2, 2];
                Code_Variable = r.Value;

                for (int i = 3; i < 1000; i++)
                {
                    r = ws_Src.Cells[i, 1];
                    string Libelle = Convert.ToString(r.Value);
                    r = ws_Src.Cells[i, 2]; string Code = Convert.ToString(r.Value);
                    if (Libelle == null) { break; }

                    LigneTV tv = new LigneTV(Code, Libelle);
                    liste_Src.Add(tv);
                }
                wb_Src.Close();

                //Lecture du second fichier
                string file_Cible = file_Src.Replace(repert_Src, repert_Cible);
                Workbook wb_Cible = app.Workbooks.Open(file_Cible);
                Worksheet ws_Cible = wb_Cible.Sheets[1];
                List<LigneTV> liste_Cible = new List<LigneTV>();

                for (int i = 3; i < 1000; i++)
                {
                    r = ws_Cible.Cells[i, 1]; string Libelle = Convert.ToString(r.Value);
                    r = ws_Cible.Cells[i, 2]; string Code = Convert.ToString(r.Value);
                    if (Libelle == null) { break; }

                    LigneTV tv = new LigneTV(Code, Libelle);
                    liste_Cible.Add(tv);
                }
                wb_Cible.Close();

                //Création du fichier issu de la comparaison
                string fichier_diff = file_Src.Replace(repert_Src, repert_Diff);
                Workbook wb_Diff;
                Worksheet ws_Diff;
                int n = 0;

                if (File.Exists(fichier_diff))
                {
                    wb_Diff = app.Workbooks.Open(fichier_diff);
                    ws_Diff = wb_Diff.Sheets[1];
                    for (int i = 3; i < 1000; i++)
                    {
                        r = ws_Diff.Cells[i, 1]; string Libelle = Convert.ToString(r.Value);
                        if (Libelle == null) { break; }
                        n = i;
                    }
                }
                else
                {
                    wb_Diff = app.Workbooks.Add();
                    ws_Diff = wb_Diff.Sheets[1];
                    n = 1;
                    //Entete
                    r = ws_Diff.Cells[1, 1];
                    r.Value = "Libelle_VN";
                    r = ws_Diff.Cells[1, 2];
                    r.Value = "Code_VN";
                    r = ws_Diff.Cells[1, 3];
                    r.Value = "Description_VN";
                    n++;
                    //Variable
                    r = ws_Diff.Cells[n, 1];
                    r.Value = Libelle_Variable;
                    r = ws_Diff.Cells[n, 2];
                    r.Value = Code_Variable;
                }

                int k = 0;
                foreach (LigneTV tv_Src in liste_Src)
                {
                    bool ok = false;
                    foreach (LigneTV tv_Cible in liste_Cible)
                    {
                        if (tv_Src.Code == tv_Cible.Code) { ok = true; break; }
                    }
                    if (!ok)
                    {
                        n++;
                        r = ws_Diff.Cells[n, 1];
                        r.Value = tv_Src.Libelle;
                        r = ws_Diff.Cells[n, 2];
                        r.Value = tv_Src.Code;
                        k++;
                    }
                }

                if (k > 0)
                { Texte_Resultat += file_Src.Replace(repert_Src, "").Replace(".xls", "") + " : " + k + " modifications" + "\r\n"; }

                wb_Diff.SaveAs(fichier_diff);
                wb_Diff.SaveAs(fichier_diff, XlFileFormat.xlExcel8);

                wb_Diff.Close();
            }

            wk.Close();
        }

        void Afficher_Resultat()
        { 
            //Affichage du résultat
            File.WriteAllText(Chemin + "\\Fichiers\\TV\\resultats.txt", Texte_Resultat);
            System.Windows.Forms.TextBox ctrl = new System.Windows.Forms.TextBox();
            ctrl.Dock = DockStyle.Fill;
            ctrl.Text = Texte_Resultat;
            ctrl.Multiline = true;
            ctrl.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            ctrl.Font = new System.Drawing.Font("Courier new",11);
            DockContent D = new DockContent();
            D.Controls.Add(ctrl);
            D.Tag="RES_EXPORT_6PO";
            D.Text = "Résultats de l'export";
            D.ShowInTaskbar = false;
            D.CloseButton = true;
            D.Show(Acces.DP, DockState.Document);
        }
    }
}
