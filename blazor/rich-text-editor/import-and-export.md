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