---
layout: post
title: Column Resizing in Blazor Tree Grid Component | Syncfusion
description: Checkout and learn here all about column resizing in the Syncfusion Blazor Tree Grid component and much more details.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Column Resizing in Blazor Tree Grid

Column width can be resized by clicking and dragging the right edge of the column header. While dragging, the width of the respective column will be resized immediately. Each column can be auto resized by double-clicking the right edge of the column header to fit the width of that column based on the widest cell content. To enable column resize, set the [AllowResizing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_AllowResizing) property to true.

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data;
@using Syncfusion.Blazor.TreeGrid;

<SfTreeGrid IdMapping="TaskId" ParentIdMapping="ParentId"  AllowResizing="true" DataSource="@TreeGridData" TreeColumnIndex="1">
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="80" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="180"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="80"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="80"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code{
    public List<TreeData.BusinessObject> TreeGridData { get; set; }
    protected override void OnInitialized()
    {
        this.TreeGridData = TreeData.GetSelfDataSource().ToList();
    }
}

{% endhighlight %}

{% highlight c# %}

namespace TreeGridComponent.Data {

public class TreeData
    {
        public class BusinessObject
        {
            public int TaskId { get; set;}
            public string TaskName { get; set;}
            public int? Duration { get; set;}
            public int? Progress { get; set;}
            public int? ParentId { get; set;}
        }

        public static List<BusinessObject> GetSelfDataSource()
        {
            List<BusinessObject> BusinessObjectCollection = new List<BusinessObject>();
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 1,TaskName = "Parent Task 1",Duration = 10,Progress = 70,ParentId = null });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 2,TaskName = "Child task 1",Duration = 4,Progress = 80,ParentId = 1 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 3,TaskName = "Child Task 2",Duration = 5,Progress = 65,ParentId = 2 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 4,TaskName = "Child task 3",Duration = 6,Progress = 77,ParentId = 3 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 5,TaskName = "Parent Task 2",Duration = 10,Progress = 70,ParentId = null});
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 6,TaskName = "Child task 1",Duration = 4,Progress = 80,ParentId = 5});
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 7,TaskName = "Child Task 2",Duration = 5,Progress = 65,ParentId = 5});
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 8,TaskName = "Child task 3",Duration = 6,Progress = 77,ParentId = 5});
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 9,TaskName = "Child task 4",Duration = 6,Progress = 77,ParentId = 5});
            return BusinessObjectCollection;
        }
    }
}

{% endhighlight %}

{% endtabs %}

![Resizing Column in Blazor Tree Grid](../images/blazor-treegrid-column-resizing.gif)

N> You can disable resizing for a particular column by setting the `AllowResizing` property of the [TreeGridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridColumn.html) component to false.
<br/> In RTL mode, you can click and drag the left edge of the header cell to resize the column.

## Min and max width

Column resize can be restricted between minimum and maximum width by defining the [MinWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridColumn_MinWidth) and [MaxWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridColumn_MaxWidth) properties in [TreeGridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridColumn.html) component.

In the following sample, minimum and maximum width are defined for **TaskName** and **Duration** columns.

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data;
@using Syncfusion.Blazor.TreeGrid;

<SfTreeGrid IdMapping="TaskId" ParentIdMapping="ParentId"  AllowResizing="true" DataSource="@TreeGridData" TreeColumnIndex="1">
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="80" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" MinWidth="170" MaxWidth="250" Width="180"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" MinWidth="50" MaxWidth="150" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="80"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="80"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code{
    public List<TreeData.BusinessObject> TreeGridData { get; set; }
    protected override void OnInitialized()
    {
        this.TreeGridData = TreeData.GetSelfDataSource().ToList();
    }
}

{% endhighlight %}

