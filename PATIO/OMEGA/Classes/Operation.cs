using System;
using PATIO.Modules;

namespace PATIO.OMEGA.Classes
{
    class Operation
    {
        public AccesNet Acces;
        public int ID { get; set; }
        public String Code { get; set; }
        public String Libelle { get; set; }

        public TypeOperation TypeOperation { get; set; } = TypeOperation.Dépenses;

        public int ProprietaireId { get; set; }
        public bool Actif { get; set; } = true;

        public void Construire(Element e)
        {
            ID = e.ID;
            Code = e.Code;
            Libelle = e.Libelle.Replace("'''", "'");
            TypeOperation = (TypeOperation)e.Type_Element;
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
        }

        //Transforme un groupe sous la forme Element, dElement
        public Element Déconstruire()
        {
            Element e = new Element();
            //dElement d;

            e.ID = ID;
            e.Element_Type = Acces.type_GROUPE.id;
            e.Code = Code;
            e.Libelle = Libelle;
            e.Type_Element = (int)TypeOperation;
            e.Actif = Actif;

            return e;
        }

        //Comparateur par défaut
        public int CompareTo(Operation p)
        {
            if (p is null) { return 1; }
            else { return (this.Libelle.CompareTo(p.Libelle)); }
        }
    }
}
