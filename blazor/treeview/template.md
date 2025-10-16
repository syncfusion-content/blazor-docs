---
layout: post
title: Template in Blazor TreeView Component | Syncfusion
description: Checkout and learn here all about Template in Syncfusion Blazor TreeView component and much more details.
platform: Blazor
control: TreeView
documentation: ug
---

# Template in Blazor TreeView Component

The Blazor TreeView component allows to customize the look of TreeView nodes using the `NodeTemplate` property. The [`NodeTemplate`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.TreeViewTemplates-1.html#Syncfusion_Blazor_Navigations_TreeViewTemplates_1_NodeTemplate) tag is nested inside the TreeViewTemplates tag, where the custom structure for TreeView can be defined. Inside the NodeTemplate tag, a generic type context property is used to access the tree node details.

To customize Blazor TreeView items easily using a template and the [`CssClass`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfTreeView-1.html#Syncfusion_Blazor_Navigations_SfTreeView_1_CssClass) property, refer to this video:

{% youtube
"youtube:https://www.youtube.com/watch?v=LQlFt9d5E34" %}

In the following sample, employee information such as employee photo, name, and designation have been included using the `NodeTemplate` property.

```cshtml
@using Syncfusion.Blazor.Navigations
@inject Microsoft.AspNetCore.Components.NavigationManager UriHelper

<SfTreeView TValue="EmployeeDetails" CssClass="custom">
    <TreeViewFieldsSettings TValue="EmployeeDetails" Id="EmployeeId" Text="EmployeeName" DataSource="@Employee" Expanded="Expanded" HasChildren="HasChild" Selected="Selected" ParentID="ParentId"></TreeViewFieldsSettings>
    <TreeViewTemplates TValue="EmployeeDetails">
        <NodeTemplate>
            @{
                var employee = ((context as EmployeeDetails));
                <img class="eimage" src="@($"https://ej2.syncfusion.com/demos/src/treeview/images/employees/{employee.Image}.png")" alt="@employee.Image" />
                <div class="ename">@((@context as EmployeeDetails).EmployeeName)</div>
                <div class="ejob">@((@context as EmployeeDetails).Designation)</div>
            }
        </NodeTemplate>
    </TreeViewTemplates>
</SfTreeView>

@code
{
    public class EmployeeDetails
    {
        public string? EmployeeName { get; set; }
        public int EmployeeId { get; set; }
        public int? ParentId { get; set; }
        public bool HasChild { get; set; }
        public bool Expanded { get; set; }
        public bool Selected { get; set; }
        public string? Image { get; set; }
        public string? Designation { get; set; }
    }

    List<EmployeeDetails> Employee = new List<EmployeeDetails>();

    protected override void OnInitialized()
    {
        base.OnInitialized();

        Employee.Add(new EmployeeDetails
        {
            EmployeeId = 1,
            EmployeeName = "Steven Buchanan",
            HasChild = true,
            Expanded = true,
            Image = "10",
            Designation = "CEO"
        });
        Employee.Add(new EmployeeDetails
        {
            EmployeeId = 2,
            ParentId = 1,
            EmployeeName = "Laura Callahan",
            Image = "2",
            Designation = "Product Manager",
            HasChild = true
        });
        Employee.Add(new EmployeeDetails
        {
            EmployeeId = 3,
            ParentId = 2,
            EmployeeName = "Andrew Fuller",
            Image = "7",
            Designation = "Team Lead",
            HasChild = true
        });
        Employee.Add(new EmployeeDetails
        {
            EmployeeId = 4,
            ParentId = 3,
            EmployeeName = "Anne Dodsworth",
            Image = "1",
            Designation = "Developer"
        });
        Employee.Add(new EmployeeDetails
        {
            EmployeeId = 5,
            ParentId = 1,
            EmployeeName = "Nancy Davolio",
            HasChild = true,
            Image = "4",
            Designation = "Product Manager"
        });
        Employee.Add(new EmployeeDetails
        {
            EmployeeId = 6,
            ParentId = 5,
            EmployeeName = "Michael Suyama",
            Image = "9",
            Designation = "Team Lead",
            HasChild = true
        });
        Employee.Add(new EmployeeDetails
        {
            EmployeeId = 7,
            ParentId = 6,
            EmployeeName = "Robert King",
            Image = "8",
            Designation = "Developer"
        });
        Employee.Add(new EmployeeDetails
        {
            EmployeeId = 8,
            ParentId = 7,
            EmployeeName = "Margaret Peacock",
            Image = "6",
            Designation = "Developer"
        });
        Employee.Add(new EmployeeDetails
        {
            EmployeeId = 9,
            ParentId = 1,
            EmployeeName = "Janet Leverling",
            Image = "3",
            Designation = "HR"
        });
    }
}
<style>
    .custom.e-treeview .e-fullrow {
        height: 72px;
    }

    .custom.e-treeview .e-list-text {
        line-height: normal;
    }

    .eimage {
        float: left;
        padding: 11px 16px 11px 0;
        height: 48px;
        width: 48px;
        box-sizing: content-box;
    }

    .ename {
        font-size: 16px;
        padding: 14px 0 0;
    }

    .ejob {
        font-size: 14px;
        opacity: .87;
    }
</style>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BZrICtCABhRfFWww?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor TreeView with Template](./images/blazor-treeview-template.png)

## Apply Template to Header

The Blazor TreeView component provides the ability to customize the appearance of its nodes through the use of the [`NodeTemplate`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.TreeViewTemplates-1.html#Syncfusion_Blazor_Navigations_TreeViewTemplates_1_NodeTemplate) property. This property is nested within the [`TreeViewTemplates`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.TreeViewTemplates-1.html) tag, which defines the custom structure for the TreeView. However, in this section this template is only applied to parent nodes.

```cshtml
@using Syncfusion.Blazor.Navigations

<div class="control-section">
    <div class="control_wrapper">
        @*Initialize the TreeView component*@
        <SfTreeView TValue="TreeData">
            <TreeViewFieldsSettings Id="Id" Text="Name" ParentID="Pid" HasChildren="HasChild" Selected="Selected" Expanded="Expanded" DataSource="@LocalData"></TreeViewFieldsSettings>
            <TreeViewTemplates TValue="TreeData">
                <NodeTemplate>
                    <div>
                        <div class="treeviewdiv">
                            <div class="nodetext">
                                <span class="treeName">@((context as TreeData).Name)</span>
                            </div>
                            @{
                                @if (((context as TreeData).HasChild))
                                {
                                    <div class="nodebadge">
                                        <span class="treeCount e-badge e-badge-primary">@((context as TreeData).Count)</span>
                                    </div>
                                }
                            }
                        </div>
                    </div>
                </NodeTemplate>
            </TreeViewTemplates>
        </SfTreeView>
    </div>
</div>
@code {
    // Specifies the DataSource value for TreeView component.
    List<TreeData> LocalData = new List<TreeData>();
    protected override void OnInitialized()
    {
        base.OnInitialized();
        LocalData.Add(new TreeData
            {
                Id = "1",
                Name = "Favorites",
                HasChild = true,
                Count = 14
            });
        LocalData.Add(new TreeData
            {
                Id = "2",
                Pid = "1",
                Name = "Sales Reports",
            });
        LocalData.Add(new TreeData
            {
                Id = "3",
                Pid = "1",
                Name = "Sent Items"
            });
        LocalData.Add(new TreeData
            {
                Id = "4",
                Pid = "1",
                Name = "Marketing Reports",
            });
        LocalData.Add(new TreeData
            {
                Id = "5",
                HasChild = true,
                Name = "My Folder",
                Expanded = true,
                Count = 10
            });
        LocalData.Add(new TreeData
            {
                Id = "6",
                Pid = "5",
                Name = "Inbox",
                Selected = true,
            });
        LocalData.Add(new TreeData
            {
                Id = "7",
                Pid = "5",
                Name = "Drafts",
            });
        LocalData.Add(new TreeData
            {
                Id = "8",
                Pid = "5",
                Name = "Deleted Items"
            });
        LocalData.Add(new TreeData
            {
                Id = "9",
                Pid = "5",
                Name = "Sent Items"
            });
        LocalData.Add(new TreeData
            {
                Id = "10",
                Pid = "5",
                Name = "Sales Reports",
            });
        LocalData.Add(new TreeData
            {
                Id = "11",
                Pid = "5",
                Name = "Marketing Reports",
            });
        LocalData.Add(new TreeData
            {
                Id = "12",
                Pid = "5",
                Name = "Outbox"
            });
    }
    class TreeData
    {
        public string? Id { get; set; }
        public string? Pid { get; set; }
        public string? Name { get; set; }
        public bool HasChild { get; set; }
        public bool Expanded { get; set; }
        public int Count { get; set; }
        public bool Selected { get; set; }
    }
}
<style>
    /* Sample specific styles */
    .control_wrapper {
        max-width: 320px;
        margin: auto;
        border: 1px solid #dddddd;
        border-radius: 3px;
        max-height: 420px;
        overflow: auto;
    }
    /* Specifies the styles for custom generated elements in the TreeView component */
    .e-treeview .e-list-text {
        width: 99%;
    }

    .treeCount.e-badge {
        padding: 0.4em;
        vertical-align: text-bottom;
    }

    .nodetext {
        float: left;
    }

    .nodebadge {
        float: right;
        margin-right: 5px
    }
</style>

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/htheCZiqVVQMJDpI?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor TreeView with Header Template](./images/blazor-treeview-template-header.png)
