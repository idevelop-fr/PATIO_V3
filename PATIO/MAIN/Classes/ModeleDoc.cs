using System;
using System.Windows.Forms;

namespace PATIO.MAIN.Classes
{
    public class ModeleDoc : Classe_Modele, IComparable<ModeleDoc>
    {
        public Type_Modele Type_Modele { get; set; } //Type de modèle géré par Type_Element

        public string FichierBase { get; set; }
        public int Ordre { get; set; } = 1;
        public string Condition { get; set; }
        public string Contenu { get; set; }
        public int Taille { get; set; } = 100;
        public Alignement Alignement { get; set; } = Alignement.Gauche;
        public string Bordure { get; set; }

        public int Parent_ID { get; set; }

        public ModeleDoc()
        {
            ListeAttribut = new string[] {"FICHIERBASE", "ORDRE", "CONDITION", "CONTENU",
                                          "TAILLE", "ALIGNEMENT","BORDURE", "PARENT_ID",
                                         };
        }

        public override bool Construire(Element e)
        {
            ID = e.ID;
            Code = e.Code;
            Libelle = e.Libelle.Replace("''", "'");
            Element_Type = e.Element_Type;
            Actif = e.Actif;
            Type_Element = e.Type_Element;
            Type_Modele = (Type_Modele)Type_Element;

            foreach (dElement d in e.Liste)
            {
                if (d.Element_ID == ID)
                {
                    if (d.Attribut_Code == "PARENT_ID") { Parent_ID = int.Parse(d.Valeur); }
                    if (d.Attribut_Code == "FICHIERBASE") { FichierBase = d.Valeur; }
                    if (d.Attribut_Code == "ORDRE") { Ordre = int.Parse(d.Valeur); }
                    if (d.Attribut_Code == "CONDITION") { Condition = d.Valeur; }
                    if (d.Attribut_Code == "CONTENU") { Contenu = d.Valeur; }
                    if (d.Attribut_Code == "TAILLE") { try { Taille = int.Parse(d.Valeur); } catch { } }
                    if (d.Attribut_Code == "ALIGNEMENT") { Alignement = (Alignement)int.Parse(d.Valeur); }
                    if (d.Attribut_Code == "BORDURE") { Bordure = d.Valeur; }
                }
            }

            return true;
        }

        //Transforme un groupe sous la forme Element, dElement
        public override Element Déconstruire()
        {
            Element e = new Element();
            dElement d;
            TypeElement type = Acces.type_MODELEDOC;

            e.ID = ID;
            e.Element_Type = type.ID;
            e.Code = Code;
            e.Libelle = Libelle;
            e.Type_Element = (int)Type_Modele;
            e.Actif = Actif;

            string CodeAttribut = "";
            {
                CodeAttribut = "PARENT_ID";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, Parent_ID.ToString());
                e.Liste.Add(d);
            }
            {
                CodeAttribut = "FICHIERBASE";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, FichierBase);
                e.Liste.Add(d);
            }
            {
                CodeAttribut = "ORDRE";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, Ordre.ToString());
                e.Liste.Add(d);
            }
            {
                CodeAttribut = "CONDITION";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, Condition);
                e.Liste.Add(d);
            }
            {
                CodeAttribut = "CONTENU";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, Contenu);
                e.Liste.Add(d);
            }
            {
                CodeAttribut = "TAILLE";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, Taille.ToString());
                e.Liste.Add(d);
            }
            {
                CodeAttribut = "ALIGNEMENT";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut,((int)Alignement).ToString());
                e.Liste.Add(d);
            }
            {
                CodeAttribut = "BORDURE";
                d = new dElement(ID, Acces.Trouver_Attribut(type, CodeAttribut).ID, CodeAttribut, Bordure);
                e.Liste.Add(d);
            }
            return e;
        }

        //Comparateur par défaut
        public virtual int CompareTo(ModeleDoc p)
        {
             return 1; 
        }
    }
}
