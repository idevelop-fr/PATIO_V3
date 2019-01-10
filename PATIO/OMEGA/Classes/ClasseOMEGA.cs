using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PATIO.OMEGA.Classes;
using System.Windows.Forms;
using PATIO.OMEGA.Interfaces;
using PATIO.OMEGA.Interfaces.Budgets;
using PATIO.OMEGA.Interfaces.Association;
using WeifenLuo.WinFormsUI.Docking;

namespace PATIO.MAIN.Classes
{
    public class ClasseOMEGA
    {
        public AccesNet Acces;
        public ctrlConsole Console;

        /// <summary>
        /// Renvoie la liste des budgets pour un exercice
        /// </summary>
        /// <param name="Periode"></param>
        public List<Budget> Remplir_ListeBudget(int Periode, int Enveloppe = 0)
        {
            List<Budget> listeBudget = (List<Budget>)Acces.Remplir_ListeElement(Acces.type_BUDGET, "");
            //listeBudget.Sort();
            Console.Ajouter("Liste budget Periode = " + Periode + " : " + listeBudget.Count);

            List<Budget> lstBudget = new List<Budget>();

            foreach(Budget bg in listeBudget)
            {
                if(bg.Periode == Periode)
                {
                    if(Enveloppe>0) //L'enveloppe est indiquée
                    { if(Enveloppe == bg.Enveloppe) { lstBudget.Add(bg); }
                    }
                    else { lstBudget.Add(bg); }
                }
                else { Console.Ajouter("-> bg " + bg.Code + " non inclus (" + bg.Periode + ")"); }
            }
            
            return lstBudget;
        }

        /// <summary>
        /// Renvoie la liste des lignes budgétaires pour un exercice
        /// </summary>
        /// <param name="Periode"></param>
        /// <param name="Enveloppe"></param>
        public List<Budget_Ligne> Remplir_ListeBudgetLigne(int Periode, int Enveloppe = 0)
        {
            List<Budget_Ligne> listeBudgetLigne = (List<Budget_Ligne>)Acces.Remplir_ListeElement(Acces.type_BUDGET_LIGNE, "");
            listeBudgetLigne.Sort();

            List<Budget_Ligne> lstBudgetLigne = new List<Budget_Ligne>();

            foreach (Budget_Ligne bgl in listeBudgetLigne)
            {
                if (bgl.Periode == Periode)
                {
                    if (Enveloppe > 0)
                    {
                        if (Enveloppe == bgl.Enveloppe)
                        { lstBudgetLigne.Add(bgl); }
                    }
                    else
                    { lstBudgetLigne.Add(bgl); }
                }
            }

            return lstBudgetLigne;
        }

        /// <summary>
        /// Renvoie la liste des lignes budgétaires pour un exercice
        /// </summary>
        /// <param name="Budget_ID"></param>
        /// <param name="Enveloppe"></param>
        public List<Budget_Ligne> Remplir_ListeBudgetLigne_ID(int Budget_ID)
        {
            List<Budget_Ligne> listeBudgetLigne = (List<Budget_Ligne>)Acces.Remplir_ListeElement(Acces.type_BUDGET_LIGNE, "");
            listeBudgetLigne.Sort();

            List<Budget_Ligne> lstBudgetLigne = new List<Budget_Ligne>();

            foreach (Budget_Ligne bgl in listeBudgetLigne)
            {
                if (bgl.Budget_ID == Budget_ID)
                {
                    lstBudgetLigne.Add(bgl); 
                }
            }

            return lstBudgetLigne;
        }

        /// <summary>
        /// Renvoie la liste des lignes budgétaires pour un exercice
        /// </summary>
        /// <param name="Enveloppe"></param>
        /// <param name="Periode"></param>
        /// <param name="typeFlux"></param>
        public List<Budget_Nomenclature> Remplir_ListeBudgetNomenclature(int Enveloppe, int Periode, TypeFlux typeflux)
        {
            List<Budget_Nomenclature> listeBudgetNomenclature = (List<Budget_Nomenclature>)Acces.Remplir_ListeElement(Acces.type_BUDGET_NOMENCLATURE, "");
            listeBudgetNomenclature.Sort();

            List<Budget_Nomenclature> lstBudgetNomenclature = new List<Budget_Nomenclature>();

            foreach (Budget_Nomenclature bgl in listeBudgetNomenclature)
            {
                if (bgl.Enveloppe == Enveloppe 
                    && bgl.Periode == Periode
                    && (int)bgl.TypeFlux == (int)typeflux)
                { lstBudgetNomenclature.Add(bgl); }
            }

            return lstBudgetNomenclature;
        }

        /// <summary>
        /// Renvoie la liste des versions budgétaires pour un exercice
        /// </summary>
        /// <param name="Periode"></param>
        /// <param name="Enveloppe"></param>
        public List<Budget_Version> Remplir_ListeBudgetVersion(int Periode, int Enveloppe = 0)
        {
            List<Budget_Version> listeBudgetVersion = (List<Budget_Version>)Acces.Remplir_ListeElement(Acces.type_BUDGET_VERSION, "");
            listeBudgetVersion.Sort();

            List<Budget_Version> lstBudgetVersion = new List<Budget_Version>();

            foreach (Budget_Version bvr in listeBudgetVersion)
            {
                if (bvr.Periode == Periode)
                {
                    if (Enveloppe > 0)
                    {
                        if(Enveloppe == bvr.Enveloppe )
                        { lstBudgetVersion.Add(bvr); }
                    }
                    else
                    { lstBudgetVersion.Add(bvr); }
                }
            }

            return lstBudgetVersion;
        }

