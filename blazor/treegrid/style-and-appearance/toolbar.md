---
layout: post
title: Toolbar styling in Blazor TreeGrid using CSS | Syncfusion
description: Learn how to customize the Syncfusion Blazor TreeGrid toolbar using CSS, including styling the toolbar container and buttons with CSS isolation tips.
platform: Blazor
control: TreeGrid
documentation: ug
---

# Toolbar customization in Syncfusion Blazor TreeGrid

The appearance of toolbar elements in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeGrid can be customized using CSS. Styling options are available for different parts of the toolbar interface:

- **Toolbar root container:** The outer wrapper that contains all toolbar items.
- **Toolbar buttons:**  Shows interactive elements used for actions such as Add, Edit, Delete, Update, and Cancel.

## Customize the toolbar root element

The **.e-toolbar-items** class styles the toolbar root container in the Blazor TreeGrid. This container holds all toolbar items and can be styled using CSS:

```css
.e-treegrid .e-toolbar .e-toolbar-items {
     background-color: #deecf9;
 }
```
Properties such as **background-color**, **padding**, **border**, and **box-shadow** can be modified to suit the layout design.

![Grid toolbar root element](../images/style-and-appearance/toolbar1.webp)

## Customize the toolbar button elements

The **.e-btn** class inside **.e-toolbar** defines the appearance of toolbar buttons in the Blazor TreeGrid. Apply CSS to customize their styling:
```css
.e-treegrid .e-toolbar .e-btn {
    background-color: #deecf9;
 }
```
Properties such as **background-color**, **color**, **border**, **font-size**, and **padding** can be adjusted to align with the design. Ensure that customized colors meet WCAG contrast guidelines and that focus indicators remain visible for keyboard navigation.

![Grid toolbar button element](../images/style-and-appearance/toolbar2.webp)

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.TreeGrid;

<SfTreeGrid DataSource="@TreeData" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1" Toolbar="@(new List<string> { "Add", "Edit" , "ExpandAll", "CollaspeAll" })">
    <TreeGridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Row"></TreeGridEditSettings>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="80" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="160"></TreeGridColumn>
        <TreeGridColumn Field="StartDate" HeaderText="Start Date" Format="d" Type="Syncfusion.Blazor.Grids.ColumnType.DateOnly" Width="152" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="StartTime" HeaderText="Start Time" Type="Syncfusion.Blazor.Grids.ColumnType.TimeOnly" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

<style>
    .e-treegrid .e-toolbar .e-toolbar-items {
         background-color: #deecf9;
     }
    .e-treegrid .e-toolbar .e-btn {
             background-color: #deecf9;
     }
</style>

@code {
    public class BusinessObject
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateOnly? StartDate { get; set; }
        public TimeOnly? StartTime { get; set; }
        public int Duration { get; set; }
        public int Progress { get; set; }
        public string Priority { get; set; }
        public int? ParentId { get; set; }
    }

    public List<BusinessObject> TreeData = new List<BusinessObject>();

    protected override void OnInitialized()
    {
        TreeData.Add(new BusinessObject() { TaskId = 1, TaskName = "Parent Task 1", StartDate = new DateOnly(2021, 03, 02), StartTime = new TimeOnly(10, 00, 00), Duration = 10, Progress = 70, ParentId = null, Priority = "High" });
        TreeData.Add(new BusinessObject() { TaskId = 2, TaskName = "Child task 1", StartDate = new DateOnly(2021, 03, 04), StartTime = new TimeOnly(11, 30, 00), Duration = 4, Progress = 80, ParentId = 1, Priority = "Normal" });
        TreeData.Add(new BusinessObject() { TaskId = 3, TaskName = "Child Task 2", StartDate = new DateOnly(2021, 03, 06), StartTime = new TimeOnly(12, 00, 00), Duration = 5, Progress = 65, ParentId = 1, Priority = "Critical" });
        TreeData.Add(new BusinessObject() { TaskId = 4, TaskName = "Parent Task 2", StartDate = new DateOnly(2021, 03, 08), StartTime = new TimeOnly(13, 30, 00), Duration = 6, Progress = 77, ParentId = null, Priority = "Low" });
        TreeData.Add(new BusinessObject() { TaskId = 5, TaskName = "Child Task 5", StartDate = new DateOnly(2021, 07, 10), StartTime = new TimeOnly(14, 00, 00), Duration = 9, Progress = 25, ParentId = 4, Priority = "Normal" });
        TreeData.Add(new BusinessObject() { TaskId = 6, TaskName = "Child Task 6", StartDate = new DateOnly(2021, 10, 12), StartTime = new TimeOnly(16, 00, 00), Duration = 9, Progress = 7, ParentId = 5, Priority = "Normal" });
        TreeData.Add(new BusinessObject() { TaskId = 7, TaskName = "Parent Task 3", StartDate = new DateOnly(2021, 10, 14), StartTime = new TimeOnly(17, 30, 00), Duration = 4, Progress = 45, ParentId = null, Priority = "High" });
        TreeData.Add(new BusinessObject() { TaskId = 8, TaskName = "Child Task 7", StartDate = new DateOnly(2021, 10, 16), StartTime = new TimeOnly(18, 00, 00), Duration = 3, Progress = 38, ParentId = 7, Priority = "Critical" });
        TreeData.Add(new BusinessObject() { TaskId = 9, TaskName = "Child Task 8", StartDate = new DateOnly(2021, 02, 18), StartTime = new TimeOnly(19, 30, 00), Duration = 7, Progress = 70, ParentId = 7, Priority = "Low" });
    }
}


{% endhighlight %}

{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNBdXfBBzwxxUVoB?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}