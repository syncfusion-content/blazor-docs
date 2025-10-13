---
layout: post
title: Clipboard in Blazor Scheduler Component | Syncfusion
description: Learn here all about how to integrate the Clipboard manually to a Syncfusion Blazor Scheduler component and use it with required options.
platform: Blazor
control: Scheduler
documentation: ug
---

# Clipboard in Blazor Scheduler Component

<<<<<<< HEAD
The Clipboard functionality in the Syncfusion<sup style="font-size:70%">&reg;</sup> Scheduler enhances scheduling efficiency by enabling users to cut, copy, and paste appointments with ease. This feature is especially beneficial for those managing multiple appointments, as it eliminates the need for repetitive data entry and allows users to quickly adjust their schedules without hassle.
=======
The Clipboard functionality in the Syncfusion<sup style="font-size:70%">&reg;</sup> Scheduler enhances scheduling efficiency by enabling users to cut, copy, and paste appointments with ease. This feature is especially beneficial for managing multiple appointments, as it streamlines repetitive tasks and allows for quick adjustments to schedules.
>>>>>>> 32c27d577704390b597a361089e564504af90b58

To activate the clipboard feature in the Scheduler, set the [`AllowClipboard`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.SfSchedule-1.html#Syncfusion_Blazor_Schedule_SfSchedule_1_AllowClipboard) property to `true`.

N> The [`AllowKeyboardInteraction`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.SfSchedule-1.html#Syncfusion_Blazor_Schedule_SfSchedule_1_AllowKeyboardInteraction) property must also be set to `true` for the clipboard feature to function correctly, as it relies on keyboard shortcuts.

## Cut, Copy, and Paste Using Keyboard

<<<<<<< HEAD
The Syncfusion<sup style="font-size:70%">&reg;</sup> Scheduler supports keyboard shortcuts to streamline the process of managing appointments.
=======
The Syncfusion<sup style="font-size:70%">&reg;</sup> Scheduler supports standard keyboard shortcuts to streamline the process of managing appointments.
>>>>>>> 32c27d577704390b597a361089e564504af90b58

These keyboard shortcuts enable efficient schedule management:

| Operation | Shortcut | Description                                                      |
|-----------|----------|------------------------------------------------------------------|
| Copy      | Ctrl+C   | Duplicate appointments to streamline the scheduling process.     |
| Cut       | Ctrl+X   | Move appointments to a new time slot without duplicates.         |
| Paste     | Ctrl+V   | Place copied or cut appointments into the desired time slot.     |

To use these shortcuts, simply click on the appointment and press **Ctrl+C** to copy or **Ctrl+X** to cut. To paste the copied or cut appointment, click on the desired time slot and press **Ctrl+V**.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="650px" @bind-SelectedDate="@SelectedDate" AllowClipboard="true" AllowKeyboardInteraction="true" ShowQuickInfo="false">
    <ScheduleEventSettings DataSource="@DataSource"></ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>

@code {
    private DateTime SelectedDate { get; set; } = new DateTime(2023, 1, 15);

    public List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData 
        { 
            Id = 1, 
            Subject = "Meeting with clients", 
            StartTime = new DateTime(2023, 1, 15, 9, 30, 0), 
            EndTime = new DateTime(2023, 1, 15, 11, 0, 0), 
            IsAllDay = false 
        },
        new AppointmentData 
        { 
            Id = 2, 
            Subject = "Project Review", 
            StartTime = new DateTime(2023, 1, 15, 12, 0, 0), 
            EndTime = new DateTime(2023, 1, 15, 14, 0, 0), 
            IsAllDay = false 
        },
        new AppointmentData 
        { 
            Id = 3, 
            Subject = "Team Lunch", 
            StartTime = new DateTime(2023, 1, 16, 12, 0, 0), 
            EndTime = new DateTime(2023, 1, 16, 13, 0, 0), 
            IsAllDay = false 
        },
        new AppointmentData 
        { 
            Id = 4, 
            Subject = "Development Planning", 
            StartTime = new DateTime(2023, 1, 17, 10, 0, 0), 
            EndTime = new DateTime(2023, 1, 17, 11, 30, 0), 
            IsAllDay = false 
        },
        new AppointmentData 
        { 
            Id = 5, 
            Subject = "Status Update", 
            StartTime = new DateTime(2023, 1, 18, 15, 0, 0), 
            EndTime = new DateTime(2023, 1, 18, 16, 30, 0), 
            IsAllDay = false 
        }
    };

    public class AppointmentData
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public bool IsAllDay { get; set; }
        public string RecurrenceRule { get; set; }
        public string RecurrenceException { get; set; }
        public Nullable<int> RecurrenceID { get; set; }
    }
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZBojgVmMamGGqYM?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5 %}

