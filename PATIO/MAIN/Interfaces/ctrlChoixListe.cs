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
using PATIO.MAIN.Classes;

namespace PATIO.MAIN.Interfaces
{
    public partial class ctrlChoixListe : UserControl
    {
        public List<Parametre> ListeChoix = new List<Parametre>();
        public List<Parametre> ListeSelection = new List<Parametre>();
        public List<int> ListeSelectionId = new List<int>();

        public event EventHandler<evt_Echanger> EVT_Echanger;

        public class evt_Echanger : EventArgs
        {
            public evt_Echanger(string s)
            {
                id = s;
            }
            private string id;

            public string ID
            {
                get { return id; }
                set { id = value; }
            }
        }

        public ctrlChoixListe()
        {
            InitializeComponent();
            this.Tag = "CHOIXLISTE";
        }

        public void Initialiser()
        {
            lstChoix.Items.Clear();
            lstSelection.Items.Clear();
            ListeChoix = new List<Parametre>();
            ListeSelection = new List<Parametre>();
            ListeSelectionId = new List<int>();
        }

        public void Afficher_Liste()
        {
            Afficher_Liste_Choix();
            Affiche_Liste_Selection();
        }

        public void Afficher_Liste_Choix()
        {
            lstChoix.Items.Clear();
            foreach (Parametre p in ListeChoix)
            {
                if (lblRecherche.Text.Length > 0)
                {
                    if(p.Valeur.ToUpper().Contains(lblRecherche.Text.Trim().ToUpper()))
                    {
                        lstChoix.Items.Add(p.Valeur);
                    }
                }
                else
                {
                    lstChoix.Items.Add(p.Valeur);
                }
            }
        }

        void Affiche_Liste_Selection()
        {
            foreach (Parametre p in ListeSelection)
            {
                lstSelection.Items.Add(p.Valeur);
                ListeSelectionId.Add(p.ID);
                //Suppression de la liste des choix
                for (int i = 0; i < lstChoix.Items.Count; i++)
                {
                    if (lstChoix.Items[i].ToString() == p.Valeur)
                    { lstChoix.Items.Remove(lstChoix.Items[i]); break; }
                }
            }
        }

        private void ctrlChoixListe_Resize(object sender, EventArgs e)
        {
            int taille = 0;

            //Redimensionne les composantes en largeur
            taille = this.Size.Width-Barre.Size.Width;
            if (taille >= 100)
            {
                groupBox1.Width = taille / 2;
                groupBox2.Width = taille / 2;
            }

            //Redimensionne les composantes en hauteur
            //taille = this.Size.Height - btnAjouter.Size.Height - btnRetirer.Size.Height - Separ.Size.Height;
            if(taille>0)
            {
                //ecart.Height = taille / 2;
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            Ajouter();
        }

        void Ajouter()
        {
            if(lstChoix.SelectedItem is null) { return; }

            for (int i = 0; i < lstChoix.SelectedItems.Count; i++)
            {
                foreach (Parametre p in ListeChoix)
                {
                    if (p.Valeur == lstChoix.SelectedItems[i].ToString())
                    {
                        ListeSelection.Add(p);
                        ListeSelectionId.Add(p.ID);
                        ListeChoix.Remove(p);
                        break;
                    }
                }
            }

            for (int i = 0; i < lstChoix.SelectedItems.Count; i++)
            {
                lstSelection.Items.Add(lstChoix.SelectedItems[i]);
            }

            //Suppression des valeurs de la liste
            foreach(Parametre p in ListeSelection)
            {
                for (int i = 0; i < lstChoix.Items.Count; i++)
                {
                    if (p.Valeur == lstChoix.Items[i].ToString())
                    {
                        lstChoix.Items.Remove(lstChoix.Items[i]);
                        break;
                    }
                }
            }

            lstSelection.Sorted = true;
            OnRaise_Evt_Echanger(new evt_Echanger(this.Tag.ToString())); //Déclenche l'événement de modification
        }

        protected virtual void OnRaise_Evt_Echanger(evt_Echanger e)
        {
            EventHandler<evt_Echanger> handler = EVT_Echanger;

            if (handler != null)
            {
                e.ID = this.Tag.ToString();
                handler(this, e);
            }
        }

        private void btnRetirer_Click(object sender, EventArgs e)
        {
            Retirer();
        }

        void Retirer()
        {
            if (lstSelection.SelectedItem is null) { return; }

            for (int i = 0; i < lstSelection.SelectedItems.Count; i++)
            {
                foreach (Parametre p in ListeSelection)
                {
                    if (p.Valeur == lstSelection.SelectedItems[i].ToString())
                    {
                        ListeChoix.Add(p);
                        ListeSelection.Remove(p);
                        ListeSelectionId.Remove(p.ID);
                        lstChoix.Items.Add(lstSelection.SelectedItems[i]);
                        break;
                    }
                }
            }

            foreach (Parametre p in ListeChoix)
            {
                for (int i = 0; i < lstSelection.Items.Count; i++)
                {
                    if (p.Valeur == lstSelection.Items[i].ToString())
                    {
                        lstSelection.Items.Remove(lstSelection.Items[i]);
                        break;
                    }
                }
            }

            lstChoix.Sorted = true;
            OnRaise_Evt_Echanger(new evt_Echanger(this.Tag.ToString())); //Déclenche l'événement de modification
        }

        private void lstChoix_DoubleClick(object sender, EventArgs e)
        {
            Ajouter();
            lblRecherche.Focus();
            lblRecherche.SelectAll();
        }

        private void lstSelection_DoubleClick(object sender, EventArgs e)
        {
            Retirer();
        }

        private void btnTout_Click(object sender, EventArgs e)
        {
            Transfèrer_Tout();
        }

        void Transfèrer_Tout()
        {
            if(lstChoix.Items.Count>0)
            {
                for(int i = 0; i< lstChoix.Items.Count ; i++)
                {
                    lstChoix.SelectedItems.Add(lstChoix.Items[i]);
                }
                Ajouter();
            }
            else
            {
                for (int i = 0; i < lstSelection.Items.Count; i++)
                {
                    lstSelection.SelectedItems.Add(lstSelection.Items[i]);

                }
                Retirer();
            }
        }

        private void lblRecherche_TextChanged(object sender, EventArgs e)
        {
            Afficher_Liste_Choix();
        }

        private void lstChoix_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(lstChoix.SelectedIndex <0) { return; }
            if(e.KeyChar==(Char) Keys.Enter)
            {
                MessageBox.Show(lstChoix.SelectedItem.ToString());
            }
        }

        private void lstSelection_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (lstSelection.SelectedIndex < 0) { return; }
            if (e.KeyChar == (Char)Keys.Enter)
            {
                MessageBox.Show(lstSelection.SelectedItem.ToString());
            }
        }
    }
}
