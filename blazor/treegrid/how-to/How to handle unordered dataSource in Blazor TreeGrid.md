# How to handle unordered dataSource in Blazor TreeGrid

When row virtualization is enabled in Blazor  TreeGrid, an unordered data source can cause improper rendering because the component expects hierarchical data in order. To fix this, the data should sort and structure before assigning it to the TreeGrid.
    
## Steps to Configure    
    
### 1. Configure the Tree Grid: 

Enable row virtualization and bind the data source:

```cshtml
<SfTreeGrid DataSource="@TaskCollection" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1">
    <TreeGridColumns>
        . . . . . 
    </TreeGridColumns>
</SfTreeGrid>
```

### 2. Order the dataSource before binding:

Use a recursive method to arrange tasks hierarchically:

```cshtml

protected override void OnInitialized()
{
    this.TaskCollection = GetHierarchicalOrderedTasks(GetTaskCollection());
}

public List<TaskData> GetHierarchicalOrderedTasks(List<TaskData> tasks)
{
    var orderedTasks = new List<TaskData>();

    // Recursive method to add children
    void AddChildren(int parentId)
    {
        var children = tasks.Where(t => t.ParentId == parentId).OrderBy(t => t.TaskId);
        foreach (var child in children)
        {
            orderedTasks.Add(child);
            AddChildren(child.TaskId); // Recursively add sub-children
        }
    }

    // Start with root-level tasks (no ParentId)
    var rootTasks = tasks.Where(t => t.ParentId == null).OrderBy(t => t.TaskId);
    foreach (var root in rootTasks)
    {
        orderedTasks.Add(root);
        AddChildren(root.TaskId);
    }

    return orderedTasks;
}
```

## Sample
    
Refer to the [sample](https://blazorplayground.syncfusion.com/embed/hXhntshRzqsGpGbI?appbar=true&editor=true&result=true&errorlist=true&theme=bootstrap5) for more details. 
    
## Conclusion    

To ensure smooth rendering when using virtualization in Blazor TreeGrid, the data source must be in hierarchical order. If the data is unordered, sort and structure it before binding to the TreeGrid component. This guarantees correct task hierarchy display and prevents rendering issues for large datasets.
 