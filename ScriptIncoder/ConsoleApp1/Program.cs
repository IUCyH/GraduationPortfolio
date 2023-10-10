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
            List<string> playerName = new List<string> { "신영", "지은", "재환" };
            List<string> playerID = new List<string> { "00", "01", "02" };
            List<string> explanations = new List<string> { "NA", "VO", "FB", "BIF" };
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
                                line = line.Replace(line[j], '_');

                                var isExplanation = j < line.Length - 2 ? explanations.Contains(string.Format("{0}{1}", line[j + 1], line[j + 2])) : false;
                                Console.WriteLine(string.Format("{0}{1}", line[j + 1], line[j + 2]));
                                //if (!isExplanation) continue;

                                int removeCount = 0;
                                for (int k = j; k < line.Length; k++)
                                {
                                    if (line[k] == ')')
                                    {
                                        line = line.Remove(j + 1, removeCount);
                                        break;
                                    }
                                    removeCount++;
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
                            var result = line.Split('_');

                            if(result.Length > 1)
                            {
                                result[0] = result[0].TrimEnd();
                                result[1] = result[1].TrimStart();
                                
                                for(int j = 0; j < playerName.Count; j++)
                                {
                                    if(playerName[j] == result[0])
                                    {
                                        result[0] = result[0].Replace(result[0], playerID[j]);
                                    }
                                }
                                line = result[0] + '_' + result[1];
                            }
                            else
                            {
                                result[0] = result[0].TrimStart();
                                line = result[0];
                            }

                            script.Add(line);
                        }
                    }
                }

                streamReader.Close();
                for (int j = 0; j < script.Count; j++)
                {
                    streamWriter.WriteLine(script[j], true);
                }
                streamWriter.Close();
            }
        }
    }
}
