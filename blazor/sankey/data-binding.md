---
layout: post
title: Data Binding for Blazor Sankey Diagram | Syncfusion
description: Learn how to bind nodes and links to the Syncfusion Blazor Sankey Diagram, including data models, REST API binding and JSON response format.
platform: Blazor
control: Sankey
documentation: ug
---

# Data Binding in the Blazor Sankey Diagram

The Blazor Sankey Diagram visualizes relationships and flows between categories using nodes and links. Data binding supplies the node and link information required to render the diagram effectively.

## Overview of Data Binding

The Sankey Diagram accepts data for:

1. **Nodes**: Entities or categories in the flow.
2. **Links**: Connections between nodes, including the magnitude of each flow.

Bind data using collections of objects that define node and link properties. The component generates the diagram based on this data.

## Understanding Data Models
The Blazor Sankey Diagram uses predefined data models for nodes and links available in the `Syncfusion.Blazor.Sankey` namespace. Key properties include:

### SankeyDataNode
- `Id`: Unique identifier for the node.
- `Label`: An instance of `SankeyDataLabel` to customize the node label.

### SankeyDataLink
- `SourceId`: Identifier of the source node.
- `TargetId`: Identifier of the target node.
- `Value`: Weight or magnitude of the connection.

These types are provided by the Syncfusion<sup style="font-size:70%">&reg;</sup> library; custom class definitions are not required.

## Binding Data to the Sankey Diagram
Create collections of `SankeyDataNode` and `SankeyDataLink` and assign them to the component.

Below is an example of binding data to the Sankey Diagram in a Blazor application:

{% tabs %}
{% highlight razor %}

<SfSankey Nodes=@Nodes Links=@Links>
</SfSankey>

@code {
    public List<SankeyDataNode> Nodes = new List<SankeyDataNode>();
    public List<SankeyDataLink> Links = new List<SankeyDataLink>();

    protected override void OnInitialized()
    {
        Nodes = new List<SankeyDataNode>()
        {
            new SankeyDataNode() { Id = "Coffee Production" },
            new SankeyDataNode() { Id = "Arabica" },
            new SankeyDataNode() { Id = "Robusta" },
            new SankeyDataNode() { Id = "Roasted Coffee" },
            new SankeyDataNode() { Id = "Instant Coffee" },
            new SankeyDataNode() { Id = "Green Coffee" },
            new SankeyDataNode() { Id = "North America" },
            new SankeyDataNode() { Id = "Europe" },
            new SankeyDataNode() { Id = "Asia Pacific" }
        };
        Links = new List<SankeyDataLink>()
        {
            new SankeyDataLink() { SourceId = "Coffee Production", TargetId = "Arabica", Value = 95 },
            new SankeyDataLink() { SourceId = "Coffee Production", TargetId = "Robusta", Value = 65 },
            new SankeyDataLink() { SourceId = "Arabica", TargetId = "Roasted Coffee", Value = 60 },
            new SankeyDataLink() { SourceId = "Arabica", TargetId = "Instant Coffee", Value = 20 },
            new SankeyDataLink() { SourceId = "Arabica", TargetId = "Green Coffee", Value = 15 },
            new SankeyDataLink() { SourceId = "Robusta", TargetId = "Roasted Coffee", Value = 30 },
            new SankeyDataLink() { SourceId = "Robusta", TargetId = "Instant Coffee", Value = 25 },
            new SankeyDataLink() { SourceId = "Robusta", TargetId = "Green Coffee", Value = 10 },
            new SankeyDataLink() { SourceId = "Roasted Coffee", TargetId = "North America", Value = 35 },
            new SankeyDataLink() { SourceId = "Roasted Coffee", TargetId = "Europe", Value = 30 },
            new SankeyDataLink() { SourceId = "Roasted Coffee", TargetId = "Asia Pacific", Value = 25 },
            new SankeyDataLink() { SourceId = "Instant Coffee", TargetId = "North America", Value = 15 },
            new SankeyDataLink() { SourceId = "Instant Coffee", TargetId = "Europe", Value = 15 },
            new SankeyDataLink() { SourceId = "Instant Coffee", TargetId = "Asia Pacific", Value = 15 },
            new SankeyDataLink() { SourceId = "Green Coffee", TargetId = "North America", Value = 10 },
            new SankeyDataLink() { SourceId = "Green Coffee", TargetId = "Europe", Value = 8 },
            new SankeyDataLink() { SourceId = "Green Coffee", TargetId = "Asia Pacific", Value = 7 }
        };
        base.OnInitialized();
    }
}

{% endhighlight %}
{% endtabs %}

![Blazor Sankey Data](images/data-binding/sankey-data-binding.png)

### Key Points

- `Nodes` expects a collection of `SankeyDataNode` objects.
- `Links` expects a collection of `SankeyDataLink` objects.
- `SourceId` and `TargetId` values in `SankeyDataLink` must match the corresponding `Id` values in `SankeyDataNode`.

## Advanced Binding Scenarios

Data can be sourced from:
- REST APIs: Fetch data dynamically via HTTP requests.
- Databases: Load data using Entity Framework or another ORM.
- JSON files: Deserialize JSON into node and link models.

### Example: Binding Data from a REST API

{% tabs %}
{% highlight razor %}

@inject HttpClient HttpClient

<SfSankey Nodes=@Nodes Links=@Links>
</SfSankey>

@code {
    public List<SankeyDataNode> Nodes = new List<SankeyDataNode>();
    public List<SankeyDataLink> Links = new List<SankeyDataLink>();

    protected override async Task OnInitializedAsync()
    {
        var data = await HttpClient.GetFromJsonAsync<SankeyDataResponse>("api/sankey");
        Nodes = data.Nodes;
        Links = data.Links;
    }

    public class SankeyDataResponse
    {
        public List<SankeyDataNode> Nodes { get; set; }
        public List<SankeyDataLink> Links { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}


### Updated REST API Example
The API endpoint should return a JSON response in the following format:

{% tabs %}
{% highlight json %}

{
    "Nodes": [
        { "Id": "Coffee Production" },
        { "Id": "Arabica" },
        { "Id": "Robusta" },
        ...
    ],
    "Links": [
        { "SourceId": "Coffee Production", "TargetId": "Arabica", "Value": 95 },
        { "SourceId": "Coffee Production", "TargetId": "Robusta", "Value": 65 },
        ...
    ]
}

{% endhighlight %}
{% endtabs %}

## See also

* [Nodes](./nodes)
* [Links](./links)
* [Labels](./labels)
