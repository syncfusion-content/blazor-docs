---
layout: post
title: Page Settings in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Page Settings in Syncfusion Blazor Diagram component and much more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Page Settings in Blazor Diagram Component

By default, Diagram’s page size is decided based on the position of its diagramming elements. The size and appearance of the diagram pages can be customized using the [PageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PageSettings.html) property of the diagram.

* The [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PageSettings.html#Syncfusion_Blazor_Diagram_PageSettings_Width) and [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PageSettings.html#Syncfusion_Blazor_Diagram_PageSettings_Height) properties of `PageSettings` define the size of the page. The default value for width is 1123 pixels and height is 794 pixels.

* The [Orientation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PageSettings.html#Syncfusion_Blazor_Diagram_PageSettings_Orientation) property of `PageSettings` is used to change the page orientation to portrait or landscape. The default orientation is landscape.

* Page breaks are used as a visual guide to show how the pages are split into multiple pages. The [ShowPageBreaks](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PageSettings.html#Syncfusion_Blazor_Diagram_PageSettings_ShowPageBreaks) property decides the Visibility of Page breaks. By default, it is false. If it is true, then the page break lines will be visible.

* To explore those properties, refer to [PageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PageSettings.html).

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px">
    @*Initialize the page settings with page orientation and break lines*@
    <PageSettings Height="300" 
                  Width="300" 
                  Orientation="@orientation" 
                  ShowPageBreaks="true">
    </PageSettings>
</SfDiagramComponent>

@code
{
    //Sets the page orientation as landscape.
    public PageOrientation orientation = PageOrientation.Landscape;
}
```

|Orientation|Output|
|-------|-------|
|Landscape|![Landscape Orientation](./images/LandscapeOrientation.png)|
|Portrait|![Portrait Orientation](./images/PortraitOrientation.png)|

## How to enable the multiple page

Based on the diagramming element position, the size of the page dynamically increases or decreases in multiples of page width and height using the [MultiplePage](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PageSettings.html#Syncfusion_Blazor_Diagram_PageSettings_MultiplePage) property of `PageSettings`.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="nodes">
    @*Initialize the page settings with multiple page, page orientation and break lines*@
    <PageSettings Height="300"
                  Width="300"
                  MultiplePage="true"
                  Orientation="@orientation"
                  ShowPageBreaks="true">
    </PageSettings>
</SfDiagramComponent>

@code
{
    //Sets the page orientation as landscape.
    public PageOrientation orientation = PageOrientation.Landscape;
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    protected override void OnInitialized()
    {
        Node node = new Node()
        {
            ID = "node6",
            Width = 50,
            Height = 50,
            OffsetX = 150,
            OffsetY = 100,
            Style = new ShapeStyle()
            {
                Fill = "#6495ED",
                StrokeColor = "white"
            }
        };
        nodes.Add(node);
    }
}
```
![Multiple Page](./images/MultiplePage.png)

## How to change the page appearance

The appearance of the pages can be customized by using the following properties of the PageSettings class:

* The `Background` property of [BackgroundStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BackgroundStyle.html) is used to customize the background color of the page.

* The [Image Source](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BackgroundStyle.html#Syncfusion_Blazor_Diagram_BackgroundStyle_ImageSource) property of the [Background Style](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BackgroundStyle.html) allows you to set the path of the image.

* The [Image Scale](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BackgroundStyle.html#Syncfusion_Blazor_Diagram_BackgroundStyle_ImageScale) and [Image Align](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BackgroundStyle.html#Syncfusion_Blazor_Diagram_BackgroundStyle_ImageAlign) properties of the `BackgroundStyle` help to stretch/align the background images.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="nodes">
    @*Initialize the page settings with page orientation and break lines*@
    <PageSettings Height="300"
                  Width="300"
                  Orientation="@orientation"
                  MultiplePage="true"
                  ShowPageBreaks="true">
        @*Set the page background color*@
        <BackgroundStyle Background="LightGreen" />
        <PageMargin Left="10" Top="10" Bottom="10" />
    </PageSettings>
</SfDiagramComponent>

@code
{
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    protected override void OnInitialized()
    {
        Node node = new Node()
        {
            ID = "node6",
            Width = 50,
            Height = 50,
            OffsetX = 150,
            OffsetY = 100,
            Style = new ShapeStyle()
            {
                Fill = "#6495ED",
                StrokeColor = "white"
            }
        };
        nodes.Add(node);
    }
    //Set the page orientation as landscape.
    public PageOrientation orientation = PageOrientation.Landscape;
}
```
![PageBackground Color](./images/PageBackground.png)

## How to change the margin around the pages

The area between the main content of a page and the page edges can be changed by using the PageMargin property. The default values for the margin are set to 25 on all sides.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px">
    @*Initialize the page settings with page margin*@
    <PageSettings Height="300" 
                  Width="300" 
                  MultiplePage="true"                  
                  ShowPageBreaks="true">
        <BackgroundStyle Background="lightblue"/>
        <PageMargin Left="50" Right="50" Top="50" Bottom="50"/> 
    </PageSettings>
</SfDiagramComponent>
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
