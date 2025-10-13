---
layout: post
title: Import/Export in Rich Text Editor | Syncfusion
description: Checkout and learn here all about Import/Export in Syncfusion Blazor Rich Text Editor component and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Import/Export in Blazor Rich Text Editor component

## Import from Microsoft Word

The Rich Text Editor allows you to import content from Word documents, preserving the original formatting and structure, including headings, lists, tables, and text styles. This ensures accurate representation of documents within the editor, enabling seamless editing.

To integrate an `ImportWord` option into the Rich Text Editor toolbar using the [RichTextEditorToolbarSettings.Items](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorToolbarSettings.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorToolbarSettings_Items) property.

To enable the `ImportWord` functionality, the `ServiceUrl` property must be correctly configured within the `ImportWord`. This API endpoint facilitates the file upload process and manages the server-side conversion of the document.

The following code block provides a detailed explanation of the API endpoint used for the import functionality:

```csharp

    public IActionResult ImportFromWord(IList<IFormFile> UploadFiles)
        {
            string HtmlString = string.Empty;
            if (UploadFiles != null)
            {
                foreach (var file in UploadFiles)
                {
                    string filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    filename = _webHostEnvironment.WebRootPath + $@"\{filename}";
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
                    HtmlString = SanitizeHtml(HtmlString);
                    System.IO.File.Delete(filename);
                }
                return Ok(HtmlString);
            }
            else
            {
                Response.Clear();
                // Return an appropriate status code or message
                return BadRequest("No files were uploaded.");
            }
        }

        private string ExtractBodyContent(string html)
        {
            if (html.Contains("<html") && html.Contains("<body"))
            {
                return html.Remove(0, html.IndexOf("<body>") + 6).Replace("</body></html>", "");
            }
            return html;
        }

        private string SanitizeHtml(string html)
        {
            // Remove or replace non-ASCII or control characters
            // For example, you can use regular expressions to replace them with spaces
            // Regex pattern to match non-ASCII or control characters: [^\x20-\x7E]
            return Regex.Replace(html, @"[^\x20-\x7E]", " ");
        }


```

The `ImportWord` feature integrates with `ActionBegin` and `ActionComplete` events. Setting the `cancel` property to `true` in `ActionBegin` prevents execution.

The following example illustrates how to set up the `ImportWord` in the Rich Text Editor to facilitate content importation from Word documents:

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.RichTextEditor
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.DropDowns
@inject IJSRuntime JS
<div class="control-section">
    <div class="control-wrapper">
        <div class="">
            <SfRichTextEditor @ref="EditorRef" ID="RT_Editor" ShowCharCount="true" AutoSaveOnIdle="true" EnableTabKey="true" EnableXhtml="true" Placeholder="@PlaceHolderText">
                <h2 style="text-align: center;">Invitation to Microsoft Webinar Meet-Up</h2><p>
                    Dear Guest,
                </p><p>
                    We're thrilled to extend a special invitation to you for an exclusive Microsoft webinar meet-up, where we'll explore the latest innovations and insights driving the future of technology. As a valued member of our community, we believe this event will offer invaluable knowledge and networking opportunities.
                </p><h2>Event Details:</h2>
                <table class="e-rte-table" style="width: 100%; height: 125px;">
                    <tbody>
                        <tr style="height: 20%;">
                            <th class="">Time:</th>
                            <td>10:00 AM - 12:00 PM</td>
                        </tr>
                        <tr style="height: 20%;">
                            <th>Duration:</th>
                            <td>2 hours</td>
                        </tr>
                        <tr style="height: 20%;">
                            <th>Platform:</th>
                            <td>Microsoft Teams</td>
                        </tr>
                    </tbody>
                </table><p><br></p><h2>Agenda:</h2>
                <ul>
                    <li>Introduction to Cutting-Edge Microsoft Technologies</li>
                    <li>Deep Dive into AI in Business: Leveraging Microsoft Azure Solutions</li>
                    <li>Live Q&A Session with Industry Experts</li>
                    <li>Networking Opportunities with Peers and Professionals</li>
                </ul><h2>Why Attend?</h2>
                <ul>
                    <li>Gain insights into the latest trends and advancements in technology.</li>
                    <li>Interact with industry experts and expand your professional network.</li>
                    <li>Get your questions answered in real-time during the live Q&A session.</li>
                    <li>Access exclusive resources and offers available only to webinar attendees.</li>
                </ul><p>
                    Feel free to invite your colleagues and peers who might benefit from this enriching experience. Simply forward this email to them or share the event details.
                </p><p>
                    We're looking forward to your participation and to exploring the exciting world of Microsoft technology together. Should you have any questions or require further information, please don't hesitate to contact us at <a href="mailto:webinar@company.com">webinar@company.com</a>.
                </p><p>
                    <br>
                </p><p>Warm regards,</p><p>John Doe<br>Event Coordinator<br>ABC Company</p>
                <RichTextEditorToolbarSettings Items="@Tools"></RichTextEditorToolbarSettings>
                <RichTextEditorImportWord ServiceUrl="https://blazor.syncfusion.com/services/production/api/RichTextEditor/ImportFromWord"></RichTextEditorImportWord>
                <RichTextEditorQuickToolbarSettings Table="@TableQuickToolbarItems" ShowOnRightClick="true" />
                <RichTextEditorImageSettings SaveUrl="@SaveURL" Path="@Path"></RichTextEditorImageSettings>
            </SfRichTextEditor>
        </div>
    </div>
