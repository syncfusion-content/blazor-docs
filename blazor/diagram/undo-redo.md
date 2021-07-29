---
layout: post
title: Undo Redo in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Undo Redo in Syncfusion Blazor Diagram component and much more details.
platform: Blazor
control: Diagram
documentation: ug
---

# Undo Redo in Blazor Diagram Component

Diagram tracks the history of actions that are performed after initializing the diagram and provides support to reverse and restore those changes.

## Undo and redo

Diagram provides built-in support to track the changes that are made through interaction and through public APIs. The changes can be reverted or restored either through shortcut keys or through commands.

## Undo/redo through shortcut keys

Undo/redo commands can be executed through shortcut keys. Shortcut key for undo is Ctrl+Z and shortcut key for redo is Ctrl+Y.

## Undo/redo through public APIs

The server-side methods [`Undo`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SfDiagram.html#Syncfusion_Blazor_Diagrams_SfDiagram_Undo) and [`Redo`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SfDiagram.html#Syncfusion_Blazor_Diagrams_SfDiagram_Redo) help you to revert/restore the changes. The following code example illustrates how to undo/redo the changes through script.

```csharp
SfDiagram Diagram;

// Reverts the last action performed
this.Diagram.Undo();

// Restores the last undone action
this.Diagram.Redo();
```

When a change in the diagram is reverted or restored (undo/redo), the [`HistoryChange`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramModel.html#Syncfusion_Blazor_Diagrams_DiagramModel_HistoryChange) event gets triggered.

### Group multiple changes

History list allows to revert or restore multiple changes through a single undo/redo command. For example, revert/restore the fill color change of multiple elements at a time.

The server-side method [`StartGroupAction`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.History.html#Syncfusion_Blazor_Diagrams_History_StartGroupAction) is used  to notify the diagram to start grouping the changes. The server-side method [`EndGroupAction`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.History.html#Syncfusion_Blazor_Diagrams_History_EndGroupAction) is used to notify to stop grouping the changes. The following code illustrates how to undo/redo to change of multiple elements at a time.

```csharp
SfDiagram Diagram;

//Starts grouping the changes
this.Diagram.StartGroupAction();

//Ends grouping the changes
this.Diagram.EndGroupAction();
```

### Track custom changes

Diagram provides options to track the changes that are made to custom properties. For example, in case of an employee relationship diagram, track the changes in the employee information. The `HistoryList` of the diagram enables you to track such changes.
The following example illustrates how to track such custom property changes.

Before changing the employee information, save the existing information to history list by using the server-side method push of `HistoryList`.
The history list [`CanLog`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.History.html#Syncfusion_Blazor_Diagrams_History_CanLog) method can be used which takes a history entry as argument and returns whether the specific entry can be added or not.

The following code example illustrates how to save the existing property values.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

@* Initialize Diagram *@
<SfDiagram Height="600" @ref="@diagram" Nodes="@NodeCollection">
</SfDiagram>

@code{
    //Reference of diagram
    SfDiagram diagram;
    public string Height { get; set; } = "500px";
    //Initialize node collection with node
    ObservableCollection<DiagramNode> NodeCollection = new ObservableCollection<DiagramNode>()
    {
         new DiagramNode()
         {
             //Unique id of the node
             Id="NewIdea",
             //Size of the node
             Height=100,
             Width=100,
             //Position of the node
             OffsetX=100,
             OffsetY=100,
             //Customize the appearance of the node
             Style= new NodeShapeStyle(){Fill="#6BA5D7",StrokeColor="White"},
             //Enable shadow constraint of the node
             Constraints=NodeConstraints.Default|NodeConstraints.Shadow,
             //Initialize annotation collection with annotation
             Annotations=new ObservableCollection<DiagramNodeAnnotation>()
             {
                 new DiagramNodeAnnotation()
                 {
                     Content="node1",
                     //Customize the appearance of the annotations
                     Style=new AnnotationStyle()
                     {
                         Color="White",
                         StrokeColor="None"
                     },
                 }
             },
             //Customizes the appearance of the node shadow style
             Shadow=new DiagramShadow()
             {
                 Angle=50,
                 Opacity=0.8,
                 Distance=9
             }
         }
    };

    public void TrackCustomActions()
    {
        //Creates a custom entry
        HistoryEntry historyEntry = new HistoryEntry() { UndoObject = diagram.Nodes[0] };
        // adds that to history list
        diagram.AddHistoryEntry(historyEntry);
        diagram.DataBind();
    }
     }
```

### Track undo/redo actions

The [`GetHistoryStack`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SfDiagram.html#Syncfusion_Blazor_Diagrams_SfDiagram_GetHistoryStack_System_Boolean_) method is used to get the collection of undo and redo actions which should be performed in the diagram.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

@* Initialize Diagram *@
<SfDiagram Height="1000" @ref="@diagram" Nodes="@NodeCollection">
</SfDiagram>

@code
 {
    //Get the collection of undostack objects when passing true to GetHistoryStack() method.
    List<HistoryEntry> undostack = await diagram.GetHistoryStack(true);

    //Get the collection of redo stack objects when passing true to GetHistoryStack() method.
    List<HistoryEntry> redostack = await diagram.GetHistoryStack(false);
 }
```

## History change event

The [`HistoryChange`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramModel.html#Syncfusion_Blazor_Diagrams_DiagramModel_HistoryChange) event triggers, whenever the interaction of the node and connector is take place.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

@* Initialize Diagram *@
<SfDiagram  Height="600" >
</SfDiagram>

@code
 {
public void Onhistorychange(IBlazorHistoryChangeArgs args)
    {
        //causes of history change
        var cause = args.Cause;
    }
 }
```