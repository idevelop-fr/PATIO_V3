using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PATIO.CAPA.Classes;
using PATIO.CAPA.Interfaces;
using PATIO.MAIN.Classes;

namespace PATIO.CAPA.Interfaces
{
    public partial class ctrlPlan : UserControl
    {
        /// <summary>
        /// Définition des paramètres publics
        /// </summary>
        public AccesNet Acces;
        public TreeNode NodG;
        public Plan plan;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;

        public ctrlConsole Console;
        public string Chemin;

        /// <summary>
        /// Définition des paramètres locaux
        /// </summary>
        List<Lien> listeLien;
        ctrlListePlan ctrllisteplan = new ctrlListePlan();
        ctrlListeObjectif ctrllisteobjectif;
        ctrlListeAction ctrllisteaction;
        ctrlListeIndicateur ctrllisteindicateur;
        ctrlPlanCorrection ctrlplancorrection;

        List<int> ListeElementCocher;
        int PosImageActionPhare;

        class Img
        {
            public int typeImg;
            public int ImgId;
            public int Id;
        }
        List<Img> imgs;

        /// <summary>
        /// Procédure d'initialisation standard du composant
        /// </summary>
        public ctrlPlan()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Affichage des différents éléments composant l'interface de gestion d'un plan
        /// </summary>
        public void Afficher()
        {
            plan = (Plan)Acces.Trouver_Element(Acces.type_PLAN, plan.ID);
            //Affichage des listes de droite
            Afficher_ListeObjectif();
            Afficher_ListeAction();
            Afficher_ListeIndicateur();
            Afficher_Correction();

            //Affecte les icônes aux objets
            Creer_ListeImages();

            //Repositionne les objets selon les liens établis
            Afficher_Structure();
        }

        /// <summary>
        /// Affichage du module permettant les corrections
        /// </summary>
        void Afficher_Correction()
        {
            ctrlplancorrection = new ctrlPlanCorrection();
            ctrlplancorrection.Acces = Acces;
            ctrlplancorrection.DP = DP;
            ctrlplancorrection.Console = Console;
            ctrlplancorrection.Chemin = Chemin;
            ctrlplancorrection.Initialiser();
            ctrlplancorrection.Dock = DockStyle.Fill;

            tabCorrection.Controls.Add(ctrlplancorrection);
        }

        /// <summary>
        /// Affichage des éléments composant le plan
        /// </summary>
        void Afficher_Structure()
        {
            //Affichage du libellé du plan
            lblLibellePlan.Text = plan.Libelle;
            lblNbObjectif.Text = "Objectifs : ";
            lblNbAction.Text = "Actions : ";
            lblNbOpération.Text = "Opérations : ";
            lblNbIndicateur.Text = "Indicateurs : ";

            //Affichage de la structure actuelle du plan d'actions
            treeStructure.Nodes.Clear();
            NodG = new TreeNode()
            {
                Text = "Plan d'actions de " + plan.NiveauPlan,
                Name = Acces.type_PLAN.Code + "-" + plan.ID,
                ImageIndex = 1,
                Tag = Acces.type_PLAN,
            };

            NodG.Expand();

            //Place les objets selon les lien établis
            Repositionner();

            treeStructure.Nodes.Add(NodG);
        }

        /// <summary>
        /// Repositionne les éléments selon la hiérarchie définie
        /// </summary>
        void Repositionner()
        {
            //Placement des objectifs/sous-objectifs
            listeLien = Acces.Remplir_ListeLien_Niv0(Acces.type_PLAN, plan.ID.ToString());
            listeLien.Sort();

            //On balaye la liste des éléments
            //On crée l'élément sous le parent
            foreach (var p in listeLien)
            {
                //Recherche du parent
                string Parent = Acces.Trouver_TableValeur(p.Element1_Type).Code + "-" + p.Element1_ID.ToString();
                TreeNode NodParent = NodG;

                if (!(Parent == NodG.Name))
                {
                    TreeNode[] NodP = NodG.Nodes.Find(Parent, true);
                    if (NodP.Length > 0) { NodParent = NodP[0]; }
                }

                string Enfant = Acces.Trouver_TableValeur(p.Element2_Type).Code + "-" + p.Element2_ID.ToString();
                if (!(Enfant is null))
                {
                    Boolean Ajoute = true;
                    //Création de l'élément enfant
                    TreeNode NodEnfant = new TreeNode()
                    {
                        Name = Enfant,
                        Tag = p,
                    };

                    if (p.Element2_Type == Acces.type_OBJECTIF.ID)
                    //if (p.Element2_Type == Acces.Trouver_TableValeur_ID("TYPE_ELEMENT", p.Element1_Type.ToString()))
                    {
                        Objectif q = (Objectif)Acces.Trouver_Element(Acces.type_OBJECTIF, p.Element2_ID);
                        if (!(q is null))
                        {
                            NodEnfant.Text = q.Libelle;
                            NodEnfant.Name = Acces.type_OBJECTIF.Code + "-" + q.ID;
                            NodEnfant.ImageIndex = Donner_ImageIndex(Acces.type_OBJECTIF, p.Element2_ID);
                            NodEnfant.ToolTipText = q.Code;
                        }
                        else { Console.Ajouter("[Objectif non trouvé] ID:" + p.Element2_ID + " Code :" + p.Element2_Code); }
                    }

                    if (p.Element2_Type == Acces.type_ACTION.ID)
                    {
                        PATIO.CAPA.Classes.Action q = (PATIO.CAPA.Classes.Action)Acces.Trouver_Element(Acces.type_ACTION, p.Element2_ID);
                        if (!OptAfficherOpération.Checked) { Ajoute = (q.TypeAction == TypeAction.ACTION); }
                        if (!(q is null))
                        {
                            NodEnfant.Text = q.Libelle;
                            NodEnfant.Name = Acces.type_ACTION.Code + "-" + q.ID;
                            NodEnfant.ImageIndex = Donner_ImageIndex(Acces.type_ACTION, p.Element2_ID);
                            if (q.ActionPhare) { NodEnfant.ImageIndex = imgs[PosImageActionPhare].Id; }
                            NodEnfant.ToolTipText = q.Code + " [" + p.ordre + "]";
                        }
                        else { Console.Ajouter("[Action non trouvée] ID:" + p.Element2_ID + " CODE:" + p.Element2_Code); }
                    }

                    if (p.Element2_Type == Acces.type_INDICATEUR.ID)
                    {
                        Ajoute = OptAfficherIndicateur.Checked;
                        Indicateur q = (Indicateur)Acces.Trouver_Element(Acces.type_INDICATEUR, p.Element2_ID);
                        if (!(q is null))
                        {
                            NodEnfant.Text = q.Libelle;
                            NodEnfant.Name = Acces.type_INDICATEUR.Code + "-" + q.ID;
                            NodEnfant.ImageIndex = Donner_ImageIndex(Acces.type_INDICATEUR, p.Element2_ID);
                            NodEnfant.ToolTipText = q.Code;
                        }
                        else { Console.Ajouter("[Indicateur non trouvée] ID:" + p.Element2_ID + " CODE:" + p.Element2_Code); }
                    }

                    if (Ajoute)
                    {
                        NodParent.Nodes.Add(NodEnfant);
                    }
                }
            }
            if (btnEtendre.Checked) { NodG.ExpandAll(); }

            Afficher_Stat();
        }

        void Afficher_Stat()
        {
            int nbObjectif = 0; int nbAction = 0; int nbOpération = 0; int nbIndicateur = 0;

            listeLien = Acces.Remplir_ListeLien_Niv0(Acces.type_PLAN, plan.ID.ToString());

            foreach(Lien p in listeLien)
            {
                string Parent = Acces.Trouver_TableValeur(p.Element1_Type).Code + "-" + p.Element1_ID.ToString();
                string Enfant = Acces.Trouver_TableValeur(p.Element2_Type).Code + "-" + p.Element2_ID.ToString();
                if (!(Enfant is null))
                {
                    Boolean Ajoute = true;
                    //Création de l'élément enfant

                    if (p.Element2_Type == Acces.type_OBJECTIF.ID)
                    //if (p.Element2_Type == Acces.Trouver_TableValeur_ID("TYPE_ELEMENT", p.Element1_Type.ToString()))
                    {
                        Objectif q = (Objectif)Acces.Trouver_Element(Acces.type_OBJECTIF, p.Element2_ID);
                        if (!(q is null))
                        {
                            nbObjectif++;
                        }
                        else { Console.Ajouter("[Objectif non trouvé] ID:" + p.Element2_ID + " Code :" + p.Element2_Code); }
                    }

                    if (p.Element2_Type == Acces.type_ACTION.ID)
                    {
                        PATIO.CAPA.Classes.Action q = (PATIO.CAPA.Classes.Action)Acces.Trouver_Element(Acces.type_ACTION, p.Element2_ID);
                        if (!OptAfficherOpération.Checked) { Ajoute = (q.TypeAction == TypeAction.ACTION); }
                        if (!(q is null))
                        {
                            if (q.TypeAction == TypeAction.ACTION) { nbAction++; }
                            if (q.TypeAction == TypeAction.OPERATION) { nbOpération++; }
                        }
                        else { Console.Ajouter("[Action non trouvée] ID:" + p.Element2_ID + " CODE:" + p.Element2_Code); }
                    }

                    if (p.Element2_Type == Acces.type_INDICATEUR.ID)
                    {
                        Ajoute = OptAfficherIndicateur.Checked;
                        Indicateur q = (Indicateur)Acces.Trouver_Element(Acces.type_INDICATEUR, p.Element2_ID);
                        if (!(q is null))
                        {
                            nbIndicateur++;
                        }
                        else { Console.Ajouter("[Indicateur non trouvée] ID:" + p.Element2_ID + " CODE:" + p.Element2_Code); }
                    }
                }
            }

            lblNbObjectif.Text = "Objectifs : " + nbObjectif.ToString();
            lblNbAction.Text = "Actions : " + nbAction.ToString();
            lblNbOpération.Text = "Opérations : " + nbOpération.ToString();
            lblNbIndicateur.Text = "Indicateurs : " + nbIndicateur.ToString();
        }

