using System;
using System.Data;

namespace PATIO.MAIN.Classes
{
    public class Droit
    {
        public AccesNet Acces;

        public int ID { get; set; }
        public int User_ID { get; set; }
        public string Code { get; set; }
        public string DateDeb { get; set; }
        public string DateFin { get; set; }
        public bool Actif { get; set; }

        public Droit() { }

        public Droit(int _USER_ID, string _Code, string _DateDeb, string _DateFin)
        {
            User_ID = _USER_ID;
            Code = _Code;
            DateDeb = _DateDeb;
            DateFin = _DateFin;
            Actif = true;
        }

        public void Ajouter()
        {
            string sql;

            sql = "INSERT INTO droit (user_id, code, datedeb, datefin, actif) VALUES (";
            sql += "'" + User_ID + "',";
            sql += "'" + Code + "',";
            sql += "'" + DateDeb + "',";
            sql += "'" + DateFin + "',";
            sql += "'" + (Actif ?"1":"0") + "')";
            Acces.cls.Execute(sql);

            //Recherche de l'iD attribué
            sql = "SELECT id from droit";
            sql += " WHERE user_id='" + User_ID + "'";
            sql += " AND code='" + Code + "'";
            sql += " AND datedeb='" + DateDeb + "'";
            sql += " AND datefin='" + DateFin + "'";
            DataSet Sn = Acces.cls.ContenuRequete(sql);

            if (Acces.cls.NbLignes > 0) { ID = int.Parse(Sn.Tables["dataset"].Rows[0][0].ToString()); }
        }

        public void MettreAJour()
        {
            string sql;

            sql = "UPDATE droit SET";
            sql += " user_id ='" + User_ID + "',";
            sql += " code ='" + Code + "',";
            sql += " datedeb ='" + DateDeb + "',";
            sql += " datefin ='" + DateFin + "',";
            sql += " actif ='" + (Actif?"1":"0") + "'";
            sql += " WHERE id='" + ID + "'";
            Acces.cls.Execute(sql);
        }

        public void Supprimer()
        {
            string sql;

            sql = "DELETE FROM droit";
            sql += " WHERE id='" + ID + "'";
            Acces.cls.Execute(sql);
        }

        public Boolean Exister(int _User_ID, string _Code, string _DATE="")
        {
            string sql;

            sql = "SELECT * FROM droit";
            sql += " WHERE user_id='" + _User_ID + "'";
            sql += " AND Code='" + _Code + "'";
            sql += " AND actif=1";
            if (_DATE.Length > 0) {
                sql += " AND datedeb<='" + _DATE + "'";
                sql += " AND datefin>='" + _DATE + "'";
            }
            DataSet Sn = Acces.cls.ContenuRequete(sql);

            if (Acces.cls.NbLignes == 0) { return false; }
            else
            {
                foreach (DataRow r in Sn.Tables["dataset"].Rows)
                {
                    if (r["id"].ToString() != ID.ToString())
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        //Comparateur par défaut
        public int CompareTo(Parametre p)
        {
            if (p is null) { return 1; }
            else
            {
                string A = Code;
                string B = p.Code;
                return (A.CompareTo(B));
            }
        }
    }
}
