using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PATIO.CAPA.Classes;
using PATIO.Modules;
using PATIO.CAPA.Interfaces;

namespace PATIO.CAPA.Interfaces
{
    public partial class ctrlCompare : UserControl
    {
        /// <summary>
        /// Définition des paramètres publics
        /// </summary>
        public AccesNet Acces;
        public TreeNode NodG;
        //public Plan plan;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;

        public ctrlConsole Console;
        public string Chemin;

        /// <summary>
        /// Définition des paramètres locaux
        /// </summary>
        List<Lien> listeLien;
        ctrlListeObjectif ctrllisteobjectif;
        ctrlListeAction ctrllisteaction;
        ctrlListeIndicateur ctrllisteindicateur;
        ctrlPlanCorrection ctrlplancorrection;

        List<Plan> ListePlan = new List<Plan>();
        int PosImageActionPhare;

        class Img
        {
            public int typeImg;
            public int ImgId;
            public int Id;
        }
        List<Img> imgs;

        public ctrlCompare()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Affichage des différents éléments composant l'interface de gestion d'un plan
        /// </summary>
        public void Afficher(Plan plan)
        {
            //Affichage des listes de droite
            Afficher_ListeObjectif();
            Afficher_ListeAction();
            Afficher_ListeIndicateur();

            //Affecte les icônes aux objets
            Creer_ListeImages(plan);

            //Repositionne les objets selon les liens établis
            //Afficher_Structure();
            ListePlan = (List<Plan>)Acces.Remplir_ListeElement(Acces.type_PLAN.id, "");

            Afficher_ListePlan(lstPlanSrc);
            Afficher_ListePlan(lstPlanDest);
        }

        void Afficher_ListePlan(ToolStripComboBox liste)
        {
            liste.Items.Clear();
            foreach(Plan p in ListePlan) { liste.Items.Add(p.Libelle); }
        }

        /// <summary>
        /// Importation des images des composants afin de permettre l'affichage les icones dans la structure
        /// </summary>
        void Creer_ListeImages(Plan plan)
        {
            int n, k;
            imageList1.Images.Clear();
            imgs = new List<Img>();

            //Image de sélection
            n = 0;
            k = 0;
            Img img = new Img();
            img.Id = n;
            img.ImgId = k;
            imgs.Add(img);
            imageList1.Images.Add(PATIO.Properties.Resources.suivant);

            //Image du plan
            n++;
            img = new Img();
            img.Id = n;
            img.ImgId = k;
            imgs.Add(img);
            imageList1.Images.Add(Inserer_ImagePlan(plan));

            //Objectif
            n++;
            k = 0;
            foreach (Image pict in ctrllisteobjectif.imageList1.Images)
            {
                if (!(pict == PATIO.Properties.Resources.suivant))
                {
                    img = new Img();
                    img.typeImg = Acces.type_OBJECTIF.id;
                    img.Id = n;
                    img.ImgId = k;
                    imgs.Add(img);
                    imageList1.Images.Add(pict);
                    k++; n++;
                }
            }

            //Action
            k = 0;
            foreach (Image pict in ctrllisteaction.imageList1.Images)
            {
                if (!(pict == PATIO.Properties.Resources.suivant))
                {
                    img = new Img();
                    img.typeImg = Acces.type_ACTION.id;
                    img.Id = n;
                    img.ImgId = k;
                    imgs.Add(img);
                    imageList1.Images.Add(pict);
                    k++; n++;
                }
            }

            //Indicateur
            k = 0;
            foreach (Image pict in ctrllisteindicateur.imageList1.Images)
            {
                if (!(pict == PATIO.Properties.Resources.suivant))
                {
                    img = new Img();
                    img.typeImg = Acces.type_INDICATEUR.id;
                    img.Id = n;
                    img.ImgId = k;
                    imgs.Add(img);
                    imageList1.Images.Add(pict);
                    k++; n++;
                }
            }

            //Cas de l'action phare
            Image picture = PATIO.Properties.Resources.btn_cercle_rouge;
            img = new Img();
            img.typeImg = Acces.type_ACTION.id;
            img.Id = n;
            img.ImgId = k;
            imgs.Add(img);
            imageList1.Images.Add(picture);
            PosImageActionPhare = n;
        }

