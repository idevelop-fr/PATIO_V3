﻿using System;
using System.Windows.Forms;
using System.IO;
using PATIO.CAPA.Classes;
using PATIO.MAIN.Classes;

namespace PATIO.CAPA.Interfaces
{
    public partial class ctrlXWiki : UserControl
    {
        public AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;
        public string Chemin;

        public ctrlConsole Console;

        public ctrlXWiki()
        {
            InitializeComponent();
        }

        public void Initialise()
        {
            
        }

        private void btnExtraire_Click(object sender, EventArgs e)
        {
            Extraire();
        }

        void Extraire()
        {
            string command = "";
            string CheminImport = Chemin + "/Import";

            lst.Items.Add("Extraction REST");
            lst.Items.Add("->Répertoire de destination " + CheminImport);
            Console.Ajouter("Extraction des fichiers XML REST");

            if (!Directory.Exists(CheminImport)) { Directory.CreateDirectory(CheminImport); }

            //Création du fichier de cookies
            lst.Items.Add("->Connexion au site REST");
            Connexion();

            if (optPlan.Checked)
            {
                //Extraction des données
                lst.Items.Add("->Extraction des plans");
                command = "curl -o " + CheminImport + "/plans.xml --cookie " + CheminImport + "/loginCookies https://ars-hdf.xwiki.com/xwiki/rest/wikis/plansactions/spaces/Plan/spaces/pages";
                ExecuteCommandSync(command);
                //Traitement des données
                lst.Items.Add("----------------------");
                lst.Items.Add("->Plan");
                Traitement_Plan();
            }

            if (optObjectif.Checked)
            {
                //Extraction des données
                lst.Items.Add("->Extraction des objectifs");
                command = "curl -o " + CheminImport + "/objectifs.xml --cookie " + CheminImport + "/loginCookies https://ars-hdf.xwiki.com/xwiki/rest/wikis/plansactions/spaces/Objectif/spaces/pages";
                ExecuteCommandSync(command);
                //Traitement des données
                lst.Items.Add("----------------------");
                lst.Items.Add("->Objectif");
                Traitement_Objectif();
            }

            if (optAction.Checked)
            {
                //Extraction des données
                lst.Items.Add("->Extraction des actions");
                command = "curl -o " + CheminImport + "/actions.xml --cookie " + CheminImport + "/loginCookies https://ars-hdf.xwiki.com/xwiki/rest/wikis/plansactions/spaces/Action/spaces/pages";
                ExecuteCommandSync(command);
                //Traitement des données
                lst.Items.Add("----------------------");
                lst.Items.Add("->Action");
                Traitement_Action();
            }

            if (optOperation.Checked)
            {
                //Extraction des données
                lst.Items.Add("->Extraction des opérations");
                command = "curl -o " + CheminImport + "/operations.xml --cookie " + CheminImport + "/loginCookies https://ars-hdf.xwiki.com/xwiki/rest/wikis/plansactions/spaces/Projet/spaces/pages";
                ExecuteCommandSync(command);
                //Traitement ds données
                lst.Items.Add("----------------------");
                lst.Items.Add("->Opération");
                Traitement_Opération();
            }

            if (optIndicateur.Checked)
            {
                //Extraction des données
                lst.Items.Add("->Extraction des indicateurs");
                command = "curl -o " + CheminImport + "/indicateurs.xml --cookie " + CheminImport + "/loginCookies https://ars-hdf.xwiki.com/xwiki/rest/wikis/plansactions/spaces/Indicateur/spaces/pages";
                ExecuteCommandSync(command);
                //Traitement des données
                lst.Items.Add("----------------------");
                lst.Items.Add("->Indicateur");
                Traitement_Indicateur();
            }

            lst.Items.Add("Traitement des fichiers extraits");
            Console.Ajouter("Traitement des fichiers extraits");
        }

        //Connexion au site REST
        void Connexion()
        {
            string CheminImport = Chemin + "/Import";
            string command = "curl -u dfernagut:Mdp62Cyber --cookie-jar " + CheminImport + "/loginCookies https://ars-hdf.xwiki.com/xwiki/bin/loginsubmit/XWiki/XWikiLogin";
            ExecuteCommandSync(command);
        }

