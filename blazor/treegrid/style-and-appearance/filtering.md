---
layout: post
title: Blazor TreeGrid Filtering Customization | Syncfusion
description: Learn how to customize the Blazor TreeGrid filter UI using CSS, including filter bars, dialogs, icons, buttons, and menus.
platform: Blazor
control: TreeGrid
documentation: ug
---

# Filtering Customization in Blazor TreeGrid

Customize the appearance of filtering elements in the Blazor TreeGrid using CSS. Filtering can be enabled using `AllowFiltering="true"` on the `<SfTreeGrid>` component. Styling options are available for different parts of the filtering interface:

- **Filter bar cell and input elements:** Used to enter filter values directly in the header row.
- **Input focus styles:** Visual highlight applied when the filter input field is focused.
- **Clear and filter icons:** Icons for clearing filter values and indicating active filters in column headers.
- **Filter dialog content and footer:** Sections of the filter popup used for entering filter criteria and confirming actions.
- **Input fields and buttons within the filter dialog:** Controls used to specify filter values and apply or cancel filtering.
- **Excel-style number filter visuals:** Menu-style interface for selecting numeric filter conditions in Excel-like filtering mode.

## Customize the filter bar cell element

Use the **.e-filterbarcell** class to style the filter bar cells in the header row. Apply the following CSS to adjust appearance:

```css
.e-treegrid .e-filterbarcell {
    background-color: #045fb4;
}
```

Modify properties such as **background-color**, **padding**, and **border** to visually distinguish the filter row from header cells.

![Filter bar cell with custom background](../images/style-and-appearance/filter-bar-cell-element.webp)

## Customize the filter bar input element

Use the **.e-input** class inside **.e-filterbarcell** to style the input field in the filter bar. Apply the following CSS:

```css
.e-treegrid .e-filterbarcell .e-input-group input.e-input {
    font-family: cursive;
}
```

Modify properties such as **font-family**, **font-size**, and **border** to improve readability and match the TreeGrid design.

![Filter bar input with custom font](../images/style-and-appearance/filter-bar-input-element.webp)

## Customize the input focus

Use the **.e-input-focus** class to style the filter bar input group when focused. Apply the following CSS:

```css
.e-treegrid .e-filterbarcell .e-input-group.e-input-focus {
    background-color: #deecf9;
}
```

Modify properties such as **background-color** and **border** to enhance focus visibility and support keyboard navigation.

![Filter bar input focus](../images/style-and-appearance/filter-bar-input-element-focus.webp)

## Customize the filter bar input clear icon

Use the **.e-clear-icon::before** class to style the clear icon in the filter bar input. Apply the following CSS:

```css
.e-treegrid .e-filterbarcell .e-input-group .e-clear-icon::before {
    content: '\e72c';
}
```

Update the `content` property to use a different glyph from the icon set.

![Filter bar input with customized clear icon](../images/style-and-appearance/filter-bar-input-clear-icon.webp)

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.TreeGrid

<SfTreeGrid DataSource="@TreeGridData"
        IdMapping="TaskId"
        ParentIdMapping="ParentId"
        TreeColumnIndex="1"
        AllowFiltering="true"
        AllowPaging="true">
    <TreeGridPageSettings PageSize="8"></TreeGridPageSettings>
    <TreeGridColumns>
        <TreeGridColumn Field=@nameof(TreeData.BusinessObject.TaskId) HeaderText="Task ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="140"></TreeGridColumn>
        <TreeGridColumn Field=@nameof(TreeData.BusinessObject.TaskName) HeaderText="Task Name" Width="120"></TreeGridColumn>
        <TreeGridColumn Field=@nameof(TreeData.BusinessObject.Duration) HeaderText="Duration" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></TreeGridColumn>
        <TreeGridColumn Field=@nameof(TreeData.BusinessObject.Progress) HeaderText="Progress" Width="100"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

<style>
    .e-treegrid .e-filterbarcell {
        background-color: #045fb4;
        color: #ffffff;
    }

    .e-treegrid .e-filterbarcell .e-input-group input.e-input {
        font-family: cursive;
    }

    .e-treegrid .e-filterbarcell .e-input-group.e-input-focus {
        background-color: #deecf9;
    }

    .e-treegrid .e-filterbarcell .e-input-group .e-clear-icon::before {
        font-family: 'e-icons' !important;
        font-weight: normal;
        content: '\e72c';
    }

    /* Optional: highlight the focused filter cell for keyboard users */
    .e-treegrid .e-filterbarcell:focus-visible {
        outline: 2px solid #005a9e;
        outline-offset: -2px;
    }
