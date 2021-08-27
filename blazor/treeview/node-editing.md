---
layout: post
title: Node Editing in Blazor TreeView Component | Syncfusion
description: Checkout and learn here all about Node Editing in Syncfusion Blazor TreeView component and much more.
platform: Blazor
control: TreeView
documentation: ug
---

# Node Editing in Blazor TreeView Component

The Blazor TreeView allows to edit nodes by setting the `AllowEditing` property to **true**. To directly edit the nodes in place, **double click** the TreeView node or **select** the node and press **F2** key.

When editing is completed by focus out or by pressing the **Enter** key, the modified node’s text saves automatically. If you do not want to save the modified node’s text in TreeView node, press **Escape** key. It does not save the edited text to the TreeView node.

* Node editing can also be performed programmatically by using the `BeginEdit` method. On passing the node ID or element through this method, the edit textbox will be created for the particular node thus allowing us to edit it.

* In order to validate or prevent editing, the `NodeEditing` event can be used which is triggered before the TreeView node is renamed. On successfully renaming a node the `NodeEdited` event will be triggered.

```cshtml
@using Syncfusion.Blazor.Navigations
<SfTreeView TValue="DriveData" AllowEditing="true">
    <TreeViewFieldsSettings TValue="DriveData" Id="NodeId" Text="NodeText" Child="Children" DataSource="@Drive" Expanded="Expanded"></TreeViewFieldsSettings>
</SfTreeView>

@code{
    public class DriveData
    {
        public string NodeId { get; set; }
        public string NodeText { get; set; }
        public bool Expanded { get; set; }
        public bool Selected { get; set; }
        public List<DriveData> Children;
    }

    object Child;
    List<DriveData> Drive = new List<DriveData>();
    protected override void OnInitialized()
    {
        base.OnInitialized();
        List<DriveData> Folder1 = new List<DriveData>();

        Drive.Add(new DriveData
        {
            NodeId = "01",
            NodeText = "Local Disk (C:)",
            Children = Folder1,
        });

        List<DriveData> File1 = new List<DriveData>();

        Folder1.Add(new DriveData
        {
            NodeId = "01-01",
            NodeText = "Program Files",
            Children = File1
        });
        File1.Add(new DriveData
        {
            NodeId = "01-01-01",
            NodeText = "Windows NT"
        });

        List<DriveData> File2 = new List<DriveData>();

        Folder1.Add(new DriveData
        {
            NodeId = "01-02",
            NodeText = "Users",
            Expanded = true,
            Children = File2
        });
        File2.Add(new DriveData
        {
            NodeId = "01-02-01",
            NodeText = "Smith"
        });

        List<DriveData> File3 = new List<DriveData>();

        Folder1.Add(new DriveData
        {
            NodeId = "01-03",
            NodeText = "Windows",
            Children = File3
        });
        File3.Add(new DriveData
        {
            NodeId = "01-03-01",
            NodeText = "Boot"
        });

        List<DriveData> Folder2 = new List<DriveData>();

        Drive.Add(new DriveData
        {
            NodeId = "02",
            NodeText = "Local Disk (D:)",
            Children = Folder2,
            Expanded = true,
        });

        List<DriveData> File4 = new List<DriveData>();

        Folder2.Add(new DriveData
        {
            NodeId = "02-01",
            NodeText = "Personals"
        });
        Folder2.Add(new DriveData
        {
            NodeId = "02-02",
            NodeText = "Projects"
        });
        Folder2.Add(new DriveData
        {
            NodeId = "02-03",
            NodeText = "Office"
        });
    }
}

```

![TreeView Sample](./images/node-editing.png)