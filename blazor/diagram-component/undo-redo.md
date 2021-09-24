---
layout: post
title: Undo redo in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about undo redo support in Syncfusion Blazor Diagram component and much more details.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Undo Redo support in Blazor Diagram Component

Diagram tracks the history of actions that are performed after initializing the diagram and provides support to reverse and restore those changes.

## Undo and redo

Diagram provides built-in support to track the changes that are made through interaction and through public APIs. The changes can be reverted or restored either through shortcut keys or through commands.

## Undo/redo through shortcut keys

Undo/redo commands can be executed through shortcut keys. Shortcut key for undo is Ctrl+Z and shortcut key for redo is Ctrl+Y.

## Undo/redo through public APIs

The `Undo` and `Redo` methods helps you to revert/restore the changes. The following code example illustrates how to undo/redo the changes through code.

```cshtml
SfDiagramComponent Diagram;

// Reverts the last action performed
diagram.Undo();

// Restores the last undone action
diagram.Redo();
```

When a change in the diagram is reverted or restored (undo/redo), the `HistoryChanged` event gets triggered.

### Group multiple changes

History list allows to revert or restore multiple changes through a single undo/redo command. For example, revert/restore the fill color change of multiple elements at a time.

`StartGroupAction` is used to notify the diagram to start grouping the changes. `EndGroupAction` is used to notify to stop grouping the changes. The following code illustrates how to undo/redo to change of multiple elements at a time.

```cshtml
SfDiagramComponent diagram;

//Starts grouping the changes
diagram.StartGroupAction();

//Ends grouping the changes
diagram.EndGroupAction();
```

## History change event

* While interacting the elements in the diagram, this event can be used to do the customization.
* When interacting the node or connector, the entries getting added to the history list to trigger this event.

The `HistoryChangedEventArgs` notifies while the changes occurs during undo/redo process.

```cshtml
@using Syncfusion.Blazor.Diagram

@* Initialize Diagram *@
<SfDiagramComponent @ref="@diagram" Height="600" HistoryChanged="@Onhistorychange">
</SfDiagramComponent>

@code
 {
    SfDiagramComponent diagram;

    public void Onhistorychange(HistoryChangedEventArgs args)
    {
        //causes of history change
        HistoryChangedAction ActionTrigger = args.ActionTrigger;
    }
}
```

## Track custom entry

Diagram provides options to track the changes that are made to custom properties. The following example illustrates how to track such custom property changes.

```cshtml
@using Syncfusion.Blazor.Diagram

<input value="CustomEntry" type="button" @onclick="@OnCustomEntry" name="CustomEntry" />

@* Initialize Diagram *@
<SfDiagramComponent @ref="@diagram" Height="600" Nodes="@nodes">    
</SfDiagramComponent>

@code
 {
    SfDiagramComponent diagram;
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        Dictionary<string, object> NodeInfo = new Dictionary<string, object>();
        NodeInfo.Add("nodeInfo", "Central Node");
        // A node is created and stored in the nodes collection.
        Node node = new Node()
        {
            ID = "node1",
            // Position of the node
            OffsetX = 250,
            OffsetY = 250,
            // Size of the node
            Width = 100,
            Height = 100,
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "white" },
            AdditionalInfo = NodeInfo
        };
        // Add node
        nodes.Add(node);
    }

    private void OnCustomEntry()
    {
        HistoryEntry entry = new HistoryEntry();
        entry.UndoObject = diagram.Nodes[0];
        diagram.AddHistoryEntry(entry);
    }
}
```

### HistoryAdding

HistoryAdding in the DiagramHistoryManager, which takes a history entry as argument and returns whether the specific entry can be added or not.

```cshtml
@using Syncfusion.Blazor.Diagram

@* Initialize Diagram *@
<SfDiagramComponent @ref="@diagram" Height="600" Nodes="@nodes">
    <DiagramHistoryManager HistoryAdding="@OnHistoryAdding"/>
</SfDiagramComponent>

@code
 {
    SfDiagramComponent diagram;
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        // A node is created and stored in the nodes collection.
        Node node = new Node()
        {
            ID = "node1",
            // Position of the node
            OffsetX = 250,
            OffsetY = 250,
            // Size of the node
            Width = 100,
            Height = 100,
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "white" }
        };
        // Add node
        nodes.Add(node);
    }

    private void OnHistoryAdding(HistoryAddingEventArgs entry)
    {
        // Sets true to cancel undo/redo action.
        entry.Cancel = true;
    }
}
```

### Custom undo redo
Undo method in DiagramHistoryManager get called when the custom entry is in undo stage and Redo method in DiagramHistoryManager get called when the custom entry is in redo stage.

```cshtml
@using Syncfusion.Blazor.Diagram

<input value="CustomEntry" type="button" @onclick="@OnCustomEntry" name="CustomEntry" />

@* Initialize Diagram *@
<SfDiagramComponent @ref="@diagram" Height="600" Nodes="@nodes">
    <DiagramHistoryManager Undo="@onCustomUndo" Redo="@onCustomRedo"/>
</SfDiagramComponent>

@code
{
    SfDiagramComponent diagram;
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    string EventValue = string.Empty;

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        // A node is created and stored in the nodes collection.
        Node node = new Node()
        {
            ID = "node1",
            // Position of the node
            OffsetX = 250,
            OffsetY = 250,
            // Size of the node
            Width = 100,
            Height = 100,
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "white" }
        };
        // Add node
        nodes.Add(node);
    }

    private void OnCustomEntry()
    {
        HistoryEntry entry = new HistoryEntry();
        entry.UndoObject = diagram.Nodes[0];
        diagram.AddHistoryEntry(entry);
    }

    private void onCustomUndo(HistoryEntryBase entry)
    {
        (entry.RedoObject) = entry.UndoObject.Clone() as Node;
        (entry.UndoObject as Node).AdditionalInfo[(entry.UndoObject as Node).ID] = "Start";
        EventValue += "UndoObject:" + (entry.UndoObject as Node).AdditionalInfo[(entry.UndoObject as Node).ID];
    }

    private void onCustomRedo(HistoryEntryBase entry)
    {
        EventValue += "RedoObject:" + (entry.RedoObject as Node).AdditionalInfo[(entry.RedoObject as Node).ID];
        var current = entry.UndoObject.Clone() as Node;
        (entry.UndoObject as Node).AdditionalInfo[(entry.UndoObject as Node).ID] = "Description";
        entry.RedoObject = current;
    }
}
```