        //Extraction de l'ensemble des plans
        void Traitement_Plan()
        {/*
            string CheminImport = Chemin + "/Import";
            string Fichier = CheminImport + "/Plans.xml";

            List<string> liste = new List<string>();

            lVersion lv = new lVersion();
            lv.Acces = Acces;

            //Lecture du fichier
            DataSet ds = new DataSet();
            ds.ReadXml(Fichier);

            //Traitement des données
            int n = 0;
            foreach (DataRow r in ds.Tables["pageSummary"].Rows)
            {
                string id = r["id"].ToString();
                string code = r["title"].ToString();
                string version_xml = r["version"].ToString();

                lst.Items.Add("->Plan " + code);
                Application.DoEvents();
                n++;

                lv.ChargeCode(Acces.type_PLAN, code);

                if(lv.Liste.Count>0)
                {
                    Version v = lv.Liste[0];

                    if (version_xml != v.Valeur)
                    {
                        Extraction_Plan(code);
                        v.Valeur = version_xml;
                        lv.Enregistrer();
                        lst.Items.Add("-->Version créée/modifiée");
                    }
                    else
                    {
                        lst.Items.Add("-->Version identique");
                    }
                }
                else
                {
                    Extraction_Plan(code);
                    Version v = new Version();
                    v.TypeElement = Acces.type_PLAN;
                    v.Code = code;
                    v.Valeur = version_xml;
                    lv.Ajouter(v);
                    lst.Items.Add("-->Version ajoutée");
                }
            }
            lst.SelectedIndex = lst.Items.Count - 1;
            lst.Items.Add(n + " plans extraits");*/
        }

        //Extraction d'une page Plan
        void Extraction_Plan(string Code)
        {/*
            string repert = Chemin + "//Import//Plan//";
            if (!(Directory.Exists(repert))) { Directory.CreateDirectory(repert); }
            string Fichier = repert + Code + ".xml";

            //Test le mode d'extraction
            if (!(optSave.Checked))
            {
                //Téléchargement de la page
                string url = "https://ars-hdf.xwiki.com/xwiki/rest/wikis/plansactions/spaces/Plan/pages/" + Code + "/objects/Plan.Code.PlanClass/0";
                string command = "curl -o " + Fichier + " --cookie " + Chemin + "/Import/loginCookies " + url;
                ExecuteCommandSync(command);
            }

            //Lecture des informations
            DataSet ds = new DataSet();
            try
            {
                ds.ReadXml(Fichier);
            }
            catch { lst.Items.Add("Erreur Plan : " + Code); return; }

            //Traitement des informations
            bool modif = false;
            lPlan lp = new lPlan();
            lp.Acces = Acces;
            lp.ChargeCode(Code);

            //Enregistrement des informations
            Plan p;
            if (lp.Liste.Count > 0)
            {
                p = lp.Liste[0];
                modif = true;
            }
            else
            {
                p = new Plan();
                p.Code = Code;
                p.Actif = true;
            }

            //Traitement des données
            foreach (DataRow r in ds.Tables["Property"].Rows)
            {
                switch(r["name"].ToString())
                {
                    case "plan_libelle":
                        p.Libelle = r["value"].ToString();
                        break;
                    case "plan_abrege":
                        p.Abrege = r["value"].ToString();
                        break;
                }
            }

            //MessageBox.Show(Code.Substring(1, 3));
            switch(Code.Substring(0,3))
            {
                case "PAN":
                    p.TypePlan = TypePlan.NATIONAL;
                    break;
                case "PAR":
                    p.TypePlan = TypePlan.REGIONAL;
                    break;
                default:
                    p.TypePlan = TypePlan.DOSSIER;
                    break;
            }

            if (!modif)
            {
                lp.Ajouter(p);
                lst.SelectedIndex = lst.Items.Count - 1;
                lst.Items[lst.Items.Count-1] += lst.Items[lst.Items.Count-1] + "-->Créé";
            }
            else
            {
                lp.Enregistrer();
                lst.SelectedIndex = lst.Items.Count - 1;
                lst.Items[lst.Items.Count-1] += lst.Items[lst.Items.Count-1] + "-->Modifié";
            }*/
        }

