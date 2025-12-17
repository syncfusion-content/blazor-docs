---
layout: post
title: Force Directed Tree Layout in Blazor Diagram Component | Syncfusion
description: Learn here all about how to create force directed tree layout in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Force-Directed Tree Layout in Blazor Diagram Component

The Force-Directed Tree Layout is a physics-based algorithm that arranges nodes by simulating attractive and repulsive forces. This layout is ideal for visualizing complex relationships such as social networks, dependency graphs, and knowledge maps.

## How the Force-Directed Tree Layout Works

The Force-Directed Tree Layout uses a simulation of physical forces to position nodes in a visually balanced way:

- Repulsive Force: Each node pushes away other nodes, similar to charged particles, to prevent overlap.
- Attractive Force: Connectors act like springs, pulling connected nodes closer together to maintain relationships.

## Configure Force-Directed Tree Layout Settings

To enable the Force-Directed Tree Layout, set the Layout.Type property to **LayoutType.ForceDirectedTree** and configure the `ForceDirectedTreeLayoutSettings` class, which provides control over the simulation.

## Layout Properties

### ConnectorLength

Defines the ideal distance between connected nodes.

>**Note:** Minimum value: 30.  Larger values spread nodes farther apart.

### MaximumIteration

Specifies how many times the algorithm runs to stabilize the layout.

>**Note:** Minimum value: 100. Higher values improve stability but increase processing time.

### RepulsionStrength

Controls how strongly nodes repel each other.

The following example increases the repulsion strength to spread out nodes further.

>**Note:** Minimum value: 3000. Higher values create more space between nodes.

### AttractionStrength

Determines how strongly connected nodes pull toward each other.

>**Note:** Range: 0 to 1. Higher values cluster connected nodes more tightly.

