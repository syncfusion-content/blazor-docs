---
layout: post
title: Phase in Blazor Diagram Component | Syncfusion
description: Check out and learn here all about Phase support in Syncfusion Blazor Diagram component, its elements and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Phase in Blazor Diagram Component

 The `Phase` is the subprocess which will split each lane as horizontally or vertically based on the swimlane orientation. The multiple phases can be added to the swimlane.

## Create an empty Phase

You can create the `Phase` and add into the `Phases` collection of the Swimlane.

>Note: For Horizontal Swimlane, you must set the `Width` of the Phase. For Vertical Swimlane, you must set the `Height` of the Phase.

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

You can download a complete working sample from [GitHub]().


## Dynamically add phase to Swimlane

 You can add a phase at runtime by using the `Add` and `Remove` methods of the `Swimlane.Phases` collection. The following code example explains how to add and remove phases at run time.

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

You can download a complete working sample from [GitHub]().

## Create the Phase Header and Header customization

* The `Header` property of Phase allows you to describe the phase textually and customize the appearance of the description.
* The size of the Phase header can be controlled by using the header's `Width` and `Height` properties.
* The appearance of the Phase header can be customized by using the `Style` property.

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

You can download a complete working sample from [GitHub]().

The Phase header annotations also support templates. You can define HTML content at the tag level and specify the use of a template with the [UseTemplate]() property. If you want to define a separate template for each phase, differentiate the annotation by using the ID property.

The following code example explains how to define a Phase header annotaiton template.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Swimlanes="@SwimlaneCollections">
    <DiagramTemplates>
        <AnnotationTemplate>
            @if (context is Annotation annotation)
            {
                if (annotation.ID == "Phase 1")
                {
                    string ID = annotation.ID + "TemplateContent";
                    <div id="@ID" class="profile-card" style="width:100%;height:100%;display:flex;align-items:center; gap:10px">
                        <svg xmlns="http://www.w3.org/2000/svg" height="24" width="24" viewBox="0 0 24 24">
                            <g>
                                <ellipse cy="12" cx="12" ry="12" rx="12" fill="#000000" />
                                <path id="path1" transform="rotate(0,12,12) translate(6.06543695926666,6) scale(0.375,0.375)  " fill="#FFFFFF" d="M15.827007,0C20.406003,0 24.346007,3.1960449 24.346007,9.2930298 24.346007,13.259033 22.542005,17.289001 20.180997,19.791992L20.193005,19.791992C19.287,22.627014 20.736997,23.299011 20.966,23.376038 25.997008,25.090027 31.651002,28.317993 31.651002,31.626038L31.651002,32 0,32 0,31.626038C8.034749E-08,28.414001 5.6260008,25.161011 10.421,23.376038 10.766993,23.244995 12.422999,22.317017 11.497004,19.817993 9.1220035,17.321045 7.3279971,13.275024 7.3279971,9.2930298 7.3279971,3.1960449 11.245006,0 15.827007,0z" />
                            </g>
                        </svg>
                        <div class="profile-name" style="font-size:12px;font-weight:bold;">Users</div>
                    </div>
                }              
            }
        </AnnotationTemplate>
    </DiagramTemplates>
</SfDiagramComponent>

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
                            Annotation = new ShapeAnnotation(){ ID="Phase 1", 
                                Content = "Phase 1",
                                UseTemplate = true,
                                Height = 50,
                                Width = 75,
                            },
                            Height = 30,
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
![Phase Header](Swimlane-images/Swimlane_Phase_Header_Template.PNG).

You can download a complete working sample from [GitHub]().

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

