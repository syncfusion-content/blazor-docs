---
layout: post
title: Commands in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Commands in Syncfusion Blazor Diagram component and much more details.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Commands in Blazor Diagram Component

There are several commands available in the diagram as follows.

* Alignment commands
* Distribute commands
* Sizing commands
* Clipboard commands
* Grouping commands
* Zoom commands
* Undo/Redo commands

## Alignment commands

Alignment commands enable you to align the selected or defined objects such as nodes and connectors with respect to the selection boundary. Following are the AlignmentOptions in `SetAlign` commands which shows how to use align methods in the diagram.

### Align Left
The following code example illustrates how to align all the selected objects at the left side of the selection boundary.

```cshtml
@using Syncfusion.Blazor.Diagram

<input type="button" value="Left" @onclick="@OnAlignLeft" />

<SfDiagramComponent @ref="diagram" Width="1000px" Height="500px" Nodes="@nodes" Connectors="@Connectors"/>

@code
{
    SfDiagramComponent diagram;
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    DiagramObjectCollection<Connector> Connectors = new DiagramObjectCollection<Connector>();

    protected override void OnInitialized()
    {
        Node node1 = new Node()
        {
            ID = "node1",
            Width = 50,
            Height = 30,
            OffsetX = 500,
            OffsetY = 100,
            Shape = new BasicShape() { Type = Shapes.Basic, Shape = BasicShapeType.Rectangle }
        };
        nodes.Add(node1);
        Node node2 = new Node()
        {
            ID = "node2",
            Width = 60,
            Height = 40,
            OffsetX = 500,
            OffsetY = 300,
            Shape = new BasicShape() { Type = Shapes.Basic, Shape = BasicShapeType.Rectangle }
        };
        nodes.Add(node2);
        Node node3 = new Node()
        {
            ID = "node3",
            Width = 70,
            Height = 50,
            OffsetX = 500,
            OffsetY = 500,
            Shape = new BasicShape() { Type = Shapes.Basic, Shape = BasicShapeType.Rectangle }
        };
        nodes.Add(node3);
    }

    private void OnAlignLeft()
    {
        diagram.SetAlign(AlignmentOptions.Left);
    }      
}
```

### Align Right

The following code example illustrates how to align all the selected objects at the right side of the selection boundary.

```cshtml
@using Syncfusion.Blazor.Diagram

<input type="button" value="Right" @onclick="@OnAlignRight" />

<SfDiagramComponent @ref="diagram" Width="1000px" Height="500px" Nodes="@nodes" Connectors="@Connectors"/>

@code
{
    SfDiagramComponent diagram;
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    DiagramObjectCollection<Connector> Connectors = new DiagramObjectCollection<Connector>();

   protected override void OnInitialized()
    {
        Node node1 = new Node()
        {
            ID = "node1",
            Width = 50,
            Height = 30,
            OffsetX = 500,
            OffsetY = 100,
            Shape = new BasicShape() { Type = Shapes.Basic, Shape = BasicShapeType.Rectangle }
        };
        nodes.Add(node1);
        Node node2 = new Node()
        {
            ID = "node2",
            Width = 60,
            Height = 40,
            OffsetX = 500,
            OffsetY = 300,
            Shape = new BasicShape() { Type = Shapes.Basic, Shape = BasicShapeType.Rectangle }
        };
        nodes.Add(node2);
        Node node3 = new Node()
        {
            ID = "node3",
            Width = 70,
            Height = 50,
            OffsetX = 500,
            OffsetY = 500,
            Shape = new BasicShape() { Type = Shapes.Basic, Shape = BasicShapeType.Rectangle }
        };
        nodes.Add(node3);
    }

    private void OnAlignRight()
    {
        diagram.SetAlign(AlignmentOptions.Right);
    }     
}
```

### Align Top
The following code example illustrates how to align all the selected objects at the top of the selection boundary.

