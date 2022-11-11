---
layout: post
title: Update form field using context menu in Blazor PDF Viewer | Syncfusion
description: Learn here all about how to update form field using context menu in Syncfusion Blazor PDF Viewer component and more.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# Update form field using context menu in Blazor PDF Viewer Component

You can update the form field's at runtime using the FormFieldClick event and UpdateFormFieldsAsync() method of PDF Viewer. The following code example explains how to open Context menu when you click on the form field and how to update the menu item content as form field's value. In this example, the Syncfusion’s ContextMenu component is used to update form field.


```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.PdfViewer
@using Syncfusion.Blazor.PdfViewerServer
@using Syncfusion.Blazor.Navigations 

<div id="target" class="e-pdfviewer-signatureformfields" @onmousemove="mouseOver" style="position:absolute;left:0;right:0;top:0;bottom:0;z-index:100">
    <SfPdfViewerServer @ref="viewer" DocumentPath="@DocumentPath" Height="100%" Width="100%">
        <PdfViewerEvents DocumentLoaded="@documentLoad" FormFieldClick="@formFeildClick"></PdfViewerEvents>
    </SfPdfViewerServer>
</div>

<SfContextMenu @ref="contextMenuObj" Target="#target" Items="@menuItems">
    <MenuFieldSettings Text="Content"></MenuFieldSettings>
    <MenuEvents TValue="CustomItem" ItemSelected="@selectedHandler"></MenuEvents>
</SfContextMenu>

@code 
{    
    SfPdfViewerServer viewer;
    SfContextMenu<CustomItem> contextMenuObj;

    private class CustomItem
    {
        public string Content { get; set; }
        public string Id { get; set; }
    }

    //Sets the PDF document path for initial loading.
    private string DocumentPath { get; set; } = "wwwroot/FF1.pdf";

    double x = 0; double y = 0;
    private string feildId = "";
    FormField formField;
    private CustomItem SelectedItem;

    private void mouseOver(MouseEventArgs args)
    {
        x = args.ClientX;
        y = args.ClientY;
    }

    //This method will get invoked when the menu item is clicked.
    private void selectedHandler(MenuEventArgs<CustomItem> args)
    {
        SelectedItem = args.Item;
        Dictionary<string, string> param = new Dictionary<string, string>();
        param.Add(feildId, SelectedItem.Content); 
        formField.Value = SelectedItem.Content;
        //This method is used to update the isReadOnly property of the form field.
        viewer.UpdateFormFieldsAsync(formField);  
    }

    //This method will get invoked when you click on the form field like name.
    private void formFeildClick(FormFieldClickArgs args)
    {
        feildId = args.Field.Id;
        formField = args.Field;
        //This method will open the context menu on the specified position.
        contextMenuObj.Open(x, y);
    }

    //Represents the collection to hold the menu items.
    private List<CustomItem> menuItems = new List<CustomItem>();

    //This method will get invoked once the PDF Viewer is loaded.
    private async void documentLoad(LoadEventArgs args)
    {
        //Perform export annotations action in the PDF Viewer. 
        Dictionary<string, string> feilds = await viewer.ExportFormFieldsAsObjectAsync();
        if (feilds.Keys.Count > 0)
        {
            foreach (KeyValuePair<string, string> feild in feilds)
            {
                if (menuItems.Count < 10)
                {
                    //Add custom menu item to the menuitems list.
                    menuItems.Add(new CustomItem() { Content = feild.Key, Id = feild.Key });
                }
            }

        }
    }
}
```

> [View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Render%20PDFViewer%20with%20different%20components/PDFViewer%20with%20ContextMenu).

> You can refer to our [Blazor PDF Viewer](https://www.syncfusion.com/blazor-components/blazor-pdf-viewer) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor PDF Viewer example](https://blazor.syncfusion.com/demos/pdf-viewer/default-functionalities?theme=bootstrap4) to understand how to explains core features of PDF Viewer.