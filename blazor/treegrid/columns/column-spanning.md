---
layout: post
title: Column Spanning in Blazor Tree Grid Component | Syncfusion
description: Check out here and learn more details about the Column spanning in the Syncfusion Blazor Tree Grid component.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Column Spanning in Blazor TreeGrid

Column spanning in the Syncfusion Blazor TreeGrid provides automatic vertical merging of adjacent cells within the same column when identical values are detected. This feature improves readability by consolidating repeated values into a single taller cell, which is especially useful when the same value appears across consecutive rows.

The functionality is enabled by setting the [AutoSpan](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_AutoSpan) property of the `SfTreeGrid` component to `AutoSpanMode.Column`. Once applied, the TreeGrid evaluates each column and merges stacked cells that share identical values, thereby reducing visual redundancy and presenting a cleaner, more structured layout. The merging process is fully declarative and requires no additional code or preprocessing.

Column spanning is part of the broader `AutoSpanMode` enumeration, which provides multiple options for customizing cell merging behavior in the Syncfusion Blazor TreeGrid. The available modes include `None`, `Row`, `Column`, and `HorizontalAndVertical`. 

## AutoSpanMode enumeration

| Enum Value | Description |
|---------|-----|
| AutoSpanMode.None | Disables automatic cell spanning. Every cell remains isolated. (Default Mode) | 
| AutoSpanMode.Row | Enables horizontal merging across columns within the same row. | 
| AutoSpanMode.Column | Enables vertical merging of adjacent cells with identical values in the same column. | 
| AutoSpanMode.HorizontalAndVertical | Enables both horizontal and vertical merging. Executes row merging first, followed by column merging. | 


## Enabling column spanning

Vertical cell merging in the Syncfusion Blazor TreeGrid is enabled by setting the `AutoSpan` property of the `SfTreeGrid` component to `AutoSpanMode.Column`. In this mode, the TreeGrid automatically merges stacked cells that share identical values within the same column. This reduces redundancy across consecutive rows and provides a cleaner, more structured layout for repeated data. The merging process is fully declarative and requires no additional code or preprocessing.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Buttons

<SfTreeGrid @ref="TreeGridInstance" DataSource="@TreeData" IdMapping="Id" EnableHover ParentIdMapping="ParentId" AutoSpan="AutoSpanMode.Column" TreeColumnIndex="1" GridLines="GridLine.Both">
    <TreeGridColumns>
        <TreeGridColumn Field="Id"  HeaderText="ID" Width="80" TextAlign="TextAlign.Center" IsPrimaryKey></TreeGridColumn>
        <TreeGridColumn Field="Name" HeaderText="Developer" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="Slot1" HeaderText="10:00 - 11:00 AM" Width="150" ></TreeGridColumn>
        <TreeGridColumn Field="Slot2" HeaderText="11:00 - 12:00 AM" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="Slot3" HeaderText="12:00 - 13:00 PM" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="Slot4" HeaderText="01:00 - 02:00 PM" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="Slot5" HeaderText="02:00 - 03:00 PM" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="Slot6" HeaderText="03:00 - 04:00 PM" Width="150"></TreeGridColumn>
        <TreeGridColumn Field="Slot7" HeaderText="04:00 - 05:00 PM" Width="150"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    public SfTreeGrid<DeveloperSchedule> TreeGridInstance;
    public List<DeveloperSchedule> TreeData { get; set; }

    protected override void OnInitialized()
    {
        TreeData = DeveloperSchedule.GetTree().ToList();
    }

    public class DeveloperSchedule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slot1 { get; set; }
        public string Slot2 { get; set; }
        public string Slot3 { get; set; }
        public string Slot4 { get; set; }
        public string Slot5 { get; set; }
        public string Slot6 { get; set; }
        public string Slot7 { get; set; }
        public int? ParentId { get; set; }
        public bool IsExpanded { get; set; }

        public static List<DeveloperSchedule> GetTree()
        {
            List<DeveloperSchedule> Developers = new List<DeveloperSchedule>
            {
                new DeveloperSchedule { Id = 1, Name = "Martin", Slot1 = "Feature Dev", Slot2 = "Bug Fixing", Slot3 = "Team Sync", Slot4 = "Lunch Break", Slot5 = "Testing", Slot6 = "Planning", Slot7 = "Code Review", IsExpanded = false },
                new DeveloperSchedule { Id = 2, ParentId = 1, Name = "Vance", Slot1 = "Bug Fixing", Slot2 = "Bug Fixing", Slot3 = "Team Sync", Slot4 = "Lunch Break", Slot5 = "Planning", Slot6 = "Code Review", Slot7 = "Feature Dev" },
                new DeveloperSchedule { Id = 3, ParentId = 2, Name = "Charlie", Slot1 = "Team Sync", Slot2 = "Team Sync", Slot3 = "Testing", Slot4 = "Lunch Break", Slot5 = "Feature Dev", Slot6 = "Code Review", Slot7 = "Bug Fixing" },
                new DeveloperSchedule { Id = 4, Name = "Taylor", Slot1 = "Team Sync", Slot2 = "Bug Fixing", Slot3 = "Planning", Slot4 = "Lunch Break", Slot5 = "Testing", Slot6 = "Bug Fixing", Slot7 = "Planning", IsExpanded = false },
                new DeveloperSchedule { Id = 5, ParentId = 4, Name = "Anderson", Slot1 = "Testing", Slot2 = "Planning", Slot3 = "Code Review", Slot4 = "Lunch Break", Slot5 = "Bug Fixing", Slot6 = "Testing", Slot7 = "Planning" },
                new DeveloperSchedule { Id = 6, ParentId = 5, Name = "Chris", Slot1 = "Planning", Slot2 = "Code Review", Slot3 = "Feature Dev", Slot4 = "Lunch Break", Slot5 = "Testing", Slot6 = "Team Sync", Slot7 = "Testing" },
                new DeveloperSchedule { Id = 7, Name = "Elizabeth", Slot1 = "Code Review", Slot2 = "Feature Dev", Slot3 = "Bug Fixing", Slot4 = "Lunch Break", Slot5 = "Testing", Slot6 = "Code Review", Slot7 = "Planning", IsExpanded = false },
                new DeveloperSchedule { Id = 8, ParentId = 7, Name = "Robert", Slot1 = "Feature Dev", Slot2 = "Bug Fixing", Slot3 = "Bug Fixing", Slot4 = "Lunch Break", Slot5 = "Testing", Slot6 = "Planning", Slot7 = "Code Review" },
                new DeveloperSchedule { Id = 9, ParentId = 8, Name = "Smith", Slot1 = "Bug Fixing", Slot2 = "Testing", Slot3 = "Team Sync", Slot4 = "Lunch Break", Slot5 = "Planning", Slot6 = "Planning", Slot7 = "Feature Dev" },
                new DeveloperSchedule { Id = 10, ParentId = 7, Name = "John", Slot1 = "Scrum", Slot2 = "Team Sync", Slot3 = "Testing", Slot4 = "Lunch Break", Slot5 = "Code Review", Slot6 = "Feature Dev", Slot7 = "Bug Fixing" }
            };
            return Developers;
        }
    }
}
{% endhighlight %}
{% endtabs %}


## Disable column spanning for specific column

Spanning in the Syncfusion Blazor TreeGrid can be disabled at the column level by setting the `AutoSpan` property of the `TreeGridColumn` component to `AutoSpanMode.None`. This configuration provides fine-grained control, allowing automatic spanning to be applied globally while excluding specific columns where merging is not desired.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Buttons

