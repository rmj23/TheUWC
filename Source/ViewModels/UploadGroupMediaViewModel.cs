using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace Source.Models
{
    public class UploadGroupMediaViewModel
    {
        public int projectId { get; set; }
        public int groupId { get; set; }
        public HttpPostedFileBase File { get; set; }
        public string mediaType { get; set; }
        public string title { get; set; }
        public List<SelectListItem> mediaTypes { get; set; }
        public byte[] media;
        public UploadGroupMediaViewModel(int? projectId, int? groupId)
        {
            this.projectId = (int)projectId;
            this.groupId = (int)groupId;
            mediaTypes = new List<SelectListItem> { new SelectListItem { Value = "PDF", Text = "PDF" },
                                            new SelectListItem { Text = "DOC", Value = "DOC"}, new SelectListItem {Text = "Video", Value = "Video" }, new SelectListItem { Text = "Image", Value = "Image"} };
        }
        public UploadGroupMediaViewModel()
        { }

        internal void bindMedia()
        {
            media = new byte[File.InputStream.Length];
            File.InputStream.Read(media, 0, media.Length);
            var tmpMediaType = File.ContentType.ToString();
            if (tmpMediaType.Contains("doc"))
            {
                mediaType = "DOC";
            }
            if (tmpMediaType.Contains("pdf"))
            {
                mediaType = "PDF";
            }
            if (tmpMediaType.Contains("jpeg"))
            {
                mediaType = "IMG_JPEG";
            }
            if (tmpMediaType.Contains("png"))
            {
                mediaType = "IMG_PNG";
            }
            if (tmpMediaType.Contains("mov"))
            {
                mediaType = "MOV";
            }
            if (tmpMediaType.Contains("mpeg"))
            {
                mediaType = "AUDIO";
            }
            if (tmpMediaType.Contains("mp4"))
            {
                mediaType = "MOV_MP4";
            }
        }
    }
}