{% highlight c# %}

namespace TreeGridComponent.Data {

public class TreeData
    {
        public class BusinessObject
        {
            public int TaskId { get; set;}
            public string TaskName { get; set;}
            public int? Duration { get; set;}
            public int? Progress { get; set;}
            public int? ParentId { get; set;}
        }

        public static List<BusinessObject> GetSelfDataSource()
        {
            List<BusinessObject> BusinessObjectCollection = new List<BusinessObject>();
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 1,TaskName = "Parent Task 1",Duration = 10,Progress = 70,ParentId = null });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 2,TaskName = "Child task 1",Duration = 4,Progress = 80,ParentId = 1 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 3,TaskName = "Child Task 2",Duration = 5,Progress = 65,ParentId = 2 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 4,TaskName = "Child task 3",Duration = 6,Progress = 77,ParentId = 3 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 5,TaskName = "Parent Task 2",Duration = 10,Progress = 70,ParentId = null});
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 6,TaskName = "Child task 1",Duration = 4,Progress = 80,ParentId = 5});
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 7,TaskName = "Child Task 2",Duration = 5,Progress = 65,ParentId = 5});
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 8,TaskName = "Child task 3",Duration = 6,Progress = 77,ParentId = 5});
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 9,TaskName = "Child task 4",Duration = 6,Progress = 77,ParentId = 5});
            return BusinessObjectCollection;
        }
    }
}

{% endhighlight %}

{% endtabs %}

## Resize stacked column

Stacked columns can be resized by clicking and dragging the right edge of the stacked column header. While dragging, the width of the respective child columns will be resized at the same time. You can disable resize for any particular stacked column by setting [AllowResizing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_AllowResizing) property of the [TreeGridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridColumn.html)as **false** to its columns.

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data;
@using Syncfusion.Blazor.TreeGrid;

<SfTreeGrid IdMapping="ID" ParentIdMapping="ParentID" DataSource="@TreeGridData" TreeColumnIndex="1" AllowResizing="true">
    <TreeGridColumns>
        <TreeGridColumn HeaderText="Order Details" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right">
            <TreeGridColumns>
                <TreeGridColumn Field="ID" Width="110" HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
                <TreeGridColumn Field="Name" Width="220" HeaderText="Order Name" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Left"></TreeGridColumn>
                <TreeGridColumn Field="OrderDate" Width="120" HeaderText="Order Date" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Format="yMd" Type="Syncfusion.Blazor.Grids.ColumnType.Date"></TreeGridColumn>
            </TreeGridColumns>
        </TreeGridColumn>
        <TreeGridColumn HeaderText="Shipment Details" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Center">
            <TreeGridColumns>
                <TreeGridColumn Field="ShipmentCategory" Width="170" HeaderText="Shipment Category"></TreeGridColumn>
                <TreeGridColumn Field="Units" Width="220" HeaderText="Units" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Left"></TreeGridColumn>
                <TreeGridColumn Field="ShippedDate" Width="120" HeaderText="Shipment Date" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Format="yMd" Type="Syncfusion.Blazor.Grids.ColumnType.Date"></TreeGridColumn>
            </TreeGridColumns>
        </TreeGridColumn>
        <TreeGridColumn HeaderText="Price Details" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Center">
            <TreeGridColumns>
                <TreeGridColumn Field="UnitPrice" Width="180" HeaderText="Price per unit" Format="C2" Type="Syncfusion.Blazor.Grids.ColumnType.Number" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
                <TreeGridColumn Field="Price" Width="220" HeaderText="Price" Format="C" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Left"></TreeGridColumn>
                <TreeGridColumn Field="OrderDate" Width="120" HeaderText="Total Price" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Type="Syncfusion.Blazor.Grids.ColumnType.Number"></TreeGridColumn>
            </TreeGridColumns>
        </TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code{
    public List<ShipmentData> TreeGridData { get; set; }
    protected override void OnInitialized()
    {
        this.TreeGridData = ShipmentData.GetShipmentData().ToList();
    }
}

{% endhighlight %}

