---
layout: post
title: Insert HTML in Blazor DocumentEditor | Syncfusion
description: Learn how to Insert HTML in the Syncfusion Blazor Document Editor component and much more.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# Insert HTML in Blazor Document Editor

The Document Editor allows you to insert HTML content, which is then seamlessly integrated into your document.

The following example code illustrates how to insert html content in document editor.

```csharp
@using System.IO
@using Syncfusion.Blazor.DocumentEditor
@using System.Text.Json

<SfDocumentEditorContainer @ref="container" EnableToolbar=true ToolbarItems="@Items">
    <DocumentEditorContainerEvents OnToolbarClick="OnToolbarClick"></DocumentEditorContainerEvents> 
</SfDocumentEditorContainer> 
 
@code { 
    SfDocumentEditorContainer container; 
    List<Object> Items = new List<Object> { "New","Open",new CustomToolbarItemModel() { Id = "insert", Text = "Insert HTML",PrefixIcon= "e-paste icon" }, "Separator", "Undo", "Redo", "Separator", "Image", "Table", "Hyperlink", "Bookmark", "TableOfContents", "Separator", "Header", "Footer", "PageSetup", "PageNumber", "Break", "InsertFootnote", "InsertEndnote", "Separator", "Find", "Separator", "Comments", "TrackChanges", "Separator", "LocalClipboard", "RestrictEditing", "Separator", "FormFields", "UpdateFields" }; 

    private void OnToolbarClick(ClickEventArgs args)
    {
        if (args.Item.Id == "insert")
        {
            InsertHtml();
        }
    }

    private async Task InsertHtml()
    {
        string htmlContent = @"
        <html>
            <body style='font-size: ""12px""; font-family: ""Algerian""; color: ""#e02222""; '>
                <table title='hello' border='1' bordercolor='black' cellspacing='0'>
                    <thead>
                        <tr>
                        <th>hello</th>
                        </tr>
                    </thead>
                    <tbody>
                    <tr>
                    <td>World</td>
                    </tr>
                    </tbody>
                </table>
            </body>
        </html>";
        htmlContent = htmlContent.Replace("\n", "").Replace("\r", "").Trim();
        WordDocument document = WordDocument.LoadString(htmlContent, ImportFormatType.Docx);
        string sfdtString = JsonSerializer.Serialize(document);
        await container.DocumentEditor.Editor.PasteAsync(sfdtString);
    }
}; 
```