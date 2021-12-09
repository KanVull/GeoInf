
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
            this.SuspendLayout();
            // 
            // buttonGetObjects
            // 
            this.buttonGetObjects.Location = new System.Drawing.Point(12, 207);
            this.buttonGetObjects.Name = "buttonGetObjects";
            this.buttonGetObjects.Size = new System.Drawing.Size(196, 23);
            this.buttonGetObjects.TabIndex = 0;
            this.buttonGetObjects.Text = "Get Objects ID";
            this.buttonGetObjects.UseVisualStyleBackColor = true;
            this.buttonGetObjects.Click += new System.EventHandler(this.buttonGetObjects_Click);
            // 
            // buttonGetSelected
            // 
            this.buttonGetSelected.Location = new System.Drawing.Point(12, 262);
            this.buttonGetSelected.Name = "buttonGetSelected";
            this.buttonGetSelected.Size = new System.Drawing.Size(196, 23);
            this.buttonGetSelected.TabIndex = 1;
            this.buttonGetSelected.Text = "Selected Object ID";
            this.buttonGetSelected.UseVisualStyleBackColor = true;
            this.buttonGetSelected.Click += new System.EventHandler(this.buttonGetSelected_Click);
            // 
            // textBoxIDSelectedObject
            // 
            this.textBoxIDSelectedObject.Location = new System.Drawing.Point(12, 236);
            this.textBoxIDSelectedObject.Name = "textBoxIDSelectedObject";
            this.textBoxIDSelectedObject.ReadOnly = true;
            this.textBoxIDSelectedObject.Size = new System.Drawing.Size(196, 20);
            this.textBoxIDSelectedObject.TabIndex = 2;
            // 
            // listBoxObjects
            // 
            this.listBoxObjects.FormattingEnabled = true;
            this.listBoxObjects.Location = new System.Drawing.Point(13, 13);
            this.listBoxObjects.Name = "listBoxObjects";
            this.listBoxObjects.Size = new System.Drawing.Size(196, 186);
            this.listBoxObjects.TabIndex = 3;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 296);
            this.Controls.Add(this.listBoxObjects);
            this.Controls.Add(this.textBoxIDSelectedObject);
            this.Controls.Add(this.buttonGetSelected);
            this.Controls.Add(this.buttonGetObjects);
            this.Name = "mainForm";
            this.Text = "Форма работы с ГИС ИнГЕО";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGetObjects;
        private System.Windows.Forms.Button buttonGetSelected;
        private System.Windows.Forms.TextBox textBoxIDSelectedObject;
        private System.Windows.Forms.ListBox listBoxObjects;
    }
}