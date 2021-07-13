# Globalization and RTL

The PDF Viewer component allows you to localize the static text on formatting pane, toolbar, dialog and more. It can be achieved by setting the `Locale` property and providing the localized text through the `LoadLocaleData()` method.

Also, this component provides support to render the user interface suitable for users who use **right-to-left (RTL)** languages (Arabic, Hebrew, Azeri, Farsi, Urdu). You can specify the control to render in RTL by setting the `EnableRtl` property to true.

The following code snippet shows how to localize the component for Arabic language by setting the Locale and EnableRtl properties and providing the localized text.

```csharp
@using Syncfusion.Blazor
@using Syncfusion.Blazor.PdfViewerServer


<SfPdfViewerServer Width="1060px" Height="500px" DocumentPath="@DocumentPath" EnableRtl="true" Locale="ar-AE" />

@code{
    public string DocumentPath { get; set; } = "wwwroot/data/PDF_Succinctly.pdf";
    [Inject]
    protected IJSRuntime JsRuntime { get; set; }
    protected override void OnAfterRender(bool firstRender)
    {
        this.JsRuntime.Sf().LoadLocaleData("wwwroot/locale.json");
    }
}
```

The following table shows the default text values used in PDF Viewer in 'en-US' culture:

|Keywords|Values|
|---|---|
|PdfViewer|PDF Viewer|
|Cancel|Cancel|
|Download file|Download file|
|Download|Download|
|Enter Password|This document is password protected. Please enter a password.|
|File Corrupted|File corrupted|
|File Corrupted Content|The file is corrupted and cannot be opened.|
|Fit Page|Fit page|
|Fit Width|Fit width|
|Automatic|Automatic|
|Go To First Page|Show first page|
|Invalid Password|Incorrect password. Please try again.|
|Next Page|Show next page|
|OK|OK|
|Open|Open file|
|Page Number|Current page number|
|Previous Page|Show previous page|
|Go To Last Page|Show last page|
|Zoom|Zoom|
|Zoom In|Zoom in|
|Zoom Out|Zoom out|
|Page Thumbnails|Page thumbnails|
|Bookmarks|Bookmarks|
|Print|Print file
|Password Protected|Password required|
|Copy|Copy|
|Text Selection|Text selection tool|
|Panning|Pan mode|
|Text Search|Find text|
|Find in document|Find in document|
|Match case|Match case|
|Apply|Apply|
|GoToPage|Go to page|
|No matches|Viewer has finished searching the document. No more matches were found|
|No Text Found|No Text Found|
|Undo|Undo|
|Redo|Redo|
|Annotation|Add or Edit annotations|
|Highlight|Highlight Text|
|Underline|Underline Text|
|Strikethrough|Strikethrough Text|
|Delete|Delete annotation|
|Opacity|Opacity|
|Color edit|Change Color|
|Opacity edit|Change Opacity|
|Highlight context|Highlight|
|Underline context|Underline|
|Strikethrough context|Strike through|
|Server error|Web-service is not listening. PDF Viewer depends on web-service for all it's features. Please start the web service to continue.|
|Open text|Open|
|First text|First Page|
|Previous text|Previous Page|
|Next text|Next Page|
|Last text|Last Page|
|Zoom in text|Zoom In|
|Zoom out text|Zoom Out|
|Selection text|Selection|
|Pan text|Pan|
|Print text|Print|
|Search text|Search|
|Annotation Edit text|Edit Annotation|
|Line Thickness|Line Thickness|
|Line Properties|Line Properties|
|Start Arrow|Start Arrow|
|End Arrow|End Arrow|
|Line Style|Line Style|
|Fill Color|Fill Color|
|Line Color|Line Color|
|None|None|
|Open Arrow|Open|
|Closed Arrow|Closed|
|Round Arrow|Round|
|Square Arrow|Square|
|Diamond Arrow|Diamond|
|Cut|Cut|
|Paste|Paste|
|Delete Context|Delete|
|Properties|Properties|
|Add Stamp|Add Stamp|
|Add Shapes|Add Shapes|
|Stroke edit|Change Stroke Color|
|Change thickness|Change Border Thickness|
|Add line|Add Line|
|Add arrow|Add Arrow|
|Add rectangle|Add Rectangle|
|Add circle|Add Circle|
|Add polygon|Add Polygon|
|Add Comments|Add Comments|
|Comments|Comments|
|No Comments Yet|No Comments Yet|
|Accepted|Accepted|
|Completed|Completed|
|Cancelled|Cancelled|
|Rejected|Rejected|
|Leader Length|Leader Length|
|Scale Ratio|Scale Ratio|
|Calibrate|Calibrate|
|Calibrate Distance|Calibrate Distance|
|Calibrate Perimeter|Calibrate Perimeter|
|Calibrate Area|Calibrate Area|
|Calibrate Radius|Calibrate Radius|
|Calibrate Volume|Calibrate Volume|
|Depth|Depth|
|Closed|Closed|
|Round|Round|
|Square|Square|
|Diamond|Diamond|
|Edit|Edit|
|Set Status|Set Status|
|Post|Post|
|Page|Page|
|Add a comment|Add a comment|
|Add a reply|Add a reply|