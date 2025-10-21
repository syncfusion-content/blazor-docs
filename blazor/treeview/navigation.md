---
layout: post
title: Navigation in Blazor TreeView Component | Syncfusion
description: Checkout and learn here all about the navigation in Syncfusion Blazor TreeView component and much more.
platform: Blazor
control: TreeView
documentation: ug
---

# Navigation in Blazor TreeView Component

Using the [**NavigateUrl**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.TreeViewFieldOptions-1.html#Syncfusion_Blazor_Navigations_TreeViewFieldOptions_1_NavigateUrl) of the Blazor TreeView component, you can navigate from one page to another based on the node selection and link provided in the corresponding nodes.

To perform navigation in the TreeView component, use and map the **NavigateUrl** field in the data source.

## Navigation URL binding in Blazor TreeView Component

In the Blazor TreeView component, use the [**NavigateUrl**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.TreeViewFieldOptions-1.html#Syncfusion_Blazor_Navigations_TreeViewFieldOptions_1_NavigateUrl) property to specify the URL to navigate to when the tree node is selected.

```cshtml
@using Syncfusion.Blazor.Navigations
<SfTreeView TValue="MailItem">
    <TreeViewFieldsSettings TValue="MailItem" Id="ID" NavigateUrl="NavigateUrl" DataSource="@MyFolder" Text="FolderName" ParentID="ParentId" HasChildren="HasSubFolders" Expanded="Expanded"></TreeViewFieldsSettings>
</SfTreeView>

@code {
    public class MailItem
    {
        public string? ID { get; set; }
        public string? ParentId { get; set; }
        public string? FolderName { get; set; }
        public bool Expanded { get; set; }
        public bool HasSubFolders { get; set; }
        public string? NavigateUrl { get; set; }
    }
    List<MailItem> MyFolder = new List<MailItem>();
    protected override void OnInitialized()
    {
        base.OnInitialized();
        MyFolder.Add(new MailItem
            {
                ID = "1",
                FolderName = "Inbox",
                HasSubFolders = true,
                Expanded = true,
                NavigateUrl = "/counter"
            });
        MyFolder.Add(new MailItem
            {
                ID = "2",
                ParentId = "1",
                FolderName = "Categories",
                Expanded = true,
                HasSubFolders = true,
                NavigateUrl = "/home"
            });
        MyFolder.Add(new MailItem
            {
                ID = "3",
                ParentId = "2",
                FolderName = "Primary",
                NavigateUrl = "/syncfusiondemo"
            });
        MyFolder.Add(new MailItem
            {
                ID = "4",
                ParentId = "2",
                FolderName = "Social",
                NavigateUrl = "/syncfusiondoc"
            });
        MyFolder.Add(new MailItem
            {
                ID = "5",
                ParentId = "2",
                FolderName = "Promotions",
                NavigateUrl = "/treeview"
            });
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VZhyWXsKsofaKFFo?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Full Row Navigation in Blazor TreeView Component

The [`FullRowNavigable`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfTreeView-1.html#Syncfusion_Blazor_Navigations_SfTreeView_1_FullRowNavigable) property allows the entire TreeView node area, rather than just the text element, to be clickable and navigable in the Blazor TreeView component.

```cshtml
@using Syncfusion.Blazor.Navigations
<SfTreeView TValue="MailItem" FullRowNavigable="true">
    <TreeViewFieldsSettings TValue="MailItem" Id="ID" NavigateUrl="NavigateUrl" DataSource="@MyFolder" Text="FolderName" ParentID="ParentId" HasChildren="HasSubFolders" Expanded="Expanded"></TreeViewFieldsSettings>
</SfTreeView>

@code{
    public class MailItem
    {
        public string? ID { get; set; }
        public string? ParentId { get; set; }
        public string? FolderName { get; set; }
        public bool Expanded { get; set; }
        public bool HasSubFolders { get; set; }
        public string? NavigateUrl { get; set; }
    }
    List<MailItem> MyFolder = new List<MailItem>();
    protected override void OnInitialized()
    {
        base.OnInitialized();
        MyFolder.Add(new MailItem
        {
            ID = "1",
            FolderName = "Inbox",
            HasSubFolders = true,
            Expanded = true,
            NavigateUrl="/counter"
        });
        MyFolder.Add(new MailItem
        {
            ID = "2",
            ParentId = "1",
            FolderName = "Categories",
            Expanded = true,
            HasSubFolders = true,
            NavigateUrl="/home"
        });
        MyFolder.Add(new MailItem
        {
            ID = "3",
            ParentId = "2",
            FolderName = "Primary"
        });
        MyFolder.Add(new MailItem
        {
            ID = "4",
            ParentId = "2",
            FolderName = "Social"
        });
        MyFolder.Add(new MailItem
        {
            ID = "5",
            ParentId = "2",
            FolderName = "Promotions"
        });
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/htBeMjMgWyoQVXTq?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Handle Processing on Node Click in Blazor TreeView Component

When a node in the Blazor TreeView component is clicked, its ID, text, and parent ID are retrieved using the [`NodeClicked`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.TreeViewEvents-1.html#Syncfusion_Blazor_Navigations_TreeViewEvents_1_NodeClicked) event.

```cshtml
@using Syncfusion.Blazor.Navigations
<div class="tree">
<SfTreeView TValue="MailItem" @ref="tree">
    <TreeViewEvents TValue="MailItem" NodeClicked="nodeClicked"></TreeViewEvents>
    <TreeViewFieldsSettings TValue="MailItem" Id="ID" HtmlAttributes="HtmlAttributes" DataSource="@MyFolder" Text="FolderName" ParentID="ParentId" HasChildren="HasSubFolders" Expanded="Expanded"></TreeViewFieldsSettings>
</SfTreeView>
</div>
<div class="containers">
    <p>Details of the clicked node</p>
<table >
        <tr>
            <th style="width: 50%">ID</th>
            <td style="width: 50%" align="center"><div>@ID</div></td>
        </tr>
        <tr>
            <th style="width: 50%;">Text</th>
            <td style="width: 30%" align="center">
                <div>@Text</div>
            </td>
        </tr>
        <tr><th style="width: 50%;" >Parent ID</th>
            <td style="width: 30%" align="center">
                    @if (ParentID == null)
                    {
                        <div>null</div>
                    }
                    else
                    {
                        <div>@ParentID</div>
                    }
            </td>
        </tr>
    </table>
</div>
@code {
    SfTreeView<MailItem> tree;
    public class MailItem
    {
        public string? ID { get; set; }
        public string? ParentId { get; set; }
        public string? FolderName { get; set; }
        public bool Expanded { get; set; }
        public bool HasSubFolders { get; set; }
        public Dictionary<string, object> HtmlAttributes { get; set; }
    }

    List<MailItem> MyFolder = new List<MailItem>();
    protected override void OnInitialized()
    {
        base.OnInitialized();
        MyFolder.Add(new MailItem
            {
                ID = "1",
                FolderName = "Inbox",
                HasSubFolders = true,
                Expanded = true
            });
        MyFolder.Add(new MailItem
            {
                ID = "2",
                ParentId = "1",
                FolderName = "Categories",
                Expanded = true,
                HasSubFolders = true
            });
        MyFolder.Add(new MailItem
            {
                ID = "3",
                ParentId = "2",
                FolderName = "Primary"
            });
        MyFolder.Add(new MailItem
            {
                ID = "4",
                ParentId = "2",
                FolderName = "Social"
            });
        MyFolder.Add(new MailItem
            {
                ID = "5",
                ParentId = "2",
                FolderName = "Promotions"
            });

    }
    public string? ID;
    public string? Text;
    public string? ParentID;
    public void nodeClicked(NodeClickEventArgs args)
    {
        ID = (args.NodeData.Id);
        Text = (args.NodeData.Text);
        ParentID = (args.NodeData.ParentID);
    }
}
<style>
    .containers {
        margin-top: -200px;
        margin-left: 800px;
    }
    .tree{
        width:50%;
    }
</style>

```

## Tree Node as Hyperlink in Blazor TreeView Component

The [**NavigateUrl**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.TreeViewFieldOptions-1.html#Syncfusion_Blazor_Navigations_TreeViewFieldOptions_1_NavigateUrl) property is used to navigate between pages upon tree node selection. Custom CSS styles are applied to visually customize the TreeView node to appear as a hyperlink.

```cshtml

@using Syncfusion.Blazor.Navigations
<SfTreeView TValue="MailItem">
    <TreeViewFieldsSettings TValue="MailItem" Id="ID" NavigateUrl="NavigateUrl" DataSource="@MyFolder" Text="FolderName" ParentID="ParentId" HasChildren="HasSubFolders" Expanded="Expanded"></TreeViewFieldsSettings>
</SfTreeView>

@code{
    public class MailItem
    {
        public string? ID { get; set; }
        public string? ParentId { get; set; }
        public string? FolderName { get; set; }
        public bool Expanded { get; set; }
        public bool HasSubFolders { get; set; }
        public string? NavigateUrl { get; set; }
    }
    List<MailItem> MyFolder = new List<MailItem>();
    protected override void OnInitialized()
    {
        base.OnInitialized();
        MyFolder.Add(new MailItem
        {
            ID = "1",
            FolderName = "Inbox",
            HasSubFolders = true,
            Expanded = true,
            NavigateUrl="/counter"
        });
        MyFolder.Add(new MailItem
        {
            ID = "2",
            ParentId = "1",
            FolderName = "Categories",
            Expanded = true,
            HasSubFolders = true,
            NavigateUrl="/home"
        });
        MyFolder.Add(new MailItem
        {
            ID = "3",
            ParentId = "2",
            FolderName = "Primary",
            NavigateUrl = "/"
        });
        MyFolder.Add(new MailItem
        {
            ID = "4",
            ParentId = "2",
            FolderName = "Social",
            NavigateUrl = "/social"
        });
        MyFolder.Add(new MailItem
        {
            ID = "5",
            ParentId = "2",
            FolderName = "Promotions",
            NavigateUrl = "/promotions"
        });
    }
}
<style>
    .e-treeview .e-list-text {
        cursor: pointer;
        color: blue;
        text-decoration: underline;
    }
</style>

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rjVyiDMgMIHAZHOb?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## NavigateUrl with Built-in URLs

The functionality of the `href` attribute in the Blazor TreeView component's [`NavigateUrl`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.TreeViewFieldOptions-1.html#Syncfusion_Blazor_Navigations_TreeViewFieldOptions_1_NavigateUrl) property is aligned with Blazor routing standards. Instead of rendering a traditional anchor tag, the component now uses the [NavigationManager.NavigateTo](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.navigationmanager.navigateto?view=aspnetcore-9.0) method to programmatically navigate to the specified URL.

However, when using the built-in URLs from the NuGet package (for example, **MicrosoftIdentity/Account/SignOut** from **Microsoft.Identity.Web.UI**), these URLs may not function properly in the application. To resolve this, you need to prevent the default navigation functionality by setting [`args.Cancel`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.NodeSelectEventArgs.html#Syncfusion_Blazor_Navigations_NodeSelectEventArgs_Cancel) to **true** and then use the [NavigationManager.NavigateTo](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.navigationmanager.navigateto?view=aspnetcore-9.0) method within the [NodeSelecting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.TreeViewEvents-1.html#Syncfusion_Blazor_Navigations_TreeViewEvents_1_NodeSelecting) event, as shown below:

```cshtml

@inject NavigationManager Navigate
@using Syncfusion.Blazor.Navigations

<SfTreeView TValue="NavbarItemTree" ExpandOn="@ExpandAction.Click">
    <TreeViewEvents TValue="NavbarItemTree" NodeSelecting="NodeSelecting"></TreeViewEvents>
    <TreeViewFieldsSettings TValue="NavbarItemTree"
                            Id="@nameof(NavbarItemTree.NodeId)"
                            NavigateUrl="@nameof(NavbarItemTree.NodeLink)"
                            Text="@nameof(NavbarItemTree.NodeText)"
                            HasChildren="@nameof(NavbarItemTree.HasChild)"
                            ParentID="@nameof(NavbarItemTree.ParentId)"
                            DataSource="@NavbarItemNodes">
    </TreeViewFieldsSettings>
</SfTreeView>

@code {
    public void NodeSelecting(NodeSelectEventArgs args)
    {
        if (args.NodeData.Id == "3")
        {
            args.Cancel = true;
            Navigate.NavigateTo("MicrosoftIdentity/Account/SignOut", true);
        }
    }

    public class NavbarItemTree
    {
        public int NodeId { get; set; }
        public int? ParentId { get; set; }
        public bool HasChild { get; set; }
        public bool Expanded { get; set; }
        public bool Selected { get; set; }
        public string NodeText { get; set; }
        public string NodeLink { get; set; }
    }

    private readonly List<NavbarItemTree> NavbarItemNodes = new();

    protected override void OnInitialized()
    {
        NavbarItemNodes.Add(new NavbarItemTree
        {
            NodeId = 1,
            NodeText = "Account",
            HasChild = true
        });

        NavbarItemNodes.Add(new NavbarItemTree
        {
            ParentId = 1,
            NodeId = 2,
            NodeLink = "/counter",
            NodeText = "Profile"
        });

        NavbarItemNodes.Add(new NavbarItemTree
        {
            ParentId = 1,
            NodeId = 3,
            NodeLink = "MicrosoftIdentity/Account/SignOut",
            NodeText = "Logout"
        });
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VXVyMNiKiecLpEyW?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}