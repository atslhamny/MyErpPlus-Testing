using System.Windows.Forms;

namespace Tester
{
   partial class FrmMain
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
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
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
         this.logsitemsBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
         this.statusStrip1 = new System.Windows.Forms.StatusStrip();
         this.LblTest = new System.Windows.Forms.ToolStripStatusLabel();
         this.LblPass = new System.Windows.Forms.ToolStripStatusLabel();
         this.LblFailed = new System.Windows.Forms.ToolStripStatusLabel();
         this.LblProgress = new System.Windows.Forms.ToolStripStatusLabel();
         this.toolStrip1 = new System.Windows.Forms.ToolStrip();
         this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
         this.MnTest = new System.Windows.Forms.ToolStripComboBox();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.BtnStart = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this.BtnOptions = new System.Windows.Forms.ToolStripButton();
         this.tabControl1 = new System.Windows.Forms.TabControl();
         this.tabPage1 = new System.Windows.Forms.TabPage();
         this.web1 = new Microsoft.Web.WebView2.WinForms.WebView2();
         this.tabPage2 = new System.Windows.Forms.TabPage();
         this.dataGridView2 = new System.Windows.Forms.DataGridView();
         this.positifNegatifDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.stopwatch = new System.Windows.Forms.DataGridViewTextBoxColumn();
         ((System.ComponentModel.ISupportInitialize)(this.logsitemsBindingSource2)).BeginInit();
         this.statusStrip1.SuspendLayout();
         this.toolStrip1.SuspendLayout();
         this.tabControl1.SuspendLayout();
         this.tabPage1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.web1)).BeginInit();
         this.tabPage2.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
         this.SuspendLayout();
         // 
         // logsitemsBindingSource2
         // 
         this.logsitemsBindingSource2.DataSource = typeof(Tester.LogItem);
         // 
         // statusStrip1
         // 
         this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LblTest,
            this.LblPass,
            this.LblFailed,
            this.LblProgress});
         this.statusStrip1.Location = new System.Drawing.Point(0, 480);
         this.statusStrip1.Name = "statusStrip1";
         this.statusStrip1.Size = new System.Drawing.Size(1366, 24);
         this.statusStrip1.TabIndex = 2;
         this.statusStrip1.Text = "statusStrip1";
         // 
         // LblTest
         // 
         this.LblTest.Name = "LblTest";
         this.LblTest.Size = new System.Drawing.Size(42, 19);
         this.LblTest.Text = "Test : 0";
         // 
         // LblPass
         // 
         this.LblPass.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
         this.LblPass.Name = "LblPass";
         this.LblPass.Size = new System.Drawing.Size(49, 19);
         this.LblPass.Text = "Pass : 0";
         // 
         // LblFailed
         // 
         this.LblFailed.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
         this.LblFailed.Name = "LblFailed";
         this.LblFailed.Size = new System.Drawing.Size(44, 19);
         this.LblFailed.Text = "Fail : 0";
         // 
         // LblProgress
         // 
         this.LblProgress.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
         this.LblProgress.Name = "LblProgress";
         this.LblProgress.Size = new System.Drawing.Size(56, 19);
         this.LblProgress.Text = "Progress";
         // 
         // toolStrip1
         // 
         this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.MnTest,
            this.toolStripSeparator1,
            this.BtnStart,
            this.toolStripSeparator2,
            this.BtnOptions});
         this.toolStrip1.Location = new System.Drawing.Point(0, 0);
         this.toolStrip1.Name = "toolStrip1";
         this.toolStrip1.Size = new System.Drawing.Size(1366, 25);
         this.toolStrip1.TabIndex = 3;
         this.toolStrip1.Text = "toolStrip1";
         // 
         // toolStripLabel1
         // 
         this.toolStripLabel1.Name = "toolStripLabel1";
         this.toolStripLabel1.Size = new System.Drawing.Size(36, 22);
         this.toolStripLabel1.Text = "Test : ";
         // 
         // MnTest
         // 
         this.MnTest.Items.AddRange(new object[] {
            "Finance and Accounting",
            "Warehouse and Inventory",
            "Purchasing",
            "Sales",
            "Production",
            "Fix Asset"});
         this.MnTest.Name = "MnTest";
         this.MnTest.Size = new System.Drawing.Size(121, 25);
         this.MnTest.Text = "All DataMaster";
         this.MnTest.SelectedIndexChanged += new System.EventHandler(this.MnTest_SelectedIndexChanged);
         this.MnTest.Click += new System.EventHandler(this.MnTest_Click);
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
         // 
         // BtnStart
         // 
         this.BtnStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
         this.BtnStart.Image = ((System.Drawing.Image)(resources.GetObject("BtnStart.Image")));
         this.BtnStart.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.BtnStart.Name = "BtnStart";
         this.BtnStart.Size = new System.Drawing.Size(35, 22);
         this.BtnStart.Text = "Start";
         this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
         // 
         // toolStripSeparator2
         // 
         this.toolStripSeparator2.Name = "toolStripSeparator2";
         this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
         // 
         // BtnOptions
         // 
         this.BtnOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
         this.BtnOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnOptions.Image")));
         this.BtnOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.BtnOptions.Name = "BtnOptions";
         this.BtnOptions.Size = new System.Drawing.Size(53, 22);
         this.BtnOptions.Text = "Options";
         this.BtnOptions.Click += new System.EventHandler(this.BtnOptions_Click);
         // 
         // tabControl1
         // 
         this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
         this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tabControl1.Controls.Add(this.tabPage1);
         this.tabControl1.Controls.Add(this.tabPage2);
         this.tabControl1.Location = new System.Drawing.Point(3, 28);
         this.tabControl1.Multiline = true;
         this.tabControl1.Name = "tabControl1";
         this.tabControl1.SelectedIndex = 0;
         this.tabControl1.Size = new System.Drawing.Size(1351, 449);
         this.tabControl1.TabIndex = 4;
         // 
         // tabPage1
         // 
         this.tabPage1.Controls.Add(this.web1);
         this.tabPage1.Location = new System.Drawing.Point(4, 4);
         this.tabPage1.Name = "tabPage1";
         this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
         this.tabPage1.Size = new System.Drawing.Size(1343, 423);
         this.tabPage1.TabIndex = 2;
         this.tabPage1.Text = "Process";
         this.tabPage1.UseVisualStyleBackColor = true;
         // 
         // web1
         // 
         this.web1.AllowExternalDrop = true;
         this.web1.CreationProperties = null;
         this.web1.DefaultBackgroundColor = System.Drawing.Color.White;
         this.web1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.web1.Location = new System.Drawing.Point(3, 3);
         this.web1.Name = "web1";
         this.web1.Size = new System.Drawing.Size(1337, 417);
         this.web1.TabIndex = 6;
         this.web1.ZoomFactor = 1D;
         // 
         // tabPage2
         // 
         this.tabPage2.Controls.Add(this.dataGridView2);
         this.tabPage2.Location = new System.Drawing.Point(4, 4);
         this.tabPage2.Name = "tabPage2";
         this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
         this.tabPage2.Size = new System.Drawing.Size(1343, 423);
         this.tabPage2.TabIndex = 1;
         this.tabPage2.Text = "Logs";
         this.tabPage2.UseVisualStyleBackColor = true;
         // 
         // dataGridView2
         // 
         this.dataGridView2.AutoGenerateColumns = false;
         this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
         this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.positifNegatifDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.stopwatch});
         this.dataGridView2.DataSource = this.logsitemsBindingSource2;
         this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dataGridView2.Location = new System.Drawing.Point(3, 3);
         this.dataGridView2.Name = "dataGridView2";
         this.dataGridView2.RowHeadersVisible = false;
         this.dataGridView2.Size = new System.Drawing.Size(1337, 417);
         this.dataGridView2.TabIndex = 1;
         // 
         // positifNegatifDataGridViewTextBoxColumn
         // 
         this.positifNegatifDataGridViewTextBoxColumn.DataPropertyName = "PositifNegatif";
         this.positifNegatifDataGridViewTextBoxColumn.HeaderText = "Positif/Negatif";
         this.positifNegatifDataGridViewTextBoxColumn.Name = "positifNegatifDataGridViewTextBoxColumn";
         // 
         // dataGridViewTextBoxColumn2
         // 
         this.dataGridViewTextBoxColumn2.DataPropertyName = "Process";
         this.dataGridViewTextBoxColumn2.HeaderText = "Process";
         this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
         // 
         // dataGridViewTextBoxColumn3
         // 
         this.dataGridViewTextBoxColumn3.DataPropertyName = "Result";
         this.dataGridViewTextBoxColumn3.HeaderText = "Result";
         this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
         // 
         // stopwatch
         // 
         this.stopwatch.DataPropertyName = "StopWatch";
         this.stopwatch.HeaderText = "StopWatch";
         this.stopwatch.Name = "stopwatch";
         // 
         // FrmMain
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1366, 504);
         this.Controls.Add(this.tabControl1);
         this.Controls.Add(this.toolStrip1);
         this.Controls.Add(this.statusStrip1);
         this.Name = "FrmMain";
         this.Text = "MyERP Serenity | Tester";
         this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
         ((System.ComponentModel.ISupportInitialize)(this.logsitemsBindingSource2)).EndInit();
         this.statusStrip1.ResumeLayout(false);
         this.statusStrip1.PerformLayout();
         this.toolStrip1.ResumeLayout(false);
         this.toolStrip1.PerformLayout();
         this.tabControl1.ResumeLayout(false);
         this.tabPage1.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.web1)).EndInit();
         this.tabPage2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion
      private BindingSource logsitemsBindingSource2;
      private StatusStrip statusStrip1;
      private ToolStripStatusLabel LblTest;
      private ToolStripStatusLabel LblPass;
      private ToolStripStatusLabel LblFailed;
      private ToolStripStatusLabel LblProgress;
      private ToolStrip toolStrip1;
      private ToolStripLabel toolStripLabel1;
      private ToolStripComboBox MnTest;
      private ToolStripSeparator toolStripSeparator1;
      private ToolStripButton BtnStart;
      private ToolStripSeparator toolStripSeparator2;
      private ToolStripButton BtnOptions;
      private TabControl tabControl1;
      private TabPage tabPage2;
      private DataGridView dataGridView2;
      private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
      private DataGridViewTextBoxColumn positifNegatifDataGridViewTextBoxColumn;
      private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
      private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
      private DataGridViewTextBoxColumn stopwatch;
      private TabPage tabPage1;
      public Microsoft.Web.WebView2.WinForms.WebView2 web1;
   }
}

