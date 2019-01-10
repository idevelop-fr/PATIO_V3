using System;
using PATIO.MAIN.Classes;
using System.Windows.Forms;

namespace PATIO.MAIN.Classes
{
    public class Classe_Modele : IComparable
    {
        public AccesNet Acces;
        public int ID { get; set; }
        public String Code { get; set; }
        public String Libelle { get; set; }
        public int Element_Type { get; set; } //Acces.Type_xx.Id

        public int Type_Element { get; set; } //Sous-type

        public bool Actif { get; set; } = true;

        public string[] ListeAttribut = { };

        public virtual bool Construire(Element e)
        {
            ID = e.ID;
            Code = e.Code;
            Libelle = e.Libelle.Replace("''", "'");
            Element_Type = e.Element_Type;
            Actif = e.Actif;

            return true;
        }

        //Transforme un groupe sous la forme Element, dElement
        public virtual Element Déconstruire()
        {
            Element e = new Element();
            dElement d;
            TypeElement type = Acces.type_BUDGET;

            e.ID = ID;
            e.Element_Type = type.ID;
            e.Code = Code;
            e.Libelle = Libelle;
            e.Element_Type = Element_Type;
            e.Actif = Actif;

            return e;
        }

        //Comparateur par défaut
        public virtual int CompareTo(object p)
        {
             return 1; 
        }
    }
}
