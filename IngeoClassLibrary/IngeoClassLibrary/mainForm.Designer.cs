
namespace IngeoClassLibrary
{
    partial class mainForm
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
            this.buttonGetObjects = new System.Windows.Forms.Button();
            this.buttonGetSelected = new System.Windows.Forms.Button();
            this.textBoxIDSelectedObject = new System.Windows.Forms.TextBox();
            this.listBoxObjects = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonDijkstra = new System.Windows.Forms.Button();
            this.listBoxCoordinates = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.listBoxIDs = new System.Windows.Forms.ListBox();
            this.listBoxLength = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonGetObjects
            // 
            this.buttonGetObjects.Location = new System.Drawing.Point(5, 200);
            this.buttonGetObjects.Name = "buttonGetObjects";
            this.buttonGetObjects.Size = new System.Drawing.Size(453, 23);
            this.buttonGetObjects.TabIndex = 0;
            this.buttonGetObjects.Text = "Get Objects ID";
            this.buttonGetObjects.UseVisualStyleBackColor = true;
            this.buttonGetObjects.Click += new System.EventHandler(this.buttonGetObjects_Click);
            // 
            // buttonGetSelected
            // 
            this.buttonGetSelected.Location = new System.Drawing.Point(5, 255);
            this.buttonGetSelected.Name = "buttonGetSelected";
            this.buttonGetSelected.Size = new System.Drawing.Size(453, 23);
            this.buttonGetSelected.TabIndex = 1;
            this.buttonGetSelected.Text = "Selected Object ID";
            this.buttonGetSelected.UseVisualStyleBackColor = true;
            this.buttonGetSelected.Click += new System.EventHandler(this.buttonGetSelected_Click);
            // 
            // textBoxIDSelectedObject
            // 
            this.textBoxIDSelectedObject.Location = new System.Drawing.Point(5, 229);
            this.textBoxIDSelectedObject.Name = "textBoxIDSelectedObject";
            this.textBoxIDSelectedObject.ReadOnly = true;
            this.textBoxIDSelectedObject.Size = new System.Drawing.Size(453, 20);
            this.textBoxIDSelectedObject.TabIndex = 2;
            // 
            // listBoxObjects
            // 
            this.listBoxObjects.FormattingEnabled = true;
            this.listBoxObjects.Location = new System.Drawing.Point(6, 6);
            this.listBoxObjects.Name = "listBoxObjects";
            this.listBoxObjects.Size = new System.Drawing.Size(452, 186);
            this.listBoxObjects.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(472, 432);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listBoxObjects);
            this.tabPage1.Controls.Add(this.buttonGetObjects);
            this.tabPage1.Controls.Add(this.textBoxIDSelectedObject);
            this.tabPage1.Controls.Add(this.buttonGetSelected);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(464, 372);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "IDs";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.listBoxCoordinates);
            this.tabPage2.Controls.Add(this.buttonDijkstra);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(464, 406);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Dijkstra";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonDijkstra
            // 
            this.buttonDijkstra.Location = new System.Drawing.Point(3, 6);
            this.buttonDijkstra.Name = "buttonDijkstra";
            this.buttonDijkstra.Size = new System.Drawing.Size(455, 23);
            this.buttonDijkstra.TabIndex = 0;
            this.buttonDijkstra.Text = "Алгоритм Дейкстры";
            this.buttonDijkstra.UseVisualStyleBackColor = true;
            this.buttonDijkstra.Click += new System.EventHandler(this.buttonDijkstra_Click);
            // 
            // listBoxCoordinates
            // 
            this.listBoxCoordinates.FormattingEnabled = true;
            this.listBoxCoordinates.Location = new System.Drawing.Point(7, 36);
            this.listBoxCoordinates.Name = "listBoxCoordinates";
            this.listBoxCoordinates.Size = new System.Drawing.Size(451, 173);
            this.listBoxCoordinates.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBoxIDs);
            this.groupBox1.Location = new System.Drawing.Point(7, 216);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 125);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IDs";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBoxLength);
            this.groupBox2.Location = new System.Drawing.Point(231, 216);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(227, 125);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Стоимости путей";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxPath);
            this.groupBox3.Location = new System.Drawing.Point(7, 348);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(451, 52);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Результат";
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(7, 20);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.ReadOnly = true;
            this.textBoxPath.Size = new System.Drawing.Size(438, 20);
            this.textBoxPath.TabIndex = 0;
            // 
            // listBoxIDs
            // 
            this.listBoxIDs.FormattingEnabled = true;
            this.listBoxIDs.Location = new System.Drawing.Point(7, 20);
            this.listBoxIDs.Name = "listBoxIDs";
            this.listBoxIDs.Size = new System.Drawing.Size(205, 95);
            this.listBoxIDs.TabIndex = 0;
            // 
            // listBoxLength
            // 
            this.listBoxLength.FormattingEnabled = true;
            this.listBoxLength.Location = new System.Drawing.Point(6, 19);
            this.listBoxLength.Name = "listBoxLength";
            this.listBoxLength.Size = new System.Drawing.Size(215, 95);
            this.listBoxLength.TabIndex = 1;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 456);
            this.Controls.Add(this.tabControl1);
            this.Name = "mainForm";
            this.Text = "Форма работы с ГИС ИнГЕО";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonGetObjects;
        private System.Windows.Forms.Button buttonGetSelected;
        private System.Windows.Forms.TextBox textBoxIDSelectedObject;
        private System.Windows.Forms.ListBox listBoxObjects;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBoxLength;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBoxIDs;
        private System.Windows.Forms.ListBox listBoxCoordinates;
        private System.Windows.Forms.Button buttonDijkstra;
    }
}