        //Extraction de l'ensemble des objectifs
        void Traitement_Objectif()
        {/*
            string CheminImport = Chemin + "/Import";
            string Fichier = CheminImport + "/Objectifs.xml";

            List<string> liste = new List<string>();

            lVersion lv = new lVersion();
            lv.Acces = Acces;

            //Lecture du fichier
            DataSet ds = new DataSet();
            ds.ReadXml(Fichier);

            //Traitement des données
            int n = 0;
            foreach (DataRow r in ds.Tables["pageSummary"].Rows)
            {
                string id = r["id"].ToString();
                string code = r["title"].ToString();
                string version_xml = r["version"].ToString();

                lst.Items.Add("->Objectif " + code);
                Application.DoEvents();
                n++;

                lv.ChargeCode(Acces.type_OBJECTIF, code);

                if (lv.Liste.Count > 0)
                {
                    Version v = lv.Liste[0];

                    if (version_xml != v.Valeur)
                    {
                        Extraction_Objectif(code);
                        v.Valeur = version_xml;
                        lv.Enregistrer();
                        lst.Items.Add("-->Version créée/modifiée");
                    }
                    else
                    {
                        lst.Items.Add("-->Version identique");
                    }
                }
                else
                {
                    Extraction_Objectif(code);
                    Version v = new Version();
                    v.TypeElement = Acces.type_OBJECTIF;
                    v.Code = code;
                    v.Valeur = version_xml;
                    lv.Ajouter(v);
                    lst.Items.Add("-->Version ajoutée");
                }
            }
            lst.SelectedIndex = lst.Items.Count - 1;
            lst.Items.Add(n + " objectifs extraits");*/
        }

        //Extraction d'une page Objectif
        void Extraction_Objectif(string Code)
        {/*
            string repert = Chemin + "//Import//Objectif//";
            if (!(Directory.Exists(repert))) { Directory.CreateDirectory(repert); }
            string Fichier = repert + Code + ".xml";

            //Test le mode d'extraction
            if (!(optSave.Checked))
            {
                //Téléchargement de la page
                string url = "https://ars-hdf.xwiki.com/xwiki/rest/wikis/plansactions/spaces/Objectif/pages/" + Code + "/objects/Objectif.Code.ObjectifClass/0";
                string command = "curl -o " + Fichier + " --cookie " + Chemin + "/Import/loginCookies " + url;
                ExecuteCommandSync(command);
            }
            //Lecture des informations
            DataSet ds = new DataSet();
            try
            {
                ds.ReadXml(Fichier);
            }
            catch { lst.Items.Add("Erreur Objectif : " + Code); return; }

            //Traitement des informations
            bool modif = false;
            lObjectif lp = new lObjectif();
            lp.Acces = Acces;
            lp.ChargeCode(Code);

            //Enregistrement des informations
            Objectif p;
            if (lp.Liste.Count > 0)
            {
                p = lp.Liste[0];
                modif = true;
            }
            else
            {
                p = new Objectif();
                p.Code = Code;
                p.Actif = true;
            }

            //Traitement des données
            foreach (DataRow r in ds.Tables["Property"].Rows)
            {
                switch (r["name"].ToString())
                {
                    case "objectif_libelle":
                        p.Libelle = r["value"].ToString();
                        break;
                    case "objectif_type":
                        p.TypeObjectif = TypeObjectif.DOSSIER;
                        if (r["value"].ToString() == "AXE") { p.TypeObjectif = TypeObjectif.AXE; }
                        if (r["value"].ToString() == "STRAT") { p.TypeObjectif = TypeObjectif.STRATEGIQUE; }
                        if (r["value"].ToString() == "GENERAL") { p.TypeObjectif = TypeObjectif.GENERAL; }
                        if (r["value"].ToString() == "OPER") { p.TypeObjectif = TypeObjectif.OPERATIONNEL; }
                        break;
                }
            }

            if (!modif)
            {
                lp.Ajouter(p);
                lst.SelectedIndex = lst.Items.Count - 1;
                lst.Items[lst.Items.Count - 1] += lst.Items[lst.Items.Count - 1] + "-->Créé";
            }
            else
            {
                lp.Enregistrer();
                lst.SelectedIndex = lst.Items.Count - 1;
                lst.Items[lst.Items.Count - 1] += lst.Items[lst.Items.Count - 1] + "-->Modifié";
            }*/
        }

