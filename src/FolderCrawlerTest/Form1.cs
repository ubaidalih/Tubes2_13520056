using Microsoft.WindowsAPICodePack.Dialogs;
using System.Diagnostics;

namespace FolderCrawlerTest
{
    public partial class Form1 : Form
    {
        class Item
        {
            public string type { get; set; }
            public string path { get; set; }
            public Item(string type, string path)
            {
                this.type = type;
                this.path = path;
            }

        }

        private static bool validFolder = false;
        private static bool foundFile = false;
        private static bool isSearching = false;
        private static Microsoft.Msagl.Drawing.Graph graph;
        private static List<Label> hyperlinks = new List<Label>();
        private void wait(int milliseconds)
        {
            /* Credits to StackOverflow */
            var timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;

            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();

            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
            };

            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }

        private string GetSafeName(string path)
        {
            return path.Substring(path.LastIndexOf(Path.DirectorySeparatorChar) + 1);
        }

        private string GetRootPath(string path)
        {
            return path.Substring(0, path.LastIndexOf(Path.DirectorySeparatorChar));
        }
        private void DFS(string root, string filename, List<String> foundPaths)
        {
            graph = new Microsoft.Msagl.Drawing.Graph("graph");
            Stack<Item> itemStack = new Stack<Item>();
            itemStack.Push(new Item("FOLDER", root));
            while (itemStack.Count > 0)
            {
                wait(trackBarSpeed.Value);

                Item item = itemStack.Pop();
                if (!checkBoxOccurence.Checked && foundFile)
                {
                    /* Apabila file sudah ditemukan, artinya node ini tidak dicek tapi ada dalam antrian (warna hitam). */
                    graph.AddEdge(GetRootPath(item.path), item.path);
                    Microsoft.Msagl.Drawing.Node r = graph.FindNode(GetRootPath(item.path));
                    Microsoft.Msagl.Drawing.Node c = graph.FindNode(item.path);
                    r.LabelText = GetSafeName(GetRootPath(item.path));
                    c.LabelText = GetSafeName(item.path);
                }
                else
                {
                    if (item.type == "FOLDER")
                    {
                        /* Proses sebuah directory. */
                        /* Masukkan ke dalam graf dulu, */
                        if (item.path != root)
                        {
                            graph.AddEdge(GetRootPath(item.path), item.path).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                            Microsoft.Msagl.Drawing.Node r = graph.FindNode(GetRootPath(item.path));
                            Microsoft.Msagl.Drawing.Node c = graph.FindNode(item.path);
                            r.LabelText = GetSafeName(GetRootPath(item.path));
                            c.LabelText = GetSafeName(item.path);
                            c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
                            if (r.Attr.FillColor != Microsoft.Msagl.Drawing.Color.PaleGreen)
                            {
                                r.Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
                            }
                        }
                        /* Masukkan subdirectories ke dalam stack */
                        string[] subdirectoryEntries = Directory.GetDirectories(item.path);
                        foreach (string subdir in subdirectoryEntries)
                        {
                            itemStack.Push(new Item("FOLDER", subdir));
                        }
                        /* Masukkan files ke dalam stack */
                        string[] fileEntries = Directory.GetFiles(item.path);
                        foreach (string file in fileEntries)
                        {
                            itemStack.Push(new Item("FILE", file));
                        }
                    } 
                    else
                    {
                        /* Proses sebuah file. */
                        if (GetSafeName(item.path) == filename)
                        {
                            graph.AddEdge(GetRootPath(item.path), item.path).Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
                            Microsoft.Msagl.Drawing.Node r = graph.FindNode(GetRootPath(item.path));
                            Microsoft.Msagl.Drawing.Node c = graph.FindNode(item.path);
                            r.LabelText = GetSafeName(GetRootPath(item.path));
                            c.LabelText = GetSafeName(item.path);
                            /* Warnai semua node dan edge dari c sampai root */
                            Queue<Microsoft.Msagl.Drawing.Node> nodeQueue = new Queue<Microsoft.Msagl.Drawing.Node>();
                            nodeQueue.Enqueue(c);
                            while (nodeQueue.Count > 0)
                            {
                                Microsoft.Msagl.Drawing.Node node = nodeQueue.Dequeue();
                                node.Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
                                foreach (Microsoft.Msagl.Drawing.Edge edge in node.InEdges)
                                {
                                    edge.Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
                                    nodeQueue.Enqueue(edge.SourceNode);
                                }
                            }
                            foundFile = true;
                            foundPaths.Add(item.path);
                        }
                        else
                        {
                            graph.AddEdge(GetRootPath(item.path), item.path).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                            Microsoft.Msagl.Drawing.Node r = graph.FindNode(GetRootPath(item.path));
                            Microsoft.Msagl.Drawing.Node c = graph.FindNode(item.path);
                            r.LabelText = GetSafeName(GetRootPath(item.path));
                            c.LabelText = GetSafeName(item.path);
                            c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
                            if (r.Attr.FillColor != Microsoft.Msagl.Drawing.Color.PaleGreen)
                            {
                                r.Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
                            }
                        }
                    }
                }

                graphViewer.Graph = graph;
            }
        }

