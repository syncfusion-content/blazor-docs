---
layout: post
title: Import and Export in RichTextEditor | Syncfusion
description: Checkout and learn here all about import and export in Syncfusion Blazor RichTextEditor component and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Import and Export in Blazor RichTextEditor

## Import to Html file

The Rich Text Editor allows you to load an external HTML file in the editor's content, which contains the text with styling and images. You can read the HTML file from your path using the [StremReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.streamreader?view=net-6.0) class and assign it to the editor with the `@bind-Value` property.

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

![Blazor RichTextEditor import to HTML file](./images/blazor-richtexteditor-import-html.png)

> [View Sample in GitHub](https://github.com/SyncfusionExamples/import-html-file-to-blazor-rich-text-editor).

## Import to RTF file

You can import the RTF file into the editor by using the file uploader component, and you can get the RTF file content from the uploader success event. Then, you can import the RTF values into the editor.

{% tabs %}
{% highlight razor %}

@using Import_RTF_File.Data;
@using Syncfusion.Blazor.RichTextEditor;
@using Syncfusion.Blazor.Inputs;
@inject ExportService exportService

<SfRichTextEditor ID="defalt_RTE" @ref="RteObj" @bind-Value="@rteValue" EnableHtmlSanitizer="false">
    <RichTextEditorImageSettings SaveUrl="api/SampleData/Save" Path="../images/"></RichTextEditorImageSettings>
</SfRichTextEditor>
<SfUploader ID="UploadFiles">
    <UploaderAsyncSettings SaveUrl="api/SampleData/Import" RemoveUrl="https://aspnetmvc.syncfusion.com/services/api/uploadbox/Remove"></UploaderAsyncSettings>
    <UploaderEvents Success="@onSuccess"></UploaderEvents>
</SfUploader>

@code {
    SfRichTextEditor RteObj;
    private string rteValue { get; set; } = "<div>Example of Importing Text File into the Editor</div>";
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

![Blazor RichTextEditor import to RTF file](./images/blazor-richtexteditor-import-rtf.png)

> [View Sample in GitHub](https://github.com/SyncfusionExamples/import-rtf-file-to-blazor-rich-text-editor).

## Import text file to editor

The Rich Text Editor allows you to load an external text file into the editor. You can read the text file from your path using the [StremReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.streamreader?view=net-6.0) class and assign it to the editor with the `@bind-Value` property.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.RichTextEditor
@using Syncfusion.Blazor.Buttons
@using System.IO
@using System.Text

<SfButton OnClick="@importStream">Import Text Data</SfButton>
<SfRichTextEditor ID="defalt_RTE" @ref="RteObj" @bind-Value="@rteValue" EnableHtmlSanitizer="false">
</SfRichTextEditor>

@code {
    SfRichTextEditor RteObj;
    public string text { get; set; }
    private string rteValue { get; set; } = "<p>Click the button to import text file</p>";
    private string HtmlString { get; set; }
    private string PathToHTMLFile = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\wwwroot\RTESample.txt");
    public void importStream()
    {
        using (FileStream fs = File.Open(PathToHTMLFile, FileMode.Open, FileAccess.ReadWrite))
        {
            using (StreamReader sr = new StreamReader(fs))
            {
                HtmlString = sr.ReadToEnd();
                this.rteValue = HtmlString;
            }
        }
    }
}

{% endhighlight %}
{% endtabs %}

![Blazor RichTextEditor import to text file](./images/blazor-richtexteditor-import-text.png)

> [View Sample in GitHub](https://github.com/SyncfusionExamples/import-text-file-to-blazor-rich-text-editor).

## Export to RTF file

Using the [Syncfusion.DocIO](https://libraries.io/nuget/Syncfusion.DocIO.NET) libraries, you can export RTE content to RTF format.

Use the following code to export the RTF file: When you click the export button, you can use the **Syncfusion.DocIO** libraries to convert the RTE content to an RTF file.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.RichTextEditor;
@using Syncfusion.Blazor.Inputs;
@inject NavigationManager navigationManager;
@inject HttpClient Http
@using System.Net.Http;
@using System.Threading.Tasks;

<Syncfusion.Blazor.Buttons.SfButton OnClick="OnExport">Export</Syncfusion.Blazor.Buttons.SfButton>
    <SfRichTextEditor ID="customtool" @ref="RteObj" @bind-Value="@rteValue" EnableHtmlSanitizer="false">
        <RichTextEditorImageSettings SaveUrl="api/SampleData/Save" Path="../images/"></RichTextEditorImageSettings>
    </SfRichTextEditor>

@code {
    SfRichTextEditor RteObj;
    [Inject]
    IJSRuntime jsRuntime { get; set; }
    private string rteValue { get; set; } = "<p>Click the export button to download the RTE content in RTF format</p>";
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
}

{% endhighlight %}
{% endtabs %}

> [View Sample in GitHub](https://github.com/SyncfusionExamples/blazor-rich-text-editor-export-to-rtf).

## Export to HTML file

Using the [Syncfusion.DocIO](https://libraries.io/nuget/Syncfusion.DocIO.NET) libraries, you can export RTE content to HTML format.

While clicking on the export button, it makes a call to the Export to HTML service.

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

{% tabs %}
{% highlight cshtml tabtitle="~/ExportService.cs" %}

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

{% endhighlight %}
{% endtabs %}

> [View Sample in GitHub](https://github.com/SyncfusionExamples/blazor-rich-text-editor-export-to-html).