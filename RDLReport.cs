using Microsoft.Reporting.NETCore;

namespace SparkReport.NET
{
    /// <summary>
    /// Represents a report.
    /// </summary>
    public class RDLReport
    {
        private ReportParameters _parameters = [];
        private readonly List<ReportDataSource> _datasets = [];

        /// <summary>
        /// The path to the report.
        /// </summary>
        public string ReportPath { get; set; } = string.Empty;

        /// <summary>
        /// Sets the report parameters.
        /// </summary>
        public void SetParameters(ReportParameters parameters) => _parameters = parameters;

        /// <summary>
        /// Adds a data source to the report.
        /// </summary>
        public void AddDataSource(string name, object data) => _datasets.Add(new ReportDataSource(name, data));

        /// <summary>
        /// Renders the report.
        /// </summary>
        /// <param name="format">like PDF, EXCEL, WORD, HTML</param>
        /// <returns>byte[] of file, content type, filename</returns>
        public (byte[], string, string) Render(string format = "PDF")
        {
            (string, string, string) options = format switch
            {
                "EXCEL" => ("EXCELOPENXML", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "xlsx"),
                "HTML" => ("HTML5", "text/html", "html"),
                "PDF" => ("PDF", "application/pdf", "pdf"),
                "WORD" => ("WORDOPENXML", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "docx"),
                _ => ("PDF", "application/pdf", "pdf"),
            };
            try
            {
                var report = new LocalReport
                {
                    ReportPath = ReportPath,
                    EnableExternalImages = true,
                    EnableHyperlinks = true
                };

                if (_parameters.Count > 0) report.SetParameters(_parameters.Select(x => new ReportParameter(x.Key, x.Value)).ToList());
                if (_datasets.Count > 0) _datasets.ForEach(x => report.DataSources.Add(x));

                string filename = Path.GetFileNameWithoutExtension(report.ReportPath) + "." + options.Item3;
                return (report.Render(options.Item1), options.Item2, filename);
            }
            catch (Exception ex)
            {
                throw new Exception(GetExceptionMessage(ex));
            }
        }

        private static string GetExceptionMessage(Exception ex)
        {
            Exception innerEx = ex;
            while (innerEx.InnerException != null)
            {
                innerEx = innerEx.InnerException;
            }
            return innerEx.Message;
        }
    }
}
