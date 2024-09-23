---
layout: post
title: User Handle in Blazor Diagram Component | Syncfusion
description: Learn here all about how to create the user handles in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# User Handles for Node and Connector in Blazor Diagram Component

The user handles are customizable handles that can be used to perform custom actions and default clipboard actions.

## How to initialize the userhandle

The user handle can be enabled for the selected nodes/connectors by setting a [SelectorConstraints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SelectorConstraints.html) as [UserHandle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SelectorConstraints.html#Syncfusion_Blazor_Diagram_SelectorConstraints_UserHandle) and then use the [UserHandle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UserHandle.html) class to define the userhandle object and add that to [UserHandles](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramSelectionSettings.html#Syncfusion_Blazor_Diagram_DiagramSelectionSettings_UserHandles) collection of the DiagramSelectionSettings. The following code example is used to enable and create user handles for the diagram nodes/connectors.

```csharp
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px"
                    Nodes="@nodes"
                    SelectionSettings="@SelectedModel">
    <SnapSettings>
        <HorizontalGridLines LineColor="White" LineDashArray="2,2" />
        <VerticalGridLines LineColor="White" LineDashArray="2,2" />
    </SnapSettings>
</SfDiagramComponent>

@code
{
    // Defines diagram's nodes collection.
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    // Defines diagram's SelectionSettings.
    DiagramSelectionSettings SelectedModel = new DiagramSelectionSettings();
    DiagramObjectCollection<UserHandle> UserHandles = new DiagramObjectCollection<UserHandle>();
    protected override void OnInitialized()
    {
        //Creating the userhandle for cloning the objects.
        UserHandle cloneHandle = new UserHandle()
        {
            //Name of the user handle.
            Name = "clone",
            //Set path data for userhandle.
            PathData = "M60.3,18H27.5c-3,0-5.5,2.4-5.5,5.5v38.2h5.5V23.5h32.7V18z M68.5,28.9h-30c-3,0-5.5,2.4-5.5,5.5v38.2c0,3,2.4,5.5,5.5,5.5h30c3,0,5.5-2.4,5.5-5.5V34.4C73.9,31.4,71.5,28.9,68.5,28.9z M68.5,72.5h-30V34.4h30V72.5z",
            //Set visibility for the user handle.
            Visible = true,
            //Set the position for the user handle.
            Offset = 0,
            //Set side based on the given offset.
            Side = Direction.Bottom,
            //Set margin for the user handle.
            Margin = new DiagramThickness() { Top = 0, Bottom = 0, Left = 0, Right = 0 }
        };
        //Add user handle to the collection.
        UserHandles = new DiagramObjectCollection<UserHandle>()
        {
            cloneHandle
        };
        SelectedModel = new DiagramSelectionSettings()
        {
            //Enable userhandle for selected model.
            Constraints = SelectorConstraints.UserHandle,
            UserHandles = this.UserHandles
        };
        nodes = new DiagramObjectCollection<Node>();
        Node diagramNode = new Node()
        {
            ID = "node1",
            OffsetX = 100,
            OffsetY = 100,
            Width = 100,
            Height = 100,
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "none" },
            Annotations = new DiagramObjectCollection<ShapeAnnotation>() { new ShapeAnnotation { Content = "Node" } }
        };
        nodes.Add(diagramNode);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/UserHandle/InitializeUserHandle)

![Blazor Diagram Node with User Handle](images/blazor-diagram-with-user-handle.png)

## Customization

### Positioning the user handle

The [Offset](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UserHandle.html#Syncfusion_Blazor_Diagram_UserHandle_Offset) property of user handle is used to align the user handles based on fractions. 0 represents Top-Left corner, 1 represents Bottom-Right corner, and 0.5 represents half of Width or Height. The [Side](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UserHandle.html#Syncfusion_Blazor_Diagram_UserHandle_Side) property is used to set how the user handle is aligned based on the given `Offset`.

The following table shows all the possible alignments visually shows the user handle positions.

| Offset | Side | Output |
| -------- | -------- | -------- |
|0|Left|![Blazor Diagram Node with User Handle at TopLeft Corner](images/blazor-diagram-user-handle-at-topleft-corner.png)|
|0|Right|![Blazor Diagram Node with User Handle at TopRight Corner](images/blazor-diagram-user-handle-at-topright-corner.png)|
|0|Top|![Blazor Diagram Node with User Handle at Top Corner](images/blazor-diagram-user-handle-at-top-corner.png)|
|0|Bottom|![Blazor Diagram Node with User Handle at LeftBottom Corner](images/blazor-diagram-user-handle-at-leftbottom-corner.png)|
|1|Left|![Blazor Diagram Node with User Handle at Left Corner](images/blazor-diagram-user-handle-at-left-corner.png)|
|1|Right|![Blazor Diagram Node with User Handle at RightBottom Corner](images/blazor-diagram-user-handle-at-rightbottom-corner.png)|
|1|Top|![Blazor Diagram Node with User Handle at RightTop Corner](images/blazor-diagram-user-handle-at-righttop-corner.png)|
|1|Bottom|![Blazor Diagram Node with User Handle at Bottom Corner](images/blazor-diagram-user-handle-at-bottom-corner.png)|

### How to change the size of the user handle

Diagram allows to set size for user handles by using the [Size](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UserHandle.html#Syncfusion_Blazor_Diagram_UserHandle_Size) property. The default value of the `Size` property is 25.

### How to change the style of the user handle

You can change the style of the user handles with the specific properties of PathColor, BorderColor, BackgroundColor and BorderWidth. The following code explains how to customize the appearance of the user handles.

* The user handle's [PathColor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UserHandle.html#Syncfusion_Blazor_Diagram_UserHandle_PathColor) property is used to change the color of the given [PathData](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UserHandle.html#Syncfusion_Blazor_Diagram_UserHandle_PathData) of the user handle.

* The user handle [BorderColor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UserHandle.html#Syncfusion_Blazor_Diagram_UserHandle_BorderColor) and [BackgroundColor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UserHandle.html#Syncfusion_Blazor_Diagram_UserHandle_BackgroundColor) properties are used to define the background color and border color of the user handle and the [BorderWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UserHandle.html#Syncfusion_Blazor_Diagram_UserHandle_BorderWidth) property is used to define the border width of the user handles.

* The [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UserHandle.html#Syncfusion_Blazor_Diagram_UserHandle_Visible) property indicates whether the user handle is visible in the user interface.

The following code explains how to customize the appearance of the user handle.

```csharp
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes" SelectionSettings="@SelectedModel">
    <SnapSettings>
        <HorizontalGridLines LineColor="White" LineDashArray="2,2"/>
        <VerticalGridLines LineColor="White" LineDashArray="2,2"/>
    </SnapSettings>
</SfDiagramComponent>

@code
{
    // Defines diagram's nodes collection.
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    // Defines diagram's SelectionSettings.
    DiagramSelectionSettings SelectedModel = new DiagramSelectionSettings();
    DiagramObjectCollection<UserHandle> UserHandles = new DiagramObjectCollection<UserHandle>();

    protected override void OnInitialized()
    {
        //Creating the userhandle for cloning the objects.
        UserHandle cloneHandle = new UserHandle()
        {
            //Name of the user handle.
            Name = "clone",
            //Set path data for userhandle.
            PathData = "M60.3,18H27.5c-3,0-5.5,2.4-5.5,5.5v38.2h5.5V23.5h32.7V18z M68.5,28.9h-30c-3,0-5.5,2.4-5.5,5.5v38.2c0,3,2.4,5.5,5.5,5.5h30c3,0,5.5-2.4,5.5-5.5V34.4C73.9,31.4,71.5,28.9,68.5,28.9z M68.5,72.5h-30V34.4h30V72.5z",
            //Set visibility for the user handle.
            Visible = true,
            //Set the position for the user handle.
            Offset = 1,
            //Set side based on the given offset.
            Side = Direction.Bottom,
            //Set margin for the user handle.
            Margin = new DiagramThickness() { Top = 0, Bottom = 0, Left = 0, Right = 0 },
            //Set size of the user handle.
            Size = 50,
            //Set path color for given path data.
            PathColor = "yellow",
            //Set Border color of the user handle.
            BorderColor = "red",
            //Set Background Color of the user handle.
            BackgroundColor = "green",
            //Set Border Width Color of the user handle.
            BorderWidth = 3,
        };
        //Add user handle to the collection.
        UserHandles = new DiagramObjectCollection<UserHandle>()
        {
            cloneHandle
        };
        SelectedModel = new DiagramSelectionSettings()
        {
            //Enable userhandle for selected model.
            Constraints = SelectorConstraints.UserHandle,
            UserHandles = this.UserHandles
        };
        nodes = new DiagramObjectCollection<Node>();
        Node diagramNode = new Node()
        {
            ID = "node1",
            OffsetX = 100,
            OffsetY = 100,
            Width = 100,
            Height = 100,
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "none" },
            Annotations = new DiagramObjectCollection<ShapeAnnotation>() { new ShapeAnnotation { Content = "Node" } }
        };
        nodes.Add(diagramNode);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/UserHandle/Style)

![Customizing Appearance of Userhandle in Blazor Diagram](images/blazor-diagram-custom-user-handle-appearance.png)

### How to change the userhandle's visible target

The [VisibleTarget](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.VisibleTarget.html) property is used to specify whether the userhandle is visible for Node or Connector or both.

| VisibleTarget | Node | Connector | Description |
| -------- | -------- | -------- |-------- |
|Node|![VisibleTarget set as Node](Images/blazor-diagram-user-handle-visible-target-node.png)|![VisibleTarget set as Node](Images/blazor-diagram-user-handle-visible-target-node1.png)|When the VisibleTarget is set as the node, the userhandle only renders for nodes, not for connectors. |
|Connector|![VisibleTarget set as connector](Images/blazor-diagram-user-handle-visible-target-connector1.png)|![VisibleTarget set as connector](Images/blazor-diagram-user-handle-visible-target-connector.png)|When VisibleTarget is set as the connector, the userhandle only renders for the connector, not for nodes. |
|Both|![VisibleTarget set as Both](Images/blazor-diagram-user-handle-visible-target-node.png)|![VisibleTarget set as Both](Images/blazor-diagram-user-handle-visible-target-connector.png)|When the VisibleTarget is set as both, then the userhandle renders for both nodes and connectors |

The following code example shows how to change the VisibleTarget in the userhandle.

```cshtml
@using Syncfusion.Blazor.Diagram
@using System.Collections.ObjectModel
@using Syncfusion.Blazor.Buttons

<SfDiagramComponent @ref="@Diagram" Width="1200px" Height="600px" Nodes="@nodes" GetCustomTool="@tools" GetCustomCursor="@cursor" Connectors="@connectors" SelectionSettings="@SelectedModel">
</SfDiagramComponent>

<SfButton Content="VisibilityNode" OnClick="@VisibilityNode" />
<SfButton Content="VisibilityConnector" OnClick="@VisibilityConnector" />
<SfButton Content="VisibilityBoth" OnClick="@VisibilityBoth" />

@code
{
    //Reference the diagram
    public SfDiagramComponent Diagram;
    //Intialize diagram's nodes collection
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    NodeGroup groupNode = new NodeGroup();
    //Intialize diagram's nodes collection
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
    //Intialize diagram's selectionsettings
    DiagramSelectionSettings SelectedModel = new DiagramSelectionSettings();
    //Intialize diagram's userhandle
    DiagramObjectCollection<UserHandle> UserHandles = new DiagramObjectCollection<UserHandle>();
    public string cursor(DiagramElementAction action, bool active, string handle)
    {
        string cursors = null;
        if (handle == "changeCursor")
        {
            cursors = "crosshair";
        }
        return cursors;
    }
    public InteractionControllerBase tools(DiagramElementAction action, string id)
    {
        InteractionControllerBase tool = null;
        if (id == "clone")
        {
            tool = new CloneTool(Diagram);
        }
        else if (id == "nodeDelete")
        {
            tool = new AddDeleteTool(Diagram);
        }
        return tool;
    }
    public class AddDeleteTool : DragController
    {
        SfDiagramComponent sfDiagram;
        public AddDeleteTool(SfDiagramComponent Diagram) : base(Diagram)
        {
            sfDiagram = Diagram;
        }
        public override void OnMouseUp(DiagramMouseEventArgs args)
        {
            bool GroupAction = false;
            sfDiagram.BeginUpdate();
            if (sfDiagram.SelectionSettings.Nodes.Count > 1 || sfDiagram.SelectionSettings.Connectors.Count > 1 ||
                ((sfDiagram.SelectionSettings.Nodes.Count + sfDiagram.SelectionSettings.Connectors.Count) > 1))
            {
                GroupAction = true;
            }
            if (GroupAction)
            {
                sfDiagram.StartGroupAction();
            }
            if (sfDiagram.SelectionSettings.Nodes.Count != 0)
            {
                for (var i = sfDiagram.SelectionSettings.Nodes.Count - 1; i >= 0; i--)
                {
                    Node deleteNode = sfDiagram.SelectionSettings.Nodes[i];
                    sfDiagram.Nodes.Remove(deleteNode);
                }
            }
            if (sfDiagram.SelectionSettings.Connectors.Count != 0)
            {
                for (var i = sfDiagram.SelectionSettings.Connectors.Count - 1; i >= 0; i--)
                {
                    Connector deleteConnector = sfDiagram.SelectionSettings.Connectors[i];
                    sfDiagram.Connectors.Remove(deleteConnector);
                }
            }
            if (GroupAction)
            {
                sfDiagram.EndGroupAction();
            }
            _ = sfDiagram.EndUpdateAsync();
            base.OnMouseUp(args);
            this.InAction = true;
        }
    }
    public class CloneTool : DragController
    {
        SfDiagramComponent sfDiagram;
        public CloneTool(SfDiagramComponent Diagram) : base(Diagram)
        {
            sfDiagram = Diagram;
        }
        public override void OnMouseDown(DiagramMouseEventArgs args)
        {
            NodeBase newObject;
            if (sfDiagram.SelectionSettings.Nodes.Count > 0)
            {
                newObject = (sfDiagram.SelectionSettings.Nodes[0]).Clone() as Node;
            }
            else
            {
                newObject = (sfDiagram.SelectionSettings.Connectors[0]).Clone() as Connector;
            }
            newObject.ID += sfDiagram.Nodes.Count.ToString();
            sfDiagram.Copy();
            sfDiagram.Paste();
            ObservableCollection<IDiagramObject> obj = new ObservableCollection<IDiagramObject>() { sfDiagram.Nodes[sfDiagram.Nodes.Count - 1] as IDiagramObject };
            sfDiagram.Select(obj);
            base.OnMouseDown(args);
            this.InAction = true;
        }
    }
    protected override void OnInitialized()
    {
        UserHandle cloneHandle = new UserHandle()
            {
                Name = "clone",
                PathData = "M60.3,18H27.5c-3,0-5.5,2.4-5.5,5.5v38.2h5.5V23.5h32.7V18z M68.5,28.9h-30c-3,0-5.5,2.4-5.5,5.5v38.2c0,3,2.4,5.5,5.5,5.5h30c3,0,5.5-2.4,5.5-5.5V34.4C73.9,31.4,71.5,28.9,68.5,28.9z M68.5,72.5h-30V34.4h30V72.5z",
                Offset = 0,
                Visible = true,
                Side = Direction.Top,
                Margin = new DiagramThickness { Top = 0, Bottom = 0, Left = 0, Right = 0 },
                Size = 30,
                PathColor = "yellow",
                BorderColor = "red",
                BackgroundColor = "green",
                BorderWidth = 3,
            };
        UserHandle nodeDelete = new UserHandle()
            {
                Name = "nodeDelete",
                PathData = "M 33.986328 15 A 1.0001 1.0001 0 0 0 33 16 L 33 71.613281 A 1.0001 1.0001 0 0 0 34.568359 72.435547 L 47.451172 63.53125 L 56.355469 85.328125 A 1.0001 1.0001 0 0 0 57.667969 85.871094 L 66.191406 82.298828 A 1.0001 1.0001 0 0 0 66.730469 80.998047 L 57.814453 59.171875 L 73.195312 56.115234 A 1.0001 1.0001 0 0 0 73.708984 54.429688 L 34.708984 15.294922 A 1.0001 1.0001 0 0 0 33.986328 15 z M 35 18.419922 L 70.972656 54.517578 L 56.234375 57.447266 A 1.0001 1.0001 0 0 0 55.503906 58.806641 L 64.503906 80.835938 L 57.826172 83.636719 L 48.832031 61.623047 A 1.0001 1.0001 0 0 0 47.337891 61.177734 L 35 69.707031 L 35 18.419922 z M 37.494141 23.970703 A 0.50005 0.50005 0 0 0 37 24.470703 L 37 58.5 A 0.50005 0.50005 0 1 0 38 58.5 L 38 25.679688 L 51.123047 38.849609 A 0.50005 0.50005 0 1 0 51.832031 38.144531 L 37.853516 24.117188 A 0.50005 0.50005 0 0 0 37.494141 23.970703 z M 53.496094 40.021484 A 0.50005 0.50005 0 0 0 53.146484 40.878906 L 64.898438 52.671875 L 61.359375 53.373047 A 0.50005 0.50005 0 1 0 61.552734 54.353516 L 66.007812 53.470703 A 0.50005 0.50005 0 0 0 66.263672 52.626953 L 53.853516 40.173828 A 0.50005 0.50005 0 0 0 53.496094 40.021484 z M 58.521484 53.941406 A 0.50005 0.50005 0 0 0 58.4375 53.951172 L 51.482422 55.330078 A 0.50005 0.50005 0 0 0 51.117188 56.009766 L 51.794922 57.666016 A 0.50016022 0.50016022 0 1 0 52.720703 57.287109 L 52.273438 56.193359 L 58.632812 54.931641 A 0.50005 0.50005 0 0 0 58.521484 53.941406 z M 53.089844 59.017578 A 0.50005 0.50005 0 0 0 52.630859 59.714844 L 53.037109 60.708984 A 0.50005 0.50005 0 1 0 53.962891 60.332031 L 53.556641 59.335938 A 0.50005 0.50005 0 0 0 53.089844 59.017578 z M 54.300781 61.984375 A 0.50005 0.50005 0 0 0 53.841797 62.679688 L 60.787109 79.679688 A 0.50016068 0.50016068 0 0 0 61.712891 79.300781 L 54.767578 62.302734 A 0.50005 0.50005 0 0 0 54.300781 61.984375 z",
                Offset = 1,
                Visible = true,
                Side = Direction.Left,
                Margin = new DiagramThickness { Top = 0, Bottom = 0, Left = 0, Right = 0 },
                Size = 30,
                PathColor = "yellow",
                BorderColor = "red",
                BackgroundColor = "green",
                BorderWidth = 3,
            };
        UserHandle changeCursor = new UserHandle()
            {
                Name = "changeCursor",
                Offset = 0.5,
                Source = "https://www.w3schools.com/images/w3schools_green.jpg",
                Visible = true,
                Side = Direction.Bottom,
                Margin = new DiagramThickness { Top = 0, Bottom = 0, Left = 0, Right = 0 },
                Size = 30,
                PathColor = "yellow",
                BorderColor = "red",
                BackgroundColor = "green",
                BorderWidth = 3,
            };
        UserHandles = new DiagramObjectCollection<UserHandle>()
        {
            cloneHandle,nodeDelete,changeCursor
        };
        SelectedModel.UserHandles = UserHandles;
        nodes = new DiagramObjectCollection<Node>();
        Node DiagramNode = new Node()
            {
                ID = "node1",
                OffsetX = 100,
                OffsetY = 100,
                Width = 100,
                Height = 100,
                Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "black" },
                Annotations = new DiagramObjectCollection<ShapeAnnotation>() { new ShapeAnnotation { Content = "Node" } }
            };
        connectors = new DiagramObjectCollection<Connector>();
        Connector Connector1 = new Connector()
            {
                ID = "connector1",
                SourcePoint = new DiagramPoint() { X = 250, Y = 250 },
                TargetPoint = new DiagramPoint() { X = 350, Y = 350 },
                Annotations = new DiagramObjectCollection<PathAnnotation>()
            {
                    new PathAnnotation()
                    {
                        ID = "connector1",
                        Offset = 0,
                        Visibility = true,
                        Style = new TextStyle(){ Color ="red", FontSize =12, TextAlign = TextAlign.Right,
                        },
                    }
            },
                Type = ConnectorSegmentType.Bezier
            };
        nodes.Add(DiagramNode);
        connectors.Add(Connector1);
    }
    //Method to sepcifies the userhandle is visible for node
    public void VisibilityNode()
    {
        foreach (UserHandle userHandle in UserHandles)
        {
            userHandle.VisibleTarget = VisibleTarget.Node;
        }
    }
    //Method to sepcifies the userhandle is visible for connector
    public void VisibilityConnector()
    {
        foreach (UserHandle userHandle in UserHandles)
        {
            userHandle.VisibleTarget = VisibleTarget.Connector;
        }
    }
    //Method to sepcifies the userhandle is visible for connector and node
    public void VisibilityBoth()
    {
        foreach (UserHandle userHandle in UserHandles)
        {
            userHandle.VisibleTarget = VisibleTarget.Node | VisibleTarget.Connector;
        }
    }
}

```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/UserHandle/VisibleofUserhandle)