        //Extraction de l'ensemble des actions
        void Traitement_Action()
        {/*
            string CheminImport = Chemin + "/Import";
            string Fichier = CheminImport + "/Actions.xml";

            List<string> liste = new List<string>();

            lVersion lv = new lVersion();
            lv.Acces = Acces;

            //Lecture du fichier
            DataSet ds = new DataSet();
            ds.ReadXml(Fichier);

            //Traitement des données
            int n = 0;
            foreach (DataRow r in ds.Tables["pageSummary"].Rows)
            {
                string id = r["id"].ToString();
                string code = r["title"].ToString();
                string version_xml = r["version"].ToString();

                lst.Items.Add("->Action " + code);
                Application.DoEvents();
                n++;

                lv.ChargeCode(Acces.type_ACTION, code);

                if (lv.Liste.Count > 0)
                {
                    Version v = lv.Liste[0];

                    if (version_xml != v.Valeur)
                    {
                        Extraction_Action(code);
                        v.Valeur = version_xml;
                        lv.Enregistrer();
                        lst.Items.Add("-->Version créée/modifiée");
                    }
                    else
                    {
                        lst.Items.Add("-->Version identique");
                    }
                }
                else
                {
                    Extraction_Action(code);
                    Version v = new Version();
                    v.TypeElement = Acces.type_ACTION;
                    v.Code = code;
                    v.Valeur = version_xml;
                    lv.Ajouter(v);
                    lst.Items.Add("-->Version ajoutée");
                }
            }
            lst.SelectedIndex = lst.Items.Count - 1;
            lst.Items.Add(n + " actions extraits");*/
        }

        //Extraction d'une page Action
        void Extraction_Action(string Code)
        {
            /*
            string repert = Chemin + "//Import//Action//";
            if (!(Directory.Exists(repert))) { Directory.CreateDirectory(repert); }
            string Fichier = repert + Code + ".xml";

            //Test le mode d'extraction
            if (!(optSave.Checked))
            {
                //Téléchargement de la page
                string url = "https://ars-hdf.xwiki.com/xwiki/rest/wikis/plansactions/spaces/Action/pages/" + Code + "/objects/Action.Code.ActionClass/0";
                string command = "curl -o " + Fichier + " --cookie " + Chemin + "/Import/loginCookies " + url;
                ExecuteCommandSync(command);
            }

            //Lecture des informations
            DataSet ds = new DataSet();
            try
            {
                ds.ReadXml(Fichier);
            }
            catch { lst.Items.Add("Erreur Action : " + Code); return; }

            //Traitement des informations
            bool modif = false;
            lAction lp = new lAction();
            lp.Acces = Acces;
            lp.ChargeCode(Code);

            //Enregistrement des informations
            Action p;
            if (lp.Liste.Count > 0)
            {
                p = lp.Liste[0];
                modif = true;
            }
            else
            {
                p = new Action();

                //Correction des codes
                p.Code = Code;
                p.TypeAction = TypeAction.ACTION;

                p.Actif = true;
            }

            //Traitement des données
            foreach (DataRow r in ds.Tables["Property"].Rows)
            {
                switch (r["name"].ToString())
                {
                    case "action_libelle":
                        p.Libelle = r["value"].ToString();
                        break;
                }
            }

            if (!modif)
            {
                lp.Ajouter(p);
                lst.SelectedIndex = lst.Items.Count - 1;
                lst.Items[lst.Items.Count - 1] += lst.Items[lst.Items.Count - 1] + "-->Créé";
            }
            else
            {
                lp.Enregistrer();
                lst.SelectedIndex = lst.Items.Count - 1;
                lst.Items[lst.Items.Count - 1] += lst.Items[lst.Items.Count - 1] + "-->Modifié";
            }*/
        }

