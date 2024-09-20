using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using A = DocumentFormat.OpenXml.Drawing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;
namespace Terenski_zapisnik.Models
{
    public class ProjectModel
    {
        public static string ProjectName { get; set; }

        public static string Kupac { get; set; }

        public static string Lokacija { get; set; }

        public static string RadniNalog { get; set; }

        public static string Datum { get; set; }
        //public static DateTime Datum { get; set; }

        public static string Ispitivac { get; set; }

        public static string Voditelj { get; set; }

        public static void InputError(string name)
        {
            MessageBox.Show($"Krivi unos za {name}", "Krivi unos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void RunError(string text)
        {
            MessageBox.Show($"{text}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void Ispis()
        {
            // Replace "YourTemplatePath.docx" with the path to your Word template
            //string templatePath = "Template.docx";
            string templatePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Template.docx");

            //string templatePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img", "Template.docx");

            try
            {
                //dionicaoutput
                using (WordprocessingDocument templateDoc = WordprocessingDocument.Open(templatePath, true))
                {
                    // Show the save file dialog to get the output path from the user
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Word Documents (*.docx)|*.docx";
                        saveFileDialog.Title = "Save As";
                        saveFileDialog.FileName = "OutputDocument";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string outputPath = saveFileDialog.FileName;

                            // Clone the template document to create a new one
                            using (WordprocessingDocument outputDoc = templateDoc.Clone(outputPath))
                            {
                                ReplaceTextAtBookmark(outputDoc, "Kupac", Kupac);
                                ReplaceTextAtBookmark(outputDoc, "Lokacija", Lokacija);
                                ReplaceTextAtBookmark(outputDoc, "RadniNalog", RadniNalog);
                                ReplaceTextAtBookmark(outputDoc, "Datum", Datum);
                                //ReplaceTextAtBookmark(outputDoc, "Datum", Datum.ToString("dd.MM.yyyy"));

                                //Dionica

                                for (int i = 0; i < Dionice.dionice.Count; i++)
                                {
                                    ReplaceTextAtBookmark(outputDoc, $"RedniBr{i}", $"{i + 1}.");
                                    ReplaceTextAtBookmark(outputDoc, $"Oplosje{i}", Math.Round(Dionice.dionice[i].DionicaModel.OmocenoOplosje, 2).ToString());
                                    ReplaceTextAtBookmark(outputDoc, $"Vdop{i}", Math.Round(Dionice.dionice[i].DionicaModel.Vdopusteno, 2).ToString());
                                    ReplaceTextAtBookmark(outputDoc, $"VrijemePoc{i}", Dionice.dionice[i].DionicaModel.StartTime);
                                    ReplaceTextAtBookmark(outputDoc, $"VrijemeEnd{i}", Dionice.dionice[i].DionicaModel.EndTime);
                                    ReplaceTextAtBookmark(outputDoc, $"VIzmj{i}", Dionice.dionice[i].DionicaModel.VIzmjereno.ToString());
                                    ReplaceTextAtBookmark(outputDoc, $"VIzmjereno{i}", Dionice.dionice[i].DionicaModel.VIzmjereno.ToString());
                                    ReplaceTextAtBookmark(outputDoc, $"IspitniTlak{i}", Dionice.dionice[i].DionicaModel.IspitniTlak.ToString());


                                    if (Dionice.dionice[i].DionicaModel.VIzmjereno <= Dionice.dionice[i].DionicaModel.Vdopusteno)
                                    {
                                        ReplaceTextAtBookmark(outputDoc, $"Y{i}", "X");
                                        ReplaceTextAtBookmark(outputDoc, $"N{i}", "");
                                    }
                                    else
                                    {
                                        ReplaceTextAtBookmark(outputDoc, $"Y{i}", "");
                                        ReplaceTextAtBookmark(outputDoc, $"N{i}", "X");
                                    }

                                    //if (Image != null)
                                    //{
                                    ReplaceBookmarkWithImage(outputDoc, $"ImageBookmark{i}", Dionice.dionice[i].DionicaModel.Image);
                                    //}

                                    ReplaceTextAtBookmark(outputDoc, $"DionicaInfo{i}", $"{Dionice.dionice[i].DionicaModel.DionicaNaziv}, {Dionice.dionice[i].DionicaModel.DionicaMaterijal}, {Dionice.dionice[i].DionicaModel.DionicaPromjer}");
                                    //ReplaceTextAtBookmark(outputDoc, "Bookmark2", "Text for Bookmark2");
                                }


                                Console.WriteLine($"Document saved successfully to: {outputPath}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        #region Helpers
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



        #region old
        private static void ReplaceBookmarkWithImage(WordprocessingDocument doc, string bookmarkName, System.Drawing.Image image)
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

        public static void InsertImageIntoBookmark(WordprocessingDocument doc, BookmarkStart bookmarkStart, System.Drawing.Image image)
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

            //double ratio = image.Width / image.Height;

            //AddImageToBody(doc.MainDocumentPart.GetIdOfPart(imagePart), bookmarkStart, 2700000L, 2692800L);

            //double ratio = (double)image.Width / image.Height;
            //long constantWidth = 2700000L; // Your constant width value

            //// Calculate the width based on the aspect ratio
            //long calculatedWidth = (long)(constantWidth * ratio);

            //AddImageToBody(doc.MainDocumentPart.GetIdOfPart(imagePart), bookmarkStart, calculatedWidth, 2692800L);

            double ratio = (double)image.Width / image.Height;
            long constantWidth = 2700000L;
            long constantHeight = 2692800L;

            // Calculate the width based on the aspect ratio
            long calculatedWidth = (long)(constantWidth * ratio);

            if (calculatedWidth > constantWidth)
            {
                calculatedWidth = constantWidth;
                long calculatedHeight = (long)(calculatedWidth / ratio);

                AddImageToBody(doc.MainDocumentPart.GetIdOfPart(imagePart), bookmarkStart, calculatedWidth, calculatedHeight);
            }
            else
            {
                AddImageToBody(doc.MainDocumentPart.GetIdOfPart(imagePart), bookmarkStart, calculatedWidth, constantHeight);
            }
        }

        public static ImagePart AddImagePart(MainDocumentPart mainPart, System.Drawing.Image image)
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

        private static void AddImageToBody(string relationshipId, BookmarkStart bookmarkStart, Int64Value Cx, Int64Value Cy)
        {
            // Define the reference of the image.
            var element =
                new Drawing(
                    new DW.Inline(
                        new DW.Extent()
                        {
                            //Cx = 2700000L,
                            //Cy = 2692800L
                            Cx = Cx,
                            Cy = Cy
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
                                        new A.Transform2D(new A.Offset() { X = 0L, Y = 0L }, new A.Extents() { Cx = Cx, Cy = Cy }),
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

        #endregion







        #endregion




    }
}
