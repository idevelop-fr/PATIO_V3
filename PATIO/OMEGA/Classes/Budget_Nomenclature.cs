using System;
using PATIO.MAIN.Classes;
using System.Windows.Forms;

namespace PATIO.OMEGA.Classes
{
    public class Budget_Nomenclature : Classe_Modele, IComparable<Budget_Nomenclature>
    {
        public int Periode { get; set; }
        public int Enveloppe { get; set; }
        public TypeFlux TypeFlux { get; set; }

        public Budget_Nomenclature()
        {
            ListeAttribut = new string[] { "PERIODE", "TYPE_FLUX", };
        }

        public override bool Construire(Element e)
        {
            ID = e.ID;
            Code = e.Code;
            Libelle = e.Libelle.Replace("''", "'");
            Element_Type = e.Element_Type;
            Type_Element = e.Type_Element;
            Actif = e.Actif;
            Enveloppe = e.Type_Element;

            foreach (dElement d in e.Liste)
            {
                if (d.Element_ID == ID)
                {
                    if (d.Attribut_Code == "PERIODE") { Periode = int.Parse(d.Valeur); }
                    if (d.Attribut_Code == "TYPE_FLUX") { TypeFlux = (TypeFlux) int.Parse(d.Valeur); }
                }
            }

            return true;
        }

        //Transforme un groupe sous la forme Element, dElement
        public override Element Déconstruire()
        {
            TypeElement type = Acces.type_BUDGET_NOMENCLATURE;

            Element e = new Element();
            dElement d;
            string CodeAttribut = "";

            e.ID = ID;
            e.Code = Code;
            e.Libelle = Libelle;
            e.Element_Type = type.ID;
            e.Type_Element = Enveloppe ;
            e.Actif = Actif;

            //Période
            {
                CodeAttribut = "PERIODE";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, Periode.ToString());
                e.Liste.Add(d);
            }

            //TypeFlux
            {
                CodeAttribut = "TYPE_FLUX";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, ((int) TypeFlux).ToString());
                e.Liste.Add(d);
            }
            return e;
        }

        //Comparateur par défaut
        public int CompareTo(Budget_Nomenclature p)
        {
            if (p is null) { return 1; }
            else { return (this.Code.CompareTo(p.Code)); }
        }
    }
}