        //Extraction de l'ensemble des opérations
        void Traitement_Opération()
        {/*
            string CheminImport = Chemin + "/Import";
            string Fichier = CheminImport + "/Operations.xml";

            List<string> liste = new List<string>();

            lVersion lv = new lVersion();
            lv.Acces = Acces;

            //Lecture du fichier
            DataSet ds = new DataSet();
            ds.ReadXml(Fichier);

            //Traitement des données
            int n = 0;
            foreach (DataRow r in ds.Tables["pageSummary"].Rows)
            {
                string id = r["id"].ToString();
                string code = r["title"].ToString();
                string version_xml = r["version"].ToString();

                lst.Items.Add("->Opération " + code);
                Application.DoEvents();
                n++;

                lv.ChargeCode(Acces.type_ACTION, code);

                if (lv.Liste.Count > 0)
                {
                    Version v = lv.Liste[0];

                    if (version_xml != v.Valeur)
                    {
                        Extraction_Opération(code);
                        v.Valeur = version_xml;
                        lv.Enregistrer();
                        lst.Items.Add("-->Version créée/modifiée");
                    }
                    else
                    {
                        lst.Items.Add("-->Version identique");
                    }
                }
                else
                {
                    Extraction_Opération(code);
                    Version v = new Version();
                    v.TypeElement = Acces.type_ACTION;
                    v.Code = code;
                    v.Valeur = version_xml;
                    lv.Ajouter(v);
                    lst.Items.Add("-->Version ajoutée");
                }
            }
            lst.SelectedIndex = lst.Items.Count - 1;
            lst.Items.Add(n + " opérations extraits");*/
        }

        //Extraction d'une page Opération
        void Extraction_Opération(string Code)
        {/*
            string repert = Chemin + "//Import//Operation//";
            if (!(Directory.Exists(repert))) { Directory.CreateDirectory(repert); }
            string Fichier = repert + Code + ".xml";

            //Test le mode d'extraction
            if (!(optSave.Checked))
            {
                //Téléchargement de la page
                string url = "https://ars-hdf.xwiki.com/xwiki/rest/wikis/plansactions/spaces/Projet/pages/" + Code + "/objects/Projet.Code.ProjetClass/0";
                string command = "curl -o " + Fichier + " --cookie " + Chemin + "/Import/loginCookies " + url;
                ExecuteCommandSync(command);
            }

            //Lecture des informations
            DataSet ds = new DataSet();
            try
            {
                ds.ReadXml(Fichier);
            }
            catch { lst.Items.Add("Erreur Opération : " + Code); return; }

            //Traitement des informations
            bool modif = false;
            lAction lp = new lAction();
            lp.Acces = Acces;
            lp.ChargeCode(Code);

            //Enregistrement des informations
            Action p;
            if (lp.Liste.Count > 0)
            {
                p = lp.Liste[0];
                modif = true;
            }
            else
            {
                p = new Action();
                p.Code = Code;
                p.TypeAction = TypeAction.OPERATION;
                p.Actif = true;
            }

            //Traitement des données
            foreach (DataRow r in ds.Tables["Property"].Rows)
            {
                switch (r["name"].ToString())
                {
                    case "operation_libelle":
                        p.Libelle = r["value"].ToString();
                        break;
                }
            }

            if (!modif)
            {
                lp.Ajouter(p);
                lst.SelectedIndex = lst.Items.Count - 1;
                lst.Items[lst.Items.Count - 1] += lst.Items[lst.Items.Count - 1] + "-->Créé";
            }
            else
            {
                lp.Enregistrer();
                lst.SelectedIndex = lst.Items.Count - 1;
                lst.Items[lst.Items.Count - 1] += lst.Items[lst.Items.Count - 1] + "-->Modifié";
            }*/
        }