```cshtml
@using Syncfusion.Blazor.Diagram

<input type="button" value="Top" @onclick="@OnAlignTop" />

<SfDiagramComponent @ref="diagram" Width="1000px" Height="500px" Nodes="@nodes" Connectors="@Connectors"/>

@code
{
    SfDiagramComponent diagram;
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    DiagramObjectCollection<Connector> Connectors = new DiagramObjectCollection<Connector>();

    protected override void OnInitialized()
    {
        Node node1 = new Node()
        {
            ID = "node1",
            Width = 50,
            Height = 30,
            OffsetX = 500,
            OffsetY = 100,
            Shape = new BasicShape() { Type = Shapes.Basic, Shape = BasicShapeType.Rectangle }
        };
        nodes.Add(node1);
        Node node2 = new Node()
        {
            ID = "node2",
            Width = 60,
            Height = 40,
            OffsetX = 500,
            OffsetY = 300,
            Shape = new BasicShape() { Type = Shapes.Basic, Shape = BasicShapeType.Rectangle }
        };
        nodes.Add(node2);
        Node node3 = new Node()
        {
            ID = "node3",
            Width = 70,
            Height = 50,
            OffsetX = 500,
            OffsetY = 500,
            Shape = new BasicShape() { Type = Shapes.Basic, Shape = BasicShapeType.Rectangle }
        };
        nodes.Add(node3);
    }

    private void OnAlignTop()
    {
        diagram.SetAlign(AlignmentOptions.Top);
    }       
}
```

### Align Bottom
The following code example illustrates how to align all the selected objects at the bottom of the selection boundary.

```cshtml
@using Syncfusion.Blazor.Diagram

<input type="button" value="Bottom" @onclick="@OnAlignBottom" />

<SfDiagramComponent @ref="diagram" Width="1000px" Height="500px" Nodes="@nodes" Connectors="@Connectors"/>

@code
{
    SfDiagramComponent diagram;
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    DiagramObjectCollection<Connector> Connectors = new DiagramObjectCollection<Connector>();

   protected override void OnInitialized()
    {
        Node node1 = new Node()
        {
            ID = "node1",
            Width = 50,
            Height = 30,
            OffsetX = 500,
            OffsetY = 100,
            Shape = new BasicShape() { Type = Shapes.Basic, Shape = BasicShapeType.Rectangle }
        };
        nodes.Add(node1);
        Node node2 = new Node()
        {
            ID = "node2",
            Width = 60,
            Height = 40,
            OffsetX = 500,
            OffsetY = 300,
            Shape = new BasicShape() { Type = Shapes.Basic, Shape = BasicShapeType.Rectangle }
        };
        nodes.Add(node2);
        Node node3 = new Node()
        {
            ID = "node3",
            Width = 70,
            Height = 50,
            OffsetX = 500,
            OffsetY = 500,
            Shape = new BasicShape() { Type = Shapes.Basic, Shape = BasicShapeType.Rectangle }
        };
        nodes.Add(node3);
    }

    private void OnAlignBottom()
    {
        diagram.SetAlign(AlignmentOptions.Bottom);
    }     
}
```

### Align Middle
The following code example illustrates how to align all the selected objects at the middle of the selection boundary.

```cshtml
@using Syncfusion.Blazor.Diagram

<input type="button" value="Middle" @onclick="@OnAlignMiddle" />

<SfDiagramComponent @ref="diagram" Width="1000px" Height="500px" Nodes="@nodes" Connectors="@Connectors"/>

@code
{
    SfDiagramComponent diagram;
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    DiagramObjectCollection<Connector> Connectors = new DiagramObjectCollection<Connector>();

    protected override void OnInitialized()
    {
        Node node1 = new Node()
        {
            ID = "node1",
            Width = 50,
            Height = 30,
            OffsetX = 500,
            OffsetY = 100,
            Shape = new BasicShape() { Type = Shapes.Basic, Shape = BasicShapeType.Rectangle }
        };
        nodes.Add(node1);
        Node node2 = new Node()
        {
            ID = "node2",
            Width = 60,
            Height = 40,
            OffsetX = 500,
            OffsetY = 300,
            Shape = new BasicShape() { Type = Shapes.Basic, Shape = BasicShapeType.Rectangle }
        };
        nodes.Add(node2);
        Node node3 = new Node()
        {
            ID = "node3",
            Width = 70,
            Height = 50,
            OffsetX = 500,
            OffsetY = 500,
            Shape = new BasicShape() { Type = Shapes.Basic, Shape = BasicShapeType.Rectangle }
        };
        nodes.Add(node3);
    }

    private void OnAlignMiddle()
    {
        diagram.SetAlign(AlignmentOptions.Middle);
    }         
}
```

### Align Center

The following code example illustrates how to align all the selected objects at the center of the selection boundary.

