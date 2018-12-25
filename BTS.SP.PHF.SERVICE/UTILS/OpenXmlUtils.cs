using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml;
//using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Packaging;
using Word = DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Data.SqlClient;

using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;
//using DocumentFormat.OpenXml.Office2013.Drawing.ChartStyle;

namespace BTS.SP.PHF.SERVICE.UTILS
{
    public class OpenXmlUtils
    {
        private static int DefaultFontSize = 13;
        private static int DefaultFontSize_14 = 14;
        private static Word.RunProperties DefaultRunProperties(int fontSize)
        {
            return DefaultRunProperties(fontSize, false);
        }

        private static Word.RunProperties DefaultRunProperties(int fontSize, bool IsTitle)
        {
            Word.RunProperties property = new Word.RunProperties();
            FontSize fs = new FontSize();
            fs.Val = new StringValue((fontSize * 2).ToString());
            property.FontSize = fs;
            RunFonts rf = new RunFonts();
            rf.Ascii = new StringValue("Times New Roman");
            rf.HighAnsi = rf.Ascii;

            property.RunFonts = rf;
            Word.Languages lang = new Languages();
            lang.Val = "vi-VN";
            property.Languages = lang;
       
           

            if (IsTitle)
            {
                Word.Bold bold = new Bold();
                bold.Val = new OnOffValue(true);
                property.Bold = bold;
            }

            return property;
        }

        private static Word.ParagraphProperties DefaultParagraphProperties()
        {
            return DefaultParagraphProperties(false);
        }

        private static Word.ParagraphProperties DefaultParagraphProperties(bool FirsLineOnly)
        {
            Word.ParagraphProperties property = new Word.ParagraphProperties();
            StringValue sv = new StringValue("720");
            Indentation ind = new Indentation();

            if (FirsLineOnly)
                ind.FirstLine = sv;
            else
                ind.Left = sv;

            property.Indentation = ind;

            return property;
        }
        private static Word.ParagraphProperties DefaultParagraphPropertiesBlock()
        {
            Word.ParagraphProperties property = new Word.ParagraphProperties();
            StringValue sv = new StringValue("360");
            Indentation ind = new Indentation();
            ind.Left = sv;

            property.Indentation = ind;

            return property;
        }

        public static void AddTextToSdt(Word.SdtElement sdt, string text)
        {
            AddTextToSdt(sdt, text, DefaultFontSize);
        }

        public static void AddTextToSdt_Font(Word.SdtElement sdt, string text)
        {
            AddTextToSdt(sdt, text, DefaultFontSize_14);
        }

        public static void AddTextToSdt_Title(Word.SdtElement sdt, string text)
        {
            AddTextToSdt(sdt, text, true, DefaultFontSize_14);
        }

