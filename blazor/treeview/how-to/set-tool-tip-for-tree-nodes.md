# Set tooltip for TreeView nodes

TreeView control allows you to set tooltip option to tree nodes using the `Tooltip` property. The following code example demonstrates how to set tooltip for TreeView nodes.

```csharp
@using Syncfusion.Blazor.Navigations

<SfTreeView TValue="DriveData">
    <TreeViewFieldsSettings DataSource="@Drive" Id="NodeId" Text="NodeText" Tooltip="Tooltip" Expanded="Expanded" Child="@("Child")"></TreeViewFieldsSettings>
</SfTreeView>

@code{
    List<DriveData> Drive = new List<DriveData>();
    protected override void OnInitialized()
    {
        base.OnInitialized();
        Drive.Add(new DriveData
        {
            NodeId = "01",
            NodeText = "Local Disk (C:)",
            Tooltip = "Local Disk (C:)",
            Expanded = true,
            Child = new List<DriveData>()
            {
                new DriveData { NodeId = "01-01", NodeText = "Program Files", Tooltip = "Program Files",
                    Child = new List<DriveData>()
                    {
                        new DriveData { NodeId = "01-01-01", NodeText = "Windows NT" , Tooltip = "Windows NT"},
                    },
                },
                new DriveData { NodeId = "01-02", NodeText = "Users", Tooltip="Users",
                    Child = new List<DriveData>()
                    {
                        new DriveData { NodeId = "01-02-01", NodeText = "Smith", Tooltip= "Smith" },
                        new DriveData { NodeId = "01-02-02", NodeText = "Public", Tooltip="Public" },
                    },
                },
                new DriveData { NodeId = "01-03", NodeText = "Windows", Tooltip= "Windows",
                    Child = new List<DriveData>()
                    {
                        new DriveData { NodeId = "01-03-01", NodeText = "Boot", Tooltip = "Boot" },
                    }
                },
            },
        });
        Drive.Add(new DriveData
        {
            NodeId = "02",
            NodeText = "Local Disk (D:)",
            Tooltip = "Local Disk (D:)",
            Child = new List<DriveData>()
            {
                new DriveData { NodeId = "02-01", NodeText = "Personals", Tooltip="Personals"
                },
                new DriveData { NodeId = "02-02", NodeText = "Projects", Tooltip = "Projects"
                },
                new DriveData { NodeId = "02-02", NodeText = "Office", Tooltip = "Office"
            }
                }
        });
        Drive.Add(new DriveData
        {
            NodeId = "03",
            NodeText = "Local Disk (E:)",
            Tooltip = "Local Disk (E:)",
            Child = new List<DriveData>()
            {
                new DriveData { NodeId = "03-01", NodeText = "Pictures", Tooltip = "Pictures"
                },
                new DriveData { NodeId = "03-02", NodeText = "Documents", Tooltip ="Documents"
                },
                new DriveData { NodeId = "03-03", NodeText = "Study Materials", Tooltip = "Study Materials"
                },
            },
        });
    }
    class DriveData
    {
        public string NodeId { get; set; }
        public string NodeText { get; set; }
        public string Tooltip { get; set; }
        public string Icon { get; set; }
        public bool Expanded { get; set; }
        public bool Selected { get; set; }
        public List<DriveData> Child { get; set; }
    }
}
```

Output be like the below.

![TreeView Sample](../images/tooltip.png)
