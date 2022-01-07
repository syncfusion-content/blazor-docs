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

## Initializing the user handle

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
            //Set pathdata for userhandle.
            PathData = "M60.3,18H27.5c-3,0-5.5,2.4-5.5,5.5v38.2h5.5V23.5h32.7V18z M68.5,28.9h-30c-3,0-5.5,2.4-5.5,5.5v38.2c0,3,2.4,5.5,5.5,5.5h30c3,0,5.5-2.4,5.5-5.5V34.4C73.9,31.4,71.5,28.9,68.5,28.9z M68.5,72.5h-30V34.4h30V72.5z",
            //Set visibility for the user handle.
            Visible = true,
            //Set the position for the user handle.
            Offset = 0,
            //Set side based on the given offset.
            Side = Direction.Bottom,
            //Set margin for the user handle.
            Margin = new Margin() { Top = 0, Bottom = 0, Left = 0, Right = 0 }
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

![Blazor Diagram Node with User Handle](images/blazor-diagram-with-user-handle.png)

## Customization

### Position

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

### Size

Diagram allows to set size for user handles by using the [Size](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UserHandle.html#Syncfusion_Blazor_Diagram_UserHandle_Size) property. The default value of the `Size` property is 25.

### Style

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
            //Set pathdata for userhandle.
            PathData = "M60.3,18H27.5c-3,0-5.5,2.4-5.5,5.5v38.2h5.5V23.5h32.7V18z M68.5,28.9h-30c-3,0-5.5,2.4-5.5,5.5v38.2c0,3,2.4,5.5,5.5,5.5h30c3,0,5.5-2.4,5.5-5.5V34.4C73.9,31.4,71.5,28.9,68.5,28.9z M68.5,72.5h-30V34.4h30V72.5z",
            //Set visibility for the user handle.
            Visible = true,
            //Set the position for the user handle.
            Offset = 1,
            //Set side based on the given offset.
            Side = Direction.Bottom,
            //Set margin for the user handle.
            Margin = new Margin() { Top = 0, Bottom = 0, Left = 0, Right = 0 },
            //Set size of the user handle.
            Size = 50,
            //Set pathcolor for given pathdata.
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

![Customizing Appearance of Userhandle in Blazor Diagram](images/blazor-diagram-custom-user-handle-appearance.png)

## Fixed user handles

The [FixedUserHandle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.FixedUserHandle.html) is used to add some frequently used commands around the node and connector even without selecting it.

## Initializing the fixed user handles

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
                    Padding = new Margin() { Bottom = 1, Left = 1, Right = 1, Top = 1 }, 
                    Margin = new Margin() { Right = 20 }, Offset = new DiagramPoint() { X = 0 , Y = 0 }, 
                    PathData = "M60.3,18H27.5c-3,0-5.5,2.4-5.5,5.5v38.2h5.5V23.5h32.7V18z M68.5,28.9h-30c-3,0-5.5,2.4-5.5,5.5v38.2c0,3,2.4,5.5,5.5,5.5h30c3,0,5.5-2.4,5.5-5.5V34.4C73.9,31.4,71.5,28.9,68.5,28.9z M68.5,72.5h-30V34.4h30V72.5z" 
                },
            }
        };
        nodes.Add(node1);
    }
}
```

## Customizing the fixed user handle

* The [ID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.FixedUserHandle.html#Syncfusion_Blazor_Diagram_FixedUserHandle_ID) property of fixed user handle is used to define the unique identification of the fixed user handle and it is further used to add custom events to the fixed user handle.

* The fixed user handle can be positioned relative to the node and connector boundaries. It has `Offset`, `Padding` and `CornerRadius` settings. It is used to position and customize the fixed user handle.

* The [Padding](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.FixedUserHandle.html#Syncfusion_Blazor_Diagram_FixedUserHandle_Padding) is used to leave the space that is inside the fixed user handle between the icon and border.

* The [CornerRadius](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.FixedUserHandle.html#Syncfusion_Blazor_Diagram_FixedUserHandle_CornerRadius) allows to create fixed user handles with rounded corners. The radius of the rounded corner is set with the `CornerRadius` property.

> The [PathData](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.FixedUserHandle.html#Syncfusion_Blazor_Diagram_FixedUserHandle_PathData) needs to be provided to render fixed user handle.

### Size

Diagram allows to set size for the fixed user handles by using the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.FixedUserHandle.html#Syncfusion_Blazor_Diagram_FixedUserHandle_Width) and [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.FixedUserHandle.html#Syncfusion_Blazor_Diagram_FixedUserHandle_Height) properties. The default value of the `Width` and `Height` properties is 10.

### Style

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
                    Visibility = true, Padding = new Margin() { Bottom = 1, Left = 1, Right = 1, Top = 1 },
                    PathData = "M60.3,18H27.5c-3,0-5.5,2.4-5.5,5.5v38.2h5.5V23.5h32.7V18z M68.5,28.9h-30c-3,0-5.5,2.4-5.5,5.5v38.2c0,3,2.4,5.5,5.5,5.5h30c3,0,5.5-2.4,5.5-5.5V34.4C73.9,31.4,71.5,28.9,68.5,28.9z M68.5,72.5h-30V34.4h30V72.5z"
                }
            },
        };
        connectors.Add(connector);
    }
}
```

> The fixed user handle id need to be unique.

## Customizing the node fixed user handle

