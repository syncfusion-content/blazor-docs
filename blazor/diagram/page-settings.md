---
layout: post
title: Page Settings in Blazor Diagram Component | Syncfusion 
description: Learn about Page Settings in Blazor Diagram component of Syncfusion, and more details.
platform: Blazor
control: Diagram
documentation: ug
---

# Page Settings

Page settings enable to customize the appearance, width, and height of the diagram page.

## Page size and appearance

* The size and appearance of the diagram pages can be customized with the page settings property.

* The [`Width`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramPageSettings.html#Syncfusion_Blazor_Diagrams_DiagramPageSettings_Width) and [`Height`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramPageSettings.html#Syncfusion_Blazor_Diagrams_DiagramPageSettings_Height) properties of page settings define the size of the page and based on the size, the [`Orientation`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramPageSettings.html#Syncfusion_Blazor_Diagrams_DiagramPageSettings_Orientation) will be set for the page. In addition to that, the appearance of the page can be customized with `Source` and set of appearance specific properties.

* The `Color` property is used to customize the background color and border color of the page.

* The [`Margin`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramPageSettings.html#Syncfusion_Blazor_Diagrams_DiagramPageSettings_Margin) property is used to define the page margin.

* To explore those properties, refer to `Page Settings`.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel
<SfDiagram Height="600px" id="diagram">
    @*Initialize the page settings with page orientation and break lines*@
    <DiagramPageSettings Height="300" Width="300" Orientation="@orientation" ShowPageBreaks="true">
        @*Set the page background image*@
        <DiagramBackground Source="https://www.w3schools.com/images/w3schools_green.jpg" />
        @*Set the page margin*@
        <PageSettingsMargin Left="10" Top="10" Bottom="10" />
    </DiagramPageSettings>
</SfDiagram>

@code
{
    //Sets the page orientation as landscape.
    public PageOrientation orientation = PageOrientation.Landscape;

    //Defines diagram's nodes collection
    public ObservableCollection<DiagramNode> NodeCollection = new ObservableCollection<DiagramNode>();

    protected override void OnInitialized()
    {
        DiagramNode node = new DiagramNode()
        {
            Id = "group",
            OffsetX = 200,
            OffsetY = 200,
            Width = 100,
            Height = 100,
            Annotations = new ObservableCollection<DiagramNodeAnnotation>()
        {
                new DiagramNodeAnnotation()
                {
                    Content = "Node1",
                    Style = new AnnotationStyle()
                    {
                        Color = "white",
                    }
                }
            },
            Style = new NodeShapeStyle() { Fill = "cornflowerblue", StrokeColor = "white" }
        };
        NodeCollection.Add(node);
    }
}
```

## Set background image

Stretch and align the background image anywhere over the diagram area.
The [`Source`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramBackground.html#Syncfusion_Blazor_Diagrams_DiagramBackground_Source) property of [`Background`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramPageSettings.html#Syncfusion_Blazor_Diagrams_DiagramPageSettings_Background) allows you to set the path of the image.
The [`Scale`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramBackground.html#Syncfusion_Blazor_Diagrams_DiagramBackground_Scale) and the [`Align`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramBackground.html#Syncfusion_Blazor_Diagrams_DiagramBackground_Align) properties help to stretch/align the background images.

The following code illustrates how to stretch and align the background image.

```cshtml
@using Syncfusion.Blazor.Diagrams
<SfDiagram Height="600px" id="diagram">
    @*Initialize the page settings with page orientation and break lines*@
    <DiagramPageSettings Height="300" Width="300" Orientation="@orientation" ShowPageBreaks="true">
        <DiagramBackground Source="https://www.w3schools.com/images/w3schools_green.jpg"/>
        <PageSettingsMargin Left="10" Top="10" Bottom="10"/>
    </DiagramPageSettings>
</SfDiagram>

@code
{
    //Sets the page orientation as landscape.
    public PageOrientation orientation = PageOrientation.Landscape;
}
```

## Multiple page and page breaks

When multiple page is enabled, the size of the page dynamically increases or decreases in multiples of page width and height and completely fits diagram within the page boundaries. Page breaks is used as a visual guide to see how pages are split into multiple pages.

The [`MultiplePage`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramPageSettings.html#Syncfusion_Blazor_Diagrams_DiagramPageSettings_MultiplePage) and [`ShowPageBreak`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramPageSettings.html#Syncfusion_Blazor_Diagrams_DiagramPageSettings_ShowPageBreaks) properties of page settings allow you to enable/disable multiple pages and page breaks respectively.
The following code illustrates how to enable multiple page and page break lines.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

<SfDiagram Nodes="@NodeCollection" Height="600px" id="diagram">
    <DiagramSnapSettings>
        <HorizontalGridlines LineColor="gray"/>
        <VerticalGridlines LineColor="gray"/>
    </DiagramSnapSettings>
    @*Initialize the page settings with page orientation and multiple pages*@
    <DiagramPageSettings Height="300" Width="300" MultiplePage="true" Orientation="@orientation" ShowPageBreaks="true">
        <DiagramBackground Color="lightblue"/>
        <PageSettingsMargin Left="10" Top="10" Bottom="10"/>
    </DiagramPageSettings>
</SfDiagram>

@code
{
    //Sets the page orientation as landscape.
    public PageOrientation orientation = PageOrientation.Landscape;

    //Defines diagram's nodes collection
    public ObservableCollection<DiagramNode> NodeCollection = new ObservableCollection<DiagramNode>();

    protected override void OnInitialized()
    {
        DiagramNode node = new DiagramNode()
        {
            Id = "group",
            OffsetX = 200,
            OffsetY = 200,
            Width = 100,
            Height = 100,
            Annotations = new ObservableCollection<DiagramNodeAnnotation>()
            {
                new DiagramNodeAnnotation()
                {
                    Content = "Node1",
                    Style = new AnnotationStyle()
                    {
                        Color = "white",
                    }
                }
            },
            Style = new NodeShapeStyle() { Fill = "cornflowerblue", StrokeColor = "white" }
        };
        NodeCollection.Add(node);
    }
}
```

## Boundary constraints

The diagram provides support to restrict/customize the interactive region, out of which the elements cannot be dragged, resized, or rotated. The [`BoundaryConstraints`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramPageSettings.html#Syncfusion_Blazor_Diagrams_DiagramPageSettings_BoundaryConstraints) property of page settings allows you to customize the interactive region.
To explore the boundary constraints, refer to [`Boundary Constraints`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramPageSettings.html#Syncfusion_Blazor_Diagrams_DiagramPageSettings_BoundaryConstraints).

The following code example illustrates how to define boundary constraints with respect to the page.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

<SfDiagram Nodes="@NodeCollection" Height="600px">
    <DiagramSnapSettings>
        <HorizontalGridlines LineColor="gray" />
        <VerticalGridlines LineColor="gray" />
    </DiagramSnapSettings>
    @*Initialize the page settings with page orientation and break lines*@
    <DiagramPageSettings Height="300" Width="300" MultiplePage="true" Orientation="@orientation" BoundaryConstraints="@boundaryConstraints" ShowPageBreaks="true">
        <DiagramBackground Color="lightblue" />
        <PageSettingsMargin Left="10" Top="10" Bottom="10" />
    </DiagramPageSettings>
</SfDiagram>

@code
{
    //Reference to diagram
    SfDiagram diagram;

    public PageOrientation orientation = PageOrientation.Landscape;

    public BoundaryConstraints boundaryConstraints = BoundaryConstraints.Page;

    //Defines diagram's nodes collection
    public ObservableCollection<DiagramNode>
    NodeCollection = new ObservableCollection<DiagramNode>
        ();

        protected override void OnInitialized()
        {
        DiagramNode node = new DiagramNode()
        {
        Id = "group",
        OffsetX = 200,
        OffsetY = 200,
        Width = 100,
        Height = 100,
        Annotations = new ObservableCollection<DiagramNodeAnnotation>
            ()
            {
            new DiagramNodeAnnotation()
            {
            Content = "Node1",
            Style = new AnnotationStyle()
            {
            Color = "white",
            }
            }
            },
            Style = new NodeShapeStyle() { Fill = "cornflowerblue", StrokeColor = "white" }
            };
            NodeCollection.Add(node);
            }
            }
```
