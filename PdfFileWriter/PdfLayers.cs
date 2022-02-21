﻿/////////////////////////////////////////////////////////////////////
//
//	PdfFileWriter II
//	PDF File Write C# Class Library.
//
//	PdfLayers class
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

using System.Text;

namespace PdfFileWriter
	{
	/// <summary>
	/// Layers list mode enumeration
	/// </summary>
	public enum ListMode
		{
		/// <summary>
		/// List all layers
		/// </summary>
		AllPages,

		/// <summary>
		/// List layers for visible pages
		/// </summary>
		VisiblePages,
		}

	/// <summary>
	/// PdfLayers control class
	/// </summary>
	public class PdfLayers : PdfObject
		{
		/// <summary>
		/// Layers name
		/// </summary>
		public string Name {get; set;}

		/// <summary>
		/// Layers list mode
		/// </summary>
		public ListMode ListMode {get; set;}

		internal List<PdfLayer> LayerList;
		internal List<object> OrderList;

		/// <summary>
		/// Layers constructor
		/// </summary>
		/// <param name="Document">PDF Document</param>
		/// <param name="Name">Layers name</param>
		public PdfLayers
				(
				PdfDocument Document,
				string Name
				) : base(Document)
			{
			// Make sure it is done only once
			if(Document.Layers != null) throw new ApplicationException("PdfLayers is already defined");

			// save arguments
			this.Name = Name;

			// save this object within the document object
			Document.Layers = this;

			// create layers empty list for all layers
			LayerList = new List<PdfLayer>();
			OrderList = new List<object>();
			return;
			}

		/// <summary>
		/// Layer's display order in layers panel
		/// </summary>
		/// <param name="Layer">Layer object</param>
		public void DisplayOrder
				(
				PdfLayer Layer
				)
			{
			OrderList.Add(Layer);
			return;
			}

		/// <summary>
		/// Layer's display order group start marker
		/// </summary>
		/// <param name="GroupName">Optional group name</param>
		public void DisplayOrderStartGroup
				(
				string GroupName = ""
				)
			{
			OrderList.Add(GroupName);
			return;
			}

		/// <summary>
		/// Layer's display order group end marker
		/// </summary>
		public void DisplayOrderEndGroup()
			{
			OrderList.Add(0);
			return;
			}

		// add layers object to document catalog
		internal void CreateDictionary()
			{ 
			// build array of all layers
			StringBuilder AllLayers = new StringBuilder("[");
			StringBuilder LockedLayers = new StringBuilder("[");
			List<PdfLayer> RadioButtons = new List<PdfLayer>();
			foreach(PdfLayer Layer in LayerList)
				{
				AllLayers.AppendFormat("{0} 0 R ", Layer.ObjectNumber);
				if(Layer.Locked == LockLayer.Locked) LockedLayers.AppendFormat("{0} 0 R ", Layer.ObjectNumber);
				if(!string.IsNullOrWhiteSpace(Layer.RadioButton)) RadioButtons.Add(Layer);
				}
			AllLayers.Length--;
			AllLayers.Append(']');

			// add all layers array to the dictionary
			Dictionary.Add("/OCGs", AllLayers.ToString());

			// create default /D dictionary
			PdfDictionary DefaultDict = new PdfDictionary(this);

			// name
			DefaultDict.AddPdfString("/Name", Name);

			// list mode
			DefaultDict.AddName("/ListMode", ListMode.ToString());

			// build array of locked layers
			LockedLayers.Length--;
			if(LockedLayers.Length != 0)
				{ 
				LockedLayers.Append(']');
				DefaultDict.Add("/Locked", LockedLayers.ToString());
				}

			// add array to OCPD
			if(OrderList.Count == 0)
				{
				DefaultDict.Add("/Order", AllLayers.ToString());
				}
			else
				{ 
				StringBuilder OrderArray = new StringBuilder("[");
				foreach(object Item in OrderList)
					{
					if(Item.GetType() == typeof(PdfLayer))
						{
						OrderArray.AppendFormat("{0} 0 R ", ((PdfLayer) Item).ObjectNumber);
						}
					else if(Item.GetType() == typeof(string))
						{
						if(OrderArray[^1] == ' ') OrderArray.Length--;
						OrderArray.Append('[');
						if((string) Item != "") OrderArray.Append(TextToPdfString((string) Item, this));
						}
					else if(Item.GetType() == typeof(int) && ((int) Item) == 0)
						{
						if(OrderArray[^1] == ' ') OrderArray.Length--;
						OrderArray.Append(']');
						}
					}
				if(OrderArray[^1] == ' ') OrderArray.Length--;
				OrderArray.Append(']');
				DefaultDict.Add("/Order", OrderArray.ToString());
				}

			// radio buttons
			if(RadioButtons.Count > 1)
				{ 
				RadioButtons.Sort();
				StringBuilder RBArray = new StringBuilder("[");
				int End = RadioButtons.Count;
				int Ptr1;
				for(int Ptr = 0; Ptr < End; Ptr = Ptr1)
					{
					// count how many layers have the same radio button name
					for(Ptr1 = Ptr + 1; Ptr1 < End; Ptr1++)
						{
						if(string.Compare(RadioButtons[Ptr].RadioButton, RadioButtons[Ptr1].RadioButton) != 0) break;
						}

					// single radio button, ignore as far as radio button property
					if(Ptr1 - Ptr < 2) continue;

					// build array of layers with the same radio button name
					RBArray.Append('[');
					int Ptr3 = -1;
					for(int Ptr2 = Ptr; Ptr2 < Ptr1; Ptr2++)
						{
						RBArray.AppendFormat("{0} 0 R ", RadioButtons[Ptr2].ObjectNumber);
						if(RadioButtons[Ptr2].State == LayerState.On)
							{
							if(Ptr3 < 0)
								{
								Ptr3 = Ptr2;
								}
							else
								{
								RadioButtons[Ptr2].State = LayerState.Off;
								}
							}
						}
					RBArray.Length--;
					RBArray.Append(']');
					}
				if(RBArray.Length > 1)
					{ 
					RBArray.Append(']');
					DefaultDict.Add("/RBGroups", RBArray.ToString());
					}
				}

			StringBuilder OffLayers = new StringBuilder("[");
			foreach(PdfLayer Layer in LayerList)
				{
				if(Layer.State == LayerState.Off) OffLayers.AppendFormat("{0} 0 R ", Layer.ObjectNumber);
				}

			// build array of all initially off
			OffLayers.Length--;
			if(OffLayers.Length != 0)
				{ 
				OffLayers.Append(']');
				DefaultDict.Add("/OFF", OffLayers.ToString());
				}

			// add default dictionary
			Dictionary.AddDictionary("/D", DefaultDict);
			return;
			}
		}
	}
