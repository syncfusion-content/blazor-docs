---
layout: post
title: Ruler settings in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about the Ruler feature in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Ruler Settings in Blazor Diagram Component

The Ruler provides horizontal and vertical guides for measuring in the Diagram control. It can be used to measure diagram objects, indicate positions, and align diagram elements, making it especially useful in creating scale models.

## How to Add Rulers to the Diagram Component

The [RulerSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_RulerSettings) property of [SfDiagramComponent](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html) is used to control the visibility and appearance of the ruler in the diagram. The [HorizontalRuler](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.RulerSettings.html#Syncfusion_Blazor_Diagram_RulerSettings_HorizontalRuler) and [VerticalRuler](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.RulerSettings.html#Syncfusion_Blazor_Diagram_RulerSettings_VerticalRuler) properties of `RulerSettings` are used to define and customize the horizontal ruler and vertical ruler in the diagram canvas.

The following code demonstrates how to add a ruler to the diagram.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" >
	<RulerSettings>
        <HorizontalRuler>
          </HorizontalRuler>
        <VerticalRuler >
          </VerticalRuler>
    </RulerSettings>
</SfDiagramComponent>

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VjVoiXXlTWQuPiRI?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Ruler](images/Ruler.png)" %}

## How to Customize the Ruler

The `HorizontalRuler` and `VerticalRuler` properties `RulerSettings` class are used to customize the appearance of the rulers in the diagram. The following properties are used to customize the appearance of both the horizontal and vertical rulers.

* [Interval](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramRuler.html#Syncfusion_Blazor_Diagram_DiagramRuler_Interval) - This property allows to define the number of intervals to be present on each segment of both horizontal and vertical rulers.
* [IsVisible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramRuler.html#Syncfusion_Blazor_Diagram_DiagramRuler_IsVisible) - This property determines whether the horizontal and vertical rulers are displayed in the diagram. This can be useful for toggling rulers on and off depending on your needs.
* [TickAlignment](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramRuler.html#Syncfusion_Blazor_Diagram_DiagramRuler_TickAlignment) - This property controls the placement of the tick marks (also called hash marks) on the ruler. Typically choose to have them positioned on the left or right for the vertical ruler and on the top or bottom for the horizontal ruler.
* [MarkerColor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramRuler.html#Syncfusion_Blazor_Diagram_DiagramRuler_MarkerColor) - This property defines the color of the marker line, also known as the cursor guide. This line appears in the diagram and aligns with the ruler, visually indicating the current position of your cursor.

The code below demonstrates how the diagram ruler can be customized.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent @ref="@_diagram" Height="600px" >
	<RulerSettings>
        <HorizontalRuler  IsVisible="true" Interval="@_rulerInterval" 
                            TickAlignment="@_rulerTickAlignment" MarkerColor="@_rulerMarkerColor">
        </HorizontalRuler>
        <VerticalRuler IsVisible="false"  Interval="@_rulerInterval" 
                        TickAlignment="@_rulerTickAlignment" MarkerColor="@_rulerMarkerColor">
        </VerticalRuler>
    </RulerSettings>
</SfDiagramComponent>

@code
{
    //Reference to diagram.
    private SfDiagramComponent _diagram;
    //Defining Ruler Interval of Rulers
    private int _rulerInterval = 20;
    //Defining Tick Alignment of Rulers
    private TickAlignment _rulerTickAlignment = TickAlignment.RightAndBottom;
    //Defining Marker color of Rulers
    private string _rulerMarkerColor = "green";

}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rZBostNPTCvJUslQ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Ruler/Ruler.razor)

