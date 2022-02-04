---
layout: post
title: Drag and Drop in Blazor Kanban Component | Syncfusion
description: This section explains about drag and drop in Syncfusion Blazor Kanban component.
platform: Blazor
control: Kanban
documentation: ug
---

# Drag and drop in Blazor Kanban Component

All cards can be dragged and dropped across the columns or within the columns or swimlane row or Kanban to an external source and vice versa.

The following drag and drop types are available in the Kanban board.

* Internal drag and drop
* External drag and drop

## Internal drag and drop

Allows the user to drag and drop the cards within the Kanban board. Based on this, we can categorize into two ways.

* Column drag and drop
* Swimlane drag and drop

### Column drag and drop

Transit or change the card position using the drag-and-drop functionality. By default, the `AllowDragAndDrop` property is enabled on the Kanban board, which is used to change the card position by column-to-column or within the column.

Added dotted border on Kanban cells except the dragged clone cells when dragging, which indicates the possible ways for dropping the cards into the cells.

In the following example, disabled the drag and drop behavior on the Kanban board.

```cshtml

@using Syncfusion.Blazor.Kanban

<SfKanban TValue="TasksModel" KeyField="Status" DataSource="Tasks" AllowDragAndDrop="false">
    <KanbanColumns>
        <KanbanColumn HeaderText="Backlog" KeyField="@(new List<string>() {"Open"})"></KanbanColumn>
        <KanbanColumn HeaderText="In Progress" KeyField="@(new List<string>() {"InProgress"})"></KanbanColumn>
        <KanbanColumn HeaderText="Testing" KeyField="@(new List<string>() {"Testing"})"></KanbanColumn>
        <KanbanColumn HeaderText="Done" KeyField="@(new List<string>() {"Close"})"></KanbanColumn>
    </KanbanColumns>
    <KanbanCardSettings HeaderField="Id" ContentField="Summary"></KanbanCardSettings>
</SfKanban>

@code {
    public class TasksModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Summary { get; set; }
        public string Assignee { get; set; }
    }

    public List<TasksModel> Tasks = new List<TasksModel>()
    {
        new TasksModel { Id = "Task 1", Title = "BLAZ-29001", Status = "Open", Summary = "Analyze the new requirements gathered from the customer.", Assignee = "Nancy Davloio" },
        new TasksModel { Id = "Task 2", Title = "BLAZ-29002", Status = "InProgress", Summary = "Improve application performance", Assignee = "Andrew Fuller" },
        new TasksModel { Id = "Task 3", Title = "BLAZ-29003", Status = "Open", Summary = "Arrange a web meeting with the customer to get new requirements.", Assignee = "Janet Leverling" },
        new TasksModel { Id = "Task 4", Title = "BLAZ-29004", Status = "InProgress", Summary = "Fix the issues reported in the IE browser.", Assignee = "Janet Leverling" },
        new TasksModel { Id = "Task 5", Title = "BLAZ-29005", Status = "Review", Summary = "Fix the issues reported by the customer.", Assignee = "Steven walker" },
        new TasksModel { Id = "Task 6", Title = "BLAZ-29006", Status = "Review", Summary = "Fix the issues reported in Safari browser.", Assignee = "Nancy Davloio" },
        new TasksModel { Id = "Task 7", Title = "BLAZ-29007", Status = "Close", Summary = "Test the application in the IE browser.", Assignee = "Margaret hamilt" },
        new TasksModel { Id = "Task 8", Title = "BLAZ-29008", Status = "Validate", Summary = "Validate the issues reported by the customer.", Assignee = "Steven walker" },
        new TasksModel { Id = "Task 9", Title = "BLAZ-29009", Status = "Open", Summary = "Show the retrieved data from the server in grid control.", Assignee = "Margaret hamilt" },
        new TasksModel { Id = "Task 10", Title = "BLAZ-29010", Status = "InProgress", Summary = "Fix cannot open user’s default database SQL error.", Assignee = "Janet Leverling" },
        new TasksModel { Id = "Task 11", Title = "BLAZ-29011", Status = "Review", Summary = "Fix the issues reported in data binding.", Assignee = "Janet Leverling" },
        new TasksModel { Id = "Task 12", Title = "BLAZ-29012", Status = "Close", Summary = "Analyze SQL server 2008 connection.", Assignee = "Andrew Fuller" },
        new TasksModel { Id = "Task 13", Title = "BLAZ-29013", Status = "Validate", Summary = "Validate databinding issues.", Assignee = "Margaret hamilt" },
        new TasksModel { Id = "Task 14", Title = "BLAZ-29014", Status = "Close", Summary = "Analyze grid control.", Assignee = "Margaret hamilt" },
        new TasksModel { Id = "Task 15", Title = "BLAZ-29015", Status = "Close", Summary = "Stored procedure for initial data binding of the grid.", Assignee = "Steven walker" },
        new TasksModel { Id = "Task 16", Title = "BLAZ-29016", Status = "Close", Summary = "Analyze stored procedures.", Assignee = "Janet Leverling" },
        new TasksModel { Id = "Task 17", Title = "BLAZ-29017", Status = "Validate", Summary = "Validate editing issues.", Assignee = "Nancy Davloio" },
        new TasksModel { Id = "Task 18", Title = "BLAZ-29018", Status = "Review", Summary = "Test editing functionality.", Assignee = "Nancy Davloio" },
        new TasksModel { Id = "Task 19", Title = "BLAZ-29019", Status = "Open", Summary = "Enhance editing functionality.", Assignee = "Andrew Fuller" },
        new TasksModel { Id = "Task 20", Title = "BLAZ-29020", Status = "InProgress", Summary = "Improve the performance of the editing functionality.", Assignee = "Nancy Davloio" },
        new TasksModel { Id = "Task 21", Title = "BLAZ-29021", Status = "Open", Summary = "Arrange web meeting with the customer to show editing demo.", Assignee = "Steven walker" },
        new TasksModel { Id = "Task 22", Title = "BLAZ-29022", Status = "Review", Summary = "Fix the editing issues reported by the customer.", Assignee = "Janet Leverling" },
        new TasksModel { Id = "Task 23", Title = "BLAZ-29023", Status = "Testing", Summary = "Fix the issues reported by the customer.", Assignee = "Steven walker" },
        new TasksModel { Id = "Task 24", Title = "BLAZ-29024", Status = "Testing", Summary = "Fix the issues reported in Safari browser.", Assignee = "Nancy Davloio" },
        new TasksModel { Id = "Task 25", Title = "BLAZ-29025", Status = "Testing", Summary = "Fix the issues reported in data binding.", Assignee = "Janet Leverling" },
        new TasksModel { Id = "Task 26", Title = "BLAZ-29026", Status = "Testing", Summary = "Test editing functionality.", Assignee = "Nancy Davloio" },
        new TasksModel { Id = "Task 27", Title = "BLAZ-29027", Status = "Testing", Summary = "Test editing feature in the IE browser.", Assignee = "Janet Leverling" }
    };
}

```

