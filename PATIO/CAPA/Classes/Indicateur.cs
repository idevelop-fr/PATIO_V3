using System;
using PATIO.MAIN.Classes;
using System.Collections.Generic;

namespace PATIO.CAPA.Classes
{
    public class Indicateur :Classe_Modele, IComparable<Indicateur>
    {
        public TypeIndicateur TypeIndicateur { get; set; }

        public int Genre { get; set; }
        public int Categorie { get; set; }
        public int Type { get; set; }
        public int Repartition { get; set; }

        public Indicateur()
        {
            ListeAttribut = new string[] {"INDICATEUR_GENRE", "INDICATEUR_CATEGORIE",
                                          "INDICATEUR_TYPE", "INDICATEUR_REPARTITION"};
        }

        //Construction de l'indicateur à partir des informations de l'élément
        public override bool Construire(Element e)
        {
            ID = e.ID;
            Code = e.Code;
            Libelle = e.Libelle.Replace("'''", "'");
            TypeIndicateur = (TypeIndicateur)e.Type_Element;
            Actif = e.Actif;

            
            foreach (dElement d in e.Liste)
            {
                if (d.Element_ID == ID)
                {
                    if (d.Attribut_Code == "INDICATEUR_GENRE") { Genre = int.Parse(d.Valeur); }
                    if (d.Attribut_Code == "INDICATEUR_CATEGORIE") { Categorie = int.Parse(d.Valeur); }
                    if (d.Attribut_Code == "INDICATEUR_TYPE") { Type = int.Parse(d.Valeur); }
                    if (d.Attribut_Code == "INDICATEUR_REPARTITION") { Repartition = int.Parse(d.Valeur); }
                }
            }

            return true;
        }

        //Transforme un indicateur sous la forme Element, dElement
        public override Element Déconstruire()
        {
            Element e = new Element();
            dElement d;

            e.ID = ID;
            e.Element_Type =Acces.type_INDICATEUR.ID;
            e.Code = Code;
            e.Libelle = Libelle;
            e.Type_Element=(int) TypeIndicateur;
            e.Actif = Actif;

            string CodeAttribut = "";
            {
                CodeAttribut = "INDICATEUR_GENRE";
                d = new dElement(ID, Acces.Trouver_Attribut(Acces.type_OBJECTIF, CodeAttribut).ID, CodeAttribut, Genre.ToString());
                e.Liste.Add(d);
            }
            {
                CodeAttribut = "INDICATEUR_CATEGORIE";
                d = new dElement(ID, Acces.Trouver_Attribut(Acces.type_OBJECTIF, CodeAttribut).ID, CodeAttribut, Categorie.ToString());
                e.Liste.Add(d);
            }
            {
                CodeAttribut = "INDICATEUR_TYPE";
                d = new dElement(ID, Acces.Trouver_Attribut(Acces.type_OBJECTIF, CodeAttribut).ID, CodeAttribut, Type.ToString());
                e.Liste.Add(d);
            }
            {
                CodeAttribut = "INDICATEUR_REPARTITION";
                d = new dElement(ID, Acces.Trouver_Attribut(Acces.type_OBJECTIF, CodeAttribut).ID, CodeAttribut, Repartition.ToString());
                e.Liste.Add(d);
            }

            return e;
        }

        //Comparateur par défaut
        public int CompareTo(Indicateur p)
        {
            if (p is null) { return 1; }
            else { return (this.Libelle.CompareTo(p.Libelle)); }
        }
    }
}
