using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode;
using System.Drawing.Printing;
using System.IO;
using System.Net.Http.Headers;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace qrcodegen
{
    public partial class MainWindow : Form
    {
        private static string Path { get; set; }
        public static List<string> ThStrings = new List<string>();

        public static List<Bitmap> Bitmaps = new List<Bitmap>();

        private string documentContents;
        private string stringToPrint;
        public MainWindow()
        {
            InitializeComponent();
            tbWay.Text = @"C:\Users\%USERPROFILE%\Desktop\Stack.xlsx";
            Path = tbWay.Text;
        }

        private void btnCreateQR_Click(object sender, EventArgs e)
        {
            try
            {
                string qrtext = tbInputField.Text;
                QRCodeEncoder encoder = new QRCodeEncoder();
                Bitmap qrcode = encoder.Encode(qrtext);
                pbQRCodePic.Image = qrcode as Image;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnSaveQR_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbInputField.Text == null)
                {
                    MessageBox.Show("Создайте QR код");
                    return;
                }
                if (pbQRCodePic.Image == null)
                {
                    MessageBox.Show("Введите текст");
                    return;
                }
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PNG|*.png|JPEG|*.jpg|GIF|*.gif|BMP|*.bmp";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    pbQRCodePic.Image.Save(save.FileName);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            try
            {
                FileDialog fileDialog = new OpenFileDialog();
                fileDialog.Filter = "XLSX|*.xlsx|XLS|*.xls";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = fileDialog.FileName;
                    Path = path;
                    tbWay.Text = path;
                    //MessageBox.Show("It's ok");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(pbQRCodePic.Image, 0, 0);
        }
        public void Print()
        {
            try
            {
                int count = 0;
                int width = 256, height = 256;
                var jpg = new Bitmap(width, height);
                using (var g = Graphics.FromImage(jpg))
                {
                    foreach (var bitmap in Bitmaps)
                    {
                        count++;
                        height = bitmap.Height;
                        width = bitmap.Width;
                        g.DrawImage(bitmap, 0, 0);
                        jpg.Save($"{count}.bmp");
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }


        void Document_PrintPage(object sender, PrintPageEventArgs eventArgs)
        {
            foreach (var picture in Bitmaps)
            {
                eventArgs.Graphics.DrawImage(picture, 0, 0);
                var height = picture.Height;
                var width = picture.Width;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            ReadExcelFile();
            WriteFile();
            GroupGenerate();
            Print();
            Cleaner();
        }

        void Cleaner()
        {
            try
            {
                ThStrings.Clear();
                Bitmaps.Clear();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }
        static void ReadExcelFile()
        {
            try
            {
                //Lets open the existing excel file and read through its content . Open the excel using openxml sdk
                using (SpreadsheetDocument doc = SpreadsheetDocument.Open(Path, false))
                {
                    //create the object for workbook part  
                    WorkbookPart workbookPart = doc.WorkbookPart;
                    Sheets thesheetcollection = workbookPart.Workbook.GetFirstChild<Sheets>();
                    StringBuilder excelResult = new StringBuilder();

                    //using for each loop to get the sheet from the sheetcollection  
                    foreach (Sheet thesheet in thesheetcollection)
                    {
                        //excelResult.AppendLine("Excel Sheet Name : " + thesheet.Name);
                        //excelResult.AppendLine("----------------------------------------------- ");
                        //statement to get the worksheet object by using the sheet id  
                        Worksheet theWorksheet = ((WorksheetPart)workbookPart.GetPartById(thesheet.Id)).Worksheet;

                        SheetData thesheetdata = (SheetData)theWorksheet.GetFirstChild<SheetData>();
                        foreach (Row thecurrentrow in thesheetdata)
                        {
                            foreach (Cell thecurrentcell in thecurrentrow)
                            {
                                //statement to take the integer value  
                                string currentcellvalue = string.Empty;
                                if (thecurrentcell.DataType != null)
                                {
                                    if (thecurrentcell.DataType == CellValues.SharedString)
                                    {
                                        int id;
                                        if (Int32.TryParse(thecurrentcell.InnerText, out id))
                                        {
                                            SharedStringItem item = workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(id);
                                            if (item.Text != null)
                                            {
                                                //code to take the string value  
                                                excelResult.Append(item.Text.Text + " ");
                                                ThStrings.Add(item.Text.Text);
                                            }
                                            else if (item.InnerText != null)
                                            {
                                                currentcellvalue = item.InnerText;
                                            }
                                            else if (item.InnerXml != null)
                                            {
                                                currentcellvalue = item.InnerXml;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    excelResult.Append(Convert.ToInt16(thecurrentcell.InnerText) + " ");
                                }
                            }
                            excelResult.AppendLine();
                        }
                        excelResult.Append("");
                        //Console.WriteLine(excelResult.ToString());
                        //MessageBox.Show(excelResult.ToString());
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }


        }

        void WriteFile()
        {
            try
            {
                var sw = new StreamWriter("test.txt");
                foreach (var result in ThStrings)
                {
                    sw.WriteLine(result);
                }
                sw.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

        void GroupGenerate()
        {
            try
            {
                QRCodeEncoder encoder = new QRCodeEncoder();
                foreach (var result in ThStrings)
                {
                    Bitmaps.Add(encoder.Encode(result));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        private void btnPreview_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
    }
}
