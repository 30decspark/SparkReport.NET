using Microsoft.Reporting.NETCore;

namespace SparkReport.NET
{
    /// <summary>
    /// Class for report
    /// </summary>
    public class Report()
    {
        private readonly LocalReport report = new ();
        /// <summary>
        /// Enable external images
        /// </summary>
        public bool EnableExternalImages { get => report.EnableExternalImages; set => report.EnableExternalImages = value; }
        
        /// <summary>
        /// Enable hyperlinks
        /// </summary>
        public bool EnableHyperlinks { get => report.EnableHyperlinks; set => report.EnableHyperlinks = value; }
        
        /// <summary>
        /// Absolute path of report
        /// </summary>
        public string ReportPath { get => report.ReportPath; set => report.ReportPath = value; }
        
        /// <summary>
        /// Add dataset to report
        /// </summary>
        /// <param name="name">dataset name</param>
        /// <param name="dataset">dataset object</param>
        public void AddDataSet(string name, object dataset) => report.DataSources.Add(new ReportDataSource(name, dataset));

        /// <summary>
        /// Set report parameters
        /// </summary>
        /// <param name="parameters">parameters of report</param>
        public void SetParameters(ReportParameters parameters)
        {
            List<ReportParameter> param = [];
            foreach (var kvp in parameters)
            {
                ReportParameter p = new (kvp.Key, kvp.Value);
                param.Add(p);
            }

            try
            {
                report.SetParameters(param);
            }
            catch (Exception ex)
            {
                throw new Exception(GetExceptionMessage(ex));
            }
        }
        /// <summary>
        /// Render the report
        /// </summary>
        /// <param name="format">format like "PDF", "HTML", "WORD", "EXCEL"</param>
        /// <returns>byte[] of file, mime type, and filename</returns>
        /// <exception cref="Exception"></exception>
        public (byte[], string, string) Render(string? format)
        {
            (string, string, string) type = format switch
            {
                "EXCEL" => ("EXCELOPENXML", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "xlsx"),
                "HTML" => ("HTML5", "text/html", "html"),
                "PDF" => ("PDF", "application/pdf", "pdf"),
                "WORD" => ("WORDOPENXML", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "docx"),
                _ => ("PDF", "application/pdf", "pdf"),
            };

            try
            {
                string filename = Path.GetFileNameWithoutExtension(report.ReportPath) + "." + type.Item3;
                return (report.Render(type.Item1), type.Item2, filename);
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