        /// <summary>
        /// Importation des images des composants afin de permettre l'affichage les icones dans la structure
        /// </summary>
        void Creer_ListeImages()
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
            imageList1.Images.Add(PATIO.Properties.Resources.fleche_droite_vert);

            //Image du plan
            n++;
            img = new Img();
            img.Id = n;
            img.ImgId = k;
            imgs.Add(img);
            imageList1.Images.Add(Inserer_ImagePlan());

            //Objectif
            n++;
            k = 0;
            foreach (Image pict in ctrllisteobjectif.imageList1.Images)
            {
                if (!(pict == PATIO.Properties.Resources.fleche_droite_vert))
                {
                    img = new Img();
                    img.typeImg = Acces.type_OBJECTIF.ID;
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
                if (!(pict == PATIO.Properties.Resources.fleche_droite_vert))
                {
                    img = new Img();
                    img.typeImg = Acces.type_ACTION.ID;
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
                if (!(pict == PATIO.Properties.Resources.fleche_droite_vert))
                {
                    img = new Img();
                    img.typeImg = Acces.type_INDICATEUR.ID;
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
            img.typeImg = Acces.type_ACTION.ID;
            img.Id = n;
            img.ImgId = k;
            imgs.Add(img);
            imageList1.Images.Add(picture);
            PosImageActionPhare = n;
        }

        /// <summary>
        /// Renvoie l'index des images correspondant au type et à l'id des éléments
        /// </summary>
        int Donner_ImageIndex(TypeElement Type, int Id)
        {
            int index = 0;

            if (Type == Acces.type_OBJECTIF)
            {
                TreeNode[] lst = ctrllisteobjectif.lstObjectif.Nodes.Find(Id.ToString(), true);
                if (lst.Length > 0)
                {
                    index = lst[0].ImageIndex;
                }

                //Recherche de la positiondans la liste des images
                for (int i = 0; i < imgs.Count; i++)
                {
                    if ((imgs[i].typeImg == Type.ID) && (imgs[i].ImgId == index))
                    {
                        return imgs[i].Id;
                    }
                }

            }

            if (Type == Acces.type_ACTION)
            {
                TreeNode[] lst = ctrllisteaction.lstAction.Nodes.Find(Id.ToString(), true);
                if (lst.Length > 0)
                {
                    index = lst[0].ImageIndex;
                }

                //Recherche de la position dans la liste des images
                for (int i = 0; i < imgs.Count; i++)
                {
                    if ((imgs[i].typeImg == Type.ID) && (imgs[i].ImgId == index))
                    {
                        return imgs[i].Id;
                    }
                }

            }

            if (Type == Acces.type_INDICATEUR)
            {
                TreeNode[] lst = ctrllisteindicateur.lstIndicateur.Nodes.Find(Id.ToString(), true);
                if (lst.Length > 0)
                {
                    index = lst[0].ImageIndex;
                }

                //Recherche de la positiondans la liste des images
                for (int i = 0; i < imgs.Count; i++)
                {
                    if ((imgs[i].typeImg == Type.ID) && (imgs[i].ImgId == index))
                    {
                        return imgs[i].Id;
                    }
                }

            }

            return 0;
        }

        /// <summary>
        /// Ajoute les images correspondant aux différents types de plans
        /// </summary>
        Image Inserer_ImagePlan()
        {
            if (plan.TypePlan == TypePlan.DOSSIER) { return PATIO.Properties.Resources.dossier_plus; }        //Dossier
            if (plan.TypePlan == TypePlan.NATIONAL) { return PATIO.Properties.Resources.btn_carre_bleu; }     //National
            if (plan.TypePlan == TypePlan.REGIONAL) { return PATIO.Properties.Resources.btn_carre_vert; }     //Régional
            if (plan.TypePlan == TypePlan.TERRITORIAL) { return PATIO.Properties.Resources.btn_carre_jaune; } //Territorial
            if (plan.TypePlan == TypePlan.LOCAL) { return PATIO.Properties.Resources.btn_carre_orange; }      //Local
            if (plan.TypePlan == TypePlan.TRANSVERSE) { return PATIO.Properties.Resources.btn_carre_rouge; }  //Transverse
            return null;
        }

        /// <summary>
        /// Affiche la liste des objectifs pouvant être associés au plan
        /// </summary>
        private void Afficher_ListeObjectif()
        {
            tabObjectif.Controls.Clear();

            ctrllisteobjectif = new ctrlListeObjectif();

            ctrllisteobjectif.Acces = Acces;
            ctrllisteobjectif.DP = DP;
            ctrllisteobjectif.Console = Console;
            ctrllisteobjectif.plan = plan;
            ctrllisteobjectif.InterfaceGestion = false;
            ctrllisteobjectif.Checked = true;
            ctrllisteobjectif.lblRecherche.Text = plan.Abrege.ToUpper();
            ctrllisteobjectif.EVT_Modifier += Handler_evt_Modifier_Objectif;

            ctrllisteobjectif.Afficher_ListeObjectif();

            ctrllisteobjectif.Dock = DockStyle.Fill;

            tabObjectif.Controls.Add(ctrllisteobjectif);
        }

        /// <summary>
        /// Affiche la liste des actions pouvant être associées au plan
        /// </summary>
        private void Afficher_ListeAction()
        {
            tabAction.Controls.Clear();

            ctrllisteaction = new ctrlListeAction();

            ctrllisteaction.Acces = Acces;
            ctrllisteaction.DP = DP;
            ctrllisteaction.Console = Console;
            ctrllisteaction.CodeRef = plan.Abrege;
            ctrllisteaction.Checked = true;
            ctrllisteaction.lblRecherche.Text = plan.Abrege.ToUpper();
            ctrllisteaction.Afficher_ListeAction();
            ctrllisteaction.EVT_Modifier += Handler_evt_Modifier_Action;
            ctrllisteaction.Dock = DockStyle.Fill;
            ctrllisteaction.plan = plan;

            tabAction.Controls.Add(ctrllisteaction);

        }

        /// <summary>
        /// Affiche la liste des indicateurs pouvant être associés au plan
        /// </summary>
        private void Afficher_ListeIndicateur()
        {
            tabIndicateur.Controls.Clear();

            ctrllisteindicateur = new ctrlListeIndicateur();

            ctrllisteindicateur.Acces = Acces;
            ctrllisteindicateur.DP = DP;
            ctrllisteindicateur.Console = Console;
            ctrllisteindicateur.Checked = true;

            ctrllisteindicateur.Afficher_ListeIndicateur();

            ctrllisteindicateur.Dock = DockStyle.Fill;

            tabIndicateur.Controls.Add(ctrllisteindicateur);

        }

        /// <summary>
        /// Procédure déclenchée par clic permettant d'associer un élément au plan
        /// </summary>
        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            Ajouter_Lien();
        }

        /// <summary>
        /// Ajout d'un élément au plan
        /// Création d'un lien 
        /// </summary>
        void Ajouter_Lien()
        {
            if (treeStructure.SelectedNode is null) { MessageBox.Show("Sélectionner un objet dans la structure"); return; }

            TreeNode NodParent = treeStructure.SelectedNode;

            Console.Ajouter("[AJOUT LIEN]");
            //Détermine les informations du noeud réceptable
            int ElementParentId = int.Parse(NodParent.Name.ToString().Split('-')[1]);
            string ElementParentTypeSrc = NodParent.Name.ToString().Split('-')[0];
            string ElementParentCode = "";
            int ElementParentType_id = 0;

            //Recherche du code du noeud de destination
            if (ElementParentTypeSrc == Acces.type_PLAN.Code)
            {
                ElementParentCode = ((Plan)Acces.Trouver_Element(Acces.type_PLAN, ElementParentId)).Code;
                ElementParentType_id = Acces.type_PLAN.ID;
            }
            if (ElementParentTypeSrc == Acces.type_OBJECTIF.Code)
            {
                ElementParentCode = ((Objectif)Acces.Trouver_Element(Acces.type_OBJECTIF, ElementParentId)).Code;
                ElementParentType_id = Acces.type_OBJECTIF.ID;
            }
            if (ElementParentTypeSrc == Acces.type_ACTION.Code)
            {
                ElementParentCode = ((PATIO.CAPA.Classes.Action)Acces.Trouver_Element(Acces.type_ACTION, ElementParentId)).Code;
                ElementParentType_id = Acces.type_ACTION.ID;
            }
            if (ElementParentTypeSrc == Acces.type_INDICATEUR.Code)
            {
                ElementParentCode = ((Indicateur)Acces.Trouver_Element(Acces.type_INDICATEUR, ElementParentId)).Code;
                ElementParentType_id = Acces.type_INDICATEUR.ID;
            }

            Console.Ajouter("Destination : Id= " + ElementParentId + ", Code= " + ElementParentCode);

            int ElementEnfantId = 0;
            string ElementEnfantCode;
            string ElementEnfantType;

            Lien l;
            //Selon l'onglet d'origine, le nouveau élément est créé
            switch (tabControl1.SelectedIndex)
            {
                case 0: //Objectif
                    ctrllisteobjectif.Trouver_Selection(); //Active la recherche des éléments cochés

                    foreach (Objectif obj in ctrllisteobjectif.lObj) //Pour chaque élément coché
                    {
                        //Informations sur l'élément à lier
                        ElementEnfantId = obj.ID;
                        ElementEnfantCode = obj.Code;
                        ElementEnfantType = Acces.type_OBJECTIF.Code;
                        Console.Ajouter("Origine Objectif : Id= " + ElementEnfantId.ToString());
                        //Vérification de la non-existence du même lien
                        if (Acces.Existe_Lien(Acces.type_PLAN, plan.ID, ElementParentId, ElementEnfantId))
                        { MessageBox.Show("L'objectif " + obj.Code + " est déjà associé au noeud sélectionné"); goto Suite_Obj; }
                        //Création du lien entre l'élément à lier et le noeud de destination

                        l = new Lien()
                        {
                            Element0_Type = Acces.type_PLAN.ID,
                            Element0_ID = plan.ID,
                            Element0_Code = plan.Code,
                            Element1_Type = Acces.Trouver_TableValeur_Code("TYPE_ELEMENT", ElementParentTypeSrc).ID,
                            Element1_ID = ElementParentId,
                            Element1_Code = ElementParentCode,
                            Element2_Type = Acces.Trouver_TableValeur_Code("TYPE_ELEMENT", ElementEnfantType).ID,
                            Element2_ID = ElementEnfantId,
                            Element2_Code = ElementEnfantCode,
                            complement = "",
                            Acces = Acces,
                        };

                        l.ordre = l.Donner_Ordre() + 1;
                        Console.Ajouter("Ordre lien= " + l.ordre.ToString());

                        l.Ajouter();
                        Acces.Ajouter_Lien(l);
                        listeLien.Add(l);

                        //Ajout du noeud à la structure
                        TreeNode Nd = new TreeNode()
                        {
                            Text = obj.Libelle,
                            Name = Acces.type_OBJECTIF.Code + "-" + obj.ID.ToString(),
                            ImageIndex = Donner_ImageIndex(Acces.type_OBJECTIF, obj.ID),
                            ToolTipText = obj.Code,
                            Tag = l,
                        };
                        NodParent.Nodes.Add(Nd);
                        Nd.EnsureVisible();

                        goto Fin_Obj;

                        Suite_Obj: Console.Ajouter("Objectif déjà lié");
                        Fin_Obj:;
                    }
                    break;

                case 1: //Action
                    ctrllisteaction.Trouver_Selection();
                    foreach (PATIO.CAPA.Classes.Action action in ctrllisteaction.lAction)
                    {
                        ElementEnfantId = action.ID;
                        ElementEnfantCode = action.Code;
                        //ElementEnfantType = Acces.type_ACTION;
                        Console.Ajouter("Origine Action : Id= " + ElementEnfantId.ToString());
                        //Vérification de la non-existence du même lien
                        if (Acces.Existe_Lien(Acces.type_PLAN, plan.ID, ElementParentId, ElementEnfantId))
                        { MessageBox.Show("L'action " + action.Code + " est déjà associé au noeud sélectionné"); goto Suite_Action; }
                        //Création du lien entre l'élément à lier et le noeud de destination
                        l = new Lien()
                        {
                            Element0_Type = Acces.type_PLAN.ID,
                            Element0_ID = plan.ID,
                            Element0_Code = plan.Code,
                            Element1_Type = ElementParentType_id,
                            Element1_ID = ElementParentId,
                            Element1_Code = ElementParentCode,
                            Element2_Type = Acces.type_ACTION.ID,
                            Element2_ID = ElementEnfantId,
                            Element2_Code = ElementEnfantCode,
                            Acces = Acces,
                        };
                        l.ordre = l.Donner_Ordre() + 1;
                        Console.Ajouter("Ordre lien= " + l.ordre.ToString());
                        l.Ajouter();
                        Acces.Ajouter_Lien(l);
                        listeLien.Add(l);

                        //Ajout du noeud à la structure
                        TreeNode Nd = new TreeNode()
                        {
                            Text = action.Libelle,
                            Name = Acces.type_ACTION.Code + "-" + action.ID.ToString(),
                            ImageIndex = Donner_ImageIndex(Acces.type_ACTION, action.ID),
                            ToolTipText = action.Code,
                            Tag = l,
                        };
                        if (action.ActionPhare) { Nd.ImageIndex = imgs[PosImageActionPhare].Id; }

                        NodParent.Nodes.Add(Nd);
                        Nd.EnsureVisible();

                        goto Fin_Action;

                        Suite_Action: Console.Ajouter("Action déjà lié");
                        Fin_Action:;
                    }
                    break;

                case 2: //Indicateur
                    ctrllisteindicateur.Trouver_Selection();
                    foreach (Indicateur indic in ctrllisteindicateur.lIndicateur)
                    {
                        ElementEnfantId = indic.ID;
                        ElementEnfantCode = indic.Code;
                        //ElementEnfantType = Acces.type_INDICATEUR;
                        Console.Ajouter("Origine Indicateur : Id= " + ElementEnfantId.ToString());
                        //Vérification de la non-existence du même lien
                        if (Acces.Existe_Lien(Acces.type_PLAN, plan.ID, ElementParentId, ElementEnfantId))
                        { MessageBox.Show("L'indicateur " + indic.Code + " est déjà associé au noeud sélectionné"); goto Suite_Indicateur; }
                        //Création du lien entre l'élément à lier et le noeud de destination
                        l = new Lien()
                        {
                            Element0_Type = Acces.type_PLAN.ID,
                            Element0_ID = plan.ID,
                            Element0_Code = plan.Code,
                            Element1_Type = ElementParentType_id,
                            Element1_ID = ElementParentId,
                            Element1_Code = ElementParentCode,
                            Element2_Type = Acces.type_INDICATEUR.ID,
                            Element2_ID = ElementEnfantId,
                            Element2_Code = ElementEnfantCode,
                            Acces = Acces,
                        };
                        l.ordre = l.Donner_Ordre() + 1;
                        Console.Ajouter("Ordre lien= " + l.ordre.ToString());
                        l.Ajouter();
                        Acces.Ajouter_Lien(l);
                        listeLien.Add(l);

                        //Ajout du noeud à la structure
                        TreeNode Nd = new TreeNode()
                        {
                            Text = indic.Libelle,
                            Name = Acces.type_INDICATEUR.Code + "-" + indic.ID.ToString(),
                            ImageIndex = Donner_ImageIndex(Acces.type_INDICATEUR, indic.ID),
                            ToolTipText = indic.Code,
                            Tag = l,
                        };
                        NodParent.Nodes.Add(Nd);
                        Nd.EnsureVisible();

                        goto Fin_indicateur;

                        Suite_Indicateur: Console.Ajouter("Indicateur déjà liée");
                        Fin_indicateur:;
                    }
                    break;
            }
            Console.Ajouter("[AJOUT Lien FIN]");

            //Afficher_Structure();

            TreeNode[] Nod = treeStructure.Nodes.Find(NodParent.Name, true);
            if (Nod.Length > 0) { treeStructure.SelectedNode = Nod[0]; Nod[0].EnsureVisible(); Nod[0].ExpandAll(); }

            Afficher_Stat();
        }

        /// <summary>
        /// Procédure déclenchée par clic permettant de supprimer un élément au plan
        /// </summary>
        private void BtnEnlever_Click(object sender, EventArgs e)
        {
            Enlever_Lien();
        }

        /// <summary>
        /// Suppression d'un élément au plan
        /// </summary>
        void Enlever_Lien()
        {
            if (treeStructure.SelectedNode is null) { return; }

            TreeNode Nod = treeStructure.SelectedNode;

            if (Nod.Nodes.Count > 0) //Un noeud ne peut pas être supprimé s'il a des enfants
            {
                MessageBox.Show("Impossible de supprimer un noeud ayant des fils", "Erreur");
                return;
            }

            Lien l = (Lien)treeStructure.SelectedNode.Tag;
            l.Acces = Acces;
            l.Supprimer();
            Acces.Supprimer_Lien(l);
            listeLien.Remove(l);
            treeStructure.Nodes.Remove(Nod);
            Afficher_Stat();
        }

        /// <summary>
        /// Procédure déclenchée par clic permettant l'actualisation de l'affichage du plan
        /// </summary>
        private void BtnActualiser_Click(object sender, EventArgs e)
        {
            Afficher();
        }

        /// <summary>
        /// Procédure déclenchée par clic permettant de remonter un élément dans la hiérarchie
        /// </summary>
        private void BtnMonter_Click(object sender, EventArgs e)
        {
            Monter();
        }

        /// <summary>
        /// Remonte un élément sélectionné dans la hiérarchie du plan
        /// </summary>
        void Monter()
        {
            if (treeStructure.SelectedNode is null) { return; } //Aucune sélection
            TreeNode Nod = treeStructure.SelectedNode;
            TreeNode NodDest = null;
            var Parent = treeStructure.SelectedNode.Parent;

            if (Parent.Nodes.Count == 1) { return; }            //Le nombre d'éléments sur le niveau sélectionné = 1

            var typeElement = Nod.Name.Split('-')[0];          //Détermine le type de l'élément sélectionné
            var n = 0;
            var ok = false;
            //Détermine le nombre d'éléments du type sélectionné
            foreach (TreeNode nod in Parent.Nodes)
            {
                if (nod.Name.Split('-')[0] == typeElement)
                {
                    n++;
                    if (nod == Nod)
                    {
                        ok = true;
                    }
                    else
                    {
                        if (!ok) { NodDest = nod; }
                    }
                }
            }
            if (n == 1) { return; }                             //Le nombre d'éléments du type sélectionné est = 1
                                                                //Inutile de monter
            if (NodDest is null) { return; }

            var typeElementParent = Parent.Name.Split('-')[0];          //Détermine le type de l'élément parent
            var idElementParent = Parent.Name.Split('-')[1];               //Détermine l'ID du parent

            var idElement = Nod.Name.Split('-')[1];                        //Détermine l'ID de l'élément sélectionné

            var typeElementDest = NodDest.Name.Split('-')[0];           //Détermine le type de l'élément de destination
            var idElementDest = NodDest.Name.Split('-')[1];                //Détermine l'ID de l'élément de destination

            var NodIndex = Nod.Index;
            var NodDestIndex = NodDest.Index;

            //Recherche des liens : référence
            Lien lien = new Lien() { Acces = Acces, };
            Lien lienDest = new Lien() { Acces = Acces, };

            int Element1_Type_id = Acces.Trouver_TableValeur_Code("TYPE_ELEMENT", typeElementParent).ID;
            int Element2_Type_id = Acces.Trouver_TableValeur_Code("TYPE_ELEMENT", typeElementDest).ID;

            foreach (var lst in listeLien)
            {
                //Recherche le lien 
                if (lst.Element2_ID == int.Parse(idElementDest)
                    && lst.Element2_Type == Element2_Type_id
                    && lst.Element1_ID == int.Parse(idElementParent)
                    && lst.Element1_Type == Element1_Type_id)
                {
                    lienDest = lst;
                }
                if (lst.Element2_ID == int.Parse(idElement)
                    && lst.Element2_Type == Element2_Type_id
                    && lst.Element1_ID == int.Parse(idElementParent)
                    && lst.Element1_Type == Element1_Type_id)
                {
                    lien = lst;
                }
            }

            var ordre = lien.ordre;
            var ordreDest = lienDest.ordre;

            //Correction éventuelle
            if (ordreDest == ordre) { ordreDest = ordre - 1; }

            lienDest.ordre = ordre;
            lien.ordre = ordreDest;

            lien.Acces = Acces;
            lienDest.Acces = Acces;

            lien.MettreAJour();
            lienDest.MettreAJour();

            Afficher_Structure();

            TreeNode[] nd = treeStructure.Nodes.Find(Nod.Name, true);
            treeStructure.SelectedNode = nd[0];
            nd[0].EnsureVisible();
        }

        /// <summary>
        /// Procédure déclenchée par clic permettant de descendre un élément dans la hiérarchie
        /// </summary>
        private void BtnDescendre_Click(object sender, EventArgs e)
        {
            Descendre();
        }

        /// <summary>
        /// Descend un élément sélectionné dans la hiérarchie du plan
        /// </summary>
        void Descendre()
        {
            if (treeStructure.SelectedNode is null) { return; } //Aucune sélection
            TreeNode Nod = treeStructure.SelectedNode;
            TreeNode NodDest = null;
            var Parent = treeStructure.SelectedNode.Parent;

            if (Parent.Nodes.Count == 1) { return; }            //Le nombre d'éléments sur le niveau sélectionné = 1

            var typeElement = Nod.Name.Split('-')[0];          //Détermine le type de l'élément sélectionné
            var n = 0;
            var ok = false;
            //Détermine le nombre d'éléments du type sélectionné
            foreach (TreeNode nod in Parent.Nodes)
            {
                if (nod.Name.Split('-')[0] == typeElement)
                {
                    n++;
                    if (nod == Nod)
                    {
                        ok = true;
                    }
                    else
                    {
                        if (ok)
                        {
                            NodDest = nod;
                            ok = false;
                        }
                    }
                }
            }
            if (n == 1) { return; }                             //Le nombre d'éléments du type sélectionné est = 1
            if (NodDest is null) { return; }

            var typeElementParent = Parent.Name.Split('-')[0];          //Détermine le type de l'élément parent
            var idElementParent = Parent.Name.Split('-')[1];            //Détermine l'ID du parent
            var idElement = Nod.Name.Split('-')[1];                     //Détermine l'ID de l'élément sélectionné
            var typeElementDest = NodDest.Name.Split('-')[0];           //Détermine le type de l'élément de destination
            var idElementDest = NodDest.Name.Split('-')[1];             //Détermine l'ID de l'élément de destination
            var NodIndex = Nod.Index;
            var NodDestIndex = NodDest.Index;

            //Recherche des liens : référence
            Lien lien = new Lien();
            Lien lienDest = new Lien();

            int Element1_Type_id = Acces.Trouver_TableValeur_Code("TYPE_ELEMENT", typeElementParent).ID;
            int Element2_Type_id = Acces.Trouver_TableValeur_Code("TYPE_ELEMENT", typeElementDest).ID;

            foreach (var lst in listeLien)
            {
                if (lst.Element2_ID == int.Parse(idElementDest)
                    && lst.Element2_Type == Element2_Type_id
                    && lst.Element1_ID == int.Parse(idElementParent)
                    && lst.Element1_Type == Element1_Type_id)
                {
                    lienDest = lst;
                }
                if (lst.Element2_ID == int.Parse(idElement)
                    && lst.Element2_Type == Element2_Type_id
                    && lst.Element1_ID == int.Parse(idElementParent)
                    && lst.Element1_Type == Element1_Type_id)
                {
                    lien = lst;
                }
            }

            var ordre = lien.ordre;
            var ordreDest = lienDest.ordre;

            //Correction éventuelle
            if (ordreDest == ordre) { ordreDest = ordre + 1; }

            lienDest.ordre = ordre;
            lien.ordre = ordreDest;

            lien.Acces = Acces;
            lienDest.Acces = Acces;

            lien.MettreAJour();
            lienDest.MettreAJour();

            Afficher_Structure();

            TreeNode[] nd = treeStructure.Nodes.Find(Nod.Name, true);
            treeStructure.SelectedNode = nd[0];
            nd[0].EnsureVisible();
        }

        /// <summary>
        /// Exporte la structure hiérarchique et les éléments liés du plan
        /// vers des fichiers pour l'importation dans 6PO
        /// </summary>
        void Exporter_6PO(bool modif)
        {
            Export_6PO export = new Export_6PO();
            export.Acces = Acces;
            export.Chemin = Chemin;
            export.Console = Console;
            export.plan = plan;
            export.DP = DP;
            export.Exporter6PO(modif);

            lblResultatExport.Text = export.Texte_Resultat;

            MessageBox.Show("Fin de l'exportation du plan pour un import 6PO", "Fin de traitement");
        }

        /// <summary>
        /// Procédure déclenchée au début d'un drag and drop
        /// </summary>
        private void treeStructure_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the tree.
            TreeView tree = (TreeView)sender;

            // Get the node underneath the mouse.
            TreeNode node = tree.GetNodeAt(e.X, e.Y);
            tree.SelectedNode = node;

            // Start the drag-and-drop operation with a cloned copy of the node.
            if (node != null && e.Button == MouseButtons.Right)
            {
                tree.DoDragDrop(node.Clone(), DragDropEffects.Copy);
            }
        }

        /// <summary>
        /// Procédure déclenchée en cours d'un drag and drop
        /// </summary>
        private void treeStructure_DragOver(object sender, DragEventArgs e)
        {
            // Get the tree.
            TreeView tree = (TreeView)sender;

            // Drag and drop denied by default.
            e.Effect = DragDropEffects.None;

            // Is it a valid format?
            if (e.Data.GetData(typeof(TreeNode)) != null)
            {
                // Get the screen point.
                System.Drawing.Point pt = new System.Drawing.Point(e.X, e.Y);

                // Convert to a point in the TreeView's coordinate system.
                pt = tree.PointToClient(pt);

                // Is the mouse over a valid node?
                TreeNode node = tree.GetNodeAt(pt);
                if (node != null)
                {
                    e.Effect = DragDropEffects.Copy;
                    tree.SelectedNode = node;
                }
            }
        }

        /// <summary>
        /// Procédure déclenchée en fin d'un drag and drop
        /// </summary>
        private void treeStructure_DragDrop(object sender, DragEventArgs e)
        {
            // Get the tree.
            TreeView tree = (TreeView)sender;

            // Get the screen point.
            System.Drawing.Point pt = new System.Drawing.Point(e.X, e.Y);

            // Convert to a point in the TreeView's coordinate system.
            pt = tree.PointToClient(pt);

            // Get the node underneath the mouse.
            TreeNode NodDest = tree.GetNodeAt(pt);

            TreeNode nodSrc = (TreeNode)e.Data.GetData(typeof(TreeNode));
            string codeSrc = nodSrc.Name.Split('-')[1];
            string codeDest = NodDest.Name.Split('-')[1];

            //Caractérise les types d'éléments
            string typeElementDest = NodDest.Name.Split('-')[0];
            string typeElementSrc = nodSrc.Name.Split('-')[0];

            //Recherche du lien existant
            //-> Suppression
            Acces.Supprimer_Lien((Lien)nodSrc.Tag);

            int Element1_Type_id = Acces.Trouver_TableValeur_Code("TYPE_ELEMENT", typeElementDest).ID;
            int Element2_Type_id = Acces.Trouver_TableValeur_Code("TYPE_ELEMENT", typeElementSrc).ID;

            string Code1 = ""; string Code2 = "";

            switch (Element1_Type_id)
            {
                case 1:
                    {
                        Code1 = ((Plan)Acces.Trouver_Element(Acces.type_PLAN, int.Parse(codeDest))).Code;
                        break;
                    }

                case 2:
                    {
                        Code1 = ((Objectif)Acces.Trouver_Element(Acces.type_OBJECTIF, int.Parse(codeDest))).Code;
                        break;
                    }
                case 3:
                    {
                        Code1 = ((PATIO.CAPA.Classes.Action)Acces.Trouver_Element(Acces.type_ACTION, int.Parse(codeDest))).Code;
                        break;
                    }
                case 4:
                    {
                        Code1 = ((Indicateur)Acces.Trouver_Element(Acces.type_INDICATEUR, int.Parse(codeDest))).Code;
                        break;
                    }
            }

            switch (Element2_Type_id)
            {
                case 1:
                    {
                        Code1 = ((Plan)Acces.Trouver_Element(Acces.type_PLAN, int.Parse(codeSrc))).Code;
                        break;
                    }

                case 2:
                    {
                        Code1 = ((Objectif)Acces.Trouver_Element(Acces.type_OBJECTIF, int.Parse(codeSrc))).Code;
                        break;
                    }
                case 3:
                    {
                        Code1 = ((PATIO.CAPA.Classes.Action)Acces.Trouver_Element(Acces.type_ACTION, int.Parse(codeSrc))).Code;
                        break;
                    }
                case 4:
                    {
                        Code1 = ((Indicateur)Acces.Trouver_Element(Acces.type_INDICATEUR, int.Parse(codeSrc))).Code;
                        break;
                    }
            }

            //Création du nouveau lien
            Lien p = new Lien();
            p.Acces = Acces;
            p.Element0_Type = Acces.type_PLAN.ID;
            p.Element0_ID = plan.ID;
            p.Element0_Code = plan.Code;

            p.Element1_Type = Element1_Type_id;
            p.Element1_ID = int.Parse(codeDest);
            p.Element1_Code = Code1;

            p.Element2_Type = Element2_Type_id;
            p.Element2_ID = int.Parse(codeSrc);
            p.Element2_Code = Code2;

            p.ordre = p.Donner_Ordre() + 1;
            p.complement = "";
            p.Ajouter();

            Acces.Ajouter_Lien(p);

            Afficher_Structure();

            TreeNode[] Nd = treeStructure.Nodes.Find(nodSrc.Name, true);
            if (Nd.Length > 0) { treeStructure.SelectedNode = Nd[0]; Nd[0].EnsureVisible(); }

        }

        /// <summary>
        /// Procédure déclenchée par clic pour l'ouverture du formulaire correspondant à un élément
        /// </summary>
        private void btnOuvrir_Click(object sender, EventArgs e)
        {
            Ouvrir_Element();
        }

        /// <summary>
        /// Permet d'afficher le formulaire de modification d'un élément sélectionné
        /// </summary>
        void Ouvrir_Element()
        {
            if (treeStructure.SelectedNode is null) { return; }

            string typeElement = treeStructure.SelectedNode.Name.Split('-')[0];
            string idElement = treeStructure.SelectedNode.Name.Split('-')[1];

            if (typeElement == Acces.type_PLAN.Code)
            {
                ctrllisteplan.Acces = Acces;
                ctrllisteplan.plan = (Plan)Acces.Trouver_Element(Acces.type_PLAN, int.Parse(idElement));
                ctrllisteplan.Modifier_Plan();
                treeStructure.SelectedNode.Text = "Plan d'actions de " + ctrllisteplan.plan.NiveauPlan;
            }

            if (typeElement == Acces.type_OBJECTIF.Code)
            {
                ctrllisteobjectif.obj = (Objectif)Acces.Trouver_Element(Acces.type_OBJECTIF, int.Parse(idElement));
                ctrllisteobjectif.Modifier_Objectif();
            }

            if (typeElement == Acces.type_ACTION.Code)
            {
                ctrllisteaction.action = (PATIO.CAPA.Classes.Action)Acces.Trouver_Element(Acces.type_ACTION, (int.Parse(idElement)));
                ctrllisteaction.plan = plan;
                ctrllisteaction.Modifier_Action();
            }

            if (typeElement == Acces.type_INDICATEUR.Code)
            {
                ctrllisteindicateur.indicateur = (Indicateur)Acces.Trouver_Element(Acces.type_INDICATEUR, int.Parse(idElement));
                ctrllisteindicateur.Modifier_Indicateur();
            }
        }

        /// <summary>
        /// Procédure déclenchée pour l'affectation des droits du pilote du plan
        /// à l'ensemble des objectifs associés au plan
        /// </summary>
        private void MenuAffecterDroitsObjectifs_Click(object sender, EventArgs e)
        {
            Affecter_Droits_Objectif();
        }

        /// <summary>
        /// Affecte la qualité de pilote à l'ensemble des objectifs
        /// </summary>
        void Affecter_Droits_Objectif()
        {
            if (plan.Pilote is null) { MessageBox.Show("Le pilote du plan n'est pas connu."); return; }

            if (MessageBox.Show("Attention! tous les droits vont être réinitialisés.", "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.Cancel) { return; }

            int attribut_id = Acces.Trouver_Attribut(Acces.type_OBJECTIF, "PILOTE").ID;
            int typeelement_id = Acces.type_OBJECTIF.ID;

            foreach (Lien l in listeLien)
            {
                if (l.Element1_Type == typeelement_id)
                {
                    Objectif obj = (Objectif)Acces.Trouver_Element(Acces.type_OBJECTIF, l.Element1_ID);

                    obj.Acces = Acces;
                    string valeur = (obj.Pilote is null) ? "" : obj.Pilote.ID.ToString();
                    Acces.MettreAJour_dElement(obj.ID, valeur, plan.Pilote.ID.ToString(), "PILOTE", attribut_id);
                }

                if (l.Element2_Type == typeelement_id)
                {
                    Objectif obj = (Objectif)Acces.Trouver_Element(Acces.type_OBJECTIF, l.Element2_ID);

                    obj.Acces = Acces;
                    string valeur = (obj.Pilote is null) ? "" : obj.Pilote.ID.ToString();
                    Acces.MettreAJour_dElement(obj.ID, valeur, plan.Pilote.ID.ToString(), "PILOTE", attribut_id);
                }
            }

            Afficher();

            MessageBox.Show("Terminé");
        }

        /// <summary>
        /// Procédure déclenchée pour l'affectation des droits du pilote du plan
        /// à l'ensemble des actions associées au plan
        /// </summary>
        private void MenuAffecterDroitsActions_Click(object sender, EventArgs e)
        {
            Affecter_Droits_Action();
        }

        /// <summary>
        /// Affecte la qualité de pilote à l'ensemble des actions
        /// </summary>
        void Affecter_Droits_Action()
        {
            if (plan.Pilote is null) { MessageBox.Show("Le pilote du plan n'est pas connu."); return; }

            if (MessageBox.Show("Attention! tous les droits vont être réinitialisés.", "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.Cancel) { return; }

            int attribut_id = Acces.Trouver_Attribut(Acces.type_OBJECTIF, "PILOTE").ID;
            int typeelement_id = Acces.type_ACTION.ID;

            foreach (Lien l in listeLien)
            {
                if (l.Element1_Type == typeelement_id)
                {
                    PATIO.CAPA.Classes.Action action = (PATIO.CAPA.Classes.Action)Acces.Trouver_Element(Acces.type_ACTION, l.Element1_ID);

                    action.Acces = Acces;
                    string valeur = (action.Pilote is null) ? "" : action.Pilote.ID.ToString();
                    Acces.MettreAJour_dElement(action.ID, valeur, plan.Pilote.ID.ToString(), "PILOTE", attribut_id);
                }

                if (l.Element2_Type == typeelement_id)
                {
                    PATIO.CAPA.Classes.Action action = (PATIO.CAPA.Classes.Action)Acces.Trouver_Element(Acces.type_ACTION, l.Element2_ID);
                    if (action != null)
                    {
                        action.Acces = Acces;
                        string valeur = (action.Pilote is null) ? "" : action.Pilote.ID.ToString();
                        Acces.MettreAJour_dElement(action.ID, valeur, plan.Pilote.ID.ToString(), "PILOTE", attribut_id);
                    }
                    else
                    { MessageBox.Show("Action n°" + l.Element2_ID + " non trouvée","Contacter un administrateur"); }
                }
            }

            Afficher();

            MessageBox.Show("Terminé");
        }

        /// <summary>
        /// Procédure déclenchée pour la suppressions des liens "morts"
        /// à l'ensemble des actions associées au plan
        /// </summary>
        private void MenuSupprimer_ElementSansRef_Click(object sender, EventArgs e)
        {
            int n = 0;
            foreach (Lien l in listeLien)
            {
                if (l.Element1_ID == 0 || l.Element2_ID == 0)
                {
                    n++;
                    l.Acces = Acces;
                    l.Supprimer();
                }
            }

            Afficher();
            MessageBox.Show(n + " liens supprimés. RECHARGER les données !!");
        }

        /// <summary>
        /// Procédure déclenchée permettant l'affichage du répertoire de destination des fichiers exportés
        /// </summary>
        private void btnRepertoire_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Chemin + "\\Fichiers");
        }

        /// <summary>
        /// Procédure déclenchée par clic sur un élément permettant l'affichage des informations le concernant
        /// L'affichage se fait dans l'onglet secondaite de visualisation
        /// </summary>
        private void treeStructure_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Afficher_Detail();
        }

        /// <summary>
        /// Affichage des informations détaillées d'un élément
        /// </summary>
        void Afficher_Detail()
        {
            treeVisu.Nodes.Clear();

            if (treeStructure.SelectedNode == null) { return; }

            string id = treeStructure.SelectedNode.Name.Split('-')[1];
            string type_element = treeStructure.SelectedNode.Name.Split('-')[0];
            Console.Ajouter("Affiche_Detail : " + id + ", " + type_element);

            if (type_element == Acces.type_PLAN.Code) { Afficher_Plan(id); }
            if (type_element == Acces.type_OBJECTIF.Code) { Afficher_Objectif(id); }
            if (type_element == Acces.type_ACTION.Code) { Afficher_Action(id); }
        }

        /// <summary>
        /// Affichage des informations détaillées d'un plan
        /// </summary>
        void Afficher_Plan(string id)
        {
            //Plan p = (Plan)Acces.Trouver_Element(Acces.type_PLAN, id);
            TreeNode nd = new TreeNode("Plan");
            nd.Nodes.Add(new TreeNode("ID : " + id));
            nd.Nodes.Add(new TreeNode("Code : " + plan.Code));
            nd.Nodes.Add(new TreeNode("Libelle : " + plan.Libelle));
            nd.Nodes.Add(new TreeNode("Type : " + (TypePlan)plan.TypePlan));
            nd.Expand();
            treeVisu.Nodes.Add(nd);

            nd = new TreeNode("Détails");
            Element e = plan.Déconstruire();

            foreach (dElement d in e.Liste)
            {
                if (d.Attribut_Code.Substring(0, 1) != "_")
                {
                    nd.Nodes.Add(new TreeNode(d.Attribut_Code + " : " + d.Valeur));
                }
            }
            nd.Expand();
            treeVisu.Nodes.Add(nd);
        }

        /// <summary>
        /// Affichage des informations détaillées d'un objectif
        /// </summary>
        void Afficher_Objectif(string id)
        {
            Objectif obj = (Objectif)Acces.Trouver_Element(Acces.type_OBJECTIF, int.Parse(id));
            TreeNode nd1 = new TreeNode("Objectif");
            nd1.Nodes.Add(new TreeNode("ID : " + id));
            nd1.Nodes.Add(new TreeNode("Code : " + obj.Code));
            nd1.Nodes.Add(new TreeNode("Libelle : " + obj.Libelle));
            nd1.Nodes.Add(new TreeNode("Type : " + (TypeObjectif)obj.TypeObjectif));
            nd1.Nodes.Add(new TreeNode("Actif : " + (obj.Actif ? "Oui" : "Non")));
            nd1.Expand();
            treeVisu.Nodes.Add(nd1);

            TreeNode nd2 = new TreeNode("Détails");
            Element e = obj.Déconstruire();

            e.Liste.Sort();
            foreach (dElement d in e.Liste)
            {
                Console.Ajouter(d.Attribut_Code);
                string valeur = "";
                switch (d.Attribut_Code)
                {
                    case "PILOTE": { valeur = (Acces.Trouver_Utilisateur(int.Parse(d.Valeur))).NomPrenom; break; }
                    case "ROLE_6PO_COPILOTE": { valeur = (Acces.Trouver_Utilisateur(int.Parse(d.Valeur))).NomPrenom; break; }
                    case "ROLE_6PO_MANAGER": { valeur = (Acces.Trouver_Utilisateur(int.Parse(d.Valeur))).NomPrenom; break; }
                    case "METEO": { valeur = Acces.Trouver_TableValeur_Valeur("METEO", d.Valeur); break; }
                    case "TX_AVANCEMENT": { valeur = Acces.Trouver_TableValeur_Valeur("TX_AVANCEMENT", d.Valeur); break; }

                    case "STATUT": { valeur = Acces.Trouver_TableValeur(int.Parse( d.Valeur)).Valeur; break; }

                    case "TYPE": { valeur = Acces.Trouver_TableValeur_Valeur("TYPE_OBJECTIF", d.Valeur); break; }
                    default: { valeur = d.Valeur; break; }
                }
                if (d.Attribut_Code.Substring(0, 1) != "_")
                {
                    nd2.Nodes.Add(new TreeNode(d.Attribut_Code + " : " + valeur));
                }
            }
            nd2.Expand();
            treeVisu.Nodes.Add(nd2);
        }

        /// <summary>
        /// Affichage des informations détaillées d'une action
        /// </summary>
        void Afficher_Action(string id)
        {
            PATIO.CAPA.Classes.Action action = (PATIO.CAPA.Classes.Action)Acces.Trouver_Element(Acces.type_ACTION, int.Parse(id));
            TreeNode nd = new TreeNode("Action");
            nd.Nodes.Add(new TreeNode("ID : " + id));
            nd.Nodes.Add(new TreeNode("Code : " + action.Code));
            nd.Nodes.Add(new TreeNode("Libelle : " + action.Libelle));
            nd.Nodes.Add(new TreeNode("Type : " + (TypeAction)action.TypeAction));
            nd.Nodes.Add(new TreeNode("Actif : " + (action.Actif ? "Oui" : "Non")));
            nd.Expand();
            treeVisu.Nodes.Add(nd);

            TreeNode nd2 = new TreeNode("Détails");
            Element e = action.Déconstruire();
            //e.Liste.Sort();
            foreach (dElement d in e.Liste)
            {
                string valeur = "";
                switch (d.Attribut_Code)
                {
                    case "PILOTE": { valeur = (Acces.Trouver_Utilisateur(int.Parse(d.Valeur))).NomPrenom; break; }
                    case "ROLE_6PO_COPILOTE": { valeur = (Acces.Trouver_Utilisateur(int.Parse(d.Valeur))).NomPrenom; break; }
                    case "ROLE_6PO_MANAGER": { valeur = (Acces.Trouver_Utilisateur(int.Parse(d.Valeur))).NomPrenom; break; }
                    case "METEO": { valeur = Acces.Trouver_TableValeur_Valeur("METEO", d.Valeur); break; }
                    case "TX_AVANCEMENT": { valeur = Acces.Trouver_TableValeur_Valeur("TX_AVANCEMENT", d.Valeur); break; }
                    case "TYPE": { valeur = Acces.Trouver_TableValeur_Valeur("TYPE_ACTION", d.Valeur); break; }
                    case "VALIDATION_INTERNE": { valeur = Acces.Trouver_TableValeur_Valeur("VALIDATION_INTERNE", d.Valeur); break; }
                    case "ACTION_PHARE": { valeur = (d.Valeur == "1") ? "OUI" : "NON"; break; }
                    case "STATUT": { valeur = Acces.Trouver_TableValeur(int.Parse(d.Valeur)).Valeur; break; }

                    case "PUBLIC_CIBLE": { valeur = Acces.Trouver_TableValeur(int.Parse(d.Valeur)).Valeur; break; }
                    case "ACTEUR_SANTE": { valeur = Acces.Trouver_TableValeur(int.Parse(d.Valeur)).Valeur; break; }
                    case "LEVIER": { valeur = Acces.Trouver_TableValeur(int.Parse(d.Valeur)).Valeur; break; }
                    case "ANNEE_MO": { valeur = Acces.Trouver_TableValeur(int.Parse(d.Valeur)).Valeur; break; }
                    case "STRUCTURE_PORTEUSE": { valeur = Acces.Trouver_TableValeur(int.Parse(d.Valeur)).Valeur; break; }
                    case "PARTENAIRE_INSTITU": { valeur = Acces.Trouver_TableValeur(int.Parse(d.Valeur)).Valeur; break; }
                    case "PARTENAIRE_USAGER": { valeur = Acces.Trouver_TableValeur(int.Parse(d.Valeur)).Valeur; break; }
                    case "DIRECTION_PILOTE": { valeur = Acces.Trouver_TableValeur(int.Parse(d.Valeur)).Valeur; break; }
                    case "DIRECTION_ASSOCIE": { valeur = Acces.Trouver_TableValeur(int.Parse(d.Valeur)).Valeur; break; }
                    case "LIEN_PLAN": { valeur = Acces.Trouver_TableValeur(int.Parse(d.Valeur)).Valeur; break; }
                    case "TSANTE": { valeur = Acces.Trouver_TableValeur(int.Parse(d.Valeur)).Valeur; break; }
                    case "PRIORITE_CTS": { valeur = Acces.Trouver_TableValeur(int.Parse(d.Valeur)).Valeur; break; }

                    default: { valeur = d.Valeur; break; }
                }
                if (d.Attribut_Code.Substring(0, 1) != "_")
                {
                    nd2.Nodes.Add(new TreeNode(d.Attribut_Code + " : " + valeur));
                }
            }
            nd2.Expand();
            treeVisu.Nodes.Add(nd2);
        }

        /// <summary>
        /// Procédure déclenchée pour l'analyse des informations avant export vers 6PO
        /// </summary>
        private void btnAnalyser6PO_Click(object sender, EventArgs e)
        {
            Analyser_6PO();
        }

        /// <summary>
        /// Analyse des informations détaillées d'un élément
        /// </summary>
        void Analyser_6PO()
        {
            lblResultatExport.Text="";
            string resultat = "";
            bool ok1 = true;
            bool ok2 = true;

            //Recherche des pilotes invalides
            resultat += (char)Keys.Return + "PILOTES";
            if (plan.Pilote is null) { resultat += (char)Keys.Return + "Plan " + plan.Code; ok1 = true; }
            int typeelement_id = Acces.type_OBJECTIF.ID;

            resultat += (char)Keys.Return + "ERREUR DE LIENS";
            foreach (Lien l in listeLien)
            {
                if (l.Element2_Type == typeelement_id)
                {
                    Objectif obj = (Objectif)Acces.Trouver_Element(Acces.type_OBJECTIF, l.Element2_ID);
                    if (obj == null)
                    { resultat += (char) Keys.Return + "OBJ-Id=" + l.Element2_ID + " : " + "Objectif non trouvé"; ok2 = true;  }
                    else
                    {
                        if (obj.Pilote == null) { resultat += (char)Keys.Return + "Objectif " + obj.Code; }
                    }
                }
            }

            typeelement_id = Acces.type_ACTION.ID;

            foreach (Lien l in listeLien)
            {
                if (l.Element2_Type == typeelement_id)
                {
                    PATIO.CAPA.Classes.Action action = (PATIO.CAPA.Classes.Action)Acces.Trouver_Element(Acces.type_ACTION, l.Element2_ID);
                    if (action == null)
                    {
                        resultat += (char)Keys.Return + "ACT-Id=" + l.Element2_ID + " Action non trouvée"; }
                    else
                    {
                        if (action.Pilote == null) { resultat += (char)Keys.Return + "Action " + action.Code; }
                    }
                }
            }

            if (!ok1) { resultat += (char)Keys.Return + "Aucun problème"; }

            resultat += (char)Keys.Return;

            //Recherche des erreurs de liens

            foreach (Lien l in listeLien)
            {
                if (l.Element2_ID == 0 && l.Element2_Code.Length > 0)
                { resultat += (char)Keys.Return + "Lien " + l.ID.ToString(); ok2 = true; }
            }

            if (!ok2) { resultat += (char)Keys.Return + "Aucun problème"; }
            lblResultatExport.Text = resultat;
        }

        /// <summary>
        /// Procédure déclenchée par clic permettant l'affichage ou non des opérations dans la structure
        /// </summary>
        private void OptAfficherOpération_Click(object sender, EventArgs e)
        {
            OptAfficherOpération.Checked = !OptAfficherOpération.Checked;
            Afficher();
        }

        /// <summary>
        /// Procédure déclenchée par clic permettant l'affichage ou non des indicateurs dans la structure
        /// </summary>
        private void OptAfficherIndicateur_Click(object sender, EventArgs e)
        {
            OptAfficherIndicateur.Checked = !OptAfficherIndicateur.Checked;
            Afficher();
        }

        /// <summary>
        /// Procédure déclenchée par validation permettant l'ouverture du formulaire de l'élément sélectionné
        /// </summary>
        private void treeStructure_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Return) { Ouvrir_Element(); }
        }