### Swimlane drag and drop

By default, The Kanban does not allow dragging the cards across the swimlane rows. Enabling the `AllowDragAndDrop` property allows you to drag the cards across the swimlane rows, which is specified inside `KanbanSwimlaneSettings` property.

```cshtml

@using Syncfusion.Blazor.Kanban

<SfKanban TValue="TasksModel" KeyField="Status" DataSource="Tasks">
    <KanbanColumns>
        <KanbanColumn HeaderText="Backlog" KeyField="@(new List<string>() {"Open"})"></KanbanColumn>
        <KanbanColumn HeaderText="In Progress" KeyField="@(new List<string>() {"InProgress"})"></KanbanColumn>
        <KanbanColumn HeaderText="Testing" KeyField="@(new List<string>() {"Testing"})"></KanbanColumn>
        <KanbanColumn HeaderText="Done" KeyField="@(new List<string>() {"Close"})"></KanbanColumn>
    </KanbanColumns>
    <KanbanCardSettings HeaderField="Id" ContentField="Summary"></KanbanCardSettings>
    <KanbanSwimlaneSettings KeyField="Assignee" AllowDragAndDrop="true"></KanbanSwimlaneSettings>
</SfKanban>

@code {
    public class TasksModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Summary { get; set; }
        public string Assignee { get; set; }
    }

    public List<TasksModel> Tasks = new List<TasksModel>()
    {
        new TasksModel { Id = "Task 1", Title = "BLAZ-29001", Status = "Open", Summary = "Analyze the new requirements gathered from the customer.", Assignee = "Nancy Davloio" },
        new TasksModel { Id = "Task 2", Title = "BLAZ-29002", Status = "InProgress", Summary = "Improve application performance", Assignee = "Andrew Fuller" },
        new TasksModel { Id = "Task 3", Title = "BLAZ-29003", Status = "Open", Summary = "Arrange a web meeting with the customer to get new requirements.", Assignee = "Janet Leverling" },
        new TasksModel { Id = "Task 4", Title = "BLAZ-29004", Status = "InProgress", Summary = "Fix the issues reported in the IE browser.", Assignee = "Janet Leverling" },
        new TasksModel { Id = "Task 5", Title = "BLAZ-29005", Status = "Review", Summary = "Fix the issues reported by the customer.", Assignee = "Steven walker" },
        new TasksModel { Id = "Task 6", Title = "BLAZ-29006", Status = "Review", Summary = "Fix the issues reported in Safari browser.", Assignee = "Nancy Davloio" },
        new TasksModel { Id = "Task 7", Title = "BLAZ-29007", Status = "Close", Summary = "Test the application in the IE browser.", Assignee = "Margaret hamilt" },
        new TasksModel { Id = "Task 8", Title = "BLAZ-29008", Status = "Validate", Summary = "Validate the issues reported by the customer.", Assignee = "Steven walker" },
        new TasksModel { Id = "Task 9", Title = "BLAZ-29009", Status = "Open", Summary = "Show the retrieved data from the server in grid control.", Assignee = "Margaret hamilt" },
        new TasksModel { Id = "Task 10", Title = "BLAZ-29010", Status = "InProgress", Summary = "Fix cannot open user’s default database SQL error.", Assignee = "Janet Leverling" },
        new TasksModel { Id = "Task 11", Title = "BLAZ-29011", Status = "Review", Summary = "Fix the issues reported in data binding.", Assignee = "Janet Leverling" },
        new TasksModel { Id = "Task 12", Title = "BLAZ-29012", Status = "Close", Summary = "Analyze SQL server 2008 connection.", Assignee = "Andrew Fuller" },
        new TasksModel { Id = "Task 13", Title = "BLAZ-29013", Status = "Validate", Summary = "Validate databinding issues.", Assignee = "Margaret hamilt" },
        new TasksModel { Id = "Task 14", Title = "BLAZ-29014", Status = "Close", Summary = "Analyze grid control.", Assignee = "Margaret hamilt" },
        new TasksModel { Id = "Task 15", Title = "BLAZ-29015", Status = "Close", Summary = "Stored procedure for initial data binding of the grid.", Assignee = "Steven walker" },
        new TasksModel { Id = "Task 16", Title = "BLAZ-29016", Status = "Close", Summary = "Analyze stored procedures.", Assignee = "Janet Leverling" },
        new TasksModel { Id = "Task 17", Title = "BLAZ-29017", Status = "Validate", Summary = "Validate editing issues.", Assignee = "Nancy Davloio" },
        new TasksModel { Id = "Task 18", Title = "BLAZ-29018", Status = "Review", Summary = "Test editing functionality.", Assignee = "Nancy Davloio" },
        new TasksModel { Id = "Task 19", Title = "BLAZ-29019", Status = "Open", Summary = "Enhance editing functionality.", Assignee = "Andrew Fuller" },
        new TasksModel { Id = "Task 20", Title = "BLAZ-29020", Status = "InProgress", Summary = "Improve the performance of the editing functionality.", Assignee = "Nancy Davloio" },
        new TasksModel { Id = "Task 21", Title = "BLAZ-29021", Status = "Open", Summary = "Arrange web meeting with the customer to show editing demo.", Assignee = "Steven walker" },
        new TasksModel { Id = "Task 22", Title = "BLAZ-29022", Status = "Review", Summary = "Fix the editing issues reported by the customer.", Assignee = "Janet Leverling" },
        new TasksModel { Id = "Task 23", Title = "BLAZ-29023", Status = "Testing", Summary = "Fix the issues reported by the customer.", Assignee = "Steven walker" },
        new TasksModel { Id = "Task 24", Title = "BLAZ-29024", Status = "Testing", Summary = "Fix the issues reported in Safari browser.", Assignee = "Nancy Davloio" },
        new TasksModel { Id = "Task 25", Title = "BLAZ-29025", Status = "Testing", Summary = "Fix the issues reported in data binding.", Assignee = "Janet Leverling" },
        new TasksModel { Id = "Task 26", Title = "BLAZ-29026", Status = "Testing", Summary = "Test editing functionality.", Assignee = "Nancy Davloio" },
        new TasksModel { Id = "Task 27", Title = "BLAZ-29027", Status = "Testing", Summary = "Test editing feature in the IE browser.", Assignee = "Janet Leverling" }
    };
}

```

