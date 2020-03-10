using System.IO;
using System.Text;

namespace FileReadWrite
{
	class Program
	{
		static void Main(string[] args)
		{
			string inputFile = "itv.txt";
			FileStream fileStream = new FileStream(inputFile, FileMode.Open, FileAccess.ReadWrite);
			Encoding e = Encoding.GetEncoding(1250);//kelet európai kódolás
			int szam;
			char[] buffer = new char[1024];
			using (StreamReader fileToRead = new StreamReader(fileStream, e))
			{
				StreamWriter fileToWrite = new StreamWriter(fileStream, e);
				long p = 0;
				while ((szam = fileToRead.Read(buffer, 0, 1024)) > 0)
				{
					for (int i = 0; i < szam; i++)
					{
						if (buffer[i] == 'á')
						{
							buffer[i] = 'a';
						}
					}
					fileStream.Position = p;
					fileToWrite.Write(buffer, 0, szam);
					p = fileStream.Position;
				}
				fileToWrite.Close();
			}
		}
	}
}