        public static void AddImageToSdt(Word.SdtElement sdt, string text, long width, long height)
        {

            if (sdt == null) return;

            // Define the reference of the image.
            var element =
                 new Drawing(
                     new DW.Inline(
                         new DW.Extent() { Cx = 1000000L, Cy = 1200000L },
                         new DW.EffectExtent()
                         {
                             //LeftEdge = 5990000L,
                             //TopEdge = 0L,
                             //RightEdge = 0L,
                             //BottomEdge = 0L
                             LeftEdge = 0L,
                             TopEdge = 0L,
                             RightEdge = 0L,
                             BottomEdge = 0L
                         },
                         new DW.DocProperties()
                         {
                             Id = (UInt32Value)1U,
                             Name = "Picture 1"
                         },
                         new DW.NonVisualGraphicFrameDrawingProperties(
                             new A.GraphicFrameLocks() { NoChangeAspect = true }),
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
                                                     Uri =
                                                       "{28A0092B-C50C-407E-A947-70E740481C1C}"
                                                 })
                                         )
                                         {
                                             Embed = text,
                                             CompressionState =
                                             A.BlipCompressionValues.Print
                                         },
                                         new A.Stretch(
                                             new A.FillRectangle())),
                                     new PIC.ShapeProperties(
                                         new A.Transform2D(
                                             new A.Offset() { X = 0L, Y = 0L },
                                             new A.Extents() { Cx = width, Cy = height }),
                                         new A.PresetGeometry(
                                             new A.AdjustValueList()
                                         ) { Preset = A.ShapeTypeValues.Rectangle }))
                             ) { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
                     )
                     {
                         DistanceFromTop = (UInt32Value)0U,
                         DistanceFromBottom = (UInt32Value)0U,
                         DistanceFromLeft = (UInt32Value)0U,
                         DistanceFromRight = (UInt32Value)0U,
                         EditId = "50D07946"
                     });

            Word.Paragraph p = new Word.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(element));
            OpenXmlElement parent = sdt.Parent;
            parent.ReplaceChild(p, sdt);
        }

        public static void AddTextToSdtWithoutFont(Word.SdtElement sdt, string text)
        {

            if (sdt == null) return;
            if (sdt is Word.SdtCell)
            {
                Word.Run nRun = new Word.Run(new Word.Text(text));
                Word.Paragraph p = new Word.Paragraph(nRun);
                OpenXmlElement parent = sdt.Parent;
                parent.ReplaceChild(p, sdt);
            }
            else if (sdt is Word.SdtRun)
            {
                Word.Run nRun = new Word.Run(new Word.Text(text));
                OpenXmlElement parent = sdt.Parent;
                parent.ReplaceChild(nRun, sdt);
            }
            else if (sdt is Word.SdtBlock)
            {
                Word.Run nRun = new Word.Run(new Word.Text(text));
                Word.Paragraph p = new Word.Paragraph(nRun);
                OpenXmlElement parent = sdt.Parent;
                parent.ReplaceChild(p, sdt);
            }

        }

        public static void AddTextToSdt(Word.SdtElement sdt, string text, int fontSize)
        {
            if (sdt == null)
            {
                Word.Run nRun = new Word.Run(new Word.TabChar());
                nRun.RunProperties = DefaultRunProperties(fontSize);
                OpenXmlElement parent = sdt.Parent;
                parent.ReplaceChild(nRun, sdt);
            }
            if (sdt is Word.SdtCell)
            {
                Word.Run nRun = new Word.Run(new Word.Text(text));
                nRun.RunProperties = DefaultRunProperties(fontSize);
                Word.Paragraph p = new Word.Paragraph(nRun);
                OpenXmlElement parent = sdt.Parent;
                parent.ReplaceChild(p, sdt);
            }
            else if (sdt is Word.SdtRun)
            {
                Word.Run nRun = new Word.Run(new Word.Text(text));
                nRun.RunProperties = DefaultRunProperties(fontSize);
                OpenXmlElement parent = sdt.Parent;
                parent.ReplaceChild(nRun, sdt);
            }
            else if (sdt is Word.SdtBlock)
            {
                Word.Run nRun = new Word.Run(new Word.Text(text));
                nRun.RunProperties = DefaultRunProperties(fontSize);
                Word.Paragraph p = new Word.Paragraph(nRun);
                OpenXmlElement parent = sdt.Parent;
                parent.ReplaceChild(p, sdt);
            }
        }
        public static void AddTabToSdt(Word.SdtElement sdt, int fontSize)
        {
            Word.Run nRun = new Word.Run(new Word.TabChar());
            nRun.RunProperties = DefaultRunProperties(fontSize);
            OpenXmlElement parent = sdt.Parent;
           
            parent.ReplaceChild(nRun, sdt);
        }
        public static void AddTextToSdt(Word.SdtElement sdt, string text, bool IsTitle, int fontSize)
        {

            if (sdt == null) return;
            if (sdt is Word.SdtCell)
            {
                Word.Run nRun = new Word.Run(new Word.Text(text + "\t"));
                nRun.RunProperties = DefaultRunProperties(fontSize, IsTitle);
                Word.Paragraph p = new Word.Paragraph(nRun);
                OpenXmlElement parent = sdt.Parent;
                parent.ReplaceChild(p, sdt);
            }
            else if (sdt is Word.SdtRun)
            {
                Word.Run nRun = new Word.Run(new Word.Text(text + "\t"));
                nRun.RunProperties = DefaultRunProperties(fontSize, IsTitle);
                OpenXmlElement parent = sdt.Parent;
                parent.ReplaceChild(nRun, sdt);
            }
            else if (sdt is Word.SdtBlock)
            {
                Word.Run nRun = new Word.Run(new Word.Text(text + "\t"));
                nRun.RunProperties = DefaultRunProperties(fontSize, IsTitle);
                Word.Paragraph p = new Word.Paragraph(nRun);
                OpenXmlElement parent = sdt.Parent;
                parent.ReplaceChild(p, sdt);
            }
        }

        public static void AddTextToSdt(Word.SdtElement sdt, string[] text)
        {
            AddTextToSdt(sdt, text, DefaultFontSize);
        }

        public static void AddTextToSdt(Word.SdtElement sdt, string[] text, int fontSize)
        {
            if (sdt == null) return;
            if (sdt is Word.SdtCell)
            {
                Word.Run nRun;
                Word.Paragraph p = new Word.Paragraph();
                for (int i = 0; i < text.Count(); i++)
                {
                    nRun = new Word.Run(new Word.Text(text[i]));
                    nRun.RunProperties = DefaultRunProperties(fontSize);
                    p.Append(nRun);
                    p.Append(new Word.Break());
                }

                OpenXmlElement parent = sdt.Parent;
                parent.ReplaceChild(p, sdt);
            }
            else if (sdt is Word.SdtRun)
            {
                //Word.SdtRun sdtxRun = (Word.SdtRun)sdt;
                //Word.SdtContentRun xContentRun = sdtxRun.Descendants<Word.SdtContentRun>().FirstOrDefault();
                //Word.Run xRun = xContentRun.Descendants<Word.Run>().FirstOrDefault();
                //xRun.RemoveAllChildren<Word.RunProperties>();
                //Word.Text xText = xRun.Descendants<Word.Text>().FirstOrDefault();
                //xText.Text = text;
            }
            else if (sdt is Word.SdtBlock)
            {
                Word.Run nRun;
                Word.Paragraph p = new Word.Paragraph();
                p.ParagraphProperties = DefaultParagraphProperties();
                for (int i = 0; i < text.Count(); i++)
                {
                    nRun = new Word.Run(new Word.Text(text[i]));
                    nRun.RunProperties = DefaultRunProperties(fontSize);
                    p.Append(nRun);
                    p.Append(new Word.Break());
                }

                OpenXmlElement parent = sdt.Parent;
                parent.ReplaceChild(p, sdt);
            }
        }

        public static void AddTextToSdtBlock(Word.SdtElement sdt, string[] text)
        {

            AddTextToSdtBlock(sdt, text, DefaultFontSize);
        }

        public static void AddTextToSdtBlock(Word.SdtElement sdt, string[] text, int fontSize)
        {
            AddTextToSdtBlock(sdt, text, false, fontSize);
        }

        public static void AddTextToSdtBlock(Word.SdtElement sdt, string[] text, bool IsTitle, int fontSize)
        {
            if (sdt == null) return;
            sdt.SdtProperties.RemoveAllChildren<Word.SdtPlaceholder>();
            Word.Run nRun;
            Word.Paragraph p = new Word.Paragraph();
            if (IsTitle)
            {
                Word.ParagraphProperties property = new Word.ParagraphProperties();
                Justification jc = new Justification();
                jc.Val = JustificationValues.Center;

                property.Justification = jc;
                p.ParagraphProperties = property;
            }
            else
                p.ParagraphProperties = DefaultParagraphProperties();

            for (int i = 0; i < text.Count(); i++)
            {
                nRun = new Word.Run(new Word.Text(text[i]));
                nRun.RunProperties = DefaultRunProperties(fontSize, IsTitle);
                p.Append(nRun);
                p.Append(new Word.Break());
            }

            OpenXmlElement parent = sdt.Parent;
            if (sdt is Word.SdtBlock) //block: replace
                parent.ReplaceChild(p, sdt);
            else //run: replace parent
            {
                sdt.Parent.InsertBeforeSelf(p);
                sdt.Remove();
            }
        }
        public static void AddTextToSdtBlock(Word.SdtElement sdt, string[] text, int fontSize, StringValue ind)
        {
            if (sdt == null) return;
            sdt.SdtProperties.RemoveAllChildren<Word.SdtPlaceholder>();
            Word.Run nRun;
            Word.Paragraph p = new Word.Paragraph();
            p.ParagraphProperties = DefaultParagraphPropertiesBlock();

            for (int i = 0; i < text.Count(); i++)
            {
                text[i] = (i + 1).ToString() + ", " + text[i] + ".";
                nRun = new Word.Run(new Word.Text(text[i]));
                nRun.RunProperties = DefaultRunProperties(fontSize);
                p.Append(nRun);
                p.Append(new Word.Break());
            }

            OpenXmlElement parent = sdt.Parent;
            if (sdt is Word.SdtBlock) //block: replace
                parent.ReplaceChild(p, sdt);
            else //run: replace parent
            {
                sdt.Parent.InsertBeforeSelf(p);
                sdt.Remove();
            }
        }
        public static void WDAddTable(string fileName, string[,] data)
        {
            using (var document = WordprocessingDocument.Open(fileName, true))
            {

                var doc = document.MainDocumentPart.Document;

                Word.Table table = new Word.Table();

                Word.TableProperties props = new Word.TableProperties(
                  new TableBorders(
                    new Word.TopBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 12
                    },
                    new Word.BottomBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 12
                    },
                    new Word.LeftBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 12
                    },
                    new Word.RightBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 12
                    },
                    new Word.InsideHorizontalBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 12
                    },
                    new Word.InsideVerticalBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 12
                    }));
                table.AppendChild<Word.TableProperties>(props);

                for (var i = 0; i <= data.GetUpperBound(0); i++)
                {
                    var tr = new Word.TableRow();
                    for (var j = 0; j <= data.GetUpperBound(1); j++)
                    {
                        var tc = new Word.TableCell();
                        tc.Append(new Word.Paragraph(new Word.Run(new Word.Text(data[i, j]))));
                        // Assume you want columns that are automatically sized.
                        tc.Append(new Word.TableCellProperties(
                          new TableCellWidth { Type = TableWidthUnitValues.Auto }));
                        tr.Append(tc);
                    }
                    table.Append(tr);
                }
                doc.Body.Append(table);
                doc.Save();
            }
        }

        public static void AddTableToSdt(Word.SdtElement sdt, System.Data.DataTable table, bool IsShowHeader)
        {
            AddTableToSdt(sdt, table, IsShowHeader, DefaultFontSize, false);
        }

        public static void AddTableToSdt(Word.SdtElement sdt, System.Data.DataTable table, bool IsShowHeader, bool withParagraphProperty)
        {
            AddTableToSdt(sdt, table, IsShowHeader, withParagraphProperty);
        }

        public static void AddTableToSdt(Word.SdtElement sdt, System.Data.DataTable table, bool IsShowHeader, int fontSize, bool withParagraphProperty)
        {
            if (sdt == null) return;
            if (table == null) return;

            ArrayList cellText = new ArrayList();
            Word.Table tbl = new Word.Table();
            Word.TableProperties tableProperties1 = new Word.TableProperties();
            Word.TableStyle tableStyle1 = new Word.TableStyle() { Val = "TableGrid" };
            Word.TableWidth tableWidth1 = new Word.TableWidth() { Width = "5000", Type = Word.TableWidthUnitValues.Pct };

            Word.TableBorders tableBorders1 = new Word.TableBorders();
            Word.TopBorder topBorder1 = new Word.TopBorder() { Val = Word.BorderValues.None, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
            Word.BottomBorder bottomBorder1 = new Word.BottomBorder() { Val = Word.BorderValues.None, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
            Word.LeftBorder leftBorder1 = new Word.LeftBorder() { Val = Word.BorderValues.None, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
            Word.RightBorder rightBorder1 = new Word.RightBorder() { Val = Word.BorderValues.None, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
            Word.InsideHorizontalBorder insideHorizontalBorder1 = new Word.InsideHorizontalBorder() { Val = Word.BorderValues.None, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
            Word.InsideVerticalBorder insideVerticalBorder1 = new Word.InsideVerticalBorder() { Val = Word.BorderValues.None, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };

            tableBorders1.Append(topBorder1);
            tableBorders1.Append(bottomBorder1);
            tableBorders1.Append(leftBorder1);
            tableBorders1.Append(rightBorder1);
            tableBorders1.Append(insideHorizontalBorder1);
            tableBorders1.Append(insideVerticalBorder1);
            Word.TableLook tableLook1 = new Word.TableLook() { Val = "04A0", FirstRow = true, LastRow = false, FirstColumn = true, LastColumn = false, NoHorizontalBand = false, NoVerticalBand = true };

            tableProperties1.Append(tableStyle1);
            tableProperties1.Append(tableWidth1);
            tableProperties1.Append(tableBorders1);
            tableProperties1.Append(tableLook1);

            tbl.Append(tableProperties1);

            //if (IsShowHeader)
            //{
            //    tbl.Append(CreateHeader(table, HeaderFileResource));
            //}

            for (int rowIndex = 0; rowIndex < table.Rows.Count; rowIndex++)
            {

                cellText.Add(Convert.ToString(table.Rows[rowIndex][0]));

                Word.TableRow tr = CreateRow(cellText, fontSize, withParagraphProperty);
                tbl.AppendChild<Word.TableRow>(tr);
                cellText = new ArrayList();
            }

            OpenXmlElement parent = sdt.Parent;
            parent.InsertAfter(tbl, sdt);
            sdt.Remove();
        }

        public static void AddTableStdNew(Word.SdtElement sdt, System.Data.DataTable _table, bool IsShowHeader, string[] Headers)
        {
            if (sdt == null) return;
            if (_table == null) return;
            // Create an empty table.
            Word.Table table = new Word.Table();

            // Create a TableProperties object and specify its border information.
            Word.TableProperties tblProp = new Word.TableProperties(
                new TableBorders(
                    new Word.TopBorder() { Val = new EnumValue<BorderValues>(BorderValues.BasicThinLines), Size = 1 },
                    new Word.BottomBorder() { Val = new EnumValue<BorderValues>(BorderValues.BasicThinLines), Size = 1 },
                    new Word.LeftBorder() { Val = new EnumValue<BorderValues>(BorderValues.BasicThinLines), Size = 1 },
                    new Word.RightBorder() { Val = new EnumValue<BorderValues>(BorderValues.BasicThinLines), Size = 1 },
                    new Word.InsideHorizontalBorder() { Val = new EnumValue<BorderValues>(BorderValues.BasicThinLines), Size = 1 },
                    new Word.InsideVerticalBorder() { Val = new EnumValue<BorderValues>(BorderValues.BasicThinLines), Size = 1 }
                )
            );

            // Append the TableProperties object to the empty table.
            table.AppendChild<Word.TableProperties>(tblProp);

            if (IsShowHeader)
            {
                table.Append(CreateNoHeader(_table, Headers));
            }

            if (_table.Rows.Count > 0)
            {
                for (int i = 0; i < _table.Rows.Count; i++)
                {

                    // Create a row.
                    Word.TableRow tr = new Word.TableRow();

                    for (int j = 0; j < _table.Columns.Count; j++)
                    {
                        // Create a cell.
                        Word.TableCell tc1 = new Word.TableCell();

                        // Specify the width property of the table cell.
                        tc1.Append(new Word.TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));

                        // Specify the table cell content.
                        if (_table.Rows[i][j] != DBNull.Value)
                            tc1.Append(new Word.Paragraph(new Word.Run(new Word.Text(Convert.ToString(_table.Rows[i][j])))));
                        else
                            // Specify the table cell content.
                            tc1.Append(new Word.Paragraph(new Word.Run(new Word.Text(""))));

                        // Append the table cell to the table row.
                        tr.Append(tc1);
                    }
                    table.Append(tr);

                }

            }
            OpenXmlElement parent = sdt.Parent;
            parent.InsertAfter(table, sdt);
            sdt.Remove();


        }

        public static void AddTableStdNew(Word.SdtElement sdt, System.Data.DataTable _table, bool IsShowHeader, string[] Headers, string wTable)
        {
            if (sdt == null) return;
            if (_table == null) return;
            // Create an empty table.
            Word.Table table = new Word.Table();

            // Create a TableProperties object and specify its border information.
            Word.TableProperties tblProp = new Word.TableProperties(
                new TableBorders(
                    new Word.TopBorder() { Val = new EnumValue<BorderValues>(BorderValues.BasicThinLines), Size = 1 },
                    new Word.BottomBorder() { Val = new EnumValue<BorderValues>(BorderValues.BasicThinLines), Size = 1 },
                    new Word.LeftBorder() { Val = new EnumValue<BorderValues>(BorderValues.BasicThinLines), Size = 1 },
                    new Word.RightBorder() { Val = new EnumValue<BorderValues>(BorderValues.BasicThinLines), Size = 1 },
                    new Word.InsideHorizontalBorder() { Val = new EnumValue<BorderValues>(BorderValues.BasicThinLines), Size = 1 },
                    new Word.InsideVerticalBorder() { Val = new EnumValue<BorderValues>(BorderValues.BasicThinLines), Size = 1 }
                )
            );

            // Append the TableProperties object to the empty table.
            table.AppendChild<Word.TableProperties>(tblProp);

            if (IsShowHeader)
            {
                table.Append(CreateNoHeader(_table, Headers));
            }

            if (_table.Rows.Count > 0)
            {
                for (int i = 0; i < _table.Rows.Count; i++)
                {

                    // Create a row.
                    Word.TableRow tr = new Word.TableRow();

                    for (int j = 0; j < _table.Columns.Count; j++)
                    {
                        // Create a cell.
                        Word.TableCell tc1 = new Word.TableCell();

                        // Specify the width property of the table cell.
                        tc1.Append(new Word.TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = wTable }));

                        // Specify the table cell content.
                        if (_table.Rows[i][j] != DBNull.Value)
                            tc1.Append(new Word.Paragraph(new Word.Run(new Word.Text(Convert.ToString(_table.Rows[i][j])))));
                        else
                            // Specify the table cell content.
                            tc1.Append(new Word.Paragraph(new Word.Run(new Word.Text(""))));

                        // Append the table cell to the table row.
                        tr.Append(tc1);
                    }
                    table.Append(tr);

                }

            }
            OpenXmlElement parent = sdt.Parent;
            parent.InsertAfter(table, sdt);
            sdt.Remove();


        }

        public static void AddTableToSdt(Word.SdtElement sdt, System.Data.DataTable table, bool IsShowHeader, string HeaderFileResource)
        {
            if (sdt == null) return;
            if (table == null) return;

            ArrayList cellText = new ArrayList();
            Word.Table tbl = new Word.Table();
            Word.TableProperties tableProperties1 = new Word.TableProperties();
            Word.TableStyle tableStyle1 = new Word.TableStyle() { Val = "TableGrid" };
            Word.TableWidth tableWidth1 = new Word.TableWidth() { Width = "5000", Type = Word.TableWidthUnitValues.Pct };

            Word.TableBorders tableBorders1 = new Word.TableBorders();
            Word.TopBorder topBorder1 = new Word.TopBorder() { Val = Word.BorderValues.Single, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
            Word.LeftBorder leftBorder1 = new Word.LeftBorder() { Val = Word.BorderValues.Single, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
            Word.RightBorder rightBorder1 = new Word.RightBorder() { Val = Word.BorderValues.Single, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
            Word.InsideHorizontalBorder insideHorizontalBorder1 = new Word.InsideHorizontalBorder() { Val = Word.BorderValues.Single, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
            Word.InsideVerticalBorder insideVerticalBorder1 = new Word.InsideVerticalBorder() { Val = Word.BorderValues.Single, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };

            tableBorders1.Append(topBorder1);
            tableBorders1.Append(leftBorder1);
            tableBorders1.Append(rightBorder1);
            tableBorders1.Append(insideHorizontalBorder1);
            tableBorders1.Append(insideVerticalBorder1);
            Word.TableLook tableLook1 = new Word.TableLook() { Val = "04A0", FirstRow = true, LastRow = false, FirstColumn = true, LastColumn = false, NoHorizontalBand = false, NoVerticalBand = true };

            tableProperties1.Append(tableStyle1);
            tableProperties1.Append(tableWidth1);
            tableProperties1.Append(tableBorders1);
            tableProperties1.Append(tableLook1);

            tbl.Append(tableProperties1);

            if (IsShowHeader)
            {
                tbl.Append(CreateHeader(table, HeaderFileResource));
            }

            for (int rowIndex = 0; rowIndex < table.Rows.Count; rowIndex++)
            {
                for (int cellIndex = 0; cellIndex < table.Columns.Count; cellIndex++)
                {
                    cellText.Add(Convert.ToString(table.Rows[rowIndex][cellIndex]));
                }

                Word.TableRow tr = CreateRow(cellText);
                tbl.AppendChild<Word.TableRow>(tr);
                cellText = new ArrayList();
            }

            OpenXmlElement parent = sdt.Parent;
            parent.InsertAfter(tbl, sdt);
            sdt.Remove();
        }

        public static void AddTableToSdtNoHeader(Word.SdtElement sdt, System.Data.DataTable table, bool IsShowHeader, string[] Headers)
        {
            AddTableToSdtNoHeader(sdt, table, IsShowHeader, Headers, DefaultFontSize);
        }

        public static void AddTableToSdtNoHeader(Word.SdtElement sdt, System.Data.DataTable table, bool IsShowHeader, string[] Headers, int fontSize)
        {
            if (sdt == null) return;
            if (table == null) return;

            ArrayList cellText = new ArrayList();
            Word.Table tbl = new Word.Table();
            Word.TableProperties tableProperties1 = new Word.TableProperties();
            Word.TableStyle tableStyle1 = new Word.TableStyle() { Val = "TableGrid" };
            Word.TableWidth tableWidth1 = new Word.TableWidth() { Width = "5000", Type = Word.TableWidthUnitValues.Pct };

            Word.TableBorders tableBorders1 = new Word.TableBorders();
            Word.TopBorder topBorder1 = new Word.TopBorder() { Val = Word.BorderValues.Single, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
            Word.BottomBorder bottomBorder1 = new Word.BottomBorder() { Val = Word.BorderValues.Single, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
            Word.LeftBorder leftBorder1 = new Word.LeftBorder() { Val = Word.BorderValues.Single, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
            Word.RightBorder rightBorder1 = new Word.RightBorder() { Val = Word.BorderValues.Single, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
            Word.InsideHorizontalBorder insideHorizontalBorder1 = new Word.InsideHorizontalBorder() { Val = Word.BorderValues.Single, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
            Word.InsideVerticalBorder insideVerticalBorder1 = new Word.InsideVerticalBorder() { Val = Word.BorderValues.Single, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };

            tableBorders1.Append(topBorder1);
            tableBorders1.Append(bottomBorder1);
            tableBorders1.Append(leftBorder1);
            tableBorders1.Append(rightBorder1);
            tableBorders1.Append(insideHorizontalBorder1);
            tableBorders1.Append(insideVerticalBorder1);
            Word.TableLook tableLook1 = new Word.TableLook() { Val = "04A0", FirstRow = true, LastRow = true, FirstColumn = true, LastColumn = true, NoHorizontalBand = false, NoVerticalBand = true };

            tableProperties1.Append(tableStyle1);
            tableProperties1.Append(tableWidth1);
            tableProperties1.Append(tableBorders1);
            tableProperties1.Append(tableLook1);
            //TableIndentation ti = new TableIndentation();
            //ti.Width = 120;
            //tableProperties1.TableIndentation = ti;
            //tableProperties1

            tbl.Append(tableProperties1);

            if (IsShowHeader)
            {
                tbl.Append(CreateNoHeader(table, Headers, fontSize));
            }

            RunStyle rs = new RunStyle();
            for (int rowIndex = 0; rowIndex < table.Rows.Count; rowIndex++)
            {
                for (int cellIndex = 0; cellIndex < table.Columns.Count; cellIndex++)
                {
                    cellText.Add(Convert.ToString(table.Rows[rowIndex][cellIndex]));
                }

                Word.TableRow tr = CreateRow(cellText, fontSize);
                tbl.AppendChild<Word.TableRow>(tr);
                cellText = new ArrayList();
            }

            OpenXmlElement parent = sdt.Parent;
            parent.InsertAfter(tbl, sdt);
            sdt.Remove();
        }

        public static void AddTableToSdtNoHeader(Word.SdtElement sdt, System.Data.DataTable table, bool IsShowHeader, string[] Headers, int fontSize, bool bold, bool width)
        {
            if (sdt == null) return;
            if (table == null) return;

            ArrayList cellText = new ArrayList();
            Word.Table tbl = new Word.Table();
            Word.TableProperties tableProperties1 = new Word.TableProperties();
            Word.TableStyle tableStyle1 = new Word.TableStyle() { Val = "TableGrid" };
            Word.TableWidth tableWidth1 = new Word.TableWidth() { Width = "5000", Type = Word.TableWidthUnitValues.Pct };

            Word.TableBorders tableBorders1 = new Word.TableBorders();
            Word.TopBorder topBorder1 = new Word.TopBorder() { Val = Word.BorderValues.Single, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
            Word.BottomBorder bottomBorder1 = new Word.BottomBorder() { Val = Word.BorderValues.Single, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
            Word.LeftBorder leftBorder1 = new Word.LeftBorder() { Val = Word.BorderValues.Single, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
            Word.RightBorder rightBorder1 = new Word.RightBorder() { Val = Word.BorderValues.Single, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
            Word.InsideHorizontalBorder insideHorizontalBorder1 = new Word.InsideHorizontalBorder() { Val = Word.BorderValues.Single, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
            Word.InsideVerticalBorder insideVerticalBorder1 = new Word.InsideVerticalBorder() { Val = Word.BorderValues.Single, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
             

            tableBorders1.Append(topBorder1);
            tableBorders1.Append(bottomBorder1);
            tableBorders1.Append(leftBorder1);
            tableBorders1.Append(rightBorder1);
            tableBorders1.Append(insideHorizontalBorder1);
            tableBorders1.Append(insideVerticalBorder1);
            Word.TableLook tableLook1 = new Word.TableLook() { Val = "04A0", FirstRow = true, LastRow = true, FirstColumn = true, LastColumn = true, NoHorizontalBand = false, NoVerticalBand = true };

            tableProperties1.Append(tableStyle1);
            tableProperties1.Append(tableWidth1);
            tableProperties1.Append(tableBorders1);
            tableProperties1.Append(tableLook1);
            //TableIndentation ti = new TableIndentation();
            //ti.Width = 120;
            //tableProperties1.TableIndentation = ti;
            //tableProperties1

            tbl.Append(tableProperties1);

            if (IsShowHeader)
            {
                tbl.Append(CreateNoHeader(table, Headers, fontSize, bold));
            }

            RunStyle rs = new RunStyle();
            if (bold)
            {
                for (int rowIndex = 0; rowIndex < table.Rows.Count; rowIndex++)
                {
                    for (int cellIndex = 0; cellIndex < table.Columns.Count; cellIndex++)
                    {
                        cellText.Add(Convert.ToString(table.Rows[rowIndex][cellIndex]));
                    }
                    if (width)
                    {
                        Word.TableRow tr = CreateRowWidthCell(cellText, fontSize);
                        tbl.AppendChild<Word.TableRow>(tr);
                        cellText = new ArrayList();
                    }
                    else
                    {
                        Word.TableRow tr = CreateRow(cellText, fontSize);
                        tbl.AppendChild<Word.TableRow>(tr);
                        cellText = new ArrayList();
                    }
                }
            }
            else
            {
                for (int rowIndex = 0; rowIndex < table.Rows.Count; rowIndex++)
                {
                    for (int cellIndex = 0; cellIndex < table.Columns.Count; cellIndex++)
                    {
                        cellText.Add(Convert.ToString(table.Rows[rowIndex][cellIndex]));
                    }

                    Word.TableRow tr = CreateRowVertical(cellText, fontSize);
                    tbl.AppendChild<Word.TableRow>(tr);
                    cellText = new ArrayList();
                }

            }

            OpenXmlElement parent = sdt.Parent;
            parent.InsertAfter(tbl, sdt);
            sdt.Remove();
        }
       
        public static void AddTableToSdtNoHeader(MainDocumentPart mainPart, Word.SdtElement sdt, System.Data.DataTable table, bool IsShowHeader, string[] Headers)
        {
            if (sdt == null) return;
            if (table == null) return;

            ArrayList cellText = new ArrayList();
            Word.Table tbl = new Word.Table();
            Word.TableProperties tableProperties1 = new Word.TableProperties();
            Word.TableStyle tableStyle1 = new Word.TableStyle() { Val = "TableGrid" };
            Word.TableWidth tableWidth1 = new Word.TableWidth() { Width = "4500", Type = Word.TableWidthUnitValues.Pct };

            Word.TableBorders tableBorders1 = new Word.TableBorders();
            Word.TopBorder topBorder1 = new Word.TopBorder() { Val = Word.BorderValues.Single, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
            Word.LeftBorder leftBorder1 = new Word.LeftBorder() { Val = Word.BorderValues.Single, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
            Word.RightBorder rightBorder1 = new Word.RightBorder() { Val = Word.BorderValues.Single, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
            Word.InsideHorizontalBorder insideHorizontalBorder1 = new Word.InsideHorizontalBorder() { Val = Word.BorderValues.Single, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
            Word.InsideVerticalBorder insideVerticalBorder1 = new Word.InsideVerticalBorder() { Val = Word.BorderValues.Single, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };

            tableBorders1.Append(topBorder1);
            tableBorders1.Append(leftBorder1);
            tableBorders1.Append(rightBorder1);
            tableBorders1.Append(insideHorizontalBorder1);
            tableBorders1.Append(insideVerticalBorder1);
            Word.TableLook tableLook1 = new Word.TableLook() { Val = "04A0", FirstRow = true, LastRow = false, FirstColumn = true, LastColumn = false, NoHorizontalBand = false, NoVerticalBand = true };

            tableProperties1.Append(tableStyle1);
            tableProperties1.Append(tableWidth1);
            tableProperties1.Append(tableBorders1);
            tableProperties1.Append(tableLook1);

            tbl.Append(tableProperties1);

            if (IsShowHeader)
            {
                tbl.Append(CreateNoHeader(table, Headers));
            }

            Word.Run xRun;
            RunStyle rs = new RunStyle();

            DocDefaults defaults = mainPart.StyleDefinitionsPart.Styles.Descendants<DocDefaults>().FirstOrDefault();
            //get the font size
            string fontSize = defaults.RunPropertiesDefault.RunPropertiesBaseStyle.FontSize.Val;
            string fontAscii = defaults.RunPropertiesDefault.RunPropertiesBaseStyle.RunFonts.Ascii.Value;
            //get the font prob. (Ascii, HAnsi, ComplexScript,...etc)
            RunFonts runFont = defaults.RunPropertiesDefault.RunPropertiesBaseStyle.RunFonts;

            for (int rowIndex = 0; rowIndex < table.Rows.Count; rowIndex++)
            {
                for (int cellIndex = 0; cellIndex < table.Columns.Count; cellIndex++)
                {
                    xRun = new Word.Run();

                    cellText.Add(Convert.ToString(table.Rows[rowIndex][cellIndex]));
                }

                Word.TableRow tr = CreateRow(cellText);
                tbl.AppendChild<Word.TableRow>(tr);
                cellText = new ArrayList();
            }

            OpenXmlElement parent = sdt.Parent;
            parent.InsertAfter(tbl, sdt);
            sdt.Remove();
        }

        //public static void WDAddTable(string fileName, string[,] data)
        //{
        //    //string[,] data = null;
        //    //if (_table.Rows.Count > 0)
        //    //{
        //    //    data = new string[_table.Rows.Count,_table.Columns.Count]();
        //    //    for (int i = 0; i < _table.Rows.Count; i++)
        //    //    {
        //    //        for (int j = 0; j < _table.Columns.Count; j++)
        //    //        {
        //    //            data[i, j] = Convert.ToString(_table.Rows[i][j]);
        //    //        }
        //    //    }
        //    //}

        //    using (var document = WordprocessingDocument.Open(fileName, true))
        //    {

        //        var doc = document.MainDocumentPart.Document;

        //        Table table = new Table();

        //        TableProperties props = new TableProperties(
        //          new TableBorders(
        //            new TopBorder
        //            {
        //                Val = new EnumValue<BorderValues>(BorderValues.Single),
        //                Size = 12
        //            },
        //            new BottomBorder
        //            {
        //                Val = new EnumValue<BorderValues>(BorderValues.Single),
        //                Size = 12
        //            },
        //            new LeftBorder
        //            {
        //                Val = new EnumValue<BorderValues>(BorderValues.Single),
        //                Size = 12
        //            },
        //            new RightBorder
        //            {
        //                Val = new EnumValue<BorderValues>(BorderValues.Single),
        //                Size = 12
        //            },
        //            new InsideHorizontalBorder
        //            {
        //                Val = new EnumValue<BorderValues>(BorderValues.Single),
        //                Size = 12
        //            },
        //            new InsideVerticalBorder
        //            {
        //                Val = new EnumValue<BorderValues>(BorderValues.Single),
        //                Size = 12
        //            }));

        //        table.AppendChild<TableProperties>(props);

        //        for (var i = 0; i <= data.GetUpperBound(0); i++)
        //        {
        //            var tr = new TableRow();
        //            for (var j = 0; j <= data.GetUpperBound(1); j++)
        //            {
        //                var tc = new TableCell();
        //                tc.Append(new Paragraph(new Run(new Text(data[i, j]))));
        //                // Assume you want columns that are automatically sized.
        //                tc.Append(new TableCellProperties(
        //                  new TableCellWidth { Type = TableWidthUnitValues.Auto }));
        //                tr.Append(tc);
        //            }
        //            table.Append(tr);
        //        }
        //        doc.Body.Append(table);
        //        doc.Save();
        //    }
        //}

        protected static Word.TableRow CreateNoHeader(System.Data.DataTable table, string[] headerResource)
        {
            return CreateNoHeader(table, headerResource, DefaultFontSize);
        }

        protected static Word.TableRow CreateNoHeader(System.Data.DataTable table, string[] headerResource, int fontSize)
        {
            Word.TableRow tableHeader = new Word.TableRow();
            // Create a TableProperties object and specify its border information.

            for (int i = 0; i < table.Columns.Count; i++)
            {
                DataColumn column = table.Columns[i];
                if (headerResource[i] != null)
                {
                    Word.Run nRun = new Word.Run(new Word.Text(headerResource[i]));
                    nRun.RunProperties = DefaultRunProperties(fontSize);
                    Word.TableCell tc = new Word.TableCell();
                    tc.AppendChild(new Word.Paragraph(nRun));
                    tableHeader.AppendChild(tc);

                    TableRowProperties trp = new TableRowProperties();

                }
            }


            return tableHeader;
        }

        protected static Word.TableRow CreateNoHeader(System.Data.DataTable table, string[] headerResource, int fontSize, bool bold)
        {
            Word.TableRow tableHeader = new Word.TableRow();
            // Create a TableProperties object and specify its border information.

            for (int i = 0; i < table.Columns.Count; i++)
            {
                DataColumn column = table.Columns[i];
                if (headerResource[i] != null)
                {
                    Bold boldHeader = new Bold() { Val = false };
                    Word.Run nRun = new Word.Run(new Word.Text(headerResource[i]));
                    nRun.RunProperties = DefaultRunProperties(fontSize);
                    
                    Word.TableCell tc = new Word.TableCell();
                    tc.AppendChild(new Word.Paragraph(nRun));
                    if (bold == true)
                        nRun.RunProperties.AppendChild(boldHeader);
                    tableHeader.AppendChild(tc);

                    TableRowProperties trp = new TableRowProperties();
                }
            }


            return tableHeader;
        }

        protected static Word.TableRow CreateHeader(System.Data.DataTable table, string headerResource)
        {
            Word.TableRow tableHeader = new Word.TableRow();
            foreach (DataColumn column in table.Columns)
            {
                Word.TableCell tc = new Word.TableCell();
                tc.AppendChild(
                    new Word.Paragraph(
                        new Word.Run(
                            new Word.Text(
                                headerResource))));
                tableHeader.AppendChild(tc);
            }

            return tableHeader;
        }

        protected static Word.TableRow CreateRow(ArrayList cellText)
        {
            return CreateRow(cellText, DefaultFontSize);
        }

        protected static Word.TableRow CreateRow(ArrayList cellText, bool withParagraphProperty)
        {
            if (withParagraphProperty)
                return CreateRow(cellText, DefaultFontSize, true);
            else
                return CreateRow(cellText, DefaultFontSize, false);
        }

        protected static Word.TableRow CreateRow(ArrayList cellText, int fontSize)
        {
            return CreateRow(cellText, fontSize, false);
        }

        protected static Word.TableRow CreateRow(ArrayList cellText, int fontSize, bool withParagraphProperty)
        {
            Word.TableRow tr = new Word.TableRow();
            //create cells with simple text 
            foreach (string s in cellText)
            {
                Word.TableCell tc = new Word.TableCell();
                Word.Paragraph p = new Word.Paragraph();
                if (withParagraphProperty)
                    p.ParagraphProperties = DefaultParagraphProperties(true);
                Word.Run r = new Word.Run();
                r.RunProperties = DefaultRunProperties(fontSize);
                Word.Text t = new Word.Text(s);
                r.AppendChild(t);
                p.AppendChild(r);
                tc.AppendChild(p);
                tr.AppendChild(tc);
            }

            return tr;
        }
        protected static Word.TableRow CreateRowWidthCell(ArrayList cellText, int fontSize)
        {
            Word.TableRow tr = new Word.TableRow();
            //create cells with simple text 
            int i = 0;
            foreach (string s in cellText)
            {
                Word.TableCell tc = new Word.TableCell();
                Word.Paragraph p = new Word.Paragraph();
                Word.TableCellWidth tbC = new TableCellWidth() { Width = "900", Type = TableWidthUnitValues.Pct };
                Word.Run r = new Word.Run();
                r.RunProperties = DefaultRunProperties(fontSize);
                Word.Text t = new Word.Text(s);
                r.AppendChild(t);
                p.AppendChild(r);
                tc.AppendChild(p);
                if (i == 0 || i == 1)
                    tc.AppendChild(tbC);
                i++;
                tr.AppendChild(tc);
            }

            return tr;
        }
        protected static Word.TableRow CreateRowVertical(ArrayList cellText, int fontSize)
        {
            Word.TableRow tr = new Word.TableRow();
            //create cells with simple text
            int i = 0;
            foreach (string s in cellText)
            {
                Word.TableCell tc = new Word.TableCell();
                Word.TableCellProperties tcp = new Word.TableCellProperties();
                Word.Paragraph p = new Word.Paragraph();
                Word.Run r = new Word.Run();
                Bold boldHeader = new Bold() { Val = false };
                r.RunProperties = DefaultRunProperties(fontSize);
                if (i == 0)
                {
                    r.RunProperties.Bold = boldHeader;
                    tcp.TableCellWidth = new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "1500" };
                    tc.Append(tcp);
                }
                i++;
                Word.Text t = new Word.Text(s);
                r.AppendChild(t);
                p.AppendChild(r);
                tc.AppendChild(p);
                tr.AppendChild(tc);
            }

            return tr;
        }

        public static Word.SdtElement WDGetContentControl(MainDocumentPart mainPart, string contentControlAlias)
        {
            Word.SdtElement control = null;

            // Find the first content control whose Alias property
            // matches the supplied name.
            foreach (Word.SdtElement sdt in mainPart.Document.Descendants<Word.SdtElement>())
            {
                var alias = sdt.Descendants<Word.SdtAlias>().FirstOrDefault();
                if ((alias != null) && (alias.Val != null) &&
                  (alias.Val.HasValue) && (alias.Val.Value == contentControlAlias))
                {
                    control = sdt;
                    break;
                }
            }
            return control;
        }
    }
    //public partial class Utils
    //{
    //    /// <summary>
    //    /// Convert url title
    //    /// </summary>
    //    /// <param name="name"></param>
    //    /// <returns></returns>
    //    public static string ConvertToUrlTitle(string name)
    //    {
    //        string strNewName = name;

    //        #region Replace unicode chars
    //        Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
    //        string temp = name.Normalize(NormalizationForm.FormD);
    //        strNewName = regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
    //        #endregion

    //        #region Replace special chars
    //        string strSpecialString = "~\"“”#%&*:;<>?/\\{|}.+_@$^()[]`,!-'";

    //        foreach (char c in strSpecialString.ToCharArray())
    //        {
    //            strNewName = strNewName.Replace(c, ' ');
    //        }
    //        #endregion

    //        #region Replace space

    //        // Create the Regex.
    //        var r = new Regex(@"\s+");
    //        // Strip multiple spaces.
    //        strNewName = r.Replace(strNewName, @" ").Replace(" ", "-").Trim('-');

    //        #endregion)

    //        return strNewName;
    //    }
    //}
}