<SfTreeGrid TValue="ProjectTask" @ref="TreeGridRef" DataSource="@TreeGridData" ChildMapping="Children" TreeColumnIndex="0" Height="400" AllowSelection="false" GridLines="GridLine.Both" ShowColumnChooser="true" AutoSpan="AutoSpanMode.Column">
<TreeGridFilterSettings Type="Syncfusion.Blazor.TreeGrid.FilterType.Excel"></TreeGridFilterSettings>
<TreeGridColumns>
    <TreeGridColumn Field=@nameof(ProjectTask.ActivityName) HeaderText="<b>Phase Name</b>" Freeze="FreezeDirection.Left" IsFrozen="true" DisableHtmlEncode="false" ClipMode="ClipMode.EllipsisWithTooltip" Width="250"></TreeGridColumn>
    <TreeGridColumn HeaderText="<b>Schedule</b>" DisableHtmlEncode="false">
        <TreeGridColumns>
            <TreeGridColumn Field=@nameof(ProjectTask.StartDate) HeaderText="<b>Start Date</b>" DisableHtmlEncode="false" Type="ColumnType.Date" Format="MM/dd/yyyy" Width="140" TextAlign="TextAlign.Right"></TreeGridColumn>
            <TreeGridColumn Field=@nameof(ProjectTask.EndDate) HeaderText="<b>End Date<b>" DisableHtmlEncode="false" Type="ColumnType.Date" Format="MM/dd/yyyy" Width="140" TextAlign="TextAlign.Right"></TreeGridColumn>
        </TreeGridColumns>
    </TreeGridColumn>
    <TreeGridColumn Field=@nameof(ProjectTask.Status) HeaderText="<b>Status</b>" TextAlign="TextAlign.Center" DisableHtmlEncode="false" Width="140"></TreeGridColumn>
    <TreeGridColumn HeaderText="<b>Compliance</b>" DisableHtmlEncode="false" TextAlign="TextAlign.Center">
        <TreeGridColumns>
            <TreeGridColumn Field=@nameof(ProjectTask.PermitStatus) HeaderText="<b>Permit Status</b>" DisableHtmlEncode="false" Width="160" TextAlign="TextAlign.Center"></TreeGridColumn>
            <TreeGridColumn Field=@nameof(ProjectTask.InspectionDate) HeaderText="<b>Inspection Date</b>" DisableHtmlEncode="false" ClipMode="ClipMode.EllipsisWithTooltip" Width="150" Type="ColumnType.Date" Format="MM/dd/yyyy" TextAlign="TextAlign.Center"></TreeGridColumn>
            <TreeGridColumn Field=@nameof(ProjectTask.InspectionStatus) HeaderText="<b>Inspection Status</b>" DisableHtmlEncode="false" TextAlign="TextAlign.Center" ClipMode="ClipMode.EllipsisWithTooltip" Width="150"></TreeGridColumn>
            <TreeGridColumn Field=@nameof(ProjectTask.PunchListStatus) HeaderText="<b>Punch List Status</b>" DisableHtmlEncode="false" TextAlign="TextAlign.Center" ClipMode="ClipMode.EllipsisWithTooltip" Width="150"></TreeGridColumn>
        </TreeGridColumns>
    </TreeGridColumn>
    <TreeGridColumn HeaderText="<b>Personnel</b>" DisableHtmlEncode="false">
        <TreeGridColumns>
            <TreeGridColumn Field=@nameof(ProjectTask.Supervisor) HeaderText="<b>Supervisor</b>" DisableHtmlEncode="false" Width="180">
            </TreeGridColumn>
            <TreeGridColumn Field=@nameof(ProjectTask.Team) HeaderText="<b>Crew</b>" DisableHtmlEncode="false" Width="200"></TreeGridColumn>
        </TreeGridColumns>
    </TreeGridColumn>
    <TreeGridColumn HeaderText="<b>Materials</b>" DisableHtmlEncode="false" TextAlign="TextAlign.Center">
        <TreeGridColumns>
            <TreeGridColumn Field=@nameof(ProjectTask.MaterialUsed) HeaderText="<b>Materials Used</b>" DisableHtmlEncode="false" Width="180"></TreeGridColumn>
            <TreeGridColumn Field=@nameof(ProjectTask.MaterialCost) HeaderText="<b>Material Cost</b>" DisableHtmlEncode="false" Width="140" TextAlign="TextAlign.Right" Format="C0"></TreeGridColumn>
        </TreeGridColumns>
    </TreeGridColumn>
    <TreeGridColumn HeaderText="<b>Cost Summary</b>" DisableHtmlEncode="false" TextAlign="TextAlign.Center">
        <TreeGridColumns>
            <TreeGridColumn Field=@nameof(ProjectTask.TotalBudget) HeaderText="<b>Planned Budget</b>" DisableHtmlEncode="false" Width="140" TextAlign="TextAlign.Right" Format="C0" AutoSpan="AutoSpanMode.None"></TreeGridColumn>
            <TreeGridColumn Field=@nameof(ProjectTask.PaidToDate) HeaderText="<b>Actual Spend</b>" DisableHtmlEncode="false" Width="140" TextAlign="TextAlign.Right" ClipMode="ClipMode.EllipsisWithTooltip" Format="C0" AutoSpan="AutoSpanMode.None"></TreeGridColumn>
        </TreeGridColumns>
    </TreeGridColumn>
</TreeGridColumns>
</SfTreeGrid>

