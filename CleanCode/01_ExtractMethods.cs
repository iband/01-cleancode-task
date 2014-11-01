using System;
using System.IO;

namespace CleanCode
{
	public static class RefactorMethod
	{
        private static void WriteToFile(string path, byte[] data)
        {
            var fs = new FileStream(path, FileMode.OpenOrCreate);
            fs.Write(data, 0, data.Length);
            fs.Close();

        }
		private static void SaveData(string s, byte[] d)
		{
            WriteToFile(s, d);
            // backup
            WriteToFile(Path.ChangeExtension(s, "bkp"), d);

			// save last-write time
            WriteToFile(s + ".time", BitConverter.GetBytes(DateTime.Now.Ticks));
		}
	}
}