The following example demonstrates how to customize the properties of the Force-Directed Tree layout.
```
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent @ref="@diagram" Height="690px" Width="100%" @bind-Nodes="@Nodes" @bind-Connectors="@Connectors">
    <SnapSettings Constraints="@SnapConstraints.None"></SnapSettings>
    <Layout Type="LayoutType.ForceDirectedTree" @bind-ForceDirectedTreeLayoutSettings="@settings"></Layout>
</SfDiagramComponent>

@code {
    private SfDiagramComponent diagram;
    private DiagramObjectCollection<Node> Nodes = new DiagramObjectCollection<Node>();
    private DiagramObjectCollection<Connector> Connectors = new DiagramObjectCollection<Connector>();
    
    private ForceDirectedTreeLayoutSettings settings = new ForceDirectedTreeLayoutSettings
    {
        ConnectorLength = 120,
        MaximumIteration = 1500,
        RepulsionStrength = 20000,
        AttractionStrength = 0.8
    };

    // Easy sizing controls
    private int DepartmentsUnderCeo { get; set; } = 4;
    private int ManagersPerDepartment { get; set; } = 4;
    private int TeamsPerManager { get; set; } = 6;

    protected override void OnInitialized()
    {
        PopulateDiagram();
    }

    private void PopulateDiagram()
    {
        List<OrgItem> data = GetCompanyOrgData();
        PopulateDiagramFromData(data);
    }

    private void PopulateDiagramFromData(IEnumerable<OrgItem> items)
    {
        Dictionary<string, OrgItem> byId = items.ToDictionary(x => x.Id);
        foreach (OrgItem item in items)
        {
            Node node = CreateOrgNode(item);
            Nodes!.Add(node);
            if (!string.IsNullOrEmpty(item.ParentId) && byId.ContainsKey(item.ParentId))
            {
                Connectors!.Add(CreateConnector(item.ParentId, item.Id));
            }
        }
    }

    private Node CreateOrgNode(OrgItem item)
    {
        ShapeStyle style = new ShapeStyle { Fill = "orange", StrokeWidth = 2, StrokeColor = "#8c8c8c" };
        double width = 35; 
        double height = 35;
        Shape shape = new BasicShape() { Shape = NodeBasicShapes.Ellipse };

        switch (item.Level)
        {
            case OrgLevel.Header:
                style.Fill = "#f39c12";
                width = height = 140;
                shape = new BasicShape { Shape = NodeBasicShapes.Ellipse };
                break;
            case OrgLevel.Department:
                style.Fill = "#27ae60";
                width = height = 120;
                shape = new BasicShape { Shape = NodeBasicShapes.Ellipse };
                break;
            case OrgLevel.Manager:
                style.Fill = "#2980b9";
                shape = new BasicShape { Shape = NodeBasicShapes.Ellipse };
                width = height = 100;
                break;
            case OrgLevel.Team:
                style.Fill = "#f39c12";
                shape = new BasicShape { Shape = NodeBasicShapes.Ellipse };
                width = height = 80;
                break;
        }

        return new Node
        {
            ID = item.Id,
            Width = width,
            Height = height,
            Shape = shape,
            Annotations = new DiagramObjectCollection<ShapeAnnotation>
            {
                new ShapeAnnotation 
                { 
                    ID = $"{item.Id}_label", 
                    Content = item.Name, 
                    Style = new TextStyle() { FontSize = 18, Bold = true, Color = "white" } 
                }
            },
            Style = style
        };
    }

    private Connector CreateConnector(string sourceId, string targetId)
    {
        return new Connector
        {
            ID = $"{sourceId}_{targetId}",
            SourceID = sourceId,
            TargetID = targetId,
            Type = ConnectorSegmentType.Straight
        };
    }

    private enum OrgLevel
    {
        Header,
        Department,
        Manager,
        Team
    }

    public class OrgItem
    {
        public string Id { get; set; } = "";
        public string? ParentId { get; set; }
        public string Name { get; set; } = "";
        public OrgLevel Level { get; set; }
    }

    // Parametrized generator
    private static List<OrgItem> BuildOrgData(int departments, int managersPerDept, int teamsPerManager)
    {
        List<OrgItem> data = new List<OrgItem>
        {
            new OrgItem { Id = "departments", ParentId = null, Name = "Departments", Level = OrgLevel.Header }
        };

        // Departments
        for (int d = 1; d <= departments; d++)
        {
            string deptId = $"dept_{d}";
            data.Add(new OrgItem { Id = deptId, ParentId = "departments", Name = $"Department {d}", Level = OrgLevel.Department });

            // Managers
            for (int m = 1; m <= managersPerDept; m++)
            {
                string mgrId = $"{deptId}_mgr_{m}";
                data.Add(new OrgItem { Id = mgrId, ParentId = deptId, Name = $"Manager {d}.{m}", Level = OrgLevel.Manager });

                // Teams
                for (int t = 1; t <= teamsPerManager; t++)
                {
                    string teamId = $"{mgrId}_team_{t}";
                    data.Add(new OrgItem
                    {
                        Id = teamId,
                        ParentId = mgrId,
                        Name = $"Team {d}.{m}.{t}",
                        Level = OrgLevel.Team
                    });
                }
            }
        }
        return data;
    }

    // A realistic software-company hierarchy: 1 CEO has 4 depts each with 4 managers each to 6 teams each
    private static List<OrgItem> GetCompanyOrgData()
    {
        List<OrgItem> data = new List<OrgItem>();

        // CEO
        data.Add(new OrgItem { Id = "departments", ParentId = null, Name = "Departments", Level = OrgLevel.Header });

        // Departments (Level 2)
        List<OrgItem> departments = new List<OrgItem>
        {
            new OrgItem { Id = "uxTeam", ParentId = "departments", Name = "UX Team", Level = OrgLevel.Department },
            new OrgItem { Id = "devTeam", ParentId = "departments", Name = "Development Team", Level = OrgLevel.Department },
            new OrgItem { Id = "salesTeam", ParentId = "departments", Name = "Sales Team", Level = OrgLevel.Department },
            new OrgItem { Id = "hrTeam", ParentId = "departments", Name = "HR Team", Level = OrgLevel.Department }
        };

        foreach (OrgItem d in departments)
            data.Add(d);

        // Managers per department (Level 3) for 4 per department
        Dictionary<string, (string id, string name)[]> managersByDept = new Dictionary<string, (string id, string name)[]>
        {
            ["uxTeam"] = new[]
            {
                ("mgr1", "Manager-1"),
                ("mgr2", "Manager-2"),
            },
            ["devTeam"] = new[]
            {
                ("po1", "PO-1"),
                ("po2", "PO-2"),
                ("po3", "PO-3"),
                ("po4", "PO-4"),
            },
            ["salesTeam"] = new[]
            {
                ("agm1", "AGM-1"),
                ("agm2", "AGM-2"),
            },
            ["hrTeam"] = new[]
            {
                ("hr_mgr", "Manager"),
            },
        };

        foreach (string dept in managersByDept.Keys)
        {
            foreach ((string id, string name) m in managersByDept[dept])
                data.Add(new OrgItem { Id = m.id, ParentId = dept, Name = m.name, Level = OrgLevel.Manager });
        }

        // Teams per manager (Level 4) variable per requirements
        Dictionary<string, int> teamCountByManager = new Dictionary<string, int>
        {
            ["mgr1"] = 3,
            ["mgr2"] = 3,
            ["po1"] = 4,
            ["po2"] = 4,
            ["po3"] = 4,
            ["po4"] = 4,
            ["agm1"] = 3,
            ["agm2"] = 3,
            ["hr_mgr"] = 2,
        };

        foreach (string dept in managersByDept.Keys)
        {
            foreach ((string mid, string mname) mm in managersByDept[dept])
            {
                int count = teamCountByManager.ContainsKey(mm.mid) ? teamCountByManager[mm.mid] : 0;
                for (int i = 1; i <= count; i++)
                {
                    string teamId = $"{mm.mid}_t{i}";
                    data.Add(new OrgItem
                    {
                        Id = teamId,
                        ParentId = mm.mid,
                        Name = $"Team-{i}",
                        Level = OrgLevel.Team
                    });
                }
            }
        }
        return data;
    }
}
```

