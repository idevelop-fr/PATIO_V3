using System;
using System.Collections.Generic;
using PATIO.CAPA.Classes;
using PATIO.MAIN.Classes;
using PATIO.ADMIN.Classes;

namespace PATIO.CAPA.Classes
{
    public class Projet : Classe_Modele, IComparable<Projet>
    {
        public Utilisateur Pilote { get; set; }
        public int TypeProjet { get; set; }
        public int Statut { get; set; } = 0;

        public List<int> EnveloppeBudget { get; set; }

        public Projet()
        {
            ListeAttribut = new string[] { "PILOTE", "STATUT", "ENVELOPPE_BUDGET", };
            EnveloppeBudget = new List<int>();
        }

        //Construit un plan à partir des informations de l'élément
        public override bool Construire(Element e)
        {
            Plan p = new Plan();

            ID = e.ID;
            Code = e.Code;
            Libelle = e.Libelle.Replace("'''", "'");
            TypeProjet = e.Type_Element;
            Actif = e.Actif;
            foreach (dElement d in e.Liste)
            {
                if (d.Element_ID == ID)
                {
                    d.Valeur = d.Valeur.Replace("'''", "'");
                    if (d.Attribut_Code == "PILOTE") { Pilote = Acces.Trouver_Utilisateur(int.Parse(d.Valeur.ToString())); }
                    if (d.Attribut_Code == "STATUT") { Statut = int.Parse(d.Valeur.ToString()); }
                    if (d.Attribut_Code == "ENVELOPPE_BUDGET") { EnveloppeBudget.Add(int.Parse(d.Valeur)); }
                }
            }

            return true;
        }

        //Transforme un plan sous la forme Element, dElement
        public override Element Déconstruire()
        {
            Element e = new Element();
            dElement d;
            TypeElement type = Acces.type_PROJET;

            e.ID = ID;
            e.Element_Type = type.ID;
            e.Code = Code;
            e.Libelle = Libelle;
            e.Type_Element = TypeProjet;
            e.Actif = Actif;

            string CodeAttribut = "";

            if (Pilote != null)
            {
                CodeAttribut = "PILOTE";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, Pilote.ID.ToString());
                e.Liste.Add(d);
            }

            {
                CodeAttribut = "STATUT";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, Statut.ToString());
                e.Liste.Add(d);
            }

            if(EnveloppeBudget != null)
            {
                CodeAttribut = "ENVELOPPE_BUDGET";
                foreach (int k in EnveloppeBudget)
                {
                    d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, k.ToString());
                    e.Liste.Add(d);
                }
            }

            return e;
        }

        //Comparateur par défaut
        public virtual int CompareTo(Projet p)
        {
            if (p is null) { return 1; }
            else { return (this.Libelle.CompareTo(p.Libelle)); }
        }

    }

}