</div>
@code {
    SfRichTextEditor EditorRef;
    private string SaveURL = "https://blazor.syncfusion.com/services/production/api/RichTextEditor/SaveFile";
    private string Path = "https://blazor.syncfusion.com/services/production/RichTextEditor/";
    private string PlaceHolderText = "Type something or use @ to tag a user...";
    private List<ToolbarItemModel> Tools = new List<ToolbarItemModel>()
    {
        new ToolbarItemModel() { Command = ToolbarCommand.Undo },
        new ToolbarItemModel() { Command = ToolbarCommand.Redo },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.ImportWord },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.Bold },
        new ToolbarItemModel() { Command = ToolbarCommand.Italic },
        new ToolbarItemModel() { Command = ToolbarCommand.Underline },
        new ToolbarItemModel() { Command = ToolbarCommand.StrikeThrough },
        new ToolbarItemModel() { Command = ToolbarCommand.SuperScript },
        new ToolbarItemModel() { Command = ToolbarCommand.SubScript },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.FontName },
        new ToolbarItemModel() { Command = ToolbarCommand.FontSize },
        new ToolbarItemModel() { Command = ToolbarCommand.FontColor },
        new ToolbarItemModel() { Command = ToolbarCommand.BackgroundColor },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.LowerCase },
        new ToolbarItemModel() { Command = ToolbarCommand.UpperCase },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.Formats },
        new ToolbarItemModel() { Command = ToolbarCommand.Alignments },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.NumberFormatList },
        new ToolbarItemModel() { Command = ToolbarCommand.BulletFormatList },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.Outdent },
        new ToolbarItemModel() { Command = ToolbarCommand.Indent },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.CreateLink },
        new ToolbarItemModel() { Command = ToolbarCommand.Image },
        new ToolbarItemModel() { Command = ToolbarCommand.Video },
        new ToolbarItemModel() { Command = ToolbarCommand.Audio },
        new ToolbarItemModel() { Command = ToolbarCommand.CreateTable },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.ClearFormat },
        new ToolbarItemModel() { Command = ToolbarCommand.Print },
        new ToolbarItemModel() { Command = ToolbarCommand.SourceCode },
        new ToolbarItemModel() { Command = ToolbarCommand.FullScreen },
    };
    private List<TableToolbarItemModel> TableQuickToolbarItems = new List<TableToolbarItemModel>()
    {
        new TableToolbarItemModel() { Command = TableToolbarCommand.TableHeader },
        new TableToolbarItemModel() { Command = TableToolbarCommand.TableRows },
        new TableToolbarItemModel() { Command = TableToolbarCommand.TableColumns },
        new TableToolbarItemModel() { Command = TableToolbarCommand.TableCell },
        new TableToolbarItemModel() { Command = TableToolbarCommand.HorizontalSeparator },
        new TableToolbarItemModel() { Command = TableToolbarCommand.BackgroundColor },
        new TableToolbarItemModel() { Command = TableToolbarCommand.TableRemove },
        new TableToolbarItemModel() { Command = TableToolbarCommand.TableCellVerticalAlign },
        new TableToolbarItemModel() { Command = TableToolbarCommand.Styles }
    };
}

