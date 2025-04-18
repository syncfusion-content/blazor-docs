---
layout: post
title: Searching and Filtering in Blazor TreeView Component | Syncfusion
description: Checkout and learn here all about Searching and Filtering in Syncfusion Blazor TreeView component and much more details.
platform: Blazor
control: TreeView
documentation: ug
---

# Searching and Filtering in Blazor TreeView Component

The Blazor TreeView component allows for searching and filtering of TreeView nodes through an external input TextBox.

```cshtml 
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Navigations

<div id="container">
    <div id="sample">
        <SfTextBox Placeholder="Filter" Input="@OnInput"></SfTextBox>
        <SfTreeView @ref="tree" ID="tree" TValue="Listdata">
            <TreeViewEvents TValue="Listdata" DataBound="dataBound"></TreeViewEvents>
            <TreeViewFieldsSettings DataSource="@ListDataSource" TValue="Listdata" Id="Id" IconCss="Icon" ParentID="Pid" Text="Name" HasChildren="HasChild" Expanded="Expanded"></TreeViewFieldsSettings>
        </SfTreeView>
    </div>
</div>
@code
{
    SfTreeView<Listdata> tree;
    List<Listdata> ListDataSource = new List<Listdata>();
    List<Listdata> Temp = new List<Listdata>();
    public bool isFiltered = false;
    List<Listdata> DataSource = new List<Listdata>();
    protected override void OnInitialized()
    {
        ListDataSource = GetData();
    }

    public List<Listdata> GetData()
    { 
        
        List<Listdata> TempDataSource = new List<Listdata>(){
            new Listdata
            {
                Id = 1,
                Name = "Australia",
                HasChild = true,
                Expanded = false,
                Icon = "folder"
            },
            new Listdata
            {
                Id = 2,
                Pid = 1,
                Name = "New South Wales",
                Icon = "folder"
            },
            new Listdata
            {
                Id = 3,
                Pid = 1,
                Name = "Victoria",
                Icon = "folder"
            },
            new Listdata
            {
                Id = 4,
                Pid = 1,
                Name = "South Australia",
                Icon = "folder"
            },
            new Listdata
            {
                Id = 6,
                Pid = 1,
                Name = "Western Australia",
                Icon = "folder"
            },
            new Listdata
            {
                Id = 7,
                Name = "Brazil",
                HasChild = true,
                Icon = "folder"
            },
            new Listdata
            {
                Id = 8,
                Pid = 7,
                Name = "Paraná",
                Icon = "folder"
            },
            new Listdata
            {
                Id = 9,
                Pid = 7,
                Name = "Ceará",
                Icon = "folder"
            },
            new Listdata
            {
                Id = 10,
                Pid = 7,
                Name = "Acre",
                Icon = "folder"
            },
            new Listdata
            {
                Id = 11,
                Name = "China",
                HasChild = true,
                Icon = "folder"
            },
            new Listdata
            {
                Id = 12,
                Pid = 11,
                Name = "Guangzhou",
                Icon = "folder"
            },
            new Listdata
            {
                Id = 13,
                Pid = 11,
                Name = "Shanghai",
                Icon = "folder"
            },
            new Listdata
            {
                Id = 14,
                Pid = 11,
                Name = "Beijing",
                Icon = "folder"
            },
            new Listdata
            {
                Id = 15,
                Pid = 11,
                Name = "Shantou",
                Icon = "folder"
            },
            new Listdata
            {
                Id = 16,
                Name = "France",
                Icon = "folder",
                HasChild = true
            },
            new Listdata
            {
                Id = 17,
                Pid = 16,
                Name = "Pays de la Loire",
                Icon = "folder"
            },
            new Listdata
            {
                Id = 18,
                Pid = 16,
                Name = "Aquitaine",
                Icon = "folder"
            },
            new Listdata
            {
                Id = 19,
                Pid = 16,
                Name = "Brittany",
                Icon = "folder"
            },
            new Listdata
            {
                Id = 20,
                Pid = 16,
                Name = "Lorraine",
                Icon = "folder"
            },
            new Listdata
            {
                Id = 21,
                Name = "India",
                HasChild = true,
                Icon = "folder"
            },
            new Listdata
            {
                Id = 22,
                Pid = 21,
                Name = "Assam",
                Icon = "folder"
            },
            new Listdata
            {
                Id = 23,
                Pid = 21,
                Name = "Bihar",
                Icon = "folder"
            },
            new Listdata
            {
                Id = 24,
                Pid = 21,
                Name = "Tamil Nadu",
                Icon = "folder"
            }
        };

        return TempDataSource;    
    }

    public void OnInput(InputEventArgs eventArgs)
    {
        if (eventArgs.Value == "")
        {
            ListDataSource = GetData();
            isFiltered = false;
        }
        else
        {
            DataSource = GetData();
            // Filter all the nodes of the Searched ID.
            List<Listdata> filteredValues = DataSource.FindAll(e => e.Name.ToString().StartsWith(eventArgs.Value));
            List<Listdata> filteredDataSource = new List<Listdata>();
            Listdata data = new Listdata();
            for (int i = 0; i < filteredValues.Count; i++)
            {
                data = filteredValues[i];
                if(data.Pid == null)
                {
                    data.HasChild = false;
                    filteredDataSource.Add(data);
                    break;
                }
                while (data.Pid != null)
                {
                    if (filteredDataSource.Exists(e => e.Id.Equals(data.Id))) { break; }
                    filteredDataSource.Add(data);
                    data = DataSource.Find(e => e.Id.Equals(data.Pid));
                }
                if (!filteredDataSource.Exists(e => e.Id.Equals(data.Id)))
                {
                    filteredDataSource.Add(data);
                }
            }
            // Update the TreeView based on the searched ID value.
            ListDataSource = filteredDataSource;
            isFiltered = true;
        }
    }

    public async Task dataBound()
    {
        if (isFiltered)
        {
            await this.tree.ExpandAllAsync();
        }
        else
        {
            await this.tree.CollapseAllAsync();
        }
    }

    public class Listdata
    {
        public int Id { get; set; }
        public int? Pid { get; set; } = null;
        public string? Name { get; set; }
        public bool HasChild { get; set; }
        public bool Expanded { get; set; }
        public string? Icon { get; set; }
    } 
}

<style>
    #tree {
        box-shadow: 0 1px 4px #ddd;
        border-bottom: 1px solid #ddd;
    }

    .e-treeview .e-list-icon {
        background-repeat: no-repeat;
        height: 20px;
        background-image: url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACcAAAJxCAYAAADB66v2AAAACXBIWXMAAA7EAAAOxAGVKw4bAAAGymlUWHRYTUw6Y29tLmFkb2JlLnhtcAAAAAAAPD94cGFja2V0IGJlZ2luPSLvu78iIGlkPSJXNU0wTXBDZWhpSHpyZVN6TlRjemtjOWQiPz4gPHg6eG1wbWV0YSB4bWxuczp4PSJhZG9iZTpuczptZXRhLyIgeDp4bXB0az0iQWRvYmUgWE1QIENvcmUgNS42LWMxNDAgNzkuMTYwNDUxLCAyMDE3LzA1LzA2LTAxOjA4OjIxICAgICAgICAiPiA8cmRmOlJERiB4bWxuczpyZGY9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkvMDIvMjItcmRmLXN5bnRheC1ucyMiPiA8cmRmOkRlc2NyaXB0aW9uIHJkZjphYm91dD0iIiB4bWxuczp4bXA9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC8iIHhtbG5zOnhtcE1NPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvbW0vIiB4bWxuczpzdFJlZj0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL3NUeXBlL1Jlc291cmNlUmVmIyIgeG1sbnM6c3RFdnQ9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9zVHlwZS9SZXNvdXJjZUV2ZW50IyIgeG1sbnM6ZGM9Imh0dHA6Ly9wdXJsLm9yZy9kYy9lbGVtZW50cy8xLjEvIiB4bWxuczpwaG90b3Nob3A9Imh0dHA6Ly9ucy5hZG9iZS5jb20vcGhvdG9zaG9wLzEuMC8iIHhtcDpDcmVhdG9yVG9vbD0iQWRvYmUgUGhvdG9zaG9wIENDIDIwMjIgKFdpbmRvd3MpIiB4bXA6Q3JlYXRlRGF0ZT0iMjAxNy0xMS0yM1QxMjoyODowMiswNTozMCIgeG1wOk1vZGlmeURhdGU9IjIwMTctMTItMDhUMTA6NDQ6MTArMDU6MzAiIHhtcDpNZXRhZGF0YURhdGU9IjIwMTctMTItMDhUMTA6NDQ6MTArMDU6MzAiIHhtcE1NOkluc3RhbmNlSUQ9InhtcC5paWQ6MWM2MzdlZDktNGU1NC00ZGExLTgyOTMtM2ZiYTk4MzUxYzcxIiB4bXBNTTpEb2N1bWVudElEPSJhZG9iZTpkb2NpZDpwaG90b3Nob3A6ZTQyODI3OTktNTUxZS1iNzQ4LWEyZDAtNjEyZDQwZmIyYTBiIiB4bXBNTTpPcmlnaW5hbERvY3VtZW50SUQ9InhtcC5kaWQ6RTI1MDIzMEVFOUUzMTFFNUEyQTZCRUJEQkNCNUYwNkMiIGRjOmZvcm1hdD0iaW1hZ2UvcG5nIiBwaG90b3Nob3A6Q29sb3JNb2RlPSIzIiBwaG90b3Nob3A6SUNDUHJvZmlsZT0ic1JHQiBJRUM2MTk2Ni0yLjEiPiA8eG1wTU06RGVyaXZlZEZyb20gc3RSZWY6aW5zdGFuY2VJRD0ieG1wLmlpZDpFMjUwMjMwQkU5RTMxMUU1QTJBNkJFQkRCQ0I1RjA2QyIgc3RSZWY6ZG9jdW1lbnRJRD0ieG1wLmRpZDpFMjUwMjMwQ0U5RTMxMUU1QTJBNkJFQkRCQ0I1RjA2QyIvPiA8eG1wTU06SGlzdG9yeT4gPHJkZjpTZXE+IDxyZGY6bGkgc3RFdnQ6YWN0aW9uPSJzYXZlZCIgc3RFdnQ6aW5zdGFuY2VJRD0ieG1wLmlpZDoyNjMwMjljZi01NTU5LTRhZjAtYjJjZC03MGM4MDYwMzI2MjAiIHN0RXZ0OndoZW49IjIwMTctMTEtMjNUMTI6NTk6MzYrMDU6MzAiIHN0RXZ0OnNvZnR3YXJlQWdlbnQ9IkFkb2JlIFBob3Rvc2hvcCBDQyAoTWFjaW50b3NoKSIgc3RFdnQ6Y2hhbmdlZD0iLyIvPiA8cmRmOmxpIHN0RXZ0OmFjdGlvbj0ic2F2ZWQiIHN0RXZ0Omluc3RhbmNlSUQ9InhtcC5paWQ6MWM2MzdlZDktNGU1NC00ZGExLTgyOTMtM2ZiYTk4MzUxYzcxIiBzdEV2dDp3aGVuPSIyMDE3LTEyLTA4VDEwOjQ0OjEwKzA1OjMwIiBzdEV2dDpzb2Z0d2FyZUFnZW50PSJBZG9iZSBQaG90b3Nob3AgQ0MgKE1hY2ludG9zaCkiIHN0RXZ0OmNoYW5nZWQ9Ii8iLz4gPC9yZGY6U2VxPiA8L3htcE1NOkhpc3Rvcnk+IDwvcmRmOkRlc2NyaXB0aW9uPiA8L3JkZjpSREY+IDwveDp4bXBtZXRhPiA8P3hwYWNrZXQgZW5kPSJyIj8+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);
    }

    .e-treeview .e-list-icon.folder {
        background-position: -10px -552px
    }

    #sample {
        height: 220px;
        margin: 0 auto;
        display: block;
        max-width: 350px;
    }

    .e-treeview .e-list-icon.docx {
        background-position: -10px -20px
    }
</style>

```

![Searching and Filtering in Blazor TreeView Component](./images/blazor-treeview-searching-and-filtering.png)
