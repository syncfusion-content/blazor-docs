---
layout: post
title: Context Menu in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Context Menu in Syncfusion Blazor Diagram component and much more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Context Menu in Blazor Diagram Component

<!-- markdownlint-disable MD010 -->

In Graphical User Interface (GUI), a context menu is a certain type of menu that appears when you perform right-click operation. You can create a nested level of context menu items.
Diagram provides some in-built context menu items and allows you to define custom menu items through the [ContextMenuSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ContextMenuSettings.html) property.

## Default context menu

The [Show](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ContextMenuSettings.html#Syncfusion_Blazor_Diagram_ContextMenuSettings_Show) property helps you to enable or disable the context menu. Diagram provides default context menu items such as copy, cut, paste, select all, undo, redo and group options. The following code shows how to enable the default context menu items.

```cshtml
<SfDiagramComponent @ref="diagram" Height="600px">
    //Define context menu
    <ContextMenuSettings Show="true">
    </ContextMenuSettings>
</SfDiagramComponent>
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/main/UG-Samples/ContextMenu)
![Default Context Menu](images/ContextMenuDefault.gif)

The following code shows how to disable the default context menu items.

```cshtml
<SfDiagramComponent @ref="diagram" Height="600px">
    //Define context menu
    <ContextMenuSettings Show="false">
    </ContextMenuSettings>
</SfDiagramComponent>
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/main/UG-Samples/ContextMenu)
## Custom context menu

Custom context menu provides an option to add the new custom items to the context menu.