{% endhighlight %}
{% endtabs %}

## Export to PDF / Microsoft Word

The Rich Text Editor's export functionality allows users to convert their edited content into PDF or Word documents with a single click, preserving all text styles, images, tables, and other formatting elements.

You can add `ExportWord` and `ExportPdf` tools to the Rich Text Editor toolbar using the [RichTextEditorToolbarSettings.Items](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorToolbarSettings.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorToolbarSettings_Items) property.

To enable the `ExportWord` and `ExportPdf` functionality, the `ServiceUrl` property must be correctly configured within the `RichTextEditorExportWord` and `RichTextEditorExportPdf`. These API endpoints handle the export process and manage the server-side generation of Word and PDF files, respectively.

The following code block provides a detailed explanation of the API endpoint used for the content export functionality:

```csharp

    public class ExportParam
        {
            public string html { get; set; }
        }

        [AcceptVerbs("Post")]
        [EnableCors("AllowAllOrigins")]
        [Route("ExportToPdf")]
        public ActionResult ExportToPdf([FromBody] ExportParam args)
        {
            string htmlString = args.html;
            if (string.IsNullOrEmpty(htmlString)
            {
                return null;
            }
            using (WordDocument wordDocument = new WordDocument())
            {
                //This method adds a section and a paragraph in the document
                wordDocument.EnsureMinimal();
                wordDocument.HTMLImportSettings.ImageNodeVisited += OpenImage;
                //Append the HTML string to the paragraph.
                wordDocument.LastParagraph.AppendHTML(htmlString);
                DocIORenderer render = new DocIORenderer();
                //Converts Word document into PDF document
                PdfDocument pdfDocument = render.ConvertToPDF(wordDocument);
                wordDocument.HTMLImportSettings.ImageNodeVisited -= OpenImage;
                MemoryStream stream = new MemoryStream();
                pdfDocument.Save(stream);
                return File(stream.ToArray(), System.Net.Mime.MediaTypeNames.Application.Pdf, "Sample.pdf");
            }
        }

        [AcceptVerbs("Post")]
        [EnableCors("AllowAllOrigins")]
        [Route("ExportToDocx")]
        public FileStreamResult ExportToDocx([FromBody] ExportParam args)
        {
            string htmlString = args.html;
             if (string.IsNullOrEmpty(htmlString)
            {
                return null;
            }
            using (WordDocument document = new WordDocument())
            {
                document.EnsureMinimal();
                //Hooks the ImageNodeVisited event to open the image from a specific location
                document.HTMLImportSettings.ImageNodeVisited += OpenImage;
                //Validates the Html string
                bool isValidHtml = document.LastSection.Body.IsValidXHTML(htmlString, XHTMLValidationType.None);
                //When the Html string passes validation, it is inserted to the document
                if (isValidHtml)
                {
                    //Appends the Html string to first paragraph in the document
                    document.Sections[0].Body.Paragraphs[0].AppendHTML(htmlString);
                }
                //Unhooks the ImageNodeVisited event after loading HTML
                document.HTMLImportSettings.ImageNodeVisited -= OpenImage;
                //Creates file stream.
                MemoryStream stream = new MemoryStream();
                document.Save(stream, FormatType.Docx);
                stream.Position = 0;
                //Download Word document in the browser
                return File(stream, "application/msword", "Result.docx");
            }
        }

```

