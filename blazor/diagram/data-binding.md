---
layout: post
title: Data Binding in Blazor Diagram Component | Syncfusion
description: Learn here all about Data Binding such as local data, remote data in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Data Binding in Blazor Diagram Component

* [Diagram](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html) can be populated with the [Nodes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_Nodes) and [Connectors](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_Connectors) based on the information provided from an external data source.

* Diagram exposes its specific data-related properties allowing you to specify the data source fields from where the node information has to be retrieved.

* The [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DataSourceSettings.html#Syncfusion_Blazor_Diagram_DataSourceSettings_DataSource) property is used to define the data source either as a collection of objects or as an instance of `DataSource` that needs to be populated in the diagram.

* The [ID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DataSourceSettings.html#Syncfusion_Blazor_Diagram_DataSourceSettings_ID) property is used to define the unique field of each JSON data.

* The [ParentID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DataSourceSettings.html#Syncfusion_Blazor_Diagram_DataSourceSettings_ParentID) property is used to define the parent field which builds the relationship between ID and parent field.

* The [Root](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DataSourceSettings.html#Syncfusion_Blazor_Diagram_DataSourceSettings_Root) property is used to define the root node for the diagram populated from the data source.

* To explore those properties, see [DataSourceSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DataSourceSettings.html).

* Diagram supports two types of data binding. They are:

    1. Local data
    2. Remote data

## How to bind local data with diagram

Diagram can be populated based on the user defined JSON data (Local Data) by mapping the relevant data source fields.

To map the user defined JSON data with diagram, configure the fields of `DataSourceSettings`. The following code example illustrates how to bind local data with the diagram.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent @ref="@Diagram" 
                    Height="499px"
                    InteractionController="DiagramInteractions.ZoomPan" 
                    ConnectorCreating="@ConnectorDefaults" 
                    NodeCreating="@NodeDefaults">
    <DataSourceSettings ID="Name" ParentID="Category" DataSource="DataSource"/>
    <Layout @bind-Type="type" 
            @bind-HorizontalSpacing="@HorizontalSpacing" 
            @bind-Orientation="@orientation" 
            @bind-VerticalSpacing="@VerticalSpacing" 
            @bind-HorizontalAlignment="@horizontalAlignment" 
            @bind-VerticalAlignment="@verticalAlignment" 
            GetLayoutInfo="GetLayoutInfo">
        <LayoutMargin Top="50" Bottom="50" Right="50" Left="50"/>
    </Layout>
</SfDiagramComponent>

@code
{
    SfDiagramComponent Diagram;
    // Specify the layout type.
    LayoutType type = LayoutType.HierarchicalTree;
    // Specify the orientation of the layout.
    LayoutOrientation orientation = LayoutOrientation.TopToBottom;
    HorizontalAlignment horizontalAlignment = HorizontalAlignment.Auto;
    VerticalAlignment verticalAlignment = VerticalAlignment.Auto;
    int HorizontalSpacing = 30;
    int VerticalSpacing = 30;

    // Defines the connector's default values.
    private void ConnectorDefaults(IDiagramObject connector)
    {
        (connector as Connector).Type = ConnectorSegmentType.Orthogonal;
        (connector as Connector).TargetDecorator.Shape = DecoratorShape.None;
        (connector as Connector).Style = new ShapeStyle() { StrokeColor = "#6d6d6d" };
        (connector as Connector).Constraints = 0;
        (connector as Connector).CornerRadius = 5;
    }

    // Create the layout info.
    private TreeInfo GetLayoutInfo(IDiagramObject obj, TreeInfo options)
    {
        // Enable the sub-tree.
        options.EnableSubTree = true;
        // Specify the subtree orientation.
        options.Orientation = Orientation.Horizontal;
        return options;
    }

    // Defines the node's default values.
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
                Style =new TextStyle(){Color = "white"}
            }
        };
    }

    // Create the hierarchical details with needed properties.
    public class HierarchicalDetails
    {
        public string Name { get; set; }
        public string FillColor { get; set; }
        public string Category { get; set; }
    }

    // Create the data source with node name and fill color values.
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
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/DataBinding/LocalData)

## How to bind expandoObject data with diagram

Diagram is a generic component which is strongly bound to a model type. There are cases when the model type is unknown during compile time. In such circumstances data can be bound to the Diagram as a list of **ExpandoObjects**. 
Diagram can also perform all kind of supported Layout operations in ExpandoObjects such as,
* Hierarchical layout
* Organization chart
* Mind Map layout
* Complex Hierarchical Tree layout

The **ExpandoObject** can be bound to Diagram by assigning to the [DataSource] property of the [DataSourceSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DataSourceSettings.html).
The following code example illustrates how to bind ExpandoObject data with the diagram.


```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent @ref="@Diagram" 
                    Height="499px"
                    InteractionController="DiagramInteractions.ZoomPan" 
                    ConnectorCreating="@ConnectorDefaults" 
                    NodeCreating="@NodeDefaults">
    <DataSourceSettings ID="Name" ParentID="Category" DataSource="DataSource"/>
    <Layout @bind-Type="type" 
            @bind-HorizontalSpacing="@HorizontalSpacing" 
            @bind-Orientation="@orientation" 
            @bind-VerticalSpacing="@VerticalSpacing" 
            @bind-HorizontalAlignment="@horizontalAlignment" 
            @bind-VerticalAlignment="@verticalAlignment" 
            GetLayoutInfo="GetLayoutInfo">
        <LayoutMargin Top="50" Bottom="50" Right="50" Left="50"/>
    </Layout>
</SfDiagramComponent>

@code
{
    SfDiagramComponent Diagram;
    // Specify the layout type.
    LayoutType type = LayoutType.HierarchicalTree;
    // Specify the orientation of the layout.
    LayoutOrientation orientation = LayoutOrientation.TopToBottom;
    HorizontalAlignment horizontalAlignment = HorizontalAlignment.Auto;
    VerticalAlignment verticalAlignment = VerticalAlignment.Auto;
    int HorizontalSpacing = 30;
    int VerticalSpacing = 30;
    public List<ExpandoObject> DataSource { get; set; }
    public List<ExpandoObject> ExpandoData = new List<ExpandoObject>();

    // Defines the connector's default values.
    private void ConnectorDefaults(IDiagramObject connector)
    {
        (connector as Connector).Type = ConnectorSegmentType.Orthogonal;
        (connector as Connector).TargetDecorator.Shape = DecoratorShape.None;
        (connector as Connector).Style = new ShapeStyle() { StrokeColor = "#6d6d6d" };
        (connector as Connector).Constraints = 0;
        (connector as Connector).CornerRadius = 5;
    }

    // Create the layout info.
    private TreeInfo GetLayoutInfo(IDiagramObject obj, TreeInfo options)
    {
        // Enable the sub-tree.
        options.EnableSubTree = true;
        // Specify the subtree orientation.
        options.Orientation = Orientation.Horizontal;
        return options;
    }

    // Defines the node's default values.
    private void NodeDefaults(IDiagramObject obj)
    {
        Node node = obj as Node;
        if (node.Data is System.Text.Json.JsonElement)
        {
            node.Data = System.Text.Json.JsonSerializer.Deserialize<ExpandoObject>(node.Data.ToString());
        }
        dynamic hierarchicalData = node.Data as ExpandoObject;
        node.Style = new ShapeStyle() { Fill = "#659be5", StrokeColor = "none", StrokeWidth = 2, };
        node.BackgroundColor = "#659be5";
        node.Width = 150;
        node.Height = 50;
        node.Annotations = new DiagramObjectCollection<ShapeAnnotation>()
        {
            new ShapeAnnotation()
            {
                Content = hierarchicalData.Name,
                Style =new TextStyle(){Color = "white"}
            }
        };     
    }

     protected override void OnInitialized()
    {
        this.DataSource = GetData();
    }
    public List<ExpandoObject> GetData()
    {
        ExpandoData.Clear();
        dynamic Member1 = new ExpandoObject();

        Member1.Name = "Diagram";
        Member1.Category = "";
        Member1.FillColor = "#71AF17";
        ExpandoData.Add(Member1);

        dynamic Member2 = new ExpandoObject();

        Member2.Name = "Layout";
        Member2.Category = "Diagram";
        Member2.FillColor = "#659be5";
        ExpandoData.Add(Member2);

        dynamic Member3 = new ExpandoObject();

        Member3.Name = "Tree layout";
        Member3.Category = "Layout";
        Member3.FillColor = "#659be5";
        ExpandoData.Add(Member3);

        dynamic Member7 = new ExpandoObject();

        Member7.Name = "Organizational chart";
        Member7.Category = "Layout";
        Member7.FillColor = "#659be5";
        ExpandoData.Add(Member7);

        dynamic Member8 = new ExpandoObject();

        Member8.Name = "Hierarchical tree";
        Member8.Category = "Tree layout";
        Member8.FillColor = "#659be5";
        ExpandoData.Add(Member8);

        dynamic Member14 = new ExpandoObject();

        Member14.Name = "Radial tree";
        Member14.Category = "Tree layout";
        Member14.FillColor = "#659be5";
        ExpandoData.Add(Member14);

        dynamic Member9 = new ExpandoObject();

        Member9.Name = "Mind map";
        Member9.Category = "Hierarchical tree";
        Member9.FillColor = "#659be5";
        ExpandoData.Add(Member9);

        dynamic Member10 = new ExpandoObject();

        Member10.Name = "Family tree";
        Member10.Category = "Hierarchical tree";
        Member10.FillColor = "#659be5";
        ExpandoData.Add(Member10);

        dynamic Member4 = new ExpandoObject();

        Member4.Name = "Management";
        Member4.Category = "Organizational chart";
        Member4.FillColor = "#659be5";
        ExpandoData.Add(Member4);

        dynamic Member11 = new ExpandoObject();

        Member11.Name = "Human resources";
        Member11.Category = "Management";
        Member11.FillColor = "#659be5";
        ExpandoData.Add(Member11);

        dynamic Member12 = new ExpandoObject();

        Member12.Name = "University";
        Member12.Category = "Management";
        Member12.FillColor = "#659be5";
        ExpandoData.Add(Member12);

        return ExpandoData;
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/DataBinding/ExpandoObject)

##  How to bind dynamicObject data with diagram

Diagram is a generic component which is strongly bound to a model type. There are cases when the model type is unknown during compile time. In such circumstances data can be bound to the Diagram as a list of **DynamicObject**.
Diagram can also perform all kind of supported Layout operations in DynamicObject such as,
* Hierarchical layout
* Organization chart
* Mind Map layout
* Complex Hierarchical Tree layout

 The **DynamicObject** can be bound to Diagram by assigning to the [DataSource] property of the [DataSourceSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DataSourceSettings.html).
The following code example illustrates how to bind DynamicObject data with the diagram.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent @ref="@Diagram" 
                    Height="499px"
                    InteractionController="DiagramInteractions.ZoomPan" 
                    ConnectorCreating="@ConnectorDefaults" 
                    NodeCreating="@NodeDefaults">
    <DataSourceSettings ID="Name" ParentID="Category" DataSource="DataSource"/>
    <Layout @bind-Type="type" 
            @bind-HorizontalSpacing="@HorizontalSpacing" 
            @bind-Orientation="@orientation" 
            @bind-VerticalSpacing="@VerticalSpacing" 
            @bind-HorizontalAlignment="@horizontalAlignment" 
            @bind-VerticalAlignment="@verticalAlignment" 
            GetLayoutInfo="GetLayoutInfo">
        <LayoutMargin Top="50" Bottom="50" Right="50" Left="50"/>
    </Layout>
</SfDiagramComponent>

@code
{
    SfDiagramComponent Diagram;
    // Specify the layout type.
    LayoutType type = LayoutType.HierarchicalTree;
    // Specify the orientation of the layout.
    LayoutOrientation orientation = LayoutOrientation.TopToBottom;
    HorizontalAlignment horizontalAlignment = HorizontalAlignment.Auto;
    VerticalAlignment verticalAlignment = VerticalAlignment.Auto;
    int HorizontalSpacing = 30;
    int VerticalSpacing = 30;
    public List<HierarchicalDetails> DataSource { get; set; }
    public List<HierarchicalDetails> ExpandoData = new List<HierarchicalDetails>();

    // Defines the connector's default values.
    private void ConnectorDefaults(IDiagramObject connector)
    {
        (connector as Connector).Type = ConnectorSegmentType.Orthogonal;
        (connector as Connector).TargetDecorator.Shape = DecoratorShape.None;
        (connector as Connector).Style = new ShapeStyle() { StrokeColor = "#6d6d6d" };
        (connector as Connector).Constraints = 0;
        (connector as Connector).CornerRadius = 5;
    }

    // Create the layout info.
    private TreeInfo GetLayoutInfo(IDiagramObject obj, TreeInfo options)
    {
        // Enable the sub-tree.
        options.EnableSubTree = true;
        // Specify the subtree orientation.
        options.Orientation = Orientation.Horizontal;
        return options;
    }

    // Defines the node's default values.
    private void NodeDefaults(IDiagramObject obj)
    {
        Node node = obj as Node;
        if (node.Data is System.Text.Json.JsonElement)
        {
            node.Data = System.Text.Json.JsonSerializer.Deserialize<HierarchicalDetails>(node.Data.ToString());
        }
        dynamic hierarchicalData = node.Data as HierarchicalDetails;
        node.Style = new ShapeStyle() { Fill = "#659be5", StrokeColor = "none", StrokeWidth = 2, };
        node.BackgroundColor = "#659be5";
        node.Width = 150;
        node.Height = 50;
        node.Annotations = new DiagramObjectCollection<ShapeAnnotation>()
        {
            new ShapeAnnotation()
            {
                Content = hierarchicalData.Name,
                Style =new TextStyle(){Color = "white"}
            }
        };     
    }

    public class HierarchicalDetails:DynamicObject
    {
        Dictionary<string, object> dictionary = new Dictionary<string, object>();

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            string name = binder.Name;
            return dictionary.TryGetValue(name, out result);
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            dictionary[binder.Name] = value;
            return true;
        }

        public override System.Collections.Generic.IEnumerable<string> GetDynamicMemberNames()
        {
            return this.dictionary?.Keys;
        }

    }
    protected override void OnInitialized()
    {
        this.ExpandoDataSource = GetData();
    }
    public List<HierarchicalDetails> GetData()
    {
        ExpandoData.Clear();
        dynamic Member1 = new HierarchicalDetails();

        Member1.Name = "Diagram";
        Member1.Category = "";
        Member1.FillColor = "#71AF17";
        ExpandoData.Add(Member1);

        dynamic Member2 = new HierarchicalDetails();

        Member2.Name = "Layout";
        Member2.Category = "Diagram";
        Member2.FillColor = "#659be5";
        ExpandoData.Add(Member2);

        dynamic Member3 = new HierarchicalDetails();

        Member3.Name = "Tree layout";
        Member3.Category = "Layout";
        Member3.FillColor = "#659be5";
        ExpandoData.Add(Member3);

        dynamic Member7 = new HierarchicalDetails();

        Member7.Name = "Organizational chart";
        Member7.Category = "Layout";
        Member7.FillColor = "#659be5";
        ExpandoData.Add(Member7);

        dynamic Member8 = new HierarchicalDetails();

        Member8.Name = "Hierarchical tree";
        Member8.Category = "Tree layout";
        Member8.FillColor = "#659be5";
        ExpandoData.Add(Member8);

        dynamic Member14 = new HierarchicalDetails();

        Member14.Name = "Radial tree";
        Member14.Category = "Tree layout";
        Member14.FillColor = "#659be5";
        ExpandoData.Add(Member14);

        dynamic Member9 = new HierarchicalDetails();

        Member9.Name = "Mind map";
        Member9.Category = "Hierarchical tree";
        Member9.FillColor = "#659be5";
        ExpandoData.Add(Member9);

        dynamic Member10 = new HierarchicalDetails();

        Member10.Name = "Family tree";
        Member10.Category = "Hierarchical tree";
        Member10.FillColor = "#659be5";
        ExpandoData.Add(Member10);

        dynamic Member4 = new HierarchicalDetails();

        Member4.Name = "Management";
        Member4.Category = "Organizational chart";
        Member4.FillColor = "#659be5";
        ExpandoData.Add(Member4);

        dynamic Member11 = new HierarchicalDetails();

        Member11.Name = "Human resources";
        Member11.Category = "Management";
        Member11.FillColor = "#659be5";
        ExpandoData.Add(Member11);

        dynamic Member12 = new HierarchicalDetails();

        Member12.Name = "University";
        Member12.Category = "Management";
        Member12.FillColor = "#659be5";
        ExpandoData.Add(Member12);

        return ExpandoData;
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/DataBinding/DynamicObj)

## How to bind json data with diagram

Local JSON data can be bound to the Diagram component by assigning the array of objects to the Json property of the SfDataManager component.

The following sample code demonstrates binding local data through the SfDataManager to the Diagram component,

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Data

<SfDiagramComponent @ref="Diagram" Width="1000px" Height="500px"
                    NodeCreating="NodeDefaults" SetNodeTemplate="SetTemplate">
    <DataSourceSettings ID="Name" ParentID="Category">
        <SfDataManager Json="DataSource" Adaptor="Syncfusion.Blazor.Adaptors.JsonAdaptor"></SfDataManager>
    </DataSourceSettings>
    <Layout HorizontalSpacing="40" VerticalSpacing="40" Type="LayoutType.HierarchicalTree"></Layout>
</SfDiagramComponent>

@code
{
    SfDiagramComponent Diagram;
    float x = 100;
    float y = 100;
    Query Query = new Query().Select(new List<string>() { "EmployeeID", "ReportsTo", "FirstName" }).Take(9);

    // Create the hierarchical details with needed properties.
    public class HierarchicalDetails
    {
        public string Name { get; set; }
        public string FillColor { get; set; }
        public string Category { get; set; }
    }

    // Create the data source with node name and fill color values.
    public HierarchicalDetails[] DataSource = new HierarchicalDetails[]
    {
        new HierarchicalDetails(){ Name ="Diagram", Category="",FillColor="#659be5"},
        new HierarchicalDetails(){ Name ="Layout", Category="Diagram",FillColor="#659be5"},
        new HierarchicalDetails(){ Name ="Organizational chart", Category="Diagram",FillColor="#659be5"},
        new HierarchicalDetails(){ Name ="Tree layout", Category="Layout",FillColor="#659be5"},
        new HierarchicalDetails(){ Name ="Hierarchical tree", Category="Tree layout",FillColor="#659be5"},
    };
    
    // Defines the node's default values.
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

    private CommonElement SetTemplate(IDiagramObject node)
    {
        return null;
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/DataBinding/JSONData)

## How to bind remote data with diagram

To bind remote data to [Diagram component](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html), assign service data as an instance of [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) to the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DataSourceSettings.html#Syncfusion_Blazor_Diagram_DataSourceSettings_DataSource) property or by using SfDataManager component. To interact with remote data source, provide the endpoint Url.

When using SfDataManager for data binding then the TValue must be provided explicitly in the diagram component. By default, SfDataManager uses ODataAdaptor for remote data-binding.

### Binding with OData v4 services

The ODataV4 is an improved version of OData protocols, and the SfDataManager can also retrieve and consume OData v4 services. For more details on OData v4 services, refer to the [OData documentation](http://docs.oasis-open.org/odata/odata/v4.0/errata03/os/complete/part1-protocol/odata-v4.0-errata03-os-part1-protocol-complete.html#_Toc453752197). To bind OData v4 service, use the ODataV4Adaptor.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Data

<div style="width:100%">
    <div style="width:70%">
        <SfDiagramComponent Height="400px" InteractionController="@DiagramInteractions.ZoomPan" 
                            NodeCreating="OnNodeCreating" ConnectorCreating="OnConnectorCreating" SetNodeTemplate="SetTemplate">
            <DataSourceSettings Id="EmployeeID" ParentId="ReportsTo">
                <SfDataManager Url="https://services.odata.org/V4/Northwind/Northwind.svc/Employees" Adaptor="Syncfusion.Blazor.Adaptors.ODataV4Adaptor"></SfDataManager>
            </DataSourceSettings>
            <SnapSettings Constraints ="SnapConstraints.None"></SnapSettings>
            <Layout HorizontalSpacing="40" VerticalSpacing="40" Type="LayoutType.HierarchicalTree"></Layout>
        </SfDiagramComponent>
    </div>
</div>

@code
{
    SfDiagramComponent Diagram;
    private float x = 100;
    private float y = 100;
    public class Employee
    {
        public int? EmployeeID { get; set; }
        public string FirstName { get; set; }
        public int? ReportsTo { get; set; }
    }
    private Query Query = new Query().Select(new List<string>() { "EmployeeID", "ReportsTo", "FirstName" }).Take(9);
    private void OnNodeCreating(IDiagramObject obj)
    {
        Node node = obj as Node;
        node.OffsetX = x;
        node.OffsetY = y;
        node.Width = 80;
        node.Height = 40;        
        node.Shape = new BasicShape() { Type = Syncfusion.Blazor.Diagram.NodeShapes.Basic, Shape = NodeBasicShapes.Rectangle, CornerRadius = 8 };
        node.Style = new ShapeStyle() { StrokeWidth = 0, Fill = "" };
        x += 100;

        Dictionary<string, object> data = node.Data as Dictionary<string, object>;
        node.Annotations = new DiagramObjectCollection<ShapeAnnotation>()
        {
            new ShapeAnnotation()
            {
                Content = data["FirstName"].ToString(),
                Style = new TextStyle(){ Color = "white"}
            }
        };
        if (data["FirstName"].ToString() == "Andrew")
        {
            node.Style.Fill = "#3A4857";
        }
        else if (data["FirstName"].ToString() == "Nancy")
        {
            node.Style.Fill = "#2B8C68";
        }
        else if (data["FirstName"].ToString() == "Janet")
        {
            node.Style.Fill = "#488CC1";
        }
        else if (data["FirstName"].ToString() == "Janet")
        {
            node.Style.Fill = "#488CC1";
        }
        else if (data["FirstName"].ToString() == "Margaret")
        {
            node.Style.Fill = "#4C888F";
        }
        else if (data["FirstName"].ToString() == "Steven")
        {
            node.Style.Fill = "#8E4DB4";
        }
        else if (data["FirstName"].ToString() == "Laura")
        {
            node.Style.Fill = "#CD6A32";
        }
        else
        {
            node.Style.Fill = "#8E4DB4";
        }
    }
    private void OnConnectorCreating(IDiagramObject obj)
    {
        Connector connector = obj as Connector;
        connector.Style.StrokeColor = "#048785";
        connector.Type = ConnectorSegmentType.Orthogonal;
        connector.TargetDecorator.Shape = DecoratorShape.None;
        connector.SourceDecorator.Shape = DecoratorShape.None;
        connector.Style = new ShapeStyle() { StrokeColor = "#3A4857", Fill = "#3A4857", StrokeWidth = 1, StrokeDashArray = "3,3" };
    }
    private CommonElement SetTemplate(IDiagramObject node)
    {
        return null;
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/DataBinding/RemoteData)

## See Also

* [How to arrange the diagram nodes and connectors using varies layout](./layout/automatic-layout/)