@code {
    public SfTreeGrid<ProjectTask> TreeGridRef { get; set; }
    public List<ProjectTask> TreeGridData { get; set; } = new();
    protected override void OnInitialized()
    {
        TreeGridData = ProjectTask.GetRowSpanData();
    }
    public class ProjectTask
    {
        public string ActivityName { get; set; } = string.Empty;
        public string LevelId { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Supervisor { get; set; } = string.Empty;
        public string Team { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int Progress { get; set; }
        public decimal TotalBudget { get; set; }
        public decimal PaidToDate { get; set; }
        public string Currency { get; set; } = string.Empty;
        public string CostCode { get; set; } = string.Empty;
        public string PermitStatus { get; set; } = string.Empty;
        public DateTime? InspectionDate { get; set; }
        public string InspectionStatus { get; set; } = string.Empty;
        public string FollowUpActions { get; set; } = string.Empty;
        public decimal InspectionCost { get; set; }
        public string PunchListStatus { get; set; } = string.Empty;
        public string DocumentReference { get; set; } = string.Empty;
        public string MaterialUsed { get; set; } = string.Empty;
        public decimal MaterialCost { get; set; }
        public string MaterialStockRemaining { get; set; } = string.Empty;
        public List<ProjectTask> Children { get; set; } = new();
        public static List<ProjectTask> GetRowSpanData()
        {
            return new List<ProjectTask>
            {
                new ProjectTask
                {
                    ActivityName = "Tower",
                    LevelId = "L1-001",
                    StartDate = new DateTime(2025, 7, 1),
                    EndDate = new DateTime(2025, 12, 29),
                    Supervisor = "John Carter",
                    Team = "Executive Oversight",
                    Status = "Active",
                    Progress = 70,
                    TotalBudget = 1500000m,
                    PaidToDate = 1050000m,
                    Currency = "USD",
                    CostCode = "01-00-00",
                    PermitStatus = "Approved",
                    InspectionDate = new DateTime(2025, 12, 30),
                    InspectionStatus = "Active",
                    FollowUpActions = "Monitor progress",
                    InspectionCost = 600m,
                    PunchListStatus = "Open",
                    DocumentReference = "DOC-TWR-OVR",
                    MaterialUsed = "Project Planning Kits",
                    MaterialCost = 75000m,
                    MaterialStockRemaining = "N/A",
                    Children = new List<ProjectTask>
                    {
                        new ProjectTask
                        {
                            ActivityName = "Design Stage",
                            LevelId = "L2-001",
                            StartDate = new DateTime(2025, 7, 1),
                            EndDate = new DateTime(2025, 8, 15),
                            Supervisor = "Ethan Park",
                            Team = "Design Division",
                            Status = "Completed",
                            Progress = 100,
                            TotalBudget = 305000m,
                            PaidToDate = 350000m,
                            Currency = "USD",
                            CostCode = "02-01-00",
                            PermitStatus = "Issued",
                            InspectionDate = new DateTime(2025, 8, 16),
                            InspectionStatus = "Passed",
                            FollowUpActions = "None",
                            InspectionCost = 200m,
                            PunchListStatus = "Cleared",
                            DocumentReference = "DOC-TWR-DES-STG",
                            MaterialUsed = "Design Blueprints",
                            MaterialCost = 50000m,
                            MaterialStockRemaining = "N/A",
                            Children = new List<ProjectTask>
                            {
                                new ProjectTask { ActivityName = "Architectural Design Task", LevelId = "L3-001", StartDate = new DateTime(2025, 7, 2), EndDate = new DateTime(2025, 7, 10), Supervisor = "David Lin", Team = "Architecture Unit", Status = "Scheduled", Progress = 100, TotalBudget = 100000m, PaidToDate = 0m, Currency = "USD", CostCode = "02-02-01", PermitStatus = "Scheduled", InspectionDate = new DateTime(2025, 7, 11), InspectionStatus = "Passed", FollowUpActions = "None", InspectionCost = 100m, PunchListStatus = "Cleared", DocumentReference = "DOC-TWR-ARC-TSK", MaterialUsed = "CAD Drawings", MaterialCost = 15000m, MaterialStockRemaining = "N/A" },
                                new ProjectTask { ActivityName = "Structural Design Task", LevelId = "L3-002", StartDate = new DateTime(2025, 7, 11), EndDate = new DateTime(2025, 7, 25), Supervisor = "Sarah Patel", Team = "Structural Unit", Status = "Scheduled", Progress = 100, TotalBudget = 120000m, PaidToDate = 0m, Currency = "USD", CostCode = "02-02-02", PermitStatus = "Scheduled", InspectionDate = new DateTime(2025, 7, 26), InspectionStatus = "Passed", FollowUpActions = "None", InspectionCost = 100m, PunchListStatus = "Cleared", DocumentReference = "DOC-TWR-STR-TSK", MaterialUsed = "Structural Plans", MaterialCost = 15000m, MaterialStockRemaining = "N/A" },
                                new ProjectTask { ActivityName = "MEP Design Task", LevelId = "L3-003", StartDate = new DateTime(2025, 7, 26), EndDate = new DateTime(2025, 8, 15), Supervisor = "Carlos Rivera", Team = "MEP Unit", Status = "Scheduled", Progress = 100, TotalBudget = 100000m, PaidToDate = 0m, Currency = "USD", CostCode = "02-02-03", PermitStatus = "Scheduled", InspectionDate = new DateTime(2025, 8, 16), InspectionStatus = "Passed", FollowUpActions = "None", InspectionCost = 100m, PunchListStatus = "Cleared", DocumentReference = "DOC-TWR-MEP-TSK", MaterialUsed = "Electrical Schematics", MaterialCost = 20000m, MaterialStockRemaining = "N/A" }
                            }
                        },
                        new ProjectTask
                        {
                            ActivityName = "Construction Stage",
                            LevelId = "L2-002",
                            StartDate = new DateTime(2025, 8, 16),
                            EndDate = new DateTime(2025, 10, 20),
                            Supervisor = "James Patel",
                            Team = "Construction Division",
                            Status = "In Progress",
                            Progress = 75,
                            TotalBudget = 900000m,
                            PaidToDate = 675000m,
                            Currency = "USD",
                            CostCode = "03-01-00",
                            PermitStatus = "Issued",
                            InspectionDate = new DateTime(2025, 10, 21),
                            InspectionStatus = "Passed with Notes",
                            FollowUpActions = "Reinforce structure",
                            InspectionCost = 300m,
                            PunchListStatus = "Open",
                            DocumentReference = "DOC-TWR-CON-STG",
                            MaterialUsed = "Construction Materials",
                            MaterialCost = 50000m,
                            MaterialStockRemaining = "300 tons",
                            Children = new List<ProjectTask>
                            {
                                new ProjectTask { ActivityName = "Foundation Construction Task", LevelId = "L3-004", StartDate = new DateTime(2025, 8, 16), EndDate = new DateTime(2025, 8, 25), Supervisor = "Robert Singh", Team = "Foundation Crew", Status = "Completed", Progress = 100, TotalBudget = 305000m, PaidToDate = 350000m, Currency = "USD", CostCode = "03-02-01", PermitStatus = "Approved", InspectionDate = new DateTime(2025, 8, 26), InspectionStatus = "Passed", FollowUpActions = "None", InspectionCost = 100m, PunchListStatus = "Cleared", DocumentReference = "DOC-TWR-FND-TSK", MaterialUsed = "Concrete", MaterialCost = 15000m, MaterialStockRemaining = "N/A" },
                                new ProjectTask { ActivityName = "Structural Construction Task", LevelId = "L3-005", StartDate = new DateTime(2025, 8, 26), EndDate = new DateTime(2025, 9, 20), Supervisor = "Nathan Blake", Team = "Structural Team", Status = "In Progress", Progress = 80, TotalBudget = 300000m, PaidToDate = 240000m, Currency = "USD", CostCode = "03-02-02", PermitStatus = "Approved", InspectionDate = new DateTime(2025, 9, 21), InspectionStatus = "Passed with Notes", FollowUpActions = "Reinforce beams", InspectionCost = 100m, PunchListStatus = "Open", DocumentReference = "DOC-TWR-STR-TSK", MaterialUsed = "Steel Beams", MaterialCost = 20000m, MaterialStockRemaining = "200 tons" },
                                new ProjectTask { ActivityName = "Exterior Construction Task", LevelId = "L3-006", StartDate = new DateTime(2025, 9, 21), EndDate = new DateTime(2025, 10, 20), Supervisor = "Thomas Reed", Team = "Exterior Crew", Status = "In Progress", Progress = 40, TotalBudget = 300000m, PaidToDate = 120000m, Currency = "USD", CostCode = "03-02-03", PermitStatus = "Approved", InspectionDate = new DateTime(2025, 10, 21), InspectionStatus = "Passed with Notes", FollowUpActions = "Continue exterior work", InspectionCost = 100m, PunchListStatus = "Open", DocumentReference = "DOC-TWR-EXT-TSK", MaterialUsed = "Metal Panels", MaterialCost = 15000m, MaterialStockRemaining = "300 panels" }
                            }
                        },
                        new ProjectTask
                        {
                            ActivityName = "Safety Stage",
                            LevelId = "L2-003",
                            StartDate = new DateTime(2025, 10, 21),
                            EndDate = new DateTime(2025, 11, 5),
                            Supervisor = "Nathan Blake",
                            Team = "Safety Division",
                            Status = "In Progress",
                            Progress = 60,
                            TotalBudget = 50000m,
                            PaidToDate = 30000m,
                            Currency = "USD",
                            CostCode = "04-01-00",
                            PermitStatus = "Issued",
                            InspectionDate = new DateTime(2025, 11, 6),
                            InspectionStatus = "Scheduled",
                            FollowUpActions = "Complete safety audit",
                            InspectionCost = 0m,
                            PunchListStatus = "Open",
                            DocumentReference = "DOC-TWR-SAF-STG",
                            MaterialUsed = "Safety Equipment",
                            MaterialCost = 10000m,
                            MaterialStockRemaining = "50 units",
                            Children = new List<ProjectTask>
                            {
                                new ProjectTask { ActivityName = "OSHA Compliance Task", LevelId = "L3-007", StartDate = new DateTime(2025, 10, 21), EndDate = new DateTime(2025, 10, 27), Supervisor = "Laura Bennett", Team = "Safety Inspectors", Status = "In Progress", Progress = 70, TotalBudget = 20000m, PaidToDate = 14000m, Currency = "USD", CostCode = "04-02-01", PermitStatus = "Issued", InspectionDate = new DateTime(2025, 10, 28), InspectionStatus = "In Progress", FollowUpActions = "Complete briefing", InspectionCost = 0m, PunchListStatus = "Open", DocumentReference = "DOC-TWR-OSHA-TSK", MaterialUsed = "Safety Gear", MaterialCost = 4000m, MaterialStockRemaining = "40 helmets" },
                                new ProjectTask { ActivityName = "Fire Safety Task", LevelId = "L3-008", StartDate = new DateTime(2025, 10, 28), EndDate = new DateTime(2025, 11, 1), Supervisor = "Melissa Tran", Team = "Fire Safety Team", Status = "Scheduled", Progress = 30, TotalBudget = 15000m, PaidToDate = 0m, Currency = "USD", CostCode = "04-02-02", PermitStatus = "Issued", InspectionDate = new DateTime(2025, 11, 2), InspectionStatus = "Scheduled", FollowUpActions = "Install exits", InspectionCost = 0m, PunchListStatus = "Open", DocumentReference = "DOC-TWR-FIRE-TSK", MaterialUsed = "Extinguishers", MaterialCost = 3000m, MaterialStockRemaining = "15 units" },
                                new ProjectTask { ActivityName = "Structural Audit Task", LevelId = "L3-009", StartDate = new DateTime(2025, 11, 2), EndDate = new DateTime(2025, 11, 5), Supervisor = "David Lin", Team = "Audit Engineers", Status = "Scheduled", Progress = 20, TotalBudget = 15000m, PaidToDate = 0m, Currency = "USD", CostCode = "04-02-03", PermitStatus = "Issued", InspectionDate = new DateTime(2025, 11, 6), InspectionStatus = "Scheduled", FollowUpActions = "Verify integrity", InspectionCost = 0m, PunchListStatus = "Open", DocumentReference = "DOC-TWR-AUD-TSK", MaterialUsed = "Inspection Tools", MaterialCost = 3000m, MaterialStockRemaining = "N/A" }
                            }
                        },
                        new ProjectTask
                        {
                            ActivityName = "Finishing Stage",
                            LevelId = "L2-004",
                            StartDate = new DateTime(2025, 11, 6),
                            EndDate = new DateTime(2025, 12, 10),
                            Supervisor = "Melissa Tran",
                            Team = "Finishing Division",
                            Status = "Planning",
                            Progress = 30,
                            TotalBudget = 250000m,
                            PaidToDate = 75000m,
                            Currency = "USD",
                            CostCode = "05-01-00",
                            PermitStatus = "Under Review",
                            InspectionDate = new DateTime(2025, 12, 11),
                            InspectionStatus = "Scheduled",
                            FollowUpActions = "Begin interior work",
                            InspectionCost = 0m,
                            PunchListStatus = "Pending",
                            DocumentReference = "DOC-TWR-FIN-STG",
                            MaterialUsed = "Finishing Supplies",
                            MaterialCost = 25000m,
                            MaterialStockRemaining = "200 units",
                            Children = new List<ProjectTask>
                            {
                                new ProjectTask { ActivityName = "Interior Drywall Task", LevelId = "L3-010", StartDate = new DateTime(2025, 11, 6), EndDate = new DateTime(2025, 11, 20), Supervisor = "Hannah Kim", Team = "Drywall Crew", Status = "In Progress", Progress = 50, TotalBudget = 80000m, PaidToDate = 40000m, Currency = "USD", CostCode = "05-02-01", PermitStatus = "Issued", InspectionDate = new DateTime(2025, 11, 21), InspectionStatus = "In Progress", FollowUpActions = "Check alignment", InspectionCost = 0m, PunchListStatus = "Open", DocumentReference = "DOC-TWR-DRY-TSK", MaterialUsed = "Drywall Sheets", MaterialCost = 8000m, MaterialStockRemaining = "150 panels" },
                                new ProjectTask { ActivityName = "Flooring Installation Task", LevelId = "L3-011", StartDate = new DateTime(2025, 11, 21), EndDate = new DateTime(2025, 12, 1), Supervisor = "Sarah Patel", Team = "Flooring Team", Status = "Scheduled", Progress = 10, TotalBudget = 80000m, PaidToDate = 0m, Currency = "USD", CostCode = "05-02-02", PermitStatus = "Issued", InspectionDate = new DateTime(2025, 12, 2), InspectionStatus = "Scheduled", FollowUpActions = "Verify level", InspectionCost = 0m, PunchListStatus = "Open", DocumentReference = "DOC-TWR-FLR-TSM", MaterialUsed = "Concrete Flooring", MaterialCost = 10000m, MaterialStockRemaining = "200 bags" },
                                new ProjectTask { ActivityName = "Fixture Setup Task", LevelId = "L3-012", StartDate = new DateTime(2025, 12, 2), EndDate = new DateTime(2025, 12, 10), Supervisor = "Lucas Nguyen", Team = "Fit-Out Crew", Status = "Scheduled", Progress = 10, TotalBudget = 90000m, PaidToDate = 0m, Currency = "USD", CostCode = "05-02-03", PermitStatus = "Issued", InspectionDate = new DateTime(2025, 12, 11), InspectionStatus = "Scheduled", FollowUpActions = "Install fixtures", InspectionCost = 0m, PunchListStatus = "Open", DocumentReference = "DOC-TWR-FIX-TSK", MaterialUsed = "Lighting Fixtures", MaterialCost = 7000m, MaterialStockRemaining = "50 units" }
                            }
                        },
                        new ProjectTask
                        {
                            ActivityName = "Closeout Stage",
                            LevelId = "L2-005",
                            StartDate = new DateTime(2025, 12, 11),
                            EndDate = new DateTime(2025, 12, 29),
                            Supervisor = "Emma Wilson",
                            Team = "Closeout Division",
                            Status = "Planning",
                            Progress = 20,
                            TotalBudget = 50000m,
                            PaidToDate = 10000m,
                            Currency = "USD",
                            CostCode = "06-01-00",
                            PermitStatus = "Under Review",
                            InspectionDate = new DateTime(2025, 12, 30),
                            InspectionStatus = "Scheduled",
                            FollowUpActions = "Finalize handover",
                            InspectionCost = 0m,
                            PunchListStatus = "Open",
                            DocumentReference = "DOC-TWR-CLO-STG",
                            MaterialUsed = "Closeout Documents",
                            MaterialCost = 5000m,
                            MaterialStockRemaining = "N/A",
                            Children = new List<ProjectTask>
                            {
                                new ProjectTask { ActivityName = "Punch List Review Task", LevelId = "L3-013", StartDate = new DateTime(2025, 12, 11), EndDate = new DateTime(2025, 12, 15), Supervisor = "John Carter", Team = "Closeout Team", Status = "Scheduled", Progress = 20, TotalBudget = 15000m, PaidToDate = 0m, Currency = "USD", CostCode = "06-02-01", PermitStatus = "Scheduled", InspectionDate = new DateTime(2025, 12, 16), InspectionStatus = "Not Started", FollowUpActions = "Resolve issues", InspectionCost = 0m, PunchListStatus = "Pending", DocumentReference = "DOC-TWR-PLR-TSK", MaterialUsed = "Punch List Forms", MaterialCost = 2000m, MaterialStockRemaining = "N/A" },
                                new ProjectTask { ActivityName = "Final Documentation Task", LevelId = "L3-014", StartDate = new DateTime(2025, 12, 16), EndDate = new DateTime(2025, 12, 22), Supervisor = "Emily Foster", Team = "Documentation Team", Status = "Scheduled", Progress = 20, TotalBudget = 15000m, PaidToDate = 0m, Currency = "USD", CostCode = "06-02-02", PermitStatus = "Scheduled", InspectionDate = new DateTime(2025, 12, 23), InspectionStatus = "Not Started", FollowUpActions = "Prepare reports", InspectionCost = 0m, PunchListStatus = "Pending", DocumentReference = "DOC-TWR-FD-TSK", MaterialUsed = "As-Built Drawings", MaterialCost = 2000m, MaterialStockRemaining = "N/A" },
                                new ProjectTask { ActivityName = "Client Handover Task", LevelId = "L3-015", StartDate = new DateTime(2025, 12, 23), EndDate = new DateTime(2025, 12, 29), Supervisor = "Emma Wilson", Team = "Client Relations", Status = "Scheduled", Progress = 20, TotalBudget = 20000m, PaidToDate = 0m, Currency = "USD", CostCode = "06-02-03", PermitStatus = "Scheduled", InspectionDate = new DateTime(2025, 12, 30), InspectionStatus = "Not Started", FollowUpActions = "Conduct walkthrough", InspectionCost = 0m, PunchListStatus = "Pending", DocumentReference = "DOC-TWR-CH-TSK", MaterialUsed = "Handover Kits", MaterialCost = 1000m, MaterialStockRemaining = "Delivered" }
                            }
                        }
                    }
                },
                new ProjectTask
                {
                    ActivityName = "Warehouse",
                    LevelId = "L1-004",
                    StartDate = new DateTime(2025, 8, 1),
                    EndDate = new DateTime(2025, 12, 28),
                    Supervisor = "Emma Wilson",
                    Team = "Executive Oversight",
                    Status = "Active",
                    Progress = 55,
                    TotalBudget = 1030000m,
                    PaidToDate = 566500m,
                    Currency = "USD",
                    CostCode = "01-00-00",
                    PermitStatus = "Approved",
                    InspectionDate = new DateTime(2025, 12, 29),
                    InspectionStatus = "Passed with Notes",
                    FollowUpActions = "Address structural concerns",
                    InspectionCost = 400m,
                    PunchListStatus = "Open",
                    DocumentReference = "DOC-WH-OVR",
                    MaterialUsed = "Project Planning Kits",
                    MaterialCost = 50000m,
                    MaterialStockRemaining = "N/A",
                    Children = new List<ProjectTask>
                    {
                        new ProjectTask
                        {
                            ActivityName = "Design Stage",
                            LevelId = "L2-016",
                            StartDate = new DateTime(2025, 8, 1),
                            EndDate = new DateTime(2025, 9, 10),
                            Supervisor = "Ethan Park",
                            Team = "Design Division",
                            Status = "Completed",
                            Progress = 100,
                            TotalBudget = 202000m,
                            PaidToDate = 220000m,
                            Currency = "USD",
                            CostCode = "02-01-00",
                            PermitStatus = "Issued",
                            InspectionDate = new DateTime(2025, 9, 11),
                            InspectionStatus = "Passed",
                            FollowUpActions = "None",
                            InspectionCost = 300m,
                            PunchListStatus = "Cleared",
                            DocumentReference = "DOC-WH-DES-STG",
                            MaterialUsed = "Design Blueprints",
                            MaterialCost = 30000m,
                            MaterialStockRemaining = "N/A",
                            Children = new List<ProjectTask>
                            {
                                new ProjectTask { ActivityName = "Architectural Design Task", LevelId = "L3-046", StartDate = new DateTime(2025, 8, 2), EndDate = new DateTime(2025, 8, 12), Supervisor = "David Lin", Team = "Architecture Unit", Status = "Completed", Progress = 100, TotalBudget = 70000m, PaidToDate = 70200m, Currency = "USD", CostCode = "02-02-01", PermitStatus = "Approved", InspectionDate = new DateTime(2025, 8, 13), InspectionStatus = "Passed", FollowUpActions = "None", InspectionCost = 100m, PunchListStatus = "Cleared", DocumentReference = "DOC-WH-ARC-TSK", MaterialUsed = "CAD Drawings", MaterialCost = 10000m, MaterialStockRemaining = "N/A" },
                                new ProjectTask { ActivityName = "Structural Design Task", LevelId = "L3-047", StartDate = new DateTime(2025, 8, 13), EndDate = new DateTime(2025, 8, 28), Supervisor = "Sarah Patel", Team = "Structural Unit", Status = "Completed", Progress = 100, TotalBudget = 72000m, PaidToDate = 70000m, Currency = "USD", CostCode = "02-02-02", PermitStatus = "Approved", InspectionDate = new DateTime(2025, 8, 29), InspectionStatus = "Passed", FollowUpActions = "None", InspectionCost = 100m, PunchListStatus = "Cleared", DocumentReference = "DOC-WH-STR-TSK", MaterialUsed = "Structural Plans", MaterialCost = 10000m, MaterialStockRemaining = "N/A" },
                                new ProjectTask { ActivityName = "MEP Design Task", LevelId = "L3-048", StartDate = new DateTime(2025, 8, 29), EndDate = new DateTime(2025, 9, 10), Supervisor = "Carlos Rivera", Team = "MEP Unit", Status = "Completed", Progress = 100, TotalBudget = 62000m, PaidToDate = 60000m, Currency = "USD", CostCode = "02-02-03", PermitStatus = "Approved", InspectionDate = new DateTime(2025, 9, 11), InspectionStatus = "Passed", FollowUpActions = "None", InspectionCost = 100m, PunchListStatus = "Cleared", DocumentReference = "DOC-WH-MEP-TSK", MaterialUsed = "Electrical Schematics", MaterialCost = 10000m, MaterialStockRemaining = "N/A" }
                            }
                        },
                        new ProjectTask
                        {
                            ActivityName = "Construction Stage",
                            LevelId = "L2-017",
                            StartDate = new DateTime(2025, 9, 11),
                            EndDate = new DateTime(2025, 11, 20),
                            Supervisor = "James Patel",
                            Team = "Construction Division",
                            Status = "In Progress",
                            Progress = 50,
                            TotalBudget = 800000m,
                            PaidToDate = 400000m,
                            Currency = "USD",
                            CostCode = "03-01-00",
                            PermitStatus = "Issued",
                            InspectionDate = new DateTime(2025, 11, 21),
                            InspectionStatus = "Passed with Notes",
                            FollowUpActions = "Address structural issues",
                            InspectionCost = 400m,
                            PunchListStatus = "Open",
                            DocumentReference = "DOC-WH-CON-STG",
                            MaterialUsed = "Construction Materials",
                            MaterialCost = 200000m,
                            MaterialStockRemaining = "500 tons",
                            Children = new List<ProjectTask>
                            {
                                new ProjectTask { ActivityName = "Foundation Construction Task", LevelId = "L3-049", StartDate = new DateTime(2025, 9, 11), EndDate = new DateTime(2025, 9, 25), Supervisor = "Robert Singh", Team = "Foundation Crew", Status = "Completed", Progress = 100, TotalBudget = 300000m, PaidToDate = 320000m, Currency = "USD", CostCode = "03-02-01", PermitStatus = "Approved", InspectionDate = new DateTime(2025, 9, 26), InspectionStatus = "Passed", FollowUpActions = "None", InspectionCost = 100m, PunchListStatus = "Cleared", DocumentReference = "DOC-WH-FND-TSK", MaterialUsed = "Concrete Mix", MaterialCost = 80000m, MaterialStockRemaining = "N/A" },
                                new ProjectTask { ActivityName = "Framing Construction Task", LevelId = "L3-050", StartDate = new DateTime(2025, 9, 26), EndDate = new DateTime(2025, 10, 25), Supervisor = "Angela Moore", Team = "Structural Crew", Status = "In Progress", Progress = 60, TotalBudget = 300000m, PaidToDate = 180000m, Currency = "USD", CostCode = "03-02-02", PermitStatus = "Approved", InspectionDate = new DateTime(2025, 10, 26), InspectionStatus = "Passed with Notes", FollowUpActions = "Continue framing", InspectionCost = 200m, PunchListStatus = "Open", DocumentReference = "DOC-WH-FRM-TSK", MaterialUsed = "Steel Beams", MaterialCost = 60000m, MaterialStockRemaining = "200 tons" },
                                new ProjectTask { ActivityName = "Exterior Construction Task", LevelId = "L3-051", StartDate = new DateTime(2025, 10, 26), EndDate = new DateTime(2025, 11, 20), Supervisor = "Thomas Reed", Team = "Exterior Crew", Status = "In Progress", Progress = 20, TotalBudget = 200000m, PaidToDate = 40000m, Currency = "USD", CostCode = "03-02-03", PermitStatus = "Issued", InspectionDate = new DateTime(2025, 11, 21), InspectionStatus = "In Progress", FollowUpActions = "Continue exterior work", InspectionCost = 0m, PunchListStatus = "Open", DocumentReference = "DOC-WH-EXT-TSK", MaterialUsed = "Metal Panels", MaterialCost = 60000m, MaterialStockRemaining = "300 panels" }
                            }
                        },
                        new ProjectTask
                        {
                            ActivityName = "Safety Stage",
                            LevelId = "L2-018",
                            StartDate = new DateTime(2025, 11, 21),
                            EndDate = new DateTime(2025, 12, 10),
                            Supervisor = "Nathan Blake",
                            Team = "Safety Division",
                            Status = "Planning",
                            Progress = 30,
                            TotalBudget = 30000m,
                            PaidToDate = 9000m,
                            Currency = "USD",
                            CostCode = "04-01-00",
                            PermitStatus = "Under Review",
                            InspectionDate = new DateTime(2025, 12, 11),
                            InspectionStatus = "Scheduled",
                            FollowUpActions = "Schedule safety audit",
                            InspectionCost = 0m,
                            PunchListStatus = "Scheduled",
                            DocumentReference = "DOC-WH-SAF-STG",
                            MaterialUsed = "Safety Equipment",
                            MaterialCost = 5000m,
                            MaterialStockRemaining = "50 units",
                            Children = new List<ProjectTask>
                            {
                                new ProjectTask { ActivityName = "OSHA Compliance Task", LevelId = "L3-052", StartDate = new DateTime(2025, 11, 21), EndDate = new DateTime(2025, 11, 28), Supervisor = "Laura Bennett", Team = "Safety Inspectors", Status = "Scheduled", Progress = 30, TotalBudget = 10000m, PaidToDate = 0m, Currency = "USD", CostCode = "04-02-01", PermitStatus = "Scheduled", InspectionDate = new DateTime(2025, 11, 29), InspectionStatus = "Not Started", FollowUpActions = "Conduct briefing", InspectionCost = 0m, PunchListStatus = "Not Started", DocumentReference = "DOC-WH-OSHA-TSK", MaterialUsed = "Safety Gear", MaterialCost = 2000m, MaterialStockRemaining = "40 helmets" },
                                new ProjectTask { ActivityName = "Fire Safety Task", LevelId = "L3-053", StartDate = new DateTime(2025, 11, 29), EndDate = new DateTime(2025, 12, 5), Supervisor = "Melissa Tran", Team = "Fire Safety Team", Status = "Scheduled", Progress = 20, TotalBudget = 10000m, PaidToDate = 0m, Currency = "USD", CostCode = "04-02-02", PermitStatus = "Scheduled", InspectionDate = new DateTime(2025, 12, 6), InspectionStatus = "Not Started", FollowUpActions = "Install exits", InspectionCost = 0m, PunchListStatus = "Not Started", DocumentReference = "DOC-WH-FIRE-TSK", MaterialUsed = "Extinguishers", MaterialCost = 1500m, MaterialStockRemaining = "15 units" },
                                new ProjectTask { ActivityName = "Structural Audit Task", LevelId = "L3-054", StartDate = new DateTime(2025, 12, 6), EndDate = new DateTime(2025, 12, 10), Supervisor = "David Lin", Team = "Audit Engineers", Status = "Scheduled", Progress = 20, TotalBudget = 10000m, PaidToDate = 0m, Currency = "USD", CostCode = "04-02-03", PermitStatus = "Scheduled", InspectionDate = new DateTime(2025, 12, 11), InspectionStatus = "Not Started", FollowUpActions = "Verify integrity", InspectionCost = 0m, PunchListStatus = "Not Started", DocumentReference = "DOC-WH-AUD-TSK", MaterialUsed = "Inspection Tools", MaterialCost = 1500m, MaterialStockRemaining = "N/A" }
                            }
                        }
                    }
                }
            };
        }
    }
}
{% endhighlight %}
{% endtabs %}

The effective spanning behavior in the Syncfusion Blazor TreeGrid is determined by the intersection of TreeGrid-level and column-level `AutoSpan` modes. A column can only restrict the spanning directions permitted at the TreeGrid level and cannot enable a span direction that has been disabled globally. This ensures consistent behavior across the TreeGrid while allowing fine-grained control for individual columns.

### Complete combination matrix

| TreeGrid AutoSpan | Column AutoSpan | Effective Behavior |
|---|---|---|
| None | None | No spanning. Both TreeGrid and column explicitly disable spanning. |
| None | Row | No spanning. TreeGrid-level None overrides column-level Row. |
| None | Column | No spanning. TreeGrid-level None overrides column-level Column. |
| None | HorizontalAndVertical | No spanning. TreeGrid-level None overrides all spanning modes. |
| Row | None | No spanning. Column explicitly disables spanning. |
| Row | Row | Row spanning only. Both TreeGrid and column enable row spanning. |
| Row | Column | No spanning. TreeGrid only allows row spanning; column cannot enable column spanning. |
| Row | HorizontalAndVertical | Row spanning only. TreeGrid only allows row spanning. |
| Column | None | No spanning. Column explicitly disables spanning. |
| Column | Row | No spanning. TreeGrid only allows column spanning; column cannot enable row spanning. |
| Column | Column | Column spanning only. Both TreeGrid and column enable column spanning. |
| Column | HorizontalAndVertical | Column spanning only. TreeGrid only allows column spanning. |
| HorizontalAndVertical | None | No spanning. Column explicitly disables both directions. |
| HorizontalAndVertical | Row | Row spanning only. TreeGrid allows both; column narrows to Row. |
| HorizontalAndVertical | Column | Column spanning only. TreeGrid allows both; column narrows to Column. |
| HorizontalAndVertical | HorizontalAndVertical | Row and Column spanning. Both TreeGrid and column enable both directions. |

---

## Applying column spanning via programmatically

In addition to automatic cell merging, the Syncfusion Blazor TreeGrid provides API support for manually merging cells when custom layout behavior is required. This functionality is available through the `MergeCellsAsync` method, which enables the definition of rectangular regions of cells to be merged programmatically.

Use `MergeCellsAsync` method to manually merge cells by defining rectangular regions. This method supports both single and batch merging, allowing precise control over layout customization when automatic spanning is insufficient.

| Parameter | Type | Description |
|-----------|------|-------------|
| info | `MergeCellInfo` | Defines a single rectangular cell region to be merged. |
| infos | `IEnumerable<MergeCellInfo>` | Specifies multiple cell regions to be merged in a batch operation. Each region is defined by a `MergeCellInfo` instance. |

To define a merged region, use the following properties of the MergeCellInfo class,

| Property     | Type | Description                                                                 |
|--------------|------|-----------------------------------------------------------------------------|
| RowIndex     | int  | The zero-based index of the anchor row (top-left cell of the merged region). |
| ColumnIndex  | int  | The zero-based index of the anchor column (top-left cell of the merged region). |
| RowSpan      | int (optional) | The number of rows to span, starting from the anchor cell. By default set to 1. |
| ColumnSpan   | int (optional) | The number of columns to span, starting from the anchor cell. By default set to 1. |

The following sample demonstrates programmatic column spanning by calling `MergeCellsAsync` with `RowIndex`, `ColumnIndex`, and `ColumnSpan` for a single merge, and by passing multiple `MergeCellInfo` objects with the same parameters in an array for batch merging.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="MergeCellsAsync">Merge Cell</SfButton>
<SfButton OnClick="MergeMultipleCellsAsync">Merge Multiple Cells</SfButton>

<SfTreeGrid TValue="ProjectTask" @ref="Grid" DataSource="@Tasks" ChildMapping="Children" TreeColumnIndex="0" AllowPaging="true" GridLines="GridLine.Both">
    <TreeGridColumns>
        <TreeGridColumn Field="@nameof(ProjectTask.ActivityName)" HeaderText="Activity Name" Width="180" />
        <TreeGridColumn Field="@nameof(ProjectTask.StartDate)" HeaderText="Start Date" Format="d" Type="ColumnType.Date" Width="130" />
        <TreeGridColumn Field="@nameof(ProjectTask.EndDate)" HeaderText="End Date" Format="d" Type="ColumnType.Date" Width="130" />
        <TreeGridColumn Field="@nameof(ProjectTask.Supervisor)" HeaderText="Supervisor" Width="150" />
        <TreeGridColumn Field="@nameof(ProjectTask.Progress)" HeaderText="Progress" Width="100" />
        <TreeGridColumn Field="@nameof(ProjectTask.Status)" HeaderText="Status" Width="120" />
    </TreeGridColumns>
</SfTreeGrid>

@code 
{
    private SfTreeGrid<ProjectTask> Grid;
    public List<ProjectTask> Tasks { get; set; }

    public async Task MergeCellsAsync()
    {
        await Grid.MergeCellsAsync(new MergeCellInfo
        {
            RowIndex = 1,
            ColumnIndex = 1,
            ColumnSpan = 2,
        });
    }

    public async Task MergeMultipleCellsAsync()
    {
        await Grid.MergeCellsAsync(new[]
        {
            new MergeCellInfo { RowIndex = 0, ColumnIndex = 0, ColumnSpan = 2 },
            new MergeCellInfo { RowIndex = 5, ColumnIndex = 0, ColumnSpan = 3 },
            new MergeCellInfo { RowIndex = 7, ColumnIndex = 0, ColumnSpan = 2 }
        });
    }

    protected override void OnInitialized()
    {
        Tasks = ProjectTask.GetRowSpanData();
    }
}
{% endhighlight %}
{% highlight c# tabtitle="Order.cs" %}

public class ProjectTask
{
    public string ActivityName { get; set; } = string.Empty;
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Supervisor { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public int Progress { get; set; }
    public List<ProjectTask> Children { get; set; } = new();

    public static List<ProjectTask> GetRowSpanData()
    {
        return new List<ProjectTask>
        {
            new ProjectTask 
            { 
                ActivityName = "Tower",
                StartDate = new DateTime(2025, 7, 1),
                EndDate = new DateTime(2025, 12, 29),
                Supervisor = "John Carter",
                Status = "In Progress",
                Progress = 87,
                Children = new List<ProjectTask>
                {
                    new ProjectTask 
                    { 
                        ActivityName = "Design Stage",
                        StartDate = new DateTime(2025, 7, 1),
                        EndDate = new DateTime(2025, 8, 15),
                        Supervisor = "Ethan Park",
                        Status = "Completed",
                        Progress = 100,
                        Children = new List<ProjectTask>
                        {
                            new ProjectTask { ActivityName = "Architectural Design Task", StartDate = new DateTime(2025, 7, 2), EndDate = new DateTime(2025, 7, 10), Supervisor = "David Lin", Status = "Completed", Progress = 100 },
                            new ProjectTask { ActivityName = "Structural Design Task", StartDate = new DateTime(2025, 7, 11), EndDate = new DateTime(2025, 7, 25), Supervisor = "Sarah Patel", Status = "Completed", Progress = 100 },
                            new ProjectTask { ActivityName = "MEP Design Task", StartDate = new DateTime(2025, 7, 26), EndDate = new DateTime(2025, 8, 15), Supervisor = "Carlos Rivera", Status = "Completed", Progress = 100 }
                        }
                    },
                    new ProjectTask 
                    { 
                        ActivityName = "Construction Stage",
                        StartDate = new DateTime(2025, 8, 16),
                        EndDate = new DateTime(2025, 10, 20),
                        Supervisor = "James Patel",
                        Status = "Completed",
                        Progress = 100,
                        Children = new List<ProjectTask>
                        {
                            new ProjectTask { ActivityName = "Foundation Construction Task", StartDate = new DateTime(2025, 8, 16), EndDate = new DateTime(2025, 8, 25), Supervisor = "Robert Singh", Status = "Completed", Progress = 100 },
                            new ProjectTask { ActivityName = "Structural Construction Task", StartDate = new DateTime(2025, 8, 26), EndDate = new DateTime(2025, 9, 20), Supervisor = "Nathan Blake", Status = "Completed", Progress = 100 },
                            new ProjectTask { ActivityName = "Exterior Construction Task", StartDate = new DateTime(2025, 9, 21), EndDate = new DateTime(2025, 10, 20), Supervisor = "Thomas Reed", Status = "Completed", Progress = 100 }
                        }
                    },
                    new ProjectTask 
                    { 
                        ActivityName = "Safety Stage",
                        StartDate = new DateTime(2025, 10, 21),
                        EndDate = new DateTime(2025, 11, 5),
                        Supervisor = "Nathan Blake",
                        Status = "Completed",
                        Progress = 100,
                        Children = new List<ProjectTask>
                        {
                            new ProjectTask { ActivityName = "OSHA Compliance Task", StartDate = new DateTime(2025, 10, 21), EndDate = new DateTime(2025, 10, 27), Supervisor = "Laura Bennett", Status = "Completed", Progress = 100 },
                            new ProjectTask { ActivityName = "Fire Safety Task", StartDate = new DateTime(2025, 10, 28), EndDate = new DateTime(2025, 11, 1), Supervisor = "Melissa Tran", Status = "Completed", Progress = 100 },
                            new ProjectTask { ActivityName = "Structural Audit Task", StartDate = new DateTime(2025, 11, 2), EndDate = new DateTime(2025, 11, 5), Supervisor = "David Lin", Status = "Completed", Progress = 100 }
                        }
                    },
                    new ProjectTask 
                    { 
                        ActivityName = "Finishing Stage",
                        StartDate = new DateTime(2025, 11, 6),
                        EndDate = new DateTime(2025, 12, 10),
                        Supervisor = "Melissa Tran",
                        Status = "Completed",
                        Progress = 100,
                        Children = new List<ProjectTask>
                        {
                            new ProjectTask { ActivityName = "Interior Drywall Task", StartDate = new DateTime(2025, 11, 6), EndDate = new DateTime(2025, 11, 20), Supervisor = "Hannah Kim", Status = "Completed", Progress = 100 },
                            new ProjectTask { ActivityName = "Flooring Installation Task", StartDate = new DateTime(2025, 11, 21), EndDate = new DateTime(2025, 12, 1), Supervisor = "Sarah Patel", Status = "Completed", Progress = 100 },
                            new ProjectTask { ActivityName = "Fixture Setup Task", StartDate = new DateTime(2025, 12, 2), EndDate = new DateTime(2025, 12, 10), Supervisor = "Lucas Nguyen", Status = "Completed", Progress = 100 }
                        }
                    },
                    new ProjectTask 
                    { 
                        ActivityName = "Closeout Stage",
                        StartDate = new DateTime(2025, 12, 11),
                        EndDate = new DateTime(2025, 12, 29),
                        Supervisor = "Emma Wilson",
                        Status = "In Progress",
                        Progress = 33,
                        Children = new List<ProjectTask>
                        {
                            new ProjectTask { ActivityName = "Punch List Review Task", StartDate = new DateTime(2025, 12, 11), EndDate = new DateTime(2025, 12, 15), Supervisor = "John Carter", Status = "Completed", Progress = 100 },
                            new ProjectTask { ActivityName = "Final Documentation Task", StartDate = new DateTime(2025, 12, 16), EndDate = new DateTime(2025, 12, 22), Supervisor = "Emily Foster", Status = "In Progress", Progress = 0 },
                            new ProjectTask { ActivityName = "Client Handover Task", StartDate = new DateTime(2025, 12, 23), EndDate = new DateTime(2025, 12, 29), Supervisor = "Emma Wilson", Status = "Scheduled", Progress = 0 }
                        }
                    }
                }
            },
            new ProjectTask 
            { 
                ActivityName = "Warehouse",
                StartDate = new DateTime(2025, 8, 1),
                EndDate = new DateTime(2025, 12, 28),
                Supervisor = "Emma Wilson",
                Status = "Completed",
                Progress = 100,
                Children = new List<ProjectTask>
                {
                    new ProjectTask 
                    { 
                        ActivityName = "Design Stage",
                        StartDate = new DateTime(2025, 8, 1),
                        EndDate = new DateTime(2025, 9, 10),
                        Supervisor = "Ethan Park",
                        Status = "Completed",
                        Progress = 100,
                        Children = new List<ProjectTask>
                        {
                            new ProjectTask { ActivityName = "Architectural Design Task", StartDate = new DateTime(2025, 8, 2), EndDate = new DateTime(2025, 8, 12), Supervisor = "David Lin", Status = "Completed", Progress = 100 },
                            new ProjectTask { ActivityName = "Structural Design Task", StartDate = new DateTime(2025, 8, 13), EndDate = new DateTime(2025, 8, 28), Supervisor = "Sarah Patel", Status = "Completed", Progress = 100 },
                            new ProjectTask { ActivityName = "MEP Design Task", StartDate = new DateTime(2025, 8, 29), EndDate = new DateTime(2025, 9, 10), Supervisor = "Carlos Rivera", Status = "Completed", Progress = 100 }
                        }
                    },
                    new ProjectTask 
                    { 
                        ActivityName = "Construction Stage",
                        StartDate = new DateTime(2025, 9, 11),
                        EndDate = new DateTime(2025, 11, 20),
                        Supervisor = "James Patel",
                        Status = "Completed",
                        Progress = 100,
                        Children = new List<ProjectTask>
                        {
                            new ProjectTask { ActivityName = "Foundation Construction Task", StartDate = new DateTime(2025, 9, 11), EndDate = new DateTime(2025, 9, 25), Supervisor = "Robert Singh", Status = "Completed", Progress = 100 },
                            new ProjectTask { ActivityName = "Framing Construction Task", StartDate = new DateTime(2025, 9, 26), EndDate = new DateTime(2025, 10, 25), Supervisor = "Angela Moore", Status = "Completed", Progress = 100 },
                            new ProjectTask { ActivityName = "Exterior Construction Task", StartDate = new DateTime(2025, 10, 26), EndDate = new DateTime(2025, 11, 20), Supervisor = "Thomas Reed", Status = "Completed", Progress = 100 }
                        }
                    },
                    new ProjectTask 
                    { 
                        ActivityName = "Safety Stage",
                        StartDate = new DateTime(2025, 11, 21),
                        EndDate = new DateTime(2025, 12, 10),
                        Supervisor = "Nathan Blake",
                        Status = "Completed",
                        Progress = 100,
                        Children = new List<ProjectTask>
                        {
                            new ProjectTask { ActivityName = "OSHA Compliance Task", StartDate = new DateTime(2025, 11, 21), EndDate = new DateTime(2025, 11, 28), Supervisor = "Laura Bennett", Status = "Completed", Progress = 100 },
                            new ProjectTask { ActivityName = "Fire Safety Task", StartDate = new DateTime(2025, 11, 29), EndDate = new DateTime(2025, 12, 5), Supervisor = "Melissa Tran", Status = "Completed", Progress = 100 },
                            new ProjectTask { ActivityName = "Structural Audit Task", StartDate = new DateTime(2025, 12, 6), EndDate = new DateTime(2025, 12, 10), Supervisor = "David Lin", Status = "Completed", Progress = 100 }
                        }
                    }
                }
            }
        };
    }
}

{% endhighlight %}
{% endtabs %}

## Clearing spanning via programmatically

The Syncfusion Blazor TreeGrid provides API support to manually remove merged regions when restoration of individual cells is required. This functionality is achieved using the `UnmergeCellsAsync` methods, which allow specific merged areas to be unmerged programmatically. For scenarios where all merged regions in the current view need to be reset, the `UnmergeAllAsync` method can be used to restore every cell to its original state.

| Method | Parameter | Type | Description |
|--------|-----------|------|-------------|
| `UnmergeCellsAsync` | info | `UnmergeCellInfo` | Removes a single merged area identified by its anchor cell (top‑left of the merged region). |
| `UnmergeCellsAsync` | infos | `IEnumerable<UnmergeCellInfo>` | Removes multiple merged areas in one combined operation, improving performance by reducing re‑renders. |
| `UnmergeAllAsync` | – | – | Removes all merged regions in the current view, restoring every cell to its original state. |

To identify a merged region, use the following properties of the UnmergeCellInfo class:

| Property     | Type | Description                                                                 |
|--------------|------|-----------------------------------------------------------------------------|
| RowIndex     | int  | The zero-based index of the anchor row (top-left cell of the merged region). |
| ColumnIndex  | int  | The zero-based index of the anchor column (top-left cell of the merged region). |

This sample demonstrates clearing merged regions in the TreeGrid by calling `UnmergeCellsAsync` with `RowIndex` and `ColumnIndex` to remove specific spans, passing multiple `UnmergeCellInfo` objects for batch unmerging, and using `UnmergeAllAsync` to reset all merged cells at once.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="MergeCellsAsync">Merge Cell</SfButton>
<SfButton OnClick="UnMergeCell">UnMerge Cell</SfButton>

<SfButton OnClick="MergeMultipleCellsAsync">Merge Multiple Cells</SfButton>
<SfButton OnClick="UnMergeCells">UnMerge Multiple Cells</SfButton>

<SfButton OnClick="UnMergeAllCells">UnMerge All Cells</SfButton>

<SfTreeGrid TValue="ProjectTask" @ref="Grid" DataSource="@Tasks" ChildMapping="Children" TreeColumnIndex="0" AllowPaging="true" GridLines="GridLine.Both">
    <TreeGridColumns>
        <TreeGridColumn Field="@nameof(ProjectTask.ActivityName)" HeaderText="Activity Name" Width="180" />
        <TreeGridColumn Field="@nameof(ProjectTask.StartDate)" HeaderText="Start Date" Format="d" Type="ColumnType.Date" Width="130" />
        <TreeGridColumn Field="@nameof(ProjectTask.EndDate)" HeaderText="End Date" Format="d" Type="ColumnType.Date" Width="130" />
        <TreeGridColumn Field="@nameof(ProjectTask.Supervisor)" HeaderText="Supervisor" Width="150" />
        <TreeGridColumn Field="@nameof(ProjectTask.Progress)" HeaderText="Progress" Width="100" />
        <TreeGridColumn Field="@nameof(ProjectTask.Status)" HeaderText="Status" Width="120" />
    </TreeGridColumns>
</SfTreeGrid>

@code 
{
    private SfTreeGrid<ProjectTask> Grid;
    public List<ProjectTask> Tasks { get; set; }

    public async Task MergeCellsAsync()
    {
        await Grid.MergeCellsAsync(new MergeCellInfo
        {
            RowIndex = 1,
            ColumnIndex = 1,
            ColumnSpan = 2,
        });
    }

    public async Task UnMergeCell()
    {
        await Grid.UnmergeCellsAsync(new UnmergeCellInfo
        {
            RowIndex = 1,
            ColumnIndex = 1,
        });
    }

    public async Task MergeMultipleCellsAsync()
    {
        await Grid.MergeCellsAsync(new[]
        {
            new MergeCellInfo { RowIndex = 0, ColumnIndex = 0, ColumnSpan = 2 },
            new MergeCellInfo { RowIndex = 5, ColumnIndex = 0, ColumnSpan = 3 },
            new MergeCellInfo { RowIndex = 7, ColumnIndex = 0, ColumnSpan = 2 }
        });
    }

    public async Task UnMergeCells()
    {
        await Grid.UnmergeCellsAsync(new[]
        {
            new UnmergeCellInfo { RowIndex = 0, ColumnIndex = 0 },
            new UnmergeCellInfo { RowIndex = 5, ColumnIndex = 0 },
            new UnmergeCellInfo { RowIndex = 7, ColumnIndex = 0 }
        });
    }

    public async Task UnMergeAllCells()
    {
        await Grid.UnmergeAllAsync();
    }

    protected override void OnInitialized()
    {
        Tasks = ProjectTask.GetRowSpanData();
    }
}
{% endhighlight %}
{% highlight c# tabtitle="Order.cs" %}

public class ProjectTask
{
    public string ActivityName { get; set; } = string.Empty;
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Supervisor { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public int Progress { get; set; }
    public List<ProjectTask> Children { get; set; } = new();

    public static List<ProjectTask> GetRowSpanData()
    {
        return new List<ProjectTask>
        {
            new ProjectTask 
            { 
                ActivityName = "Tower",
                StartDate = new DateTime(2025, 7, 1),
                EndDate = new DateTime(2025, 12, 29),
                Supervisor = "John Carter",
                Status = "In Progress",
                Progress = 87,
                Children = new List<ProjectTask>
                {
                    new ProjectTask 
                    { 
                        ActivityName = "Design Stage",
                        StartDate = new DateTime(2025, 7, 1),
                        EndDate = new DateTime(2025, 8, 15),
                        Supervisor = "Ethan Park",
                        Status = "Completed",
                        Progress = 100,
                        Children = new List<ProjectTask>
                        {
                            new ProjectTask { ActivityName = "Architectural Design Task", StartDate = new DateTime(2025, 7, 2), EndDate = new DateTime(2025, 7, 10), Supervisor = "David Lin", Status = "Completed", Progress = 100 },
                            new ProjectTask { ActivityName = "Structural Design Task", StartDate = new DateTime(2025, 7, 11), EndDate = new DateTime(2025, 7, 25), Supervisor = "Sarah Patel", Status = "Completed", Progress = 100 },
                            new ProjectTask { ActivityName = "MEP Design Task", StartDate = new DateTime(2025, 7, 26), EndDate = new DateTime(2025, 8, 15), Supervisor = "Carlos Rivera", Status = "Completed", Progress = 100 }
                        }
                    },
                    new ProjectTask 
                    { 
                        ActivityName = "Construction Stage",
                        StartDate = new DateTime(2025, 8, 16),
                        EndDate = new DateTime(2025, 10, 20),
                        Supervisor = "James Patel",
                        Status = "Completed",
                        Progress = 100,
                        Children = new List<ProjectTask>
                        {
                            new ProjectTask { ActivityName = "Foundation Construction Task", StartDate = new DateTime(2025, 8, 16), EndDate = new DateTime(2025, 8, 25), Supervisor = "Robert Singh", Status = "Completed", Progress = 100 },
                            new ProjectTask { ActivityName = "Structural Construction Task", StartDate = new DateTime(2025, 8, 26), EndDate = new DateTime(2025, 9, 20), Supervisor = "Nathan Blake", Status = "Completed", Progress = 100 },
                            new ProjectTask { ActivityName = "Exterior Construction Task", StartDate = new DateTime(2025, 9, 21), EndDate = new DateTime(2025, 10, 20), Supervisor = "Thomas Reed", Status = "Completed", Progress = 100 }
                        }
                    },
                    new ProjectTask 
                    { 
                        ActivityName = "Safety Stage",
                        StartDate = new DateTime(2025, 10, 21),
                        EndDate = new DateTime(2025, 11, 5),
                        Supervisor = "Nathan Blake",
                        Status = "Completed",
                        Progress = 100,
                        Children = new List<ProjectTask>
                        {
                            new ProjectTask { ActivityName = "OSHA Compliance Task", StartDate = new DateTime(2025, 10, 21), EndDate = new DateTime(2025, 10, 27), Supervisor = "Laura Bennett", Status = "Completed", Progress = 100 },
                            new ProjectTask { ActivityName = "Fire Safety Task", StartDate = new DateTime(2025, 10, 28), EndDate = new DateTime(2025, 11, 1), Supervisor = "Melissa Tran", Status = "Completed", Progress = 100 },
                            new ProjectTask { ActivityName = "Structural Audit Task", StartDate = new DateTime(2025, 11, 2), EndDate = new DateTime(2025, 11, 5), Supervisor = "David Lin", Status = "Completed", Progress = 100 }
                        }
                    },
                    new ProjectTask 
                    { 
                        ActivityName = "Finishing Stage",
                        StartDate = new DateTime(2025, 11, 6),
                        EndDate = new DateTime(2025, 12, 10),
                        Supervisor = "Melissa Tran",
                        Status = "Completed",
                        Progress = 100,
                        Children = new List<ProjectTask>
                        {
                            new ProjectTask { ActivityName = "Interior Drywall Task", StartDate = new DateTime(2025, 11, 6), EndDate = new DateTime(2025, 11, 20), Supervisor = "Hannah Kim", Status = "Completed", Progress = 100 },
                            new ProjectTask { ActivityName = "Flooring Installation Task", StartDate = new DateTime(2025, 11, 21), EndDate = new DateTime(2025, 12, 1), Supervisor = "Sarah Patel", Status = "Completed", Progress = 100 },
                            new ProjectTask { ActivityName = "Fixture Setup Task", StartDate = new DateTime(2025, 12, 2), EndDate = new DateTime(2025, 12, 10), Supervisor = "Lucas Nguyen", Status = "Completed", Progress = 100 }
                        }
                    },
                    new ProjectTask 
                    { 
                        ActivityName = "Closeout Stage",
                        StartDate = new DateTime(2025, 12, 11),
                        EndDate = new DateTime(2025, 12, 29),
                        Supervisor = "Emma Wilson",
                        Status = "In Progress",
                        Progress = 33,
                        Children = new List<ProjectTask>
                        {
                            new ProjectTask { ActivityName = "Punch List Review Task", StartDate = new DateTime(2025, 12, 11), EndDate = new DateTime(2025, 12, 15), Supervisor = "John Carter", Status = "Completed", Progress = 100 },
                            new ProjectTask { ActivityName = "Final Documentation Task", StartDate = new DateTime(2025, 12, 16), EndDate = new DateTime(2025, 12, 22), Supervisor = "Emily Foster", Status = "In Progress", Progress = 0 },
                            new ProjectTask { ActivityName = "Client Handover Task", StartDate = new DateTime(2025, 12, 23), EndDate = new DateTime(2025, 12, 29), Supervisor = "Emma Wilson", Status = "Scheduled", Progress = 0 }
                        }
                    }
                }
            },
            new ProjectTask 
            { 
                ActivityName = "Warehouse",
                StartDate = new DateTime(2025, 8, 1),
                EndDate = new DateTime(2025, 12, 28),
                Supervisor = "Emma Wilson",
                Status = "Completed",
                Progress = 100,
                Children = new List<ProjectTask>
                {
                    new ProjectTask 
                    { 
                        ActivityName = "Design Stage",
                        StartDate = new DateTime(2025, 8, 1),
                        EndDate = new DateTime(2025, 9, 10),
                        Supervisor = "Ethan Park",
                        Status = "Completed",
                        Progress = 100,
                        Children = new List<ProjectTask>
                        {
                            new ProjectTask { ActivityName = "Architectural Design Task", StartDate = new DateTime(2025, 8, 2), EndDate = new DateTime(2025, 8, 12), Supervisor = "David Lin", Status = "Completed", Progress = 100 },
                            new ProjectTask { ActivityName = "Structural Design Task", StartDate = new DateTime(2025, 8, 13), EndDate = new DateTime(2025, 8, 28), Supervisor = "Sarah Patel", Status = "Completed", Progress = 100 },
                            new ProjectTask { ActivityName = "MEP Design Task", StartDate = new DateTime(2025, 8, 29), EndDate = new DateTime(2025, 9, 10), Supervisor = "Carlos Rivera", Status = "Completed", Progress = 100 }
                        }
                    },
                    new ProjectTask 
                    { 
                        ActivityName = "Construction Stage",
                        StartDate = new DateTime(2025, 9, 11),
                        EndDate = new DateTime(2025, 11, 20),
                        Supervisor = "James Patel",
                        Status = "Completed",
                        Progress = 100,
                        Children = new List<ProjectTask>
                        {
                            new ProjectTask { ActivityName = "Foundation Construction Task", StartDate = new DateTime(2025, 9, 11), EndDate = new DateTime(2025, 9, 25), Supervisor = "Robert Singh", Status = "Completed", Progress = 100 },
                            new ProjectTask { ActivityName = "Framing Construction Task", StartDate = new DateTime(2025, 9, 26), EndDate = new DateTime(2025, 10, 25), Supervisor = "Angela Moore", Status = "Completed", Progress = 100 },
                            new ProjectTask { ActivityName = "Exterior Construction Task", StartDate = new DateTime(2025, 10, 26), EndDate = new DateTime(2025, 11, 20), Supervisor = "Thomas Reed", Status = "Completed", Progress = 100 }
                        }
                    },
                    new ProjectTask 
                    { 
                        ActivityName = "Safety Stage",
                        StartDate = new DateTime(2025, 11, 21),
                        EndDate = new DateTime(2025, 12, 10),
                        Supervisor = "Nathan Blake",
                        Status = "Completed",
                        Progress = 100,
                        Children = new List<ProjectTask>
                        {
                            new ProjectTask { ActivityName = "OSHA Compliance Task", StartDate = new DateTime(2025, 11, 21), EndDate = new DateTime(2025, 11, 28), Supervisor = "Laura Bennett", Status = "Completed", Progress = 100 },
                            new ProjectTask { ActivityName = "Fire Safety Task", StartDate = new DateTime(2025, 11, 29), EndDate = new DateTime(2025, 12, 5), Supervisor = "Melissa Tran", Status = "Completed", Progress = 100 },
                            new ProjectTask { ActivityName = "Structural Audit Task", StartDate = new DateTime(2025, 12, 6), EndDate = new DateTime(2025, 12, 10), Supervisor = "David Lin", Status = "Completed", Progress = 100 }
                        }
                    }
                }
            }
        };
    }
}

{% endhighlight %}
{% endtabs %}

## Limitations

The following list outlines the features that are not compatible with row spanning.

* Virtualization
* Infinite Scrolling
* Row Drag and Drop
* Column Virtualization
* Detail Template
* Editing
* Export

## See also

* [Column spanning in Syncfusion<sup style="font-size:70%">&reg;</sup> TreeGrid](https://blazor.syncfusion.com/documentation/treegrid/columns/column-spanning)