## External drag and drop

Allows the user to drag and drop the cards from one Kanban to another Kanban or Kanban to an external source and vice versa.

### Kanban to Kanban

Drag and drop the card from one Kanban to another Kanban and vice versa. This can be achieved by specifying the `ExternalDropId` property which is used to specify the id of the dropped Kanban element and the `DragStop` event which is used to delete the card on dragged Kanban and add the card on dropped Kanban using the `DeleteCard` and `AddCard` public methods.

In the following example, Drag the card from one Kanban and drop it into another Kanban using the `DragStop` event. 

{% highlight razor %}

@using Syncfusion.Blazor.Kanban

<div class="component-container">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-6">
                <SfKanban ID="TaskKanban" @ref="KanbanTaskRef" TValue="TasksModel" KeyField="Status" DataSource="Tasks" ExternalDropId="@TaskDropTarget">
                    <KanbanColumns>
                        <KanbanColumn HeaderText="Backlog" KeyField="@(new List<string>() {"Open"})"></KanbanColumn>
                        <KanbanColumn HeaderText="In Progress" KeyField="@(new List<string>() {"InProgress"})"></KanbanColumn>
                        <KanbanColumn HeaderText="Done" KeyField="@(new List<string>() {"Close"})"></KanbanColumn>
                    </KanbanColumns>
                    <KanbanCardSettings HeaderField="Id" ContentField="Summary"></KanbanCardSettings>
                    <KanbanEvents TValue="TasksModel" DragStop="TaskDragStop"></KanbanEvents>
                    <KanbanSortSettings SortBy="SortOrderBy.Index" Field="RankId"></KanbanSortSettings>
                </SfKanban>
            </div>
            <div class="col-md-6">
                <SfKanban ID="PizzaKanban" @ref="KanbanPizzaRef" TValue="PizzaModel" KeyField="Category" DataSource="PizzaData" ExternalDropId="@PizzaDropTarget">
                    <KanbanColumns>
                        <KanbanColumn HeaderText="Menu" KeyField="@(new List<string>() {"Menu"})"></KanbanColumn>
                        <KanbanColumn HeaderText="Order" KeyField="@(new List<string>() {"Order"})"></KanbanColumn>
                        <KanbanColumn HeaderText="Delivered" KeyField="@(new List<string>() {"Delivered"})"></KanbanColumn>
                    </KanbanColumns>
                    <KanbanCardSettings HeaderField="OrderID" ContentField="Description"></KanbanCardSettings>
                    <KanbanEvents TValue="PizzaModel" DragStop="PizzaDragStop"></KanbanEvents>
                    <KanbanSortSettings SortBy="SortOrderBy.Index" Field="RankId"></KanbanSortSettings>
                </SfKanban>
            </div>
        </div>
    </div>
</div>

