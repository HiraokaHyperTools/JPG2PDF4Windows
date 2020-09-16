using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.codec;
using kenjiuno.AutoHourglass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Image = iTextSharp.text.Image;
using Rectangle = iTextSharp.text.Rectangle;

namespace JPG2PDF4Windows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void selectFilesBtn_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                Filter = "*.jpg|*.jpg",
                CheckPathExists = true,
                CheckFileExists = true,
                Multiselect = true,
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var sfd = new SaveFileDialog
                {
                    Filter = "*.pdf|*.pdf",
                    CheckPathExists = true,
                    FileName = Path.Combine(Path.GetDirectoryName(ofd.FileName), Path.GetFileNameWithoutExtension(ofd.FileName) + ".pdf"),
                    InitialDirectory = Path.GetDirectoryName(ofd.FileName),
                };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (new AH())
                    {
                        CreatePdf(ofd.FileNames, sfd.FileName);
                    }

                    MessageBox.Show("PDF ファイルを作成しました。");
                }
            }
        }
        void CreatePdf(string[] inFiles, string outFile)
        {
            var document = new Document();
            var pdf = new MemoryStream();
            var writer = PdfWriter.GetInstance(document, pdf);
            var first = true;

            foreach (var inFile in inFiles)
            {
                var fileExt = Path.GetExtension(inFile).ToLowerInvariant();
                var images = new List<Image>();
                if (fileExt == ".jpg" || fileExt == ".jpeg")
                {
                    images.Add(new Jpeg(File.ReadAllBytes(inFile)));
                }
                else if (fileExt == ".tif" | fileExt == ".tiff")
                {
                    var file = new RandomAccessFileOrArray(File.ReadAllBytes(inFile));
                    for (int y = 1, cy = TiffImage.GetNumberOfPages(file); y <= cy; y++)
                    {
                        images.Add(TiffImage.GetTiffImage(file, y));
                    }
                }
                else
                {
                    images.Add(Image.GetInstance(File.ReadAllBytes(inFile)));
                }

                foreach (var image in images)
                {
                    var rect = new Rectangle(
                        image.Width / HelpDpi(image.DpiX) * 72,
                        image.Height / HelpDpi(image.DpiY) * 72
                    );

                    image.ScaleAbsolute(rect.Width, rect.Height);
                    document.SetPageSize(rect);
                    document.SetMargins(0, 0, 0, 0);

                    if (first)
                    {
                        first = false;
                        document.Open();
                    }
                    else
                    {
                        document.NewPage();
                    }

                    document.Add(image);
                }
            }

            document.Close();
            writer.Close();

            File.WriteAllBytes(outFile, pdf.ToArray());
        }

        private float HelpDpi(int dpi)
        {
            if (dpi <= 0)
                return (int)altDpi.Value;
            return dpi;
        }

        private void selectFilesBtn_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect & (e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.All : DragDropEffects.None);
        }

        private void selectFilesBtn_DragDrop(object sender, DragEventArgs e)
        {
            var files = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (files != null && files.Length >= 1)
            {
                var sfd = new SaveFileDialog
                {
                    Filter = "*.pdf|*.pdf",
                    CheckPathExists = true,
                    FileName = Path.Combine(Path.GetDirectoryName(files[0]), Path.GetFileNameWithoutExtension(files[0]) + ".pdf"),
                    InitialDirectory = Path.GetDirectoryName(files[0]),
                };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (new AH())
                    {
                        CreatePdf(files, sfd.FileName);
                    }

                    MessageBox.Show("PDF ファイルを作成しました。");
                }
            }
        }
    }
}