The `FileName` and `Stylesheet` properties within the `ExportWord` and `ExportPdf` allow for the customization of file names and stylesheets for the exported documents, respectively.

The `ExportWord` and `ExportPdf` functionality is integrated within the `ActionBegin` and `ActionComplete` events. If the cancel property is set to true in the `ActionBegin` event argument, the execution of the `ExportWord` and `ExportPdf` functionality can be prevented.

The `ActionBegin` event argument includes an `ExportValue` property, which contains the content to be exported. This content can be modified by configuring the `ActionBegin` event.

The following example demonstrates how to configure the `ExportWord` and `ExportPdf` tools in the Rich Text Editor, facilitating the export of content into Word or PDF documents:

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.RichTextEditor
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.DropDowns
@inject IJSRuntime JS
<div class="control-section">
    <div class="control-wrapper">
        <div class="">
            <SfRichTextEditor @ref="EditorRef" ID="RT_Editor" ShowCharCount="true" AutoSaveOnIdle="true" EnableTabKey="true" EnableXhtml="true" Placeholder="@PlaceHolderText">
                <h2 style="text-align: center;">Invitation to Microsoft Webinar Meet-Up</h2><p>
                    Dear Guest,
                </p><p>
                    We're thrilled to extend a special invitation to you for an exclusive Microsoft webinar meet-up, where we'll explore the latest innovations and insights driving the future of technology. As a valued member of our community, we believe this event will offer invaluable knowledge and networking opportunities.
                </p><h2>Event Details:</h2><table class="e-rte-table" style="width: 100%; height: 125px;">
                    <tbody>
                    <tr style="height: 20%;">
                        <th class="">Time:</th>
                        <td>10:00 AM - 12:00 PM</td>
                    </tr>
                    <tr style="height: 20%;">
                        <th>Duration:</th>
                        <td>2 hours</td>
                    </tr>
                    <tr style="height: 20%;">
                        <th>Platform:</th>
                        <td>Microsoft Teams</td>
                    </tr>
                </tbody></table><p><br></p><h2>Agenda:</h2><ul>
                    <li>Introduction to Cutting-Edge Microsoft Technologies</li>
                    <li>Deep Dive into AI in Business: Leveraging Microsoft Azure Solutions</li>
                    <li>Live Q&A Session with Industry Experts</li>
                    <li>Networking Opportunities with Peers and Professionals</li>
                </ul><h2>Why Attend?</h2><ul>
                    <li>Gain insights into the latest trends and advancements in technology.</li>
                    <li>Interact with industry experts and expand your professional network.</li>
                    <li>Get your questions answered in real-time during the live Q&A session.</li>
                    <li>Access exclusive resources and offers available only to webinar attendees.</li>
                </ul><p>
                    Feel free to invite your colleagues and peers who might benefit from this enriching experience. Simply forward this email to them or share the event details.
                </p><p>
                    We're looking forward to your participation and to exploring the exciting world of Microsoft technology together. Should you have any questions or require further information, please don't hesitate to contact us at <a href="mailto:webinar@company.com">webinar@company.com</a>.</p><p>
                <br></p><p>Warm regards,</p><p>John Doe<br>Event Coordinator<br>ABC Company</p>
                <RichTextEditorToolbarSettings Items="@Tools"></RichTextEditorToolbarSettings>
                 <RichTextEditorExportPdf ServiceUrl="https://blazor.syncfusion.com/services/production/api/RichTextEditor/ExportToPdf" FileName="RichTextEditor.pdf"></RichTextEditorExportPdf>
                <RichTextEditorExportWord ServiceUrl="https://blazor.syncfusion.com/services/production/api/RichTextEditor/ExportToDocx" FileName="RichTextEditor.docx"></RichTextEditorExportWord>
                <RichTextEditorQuickToolbarSettings Table="@TableQuickToolbarItems" ShowOnRightClick="true" />
                <RichTextEditorImageSettings SaveUrl="@SaveURL" Path="@Path"></RichTextEditorImageSettings>
            </SfRichTextEditor>
        </div>
    </div>
