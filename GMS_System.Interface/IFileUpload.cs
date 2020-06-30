using GMS_System.Model;
using System.Collections.Generic;

namespace GMS_System.Interface
{
    public interface IFileUpload
    {
        List<FileUploadLogs> GetFileUploadLogs(int tenantId,int fileuploadFor);

        int CreateFileUploadLog(int tenantid, string filename, bool isuploaded, string errorlogfilename, string successlogfilename, int createdby, string filetype,
          string succesFilepath, string errorFilepath, int fileuploadFor);
    }
}
