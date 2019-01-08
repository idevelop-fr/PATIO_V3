using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PATIO.MAIN.Classes;

namespace PATIO.ADMIN.Interfaces
{
    class Edition_doc
    {
        /// <summary>
        /// Définition des paramètres publics
        /// </summary>
        public AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;
        public ctrlConsole Console;

        public List<ModeleDoc> listeModeleDoc;
        public string CheminBase;
        public string CheminTemp;

        Microsoft.Office.Interop.Word.Document Doc;
        Microsoft.Office.Interop.Word.Application App;

        Microsoft.Office.Interop.Word.WdExportFormat paramExportFormat = Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF;
        bool paramOpenAfterExport = false;
        Microsoft.Office.Interop.Word.WdExportOptimizeFor paramExportOptimizeFor = Microsoft.Office.Interop.Word.WdExportOptimizeFor.wdExportOptimizeForPrint;
        Microsoft.Office.Interop.Word.WdExportRange paramExportRange = Microsoft.Office.Interop.Word.WdExportRange.wdExportAllDocument;
        int paramStartPage = 0;
        int paramEndPage = 0;
        Microsoft.Office.Interop.Word.WdExportItem paramExportItem = Microsoft.Office.Interop.Word.WdExportItem.wdExportDocumentContent;
        bool paramIncludeDocProps = true;
        bool paramKeepIRM = true;
        Microsoft.Office.Interop.Word.WdExportCreateBookmarks paramCreateBookmarks = Microsoft.Office.Interop.Word.WdExportCreateBookmarks.wdExportCreateWordBookmarks;
        bool paramDocStructureTags = true;
        bool paramBitmapMissingFonts = true;
        bool paramUseISO19005_1 = false;