</style>

@code {
    private List<TreeData.BusinessObject> TreeGridData { get; set; }

    protected override void OnInitialized()
    {
        TreeGridData = TreeData.GetSelfDataSource().ToList();
    }
}

{% endhighlight %}

{% highlight c# tabtitle="TreeData.cs" %}

namespace TreeGridComponent.Data
{
    public class TreeData
    {
        public class BusinessObject
        {
            public int TaskId { get; set; }
            public string TaskName { get; set; }
            public int? Duration { get; set; }
            public int? Progress { get; set; }
            public string Priority { get; set; }
            public int? ParentId { get; set; }
        }

        internal static List<BusinessObject> GetSelfDataSource()
        {
            List<BusinessObject> BusinessObjectCollection = new List<BusinessObject>();
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 1, TaskName = "Parent Task 1", Duration = 10, Progress = 70, Priority = "Critical", ParentId = null });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 2, TaskName = "Child task 1", Duration = 8, Progress = 80, Priority = "Low", ParentId = 1 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 3, TaskName = "Child Task 2", Duration = 5, Progress = 65, Priority = "Critical", ParentId = 2 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 4, TaskName = "Child task 3", Duration = 6, Progress = 77, Priority = "High", ParentId = 3 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 5, TaskName = "Parent Task 2", Duration = 10, Progress = 70, Priority = "Critical", ParentId = null });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 6, TaskName = "Child task 1", Duration = 4, Progress = 80, Priority = "Critical", ParentId = 5 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 7, TaskName = "Child Task 2", Duration = 5, Progress = 65, Priority = "Low", ParentId = 5 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 8, TaskName = "Child task 3", Duration = 6, Progress = 77, Priority = "High", ParentId = 5 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 9, TaskName = "Child task 4", Duration = 6, Progress = 77, Priority = "Low", ParentId = 5 });
            return BusinessObjectCollection;
        }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rDVntwjvfXOiyGVq?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Customize the filtering icon in the header

Use the **.e-icon-filter::before** class to style the filter icon in column headers. Apply the following CSS:

```css
.e-treegrid .e-icon-filter::before {
    content: '\e81e';
}
```

Update the `content` value to match the desired icon glyph.

![Header filter icon](../images/style-and-appearance/grid-filtering-icon.webp)

## Customize the filter dialog content

Use the **.e-filter-popup .e-dlg-content** class to style the content area of the filter dialog. Apply the following CSS:

```css
.e-treegrid .e-filter-popup .e-dlg-content {
    background-color: #deecf9;
}
```

Modify properties such as **background-color**, **padding**, and **border** to match the application theme.

![Filter dialog content](../images/style-and-appearance/filter-dialog-content.webp)

## Customize the filter dialog footer

Use the **.e-filter-popup .e-footer-content** class to style the footer section of the filter dialog. Apply the following CSS:

```css
.e-treegrid .e-filter-popup .e-footer-content {
    background-color: #deecf9;
}
```

Modify properties such as **background-color**, **text-align**, and **border** to align with the layout design.

![Filter dialog footer](../images/style-and-appearance/filter-dialog-footer.webp)

## Customize the filter dialog input field

Use the **.e-input** class inside **.e-filter-popup** to style input fields in the filter dialog. Apply the following CSS:

```css
.e-treegrid .e-filter-popup .e-input-group input.e-input {
    font-family: cursive;
}
```

Modify properties such as **font-family**, **color**, and **border** to improve clarity and consistency.

![Filter dialog input](../images/style-and-appearance/filter-dialog-input-element.webp)

## Customize the filter dialog button element

Use the **.e-filter-popup .e-btn** class to style buttons inside the filter dialog. Apply the following CSS:

```css
.e-treegrid .e-filter-popup .e-btn {
    font-family: cursive;
}
```

Modify properties such as **font-family**, **background-color**, and **border** to match the design.

![Filter dialog buttons](../images/style-and-appearance/filter-dialog-button-element.webp)

## Customize the Excel-style filter menu

