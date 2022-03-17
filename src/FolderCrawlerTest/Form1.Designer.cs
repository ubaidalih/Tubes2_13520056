namespace FolderCrawlerTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonChooseFolder = new System.Windows.Forms.Button();
            this.textBoxDirectory = new System.Windows.Forms.TextBox();
            this.textBoxInputFile = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.graphViewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            this.radioBFS = new System.Windows.Forms.RadioButton();
            this.radioDFS = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxOccurence = new System.Windows.Forms.CheckBox();
            this.labelSearchTime = new System.Windows.Forms.Label();
            this.trackBarSpeed = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelSearchResult = new System.Windows.Forms.Label();
            this.labelCrawlSpeed = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonChooseFolder
            // 
            this.buttonChooseFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(52)))), ((int)(((byte)(187)))));
            this.buttonChooseFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChooseFolder.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonChooseFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(241)))), ((int)(((byte)(247)))));
            this.buttonChooseFolder.Location = new System.Drawing.Point(489, 0);
            this.buttonChooseFolder.Name = "buttonChooseFolder";
            this.buttonChooseFolder.Size = new System.Drawing.Size(60, 44);
            this.buttonChooseFolder.TabIndex = 0;
            this.buttonChooseFolder.Text = "→";
            this.buttonChooseFolder.UseVisualStyleBackColor = false;
            this.buttonChooseFolder.Click += new System.EventHandler(this.buttonChooseFolder_Click);
            // 
            // textBoxDirectory
            // 
            this.textBoxDirectory.BackColor = System.Drawing.Color.White;
            this.textBoxDirectory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDirectory.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxDirectory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(111)))), ((int)(((byte)(149)))));
            this.textBoxDirectory.Location = new System.Drawing.Point(37, 129);
            this.textBoxDirectory.Name = "textBoxDirectory";
            this.textBoxDirectory.ReadOnly = true;
            this.textBoxDirectory.Size = new System.Drawing.Size(472, 22);
            this.textBoxDirectory.TabIndex = 2;
            this.textBoxDirectory.TabStop = false;
            this.textBoxDirectory.Text = "You have not selected any folder yet.";
            // 
            // textBoxInputFile
            // 
            this.textBoxInputFile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxInputFile.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxInputFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(111)))), ((int)(((byte)(149)))));
            this.textBoxInputFile.Location = new System.Drawing.Point(14, 11);
            this.textBoxInputFile.Name = "textBoxInputFile";
            this.textBoxInputFile.Size = new System.Drawing.Size(397, 22);
            this.textBoxInputFile.TabIndex = 4;
            this.textBoxInputFile.Text = "Filename.txt";
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(52)))), ((int)(((byte)(187)))));
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(241)))), ((int)(((byte)(247)))));
            this.buttonSearch.Location = new System.Drawing.Point(415, 0);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(134, 44);
            this.buttonSearch.TabIndex = 5;
            this.buttonSearch.Text = "Search!";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // graphViewer
            // 
            this.graphViewer.ArrowheadLength = 10D;
            this.graphViewer.AsyncLayout = false;
            this.graphViewer.AutoScroll = true;
            this.graphViewer.BackwardEnabled = false;
            this.graphViewer.BuildHitTree = true;
            this.graphViewer.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.UseSettingsOfTheGraph;
            this.graphViewer.EdgeInsertButtonVisible = true;
            this.graphViewer.FileName = "";
            this.graphViewer.ForwardEnabled = false;
            this.graphViewer.Graph = null;
            this.graphViewer.InsertingEdge = false;
            this.graphViewer.LayoutAlgorithmSettingsButtonVisible = true;
            this.graphViewer.LayoutEditingEnabled = true;
            this.graphViewer.Location = new System.Drawing.Point(515, 173);
            this.graphViewer.LooseOffsetForRouting = 0.25D;
            this.graphViewer.MouseHitDistance = 0.05D;
            this.graphViewer.Name = "graphViewer";
            this.graphViewer.NavigationVisible = true;
            this.graphViewer.NeedToCalculateLayout = true;
            this.graphViewer.OffsetForRelaxingInRouting = 0.6D;
            this.graphViewer.PaddingForEdgeRouting = 8D;
            this.graphViewer.PanButtonPressed = false;
            this.graphViewer.SaveAsImageEnabled = true;
            this.graphViewer.SaveAsMsaglEnabled = true;
            this.graphViewer.SaveButtonVisible = true;
            this.graphViewer.SaveGraphButtonVisible = true;
            this.graphViewer.SaveInVectorFormatEnabled = true;
            this.graphViewer.Size = new System.Drawing.Size(608, 449);
            this.graphViewer.TabIndex = 6;
            this.graphViewer.TightOffsetForRouting = 0.125D;
            this.graphViewer.ToolBarIsVisible = true;
            this.graphViewer.Transform = ((Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation)(resources.GetObject("graphViewer.Transform")));
            this.graphViewer.UndoRedoButtonsVisible = true;
            this.graphViewer.WindowZoomButtonPressed = false;
            this.graphViewer.ZoomF = 1D;
            this.graphViewer.ZoomWindowThreshold = 0.05D;
            // 
            // radioBFS
            // 
            this.radioBFS.AutoSize = true;
            this.radioBFS.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioBFS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(111)))), ((int)(((byte)(149)))));
            this.radioBFS.Location = new System.Drawing.Point(433, 174);
            this.radioBFS.Name = "radioBFS";
            this.radioBFS.Size = new System.Drawing.Size(55, 26);
            this.radioBFS.TabIndex = 7;
            this.radioBFS.Text = "BFS";
            this.radioBFS.UseVisualStyleBackColor = true;
            // 
            // radioDFS
            // 
            this.radioDFS.AutoSize = true;
            this.radioDFS.Checked = true;
            this.radioDFS.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioDFS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(111)))), ((int)(((byte)(149)))));
            this.radioDFS.Location = new System.Drawing.Point(370, 174);
            this.radioDFS.Name = "radioDFS";
            this.radioDFS.Size = new System.Drawing.Size(57, 26);
            this.radioDFS.TabIndex = 8;
            this.radioDFS.TabStop = true;
            this.radioDFS.Text = "DFS";
            this.radioDFS.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(111)))), ((int)(((byte)(149)))));
            this.label3.Location = new System.Drawing.Point(26, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 22);
            this.label3.TabIndex = 9;
            this.label3.Text = "Search settings";
            // 
            // checkBoxOccurence
            // 
            this.checkBoxOccurence.AutoSize = true;
            this.checkBoxOccurence.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxOccurence.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(111)))), ((int)(((byte)(149)))));
            this.checkBoxOccurence.Location = new System.Drawing.Point(323, 274);
            this.checkBoxOccurence.Name = "checkBoxOccurence";
            this.checkBoxOccurence.Size = new System.Drawing.Size(165, 26);
            this.checkBoxOccurence.TabIndex = 12;
            this.checkBoxOccurence.Text = "Find all occurence";
            this.checkBoxOccurence.UseVisualStyleBackColor = true;
            // 
            // labelSearchTime
            // 
            this.labelSearchTime.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSearchTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(111)))), ((int)(((byte)(149)))));
            this.labelSearchTime.Location = new System.Drawing.Point(26, 303);
            this.labelSearchTime.Name = "labelSearchTime";
            this.labelSearchTime.Size = new System.Drawing.Size(462, 28);
            this.labelSearchTime.TabIndex = 13;
            this.labelSearchTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trackBarSpeed
            // 
            this.trackBarSpeed.Location = new System.Drawing.Point(369, 217);
            this.trackBarSpeed.Maximum = 500;
            this.trackBarSpeed.Name = "trackBarSpeed";
            this.trackBarSpeed.Size = new System.Drawing.Size(118, 45);
            this.trackBarSpeed.TabIndex = 14;
            this.trackBarSpeed.Value = 100;
            this.trackBarSpeed.Scroll += new System.EventHandler(this.trackBarSpeed_Scroll);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(241)))), ((int)(((byte)(247)))));
            this.panel1.Controls.Add(this.labelSearchResult);
            this.panel1.Controls.Add(this.labelSearchTime);
            this.panel1.Controls.Add(this.labelCrawlSpeed);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxDirectory);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.trackBarSpeed);
            this.panel1.Controls.Add(this.graphViewer);
            this.panel1.Controls.Add(this.checkBoxOccurence);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.radioDFS);
            this.panel1.Controls.Add(this.radioBFS);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(-1, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1352, 646);
            this.panel1.TabIndex = 15;
            // 
            // labelSearchResult
            // 
            this.labelSearchResult.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSearchResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(111)))), ((int)(((byte)(149)))));
            this.labelSearchResult.Location = new System.Drawing.Point(26, 331);
            this.labelSearchResult.Name = "labelSearchResult";
            this.labelSearchResult.Size = new System.Drawing.Size(461, 28);
            this.labelSearchResult.TabIndex = 22;
            this.labelSearchResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCrawlSpeed
            // 
            this.labelCrawlSpeed.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCrawlSpeed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(111)))), ((int)(((byte)(149)))));
            this.labelCrawlSpeed.Location = new System.Drawing.Point(369, 239);
            this.labelCrawlSpeed.Name = "labelCrawlSpeed";
            this.labelCrawlSpeed.Size = new System.Drawing.Size(118, 23);
            this.labelCrawlSpeed.TabIndex = 21;
            this.labelCrawlSpeed.Text = "100 ms";
            this.labelCrawlSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(111)))), ((int)(((byte)(149)))));
            this.label1.Location = new System.Drawing.Point(26, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 22);
            this.label1.TabIndex = 20;
            this.label1.Text = "Crawl speed (ms)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(111)))), ((int)(((byte)(149)))));
            this.label7.Location = new System.Drawing.Point(155, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 22);
            this.label7.TabIndex = 17;
            this.label7.Text = "and";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Open Sans Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(52)))), ((int)(((byte)(187)))));
            this.label6.Location = new System.Drawing.Point(37, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(355, 22);
            this.label6.TabIndex = 16;
            this.label6.Text = "Search for files and see the process real time.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Open Sans", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.label5.Location = new System.Drawing.Point(26, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(340, 59);
            this.label5.TabIndex = 15;
            this.label5.Text = "Folder Crawler";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.buttonChooseFolder);
            this.panel2.Location = new System.Drawing.Point(26, 118);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(549, 44);
            this.panel2.TabIndex = 18;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.textBoxInputFile);
            this.panel3.Controls.Add(this.buttonSearch);
            this.panel3.Location = new System.Drawing.Point(574, 118);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(549, 44);
            this.panel3.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 647);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button buttonChooseFolder;
        private TextBox textBoxDirectory;
        private TextBox textBoxInputFile;
        private Button buttonSearch;
        private Microsoft.Msagl.GraphViewerGdi.GViewer graphViewer;
        private RadioButton radioBFS;
        private RadioButton radioDFS;
        private Label label3;
        private CheckBox checkBoxOccurence;
        private Label labelSearchTime;
        private TrackBar trackBarSpeed;
        private Panel panel1;
        private Label label5;
        private Label label6;
        private Label label7;
        private Panel panel2;
        private Panel panel3;
        private Label label1;
        private Label labelCrawlSpeed;
        private Label labelSearchResult;
    }
}