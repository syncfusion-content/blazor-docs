---
layout: post
title: Virtualization in Blazor TreeGrid Component | Syncfusion
description: Checkout and learn here all about virtualization in Syncfusion Blazor TreeGrid component and much more.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Virtualization in Blazor TreeGrid Component

Tree Grid allows to load large amount of data without performance degradation.

## Row Virtualization

Row virtualization allows to load and render rows only in the content viewport. It is an alternative way of paging in which the rows will be appended while scrolling vertically. To setup the row virtualization, define the [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.SfTreeGrid%601~EnableVirtualization.html) as true and content height by [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.SfTreeGrid%601~Height.html) property.

The number of records displayed in the Tree Grid is determined implicitly by height of the content area and a buffer records will be maintained in the Tree Grid content in addition to the original set of rows.

Expand and Collapse state of any child record will be persisted.

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data;
@using Syncfusion.Blazor.TreeGrid;
@using Syncfusion.Blazor.Grids;

<SfTreeGrid TValue="VirtualData" DataSource="@TreeGridData" ChildMapping="Children" EnableVirtualization="true" Height="350" TreeColumnIndex="1">
    <TreeGridColumns>
        <TreeGridColumn Field="TaskID" HeaderText="Player Jersey" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="FIELD1" HeaderText="Player Name" Width="100"></TreeGridColumn>
        <TreeGridColumn Field="FIELD2" HeaderText="Year" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="FIELD3" HeaderText="Stint" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="FIELD4" HeaderText="TMID" Width="80"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code{
    public VirtualData[] TreeGridData { get; set; }   

    protected override void OnInitialized()
    {
        this.TreeGridData = VirtualData.GetVirtualData().ToArray();
    } 
}

{% endhighlight %}

{% highlight c# %}

namespace TreeGridComponent.Data {

public class VirtualData
    {
        public int? TaskID { get; set; }
        public string FIELD1 { get; set; }
        public int? FIELD2 { get; set; }
        public int? FIELD3 { get; set; }
        public int? FIELD4 { get; set; }
        public List<VirtualData> Children { get; set; }

        public static List<VirtualData> GetVirtualData()
        {
            List<VirtualData> DataCollection = new List<VirtualData>();

            for (var i = 1; i <= 1000; i++)
            {
                VirtualData Parent1 = new VirtualData()
                {
                    TaskID = 1,
                    FIELD1 = "VINET",
                    FIELD2 = 1967,
                    FIELD3 = 395,
                    FIELD4 = 87,
                    Children = new List<VirtualData>()
                };
                VirtualData Child1 = new VirtualData()
                {
                    TaskID = 2,
                    FIELD1 = "TOMSP",
                    FIELD2 = 1968,
                    FIELD3 = 295,
                    FIELD4 = 44
                };
                VirtualData Child2 = new VirtualData()
                {
                    TaskID = 3,
                    FIELD1 = "HANAR",
                    FIELD2 = 1969,
                    FIELD3 = 376,
                    FIELD4 = 22
                };
                VirtualData Child3 = new VirtualData()
                {
                    TaskID = 4,
                    FIELD1 = "VICTE",
                    FIELD2 = 1970,
                    FIELD3 = 123,
                    FIELD4 = 35
                };
                VirtualData Child4 = new VirtualData()
                {
                    TaskID = 5,
                    FIELD1 = "SUPRD",
                    FIELD2 = 1971,
                    FIELD3 = 567,
                    FIELD4 = 98
                };
                VirtualData Child5 = new VirtualData()
                {
                    TaskID = 6,
                    FIELD1 = "RICSU",
                    FIELD2 = 1972,
                    FIELD3 = 378,
                    FIELD4 = 56
                };
                VirtualData Parent2 = new VirtualData()
                {
                    TaskID = 1,
                    FIELD1 = "TOMSP",
                    FIELD2 = 1968,
                    FIELD3 = 295,
                    FIELD4 = 44,
                    Children = new List<VirtualData>()
                };
                VirtualData Child6 = new VirtualData()
                {
                    TaskID = 2,
                    FIELD1 = "VINET",
                    FIELD2 = 1967,
                    FIELD3 = 395,
                    FIELD4 = 87
                };
                VirtualData Child7 = new VirtualData()
                {
                    TaskID = 3,
                    FIELD1 = "VICTE",
                    FIELD2 = 1970,
                    FIELD3 = 123,
                    FIELD4 = 35
                };
                VirtualData Child8 = new VirtualData()
                {
                    TaskID = 4,
                    FIELD1 = "RICSU",
                    FIELD2 = 1972,
                    FIELD3 = 378,
                    FIELD4 = 56
                };
                VirtualData Child9 = new VirtualData()
                {
                    TaskID = 5,
                    FIELD1 = "HANAR",
                    FIELD2 = 1969,
                    FIELD3 = 376,
                    FIELD4 = 22
                };
                VirtualData Child10 = new VirtualData()
                {
                    TaskID = 6,
                    FIELD1 = "SUPRD",
                    FIELD2 = 1971,
                    FIELD3 = 567,
                    FIELD4 = 98
                };
                Parent1.Children.Add(Child1);
                Parent1.Children.Add(Child2);
                Parent1.Children.Add(Child3);
                Parent1.Children.Add(Child4);
                Parent1.Children.Add(Child5);

                Parent2.Children.Add(Child6);
                Parent2.Children.Add(Child7);
                Parent2.Children.Add(Child8);
                Parent2.Children.Add(Child9);
                Parent2.Children.Add(Child10);

                DataCollection.Add(Parent1);
                DataCollection.Add(Parent2);
            }
            return DataCollection;
        }
    }
}

{% endhighlight %}

{% endtabs %}

![Virtualization](images/virtualization.gif)

## Limitations for Virtualization

* While using column virtualization, column width should be in the pixel. Percentage values are not accepted.
* Due to the element height limitation in browsers, the maximum number of records loaded by the tree grid is limited by the browser capability.
* Cell selection will not be persisted in both row and column virtualization.
* Stacked Header is not compatible with detail template.
* Virtual scrolling is not compatible with detail template.
* Row count of the page does not depend on the **PageSize** property of the **TreeGridPageSettings**. Row count for the page is determined by the [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_Height) given to the Tree Grid.
* The virtual height of the tree grid content is calculated using the row height and total number of records in the data source and hence features which changes row height such as text wrapping are not supported. In order to increase the row height to accommodate the content then the row height can be  specified as below to ensure all the table rows are in same height.
* Programmatic selection using the **SelectRows** method is not supported in virtual scrolling.
* Frozen column feature is not supported with Virtual Scrolling.