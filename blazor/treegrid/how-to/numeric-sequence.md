---
layout: post
title: Different numeric sequence for each levels in Blazor TreeGrid Component | Syncfusion
description: Checkout and learn here all about customizing numeric sequence for diffrenet levels in Syncfusion Blazor TreeGrid component and more.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Numeric Sequence  Blazor TreeGrid Component

This guide shows how to display level-based numbering for nodes in the Syncfusion Blazor TreeGrid by adding a label in the column's template that reflects each row’s position among its valid siblings and formats it by level (for example: level 0 = decimal 1., 2., 3.; level 1 = upper Roman I., II., III.; level 2 = lower Roman i., ii., iii.; repeating as needed). The implementation computes the row’s hierarchical level by traversing ParentId, builds the 1-based index from the current view’s sibling set (so numbering automatically respects TreeGrid sorting and filtering), and skips rows you don’t want numbered (such as adding). The numbering style is controlled via a simple per-level style map (e.g., decimal, upper-roman, lower-roman, and can be customized depends on the need), and conversion to Roman numerals uses Humanizer’s ToRoman method. You can customize which rows are counted and how each level is formatted, and optionally extend the approach to composite labels (like 1.II.3) by computing and joining each ancestor level’s index.

```cshtml
@using Humanizer;
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.TreeGrid;

<SfTreeGrid @ref="TreeGrid" DataSource="@TreeGridData" IdMapping="TaskId" AllowSelection="true" ParentIdMapping="ParentId" TreeColumnIndex="1">
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="80" IsPrimaryKey="true" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="160">
            <Template>
                @{
                    var data = (context as TreeData.BusinessObject);
                    int numericIndex = 0; // New index counter for valid rows

                    if (data.ParentId != null)
                    {
                        var parentRecords = this.TreeGrid.GetCurrentViewRecords().Where(record => record.TaskId.ToString() == data.ParentId.ToString())?.ToList();
                        var ParentRec = parentRecords.Count > 0 ? parentRecords[0] : null;

                        if (ParentRec != null)
                        {
                            var childRecords = this.TreeGrid.GetCurrentViewRecords()
                            .Where(rec => rec.ParentId != null && rec.ParentId.ToString() == ParentRec.TaskId.ToString())
                            .ToList();

                            for (var i = 0; i < childRecords.Count; i++)
                            {
                                if (childRecords[i].TaskId == 0 || childRecords[i].TaskName == null)
                                {
                                    continue; // Skip invalid records
                                }

                                if (childRecords[i].AgendaTopicTypeId != 4)
                                {
                                    numericIndex++; // Increment only for valid records
                                }

                                if (childRecords[i].TaskId == data.TaskId)
                                {
                                    var InternalProps = this.TreeGrid.GetRowModel(childRecords[i]);
                                    this.RowCounter = GetTopicStyle(InternalProps, numericIndex - 1); // Pass valid index
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        var ParentRec = this.TreeGrid.GetCurrentViewRecords().Where(record => record.ParentId == null).ToList();
                        for (int i = 0; i < ParentRec.Count; i++)
                        {
                            if (ParentRec[i].TaskId == 0 || ParentRec[i].TaskName == null)
                            {
                                continue; // Skip invalid records
                            }
                            if (ParentRec[i].AgendaTopicTypeId != 4)
                            {
                                numericIndex++; // Increment only for valid records
                            }
                            if (ParentRec[i].TaskId == data.TaskId)
                            {
                                var InternalProps = this.TreeGrid.GetRowModel(ParentRec[i]);
                                this.RowCounter = GetTopicStyle(InternalProps, numericIndex - 1);
                                break;
                            }
                        }
                    }
                    <span >
                        <span > @((MarkupString)this.RowCounter)</span>
                        <span >@data.TaskName</span>
                    </span>
                }
            </Template>
        </TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Priority" HeaderText="Priority" Width="80"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    public List<TreeData.BusinessObject> TreeGridData { get; set; }
    SfTreeGrid<TreeData.BusinessObject> TreeGrid;

    public string styles { get; set; }
    public string RowCounter;

    public string num = "";
    public int parentIndex = 0;
    public int childIndex = 0;
    public int subChildIndex = 0;
    public int grandChildIndex = 0;

    protected string RootNodeStyle { get; set; } = "decimal";
    protected string ChildrenNodeStyle { get; set; } = "upper-roman";
    protected string SubChildrenNodeStyle { get; set; } = "lower-roman";
    protected string SubSubChildrenNodeStyle { get; set; } = "decimal";
    protected string SubSubSubChildrenNodeStyle { get; set; } = "upper-roman";

    private int GetHierarchyLevel(TreeData.BusinessObject data, IEnumerable<TreeData.BusinessObject> records)
    {
        int level = 0;
        while (data.ParentId != null)
        {
            level++;
            data = records.FirstOrDefault(rec => rec.TaskId == data.ParentId);
        }
        return level;
    }

    // Function to calculate row counter dynamically
    private string CalculateRowCounter(TreeData.BusinessObject data, ITreeGridRowModel<TreeData.BusinessObject> internalProps, IEnumerable<TreeData.BusinessObject> records)
    {
        // List to hold hierarchy level numbers (e.g., 1.2.1.1)
        List<string> counterList = new List<string>();

        // Recursively traverse parents to build hierarchy numbering
        BuildCounterRecursive(data, records, counterList);

        // Join all parts with "." to get the final row counter (e.g., "1.2.1")
        return string.Join(".", counterList);
    }

    // Recursively build the counter from parent-child relationships
    private void BuildCounterRecursive(TreeData.BusinessObject data, IEnumerable<TreeData.BusinessObject> records, List<string> counterList)
    {
        // Find siblings of the current node (items with the same ParentId), excluding invalid ones
        var siblings = records
            .Where(rec => rec.ParentId == data.ParentId && rec.TaskId != 0 && rec.TaskName != null) // Skip rows with ID = 0 or Title = null
            .ToList();

        // Find index of current item among its valid siblings
        int index = siblings.FindIndex(rec => rec.TaskId == data.TaskId);

        // If the current row is found among valid siblings, add its index to the counter
        if (index != -1)
        {
            // Add the index (+1 because list indices start at 0) to the hierarchy list
            counterList.Insert(0, (index + 1).ToString());
        }

        // Recursively call function on the parent, if it exists
        if (data.ParentId != null)
        {
            var parentRecord = records.FirstOrDefault(rec => rec.TaskId == data.ParentId);
            if (parentRecord != null && parentRecord.TaskId != 0 && parentRecord.TaskName != null) // Ensure parent is valid
            {
                BuildCounterRecursive(parentRecord, records, counterList);
            }
        }
    }
    private double GenerateWhiteSpaceCounter(int level)
    {
        var numeric = string.Join(" ", Enumerable.Repeat(" ", level));
        var numericValue = numeric.Length + 1.5;
        if (level == 2 || level == 0) { numericValue = numeric.Length + 1; }
        if (level == 3) { numericValue = numeric.Length + 0.5; }
        if (level == 4) { numericValue = numeric.Length; }
        return numericValue;
    }
    private string GetTopicStyle(ITreeGridRowModel<TreeData.BusinessObject> rowModel, int validIndex)
    {
        var currentRec = this.TreeGrid.GetCurrentViewRecords();
        var lengthOfWhiteSpace = GenerateWhiteSpaceCounter(GetHierarchyLevel(rowModel.Data, currentRec));

        string style = rowModel.Level switch
        {
            0 => RootNodeStyle,
            1 => ChildrenNodeStyle,
            2 => SubChildrenNodeStyle,
            3 => SubSubChildrenNodeStyle,
            4 => SubSubSubChildrenNodeStyle,
            _ => ""
        };

        // Define numbering styles
        string[] alphabet = Enumerable.Range('a', 26).Select(x => ((char)x) + ".").ToArray();
        string[] roman = Enumerable.Range(1, 26).Select(x => x.ToRoman().ToLowerInvariant() + ".").ToArray();
        string[] Alphabet = Enumerable.Range('A', 26).Select(x => ((char)x) + ".").ToArray();
        string[] Romans = Enumerable.Range(1, 26).Select(x => x.ToRoman() + ".").ToArray();

        // Assign numbering based on style
        return style switch
        {
            "decimal" => (validIndex + 1).ToString() + ".",
            "lower-alpha" => validIndex < alphabet.Length ? alphabet[validIndex] : "",
            "lower-roman" => validIndex < roman.Length ? roman[validIndex] : "",
            "upper-alpha" => validIndex < Alphabet.Length ? Alphabet[validIndex] : "",
            "upper-roman" => validIndex < Romans.Length ? Romans[validIndex] : "",         
        };
    }
    private string GenerateNRowCounter(int level)
    {
        return string.Join(" ", Enumerable.Repeat(" ", level));
    }

    protected override void OnInitialized()
    {
        this.TreeGridData = TreeData.GetSelfDataSource().ToList();
    }

    public class TreeData
    {
        public class BusinessObject
        {
            public int TaskId { get; set; }
            public string TaskName { get; set; }
            public int? Duration { get; set; }
            public int? Progress { get; set; }
            public string Priority { get; set; }
            public int? ParentId { get; set; }
            public int? AgendaTopicTypeId { get; set; }
            
        }

        public static List<BusinessObject> GetSelfDataSource()
        {
            List<BusinessObject> BusinessObjectCollection = new List<BusinessObject>();
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 1, TaskName = "Parent Task 1", Duration = 10, Progress = 70, Priority = "Critical", ParentId = null });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 2, TaskName = "Child task 1", Progress = 80, Priority = "Low", ParentId = 1 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 3, TaskName = "Child Task 2", Duration = 5, Progress = 65, Priority = "Critical", ParentId = 2 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 4, TaskName = "Child task 3", Duration = 6, Priority = "High", Progress = 77, ParentId = 3 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 5, TaskName = "Parent Task 2", Duration = 10, Progress = 70, Priority = "Critical", ParentId = null });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 6, TaskName = "Child task 1", Duration = 4, Progress = 80, Priority = "Critical", ParentId = 5 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 7, TaskName = "Child Task 2", Duration = 5, Progress = 65, Priority = "Low", ParentId = 5 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 8, TaskName = "Child task 3", Duration = 6, Progress = 77, Priority = "High", ParentId = 5 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 9, TaskName = "Child task 4", Duration = 6, Progress = 77, Priority = "Low", ParentId = 5 });
            return BusinessObjectCollection;
        }
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LZBHjiXVilGeqAWz?appbar=true&editor=true&result=true&errorlist=true&theme=bootstrap5" %}

