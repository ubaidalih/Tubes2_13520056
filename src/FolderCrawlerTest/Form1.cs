using Microsoft.WindowsAPICodePack.Dialogs;
using System.Diagnostics;

namespace FolderCrawlerTest
{
    public partial class Form1 : Form
    {
        private static bool validFolder = false;
        private static bool foundFile = false;
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
            return path.Substring(path.LastIndexOf('\\') + 1);
        }

        private void BFSSearch(string root, string fileName, List<String> foundPaths)
        {
            Dictionary<Microsoft.Msagl.Drawing.Node, Boolean> nodeStatus = new Dictionary<Microsoft.Msagl.Drawing.Node, Boolean>();
            graph = new Microsoft.Msagl.Drawing.Graph("graph");
            Queue<string> subdirectoryQueue = new Queue<string>();
            subdirectoryQueue.Enqueue(root);
            while (subdirectoryQueue.Count > 0)
            {
                /* Ambil head dari queue, lalu proses */
                string currDirectory = subdirectoryQueue.Dequeue();
                /* Cek file-file yang ada dahulu, */
                string[] fileEntries = Directory.GetFiles(currDirectory);
                foreach (string fileEntry in fileEntries)
                {
                    wait(trackBarSpeed.Value);
                    graph.AddEdge(currDirectory, fileEntry).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                    Microsoft.Msagl.Drawing.Node c = graph.FindNode(currDirectory);
                    Microsoft.Msagl.Drawing.Node f = graph.FindNode(fileEntry);
                    if (!nodeStatus.ContainsKey(c))
                    {
                        c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
                    }
                    if (!nodeStatus.ContainsKey(f))
                    {
                        f.Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
                    }                   
                    c.LabelText = GetSafeName(currDirectory);
                    f.LabelText = GetSafeName(fileEntry);
                    if (GetSafeName(fileEntry) == fileName)
                    {
                        foundPaths.Add(fileEntry);
                        /* Warnai sampai root */
                        Queue<Microsoft.Msagl.Drawing.Node> nodeQueue = new Queue<Microsoft.Msagl.Drawing.Node>();
                        nodeQueue.Enqueue(f);
                        while (nodeQueue.Count > 0)
                        {
                            Microsoft.Msagl.Drawing.Node node = nodeQueue.Dequeue();
                            nodeStatus[node] = true;
                            node.Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
                            foreach (Microsoft.Msagl.Drawing.Edge edge in node.InEdges)
                            {
                                edge.Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
                                if (!nodeStatus.ContainsKey(edge.SourceNode))
                                {
                                    nodeQueue.Enqueue(edge.SourceNode);
                                }
                            }
                        }
                        if (!checkBoxOccurence.Checked)
                        {
                            graphViewer.Graph = graph;
                            foundFile = true;
                            return;
                        }
                    }
                    graphViewer.Graph = graph;
                }
                /* Masukkan subdirectory ke queue untuk diproses */
                string[] subdirectoryEntries = Directory.GetDirectories(currDirectory);
                foreach (string subdirectoryEntry in subdirectoryEntries)
                {
                    wait(trackBarSpeed.Value);
                    graph.AddEdge(currDirectory, subdirectoryEntry).Attr.Color = Microsoft.Msagl.Drawing.Color.Red; ;
                    Microsoft.Msagl.Drawing.Node c = graph.FindNode(currDirectory);
                    Microsoft.Msagl.Drawing.Node s = graph.FindNode(subdirectoryEntry);
                    if (!nodeStatus.ContainsKey(c))
                    {
                        c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
                    }
                    if (!nodeStatus.ContainsKey(s))
                    {
                        s.Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
                    }
                    c.LabelText = GetSafeName(currDirectory);
                    s.LabelText = GetSafeName(subdirectoryEntry);
                    graphViewer.Graph = graph;
                    subdirectoryQueue.Enqueue(subdirectoryEntry);
                }
            }
        }