        private void BFS(string root, string filename, List<String> foundPaths)
        {
            graph = new Microsoft.Msagl.Drawing.Graph("graph");
            Queue<Item> itemQueue = new Queue<Item>();
            itemQueue.Enqueue(new Item("FOLDER", root));
            while (itemQueue.Count > 0)
            {
                wait(trackBarSpeed.Value);

                Item item = itemQueue.Dequeue();
                if (!checkBoxOccurence.Checked && foundFile)
                {
                    /* Apabila file sudah ditemukan, artinya node ini tidak dicek tapi ada dalam antrian (warna hitam). */
                    graph.AddEdge(GetRootPath(item.path), item.path);
                    Microsoft.Msagl.Drawing.Node r = graph.FindNode(GetRootPath(item.path));
                    Microsoft.Msagl.Drawing.Node c = graph.FindNode(item.path);
                    r.LabelText = GetSafeName(GetRootPath(item.path));
                    c.LabelText = GetSafeName(item.path);
                }
                else
                {
                    if (item.type == "FOLDER")
                    {
                        /* Proses sebuah directory. */
                        /* Masukkan ke dalam graf dulu, */
                        if (item.path != root)
                        {
                            graph.AddEdge(GetRootPath(item.path), item.path).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                            Microsoft.Msagl.Drawing.Node r = graph.FindNode(GetRootPath(item.path));
                            Microsoft.Msagl.Drawing.Node c = graph.FindNode(item.path);
                            r.LabelText = GetSafeName(GetRootPath(item.path));
                            c.LabelText = GetSafeName(item.path);
                            c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
                            if (r.Attr.FillColor != Microsoft.Msagl.Drawing.Color.PaleGreen)
                            {
                                r.Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
                            }
                        }
                        /* Masukkan files ke dalam stack */
                        string[] fileEntries = Directory.GetFiles(item.path);
                        foreach (string file in fileEntries)
                        {
                            itemQueue.Enqueue(new Item("FILE", file));
                        }
                        /* Masukkan subdirectories ke dalam stack */
                        string[] subdirectoryEntries = Directory.GetDirectories(item.path);
                        foreach (string subdir in subdirectoryEntries)
                        {
                            itemQueue.Enqueue(new Item("FOLDER", subdir));
                        }
                    }
                    else
                    {
                        /* Proses sebuah file. */
                        if (GetSafeName(item.path) == filename)
                        {
                            graph.AddEdge(GetRootPath(item.path), item.path).Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
                            Microsoft.Msagl.Drawing.Node r = graph.FindNode(GetRootPath(item.path));
                            Microsoft.Msagl.Drawing.Node c = graph.FindNode(item.path);
                            r.LabelText = GetSafeName(GetRootPath(item.path));
                            c.LabelText = GetSafeName(item.path);
                            /* Warnai semua node dan edge dari c sampai root */
                            Queue<Microsoft.Msagl.Drawing.Node> nodeQueue = new Queue<Microsoft.Msagl.Drawing.Node>();
                            nodeQueue.Enqueue(c);
                            while (nodeQueue.Count > 0)
                            {
                                Microsoft.Msagl.Drawing.Node node = nodeQueue.Dequeue();
                                node.Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
                                foreach (Microsoft.Msagl.Drawing.Edge edge in node.InEdges)
                                {
                                    edge.Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
                                    nodeQueue.Enqueue(edge.SourceNode);
                                }
                            }
                            foundFile = true;
                            foundPaths.Add(item.path);
                        }
                        else
                        {
                            graph.AddEdge(GetRootPath(item.path), item.path).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                            Microsoft.Msagl.Drawing.Node r = graph.FindNode(GetRootPath(item.path));
                            Microsoft.Msagl.Drawing.Node c = graph.FindNode(item.path);
                            r.LabelText = GetSafeName(GetRootPath(item.path));
                            c.LabelText = GetSafeName(item.path);
                            c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
                            if (r.Attr.FillColor != Microsoft.Msagl.Drawing.Color.PaleGreen)
                            {
                                r.Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
                            }
                        }
                    }
                }

                graphViewer.Graph = graph;
            }
        }

