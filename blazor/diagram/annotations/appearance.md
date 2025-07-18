---
layout: post
title: Annotation Appearance in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Appearance in Syncfusion Blazor Diagram component and much more details.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Annotation Appearance in Blazor Diagram Component

## How to Customize Annotation Size

The diagram allows you to set size for annotations by using the Height and Width properties. The default value of the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Annotation.html#Syncfusion_Blazor_Diagram_Annotation_Width) and [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Annotation.html#Syncfusion_Blazor_Diagram_Annotation_Height) properties is 0, and it takes the node or connector size as default. The following code example shows how the annotation size is customized.

```cshtml
@using Syncfusion.Blazor.Diagram
<SfDiagramComponent Height="600px" Connectors="@connectors" />
@code
{
    // Defines diagram's connector collection.
    DiagramObjectCollection<Connector> connectors;
    protected override void OnInitialized()
    {
        connectors = new DiagramObjectCollection<Connector>();
        Connector connector = new Connector()
        {
            SourcePoint = new DiagramPoint() { X = 300, Y = 40 },
            TargetPoint = new DiagramPoint() { X = 400, Y = 160 },
            Type = ConnectorSegmentType.Orthogonal,
            Style = new TextStyle() { StrokeColor = "#6495ED" },
            Annotations = new DiagramObjectCollection<PathAnnotation>()
            {
              new PathAnnotation 
              { 
                  Content = "Annotation length will be varied", 
                  // Sets the size of the annotation.
                  Width = 50, 
                  Height = 50 
              },
            }
        };
        connectors.Add(connector);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Annotations/Appearance/SizeOfAnnotation)

![Changing Annotation Size in Blazor Diagram](../images/blazor-diagram-annotation-size.png)

## How to Add Hyper Link to Annotation

The diagram provides support to add a [Hyperlink](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Annotation.html#Syncfusion_Blazor_Diagram_Annotation_Hyperlink) to the node's or connector's annotation. It can also be customized.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes" />

@code
{
    // Defines diagram's node collection.
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        Node node = new Node()
        {
            ID = "node",
            Width = 100,
            Height = 100,
            OffsetX = 100,
            OffsetY = 100,
            // Sets the annotation for the Node.
            Annotations = new DiagramObjectCollection<ShapeAnnotation>()
            {
                // Add text as hyperlink.
                new ShapeAnnotation 
                { 
                    Hyperlink = new HyperlinkSettings
                    { 
                        Url = "https://www.syncfusion.com"
                    } 
                }
            },
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "white" },
        };
        nodes.Add(node);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Annotations/Appearance/HyperlinktoAnnotation)

![Annotation with Hyperlink in Blazor Diagram](../images/blazor-diagram-annotation-with-hyperlink.png)

### How to Display Text in Annotation Hyper Links

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes" />

@code
{
    // Defines diagram's node collection.
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        Node node = new Node()
        {
            ID = "node",
            Width = 100,
            Height = 100,
            OffsetX = 100,
            OffsetY = 100,
            // Sets the annotation for the Node.
            Annotations = new DiagramObjectCollection<ShapeAnnotation>()
            {
                // Add text as hyperlink.
                new ShapeAnnotation 
                { 
                    Hyperlink = new HyperlinkSettings
                    { 
                        Content = "Syncfusion", 
                        Url = "https://www.syncfusion.com" 
                    } 
                }
            },
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "white" },
        };
        nodes.Add(node);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Annotations/Appearance/HyperlinkWithContent)

![HyperLink with Content in Blazor Diagram](../images/blazor-diagram-hyperlink-content.png)

## How to Wrap Text Using Text Wrapping

The [TextWrapping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.TextStyle.html#Syncfusion_Blazor_Diagram_TextStyle_TextWrapping) property of an annotation defines how the text should be wrapped. When text overflows node boundaries, you can control it by using the `TextWrapping`. So, it is wrapped into multiple lines. The following code explains how to wrap a text in a node.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes" />

@code
{
    // Defines diagram's node collection.
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        Node node = new Node()
        {
            ID = "node",
            Width = 100,
            Height = 100,
            OffsetX = 100,
            OffsetY = 100,
            // Sets the annotation for the node.
            Annotations = new DiagramObjectCollection<ShapeAnnotation>()
            {
                new ShapeAnnotation 
                {
                    Content = "Annotation Text Wrapping",
                    Style = new TextStyle()
                    { 
                        // Sets the text wrapping of the annotation as Wrap.
                        TextWrapping = TextWrap.Wrap
                    } 
                }
            },
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "white" },
        };
        nodes.Add(node);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Annotations/Appearance/AnnotationWithTextWrapping)

| TextWrapping | Description | Image |
| -------- | -------- | -------- |
| [No Wrap](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.TextWrap.html#Syncfusion_Blazor_Diagram_TextWrap_NoWrap) | Text will not be wrapped. | ![Blazor Diagram Text without Wrap](../images/blazor-diagram-label-without-wrap.png) |
| [Wrap](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.TextWrap.html#Syncfusion_Blazor_Diagram_TextWrap_Wrap) | Text-wrapping occurs, when the text overflows beyond the available node width. | ![Text Wrapping in Blazor Diagram](../images/blazor-diagram-text-wrapping.png) |
| [WrapWithOverflow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.TextWrap.html#Syncfusion_Blazor_Diagram_TextWrap_WrapWithOverflow) | Text-wrapping occurs, when the text overflows beyond the available node width. However, the text may overflow beyond the node width in the case of a very long word. | ![Blazor Diagram Text Wrapping with Overflow](../images/blazor-diagram-text-wrap-with-overflow.png) |

### How to Control Text Overflow

The [TextOverflow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.TextStyle.html#Syncfusion_Blazor_Diagram_TextStyle_TextOverflow) property specifies how the overflowed content that is not displayed should be signaled to the user. The TextOverflow property can have the following values.

* **Wrap**: Wraps the text to next line, when it exceeds its bounds.
* **Ellipsis**: It truncates the overflown text and renders an ellipsis ("...") to represent the clipped text.
* **Clip**: Clips the text, and the overflow text will not be shown.

The following code sample shows how the different types of overflow property working for the different types of text wrapping.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes" />

@code
{
    // Defines diagram's node collection.
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        Node node = new Node()
        {
            ID = "node",
            Width = 100,
            Height = 100,
            OffsetX = 100,
            OffsetY = 100,
            // Sets the style for the text to be displayed.
            Annotations = new DiagramObjectCollection<ShapeAnnotation>()
            {
                new ShapeAnnotation
                {
                    Content = "The text element with property of overflow as Wrap and wrapping as NoWrap",
                    Style = new TextStyle()
                    { 
                        // Sets the text overflow of the annotation as Wrap.
                        TextOverflow = TextOverflow.Wrap,
                        TextWrapping = TextWrap.NoWrap 
                    }
                },
            },
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "white" },
        };
        nodes.Add(node);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Annotations/Appearance/AnnotationWithTextOverflow)

| TextOverflow | Wrapping | Image |
| -------- | -------- | -------- |
| Wrap | No Wrap | ![Blazor Diagram Without Text Wrap in TextWrapOverflow](../images/blazor-diagram-flowwrap-nowrap.png) |
| Wrap| Wrap | ![Blazor Diagram With Text Wrap in TextWrapOverflow](../images/blazor-diagram-flowwrap-wrap.png) |
| Wrap | WrapWithOverflow | ![Blazor Diagram Text Wrap with Overflow in TextWrapOverflow](../images/blazor-diagram-flowwrap-wrapwithoverflow.png) |
| Ellipsis | No Wrap | ![Blazor Diagram Without Text Wrap in TextEllipsisOverflow](../images/blazor-diagram-flowellipsis-nowrap.png) |
| Ellipsis| Wrap | ![Blazor Diagram With Text Wrap in TextEllipsisOverflow](../images/blazor-diagram-flowellipsis-wrap.png) |
| Ellipsis | WrapWithOverflow | ![Blazor Diagram Text Wrap with Overflow in TextEllipsisOverflow](../images/blazor-diagram-flowellipsis-wrapwithoverflow.png) |
| Clip | No Wrap | ![Blazor Diagram Without Text Wrap in TextClipOverflow](../images/blazor-diagram-flowclip-nowrap.png) |
| Clip| Wrap | ![Blazor Diagram With Text Wrap in TextClipOverflow](../images/blazor-diagram-flowclip-wrap.png) |
| Clip | WrapWithOverflow | ![Blazor Diagram Text Wrap with Overflow in TextClipOverflow](../images/blazor-diagram-flowclip-wrapwithoverflow.png) |

N>**Note :** All the customization over the overflow is also applicable to connector’s annotation.

## How to Customize the Appearance of an Annotation

You can change the font style of the annotations with the font specific properties such as FontSize, FontFamily, and Color. The following code explains how to customize the appearance of the annotation.

* The annotation’s [Bold](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.TextStyle.html#Syncfusion_Blazor_Diagram_TextStyle_Bold), [Italic](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.TextStyle.html#Syncfusion_Blazor_Diagram_TextStyle_Italic), and [TextDecoration](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.TextStyle.html#Syncfusion_Blazor_Diagram_TextStyle_TextDecoration) properties are used to style the annotation’s text.

* The annotation’s [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ShapeStyle.html#Syncfusion_Blazor_Diagram_ShapeStyle_Fill), [StrokeColor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ShapeStyle.html#Syncfusion_Blazor_Diagram_ShapeStyle_StrokeColor), and [StrokeWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ShapeStyle.html#Syncfusion_Blazor_Diagram_ShapeStyle_StrokeWidth) properties are used to define the background color and border color of the annotation and the [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ShapeStyle.html#Syncfusion_Blazor_Diagram_ShapeStyle_Opacity) property is used to define the transparency of the annotations.

* The [Visibility](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Annotation.html#Syncfusion_Blazor_Diagram_Annotation_Visibility) property of the annotation enables or disables the visibility of annotation.

The Fill, Border, and Opacity appearances of the text can also be customized with appearance specific properties of the annotation. The following code explains how to customize the appearance of the annotation.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes" />

@code
{
    // Defines diagram's node collection.
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        Node node = new Node()
        {
            ID = "node",
            Width = 100,
            Height = 100,
            OffsetX = 100,
            OffsetY = 100,
            // Sets the annotation for the node.
            Annotations = new DiagramObjectCollection<ShapeAnnotation>()
            {
                new ShapeAnnotation 
                {
                    Content = "Annotation Text",
                    Style = new TextStyle() 
                    {
                        // Sets the style for the annotation.
                        Color="black",
                        Bold = true,
                        Italic = true,
                        TextDecoration = TextDecoration.Underline,
                        FontSize = 12,
                        FontFamily = "TimesNewRoman"  
                    } 
                }
            },
            Style = new ShapeStyle() { Fill = "#6BA5D7", StrokeColor = "white" },
        };
        nodes.Add(node);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Annotations/Appearance/Appearance)

![Blazor Diagram Label with Custom Annotation](../images/blazor-diagram-label-with-custom-annotation.png)

## How to Update Annotation Font Style at Runtime

You can change the font style of the annotations with the font specific properties such as [FontSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.TextStyle.html#Syncfusion_Blazor_Diagram_TextStyle_FontSize), [FontFamily](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.TextStyle.html#Syncfusion_Blazor_Diagram_TextStyle_FontFamily), and [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.TextStyle.html#Syncfusion_Blazor_Diagram_TextStyle_Color). The following code explains how to update the font style of the annotation.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Buttons


<SfButton Content="UpdateStyle" OnClick="@UpdateStyle" />

<SfDiagramComponent @ref="@Diagram" Height="600px" Nodes="@nodes" />

@code
{
    // Reference of the diagram.
    SfDiagramComponent Diagram;

    // Defines diagram's node collection.
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        Node node = new Node()
        {
            ID = "node1",
            Width = 100,
            Height = 100,
            OffsetX = 100,
            OffsetY = 100,
            // Sets the annotation for the node.
            Annotations = new DiagramObjectCollection<ShapeAnnotation>()
            {
                new ShapeAnnotation
                {
                    Content = "Annotation Text",
                    Style = new TextStyle() 
                    {
                        Color = "black",
                        Bold = true,
                        Italic = true,
                        TextDecoration = TextDecoration.Underline,
                        FontSize = 12, 
                        FontFamily = "TimesNewRoman"
                    }
                }
            },
            Style = new ShapeStyle() { Fill = "#6BA5D7", StrokeColor = "white" },
        };
        nodes.Add(node);
    }

    public void UpdateStyle()
    {
        // Change the style of the annotation.
        Diagram.BeginUpdate();
        Diagram.Nodes[0].Annotations[0].Style.Bold = false;
        Diagram.Nodes[0].Annotations[0].Style.TextDecoration = TextDecoration.None;
        Diagram.Nodes[0].Annotations[0].Style.Color = "Red";
        Diagram.EndUpdateAsync();
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Annotations/Appearance/AnnotationStyleatRunTime)

## How to Edit Annotations at Runtime

The diagram provides support to edit an annotation at runtime, either programmatically or interactively. By default, the annotation is in view mode. However, it can be brought into edit mode in two ways.

* You can edit the annotation programmatically by using the [StartTextEdit](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_StartTextEdit_Syncfusion_Blazor_Diagram_IDiagramObject_System_String_) method.
* Also, you can edit the annotation interactively.
* By double-clicking the annotation.
* By selecting the item and pressing the F2 key.

Double-clicking any annotation will enable the editing and the node enables first annotation editing. When the focus of editor is lost, the annotation for the node is updated. 

## How to Set Read Only Mode for Annotations

The diagram allows you to create read-only annotations. You have to set the read-only property of annotation to enable or disable the [ReadOnly](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.AnnotationConstraints.html#Syncfusion_Blazor_Diagram_AnnotationConstraints_ReadOnly) constraints. The following code explains how to enable read-only mode.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes" />

@code
{
    // Defines diagram's node collection.
    DiagramObjectCollection<Node> nodes;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        Node node = new Node()
        {
            ID = "node",
            Width = 100,
            Height = 100,
            OffsetX = 100,
            OffsetY = 100,
            Annotations = new DiagramObjectCollection<ShapeAnnotation>()
            {
                new ShapeAnnotation 
                {
                    Content = "Annotation Text",
                    // Sets the constraints as Read only.           
                    Constraints = AnnotationConstraints.ReadOnly
                }
            },
            Style = new ShapeStyle() { Fill = "#6BA5D7", StrokeColor = "white" },
        };
        nodes.Add(node);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Annotations/Appearance/ReaonlyConstraints)

## How to Create Multiple Annotations

You can add any number of annotations to a node or connector. The following code example shows how to add multiple annotations to a node. 

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes" Connectors="@connectors" />

@code
{
    // Defines diagram's node collection.
    DiagramObjectCollection<Node> nodes;

    // Defines diagram's connector collection.
    DiagramObjectCollection<Connector> connectors;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        Node node = new Node()
        {
            ID = "node",
            Width = 100,
            Height = 100,
            OffsetX = 100,
            OffsetY = 100,
            Style = new ShapeStyle() { Fill = "#6BA5D7", StrokeColor = "white" },
            // Sets the multiple annotation for the node.
            Annotations = new DiagramObjectCollection<ShapeAnnotation>()
            {
                new ShapeAnnotation 
                {
                    Content = "Left",
                    Offset = new DiagramPoint(){ X = .12,Y = .1}
                },
                new ShapeAnnotation 
                {
                    Content = "Center",
                    Offset = new DiagramPoint(){ X = .5,Y = .5}
                },
                new ShapeAnnotation 
                {
                    Content = "Right",
                    Offset = new DiagramPoint(){ X = .82,Y = .9}
                }
            },
        };
        nodes.Add(node);
        connectors = new DiagramObjectCollection<Connector>();
        Connector connector = new Connector()
        {
            SourcePoint = new DiagramPoint() { X = 300, Y = 40 },
            TargetPoint = new DiagramPoint() { X = 400, Y = 160 },
            Type = ConnectorSegmentType.Orthogonal,
            Style = new TextStyle() { StrokeColor = "#6495ED" },
            Annotations = new DiagramObjectCollection<PathAnnotation>()
            {
                new PathAnnotation 
                { 
                    Content = "Offset as 0",
                    Offset = 0 
                },
                new PathAnnotation 
                { 
                    Content = "Offset as 0.5",
                    Offset = 0.5
                },
                new PathAnnotation 
                {
                    Content = "Offset as 1",
                    Offset = 1 
                },
            }
        };
        connectors.Add(connector);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Annotations/Appearance/MultipleAnnotation)

![Blazor Diagram with Multiple Annotations](../images/blazor-diagram-multiple-annotations.png)

N>* Type of the annotation’s property of the node or connector is ObservableCollection.
<br/>* Default value of the annotation will be null.
<br/>* All the same customization can be applicable for the annotations.
<br/>* Text Editing can be started only the first annotation of the annotation collection when you double click the node or connector.

## How to Control Annotation Constraints

[AnnotationConstraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.AnnotationConstraints.html) are used to enable or disable certain behaviors of the annotation. Constraints are provided as flagged enumerations, so that multiple behaviors can be enabled or disabled with bitwise operators.

AnnotationConstraints may have multiple behaviors as follows:

| Constraints | Usages |
|---|---|
| [ReadOnly](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.AnnotationConstraints.html#Syncfusion_Blazor_Diagram_AnnotationConstraints_ReadOnly) | Enables or disables whether the annotation to be read only or not. |
| [None](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.AnnotationConstraints.html#Syncfusion_Blazor_Diagram_AnnotationConstraints_None) | Disables all behaviors of Annotation. |
|[InheritReadOnly](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.AnnotationConstraints.html#Syncfusion_Blazor_Diagram_AnnotationConstraints_InheritReadOnly) |Enables or disables to inherit the ReadOnly option from the parent object.|

N> The default value is [InheritReadOnly](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.AnnotationConstraints.html#Syncfusion_Blazor_Diagram_AnnotationConstraints_InheritReadOnly) for constraints property of the annotation.

Refer to [Constraints](https://blazor.syncfusion.com/documentation/diagram/constraints) to learn about how to enable or disable the annotation constraints.

## How to Define Templates in Annotations
The Diagram provides support for templates in annotations. You can define HTML content at the tag level and specify the use of a template using the [UseTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Annotation.html#Syncfusion_Blazor_Diagram_Annotation_UseTemplate) property. If you need to define separate templates for each annotation, you can differentiate them by using the ID property.

The following code illustrates how to define a template for a node's annotation. Similarly, you can define templates for connectors.
```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Width="1000px" Height="1000px" Nodes="@nodes" Connectors="@connectors">
    <SnapSettings Constraints="SnapConstraints.None"></SnapSettings>
    <DiagramTemplates>
        <AnnotationTemplate>
            @if (context is Annotation annotation)
            {
                if (annotation.ID.Contains("Node"))
                {
                    string ID = annotation.ID + "TemplateContent";
                    <div id="@ID" class="profile-card" style="width:100%;height:100%;display:flex;align-items:center; gap:10px">
                        <svg xmlns="http://www.w3.org/2000/svg" height="48" width="48" viewBox="0 0 48 48">
                            <g>
                                <rect height="48" width="48" fill="#000000" rx="50%" ry="50%" />
                                <path id="path1" transform="rotate(0,24,24) translate(11.1417800784111,11) scale(0.8125,0.8125)  " fill="#FFFFFF" d="M15.827007,0C20.406003,0 24.346007,3.1960449 24.346007,9.2930298 24.346007,13.259033 22.542005,17.289001 20.180997,19.791992L20.193005,19.791992C19.287,22.627014 20.736997,23.299011 20.966,23.376038 25.997008,25.090027 31.651002,28.317993 31.651002,31.626038L31.651002,32 0,32 0,31.626038C8.034749E-08,28.414001 5.6260008,25.161011 10.421,23.376038 10.766993,23.244995 12.422999,22.317017 11.497004,19.817993 9.1220035,17.321045 7.3279971,13.275024 7.3279971,9.2930298 7.3279971,3.1960449 11.245006,0 15.827007,0z" />
                            </g>
                        </svg>
                        <div class="profile-name" style="font-size:12px;font-weight:bold;">Nicolas</div>
                    </div>
                }
                if (annotation.ID.Contains("Connector"))
                {
                    string ID = annotation.ID + "TemplateContent";
                    <div id="@ID" class="profile-card" style="width: 100%; height: 100%; display: flex; align-items: center; gap: 10px">
                        <svg xmlns="http://www.w3.org/2000/svg" height="48" width="48" viewBox="0 0 48 48">
                            <g>
                                <rect height="48" width="48" fill="#000000" rx="50%" ry="50%" />
                                <path id="path1" transform="rotate(0,24,24) translate(11,12.3588990783035) scale(0.812500048428777,0.812500048428777)  " fill="#FFFFFF" d="M21.576999,13.473151C26.414003,15.496185 30.259996,20.071221 31.999999,25.86432 15.448002,32.143386 0,25.86432 0,25.86432 1.7140042,20.158227 5.4690005,15.632174 10.202001,13.564156 11.338002,15.514191 13.444005,16.827195 15.862003,16.827195 18.317996,16.827195 20.455997,15.474182 21.576999,13.473151z M16.000003,0C19.617999,1.5323894E-07 22.550998,2.9330488 22.550998,6.5510722 22.550998,10.170134 19.617999,13.102144 16.000003,13.102144 12.381993,13.102144 9.4489957,10.170134 9.4489957,6.5510722 9.4489957,2.9330488 12.381993,1.5323894E-07 16.000003,0z" />
                            </g>
                        </svg>
                        <div class="profile-name" style="font-size:12px;font-weight:bold;">Nicolas</div>
                    </div>
                }
            }
        </AnnotationTemplate>
    </DiagramTemplates>
