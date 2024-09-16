---
layout: post
title: Data Binding in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Data Binding in Syncfusion Blazor Diagram component and much more.
platform: Blazor
control: Diagram
documentation: ug
---

# Data Binding in Blazor Diagram Component

* Diagram can be populated with the `Nodes` and `Connectors` based on the information provided from an external data source.

* Diagram exposes its specific data-related properties allowing you to specify the data source fields from where the node information has to be retrieved from.

* The [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramDataSource.html#Syncfusion_Blazor_Diagrams_DiagramDataSource_DataSource) property is used to define the data source either as a collection of objects or as an instance of [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramDataSource.html#Syncfusion_Blazor_Diagrams_DiagramDataSource_DataSource) that needs to be populated in the diagram.

* The `ID` property is used to define the unique field of each JSON data.

* The `ParentId` property is used to defines the parent field which builds the relationship between ID and parent field.

* The `Root` property is used to define the root node for the diagram populated from the data source.

* To explore those properties, see [DataSourceSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SfDiagram.html#Syncfusion_Blazor_Diagrams_SfDiagram_DataSourceSettings).

* Diagram supports two types of data binding. They are:

    1. Local data
    2. Remote data

## Local data

Diagram can be populated based on the user defined JSON data (Local Data) by mapping the relevant data source fields.

To map the user defined JSON data with diagram, configure the fields of [DataSourceSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SfDiagram.html#Syncfusion_Blazor_Diagrams_SfDiagram_DataSourceSettings). The following code example illustrates how to bind local data with the diagram.

```cshtml
@using Syncfusion.Blazor.Diagrams
@using System.Collections.ObjectModel

<SfDiagram Height="600px" Layout="@LayoutValue" ConnectorDefaults="@ConnectorDefault" NodeDefaults="@NodeDefaults">
    <DiagramDataSource Id="Name" ParentId="Category" DataSource="@DataSource" DataMapSettings="@datamap">
        <DiagramDataMapSettings>
            <DiagramDataMapSetting Property="Annotations[0].Content" Field="Name"></DiagramDataMapSetting>
        </DiagramDataMapSettings>
    </DiagramDataSource>
</SfDiagram>

@code
{
    //Defines diagram's nodes collection
    public ObservableCollection<DiagramNode> NodeCollection = new ObservableCollection<DiagramNode>();
    //Defines diagram's connector collection
    public ObservableCollection<DiagramConnector> ConnectorCollection = new ObservableCollection<DiagramConnector>();

    //Defines the node default values.
    DiagramNode NodeDefaults = new DiagramNode()
    {
        Width = 95,
        Height = 30,
        BackgroundColor = "#6BA5D7",
        Shape = new DiagramShape() { Type = Shapes.Basic, BasicShape = BasicShapes.Rectangle },
        Style = new NodeShapeStyle { Fill = "#ffeec7", StrokeColor = "#ffeec7", StrokeWidth = 1, },
        Annotations = new ObservableCollection<DiagramNodeAnnotation>()
        {
            new DiagramNodeAnnotation()
            {
                Id = "label1",
                Style = new AnnotationStyle()
                {
                    Color = "black"
                },
            }
        }
    };
    //Defines the connector's default values.
    DiagramConnector ConnectorDefault = new DiagramConnector
    {
        Type = Segments.Orthogonal,
        Style = new ConnectorShapeStyle() { StrokeColor = "#4d4d4d", StrokeWidth = 2 },
        TargetDecorator = new ConnectorTargetDecorator()
        {
            Shape = DecoratorShapes.None,
        }
    };
    //Create the layout info
    TreeInfo LayoutInfo = new TreeInfo()
    {
        //Enable the sub-tree.
        CanEnableSubTree = true,
        //Specify the sub-tree orientation
        Orientation = SubTreeOrientation.Horizontal,
    };
    //Create the data map settings.
    List<DiagramDataMapSetting> datamap { get; set; } = new List<DiagramDataMapSetting>()
    {
        new DiagramDataMapSetting() { Property = "Shape.TextContent", Field = "Name" }
    };

    DiagramLayout LayoutValue = new DiagramLayout() { };

    protected override void OnInitialized()
    {
        LayoutValue = new DiagramLayout()
        {
            Type = LayoutType.HierarchicalTree,
            VerticalSpacing = 30,
            HorizontalSpacing = 30,
            EnableAnimation = true,
            LayoutInfo = this.LayoutInfo
        };
    }

    //Create the hierarchical details with needed properties.
    public class HierarchicalDetails
    {
        public string Name { get; set; }
        public string FillColor { get; set; }
        public string Category { get; set; }
    }
    
    //Create the data source with node name and fill color values.
    public List<object> DataSource = new List<object>()
    {
        new HierarchicalDetails(){ Name ="Diagram", Category="",FillColor="#916DAF"},
        new HierarchicalDetails(){ Name ="Layout", Category="Diagram",FillColor=""},
        new HierarchicalDetails(){ Name ="Tree Layout", Category="Layout",FillColor=""},
        new HierarchicalDetails(){ Name ="Organizational Chart", Category="Layout",FillColor=""},
        new HierarchicalDetails(){ Name ="Hierarchical Tree", Category="Tree Layout",FillColor=""},
        new HierarchicalDetails(){ Name ="Radial Tree", Category="Tree Layout",FillColor=""},
        new HierarchicalDetails(){ Name ="Mind Map", Category="Hierarchical Tree",FillColor=""},
        new HierarchicalDetails(){ Name ="Family Tree", Category="Hierarchical Tree",FillColor=""},
        new HierarchicalDetails(){ Name ="Management", Category="Organizational Chart",FillColor=""},
        new HierarchicalDetails(){ Name ="Human Resources", Category="Management",FillColor=""},
        new HierarchicalDetails(){ Name ="University", Category="Management",FillColor=""},
        new HierarchicalDetails(){ Name ="Business", Category="#Management",FillColor=""}
    };
}
```

## See Also

* [How to arrange the diagram nodes and connectors using varies layout](https://blazor.syncfusion.com/documentation/diagram-classic/layout/automatic-layout)