        /// <summary>
        /// Renvoie la liste des versions budgétaires pour un exercice
        /// </summary>
        /// <param name="budget_id"></param>
        public List<Budget_Version> Remplir_ListeBudgetVersion_ID(int Budget_ID)
        {
            List<Budget_Version> listeBudgetVersion = (List<Budget_Version>)Acces.Remplir_ListeElement(Acces.type_BUDGET_VERSION, "");
            listeBudgetVersion.Sort();

            List<Budget_Version> lstBudgetVersion = new List<Budget_Version>();

            foreach (Budget_Version bvr in listeBudgetVersion)
            {
                if (bvr.Budget_ID == Budget_ID)
                {
                    lstBudgetVersion.Add(bvr); 
                }
            }

            return lstBudgetVersion;
        }

        /// <summary>
        /// Renvoie la liste des opérations budgétaires pour un exercice
        /// </summary>
        /// <param name="Periode"></param>
        public List<Budget_Operation> Remplir_ListeBudgetOperation(int Periode)
        {
            List<Budget_Operation> listeBudgetOperation = (List<Budget_Operation>)Acces.Remplir_ListeElement(Acces.type_BUDGET_OPERATION, "");
            listeBudgetOperation.Sort();

            List<Budget_Operation> lstBudgetOperation = new List<Budget_Operation>();
            foreach (Budget_Operation bgl in listeBudgetOperation)
            {
                if (bgl.Periode == Periode) { lstBudgetOperation.Add(bgl); }
            }

            return lstBudgetOperation;
        }

        /// <summary>
        /// Renvoie la liste des virement budgétaires pour un exercice
        /// </summary>
        /// <param name="Periode"></param>
        public List<Budget_Virement> Remplir_ListeBudgetVirement(int Periode)
        {
            List<Budget_Virement> listeBudgetVirement = (List<Budget_Virement>)Acces.Remplir_ListeElement(Acces.type_BUDGET_VIREMENT, "");
            listeBudgetVirement.Sort();

            List<Budget_Virement> lstBudgetVirement = new List<Budget_Virement>();
            foreach (Budget_Virement bvr in listeBudgetVirement)
            {
                if (bvr.Periode == Periode) { lstBudgetVirement.Add(bvr); }
            }

            return lstBudgetVirement;
        }

        public void Afficher_BudgetEnveloppe()
        {
            DockContent D1 = new DockContent();

            ctrlListeEnveloppe ctrl = new ctrlListeEnveloppe();
            ctrl.Acces = Acces;
            ctrl.DP = Acces.DP;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Console = Acces.Console;
            ctrl.Chemin = Acces.CheminTemp;
            ctrl.Initialiser();
            D1.Controls.Add(ctrl);

            D1.Text = "Gestion des enveloppes";
            D1.Tag = "BUDGET_ENVELOPPE";
            D1.ShowInTaskbar = false;
            D1.CloseButton = true;
            D1.Show(Acces.DP, DockState.DockLeft);
        }

        public void Afficher_BudgetPeriode()
        {
            DockContent D1 = new DockContent();

            ctrlListePeriode ctrl = new ctrlListePeriode();
            ctrl.Acces = Acces;
            ctrl.DP = Acces.DP;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Console = Acces.Console;
            ctrl.Chemin = Acces.CheminTemp;
            ctrl.Initialiser();
            D1.Controls.Add(ctrl);

            D1.Text = "Gestion des périodes";
            D1.Tag = "BUDGET_PERIODE";
            D1.ShowInTaskbar = false;
            D1.CloseButton = true;
            D1.Show(Acces.DP, DockState.DockLeft);
        }

        public void Afficher_BudgetStructure(string Tab)
        {
            DockContent D1 = new DockContent();

            ctrlListeBudget ctrl = new ctrlListeBudget();
            ctrl.Acces = Acces;
            ctrl.DP = Acces.DP;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Console = Acces.Console;
            ctrl.Initialiser();
            if (Tab == "BUDGET") { ctrl.Afficher_Tab_BUDGET(); }
            if (Tab == "OPERATION") { ctrl.Afficher_Tab_OPERATION(); }
            if (Tab == "VIREMENT") { ctrl.Afficher_Tab_VIREMENT(); }
            D1.Controls.Add(ctrl);

            D1.Text = "Gestion des budgets";
            D1.Tag = "BUDGET";
            D1.ShowInTaskbar = false;
            D1.CloseButton = true;
            D1.Show(Acces.DP, DockState.Document);
        }

        public void Afficher_Nomenclature()
        {
            DockContent D1 = new DockContent();

            ctrl_Nomenclature ctrl = new ctrl_Nomenclature();
            ctrl.Acces = Acces;
            ctrl.Initialiser();
            ctrl.Dock = DockStyle.Fill;
            D1.Controls.Add(ctrl);

            D1.Show(Acces.DP, DockState.Document);
            D1.Text = "Nomenclature";
            D1.Tag = "NOMENCLATURE";
            D1.ShowInTaskbar = false;
            D1.CloseButton = true;
        }

        public void Afficher_GestionAssociation()
        {
            DockContent D1 = new DockContent();

            ctrlListeAssociation  ctrl = new ctrlListeAssociation();
            ctrl.Acces = Acces;
            ctrl.Initialiser();
            ctrl.Dock = DockStyle.Fill;
            D1.Controls.Add(ctrl);

            D1.Show(Acces.DP, DockState.Document);
            D1.Text = "Associations";
            D1.Tag = "ASSOCIATION";
            D1.ShowInTaskbar = false;
            D1.CloseButton = true;
        }
    }
}
