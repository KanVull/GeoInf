
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBoxLength = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBoxIDs = new System.Windows.Forms.ListBox();
            this.listBoxCoordinates = new System.Windows.Forms.ListBox();
            this.buttonDijkstra = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txbLegalSquare = new System.Windows.Forms.TextBox();
            this.txbFactSquare = new System.Windows.Forms.TextBox();
            this.txbDeltaSquare = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbStatus = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
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
            this.tabControl1.Controls.Add(this.tabPage3);
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
            this.tabPage1.Size = new System.Drawing.Size(464, 406);
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
            // listBoxLength
            // 
            this.listBoxLength.FormattingEnabled = true;
            this.listBoxLength.Location = new System.Drawing.Point(6, 19);
            this.listBoxLength.Name = "listBoxLength";
            this.listBoxLength.Size = new System.Drawing.Size(215, 95);
            this.listBoxLength.TabIndex = 1;
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
            // listBoxIDs
            // 
            this.listBoxIDs.FormattingEnabled = true;
            this.listBoxIDs.Location = new System.Drawing.Point(7, 20);
            this.listBoxIDs.Name = "listBoxIDs";
            this.listBoxIDs.Size = new System.Drawing.Size(205, 95);
            this.listBoxIDs.TabIndex = 0;
            // 
            // listBoxCoordinates
            // 
            this.listBoxCoordinates.FormattingEnabled = true;
            this.listBoxCoordinates.Location = new System.Drawing.Point(7, 36);
            this.listBoxCoordinates.Name = "listBoxCoordinates";
            this.listBoxCoordinates.Size = new System.Drawing.Size(451, 173);
            this.listBoxCoordinates.TabIndex = 1;
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
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnSave);
            this.tabPage3.Controls.Add(this.txbStatus);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.txbDeltaSquare);
            this.tabPage3.Controls.Add(this.txbFactSquare);
            this.tabPage3.Controls.Add(this.txbLegalSquare);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(464, 406);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Law";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registered area";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Actual area";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Area deviation";
            // 
            // txbLegalSquare
            // 
            this.txbLegalSquare.Location = new System.Drawing.Point(97, 47);
            this.txbLegalSquare.Name = "txbLegalSquare";
            this.txbLegalSquare.ReadOnly = true;
            this.txbLegalSquare.Size = new System.Drawing.Size(361, 20);
            this.txbLegalSquare.TabIndex = 3;
            // 
            // txbFactSquare
            // 
            this.txbFactSquare.Location = new System.Drawing.Point(97, 78);
            this.txbFactSquare.Name = "txbFactSquare";
            this.txbFactSquare.ReadOnly = true;
            this.txbFactSquare.Size = new System.Drawing.Size(361, 20);
            this.txbFactSquare.TabIndex = 4;
            // 
            // txbDeltaSquare
            // 
            this.txbDeltaSquare.Location = new System.Drawing.Point(97, 108);
            this.txbDeltaSquare.Name = "txbDeltaSquare";
            this.txbDeltaSquare.ReadOnly = true;
            this.txbDeltaSquare.Size = new System.Drawing.Size(361, 20);
            this.txbDeltaSquare.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Object status:";
            // 
            // txbStatus
            // 
            this.txbStatus.Location = new System.Drawing.Point(6, 153);
            this.txbStatus.Multiline = true;
            this.txbStatus.Name = "txbStatus";
            this.txbStatus.ReadOnly = true;
            this.txbStatus.Size = new System.Drawing.Size(452, 95);
            this.txbStatus.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(6, 254);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(452, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Lagality of construction";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
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
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txbStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbDeltaSquare;
        private System.Windows.Forms.TextBox txbFactSquare;
        private System.Windows.Forms.TextBox txbLegalSquare;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}