N> For Mac users, use **Cmd** instead of **Ctrl** for copy, cut, and paste operations.

## Cut, Copy, and Paste Using Context Menu

Appointments can be programmatically managed using the public methods `CopyAsync`, `CutAsync`, and `PasteAsync`. These methods allow developers to trigger the same clipboard actions as keyboard shortcuts or context menu options, providing more control over the appointment management process.

Utilize these public methods to manage appointments programmatically in Syncfusion<sup style="font-size:70%">&reg;</sup> Schedule:

| Method          | Parameters                            | Description                                                        |
|-----------------|---------------------------------------|--------------------------------------------------------------------|
| `CopyAsync`   | None                                  | Duplicate the selected appointment for reuse.                      |
| `CutAsync`    | None                                  | Remove the selected appointment from its current slot for moving.  |
| `PasteAsync`  | targetElement (Scheduler's work-cell) | Insert the copied or cut appointment into the specified time slot. |

By using these methods within event handlers (e.g., from a custom context menu), precise control over clipboard operations is achieved.

```cshtml
@using Syncfusion.Blazor.Schedule
@using Syncfusion.Blazor.Navigations
<div class="col-lg-12 control-section">
    <SfSchedule TValue="AppointmentData" @ref="ScheduleRef" Height="650px" @bind-SelectedDate="@SelectedDate" AllowClipboard="true" ShowQuickInfo="false">
        <ScheduleEventSettings DataSource="@EventDataSource"></ScheduleEventSettings>
        <ScheduleViews>
            <ScheduleView Option="View.Week"></ScheduleView>
            <ScheduleView Option="View.Day"></ScheduleView>
            <ScheduleView Option="View.Month"></ScheduleView>
            <ScheduleView Option="View.TimelineDay"></ScheduleView>
            <ScheduleView Option="View.TimelineMonth"></ScheduleView>
        </ScheduleViews>
    </SfSchedule>
    <SfContextMenu TValue="MenuItem" Target=".e-schedule">
        <MenuItems>
            <MenuItem Text="Copy" Id="Copy" Hidden="@(!isEvent)" IconCss="e-icons e-copy"></MenuItem>
            <MenuItem Text="Cut" Id="Cut" Hidden="@(!isEvent)" IconCss="e-icons e-cut"></MenuItem>
            <MenuItem Text="Paste" Id="Paste" Hidden="@(!isCell)" IconCss="e-icons e-paste"></MenuItem>
        </MenuItems>
        <MenuEvents TValue="MenuItem" OnOpen="OnOpen" ItemSelected="OnItemSelected"></MenuEvents>
    </SfContextMenu>
</div>
@code {
    private DateTime SelectedDate { get; set; } = new DateTime(2023, 1, 8);
    private bool isCell;
    private bool isEvent;
    SfSchedule<AppointmentData> ScheduleRef;
    private AppointmentData EventData { get; set; }
    private CellClickEventArgs CellData { get; set; }
    private ElementInfo<AppointmentData> ElementData { get; set; }
    private List<AppointmentData> EventDataSource = new List<AppointmentData>()
    {   
        new AppointmentData
        {
            Id = 1,
            Subject = "Explosion of Betelgeuse Star",
            Location = "Space Centre USA",
            StartTime = new DateTime(2023, 1, 5, 9, 30, 0),
            EndTime = new DateTime(2023, 1, 5, 11, 0, 0),
            CategoryColor = "#1aaa55"
        },
        new AppointmentData
        {
            Id = 2,
            Subject = "Thule Air Crash Report",
            Location = "Newyork City",
            StartTime = new DateTime(2023, 1, 6, 12, 0, 0),
            EndTime = new DateTime(2023, 1, 6, 14, 0, 0),
            CategoryColor = "#357cd2"
        },
        new AppointmentData
        {
            Id = 3,
            Subject = "Blue Moon Eclipse",
            Location = "Space Centre USA",
            StartTime = new DateTime(2023, 1, 7, 9, 30, 0),
            EndTime = new DateTime(2023, 1, 7, 11, 0, 0),
            CategoryColor = "#7fa900"
        },
        new AppointmentData
        {
            Id = 4,
            Subject = "Meteor Showers in 2022",
            Location = "Space Centre USA",
            StartTime = new DateTime(2023, 1, 8, 13, 0, 0),
            EndTime = new DateTime(2023, 1, 8, 14, 30, 0),
            CategoryColor = "#ea7a57"
        },
        new AppointmentData
        {
            Id = 5,
            Subject = "Milky Way as Melting Pot",
            Location = "Space Centre USA",
            StartTime = new DateTime(2023, 1, 9, 12, 0, 0),
            EndTime = new DateTime(2023, 1, 9, 14, 0, 0),
            CategoryColor = "#00bdae"
        }
    };

    public async Task OnOpen(BeforeOpenCloseMenuEventArgs<MenuItem> args)
    {
        ElementData = await ScheduleRef.GetElementInfoAsync((int)args.Left, (int)args.Top);
        if (args.ParentItem == null && ElementData != null)
        {
            if (ElementData.ElementType == ElementType.Event)
            {
                EventData = ElementData.EventData;
                isCell = false;
                isEvent = true;
            }
            else if (ElementData.ElementType == ElementType.WorkCells || ElementData.ElementType == ElementType.DateHeader || 
            ElementData.ElementType == ElementType.AllDayCells)
            {
                isCell = true;
                isEvent = false;
                CellData = new CellClickEventArgs
                    {
                        StartTime = ElementData.StartTime,
                        EndTime = ElementData.EndTime,
                        IsAllDay = ElementData.IsAllDay,
                    };
            }
            else
            {
                args.Cancel = true;
            }
        }
    }
    public async Task OnItemSelected(MenuEventArgs<MenuItem> args)
    {
        var SelectedMenuItem = args.Item.Id;
        switch (SelectedMenuItem)
        {
            case "Copy":
                await CopyEvent(EventData);
                break;
            case "Cut":
                await CutEvent(EventData);
                break;
            case "Paste":
                if (isCell)
                {
                    await PasteEvent(CellData);
                }
                break;
        }
    }
    private async Task PasteEvent(CellClickEventArgs cellData)
    {
        await ScheduleRef.PasteAsync(cellData);
    }
    private async Task CopyEvent(AppointmentData eventData)
    {
        await ScheduleRef.CopyAsync(eventData);
    }
    private async Task CutEvent(AppointmentData eventData)
    {
        await ScheduleRef.CutAsync(eventData);
    }
    public class AppointmentData
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
        public virtual Guid Guid { get; set; }
    }
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNVojqVGhZgDmVrp?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5 %}

## Modifying Content Before Pasting

The content of an appointment can be modified before it is pasted by utilizing the `Paste` event. This event provides access to the appointment details, allowing for necessary changes.

The following example demonstrates how to seamlessly copy and paste content from a grid to a scheduler. To do this, follow these steps:

1. **Select an Item**: Click on an item in the grid.
2. **Copy the Details**: Press **Ctrl + C** to copy the selected event details.
3. **Choose a Time Slot**: Click on the desired time slot in the scheduler.
4. **Paste the Details**: Press **Ctrl + V** to paste the copied appointment details into the selected time slot.

In this example, the `Paste` event can be utilized to intercept the event details before they are pasted. This allows you to modify the content as needed. Such modifications could include adjusting the time, adding notes, or altering other specifics of the appointment.

```cshtml

@using Syncfusion.Blazor.Schedule
@using Syncfusion.Blazor.Grids
@using System.Text.Json

<div class="container">
    <div class="row">
          <div class="col-lg-6">
            <SfSchedule TValue="AppointmentData" @ref="ScheduleRef" Height="550px" Width="100%" 
                        @bind-SelectedDate="@CurrentDate" AllowClipboard="true" ShowQuickInfo="false">
                <ScheduleEvents TValue="AppointmentData" Paste="OnBeforePaste"></ScheduleEvents>
                <ScheduleEventSettings DataSource="@ScheduleData"></ScheduleEventSettings>
                <ScheduleViews>
                    <ScheduleView Option="View.Day"></ScheduleView>
                    <ScheduleView Option="View.Week"></ScheduleView>
                    <ScheduleView Option="View.WorkWeek"></ScheduleView>
                    <ScheduleView Option="View.Month"></ScheduleView>
                    <ScheduleView Option="View.Agenda"></ScheduleView>
                </ScheduleViews>
            </SfSchedule>
        </div>
        <div class="col-lg-6">
            <SfGrid @ref="GridRef" DataSource="@GridData" AllowSelection="true" Width="100%" CssClass="drag-grid">
                <GridColumns>
                    <GridColumn Field="OrderID" HeaderText="Order ID" Width="90" TextAlign="TextAlign.Right"></GridColumn>
                    <GridColumn Field="CustomerID" HeaderText="Customer ID" Width="100"></GridColumn>
                    <GridColumn Field="ShipCity" HeaderText="Ship City" Width="100"></GridColumn>
                    <GridColumn Field="ShipName" HeaderText="Ship Name" Width="130"></GridColumn>
                    <GridColumn Field="OrderDate" HeaderText="Order Date" Width="100" Format="d" Type="ColumnType.Date"></GridColumn>
                </GridColumns>
            </SfGrid>
        </div>
    </div>
</div>

@code {
    private DateTime CurrentDate { get; set; } = new DateTime(2024, 1, 15);
    private SfSchedule<AppointmentData> ScheduleRef;
    private SfGrid<OrderData> GridRef;

    private List<AppointmentData> ScheduleData { get; set; } = new List<AppointmentData>
    {
        new AppointmentData { 
            Id = 1, 
            Subject = "Meeting", 
            StartTime = new DateTime(2024, 1, 15, 10, 0, 0),
            EndTime = new DateTime(2024, 1, 15, 11, 30, 0),
            Location = "Conference Room",
            Description = "Monthly Status Update"
        },
        new AppointmentData { 
            Id = 2, 
            Subject = "Team Lunch", 
            StartTime = new DateTime(2024, 1, 16, 12, 0, 0),
            EndTime = new DateTime(2024, 1, 16, 13, 0, 0),
            Location = "Cafeteria",
            Description = "Team Building"
        }
    };

    private List<OrderData> GridData { get; set; } = new List<OrderData>
    {
        new OrderData { OrderID = 10248, CustomerID = "VINET", Role = "Admin", EmployeeID = 5,
            ShipName = "Vins et alcools Chevalier", ShipCity = "Reims", ShipAddress = "59 rue de l Abbaye",
            ShipRegion = "CJ", Mask = "1111", ShipPostalCode = "51100", ShipCountry = "France", Freight = 32.38, Verified = true,
            OrderDate = new DateTime(2024, 1, 1) },
        new OrderData { OrderID = 10249, CustomerID = "TOMSP", Role = "Employee", EmployeeID = 6,
            ShipName = "Toms Spezialitäten", ShipCity = "Münster", ShipAddress = "Luisenstr. 48",
            ShipRegion = "CJ", Mask = "2222", ShipPostalCode = "44087", ShipCountry = "Germany", Freight = 11.61, Verified = false,
            OrderDate = new DateTime(2024, 1, 2) },
        new OrderData { OrderID = 10250, CustomerID = "HANAR", Role = "Admin", EmployeeID = 4,
            ShipName = "Hanari Carnes", ShipCity = "Rio de Janeiro", ShipAddress = "Rua do Paço, 67",
            ShipRegion = "RJ", Mask = "3333", ShipPostalCode = "05454-876", ShipCountry = "Brazil", Freight = 65.83, Verified = true,
            OrderDate = new DateTime(2024, 1, 3) },
        new OrderData { OrderID = 10251, CustomerID = "VICTE", Role = "Manager", EmployeeID = 3,
            ShipName = "Victuailles en stock", ShipCity = "Lyon", ShipAddress = "2, rue du Commerce",
            ShipRegion = "CJ", Mask = "4444", ShipPostalCode = "69004", ShipCountry = "France", Freight = 41.34, Verified = true,
            OrderDate = new DateTime(2024, 1, 4) },
        new OrderData { OrderID = 10252, CustomerID = "SUPRD", Role = "Manager", EmployeeID = 2,
            ShipName = "Suprêmes délices", ShipCity = "Charleroi", ShipAddress = "Boulevard Tirou, 255",
            ShipRegion = "CJ", Mask = "5555", ShipPostalCode = "B-6000", ShipCountry = "Belgium", Freight = 51.3, Verified = true,
            OrderDate = new DateTime(2024, 1, 5) }
    };

    public async Task OnBeforePaste(PasteEventArgs<AppointmentData> args)
    {
        if (args.ClipboardText is string stringData)
        {
            string[] dataArray = stringData.Split('\t');
            if (dataArray.Length >= 5)
            {
                int id;
                if (int.TryParse(dataArray[0], out id))
                {
                    DateTime orderDate;
                    DateTime.TryParse(dataArray[4], out orderDate);

                    args.Data = new List<AppointmentData> {
                        new AppointmentData {
                            Id = id,
                            Subject = $"{dataArray[1]}",
                            StartTime = orderDate,
                            EndTime = orderDate.AddHours(1),
                            Location = dataArray[2],
                            Description = $"Order from {dataArray[3]}"
                        }
                    };
                }
            }
        }
    }

    public class AppointmentData
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public bool IsAllDay { get; set; }
        public string RecurrenceRule { get; set; }
        public string RecurrenceException { get; set; }
        public int? RecurrenceID { get; set; }
    }

    public class OrderData
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public string Role { get; set; }
        public int EmployeeID { get; set; }
        public string ShipName { get; set; }
        public string ShipCity { get; set; }
        public string ShipAddress { get; set; }
        public string ShipRegion { get; set; }
        public string Mask { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        public double Freight { get; set; }
        public bool Verified { get; set; }
        public DateTime OrderDate { get; set; }
    }
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXroNUhmrDOIbXBe?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5 %}