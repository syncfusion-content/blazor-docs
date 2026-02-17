---
layout: post
title: Context Menu in Syncfusion Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Diagram Context Menu in Syncfusion Blazor Diagram component and much more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Context Menu in Diagram Component

<!-- markdownlint-disable MD010 -->

In graphical user interfaces (GUIs), a context menu is a menu that opens on right-click and can create a nested level of context menu items.
The Diagram component provides built-in context menu items and supports custom items through the [ContextMenuSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ContextMenuSettings.html) property.

## How to Enable Default Context Menu

The [Show](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ContextMenuSettings.html#Syncfusion_Blazor_Diagram_ContextMenuSettings_Show) property enables or disables the context menu. The default context menu items such as copy, cut, paste, select all, undo, redo and group options. The following code shows how to enable the default context menu items.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px">
    <ContextMenuSettings Show="true">
    </ContextMenuSettings>
</SfDiagramComponent>
```
A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/ContextMenu/DefaultContextMenu.razor)
![Default Context Menu](images/ContextMenuDefault.gif)

The following code shows how to disable the default context menu items.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px">
    <ContextMenuSettings Show="false">
    </ContextMenuSettings>
</SfDiagramComponent>
```

## How to Add Custom Items to the Context Menu

Custom context menu provides an option to add new custom items to the context menu.

* Default context menu items, Define some additional context menu items. Those additional items must be defined and added to the [Items](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ContextMenuSettings.html#Syncfusion_Blazor_Diagram_ContextMenuSettings_Items) property of the context menu.

* The context menu [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ContextMenuItem.html#Syncfusion_Blazor_Diagram_ContextMenuItem_Text) and [ID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ContextMenuItem.html#Syncfusion_Blazor_Diagram_ContextMenuItem_ID) properties to set the text and ID for the context menu item.

* Set a navigation url for the context menu item using the context menu [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ContextMenuItem.html#Syncfusion_Blazor_Diagram_ContextMenuItem_Url) property.

* The [IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ContextMenuItem.html#Syncfusion_Blazor_Diagram_ContextMenuItem_IconCss) property defines the class or multiple classes separated by a space for the menu item that is used to include an icon. The Menu item consists of the font icon and sprite image.

* The [Separator](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ContextMenuItem.html#Syncfusion_Blazor_Diagram_ContextMenuItem_Separator) property defines the horizontal lines that are used to separate the menu items. Cannot select the separators. Using the separator attribute, enable separators to group the menu items.

* Show or hide an item using the [Hidden](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ContextMenuItem.html#Syncfusion_Blazor_Diagram_ContextMenuItem_Hidden) property.

* Enable or disable an item using the [Disabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ContextMenuItem.html#Syncfusion_Blazor_Diagram_ContextMenuItem_Disabled) property.

* Add submenu items with the [Items](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ContextMenuItem.html#Syncfusion_Blazor_Diagram_ContextMenuItem_Items) property.

### How to Add Custom and Default Context Menu Items Together

The following code example shows how to add custom context menu items along with the default context menu. Set the [ShowCustomMenuOnly](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ContextMenuSettings.html#Syncfusion_Blazor_Diagram_ContextMenuSettings_ShowCustomMenuOnly) property to false to render both the custom context menu and default context menu.

```cshtml
@using Syncfusion.Blazor.Diagram
@using System.Collections.ObjectModel

<SfDiagramComponent @ref="_diagram" Height="600px" Width="90%" @bind-Nodes="_nodes" @bind-Connectors="_connectors">
    <ContextMenuSettings Show="true"
                         ShowCustomMenuOnly="false"
                         Items="@_items">
    </ContextMenuSettings>
</SfDiagramComponent>

@code {
    private SfDiagramComponent _diagram;
    private DiagramObjectCollection<Node> _nodes;
    private DiagramObjectCollection<Connector> _connectors;
    private List<ContextMenuItem> _items; 

    protected override void OnInitialized()
    {
        _nodes = new DiagramObjectCollection<Node>();
        _connectors = new DiagramObjectCollection<Connector>();

        _items = new List<ContextMenuItem>()
        {
                new ContextMenuItem()
                {
                    Text = "Save As...",
                    ID = "save",
                    IconCss = "e-save",
                },
                new ContextMenuItem()
                {
                    Text = "Delete",
                    ID = "delete",
                    IconCss = "e-delete"
                }
        };

        Node node1 = new Node()
        {
            ID = "node1",
            Height = 100,
            Width = 100,
            OffsetX = 100,
            OffsetY = 100,
            Style = new ShapeStyle()
            {
                Fill = "#6BA5D7",
                StrokeColor = "white",
                StrokeWidth = 1
            }
        };
        Node node2 = new Node()
        {
            ID = "node2",
            Height = 100,
            Width = 100,
            OffsetX = 300,
            OffsetY = 100,
            Style = new ShapeStyle()
            {
                Fill = "#6BA5D7",
                StrokeColor = "white",
                StrokeWidth = 1
            }
        };
        _nodes.Add(node1);
        _nodes.Add(node2);

        Connector connector1 = new Connector()
        {
            ID = "connector1",
            SourceID = "node1",
            TargetID = "node2",
            Type = ConnectorSegmentType.Straight,
            Style = new ShapeStyle()
            {
                Fill = "#6BA5D7",
                StrokeWidth = 2
            }
        };
        _connectors.Add(connector1);
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BtryWDDQToDgkczx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/ContextMenu/CustomContextMenu.razor)

### How to Show Custom Context Menu Alone

Set the [ShowCustomMenuOnly](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ContextMenuSettings.html#Syncfusion_Blazor_Diagram_ContextMenuSettings_ShowCustomMenuOnly) property to **true** to display only custom context menu items.
The following code example shows how to show custom context menu items alone.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px">
    <ContextMenuSettings Show="true" ShowCustomMenuOnly="true">
    </ContextMenuSettings>
</SfDiagramComponent>
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/ContextMenu/CustomContextMenuOnly.razor)

![Custom Context Menu](images/ContextMenuCustomMenuOnly.gif)

## How to Customize Context Menu Items Using Templates

Diagram provides template support for the context menu. The context menu items can be customized using the [ContextMenuTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ContextMenuSettings.html#Syncfusion_Blazor_Diagram_ContextMenuSettings_ContextMenuTemplate) at the tag level. The following code explains how to define a template for context menu items.

```cshtml
@using Syncfusion.Blazor.Diagram
@using System.Collections.ObjectModel


<SfDiagramComponent @ref="_diagram" Height="600px" Width="90%" @bind-Nodes="_nodes"
                    @bind-Connectors="_connectors">
    <ContextMenuSettings @bind-Show="@_show"
                        @bind-ShowCustomMenuOnly="_customMenuOnly"
                        @bind-Items="@_items">
    <ContextMenuTemplate>
        @context.Text
        <span class="shortcut">@((@context.Text == "Save As...") ? "Ctrl + S" : "")</span>
    </ContextMenuTemplate>
    </ContextMenuSettings>
</SfDiagramComponent>

@code {
    //Reference the diagram
    private SfDiagramComponent _diagram;
    //Define diagram nodes collection
    private DiagramObjectCollection<Node> _nodes;
    //Define diagram connectors collection
    private DiagramObjectCollection<Connector> _connectors;

    private List<ContextMenuItem> _items;
    private bool _customMenuOnly = false;
    private bool _show = true;

    protected override void OnInitialized()
    {
    //Initialize diagram nodes collection
    _nodes = new DiagramObjectCollection<Node>();
    //Initialize diagram connectors collection
    _connectors = new DiagramObjectCollection<Connector>();

    _items = new List<ContextMenuItem>()
    {
            new ContextMenuItem()
            {
                Text = "Save As...",
                ID = "save",
                IconCss = "e-save",
            },
            new ContextMenuItem()
            {
                Text = "Delete",
                ID = "delete",
                IconCss = "e-delete"
            }
    };

    Node node1 = new Node()
        {
            ID = "node1",
            Height = 100,
            Width = 100,
            OffsetX = 100,
            OffsetY = 100,
            Style = new ShapeStyle()
            {
                Fill = "#6BA5D7",
                StrokeColor = "white",
                StrokeWidth = 1
            }
        };
    Node node2 = new Node()
        {
            ID = "node2",
            Height = 100,
            Width = 100,
            OffsetX = 300,
            OffsetY = 100,
            Style = new ShapeStyle()
            {
                Fill = "#6BA5D7",
                StrokeColor = "white",
                StrokeWidth = 1
            }
        };
    _nodes.Add(node1);
    _nodes.Add(node2);

    Connector connector1 = new Connector()
        {
            ID = "connector1",
            SourceID = "node1",
            TargetID = "node2",
            Type = ConnectorSegmentType.Straight,
            Style = new ShapeStyle()
            {
                Fill = "#6BA5D7",
                StrokeWidth = 2
            }
        };
    _connectors.Add(connector1);
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BZhSitXcpeBhpOuL?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/ContextMenu/ContextMenuTemplate.razor)
![Context Menu Template](images/ContextMenuTemplate.gif)

## Events

The Diagram control provides events for the context menu, triggered when rendering the context menu and when clicking the items of the context menu.

### How to Handle Context Menu Opening Event

The Diagram control triggers the event [ContextMenuOpening](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ContextMenuSettings.html#Syncfusion_Blazor_Diagram_ContextMenuSettings_ContextMenuOpening)  when performing a right click on the diagram or the diagram elements such as Node, Connector and Groups. To explore the arguments, refer to the [DiagramMenuOpeningEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramMenuOpeningEventArgs.html).

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px">
    <ContextMenuSettings Show="true" ShowCustomMenuOnly="false" ContextMenuOpening="@OnContextMenuOpen">
    </ContextMenuSettings>
</SfDiagramComponent>

@code
{
    public void OnContextMenuOpen(DiagramMenuOpeningEventArgs arg)
    {
        //Action to be performed
    }
}
```
A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/ContextMenu/ContextMenuOpenningEvent.razor)

### How to Handle Context Menu Item Clicked Event

The Diagram control triggers the event [ContextMenuItemClicked](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ContextMenuSettings.html#Syncfusion_Blazor_Diagram_ContextMenuSettings_ContextMenuItemClicked) when the context menu item is clicked. To explore the arguments, refer to the [DiagramMenuClickEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramMenuClickEventArgs.html).

```cshtml
@using Syncfusion.Blazor.Diagram
@using System.Collections.ObjectModel

<SfDiagramComponent Height="600px">
    <ContextMenuSettings Show="true" ShowCustomMenuOnly="false" ContextMenuItemClicked="@ContextMenuItemClickHandler">
    </ContextMenuSettings>
</SfDiagramComponent>

@code
{
    public void ContextMenuItemClickHandler(DiagramMenuClickEventArgs arg)
    {
        //Action to be performed
    }
}
```
A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/ContextMenu/ContextMenuItemClickedEvent.razor)

The following code example shows how to add separate custom context menu items for nodes and connectors. In the following code, the node color context menu item only renders for the node and the connector color context menu item only renders for the connector.

```cshtml
@using Syncfusion.Blazor.Diagram
<SfDiagramComponent @ref="@_diagram" Height="600px"
           Nodes="@_nodeCollection"
           Connectors="@_connectorCollection">
    
    <ContextMenuSettings Show="true" Items="@_contextMenuItemModels" ShowCustomMenuOnly="true" ContextMenuOpening="@OnContextMenuOpen">
    </ContextMenuSettings>
</SfDiagramComponent>

@code
{
    //Reference to diagram
    private SfDiagramComponent _diagram;
    //Defines diagram's nodes collection
    private DiagramObjectCollection<Node> _nodeCollection = new DiagramObjectCollection<Node>();
    //Defines diagram's connector collection
    private DiagramObjectCollection<Connector> _connectorCollection = new DiagramObjectCollection<Connector>();

    protected override void OnInitialized()
    {
        //Create a node
        Node node1 = new Node()
        {
            ID = "node1",
            Height = 100,
            Width = 100,
            OffsetX = 100,
            OffsetY = 100,
            Style = new ShapeStyle()
            {
                Fill = "#6BA5D7",
                StrokeColor = "white",
                StrokeWidth = 1
            }
        };
        Node node2 = new Node()
            {
                ID = "node2",
                Height = 100,
                Width = 100,
                OffsetX = 300,
                OffsetY = 100,
                Style = new ShapeStyle()
                {
                    Fill = "#6BA5D7",
                    StrokeColor = "white",
                    StrokeWidth = 1
                }
            };
        //Add node into node's collection
        _nodeCollection.Add(node1);
        _nodeCollection.Add(node2);

        Connector connector1 = new Connector()
        {
            ID = "connector1",
            SourceID = "node1",
            TargetID = "node2",
            Type = ConnectorSegmentType.Straight,
            Style = new ShapeStyle()
            {
                Fill = "#6BA5D7",
                StrokeWidth = 2
            }
        };
        _connectorCollection.Add(connector1);
    }
    List<ContextMenuItem> _contextMenuItemModels = new List<ContextMenuItem>()
    {
        new ContextMenuItem()
        {
            Text ="Node Color",
            ID="Node",
            Items = new List<ContextMenuItem>()
            {
                new ContextMenuItem(){  Text ="Red", ID="Red", },
                new ContextMenuItem(){  Text ="Yellow", ID="Yellow", },
                new ContextMenuItem(){  Text ="Green", ID="Green", }
            }
        },
        new ContextMenuItem()
        {
            Text ="Connector Color",
            ID="Connector",
            Items = new List<ContextMenuItem>()
            {
                new ContextMenuItem(){  Text ="Red", ID="black", },
                new ContextMenuItem(){  Text ="Yellow", ID="blue", },
                new ContextMenuItem(){  Text ="Green", ID="brown", }
            }
        },
    };

    public void OnContextMenuOpen(DiagramMenuOpeningEventArgs arg)
    {
        if (_diagram.SelectionSettings.Nodes.Count > 0)
        {
            arg.HiddenItems.Add("Connector");
        }
        if (_diagram.SelectionSettings.Connectors.Count > 0)
        {
            arg.HiddenItems.Add("Node");
        }
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hZLIMXjGfIhvkfXe?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/ContextMenu/ContextMenuEvents.razor)

## See also

* [How to Zoom the Diagram Without Ctrl + Wheel and Enable Pan on Right-Click Instead of Left-Click in Blazor Diagram](https://support.syncfusion.com/kb/article/18992/how-to-zoom-the-diagram-without-ctrl--wheel-and-enable-pan-on-right-click-instead-of-left-click-in-blazor-diagram)
