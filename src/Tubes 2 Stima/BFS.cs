using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubes_2_Stima
{
    public class BFS
    {
        public static string[] pathBFS = new string[20];
        public static string ansBFS = "";
        public static void SearchBFS(string root, string filename)
        {
            Queue<Tuple<string, int>> dirs = new Queue<Tuple<string, int>>(10000);


            if (!System.IO.Directory.Exists(root))
            {
                throw new ArgumentException();
            }
            Tuple<string, int> temp = new Tuple<string, int>(root, 0);
            dirs.Enqueue(temp);
            int depth = 0;
            while (dirs.Count > 0)
            {
                Tuple<string, int> cur = dirs.Dequeue();
                string currentDir = cur.Item1;
                depth = cur.Item2;
                pathBFS[depth] = currentDir + "\\";

                string[] files = null;
                try
                {
                    files = System.IO.Directory.GetFiles(currentDir);
                }

                catch (UnauthorizedAccessException e)
                {

                    System.Console.WriteLine(e.Message);
                    continue;
                }

                catch (System.IO.DirectoryNotFoundException e)
                {
                    System.Console.WriteLine(e.Message);
                    continue;
                }
                foreach (string file in files)
                {
                    try
                    {
                        System.IO.FileInfo fi = new System.IO.FileInfo(file);
                        if (fi.Name == filename)
                        {
                            ansBFS = pathBFS[depth] + filename;
                            System.Console.WriteLine(ansBFS);
                            return;
                        }
                    }
                    catch (System.IO.FileNotFoundException e)
                    {
                        System.Console.WriteLine(e.Message);
                        continue;
                    }
                }

                string[] subDirs;
                try
                {
                    subDirs = System.IO.Directory.GetDirectories(currentDir);
                }

                catch (UnauthorizedAccessException e)
                {
                    System.Console.WriteLine(e.Message);
                    continue;
                }
                catch (System.IO.DirectoryNotFoundException e)
                {
                    System.Console.WriteLine(e.Message);
                    continue;
                }

                foreach (string str in subDirs)
                {
                    Tuple<string, int> temp2 = new Tuple<string, int>(str, depth + 1);
                    dirs.Enqueue(temp2);
                }
            }
        }
    }
}