        private void addHyperlinks(List<String> paths)
        {
            int Y = 0;
            foreach (String path in paths)
            {
                Label l = new Label();
                Controls.Add(l);
                l.Font = new Font("Open Sans", 8.25F, FontStyle.Underline, GraphicsUnit.Point);
                l.ForeColor = Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(52)))), ((int)(((byte)(187)))));
                l.Location = new Point(26, 359 + Y * 30);
                l.Name = path;
                l.Size = new Size(461, 28);
                l.TabIndex = 23;
                l.Text = path.Substring(textBoxDirectory.Text.Length);
                l.TextAlign = ContentAlignment.MiddleLeft;
                l.Click += new EventHandler(hyperlink_Click);
                l.MouseHover += new EventHandler(hyperlink_Hover);
                l.BringToFront();
                hyperlinks.Add(l);
                Y++;
            }
        }

        private void clearHyperlinks()
        {
            foreach (Label l in hyperlinks)
            {
                this.Controls.Remove(l);
            }
        }
        private void hyperlink_Click(object sender, EventArgs e)
        {
            Label l = sender as Label;
            string path = l.Name.Substring(0, l.Name.LastIndexOf('\\'));
            Process.Start(new System.Diagnostics.ProcessStartInfo()
            {
                FileName = path,
                UseShellExecute = true,
                Verb = "open"
            });
        }

        private void hyperlink_Hover(object sender, EventArgs e)
        {
            Label l = sender as Label;
            l.Cursor = Cursors.Hand;
        }

        public Form1()
        {
            InitializeComponent();
            this.Text = "Folder Crawler";
        }

        private void buttonChooseFolder_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = Directory.GetCurrentDirectory();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                textBoxDirectory.Text = dialog.FileName;
                validFolder = true;
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (isSearching)
            {
                MessageBox.Show("Please wait for the current search to end first!");
                return;
            }
            if (!validFolder)
            {
                MessageBox.Show("Please input a valid directory to search from first!");
                return;
            }
            if (textBoxInputFile.TextLength == 0)
            {
                MessageBox.Show("Please input a filename to search first!");
                return;
            }
            if (!radioDFS.Checked && !radioBFS.Checked)
            {
                MessageBox.Show("Please select a crawling method first!");
            }
            if (radioBFS.Checked)
            {
                isSearching = true;
                clearHyperlinks();
                labelSearchTime.Text = "";
                labelSearchResult.Text = "";
                graph = new Microsoft.Msagl.Drawing.Graph("graph");
                foundFile = false;
                Stopwatch sw = new Stopwatch();
                List<String> foundPaths = new List<String>();
                sw.Start();
                BFS(textBoxDirectory.Text, textBoxInputFile.Text, foundPaths);
                sw.Stop();
                labelSearchTime.Text = $"Search took {sw.Elapsed.TotalSeconds:0.00} seconds.";
                if (foundPaths.Count == 0)
                {
                    labelSearchResult.Text = "Path not found!";
                } else
                {
                    labelSearchResult.Text = $"Found {foundPaths.Count} path(s)!";
                    addHyperlinks(foundPaths);
                }
                isSearching = false;
                return;
            }
            if (radioDFS.Checked)
            {
                isSearching = true;
                clearHyperlinks();
                labelSearchTime.Text = "";
                labelSearchResult.Text = "";
                foundFile = false;
                graph = new Microsoft.Msagl.Drawing.Graph("graph");
                List<String> foundPaths = new List<String>();
                Stopwatch sw = new Stopwatch();
                sw.Start();
                DFS(textBoxDirectory.Text, textBoxInputFile.Text, foundPaths);
                sw.Stop();
                labelSearchTime.Text = $"Search took {sw.Elapsed.TotalSeconds:0.00} seconds.";
                if (foundPaths.Count == 0)
                {
                    labelSearchResult.Text = "Path not found!";
                }
                else
                {
                    labelSearchResult.Text = $"Found {foundPaths.Count} path(s)!";
                    addHyperlinks(foundPaths);
                }
                isSearching = false;
                return;
            }
        }

        private void trackBarSpeed_Scroll(object sender, EventArgs e)
        {
            labelCrawlSpeed.Text = Convert.ToString(trackBarSpeed.Value) + " ms";
        }
    }
}