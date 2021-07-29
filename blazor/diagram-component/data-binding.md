---
layout: post
title: Data Binding in Blazor Diagram Component | Syncfusion
description: Learn here all about Data Binding such as local data , remote data in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Data Binding in Blazor Diagram Component

* Diagram can be populated with the `Nodes` and `Connectors` based on the information provided from an external data source.

* Diagram exposes its specific data-related properties allowing you to specify the data source fields from where the node information has to be retrieved from.

* The `DataSource` property is used to define the data source either as a collection of objects or as an instance of `DataSource` that needs to be populated in the diagram.

* The `ID` property is used to define the unique field of each JSON data.

* The `ParentId` property is used to defines the parent field which builds the relationship between ID and parent field.

* The `Root` property is used to define the root node for the diagram populated from the data source.

* To explore those properties, see `DataSourceSettings`.

* Diagram supports two types of data binding. They are:

    1. Local data
    2. Remote data

## Local data

Diagram can be populated based on the user defined JSON data (Local Data) by mapping the relevant data source fields.

To map the user defined JSON data with diagram, configure the fields of `DataSourceSettings`. The following code example illustrates how to bind local data with the diagram.

```csharp
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Diagram.Internal

<SfDiagramComponent @ref="@Diagram" Height="499px" Tool="@DiagramTools.ZoomPan" ConnectorDefaults="@ConnectorDefaults" NodeDefaults="@NodeDefaults">
    <DataSourceSettings Id="Name" ParentId="Category" DataSource="DataSource"> </DataSourceSettings>
    <Layout @bind-Type="type" @bind-HorizontalSpacing="@HorizontalSpacing" @bind-Orientation="@orientation" @bind-VerticalSpacing="@VerticalSpacing" @bind-HorizontalAlignment="@horizontalAlignment" @bind-VerticalAlignment="@verticalAlignment" GetLayoutInfo="GetLayoutInfo">
        <LayoutMargin @bind-Top="@top" @bind-Bottom="@bottom" @bind-Right="@right" @bind-Left="@left"></LayoutMargin>
    </Layout>
</SfDiagramComponent>

@code
{
    SfDiagramComponent Diagram;
    double top = 50;
    double bottom = 50;
    double right = 50;
    double left = 50;
    LayoutType type = LayoutType.HierarchicalTree;
    LayoutOrientation orientation = LayoutOrientation.TopToBottom;
    HorizontalAlignment horizontalAlignment = HorizontalAlignment.Auto;
    VerticalAlignment verticalAlignment = VerticalAlignment.Auto;
    int HorizontalSpacing = 30;
    int VerticalSpacing = 30;

    private void ConnectorDefaults(IDiagramObject connector)
    {
        (connector as Connector).Type = Segments.Orthogonal;
        (connector as Connector).TargetDecorator.Shape = DecoratorShapes.None;
        (connector as Connector).Style = new ShapeStyle() { StrokeColor = "#6d6d6d" };
        (connector as Connector).Constraints = 0;
        (connector as Connector).CornerRadius = 5;
    }

    private TreeInfo GetLayoutInfo(IDiagramObject obj, TreeInfo options)
    {
        options.CanEnableSubTree = true;
        options.Orientation = SubTreeOrientation.Horizontal;
        return options;
    }
    private void NodeDefaults(IDiagramObject obj)
    {
        Node node = obj as Node;
        if (node.Data is System.Text.Json.JsonElement)
        {
            node.Data = System.Text.Json.JsonSerializer.Deserialize<HierarchicalDetails>(node.Data.ToString());
        }
        HierarchicalDetails hierarchicalData = node.Data as HierarchicalDetails;
        node.Style = new ShapeStyle() { Fill = "#659be5", StrokeColor = "none", StrokeWidth = 2, };
        node.BackgroundColor = "#659be5";
        node.Width = 150;
        node.Height = 50;
        node.Annotations = new DiagramObjectCollection<ShapeAnnotation>()
{
            new ShapeAnnotation()
            {
                Content = hierarchicalData.Name,
                Style =new TextShapeStyle(){Color = "white"}
            }
        };
    }

    public class HierarchicalDetails
    {
        public string Name { get; set; }
        public string FillColor { get; set; }
        public string Category { get; set; }

    }
    public List<HierarchicalDetails> DataSource = new List<HierarchicalDetails>()
{
        new HierarchicalDetails(){ Name ="Diagram", Category="",FillColor="#659be5"},
        new HierarchicalDetails(){ Name ="Layout", Category="Diagram",FillColor="#659be5"},
        new HierarchicalDetails(){ Name ="Tree layout", Category="Layout",FillColor="#659be5"},
        new HierarchicalDetails(){ Name ="Organizational chart", Category="Layout",FillColor="#659be5"},
        new HierarchicalDetails(){ Name ="Hierarchical tree", Category="Tree layout",FillColor="#659be5"},
        new HierarchicalDetails(){ Name ="Radial tree", Category="Tree layout",FillColor="#659be5"},
        new HierarchicalDetails(){ Name ="Mind map", Category="Hierarchical tree",FillColor="#659be5"},
        new HierarchicalDetails(){ Name ="Family tree", Category="Hierarchical tree",FillColor="#659be5"},
        new HierarchicalDetails(){ Name ="Management", Category="Organizational chart",FillColor="#659be5"},
        new HierarchicalDetails(){ Name ="Human resources", Category="Management",FillColor="#659be5"},
        new HierarchicalDetails(){ Name ="University", Category="Management",FillColor="#659be5"},
        new HierarchicalDetails(){ Name ="Business", Category="#Management",FillColor="#659be5"}
    };
}
```