The node fixed user handle can be aligned relative to the node boundaries. It has [Margin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.NodeFixedUserHandle.html#Syncfusion_Blazor_Diagram_NodeFixedUserHandle_Margin) and [Offset](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.NodeFixedUserHandle.html#Syncfusion_Blazor_Diagram_NodeFixedUserHandle_Offset) settings. It is quite useful to position the node fixed user handle and used together and gives you more control over the node fixed user handle positioning.

### Margin for the node fixed user handle

[Margin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.NodeFixedUserHandle.html#Syncfusion_Blazor_Diagram_NodeFixedUserHandle_Margin) is an absolute value used to add some blank space in any one of its four sides. The fixed user handle can be displaced with the `Margin` property.

### Offset for the node fixed user handle

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
                    Padding = new Margin() { Bottom = 1, Left = 1, Right = 1, Top = 1 },
                    Margin = new Margin() { Left = 20 },
                    Offset = new DiagramPoint() { Y = 0 },
                    PathData = "M60.3,18H27.5c-3,0-5.5,2.4-5.5,5.5v38.2h5.5V23.5h32.7V18z M68.5,28.9h-30c-3,0-5.5,2.4-5.5,5.5v38.2c0,3,2.4,5.5,5.5,5.5h30c3,0,5.5-2.4,5.5-5.5V34.4C73.9,31.4,71.5,28.9,68.5,28.9z M68.5,72.5h-30V34.4h30V72.5z"  
                },
            }
        };
        nodes.Add(diagramNode);
    }
}
```

## Customizing the connector fixed user handle

* The connector fixed user handle can be aligned relative to the connector boundaries. It has alignment, displacement and offset settings. It is useful to position the connector fixed user handle and used together and gives you more control over the connector fixed user handle positioning.

* The [Offset](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ConnectorFixedUserHandle.html#Syncfusion_Blazor_Diagram_ConnectorFixedUserHandle_Offset) and [Alignment](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ConnectorFixedUserHandle.html#Syncfusion_Blazor_Diagram_ConnectorFixedUserHandle_Alignment) properties of fixed user handle allows you to align the connector fixed user handles to the segments.

### Offset for the connector fixed user handle

The [Offset](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ConnectorFixedUserHandle.html#Syncfusion_Blazor_Diagram_ConnectorFixedUserHandle_Offset) property of connector fixed user handle is used to align the user handle based on fractions. 0 represents the connector source point, 1 represents the connector target point, and 0.5 represents the center point of the connector segment.

### Alignment

The connector’s fixed user handle can be aligned over its segment path using the [Alignment](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ConnectorFixedUserHandle.html#Syncfusion_Blazor_Diagram_ConnectorFixedUserHandle_Alignment) property of fixed user handle.

The following table shows all the possible alignments visually shows the fixed user handle positions.

| Offset | Alignment | Output |
| -------- | -------- | -------- |
| 0 | Before |![Displaying Fixed User Handle in Before Blazor Diagram Connector](images/blazor-diagram-user-handle-in-before-connector.png)|
| 0.5 | Center |![Displaying Fixed User Handle in Center of Blazor Diagram Connector](images/blazor-diagram-user-handle-in-center-of-connector.png)|
| 1 | After |![Displaying Fixed User Handle in After Blazor Diagram Connector](images/blazor-diagram-user-handle-in-after-connector.png)|

### Displacement

* The [Displacement](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ConnectorFixedUserHandle.html#Syncfusion_Blazor_Diagram_ConnectorFixedUserHandle_Displacement) property allows you to specify the space to be left from the connector segment based on the x and y value provided.

The following table shows all the possible alignments visually shows the fixed user handle positions.

| Displacement | Alignment | Output |
| -------- | -------- | -------- |
| y = 10 | Before |![Displaying Fixed User Handle Before Blazor Diagram Node](images/blazor-diagram-user-handle-in-before-node.png)|
| y = 10 | After |![Displaying Fixed User Handle Before Blazor Diagram Node](images/blazor-diagram-user-handle-in-after-node.png)|

> Displacement will not be done if the alignment is set to center.

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
                    Visibility = true, Padding = new Margin() { Bottom = 1, Left = 1, Right = 1, Top = 1 },
                    PathData = "M60.3,18H27.5c-3,0-5.5,2.4-5.5,5.5v38.2h5.5V23.5h32.7V18z M68.5,28.9h-30c-3,0-5.5,2.4-5.5,5.5v38.2c0,3,2.4,5.5,5.5,5.5h30c3,0,5.5-2.4,5.5-5.5V34.4C73.9,31.4,71.5,28.9,68.5,28.9z M68.5,72.5h-30V34.4h30V72.5z"
                }
            }
        };
        connectors.Add(connector);
    }
}
```

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
                    Padding = new Margin() { Bottom = 1, Left = 1, Right = 1, Top = 1 },
                    Margin = new Margin() { Right = 20 },
                    Offset = new DiagramPoint() { X = 0 , Y = 0 },
                    PathData = "M60.3,18H27.5c-3,0-5.5,2.4-5.5,5.5v38.2h5.5V23.5h32.7V18z M68.5,28.9h-30c-3,0-5.5,2.4-5.5,5.5v38.2c0,3,2.4,5.5,5.5,5.5h30c3,0,5.5-2.4,5.5-5.5V34.4C73.9,31.4,71.5,28.9,68.5,28.9z M68.5,72.5h-30V34.4h30V72.5z"
                },
            }
        };
        nodes.Add(node1);
    }
}
```