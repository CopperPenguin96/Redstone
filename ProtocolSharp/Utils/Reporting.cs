using System;
using System.Collections.Generic;

namespace ProtocolSharp.Utils
{
	public class Reporting
	{
		public static readonly List<Report> Reports = new List<Report>();

		public static void AddReport(Report report)
		{
			if (report == null) throw new ArgumentNullException(nameof(report));
			if (report.Message == null) throw new ArgumentNullException(nameof(report.Message));

			Reports.Add(report);
		}

		public static void AddReport(string message, ReportType severity = ReportType.Normal)
		{
			if (message == null) throw new ArgumentNullException(nameof(message));

			AddReport(new Report {Type = severity, Message = message});
		}
	}

	public sealed class Report
	{
		public ReportType Type { get; set; } = ReportType.Normal;

		public DateTime Time => DateTime.Now;

		public string Message { get; set; }

		public Exception Reason { get; set; }
	}


	public enum ReportType
	{
		Normal,
		Chat,
		Warning,
		Error,
		SeriousError,
		Crash
	}
}
