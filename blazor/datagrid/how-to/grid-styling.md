---
layout: post
title: Styling and appearance in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Styling and appearance in Syncfusion Blazor DataGrid component and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Styling and Appearance in Blazor DataGrid Component

To modify the Grid appearance, you need to override the default CSS of grid. Find the list of CSS classes and their corresponding section in grid. Also, you have an option to create your own custom theme for all the Syncfusion Blazor components using our [Theme Studio](https://blazor.syncfusion.com/themestudio/?theme=material).

|Section|CSS class|Purpose of CSS class |
|-----|-----|----- |
|**Root**|e-grid|This class is in the root element (div) of the grid control.|
|**Header**|e-gridheader|This class is added in the root element of header element. In this class, You can override thin line between header and content of the grid.|
| |e-table|This class is added at 'table' of the grid header. This CSS class makes table width as 100 %.|
| |e-columnheader|This class is added at 'tr' of the grid header.|
| |e-headercell|This class is added in 'th' element of grid header. You can override background color of header and border color.|
| |e-headercelldiv|This class is added in the div which presents 'th' element in the header. Use the e-headercelldiv to override the skeleton of the header.|
|**Body**|e-gridcontent|This class is added at root of body content. This is to override background color of the body.|
| |e-table|This class is added to the table of content. This CSS class makes table width as 100 %.|
| |e-altrow|This class is added to alternate rows of grid. This is to override alternate row color of the grid.|
| |e-rowcell|This class is added to all cells in the grid. This is to override cells appearance and styling.|
| |e-groupcaption|This class is added to the 'td' of group caption which is to change the background color of caption cell.|
| |e-selectionbackground|This class is added to rowcell's of the grid. This is override selection.|
|**Pager**|e-pager|This class is added to root element of the pager. This to change appearance of the background color and color of font.|
| |e-pagercontainer|This class is added to numeric items of the pager.|
| |e-parentmsgbar|This class is added to pager info of the pager.|
|**Summary**|e-gridfooter|This class is added to root of the summary div.|
| |e-summaryrow|This class is added to rows of grid summary.|
| |e-summarycell|This class is added to cells of summary row. This is to override background color of summary.|

## Icons

CSS class|Purpose of CSS class
-----|-----
e-add|This class is added to icon of Add toolbar button.
e-edit|This class is added to icon of Edit toolbar button.
e-delete|This class is added to icon of Delete toolbar button.
e-cancel|This class is added to icon of Cancel toolbar button.
e-update|This class is added to icon of Update toolbar button.
e-excelexport|This class is added to icon of ExcelExport toolbar button.
e-csvexport|This class is added to icon of CsvExport toolbar button.
e-pdfexport|This class is added to icon of PdfExport toolbar button.
e-search-icon|This class is added to icon of Search toolbar button.
e-icon-ascending|This class is added to Sort ascending notify icon in grid header.
e-icon-descending|This class is added to Sort descending notify icon in grid header.
e-icon-filter|This class is added to Filter icon in grid header.
e-icon-group|This class is added to Group icon in grid header.
e-columnmenu|This class is added to ColumnMenu icon in grid header.
e-columnchooser-btn|This class is added to ColumnChooser button icon in grid toolbar.
e-icon-gdownarrow|This class is added to collapse icon in grouped/detail row.
e-icon-grightarrow|This class is added to expand icon in grouped/detail row.
e-icon-first|This class is added to pager arrow icon which makes navigation to first page.
e-icon-prev|This class is added to pager arrow icon which makes navigation to previous page.
e-icon-last|This class is added to pager arrow icon which makes navigation to last page.
e-icon-next|This class is added to pager arrow icon which makes navigation to next page.
e-ddl-icon|This class is added to icon of pager dropdown arrow.

## To create animation for the Grid cells, making the values inside them blink using CSS

In Syncfusion Blazor Grid, we can create a blinking animation effect for Grid cells using the [QueryCellInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_QueryCellInfo) event. This event allows us to customize cell content dynamically based on real-time data conditions. Syncfusion Blazor components support automatic updates with [ObservableCollection](https://learn.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.observablecollection-1?view=netframework-4.8) and [INotifyPropertyChanged](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged?view=netframework-4.8), ensuring that any data changes are automatically reflected in the Grid. This, combined with the `QueryCellInfo` event, to achieve the blinking cell effect

The following code example demonstrates, DataGrid with a blinking cell effect using the `QueryCellInfo` event and synchronized with `ObservableCollection` for automatic updates

```cshtml

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons
@using System.Collections.ObjectModel;
@using System.ComponentModel;
@using System;
@using System.Threading.Tasks;
@using System.Runtime.CompilerServices;
@using System.Threading;



<SfButton ID="Button" @onclick="FreightLoop">FreightLoop</SfButton>
<br />
<br />
<SfGrid DataSource="@observableData" AllowPaging="true">
    <GridEvents QueryCellInfo="CustomizeCell" TValue="DataOrder"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(DataOrder.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="@TextAlign.Center" HeaderTextAlign="@TextAlign.Center" Width="140"></GridColumn>
        <GridColumn Field=@nameof(DataOrder.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(DataOrder.OrderDate) HeaderText="Order Date" EditType="EditType.DatePickerEdit" Format="d" TextAlign="TextAlign.Right" Type="ColumnType.Date" Width="160"></GridColumn>
        <GridColumn Field=@nameof(DataOrder.Freight) HeaderText="Freight" EditType="EditType.NumericEdit" Format="C2" Width="140" TextAlign="@TextAlign.Right" HeaderTextAlign="@TextAlign.Right"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private ObservableCollection<DataOrder> observableData { get; set; }
    SfGrid<DataOrder> Grid;
    SfButton Button;
    protected override void OnInitialized()
    {
        observableData = new ObservableCollection<DataOrder>(Enumerable.Range(1, 3).Select(x => new DataOrder()
            {
                OrderID = 10000 + x,
                CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
                Freight = 100 * x,
                OrderDate = DateTime.Now.AddDays(-x),
            }));
    }
    private void FreightLoop()
    {
        Thread loop = new Thread(new ThreadStart(UpdatePrice));
        loop.Start();


    }

    public async void UpdatePrice()
    {
        int i = 0;
        while (true)
        {
            i++;
            switch (i)
            {
                case 1:


                    observableData[0].Freight = observableData[0].Freight + 10;

                    break;
                case 2:
                    observableData[1].Freight = observableData[1].Freight + 10;

                    break;
                case 3:
                    observableData[2].Freight = observableData[2].Freight + 10;

                    break;
                default:
                    i = 0;
                    break;
            }
            await InvokeAsync(() =>
                {
                    base.StateHasChanged();
                });
            Thread.Sleep(250);
        }
    }

    public async Task CustomizeCell(QueryCellInfoEventArgs<DataOrder> args)
    {
        if (args.Column.Field == "Freight")
        {
            if (args.Data.freight > 100 && args.Data.freight < 200)
            {
                args.Cell.AddClass(new string[] { "below-30" });
            }
            else if (args.Data.freight > 200 && args.Data.freight < 300)
            {

                args.Cell.AddClass(new string[] { "below-80" });
            }
            else if (args.Data.freight > 300 && args.Data.freight < 400)
            {

                args.Cell.AddClass(new string[] { "above-80" });
            }

            else
            {
                args.Cell.AddStyle(new string[] { "background-color: white" });

            }


        }

    }

 
    public class DataOrder : INotifyPropertyChanged
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal freight { get; set; }
        public decimal Freight
        {
            get { return freight; }
            set
            {
                this.freight = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        async Task OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

<style>
    .below-30 {
        -webkit-animation: below-30 1.2s infinite; /* Safari 4+ */
        -moz-animation: below-30 1.3s infinite; /* Fx 5+ */
        -o-animation: below-30 1.2s infinite; /* Opera 12+ */
        animation: below-30 1.2s infinite; /* IE 10+, Fx 29+ */
    }

    .below-80 {
        -webkit-animation: below-60 1.2s infinite; /* Safari 4+ */
        -moz-animation: below-60 1.2s infinite; /* Fx 5+ */
        -o-animation: below-60 1.2s infinite; /* Opera 12+ */
        animation: below-60 1.2s infinite; /* IE 10+, Fx 29+ */
    }

    .above-80 {
        -webkit-animation: above-80 1.2s infinite; /* Safari 4+ */
        -moz-animation: above-80 1.2s infinite; /* Fx 5+ */
        -o-animation: above-80 1.2s infinite; /* Opera 12+ */
        animation: above-80 1.2s infinite; /* IE 10+, Fx 29+ */
    }

    @@-webkit-keyframes below-30 {
        0%, 49% {
            background-color: white;
        }

        50%, 100% {
            background-color: red;
        }
    }

    @@-webkit-keyframes below-60 {
        0%, 49% {
            background-color: white;
        }

        50%, 100% {
            background-color: yellow;
        }
    }

    @@-webkit-keyframes above-80 {
        0%, 49% {
            background-color: white;
        }

        50%, 100% {
            background-color: green;
        }
    }
</style>
```

The following screenshot shows blinking animation effect for Grid cells.

![create animation for the Grid cells, making the values inside them blink using CSS](../images/animation-Grid-cells-values.gif)