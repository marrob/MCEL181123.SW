
namespace Konvolucio.MCEL181123
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public class IoLog
    {
        public static IoLog Instance { get; } = new IoLog();
        public string Path = Application.StartupPath;
        public bool Enabled;

        public double? GetFileSizeKB
        {
            get
            {
                if (File.Exists(Path))
                {
                    FileInfo fi = new FileInfo(Path);
                    return fi.Length / 1024;
                }
                else
                    return null;
            }
        }

        public IoLog()
        {
            Enabled = true;
            Path = "IoLog.txt";
        }

        public void WirteLine(string line)
        {
            if (Enabled)
            {
                line = DateTime.Now.ToString(AppConstants.GenericTimestampFormat, System.Globalization.CultureInfo.InvariantCulture) + ";" + line + AppConstants.NewLine;
                var fileWrite = new StreamWriter(Path, true, Encoding.ASCII);
                fileWrite.NewLine = AppConstants.NewLine;
                fileWrite.Write(line);
                fileWrite.Flush();
                fileWrite.Close();
            }
        }
    }
}