</div>
@code {
    SfRichTextEditor EditorRef;
    private string SaveURL = "https://blazor.syncfusion.com/services/production/api/RichTextEditor/SaveFile";
    private string Path = "https://blazor.syncfusion.com/services/production/RichTextEditor/";
    private string PlaceHolderText = "Type something or use @ to tag a user...";
    private List<ToolbarItemModel> Tools = new List<ToolbarItemModel>()
    {
        new ToolbarItemModel() { Command = ToolbarCommand.Undo },
        new ToolbarItemModel() { Command = ToolbarCommand.Redo },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.ExportWord },
        new ToolbarItemModel() { Command = ToolbarCommand.ExportPdf },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.Bold },
        new ToolbarItemModel() { Command = ToolbarCommand.Italic },
        new ToolbarItemModel() { Command = ToolbarCommand.Underline },
        new ToolbarItemModel() { Command = ToolbarCommand.StrikeThrough },
        new ToolbarItemModel() { Command = ToolbarCommand.SuperScript },
        new ToolbarItemModel() { Command = ToolbarCommand.SubScript },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.FontName },
        new ToolbarItemModel() { Command = ToolbarCommand.FontSize },
        new ToolbarItemModel() { Command = ToolbarCommand.FontColor },
        new ToolbarItemModel() { Command = ToolbarCommand.BackgroundColor },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.LowerCase },
        new ToolbarItemModel() { Command = ToolbarCommand.UpperCase },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.Formats },
        new ToolbarItemModel() { Command = ToolbarCommand.Alignments },
        new ToolbarItemModel() { Command = ToolbarCommand.Blockquote },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.NumberFormatList },
        new ToolbarItemModel() { Command = ToolbarCommand.BulletFormatList },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.Outdent },
        new ToolbarItemModel() { Command = ToolbarCommand.Indent },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.CreateLink },
        new ToolbarItemModel() { Command = ToolbarCommand.Image },
        new ToolbarItemModel() { Command = ToolbarCommand.Video },
        new ToolbarItemModel() { Command = ToolbarCommand.Audio },
        new ToolbarItemModel() { Command = ToolbarCommand.CreateTable },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.ClearFormat },
        new ToolbarItemModel() { Command = ToolbarCommand.Print },
        new ToolbarItemModel() { Command = ToolbarCommand.SourceCode },
        new ToolbarItemModel() { Command = ToolbarCommand.FullScreen },
    };
    private List<TableToolbarItemModel> TableQuickToolbarItems = new List<TableToolbarItemModel>()
    {
        new TableToolbarItemModel() { Command = TableToolbarCommand.TableHeader },
        new TableToolbarItemModel() { Command = TableToolbarCommand.TableRows },
        new TableToolbarItemModel() { Command = TableToolbarCommand.TableColumns },
        new TableToolbarItemModel() { Command = TableToolbarCommand.TableCell },
        new TableToolbarItemModel() { Command = TableToolbarCommand.HorizontalSeparator },
        new TableToolbarItemModel() { Command = TableToolbarCommand.BackgroundColor },
        new TableToolbarItemModel() { Command = TableToolbarCommand.TableRemove },
        new TableToolbarItemModel() { Command = TableToolbarCommand.TableCellVerticalAlign },
        new TableToolbarItemModel() { Command = TableToolbarCommand.Styles }
    };
}

{% endhighlight %}
{% endtabs %}

### Exporting Rich Text Editor content to PDF or word using external tools

