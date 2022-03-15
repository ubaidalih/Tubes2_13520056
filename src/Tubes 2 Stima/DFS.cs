using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Tubes_2_Stima
{
    public class DFS
    {
        public static string[] path = new string[20];
        public static string ans = "";
        public static void SearchDFS(string root, string filename)
        {
            Stack<Tuple<string, int>> dirs = new Stack<Tuple<string, int>>(10000);
            

            if (!System.IO.Directory.Exists(root))
            {
                throw new ArgumentException();
            }
            Tuple<string, int> temp = new Tuple<string, int>(root, 0);
            dirs.Push(temp);
            int depth = 0;
            while (dirs.Count > 0)
            {
                Tuple<string, int> cur = dirs.Pop();
                string currentDir = cur.Item1;
                depth = cur.Item2;
                path[depth] = currentDir + "\\";

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
                            ans = path[depth]+filename;
                            System.Console.WriteLine(ans);
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
                    dirs.Push(temp2);
                }
            }
        }
    }
}