        public void Créer_Document(string Fichier_Modele, bool OptionPDF)
        {
            if(Fichier_Modele.Length == 0) { return; }

            int K = 0; //Nombre de paragraphes dans le document
            string fichier = Fichier_Modele + ".docx";
            App = new Microsoft.Office.Interop.Word.Application();
            Doc = new Microsoft.Office.Interop.Word.Document();

            //Ouverture du modèle désigné ou celui par défaut
            if (System.IO.File.Exists(CheminTemp + "\\Modeles\\" + fichier))
            {
                App.Documents.Open(CheminTemp + "\\Modeles\\" + fichier);
                Doc = App.ActiveDocument;
            }
            else
            {
                Doc = App.Documents.Add();
                Doc.Activate();
            }

            //Traitement des informations
            foreach (ModeleDoc md_Zone in listeModeleDoc)
            {
                //Traitement d'une zone
                if(md_Zone.Type_Modele == Type_Modele.ZONE)
                {
                    //Traitement des lignes dans la zone
                    foreach(ModeleDoc md_Ligne in listeModeleDoc)
                    {
                        if (md_Ligne.Type_Modele == Type_Modele.LIGNE && md_Ligne.Parent_ID == md_Zone.ID)
                        {
                            Doc.Paragraphs.Add();
                            Microsoft.Office.Interop.Word.Range table = Doc.Paragraphs[K + 1].Range;

                            if (md_Ligne.Contenu == "SAUT_LIGNE")
                            {
                                table.InsertBreak(Microsoft.Office.Interop.Word.WdBreakType.wdPageBreak);
                            }
                            else
                            {
                                List<ModeleDoc> listeColonne = new List<ModeleDoc>();

                                //Détermine le nombre de colonnes composant la ligne
                                foreach (ModeleDoc md_Colonne in listeModeleDoc)
                                { if (md_Colonne.Type_Modele == Type_Modele.COLONNE && md_Colonne.Parent_ID == md_Ligne.ID)
                                    { listeColonne.Add(md_Colonne); } }

                                //Création du tableau
                                Microsoft.Office.Interop.Word.Table Tb = Doc.Tables.Add(table, 1, listeColonne.Count);
                                Tb.PreferredWidth = 100;
                                Tb.PreferredWidthType = Microsoft.Office.Interop.Word.WdPreferredWidthType.wdPreferredWidthPercent;

                                //Traitement des colonnes dans la ligne
                                for (int col = 0; col < listeColonne.Count; col++)
                                {
                                    ModeleDoc md_Col = listeColonne[col];
                                    Tb.Cell(1, col).Range.Text = md_Col.Contenu;
                                    //Alignement
                                    {
                                        if (md_Col.Alignement == Alignement.Gauche)
                                        { Tb.Cell(1, col).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft; }
                                        if (md_Col.Alignement == Alignement.Centré)
                                        { Tb.Cell(1, col).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter; }
                                        if (md_Col.Alignement == Alignement.Droit)
                                        { Tb.Cell(1, col).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight; }
                                        if (md_Col.Alignement == Alignement.Justifié)
                                        { Tb.Cell(1, col).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphJustify; }
                                    }
                                    //Bordures
                                    {
                                        if (md_Col.Bordure.Contains("L"))
                                        {
                                            Tb.Cell(1, col).Range.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderLeft].LineStyle =
                                                Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
                                        }
                                        if (md_Col.Bordure.Contains("R"))
                                        {
                                            Tb.Cell(1, col).Range.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderRight].LineStyle =
                                                Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
                                        }
                                        if (md_Col.Bordure.Contains("H"))
                                        {
                                            Tb.Cell(1, col).Range.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderTop].LineStyle =
                                                Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
                                        }
                                        if (md_Col.Bordure.Contains("B"))
                                        {
                                            Tb.Cell(1, col).Range.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderBottom].LineStyle =
                                                Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
                                        }
                                    }
                                }
                                //Redimensionne les colonnes
                                for (int col = 0; col < listeColonne.Count; col++)
                                {
                                    Tb.Columns[col].PreferredWidthType = Microsoft.Office.Interop.Word.WdPreferredWidthType.wdPreferredWidthPercent;
                                    Tb.Columns[col].PreferredWidth = float.Parse(listeColonne[col].Taille.ToString());
                                }
                            }
                        }
                    }
                }
            }

            //Sauvegarde du fichier
            {
                string Nom_Doc = string.Format("{0:yyyyMMddHHmmsssfff}", DateTime.Now);
                string fichier_dest = CheminTemp + "\\" + Nom_Doc + ".docx";
                Doc.SaveAs(fichier_dest);

                if (OptionPDF)
                {
                    string fichier_pdf = CheminTemp + "\\" + Nom_Doc + ".pdf";

                    Doc.ExportAsFixedFormat(fichier_pdf, paramExportFormat, paramOpenAfterExport, paramExportOptimizeFor,
                        paramExportRange, paramStartPage, paramEndPage, paramExportItem, paramIncludeDocProps,
                        paramKeepIRM, paramCreateBookmarks, paramDocStructureTags, paramBitmapMissingFonts, paramUseISO19005_1);

                    System.Diagnostics.Process.Start(fichier_pdf); //Ouverture
                    Doc.SaveAs(fichier_dest);
                    App.Quit();
                }
                else
                {
                    App.Visible = true;
                    App.Activate();
                }
            }
        }

        public void ExtraireParametre(string Modele)
        {
            string Fichier = Modele + ".docx";

            App.Documents.Open(CheminBase + "\\Modeles\\" + Fichier);
            Doc = App.ActiveDocument;

            Microsoft.Office.Interop.Word.Range range = App.ActiveDocument.Content;

            range.Find.ClearFormatting();
            range.Find.Forward = true;
            range.Find.MatchWildcards = true;
            range.Text = "[*]";
            range.Find.MatchAllWordForms = true;
            range.Find.Execute();

            while (range.Find.Found)
            {
                range.Select();
                string txt = range.Text;
                MessageBox.Show(txt);
            }
        }
    }
}
