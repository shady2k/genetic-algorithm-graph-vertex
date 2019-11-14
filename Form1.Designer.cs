namespace gavg
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation planeTransformation3 = new Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation();
            Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation planeTransformation4 = new Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation();
            this.button1 = new System.Windows.Forms.Button();
            this.gViewer1 = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            this.gViewer2 = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            this.dgvAdjacency = new System.Windows.Forms.DataGridView();
            this.tbChromosomes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.A = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.B = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdjacency)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 580);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Рассчитать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gViewer1
            // 
            this.gViewer1.ArrowheadLength = 10D;
            this.gViewer1.AsyncLayout = false;
            this.gViewer1.AutoScroll = true;
            this.gViewer1.BackColor = System.Drawing.Color.White;
            this.gViewer1.BackwardEnabled = false;
            this.gViewer1.BuildHitTree = true;
            this.gViewer1.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.UseSettingsOfTheGraph;
            this.gViewer1.EdgeInsertButtonVisible = true;
            this.gViewer1.FileName = "";
            this.gViewer1.ForwardEnabled = false;
            this.gViewer1.Graph = null;
            this.gViewer1.InsertingEdge = false;
            this.gViewer1.LayoutAlgorithmSettingsButtonVisible = true;
            this.gViewer1.LayoutEditingEnabled = true;
            this.gViewer1.Location = new System.Drawing.Point(268, 28);
            this.gViewer1.LooseOffsetForRouting = 0.25D;
            this.gViewer1.MouseHitDistance = 0.05D;
            this.gViewer1.Name = "gViewer1";
            this.gViewer1.NavigationVisible = true;
            this.gViewer1.NeedToCalculateLayout = true;
            this.gViewer1.OffsetForRelaxingInRouting = 0.6D;
            this.gViewer1.PaddingForEdgeRouting = 8D;
            this.gViewer1.PanButtonPressed = false;
            this.gViewer1.SaveAsImageEnabled = true;
            this.gViewer1.SaveAsMsaglEnabled = true;
            this.gViewer1.SaveButtonVisible = true;
            this.gViewer1.SaveGraphButtonVisible = true;
            this.gViewer1.SaveInVectorFormatEnabled = true;
            this.gViewer1.Size = new System.Drawing.Size(361, 277);
            this.gViewer1.TabIndex = 4;
            this.gViewer1.TightOffsetForRouting = 0.125D;
            this.gViewer1.ToolBarIsVisible = false;
            this.gViewer1.Transform = planeTransformation3;
            this.gViewer1.UndoRedoButtonsVisible = true;
            this.gViewer1.WindowZoomButtonPressed = false;
            this.gViewer1.ZoomF = 1D;
            this.gViewer1.ZoomWindowThreshold = 0.05D;
            // 
            // gViewer2
            // 
            this.gViewer2.ArrowheadLength = 10D;
            this.gViewer2.AsyncLayout = false;
            this.gViewer2.AutoScroll = true;
            this.gViewer2.BackColor = System.Drawing.Color.White;
            this.gViewer2.BackwardEnabled = false;
            this.gViewer2.BuildHitTree = true;
            this.gViewer2.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.UseSettingsOfTheGraph;
            this.gViewer2.EdgeInsertButtonVisible = true;
            this.gViewer2.FileName = "";
            this.gViewer2.ForwardEnabled = false;
            this.gViewer2.Graph = null;
            this.gViewer2.InsertingEdge = false;
            this.gViewer2.LayoutAlgorithmSettingsButtonVisible = true;
            this.gViewer2.LayoutEditingEnabled = true;
            this.gViewer2.Location = new System.Drawing.Point(268, 326);
            this.gViewer2.LooseOffsetForRouting = 0.25D;
            this.gViewer2.MouseHitDistance = 0.05D;
            this.gViewer2.Name = "gViewer2";
            this.gViewer2.NavigationVisible = true;
            this.gViewer2.NeedToCalculateLayout = true;
            this.gViewer2.OffsetForRelaxingInRouting = 0.6D;
            this.gViewer2.PaddingForEdgeRouting = 8D;
            this.gViewer2.PanButtonPressed = false;
            this.gViewer2.SaveAsImageEnabled = true;
            this.gViewer2.SaveAsMsaglEnabled = true;
            this.gViewer2.SaveButtonVisible = true;
            this.gViewer2.SaveGraphButtonVisible = true;
            this.gViewer2.SaveInVectorFormatEnabled = true;
            this.gViewer2.Size = new System.Drawing.Size(361, 277);
            this.gViewer2.TabIndex = 5;
            this.gViewer2.TightOffsetForRouting = 0.125D;
            this.gViewer2.ToolBarIsVisible = false;
            this.gViewer2.Transform = planeTransformation4;
            this.gViewer2.UndoRedoButtonsVisible = true;
            this.gViewer2.WindowZoomButtonPressed = false;
            this.gViewer2.ZoomF = 1D;
            this.gViewer2.ZoomWindowThreshold = 0.05D;
            // 
            // dgvAdjacency
            // 
            this.dgvAdjacency.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdjacency.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.A,
            this.B});
            this.dgvAdjacency.Location = new System.Drawing.Point(12, 326);
            this.dgvAdjacency.Name = "dgvAdjacency";
            this.dgvAdjacency.Size = new System.Drawing.Size(229, 234);
            this.dgvAdjacency.TabIndex = 6;
            this.dgvAdjacency.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // tbChromosomes
            // 
            this.tbChromosomes.Location = new System.Drawing.Point(12, 28);
            this.tbChromosomes.Multiline = true;
            this.tbChromosomes.Name = "tbChromosomes";
            this.tbChromosomes.Size = new System.Drawing.Size(229, 277);
            this.tbChromosomes.TabIndex = 7;
            this.tbChromosomes.Text = "1, 2, 3, 4, 5\r\n2, 1, 3, 4, 5\r\n1, 5, 3, 4, 2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Список хромосом:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 310);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Матрица смежности:";
            // 
            // A
            // 
            this.A.HeaderText = "A";
            this.A.Name = "A";
            this.A.Width = 50;
            // 
            // B
            // 
            this.B.HeaderText = "B";
            this.B.Name = "B";
            this.B.Width = 50;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(265, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Первоначальный набор хромосом:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(265, 310);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Набор хромосом после мутации:";
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(635, 28);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.Size = new System.Drawing.Size(258, 575);
            this.tbLog.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(632, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Отчет:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 624);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbChromosomes);
            this.Controls.Add(this.dgvAdjacency);
            this.Controls.Add(this.gViewer2);
            this.Controls.Add(this.gViewer1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Генетический алгоритм размещения вершин графа";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdjacency)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private Microsoft.Msagl.GraphViewerGdi.GViewer gViewer1;
        private Microsoft.Msagl.GraphViewerGdi.GViewer gViewer2;
        private System.Windows.Forms.DataGridView dgvAdjacency;
        private System.Windows.Forms.TextBox tbChromosomes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn A;
        private System.Windows.Forms.DataGridViewTextBoxColumn B;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.Label label5;
    }
}

