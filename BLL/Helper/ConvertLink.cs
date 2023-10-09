using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL.Helper
{
    public class ConvertLink
    {
        public static string ConvertToDirectLink(string googleDriveLink)
        {
            string fileId = ExtractFileId(googleDriveLink);
            return $"https://drive.google.com/uc?id={fileId}";
        }

        private static string ExtractFileId(string link)
        {
            Regex regex = new Regex(@"/d/([^/]+)/");
            Match match = regex.Match(link);
            return match.Success ? match.Groups[1].Value : "";
        }
    }
}
