﻿/////////////////////////////////////////////////////////////////////
//
//	TestPdfFileWriter II
//	Test/demo program for PdfFileWrite C# Class Library.
//
//	EnumFontFamilies
//	Enumerate all Truetype font families in your computer.
//
//	Author: Uzi Granot
//	Original Version: 1.0
//	Date: April 1, 2013
//	Major rewrite Version: 2.0
//	Date: February 1, 2022
//	Copyright (C) 2013-2022 Uzi Granot. All Rights Reserved
//
//	PdfFileWriter C# class library and TestPdfFileWriter test/demo
//  application are free software. They are distributed under the
//  Code Project Open License (CPOL-1.02).
//
//	The main points of CPOL-1.02 subject to the terms of the License are:
//
//	Source Code and Executable Files can be used in commercial applications;
//	Source Code and Executable Files can be redistributed; and
//	Source Code can be modified to create derivative works.
//	No claim of suitability, guarantee, or any warranty whatsoever is
//	provided. The software is provided "as-is".
//	The Article accompanying the Work may not be distributed or republished
//	without the Author's consent
//
//	The document PdfFileWriterLicense.pdf contained within
//	the distribution specify the license agreement and other
//	conditions and notes. You must read this document and agree
//	with the conditions specified in order to use this software.
//
//	For version history please refer to PdfDocument.cs
//
/////////////////////////////////////////////////////////////////////

using PdfFileWriter;
using System.Text;


