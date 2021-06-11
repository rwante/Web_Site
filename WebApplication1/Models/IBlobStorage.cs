using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public interface IBlobStorage
    {
        Task UploadAsnyc(Stream fileStream, string name, string containerName);
        Task<Stream> DownloadAsync(string fileName, string containerName);
        Task DeleteAsync(string fileName, string containerName);
        Task SetLogAsync(string text, string fileName);
        Task<List<string>> GetLogAsync(string fileName);
        List<string> GetNames(string containerNames);
    }
}
