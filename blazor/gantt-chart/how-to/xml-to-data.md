---
layout: post
title: Import Microsoft Project XML into Blazor Gantt Chart | Syncfusion
description: Learn here to import microsoft project XML into Gantt Chart in Syncfusion Blazor Gantt Chart component.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Import Microsoft Project XML into Syncfusion Blazor Gantt Chart

In this guide, we'll explore how to import task data from an XML file into a Syncfusion Blazor Gantt Chart. This example assumes you have an XML file conforming to the Microsoft Project XML schema, containing task-related information.

**Step 1**:
Begin by adding a file upload component to your Blazor application using Syncfusion's `SfUploader`. This component allows users to upload XML files easily. Here's how you can implement it.

```cshtml
<SfUploader AutoUpload="true">
    <UploaderEvents ValueChange="@OnChange"></UploaderEvents>
</SfUploader>
```

**Step 2**:
Now, implement the OnChange method in the `@code` block to handle file changes. This method reads the XML file, converts it into a list of `TaskData`, and updates the Gantt Chart's data source.

```cshtml
@code {
    // ... (Previous code)
    private async Task OnChange(UploadChangeEventArgs args)
    {
        try
        {
            foreach (var file in args.Files)
            {
                // ... (Code for saving the file)
                // Convert XML to task data list
                var taskDataList = XmlToTaskDataList(File.ReadAllText(path));
                GanttData.AddRange(taskDataList);
            }
            this.Gantt.RefreshAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    // ... (Remaining code)
}
```

**Step 3**:
The `XmlToTaskDataList` method parses the XML content and converts it into a list of `TaskData`. This method utilizes the `XDocument` class to read XML elements and extract task-related information.

```cshtml
// ... (Code for XmlToTaskDataList)
private List<TaskData> XmlToTaskDataList(string xmlContent)
{
    // ... (Code for XML parsing and TaskData extraction)
}
```

**Step 4**:
Implement additional utility methods such as `IsChildWithDot`, `GetParentId`, and `ConvertDurationToDays` to handle specific XML structure cases and convert duration values to days.

**Step 5**:
Ensure that you have initialized your Gantt Chart component with the required task fields and edit settings.

```cshtml
<SfGantt TValue="TaskData" DataSource="@GanttData" @ref="Gantt" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" Duration="Duration"
                     Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" AllowTaskbarEditing="true"></GanttEditSettings>
</SfGantt>
```

Now, your Blazor application is equipped to seamlessly import task data from XML files and display them in the Syncfusion Gantt Chart.

The following code snippet import Microsoft Project XML into Blazor Gantt Chart control.

```cshtml
@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Inputs
@using System.Collections.Generic
@using System.IO
@using System.Xml.Linq
@using System.Xml.XPath
@using System.Xml;
<h3>Syncfusion Blazor Gantt with XML Data</h3>
<SfUploader AutoUpload="true">
    <UploaderEvents ValueChange="@OnChange"></UploaderEvents>
</SfUploader>
<SfGantt TValue="TaskData" DataSource="@GanttData" @ref="Gantt" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" Duration="Duration"
                     Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" AllowTaskbarEditing="true"></GanttEditSettings>
</SfGantt>
@code {
    SfGantt<TaskData> Gantt;
    private List<TaskData> GanttData = new List<TaskData>();
    private async Task OnChange(UploadChangeEventArgs args)
    {
        try
        {
            foreach (var file in args.Files)
            {
                var path = @"" + file.FileInfo.Name;
                using (FileStream filestream = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    await file.File.OpenReadStream(long.MaxValue).CopyToAsync(filestream);
                }
                // Convert XML to task data list
                var taskDataList = XmlToTaskDataList(File.ReadAllText(path));
                GanttData.AddRange(taskDataList);
            }
            this.Gantt.RefreshAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    private List<TaskData> XmlToTaskDataList(string xmlContent)
    {
        var taskDataList = new List<TaskData>();
        try
        {
            var xmlDoc = XDocument.Parse(xmlContent);
            // Define the namespace
            XNamespace projectNamespace = "http://schemas.microsoft.com/project";
            // Iterate through each Task element under Tasks
            foreach (var taskElement in xmlDoc.Descendants(projectNamespace + "Task"))
            {
                // Create a new TaskData object for each Task element
                TaskData taskData = new TaskData();
                taskData.TaskId = int.Parse(taskElement.Element(projectNamespace + "ID").Value);
                taskData.TaskName = taskElement.Element(projectNamespace + "Name").Value;
                taskData.StartDate = DateTime.Parse(taskElement.Element(projectNamespace + "Start").Value);
                taskData.EndDate = DateTime.Parse(taskElement.Element(projectNamespace + "Finish").Value);
                if (taskElement.Element(projectNamespace + "Duration").Value != null)
                {
                    string durationValue = taskElement.Element(projectNamespace + "Duration").Value;
                    double durationInDays = ConvertDurationToDays(durationValue);
                    taskData.Duration = durationInDays.ToString();
                }
                taskData.Progress = int.Parse(taskElement.Element(projectNamespace + "PercentComplete").Value);
                // Extract the WBS value
                var wbsElement = taskElement.Element(projectNamespace + "WBS");
                string wbsValue = wbsElement != null ? wbsElement.Value : null;
                // Determine the parent based on the WBS value
                taskData.ParentId = IsChildWithDot(wbsValue) ? GetParentId(wbsValue) : null;
                // Add the task data to the list
                taskDataList.Add(taskData);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error converting XML to TaskData list: " + ex.Message);
        }
        return taskDataList;
    }
    private bool IsChildWithDot(string wbsValue)
    {
        // Check if wbsValue contains a dot
        return wbsValue != null && wbsValue.Contains(".");
    }
    private int? GetParentId(string wbsValue)
    {
        // If wbsValue contains a dot, get the substring before the dot as the parent ID
        if (IsChildWithDot(wbsValue))
        {
            int dotIndex = wbsValue.IndexOf('.');
            if (dotIndex != -1)
            {
                string parentWbs = wbsValue.Substring(0, dotIndex);
                // Convert parentWbs to int and return as the parent ID
                if (int.TryParse(parentWbs, out int parentId))
                {
                    return parentId;
                }
            }
        }
        return null; // No parent found
    }
    private double ConvertDurationToDays(string duration)
    {
        TimeSpan timeSpan = XmlConvert.ToTimeSpan(duration);
        double totalDays = timeSpan.TotalDays;
        return totalDays;
    }
    public class TaskData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentId { get; set; }
    }
}
```