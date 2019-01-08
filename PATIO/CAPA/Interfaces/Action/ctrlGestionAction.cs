using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PATIO.MAIN.Classes;
using PATIO.CAPA.Classes;
using PATIO.MAIN.Interfaces;

namespace PATIO.CAPA.Interfaces
{
    public partial class ctrlGestionAction : UserControl
    {
        /// <summary>
        /// Définition des paramètres publics
        /// </summary>
        public PATIO.CAPA.Classes.Action action;
        public AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;

        public ctrlConsole Console;

        public ctrlGestionAction()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {
            Afficher_ListeElement();
        }

        public void Afficher_Onglets(int i)
        {
            tabControlElement.SelectedIndex = i;
        }

        void Afficher_ListeElement()
        {
            Afficher_Informations();
            Afficher_ListeProjet();
            Afficher_Indicateur();
            Afficher_Document();
        }

        void Afficher_Informations()
        {
            ctrlGestionAction_Information1.Acces = Acces;
            ctrlGestionAction_Information1.action = action;
            ctrlGestionAction_Information1.Initialiser();
        }

        void Afficher_ListeProjet()
        {
            ctrlListeProjet1.Acces = Acces;
            ctrlListeProjet1.action = action;
            ctrlListeProjet1.Console = Console;
            ctrlListeProjet1.Initialiser();
        }

        void Afficher_Indicateur()
        {
            ctrlGestionAction_Indicateur1.Acces = Acces;
            ctrlGestionAction_Indicateur1.action = action;
            ctrlGestionAction_Indicateur1.Initialiser();
        }

        void Afficher_Document()
        {
            ctrlGestionAction_Document1.Acces = Acces;
            ctrlGestionAction_Document1.action = action;
            ctrlGestionAction_Document1.Initialiser();
        }

    }
}