</SfDiagramComponent>
@code
{
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();

    protected override void OnInitialized()
    {
        Node node = new Node()
        {
            ID = "node1",
            Height = 100,
            Width = 100,
            OffsetX = 300,
            OffsetY = 300,
            Style = new ShapeStyle() { Fill = "#6BA5D7", StrokeColor = "black", Opacity = 1 },
            Annotations = new DiagramObjectCollection<ShapeAnnotation>()
            {
                 new ShapeAnnotation()
                 {
                     ID = "NodeAnnotation1",
                     UseTemplate = true,
                     Height = 75,
                     Width = 75,

                 },
            },
        };
        nodes.Add(node);

        Connector connector = new Connector()
        {
            ID = "connector1",
            SourcePoint = new DiagramPoint() { X = 450, Y = 250 },
            TargetPoint = new DiagramPoint() { X = 550, Y = 350 },
            Type = ConnectorSegmentType.Orthogonal,
            Annotations = new DiagramObjectCollection<PathAnnotation>()
            {
                 new PathAnnotation()
                 {
                     ID = "ConnectorAnnotation1",
                     UseTemplate = true,
                     Height = 50,
                     Width = 75,
                     Alignment = AnnotationAlignment.Before,
                     Offset = 0.3,
                     Displacement = new DiagramPoint(){X = 0, Y = -0.5}

                 },
            },
        };
        connectors.Add(connector);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Annotations/TemplateSupportforAnnotation)
![Blazor Diagram with Template Annotations](../images/TemplateSupportforAnnotation.png)

## See also

* [How to add or remove annotation constraints](../constraints#annotation-constraints)

* [How to add annotation for Node](./node-annotation)

* [How to add annotation for Connector](./connector-annotation)

* [How to Prevent Text Overflow and Display Excess Content on Hover in a Diagram](https://support.syncfusion.com/kb/article/18726/how-to-prevent-text-overflow-and-display-excess-content-on-hover-in-a-diagram)