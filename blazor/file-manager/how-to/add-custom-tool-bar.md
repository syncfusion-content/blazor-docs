---
layout: post
title: Adding Custom Item to Toolbar in Blazor FileManager | Syncfusion
description: Learn here all about adding custom item to toolbar in Syncfusion Blazor FileManager component and more.
platform: Blazor
control: File Manager
documentation: ug
---

# Adding Custom Item to Toolbar in Blazor FileManager Component

The custom toolbar items can be added and customized using the `ToolbarSettings` API and `FileManagerCustomToolbarItem` property.

**Case1**: The 'Custom' button has been introduced to the toolbar using the list of items. To access the custom tool, you can utilize the PrefixIcon and Tooltip attributes, which have been incorporated into the newly added toolbar button.

**Case2**:To include additional components in the toolbar, you need to utilize the template tag. This allows you to render other components seamlessly within the toolbar.

```cshtml

@using Syncfusion.Blazor.FileManager

    <SfFileManager TValue="FileManagerDirectoryContent">
        <FileManagerAjaxSettings Url="/api/SampleData/FileOperations"
                                 UploadUrl="/api/SampleData/Upload"
                                 DownloadUrl="/api/SampleData/Download"
                                 GetImageUrl="/api/SampleData/GetImage">
        </FileManagerAjaxSettings>
        <FileManagerToolbarSettings ToolbarItems="@Items"> 
            <FileManagerCustomToolbarItem Name="Zoomin">
                <Template>
                    <SfButton CssClass="e-tbar-btn-text e-tbar-ddb-text " Content="Zoom In" IconCss="e-icons e-zoom-in"></SfButton>
                </Template>
            </FileManagerCustomToolbarItem>
        </FileManagerToolbarSettings>
    </SfFileManager>

@code {
    public List<ToolBarItemModel> Items = new List<ToolBarItemModel>(){
        new ToolBarItemModel() { Name = "NewFolder" },
        new ToolBarItemModel() { Name = "Cut" },
        new ToolBarItemModel() { Name = "Copy" },
        new ToolBarItemModel() { Name = "Paste" },
        new ToolBarItemModel() { Name = "Delete" },
        new ToolBarItemModel() { Name = "Download" },
        new ToolBarItemModel() { Name = "Rename" },
        new ToolBarItemModel() { Name = "SortBy" },
        new ToolBarItemModel() { Name = "Refresh" },
        new ToolBarItemModel() { Name = "Custom", Text="Custom", TooltipText="Test Tooltip", PrefixIcon="e-icons e-check"},
        new ToolBarItemModel() {  Name = "Zoomin" , TooltipText ="Click to zoom in" },
        new ToolBarItemModel() { Name = "Selection" },
        new ToolBarItemModel() { Name = "View" },
        new ToolBarItemModel() { Name = "Details" },
    };
}

```

## Run the application

After successful compilation of your application, simply press `F5` to run the application.



![Blazor FileManger displays Custom Item in Toolbar](../images/blazor-filemanager-custom-item-in-toolbar.png)
