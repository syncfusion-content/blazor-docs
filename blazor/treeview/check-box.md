---
layout: post
title: CheckBox in Blazor TreeView Component | Syncfusion
description: Checkout and learn here all about CheckBox in Syncfusion Blazor TreeView component and much more details.
platform: Blazor
control: TreeView
documentation: ug
---

# CheckBox in Blazor TreeView Component

The Blazor TreeView component enables multiple node selection through checkboxes by activating the [`ShowCheckBox`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfTreeView-1.html#Syncfusion_Blazor_Navigations_SfTreeView_1_ShowCheckBox) property. When this property is enabled, a checkbox appears before the text of each TreeView node.


## AutoCheck in Blazor TreeView Component

By default, the checked states of parent and child nodes are dependent. This means:
*   If not all child nodes are checked, the parent node will display as partially checked (in an intermediate state).
*   If all child nodes are checked, the parent node will display as fully checked.
*   When a parent node is checked, its child nodes will also become checked.

For independent checked states, allowing child nodes to be checked or unchecked without affecting their parents (and vice-versa), use the [`AutoCheck`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfTreeView-1.html#Syncfusion_Blazor_Navigations_SfTreeView_1_AutoCheck) property. Set `AutoCheck` to `false` to achieve independent states.

```cshtml
@using Syncfusion.Blazor.Navigations
<SfTreeView TValue="MusicAlbum" ShowCheckBox="true" AutoCheck="true">
    <TreeViewFieldsSettings TValue="MusicAlbum" Id="Id" DataSource="@Albums" Text="Name" ParentID="ParentId" HasChildren="HasChild" Expanded="Expanded" IsChecked="IsChecked"></TreeViewFieldsSettings>
</SfTreeView>

@code{
    public class MusicAlbum
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string? Name { get; set; }
        public bool Expanded { get; set; }
        public bool? IsChecked { get; set; }
        public bool HasChild { get; set; }
    }
    List<MusicAlbum> Albums = new List<MusicAlbum>();
    protected override void OnInitialized()
    {
        base.OnInitialized();
        Albums.Add(new MusicAlbum
        {
            Id = 1,
            Name = "Discover Music",
            HasChild = true,
        });
        Albums.Add(new MusicAlbum
        {
            Id = 2,
            ParentId = 1,
            Name = "Hot Singles"
        });
        Albums.Add(new MusicAlbum
        {
            Id = 3,
            ParentId = 1,
            Name = "Rising Artists"
        });
        Albums.Add(new MusicAlbum
        {
            Id = 4,
            ParentId = 1,
            Name = "Live Music"
        });
        Albums.Add(new MusicAlbum
        {
            Id = 14,
            HasChild = true,
            Name = "MP3 Albums",
            Expanded = true,
            IsChecked = true
        });
        Albums.Add(new MusicAlbum
        {
            Id = 15,
            ParentId = 14,
            Name = "Rock"
        });
        Albums.Add(new MusicAlbum
        {
            Id = 16,
            Name = "Gospel",
            ParentId = 14,
        });
        Albums.Add(new MusicAlbum
        {
            Id = 17,
            ParentId = 14,
            Name = "Latin Music"
        });
        Albums.Add(new MusicAlbum
        {
            Id = 18,
            ParentId = 14,
            Name = "Jazz"
        });
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNhSitCBUvmzMcKy?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor TreeView with CheckBox](./images/blazor-treeview-checkbox.png)" %}

## Check Nodes through Data Binding

A specific node is checked by setting the [`IsChecked`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.TreeViewFieldSettings-1.html#Syncfusion_Blazor_Navigations_TreeViewFieldSettings_1_IsChecked) field to `true` for the corresponding node in the data source. This field specifies the checked state of the TreeView node.

```cshtml
@using Syncfusion.Blazor.Navigations
<SfTreeView TValue="MusicAlbum" ShowCheckBox="true" AutoCheck="true">
    <TreeViewFieldsSettings TValue="MusicAlbum" Id="Id" DataSource="@Albums" Text="Name" ParentID="ParentId" HasChildren="HasChild" Expanded="Expanded" IsChecked="IsChecked"></TreeViewFieldsSettings>
</SfTreeView>

@code{
    public class MusicAlbum
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string? Name { get; set; }
        public bool Expanded { get; set; }
        public bool? IsChecked { get; set; }
        public bool HasChild { get; set; }
    }
    List<MusicAlbum> Albums = new List<MusicAlbum>();
    protected override void OnInitialized()
    {
        base.OnInitialized();
        Albums.Add(new MusicAlbum
        {
            Id = 1,
            Name = "Discover Music",
            HasChild = true,
        });
        Albums.Add(new MusicAlbum
        {
            Id = 2,
            ParentId = 1,
            Name = "Hot Singles"
        });
        Albums.Add(new MusicAlbum
        {
            Id = 3,
            ParentId = 1,
            Name = "Rising Artists"
        });
        Albums.Add(new MusicAlbum
        {
            Id = 4,
            ParentId = 1,
            Name = "Live Music"
        });
        Albums.Add(new MusicAlbum
        {
            Id = 14,
            HasChild = true,
            Name = "MP3 Albums",
            Expanded = true,
            IsChecked = true
        });
        Albums.Add(new MusicAlbum
        {
            Id = 15,
            ParentId = 14,
            Name = "Rock"
        });
        Albums.Add(new MusicAlbum
        {
            Id = 16,
            Name = "Gospel",
            ParentId = 14,
        });
        Albums.Add(new MusicAlbum
        {
            Id = 17,
            ParentId = 14,
            Name = "Latin Music"
        });
        Albums.Add(new MusicAlbum
        {
            Id = 18,
            ParentId = 14,
            Name = "Jazz"
        });
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VZreMtWrAblXlpWM?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Check nodes using CheckedNodes property

The Blazor TreeView component enables checking specific nodes upon initial rendering or dynamically via the two-way bound [`CheckedNodes`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfTreeView-1.html#Syncfusion_Blazor_Navigations_SfTreeView_1_CheckedNodes) property. This property accepts an array of node IDs (as strings) to control checkbox selection.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfTreeView TValue="MusicAlbum" ShowCheckBox="true" AutoCheck="true" @bind-CheckedNodes="CheckedNodes">
    <TreeViewFieldsSettings TValue="MusicAlbum" Id="Id" DataSource="@Albums" Text="Name" ParentID="ParentId" HasChildren="HasChild" Expanded="Expanded" IsChecked="IsChecked"></TreeViewFieldsSettings>
</SfTreeView>

@code {
    // Specifies the CheckedNodes value for TreeView component.
    public string[] CheckedNodes = new string[] { "2", "4" };
    public class MusicAlbum
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string? Name { get; set; }
        public bool Expanded { get; set; }
        public bool? IsChecked { get; set; }
        public bool HasChild { get; set; }
    }
    List<MusicAlbum> Albums = new List<MusicAlbum>();
    protected override void OnInitialized()
    {
        base.OnInitialized();
        Albums.Add(new MusicAlbum
            {
                Id = 1,
                Name = "Discover Music",
                HasChild = true,
                Expanded = true
            });
        Albums.Add(new MusicAlbum
            {
                Id = 2,
                ParentId = 1,
                Name = "Hot Singles"
            });
        Albums.Add(new MusicAlbum
            {
                Id = 3,
                ParentId = 1,
                Name = "Rising Artists"
            });
        Albums.Add(new MusicAlbum
            {
                Id = 4,
                ParentId = 1,
                Name = "Live Music"
            });
        Albums.Add(new MusicAlbum
            {
                Id = 14,
                HasChild = true,
                Name = "MP3 Albums",
                Expanded = true

            });
        Albums.Add(new MusicAlbum
            {
                Id = 15,
                ParentId = 14,
                Name = "Rock"
            });
        Albums.Add(new MusicAlbum
            {
                Id = 16,
                Name = "Gospel",
                ParentId = 14,
            });
        Albums.Add(new MusicAlbum
            {
                Id = 17,
                ParentId = 14,
                Name = "Latin Music"
            });
        Albums.Add(new MusicAlbum
            {
                Id = 18,
                ParentId = 14,
                Name = "Jazz"
            });
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rXBSMZsVqvvPrMXI?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor TreeView](./images/checkednodes.png)" %}

## Check and Uncheck All Nodes

The Blazor TreeView component offers the ability to check all unchecked nodes within the component by utilizing the [CheckAllAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfTreeView-1.html#Syncfusion_Blazor_Navigations_SfTreeView_1_CheckAllAsync_System_String___) method. Additionally, specific nodes are selected by passing an array of their IDs to this method. The [`UncheckAllAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfTreeView-1.html#Syncfusion_Blazor_Navigations_SfTreeView_1_UncheckAllAsync_System_String___) method performs the opposite action, unchecking all previously checked nodes, or specific nodes if an array of checked node IDs is passed.

The example demonstrates the usage of these methods within the context of a button click event.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="CheckAll">TreeView CheckAll</SfButton>
<SfButton OnClick="UncheckAll">TreeView UncheckAll</SfButton>
<SfTreeView TValue="MusicAlbum" @ref="treeview" ShowCheckBox="true" AutoCheck="true">
    <TreeViewFieldsSettings TValue="MusicAlbum" Id="Id" DataSource="@Albums" Text="Name" ParentID="ParentId" HasChildren="HasChild" Expanded="Expanded" IsChecked="IsChecked"></TreeViewFieldsSettings>
</SfTreeView>
@code {
    SfTreeView<MusicAlbum>? treeview;
    public class MusicAlbum
    {
        public string? Id { get; set; }
        public string? ParentId { get; set; }
        public string? Name { get; set; }
        public bool Expanded { get; set; }
        public bool? IsChecked { get; set; }
        public bool HasChild { get; set; }
    }
    List<MusicAlbum> Albums = new List<MusicAlbum>();
    protected override void OnInitialized()
    {
        base.OnInitialized();
        Albums.Add(new MusicAlbum
            {
                Id = "1",
                Name = "Discover Music",
                HasChild = true,
                Expanded=true
            });
        Albums.Add(new MusicAlbum
            {
                Id = "2",
                ParentId = "1",
                Name = "Hot Singles"
            });
        Albums.Add(new MusicAlbum
            {
                Id = "3",
                ParentId = "1",
                Name = "Rising Artists"
            });
        Albums.Add(new MusicAlbum
            {
                Id = "4",
                ParentId = "1",
                Name = "Live Music"
            });
        Albums.Add(new MusicAlbum
            {
                Id = "04",
                HasChild = true,
                Name = "MP3 Albums",
                Expanded = true
            });
        Albums.Add(new MusicAlbum
            {
                Id = "5",
                ParentId = "04",
                Name = "Rock"
            });
        Albums.Add(new MusicAlbum
            {
                Id = "6",
                Name = "Gospel",
                ParentId = "04",
            });
        Albums.Add(new MusicAlbum
            {
                Id = "7",
                ParentId = "04",
                Name = "Latin Music"
            });
        Albums.Add(new MusicAlbum
            {
                Id = "8",
                ParentId = "04",
                Name = "Jazz"
            });
    }
    public void CheckAll()
    {
        // To check all the nodes in the TreeView
        this.treeview.CheckAllAsync();
        // To check the particular node in the TreeView
        // this.treeview.CheckAllAsync(new string[]{"1"});
    }
    public void UncheckAll()
    {
        // To uncheck all the nodes in the TreeView
        this.treeview.UncheckAllAsync();
        // To uncheck the particular node in the TreeView
        // this.treeview.UncheckAllAsync(new string[]{"1"});
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LtrICXiVgusUIOKg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor TreeView](./images/check-uncheck.png)" %}

## Get Checked Nodes

The Blazor TreeView component provides the capability to pre-select specific nodes during initialization through the [`CheckedNodes`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfTreeView-1.html#Syncfusion_Blazor_Navigations_SfTreeView_1_CheckedNodes) property. Additionally, the component offers the [`GetTreeData`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfTreeView-1.html#Syncfusion_Blazor_Navigations_SfTreeView_1_GetTreeData_System_String_) method, which allows for retrieval of the updated data source. By passing the IDs of specific TreeView nodes (obtained from `CheckedNodes`) as arguments to this method, the updated data source of only those nodes will be returned. If no arguments are passed, the entire updated data source of the TreeView will be returned.

```cshtml
@using Syncfusion.Blazor.Navigations

<div class="control_wrapper">
    <SfTreeView TValue="MusicAlbum" @ref="TreeRef" ShowCheckBox="true" @bind-CheckedNodes="@CheckedNodes">
        <TreeViewFieldsSettings TValue="MusicAlbum" Id="Id" DataSource="@Albums" Text="Name" ParentID="ParentId" HasChildren="HasChild" Expanded="Expanded" IsChecked="IsChecked"></TreeViewFieldsSettings>
    </SfTreeView>
</div>
<div class="col-lg-4 property-section property-custom">
    <div class="property-panel-section">
        <div class="property-panel-header">Checked Items</div>
        <div id="selecttable" class="property-panel-content">
            <table id="property" title="Properties" class="property-panel-table">
                <thead>
                    <tr>
                        <th style="width: 50%">Id</th>
                        <th style="width: 50%;">Text</th>
                    </tr>
                </thead>
                <tbody>
                    @if (TreeRef != null)
                    {
                        @for (int i = 0; i < CheckedNodes?.Length; i++)
                        {
                            List<MusicAlbum> tree = TreeRef.GetTreeData(CheckedNodes[i]);
                            <tr>
                                <td style="width: 30%">
                                    <div>@tree[0].Id</div>
                                </td>
                                <td style="width: 30%">
                                    <div>@tree[0].Name</div>
                                </td>
                            </tr>
                        }
                    }
                </tbody>
            </table>
        </div>
    </div>
</div>
@code {
    // Specify the reference of TreeView element.
    SfTreeView<MusicAlbum>? TreeRef;
    // Specifies the CheckedNodes value for TreeView component.
    public string[] CheckedNodes = new string[] { "2", "4" };
    public class MusicAlbum
    {
        public string? Id { get; set; }
        public int? ParentId { get; set; }
        public string? Name { get; set; }
        public bool Expanded { get; set; }
        public bool? IsChecked { get; set; }
        public bool HasChild { get; set; }
    }
    List<MusicAlbum> Albums = new List<MusicAlbum>();
    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
        {
            StateHasChanged();
        }
    }
    protected override void OnInitialized()
    {
        base.OnInitialized();
        Albums.Add(new MusicAlbum
            {
                Id = "1",
                Name = "Discover Music",
                HasChild = true,
                Expanded = true
            });
        Albums.Add(new MusicAlbum
            {
                Id = "2",
                ParentId = 1,
                Name = "Hot Singles"
            });
        Albums.Add(new MusicAlbum
            {
                Id = "3",
                ParentId = 1,
                Name = "Rising Artists"
            });
        Albums.Add(new MusicAlbum
            {
                Id = "4",
                ParentId = 1,
                Name = "Live Music"
            });
        Albums.Add(new MusicAlbum
            {
                Id = "14",
                HasChild = true,
                Name = "MP3 Albums",
                Expanded = true

            });
        Albums.Add(new MusicAlbum
            {
                Id = "15",
                ParentId = 14,
                Name = "Rock"
            });
        Albums.Add(new MusicAlbum
            {
                Id = "16",
                Name = "Gospel",
                ParentId = 14,
            });
        Albums.Add(new MusicAlbum
            {
                Id = "17",
                ParentId = 14,
                Name = "Latin Music"
            });
        Albums.Add(new MusicAlbum
            {
                Id = "18",
                ParentId = 14,
                Name = "Jazz"
            });
    }
}
<style>
    .control_wrapper {
        max-width: 500px;
        border: 1px solid #dddddd;
        border-radius: 3px;
        max-height: 470px;
        overflow: auto;
    }

    .col-lg-4.property-section.property-custom{
        border: 1px solid #dddddd;
        padding: 15px;
    }

    #selecttable {
        overflow: auto;
        max-height: 420px;
    }

    #selecttable div {
        padding-left: 0;
    }
</style>

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hXVyCtMrKkBdTNdz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Get checked nodes](./images/blazor-treeview-get-checked-nodes.png)" %}

## Single Selection with CheckBox

The Blazor TreeView component facilitates single selection of nodes with checkboxes by utilizing the [`UncheckAllAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfTreeView-1.html#Syncfusion_Blazor_Navigations_SfTreeView_1_UncheckAllAsync_System_String___) method within the [`NodeChecking`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.TreeViewEvents-1.html#Syncfusion_Blazor_Navigations_TreeViewEvents_1_NodeChecking) event. This approach programmatically unchecks all previously selected nodes when a new node is checked.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfTreeView TValue="MusicAlbum" ShowCheckBox="true" AutoCheck="true" @ref="tree">
    <TreeViewEvents TValue="MusicAlbum" NodeChecking="NodeChecking"></TreeViewEvents>
    <TreeViewFieldsSettings TValue="MusicAlbum" Id="Id" DataSource="@Albums" Text="Name" ParentID="ParentId" HasChildren="HasChild" Expanded="Expanded" IsChecked="IsChecked"></TreeViewFieldsSettings>
</SfTreeView>

@code{
    SfTreeView<MusicAlbum>? tree;
    public class MusicAlbum
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string? Name { get; set; }
        public bool Expanded { get; set; }
        public bool? IsChecked { get; set; }
        public bool HasChild { get; set; }
    }
    public void NodeChecking(NodeCheckEventArgs args)
    {
        if(args.Action=="check" && args.IsInteracted)
        {
            this.tree.UncheckAllAsync();
        }

    }
    List<MusicAlbum> Albums = new List<MusicAlbum>();
    protected override void OnInitialized()
    {
        base.OnInitialized();
        Albums.Add(new MusicAlbum
        {
            Id = 1,
            Name = "Discover Music",
            HasChild = true,
            Expanded = true
        });
        Albums.Add(new MusicAlbum
        {
            Id = 2,
            ParentId = 1,
            Name = "Hot Singles"
        });
        Albums.Add(new MusicAlbum
        {
            Id = 3,
            ParentId = 1,
            Name = "Rising Artists"
        });
        Albums.Add(new MusicAlbum
        {
            Id = 4,
            ParentId = 1,
            Name = "Live Music"
        });
        Albums.Add(new MusicAlbum
        {
            Id = 14,
            HasChild = true,
            Name = "MP3 Albums",
            Expanded = true
        
        });
        Albums.Add(new MusicAlbum
        {
            Id = 15,
            ParentId = 14,
            Name = "Rock"
        });
        Albums.Add(new MusicAlbum
        {
            Id = 16,
            Name = "Gospel",
            ParentId = 14,
        });
        Albums.Add(new MusicAlbum
        {
            Id = 17,
            ParentId = 14,
            Name = "Latin Music"
        });
        Albums.Add(new MusicAlbum
        {
            Id = 18,
            ParentId = 14,
            Name = "Jazz"
        });
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hthIiNCBAEUoTLhN?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Hide CheckBox for Parent Nodes

The Blazor TreeView component can render checkboxes before each node when [`ShowCheckBox`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfTreeView-1.html#Syncfusion_Blazor_Navigations_SfTreeView_1_ShowCheckBox) is enabled. To display checkboxes only for child nodes, the checkboxes for parent nodes can be removed by applying custom CSS.

```cshtml
@using Syncfusion.Blazor.Navigations
<SfTreeView TValue="Country" ShowCheckBox="true" CssClass="customTree">
    <TreeViewFieldsSettings TValue="Country" Id="Id" DataSource="@Countries" Text="Name" ParentID="ParentId" HasChildren="HasChild" Expanded="Expanded" Selected="IsSelected"></TreeViewFieldsSettings>
</SfTreeView>

@code{
    public class Country
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string? Name { get; set; }
        public bool HasChild { get; set; }
        public bool Expanded { get; set; }
        public bool IsSelected { get; set; }
    }
    List<Country> Countries = new List<Country>();

    protected override void OnInitialized()
    {
        base.OnInitialized();
        Countries.Add(new Country
        {
            Id = 1,
            Name = "Australia",
            HasChild = true,
            Expanded = true
        });
        Countries.Add(new Country
        {
            Id = 2,
            ParentId = 1,
            Name = "New South Wales",
            IsSelected = true
        });
        Countries.Add(new Country
        {
            Id = 3,
            ParentId = 1,
            Name = "Victoria",
            IsSelected = true
        });
        Countries.Add(new Country
        {
            Id = 4,
            ParentId = 1,
            Name = "South Australia"
        });
        Countries.Add(new Country
        {
            Id = 5,
            ParentId = 1,
            Name = "Western Australia"
        });
        Countries.Add(new Country
        {
            Id = 6,
            Name = "Brazil",
            HasChild = true
        });
        Countries.Add(new Country
        {
            Id = 7,
            ParentId = 6,
            Name = "Paraná"
        });
        Countries.Add(new Country
        {
            Id = 8,
            ParentId = 6,
            Name = "Ceará"
        });
        Countries.Add(new Country
        {
            Id = 9,
            Name = "China",
            HasChild = true
        });
        Countries.Add(new Country
        {
            Id = 10,
            ParentId = 9,
            Name = "Guangzhou"
        });
        Countries.Add(new Country
        {
            Id = 11,
            ParentId = 9,
            Name = "Shantou"
        });
    }
}

<style>
    .customTree .e-list-item.e-level-1 .e-text-content.e-icon-wrapper
    .e-checkbox-wrapper {
        display: none
    }
</style>

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/htLosZWBgaTqlQtr?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Hide CheckBox for parent nodes](./images/blazor-treeview-remove-parent-checkbox.png)" %}

## Cancel the Check Action

The Blazor TreeView component offers the ability to cancel the check action by setting the [Cancel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.NodeCheckEventArgs.html#Syncfusion_Blazor_Navigations_NodeCheckEventArgs_Cancel) argument value as true within the [NodeChecking](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.TreeViewEvents-1.html#Syncfusion_Blazor_Navigations_TreeViewEvents_1_NodeChecking) event. This will prevent the check action from occurring within the TreeView component.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfTreeView TValue="MusicAlbum" ShowCheckBox="true" AutoCheck="true">
    <TreeViewEvents TValue="MusicAlbum" NodeChecking="NodeChecking"></TreeViewEvents>
    <TreeViewFieldsSettings TValue="MusicAlbum" Id="Id" DataSource="@Albums" Text="Name" ParentID="ParentId" HasChildren="HasChild" Expanded="Expanded" IsChecked="IsChecked"></TreeViewFieldsSettings>
</SfTreeView>

@code {
    public class MusicAlbum
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string? Name { get; set; }
        public bool Expanded { get; set; }
        public bool? IsChecked { get; set; }
        public bool HasChild { get; set; }
    }
    public void NodeChecking(NodeCheckEventArgs args)
    {
        args.Cancel = true;
    }
    List<MusicAlbum> Albums = new List<MusicAlbum>();
    protected override void OnInitialized()
    {
        base.OnInitialized();
        Albums.Add(new MusicAlbum
            {
                Id = 1,
                Name = "Discover Music",
                HasChild = true,
                Expanded = true
            });
        Albums.Add(new MusicAlbum
            {
                Id = 2,
                ParentId = 1,
                Name = "Hot Singles"
            });
        Albums.Add(new MusicAlbum
            {
                Id = 3,
                ParentId = 1,
                Name = "Rising Artists"
            });
        Albums.Add(new MusicAlbum
            {
                Id = 4,
                ParentId = 1,
                Name = "Live Music"
            });
        Albums.Add(new MusicAlbum
            {
                Id = 14,
                HasChild = true,
                Name = "MP3 Albums",
                Expanded = true

            });
        Albums.Add(new MusicAlbum
            {
                Id = 15,
                ParentId = 14,
                Name = "Rock"
            });
        Albums.Add(new MusicAlbum
            {
                Id = 16,
                Name = "Gospel",
                ParentId = 14,
            });
        Albums.Add(new MusicAlbum
            {
                Id = 17,
                ParentId = 14,
                Name = "Latin Music"
            });
        Albums.Add(new MusicAlbum
            {
                Id = 18,
                ParentId = 14,
                Name = "Jazz"
            });
    }
}

```