## JSON Data

Local JSON data can be bound to the Diagram component by assigning the array of objects to the Json property of the SfDataManager component.

The following sample code demonstrates binding local data through the SfDataManager to the Diagram component,

```csharp
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Data
@using System.Collections.ObjectModel

<SfDiagramComponent @ref="Diagram" Width="1000px" Height="500px"
                    NodeDefaults="NodeDefaults" SetNodeTemplate="SetTemplate">
    <DataSourceSettings Id="Name" ParentId="Category">
        <SfDataManager Json="DataSource" Adaptor="Syncfusion.Blazor.Adaptors.JsonAdaptor"></SfDataManager>
    </DataSourceSettings>
    <Layout HorizontalSpacing="40" VerticalSpacing="40" Type="LayoutType.HierarchicalTree"></Layout>
</SfDiagramComponent>

@code{
    SfDiagramComponent Diagram;

    float x = 100;
    float y = 100;
    Query Query = new Query().Select(new List<string>() { "EmployeeID", "ReportsTo", "FirstName" }).Take(9);
    public class HierarchicalDetails
    {
        public string Name { get; set; }
        public string FillColor { get; set; }
        public string Category { get; set; }
    }
    public HierarchicalDetails[] DataSource = new HierarchicalDetails[]
    {
        new HierarchicalDetails(){ Name ="Diagram", Category="",FillColor="#659be5"},
        new HierarchicalDetails(){ Name ="Layout", Category="Diagram",FillColor="#659be5"},
        new HierarchicalDetails(){ Name ="Organizational chart", Category="Diagram",FillColor="#659be5"},
        new HierarchicalDetails(){ Name ="Tree layout", Category="Layout",FillColor="#659be5"},
        new HierarchicalDetails(){ Name ="Hierarchical tree", Category="Tree layout",FillColor="#659be5"},
    };

    private void NodeDefaults(IDiagramObject obj)
    {
        Node node = obj as Node;
        node.OffsetX = x;
        node.OffsetY = y;
        x += 100;

        HierarchicalDetails hierarchicalData = node.Data as HierarchicalDetails;
        node.Style.Fill = hierarchicalData.FillColor;
        node.Annotations = new DiagramObjectCollection<ShapeAnnotation>()
        {
            new ShapeAnnotation()
            {
                Content = hierarchicalData.Name
            }
        };
    }

    private ICommonElement SetTemplate(IDiagramObject node)
    {
        return null;
    }
}
```

## Remote Data

To bind remote data to Diagram component, assign service data as an instance of SfDataManager to the DataSource property or by using SfDataManager component. To interact with remote data source, provide the endpoint Url.

When using SfDataManager for data binding then the TValue must be provided explicitly in the diagram component. By default, SfDataManager uses ODataAdaptor for remote data-binding.

### Binding with OData v4 services

The ODataV4 is an improved version of OData protocols, and the SfDataManager can also retrieve and consume OData v4 services. For more details on OData v4 services, refer to the OData documentation. To bind OData v4 service, use the ODataV4Adaptor.

```csharp
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Data

<SfDiagramComponent @ref="Diagram" Width="1000px" Height="500px"
                            NodeDefaults="NodeDefaults"  SetNodeTemplate="SetTemplate">
    <DataSourceSettings Id="EmployeeID" ParentId="ReportsTo">
        <SfDataManager Url="https://services.odata.org/V4/Northwind/Northwind.svc/Employees" Adaptor="Syncfusion.Blazor.Adaptors.ODataV4Adaptor"></SfDataManager>
    </DataSourceSettings>
    <Layout HorizontalSpacing="40" VerticalSpacing="40" Type="LayoutType.HierarchicalTree"></Layout>
</SfDiagramComponent>

@code
{
    SfDiagramComponent Diagram;
    float x = 100;
    float y = 100;
    public class Employee
    {
        public int? EmployeeID { get; set; }
        public string FirstName { get; set; }
        public int? ReportsTo { get; set; }
    }
    Query Query = new Query().Select(new List<string>() { "EmployeeID", "ReportsTo", "FirstName" }).Take(9);
    private void NodeDefaults(IDiagramObject obj)
    {
        Node node = obj as Node;
        node.OffsetX = x;
        node.OffsetY = y;
        x += 100;
        Employee data = System.Text.Json.JsonSerializer.Deserialize<Employee>(node.Data.ToString());
        node.Annotations = new DiagramObjectCollection<ShapeAnnotation>()
        {
            new ShapeAnnotation()
            {
                Content = data.FirstName
            }
        };
    }
  
    private ICommonElement SetTemplate(IDiagramObject node)
    {
        return null;
    }
}
```

## See Also

* [How to arrange the diagram nodes and connectors using varies layout](./layout/automatic-layout/)