```cshtml
@using Syncfusion.Blazor.Diagram

<input type="button" value="Center" @onclick="@OnAlignCenter" />

<SfDiagramComponent @ref="diagram" Width="1000px" Height="500px" Nodes="@nodes" Connectors="@Connectors"/>

@code
{
    SfDiagramComponent diagram;
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    DiagramObjectCollection<Connector> Connectors = new DiagramObjectCollection<Connector>();

    protected override void OnInitialized()
    {
        Node node1 = new Node()
        {
            ID = "node1",
            Width = 50,
            Height = 30,
            OffsetX = 500,
            OffsetY = 100,
            Shape = new BasicShape() { Type = Shapes.Basic, Shape = BasicShapeType.Rectangle }
        };
        nodes.Add(node1);
        Node node2 = new Node()
        {
            ID = "node2",
            Width = 60,
            Height = 40,
            OffsetX = 500,
            OffsetY = 300,
            Shape = new BasicShape() { Type = Shapes.Basic, Shape = BasicShapeType.Rectangle }
        };
        nodes.Add(node2);
        Node node3 = new Node()
        {
            ID = "node3",
            Width = 70,
            Height = 50,
            OffsetX = 500,
            OffsetY = 500,
            Shape = new BasicShape() { Type = Shapes.Basic, Shape = BasicShapeType.Rectangle }
        };
        nodes.Add(node3);
    }

    private void OnAlignCenter()
    {
        diagram.SetAlign(AlignmentOptions.Center);
    }        
}
```
## Distribute

The `SetDistribute` commands enable to place the selected objects on the page at equal intervals from each other. The selected objects are equally spaced within the selection boundary.

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

```cshtml
@using Syncfusion.Blazor.Diagram

<input type="button" value="Left" @onclick="@OnDistributeLeft" />
<input type="button" value="Right" @onclick="@OnDistributeRight" />
<input type="button" value="Top" @onclick="@OnDistributeTop" />
<input type="button" value="Bottom" @onclick="@OnDistributeBottom" />
<input type="button" value="Center" @onclick="@OnDistributeCenter" />
<input type="button" value="Middle" @onclick="@OnDistributeMiddle" />
<input type="button" value="BottomToTop" @onclick="@OnDistributeBottomToTop" />
<input type="button" value="RightToLeft" @onclick="@OnDistributeRightToLeft" />

<SfDiagramComponent @ref="diagram" Width="1000px" Height="500px" Nodes="@nodes" Connectors="@Connectors"/>

@code
{
    SfDiagramComponent diagram;
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    DiagramObjectCollection<Connector> Connectors = new DiagramObjectCollection<Connector>();

     protected override void OnInitialized()
    {
        Node node1 = new Node()
        {
            ID = "node1",
            Width = 50,
            Height = 30,
            OffsetX = 500,
            OffsetY = 100,
            Shape = new BasicShape() { Type = Shapes.Basic, Shape = BasicShapeType.Rectangle }
        };
        nodes.Add(node1);
        Node node2 = new Node()
        {
            ID = "node2",
            Width = 60,
            Height = 40,
            OffsetX = 400,
            OffsetY = 200,
            Shape = new BasicShape() { Type = Shapes.Basic, Shape = BasicShapeType.Rectangle }
        };
        nodes.Add(node2);
        Node node3 = new Node()
        {
            ID = "node3",
            Width = 70,
            Height = 50,
            OffsetX = 500,
            OffsetY = 300,
            Shape = new BasicShape() { Type = Shapes.Basic, Shape = BasicShapeType.Rectangle }
        };
        nodes.Add(node3);
    }

    private void OnDistributeLeft()
    {
        diagram.SetDistribute(DistributeOptions.Left);
    }

    private void OnDistributeRight()
    {
        diagram.SetDistribute(DistributeOptions.Right);
    }

    private void OnDistributeTop()
    {
        diagram.SetDistribute(DistributeOptions.Top);
    }

    private void OnDistributeBottom()
    {
        diagram.SetDistribute(DistributeOptions.Bottom);
    }

    private void OnDistributeMiddle()
    {
        diagram.SetDistribute(DistributeOptions.Middle);
    }

    private void OnDistributeCenter()
    {
        diagram.SetDistribute(DistributeOptions.Center);
    }

    private void OnDistributeBottomToTop()
    {
        diagram.SetDistribute(DistributeOptions.BottomToTop);
    }

    private void OnDistributeRightToLeft()
    {
        diagram.SetDistribute(DistributeOptions.RightToLeft);
    }
}
```

