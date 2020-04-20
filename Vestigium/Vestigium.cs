using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace CodeJam2020
{
    public class Vestigium
    {
        private const bool DEBUG = true;
        private const string Name = nameof(Vestigium);
        private const string Path = "..\\..\\";
        private static readonly TextReader Reader = DEBUG? new StreamReader(Path + Name + ".in"): System.Console.In;
        private static readonly TextWriter Writer = DEBUG? new StreamWriter(Path + Name + ".out"): System.Console.Out; 
        public static void Main()
        {


            int testCases = int.Parse(Reader.ReadLine());
            for (int testCase = 1; testCase <= testCases; testCase++)
            {
                string[] line = Reader.ReadLine().Split(' ');
                int rowCount = int.Parse(line[0]);

                int[,] matrix = new int[rowCount, rowCount];
                for (int i = 0; i < rowCount; i++) {
                    line = Reader.ReadLine().Split(' ');

                    for (int j = 0; j < rowCount; j++)
                    {
                        matrix[i,j] = int.Parse(line[j]);
                    }
                }
                solve(testCase, matrix,rowCount);
            }

            Writer.Flush();
            Writer.Close();
            Reader.Close();
        }

        private static void solve(int testCase, int[,] matrix,int rowCount )
        {
            int trace = 0;
            for (int i = 0; i < rowCount; i++) {
                trace = trace + matrix[i,i];
            }
            int dupRowCount = 0;
            for (int i = 0; i <rowCount; i++) {
                List<int> numbersPresent = new List<int>(matrix.Length + 1);
                for (int j = 0; j < rowCount; j++) {
                    int v = matrix[i,j];
                    if (numbersPresent.Contains(v)) {
                        dupRowCount++;
                        break;
                    }
                    numbersPresent.Add(v);
                }
            }
            int dupColumnCount = 0;
            for (int j = 0; j < rowCount; j++) {
                List<int> numbersPresent = new List<int>(matrix.Length + 1);
                for (int i = 0; i < rowCount; i++) {
                    int v = matrix[i,j];
                    if (numbersPresent.Contains(v)) {
                        dupColumnCount++;
                        break;
                    }
                    numbersPresent.Add(v);
                }
            }
            Writer.WriteLine("Case #" + testCase + ": " + trace + " " + dupRowCount + " " + dupColumnCount);
        }
    }
}