        /// <summary>
        /// Affichage des éléments composant le plan
        /// </summary>
        void Afficher_Structure(ToolStripComboBox liste,  TreeView tree)
        {
            if(liste.SelectedIndex<0) { return; }

            Plan plan = ListePlan[liste.SelectedIndex];

            //Affichage de la structure actuelle du plan d'actions
            tree.Nodes.Clear();
            NodG = new TreeNode()
            {
                Text = "Plan d'actions de " + plan.NiveauPlan,
                Name = Acces.type_PLAN.code + "-" + plan.ID,
                ImageIndex = 1,
                Tag = Acces.type_PLAN.id,
            };

            NodG.Expand();

            //Place les objets selon les lien établis
            Repositionner(plan);

            tree.Nodes.Add(NodG);
        }

        /// <summary>
        /// Repositionne les éléments selon la hiérarchie définie
        /// </summary>
        void Repositionner(Plan plan)
        {
            int nbObjectif = 0; int nbAction = 0; int nbOpération = 0; int nbIndicateur = 0;

            //Placement des objectifs/sous-objectifs
            listeLien = Acces.Remplir_ListeLien(Acces.type_PLAN, plan.ID.ToString());
            listeLien.Sort();

            //On balaye la liste des éléments
            //On crée l'élément sous le parent
            foreach (var p in listeLien)
            {
                //Recherche du parent
                string Parent = Acces.Trouver_TableValeur(p.element1_type).Code + "-" + p.element1_id.ToString();
                TreeNode NodParent = NodG;

                if (!(Parent == NodG.Name))
                {
                    TreeNode[] NodP = NodG.Nodes.Find(Parent, true);
                    if (NodP.Length > 0) { NodParent = NodP[0]; }
                }

                string Enfant = Acces.Trouver_TableValeur(p.element2_type).Code + "-" + p.element2_id.ToString();
                if (!(Enfant is null))
                {
                    Boolean Ajoute = true;
                    //Création de l'élément enfant
                    TreeNode NodEnfant = new TreeNode()
                    {
                        Name = Enfant,
                        Tag = p,
                    };

                    if (p.element2_type == Acces.type_OBJECTIF.id)
                    //if (p.element2_type == Acces.Trouver_TableValeur_ID("TYPE_ELEMENT", p.element1_type.ToString()))
                    {
                        Objectif q = (Objectif)Acces.Trouver_Element(Acces.type_OBJECTIF.id, p.element2_id);
                        if (!(q is null))
                        {
                            NodEnfant.Text = q.Libelle;
                            NodEnfant.Name = Acces.type_OBJECTIF.code + "-" + q.ID;
                            NodEnfant.ImageIndex = Donner_ImageIndex(Acces.type_OBJECTIF.id, p.element2_id);
                            NodEnfant.ToolTipText = q.Code;
                            nbObjectif++;
                        }
                        else { Console.Ajouter("[Objectif non trouvé] ID:" + p.element2_id + " Code :" + p.element2_code); }
                    }

                    if (p.element2_type == Acces.type_ACTION.id)
                    {
                        PATIO.CAPA.Classes.Action q = (PATIO.CAPA.Classes.Action)Acces.Trouver_Element(Acces.type_ACTION.id, p.element2_id);
                        if (!(q is null))
                        {
                            NodEnfant.Text = q.Libelle;
                            NodEnfant.Name = Acces.type_ACTION.code + "-" + q.ID;
                            NodEnfant.ImageIndex = Donner_ImageIndex(Acces.type_ACTION.id, p.element2_id);
                            if (q.ActionPhare) { NodEnfant.ImageIndex = imgs[PosImageActionPhare].Id; }
                            NodEnfant.ToolTipText = q.Code + " [" + p.ordre + "]";
                            if (q.TypeAction == TypeAction.ACTION) { nbAction++; }
                            if (q.TypeAction == TypeAction.OPERATION) { nbOpération++; }
                        }
                        else { Console.Ajouter("[Action non trouvée] ID:" + p.element2_id + " CODE:" + p.element2_code); }
                    }

                    if (p.element2_type == Acces.type_INDICATEUR.id)
                    {
                        Indicateur q = (Indicateur)Acces.Trouver_Element(Acces.type_INDICATEUR.id, p.element2_id);
                        if (!(q is null))
                        {
                            NodEnfant.Text = q.Libelle;
                            NodEnfant.Name = Acces.type_INDICATEUR.code + "-" + q.ID;
                            NodEnfant.ImageIndex = Donner_ImageIndex(Acces.type_INDICATEUR.id, p.element2_id);
                            NodEnfant.ToolTipText = q.Code;
                            nbIndicateur++;
                        }
                        else { Console.Ajouter("[Indicateur non trouvée] ID:" + p.element2_id + " CODE:" + p.element2_code); }
                    }

                    if (Ajoute)
                    {
                        NodParent.Nodes.Add(NodEnfant);
                    }
                }
            }
        }

