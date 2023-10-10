using System;
using System.IO;
using System.Collections.Generic;

namespace Script
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("폴더 경로 입력 (Scripts 폴더 속성 들어가서 위치 부분 전체 복사)");
            string defaultPath = Console.ReadLine();
            List<string> script = new List<string>();
            DirectoryInfo directory = new DirectoryInfo(defaultPath + @"\" + "Scripts");

            int count = directory.GetFiles().Length;

            for (int i = 0; i < count; i++)
            {
                string path = string.Format(@"{0}\Scripts\Chapter{1:00}.txt", defaultPath, i + 1);
                string path2 = string.Format(@"{0}\Scripts\Edit\Chapter{1:00}.txt", defaultPath, i + 1);
                StreamReader streamReader = new StreamReader(path);
                StreamWriter streamWriter = new StreamWriter(path2);

                while (!streamReader.EndOfStream)
                {
                    var line = streamReader.ReadLine();

                    if (!string.IsNullOrEmpty(line))
                    {
                        if (line.Contains("-") || line.Contains("/") || line.Contains("S#")) continue;

                        for (int j = 0; j < line.Length; j++)
                        {
                            if (line[j] == '\t')
                            {
                                line = line.Remove(j, 1);
                                j--;
                            }
                        }

                        for (int j = 0; j < line.Length; j++)
                        {
                            if (line[j] == '(')
                            {
                                int removeCount = 0;
                                for (int k = j; k < line.Length; k++)
                                {
                                    removeCount++;
                                    if (line[k] == ')')
                                    {
                                        line = line.Replace(line[k], '_');
                                        line = line.Remove(j, removeCount - 1);
                                        break;
                                    }
                                }
                            }
                        }

                        bool canAdd = true;
                        if (line.Contains(" "))
                        {
                            for (int j = 0; j < line.Length; j++)
                            {
                                if(line[j] == ' ' && j == line.Length - 1)
                                {
                                    canAdd = false;
                                }
                                if(line[j] != ' ')
                                {
                                    break;
                                }
                            }
                        }
                        if (line.Contains("_"))
                        {
                            for (int j = 0; j < line.Length; j++)
                            {
                                if (line[j] == '_' && j == line.Length - 1)
                                {
                                    canAdd = false;
                                }
                                if(line[j] != '_')
                                {
                                    break;
                                }
                            }
                        }

                        if (canAdd && !string.IsNullOrEmpty(line))
                        {
                            script.Add(line);

                            var splitResult = line.Split('_');
                            for(int i = 0; i < splitResult[0].Length; i++)
                            {
                                if(splitResult[0][i] == ' ')
                                {
                                    splitResult[0].Remove(i, 1);
                                }
                            }
                        }
                    }
                }

                streamReader.Close();
                for (int j = 0; j < script.Count; j++)
                {
                    streamWriter.WriteLine(script[j], true);
                    Console.WriteLine(script[j]);
                }
                streamWriter.Close();
            }
        }
    }
}
