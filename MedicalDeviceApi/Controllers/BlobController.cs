using System.Net;
using MedicalDevice.Database;
using MedicalDevice.Model;
using Microsoft.AspNetCore.Mvc;

namespace MedicalDevice.Controllers
{
    [ApiController]
    [Route("blob")]
    public class BlobController(DatabaseContext context) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Ulid>> CreateBlob(IFormFile file)
        {
            await using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);

            var blob = new Blob
            {
                Id = Ulid.NewUlid(),
                Content = memoryStream.ToArray(),
                ContentType = FileExtensions.ContainsKey(file.ContentType) ? file.ContentType : "application/octet-stream"
            };

            context.Add(blob);
            await context.SaveChangesAsync();

            return blob.Id;
        }

        [HttpGet, Route("{id}")]
        public async Task<FileContentResult> GetBlob([FromRoute] Ulid id)
        {
            var blob = await context.Blobs.FindAsync(id)
                ?? throw new BadHttpRequestException("Blob does not exist", (int)HttpStatusCode.NotFound);

            if (!FileExtensions.TryGetValue(blob.ContentType, out var extension))
            {
                extension = string.Empty;
            }

            return File(blob.Content, blob.ContentType, $"{blob.Id}{extension}");
        }

        private static readonly Dictionary<string, string> FileExtensions = new()
        {
            { "application/atom+xml", ".atom" },
            { "application/font-woff", ".woff" },
            { "application/java-archive", ".jar" },
            { "application/javascript", ".js" },
            { "application/json", ".json" },
            { "application/msword", ".doc" },
            { "application/octet-stream", ".bin" },
            { "application/ogg", ".ogx" },
            { "application/pdf", ".pdf" },
            { "application/rtf", ".rtf" },
            { "application/vnd.apple.installer+xml", ".mpkg" },
            { "application/vnd.ms-excel", ".xls" },
            { "application/vnd.ms-fontobject", ".eot" },
            { "application/vnd.ms-powerpoint", ".ppt" },
            { "application/vnd.oasis.opendocument.presentation", ".odp" },
            { "application/vnd.oasis.opendocument.spreadsheet", ".ods" },
            { "application/vnd.oasis.opendocument.text", ".odt" },
            { "application/vnd.openxmlformats-officedocument.presentationml.presentation", ".pptx" },
            { "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", ".xlsx" },
            { "application/vnd.openxmlformats-officedocument.wordprocessingml.document", ".docx" },
            { "application/x-7z-compressed", ".7z" },
            { "application/x-rar-compressed", ".rar" },
            { "application/x-shockwave-flash", ".swf" },
            { "application/xhtml+xml", ".xhtml" },
            { "application/xml", ".xml" },
            { "application/zip", ".zip" },
            { "audio/aac", ".aac" },
            { "audio/midi", ".mid" },
            { "audio/mpeg", ".mp3" },
            { "audio/ogg", ".oga" },
            { "audio/wav", ".wav" },
            { "audio/webm", ".weba" },
            { "font/otf", ".otf" },
            { "font/ttf", ".ttf" },
            { "font/woff", ".woff" },
            { "font/woff2", ".woff2" },
            { "image/bmp", ".bmp" },
            { "image/gif", ".gif" },
            { "image/jpeg", ".jpeg" },
            { "image/png", ".png" },
            { "image/svg+xml", ".svg" },
            { "image/webp", ".webp" },
            { "text/css", ".css" },
            { "text/csv", ".csv" },
            { "text/html", ".html" },
            { "text/plain", ".txt" },
            { "text/xml", ".xml" },
            { "video/3gpp", ".3gp" },
            { "video/mp2t", ".ts" },
            { "video/mp4", ".mp4" },
            { "video/mpeg", ".mpeg" },
            { "video/ogg", ".ogv" },
            { "video/webm", ".webm" },
            { "video/x-msvideo", ".avi" }
        };
    }
}