By default, when exporting content from the Blazor Rich Text Editor to generate PDF or Word documents using external tools (instead of Syncfusion’s built-in export services), the editor’s internal styles are not included in the retrieved HTML. This can lead to formatting inconsistencies in the final output.

To preserve the intended appearance of the content, you should manually apply the following CSS styles to the exported HTML container.

> Make sure to add a CSS class `e-rte-content` to the content container.

```CSS
.e-rte-content {
    font-size: 1em;
    font-weight: 400;
    margin: 0;
}
html {
    height: auto;
    margin: 0;
}
body {
    margin: 0;
    color: #333;
    word-wrap: break-word;
}
.e-content {
    min-height: 100px;
    outline: 0 solid transparent;
    padding: 16px;
    position: relative;
    overflow-x: auto;
    font-weight: normal;
    line-height: 1.5;
    font-size: 14px;
    text-align: inherit;
    font-family: \"Roboto\", \"Segoe UI\", \"GeezaPro\", \"DejaVu Serif\", \"sans-serif\", \"-apple-system\", \"BlinkMacSystemFont\";
}
p {
    margin-top: 0;
    margin-right: 0;
    margin-bottom: 10px;
    margin-left: 0;
}
h1 {
    font-size: 2.857em;
    font-weight: 600;
    line-height: 1.2;
    margin-top: 10px;
    margin-right: 0;
    margin-bottom: 10px;
    margin-left: 0;
}
h2 {
    font-size: 2.285em;
    font-weight: 600;
    line-height: 1.2;
    margin-top: 10px;
    margin-right: 0;
    margin-bottom: 10px;
    margin-left: 0;
}
h3 {
    font-size: 2em;
    font-weight: 600;
    line-height: 1.2;
    margin-top: 10px;
    margin-right: 0;
    margin-bottom: 10px;
    margin-left: 0;
}
h4 {
    font-size: 1.714em;
    font-weight: 600;
    line-height: 1.2;
    margin-top: 10px;
    margin-right: 0;
    margin-bottom: 10px;
    margin-left: 0;
}
h5 {
    font-size: 1.428em;
    font-weight: 600;
    line-height: 1.2;
    margin-top: 10px;
    margin-right: 0;
    margin-bottom: 10px;
    margin-left: 0;
}
h6 {
    font-size: 1.142em;
    font-weight: 600;
    line-height: 1.5;
    margin-top: 10px;
    margin-right: 0;
    margin-bottom: 10px;
    margin-left: 0;
}
blockquote {
    margin-top: 10px;
    margin-right: 0;
    margin-bottom: 10px;
    margin-left: 0;
    padding-left: 12px;
    border-left: 2px solid #5c5c5c;
}
pre {
    border: 0;
    border-radius: 0;
    color: #333;
    font-size: inherit;
    line-height: inherit;
    margin-top: 0;
    margin-right: 0;
    margin-bottom: 10px;
    margin-left: 0;
    overflow: visible;
    padding: 0;
    white-space: pre-wrap;
    word-break: inherit;
    word-wrap: break-word;
}
code {
    background-color: #9d9d9d26;
    color: #ed484c;
}
strong {
    font-weight: bold;
}
b {
    font-weight: bold;
}
a {
    text-decoration: none;
    user-select: auto;
}
li {
    margin-bottom: 10px;
}
li ol {
    margin-block-start: 10px;
}
li ul {
    margin-block-start: 10px;
}
ul {
    list-style-type: disc;
}
ul ul {
    list-style-type: circle;
}
ol ul {
    list-style-type: circle;
}
ul ul ul {
    list-style-type: square;
}
ol ul ul {
    list-style-type: square;
}
ul ol ul {
    list-style-type: square;
}
ol ol ul {
    list-style-type: square;
}
table {
    margin-bottom: 10px;
    border-collapse: collapse;
}
th {
    background-color: rgba(157, 157, 157, .15);
    border: 1px solid #BDBDBD;
    height: 20px;
    min-width: 20px;
    padding: 2px 5px;
}
td {
    border: 1px solid #BDBDBD;
    height: 20px;
    min-width: 20px;
    padding: 2px 5px;
}
.e-rte-image {
    border: 0;
    cursor: pointer;
    display: block;
    float: none;
    margin: auto;
    max-width: 100%;
    position: relative;
}
.e-rte-audio {
    border: 0;
    cursor: pointer;
    display: block;
    float: none;
    margin: auto;
    max-width: 100%;
    position: relative;
}
.e-rte-video {
    border: 0;
    cursor: pointer;
    display: block;
    float: none;
    margin: auto;
    max-width: 100%;
    position: relative;
}
.e-imginline {
    margin-left: 5px;
    margin-right: 5px;
    display: inline-block;
    float: none;
    max-width: 100%;
    padding: 1px;
    vertical-align: bottom;
}
.e-audio-inline {
    margin-left: 5px;
    margin-right: 5px;
    display: inline-block;
    float: none;
    max-width: 100%;
    padding: 1px;
    vertical-align: bottom;
}
.e-video-inline {
    margin-left: 5px;
    margin-right: 5px;
    display: inline-block;
    float: none;
    max-width: 100%;
    padding: 1px;
    vertical-align: bottom;
}
.e-imgcenter {
    cursor: pointer;
    display: block;
    float: none;
    margin-top: 5px;
    margin-right: auto;
    margin-bottom: 5px;
    margin-left: auto;
    max-width: 100%;
    position: relative;
}
.e-video-center {
    cursor: pointer;
    display: block;
    float: none;
    margin-top: 5px;
    margin-right: auto;
    margin-bottom: 5px;
    margin-left: auto;
    max-width: 100%;
    position: relative;
}
.e-imgright {
    float: right;
    margin-top: 0;
    margin-right: auto;
    margin-bottom: 0;
    margin-left: auto;
    margin-left: 5px;
    text-align: right;
}
.e-video-right {
    float: right;
    margin-top: 0;
    margin-right: auto;
    margin-bottom: 0;
    margin-left: auto;
    margin-left: 5px;
    text-align: right;
}
.e-imgleft {
    float: left;
    margin-top: 0;
    margin-right: auto;
    margin-bottom: 0;
    margin-left: auto;
    margin-right: 5px;
    text-align: left;
}
.e-video-left {
    float: left;
    margin-top: 0;
    margin-right: auto;
    margin-bottom: 0;
    margin-left: auto;
    margin-right: 5px;
    text-align: left;
}
.e-rte-img-caption {
    display: inline-block;
    margin-top: 5px;
    margin-right: auto;
    margin-bottom: 5px;
    margin-left: auto;
    max-width: 100%;
    position: relative;
}
.e-caption-inline {
    display: inline-block;
    margin-top: 5px;
    margin-right: auto;
    margin-bottom: 5px;
    margin-left: auto;
    margin-left: 5px;
    margin-right: 5px;
    max-width: calc(100% - (2 * 5px));
    position: relative;
    text-align: center;
    vertical-align: bottom;
}
.e-img-wrap {
    display: inline-block;
    margin: auto;
    padding: 0;
    text-align: center;
    width: 100%;
}
.e-imgbreak {
    border: 0;
    cursor: pointer;
    display: block;
    float: none;
    margin-top: 5px;
    margin-right: auto;
    margin-bottom: 5px;
    margin-left: auto;
    max-width: 100%;
    position: relative;
}
.e-audio-break {
    border: 0;
    cursor: pointer;
    display: block;
    float: none;
    margin-top: 5px;
    margin-right: auto;
    margin-bottom: 5px;
    margin-left: auto;
    max-width: 100%;
    position: relative;
}
.e-video-break {
    border: 0;
    cursor: pointer;
    display: block;
    float: none;
    margin-top: 5px;
    margin-right: auto;
    margin-bottom: 5px;
    margin-left: auto;
    max-width: 100%;
    position: relative;
}
```