## Sizing Commands

 Sizing commands are used to resize all selected object based on width, height, and size of the reference object (FirstSelectedItem).

`SizingMode` are as follows:

* `Width` : Scales the width of the selected objects.
* `Height` : Scales the height of the selected objects.
* `Size` : Scales the selected objects both vertically and horizontally.

The following code example illustrates how to execute the size commands.

```cshtml
@using Syncfusion.Blazor.Diagram

<input type="button" value="SameSize" @onclick="@OnSameSize" />
<input type="button" value="SameWidth" @onclick="@OnSameWidth" />
<input type="button" value="SameHeight" @onclick="@OnSameHeight" />

<SfDiagramComponent @ref="@diagram" Height="600px" Nodes="@nodes" Connectors="@connectors" />

@code
{
    //Reference to diagram
    SfDiagramComponent diagram;
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();

    protected override void OnInitialized()
    {
        Node node1 = new Node()
        {
            ID = "node1",
            Width = 50,
            Height = 30,
            OffsetX = 500,
            OffsetY = 100,
            Shape = new BasicShape() { Type = Shapes.Basic, Shape = BasicShapeType.Rectangle },
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "#6495ED" }
        };
        nodes.Add(node1);
        Node node2 = new Node()
        {
            ID = "node2",
            Width = 60,
            Height = 40,
            OffsetX = 400,
            OffsetY = 200,
            Shape = new BasicShape() { Type = Shapes.Basic, Shape = BasicShapeType.Rectangle },
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "#6495ED" }
        };
        nodes.Add(node2);
        Node node3 = new Node()
        {
            ID = "node3",
            Width = 70,
            Height = 50,
            OffsetX = 500,
            OffsetY = 300,
            Shape = new BasicShape() { Type = Shapes.Basic, Shape = BasicShapeType.Rectangle },
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "#6495ED" }
        };
        nodes.Add(node3);
    }

    private void OnSameSize()
    {
        diagram.SetSameSize(SizingMode.Size);
    }

    private void OnSameWidth()
    {
        diagram.SetSameSize(SizingMode.Width);
    }

    private void OnSameHeight()
    {
        diagram.SetSameSize(SizingMode.Height);
    }
```

## Clipboard

Clipboard commands are used to cut, copy, or paste the selected elements.

* Cuts the selected elements from the diagram to the diagram’s clipboard using `Cut` command.

* Copies the selected elements from the diagram to the diagram’s clipboard using `Copy` command.

* Pastes the diagram’s clipboard data (nodes/connectors) into the diagram using `Paste` command.

The following code illustrates how to execute the clipboard commands.

```cshtml
@using Syncfusion.Blazor.Diagram

<input type="button" value="Cut" @onclick="@OnCut" />
<input type="button" value="Copy" @onclick="@OnCopy" />
<input type="button" value="Paste" @onclick="@OnPaste" />

<SfDiagramComponent @ref="@diagram" Height="600px" Nodes="@nodes" Connectors="@Connectors"/>

@code
{
    //Reference to diagram
    SfDiagramComponent diagram;
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    DiagramObjectCollection<Connector> Connectors = new DiagramObjectCollection<Connector>();

    protected override void OnInitialized()
    {
        Node node1 = new Node()
        {
            ID = "node1",
            Width = 50,
            Height = 30,
            OffsetX = 500,
            OffsetY = 100,
            Shape = new BasicShape() { Type = Shapes.Basic, Shape = BasicShapeType.Rectangle },
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "#6495ED" }
        };
        nodes.Add(node1);
        Node node2 = new Node()
        {
            ID = "node2",
            Width = 60,
            Height = 40,
            OffsetX = 400,
            OffsetY = 200,
            Shape = new BasicShape() { Type = Shapes.Basic, Shape = BasicShapeType.Rectangle },
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "#6495ED" }
        };
        nodes.Add(node2);
    }

    private void OnCut()
    {
        diagram.Cut();
    }

    private void OnCopy()
    {
        diagram.Copy();
    }

    private void OnPaste()
    {
        diagram.Paste();
    }
}
```

## Grouping

**Grouping commands** are used to group/ungroup the selected elements on the diagram. To group the elements , select the elements using select all command and group the selected elements.

