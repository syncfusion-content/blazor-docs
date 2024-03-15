---
layout: post
title: Phase in Blazor Diagram Component | Syncfusion
description: Check out and learn here all about Phase support in Syncfusion Blazor Diagram component, its elements and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Phase in Blazor Diagram Component

 The [Phase](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Phase.html) is the subprocess which will split each lane as horizontally or vertically based on the swimlane orientation. The multiple phases can be added to the swimlane.

## Create an empty Phase

You can create the [Phase](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Phase.html) and add into the [Phases](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Swimlane.html#Syncfusion_Blazor_Diagram_Swimlane_Phases) collection of the Swimlane.

>Note: For Horizontal Swimlane, you must set the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SwimlaneChild.html#Syncfusion_Blazor_Diagram_SwimlaneChild_Width) of the Phase. For Vertical Swimlane, you must set the [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SwimlaneChild.html#Syncfusion_Blazor_Diagram_SwimlaneChild_Height) of the Phase.

The following code example explains how to add a phase at the swimlane.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Swimlanes="@SwimlaneCollections" />

@code
{
    //Define diagram's swimlane collection.
    DiagramObjectCollection<Swimlane> SwimlaneCollections = new DiagramObjectCollection<Swimlane>();

    protected override void OnInitialized()
    {
        // A swimlane is created and stored in the swimlanes collection.
        Swimlane swimlane = new Swimlane()
            {
                Header = new SwimlaneHeader()
                {
                    Annotation = new ShapeAnnotation()
                    {
                        Content = "SALES PROCESS FLOW CHART"
                    },
                    Height = 50,
                },
                OffsetX = 400,
                OffsetY = 200,
                Height = 150,
                Width = 450,
                Phases = new DiagramObjectCollection<Phase>()
                {
                    new Phase()
                    {
                        Width = 450,
                        Header = new SwimlaneHeader()
                        {
                            Annotation = new ShapeAnnotation(){Content = "Phase 1"},
                            Height = 30
                        }
                    }
                }
            };
        // Add swimlane.
        SwimlaneCollections.Add(swimlane);
    }
}
```

![Phse](Swimlane-images/Swimlane_Phase.PNG).

You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Swimlanes/Phase/PhaseCreation).


## Dynamically add phase to Swimlane

 You can add a phase at runtime by using the `Add` and `Remove` methods of the [Swimlane.Phases](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Swimlane.html#Syncfusion_Blazor_Diagram_Swimlane_Phases) collection. The following code example explains how to add and remove phases at run time.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Buttons

<SfButton Content="Add Phase" OnClick="@AddPhase" />
<SfButton Content="Remove Phase" OnClick="@RemovePhase" />
<SfDiagramComponent Height="600px" Swimlanes="@SwimlaneCollections" />

@code
{
    //Define diagram's swimlane collection.
    DiagramObjectCollection<Swimlane> SwimlaneCollections = new DiagramObjectCollection<Swimlane>();

    protected override void OnInitialized()
    {
        // A swimlane is created and stored in the swimlanes collection.
        Swimlane swimlane = new Swimlane()
            {
                Header = new SwimlaneHeader()
                {
                    Annotation = new ShapeAnnotation()
                    {
                        Content = "SALES PROCESS FLOW CHART"
                    },
                    Height = 50,
                },
                OffsetX = 400,
                OffsetY = 200,
                Height = 150,
                Width = 450,
                Phases = new DiagramObjectCollection<Phase>()
                {
                    new Phase()
                    {
                        Width = 450,
                        Header = new SwimlaneHeader()
                        {
                            Annotation = new ShapeAnnotation(){Content = "Phase 1"},
                            Height = 30
                        }
                    }
                }
            };
        // Add swimlane.
        SwimlaneCollections.Add(swimlane);
    }

    private void AddPhase()
    {
        Swimlane swimlane = SwimlaneCollections[0];
        Phase newPhase = new Phase()
            {
                Width = 100,
                Header = new SwimlaneHeader()
                {
                    Annotation = new ShapeAnnotation() { Content = "Phase " + (swimlane.Phases.Count + 1) },
                    Height = 30
                }
            };
        swimlane.Phases.Add(newPhase);
    }

    private void RemovePhase()
    {
        Swimlane swimlane = SwimlaneCollections[0];
        if (swimlane.Phases.Count > 1)
            swimlane.Phases.RemoveAt(swimlane.Phases.Count - 1);
    }
}
```

![Phase Add Remove](Swimlane-images/Phase_Add_Remove.gif)

You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Swimlanes/Phase/AddRemovePhaseAtRuntime).

## Create the Phase Header and Header customization

* The [Header](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Phase.html#Syncfusion_Blazor_Diagram_Phase_Header) property of Phase allows you to describe the phase textually and customize the appearance of the description.
* The size of the Phase header can be controlled by using the header's [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SwimlaneChild.html#Syncfusion_Blazor_Diagram_SwimlaneChild_Width) and [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SwimlaneChild.html#Syncfusion_Blazor_Diagram_SwimlaneChild_Height) properties.
* The appearance of the Phase header can be customized by using the [Style](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SwimlaneHeader.html#Syncfusion_Blazor_Diagram_SwimlaneHeader_Style) property.

The following code example explains how to define a Phase header and its customization.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Swimlanes="@SwimlaneCollections" />

@code
{
    //Define diagram's swimlane collection.
    DiagramObjectCollection<Swimlane> SwimlaneCollections = new DiagramObjectCollection<Swimlane>();

    protected override void OnInitialized()
    {
        // A swimlane is created and stored in the swimlanes collection.
        Swimlane swimlane = new Swimlane()
            {
                Header = new SwimlaneHeader()
                {
                    Annotation = new ShapeAnnotation()
                    {
                        Content = "SALES PROCESS FLOW CHART"
                    },
                    Height = 50,
                },
                OffsetX = 400,
                OffsetY = 200,
                Height = 150,
                Width = 450,
                Phases = new DiagramObjectCollection<Phase>()
                {
                    new Phase()
                    {
                        Width = 450,
                        Header = new SwimlaneHeader()
                        {
                            Annotation = new ShapeAnnotation(){Content = "Phase 1", Style = new TextStyle(){ Color = "White", TextDecoration = TextDecoration.Underline, Italic = true, Bold = true} },
                            Height = 30
                        },
                        Style = new TextStyle(){Fill = "Teal"},
                    }
                }
            };
        // Add swimlane.
        SwimlaneCollections.Add(swimlane);
    }
}
```
![Phase Header](Swimlane-images/Swimlane_Phase_Header.PNG).

You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Swimlanes/Phase/PhaseHeader).

## Header Selection and Resize

 * You can select the individual phase header by clicking on the header twice. On the first click, you can select the respective phase. 

 * You can resize the individual phase header. While resizing the phase, it will maintain 20px distances from Lane children.

  * When a element is resized, the [SizeChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_SizeChanging) and [SizeChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_SizeChanged) events get triggered.

 The following image shows how to select and resize the phase header.

![Header Select and Resize](Swimlane-images/Header_Selection_Resize.gif).

## Phase header editing

The diagram provides support for editing phase headers at runtime. You can achieve header editing by using the double-click event. Double-clicking the header label enables the editing of that specific header. 

The following image shows how to edit the phase header.

![Phase Header Editing](Swimlane-images/Phase_Header_Edit.gif)


## Phase interaction

### Select

Phase can be selected by clicking (tapping) the header of the phase.

### Resizing

* The phase can be resized by using its selector.
* You must click the phase header to enable the phase selection.
* Once the phase can be resized, the lane size will be updated automatically.

