---
layout: post
title: Commands in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Commands in Syncfusion Blazor Diagram component and much more details.
platform: Blazor
control: Diagram
documentation: ug
---

# Commands in Blazor Diagram Component

<!-- markdownlint-disable MD010 -->

There are several commands available in the diagram as follows.

* Alignment commands
* Distribute commands
* Sizing commands
* Clipboard commands
* Grouping commands
* Z-order commands
* Zoom commands
* Nudge commands
* FitToPage commands
* Undo/Redo commands

## Alignment commands

Alignment commands enable you to align the selected or defined objects such as nodes and connectors with respect to the selection boundary. Refer to `Align` commands which shows how to use align methods in the diagram.

 <!-- markdownlint-disable MD033 -->

| Parameters | Description |
|:------------| :------ |
|[`Alignment Options`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.AlignmentOptions.html) | Defines the specific direction, with respect to which the objects to be aligned. The accepted values of the argument "alignment options" are as follows. <br /> Left - Aligns all the selected objects at the left of the selection boundary. <br /> Right - Aligns all the selected objects at the right of the selection boundary. <br /> Center - Aligns all the selected objects at the center of the selection boundary. <br /> Top - Aligns all the selected objects at the top of the selection boundary. <br /> Bottom - Aligns all the selected objects at the bottom of the selection boundary. <br /> Middle - Aligns all the selected objects at the middle of the selection boundary.|
| Objects | Defines the objects to be aligned. This is an optional parameter. By default, all the nodes and connectors in the selected region of the diagram gets aligned. |
[`Alignment Mode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.AlignmentMode.html)  | Defines the specific mode, with respect to which the objects to be aligned. This is an optional parameter. The default alignment mode is `Object`. <br /> The accepted values of the argument "alignment mode" are as follows. <br /> Object - Aligns the objects based on the first object in the selected list. <br /> Selector - Aligns the objects based on the selection boundary. | 
<!-- markdownlint-enable MD033 -->

The following code example illustrates how to align all the selected objects at the left side of the selection boundary.

```cshtml
@using Syncfusion.Blazor.Diagrams

<SfDiagram @ref="@diagram" Height="600px"/>

@code
{
    //Reference to diagram
    SfDiagram diagram;

    private void Align()
    {
        //Aligns the selected items to left
        diagram.Align(AlignmentOptions.Left, null, AlignmentMode.Selector);
    }
}
```

## Distribute

The [`Distribute`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SfDiagram.html#Syncfusion_Blazor_Diagrams_SfDiagram_Distribute_Syncfusion_Blazor_Diagrams_DistributeOptions_System_Object_) commands enable to place the selected objects on the page at equal intervals from each other. The selected objects are equally spaced within the selection boundary.

The factor to distribute the shapes `DistributeOptions` are listed as follows:

* RightToLeft: Distributes the objects based on the distance between the right and left sides of the adjacent objects.
* Left: Distributes the objects based on the distance between the left sides of the adjacent objects.
* Right: Distributes the objects based on the distance between the right sides of the adjacent objects.
* Center: Distributes the objects based on the distance between the center of the adjacent objects.
* BottomToTop: Distributes the objects based on the distance between the bottom and top sides of the adjacent objects.
* Top: Distributes the objects based on the distance between the top sides of the adjacent objects.
* Bottom: Distributes the objects based on the distance between the bottom sides of the adjacent objects.
* Middle: Distributes the objects based on the distance between the vertical center of the adjacent objects.

The following code example illustrates how to execute the space commands.

```csharp

@using Syncfusion.Blazor.Diagrams

<SfDiagram @ref="@diagram" Height="600px"/>

@code
{
    //Reference to diagram
    SfDiagram diagram;

    private void Distribute()
    {
        //Distribute the elements in equal spacing
        diagram.Distribute(DistributeOptions.RightToLeft);
    }
}
```

## Sizing Commands

Sizing [`SameSize`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SfDiagram.html#Syncfusion_Blazor_Diagrams_SfDiagram_SameSize_Syncfusion_Blazor_Diagrams_SizingOptions_System_Object_) commands enable to equally size the selected nodes with respect to the first selected object.

`SizingOptions` are as follows:

* Width: Scales the width of the selected objects.
* Height: Scales the height of the selected objects.
* Size: Scales the selected objects both vertically and horizontally.

The following code example illustrates how to execute the size commands.

```cshtml
@using Syncfusion.Blazor.Diagrams
<SfDiagram @ref="@diagram" Height="600px"/>

@code
{
    //Reference to diagram
    SfDiagram diagram;

    private void SameSize()
    {
        //Changing the selected nodes to same size
        SizingOptions sizingOptions = SizingOptions.Size;
        diagram.SameSize(sizingOptions);
    }
}
```

## Clipboard

Clipboard commands are used to cut, copy, or paste the selected elements. Refer to the following link which shows how to use clipboard methods in the diagram.

* Cuts the selected elements from the diagram to the diagram’s clipboard, [`Cut`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SfDiagram.html#Syncfusion_Blazor_Diagrams_SfDiagram_Cut).

* Copies the selected elements from the diagram to the diagram’s clipboard, [`Copy`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SfDiagram.html#Syncfusion_Blazor_Diagrams_SfDiagram_Copy).

* Pastes the diagram’s clipboard data (nodes/connectors) into the diagram, [`Paste`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SfDiagram.html#Syncfusion_Blazor_Diagrams_SfDiagram_Paste_System_Object_).

The following code illustrates how to execute the clipboard commands.

```cshtml
@using Syncfusion.Blazor.Diagrams
<SfDiagram @ref="@diagram" Height="600px">
</SfDiagram>

@code
{
    //Reference to diagram
    SfDiagram diagram;

    private void Cut()
    {
        //copies the selected nodes
        this.diagram.Cut();
    }

    private void Copy()
    {
        //copies the selected nodes
        this.diagram.Copy();
    }

    private void Paste()
    {
        //pastes the copied objects
        this.diagram.Paste();
    }
}
```

## Grouping

**Grouping commands** are used to group/ungroup the selected elements on the diagram. Refer to the following link which shows how to use grouping commands in the diagram.

[`Group`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SfDiagram.html#Syncfusion_Blazor_Diagrams_SfDiagram_Group) the selected nodes and connectors in the diagram.

[`Ungroup`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SfDiagram.html#Syncfusion_Blazor_Diagrams_SfDiagram_UnGroup) the selected nodes and connectors in the diagram.

The following code illustrates how to execute the grouping commands.

```cshtml
@using Syncfusion.Blazor.Diagrams
<SfDiagram @ref="@diagram" Height="600px">
</SfDiagram>

@code
{
    //Reference to diagram
    SfDiagram diagram;

   private void SelectAll()
    {
        //Selects the nodes
        this.diagram.SelectAll();
    }
    private void Group()
    {
        //Groups the selected elements.
        this.diagram.Group();
    }
}
```

## Z-Order command

**Z-Order commands** enable you to visually arrange the selected objects such as nodes and connectors on the page.

## BringToFront command

The [`BringToFront`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SfDiagram.html#Syncfusion_Blazor_Diagrams_SfDiagram_BringToFront) command visually brings the selected element to front over all the other overlapped elements. The following code illustrates how to execute the `BringToFront` command.

```cshtml
@using Syncfusion.Blazor.Diagrams
<SfDiagram @ref="@diagram" Height="600px">
</SfDiagram>

@code
{
    //Reference to diagram
    SfDiagram diagram;

    private void BringToFront()
    {
        //Brings to front the selected node.
        this.diagram.BringToFront();
    }
}
```

## SendToBack command

The [`SendToBack`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SfDiagram.html#Syncfusion_Blazor_Diagrams_SfDiagram_SendToBack) command visually moves the selected element behind all the other overlapped elements. The following code illustrates how to execute the `SendToBack` command.

```cshtml
@using Syncfusion.Blazor.Diagrams
<SfDiagram @ref="@diagram" Height="600px">
</SfDiagram>

@code
{
    //Reference to diagram
    SfDiagram diagram;

    private void SendToBack()
    {
        //Sends to front the selected node.
        this.diagram.SendToBack();
    }
}
```

## MoveForward command

The [`MoveForward`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SfDiagram.html#Syncfusion_Blazor_Diagrams_SfDiagram_MoveForward) command visually moves the selected element over the nearest overlapping element. The following code illustrates how to execute the `MoveForward` command.

```cshtml
@using Syncfusion.Blazor.Diagrams
<SfDiagram @ref="@diagram" Height="600px">
</SfDiagram>

@code
{
    //Reference to diagram
    SfDiagram diagram;

    private void MoveForward()
    {
        //move to Forward the selected node.
        this.diagram.MoveForward();
    }
}
```

## SendBackward command

The [`SendBackward`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SfDiagram.html#Syncfusion_Blazor_Diagrams_SfDiagram_SendBackward) command visually moves the selected element behind the underlying element. The following code illustrates how to execute the `SendBackward` command.

```cshtml
@using Syncfusion.Blazor.Diagrams
<SfDiagram @ref="@diagram" Height="600px">
</SfDiagram>

@code
{
    //Reference to diagram
    SfDiagram diagram;

    private void SendBackward()
    {
        //send to Forward the selected node.
        this.diagram.SendBackward();
    }
}
```

## Zoom

The [`Zoom`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SfDiagram.html#Syncfusion_Blazor_Diagrams_SfDiagram_Zoom_System_Double_Syncfusion_Blazor_Diagrams_PointModel_) command is used to zoom-in and zoom-out the diagram view.

The following code illustrates how to zoom-in/zoom out the diagram.

```cshtml
@using Syncfusion.Blazor.Diagrams
<SfDiagram @ref="@diagram" Height="600px">
</SfDiagram>

@code
{
    //Reference to diagram
    SfDiagram diagram;

    private void Zoom()
    {
        // Sets the ZoomFactor
        //Defines the FocusPoint to zoom the Diagram with respect to any point
        //When you do not set focus point, zooming is performed with reference to the center of current Diagram view.
        this.diagram.Zoom(1.2, new PointModel() { X = 100, Y = 100 });
    }
}
```

## Nudge command

The [`Nudge`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SfDiagram.html#Syncfusion_Blazor_Diagrams_SfDiagram_Nudge_Syncfusion_Blazor_Diagrams_NudgeDirection_System_Nullable_System_Double__System_Nullable_System_Double__) commands move the selected elements towards up, down, left, or right by 1 pixel.

`NudgeDirection` nudge command moves the selected elements towards the specified direction by 1 pixel, by default.

The accepted values of the argument "direction" are as follows:

* Up: Moves the selected elements towards up by the specified delta value.
* Down: Moves the selected elements towards down by the specified delta value.
* Left: Moves the selected elements towards left by the specified delta value.
* Right: Moves the selected elements towards right by the specified delta value.

The following code illustrates how to execute nudge command.

```cshtml
@using Syncfusion.Blazor.Diagrams
<SfDiagram @ref="@diagram" Height="600px">
</SfDiagram>

@code
{
    //Reference to diagram
    SfDiagram diagram;

    private void NudgeRight()
    {
        //Nudges to right
        this.diagram.Nudge(NudgeDirection.Right);
    }
}
```

## Nudge by using arrow keys

The corresponding arrow keys are used to move the selected elements towards up, down, left, or right direction by 1 pixel.

![Nudge Command](images/Commands_img4.png)

Nudge commands are particularly useful for accurate placement of elements.

## BringIntoView

The [`BringIntoView`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SfDiagram.html#Syncfusion_Blazor_Diagrams_SfDiagram_BringIntoView_System_Object_) command brings the specified rectangular region into the viewport of the diagram.

The following code illustrates how to execute the `BringIntoView` command.

```cshtml
@using Syncfusion.Blazor.Diagrams
<SfDiagram @ref="@diagram" Height="600px">
</SfDiagram>

@code
{
    //Reference to diagram
    SfDiagram diagram;

    private void BringIntoView()
    {
        var bound = new System.Drawing.Rectangle(600, 600, 500, 400);
        //Brings the specified rectangular region of the Diagram content to the viewport of the page.
        this.diagram.BringIntoView(bound);
    }
}
```

## BringToCenter

The [`BringToCenter`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SfDiagram.html#Syncfusion_Blazor_Diagrams_SfDiagram_BringToCenter_System_Object_) command brings the specified rectangular region of the diagram content to the center of the viewport.

The following code illustrates how to execute the `BringToCenter` command.

```cshtml
@using Syncfusion.Blazor.Diagrams
<SfDiagram @ref="@diagram" Height="600px">
</SfDiagram>

@code
{
    //Reference to diagram
    SfDiagram diagram;

    private void BringToCenter()
    {
        var bound = new System.Drawing.Rectangle(600, 600, 500, 400);
        //Brings the specified rectangular region of the Diagram content to the viewport of the page.
        this.diagram.BringToCenter(bound);
    }
}
```

## FitToPage command

The [`FitToPage`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SfDiagram.html#Syncfusion_Blazor_Diagrams_SfDiagram_FitToPage_Syncfusion_Blazor_Diagrams_IFitOptions_) command helps to fit the diagram content into the view with respect to either width, height, or at the whole.

The [`Mode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.IFitOptions.html#Syncfusion_Blazor_Diagrams_IFitOptions_Mode) parameter defines whether the diagram must be horizontally/vertically fit into the viewport with respect to width, height, or entire bounds of the diagram.

The [`Region`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.IFitOptions.html#Syncfusion_Blazor_Diagrams_IFitOptions_Region) parameter defines the region that must be drawn as an image.

The [`Margin`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.IFitOptions.html#Syncfusion_Blazor_Diagrams_IFitOptions_Margin) parameter defines the region/bounds of the diagram content that is to be fit into the view.

The [`CanZoomIn`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.IFitOptions.html#Syncfusion_Blazor_Diagrams_IFitOptions_CanZoomIn) parameter enables/disables zooming to fit the smaller content into a larger viewport.

The [`CustomBounds`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.IFitOptions.html#Syncfusion_Blazor_Diagrams_IFitOptions_CustomBounds) parameter the custom region that must be fit into the viewport.

The following code illustrates how to execute `FitToPage` command.

```cshtml
@using Syncfusion.Blazor.Diagrams
<SfDiagram @ref="@diagram" Height="600px">
</SfDiagram>

@code
{
    //Reference to diagram
    SfDiagram diagram;

    private void FitToPage()
    {
        //fit the diagram to the page
        diagram.FitToPage();
    }
}
```

## Undo and Redo command

The [`Undo`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SfDiagram.html#Syncfusion_Blazor_Diagrams_SfDiagram_Undo) and [`Redo`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SfDiagram.html#Syncfusion_Blazor_Diagrams_SfDiagram_Redo) commands help you to revert/restore the changes.

```cshtml
@using Syncfusion.Blazor.Diagrams
<SfDiagram @ref="@diagram" Height="600px">
</SfDiagram>

@code
{
    //Reference to diagram
    SfDiagram diagram;

    private void Undo()
    {
        //Revert the changes
        diagram.Undo();
    }

    private void Redo()
    {
        //Restore the changes
        diagram.Redo();
    }
}
```

## Command manager

Diagram provides support to map or bind command execution with desired combination of key gestures. Diagram provides some built-in commands.
The [`CommandManager`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramCommandManager.html) provides support to define custom commands. The custom commands are executed when the specified key gesture is recognized.

### Command Execution Event

You can use the [`OnCommandExecuted`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramEvents.html#Syncfusion_Blazor_Diagrams_DiagramEvents_OnCommandExecuted) event to trigger when execute the custom command in diagram.

### Custom command

To define a custom command, specify the following properties:
* [`Gesture`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramCommand.html#Syncfusion_Blazor_Diagrams_DiagramCommand_Gesture): A combination of [`Keys`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramKeyGesture.html#Syncfusion_Blazor_Diagrams_DiagramKeyGesture_Key) and [`KeyModifiers`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramKeyGesture.html#Syncfusion_Blazor_Diagrams_DiagramKeyGesture_KeyModifiers).
* [`Parameter`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramCommand.html#Syncfusion_Blazor_Diagrams_DiagramCommand_Parameter): Defines any additional parameters that are required at runtime.
* [`Name`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramCommand.html#Syncfusion_Blazor_Diagrams_DiagramCommand_Name): Defines the name of the command.

To explore the properties of custom commands, refer to the [`Commands`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramCommandManager.html).

The following code example shows how to define a custom command.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

<SfDiagram @ref="@Diagram" Height="600px"
            Nodes="@NodeCollection">
    @* Initializing the custom commands *@
    <DiagramCommandManager>
        <DiagramCommands>
            <DiagramCommand Name="customGroup">
                <DiagramKeyGesture Key="Keys.G" KeyModifiers="KeyModifiers.Control"></DiagramKeyGesture>
            </DiagramCommand>
            <DiagramCommand Name="customUnGroup">
                <DiagramKeyGesture Key="Keys.U" KeyModifiers="KeyModifiers.Control"></DiagramKeyGesture>
            </DiagramCommand>
        </DiagramCommands>
    </DiagramCommandManager>
    @* To define the custom commands execution event *@
    <DiagramEvents OnCommandExecuted="@CommandExecute"></DiagramEvents>
</SfDiagram>

@code {
    // Reference to diagram
    SfDiagram Diagram;

    // Defines diagram's nodes collection
    public ObservableCollection<DiagramNode> NodeCollection { get; set; }

    protected override void OnInitialized()
    {
        //Initializing the nodes collection
        NodeCollection = new ObservableCollection<DiagramNode>();

        DiagramNode diagramNode = new DiagramNode()
        {
            Id = "node1",
            OffsetX = 100,
            OffsetY = 100,
            Width = 100,
            Height = 100,

            Style = new NodeShapeStyle() { Fill = "#659be5", StrokeColor = "none" },
            Annotations = new ObservableCollection<DiagramNodeAnnotation>() { new DiagramNodeAnnotation() { Content = "Node" } }
        };

        NodeCollection.Add(diagramNode);

        DiagramNode diagramNode1 = new DiagramNode()
        {
            Id = "node2",
            OffsetX = 300,
            OffsetY = 100,
            Width = 100,
            Height = 100,

            Style = new NodeShapeStyle() { Fill = "#659be5", StrokeColor = "none" },
            Annotations = new ObservableCollection<DiagramNodeAnnotation>() { new DiagramNodeAnnotation() { Content = "Node" } }
        };

        NodeCollection.Add(diagramNode1);

    }
    /// <summary>
    /// Custom command execution event
    /// </summary>
    public void CommandExecute(ICommandExecuteEventArgs args)
    {
        if (args.Gesture.KeyModifiers == KeyModifiers.Control && args.Gesture.Key == Keys.G)
        {
            //Custom command to group the selected nodes
            Diagram.Group();
        }
        if (args.Gesture.KeyModifiers == KeyModifiers.Control && args.Gesture.Key == Keys.U)
        {
            //Custom command to ungroup the selected items
            if (Diagram.SelectedItems.Nodes.Count > 0 && Diagram.SelectedItems.Nodes[0].Children != null && Diagram.SelectedItems.Nodes[0].Children.Length > 0)
            {
                Diagram.UnGroup();
            }
        }
    }
}
```

### Modify the existing command

When any one of the default commands is not desired, they can be disabled. To change the functionality of a specific command, the command can be completely modified.

The following code example shows how to disable a command and how to modify the built-in commands.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

<SfDiagram @ref="@Diagram" Height="600px"
            Nodes="@NodeCollection">
    @* Initializing the custom commands *@
    <DiagramCommandManager>
        <DiagramCommands>
            <DiagramCommand Name="navigationDown">
                <DiagramKeyGesture Key="Keys.Down"></DiagramKeyGesture>
            </DiagramCommand>
            <DiagramCommand Name="navigationUp">
                <DiagramKeyGesture Key="Keys.Up"></DiagramKeyGesture>
            </DiagramCommand>
            <DiagramCommand Name="navigationLeft">
                <DiagramKeyGesture Key="Keys.Left"></DiagramKeyGesture>
            </DiagramCommand>
            <DiagramCommand Name="navigationRight">
                <DiagramKeyGesture Key="Keys.Right"></DiagramKeyGesture>
            </DiagramCommand>
        </DiagramCommands>
    </DiagramCommandManager>
    @* To define the custom commands execution event *@
    <DiagramEvents OnCommandExecuted="@CommandExecute"></DiagramEvents>
</SfDiagram>

@code {
    // Reference to diagram
    SfDiagram Diagram;

    // Defines diagram's nodes collection
    public ObservableCollection<DiagramNode> NodeCollection { get; set; }

    protected override void OnInitialized()
    {
        //Initializing the nodes collection
        NodeCollection = new ObservableCollection<DiagramNode>();

        DiagramNode diagramNode = new DiagramNode()
        {
            Id = "node1",
            OffsetX = 100,
            OffsetY = 100,
            Width = 100,
            Height = 100,

            Style = new NodeShapeStyle() { Fill = "#659be5", StrokeColor = "none" },
            Annotations = new ObservableCollection<DiagramNodeAnnotation>() { new DiagramNodeAnnotation() { Content = "Node" } }
        };

        NodeCollection.Add(diagramNode);

    }
    /// <summary>
    /// Custom command execute event
    /// </summary>
    public void CommandExecute(ICommandExecuteEventArgs args)
    {
        if (args.Gesture.Key == Keys.Left)
        {
            //Allow left arrow key to nudge the selected node in left
            if (Diagram.SelectedItems.Nodes.Count > 0)
                Diagram.Nudge(NudgeDirection.Left);
        }
        if (args.Gesture.Key == Keys.Down || args.Gesture.Key == Keys.Up || args.Gesture.Key == Keys.Right)
        {
            //to disable a built-in command and none of action execute
        }
    }
}
```

## See Also

* [How to create the custom context menu items](./context-menu)