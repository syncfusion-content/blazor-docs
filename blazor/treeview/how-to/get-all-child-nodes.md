---
layout: post
title: Get all child nodes through parentID in Blazor TreeView | Syncfusion
description: Learn here more about how to get all child nodes through parentID in Syncfusion Blazor TreeView component and more.
platform: Blazor
control: TreeView
documentation: ug
---

# Get all child nodes through parentID in Blazor TreeView Component

This section shows how to get the child nodes from corresponding Parent ID. Using the [`GetTreeData`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfTreeView-1.html#Syncfusion_Blazor_Navigations_SfTreeView_1_GetTreeData_System_String_) method, the node details of the TreeView is achieved.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Inputs
@using Newtonsoft.Json;

<SfTreeView TValue="TreeData" @ref="tree">
    <TreeViewFieldsSettings DataSource="@TreeDataSource" Id="Code" Text="Name" Selected="Selected" Expanded="Expanded" Child="Child"></TreeViewFieldsSettings>
</SfTreeView>
<SfMaskedTextBox @ref="mask" Placeholder="Enter the ID (ex: NA)" FloatLabelType="@FloatLabelType.Always" Width="250"></SfMaskedTextBox>
<button class="e-btn e-info" @onclick="@GetDetails">Submit</button>
<br />
@if (TreeNodeDetails != null)
{
    @TreeNodeDetails
}

@code{

    List<TreeData> TreeDataSource = new List<TreeData>();
    SfTreeView<TreeData> tree;
    SfMaskedTextBox mask;
    string TreeNodeDetails = null;

    async void GetDetails()
    {
        String EnteredText = mask.Value.ToString();
        List<TreeData> treeData = tree.GetTreeData(EnteredText);
        TreeNodeDetails = $"NodeData: {JsonConvert.SerializeObject(treeData[0])}";
        StateHasChanged();

    }
    protected override void OnInitialized()
    {
        base.OnInitialized();

        TreeDataSource.Add(new TreeData
        {
            Code = "NA",
            Name = "North America",
            Child = new List<TreeData>()
            {
                new TreeData { Code = "USA", Name = "United States of America", Selected = true },
                new TreeData { Code = "CUB", Name = "Cuba" },
                new TreeData { Code = "MEX", Name = "Mexico" },
            },
        });
        TreeDataSource.Add(new TreeData
        {
            Code = "AF",
            Name = "Africa",
            Child = new List<TreeData>()
            {
                new TreeData { Code = "NGA", Name = "Nygeria" },
                new TreeData { Code = "EGY", Name = "Egypt" },
                new TreeData { Code = "ZAF", Name = "South Africa" },
            },
        });
        TreeDataSource.Add(new TreeData
        {
            Code = "AS",
            Name = "Asia",
            Child = new List<TreeData>()
            {
                new TreeData { Code = "CHN", Name = "China" },
                new TreeData { Code = "IND", Name = "India" },
                new TreeData { Code = "JPN", Name = "Japan" },
            },
        });
        TreeDataSource.Add(new TreeData
        {
            Code = "EU",
            Name = "Europe",
            Child = new List<TreeData>()
            {
                new TreeData { Code = "DNK", Name = "Denmark" },
                new TreeData { Code = "AUT", Name = "Austria" },
                new TreeData { Code = "FIN", Name = "Finland" },
            },
        });
        TreeDataSource.Add(new TreeData
        {
            Code = "SA",
            Name = "South America",
            Child = new List<TreeData>()
            {
                new TreeData { Code = "BRA", Name = "Brazil" },
                new TreeData { Code = "COL", Name = "Colombia" },
                new TreeData { Code = "ARG", Name = "Argentina" },
            },
        });
        TreeDataSource.Add(new TreeData
        {
            Code = "OC",
            Name = "Oceania",
            Child = new List<TreeData>()
            {
                new TreeData { Code = "AUS", Name = "Australia" },
                new TreeData { Code = "NZL", Name = "Newzealand" },
                new TreeData { Code = "WSM", Name = "Samoa" },
            },
        });
        TreeDataSource.Add(new TreeData
        {
            Code = "AN",
            Name = "Antartica",
            Child = new List<TreeData>()
            {
                new TreeData { Code = "BVT", Name = "Bouvet Island" },
                new TreeData { Code = "ATF", Name = "French Southern Lands" },
            },
        });
    }

    public class TreeData
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public bool Expanded { get; set; }
        public bool Selected { get; set; }
        public List<TreeData> Child;
    }
}
```