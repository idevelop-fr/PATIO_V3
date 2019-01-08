using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PATIO.MAIN.Classes;
using PATIO.CAPA.Classes;

namespace PATIO.CAPA.Interfaces
{
    public partial class frmProcessus : Form
    {
        public Process processus;
        public Process processusParent;
        public AccesNet Acces;
        public Boolean Creation = false;

        string[] listeTypeProcessus;

        public frmProcessus()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {
            btnAjouterDonnée.Visible = false;
            lblLibelleProcessus.Text = processus.Libelle;
            lblCodeProcessus.Text = processus.Code;
            Afficher_Code();

            OptActiveProcessus.Checked = processus.Actif;

            Afficher_TypeProcessus();
            lstTypeProcessus.SelectedIndex = lstTypeProcessus.Items.IndexOf(processus.Type_Processus.ToString());

            Afficher_Données();
        }

        void Afficher_Données()
        {
            ChoixDonneeEntrant.Initialiser();
            foreach (table_valeur tv in Acces.Remplir_ListeTableValeur("DONNEE_PROCESSUS"))
            {
                Boolean ok = false;
                foreach (int k in processus.DonneeEntrante)
                {
                    if (tv.ID == k) { ok = true; break; }
                }
                if (ok)
                {
                    ChoixDonneeEntrant.ListeSelection.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
                }
                ChoixDonneeEntrant.ListeChoix.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
            }
            ChoixDonneeEntrant.Afficher_Liste();

            ChoixDonneeSortant.Initialiser();
            foreach (table_valeur tv in Acces.Remplir_ListeTableValeur("DONNEE_PROCESSUS"))
            {
                Boolean ok = false;
                foreach (int k in processus.DonneeSortante)
                {
                    if (tv.ID == k) { ok = true; break; }
                }
                if (ok)
                {
                    ChoixDonneeSortant.ListeSelection.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
                }
                ChoixDonneeSortant.ListeChoix.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
            }
            ChoixDonneeSortant.Afficher_Liste();
        }

        void Afficher_TypeProcessus()
        {
            lstTypeProcessus.Items.Clear();

            listeTypeProcessus = Enum.GetNames(typeof(TypeProcessus));

            foreach (var t in listeTypeProcessus)
            {
                lstTypeProcessus.Items.Add(t);
            }
        }

        private void BtnAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        void Valider()
        {
            var LibProcessus = lblLibelleProcessus.Text.Trim();
            var CodeProcessus = lblCodeProcessus.Text.Trim().ToUpper();
            var OptActive = OptActiveProcessus.Checked;
            var TypeProcessus = (TypeProcessus)lstTypeProcessus.SelectedIndex;


            if (LibProcessus.Length == 0)
            {
                MessageBox.Show("Libellé du processus obligatoire", "Erreur", MessageBoxButtons.OK);
                return;
            }

            if (CodeProcessus.Length == 0)
            {
                MessageBox.Show("Code du processus obligatoire", "Erreur", MessageBoxButtons.OK);
                return;
            }

            bool ok = false;
            if (Creation) { ok = Acces.Existe_Element(Acces.type_PROCESSUS, "CODE", CodeProcessus); }
            else
            {
                //ok = fonc.ExisteCode(Acces.type_INDICATEUR, CodeGroupe, groupe.ID);
            }

            if (ok) { MessageBox.Show("Pb avec le code", "Erreur", MessageBoxButtons.OK); return; }

            processus.Acces = Acces;
            processus.Libelle = LibProcessus;
            processus.Code = CodeProcessus;
            processus.Actif = OptActive;
            processus.Type_Processus = TypeProcessus;
            processus.DonneeEntrante = ChoixDonneeEntrant.ListeSelectionId;
            processus.DonneeSortante = ChoixDonneeSortant.ListeSelectionId;

            TypeElement Type = Acces.type_PROCESSUS;

            if (Creation)
            {
                if (!(Acces.Existe_Element(Type, "CODE", processus.Code)))
                {
                    processus.ID = Acces.Ajouter_Element(Type, processus);

                    if (processusParent != null)
                    {
                        Lien p = new Lien() { Acces = Acces };
                        p.element0_type = Acces.type_PLAN.ID; //SYSTEME
                        p.element0_id = 1; //SYSTEME
                        p.element0_code = "SYSTEME"; //SYSTEME
                        p.element1_type = Acces.type_PROCESSUS.ID;
                        p.element1_id = processusParent.ID;
                        p.element1_code = ((Process)Acces.Trouver_Element(Acces.type_PROCESSUS, p.element1_id)).Code;
                        p.element2_type = Acces.type_PROCESSUS.ID;
                        p.element2_id = processus.ID;
                        p.element2_code = ((Process)Acces.Trouver_Element(Acces.type_PROCESSUS, p.element2_id)).Code;
                        p.ordre = p.Donner_Ordre() + 1;

                        p.Ajouter();
                        Acces.Ajouter_Lien(p);
                    }
                }
                else { MessageBox.Show("Processus existant (Code)", "Erreur"); return; }
            }
            else
            {
                Acces.Enregistrer(Type, processus);
            }

            this.DialogResult = DialogResult.OK;
        }

        private void BtnValider_Click(object sender, EventArgs e)
        {
            Valider();
        }

        void Generer_Code()
        {
            string code = lblEntete.Text;

            if (lblRef1.Text.Length > 0) { code += "-" + lblRef1.Text.Replace("-", "_").Trim(); }
            if (lblRef2.Text.Length > 0) { code += "-" + lblRef2.Text.Replace("-", "_").Trim(); }

            lblCodeProcessus.Text = code;
        }

        private void lblRef1_TextChanged(object sender, EventArgs e)
        {
            Generer_Code();
        }

        private void lblRef2_TextChanged(object sender, EventArgs e)
        {
            Generer_Code();
        }

        void Afficher_Code()
        {
            string code = lblCodeProcessus.Text.Replace("PRO-", "");

            lblEntete.Text = "PRO";
            lblRef1.Text = code.Split('-')[0];
            try { lblRef2.Text = code.Split('-')[1]; } catch { }
        }

        private void btnAjouterDonnée_Click(object sender, EventArgs e)
        {
            Ajouter_Donnee();
        }

        void Ajouter_Donnee()
        {
            PATIO.ADMIN.frmTableValeur f = new ADMIN.frmTableValeur();
            f.Acces = Acces;
            f.Initialiser();
            f.lstNom.Text = "DONNEE_PROCESSUS";

            if (f.ShowDialog() == DialogResult.OK)
            {
                Afficher_Données();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAjouterDonnée.Visible = (tabControl1.SelectedIndex == 1);
        }
    }
}
