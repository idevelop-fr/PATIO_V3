using System;
using PATIO.CAPA.Classes;
using System.Text;
using System.IO;

namespace PATIO.MAIN.Classes
{
    public class Fonctions
    {
        public AccesNet Acces;

        public TypePlan DonneTypePlan(string Libelle)
        {
            if (Libelle == TypePlan.DOSSIER.ToString()) { return TypePlan.DOSSIER; }
            if (Libelle == TypePlan.NATIONAL.ToString()) { return TypePlan.NATIONAL; }
            if (Libelle == TypePlan.REGIONAL.ToString()) { return TypePlan.REGIONAL; }
            if (Libelle == TypePlan.TERRITORIAL.ToString()) { return TypePlan.TERRITORIAL; }
            if (Libelle == TypePlan.TRANSVERSE.ToString()) { return TypePlan.TRANSVERSE; }
            if (Libelle == TypePlan.LOCAL.ToString()) { return TypePlan.LOCAL; }

            return TypePlan.DOSSIER;
        }

        public NiveauPlan DonneNiveauPlan(string Libelle)
        {
            if (Libelle == NiveauPlan.Niveau_2.ToString()) { return NiveauPlan.Niveau_2; }
            if (Libelle == NiveauPlan.Niveau_3.ToString()) { return NiveauPlan.Niveau_3; }
            if (Libelle == NiveauPlan.Niveau_4.ToString()) { return NiveauPlan.Niveau_4; }

            return NiveauPlan.Niveau_2;
        }

        public TypeObjectif DonneTypeObjectif(string Libelle)
        {
            if (Libelle == TypeObjectif.DOSSIER.ToString()) { return TypeObjectif.DOSSIER; }
            if (Libelle == TypeObjectif.AXE.ToString()) { return TypeObjectif.AXE; }
            if (Libelle == TypeObjectif.STRATEGIQUE.ToString()) { return TypeObjectif.STRATEGIQUE; }
            if (Libelle == TypeObjectif.OPERATIONNEL.ToString()) { return TypeObjectif.OPERATIONNEL; }

            return TypeObjectif.DOSSIER;
        }

        public Meteo DonneMeteo(string Libelle)
        {
            if (Libelle == Meteo.SOLEIL.ToString()) { return Meteo.SOLEIL; }
            if (Libelle == Meteo.SOLEIL_NUAGES.ToString()) { return Meteo.SOLEIL_NUAGES; }
            if (Libelle == Meteo.NUAGES.ToString()) { return Meteo.NUAGES; }
            if (Libelle == Meteo.ORAGE.ToString()) { return Meteo.ORAGE; }

            return Meteo.SOLEIL;
        }

        public TxAvancement DonneTxAvancement(string Libelle)
        {
            if (Libelle == TxAvancement.PCT_0_25.ToString()) { return TxAvancement.PCT_0_25; }
            if (Libelle == TxAvancement.PCT_25_50.ToString()) { return TxAvancement.PCT_25_50; }
            if (Libelle == TxAvancement.PCT_50_75.ToString()) { return TxAvancement.PCT_50_75; }
            if (Libelle == TxAvancement.PCT_75_100.ToString()) { return TxAvancement.PCT_75_100; }

            return TxAvancement.PCT_0_25;
        }

        public TypeAction DonneTypeAction(string Libelle)
        {
            if (Libelle == TypeAction.DOSSIER.ToString()) { return TypeAction.DOSSIER; }
            if (Libelle == TypeAction.ACTION.ToString()) { return TypeAction.ACTION; }
            if (Libelle == TypeAction.OPERATION.ToString()) { return TypeAction.OPERATION; }

            return TypeAction.DOSSIER;
        }

        public TypeIndicateur DonneTypeIndicateur(string Libelle)
        {
            if (Libelle == TypeIndicateur.DOSSIER.ToString()) { return TypeIndicateur.DOSSIER; }
            if (Libelle == TypeIndicateur.IMPACT.ToString()) { return TypeIndicateur.IMPACT; }
            if (Libelle == TypeIndicateur.MOYEN.ToString()) { return TypeIndicateur.MOYEN; }
            if (Libelle == TypeIndicateur.RESULTAT.ToString()) { return TypeIndicateur.RESULTAT; }

            return TypeIndicateur.DOSSIER;
        }

        public TypeLicence DonneTypeLicence(string Libelle)
        {
            if (Libelle == TypeLicence.ADMINISTRATEUR.ToString()) { return TypeLicence.ADMINISTRATEUR; }
            if (Libelle == TypeLicence.PILOTE.ToString()) { return TypeLicence.PILOTE; }
            if (Libelle == TypeLicence.VISITEUR.ToString()) { return TypeLicence.VISITEUR; }

            return TypeLicence.VISITEUR;
        }

        public string Converti_utf8(string txt)
        {
            var utf8 = System.Text.Encoding.UTF8;
            byte[] utfBytes = utf8.GetBytes(txt);
            string texte = utf8.GetString(utfBytes, 0, utfBytes.Length);
            return texte;
        }

        public DateTime ConvertiStringToDate(string txt)
        {
            DateTime d = new DateTime();

            if (txt != null)
            {
                try
                {
                    string D = txt.Substring(6, 2);
                    string M = txt.Substring(4, 2);
                    string A = txt.Substring(0, 4);
                    d = DateTime.Parse(D + "/" + M + "/" + A);
                }
                catch { }
            }

            return d;
        }

        public string ConvertiDateToString(DateTime date)
        {
            return string.Format("{0:yyyyMMdd}", date);
        }

        public String readFileAsUtf8(string fileName)
        {
            Encoding encoding = Encoding.Default;
            String original = String.Empty;

            using (StreamReader sr = new StreamReader(fileName, Encoding.Default))
            {
                original = sr.ReadToEnd();
                encoding = sr.CurrentEncoding;
                sr.Close();
            }

            if (encoding == Encoding.UTF8)
                return original;

            byte[] encBytes = encoding.GetBytes(original);
            byte[] utf8Bytes = Encoding.Convert(encoding, Encoding.UTF8, encBytes);
            return Encoding.UTF8.GetString(utf8Bytes);
        }
    }
}
