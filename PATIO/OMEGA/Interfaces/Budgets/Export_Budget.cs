using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;
using PATIO.OMEGA.Classes;
using PATIO.MAIN.Classes;
using System.Windows.Forms;
using System.IO;
using WeifenLuo.WinFormsUI.Docking;

namespace PATIO.OMEGA.Interfaces.Budgets
{
    public class Export_Budget
    {
        public AccesNet Acces;
        public ctrlConsole Console;
        public DockPanel DP;

        public string Chemin;
        public int Periode;

        Microsoft.Office.Interop.Excel.Application app;
        string Texte_Resultat = "";

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
        public void Exporter_Budget()
        {
            DateTime d1 = DateTime.Now;

            //Création de l'application Excel
            app = new Microsoft.Office.Interop.Excel.Application();
            app.DisplayAlerts = false;

            Console.Ajouter("Export des budgets...");

            Texte_Resultat = "EXPORTATION Budget" + "\r\n";


            //Exportation des objectifs
            Console.Ajouter("->Export des objectifs...");
            Texte_Resultat += "### Export des objectifs ###" + "\r\n";
            ExportBudget();


            Console.Ajouter("...Fin Export Plan");
            DateTime d2 = DateTime.Now;
            Texte_Resultat += "### Fin de l'export ###" + "\r\n";
            Texte_Resultat += "Temps : " + string.Format("{0:ss}",d2-d1) + "\r\n";
            Afficher_Resultat();

            //Fermeture de l'application Excel
            app.Quit();
            app = null;
        }


        //Exportation de la liste des objectifs d'un plan -> Il s'agit de la liste des actions
        void ExportBudget()
        {
            var fichier = Acces.CheminTemp + "\\Fichiers\\" + "RPT_BUD-" + Periode.ToString();

            Workbooks wk = app.Workbooks;
            Workbook wb = app.Workbooks.Add();

            //Création des feuilles
            int nb_feuilles = wb.Sheets.Count;

            Worksheet ws1 = wb.Sheets.Add(); ws1.Name = "BUDGET";

            //Suppression des feuilles déjà existantes
            for (var i = nb_feuilles + 1; i > 1; i--) 
            {
                Worksheet w = wb.Sheets[i];
                w.Delete();
            }

            Range r;
            int n = 1;

            //Création des entêtes
            r = ws1.Cells[n, 1];
            r.Value = "Budget";
            r = ws1.Cells[n, 3];
            r.Value = "AE";
            r = ws1.Cells[n, 5];
            r.Value = "CP";

            n++;
            r = ws1.Cells[n, 1];
            r.Value = "Budget";
            r = ws1.Cells[n, 2];
            r.Value = "Recettes";
            r = ws1.Cells[n, 3];
            r.Value = "Dépenses";
            r = ws1.Cells[n, 4];
            r.Value = "Recettes";
            r = ws1.Cells[n, 5];
            r.Value = "Dépenses";

            List<Budget> ListeBudget = Acces.clsOMEGA.Remplir_ListeBudget(Periode);
            List<Budget_Operation> ListeOperation = Acces.clsOMEGA.Remplir_ListeBudgetOperation(Periode);

            foreach (Budget bg in ListeBudget)
            {
                n++;
                r = ws1.Cells[n, 1];
                r.Value = bg.Libelle;

                //AE
                double S_Recette = 0;
                double S_Depense = 0;

                foreach(Budget_Operation bo in ListeOperation)
                {
                    if(bg.Enveloppe == bo.Enveloppe && bo.Type_Montant == TypeMontant.AE )
                    {
                        if (bo.Type_Flux == TypeFlux.Recettes) { S_Recette += bo.Montant; }
                        if (bo.Type_Flux == TypeFlux.Dépenses) { S_Depense += bo.Montant; }
                    }
                }

                r = ws1.Cells[n, 2];
                r.Value = string.Format("{0:# ### ###.00}", S_Recette);
                r = ws1.Cells[n, 3];
                r.Value = string.Format("{0:# ### ###.00}", S_Depense);

                //CP
                S_Recette = 0;
                S_Depense = 0;

                foreach (Budget_Operation bo in ListeOperation)
                {
                    if (bg.Enveloppe == bo.Enveloppe && bo.Type_Montant == TypeMontant.CP)
                    {
                        if (bo.Type_Flux == TypeFlux.Recettes) { S_Recette += bo.Montant; }
                        if (bo.Type_Flux == TypeFlux.Dépenses) { S_Depense += bo.Montant; }
                    }
                }

                r = ws1.Cells[n, 4];
                r.Value = string.Format("{0:# ### ###.00}", S_Recette);
                r = ws1.Cells[n, 5];
                r.Value = string.Format("{0:# ### ###.00}", S_Depense);
            }

            if (File.Exists(fichier + ".xls")) { File.Delete(fichier + ".xls"); }

            wb.SaveAs(fichier + ".xls");
            wb.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, fichier + ".PDF");

            wb.Close();
            wk.Close();
        }

        void Afficher_Resultat()
        { 
            //Affichage du résultat
            File.WriteAllText(Acces.CheminTemp + "\\Fichiers\\TV\\resultats.txt", Texte_Resultat);
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
