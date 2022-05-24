---
layout: post
title: Import and Export in Blazor RichTextEditor Component | Syncfusion
description: Checkout and learn here all about accessibility in Syncfusion Blazor RichTextEditor component and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

## Import Export

 We can load an external HTML file in the SfRichTextEditor which contains the text and images. we can read the file path using the Path and FileStream property in the System.IO directory.

{% tabs %}
{% highlight razor tabtitle="~/import-export.razor" %}

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
                HtmlString = sr.ReadToEnd(); 
            } 
        } 
    } 
} 

{% endhighlight %}
{% endtabs %}

We can Convert the RichTextEditor value to the record1.html file stream. So, similarly as with image uploading, we can now upload this file stream to the Azure service.

We can used EJ1 Syncfusion. EJ.Export, Syncfusion.DocIO libraries to convert the RichTextEditor value string to Html FileStream.


{% tabs %}
{% highlight razor tabtitle="~/import-export.razor" %}

<button @onclick="DownloadFile">Download</button>
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

    public void DownloadFile()
    {
        exportService.ExportToHtml(rteValue);
    }
}

{% endhighlight %}
{% endtabs %}

 ## Import RTF File to Editor

 We can import the RTF file content into the Rich Text Editor using our Uploader component and EJ1 Syncfusion. EJ.Export, Syncfusion.DocIO libraries for RTF to HTML conversions. 
 
 We can import the RTF file in the uploader, and once the file is uploaded successfully. We can replace the editor value with the converted HTML text and also can export the RichTextEditor value to the RTF file

{% tabs %}
{% highlight razor tabtitle="~/import-rte-editor.razor" %}

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

    private string rteValue { get; set; } = "<div><p>Iframe Content Loaded</p><iframe width='560' height='315' src='https://www.youtube.com/embed/9ahkQLmtEy4'></iframe></div>";

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

 ## Import Text File to Editor 

 We can import the text file to editor this can be achieved by using server-side action which retrieves the RTF file from the uploader and converts it into the HTML string which then can be retrieved in the success event of the uploader and the binding to the ‘Value’ property of the Rich Text Editor.

{% tabs %}
{% highlight razor tabtitle="~/import-text.razor" %}

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
    private string rteValue { get; set; } = "<div><p>Iframe Content Loaded</p><iframe width='560' height='315' src='https://www.youtube.com/embed/9ahkQLmtEy4'></iframe></div>"; 
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

We can also render html Iframe inside Rich Text Editor,this can be archived by setting the [`EnableHtmlSanitizer`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_EnableHtmlSanitizer) to false in the Rich Text Editor.

{% tabs %}
{% highlight razor tabtitle="~/import-text.razor" %}

@using Syncfusion.Blazor.RichTextEditor
@inject ExportService exportService

<SfRichTextEditor ID="defalt_RTE" @ref="RteObj" @bind-Value="@rteValue" EnableHtmlSanitizer="false"> 
    . . . 
</SfRichTextEditor> 

{% endhighlight %}
{% endtabs %}