using System;
using System.IO;
using System.Collections.Generic;

namespace Script
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\Downloads\ae665ae64e76e80a.txt";
            List<string> script = new List<string>();
            StreamReader streamReader = new StreamReader(path);

            while (!streamReader.EndOfStream)
            {
                var line = streamReader.ReadLine();
          
                if (!string.IsNullOrEmpty(line))
                {
                    if (!line.Contains('-') || !line.Contains('/'))
                    {
                        for (int i = 0; i < line.Length; i++)
                        {
                            if (line[i] == '\t')
                            {
                                int count = 0;
                                for (int j = i; j < line.Length; j++)
                                {
                                    if (line[j] != '\t')
                                    {
                                        line = line.Remove(i, count);
                                        break;
                                    }
                                    count++;
                                }
                            }
                        }
                        for(int i = 0; i < line.Length; i++)
                        {
                            if (line[i] == '(')
                            {
                                int count = 0;
                                for (int j = i; j < line.Length; j++)
                                {
                                    count++;
                                    if (line[j] == ')')
                                    {
                                        line = line.Replace(line[j], '_');
                                        line = line.Remove(i, count - 1);
                                        break;
                                    }
                                }
                            }
                        }
                        script.Add(line);
                        Console.WriteLine(line);
                    }
                }
            }
        }
    }
}
