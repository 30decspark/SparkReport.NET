## Usage

To use **SparkReport.NET** for rendering reports, follow these steps:

### Example Code:

```csharp
using SparkReport.NET;

// Create a new report instance
var report = new Report();

// Set the report path (RDLC file)
report.ReportPath = "Test.rdlc";

// Render the report in PDF format
byte[] pdfReport = report.Render("PDF").Item1;
