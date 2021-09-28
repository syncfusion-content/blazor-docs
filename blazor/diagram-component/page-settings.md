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

* The size and appearance of the diagram pages can be customized with the [PageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PageSettings.html) property.

* The [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PageSettings.html#Syncfusion_Blazor_Diagram_PageSettings_Width) and [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PageSettings.html#Syncfusion_Blazor_Diagram_PageSettings_Height) properties of page settings define the size of the page and based on the size, the [Orientation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PageSettings.html#Syncfusion_Blazor_Diagram_PageSettings_Orientation) will be set for the page.

* The [Background](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PageSettings.html#Syncfusion_Blazor_Diagram_PageSettings_Background) property is used to customize the background color and border color of the page.

* The [Margin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PageSettings.html#Syncfusion_Blazor_Diagram_PageSettings_Margin) property is used to define the page margin.

* To explore those properties, refer to [PageSettings](https://helpstaging.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PageSettings.html).

```cshtml
@using Syncfusion.Blazor.Diagram

 <SfDiagramComponent @ref="diagram" 
                     Width="100%" 
                     Height="500px" 
                     Nodes="@nodes" 
                     Connectors="@connectors">
        <PageSettings Width="@PageWidth" 
                      Height="@PageHeight" 
                      Orientation="@pageOrientation">
            <PageMargin Left="@marginLeft" 
                        Right="@marginRight" 
                        Top="@marginTop" 
                        Bottom="@marginBottom"></PageMargin>
        </PageSettings>
    </SfDiagramComponent>

@code
{
    SfDiagramComponent diagram;
    double PageWidth = 300;
    double PageHeight = 300;    
    //Sets the page orientation as landscape.
    PageOrientation pageOrientation = PageOrientation.Landscape;
    double marginLeft = 10;
    double marginRight = 10;
    double marginTop = 10;
    double marginBottom = 10;
    //Defines diagram's nodes collection
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();

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
        nodes.Add(node);
    }
}
```

## Set background image

Stretch and align the background image anywhere over the diagram area. 
* The [ImageSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BackgroundStyle.html#Syncfusion_Blazor_Diagram_BackgroundStyle_ImageSource) property of the [BackgroundStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BackgroundStyle.html) allows you to set the path of the image.

* The [ImageScale](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BackgroundStyle.html#Syncfusion_Blazor_Diagram_BackgroundStyle_ImageScale) and the [ImageAlign](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BackgroundStyle.html#Syncfusion_Blazor_Diagram_BackgroundStyle_ImageAlign) properties help to stretch/align the background images.

The following code illustrates how to stretch and align the background image.

```cshtml
@using Syncfusion.Blazor.Diagram

 <SfDiagramComponent @ref="diagram" 
                     Width="100%" 
                     Height="500px" 
                     Nodes="@nodes" 
                     Connectors="@connectors">
        <PageSettings @bind-Width="@PageWidth" 
                      @bind-Height="@PageHeight" 
                      @bind-Orientation="@pageOrientation" >
            <BackgroundStyle @bind-ImageSource="@imageSource" 
                             @bind-ImageScale="@imageScale" 
                             @bind-ImageAlign="@imageAlignment" 
                             @bind-Background="@bgmColor"></BackgroundStyle>
            <PageMargin @bind-Left="@marginLeft" 
                        @bind-Right="@marginRight" 
                        @bind-Top="@marginTop" 
                        @bind-Bottom="@marginBottom"></PageMargin>
        </PageSettings>
</SfDiagramComponent>

@code
{
    SfDiagramComponent diagram;
    double PageWidth = 300;
    double PageHeight = 300;
    double marginLeft = 10;
    double marginRight = 10;
    double marginTop = 10;
    double marginBottom = 10;
    // Sets the page orientation as landscape.
    PageOrientation pageOrientation = PageOrientation.Landscape;
    string imageSource = "https://www.w3schools.com/images/w3schools_green.jpg";
    Scale imageScale = Scale.Slice;
    ImageAlignment imageAlignment = ImageAlignment.XMinYMin;
    string bgmColor = "transparent";
}
```

## Multiple page and page breaks

When multiple page is enabled, the size of the page dynamically increases or decreases in multiples of page width and height and completely fits diagram within the page boundaries. Page breaks is used as a visual guide to see how pages are split into multiple pages.

The [MultiplePage](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PageSettings.html#Syncfusion_Blazor_Diagram_PageSettings_MultiplePage) and [ShowPageBreak](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PageSettings.html#Syncfusion_Blazor_Diagram_PageSettings_ShowPageBreaks) properties of page settings allow you to enable/disable multiple pages and page breaks respectively. The following code illustrates how to enable multiple page and page break lines.

```cshtml
@using Syncfusion.Blazor.Diagram

 <SfDiagramComponent @ref="diagram" 
                     Width="100%" 
                     Height="500px" 
                     Nodes="@nodes" 
                     Connectors="@connectors">
        <PageSettings Width="@PageWidth" 
                      Height="@PageHeight" 
                      Orientation="@pageOrientation" 
                      MultiplePage="@IsMultiplePage" 
                      ShowPageBreaks="@IsShowPageBreaks">
            <BackgroundStyle ImageSource="@imageSource" 
                             ImageScale="@imageScale" 
                             ImageAlign="@imageAlignment" 
                             Background="@bgmColor"></BackgroundStyle>
        </PageSettings>
    </SfDiagramComponent>

@code
{
    SfDiagramComponent diagram;
    double PageWidth = 300;
    double PageHeight = 300;
    //Sets the page orientation as landscape.
    PageOrientation pageOrientation = PageOrientation.Landscape;
    bool IsMultiplePage = true;
    bool IsShowPageBreaks = true;
    string imageSource = "https://www.w3schools.com/images/w3schools_green.jpg";
    Scale imageScale = Scale.Slice;
    ImageAlignment imageAlignment = ImageAlignment.XMinYMin;
    string bgmColor = "transparent";
    //Defines diagram's nodes collection
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();

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
        nodes.Add(node);
    }
}
```

## Boundary constraints

The diagram provides support to restrict/customize the interactive region, out of which the elements cannot be dragged, resized, or rotated. The [BoundaryConstraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PageSettings.html#Syncfusion_Blazor_Diagram_PageSettings_BoundaryConstraints) property of page settings allows you to customize the interactive region. To explore the boundary constraints, refer to [Boundary Constraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.BoundaryConstraints.html).

The following code example illustrates how to define boundary constraints with respect to the page.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

 <SfDiagramComponent @ref="diagram" 
                     Width="100%" 
                     Height="500px" 
                     Nodes="@nodes" 
                     Connectors="@connectors">
        <PageSettings BoundaryConstraints="@boundaryConstraints" 
                      Width="@PageWidth" 
                      Height="@PageHeight" 
                      Orientation="@pageOrientation" 
                      MultiplePage="@IsMultiplePage" 
                      ShowPageBreaks="@IsShowPageBreaks">
        </PageSettings>
</SfDiagramComponent>

@code
{
    SfDiagramComponent diagram;
    BoundaryConstraints boundaryConstraints = BoundaryConstraints.Diagram;
    double PageWidth = 300;
    double PageHeight = 300;
    PageOrientation pageOrientation = PageOrientation.Landscape;
    bool IsMultiplePage = true;
    bool IsShowPageBreaks = true;

    DiagramObjectCollection<Node> nodes; DiagramObjectCollection<Connector> connectors;

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
        nodes.Add(node);
    }
}
```