        private void DFSSearch(string root, string fileName, Dictionary<Microsoft.Msagl.Drawing.Node, Boolean> nodeStatus, List<String> foundPaths)
        {
            if (!checkBoxOccurence.Checked)
            {
                if (foundFile)
                {
                    return;
                }
            }
            string[] fileEntries = Directory.GetFiles(root);
            foreach (string fileEntry in fileEntries)
            {
                wait(trackBarSpeed.Value);
                graph.AddEdge(root, fileEntry).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                Microsoft.Msagl.Drawing.Node c = graph.FindNode(root);
                Microsoft.Msagl.Drawing.Node f = graph.FindNode(fileEntry);
                if (!nodeStatus.ContainsKey(c))
                {
                    c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
                }
                if (!nodeStatus.ContainsKey(f))
                {
                    f.Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
                }
                c.LabelText = GetSafeName(root);
                f.LabelText = GetSafeName(fileEntry);
                if (GetSafeName(fileEntry) == fileName)
                {
                    foundPaths.Add(fileEntry);
                    /* Warnai sampai root */
                    Queue<Microsoft.Msagl.Drawing.Node> nodeQueue = new Queue<Microsoft.Msagl.Drawing.Node>();
                    nodeQueue.Enqueue(f);
                    while (nodeQueue.Count > 0)
                    {
                        Microsoft.Msagl.Drawing.Node node = nodeQueue.Dequeue();
                        nodeStatus[node] = true;
                        node.Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
                        foreach (Microsoft.Msagl.Drawing.Edge edge in node.InEdges)
                        {
                            edge.Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
                            if (!nodeStatus.ContainsKey(edge.SourceNode))
                            {
                                nodeQueue.Enqueue(edge.SourceNode);
                            }
                        }
                    }
                    if (!checkBoxOccurence.Checked)
                    {
                        graphViewer.Graph = graph;
                        foundFile = true;
                        return;
                    }
                }
                graphViewer.Graph = graph;
            }
            /* Lakukan DFS */
            string[] subdirectoryEntries = Directory.GetDirectories(root);
            foreach (string subdirectoryEntry in subdirectoryEntries)
            {
                if (!checkBoxOccurence.Checked && foundFile)
                {
                    return;
                }
                wait(trackBarSpeed.Value);
                graph.AddEdge(root, subdirectoryEntry).Attr.Color = Microsoft.Msagl.Drawing.Color.Red; ;
                Microsoft.Msagl.Drawing.Node c = graph.FindNode(root);
                Microsoft.Msagl.Drawing.Node s = graph.FindNode(subdirectoryEntry);
                if (!nodeStatus.ContainsKey(c))
                {
                    c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
                }
                if (!nodeStatus.ContainsKey(s))
                {
                    s.Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
                }
                c.LabelText = GetSafeName(root);
                s.LabelText = GetSafeName(subdirectoryEntry);
                graphViewer.Graph = graph;
                DFSSearch(subdirectoryEntry, fileName, nodeStatus, foundPaths);
            }
        }

        private void addHyperlinks(List<String> paths)
        {
            int Y = 0;
            foreach (String path in paths)
            {
                /*
                this.labelTest.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
                this.labelTest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(52)))), ((int)(((byte)(187)))));
                this.labelTest.Location = new System.Drawing.Point(26, 359);
                this.labelTest.Name = "labelTest";
                this.labelTest.Size = new System.Drawing.Size(461, 28);
                this.labelTest.TabIndex = 23;
                this.labelTest.Text = "C:\\Users\\acoxs\\Documents\\Programming\\FolderCrawlerTest\\Folder3\\Folder4";
                this.labelTest.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                */
                Label l = new Label();
                this.Controls.Add(l);
                l.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
                l.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(52)))), ((int)(((byte)(187)))));
                l.Location = new System.Drawing.Point(26, 359 + Y * 30);
                l.Name = path;
                l.Size = new System.Drawing.Size(461, 28);
                l.TabIndex = 23;
                l.Text = path.Substring(textBoxDirectory.Text.Length);
                l.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                l.Click += new System.EventHandler(this.hyperlink_Click);
                l.MouseHover += new System.EventHandler(this.hyperlink_Hover);
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
                clearHyperlinks();
                labelSearchTime.Text = "";
                labelSearchResult.Text = "";
                graph = new Microsoft.Msagl.Drawing.Graph("graph");
                foundFile = false;
                Stopwatch sw = new Stopwatch();
                List<String> foundPaths = new List<String>();
                sw.Start();
                BFSSearch(textBoxDirectory.Text, textBoxInputFile.Text, foundPaths);
                sw.Stop();
                labelSearchTime.Text = $"Search took {sw.Elapsed.TotalSeconds:0.00} seconds.";
                if (foundPaths.Count == 0)
                {
                    labelSearchResult.Text = "Path not found!";
                } else
                {
                    labelSearchResult.Text = $"Found {foundPaths.Count} paths!";
                    addHyperlinks(foundPaths);
                }
                return;
            }
            if (radioDFS.Checked)
            {
                clearHyperlinks();
                labelSearchTime.Text = "";
                labelSearchResult.Text = "";
                Dictionary<Microsoft.Msagl.Drawing.Node, Boolean> nodeStatus = new Dictionary<Microsoft.Msagl.Drawing.Node, Boolean>();
                foundFile = false;
                graph = new Microsoft.Msagl.Drawing.Graph("graph");
                List<String> foundPaths = new List<String>();
                Stopwatch sw = new Stopwatch();
                sw.Start();
                DFSSearch(textBoxDirectory.Text, textBoxInputFile.Text, nodeStatus, foundPaths);
                sw.Stop();
                labelSearchTime.Text = $"Search took {sw.Elapsed.TotalSeconds:0.00} seconds.";
                if (foundPaths.Count == 0)
                {
                    labelSearchResult.Text = "Path not found!";
                }
                else
                {
                    labelSearchResult.Text = $"Found {foundPaths.Count} paths!";
                    addHyperlinks(foundPaths);
                }
                return;
            }
        }

        private void trackBarSpeed_Scroll(object sender, EventArgs e)
        {
            labelCrawlSpeed.Text = Convert.ToString(trackBarSpeed.Value) + " ms";
        }
    }
}