`Group` command is used to group the selected nodes and connectors in the diagram.

`Ungroup` command is used to ungroup the selected nodes and connectors in the diagram.

The following code illustrates how to execute the grouping commands.

```cshtml
@using Syncfusion.Blazor.Diagram

<input type="button" value="Group" @onclick="@OnGroup" />
<input type="button" value="UnGroup" @onclick="@OnUnGroup" />
<input type="button" value="SelectAll" @onclick="@OnSelectAll" />

<SfDiagramComponent @ref="@diagram" Height="600px" Nodes="@nodes" Connectors="@Connectors" />

@code
{
    //Reference to diagram
    SfDiagramComponent diagram;
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    DiagramObjectCollection<Connector> Connectors = new DiagramObjectCollection<Connector>();

    protected override void OnInitialized()
    {
        Node node1 = new Node()
        {
            ID = "node1",
            Width = 50,
            Height = 30,
            OffsetX = 500,
            OffsetY = 100,
            Shape = new BasicShape() { Type = Shapes.Basic, Shape = BasicShapeType.Rectangle },
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "#6495ED" }
        };
        nodes.Add(node1);
        Node node2 = new Node()
        {
            ID = "node2",
            Width = 60,
            Height = 40,
            OffsetX = 400,
            OffsetY = 200,
            Shape = new BasicShape() { Type = Shapes.Basic, Shape = BasicShapeType.Rectangle },
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "#6495ED" }
        };
        nodes.Add(node2);
    }

    private void OnGroup()
    {
        diagram.Group();
    }

    private void OnUnGroup()
    {
        diagram.UnGroup();
    }

    private void OnSelectAll()
    {
        diagram.SelectAll();
    }
}
```

## Zoom

The `Zoom` command is used to zoom-in and zoom-out the diagram view.

The following code illustrates how to zoom-in/zoom out the diagram.

```cshtml
@using Syncfusion.Blazor.Diagram

<input type="button" value="Zoom" @onclick="@OnZoom" />

<SfDiagramComponent @ref="@diagram" Height="600px" Nodes="@nodes" Connectors="@Connectors"/>

@code
{
    //Reference to diagram
    SfDiagramComponent diagram;
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    DiagramObjectCollection<Connector> Connectors = new DiagramObjectCollection<Connector>();

    protected override void OnInitialized()
    {
        Node node1 = new Node()
        {
            ID = "node1",
            Width = 50,
            Height = 30,
            OffsetX = 500,
            OffsetY = 100,
            Shape = new BasicShape() { Type = Shapes.Basic, Shape = BasicShapeType.Rectangle },
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "#6495ED" }
        };
        nodes.Add(node1);
    }

    private void OnZoom()
    {
        // Sets the ZoomFactor
        // Defines the FocusPoint to zoom the Diagram with respect to any point
        // When you do not set focus point, zooming is performed with reference to the center of current Diagram view.
        diagram.Zoom(1.2, new DiagramPoint() { X = 100, Y = 100 });
    }
}
```

## Undo and Redo command

The `Undo` and `Redo` commands help you to revert/restore the changes.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent @ref="@diagram" Height="600px">
</SfDiagramComponent>

