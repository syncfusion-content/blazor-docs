---
layout: post
title: Printing in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about the Printing feature in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Printing in Blazor Diagram Component

Diagram supports printing the visible content using the [PrintAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_PrintAsync_) method.

## How to Set Up Page Layout for Printing 

Some print options cannot be configured through JavaScript code. Therefore, the layout, paper size, and margin options must be customized using the browser page setup dialog. Refer to the following links to learn more about the browser page setup:

* [Chrome](https://support.google.com/chrome/answer/1069693?hl=en&visit_id=1-636335333734668335-3165046395&rd=1)
* [Firefox](https://support.mozilla.org/en-US/kb/how-print-web-pages-firefox)
* [Safari](https://www.mintprintables.com/print-tips/adjust-margins-osx/)
* [IE](http://www.helpteaching.com/help/print/index.htm)

## How to Customize Printing Options

Customize the print output using the properties of the [DiagramPrintSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramPrintSettings.html) class. 

| Name | Description|
|-------- | -------- |
| [Region](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramPrintSettings.html#Syncfusion_Blazor_Diagram_DiagramPrintSettings_Region) | Sets the region of the diagram to be printed. |
| [Margin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramPrintSettings.html#Syncfusion_Blazor_Diagram_DiagramPrintSettings_Margin) | Sets the margin of the page to be printed/exported.|
| [FitToPage](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramPrintSettings.html#Syncfusion_Blazor_Diagram_DiagramPrintSettings_FitToPage) | Prints the diagram into a single or multiple pages. |
| [PageWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramPrintSettings.html#Syncfusion_Blazor_Diagram_DiagramPrintSettings_PageWidth) | Sets the page width of the diagram while printing the diagram in multiple pages. |
| [PageHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramPrintSettings.html#Syncfusion_Blazor_Diagram_DiagramPrintSettings_PageHeight)| Sets the page height of the diagram while printing the diagram in multiple pages.|
| [Orientation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramPrintSettings.html#Syncfusion_Blazor_Diagram_DiagramPrintSettings_Orientation) | Sets the orientation of the page. |
| [ClipBounds](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramPrintSettings.html#Syncfusion_Blazor_Diagram_DiagramPrintSettings_ClipBounds) | Sets the custom bounds for the region of the diagram to be printed.|

These properties behave the same as the properties in the [DiagramExportSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramExportSettings.html) class. For more details, [refer](https://blazor.syncfusion.com/documentation/diagram/export#exporting-options) 

The following code example illustrates how to print the region occupied by the diagram elements using diagram [PageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PageSettings.html).

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Buttons

<SfButton Content="Print" OnClick="@OnPrintAsync" />

<SfDiagramComponent Height="600px" @ref="@_diagram">
    <PageSettings MultiplePage="true" Width="@_width" Height="@_height" Orientation="@_pageOrientation" ShowPageBreaks="@_showPageBreak">
        <PageMargin Left="@_left" Right="@_right" Top="@_top" Bottom="@_bottom"></PageMargin>
    </PageSettings>
</SfDiagramComponent>

@code {
    //Reference the diagram
    private SfDiagramComponent _diagram;
    private double _left = 10;
    private double _top = 10;
    private double _right = 10;
    private double _bottom = 10;
    private double _width = 410;
    private double _height = 550;
    private bool _multiplePage = true;
    private bool _showPageBreak = true;
    private DiagramPrintExportRegion _region = DiagramPrintExportRegion.PageSettings;
    private PageOrientation _pageOrientation = PageOrientation.Portrait;

    //Method to prin the diagram
    private async Task OnPrintAsync()
    {
        DiagramPrintSettings print = new DiagramPrintSettings();
        print.PageWidth = _width;
        print.PageHeight = _height;
        print.Region = _region;
        print.FitToPage = _multiplePage;
        print.Orientation = _pageOrientation;
        print.Margin = new DiagramThickness() { Left = _left, Top = _top, Right = _right, Bottom = _bottom };
        await _diagram.PrintAsync(print);
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BNBoCNXPziyzzRgP?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Print/PrintSample.razor)

The following code example illustrates how to print a selected region in the diagram using clip bounds.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Buttons

<SfButton Content="Print" OnClick="@OnPrintAsync" />

<SfDiagramComponent Height="600px" @ref="@_diagram" NodeCreating="NodeCreating" ConnectorCreating="ConnectorCreating">
    <PageSettings MultiplePage="true" Width="@_width" Height="@_height" Orientation="@_pageOrientation" ShowPageBreaks="@_showPageBreak">
        <PageMargin Left="@_left" Right="@_right" Top="@_top" Bottom="@_bottom"></PageMargin>
    </PageSettings>
    <DataSourceSettings DataSource="@_dataSource" ID="Id" ParentID="Manager"></DataSourceSettings>
    <Layout @bind-Type="@_layoutType" @bind-HorizontalSpacing="@_horizontalSpacing" @bind-FixedNode="@_fixedNode" @bind-Orientation="@_layoutOrientation" @bind-VerticalSpacing="@_verticalSpacing" @bind-HorizontalAlignment="@_horizontalAlignment" @bind-VerticalAlignment="@_verticalAlignment">
        <LayoutMargin @bind-Top="@_layoutTop" @bind-Bottom="@_layoutBottom" @bind-Right="@_layoutRight" @bind-Left="@_layoutLeft"></LayoutMargin>
    </Layout>
    <SnapSettings></SnapSettings>
</SfDiagramComponent>

@code {
    //Reference the diagram
    private SfDiagramComponent _diagram;
    private double _left = 10;
    private double _top = 10;
    private double _right = 10;
    private double _bottom = 10;
    private double _width = 410;
    private double _height = 550;
    private bool _multiplePage = true;
    private bool _showPageBreak = true;
    private DiagramPrintExportRegion _region = DiagramPrintExportRegion.ClipBounds;
    private PageOrientation _pageOrientation = PageOrientation.Landscape;

    //Method to prin the diagram
    private async Task OnPrintAsync()
    {
        DiagramPrintSettings print = new DiagramPrintSettings();
        print.ClipBounds = new DiagramRect() { Height = 300, Width = 500, X = 300, Y = 200 };
        print.Region = _region;
        print.FitToPage = _multiplePage;
        print.Orientation = _pageOrientation;
        await _diagram.PrintAsync(print);
    }

    private double _layoutTop = 50;
    private double _layoutBottom = 50;
    private double _layoutRight = 50;
    private double _layoutLeft = 50;
    private LayoutType _layoutType = LayoutType.OrganizationalChart;
    private LayoutOrientation _layoutOrientation = LayoutOrientation.TopToBottom;
    private HorizontalAlignment _horizontalAlignment = HorizontalAlignment.Auto;
    private VerticalAlignment _verticalAlignment = VerticalAlignment.Auto;
    private int _horizontalSpacing = 30;
    private int _verticalSpacing = 30;
    private string _fixedNode = null;

    private class HierarchicalDetails
    {
        public string Id { get; set; }
        public string Role { get; set; }
        public string Manager { get; set; }
        public string ChartType { get; set; }
        public string Color { get; set; }
    }

    private List<HierarchicalDetails> _dataSource = new List<HierarchicalDetails>()
    {
        new HierarchicalDetails()   { Id= "parent", Role= "Board", Color= "#71AF17" },
        new HierarchicalDetails()   { Id= "1", Role= "General Manager", Manager= "parent", ChartType= "right", Color= "#71AF17" },
        new HierarchicalDetails()   { Id= "11", Role= "Assistant Manager", Manager= "1", Color= "#71AF17" },
        new HierarchicalDetails()   { Id= "2", Role= "Human Resource Manager", Manager= "1", ChartType= "right", Color= "#1859B7" },
        new HierarchicalDetails()   { Id= "3", Role= "Trainers", Manager= "2", Color= "#2E95D8" },
        new HierarchicalDetails()   { Id= "4", Role= "Recruiting Team", Manager= "2", Color= "#2E95D8" },
        new HierarchicalDetails()   { Id= "5", Role= "Finance Asst. Manager", Manager= "2", Color= "#2E95D8" },
        new HierarchicalDetails()   { Id= "6", Role= "Design Manager", Manager= "1",ChartType= "right", Color= "#1859B7" },
        new HierarchicalDetails()   { Id= "7", Role= "Design Supervisor", Manager= "6", Color= "#2E95D8" },
        new HierarchicalDetails()   { Id= "8", Role= "Development Supervisor", Manager= "6", Color= "#2E95D8" },
        new HierarchicalDetails()   { Id= "9", Role= "Drafting Supervisor", Manager= "6", Color= "#2E95D8" },
        new HierarchicalDetails()   { Id= "10", Role= "Operation Manager", Manager= "1", ChartType= "right", Color= "#1859B7" },
        new HierarchicalDetails()   { Id= "11", Role= "Statistic Department", Manager= "10", Color= "#2E95D8" },
        new HierarchicalDetails()   { Id= "12", Role= "Logistic Department", Manager= "10", Color= "#2E95D8" },
        new HierarchicalDetails()   { Id= "16", Role= "Marketing Manager", Manager= "1", ChartType= "right", Color= "#1859B7" },
        new HierarchicalDetails()   { Id= "17", Role= "Oversea sales Manager", Manager= "16", Color= "#2E95D8" },
        new HierarchicalDetails()   { Id= "18", Role= "Petroleum Manager", Manager= "16", Color= "#2E95D8" },
        new HierarchicalDetails()   { Id= "20", Role= "Service Dept. Manager", Manager= "16", Color= "#2E95D8" },
        new HierarchicalDetails()   { Id= "21", Role= "Quality Department", Manager= "16", Color= "#2E95D8" }
    };

    private void NodeCreating(IDiagramObject obj)
    {
        Node node = obj as Node;
        if (node.Data is System.Text.Json.JsonElement)
        {
            node.Data = System.Text.Json.JsonSerializer.Deserialize<HierarchicalDetails>(node.Data.ToString());
        }
        HierarchicalDetails hierarchicalData = node.Data as HierarchicalDetails;
        node.Width = 150;
        node.Height = 50;
        node.Style.Fill = hierarchicalData.Color;
        // node.IsVisible = false;
        node.Annotations = new DiagramObjectCollection<ShapeAnnotation>()
        {
            new ShapeAnnotation()
            {
                Content = hierarchicalData.Role,
                Style =new TextStyle(){Color = "white"}
            }
        };
    }
    private void ConnectorCreating(IDiagramObject connector)
    {
        (connector as Connector).Type = ConnectorSegmentType.Orthogonal;
        (connector as Connector).TargetDecorator.Shape = DecoratorShape.None;
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VZLoMXXbpCREFrTL?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Print/PrintUsingClipBounds.razor)

## See Also

* [How to print or export the HTML and Native node into image format](https://support.syncfusion.com/kb/article/12332/how-to-print-or-export-the-html-and-native-node-into-image-format-in-blazor-diagarm)

* [How to Export the Blazor Diagram to PDF](https://support.syncfusion.com/kb/article/16302/how-to-export-the-blazor-diagram-to-pdf)