        /// <summary>
        /// Procédure déclenchée permettant l'initialisation des dates du plan
        /// </summary>
        private void Menu_AppliquerDates_Click(object sender, EventArgs e)
        {
            AppliquerDates_Plan();
        }

        /// <summary>
        /// Application de la modification des dates du plan
        /// </summary>
        void AppliquerDates_Plan()
        {
            Acces.Modifier_Dates_Plan(plan);
            MessageBox.Show("Traitement terminé.");
        }

        /// <summary>
        /// Procédure déclenchée par clic permettant l'extension automtique ou non de la structure du plan
        /// </summary>
        private void btnEtendre_Click(object sender, EventArgs e)
        {
            if (btnEtendre.Checked) { treeStructure.ExpandAll(); }
            if (!btnEtendre.Checked) { treeStructure.CollapseAll(); }
            btnEtendre.Checked = !btnEtendre.Checked;
        }

        /// <summary>
        /// Procédure déclenchée permettant l'actualisation des références des codes au niveau des liens
        /// Procédure technique (voir à supprimer)
        /// </summary>
        private void MenuActualiserLiens_Click(object sender, EventArgs e)
        {
            string sql;

            sql = "UPDATE lien SET Element0_Code= (SELECT element.Code FROM element";
            sql += " WHERE lien.Element0_ID = element.id";
            sql += " AND lien.Element0_ID = " + plan.ID + ")";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur, "Erreur"); }