        //Extraction de l'ensemble des indicateurs
        void Traitement_Indicateur()
        {/*
            string CheminImport = Chemin + "/Import";
            string Fichier = CheminImport + "/Indicateurs.xml";

            List<string> liste = new List<string>();

            lVersion lv = new lVersion();
            lv.Acces = Acces;

            //Lecture du fichier
            DataSet ds = new DataSet();
            ds.ReadXml(Fichier);

            //Traitement des données
            int n = 0;
            foreach (DataRow r in ds.Tables["pageSummary"].Rows)
            {
                string id = r["id"].ToString();
                string code = r["title"].ToString();
                string version_xml = r["version"].ToString();

                lst.Items.Add("->Indicateur " + code);
                Application.DoEvents();
                n++;

                lv.ChargeCode(Acces.type_INDICATEUR, code);

                if (lv.Liste.Count > 0)
                {
                    Version v = lv.Liste[0];

                    if (version_xml != v.Valeur)
                    {
                        Extraction_Indicateur(code);
                        v.Valeur = version_xml;
                        lv.Enregistrer();
                        lst.Items.Add("-->Version créée/modifiée");
                    }
                    else
                    {
                        lst.Items.Add("-->Version identique");
                    }
                }
                else
                {
                    Extraction_Indicateur(code);
                    Version v = new Version();
                    v.TypeElement = Acces.type_INDICATEUR;
                    v.Code = code;
                    v.Valeur = version_xml;
                    lv.Ajouter(v);
                    lst.Items.Add("-->Version ajoutée");
                }
            }
            lst.SelectedIndex = lst.Items.Count - 1;
            lst.Items.Add(n + " indicateurs extraits");*/
        }

        //Extraction d'une page Indicateur
        void Extraction_Indicateur(string Code)
        {/*
            string repert = Chemin + "//Import//Indicateur//";
            if (!(Directory.Exists(repert))) { Directory.CreateDirectory(repert); }
            string Fichier = repert + Code + ".xml";

            //Test le mode d'extraction
            if (!(optSave.Checked))
            {
                //Téléchargement de la page
                string url = "https://ars-hdf.xwiki.com/xwiki/rest/wikis/plansactions/spaces/Indicateur/pages/" + Code + "/objects/Indicateur.Code.IndicateurClass/0";
                string command = "curl -o " + Fichier + " --cookie " + Chemin + "/Import/loginCookies " + url;
                ExecuteCommandSync(command);
            }

            //Lecture des informations
            DataSet ds = new DataSet();
            try
            {
                ds.ReadXml(Fichier);
            }
            catch { lst.Items.Add("Erreur Indicateur : " + Code); return; }

            //Traitement des informations
            bool modif = false;
            lIndicateur lp = new lIndicateur();
            lp.Acces = Acces;
            lp.ChargeCode(Code);

            //Enregistrement des informations
            Indicateur p;
            if (lp.Liste.Count > 0)
            {
                p = lp.Liste[0];
                modif = true;
            }
            else
            {
                p = new Indicateur();
                p.Code = Code;
                p.TypeIndicateur = TypeIndicateur.DOSSIER;
                p.Actif = true;
            }

            //Traitement des données
            foreach (DataRow r in ds.Tables["Property"].Rows)
            {
                switch (r["name"].ToString())
                {
                    case "indicateur_libelle":
                        p.Libelle = r["value"].ToString();
                        break;
                    case "indicateur_type":
                        if (r["value"].ToString() == "Impact") { p.TypeIndicateur = TypeIndicateur.IMPACT; }
                        if (r["value"].ToString() == "MOY") { p.TypeIndicateur = TypeIndicateur.MOYEN; }
                        if (r["value"].ToString() == "RLT") { p.TypeIndicateur = TypeIndicateur.RESULTAT; }
                        if (r["value"].ToString() == "RIT") { p.TypeIndicateur = TypeIndicateur.RESULTAT; }
                        if (r["value"].ToString() == "RCT") { p.TypeIndicateur = TypeIndicateur.RESULTAT; }
                        break;
                }
            }

            if (!modif)
            {
                lp.Ajouter(p);
                lst.SelectedIndex = lst.Items.Count - 1;
                lst.Items[lst.Items.Count - 1] += lst.Items[lst.Items.Count - 1] + "-->Créé";
            }
            else
            {
                lp.Enregistrer();
                lst.SelectedIndex = lst.Items.Count - 1;
                lst.Items[lst.Items.Count - 1] += lst.Items[lst.Items.Count - 1] + "-->Modifié";
            }*/
        }

