---
layout: post
title: Import and Export in Blazor RichTextEditor Component | Syncfusion
description: Checkout and learn here all about import and export in Syncfusion Blazor RichTextEditor component and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Import and Export in Blazor RichTextEditor

## Import to Html file 

The Rich Text Editor allows you to load an external HTML file in the editor content which contains the text with styling and images. You can read the HTML file from your path using [StremReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.streamreader?view=net-6.0) class and assign it to the editor with the `@bind-Value` property.

{% tabs %}
{% highlight razor %}

@using System.IO; 
@using Syncfusion.Blazor.RichTextEditor 
 
<SfRichTextEditor @bind-Value="@HtmlString"> 
    <p>Rich Text Editor allows to insert images from online source as well as local computer where you want to insert the image in your content.</p> 
    <p><b>Get started Quick Toolbar to click on the image</b></p> 
    <p>It is possible to add custom style on the selected image inside the Rich Text Editor through quick toolbar.</p> 
</SfRichTextEditor> 
 
@code { 
    private string HtmlString { get; set; } 
    private string PathToHTMLFile = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\wwwroot\HtmlFiles\HtmlTest.html"); 
    protected override void OnInitialized() 
    { 
        using (FileStream fs = File.Open(PathToHTMLFile, FileMode.Open, FileAccess.ReadWrite)) 
        { 
            using (StreamReader sr = new StreamReader(fs)) 
            {
                // Importing values from HTML file.

                HtmlString = sr.ReadToEnd(); 
            } 
        } 
    } 
} 

{% endhighlight %}
{% endtabs %}

 ## Import and Export RTF file

You can import the RTF file into the editor using file uploader component, and get the RTF file content from uploader success event. Then, you can able to import the RTF values to the editor.