{% highlight c# %}

namespace TreeGridComponent.Data {

public class ShipmentData
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int Units { get; set; }
    public string Category { get; set; }
    public int UnitPrice { get; set; }
    public int Price { get; set; }
    public int? ParentID { get; set; }
    public string ShipmentCategory { get; set; }
    public DateTime ShippedDate { get; set; }
    public DateTime OrderDate { get; set; }
    public List<ShipmentData> Children { get; set; }

    public static List<ShipmentData> GetShipmentData()
    {
        List<ShipmentData> DataCollection = new List<ShipmentData>() {

        new ShipmentData() { ID = 1,Name = "Order 1",Category = "Seafood",Units = 1395,UnitPrice = 47,Price = 65565,ParentID = null,OrderDate = new DateTime(2017, 3, 2),ShippedDate = new DateTime(2017, 9, 2),ShipmentCategory = "Seafood"},
        new ShipmentData() { ID = 11,Name = "Mackerel",Category = "Frozen Seafood",Units = 235,UnitPrice = 12,Price = 2820,ParentID = 1,OrderDate = new DateTime(2017, 3, 3),ShippedDate = new DateTime(2017, 10, 3),ShipmentCategory = "Frozen Seafood"},
        new ShipmentData() { ID = 12,Name = "Yellowfin Tuna",Category = "Frozen Seafood",Units = 324,UnitPrice = 8,Price = 2592,ParentID = 1,OrderDate = new DateTime(2017, 3, 5),ShippedDate = new DateTime(2017, 10, 5),ShipmentCategory = "Frozen Seafood"},
        new ShipmentData() { ID = 13,Name = "Herrings",Category = "Frozen Seafood",Units = 488,UnitPrice = 11,Price = 5368,ParentID = 1,OrderDate = new DateTime(2017, 8, 5),ShippedDate = new DateTime(2017, 5, 15),ShipmentCategory = "Frozen Seafood"},
        new ShipmentData() { ID = 14,Name = "Preserved Olives",Category = "Edible",Units = 125,UnitPrice = 9,Price = 1125,ParentID = 1,OrderDate = new DateTime(2017, 6, 10),ShippedDate = new DateTime(2017, 6, 17),ShipmentCategory = "Edible"},
        new ShipmentData() { ID = 15,Name = " Sweet corn Frozen ",Category = "Edible",Units = 223,UnitPrice = 7,Price = 1561,ParentID = 1,OrderDate = new DateTime(2017, 7, 12),ShippedDate = new DateTime(2017, 7, 19),ShipmentCategory = "Edible"},
        new ShipmentData() { ID = 2,Name = "Order 2",Category = "Products",Units = 1944,UnitPrice = 58,Price = 21233,ParentID = null,OrderDate = new DateTime(2017, 1, 10),ShippedDate = new DateTime(2017, 1, 16),ShipmentCategory = "Seafood",Children = new List<ShipmentData>()},
        new ShipmentData() { ID = 21,Name = "Tilapias",Category = "Frozen Seafood",Units = 278,UnitPrice = 15,Price = 4170,ParentID = 2,OrderDate = new DateTime(2017, 2, 5),ShippedDate = new DateTime(2017, 2, 12),ShipmentCategory = "Frozen Seafood"},
        new ShipmentData() { ID = 22,Name = "White Shrimp",Category = "Frozen Seafood",Units = 560,UnitPrice = 7,Price = 3920,ParentID = 2,OrderDate = new DateTime(2017, 5, 22),ShippedDate = new DateTime(2017, 5, 29),ShipmentCategory = "Frozen Seafood"},
        new ShipmentData() { ID = 23,Name = "Fresh Cheese",Category = "Dairy",Units = 323,UnitPrice = 12,Price = 3876,ParentID = 2,OrderDate = new DateTime(2017, 6, 8),ShippedDate = new DateTime(2017, 6, 15),ShipmentCategory = "Dairy"},
        new ShipmentData() { ID = 24,Name = "Blue Veined Cheese",Category = "Dairy",Units = 370,UnitPrice = 15,Price = 5550,ParentID = 2,OrderDate = new DateTime(2017, 7, 10),ShippedDate = new DateTime(2017, 7, 17),ShipmentCategory = "Dairy"},
        new ShipmentData() { ID = 25,Name = "Butter",Category = "Dairy",Units = 413,UnitPrice = 9,Price = 3717,ParentID = 2,OrderDate = new DateTime(2017, 9, 18),ShippedDate = new DateTime(2017, 9, 25),ShipmentCategory = "Dairy"}
        };
        return DataCollection;
    }
}
}

{% endhighlight %}

{% endtabs %}

Resizing of stacked header is shown below
![Resizing Stacked Column in Blazor Tree Grid](../images/blazor-treegrid-resize-stacked-column.gif)

## Touch interaction

When the right edge of the header cell is tapped, a floating handler will be visible over the right border of the column. To resize the column, tap and drag the floating handler as needed. You can AutoFit a column by using the Column menu of the tree grid.

The following screenshot represents the column resizing in touch device.

![Blazor Tree Grid Column Resizing in Touch Interaction](../images/blazor-treegrid-column-resizing-touch.png)