@code {
    private SfKanban<TasksModel> KanbanTaskRef;
    private SfKanban<PizzaModel> KanbanPizzaRef;
    public class TasksModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Summary { get; set; }
        public string Assignee { get; set; }
        public int RankId { get; set; }
    }
    public class PizzaModel
    {
        public string OrderID { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Size { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int RankId { get; set; }
    }
    private List<string> TaskDropTarget = new List<string> { "#PizzaKanban" };
    private List<string> PizzaDropTarget = new List<string> { "#TaskKanban" };
    int Id = new Random().Next(251, 1000);
    public List<TasksModel> Tasks = new List<TasksModel>()
{
        new TasksModel { Id = "Task 1", Title = "BLAZ-29001", Status = "Open", Summary = "Analyze the new requirements gathered from the customer.", Assignee = "Nancy Davloio", RankId = 1 },
        new TasksModel { Id = "Task 2", Title = "BLAZ-29002", Status = "InProgress", Summary = "Improve application performance", Assignee = "Andrew Fuller", RankId = 1 },
        new TasksModel { Id = "Task 3", Title = "BLAZ-29003", Status = "Open", Summary = "Arrange a web meeting with the customer to get new requirements.", Assignee = "Janet Leverling", RankId = 2 },
        new TasksModel { Id = "Task 4", Title = "BLAZ-29004", Status = "InProgress", Summary = "Fix the issues reported in the IE browser.", Assignee = "Janet Leverling", RankId = 2 },
        new TasksModel { Id = "Task 5", Title = "BLAZ-29005", Status = "Review", Summary = "Fix the issues reported by the customer.", Assignee = "Steven walker", RankId = 1 },
        new TasksModel { Id = "Task 6", Title = "BLAZ-29006", Status = "Review", Summary = "Fix the issues reported in Safari browser.", Assignee = "Nancy Davloio", RankId = 2 },
        new TasksModel { Id = "Task 7", Title = "BLAZ-29007", Status = "Close", Summary = "Test the application in the IE browser.", Assignee = "Margaret hamilt", RankId = 1 },
        new TasksModel { Id = "Task 8", Title = "BLAZ-29008", Status = "Validate", Summary = "Validate the issues reported by the customer.", Assignee = "Steven walker", RankId = 1 },
        new TasksModel { Id = "Task 9", Title = "BLAZ-29009", Status = "Open", Summary = "Show the retrieved data from the server in grid control.", Assignee = "Margaret hamilt", RankId = 3 },
        new TasksModel { Id = "Task 10", Title = "BLAZ-29010", Status = "InProgress", Summary = "Fix cannot open user’s default database SQL error.", Assignee = "Janet Leverling", RankId = 3 }
    };

    public List<PizzaModel> PizzaData = new List<PizzaModel>
{
        new PizzaModel { OrderID= "Order ID - #16365", Title= "Mexican Green Wave", Type= "Vegetarian", Size="Small", Category="Order", Description= "Stromboli sandwich with chili sauce.", RankId = 1  },
        new PizzaModel { OrderID = "Order ID - #16366", Title = "Fresh Veggie", Type = "Vegetarian", Size = "Medium", Category = "Order", Description = "Veggie with Onions and Capsicum.", RankId = 2 },
        new PizzaModel { OrderID = "Order ID - #16367", Title = "Peppy Paneer", Type = "Vegetarian", Size = "Large", Category = "Ready to Serve", Description = "It's made using toppings of tomato, mozzarella cheese and fresh basil.", RankId = 1 },
        new PizzaModel { OrderID = "Order ID - #16368", Title = "Margherita", Type = "Vegetarian", Size = "Small", Category = "Menu", Description = "Lebanese Pizza topped with tomato sauce.", RankId = 1 },
        new PizzaModel { OrderID = "Order ID - #16369", Title = "Indian Tandoori Paneer", Type = "Vegetarian", Size = "Medium", Category = "Delivered", Description = "Tandoori Paneer with capsicum, red paprika and mint.", RankId = 1 },
        new PizzaModel { OrderID = "Order ID - #16370", Title = "Pepper Barbecue Chicken", Type = "Non-Vegetarian", Size = "Medium", Category = "Ready to Serve", Description = "Pepper Barbecue Chicken with cheese.", RankId = 1 },
        new PizzaModel { OrderID = "Order ID - #16371", Title = "Chicken Sausage", Type = "Non-Vegetarian", Size = "Large", Category = "Ready to Serve", Description = "Chicken Sausage with cheese.", RankId = 2 },
        new PizzaModel { OrderID = "Order ID - #16372", Title = "Chicken Golden Delight", Type = "Non-Vegetarian", Size = "Large", Category = "Order", Description = "Barbeque chicken with a topping of golden corn loaded with extra cheese.", RankId = 3 },
        new PizzaModel { OrderID = "Order ID - #16373", Title = "Pepper Barbecue and Onion", Type = "Non-Vegetarian", Size = "Medium", Category = "Menu", Description = "Pepper Barbecue chicken with Onion.", RankId = 2 },
        new PizzaModel { OrderID = "Order ID - #16374", Title = "Chicken Fiesta", Type = "Non-Vegetarian", Size = "Small", Category = "Delivered", Description = "Grilled Chicken Rashers with Peri-Peri chicken, Onion and Capsicum.", RankId = 2 },
    };

    private async void TaskDragStop(DragEventArgs<TasksModel> args)
    {
        if (args.IsExternal)
        {
            args.Cancel = true;
            await KanbanTaskRef.DeleteCardAsync(args.Data);
            KanbanTargetDetails<PizzaModel> KanbanPizzaTargetDetails = await KanbanPizzaRef.GetTargetDetailsAsync((int)args.Left, (int)args.Top);
            List<PizzaModel> pizzaData = new List<PizzaModel>();
            int TaskIndex;
            foreach (TasksModel taskData in args.Data)
            {
                if ((KanbanPizzaTargetDetails != null) && !String.IsNullOrEmpty(KanbanPizzaTargetDetails.PreviousCardId))
                {
                    TaskIndex = KanbanPizzaTargetDetails.PreviousCardData[0].RankId + 1;
                }
                else
                {
                    TaskIndex = 1;
                }
                pizzaData.Add(new PizzaModel { OrderID = "Order ID - #" + Id, Title = "Margherita", Type = "Vegetarian", Size = "Small", Category = taskData.Status, Description = taskData.Summary, RankId = TaskIndex });
                Id++;
            }
            await KanbanPizzaRef.AddCardAsync(pizzaData);
        }
    }

    private async void PizzaDragStop(DragEventArgs<PizzaModel> args)
    {
        if (args.IsExternal)
        {
            args.Cancel = true;
            await KanbanPizzaRef.DeleteCardAsync(args.Data);
            KanbanTargetDetails<TasksModel> KanbanTaskTargetDetails = await KanbanTaskRef.GetTargetDetailsAsync((int)args.Left, (int)args.Top);
            List<TasksModel> taskModelData = new List<TasksModel>();
            int PizzaIndex;
            foreach (PizzaModel pizzaModelData in args.Data)
            {
                if ((KanbanTaskTargetDetails != null) && !String.IsNullOrEmpty(KanbanTaskTargetDetails.PreviousCardId))
                {
                    PizzaIndex = KanbanTaskTargetDetails.PreviousCardData[0].RankId + 1;
                }
                else
                {
                    PizzaIndex = 1;
                }
                taskModelData.Add(new TasksModel { Id = "Task " + Id, Title = "BLAZ-29001", Status = pizzaModelData.Category, Summary = "Analyze the new requirements gathered from the customer.", Assignee = "Nancy Davloio", RankId = PizzaIndex });
                Id++;
            }
            await KanbanTaskRef.AddCardAsync(taskModelData);
        }
    }
}

{% endhighlight %}

### Kanban to Schedule

Drag the card from the Kanban board and drop it to the Schedule component.

In the following sample, we remove the data from the Kanban board using the `DeleteCard` public method at the `ActionBegin` event of Schedule component and add it to the Schedule component at Kanban `dragStop` event when dragging the card and dropping it to the Schedule.

{% tabs %}
{% highlight cshtml tabtitle="Index.razor" hl_lines="4" %}

@using Syncfusion.Blazor.Kanban
@using Blazor.Data;
@using Syncfusion.Blazor.Schedule
<div class="component-container">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-6">
                <SfKanban ID="Kanban1" @ref="KanbanRef" TValue="KanbanDataModel" KeyField="Status" DataSource="cardData" ExternalDropId="@DropTarget1">
                    <KanbanColumns>
                        @foreach (KanbanColumnModel item in ColumnData)
                        {
                            <KanbanColumn HeaderText="@item.HeaderText" KeyField="@item.KeyField"></KanbanColumn>
                        }
                    </KanbanColumns>
                    <KanbanCardSettings HeaderField="Id" ContentField="Summary"></KanbanCardSettings>
                    <KanbanEvents TValue="KanbanDataModel" DragStop="OnCardDragStop1"></KanbanEvents>
                </SfKanban>
            </div>
            <div class="col-md-6">
                <SfSchedule ID="Schedule1" TValue="HospitalData" @ref="ScheduleRef" Width="100%" Height="650px" CssClass="schedule-drag-drop" @bind-SelectedDate="@CurrentDate">
                    <ScheduleEvents TValue="HospitalData" OnActionBegin="OnActionBegin"></ScheduleEvents>
                    <ScheduleGroup EnableCompactView="false" Resources="@Resources"></ScheduleGroup>
                    <ScheduleResources>
                        <ScheduleResource TItem="ResourceData" TValue="int" DataSource="@Departments" Field="DepartmentID" Title="Department" Name="Departments" TextField="Text" IdField="Id" ColorField="Color"></ScheduleResource>
                        <ScheduleResource TItem="ResourceData" TValue="int" DataSource="@Consultants" Field="ConsultantID" Title="Consultant" Name="Consultants" TextField="Text" IdField="Id" ColorField="Color" GroupIDField="GroupId" AllowMultiple="false"></ScheduleResource>
                    </ScheduleResources>
                    <ScheduleViews>
                        <ScheduleView MaxEventsPerRow="1" Option="View.TimelineDay"></ScheduleView>
                        <ScheduleView MaxEventsPerRow="1" Option="View.TimelineMonth"></ScheduleView>
                    </ScheduleViews>
                    <ScheduleWorkHours Highlight="true" Start="08:00" End="18:00"></ScheduleWorkHours>
                    <ScheduleEventSettings DataSource="@DataSource">
                        <ScheduleField>
                            <FieldSubject Name="Name" Title="Patient Name"></FieldSubject>
                            <FieldStartTime Name="StartTime" Title="From"></FieldStartTime>
                            <FieldEndTime Name="EndTime" Title="To"></FieldEndTime>
                            <FieldDescription Name="Description" Title="Reason"></FieldDescription>
                        </ScheduleField>
                    </ScheduleEventSettings>
                </SfSchedule>
            </div>
        </div>
    </div>
</div>
<style>
    .treeview-external-drag {
        border: 1px solid #808080;
    }
</style>
@code{
    private SfKanban<KanbanDataModel> KanbanRef;
    private DateTime CurrentDate = new DateTime(2020, 1, 6);
    SfSchedule<HospitalData> ScheduleRef;
    public List<HospitalData> DataSource = new ScheduleData().GetHospitalData();
    public List<HospitalData> TreeViewData = new ScheduleData().GetWaitingListData();
    public string[] Resources = new string[] { "Departments", "Consultants" };
    private List<string> DropTarget1 = new List<string> { "#Schedule1" };
    private List<ResourceData> Departments { get; set; } = new List<ResourceData> {
        new ResourceData { Text = "GENERAL", Id = 1, Color = "#bbdc00" },
        new ResourceData { Text = "DENTAL", Id = 2, Color = "#9e5fff" }
    };
    private List<ResourceData> Consultants { get; set; } = new List<ResourceData> {
        new ResourceData { Text = "Alice", Id = 1, GroupId = 1, Color = "#bbdc00", Designation = "Cardiologist" },
        new ResourceData { Text = "Nancy", Id = 2, GroupId = 2, Color = "#9e5fff", Designation = "Orthodontist" },
        new ResourceData { Text = "Robert", Id = 3, GroupId = 1, Color = "#bbdc00", Designation = "Optometrist" },
        new ResourceData { Text = "Robson", Id = 4, GroupId = 2, Color = "#9e5fff", Designation = "Periodontist" },
        new ResourceData { Text = "Laura", Id = 5, GroupId = 1, Color = "#bbdc00", Designation = "Orthopedic" },
        new ResourceData { Text = "Margaret", Id = 6, GroupId = 2, Color = "#9e5fff", Designation = "Endodontist" }
    };
    public class ResourceData
    {
        public string Text { get; set; }
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string Color { get; set; }
        public string Designation { get; set; }
    }
    public class MailItem
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string FolderName { get; set; }
        public bool Expanded { get; set; }
        public bool HasSubFolders { get; set; }
    }
    public HospitalData DraggedItem { get; set; }
    private List<KanbanDataModel> cardData = new KanbanDataModel().GetTasks();
    private List<KanbanColumnModel> ColumnData = new List<KanbanColumnModel>() {
        new KanbanColumnModel(){ HeaderText= "To Do", KeyField= new List<string>() { "Open" } },
        new KanbanColumnModel(){ HeaderText= "In Progress", KeyField= new List<string>() { "InProgress" } },
        new KanbanColumnModel(){ HeaderText= "Testing", KeyField= new List<string>() { "Testing" } },
        new KanbanColumnModel(){ HeaderText= "Done", KeyField=new List<string>() { "Close" } }
    };

    public class KanbanColumnModel
    {
        public string HeaderText { get; set; }
        public List<string> KeyField { get; set; }
    }
    private async void OnCardDragStop1(Syncfusion.Blazor.Kanban.DragEventArgs<KanbanDataModel> args)
    {
        args.Cancel = true;
        CellClickEventArgs cellData = await ScheduleRef.GetTargetCell((int)args.Left, (int)args.Top);
        if (cellData != null)
        {
            var resourceDetails = ScheduleRef.GetResourceByIndex(cellData.GroupIndex);
            Random rnd = new Random();
            int Id = rnd.Next(1000);
            HospitalData kanData = DataSource.Where(data => data.Id.ToString() == args.Data[0].Id).First();
            HospitalData eventData = new HospitalData
            {
                Id = Id,
                Name = kanData.Name,
                StartTime = cellData.StartTime,
                EndTime = cellData.EndTime,
                IsAllDay = cellData.IsAllDay,
                ConsultantID = resourceDetails.GroupData.ConsultantID,
                DepartmentID = resourceDetails.GroupData.DepartmentID,
                Description = kanData.Description,
                DepartmentName = kanData.DepartmentName
            };
            await ScheduleRef.OpenEditor(eventData, Syncfusion.Blazor.Schedule.CurrentAction.Add);
            DraggedItem = kanData;
        }
    }
    public void OnActionBegin(Syncfusion.Blazor.Schedule.ActionEventArgs<HospitalData> args)
    {
        if (args.ActionType == ActionType.EventCreate && DraggedItem != null)
        {
            KanbanRef.DeleteCardAsync(DraggedItem.Id);
            DraggedItem = null;
        }
    }
}

