---
layout: post
title: Create Or Generate PDF file in Blazor Chart | Syncfusion
description: Checkout and learn here all about convert chart to pdf in Syncfusion Blazor Charts component and much more details.
platform: Blazor
control: Chart
documentation: ug
---

<!-- markdownlint-disable MD036 -->

# Converting Chart to PDF in Blazor Chart Component

The Syncfusion [Blazor PDF library](https://www.syncfusion.com/document-processing/pdf-framework/blazor/pdf-library) is used to create, read, and edit PDF documents. This library also offers functionality to merge, split, stamp, forms, and secure PDF files.

To include the Syncfusion Blazor PDF library into your Blazor application, please refer to the [NuGet Package Required](https://help.syncfusion.com/file-formats/pdf/nuget-packages-required) or [Assemblies Required](https://help.syncfusion.com/file-formats/pdf/assemblies-required) documentation.

To convert chart into pdf follow the given steps.

**Step 1:**

Create a ``MemoryStream`` to create and store the pdf document. Add the following code in ExportService.cs file under Data folder.
To know more about ExportService.cs file, kindly refer [ExportService](https://help.syncfusion.com/file-formats/pdf/create-pdf-document-in-blazor#steps-to-create-pdf-document-in-blazor-server-side-application)

```cshtml

 public class ExportService
    {
        //Export weather data to PDF document.
        public static MemoryStream CreatePdf(WeatherForecast[] forecasts)
        {
            if (forecasts == null)
            {
                throw new ArgumentNullException("Forecast cannot be null");
            }
            //Create a new PDF document.
            using (PdfDocument pdfDocument = new PdfDocument())
            {
                int paragraphAfterSpacing = 8;
                int cellMargin = 8;

                //Add page to the PDF document.
                PdfPage page = pdfDocument.Pages.Add();
                //Create a new font.
                PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 16);

                //Create a text element to draw a text in PDF page.
                PdfTextElement title = new PdfTextElement("Weather Forecast", font, PdfBrushes.Black);
                PdfLayoutResult result = title.Draw(page, new PointF(0, 0));
                PdfStandardFont contentFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
                PdfTextElement content = new PdfTextElement("This component demonstrates fetching data from a service and Exporting the data to PDF document using Syncfusion .NET PDF library.", contentFont, PdfBrushes.Black);
                PdfLayoutFormat format = new PdfLayoutFormat();
                format.Layout = PdfLayoutType.Paginate;

                //Draw a text to the PDF document.
                result = content.Draw(page, new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width, page.GetClientSize().Height), format); 

                //Memory stream to store the PDF document.
                using (MemoryStream stream = new MemoryStream())
                {
                    //Saving the PDF document into the stream.
                    pdfDocument.Save(stream);
                    //Closing the PDF document.
                    pdfDocument.Close(true);
                    return stream;
                }
            }
        }
    }
```
Create a button in the razor file which you want to convert using the following code.

```cshtml
<button class="btn btn-primary" @onclick="@ExportToPdf">Export to PDF</button>
```
Add the ``ExportToPdf`` method in razor page which you want to convert to call the export service.

```cshtml
private async Task ExportToPDF(MouseEventArgs args)
{
    await ChartObj.ExportAsync(ExportType.PNG, "pngImage", Syncfusion.PdfExport.PdfPageOrientation.Portrait, false);       
}
```

**Step 2:**

Create a class file with ``FileUtil`` name and add the following code to invoke the JavaScript action to download the file in the browser.

```cshtml
public static class FileUtil
{
    public static ValueTask<object> SaveAs(this IJSRuntime js, string filename, byte[] data)
       => js.InvokeAsync<object>(
           "saveAsFile",
           filename,
           Convert.ToBase64String(data));
}
```
**Step 3:**

Add the following JavaScript function in the ``_Host.cshtml`` available under the ``Pages`` folder.

```cshtml
<script type="text/javascript">
    function saveAsFile(filename, bytesBase64) {
            if (navigator.msSaveBlob) {
                //Download document in Edge browser
                var data = window.atob(bytesBase64);
                var bytes = new Uint8Array(data.length);
                for (var i = 0; i < data.length; i++) {
                    bytes[i] = data.charCodeAt(i);
                }
                var blob = new Blob([bytes.buffer], { type: "application/octet-stream" });
                navigator.msSaveBlob(blob, filename);
            }
            else {
        var link = document.createElement('a');
        link.download = filename;
        link.href = "data:application/octet-stream;base64," + bytesBase64;
        document.body.appendChild(link); // Needed for Firefox
        link.click();
        document.body.removeChild(link);
    }
        }
</script>
```
Refer the following code snippet to create a complete razor page to convert Blazor Chart into pdf.

```cshtml
@using Syncfusion.Pdf
@using Syncfusion.Pdf.Grid;
@using Syncfusion.Drawing;
@using Syncfusion.Pdf.Graphics;
@inject Microsoft.JSInterop.IJSRuntime JS
@using System.IO;
@using Syncfusion.Blazor.Charts;
@using ChartToPdf.Data;
 

<button class="btn btn-primary" @onclick="@ExportToPDF">Export to PDF</button>


<SfChart @ref="ChartObj" Title="Inflation - Consumer Price">
    <ChartEvents OnExportComplete="Export"></ChartEvents>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@ConsumerDetails" XName="X" YName="YValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>


@code {

    SfChart ChartObj;
    private WeatherForecast[]? forecasts;

    public class ChartData
    {
        public string X { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> ConsumerDetails = new List<ChartData>
    {
        new ChartData { X= "USA", YValue= 46 },
        new ChartData { X= "GBR", YValue= 27 },
        new ChartData { X= "CHN", YValue= 26 },
        new ChartData { X= "UK", YValue= 36 },
        new ChartData { X= "AUS", YValue= 15 },
        new ChartData { X= "IND", YValue= 55 },
        new ChartData { X= "DEN", YValue= 40 },
        new ChartData { X= "MEX", YValue= 30 }
    };

    private async Task ExportToPDF(MouseEventArgs args)
    {
        await ChartObj.ExportAsync(ExportType.PNG, "pngImage", Syncfusion.PdfExport.PdfPageOrientation.Portrait, false);       
    }

    private void Export(ExportEventArgs args)
    {
        PdfDocument pdfDocument = new PdfDocument();

        pdfDocument.PageSettings.Size = PdfPageSize.A3;

        PdfPage page = pdfDocument.Pages.Add();

        var DataURl = args.DataUrl;

        var base64 = DataURl.Split(',')[1];

        byte[] dataBytes = Convert.FromBase64String(base64);

        MemoryStream memoryStream = new MemoryStream(dataBytes);

        memoryStream.Write(dataBytes, 0, dataBytes.Length);

        PdfBitmap image = new PdfBitmap(memoryStream);

        PdfGraphics graphics = page.Graphics;

        graphics.DrawImage(image, 0, 0);         

        MemoryStream stream = new MemoryStream();

        pdfDocument.Save(stream);

        pdfDocument.Close(true);

        JS.SaveAs("Chart.pdf", stream.ToArray());
    }
}
```

To know more about PDF document in Blazor, kindly refer [File Format](https://help.syncfusion.com/file-formats/pdf/create-pdf-document-in-blazor#steps-to-create-pdf-document-in-blazor-server-side-application)

N> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.
