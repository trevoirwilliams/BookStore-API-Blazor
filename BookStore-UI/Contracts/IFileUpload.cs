using BlazorInputFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_UI.Contracts
{
    public interface IFileUpload
    {
        public Task UploadFile(IFileListEntry file, string picName);
        public void RemoveFile(string picName);
    }
}