While cliking on the export button you can call make the RTE content to the RTF file using [Syncfusion.DocIO](https://libraries.io/nuget/Syncfusion.DocIO.NET) libraries.

{% tabs %}
{% highlight razor %}

<Syncfusion.Blazor.Buttons.SfButton OnClick="OnExport">Export</Syncfusion.Blazor.Buttons.SfButton>
    <SfRichTextEditor ID="customtool" @ref="RteObj" @bind-Value="@rteValue" EnableHtmlSanitizer="false">
        <RichTextEditorImageSettings SaveUrl="api/SampleData/Save" Path="../images/"></RichTextEditorImageSettings>
    </SfRichTextEditor>
    <SfUploader ID="UploadFiles">
        <UploaderAsyncSettings SaveUrl="api/SampleData/Import" RemoveUrl="https://aspnetmvc.syncfusion.com/services/api/uploadbox/Remove"></UploaderAsyncSettings>
        <UploaderEvents Success="@onSuccess"></UploaderEvents>
    </SfUploader>

@code {
    SfRichTextEditor RteObj;
    [Inject]
    IJSRuntime jsRuntime { get; set; }
    private string rteValue { get; set; } = "<div><p>RTF Content Loaded</p></div>";
    public async Task OnExport()
    {
        HttpClientHandler clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        HttpClient client = new HttpClient(clientHandler);
        var content = new StringContent(rteValue);
        content.Headers.Add("value", rteValue);
        await client.PostAsync(navigationManager.Uri + "api/SampleData/ExportToRtf", content);
        await SampleInterop.SaveAs<object>(jsRuntime, "Sample.rtf");
    }
    public void onSuccess(SuccessEventArgs args)
    {
        var headers = args.Response.Headers.ToString();
        var header = headers.Split("rtevalue: ");
        header = header[1].Split("\r");
        this.rteValue = header[0];
    }
}

{% endhighlight %}
{% endtabs %}

 ## Import text file to editor 

You can import the text file into the editor using file uploader component, and get the text file content from uploader success event. Then, you can able to import the text file values to the editor.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.RichTextEditor
@inject ExportService exportService
 
<SfRichTextEditor ID="defalt_RTE" @ref="RteObj" @bind-Value="@rteValue" EnableHtmlSanitizer ="false"> 
    <RichTextEditorImageSettings SaveUrl="api/SampleData/Save" Path="../images/"></RichTextEditorImageSettings> 
</SfRichTextEditor> 
<SfUploader ID="UploadFiles"> 
    <UploaderAsyncSettings SaveUrl="api/SampleData/Import" RemoveUrl=https://aspnetmvc.syncfusion.com/services/api/uploadbox/Remove></UploaderAsyncSettings> 
    <UploaderEvents Success="@onSuccess"></UploaderEvents> 
</SfUploader> 
 
@code { 
    SfRichTextEditor RteObj; 
    private string rteValue { get; set; } = "<div><p>Text file Content Loaded</p></div>"; 
    public void onSuccess(SuccessEventArgs args) 
    { 
        var headers = args.Response.Headers.ToString(); 
        var header = headers.Split("rtevalue: "); 
        header = header[1].Split("\r"); 
        this.rteValue = header[0]; 
    } 
} 

{% endhighlight %}
{% endtabs %}

Import Services.cs:

```cshtml 

[HttpPost] 
[Route("Import")] 
public string Import(IList<IFormFile> UploadFiles) 
{ 
    string HtmlString = string.Empty; 
    if (UploadFiles != null) 
    { 
        foreach (var file in UploadFiles) 
        { 
            string filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"'); 
            filename = hostingEnv.WebRootPath + \\files + $@"\{filename}"; 
            using (FileStream fs = System.IO.File.Create(filename)) 
            { 
                file.CopyTo(fs); 
                fs.Flush(); 
            } 
            using (var mStream = new MemoryStream()) 
            { 
                new WordDocument(file.OpenReadStream(), FormatType.Rtf).Save(mStream, FormatType.Html); 
                mStream.Position = 0; 
                HtmlString = new StreamReader(mStream).ReadToEnd(); 
            }; 
            HtmlString = ExtractBodyContent(HtmlString); 
            var str = HtmlString.Replace("\r\n", ""); 
            Response.Headers.Add("rteValue", str); 
        } 
    } 
    return HtmlString; 
} 
 
public string ExtractBodyContent(string html) 
{ 
    if (html.Contains("<html") && html.Contains("<body")) 
    { 
        return html.Remove(0, html.IndexOf("<body>") + 6).Replace("</body></html>", ""); 
    } 
    return html; 
} 

```
## Export to HTML file

You can export the RTE content to the HTML format using the [Syncfusion.DocIO](https://libraries.io/nuget/Syncfusion.DocIO.NET) libraries.

While clicking on the export button it makes call to the Export to HTML service.

{% tabs %}
{% highlight razor %}

<button @onclick="ExportFile">Export</button>
<SfRichTextEditor ID="defalt_RTE" @ref="RteObj" @bind-Value="@rteValue">
    <ChildContent>
        <RichTextEditorToolbarSettings Items="@Tools" Type="ToolbarType.Expand"></RichTextEditorToolbarSettings>
    </ChildContent>
</SfRichTextEditor>

@code {
    [Inject]
    IJSRuntime jsRuntime { get; set; }
    SfRichTextEditor RteObj;
    private string rteValue { get; set; } = "<p>Starting Text</p>";
    public object[] Tools = new object[]{
        "Bold", "Italic", "Underline", "SubScript", "SuperScript", "StrikeThrough",
        "FontName", "FontSize", "FontColor", "BackgroundColor",
        "LowerCase", "UpperCase", "|",
        "Formats", "Alignments", "OrderedList", "UnorderedList",
        "Outdent", "Indent", "|", "CreateTable",
        "CreateLink", "Image", "|", "ClearFormat", "Print",
        "SourceCode", "FullScreen", "|", "Undo", "Redo"
    };
    public void ExportFile()
    {
        exportService.ExportToHtml(rteValue);
    }
}

{% endhighlight %}
{% endtabs %}

Here, the [Syncfusion.DocIO](https://libraries.io/nuget/Syncfusion.DocIO.NET) values are converted into document type and then coverted to HTML format.

ExportService.cs:

```cshtml 

public void ExportToHtml(string value)
{
    WordDocument document = GetDocument(value);
    //Saves the Word document to MemoryStream
    MemoryStream stream = new MemoryStream();
    document.Save(stream, FormatType.Html);
    stream.Position = 0;
    FileStream outputStream = new FileStream("filename.html", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
    document.Save(outputStream, FormatType.Html);
    document.Close();
    outputStream.Flush();
    outputStream.Dispose();
    // You can upload this stream to the azure
}

public WordDocument GetDocument(string htmlText)
{
    WordDocument document = null;
    MemoryStream stream = new MemoryStream();
    StreamWriter writer = new StreamWriter(stream, System.Text.Encoding.Default);
    htmlText = htmlText.Replace("\"", "'");
    XmlConversion XmlText = new XmlConversion(htmlText);
    XhtmlConversion XhtmlText = new XhtmlConversion(XmlText);
    writer.Write(XhtmlText.ToString());
    writer.Flush();
    stream.Position = 0;
    document = new WordDocument(stream, FormatType.Html, XHTMLValidationType.None);
    return document;
}

```