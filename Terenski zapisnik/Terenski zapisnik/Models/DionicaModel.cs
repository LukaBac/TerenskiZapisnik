using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using A = DocumentFormat.OpenXml.Drawing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Terenski_zapisnik.Models
{
    public class DionicaModel
    {
        public int Index { get; set; }

        public double IspitniTlak { get; set; }

        public double OmocenoOplosje { get; set; }

        public double Vdopusteno { get; set; }

        public double VIzmjereno { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public Image Image { get; set; }


        public string DionicaNaziv { get; set; }
        public string DionicaMaterijal { get; set; }
        public string DionicaPromjer { get; set; }

        //public void Ispis()
        //{
        //    // Replace "YourTemplatePath.docx" with the path to your Word template
        //    string templatePath = "TemplateNew(2).docx";

        //    //dionicaoutput
        //    using (WordprocessingDocument templateDoc = WordprocessingDocument.Open(templatePath, true))
        //    {
        //        // Show the save file dialog to get the output path from the user
        //        using (SaveFileDialog saveFileDialog = new SaveFileDialog())
        //        {
        //            saveFileDialog.Filter = "Word Documents (*.docx)|*.docx";
        //            saveFileDialog.Title = "Save As";
        //            saveFileDialog.FileName = "OutputDocument";

        //            if (saveFileDialog.ShowDialog() == DialogResult.OK)
        //            {
        //                string outputPath = saveFileDialog.FileName;

        //                // Clone the template document to create a new one
        //                using (WordprocessingDocument outputDoc = templateDoc.Clone(outputPath))
        //                {
        //                    ReplaceTextAtBookmark(outputDoc, "Kupac", ProjectModel.Kupac);
        //                    ReplaceTextAtBookmark(outputDoc, "Lokacija", ProjectModel.Lokacija);
        //                    ReplaceTextAtBookmark(outputDoc, "RadniNalog", ProjectModel.RadniNalog);
        //                    ReplaceTextAtBookmark(outputDoc, "Datum", ProjectModel.Datum.ToString("dd.MM.yyyy"));
        //                    ReplaceTextAtBookmark(outputDoc, "RedniBr", "1.");


        //                    //Dionica
        //                    ReplaceTextAtBookmark(outputDoc, "Oplosje", Math.Round(OmocenoOplosje, 2).ToString());
        //                    ReplaceTextAtBookmark(outputDoc, "Vdop", Math.Round(Vdopusteno, 2).ToString());
        //                    ReplaceTextAtBookmark(outputDoc, "VrijemePoc", StartTime);
        //                    ReplaceTextAtBookmark(outputDoc, "VrijemeEnd", EndTime);
        //                    ReplaceTextAtBookmark(outputDoc, "VIzmj", VIzmjereno.ToString());
        //                    ReplaceTextAtBookmark(outputDoc, "VIzmjereno", VIzmjereno.ToString());
        //                    ReplaceTextAtBookmark(outputDoc, "IspitniTlak", IspitniTlak.ToString());



        //                    if (VIzmjereno <= Vdopusteno)
        //                    {
        //                        ReplaceTextAtBookmark(outputDoc, "Y", "X");
        //                        ReplaceTextAtBookmark(outputDoc, "N", "");
        //                    }
        //                    else
        //                    {
        //                        ReplaceTextAtBookmark(outputDoc, "Y", "");
        //                        ReplaceTextAtBookmark(outputDoc, "N", "X");
        //                    }

        //                    //if (Image != null)
        //                    //{
        //                    ReplaceBookmarkWithImage(outputDoc, "ImageBookmark", Image);
        //                    //}

        //                    ReplaceTextAtBookmark(outputDoc, "DionicaInfo", $"{DionicaNaziv}, {DionicaMaterijal}, {DionicaPromjer}");
        //                    //ReplaceTextAtBookmark(outputDoc, "Bookmark2", "Text for Bookmark2");
        //                    Console.WriteLine($"Document saved successfully to: {outputPath}");
        //                }
        //            }
        //        }
        //    }
        //}

        private void ReplaceDionicaBookmarks(WordprocessingDocument doc)
        {
            //Dionica
            ReplaceTextAtBookmark(doc, "Oplosje", Math.Round(OmocenoOplosje, 2).ToString());
            ReplaceTextAtBookmark(doc, "Vdop", Math.Round(Vdopusteno, 2).ToString());
            ReplaceTextAtBookmark(doc, "VrijemePoc", StartTime);
            ReplaceTextAtBookmark(doc, "VrijemeEnd", EndTime);
            ReplaceTextAtBookmark(doc, "VIzmj", VIzmjereno.ToString());
            ReplaceTextAtBookmark(doc, "VIzmjereno", VIzmjereno.ToString());
            ReplaceTextAtBookmark(doc, "IspitniTlak", IspitniTlak.ToString());

            if (VIzmjereno <= Vdopusteno)
            {
                ReplaceTextAtBookmark(doc, "Y", "X");
                ReplaceTextAtBookmark(doc, "N", "");
            }
            else
            {
                ReplaceTextAtBookmark(doc, "Y", "");
                ReplaceTextAtBookmark(doc, "N", "X");
            }

            // if (Image != null)
            // {
            ReplaceBookmarkWithImage(doc, "ImageBookmark", Image);
            // }

            ReplaceTextAtBookmark(doc, "DionicaInfo", $"{DionicaNaziv}, {DionicaMaterijal}, {DionicaPromjer}");
        }

        private void ReplaceProjektBookmarks(WordprocessingDocument doc)
        {
            //Projekt
            ReplaceTextAtBookmark(doc, "Kupac", ProjectModel.Kupac);
            ReplaceTextAtBookmark(doc, "Lokacija", ProjectModel.Lokacija);
            ReplaceTextAtBookmark(doc, "RadniNalog", ProjectModel.RadniNalog);
            ReplaceTextAtBookmark(doc, "Datum", ProjectModel.Datum);
            //ReplaceTextAtBookmark(doc, "Datum", ProjectModel.Datum.ToString("dd.MM.yyyy"));
            ReplaceTextAtBookmark(doc, "RedniBr", "1.");
        }

        private static void CopyContent(WordprocessingDocument sourceDoc, WordprocessingDocument destinationDoc)
        {
            // Get the body of the source document
            var sourceBody = sourceDoc.MainDocumentPart.Document.Body;

            // Get the body of the destination document
            var destinationBody = destinationDoc.MainDocumentPart.Document.Body;

            // Clone the nodes from the source document to the destination document
            foreach (var element in sourceBody.Elements())
            {
                var newElement = element.CloneNode(true);
                destinationBody.AppendChild(newElement);
            }
        }


        static void ReplaceTextAtBookmark(WordprocessingDocument doc, string bookmarkName, string newText)
        {
            MainDocumentPart mainPart = doc.MainDocumentPart;
            var bookmarkStart = mainPart.Document.Descendants<BookmarkStart>().FirstOrDefault(b => b.Name == bookmarkName);

            if (bookmarkStart != null)
            {
                var run = bookmarkStart.NextSibling<DocumentFormat.OpenXml.Wordprocessing.Run>();
                if (run != null)
                {
                    run.GetFirstChild<DocumentFormat.OpenXml.Wordprocessing.Text>().Text = newText;
                }
            }
            else
            {
                Console.WriteLine($"Bookmark '{bookmarkName}' not found.");
            }
        }

        private static void ReplaceBookmarkWithImage(WordprocessingDocument doc, string bookmarkName, Image image)
        {
            // Find the specified bookmark by name
            var bookmarkStart = doc.MainDocumentPart.RootElement.Descendants<BookmarkStart>()
                .FirstOrDefault(b => b.Name == bookmarkName);

            if (bookmarkStart != null)
            {
                // Insert the image into the bookmark
                InsertImageIntoBookmark(doc, bookmarkStart, image);

                // Remove the bookmark
                bookmarkStart.Remove();
            }
            else
            {
                Console.WriteLine($"Bookmark '{bookmarkName}' not found.");
            }
        }

        public static void InsertImageIntoBookmark(WordprocessingDocument doc, BookmarkStart bookmarkStart, Image image)
        {
            // Remove anything present inside the bookmark
            OpenXmlElement elem = bookmarkStart.NextSibling();
            while (elem != null && !(elem is BookmarkEnd))
            {
                OpenXmlElement nextElem = elem.NextSibling();
                elem.Remove();
                elem = nextElem;
            }

            // Create an imagepart
            var imagePart = AddImagePart(doc.MainDocumentPart, image);

            // Insert the image part after the bookmark start
            AddImageToBody(doc.MainDocumentPart.GetIdOfPart(imagePart), bookmarkStart);
        }

        public static ImagePart AddImagePart(MainDocumentPart mainPart, Image image)
        {
            ImagePart imagePart = mainPart.AddImagePart(ImagePartType.Jpeg);

            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg); // You can choose the appropriate image format
                stream.Position = 0;

                imagePart.FeedData(stream);
            }

            return imagePart;
        }

        private static void AddImageToBody(string relationshipId, BookmarkStart bookmarkStart)
        {
            // Define the reference of the image.
            var element =
                new Drawing(
                    new DW.Inline(
                        new DW.Extent()
                        {
                            Cx = 2700000L,
                            Cy = 2692800L
                        },
                        new DW.EffectExtent() { LeftEdge = 0L, TopEdge = 0L, RightEdge = 0L, BottomEdge = 0L },
                        new DW.DocProperties() { Id = (UInt32Value)1U, Name = "Picture 1" },
                        new DW.NonVisualGraphicFrameDrawingProperties(new A.GraphicFrameLocks() { NoChangeAspect = true }),
                        new A.Graphic(
                            new A.GraphicData(
                                new PIC.Picture(
                                    new PIC.NonVisualPictureProperties(
                                        new PIC.NonVisualDrawingProperties()
                                        {
                                            Id = (UInt32Value)0U,
                                            Name = "New Bitmap Image.jpg"
                                        },
                                        new PIC.NonVisualPictureDrawingProperties()),
                                    new PIC.BlipFill(
                                        new A.Blip(
                                            new A.BlipExtensionList(
                                                new A.BlipExtension()
                                                {
                                                    Uri = "{28A0092B-C50C-407E-A947-70E740481C1C}"
                                                }))
                                        {
                                            Embed
                                                =
                                                relationshipId,
                                            CompressionState
                                                =
                                                A
                                                .BlipCompressionValues
                                                .Print
                                        },
                                        new A.Stretch(new A.FillRectangle())),
                                    new PIC.ShapeProperties(
                                        new A.Transform2D(new A.Offset() { X = 0L, Y = 0L }, new A.Extents() { Cx = 2700000L, Cy = 2692800L }),
                                        new A.PresetGeometry(new A.AdjustValueList()) { Preset = A.ShapeTypeValues.Rectangle })))
                            {
                                Uri =
                                        "http://schemas.openxmlformats.org/drawingml/2006/picture"
                            }))
                    {
                        DistanceFromTop = (UInt32Value)0U,
                        DistanceFromBottom = (UInt32Value)0U,
                        DistanceFromLeft = (UInt32Value)0U,
                        DistanceFromRight = (UInt32Value)0U,
                        EditId = "50D07946"
                    });

            // add the image element to body, the element should be in a Run.
            bookmarkStart.Parent.InsertAfter<DocumentFormat.OpenXml.Wordprocessing.Run>(new DocumentFormat.OpenXml.Wordprocessing.Run(element), bookmarkStart);
        }

    }
}
