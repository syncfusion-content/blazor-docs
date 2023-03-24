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

* The [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PageSettings.html#Syncfusion_Blazor_Diagram_PageSettings_Width) and [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PageSettings.html#Syncfusion_Blazor_Diagram_PageSettings_Height) properties of the `PageSettings` define the size of the page. The default value for width is 1123 pixels, and height is 794 pixels.

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
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/PageSettings)

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
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/PageSettings)

![Multiple Page](./images/MultiplePage.png)

## How to change the page appearance

The appearance of the pages can be customized using the following properties of the `PageSettings` class:

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
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/PageSettings)

![PageBackground Color](./images/PageBackground.png)

### How to customize the appearance of the page break

The appearance of the `PageBreak` can be customized using the style properties such as stroke, stroke-width and stroke-dasharray of the diagram pagebreak class.

Refer to the following code example on how to change the stroke, stroke-dasharray of the pagebreak.

```cshtml
@using Syncfusion.Blazor.Diagram

<style>
    .e-diagram-page-break 
    {
        stroke: blue;
        stroke-width: 3;
        stroke-dasharray: 20,20;
    }
</style>

<SfDiagramComponent Height="600px">
    <SnapSettings Constraints="SnapConstraints.None"></SnapSettings>
    @*Initialize the page settings with page orientation and break lines*@
    <PageSettings Height="500"
                  Width="500"
                  MultiplePage="true"
                  ShowPageBreaks="true">
                  <PageMargin Left="50" Right="50" Top="50" Bottom="50"></PageMargin>
    </PageSettings>
</SfDiagramComponent>
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/PageSettings)

![Pagebreak Color](./images/Pagebreak.png)

## How to change the margin around the pages

The area between the maintain content of a page and the page edges can be changed by using the PageMargin property. The default values for the margin are set to 25 on all sides.

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
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/PageSettings)

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
    //Define diagram's nodes collection.
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
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/PageSettings)

## Responsive with parent container

By setting the value in percentage, diagram gets its dimention with respect to its parent container.Specify the Width and Height as 100% to make the diagram element fill its parent container.
Setting the Height to 100% requires the diagram parent element to have explicit height or you can use calc function to set explicit height based on the browser layout.

The following code example illustrates how to set width and height in percentage

```cshtml
@using Syncfusion.Blazor.Diagram
@using System.Collections.ObjectModel
<div style="width:700px; height:700px;">
    <SfDiagramComponent @ref="@diagram" Width="100%" Height="100%" Nodes="nodes"></SfDiagramComponent>
</div>
@code
{
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    SfDiagramComponent diagram;
    protected override void OnInitialized()
    {
        nodes.Add(new Node()
        {
            ID = "node1",
            OffsetX = 100,
            OffsetY = 100,
            Width = 100,
            Height = 100,
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "white" }
        });
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/PageSettings)

## CallBack Methods

* BackgroundChanged : Specifies the callback to trigger when the Background value changes.
* BoundaryConstraintsChanged : Specifies the callback to trigger when the BoundaryConstraints value changes.
* HeightChanged : Specifies the callback to trigger when the height value changes.
* MarginChanged : Specifies the callback to trigger when the Margin value changes.
* MultiplePageChanged :Specifies the callback to trigger when the MultiplePage value changes.
* OrientationChanged : Specifies the callback to trigger when the Orientation value changes.
* ShowPageBreaksChanged : Specifies the callback to trigger when the ShowPageBreaks value changes.
* WidthChanged : Specifies the callback to trigger when the width value changes.


```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px">
    @* Sets the ScrollLimit of scroll settings *@
     <PageSettings BackgroundChanged="OnBackgroundChanged"></PageSettings>
</SfDiagramComponent>

@code
{
    private void OnBackgroundChanged()
    {
       // Enter your code.
    }
}
```