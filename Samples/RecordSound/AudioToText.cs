using Google.Cloud.Speech.V1Beta1;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
namespace RecordSound
{
    public class AudioToText
    {
      
        public string GetTextBy16BitPCMAudio(string path,string languageCode, ref string Message)
        {
            string Transcript = "";
            string credential_path = AssemblyDirectory + "\\DefaultCredentials.JSON";
            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credential_path);

            var speech = SpeechClient.Create();

            try
            {
                var response = speech.SyncRecognize(new RecognitionConfig()
                {
                    Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
                    SampleRate = 16000,
                    LanguageCode = languageCode,
                }, RecognitionAudio.FromFile(path));

                foreach (var result in response.Results)
                {
                    foreach (var alternative in result.Alternatives)
                    {
                        Transcript += alternative.Transcript;
                    }
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            return Transcript;
        }


        public  string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        public  void SetFolderPermission(string folderPath)
        {
            if (!System.IO.File.Exists(folderPath))
            {
                System.IO.Directory.CreateDirectory(folderPath);
            }
             
            var directoryInfo = new DirectoryInfo(folderPath);
            var directorySecurity = directoryInfo.GetAccessControl();
            var currentUserIdentity = WindowsIdentity.GetCurrent();
            var fileSystemRule = new FileSystemAccessRule(currentUserIdentity.Name,
                                                          FileSystemRights.Read,
                                                          InheritanceFlags.ObjectInherit |
                                                          InheritanceFlags.ContainerInherit,
                                                          PropagationFlags.None,
                                                          AccessControlType.Allow);

            directorySecurity.AddAccessRule(fileSystemRule);
            directoryInfo.SetAccessControl(directorySecurity);
        }

    }

}
    