@code
{
    //Reference to diagram
    SfDiagramComponent diagram;

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
The `CommandManager` provides support to define custom commands. The custom commands are executed when the specified key gesture is recognized.

### Command Execution Event

You can use the `Executed` event to trigger when execute the custom command in diagram.

### Custom command

To define a custom command, specify the following properties:
* `Gesture`: A combination of `Keys` and `Modifiers`.
* `Name`: Defines the name of the command.

The following code example shows how to define a custom command.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent @ref="@diagram" Height="600px" Nodes="@nodes">
    @* Initializing the custom commands *@
    <CommandManager>
        <CommandManager Commands="@command" Execute="@CommandExecute" CanExecute="@canexe">
        </CommandManager>
    </CommandManager>
</SfDiagramComponent>

@code
{
    // Reference to diagram
    SfDiagramComponent diagram;
    DiagramObjectCollection<KeyboardCommand> command = new DiagramObjectCollection<KeyboardCommand>()
    {
        new KeyboardCommand()
        {
            Name = "CustomGroup",
            Gesture = new KeyGesture() { Key = Keys.G, Modifiers = ModifierKeys.Control }
        },
        new KeyboardCommand()
        {
            Name = "CustomUnGroup",
            Gesture = new KeyGesture() { Key = Keys.U, Modifiers = ModifierKeys.Control }
        },
     };
    // Defines diagram's nodes collection
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();

    protected override void OnInitialized()
    {
        Node node1 = new Node()
        {
            ID = "node1",
            OffsetX = 100,
            OffsetY = 100,
            Width = 100,
            Height = 100,
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "#6495ED" },
            Annotations = new DiagramObjectCollection<ShapeAnnotation>()
            {
                new ShapeAnnotation() { Content = "Node" }
            }
        };
        nodes.Add(node1);
        Node node2 = new Node()
        {
            ID = "node2",
            OffsetX = 300,
            OffsetY = 100,
            Width = 100,
            Height = 100,
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "#6495ED" },
            Annotations = new DiagramObjectCollection<ShapeAnnotation>()
            {
                new ShapeAnnotation() { Content = "Node1" }
            }
        };
        nodes.Add(node2);
    }

    public void canexe(CommandKeyArgs args)
    {
        args.CanExecute = true;
    }

    /// <summary>
    /// Custom command execution event
    /// </summary>
    public void CommandExecute(CommandKeyArgs args)
    {
        if (args.Gesture.Modifiers == ModifierKeys.Control && args.Gesture.Key == Keys.G)
        {
            //Custom command to group the selected nodes
            diagram.Group();
        }
        if (args.Gesture.Modifiers == ModifierKeys.Control && args.Gesture.Key == Keys.U)
        {
            DiagramSelectionSettings selector = diagram.SelectionSettings;
            //Custom command to ungroup the selected items
            if (selector.Nodes.Count > 0 && selector.Nodes[0] is NodeGroup)
            {
                if ((selector.Nodes[0] as NodeGroup).Children.Length > 0)
                {
                    diagram.UnGroup();
                }
            }
        }
    }
}
```

### Modify the existing command

When any one of the default commands is not desired, they can be disabled. To change the functionality of a specific command, the command can be completely modified.

The following code example shows how to disable a command and how to modify the built-in commands.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent @ref="@diagram" Height="600px" Nodes="@nodes">
    @* Initializing the custom commands *@
    <CommandManager>
        <CommandManager Commands="@commands" Execute="@CommandExecute" CanExecute="@canexe">
        </CommandManager>
    </CommandManager>
</SfDiagramComponent>

@code
{
    // Reference to diagram
    SfDiagramComponent diagram;
    // Defines diagram's nodes collection
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    DiagramObjectCollection<KeyboardCommand> commands = new DiagramObjectCollection<KeyboardCommand>()
    {
        new KeyboardCommand()
        {
            Name = "SelectAll",
            Gesture = new KeyGesture() { Key = Keys.A, Modifiers = ModifierKeys.Control }
        },
        new KeyboardCommand()
        {
            Name = "Copy",
            Gesture = new KeyGesture() { Key = Keys.C, Modifiers = ModifierKeys.Control }
        }
    };

    protected override void OnInitialized()
    {
        Node node1 = new Node()
        {
            ID = "node1",
            OffsetX = 100,
            OffsetY = 100,
            Width = 100,
            Height = 100,
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "#6495ED" },
            Annotations = new DiagramObjectCollection<ShapeAnnotation>()
            {
                new ShapeAnnotation() { Content = "Node" }
            }
        };
        nodes.Add(node1);
        Node node2 = new Node()
        {
            ID = "node2",
            OffsetX = 300,
            OffsetY = 100,
            Width = 100,
            Height = 100,
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "#6495ED" },
            Annotations = new DiagramObjectCollection<ShapeAnnotation>()
            {
                new ShapeAnnotation() { Content = "Node1" }
            }
        };
        nodes.Add(node2);
    }

    public void canexe(CommandKeyArgs args)
    {
        args.CanExecute = true;
    }

    /// <summary>
    /// Custom command execution event
    /// </summary>
    public void CommandExecute(CommandKeyArgs args)
    {
        if (args.Gesture.Modifiers == ModifierKeys.Control && args.Gesture.Key == Keys.A)
        {
            //to disable a built-in command and none of action execute
        }
        if (args.Gesture.Modifiers == ModifierKeys.Control && args.Gesture.Key == Keys.C)
        {
            //Modify the existing copy command to cut command
            diagram.Cut();
        }
    }
}
```