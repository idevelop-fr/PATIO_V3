﻿using System;
using PATIO.MAIN.Classes;

namespace PATIO.OMEGA.Classes
{
    class Liquidation : Classe_Modele, IComparable<Liquidation>
    {
        public TypeLiquidation TypeLiquidation { get; set; } = TypeLiquidation.Normal;

        public Liquidation()
        {
            ListeAttribut = new string[] {            };
        }

        public override bool Construire(Element e)
        {
            ID = e.ID;
            Code = e.Code;
            Libelle = e.Libelle.Replace("'''", "'");
            TypeLiquidation = (TypeLiquidation)e.Type_Element;
            Actif = e.Actif;

            /*
            foreach (dElement d in e.Liste)
            {
                if (d.Element_ID == ID)
                {
                    if (d.Attribut_Code == "TYPE") { TypeGroupe = (TypeGroupe)(int.Parse(d.Valeur)); }
                }
            }
            */
            return true;
        }

        //Transforme un groupe sous la forme Element, dElement
        public override Element Déconstruire()
        {
            Element e = new Element();
            //dElement d;

            e.ID = ID;
            e.Element_Type = Acces.type_GROUPE.ID;
            e.Code = Code;
            e.Libelle = Libelle;
            e.Type_Element = (int)TypeLiquidation;
            e.Actif = Actif;

            return e;
        }

        //Comparateur par défaut
        public int CompareTo(Liquidation p)
        {
            if (p is null) { return 1; }
            else { return (this.Libelle.CompareTo(p.Libelle)); }
        }
    }
}
