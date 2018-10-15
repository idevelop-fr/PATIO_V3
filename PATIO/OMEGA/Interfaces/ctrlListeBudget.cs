using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PATIO.CAPA.Classes;
using PATIO.Modules;
using Microsoft.Office.Interop.Excel;
using WeifenLuo.WinFormsUI.Docking;

namespace PATIO.OMEGA.Interfaces
{
    public partial class ctrlListeBudget : UserControl
    {
        public AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;

        public string Chemin;
        public ctrlConsole Console;

        public ctrlListeBudget()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {
            Afficher_ListeBudget();
        }

        void Afficher_ListeBudget()
        {

        }

        private void btnCréerExercice_Click(object sender, EventArgs e)
        {
            Ajouter_Budget();
        }

        void Ajouter_Budget()
        {
            var f = new frmBudget();
            f.Acces = Acces;
            f.Creation = true;

            f.budget.Actif = true;

            f.Initialiser();


            if (f.ShowDialog(this) == DialogResult.OK)
            {
                Afficher_ListeBudget();

                TreeNode[] Nod = lstBudget.Nodes.Find(f.budget.ID.ToString(), true);
                if (Nod.Length > 0)
                {
                    lstBudget.SelectedNode = Nod[0];
                    Nod[0].EnsureVisible();
                }
            }
        }

        void Ajouter_SousBudget()
        {
            if (lstBudget.SelectedNode is null) { MessageBox.Show("Choix d'un budget"); return; }

            Indicateur indParent = (Indicateur)Acces.Trouver_Element(Acces.type_INDICATEUR.id, int.Parse(lstBudget.SelectedNode.Name.ToString()));
            if (!(indParent.TypeIndicateur == TypeIndicateur.DOSSIER))
            {
                MessageBox.Show("Impossible de créer un budget sous un budget autre qu'un type DOSSIER", "Erreur", MessageBoxButtons.OK);
                return;
            }

            var f = new frmBudget();
            f.Acces = Acces;
            f.Creation = true;

            f.budget.Actif = true;
            f.budget.Code = indParent.Code;
            f.Initialiser();

            if (f.ShowDialog(this) == DialogResult.OK)
            {
                if (!(lstBudget.SelectedNode is null))
                {
                    //Création du lien avec le parent
                    Lien l = new Lien()
                    {
                        element0_type = Acces.type_PLAN.id,
                        element0_id = 1,
                        element0_code = "SYSTEME",
                        element1_type = Acces.type_INDICATEUR.id,
                        element2_type = Acces.type_INDICATEUR.id,
                        element1_id = int.Parse(lstBudget.SelectedNode.Name),
                        element1_code = ((Indicateur)Acces.Trouver_Element(Acces.type_INDICATEUR.id, int.Parse(lstBudget.SelectedNode.Name))).Code,
                        element2_id = f.budget.ID,
                        element2_code = ((Indicateur)Acces.Trouver_Element(Acces.type_INDICATEUR.id, f.budget.ID)).Code,
                        ordre = 1,
                        Acces = Acces,
                    };
                    l.Ajouter();
                    Acces.Ajouter_Lien(l);
                }
                Afficher_ListeBudget();

                TreeNode[] Nod = lstBudget.Nodes.Find(f.budget.ID.ToString(), true);
                if (Nod.Length > 0) { lstBudget.SelectedNode = Nod[0].Parent; Nod[0].EnsureVisible(); }
            }
        }

        private void BtnCréerSousAction_Click(object sender, EventArgs e)
        {
            Ajouter_SousBudget();
        }
    }
}
