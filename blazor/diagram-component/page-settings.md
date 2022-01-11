---
layout: post
title: Page Settings in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Page Settings in Syncfusion Blazor Diagram component and much more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Page Settings in Blazor Diagram Component

Page settings enable to customize the appearance, width, and height of the diagram page.

## Page size and appearance

* The size and appearance of the diagram pages can be customized with the page settings property.

* The [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PageSettings.html#Syncfusion_Blazor_Diagram_PageSettings_Width) and [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PageSettings.html#Syncfusion_Blazor_Diagram_PageSettings_Height) properties of page settings define the size of the page and based on the size, the [Orientation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PageSettings.html#Syncfusion_Blazor_Diagram_PageSettings_Orientation) will be set for the page. In addition to that, the appearance of the page can be customized with `Image Source` and set of appearance specific properties.

* The `Background` property of [BackgroundStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BackgroundStyle.html) is used to customize the background color of the page.

* The [Page Margin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PageSettings.html#Syncfusion_Blazor_Diagram_PageSettings_Margin) property is used to define the page margin.

* To explore those properties, refer to [Page Settings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PageSettings.html).

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px">
    @*Initialize the page settings with page orientation and break lines*@
    <PageSettings Height="300" 
                  Width="300" 
                  Orientation="@orientation" 
                  ShowPageBreaks="true">
        @*Set the page background image*@
        <BackgroundStyle Background="LightBlue" />
        @*Set the page margin*@
        <PageMargin Left="10" Top="10" Bottom="10" />
    </PageSettings>
</SfDiagramComponent>

@code
{
    //Sets the page orientation as landscape.
    public PageOrientation orientation = PageOrientation.Landscape;
    //Defines diagram's nodes collection.
    public DiagramObjectCollection<Node> NodeCollection = new DiagramObjectCollection<Node>();

    protected override void OnInitialized()
    {
        Node node = new Node()
        {
            ID = "group",
            OffsetX = 200,
            OffsetY = 200,
            Width = 100,
            Height = 100,
            Annotations = new DiagramObjectCollection<ShapeAnnotation>()
            {
                new ShapeAnnotation()
                {
                    Content = "Node1",
                    Style = new TextStyle()
                    {
                        Color = "white",
                    }
                }
            },
            Style = new ShapeStyle() { Fill = "cornflowerblue", StrokeColor = "white" }
        };
        NodeCollection.Add(node);
    }
}
```

## Set background image

Stretch and align the background image anywhere over the diagram area. 
* The [Image Source](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BackgroundStyle.html#Syncfusion_Blazor_Diagram_BackgroundStyle_ImageSource) property of [Background Style](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BackgroundStyle.html) allows you to set the path of the image.
* The [Image Scale](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BackgroundStyle.html#Syncfusion_Blazor_Diagram_BackgroundStyle_ImageScale) and the [Image Align](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BackgroundStyle.html#Syncfusion_Blazor_Diagram_BackgroundStyle_ImageAlign) properties help to stretch/align the background images.

The following code illustrates how to stretch and align the background image.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px">
    @*Initialize the page settings with page orientation and break lines*@
    <PageSettings Height="300" 
                  Width="300" 
                  Orientation="@orientation" 
                  ShowPageBreaks="true">
        <BackgroundStyle ImageSource="https://www.w3schools.com/images/w3schools_green.jpg" />
        <PageMargin Left="10" Top="10" Bottom="10" />
    </PageSettings>
</SfDiagramComponent>

@code
{
    //Sets the page orientation as landscape.
    public PageOrientation orientation = PageOrientation.Landscape;
}
```

## Multiple page and page breaks

When multiple page is enabled, the size of the page dynamically increases or decreases in multiples of page width and height and completely fits diagram within the page boundaries. Page breaks is used as a visual guide to see how pages are split into multiple pages.

The [MultiplePage](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PageSettings.html#Syncfusion_Blazor_Diagram_PageSettings_MultiplePage) and [ShowPageBreak](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PageSettings.html#Syncfusion_Blazor_Diagram_PageSettings_ShowPageBreaks) properties of page settings allow you to enable/disable multiple pages and page breaks respectively. The following code illustrates how to enable multiple page and page break lines.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Nodes="@NodeCollection" Height="600px">
    <SnapSettings>
        <HorizontalGridLines LineColor="gray"/>
        <VerticalGridLines LineColor="gray"/>
    </SnapSettings>
    @*Initialize the page settings with page orientation and break lines*@
    <PageSettings Height="300" 
                  Width="300" 
                  MultiplePage="true" 
                  Orientation="@orientation"                   
                  ShowPageBreaks="true">
        <BackgroundStyle Background="lightblue"/>
        <PageMargin Left="10" Top="10" Bottom="10"/>        
    </PageSettings>
</SfDiagramComponent>

@code
{
    //Reference to diagram.
    SfDiagramComponent diagram;
    public PageOrientation orientation = PageOrientation.Landscape;   
    //Defines diagram's nodes collection.
    public DiagramObjectCollection<Node>
    NodeCollection = new DiagramObjectCollection<Node>();

    protected override void OnInitialized()
    {
        Node node = new Node()
        {
            ID = "group",
            OffsetX = 200,
            OffsetY = 200,
            Width = 100,
            Height = 100,
            Annotations = new DiagramObjectCollection<ShapeAnnotation>()
            {
                new ShapeAnnotation()
                {
                    Content = "Node1",
                    Style = new TextStyle()
                    {
                        Color = "white",
                    }
                }
            },
            Style = new ShapeStyle() 
            { 
                Fill = "cornflowerblue", 
                StrokeColor = "white" 
            }
        };
        NodeCollection.Add(node);
    }
}
```

## Boundary constraints

The diagram provides support to restrict/customize the interactive region, out of which the elements cannot be dragged, resized, or rotated. The [BoundaryConstraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PageSettings.html#Syncfusion_Blazor_Diagram_PageSettings_BoundaryConstraints) property of page settings allows you to customize the interactive region. To explore the boundary constraints, refer to [Boundary Constraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BoundaryConstraints.html).

The following code example illustrates how to define boundary constraints with respect to the page.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Nodes="@NodeCollection" Height="600px">
    <SnapSettings>
        <HorizontalGridLines LineColor="gray"/>
        <VerticalGridLines LineColor="gray"/>
    </SnapSettings>
    @*Initialize the page settings with page orientation and break lines*@
    <PageSettings Height="300" 
                  Width="300" 
                  MultiplePage="true" 
                  Orientation="@orientation" 
                  BoundaryConstraints="@boundaryConstraints" 
                  ShowPageBreaks="true">
        <BackgroundStyle Background="lightblue"/>
        <PageMargin Left="10" Top="10" Bottom="10"/>        
    </PageSettings>
</SfDiagramComponent>

@code
{
    //Reference to diagram.
    SfDiagramComponent diagram;
    public PageOrientation orientation = PageOrientation.Landscape;
    public BoundaryConstraints boundaryConstraints = BoundaryConstraints.Page;
    //Defines diagram's nodes collection.
    public DiagramObjectCollection<Node>
    NodeCollection = new DiagramObjectCollection<Node>();

    protected override void OnInitialized()
    {
        Node node = new Node()
        {
            ID = "group",
            OffsetX = 200,
            OffsetY = 200,
            Width = 100,
            Height = 100,
            Annotations = new DiagramObjectCollection<ShapeAnnotation>()
            {
                new ShapeAnnotation()
                {
                    Content = "Node1",
                    Style = new TextStyle()
                    {
                        Color = "white",
                    }
                }
            },
            Style = new ShapeStyle() 
            { 
                Fill = "cornflowerblue", 
                StrokeColor = "white" 
            }
        };
        NodeCollection.Add(node);
    }
}
```