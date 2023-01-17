using System;
using System.IO;
using System.Web;

namespace Source.Models
{
    public class UploadPaperDataOnlyViewModel
    {
        public HttpPostedFileBase File { get; set; }
        public PaperModel Paper { get; set; }
        public Uri PreviousUrl { get; set; }

        public UploadPaperDataOnlyViewModel(int paperID, Uri previousUrl)
        {
            Paper = new PaperModel
            {
                PaperID = paperID
            };
            PreviousUrl = previousUrl;
        }

        public UploadPaperDataOnlyViewModel()
        {
        }

        public void BindViewModelElements()
        {
            if (File == null)
            {
                Paper.Paper = null;
                Paper.FileName = null;
            }
            else
            {
                Paper.Paper = new byte[File.InputStream.Length];
                File.InputStream.Read(Paper.Paper, 0, Paper.Paper.Length);
                Paper.FileName = Path.GetFileName(File.FileName);
            }
        }
    }
}