        /// Executes a shell command synchronously.
        /// <span class="code-SummaryComment"></summary></span>
        /// <span class="code-SummaryComment"><param name="command">string command</param></span>
        /// <span class="code-SummaryComment"><returns>string, as output of the command.</returns></span>
        public void ExecuteCommandSync(object command)
        {
            try
            {
                // create the ProcessStartInfo using "cmd" as the program to be run,
                // and "/c " as the parameters.
                // Incidentally, /c tells cmd that we want it to execute the command that follows,
                // and then exit.
                System.Diagnostics.ProcessStartInfo procStartInfo =
                    new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);

                // The following commands are needed to redirect the standard output.
                // This means that it will be redirected to the Process.StandardOutput StreamReader.
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                // Do not create the black window.
                procStartInfo.CreateNoWindow = true;
                // Now we create a process, assign its ProcessStartInfo and start it
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                // Get the output into a string
                string result = proc.StandardOutput.ReadToEnd();
                // Display the command output.
                lst.Items.Add(result);
                lbl.Text = result;
            }
            catch (Exception objException)
            {
                Console.Ajouter(objException.Message);
                // Log the exception
            }
        }

        private void btnCorriger_Click(object sender, EventArgs e)
        {
            if (optPlanCorrection.Checked) { CorrigerPlan(); }
            //if (optObjectifCorrection.Checked) { CorrigerObjectif(); }
            if (optActionCorrection.Checked) { CorrigerAction(); }

            lst.Items.Add("... Fin des corrections");

        }

        void CorrigerPlan()
        {
            string sql;
            string code_type="";

            int typeelement_id_PLA = 0;
            int typeelement_id_OBJ = 0;
            int typeelement_id_ACT = 0;
            int typeelement_id_IND = 0;
            int typeelement_id_USR = 0;
            int typeelement_id_GRP = 0;
            int typeelement=0;

            for (int i=5; i>=0;i--)
            {
                switch (i)
                {
                    case 0: {
                            code_type = Acces.type_PLAN.Code;
                            typeelement_id_PLA = Acces.Trouver_TableValeur_Code("TYPE_ELEMENT", code_type).ID;
                            typeelement = typeelement_id_PLA;
                            break; }
                    case 1: {
                            code_type = Acces.type_OBJECTIF.Code;
                            typeelement_id_OBJ = Acces.Trouver_TableValeur_Code("TYPE_ELEMENT", code_type).ID;
                            typeelement = typeelement_id_OBJ;
                            break; }
                    case 2: {
                            code_type = Acces.type_ACTION.Code;
                            typeelement_id_ACT = Acces.Trouver_TableValeur_Code("TYPE_ELEMENT", code_type).ID;
                            typeelement = typeelement_id_ACT;
                            break; }
                    case 3: {
                            code_type = Acces.type_INDICATEUR.Code;
                            typeelement_id_IND = Acces.Trouver_TableValeur_Code("TYPE_ELEMENT", code_type).ID;
                            typeelement = typeelement_id_IND;
                            break; }
                    case 4: {
                            code_type = Acces.type_UTILISATEUR.Code;
                            typeelement_id_USR = Acces.Trouver_TableValeur_Code("TYPE_ELEMENT", code_type).ID; ;
                            typeelement = typeelement_id_USR;
                            break; }
                    case 5: {
                            code_type = Acces.type_GROUPE.Code;
                            typeelement_id_GRP = Acces.Trouver_TableValeur_Code("TYPE_ELEMENT", code_type).ID;
                            typeelement = typeelement_id_GRP;
                            break; }
                }

                sql = "UPDATE element SET element_type='" + typeelement.ToString() + "'";
                sql += " WHERE element_type='" + i + "'";
                Acces.cls.Execute(sql);
            }

            //Correction des liens : 4 et 5 non concernés
            for (int i = 5; i >= 0; i--)
            {
                int typeelement_id=0;
                switch (i)
                {
                    case 0: { typeelement_id = typeelement_id_PLA; break; }
                    case 1: { typeelement_id = typeelement_id_OBJ; break; }
                    case 2: { typeelement_id = typeelement_id_ACT; break; }
                    case 3: { typeelement_id = typeelement_id_IND; break; }
                }

                sql = "UPDATE lien SET Element0_Type='" + typeelement_id.ToString() + "'";
                sql += " WHERE Element0_Type='" + i + "'";
                Acces.cls.Execute(sql);
                sql = "UPDATE lien SET Element1_Type='" + typeelement_id.ToString() + "'";
                sql += " WHERE Element1_Type='" + i + "'";
                Acces.cls.Execute(sql);
                sql = "UPDATE lien SET Element2_Type='" + typeelement_id.ToString() + "'";
                sql += " WHERE Element2_Type='" + i + "'";
                Acces.cls.Execute(sql);

                sql = "UPDATE attribut SET element_type=" + typeelement_id.ToString();
                sql += " WHERE element_type='" + i +"'";
                Acces.cls.Execute(sql);
            }

            MessageBox.Show("Corrections terminées");
        }