        /// <summary>
        /// Renvoie l'index des images correspondant au type et à l'id des éléments
        /// </summary>
        int Donner_ImageIndex(int Type, int Id)
        {
            int index = 0;

            if (Type == Acces.type_OBJECTIF.id)
            {
                TreeNode[] lst = ctrllisteobjectif.lstObjectif.Nodes.Find(Id.ToString(), true);
                if (lst.Length > 0)
                {
                    index = lst[0].ImageIndex;
                }

                //Recherche de la positiondans la liste des images
                for (int i = 0; i < imgs.Count; i++)
                {
                    if ((imgs[i].typeImg == Type) && (imgs[i].ImgId == index))
                    {
                        return imgs[i].Id;
                    }
                }

            }

            if (Type == Acces.type_ACTION.id)
            {
                TreeNode[] lst = ctrllisteaction.lstAction.Nodes.Find(Id.ToString(), true);
                if (lst.Length > 0)
                {
                    index = lst[0].ImageIndex;
                }

                //Recherche de la position dans la liste des images
                for (int i = 0; i < imgs.Count; i++)
                {
                    if ((imgs[i].typeImg == Type) && (imgs[i].ImgId == index))
                    {
                        return imgs[i].Id;
                    }
                }

            }

            if (Type == Acces.type_INDICATEUR.id)
            {
                TreeNode[] lst = ctrllisteindicateur.lstIndicateur.Nodes.Find(Id.ToString(), true);
                if (lst.Length > 0)
                {
                    index = lst[0].ImageIndex;
                }

                //Recherche de la positiondans la liste des images
                for (int i = 0; i < imgs.Count; i++)
                {
                    if ((imgs[i].typeImg == Type) && (imgs[i].ImgId == index))
                    {
                        return imgs[i].Id;
                    }
                }

            }

            return 0;
        }

        /// <summary>
        /// Affiche la liste des objectifs pouvant être associés au plan
        /// </summary>
        private void Afficher_ListeObjectif()
        {
            ctrllisteobjectif = new ctrlListeObjectif();

            ctrllisteobjectif.Acces = Acces;
            ctrllisteobjectif.DP = DP;
            ctrllisteobjectif.Console = Console;
            ctrllisteobjectif.InterfaceGestion = false;
            ctrllisteobjectif.Checked = true;

            ctrllisteobjectif.Afficher_ListeObjectif();

            ctrllisteobjectif.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Affiche la liste des actions pouvant être associées au plan
        /// </summary>
        private void Afficher_ListeAction()
        {
            ctrllisteaction = new ctrlListeAction();

            ctrllisteaction.Acces = Acces;
            ctrllisteaction.DP = DP;
            ctrllisteaction.Console = Console;
            ctrllisteaction.Checked = true;
            ctrllisteaction.Afficher_ListeAction();
            ctrllisteaction.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Affiche la liste des indicateurs pouvant être associés au plan
        /// </summary>
        private void Afficher_ListeIndicateur()
        {
            ctrllisteindicateur = new ctrlListeIndicateur();

            ctrllisteindicateur.Acces = Acces;
            ctrllisteindicateur.DP = DP;
            ctrllisteindicateur.Console = Console;
            ctrllisteindicateur.Checked = true;

            ctrllisteindicateur.Afficher_ListeIndicateur();

            ctrllisteindicateur.Dock = DockStyle.Fill;

        }

        /// <summary>
        /// Ajoute les images correspondant aux différents types de plans
        /// </summary>
        Image Inserer_ImagePlan(Plan plan)
        {
            if (plan.TypePlan == TypePlan.DOSSIER) { return PATIO.Properties.Resources.dossier_plus; }        //Dossier
            if (plan.TypePlan == TypePlan.NATIONAL) { return PATIO.Properties.Resources.btn_carre_bleu; }     //National
            if (plan.TypePlan == TypePlan.REGIONAL) { return PATIO.Properties.Resources.btn_carre_vert; }     //Régional
            if (plan.TypePlan == TypePlan.TERRITORIAL) { return PATIO.Properties.Resources.btn_carre_jaune; } //Territorial
            if (plan.TypePlan == TypePlan.LOCAL) { return PATIO.Properties.Resources.btn_carre_orange; }      //Local
            if (plan.TypePlan == TypePlan.TRANSVERSE) { return PATIO.Properties.Resources.btn_carre_rouge; }  //Transverse
            return null;
        }

        private void lstPlanSrc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Afficher_Structure(lstPlanSrc, treeSrc);
        }

        private void lstPlanDest_SelectedIndexChanged(object sender, EventArgs e)
        {
            Afficher_Structure(lstPlanDest, treeDest);
        }
    }
}