{% endhighlight %}

{% highlight cshtml tabtitle="DataSource.cs" hl_lines="4" %}

using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Blazor.Data
{
    public class HospitalData
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Nullable<bool> IsAllDay { get; set; }
        public string CategoryColor { get; set; }
        public string RecurrenceRule { get; set; }
        public Nullable<int> RecurrenceID { get; set; }
        public Nullable<int> FollowingID { get; set; }
        public string RecurrenceException { get; set; }
        public string StartTimezone { get; set; }
        public string EndTimezone { get; set; }
        public string Name { get; set; }
        public int DepartmentID { get; set; }
        public int ConsultantID { get; set; }
        public string DepartmentName { get; set; }
    }

    public class ScheduleData
    {

        public List<HospitalData> GetHospitalData()
        {
            List<HospitalData> hospitalData = new List<HospitalData>();
            hospitalData.Add(new HospitalData
            {
                Id = 10,
                Name = "David",
                StartTime = new DateTime(2020, 1, 6, 9, 0, 0),
                EndTime = new DateTime(2020, 1, 6, 10, 0, 0),
                Description = "Health Checkup",
                DepartmentID = 1,
                ConsultantID = 1,
                DepartmentName = "GENERAL"
            });
            hospitalData.Add(new HospitalData
            {
                Id = 11,
                Name = "John",
                StartTime = new DateTime(2020, 1, 6, 10, 30, 0),
                EndTime = new DateTime(2020, 1, 6, 11, 30, 0),
                Description = "Tooth Erosion",
                DepartmentID = 2,
                ConsultantID = 2,
                DepartmentName = "DENTAL"
            });
            hospitalData.Add(new HospitalData
            {
                Id = 12,
                Name = "Peter",
                StartTime = new DateTime(2020, 1, 6, 12, 0, 0),
                EndTime = new DateTime(2020, 1, 6, 13, 0, 0),
                Description = "Eye and Spectacles Checkup",
                DepartmentID = 1,
                ConsultantID = 3,
                DepartmentName = "GENERAL"
            });
            hospitalData.Add(new HospitalData
            {
                Id = 13,
                Name = "Starc",
                StartTime = new DateTime(2020, 1, 6, 14, 0, 0),
                EndTime = new DateTime(2020, 1, 6, 15, 0, 0),
                Description = "Toothaches",
                DepartmentID = 2,
                ConsultantID = 4,
                DepartmentName = "DENTAL"
            });
            hospitalData.Add(new HospitalData
            {
                Id = 14,
                Name = "James",
                StartTime = new DateTime(2020, 1, 6, 10, 0, 0),
                EndTime = new DateTime(2020, 1, 6, 11, 0, 0),
                Description = "Surgery Appointment",
                DepartmentID = 1,
                ConsultantID = 5,
                DepartmentName = "GENERAL"
            });
            hospitalData.Add(new HospitalData
            {
                Id = 15,
                Name = "Jercy",
                StartTime = new DateTime(2020, 1, 6, 9, 30, 0),
                EndTime = new DateTime(2020, 1, 6, 10, 30, 0),
                Description = "Tooth Sensitivity",
                DepartmentID = 2,
                ConsultantID = 6,
                DepartmentName = "DENTAL"
            });
            hospitalData.Add(new HospitalData
            {
                Id = 16,
                Name = "Albert",
                StartTime = new DateTime(2020, 1, 7, 10, 0, 0),
                EndTime = new DateTime(2020, 1, 7, 11, 30, 0),
                Description = "Skin care treatment",
                DepartmentID = 1,
                ConsultantID = 7,
                DepartmentName = "GENERAL"
            });
            hospitalData.Add(new HospitalData
            {
                Id = 17,
                Name = "Louis",
                StartTime = new DateTime(2020, 1, 7, 12, 30, 0),
                EndTime = new DateTime(2020, 1, 7, 13, 30, 0),
                Description = "General Checkup",
                DepartmentID = 1,
                ConsultantID = 9,
                DepartmentName = "DENTAL"
            });
            hospitalData.Add(new HospitalData
            {
                Id = 18,
                Name = "Williams",
                StartTime = new DateTime(2020, 1, 7, 12, 0, 0),
                EndTime = new DateTime(2020, 1, 7, 14, 0, 0),
                Description = "Mouth Sores",
                DepartmentID = 2,
                ConsultantID = 10,
                DepartmentName = "DENTAL"
            });
            hospitalData.Add(new HospitalData
            {
                Id = 19,
                Name = "David",
                StartTime = new DateTime(2020, 1, 7, 16, 30, 0),
                EndTime = new DateTime(2020, 1, 7, 18, 45, 0),
                Description = "Eye checkup and Treatment",
                DepartmentID = 1,
                ConsultantID = 1,
                DepartmentName = "GENERAL"
            });
            hospitalData.Add(new HospitalData
            {
                Id = 20,
                Name = "John",
                StartTime = new DateTime(2020, 1, 7, 19, 30, 0),
                EndTime = new DateTime(2020, 1, 7, 21, 45, 0),
                Description = "Tooth Decay",
                DepartmentID = 2,
                ConsultantID = 2,
                DepartmentName = "DENTAL"
            });
            return hospitalData;
        }
        public List<HospitalData> GetWaitingListData()
        {
            List<HospitalData> waitingData = new List<HospitalData>();
            waitingData.Add(new HospitalData
            {
                Id = 1,
                Name = "Steven",
                StartTime = new DateTime(2020, 1, 3, 7, 30, 0),
                EndTime = new DateTime(2020, 1, 3, 9, 30, 0),
                Description = "Consulting",
                DepartmentName = "GENERAL"
            });
            waitingData.Add(new HospitalData
            {
                Id = 2,
                Name = "Milan",
                StartTime = new DateTime(2020, 1, 4, 8, 30, 0),
                EndTime = new DateTime(2020, 1, 4, 10, 30, 0),
                Description = "Bad Breath",
                DepartmentName = "DENTAL"
            });
            waitingData.Add(new HospitalData
            {
                Id = 3,
                Name = "Laura",
                StartTime = new DateTime(2020, 1, 4, 9, 30, 0),
                EndTime = new DateTime(2020, 1, 4, 10, 30, 0),
                Description = "Extraction",
                DepartmentName = "GENERAL"
            });
            waitingData.Add(new HospitalData
            {
                Id = 4,
                Name = "Janet",
                StartTime = new DateTime(2020, 1, 3, 11, 0, 0),
                EndTime = new DateTime(2020, 1, 3, 12, 30, 0),
                Description = "Gum Disease",
                DepartmentName = "DENTAL"
            });
            waitingData.Add(new HospitalData
            {
                Id = 5,
                Name = "Adams",
                StartTime = new DateTime(2020, 1, 3, 11, 0, 0),
                EndTime = new DateTime(2020, 1, 3, 12, 30, 0),
                Description = "Observation",
                DepartmentName = "GENERAL"
            });
            waitingData.Add(new HospitalData
            {
                Id = 6,
                Name = "John",
                StartTime = new DateTime(2020, 1, 3, 11, 30, 0),
                EndTime = new DateTime(2020, 1, 3, 12, 30, 0),
                Description = "Mouth Sores",
                DepartmentName = "DENTAL"
            });
            return waitingData;
        }

    }
    public class KanbanDataModel
    {
        public string Id { get; set; }
        public int ListId { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Summary { get; set; }
        public string Type { get; set; }
        public string Priority { get; set; }
        public List<string> CardTags { get; set; }
        public string Tags { get; set; }
        public double Estimate { get; set; }
        public string Assignee { get; set; }
        public int RankId { get; set; }
        public string Color { get; set; }
        public string Value { get; set; }
        public string OrderID { get; set; }
        public string Size { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Price { get; set; }
        public string AssigneeKey { get; set; }
        public List<string> ClassName { get; set; }

        public List<KanbanDataModel> GetTasks()
        {
            List<KanbanDataModel> TaskDetails = new List<KanbanDataModel>
            {                
                new KanbanDataModel { Id = "11", Title = "Task  - 29016", Status = "In Progress", Summary = "Fix cannot open user’s default database SQL error.", Priority = "Critical", Type = "High", CardTags = new List<string>() { "Database", "Sql2008" }, Estimate = 2.5, Assignee = "Janet Leverling", AssigneeKey = "Janet Leverling", RankId = 4, Color = "#cc0000", ClassName = new List<string>() { "e-critical", "e-high", "e-janet" } },
                new KanbanDataModel { Id = "12", Title = "Task  - 29017", Status = "Review", Summary = "Fix the issues reported in data binding.", Type = "Story", Priority = "Normal", CardTags = new List<string>() { "Databinding" }, Estimate = 3.5, Assignee = "Janet Leverling", AssigneeKey = "Janet Leverling", RankId = 4, Color = "#8b447a", ClassName = new List<string>() { "e-story", "e-noraml", "e-janet" } },
                new KanbanDataModel { Id = "13", Title = "Task  - 29018", Status = "Close", Summary = "Analyze SQL server 2008 connection.", Type = "Story", Priority = "Release Breaker", CardTags = new List<string>() { "Grid", "Sql" }, Estimate = 2, Assignee = "Andrew Fuller", AssigneeKey = "Andrew Fuller", RankId = 4, Color = "#8b447a", ClassName = new List<string>() { "e-story", "e-release", "e-andrew" } },
                new KanbanDataModel { Id = "14", Title = "Task  - 29019", Status = "Validate", Summary = "Validate databinding issues.", Type = "Story", Priority = "Low", CardTags = new List<string>() { "Validation" }, Estimate = 1.5, Assignee = "Margaret hamilt", AssigneeKey = "Margaret hamilt", RankId = 1, Color = "#8b447a", ClassName = new List<string>() { "e-story", "e-low", "e-margaret" } },
                new KanbanDataModel { Id = "15", Title = "Task  - 29020", Status = "Close", Summary = "Analyze grid control.", Type = "Story", Priority = "High", CardTags = new List<string>() { "Analyze" }, Estimate = 2.5, Assignee = "Margaret hamilt", AssigneeKey = "Margaret hamilt", RankId = 5, Color = "#8b447a", ClassName = new List<string>() { "e-story", "e-high", "e-margaret" } },
                new KanbanDataModel { Id = "16", Title = "Task  - 29021", Status = "Close", Summary = "Stored procedure for initial data binding of the grid.", Type = "Others", Priority = "Release Breaker", CardTags = new List<string>() { "Databinding" }, Estimate = 1.5, Assignee = "Steven walker", AssigneeKey = "Steven walker", RankId = 6, Color = "#27AE60", ClassName = new List<string>() { "e-others", "e-release", "e-steven" } },
                new KanbanDataModel { Id = "17", Title = "Task  - 29022", Status = "Close", Summary = "Analyze stored procedures.", Type = "Story", Priority = "Release Breaker", CardTags = new List<string>() { "Procedures" }, Estimate = 5.5, Assignee = "Janet Leverling", AssigneeKey = "Janet Leverling", RankId = 7, Color = "#8b447a", ClassName = new List<string>() { "e-story", "e-release", "e-janet" } },
                new KanbanDataModel { Id = "18", Title = "Task  - 29023", Status = "Validate", Summary = "Validate editing issues.", Type = "Story", Priority = "Critical", CardTags = new List<string>() { "Editing" }, Estimate = 1, Assignee = "Nancy Davloio", AssigneeKey = "Nancy Davloio", RankId = 1, Color = "#8b447a", ClassName = new List<string>() { "e-story", "e-critical", "e-nancy" } },
                new KanbanDataModel { Id = "19", Title = "Task  - 29024", Status = "Review", Summary = "Test editing functionality.", Type = "Story", Priority = "Normal", CardTags = new List<string>() { "Editing", "Test" }, Estimate = 0.5, Assignee = "Nancy Davloio", AssigneeKey = "Nancy Davloio", RankId = 5, Color = "#8b447a", ClassName = new List<string>() { "e-story", "e-normal", "e-nancy" } },
                new KanbanDataModel { Id = "20", Title = "Task  - 29025", Status = "Open", Summary = "Enhance editing functionality.", Type = "Improvement", Priority = "Low", CardTags = new List<string>() { "Editing" }, Estimate = 3.5, Assignee = "Andrew Fuller", AssigneeKey = "Andrew Fuller", RankId = 5, Color = "#7d7297", ClassName = new List<string>() { "e-imrpovement", "e-low", "e-andrew" } },                
            };
            return TaskDetails;
        }

        public List<KanbanDataModel> GetCardTasks()
        {
            List<KanbanDataModel> CardData = new List<KanbanDataModel>
            {
                new KanbanDataModel { Id = "Task 1", Title = "Task  - 29001", Status = "Open", Summary = "Analyze customer requirements.", Priority = "High", CardTags = new List<string>() { "Bug", "Release Bug" }, RankId = 1, Assignee = "Nancy Davloio" },
                new KanbanDataModel { Id = "Task 2", Title = "Task  - 29002", Status = "In Progress", Summary = "Add responsive support to applicaton", Priority = "Low", CardTags = new List<string>() { "Story", "Kanban" }, RankId = 1, Assignee = "Andrew Fuller" },
                new KanbanDataModel { Id = "Task 3", Title = "Task  - 29003", Status = "Open", Summary = "Show the retrived data from the server in grid control.", Priority = "High", CardTags = new List<string>() { "Bug", "Breaking Issue" }, RankId = 2, Assignee = "Janet Leverling" },
                new KanbanDataModel { Id = "Task 4", Title = "Task  - 29004", Status = "Open", Summary = "Fix the issues reported in the IE browser.", Priority = "High", CardTags = new List<string>() { "Bug", "Customer" }, RankId = 3, Assignee = "Andrew Fuller" },
                new KanbanDataModel { Id = "Task 5", Title = "Task  - 29005", Status = "Review", Summary = "Improve application performance.", Priority = "Normal", CardTags = new List<string>() { "Story", "Kanban" }, RankId = 1, Assignee = "Steven walker" },
                new KanbanDataModel { Id = "Task 6", Title = "Task  - 29009", Status = "Review", Summary = "API Improvements.", Priority = "Critical", CardTags = new List<string>() { "Bug", "Customer" }, RankId = 2, Assignee = "Nancy Davloio" },
                new KanbanDataModel { Id = "Task 7", Title = "Task  - 29010", Status = "Close", Summary = "Fix cannot open user's default database sql error.", Priority = "High", CardTags = new List<string>() { "Bug", "Internal" }, RankId = 8, Assignee = "Margaret hamilt" },
                new KanbanDataModel { Id = "Task 8", Title = "Task  - 29015", Status = "Open", Summary = "Fix the filtering issues reported in safari.", Priority = "Critical", CardTags = new List<string>() { "Bug", "Breaking Issue" }, RankId = 4, Assignee = "Margaret hamilt" },
                new KanbanDataModel { Id = "Task 9", Title = "Task  - 29016", Status = "Review", Summary = "Fix the issues reported in IE browser.", Priority = "High", CardTags = new List<string>() { "Bug", "Customer" }, RankId = 3, Assignee = "Andrew Fuller" },
                new KanbanDataModel { Id = "Task 10", Title = "Task  - 29017", Status = "Review", Summary = "Enhance editing functionality.", Priority = "Normal", CardTags = new List<string>() { "Story", "Kanban" }, RankId = 4, Assignee = "Janet Leverling" },
                new KanbanDataModel { Id = "Task 11", Title = "Task  - 29018", Status = "Close", Summary = "Arrange web meeting with customer to get login page requirement.", Priority = "High", CardTags = new List<string>() { "Feature" }, RankId = 1, Assignee = "Andrew Fuller" },
                new KanbanDataModel { Id = "Task 12", Title = "Task  - 29020", Status = "Close", Summary = "Login page validation.", Priority = "Low", CardTags = new List<string>() { "Bug" }, RankId = 2, Assignee = "Margaret hamilt" },
                new KanbanDataModel { Id = "Task 13", Title = "Task  - 29021", Status = "Close", Summary = "Test the application in IE browser.", Priority = "Normal", CardTags = new List<string>() { "Bug" }, RankId = 3, Assignee = "Steven walker" },
                new KanbanDataModel { Id = "Task 14", Title = "Task  - 29022", Status = "Close", Summary = "Analyze stored procedure.", Priority = "Critical", CardTags = new List<string>() { "CustomSample", "Customer" }, RankId = 4, Assignee = "Janet Leverling" },
                new KanbanDataModel { Id = "Task 15", Title = "Task  - 29024", Status = "Review", Summary = "Check login page validation.", Priority = "Low", CardTags = new List<string>() { "Story" }, RankId = 5, Assignee = "Nancy Davloio" },
                new KanbanDataModel { Id = "Task 16", Title = "Task  - 29025", Status = "Close", Summary = "Add input validation for editing.", Priority = "Critical", CardTags = new List<string>() { "Bug", "Breaking Issue" }, RankId = 5, Assignee = "Andrew Fuller" },
                new KanbanDataModel { Id = "Task 17", Title = "Task  - 29026", Status = "In Progress", Summary = "Improve performance of editing functionality.", Priority = "Critical", CardTags = new List<string>() { "Bug", "Customer" }, RankId = 2, Assignee = "Nancy Davloio" },
                new KanbanDataModel { Id = "Task 18", Title = "Task  - 29027", Status = "Open", Summary = "Arrange web meeting for cutomer requirement.", Priority = "High", CardTags = new List<string>() { "Story" }, RankId = 5, Assignee = "Steven walker" },
                new KanbanDataModel { Id = "Task 19", Title = "Task  - 29029", Status = "Review", Summary = "Fix the issues reported by the customer.", Priority = "High", CardTags = new List<string>() { "Bug" }, RankId = 6, Assignee = "Janet Leverling" },
                new KanbanDataModel { Id = "Task 20", Title = "Task  - 29030", Status = "In Progress", Summary = "Test editing functionality", Priority = "Low", CardTags = new List<string>() { "Story" }, RankId = 3, Assignee = "Janet Leverling" },
                new KanbanDataModel { Id = "Task 21", Title = "Task  - 29031", Status = "In Progress", Summary = "Check filtering validation", Priority = "Normal", CardTags = new List<string>() { "Feature", "Release" }, RankId = 4, Assignee = "Janet Leverling" },
                new KanbanDataModel { Id = "Task 22", Title = "Task  - 29032", Status = "In Progress", Summary = "Arrange web meeting with customer to get login page requirement", Priority = "Critical", CardTags = new List<string>() { "Feature" }, RankId = 5, Assignee = "Margaret hamilt" },
                new KanbanDataModel { Id = "Task 23", Title = "Task  - 29033", Status = "Open", Summary = "Arrange web meeting with customer to get editing requirements", Priority = "Critical", CardTags = new List<string>() { "Story", "Improvement" }, RankId = 6, Assignee = "Andrew Fuller" },
                new KanbanDataModel { Id = "Task 24", Title = "Task  - 29034", Status = "In Progress", Summary = "Fix the issues reported by the customer.", Priority = "Critical", CardTags = new List<string>() { "Bug", "Customer" }, RankId = 6, Assignee = "Steven walker" },
                new KanbanDataModel { Id = "Task 25", Title = "Task  - 29035", Status = "Close", Summary = "Fix the issues reported in Safari browser.", Priority = "High", CardTags = new List<string>() { "Bug" }, RankId = 6, Assignee = "Nancy Davloio" },
                new KanbanDataModel { Id = "Task 26", Title = "Task  - 29036", Status = "Review", Summary = "Check Login page validation.", Priority = "Critical", CardTags = new List<string>() { "Bug", "Customer" }, RankId = 7, Assignee = "Margaret hamilt" },
                new KanbanDataModel { Id = "Task 27", Title = "Task  - 29037", Status = "Open", Summary = "Fix the issues reported in data binding.", Priority = "Normal", CardTags = new List<string>() { "Bug" }, Estimate = 3.5, RankId = 7, Assignee = "Steven walker" },
                new KanbanDataModel { Id = "Task 28", Title = "Task  - 29038", Status = "Close", Summary = "Test editing functionality.", Priority = "Normal", CardTags = new List<string>() { "Story" }, Estimate = 0.5, RankId = 7, Assignee = "Steven walker" }
            };
            return CardData;
        }
    }
}

{% endhighlight %}
{% endtabs %}