namespace TestPdfFileWriter
	{
	/// <summary>
	/// Test font api main program
	/// </summary>
	public partial class EnumFontFamilies : Form
		{
		// data grid display of available font families and font sample
		private CustomDataGridView DataGrid;

		// Font family data grid view columns
		private enum FontFamilyColumn
			{
			Name,
			Sample,
			Family,
			Style
			}

		private readonly string[] FamilyType =
			new string[] { "Unknown", "Roman", "Swiss", "Modern", "Script", "Decorative" };

		/// <summary>
		/// Test font api class constructor 
		/// </summary>
		public EnumFontFamilies()
			{
			InitializeComponent();
			return;
			}

		/////////////////////////////////////////////////////////////////////
		// Test font api class initialization
		/////////////////////////////////////////////////////////////////////
		private void OnLoad
				(
				object sender,
				EventArgs e
				)
			{
			// add data grid
			DataGrid = new CustomDataGridView(this, false);
			DataGrid.CellFormatting += new DataGridViewCellFormattingEventHandler(OnCellFormatting);
			DataGrid.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(OnMouseDoubleClick);

			// add columns
			DataGrid.Columns.Add("FontFamilyName", "FontFamilyName");
			DataGrid.Columns.Add("Sample", "Sample");
			DataGrid.Columns.Add("Type", "Type");
			DataGrid.Columns.Add("Style", "Style");

			// load available font families array
			FontFamily[] FamilyArray = FontFamily.Families;
			foreach(FontFamily FF in FamilyArray)
				{
				// look for first available style for current font family
				int StyleIndex;
				FontStyle Style = FontStyle.Regular;
				StringBuilder StyleStr = new StringBuilder();
				string[] StyleCode = new string[] { "R,", "B,", "I,", "BI," };

				// try regulaar, bold, italic and bold-italic
				for(StyleIndex = 0; StyleIndex < 4; StyleIndex++)
					{
					if(!FF.IsStyleAvailable((FontStyle) StyleIndex)) continue;
					if(StyleStr.Length == 0) Style = (FontStyle) StyleIndex;
					StyleStr.Append(StyleCode[StyleIndex]);
					}

				// should not happen
				if(StyleStr.Length == 0) continue;

				// remove last comma
				StyleStr.Length--;

				// add one data grid row
				int Row = DataGrid.Rows.Add();
				DataGridViewRow ViewRow = DataGrid.Rows[Row];

				// save font family in row's tag
				ViewRow.Tag = FF;

				// design height
				int DesignHeight = FF.GetEmHeight(Style);

				// create font
				Font DesignFont = new Font(FF, DesignHeight, Style, GraphicsUnit.Pixel);

				// create windows sdk font info object
				PdfFontApi FontInfo = new PdfFontApi(DesignFont);

				WinTextMetric TM = FontInfo.GetTextMetricsApi();
				string Type = FamilyType[TM.tmPitchAndFamily >> 4];
				if((TM.tmPitchAndFamily & 1) == 0) Type += ",Fix";
				if((TM.tmPitchAndFamily & 2) == 0) Type += ",Bmap";
				if((TM.tmPitchAndFamily & 4) != 0) Type += ",TT";
				if((TM.tmPitchAndFamily & 8) != 0) Type += ",Dev";

				// set value of each column
				ViewRow.Cells[(int) FontFamilyColumn.Name].Value = FF.Name;
				ViewRow.Cells[(int) FontFamilyColumn.Sample].Value = "ABCDabcd0123";
				ViewRow.Cells[(int) FontFamilyColumn.Family].Value = Type;
				ViewRow.Cells[(int) FontFamilyColumn.Style].Value = StyleStr.ToString();

				// create a font for the display of the sample
				ViewRow.Cells[(int) FontFamilyColumn.Sample].Tag = new Font(FF, 12, Style);
				}

			// select first row
			if(DataGrid.Rows.Count > 0) DataGrid.Rows[0].Selected = true;

			// force resize
			OnResize(this, null);

			// exit
			return;
			}

		/// <summary>
		/// Format sample text to font family
		/// </summary>
		/// <param name="sender">Sander</param>
		/// <param name="e">Event</param>
		public void OnCellFormatting
				(
				object sender,
				DataGridViewCellFormattingEventArgs e
				)
			{
			// change font for sample column
			if(e.ColumnIndex == (int) FontFamilyColumn.Sample)
				e.CellStyle.Font = (Font) DataGrid[e.ColumnIndex, e.RowIndex].Tag;
			return;
			}

		////////////////////////////////////////////////////////////////////
		// user double click a line: display object
		////////////////////////////////////////////////////////////////////
		private void OnMouseDoubleClick
				(
				object sender,
				DataGridViewCellMouseEventArgs e
				)
			{
			if(e.Button == MouseButtons.Left && e.RowIndex >= 0)
				{
				DisplayObject((FontFamily) DataGrid.Rows[e.RowIndex].Tag);
				}
			return;
			}

		////////////////////////////////////////////////////////////////////
		// user click view button: display object
		////////////////////////////////////////////////////////////////////
		private void OnView
				(
				object sender,
				EventArgs e
				)
			{
			DataGridViewSelectedRowCollection Rows = DataGrid.SelectedRows;
			if(Rows == null || Rows.Count == 0) return;
			DisplayObject((FontFamily) Rows[0].Tag);
			return;
			}

		////////////////////////////////////////////////////////////////////
		// display object
		////////////////////////////////////////////////////////////////////
		private void DisplayObject
				(
				FontFamily Obj
				)
			{
			// create font information dialog
			FontInfoForm FontInfoDialog = new FontInfoForm(Obj);

			// show the dialog
			FontInfoDialog.ShowDialog(this);
			return;
			}

		////////////////////////////////////////////////////////////////////
		// Resize form
		////////////////////////////////////////////////////////////////////
		private void OnResize
				(
				object sender,
				EventArgs e
				)
			{
			// protect against minimize button
			if(ClientSize.Width == 0)
				return;

			// buttons
			ButtonsGroupBox.Left = (ClientSize.Width - ButtonsGroupBox.Width) / 2;
			ButtonsGroupBox.Top = ClientSize.Height - ButtonsGroupBox.Height - 4;

			// position datagrid
			if(DataGrid != null)
				{
				DataGrid.Left = 2;
				DataGrid.Top = 2;
				DataGrid.Width = ClientSize.Width - 4;
				DataGrid.Height = ButtonsGroupBox.Top - 4;
				}

			// exit
			return;
			}

		////////////////////////////////////////////////////////////////////
		// User pressed on Exit button
		////////////////////////////////////////////////////////////////////
		private void OnExit
				(
				object sender,
				EventArgs e
				)
			{
			Close();
			return;
			}
		}
	}
