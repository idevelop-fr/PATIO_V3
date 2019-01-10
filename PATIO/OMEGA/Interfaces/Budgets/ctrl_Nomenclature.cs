using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using PATIO.MAIN.Classes;
using PATIO.OMEGA.Classes;

namespace PATIO.OMEGA.Interfaces.Budgets
{
    public partial class ctrl_Nomenclature : UserControl
    {
        public AccesNet Acces;

        List<Budget_Enveloppe> listeTypeEnveloppe;
        List<Budget_Periode> listePeriode;
        string[] listeTypeFlux;
        Fonctions fct = new Fonctions();

        public ctrl_Nomenclature()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {
            Afficher_TypeEnveloppe();
            Afficher_ListePeriode();
            Afficher_TypeFlux();
        }

        void Afficher_TypeFlux()
        {
            lstTypeFlux.Items.Clear();

            listeTypeFlux = Enum.GetNames(typeof(TypeFlux));

            foreach (var t in listeTypeFlux)
            {
                lstTypeFlux.Items.Add(t);
            }
        }

        void Afficher_TypeEnveloppe()
        {
            lstTypeEnveloppe.Items.Clear();
            listeTypeEnveloppe =(List<Budget_Enveloppe>) Acces.Remplir_ListeElement(Acces.type_BUDGET_ENVELOPPE,"");

            foreach (Budget_Enveloppe benv in listeTypeEnveloppe)
            {
                lstTypeEnveloppe.Items.Add(benv.Libelle);
            }
        }

        void Afficher_ListePeriode()
        {
            lstPeriode.Items.Clear();
            listePeriode =(List<Budget_Periode>) Acces.Remplir_ListeElement(Acces.type_BUDGET_PERIODE,"");

            foreach (Budget_Periode bp in listePeriode)
            {
                lstPeriode.Items.Add(bp.Libelle);
            }
        }

        void Afficher_ListeNomenclature()
        {
            DG_Nomenclature.DataSource = null;

            if (lstTypeEnveloppe.SelectedIndex < 0) { return; }
            if (lstPeriode.SelectedIndex < 0) { return; }
            if (lstTypeFlux.SelectedIndex < 0) { return; }

            int periode = listePeriode[lstPeriode.SelectedIndex].ID;
            int enveloppe = listeTypeEnveloppe[lstTypeEnveloppe.SelectedIndex].ID;
            TypeFlux typeflux = (TypeFlux) lstTypeFlux.SelectedIndex;

            List<Budget_Nomenclature> Liste = Acces.clsOMEGA.Remplir_ListeBudgetNomenclature(enveloppe, periode, typeflux);

            DG_Nomenclature.DataSource = Liste;
            DG_Nomenclature.Columns["id"].Visible = false;
            DG_Nomenclature.Columns["enveloppe"].Visible = false;
            DG_Nomenclature.Columns["periode"].Visible = false;
            DG_Nomenclature.Columns["typeflux"].Visible = false;
            DG_Nomenclature.Columns["Actif"].Visible = false;
            DG_Nomenclature.Columns["Element_Type"].Visible = false;
            DG_Nomenclature.Columns["Type_Element"].Visible = false;

            DG_Nomenclature.Columns["code"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DG_Nomenclature.Columns["libelle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnImporter_Click(object sender, EventArgs e)
        {
            Importer_Nomenclature();
        }

        void Importer_Nomenclature()
        {
            if (lstTypeEnveloppe.SelectedIndex < 0) { return; }
            if (lstPeriode.SelectedIndex < 0) { return; }
            if (lstTypeFlux.SelectedIndex < 0) { return; }

            int periode = listePeriode[lstPeriode.SelectedIndex].ID;
            int enveloppe = listeTypeEnveloppe[lstTypeEnveloppe.SelectedIndex].ID;
            TypeFlux typeflux = (TypeFlux)lstTypeFlux.SelectedIndex;

            string fichier;

            OpenFileDialog f = new OpenFileDialog();
            f.Title = "Choix d'un fichier d'importation";
            if (f.ShowDialog() == DialogResult.OK)
            {
                fichier = f.FileName;
                if (fichier.Length == 0) { return; }


                //Suppression des éléments existants
                List<Budget_Nomenclature> Liste = Acces.clsOMEGA.Remplir_ListeBudgetNomenclature(enveloppe, periode, typeflux);
                if(Liste.Count>0)
                {
                    if (MessageBox.Show("Les données vont être remplacées. Continuez ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        MessageBox.Show("Procédure arrêtée.");
                        return;
                    }
                    foreach (Budget_Nomenclature bg in Liste)
                    {
                        Acces.Supprimer_Element(Acces.type_BUDGET_NOMENCLATURE, bg);
                    }
                }

                string texte = fct.readFileAsUtf8(fichier);

                int n = 0;
                foreach (string txt in texte.Split((char)Keys.Return))
                {
                    string txt1 = txt.Replace("\n", "");
                    if (txt1.Length > 0)
                    {
                        string code = txt1.Split(';')[0];
                        string libelle = txt1.Split(';')[1];

                        //Traitement du libellé

                        Budget_Nomenclature nmcl = new Budget_Nomenclature();
                        nmcl.Acces = Acces;
                        nmcl.Code = code;
                        nmcl.Libelle = libelle;
                        nmcl.Enveloppe = enveloppe;
                        nmcl.Periode = periode;
                        nmcl.TypeFlux = typeflux;
                        Acces.Ajouter_Element(Acces.type_BUDGET_NOMENCLATURE, nmcl);

                        n++;
                    }
                }
                MessageBox.Show("Importation " + n + " lignes");
                Afficher_ListeNomenclature();
            }
        }

        private void lstTypeEnveloppe_SelectedIndexChanged(object sender, EventArgs e)
        {
            Afficher_ListeNomenclature();
        }

        private void lstPeriode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Afficher_ListeNomenclature();
        }

        private void lstTypeFlux_SelectedIndexChanged(object sender, EventArgs e)
        {
            Afficher_ListeNomenclature();
        }
    }
}
