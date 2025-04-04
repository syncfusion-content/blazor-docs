---
layout: post
title: Treeview Integration in Blazor Accordion Component | Syncfusion
description: Checkout and learn here all about Treeview Integration in Syncfusion Blazor Accordion component and more.
platform: Blazor
control: Accordion
documentation: ug
---

# Treeview Integration in Blazor Accordion Component

The Accordion component allows you to embed other Blazor components within its panels using the [ContentTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.AccordionItem.html#Syncfusion_Blazor_Navigations_AccordionItem_ContentTemplate) property. This capability enables you to create rich, nested UI structures that help organize complex information.

You can integrate a TreeView component inside an Accordion panel by placing the TreeView component within the ContentTemplate as shown below:

```cshtml
<ContentTemplate>
    <SfTreeView TValue="TreeviewItem"></SfTreeView>
</ContentTemplate>
```

The following example shows how to render a TreeView within the Accordion.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfAccordion>
    <AccordionItems>
        <AccordionItem>
            <HeaderTemplate>Documents</HeaderTemplate>
            <ContentTemplate>
                <SfTreeView TValue="TreeviewItem">
                    <TreeViewFieldsSettings TValue="TreeviewItem" Id="Id" DataSource="@DocumentFolder" Text="FolderName" ParentID="ParentId" HasChildren="HasSubFolders" Expanded="Expanded"></TreeViewFieldsSettings>
                </SfTreeView>
            </ContentTemplate>
        </AccordionItem>
        <AccordionItem>
            <HeaderTemplate>Downloads</HeaderTemplate>
            <ContentTemplate>
                <SfTreeView TValue="TreeviewItem">
                    <TreeViewFieldsSettings TValue="TreeviewItem" Id="Id" DataSource="@DownloadFolder" Text="FolderName" ParentID="ParentId" HasChildren="HasSubFolders" Expanded="Expanded"></TreeViewFieldsSettings>
                </SfTreeView>
            </ContentTemplate>
        </AccordionItem>
        <AccordionItem>
            <HeaderTemplate>Pictures</HeaderTemplate>
            <ContentTemplate>
                <SfTreeView TValue="TreeviewItem">
                    <TreeViewFieldsSettings TValue="TreeviewItem" Id="Id" DataSource="@PictureFolder" Text="FolderName" ParentID="ParentId" HasChildren="HasSubFolders" Expanded="Expanded"></TreeViewFieldsSettings>
                </SfTreeView>
            </ContentTemplate>
        </AccordionItem>
    </AccordionItems>
</SfAccordion>

@code{
    public class TreeviewItem
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string FolderName { get; set; }
        public bool Expanded { get; set; }
        public bool HasSubFolders { get; set; }
    }

    List<TreeviewItem> DocumentFolder = new List<TreeviewItem>();
    List<TreeviewItem> DownloadFolder = new List<TreeviewItem>();
    List<TreeviewItem> PictureFolder = new List<TreeviewItem>();

    protected override void OnInitialized()
    {
        base.OnInitialized();
        DocumentFolder.Add(new TreeviewItem
        {
            Id = "1",
            FolderName = "Documents",
            HasSubFolders = true,
            Expanded = false
        });
        DocumentFolder.Add(new TreeviewItem
        {
            Id = "2",
            ParentId = "1",
            FolderName = "Environment Pollution.docx"
        });
        DocumentFolder.Add(new TreeviewItem
        {
            Id = "3",
            ParentId = "1",
            FolderName = "Global Water, Sanitation, & Hygiene.docx"
        });
        DocumentFolder.Add(new TreeviewItem
        {
            Id = "4",
            ParentId = "1",
            FolderName = "Global Warming.ppt"
        });
        DocumentFolder.Add(new TreeviewItem
        {
            Id = "5",
            ParentId = "1",
            FolderName = "Social Network.pdf"
        });
        DocumentFolder.Add(new TreeviewItem
        {
            Id = "6",
            ParentId = "1",
            FolderName = "Youth Empowerment.pdf"
        });

        DownloadFolder.Add(new TreeviewItem
        {
            Id = "1",
            FolderName = "Downloads",
            HasSubFolders = true,
            Expanded = false
        });
        DownloadFolder.Add(new TreeviewItem
        {
            Id = "2",
            ParentId = "1",
            FolderName = "UI-Guide.pdf"
        });
        DownloadFolder.Add(new TreeviewItem
        {
            Id = "3",
            ParentId = "1",
            FolderName = "Tutorials.zip"
        });
        DownloadFolder.Add(new TreeviewItem
        {
            Id = "4",
            ParentId = "1",
            FolderName = "Game.exe"
        });
        DocumentFolder.Add(new TreeviewItem
        {
            Id = "5",
            ParentId = "1",
            FolderName = "TypeScript.7z"
        });
        PictureFolder.Add(new TreeviewItem
        {
            Id = "1",
            FolderName = "Pictures",
            HasSubFolders = true,
            Expanded = true
        });
        PictureFolder.Add(new TreeviewItem
        {
            Id = "2",
            ParentId = "1",
            FolderName = "Camera Roll",
            HasSubFolders = true,
        });
        PictureFolder.Add(new TreeviewItem
        {
            Id = "3",
            ParentId = "2",
            FolderName = "WIN_20160726_094117.JPG"
        });
        PictureFolder.Add(new TreeviewItem
        {
            Id = "4",
            ParentId = "2",
            FolderName = "WIN_20160726_094118.JPG"
        });
        PictureFolder.Add(new TreeviewItem
        {
            Id = "5",
            ParentId = "1",
            FolderName = "Wind.jpg"
        });
        PictureFolder.Add(new TreeviewItem
        {
            Id = "6",
            ParentId = "1",
            FolderName = "Stone.jpg"
        });
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/LthqWrMKgwYXnecX?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Treeview Integration in Blazor Accordion](../images/blazor-accordion-treeview-integration.png)
