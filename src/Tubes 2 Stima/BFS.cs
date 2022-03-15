using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubes_2_Stima
{
    public class BFS
    {
        public static string pathBFS = "";
        public static void SearchBFS(string root, string filename)
        {
            Queue<string> dirs = new Queue<string>(10000);


            if (!System.IO.Directory.Exists(root))
            {
                throw new ArgumentException();
            }
            dirs.Enqueue(root);
            while (dirs.Count > 0)
            {
                string currentDir = dirs.Dequeue();
                pathBFS = currentDir + "\\";

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
                            pathBFS += filename;
                            System.Console.WriteLine(pathBFS);
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
                    dirs.Enqueue(str);
                }
            }
        }
    }
}
