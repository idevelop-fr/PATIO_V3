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

namespace PATIO.ADMIN.Interfaces
{
    public partial class ctrlAdmin_DataBase : UserControl
    {
        public AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;
        public string Chemin;

        public ctrlConsole Console;

        public ctrlAdmin_DataBase()
        {
            InitializeComponent();
        }

        private void btnEffacer_Click(object sender, EventArgs e)
        {
            lblSQL.Text = "";
        }

        private void btnExecuter_Click(object sender, EventArgs e)
        {
            Exécuter();
        }

        void Exécuter()
        {
            string sql = lblSQL.Text.Trim();
            if (sql.Length == 0) { return; }

            if(sql.ToUpper().Substring(0,6) == "SELECT")
            { Executer_SELECT(); }
            else
            { Executer_NON_SELECT(); }
        }

        void Executer_SELECT()
        {
            string sql = lblSQL.Text.Trim();
            lblSortie.Text = "";

            DataSet Sn = Acces.cls.ContenuRequete(sql);

            if(Acces.cls.NbLignes == 0)
            {
                lblSortie.Text = "Aucune ligne";
                return;
            }

            string texte = "";

            foreach(DataRow r in Sn.Tables["dataset"].Rows)
            {
                for(int i=0; i< Sn.Tables["dataset"].Columns.Count;i++)
                {
                    texte += r[i].ToString() + "\t" ;
                }
                texte += (char)10 + (char)13;
            }

            lblSortie.Text = texte;
        }

        void Executer_NON_SELECT()
        {
            string sql = lblSQL.Text.Trim();

            Acces.cls.Execute(sql);

            lblSortie.Text = (Acces.cls.erreur.Length>0) ? Acces.cls.erreur : "OK";
        }

        private void btnSuppression_lien_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM lien";

            sql += " WHERE Element0_ID = {ID_PLAN}";
            sql += " AND Element2_ID = {ID_OBJET}";

            lblSQL.Text = sql;
        }
    }
}
