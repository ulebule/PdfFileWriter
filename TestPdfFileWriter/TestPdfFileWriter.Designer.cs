﻿namespace TestPdfFileWriter {
    partial class TestPdfFileWriter {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
        if (disposing && (components != null)) {
        components.Dispose();
        }
        base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
			this.ArticleButton = new System.Windows.Forms.Button();
			this.GraphicsButton = new System.Windows.Forms.Button();
			this.DebugCheckBox = new System.Windows.Forms.CheckBox();
			this.CopyrightTextBox = new System.Windows.Forms.RichTextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.AcroFieldsButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// ArticleButton
			// 
			this.ArticleButton.Location = new System.Drawing.Point(11, 342);
			this.ArticleButton.Name = "ArticleButton";
			this.ArticleButton.Size = new System.Drawing.Size(77, 54);
			this.ArticleButton.TabIndex = 1;
			this.ArticleButton.Text = "Article\nExample";
			this.ArticleButton.UseVisualStyleBackColor = true;
			this.ArticleButton.Click += new System.EventHandler(this.OnArticleExample);
			// 
			// GraphicsButton
			// 
			this.GraphicsButton.Location = new System.Drawing.Point(96, 342);
			this.GraphicsButton.Name = "GraphicsButton";
			this.GraphicsButton.Size = new System.Drawing.Size(77, 54);
			this.GraphicsButton.TabIndex = 2;
			this.GraphicsButton.Text = "Other\nExample";
			this.GraphicsButton.UseVisualStyleBackColor = true;
			this.GraphicsButton.Click += new System.EventHandler(this.OnOtherExample);
			// 
			// DebugCheckBox
			// 
			this.DebugCheckBox.AutoSize = true;
			this.DebugCheckBox.Location = new System.Drawing.Point(530, 303);
			this.DebugCheckBox.Name = "DebugCheckBox";
			this.DebugCheckBox.Size = new System.Drawing.Size(63, 20);
			this.DebugCheckBox.TabIndex = 9;
			this.DebugCheckBox.Text = "Debug";
			this.DebugCheckBox.UseVisualStyleBackColor = true;
			this.DebugCheckBox.CheckedChanged += new System.EventHandler(this.OnDebugCheck);
			// 
			// CopyrightTextBox
			// 
			this.CopyrightTextBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.CopyrightTextBox.Location = new System.Drawing.Point(16, 12);
			this.CopyrightTextBox.MaxLength = 2048;
			this.CopyrightTextBox.Name = "CopyrightTextBox";
			this.CopyrightTextBox.ReadOnly = true;
			this.CopyrightTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.CopyrightTextBox.Size = new System.Drawing.Size(582, 268);
			this.CopyrightTextBox.TabIndex = 0;
			this.CopyrightTextBox.Text = "";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(521, 342);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(77, 54);
			this.button1.TabIndex = 6;
			this.button1.Text = "Font\nFamilies";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.OnFontFamilies);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(436, 342);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(77, 54);
			this.button2.TabIndex = 7;
			this.button2.Text = "Print\nExample";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.OnPrintExample);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(181, 342);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(77, 54);
			this.button3.TabIndex = 3;
			this.button3.Text = "Table\nExample";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.OnTableExample);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(351, 342);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(77, 54);
			this.button4.TabIndex = 5;
			this.button4.Text = "Layers\nExample";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.OnLayersExample);
			// 
			// AcroFieldsButton
			// 
			this.AcroFieldsButton.Location = new System.Drawing.Point(266, 342);
			this.AcroFieldsButton.Name = "AcroFieldsButton";
			this.AcroFieldsButton.Size = new System.Drawing.Size(77, 54);
			this.AcroFieldsButton.TabIndex = 4;
			this.AcroFieldsButton.Text = "Form\nExample";
			this.AcroFieldsButton.UseVisualStyleBackColor = true;
			this.AcroFieldsButton.Click += new System.EventHandler(this.OnAcroFields);
			// 
			// TestPdfFileWriter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(614, 408);
			this.Controls.Add(this.AcroFieldsButton);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.CopyrightTextBox);
			this.Controls.Add(this.DebugCheckBox);
			this.Controls.Add(this.GraphicsButton);
			this.Controls.Add(this.ArticleButton);
			this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "TestPdfFileWriter";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Test PDF File Writer";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
			this.Load += new System.EventHandler(this.OnLoad);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ArticleButton;
		private System.Windows.Forms.Button GraphicsButton;
		private System.Windows.Forms.CheckBox DebugCheckBox;
		private System.Windows.Forms.RichTextBox CopyrightTextBox;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button AcroFieldsButton;
		}
}

