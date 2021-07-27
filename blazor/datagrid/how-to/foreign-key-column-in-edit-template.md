---
layout: post
title: How to Foreign Key Column In Edit Template in Blazor DataGrid Component | Syncfusion
description: Checkout and learn about Foreign Key Column In Edit Template in Blazor DataGrid component of Syncfusion, and more details.
platform: Blazor
control: DataGrid
documentation: ug
---

<!-- Access foreign key column in edit template

You can define the **ForeignKeyColumn** in the grid and access it's value in the edit template property.
This can be achieved by initially defining [`ForeignKeyValue`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ForeignKeyValue) for the required column which compares the local-foreign data and returns the column name. This is then accessed in the grid's edit template using the common column field present in both the data.

This is demonstrated in the below sample code,

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Calendars
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Inputs

<SfGrid DataSource="@Employees" AllowPaging="true">
    <GridPageSettings PageSize="6"></GridPageSettings>
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="@EditMode.Dialog">
        <Template>
            @{
                var employee = (context as Employee);
                <div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <label class="e-float-text e-label-top">ID</label>
                            <SfTextBox ID="ID" Value="@(employee.ID.ToString())" Enabled="false"></SfTextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <label class="e-float-text e-label-top">Name</label>
                            <SfDropDownList ID="FirstName" Value="@(employee.EmployeeID)" TValue="string" DataSource="@EmployeeDetails">
                                    <DropDownListFieldSettings Value="EmployeeID" Text="Name"></DropDownListFieldSettings>
                            </SfDropDownList>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <label class="e-float-text e-label-top">Title</label>
                            <SfTextBox ID="Title" Value="@(employee.Title)"></SfTextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <label class="e-float-text e-label-top">Join Date</label>
                            <SfDatePicker ID="JoinDate" Value="@(employee.JoinDate)"></SfDatePicker>
                        </div>
                    </div>
                </div>
            }
        </Template>
    </GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Employee.ID) HeaderText="ID" IsPrimaryKey="true" TextAlign="TextAlign.Left" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Employee.EmployeeID) HeaderText="Employee Name" ForeignKeyValue="Name" DataSource="@EmployeeDetails" TextAlign="TextAlign.Left" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Employee.Title) HeaderText="Title" TextAlign="TextAlign.Left" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Employee.JoinDate) HeaderText="Join Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Left" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{

    List<Employee> Employees = new List<Employee>
    {
        new Employee() { ID = 101, EmployeeID = "1", Title = "CEO", JoinDate = DateTime.Now.AddDays(-15) },
        new Employee() { ID = 102, EmployeeID = "2", Title = "Manager", JoinDate = DateTime.Now.AddDays(-10) },
        new Employee() { ID = 103, EmployeeID = "3", Title = "Team Lead", JoinDate = DateTime.Now.AddDays(-15) },
        new Employee() { ID = 104, EmployeeID = "4", Title = "Team Lead", JoinDate = DateTime.Now.AddDays(-10) },
        new Employee() { ID = 105, EmployeeID = "5", Title = "Developer", JoinDate = DateTime.Now.AddDays(-18) },
        new Employee() { ID = 106, EmployeeID = "6", Title = "Developer", JoinDate = DateTime.Now.AddDays(-23) },
        new Employee() { ID = 107, EmployeeID = "7", Title = "Developer", JoinDate = DateTime.Now.AddDays(-15) },
        new Employee() { ID = 108, EmployeeID = "8", Title = "Developer", JoinDate = DateTime.Now.AddDays(-18) },
        new Employee() { ID = 109, EmployeeID = "9", Title = "HR Manager", JoinDate = DateTime.Now.AddDays(-23) },
        new Employee() { ID = 110, EmployeeID = "10", Title = "HR", JoinDate = DateTime.Now.AddDays(-10) },
    };

    List<EmployeeData> EmployeeDetails = new List<EmployeeData>
    {
        new EmployeeData() { EmployeeID = "1", Name = "Steven Buchanan" },
        new EmployeeData() { EmployeeID = "2", Name = "Laura Callahan" },
        new EmployeeData() { EmployeeID = "3", Name = "Andrew Fuller" },
        new EmployeeData() { EmployeeID = "4", Name = "Michael Suyama" },
        new EmployeeData() { EmployeeID = "5", Name = "Anne Dodsworth" },
        new EmployeeData() { EmployeeID = "6", Name = "Nancy Davolio" },
        new EmployeeData() { EmployeeID = "7", Name = "Margaret Peacock" },
        new EmployeeData() { EmployeeID = "8", Name = "Robert King" },
        new EmployeeData() { EmployeeID = "9", Name = "Janet Leverling" },
        new EmployeeData() { EmployeeID = "10", Name = "James Sterling" }
    };

    public class Employee
    {
        public int ID { get; set; }
        public string EmployeeID { get; set; }
        public DateTime? JoinDate { get; set; }
        public string? Title { get; set; }
    }

    public class EmployeeData
    {
        public string EmployeeID { get; set; }
        public string Name { get; set; }
    }
}

<style>
    .form-group.col-md-6 {
        width: 200px;
    }

    label.e-float-text {
        position: relative;
        padding-left: 0;
        top: 10%;
    }

    .e-dlg-container {
        margin-left: 12%;
    }
</style>
```

The following GIF represents the dialog edit template with foreign key column value,

![Foreign key column in edit template](../images/foreign-key-column-edit-template.gif) -->