            sql = "UPDATE lien SET Element1_Code= (SELECT element.Code FROM element";
            sql += " WHERE lien.Element1_ID = element.id";
            sql += " AND lien.Element0_ID = " + plan.ID + ")";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur, "Erreur"); }

            sql = "UPDATE lien SET Element2_Code= (SELECT element.Code FROM element";
            sql += " WHERE lien.Element2_ID = element.id";
            sql += " AND lien.Element0_ID = " + plan.ID + ")";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur, "Erreur"); }

            MessageBox.Show("Traitement terminé");

            Afficher_Structure();
        }

        /// <summary>
        /// Procédure déclenchée par clic permettant l'affichage ou non des cases à cocher dans la structure
        /// </summary>
        private void btnCaseCocher_Click(object sender, EventArgs e)
        {
            treeStructure.CheckBoxes = !treeStructure.CheckBoxes;
        }

        /// <summary>
        /// Procédure déclenchée par sélection permettant la recherche des éléments cochés dans la structure
        /// </summary>
        private void tabControl2_Selected(object sender, TabControlEventArgs e)
        {
            ListeElementCocher = new List<int>();
            ExtraitListeCocher(treeStructure.Nodes[0]);
        }

        /// <summary>
        /// Recherche des éléments cochés dans la structure
        /// </summary>
        void ExtraitListeCocher(TreeNode ndG)
        {
            foreach (TreeNode nd in ndG.Nodes)
            {
                if (nd.Checked == true) { ListeElementCocher.Add(int.Parse(nd.Name.Split('-')[1])); }
                if (nd.Nodes.Count > 0) { ExtraitListeCocher(nd); }
            }
        }

        /// <summary>
        /// Procédure déclenchée permettant l'affectation des droits de l'élément sélectionné
        /// à ses éléments enfants
        /// </summary>
        private void MenuAffecterDroitsEnfants_Click(object sender, EventArgs e)
        {
            if (treeStructure.SelectedNode == null) { MessageBox.Show("Aucun élément sélectionné"); return; }

            if (MessageBox.Show("Attention! tous les droits des éléments enfants vont être réinitialisés.", "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.Cancel) { return; }

            AffecterDroits_Enfants("PILOTE");
            AffecterDroits_Enfants("ROLE_6PO_COPILOTE");
            MessageBox.Show("Actualisation terminée");
        }

        /// <summary>
        /// Affecte les droits de l'élément sélectionné à ses enfants
        /// </summary>
        void AffecterDroits_Enfants(string attribut_code)
        {
            if (treeStructure.SelectedNode == null) { return; }

            TreeNode nod = treeStructure.SelectedNode;

            string element_type = nod.Name.Split('-')[0];
            int element_id = int.Parse(nod.Name.Split('-')[1]);

            if (element_type != Acces.type_OBJECTIF.Code && element_type != Acces.type_ACTION.Code)
            {
                MessageBox.Show("La modification ne s'applique à ce type d'élément. Uniquement Objectif et Action");
                return;
            }

            TypeElement element_type_id = Acces.Trouver_Type_Element(element_type);

            //Recherche des informations techniques sur l'attribut
            int attribut_id = Acces.Trouver_Attribut(element_type_id, attribut_code).ID;
            if (attribut_id == 0) { MessageBox.Show("L'attribut n'est pas connu pour ce type d'élément"); return; }

            List<string> ListeValeur = new List<string>();

            if (attribut_code == "PILOTE")
            {
                if (element_type_id == Acces.type_OBJECTIF)
                {
                    Objectif objectif = (Objectif)Acces.Trouver_Element(Acces.type_OBJECTIF, element_id);
                    if (objectif.Pilote == null) { MessageBox.Show("Erreur dans la valeur initiale"); return; }
                    ListeValeur.Add(objectif.Pilote.ID.ToString());
                }

                if (element_type_id == Acces.type_ACTION)
                {
                    PATIO.CAPA.Classes.Action action = (PATIO.CAPA.Classes.Action)Acces.Trouver_Element(element_type_id, element_id);
                    if (action.Pilote == null) { MessageBox.Show("Erreur dans la valeur initiale"); return; }
                    ListeValeur.Add(action.Pilote.ID.ToString());
                }
            }

            if (attribut_code == "ROLE_6PO_COPILOTE")
            {
                if (element_type_id == Acces.type_OBJECTIF)
                {
                    Objectif objectif = (Objectif)Acces.Trouver_Element(element_type_id, element_id);
                    if (objectif.Pilote == null) { MessageBox.Show("Erreur dans la valeur initiale"); return; }
                    foreach (int k in objectif.Role_6PO_CoPilote)
                    {
                        ListeValeur.Add(k.ToString());
                    }
                }

                if (element_type_id == Acces.type_ACTION)
                {
                    PATIO.CAPA.Classes.Action action = (PATIO.CAPA.Classes.Action)Acces.Trouver_Element(element_type_id, element_id);
                    if (action.Pilote == null) { MessageBox.Show("Erreur dans la valeur initiale"); return; }
                    foreach (int k in action.Role_6PO_CoPilote)
                    {
                        ListeValeur.Add(k.ToString());
                    }
                }
            }

            Console.Ajouter("[ACTUALISATION DROITS] ListeValeur :" + ListeValeur.Count.ToString());

            foreach (TreeNode nd in nod.Nodes)
            {
                Actualiser_Droits_enfants(nd, element_type_id, element_id, attribut_id, attribut_code, ListeValeur);
            }
        }

        /// <summary>
        /// Actualise les droits pour l'élément sélectionné
        /// </summary>
        void Actualiser_Droits_enfants(TreeNode nd, TypeElement element_type, int element_id, int attribut_id, string attribut_code, List<string> ListeValeur)
        {
            string type = nd.Name.Split('-')[0];
            int id = int.Parse(nd.Name.Split('-')[1]);

            //Recherche si l'attribut est associé à l'élément
            int att_id = Acces.Trouver_Attribut(element_type, attribut_code).ID;

            if (att_id != 0)
            {
                //Suppression des informations correspondant à lélément traité
                Acces.Supprimer_dElement(id, attribut_id);

                //Ajoute de sinformations pour l'attribut pour l'élément
                foreach (string valeur in ListeValeur)
                {
                    dElement d = new dElement() { Acces = Acces, };
                    d.Element_ID = id;
                    d.Attribut_ID = attribut_id;
                    d.Attribut_Code = attribut_code;
                    d.Valeur = valeur;
                    d.Ajouter();
                    Acces.Ajouter_dElement(d);
                    Console.Ajouter("[ACTUALISATION DROITS] Attribut :" + attribut_code + "| ID : " + id);
                }
            }
            else
            {
                Console.Ajouter("[ACTUALISATION DROITS] Attribut :" + attribut_code + "| ID : " + id + " NON TROUVE");
            }

            //Applique aux enfants
            foreach (TreeNode nde in nd.Nodes)
            {
                Actualiser_Droits_enfants(nde, element_type, element_id, attribut_id, attribut_code, ListeValeur);
            }

        }

        /// <summary>
        /// Procédure déclenchée permettant l'agrandissement de l'affichage de la structure
        /// La structure prend alors toute la largeur
        /// </summary>
        private void btnAgrandir_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = true;
            btnRéduire.Visible = true;
            btnAgrandir.Visible = false;
        }

        /// <summary>
        /// Procédure déclenchée permettant la réduction de l'affichage de la structure
        /// Les éléments de choix prennent alors toute la largeur
        /// </summary>
        private void btnRéduire_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = true;
            btnRéduire.Visible = false;
            btnAgrandir.Visible = true;
        }

        /// <summary>
        /// Procédure déclenchée permettant l'affichage partagé de la structure et des éléments de choix
        /// </summary>
        private void btnPartage_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = false;
            splitContainer1.Panel2Collapsed = false;
            btnRéduire.Visible = true;
            btnAgrandir.Visible = true;
        }

        /// <summary>
        /// procédure déclenchée lors de l'enregistrement d'une fiche objectif
        /// </summary>
        void Handler_evt_Modifier_Objectif(Object sender, ctrlListeObjectif.evt_Modifier e)
        {
            //Actualise le titre de l'onglet
            WeifenLuo.WinFormsUI.Docking.DockContent d = (WeifenLuo.WinFormsUI.Docking.DockContent)DP.ActiveDocument;
            ctrlFicheObjectif f;
            try { f = (ctrlFicheObjectif)d.Controls[0]; } catch { f = null; }

            if (f != null)
            {
                if (f.Tag.ToString() == e.ID.ToString())
                {
                    Objectif obj = f.objectif;

                    TreeNode[] nd = treeStructure.Nodes.Find(Acces.type_OBJECTIF.Code + "-" + obj.ID.ToString(), true);
                    if (nd.Length > 0)
                    {
                        nd[0].Text = obj.Libelle;
                        nd[0].ToolTipText = obj.Code;
                        nd[0].ImageIndex = Donner_ImageIndex(Acces.type_OBJECTIF, obj.ID);
                    }
                }
            }
        }

        /// <summary>
        /// procédure déclenchée lors de l'enregistrement d'une fiche action
        /// </summary>
        void Handler_evt_Modifier_Action(Object sender, ctrlListeAction.evt_Modifier e)
        {
            //Actualise le titre de l'onglet
            WeifenLuo.WinFormsUI.Docking.DockContent d = (WeifenLuo.WinFormsUI.Docking.DockContent)DP.ActiveDocument;
            ctrlFicheAction f;
            try { f = (ctrlFicheAction)d.Controls[0]; } catch { f = null; }

            if (f != null)
            {
                if (f.Tag.ToString() == e.ID.ToString())
                {
                    PATIO.CAPA.Classes.Action action = f.action;

                    TreeNode[] nd = treeStructure.Nodes.Find(Acces.type_ACTION.Code + "-" + action.ID.ToString(), true);
                    if (nd.Length > 0)
                    {
                        nd[0].Text = action.Libelle;
                        nd[0].ToolTipText = action.Code;
                        nd[0].ImageIndex = Donner_ImageIndex(Acces.type_ACTION, action.ID);
                        if (action.ActionPhare) { nd[0].ImageIndex = imgs[PosImageActionPhare].Id; }
                    }
                }
            }
        }

        /// <summary>
        /// procédure déclenchée lors de l'enregistrement d'une fiche action
        /// </summary>
        void Handler_evt_Modifier_Indicateur(Object sender, ctrlListeAction.evt_Modifier e)
        {
            //Actualise le titre de l'onglet
            WeifenLuo.WinFormsUI.Docking.DockContent d = (WeifenLuo.WinFormsUI.Docking.DockContent)DP.ActiveDocument;
            ctrlFicheAction f;
            try { f = (ctrlFicheAction)d.Controls[0]; } catch { f = null; }

            if (f != null)
            {
                if (f.Tag.ToString() == e.ID.ToString())
                {
                    PATIO.CAPA.Classes.Action action = f.action;

                    TreeNode[] nd = treeStructure.Nodes.Find(Acces.type_INDICATEUR.Code + "-" + action.ID.ToString(), true);
                    if (nd.Length > 0)
                    {
                        nd[0].Text = action.Libelle;
                        nd[0].ToolTipText = action.Code;
                        nd[0].ImageIndex = Donner_ImageIndex(Acces.type_ACTION, action.ID);
                        //nd[0].Parent.Expand();
                        //treeStructure.SelectedNode = nd[0].Parent;
                    }
                }
            }
        }

        /// <summary>
        /// Procédure déclenchée pour l'édition de la fiche de l'élément sélectionné
        /// </summary>
        private void btnEditerFiche_Click(object sender, EventArgs e)
        {
            Editer_Fiche();
        }

        /// <summary>
        /// Edition de la fiche correspondante à l'élément sélectionné
        /// </summary>
        void Editer_Fiche()
        {
            if (treeStructure.SelectedNode == null) { return; }

            string type = treeStructure.SelectedNode.Name.Split('-')[0];

            EditionFiche edite_fiche = new EditionFiche();
            edite_fiche.Acces = Acces;
            edite_fiche.Chemin = Chemin;
            edite_fiche.Console = Console;
            edite_fiche.DP = DP;

            edite_fiche.type_element = type;
            edite_fiche.id_element = int.Parse(treeStructure.SelectedNode.Name.Split('-')[1]);

            edite_fiche.Editer_Fiche();
        }

        /// <summary>
        /// Procédure déclenchée pour lancer l'exportation vers 6PO modalité d'ajout
        /// </summary>
        private void btnExporter6PO_Ajout_Click(object sender, EventArgs e)
        {
            Exporter_6PO(false);
        }

        private void btnExporter6PO_Maj_Click(object sender, EventArgs e)
        {
            Exporter_6PO(true);
        }
    }
}