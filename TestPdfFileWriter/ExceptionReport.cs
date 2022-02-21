/////////////////////////////////////////////////////////////////////
//
//	TestPdfFileWriter II
//	Test/demo program for PdfFileWrite C# Class Library.
//
//	ExceptionReport
//	Support class used in conjunction with try/catch operator.
//  The class saves in a trace file the calling stack at the
//  time of program exception.
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

namespace TestPdfFileWriter
	{
	/// <summary>
	/// Exception report 
	/// </summary>
	public static class ExceptionReport
		{
		/// <summary>
		/// Get exception message and exception stack
		/// </summary>
		/// <param name="Ex">Exception class</param>
		/// <returns>Message string</returns>
		public static string[] GetMessageAndStack
				(
				Exception Ex
				)
			{
			// get system stack at the time of exception
			string StackTraceStr = Ex.StackTrace;

			// break it into individual lines
			string[] StackTraceLines = StackTraceStr.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

			// create a new array of trace lines
			List<string> StackTrace = new List<string>();

			// exception error message
			StackTrace.Add(Ex.Message);
#if DEBUG
			Trace.Write(Ex.Message);
#endif

			// add trace lines
			foreach(string Line in StackTraceLines)
				if(Line.Contains("PdfFileWriter"))
					{
					StackTrace.Add(Line);
#if DEBUG
					Trace.Write(Line);
#endif
					}

			// error exit
			return StackTrace.ToArray();
			}
		}
	}