        void CorrigerAction()
        {
           /* lst.Items.Add("Corrections des actions...");

            lAction l = new lAction();
            l.Acces = Acces;
            l.Charge();

            foreach( Action a in l.Liste)
            {
                CorrectionCode(a);
            }

            l.Enregistrer();
            lst.Items.Add("... Fin des corrections des actions");*/
        }

       void CorrectionCode(PATIO.CAPA.Classes.Action a)
        {
            string code = a.Code;

            //Cas d'une action
            if (code.Substring(0, 3) == Acces.type_ACTION.Code)
            {
                string plan = "";
                string OS = ""; string OG = ""; string OP = "";
                string Autre = "";

                string[] lst = code.Split('-');

                plan = lst[1].ToUpper().Trim();
                if (lst.Length >= 3) { OS = lst[2].ToUpper().Trim(); }
                if (lst.Length >= 4) { OG = lst[3].ToUpper().Trim(); }
                if (lst.Length >= 5) { OP = lst[4].ToUpper().Trim(); }
                if (lst.Length >= 6) { Autre = lst[5].ToUpper().Trim(); }

                code = "ACT-" + plan;

                if (OS.Length > 0) { OS = OS.Replace("OS",""); code += "-OS" + string.Format("{0:00}", int.Parse(OS)); }
                if (OG.Length > 0) { OG = OS.Replace("OS", ""); code += "-OG" + string.Format("{0:00}", int.Parse(OG)); }
                if (OP.Length > 0) { OP = OS.Replace("OS", ""); code += "-OP" + string.Format("{0:00}", int.Parse(OP)); }
                if (Autre.Length > 0) { code += "+" + string.Format("{0:000}", int.Parse(Autre)); }
                //MessageBox.Show(Code + "-->" + code);
                a.Code = code;
                a.TypeAction = TypeAction.ACTION;
            }
            else
            {
                //Opération
                code = code.Replace("OPE-", "");
                code = "OPE-" + code;
                a.Code = code;
                a.TypeAction = TypeAction.OPERATION;
            }
        }

        private void btnExporter_Click(object sender, EventArgs e)
        {
            Exporter();
        }

        void Exporter()
        {
            string CheminImport = Chemin + "/Import";
            string Code = "PAN-PEAST";

            Connexion();

            string url = "https://ars-hdf.xwiki.com/xwiki/rest/wikis/plansactions/spaces/Plan/pages/" + Code + "/objects/Plan.Code.PlanClass/0";
            string command = "curl --cookie " + CheminImport + "/loginCookies -X PUT -H \"Content-type: application/x-www-form-urlencoded\" ";
            command +="-H \"Accept: application/xml\" -d \"className=XWiki.PlanClass\" ";
            command += "-d \"property#plan_code=" + Code + "hh\" " + url;
            MessageBox.Show(command);
            ExecuteCommandSync(command);

        }
    }
}