* Apart from the default context menu items, Define some additional context menu items. Those additional items must be defined and added to the [Items](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ContextMenuSettings.html#Syncfusion_Blazor_Diagram_ContextMenuSettings_Items) property of the context menu.

* The context menu [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ContextMenuItem.html#Syncfusion_Blazor_Diagram_ContextMenuItem_Text) and [ID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ContextMenuItem.html#Syncfusion_Blazor_Diagram_ContextMenuItem_ID) properties allows you to set the text and ID for the context menu item.

* You can set an navigation url for the context menu item using the context menu [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ContextMenuItem.html#Syncfusion_Blazor_Diagram_ContextMenuItem_Url) property.

* The [IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ContextMenuItem.html#Syncfusion_Blazor_Diagram_ContextMenuItem_IconCss) property defines the class or multiple classes separated by a space for the menu item that is used to include an icon. The Menu item consists of the font icon and sprite image.

* The [Separator](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ContextMenuItem.html#Syncfusion_Blazor_Diagram_ContextMenuItem_Separator) property defines the horizontal lines that are used to separate the menu items. You cannot select the separators. Using the separator attribute, you can enable separators to group the menu items.

* You can Hide/Show menu item using the [Hidden](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ContextMenuItem.html#Syncfusion_Blazor_Diagram_ContextMenuItem_Hidden) property.

* You can Enable/Disable menu item using the [Disabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ContextMenuItem.html#Syncfusion_Blazor_Diagram_ContextMenuItem_Disabled) property.

* You can add submenu items using the [Items](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ContextMenuItem.html#Syncfusion_Blazor_Diagram_ContextMenuItem_Items) property.

### Custom context menu along with default context menu

The following code example shows how to add custom context menu items along with the default context menu. Set  the [ShowCustomMenuOnly](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ContextMenuSettings.html#Syncfusion_Blazor_Diagram_ContextMenuSettings_ShowCustomMenuOnly) property to false to render both the custom context menu and default context menu.

```cshtml
@using Syncfusion.Blazor.Diagram
@using System.Collections.ObjectModel

<SfDiagramComponent @ref="diagram" Height="600px" Width="90%" @bind-Nodes="nodes" @bind-Connectors="connectors">
    <ContextMenuSettings Show="true"
                         ShowCustomMenuOnly="false"
                         Items="@Items">
    </ContextMenuSettings>
</SfDiagramComponent>

@code {
    SfDiagramComponent diagram;
    DiagramObjectCollection<Node> nodes;
    DiagramObjectCollection<Connector> connectors;
    List<ContextMenuItem> Items; 

    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        connectors = new DiagramObjectCollection<Connector>();

        Items = new List<ContextMenuItem>()
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
        nodes.Add(node1);
        nodes.Add(node2);

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
        connectors.Add(connector1);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/main/UG-Samples/ContextMenu)
### Custom context menu alone

Set the [ShowCustomMenuOnly](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ContextMenuSettings.html#Syncfusion_Blazor_Diagram_ContextMenuSettings_ShowCustomMenuOnly) property to true to only display the custom context menu items.
The following code example shows how to show custom context menu items alone.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px">
    // Defines context menu and set the ShowCustomMenuOnly to true to render the custom context menu alone
    <ContextMenuSettings Show="true" ShowCustomMenuOnly="true">
    </ContextMenuSettings>
</SfDiagramComponent>
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/main/UG-Samples/ContextMenu)
![Custom Context Menu](images/ContextMenuCustomMenuOnly.gif)

## Template Support for Context menu 

Diagram provides template support for context menu. The context menu items can be customized using the [ContextMenuTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ContextMenuSettings.html#Syncfusion_Blazor_Diagram_ContextMenuSettings_ContextMenuTemplate) at the tag level. The following code explains how to define template for context menu items.

```cshtml
@using Syncfusion.Blazor.Diagram
@using System.Collections.ObjectModel

<SfDiagramComponent @ref="diagram" Height="600px">
    <ContextMenuSettings Show="true" Items="@Items">

        <ContextMenuTemplate>
            @context.Text
            <span class="shortcut">@((@context.Text == "Save As...") ? "Ctrl + S" : "")</span>
        </ContextMenuTemplate>

    </ContextMenuSettings>
</SfDiagramComponent>

@code {
    SfDiagramComponent diagram;
    List<ContextMenuItem> Items;

    protected override void OnInitialized()
    {
        Items = new List<ContextMenuItem>()
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
    }
}
<style>
    .shortcut {
        float: right;
        font-size: 10px;
        opacity: 0.5;
    }
</style>
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/main/UG-Samples/ContextMenu)
![Context Menu Template](images/ContextMenuTemplate.gif)

## Events

The Diagram control provides event support for the context menu that triggers when rendering the context menu and when clicking the items of the context menu.

### ContextMenuOpening

The Diagram control triggers the event [ContextMenuOpening](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ContextMenuSettings.html#Syncfusion_Blazor_Diagram_ContextMenuSettings_ContextMenuOpening) when performing right click on the diagram or the diagram elements such as Node, Connector and Groups.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px">
    // Defines context menu and ContextMenuOpening event
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
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/main/UG-Samples/ContextMenu/ContextMenuEvent)
### ContextMenuItemClicked

The Diagram control triggers the event [ContextMenuItemClicked](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ContextMenuSettings.html#Syncfusion_Blazor_Diagram_ContextMenuSettings_ContextMenuItemClicked) when the context menu item is clicked.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px">
    // Defines context menu and ContextMenuItemClicked event
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
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/main/UG-Samples/ContextMenu/ContextMenuEvent)
The following code example shows how to add separate custom context menu items for nodes and connectors. In the following code, the node color context menu item only renders for the node and the connector color context menu item only renders for the connector.

```cshtml
<SfDiagramComponent @ref="@diagram" Height="600px"
           Nodes="@NodeCollection"
           Connectors="@ConnectorCollection">
    
    <ContextMenuSettings Show="true" Items="@contextMenuItemModels" ShowCustomMenuOnly="true" ContextMenuOpening="@OnContextMenuOpen">
    </ContextMenuSettings>
</SfDiagramComponent>

@code
{
    //Reference to diagram
    SfDiagramComponent diagram;
    //Defines diagram's nodes collection
    public DiagramObjectCollection<Node> NodeCollection = new DiagramObjectCollection<Node>();
    //Defines diagram's connector collection
    public DiagramObjectCollection<Connector> ConnectorCollection = new DiagramObjectCollection<Connector>();

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
        NodeCollection.Add(node1);
        NodeCollection.Add(node2);

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
        ConnectorCollection.Add(connector1);
    }
    List<ContextMenuItem> contextMenuItemModels = new List<ContextMenuItem>()
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
        if (diagram.SelectionSettings.Nodes.Count > 0)
        {
            arg.HiddenItems.Add("Connector");
        }
        if (diagram.SelectionSettings.Connectors.Count > 0)
        {
            arg.HiddenItems.Add("Node");
        }
    }
}

```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/main/UG-Samples/ContextMenu/ContextMenuEvent)