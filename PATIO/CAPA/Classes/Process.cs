using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PATIO.MAIN.Classes;

namespace PATIO.CAPA.Classes
{
    public class Process : Classe_Modele, IComparable<Process>
    {
        public TypeProcessus Type_Processus { get; set; }

        public List<int> DonneeEntrante;
        public List<int> DonneeSortante;

        public Process()
        {
            DonneeEntrante = new List<int>();
            DonneeSortante = new List<int>();

            ListeAttribut = new string[] {"DONNEE_ENTRANTE", "DONNEE_SORTANTE"
                                        };
        }

        //Construit un processus à partir des informations de l'élément
        public override bool Construire(Element e)
        {
            Process p = new Process();

            ID = e.ID;
            Code = e.Code;
            Libelle = e.Libelle.Replace("'''", "'");
            Type_Processus = (TypeProcessus)e.Type_Element;
            Element_Type = Acces.type_PROCESSUS.ID;
            Actif = e.Actif;


            foreach (dElement d in e.Liste)
            {
                if (d.Element_ID == ID)
                {
                    d.Valeur = d.Valeur.Replace("'''", "'");
                    // if (d.Attribut_Code == "PILOTE") { Pilote = Acces.Trouver_Utilisateur(int.Parse(d.Valeur.ToString())); }
                    if (d.Attribut_Code == "DONNEE_ENTRANTE") { DonneeEntrante.Add(int.Parse(d.Valeur)); }
                    if (d.Attribut_Code == "DONNEE_SORTANTE") { DonneeSortante.Add(int.Parse(d.Valeur)); }
                }
            }

            return true;
        }

        //Transforme un processus sous la forme Element, dElement
        public override Element Déconstruire()
        {
            Element e = new Element();
            dElement d;
            TypeElement Type = Acces.type_PROCESSUS;

            e.ID = ID;
            e.Element_Type = Type.ID;
            e.Code = Code;
            e.Libelle = Libelle;
            e.Type_Element = (int)Type_Processus;
            e.Actif = Actif;

            string CodeAttribut = "";

            if (!(DonneeEntrante is null))
            {
                CodeAttribut = "DONNEE_ENTRANTE";
                foreach (int k in DonneeEntrante)
                {
                    d = new dElement(ID, Acces.Trouver_Attribut(Type, CodeAttribut).ID, CodeAttribut, k.ToString());
                    e.Liste.Add(d);
                }
            }

            if (!(DonneeSortante is null))
            {
                CodeAttribut = "DONNEE_SORTANTE";
                foreach (int k in DonneeSortante)
                {
                    d = new dElement(ID, Acces.Trouver_Attribut(Type, CodeAttribut).ID, CodeAttribut, k.ToString());
                    e.Liste.Add(d);
                }
            }

            return e;
        }

        //Comparateur par défaut
        public virtual int CompareTo(Process p)
        {
            if (p is null) { return 1; }
            else { return (this.Code.CompareTo(p.Code)); }
        }
    }
}