![VisibleTarget](Images/blazor-diagram-user-handle-visible-target.gif)

### How to provide a template to userhandle

You can define user handle style using a template in the [UserHandleTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramTemplates.html#Syncfusion_Blazor_Diagram_DiagramTemplates_UserHandleTemplate) at the tag level. The template will be rendered when the PathData and ImageUrl properties of the userhandle are not defined. However, if either PathData or ImageUrl is defined, then template will not be rendered as they take precedence. The following code explains how to define a template for the [FixedUserHandle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.FixedUserHandle.html).

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent @ref="@Diagram" Width="1200px" Height="600px" Nodes="@nodes" Connectors="@connectors" SelectionSettings="@SelectedModel"> 
<DiagramTemplates>
        <UserHandleTemplate>
            @{
                if((context as UserHandle).Name=="user1")
                {
                    <div style="height: 100%; width: 100%">
                        <input type="button" value="Button1" />
                    </div>
                       
                }
            }
        </UserHandleTemplate>
    </DiagramTemplates>
</SfDiagramComponent>

@code
{
    SfDiagramComponent Diagram;
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
    // Defines diagram's SelectionSettings.
    DiagramSelectionSettings SelectedModel = new DiagramSelectionSettings();
    DiagramObjectCollection<UserHandle> UserHandles = new DiagramObjectCollection<UserHandle>();
    protected override void OnInitialized()
    {
        //Creating the userhandle for cloning the objects.
        UserHandle cloneHandle = new UserHandle()
            {
                Name = "user1",
                Visible = true,
                Offset = 0,
                Size = 30,
                Side = Direction.Right,
                Margin = new DiagramThickness() { Top = 0, Bottom = 0, Left = 0, Right = 0 },
                VisibleTarget=VisibleTarget.Node | VisibleTarget.Connector
            };
        //Add user handle to the collection.
        UserHandles = new DiagramObjectCollection<UserHandle>()
        {
            cloneHandle
        };
        SelectedModel = new DiagramSelectionSettings()
            {
                //Enable userhandle for the selected model.
                Constraints = SelectorConstraints.UserHandle,
                UserHandles = this.UserHandles
            };
        nodes = new DiagramObjectCollection<Node>();
        Node diagramNode = new Node()
            {
                ID = "node1",
                OffsetX = 300,
                OffsetY = 200,
                Width = 130,
                Height = 130,
                Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "none" },
                Annotations = new DiagramObjectCollection<ShapeAnnotation>() { new ShapeAnnotation { Content = "Node" } }
            };
        nodes.Add(diagramNode);

        Connector connector1 = new Connector()
        {
            ID = "connector1",
            SourcePoint = new DiagramPoint() { X = 600, Y = 120 },
            TargetPoint = new DiagramPoint() { X = 750, Y = 270 },
            Type = ConnectorSegmentType.Orthogonal
        };
        connectors.Add(connector1);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/UserHandle/CustomizeUserHandle)

![Template for UserHandle](images/UserHandleTemplate.gif)

## Fixed user handles

The [FixedUserHandle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.FixedUserHandle.html) is used to add some frequently used commands around the node and connector even without selecting it.

## How to initialize the fixed user handles

To create the fixed user handles, define and add them to the collection of nodes and connectors property. The following code example is used to create an fixed user handles for the nodes and connectors.

```csharp
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes" />

@code
{
    // Defines diagram's nodes collection.
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        Node node1 = new Node()
        {
            OffsetX = 250,
            OffsetY = 250,
            Width = 100,
            Height = 100,
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "white" },
            // A fixed user handle is created and stored in fixed user handle collection of Node.
            FixedUserHandles = new DiagramObjectCollection<NodeFixedUserHandle>()
            {
                new NodeFixedUserHandle() 
                { 
                    ID = "user1",
                    Height = 20, 
                    Width = 20, 
                    Visibility = true,
                    Padding = new DiagramThickness() { Bottom = 1, Left = 1, Right = 1, Top = 1 }, 
                    Margin = new DiagramThickness() { Right = 20 }, Offset = new DiagramPoint() { X = 0 , Y = 0 }, 
                    PathData = "M60.3,18H27.5c-3,0-5.5,2.4-5.5,5.5v38.2h5.5V23.5h32.7V18z M68.5,28.9h-30c-3,0-5.5,2.4-5.5,5.5v38.2c0,3,2.4,5.5,5.5,5.5h30c3,0,5.5-2.4,5.5-5.5V34.4C73.9,31.4,71.5,28.9,68.5,28.9z M68.5,72.5h-30V34.4h30V72.5z" 
                },
            }
        };
        nodes.Add(node1);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/UserHandle/FixedUserHandle)

## How to customize the fixed user handle

* The [ID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.FixedUserHandle.html#Syncfusion_Blazor_Diagram_FixedUserHandle_ID) property of fixed user handle is used to define the unique identification of the fixed user handle and it is further used to add custom events to the fixed user handle.

* The fixed user handle can be positioned relative to the node and connector boundaries. It has `Offset`, `Padding` and `CornerRadius` settings. It is used to position and customize the fixed user handle.

* The [Padding](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.FixedUserHandle.html#Syncfusion_Blazor_Diagram_FixedUserHandle_Padding) is used to leave the space that is inside the fixed user handle between the icon and border.

* The [CornerRadius](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.FixedUserHandle.html#Syncfusion_Blazor_Diagram_FixedUserHandle_CornerRadius) allows to create fixed user handles with rounded corners. The radius of the rounded corner is set with the `CornerRadius` property.

N> The [PathData](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.FixedUserHandle.html#Syncfusion_Blazor_Diagram_FixedUserHandle_PathData) needs to be provided to render fixed user handle.

### How to change the size of the fixed user handle

Diagram allows to set size for the fixed user handles by using the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.FixedUserHandle.html#Syncfusion_Blazor_Diagram_FixedUserHandle_Width) and [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.FixedUserHandle.html#Syncfusion_Blazor_Diagram_FixedUserHandle_Height) properties. The default value of the `Width` and `Height` properties is 10.

### How to change the style of the fixed user handle

* You can change the style of the fixed user handles with the specific properties of borderColor, borderWidth, and backgroundColor by using the [Stroke](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.FixedUserHandle.html#Syncfusion_Blazor_Diagram_FixedUserHandle_Stroke), [StrokeThickness](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.FixedUserHandle.html#Syncfusion_Blazor_Diagram_FixedUserHandle_StrokeThickness), and [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.FixedUserHandle.html#Syncfusion_Blazor_Diagram_FixedUserHandle_Fill) properties, and the icon BorderColor, and BorderWidth by using the `IconStroke` and `IconStrokeThickness` properties.

* The fixed user handle's [IconStroke](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.FixedUserHandle.html#Syncfusion_Blazor_Diagram_FixedUserHandle_IconStroke) and [IconStrokeThickness](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.FixedUserHandle.html#Syncfusion_Blazor_Diagram_FixedUserHandle_IconStrokeThickness) properties are used to change the stroke color and stroke width of the given `PathData`.

* The fixed user handle `Stroke` and `Fill` properties are used to define the background color and border color of the user handle and the `StrokeThickness` property is used to define the border width of the fixed user handle.

* The [Visibility](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.FixedUserHandle.html#Syncfusion_Blazor_Diagram_FixedUserHandle_Visibility) property indicates whether the fixed user handle is visible in the user interface.

The following code explains how to customize the appearance of the fixed user handles.

```csharp
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Connectors="@connectors">
    <SnapSettings>
        <HorizontalGridLines LineColor="White" LineDashArray="2,2"/>
        <VerticalGridLines LineColor="White" LineDashArray="2,2"/>
    </SnapSettings>
</SfDiagramComponent>

@code
{
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();

    protected override void OnInitialized()
    {
        connectors = new DiagramObjectCollection<Connector>();
        Connector connector = new Connector()
        {
            SourcePoint = new DiagramPoint() { X = 100, Y = 100 },
            TargetPoint = new DiagramPoint() { X = 200, Y = 200 },
            Type = ConnectorSegmentType.Orthogonal,
            Style = new ShapeStyle() { StrokeColor = "#6495ED" },
            // A fixed user handle is created and stored in fixed user handle collection of Connector.
            FixedUserHandles = new DiagramObjectCollection<ConnectorFixedUserHandle>()
            {
                new ConnectorFixedUserHandle() 
                { 
                    ID = "user1",
                    Height = 25, 
                    Width = 25,
                    Offset = 0.5,
                    Alignment = FixedUserHandleAlignment.After,
                    Displacement = new DiagramPoint() { Y = 10 },
                    Visibility = true, Padding = new DiagramThickness() { Bottom = 1, Left = 1, Right = 1, Top = 1 },
                    PathData = "M60.3,18H27.5c-3,0-5.5,2.4-5.5,5.5v38.2h5.5V23.5h32.7V18z M68.5,28.9h-30c-3,0-5.5,2.4-5.5,5.5v38.2c0,3,2.4,5.5,5.5,5.5h30c3,0,5.5-2.4,5.5-5.5V34.4C73.9,31.4,71.5,28.9,68.5,28.9z M68.5,72.5h-30V34.4h30V72.5z"
                }
            },
        };
        connectors.Add(connector);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/UserHandle/ConnectorFixedUserHandle)

N> The fixed user handle id need to be unique.

## How to customize the fixed userhandle of the node

The node fixed user handle can be aligned relative to the node boundaries. It has [Margin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.NodeFixedUserHandle.html#Syncfusion_Blazor_Diagram_NodeFixedUserHandle_Margin) and [Offset](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.NodeFixedUserHandle.html#Syncfusion_Blazor_Diagram_NodeFixedUserHandle_Offset) settings. It is quite useful to position the node fixed user handle and used together and gives you more control over the node fixed user handle positioning.

### Margin for the fixed user handle of the node

[Margin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.NodeFixedUserHandle.html#Syncfusion_Blazor_Diagram_NodeFixedUserHandle_Margin) is an absolute value used to add some blank space in any one of its four sides. The fixed user handle can be displaced with the `Margin` property.

### Offset for the fixed user handle of the node

The [Offset](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.NodeFixedUserHandle.html#Syncfusion_Blazor_Diagram_NodeFixedUserHandle_Offset) property of fixed user handle is used to align the user handle based on the `X` and `Y` points. (0,0) represents the top-left corner and (1,1) represents the bottom-right corner.

The following table shows all the possible alignments visually shows the fixed user handle positions.

| Offset | Margin | Output |
| -------- | -------- | -------- |
| (0,0) | Right = 20 |![Blazor Diagram with Fixed User Handle at LeftTop Position](images/blazor-diagram-user-handle-at-topleft-position.png)|
| (0.5,0) | Bottom = 20 |![Blazor Diagram with Fixed User Handle at CenterTop Position](images/blazor-diagram-user-handle-at-topcenter-position.png)|
| (1,0) | Left = 20 |![Blazor Diagram with Fixed User Handle at RightTop Position](images/blazor-diagram-user-handle-at-topright-position.png)|
| (0,0.5) | Right = 20 |![Blazor Diagram with Fixed User Handle at LeftCenter Position](images/blazor-diagram-user-handle-at-leftcenter-position.png)|
| (1,0.5) | Left = 20 |![Blazor Diagram with Fixed User Handle at RightCenter Position](images/blazor-diagram-user-handle-at-rightcenter-position.png)|
| (0,1) | Right = 20 |![Blazor Diagram with Fixed User Handle at LeftBottom Position](images/blazor-diagram-user-handle-at-bottomleft-position.png)|
| (0.5,1) | Top = 20 |![Blazor Diagram with Fixed User Handle at CenterBottom Position](images/blazor-diagram-user-handle-at-bottomcenter-position.png)|
| (1,1) | Left = 20 |![Blazor Diagram with Fixed User Handle at RightBottom Position](images/blazor-diagram-user-handle-at-bottomright-position.png)|

The following code explains how to customize the node fixed user handle.

```csharp
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes">
    <SnapSettings>
        <HorizontalGridLines LineColor="White" LineDashArray="2,2"/>
        <VerticalGridLines LineColor="White" LineDashArray="2,2"/>
    </SnapSettings>
</SfDiagramComponent>

@code
{
    // Defines diagram's nodes collection.
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();

    protected override void OnInitialized()
    {
        //Creating the userhandle for cloning the objects.
        nodes = new DiagramObjectCollection<Node>();
        Node diagramNode = new Node()
        {
            OffsetX = 250,
            OffsetY = 250,
            Width = 100,
            Height = 100,
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "white" },
            // A fixed user handle is created and stored in fixed user handle collection of Node.
            FixedUserHandles = new DiagramObjectCollection<NodeFixedUserHandle>()
            {
                new NodeFixedUserHandle() 
                { 
                    ID = "user1",
                    Height = 20, 
                    Width = 20, 
                    Visibility = true,
                    Padding = new DiagramThickness() { Bottom = 1, Left = 1, Right = 1, Top = 1 },
                    Margin = new DiagramThickness() { Left = 20 },
                    Offset = new DiagramPoint() { Y = 0 },
                    PathData = "M60.3,18H27.5c-3,0-5.5,2.4-5.5,5.5v38.2h5.5V23.5h32.7V18z M68.5,28.9h-30c-3,0-5.5,2.4-5.5,5.5v38.2c0,3,2.4,5.5,5.5,5.5h30c3,0,5.5-2.4,5.5-5.5V34.4C73.9,31.4,71.5,28.9,68.5,28.9z M68.5,72.5h-30V34.4h30V72.5z"  
                },
            }
        };
        nodes.Add(diagramNode);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/UserHandle/Offset)

## How to customize the fixed userhandle of the connector

* The connector fixed user handle can be aligned relative to the connector boundaries. It has alignment, displacement and offset settings. It is useful to position the connector fixed user handle and used together and gives you more control over the connector fixed user handle positioning.

* The [Offset](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ConnectorFixedUserHandle.html#Syncfusion_Blazor_Diagram_ConnectorFixedUserHandle_Offset) and [Alignment](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ConnectorFixedUserHandle.html#Syncfusion_Blazor_Diagram_ConnectorFixedUserHandle_Alignment) properties of fixed user handle allows you to align the connector fixed user handles to the segments.

### Offset for the connector fixed user handle

The [Offset](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ConnectorFixedUserHandle.html#Syncfusion_Blazor_Diagram_ConnectorFixedUserHandle_Offset) property of connector fixed user handle is used to align the user handle based on fractions. 0 represents the connector source point, 1 represents the connector target point, and 0.5 represents the center point of the connector segment.

### How to align the connector fixed user handle

The connector’s fixed user handle can be aligned over its segment path using the [Alignment](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ConnectorFixedUserHandle.html#Syncfusion_Blazor_Diagram_ConnectorFixedUserHandle_Alignment) property of fixed user handle.

The following table shows all the possible alignments visually shows the fixed user handle positions.

| Offset | Alignment | Output |
| -------- | -------- | -------- |
| 0 | Before |![Displaying Fixed User Handle in Before Blazor Diagram Connector](images/blazor-diagram-user-handle-in-before-connector.png)|
| 0.5 | Center |![Displaying Fixed User Handle in Center of Blazor Diagram Connector](images/blazor-diagram-user-handle-in-center-of-connector.png)|
| 1 | After |![Displaying Fixed User Handle in After Blazor Diagram Connector](images/blazor-diagram-user-handle-in-after-connector.png)|

### Displacement of the connector fixed user handle

* The [Displacement](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ConnectorFixedUserHandle.html#Syncfusion_Blazor_Diagram_ConnectorFixedUserHandle_Displacement) property allows you to specify the space to be left from the connector segment based on the x and y value provided.

The following table shows all the possible alignments visually shows the fixed user handle positions.

| Displacement | Alignment | Output |
| -------- | -------- | -------- |
| y = 10 | Before |![Displaying Fixed User Handle Before Blazor Diagram Node](images/blazor-diagram-user-handle-in-before-node.png)|
| y = 10 | After |![Displaying Fixed User Handle Before Blazor Diagram Node](images/blazor-diagram-user-handle-in-after-node.png)|

N> Displacement will not be done if the alignment is set to center.

The following code explains how to customize the connector fixed user handle.

```csharp
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Connectors="@connectors">
    <SnapSettings>
        <HorizontalGridLines LineColor="White" LineDashArray="2,2"/>
        <VerticalGridLines LineColor="White" LineDashArray="2,2"/>
    </SnapSettings>
</SfDiagramComponent>

@code
{
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();

    protected override void OnInitialized()
    {
        connectors = new DiagramObjectCollection<Connector>();
        Connector connector = new Connector()
        {
            SourcePoint = new DiagramPoint() { X = 100, Y = 100 },
            TargetPoint = new DiagramPoint() { X = 200, Y = 200 },
            Type = ConnectorSegmentType.Orthogonal,
            Style = new ShapeStyle() { StrokeColor = "#6495ED" },
            // A fixed user handle is created and stored in fixed user handle collection of Connector.
            FixedUserHandles = new DiagramObjectCollection<ConnectorFixedUserHandle>()
            {
                new ConnectorFixedUserHandle()
                {
                    ID = "user1",
                    Height = 25,
                    Width = 25,
                    Offset = 0.5,
                    Alignment = FixedUserHandleAlignment.After,
                    Displacement = new DiagramPoint { Y = 10 },
                    Visibility = true, Padding = new DiagramThickness() { Bottom = 1, Left = 1, Right = 1, Top = 1 },
                    PathData = "M60.3,18H27.5c-3,0-5.5,2.4-5.5,5.5v38.2h5.5V23.5h32.7V18z M68.5,28.9h-30c-3,0-5.5,2.4-5.5,5.5v38.2c0,3,2.4,5.5,5.5,5.5h30c3,0,5.5-2.4,5.5-5.5V34.4C73.9,31.4,71.5,28.9,68.5,28.9z M68.5,72.5h-30V34.4h30V72.5z"
                }
            }
        };
        connectors.Add(connector);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/UserHandle/ConnectorFixedUserHandle)

## How to provide a template to fixed userhandle

You can define fixed user handle style using a template in the [FixedUserHandleTemplate] at the tag level. You can define separate templates for each node and connector by differentiating them based on their ID property. The template will be rendered when the PathData properties of the fixeduserhandle is not defined. However, if both path data and template are defined, the path data will take precedence, and the template will not be rendered. The following code explains how to define a template for the fixed user handle.

```csharp
@using Syncfusion.Blazor.Diagram
<SfDiagramComponent @ref="@diagram" Height="600px" Nodes = "@nodes" Connectors="@connectors">
    <DiagramTemplates>
        <FixedUserHandleTemplate>
            @if ((context as FixedUserHandle).ID == "user1" || (context as FixedUserHandle).ID == "user2")
            {
                <div id="button" style="height: 100%; width: 100%;">
                    <input type="button" value="Button1" />
                </div>
            }
        </FixedUserHandleTemplate>
    </DiagramTemplates>
</SfDiagramComponent>
@code
{
    public SfDiagramComponent diagram;
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
    protected override void OnInitialized()
    {
        Node node1 = new Node()
        {
            ID="node1",
            OffsetX = 250,
            OffsetY = 250,
            Width = 100,
            Height = 100,
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "white" },
            FixedUserHandles = new DiagramObjectCollection<NodeFixedUserHandle>()
        {
            new NodeFixedUserHandle()
            {
                ID = "user1",
                    Height = 30,
                    Width = 30,
                    Visibility = true,
                    Padding = new DiagramThickness() { Bottom = 1, Left = 1, Right = 1, Top = 1 },
                    Margin = new DiagramThickness() { Left = 30 }, Offset = new DiagramPoint() { X = 1 , Y = 0 }
                },
             }
            };
        nodes.Add(node1);
        Connector connector = new Connector
        {
            ID = "connector1",
            Type = ConnectorSegmentType.Orthogonal,
            SourcePoint = new DiagramPoint() { X = 600, Y = 200 },
            TargetPoint = new DiagramPoint() { X = 800, Y = 400 },
            FixedUserHandles = new DiagramObjectCollection<ConnectorFixedUserHandle>() { new ConnectorFixedUserHandle() { 
                ID="user2",
                Offset = 1, 
                Alignment = FixedUserHandleAlignment.After, 
                Displacement = new DiagramPoint() { X = 10}, 
                Padding = new DiagramThickness() { Bottom = 1, Left = 1, Right = 1, Top = 1 }, 
                Width = 30, 
                Height = 30, 
            }
            }
        };
        connectors.Add(connector);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/UserHandle/CustomizeFixedUserHandle)
![Template for FixedUserHandle](images/FixedUserTemplate.png)

## FixedUserHandle event

The Diagram control provides the following event for the fixed user handle.

| Event Name | Event Type | Description |
| -------- | -------- | -------- |
| [FixedUserHandleClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_FixedUserHandleClick) | [FixedUserHandleClickEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.FixedUserHandleClickEventArgs.html) | Triggered when the mouse pointer is over the user handle and mouse button is up. |

```csharp
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px"
                    FixedUserHandleClick="Changed" Nodes="@nodes" @ref="diagram">
</SfDiagramComponent>

@code
{
    SfDiagramComponent diagram;

    public void Changed(FixedUserHandleClickEventArgs args)
    {
        if ((args.Element as Node).ID == "node1" && args.FixedUserHandle.ID == "user1")
        {
            diagram.Copy();
            diagram.Paste();
        }
    }

    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        Node node1 = new Node()
        {
            OffsetX = 250,
            OffsetY = 250,
            ID = "node1",
            Width = 100,
            Height = 100,
            Style = new ShapeStyle() { Fill = "#6BA5D7", StrokeColor = "white" },
            // A fixed user handle is created and stored in fixed user handle collection of Node.
            FixedUserHandles = new DiagramObjectCollection<NodeFixedUserHandle>()
            {
                new NodeFixedUserHandle()
                {
                    ID = "user1",
                    Height = 20,
                    Width = 20,
                    Visibility = true,
                    Padding = new DiagramThickness() { Bottom = 1, Left = 1, Right = 1, Top = 1 },
                    Margin = new DiagramThickness() { Right = 20 },
                    Offset = new DiagramPoint() { X = 0 , Y = 0 },
                    PathData = "M60.3,18H27.5c-3,0-5.5,2.4-5.5,5.5v38.2h5.5V23.5h32.7V18z M68.5,28.9h-30c-3,0-5.5,2.4-5.5,5.5v38.2c0,3,2.4,5.5,5.5,5.5h30c3,0,5.5-2.4,5.5-5.5V34.4C73.9,31.4,71.5,28.9,68.5,28.9z M68.5,72.5h-30V34.4h30V72.5z"
                },
            }
        };
        nodes.Add(node1);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/UserHandle/FixedUserHandleEvent)