## How to Create a Force-Directed Tree Using DataSource

A Force-Directed Tree layout can be created with [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DataSourceSettings.html#Syncfusion_Blazor_Diagram_DataSourceSettings_DataSource). The following code demonstrates how to render a Force-Directed Tree layout using DataSource.

```csharp
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" NodeCreating="@OnNodeCreating">
    <DataSourceSettings ID="Id" ParentID="Manager" DataSource="DataSource"></DataSourceSettings>
    <Layout Type="LayoutType.ForceDirectedTree" @bind-ForceDirectedTreeLayoutSettings="@forceDirectedSettings"></Layout>
    <SnapSettings Constraints="@SnapConstraints.None"></SnapSettings>
</SfDiagramComponent>

@code
{
    private ForceDirectedTreeLayoutSettings forceDirectedSettings = new ForceDirectedTreeLayoutSettings()
    {
        ConnectorLength = 100,
        AttractionStrength = 0.7,
        RepulsionStrength = 6000,
        MaximumIteration = 350
    };

    private void OnNodeCreating(IDiagramObject obj)
    {
        Node node = obj as Node;
        node.Height = 40;
        node.Width = 40;
        node.Shape = new BasicShape()
        {
            Type = NodeShapes.Basic,
            Shape = NodeBasicShapes.Ellipse,
        };
        node.Style = new ShapeStyle() { Fill = "darkcyan", StrokeWidth = 3, StrokeColor = "Black" };
    }

    private class ForceDirectedDetails
    {
        public string Id { get; set; }
        public string Role { get; set; }
        public string Manager { get; set; }
    }

    private List<ForceDirectedDetails> DataSource = new List<ForceDirectedDetails>()
    {
        new ForceDirectedDetails() { Id = "parent", Role = "Board" },
        new ForceDirectedDetails() { Id = "1", Role = "General Manager", Manager = "parent" },
        new ForceDirectedDetails() { Id = "2", Role = "Human Resource Manager", Manager = "1" },
        new ForceDirectedDetails() { Id = "3", Role = "Trainers", Manager = "2" },
        new ForceDirectedDetails() { Id = "4", Role = "Recruiting Team", Manager = "2" },
        new ForceDirectedDetails() { Id = "5", Role = "Finance Asst. Manager", Manager = "2" },
        new ForceDirectedDetails() { Id = "6", Role = "Design Manager", Manager = "1" },
        new ForceDirectedDetails() { Id = "7", Role = "Design Supervisor", Manager = "6" },
        new ForceDirectedDetails() { Id = "8", Role = "Development Supervisor", Manager = "6" },
        new ForceDirectedDetails() { Id = "9", Role = "Drafting Supervisor", Manager = "6" },
        new ForceDirectedDetails() { Id = "10", Role = "Operation Manager", Manager = "1" },
        new ForceDirectedDetails() { Id = "11", Role = "Statistic Department", Manager = "10" },
        new ForceDirectedDetails() { Id = "12", Role = "Logistic Department", Manager = "10" },
        new ForceDirectedDetails() { Id = "16", Role = "Marketing Manager", Manager = "1" },
        new ForceDirectedDetails() { Id = "17", Role = "Oversea sales Manager", Manager = "16" },
        new ForceDirectedDetails() { Id = "18", Role = "Petroleum Manager", Manager = "16" },
        new ForceDirectedDetails() { Id = "20", Role = "Service Dept. Manager", Manager = "16" },
        new ForceDirectedDetails() { Id = "21", Role = "Quality Department", Manager = "16" }
    };
}
```
A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Layout/ForceDirectedTreeDataSource)

![Blazor Force Directed Tree Data Source Diagram](../images/ForceDirectedTreeDataSource.png)
## See also

* [How to create a node](../nodes/nodes)

* [How to create a connector](../connectors/connectors)

* [How to generate the organization chart](./organizational-chart)

* [How to generate the hierarchical layout](./hierarchical-layout)