Use the **.e-contextmenu-container ul** class inside **.e-filter-popup** to style the filter list in the Excel-style filter dialog. Apply the following CSS:

```css
.e-treegrid .e-filter-popup .e-contextmenu-container ul {
    background-color: #deecf9;
}
```

Modify properties such as **background-color**, **color**, and **text-align** to match the required design.

![Excel-style filter menu](../images/style-and-appearance/excel-filter-dialog-number-filters-element.webp)

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.TreeGrid

<SfTreeGrid DataSource="@TreeGridData"
        IdMapping="TaskId"
        ParentIdMapping="ParentId"
        TreeColumnIndex="1"
        AllowFiltering="true"
        AllowPaging="true">
    <TreeGridPageSettings PageSize="8"></TreeGridPageSettings>
    <TreeGridFilterSettings Type="FilterType.Menu"></TreeGridFilterSettings>
    <TreeGridColumns>
        <TreeGridColumn Field=@nameof(TreeData.BusinessObject.TaskId) HeaderText="Task ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="140"></TreeGridColumn>
        <TreeGridColumn Field=@nameof(TreeData.BusinessObject.TaskName) HeaderText="Task Name" Width="120"></TreeGridColumn>
        <TreeGridColumn Field=@nameof(TreeData.BusinessObject.Duration) HeaderText="Duration" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></TreeGridColumn>
        <TreeGridColumn Field=@nameof(TreeData.BusinessObject.Progress) HeaderText="Progress" Width="100"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

<style>
    .e-treegrid .e-icon-filter::before {
        font-family: 'e-icons' !important;
        font-weight: normal;
        content: '\e81e';
    }

    .e-treegrid .e-filter-popup .e-dlg-content,
    .e-treegrid .e-filter-popup .e-footer-content,
    .e-treegrid .e-filter-popup .e-contextmenu-container ul {
        background-color: #deecf9;
    }

    .e-treegrid .e-filter-popup .e-input-group input.e-input,
    .e-treegrid .e-filter-popup .e-btn {
        font-family: cursive;
    }

    /* Optional: focus outline inside the filter dialog for keyboard users */
    .e-treegrid .e-filter-popup .e-input-group input.e-input:focus-visible,
    .e-treegrid .e-filter-popup .e-btn:focus-visible {
        outline: 2px solid #005a9e;
        outline-offset: 2px;
    }
</style>

@code {
    private List<TreeData.BusinessObject> TreeGridData { get; set; }

    protected override void OnInitialized()
    {
        TreeGridData = TreeData.GetSelfDataSource().ToList();
    }
}

{% endhighlight %}
{% highlight c# tabtitle="TreeData.cs" %}

namespace TreeGridComponent.Data
{
    public class TreeData
    {
        public class BusinessObject
        {
            public int TaskId { get; set; }
            public string TaskName { get; set; }
            public int? Duration { get; set; }
            public int? Progress { get; set; }
            public string Priority { get; set; }
            public int? ParentId { get; set; }
        }

        internal static List<BusinessObject> GetSelfDataSource()
        {
            List<BusinessObject> BusinessObjectCollection = new List<BusinessObject>();
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 1, TaskName = "Parent Task 1", Duration = 10, Progress = 70, Priority = "Critical", ParentId = null });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 2, TaskName = "Child task 1", Duration = 8, Progress = 80, Priority = "Low", ParentId = 1 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 3, TaskName = "Child Task 2", Duration = 5, Progress = 65, Priority = "Critical", ParentId = 2 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 4, TaskName = "Child task 3", Duration = 6, Progress = 77, Priority = "High", ParentId = 3 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 5, TaskName = "Parent Task 2", Duration = 10, Progress = 70, Priority = "Critical", ParentId = null });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 6, TaskName = "Child task 1", Duration = 4, Progress = 80, Priority = "Critical", ParentId = 5 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 7, TaskName = "Child Task 2", Duration = 5, Progress = 65, Priority = "Low", ParentId = 5 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 8, TaskName = "Child task 3", Duration = 6, Progress = 77, Priority = "High", ParentId = 5 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 9, TaskName = "Child task 4", Duration = 6, Progress = 77, Priority = "Low", ParentId = 5 });
            return BusinessObjectCollection;
        }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXVdjwNPJjEaBEuc?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}