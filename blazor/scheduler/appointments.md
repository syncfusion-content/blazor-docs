---
layout: post
title: Appointments in Blazor Scheduler Component | Syncfusion
description: Learn here all about the types of events, recurring events, customizing events, and also drag and resize options in Syncfusion Blazor Scheduler component.
platform: Blazor
control: Scheduler
documentation: ug
---

# Appointments in Blazor Scheduler Component

Appointments can be anything that are scheduled for a specific time period. It can be created on varied time range and each appointments are categorized based on this range. The Scheduler events can be categorized as,

* Normal events
* Spanned events
* All-day events
* Recurring events

To get start quickly about appointments and how to customize it, you can check on this video:

{% youtube
"youtube:https://www.youtube.com/watch?v=Vtl1Wyuwt-0"%}

## Normal events

Represents an appointment that is created for any specific time interval within a day.

### Creating a normal event

The following example depicts how to define a normal event on the Scheduler, with event data being loaded from simple list of appointment collection.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="550px" @bind-SelectedDate="@CurrentDate">
    <ScheduleEventSettings DataSource="@DataSource"></ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>

@code{
    DateTime CurrentDate = new DateTime(2020, 1, 31);
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData { Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 1, 31, 9, 30, 0) , EndTime = new DateTime(2020, 1, 31, 11, 0, 0) }
    };
    public class AppointmentData
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
```

## Spanned events

Represents an appointment that is created for more than 24 hours, and usually displayed on the all-day row. Also, represents another type of appointment that is created for more than one day but less than 24 hours, and usually displayed appropriately on both the days.

> For example, in week view if an appointment is created for two days say from November 25, 2020 – 11.00 PM to November 26, 2020 - 2.00 AM but less than 24 hours time interval, then the appointment split into two partitions and will be displayed on both the days.

## All-day events

Represents an appointment that is created for an entire day such as holiday events. It is usually displayed separately in an all-day row, a separate row for all-day appointments below the date header section. In Timeline views, the all-day appointments displays in the working space area, and no separate all-day row is present in that view.

> To change normal appointment into all-day event, set `IsAllDay` field to true.

### Hide all-day row events

You can make use of the CSS customization to prevent the display of all-day row appointments on the Scheduler UI.

```css
.e-schedule .e-date-header-wrap .e-schedule-table thead {
    display: none;
}
```

## Recurring events

Represents an appointment that is created for a certain time interval and occurring repeatedly on a daily, weekly, monthly or yearly basis at the same time interval based on the provided recurrence rule. Usually, the recurring events are indicated by a repeat marker added at the bottom-right position.

### Creating a recurring event

The following example depicts how to create a recurring event on Scheduler with the specific recurrence rule. In the following example, an event is made to repeat on daily mode and ends after 5 occurrences.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="550px" @bind-SelectedDate="@CurrentDate">
    <ScheduleEventSettings DataSource="@DataSource"></ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>

@code{
    DateTime CurrentDate = new DateTime(2020, 1, 9);
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData { Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 1, 6, 9, 30, 0) , EndTime = new DateTime(2020, 1, 6, 11, 0, 0),
        RecurrenceRule = "FREQ=DAILY;INTERVAL=1;COUNT=5" }
    };
    public class AppointmentData
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsAllDay { get; set; }
        public string RecurrenceRule { get; set; }
        public Nullable<int> RecurrenceID { get; set; }
        public string RecurrenceException { get; set; }
    }
}
```

### Adding exceptions

A few instance of the recurrence series can be excluded on specific dates, by adding those exceptional dates to the `RecurrenceException` field. These date values should be given in the ISO date time format with no hyphens(-) separating the date elements.

For example, 7th January 2020 can be represented as 20200107. Also, the time part being represented in UTC format needs to add "Z" after the time portion with no space. "09:30 AM" is therefore represented as "040000Z".

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="550px" @bind-SelectedDate="@CurrentDate">
    <ScheduleEventSettings DataSource="@DataSource"></ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>

@code{
    DateTime CurrentDate = new DateTime(2020, 1, 6);
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData { Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 1, 6, 9, 30, 0) , EndTime = new DateTime(2020, 1, 6, 11, 0, 0),
        RecurrenceRule = "FREQ=DAILY;INTERVAL=1;COUNT=5", RecurrenceException = "20200107T040000Z,20200109T040000Z" }
    };
    public class AppointmentData
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsAllDay { get; set; }
        public string RecurrenceRule { get; set; }
        public string RecurrenceException { get; set; }
        public Nullable<int> RecurrenceID { get; set; }
    }
}
```

### Editing an occurrence from a series

To dynamically edit a particular occurrence from an event series and display it on the initial load of Scheduler, the edited occurrence needs to be added as a new event to the dataSource collection, with an additional `RecurrenceID` field defined to it. The `RecurrenceID` field of edited occurrence usually maps the ID value of the parent event.

In this example, a recurring instance that displays on the date 30th January 2020 is edited with different timings. Therefore, this particular date is excluded from the parent recurring event that repeats from 28th January 2020 to 1st February 2020. This can be done by adding the `RecurrenceException` field with the excluded date value on the parent event. Also, the edited occurrence event which is created as a new event should carry the `RecurrenceID` field pointing to the parent event's `Id` value.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="550px" @bind-SelectedDate="@CurrentDate">
    <ScheduleEventSettings DataSource="@DataSource"></ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>

@code{
    DateTime CurrentDate = new DateTime(2020, 1, 31);
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData { Id = 1, Subject = "Scrum Meeting", StartTime = new DateTime(2020, 1, 28, 9, 30, 0) , EndTime = new DateTime(2020, 1, 28, 11, 0, 0),
        RecurrenceRule = "FREQ=DAILY;INTERVAL=1;COUNT=5", RecurrenceException = "20200130T040000Z" },
        new AppointmentData { Id = 2, Subject = "Scrum Meeting Rescheduled", StartTime = new DateTime(2020, 1, 30, 10, 30, 0) , EndTime = new DateTime(2020, 1, 30, 12, 0, 0), RecurrenceID = 1 }
    };
    public class AppointmentData
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsAllDay { get; set; }
        public string RecurrenceRule { get; set; }
        public string RecurrenceException { get; set; }
        public Nullable<int> RecurrenceID { get; set; }
    }
}
```

### Edit/Delete following recurrence events

The Scheduler allows the user to edit the following recurrence events by setting true value to `AllowEditFollowingEvents` within the `ScheduleEventSettings` tag. Once we have edited/ deleted the recurrence events as following events, then the following recurrence events will be considered as separate series, the changes will not reflect to parent series. In the following code example, if we edit or delete any of the recurrence event with following events option, then the edit or delete action is applied to further recurrence events.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Width="100%" Height="550px" @bind-SelectedDate="@CurrentDate">
    <ScheduleEventSettings DataSource="@DataSource" AllowEditFollowingEvents="true"></ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>

@code{
    DateTime CurrentDate = new DateTime(2020, 3, 10);
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData { Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 3, 9, 9, 30, 0) , EndTime = new DateTime(2020, 3, 9, 11, 0, 0), RecurrenceRule = "FREQ=DAILY;INTERVAL=1;COUNT=5" }
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

The following image depicts the edited recurrence following events.

![Edit Following Events](images/edit-following-events.png)

### Recurrence options and rules

Events can be repeated on a daily, weekly, monthly or yearly basis based on the recurrence rule which accepts the string value. The following details should be assigned to the `RecurrenceRule` property to generate the recurring instances.

* Repeat type - daily/weekly/monthly/yearly.
* How many times it needs to be repeated?
* The interval duration.
* The time period to render the appointment, etc.

There are four repeat types available namely,

* **Daily** - Creates the recurring instances on daily basis.
* **Weekly** - Creates the recurring instances on weekly basis for the selected days.
* **Monthly** - Creates the recurring instances on monthly basis for the selected months and other provided recurrence criteria.
* **Yearly** - Creates the recurring instances on yearly basis.

### Recurrence properties

 The properties based on which the recurrence appointments are created with its respective time period are depicted in the following table. Also, the valid rule string can be referred from [iCalendar](https://datatracker.ietf.org/doc/html/rfc5545#section-3.3.10) specifications.

 > Refer [iCalendar](https://datatracker.ietf.org/doc/html/rfc5545#section-3.3.10) specifications for valid recurrence rule string.

| Property | Purpose | Example |
|-------|---------| --------- |
| FREQ | Maintains the repeat type (Daily, Weekly, Monthly, Yearly) value of the appointment. | FREQ=DAILY;INTERVAL=1|
| INTERVAL | Maintains the interval value of the appointments. When you create the daily appointment at an interval of 2, the appointments are rendered on the days Monday, Wednesday and Friday (Creates an appointment on all days by leaving the interval of one day gap). | FREQ=DAILY;INTERVAL=2|
| COUNT | It holds the appointment’s count value. When the COUNT value is 10, then 10 instances of appointments are created in the recurrence series. | FREQ=DAILY;INTERVAL=1;COUNT=10|
| UNTIL | This property holds the end date value (in ISO format) denoting when the recurrence actually ends. | FREQ=DAILY;INTERVAL=1;UNTIL=20200530T041343Z;|
| BYDAY | It holds the day value(s), representing on which the appointments actually renders. Create the weekly appointment, and select the day(s) from the day options (Monday/Tuesday/Wednesday/Thursday/Friday/Saturday/Sunday). When Monday is selected, the first two letters of the selected day "MO" is saved in the BYDAY property. When multiple days are selected, the values are separated by commas. | FREQ=WEEKLY;INTERVAL=1;BYDAY=MO,WE;COUNT=10|
| BYMONTHDAY | This property is used to store the date value of the Month, while creating the Month recurrence appointment. When you create a Monthly recurrence appointment for every 3rd day of the month, then BYMONTHDAY holds the value 3 and creates the appointment on 3rd day of every month. | FREQ=MONTHLY;BYMONTHDAY=3;INTERVAL=1;COUNT=10|
| BYMONTH | This property is used to store the index value of the selected Month while creating the yearly appointments. When you create the yearly appointment on June month, the index value of June month 6 will get stored in the BYMONTH field. The appointment is created on every 6th month of a year. | FREQ=YEARLY;BYMONTHDAY=16;BYMONTH=6;INTERVAL=1;COUNT=10|
| BYSETPOS | This property is used to store the index value of the week. When you create the monthly appointment in second week of a month, the index value of the second week (2) is stored in BYSETPOS. | FREQ=MONTHLY;BYDAY=MO;BYSETPOS=2;COUNT=10|

> The default recurrence related validation has been included for recurrence appointments similar to the one available in Outlook. The validation usually occurs during the recurrence appointment creation, editing, drag and drop or resizing of the recurrence appointments and also if any single occurrence changes.

### Daily Frequency

| Description | Example |
|-------------|---------|
| Daily recurring event that never ends | FREQ=DAILY; INTERVAL=1 |
| Daily recurring event that ends after 5 occurrences | FREQ=DAILY; INTERVAL=1; COUNT=5 |
| Daily recurring event that ends exactly on 12/12/2020 | FREQ=DAILY; INTERVAL=1; UNTIL=20201212T041343Z |
| Daily event that recurs on alternative days and repeats for 10 occurrences | FREQ=DAILY; INTERVAL=2; COUNT=10 |

### Weekly Frequency

| Description | Example |
|-------------|---------|
| Weekly recurring event that repeats on every Monday, Wednesday and Friday and never ends | FREQ=WEEKLY; INTERVAL=1; BYDAY=MO,WE,FR |
| Repeats every week Thursday and ends after 10 occurrences | FREQ=WEEKLY; INTERVAL=1; BYDAY=TH; COUNT=10 |
| Repeats every week Monday and ends on 12/12/2020 | FREQ=WEEKLY; INTERVAL=1; BYDAY=MO; UNTIL=20201212T041343Z |
| Repeats on Monday, Wednesday and Friday of alternative weeks and ends after 10 occurrences | FREQ=WEEKLY; INTERVAL=2; BYDAY=MO, WE, FR; COUNT=10 |

### Monthly Frequency

| Description | Example |
|-------------|---------|
| Monthly recurring event that repeats on every 15th day of a month and never ends | FREQ=MONTHLY; BYMONTHDAY=15; INTERVAL=1 |
| Monthly recurring event that repeats on every 16th day of a month and ends after 10 occurrences | FREQ=MONTHLY; BYMONTHDAY=16; INTERVAL=1; COUNT=10 |
| Repeats every 17th day of a month and ends on 12/12/2020 | FREQ=MONTHLY; BYMONTHDAY=17; INTERVAL=1; UNTIL=20201212T041343Z |
| Repeats every 2nd Friday of a month and never ends | FREQ=MONTHLY; BYDAY=FR; BYSETPOS=2; INTERVAL=1 |
| Repeats every 4th Wednesday of a month and ends after 10 occurrences | FREQ=MONTHLY; BYDAY=WE; BYSETPOS=4; INTERVAL=1; COUNT=10 |
| Repeats every 4th Friday of a month and ends on 12/12/2020 | FREQ=MONTHLY; BYDAY=FR; BYSETPOS=4; INTERVAL=1; UNTIL=20201212T041343Z; |

### Yearly Frequency

| Description | Example |
|-------------|---------|
| Yearly event that repeats on every 15th day of December month and never ends | FREQ=YEARLY; BYMONTHDAY=15; BYMONTH=12; INTERVAL=1 |
| Event that repeats on every 10th day of December month and ends after 10 occurrences | FREQ=YEARLY; BYMONTHDAY=10; BYMONTH=12; INTERVAL=1; COUNT=10 |
| Repeats on every 12th day of December month and ends on 12/12/2025 | FREQ=YEARLY; BYMONTHDAY=12; BYMONTH=12; INTERVAL=1; UNTIL=20251212T041343Z |
| Repeats on every 3rd Friday of December month and never ends | FREQ=YEARLY; BYDAY=FR; BYMONTH=12; BYSETPOS=3; INTERVAL=1 |
| Repeats on every 3rd Tuesday of December month and ends after 10 occurrences | FREQ=YEARLY; BYDAY=TU; BYMONTH=12; BYSETPOS=3; INTERVAL=1; COUNT=10 |
| Repeats on every 4th Wednesday of December month and ends on 12/12/2028 | FREQ=YEARLY; BYDAY=WE; BYMONTH=12; BYSETPOS=4; INTERVAL=1; UNTIL=20281212T041343Z |

### Recurrence Validation

The built-in validation support has been added by default for recurring appointments during its creation, edit, drag and drop or resize action. The following are the possible validation alerts that displays on Scheduler while creating or editing the recurring events.

| Validation messages | Description |
|-------|---------|
| The recurrence pattern is not valid. | This alert will raise, when the selected recurrence rule value is not a valid one. For example, when you try to select the end date value (using `Until` option) for a recurring event, which occurs before the start date, an alert will popup out saying that the chosen pattern is invalid. |
| The changes made to specific instances of this series will be canceled and those events will match the series again. | This alert will raise, when you try to edit the whole series, whose occurrence might have been already edited. For example, If there are five occurrences and one of the occurrence is already edited. Now, when you try to edit the entire series, you will get this validation alert. |
| The duration of the event must be shorter than how frequently it occurs. Shorten the duration, or change the recurrence pattern in the recurrence event editor. | This validation will occur, if the event duration is longer than the selected frequency. For example, if you create a recurring appointment with two days duration in `Daily` frequency with no intervals set to it, you may get this alert. |
| Some months have fewer than the selected date. For these months, the occurrence will fall on the last date of the month. | When you try to create a recurring appointment on 31st of every month, where few months won’t have 31 days and in this scenario, you will get this alert. |
| Two occurrences of the same event cannot occur on the same day. | This validation will occur, when you try to edit or move any single occurrence to some other date, where another occurrence of the same event is already present. |

## Event fields

The Scheduler dataSource usually holds the event instances, where each of the instance includes a collection of appropriate [fields](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleField.html). It is mandatory to map these fields with the equivalent fields of database, when remote data is bound to it. When the local data is bound, then the field names defined within the instances needs to be mapped with the scheduler event fields correctly.

> To create an event on Scheduler, it is enough to define the `StartTime` and `EndTime` fields. In case, if remote data is bound to Scheduler, then `Id` field becomes mandatory to process the CRUD actions on appropriate events.

### Built-in fields

The built-in fields available on Scheduler event object are as follows.

| Field name | Description |
|-------|---------|
| Id | The `Id` field needs to be defined as mandatory, and usually assigns a unique ID value to each of the events.|
| Subject | The `Subject` field is optional, and usually assigns the summary text to each of the events.|
| StartTime | The `StartTime` field defines the start time of an event and it is mandatory to provide it for any of the valid event objects.|
| EndTime | The `EndTime` field defines the end time of an event and it is mandatory to provide the end time for any of the valid event objects.|
| StartTimezone | It maps the `StartTimezone` field from the dataSource and usually accepts the valid IANA timezone names. It is assumed that the value provided for this field is taken into consideration while processing the `StartTime` field. When this field is not mapped with any timezone names, then the events will be processed based on the timezone assigned to the Scheduler.|
| EndTimezone | It maps the `EndTimezone` field from the dataSource and usually accepts the valid IANA timezone names. It is assumed that the value provided for this field is taken into consideration while processing the `EndTime` field. When this field is not mapped with any timezone names, then the events will be processed based on the timezone assigned to the Scheduler.|
| Location | It maps the `Location` field from the dataSource and the location text value will be displayed over the events.|
| Description | It maps the `Description` field from the dataSource and denotes the event description which is optional.|
| IsAllDay | The `IsAllDay` field is mapped from the dataSource and is used to denote whether an event is created for an entire day or for specific time alone. Usually, an event with `IsAllDay` field set to true will be considered as an all-day event. |
| RecurrenceID | It maps the `RecurrenceID` field from dataSource and usually holds the ID value of the parent recurrence event. This field is applicable only for the edited occurrence events.|
| RecurrenceRule | It maps the `RecurrenceRule` field from dataSource and holds the recurrence rule value in a string format. Also, it uniquely identifies whether the event belongs to a recurring type or normal ones. |
| RecurrenceException | It maps the `RecurrenceException` field from dataSource and is used to hold the collection of exception dates, on which the recurring occurrences needs to be excluded. |
| IsReadonly | It maps the `IsReadonly` field from dataSource. It is mainly used to make specific appointments as readonly when set to `true`. |
| IsBlock | It maps the `IsBlock` field from dataSource. It is used to block the particular time ranges in the Scheduler and prevents the event creation on those time slots. |
| CssClass | It maps the `CssClass` field from the dataSource. It is used to customize the particular events. |

### Binding different field names

When the fields of event instances has the default mapping name, it is not mandatory to map them manually. If a Scheduler's dataSource holds the events collection with different field names, then it is necessary to map them with its equivalent field name within the `EventSettings` property.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="550px" @bind-SelectedDate="@CurrentDate">
    <ScheduleEventSettings DataSource="@DataSource">
        <ScheduleField Id="TravelId">
            <FieldSubject Name="TravelSummary"></FieldSubject>
            <FieldLocation Name="Source"></FieldLocation>
            <FieldDescription Name="Comments"></FieldDescription>
            <FieldIsAllDay Name="FullDay"></FieldIsAllDay>
            <FieldStartTime Name="DepartureTime"></FieldStartTime>
            <FieldEndTime Name="ArrivalTime"></FieldEndTime>
            <FieldStartTimezone Name="Origin"></FieldStartTimezone>
            <FieldEndTimezone Name="Destination"></FieldEndTimezone>
        </ScheduleField>
    </ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>

@code{
    DateTime CurrentDate = new DateTime(2020, 1, 10);
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData { TravelId = 1, TravelSummary = "Paris", DepartureTime = new DateTime(2020, 1, 10, 10, 0, 0) , ArrivalTime = new DateTime(2020, 1, 10, 12, 30, 0),
        Source = "London", Comments = "Summer vacation planned for outstation.", Origin= "Asia/Yekaterinburg", Destination= "Asia/Yekaterinburg" }
    };
    public class AppointmentData
    {
        public int TravelId { get; set; }
        public string TravelSummary { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public bool FullDay { get; set; }
        public string Source { get; set; }
        public string Comments { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
    }
}
```

> The mapper field `Id` is of string type and has no additional validation options, whereas all other fields has additional options.

### Event field settings

Each field of the Scheduler events are provided with additional settings such as options to set default value, to map with appropriate data source fields, to validate every event fields and to provide label values for those fields in the event window.

| Options | Description |
| ------- | ----------- |
| Default | Accepts the default value to the applicable fields (Subject, Location and Description), when no values are provided to them from dataSource. |
| Name | Accepts the field name to be mapped from the dataSource fields. |
| Title | Accepts the label values to be displayed for the fields of event editor. |
| Validation | Defines the validation rules to be applied on the event fields within the event editor. |

In following example, the Subject field in event editor will display its appropriate label as **Summary**. When no subject value is provided while saving an event, then the appointment will be saved with the default subject value as **Add Summary**.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="550px" @bind-SelectedDate="@CurrentDate">
    <ScheduleEventSettings TValue="AppointmentData" DataSource="@DataSource">
        <ScheduleField Id="Id">
            <FieldSubject Name="Subject" Title="Summary" Default="Add Summary"></FieldSubject>
            <FieldLocation Name="Location"></FieldLocation>
            <FieldDescription Name="Description"></FieldDescription>
            <FieldStartTime Name="StartTime"></FieldStartTime>
            <FieldEndTime Name="EndTime"></FieldEndTime>
        </ScheduleField>
    </ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>
@code{
    DateTime CurrentDate = new DateTime(2020, 1, 31);
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData { Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 1, 31, 9, 30, 0) , EndTime = new DateTime(2020, 1, 31, 11, 0, 0) }
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

## Adding Custom fields

Apart from the default Scheduler fields, the user can include 'n' number of custom fields for appointments. The following code example shows how to include two custom fields namely **Status** and **Priority** within event collection. It is not necessary to bind the custom fields within the `EventSettings`. However, those additional fields can be accessed easily, for internal processing as well as from application end.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="550px" @bind-SelectedDate="@CurrentDate">
    <ScheduleEventSettings DataSource="@DataSource">
    </ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>

@code{
    DateTime CurrentDate = new DateTime(2020, 1, 31);
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData { Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 1, 31, 9, 30, 0) , EndTime = new DateTime(2020, 1, 31, 11, 0, 0),
        Status = "Completed", Priority = "High"}
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
        public string Status { get; set; }
        public string Priority { get; set; }
    }
}
```

## Custom sorting of the appointments rendering

Apart from the default arrangement of the Scheduler events, the user can cusomly sorting the events based on the custom fields for appointments. The following code example shows how to sort the appointments based on the custom field **RankId** assigned to the `SortBy` property.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentSortData" Width="100%" EnableAutoRowHeight="true" @bind-SelectedDate="@CurrentDate" @bind-CurrentView="@SelectedView">
    <ScheduleEventSettings SortBy="RankId" DataSource="@DataSource"></ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.TimelineDay"></ScheduleView>
        <ScheduleView Option="View.TimelineWeek"></ScheduleView>
        <ScheduleView Option="View.TimelineWorkWeek"></ScheduleView>
        <ScheduleView Option="View.TimelineMonth"></ScheduleView>
    </ScheduleViews>
</SfSchedule>

@code{
    DateTime CurrentDate = new DateTime(2020, 2, 14);
    View SelectedView = View.Week;
    List<AppointmentSortData>
    DataSource = new List<AppointmentSortData>
    {
        new AppointmentSortData { Id = 1, Subject = "Rank A", RankId="A", StartTime = new DateTime(2020, 2, 13, 10, 0, 0) , EndTime = new DateTime(2020, 2, 13, 12, 0, 0) },
        new AppointmentSortData { Id = 2, Subject = "Rank B", RankId="B", StartTime = new DateTime(2020, 2, 13, 7, 0, 0) , EndTime = new DateTime(2020, 2, 13, 15, 0, 0) },
        new AppointmentSortData { Id = 3, Subject = "Rank C", RankId="C", StartTime = new DateTime(2020, 2, 13, 9, 0, 0) , EndTime = new DateTime(2020, 2, 13, 10, 30, 0) },
        new AppointmentSortData { Id = 4, Subject = "Rank D", RankId="D", StartTime = new DateTime(2020, 2, 13, 9, 30, 0) , EndTime = new DateTime(2020, 2, 13, 14, 0, 0) }
    };
    public class AppointmentSortData : AppointmentData
    {
        public string RankId { get; set; }
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
        public Nullable<int> RecurrenceID { get; set; }
        public string RankId { get; set; }
    }
}
```

## Drag and drop appointments

Appointments can be rescheduled to any time by dragging and dropping them onto the desired location. To work with drag and drop functionality make sure that `AllowDragAndDrop` is set to **true** on Scheduler. In mobile mode, you can drag and drop the events by tap holding an event and dropping them on to the desired location.

> By default, drag and drop action is applicable on all Scheduler views, except Agenda and Month-Agenda view.

To get start quickly about drag options available in our Scheduler, you can check on this video:

{% youtube
"youtube:https://www.youtube.com/watch?v=Vtl1Wyuwt-0"%}

### Drag and drop multiple appointments

We can drag and drop multiple appointments by enabling the `AllowMultiDrag` property. We can select multiple appointments by holding the CTRL key. Once the events are selected, we can leave the CTRL key and start dragging the event.

We can also drag multiple events from one resource to another resource. In this case, if all the selected events are in the different resources, then all the events should be moved to the single resource that is related to the target event.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="550px" AllowMultiDrag="true" @bind-SelectedDate="@CurrentDate">
    <ScheduleEventSettings DataSource="@DataSource"></ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>

@code{
    DateTime CurrentDate = new DateTime(2020, 1, 31);
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData{ Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 1, 31, 9, 30, 0) , EndTime = new DateTime(2020, 1, 31, 11, 0, 0)},
        new AppointmentData{ Id = 2, Subject = "Testing", StartTime = new DateTime(2020, 1, 31, 12, 0, 0) , EndTime = new DateTime(2020, 1, 31, 13, 0, 0)}
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

### Disable the drag action

By default, you can drag and drop the events within any of the applicable scheduler views, and to disable it, set **false** to the `AllowDragAndDrop` property.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="550px" AllowDragAndDrop="false" @bind-SelectedDate="@CurrentDate">
    <ScheduleEventSettings DataSource="@DataSource"></ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>

@code{
    DateTime CurrentDate = new DateTime(2020, 1, 31);
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData{ Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 1, 31, 9, 30, 0) , EndTime = new DateTime(2020, 1, 31, 11, 0, 0)}
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

### Preventing drag and drop on specific targets

It is possible to prevent the drag action on particular target, by passing the target to be excluded in the `ExcludeSelectors` option within `OnDragStart` event. In this example, we have prevented the drag action on all-day row.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="550px" @bind-SelectedDate="@CurrentDate">
    <ScheduleEvents TValue="AppointmentData" OnDragStart="OnAppointmentDrag"></ScheduleEvents>
    <ScheduleEventSettings DataSource="@DataSource"></ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>

@code{
    DateTime CurrentDate = new DateTime(2020, 1, 31);
    public void OnAppointmentDrag(DragEventArgs<AppointmentData> args)
    {
        args.ExcludeSelectors = "e-header-cells,e-all-day-cells";
    }
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData{ Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 1, 31, 9, 30, 0) , EndTime = new DateTime(2020, 1, 31, 11, 0, 0)}
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

### Disable scrolling on drag action

By default, while dragging an appointment to the edges, either top/bottom in the vertical Scheduler or left/right in the timeline Scheduler, scrolling action takes place automatically. To prevent this scrolling, set `false` to the `Scroll` value within the `OnDragStart` event arguments.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="550px" SelectedDate="@CurrentDate">
    <ScheduleEvents TValue="AppointmentData" OnDragStart="OnAppointmentDrag"></ScheduleEvents>
    <ScheduleEventSettings DataSource="@DataSource"></ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>

@code{
    DateTime CurrentDate = new DateTime(2020, 1, 31);
    public void OnAppointmentDrag(DragEventArgs<AppointmentData> args)
    {
        args.Scroll.Enable = false;
    }
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData{ Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 1, 31, 9, 30, 0) , EndTime = new DateTime(2020, 1, 31, 11, 0, 0)}
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

### Controlling scroll speed while dragging an event

The speed of the scrolling action while dragging an appointment to the Scheduler edges, can be controlled within the `OnDragStart` event by setting the desired value to the `ScrollBy` and `TimeDelay` option whereas its default value is 30 minutes and 100ms.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="550px" @bind-SelectedDate="@CurrentDate">
    <ScheduleEvents TValue="AppointmentData" OnDragStart="OnAppointmentDrag"></ScheduleEvents>
    <ScheduleEventSettings DataSource="@DataSource"></ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>

@code{
    DateTime CurrentDate = new DateTime(2020, 1, 31);
    public void OnAppointmentDrag(DragEventArgs<AppointmentData> args)
    {
        args.Scroll.ScrollBy = 5;
        args.Scroll.TimeDelay = 200;
    }
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData{ Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 1, 31, 9, 30, 0) , EndTime = new DateTime(2020, 1, 31, 11, 0, 0)}
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

### Auto navigation of date ranges on dragging an event

When an event is dragged either to the left or right extreme edges of the Scheduler and kept hold for few seconds without dropping, the auto navigation of date ranges will be enabled allowing the Scheduler to navigate from current date range to back and forth respectively. This action is set to `false` by default and to enable it, you need to set `Navigation` to true within the `OnDragStart` event.

By default, the navigation delay is set to 2000ms. The navigation delay decides how long the user needs to drag and hold the appointments at the extremities. You can also set your own delay value for letting the users to navigate based on it, using the `TimeDelay` within the `OnDragStart` event.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="550px" @bind-SelectedDate="@CurrentDate">
    <ScheduleEvents TValue="AppointmentData" OnDragStart="OnAppointmentDrag"></ScheduleEvents>
    <ScheduleEventSettings DataSource="@DataSource"></ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>

@code{
    DateTime CurrentDate = new DateTime(2020, 1, 31);
    public void OnAppointmentDrag(DragEventArgs<AppointmentData> args)
    {
        args.Navigation.Enable = true;
        args.Navigation.TimeDelay = 4000;
    }
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData{ Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 1, 31, 9, 30, 0) , EndTime = new DateTime(2020, 1, 31, 11, 0, 0)}
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

### Setting drag time interval

By default, while dragging an appointment, it moves at an interval of 30 minutes. To change the dragging time interval, pass the appropriate values to the `Interval` option within the `OnDragStart` event.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="550px" @bind-SelectedDate="@CurrentDate">
    <ScheduleEvents TValue="AppointmentData" OnDragStart="OnAppointmentDrag"></ScheduleEvents>
    <ScheduleEventSettings DataSource="@DataSource"></ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>

@code{
    DateTime CurrentDate = new DateTime(2020, 1, 31);
    public void OnAppointmentDrag(DragEventArgs<AppointmentData> args)
    {
        args.Interval = 10;
    }
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData{ Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 1, 31, 9, 30, 0) , EndTime = new DateTime(2020, 1, 31, 11, 0, 0)}
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

### Drag and drop items from external source

It is possible to drag and drop the unplanned items from any of the external source into the scheduler, by manually saving those dropped item as a new appointment data through `AddEventAsync` method of Scheduler.

To get start quickly about dropping items from external source to our Scheduler, you can check on this video:

{% youtube
"youtube:https://www.youtube.com/watch?v=QxBBZYef6cg"%}

In this example, we have used the tree view control as an external source and the child nodes from the tree view component are dragged and dropped onto the Scheduler. Therefore, it is necessary to make use of the `OnNodeDragStop` event of the TreeView component, where we can form an event object and save it using the `AddEventAsync` method.

```cshtml
@using Syncfusion.Blazor.Schedule
@using Syncfusion.Blazor.Navigations

<div class="row">
    <div class="col-lg-8 e-droppable">
        <SfSchedule @ref="ScheduleRef" TValue="AppointmentData" Height="650px" @bind-SelectedDate="@CurrentDate">
            <ScheduleGroup Resources="@GroupData"></ScheduleGroup>
            <ScheduleResources>
                <ScheduleResource TItem="ResourceData" TValue="int" DataSource="@Consultants" Field="ConsultantID" Title="Consultant" Name="Consultants" TextField="Text" IdField="Id" ColorField="Color"></ScheduleResource>
            </ScheduleResources>
            <ScheduleEventSettings DataSource="@DataSource">
            </ScheduleEventSettings>
            <ScheduleViews>
                <ScheduleView Option="View.Day"></ScheduleView>
                <ScheduleView Option="View.Week"></ScheduleView>
                <ScheduleView Option="View.WorkWeek"></ScheduleView>
                <ScheduleView Option="View.Month"></ScheduleView>
                <ScheduleView Option="View.Agenda"></ScheduleView>
            </ScheduleViews>
        </SfSchedule>
    </div>
    <div class="col-lg-4">
        <h3>Waiting list</h3>
        <SfTreeView TValue="EmployeeData" AllowDragAndDrop="true">
            <TreeViewFieldsSettings DataSource="@WaitingListData" Id="Id" Text="Name"></TreeViewFieldsSettings>
            <TreeViewEvents TValue="EmployeeData" OnNodeDragStop="DragStop"></TreeViewEvents>
        </SfTreeView>
    </div>
</div>

@code{
    DateTime CurrentDate = new DateTime(2020, 1, 31);
    SfSchedule<AppointmentData> ScheduleRef;
    public string[] GroupData = new string[] { "Consultants" };
    public List<ResourceData> Consultants { get; set; } = new List<ResourceData> {
    new ResourceData { Text = "Margaret", Id = 1, Color = "#1aaa55" },
    new ResourceData { Text = "Robert", Id = 2, Color = "#357cd2" },
    new ResourceData { Text = "Laura", Id = 3, Color = "#7fa900" },
    new ResourceData { Text = "Robson", Id = 4, Color = "#9e5fff" },
    new ResourceData { Text = "Laura", Id = 5, Color = "#bbdc00" }
    };
    public List<EmployeeData> WaitingListData { get; set; } = new List<EmployeeData>() {
    new EmployeeData { Id = 1, Name = "Johnson" },
    new EmployeeData { Id = 2, Name = "Sourav" },
    new EmployeeData { Id = 3,  Name = "Sanjay" }
    };
    List<AppointmentData> DataSource = new List<AppointmentData>
{
    new AppointmentData{ Id = 1, Subject = "General-Check up", StartTime = new DateTime(2020, 1, 31, 9, 30, 0) , EndTime = new DateTime(2020, 1, 31, 11, 0, 0), ConsultantID=1 }
    };

    async void DragStop(DragAndDropEventArgs args)
    {
        args.Cancel = true;
        CellClickEventArgs cellData = await ScheduleRef.GetTargetCellAsync((int)args.Left, (int)args.Top);
        if (cellData != null)
        {
            var resourceDetails = ScheduleRef.GetResourceByIndex(cellData.GroupIndex);
            Random rnd = new Random();
            AppointmentData eventData = new AppointmentData
            {
                Id = rnd.Next(1000),
                Subject = args.DraggedNodeData.Text,
                StartTime = cellData.StartTime,
                EndTime = cellData.EndTime,
                IsAllDay = cellData.IsAllDay,
                ConsultantID = resourceDetails.GroupData.ConsultantID,
            };
            await ScheduleRef.OpenEditorAsync(eventData, CurrentAction.Add);
        }
    }

    public class AppointmentData
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string RecurrenceRule { get; set; }
        public Nullable<int> RecurrenceID { get; set; }
        public string RecurrenceException { get; set; }
        public bool? IsAllDay { get; set; }
        public Nullable<int> ConsultantID { get; set; }
    }
    public class EmployeeData
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class ResourceData
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Color { get; set; }
    }
}
```

### Drag and drop items to external source

You can drag and drop the events to external source by setting the target to the property `EventDragArea`. In the following code example, we have two Scheduler and events from the first scheduler can be dropped to second scheduler. In the `Dragged` event of the first scheduler, the dragged event has been deleted from the first scheduler and added to the second scheduler.

```cshtml
@using Syncfusion.Blazor.Schedule

<div class="row">
    <div class="col-lg-6">
        <SfSchedule @ref="Schedule1Ref" Height="550px" TValue="AppointmentData" EventDragArea=".ScheduleClass" @bind-SelectedDate="@CurrentDate">
            <ScheduleEvents TValue="AppointmentData" Dragged="OnDragged"></ScheduleEvents>
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
        <SfSchedule @ref="Schedule2Ref" Height="550px" TValue="AppointmentData" CssClass="ScheduleClass" SelectedDate="@(new DateTime(2020, 1, 6))">
            <ScheduleViews>
                <ScheduleView Option="View.Day"></ScheduleView>
                <ScheduleView Option="View.Week"></ScheduleView>
                <ScheduleView Option="View.WorkWeek"></ScheduleView>
                <ScheduleView Option="View.Month"></ScheduleView>
                <ScheduleView Option="View.Agenda"></ScheduleView>
            </ScheduleViews>
        </SfSchedule>
    </div>
</div>


@code {
    DateTime CurrentDate = new DateTime(2020, 1, 6);
    SfSchedule<AppointmentData> Schedule1Ref;
    SfSchedule<AppointmentData> Schedule2Ref;
    List<AppointmentData> ScheduleData = new List<AppointmentData>
    {
        new AppointmentData { Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 1, 6, 9, 30, 0) , EndTime = new DateTime(2020, 1, 6, 11, 0, 0)}
    };
    public async Task OnDragged(DragEventArgs<AppointmentData> args)
    {
        await Schedule1Ref.DeleteEventAsync(args.Data.Id);
        Random random = new Random();
        args.Data.Id = Convert.ToInt32(random.Next());
        await Schedule2Ref.AddEventAsync(args.Data);
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
        public bool IsReadonly { get; set; }
        public string RecurrenceRule { get; set; }
        public Nullable<int> RecurrenceID { get; set; }
        public string RecurrenceException { get; set; }
        public string StartTimezone { get; set; }
        public string EndTimezone { get; set; }
    }
}
```

### Opening the editor window on drag stop

There are scenarios where you want to open the editor filled with data on newly dropped location and may need to proceed to save it, only when `Save` button is clicked on the editor. On clicking the cancel button should revert these changes. This can be achieved using the `Dragged` event of Scheduler.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" @ref="ScheduleRef" Height="550px" @bind-SelectedDate="@CurrentDate">
    <ScheduleEvents TValue="AppointmentData" Dragged="OnAppointmentDragStop"></ScheduleEvents>
    <ScheduleEventSettings DataSource="@DataSource"></ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>

@code{
    DateTime CurrentDate = new DateTime(2020, 1, 31);
    SfSchedule<AppointmentData> ScheduleRef;
    public async Task OnAppointmentDragStop(DragEventArgs<AppointmentData> args)
    {
        args.Cancel = true;
        await this.ScheduleRef.OpenEditorAsync(args.Data, CurrentAction.Save);
    }
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData{ Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 1, 31, 9, 30, 0) , EndTime = new DateTime(2020, 1, 31, 11, 0, 0)}
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

## Appointment Resizing

Another way of rescheduling an appointment can be done by resizing it through either of its handlers. To work with resizing functionality make sure that `AllowResizing` property is set to **true**.

To get start quickly about resize options available in our Scheduler, you can check on this video:

{% youtube
"youtube:https://www.youtube.com/watch?v=Vtl1Wyuwt-0"%}

### Disable the resize action

By default, resizing of events is allowed on all Scheduler views except Agenda and Month-Agenda view. To disable this event resizing action, set false to the `AllowResizing` property.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="550px" AllowResizing="false" @bind-SelectedDate="@CurrentDate">
    <ScheduleEventSettings DataSource="@DataSource"></ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>

@code{
    DateTime CurrentDate = new DateTime(2020, 1, 31);
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData { Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 1, 31, 9, 30, 0) , EndTime = new DateTime(2020, 1, 31, 11, 0, 0)}
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

### Disable scrolling on resize action

By default, while resizing an appointment, when its handler reaches the extreme edges of the Scheduler, scrolling action will takes place along with event resizing. To prevent this scrolling action, set false to `Scroll` value within the `OnResizeStart` event.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="550px" @bind-SelectedDate="@CurrentDate">
    <ScheduleEvents TValue="AppointmentData" OnResizeStart="OnAppointmentResize"></ScheduleEvents>
    <ScheduleEventSettings DataSource="@DataSource"></ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>

@code{
    DateTime CurrentDate = new DateTime(2020, 1, 31);
    public void OnAppointmentResize(ResizeEventArgs<AppointmentData> args)
    {
        args.Scroll.Enable = false;
    }
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData { Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 1, 31, 9, 30, 0) , EndTime = new DateTime(2020, 1, 31, 11, 0, 0)}
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

### Controlling scroll speed while resizing an event

The speed of the scrolling action while resizing an appointment to the Scheduler edges, can be controlled within the `OnResizeStart` event by setting the desired value to the `ScrollBy` option.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="550px" @bind-SelectedDate="@CurrentDate">
    <ScheduleEvents TValue="AppointmentData" OnResizeStart="OnAppointmentResize"></ScheduleEvents>
    <ScheduleEventSettings DataSource="@DataSource"></ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>

@code{
    DateTime CurrentDate = new DateTime(2020, 1, 31);
    public void OnAppointmentResize(ResizeEventArgs<AppointmentData> args)
    {
        args.Scroll.ScrollBy = 15;
    }
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData { Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 1, 31, 9, 30, 0) , EndTime = new DateTime(2020, 1, 31, 11, 0, 0)}
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

### Setting resize time interval

By default, while resizing an appointment, it extends or shrinks at an interval of 30 minutes. To change this default resize interval, set appropriate values to `Interval` option within the `OnResizeStart` event.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="550px" @bind-SelectedDate="@CurrentDate">
    <ScheduleEvents TValue="AppointmentData" OnResizeStart="OnAppointmentResize"></ScheduleEvents>
    <ScheduleEventSettings DataSource="@DataSource"></ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>

@code{
    DateTime CurrentDate = new DateTime(2020, 1, 31);
    public void OnAppointmentResize(ResizeEventArgs<AppointmentData> args)
    {
        args.Interval = 10;
    }
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData { Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 1, 31, 9, 30, 0) , EndTime = new DateTime(2020, 1, 31, 11, 0, 0)}
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

## Appointment customization

The look and feel of the Scheduler events can be customized using any one of the following ways.

* [Using event template](#using-template)
* [Using EventRendered event](#using-eventrendered-event)
* [Using CssClass property](#using-cssclass)

### Using template

Any kind of text, images and links can be added to customize the look of the events. The user can format and change the default appearance of the events by making use of the `Template` option available within the `ScheduleEventSettings` tag helper. 

To get start quickly on customizing events using template, you can check on this video:

{% youtube
"youtube:https://www.youtube.com/watch?v=8kBXcBjL12A"%}

The following code example customizes the appointment.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="650px" @bind-SelectedDate="@CurrentDate">
    <ScheduleEventSettings DataSource="@DataSource">
        <Template>
            <div>Subject: @((context as AppointmentData).Subject)</div>
            <div>StartTime: @((context as AppointmentData).StartTime)</div>
            <div>EndTime:  @((context as AppointmentData).EndTime)</div>
        </Template>
    </ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>
@code {
    DateTime CurrentDate = new DateTime(2020, 1, 31);
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData { Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 1, 31, 9, 30, 0) , EndTime = new DateTime(2020, 1, 31, 11, 0, 0) }
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

> All the built-in fields that are mapped to the appropriate field properties within the `ScheduleEventSettings`, as well as custom mapped fields from the Scheduler dataSource can be accessed within the template code.

### Using EventRendered event

The `EventRendered` event triggers before the appointment renders on the Scheduler. Therefore, this event can be utilized to customize the look of events based on any specific criteria, before rendering them on the scheduler.

In the following code example, the custom class has been added to events using `CssClasses` to apply color to the events.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="650px" @bind-SelectedDate="@CurrentDate">
    <ScheduleEvents TValue="AppointmentData" EventRendered="OnEventRendered"></ScheduleEvents>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
    </ScheduleViews>
    <ScheduleEventSettings DataSource="@DataSource"></ScheduleEventSettings>
</SfSchedule>
@code {
    DateTime CurrentDate = new DateTime(2020, 1, 31);
    public List<string> CustomClass = new List<string>()  { "custom-class" } ;
    public void OnEventRendered(EventRenderedArgs<AppointmentData> args)
    {
        args.CssClasses = CustomClass;
    }
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData{ Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 1, 31, 9, 30, 0) , EndTime = new DateTime(2020, 1, 31, 11, 0, 0) }
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
<style>
    .e-schedule .e-vertical-view .e-all-day-appointment-wrapper .e-appointment.custom-class,
    .e-schedule .e-vertical-view .e-day-wrapper .e-appointment.custom-class,
    .e-schedule .e-month-view .e-appointment.custom-class {
        background: #32CD32;
    }
</style>
```

Also, we can customize the events by adding or modifying its element attribute using `Attributes`. In the following code example, event attributes have been modified through the `Attributes` to apply color to the events.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="650px" @bind-SelectedDate="@CurrentDate">
    <ScheduleEvents TValue="AppointmentData" EventRendered="OnEventRendered"></ScheduleEvents>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
    </ScheduleViews>
    <ScheduleEventSettings DataSource="@DataSource"></ScheduleEventSettings>
</SfSchedule>
@code {
    DateTime CurrentDate = new DateTime(2020, 1, 31);
    public List<string> CustomClass = new List<string>() { "custom-class" };
    public void OnEventRendered(EventRenderedArgs<AppointmentData> args)
    {
        Dictionary<string, object> attributes = new Dictionary<string, object>();
        attributes.Add("style", "background: green");
        args.Attributes = attributes;
    }
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData{ Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 1, 31, 9, 30, 0) , EndTime = new DateTime(2020, 1, 31, 11, 0, 0) }
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

### Using CssClass

The customization of events can also be achieved using the built-in field `CssClass` in which you can pass the class name to be applied to specific appointments. In the following example, the background of appointments has been changed.

```cshtml
@using Syncfusion.Blazor.Schedule

@using Syncfusion.Blazor.Schedule
<SfSchedule TValue="AppointmentData" Height="650px" @bind-SelectedDate="@CurrentDate">
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
    </ScheduleViews>
    <ScheduleEventSettings DataSource="@DataSource"></ScheduleEventSettings>
</SfSchedule>
@code {
    DateTime CurrentDate = new DateTime(2020, 1, 31);
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData{ Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 1, 31, 9, 30, 0) , EndTime = new DateTime(2020, 1, 31, 11, 0, 0), CssClass = "progress" },
        new AppointmentData{ Id = 2, Subject = "Meeting-postponed", StartTime = new DateTime(2020, 1, 28, 9, 30, 0) , EndTime = new DateTime(2020, 1, 28, 11, 0, 0), CssClass = "delayed" }
    };

    public class AppointmentData
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public string CssClass { get; set; }
        public bool IsAllDay { get; set; }
        public string RecurrenceRule { get; set; }
        public string RecurrenceException { get; set; }
        public Nullable<int> RecurrenceID { get; set; }
    }
}
<style>
    .e-schedule .e-vertical-view .e-all-day-appointment-wrapper .e-appointment.progress,
    .e-schedule .e-vertical-view .e-day-wrapper .e-appointment.progress,
    .e-schedule .e-month-view .e-appointment.progress {
        background: #32CD32;
    }

    .e-schedule .e-vertical-view .e-all-day-appointment-wrapper .e-appointment.delayed,
    .e-schedule .e-vertical-view .e-day-wrapper .e-appointment.delayed,
    .e-schedule .e-month-view .e-appointment.delayed {
        background: #CD5C5C;
    }
</style>
```

Also, the customization of events can be achieved using `CssClass` property of the Scheduler. In the following example, the background of appointments has been changed using the CssClass.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="550px" CssClass="custom-class" @bind-SelectedDate="@CurrentDate">
    <ScheduleEventSettings DataSource="@DataSource"></ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>

@code{
    DateTime CurrentDate = new DateTime(2020, 1, 31);
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData { Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 1, 31, 9, 30, 0) , EndTime = new DateTime(2020, 1, 31, 11, 0, 0) }
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

<style>
    .custom-class.e-schedule .e-vertical-view .e-all-day-appointment-wrapper .e-appointment,
    .custom-class.e-schedule .e-vertical-view .e-day-wrapper .e-appointment,
    .custom-class.e-schedule .e-month-view .e-appointment {
        background: #32CD32;
    }
</style>
```

> We can't customize the events using the styles that are `height`, `width`, `top`, `left`, `right`, and `display`.

## Block Date and Time

It is possible to block a set of dates or a particular time ranges on the Scheduler. To do so, define an appointment object within `EventSettings` along with the required time range to block and set the `IsBlock` field to **true**. Usually, the event objects defined with `IsBlock` field set to true will block the entire time cells lying within the appropriate time ranges specified through `StartTime` and `EndTime` fields.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="550px" @bind-SelectedDate="@CurrentDate">
    <ScheduleEventSettings DataSource="@DataSource"></ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>

@code{
    DateTime CurrentDate = new DateTime(2020, 1, 31);
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData { Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 1, 31, 9, 30, 0) , EndTime = new DateTime(2020, 1, 31, 11, 0, 0),
        IsBlock = true }
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
        public bool IsBlock { get; set; }
        public string RecurrenceRule { get; set; }
        public string RecurrenceException { get; set; }
        public Nullable<int> RecurrenceID { get; set; }
    }
}
```

Block events can also be defined to repeat on several days as shown in the following code example.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="550px" @bind-SelectedDate="@CurrentDate">
    <ScheduleEventSettings DataSource="@DataSource"></ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>

@code{
    DateTime CurrentDate = new DateTime(2020, 1, 31);
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData { Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 1, 31, 9, 30, 0) , EndTime = new DateTime(2020, 1, 31, 11, 0, 0),
        IsBlock = true, RecurrenceRule = "FREQ=DAILY;INTERVAL=1;COUNT=5" }
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
        public bool IsBlock { get; set; }
        public string RecurrenceRule { get; set; }
        public string RecurrenceException { get; set; }
        public Nullable<int> RecurrenceID { get; set; }
    }
}
```

## Readonly

An interaction with the appointments of Scheduler can be enabled/disabled using the `Readonly` property. With this property enabled, you can simply navigate between the Scheduler dates, views and can be able to view the appointment details in the quick info window. Most importantly, the users are not allowed to perform any CRUD actions on Scheduler, when this property is set to true. By default, it is set as **false**.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="550px" Readonly="true" @bind-SelectedDate="@CurrentDate">
    <ScheduleEventSettings DataSource="DataSource"></ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>

@code{
    DateTime CurrentDate = new DateTime(2020, 1, 31);
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData { Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 1, 31, 9, 30, 0) , EndTime = new DateTime(2020, 1, 31, 11, 0, 0) }
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

## Make specific events readonly

There are scenarios where you need to restrict the CRUD action on specific appointments alone based on certain conditions. In the following example, the events that has occurred on the past hours from the current date of the Scheduler are made as read-only and the CRUD actions has been prevented only on those appointments. This can be achieved by setting `IsReadonly` field of read-only events to `true`.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="550px" @bind-SelectedDate="@CurrentDate">
    <ScheduleEventSettings DataSource="DataSource"> </ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>

@code{
    DateTime CurrentDate = new DateTime(2020, 1, 31);
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData { Id = 1, Subject = "Paris", StartTime = new DateTime(2020, 1, 28, 10, 0, 0) , EndTime = new DateTime(2020, 1, 28, 12, 0, 0),
        IsReadonly = true },
        new AppointmentData { Id = 2, Subject = "Germany", StartTime = new DateTime(2020, 1, 31, 10, 0, 0) , EndTime = new DateTime(2020, 1, 31, 12, 0, 0) }
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
        public bool IsReadonly { get; set; }
        public string RecurrenceRule { get; set; }
        public string RecurrenceException { get; set; }
        public Nullable<int> RecurrenceID { get; set; }
    }
}
```

> By default, the event editor is prevented to open on the read-only events when `IsReadonly` field is set to **true**.

## Differentiate the past time events

To differentiate the appearance of the appointments based on specific criteria such as displaying the past hour appointments with different colors on Scheduler, `EventRendered` event can be used which triggers before the appointment renders on the Scheduler.

In the following code example, the appointments beyond current date of the scheduler were differentiated with chocolate brown color.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Width="100%" Height="550px" @bind-SelectedDate="@SelectedDate">
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
    </ScheduleViews>
    <ScheduleEvents TValue="AppointmentData" EventRendered="OnEventRendered"></ScheduleEvents>
    <ScheduleEventSettings DataSource="@DataSource"></ScheduleEventSettings>
</SfSchedule>

@code{
    public DateTime SelectedDate = new DateTime(2020,1,10);
    public List<string> CustomClass = new List<string>() { "e-past-app" };
    public void OnEventRendered(EventRenderedArgs<AppointmentData> args)
    {
        if(args.Data.StartTime < SelectedDate)
        {
            args.CssClasses = CustomClass;
        }
    }
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData { Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 1, 10, 9, 30, 0) , EndTime = new DateTime(2020, 1, 10, 11, 0, 0) },
        new AppointmentData { Id = 1, Subject = "Conference", StartTime = new DateTime(2020, 1, 9, 11, 30, 0) , EndTime = new DateTime(2020, 1, 9, 13, 0, 0) }
    };
    public class AppointmentData
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
<style>
    .e-schedule .e-vertical-view .e-day-wrapper .e-appointment.e-past-app, .e-schedule .e-month-view .e-appointment.e-past-app{
        background-color: chocolate;
    }
</style>
```

## Appointments occupying entire cell

The Scheduler allows the event to occupies the full height of the cell without its header part by setting `true` for `EnableMaxHeight` Property.

We can show more indicator if more than one appointment is available in a same cell by setting `true` to `EnableIndicator` property whereas its default value is false.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Width="100%" Height="550px" SelectedDate="@(new DateTime(2020, 3, 11))" CurrentView="View.Month">
    <ScheduleViews>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.TimelineWeek"></ScheduleView>
        <ScheduleView Option="View.TimelineMonth"></ScheduleView>
    </ScheduleViews>
    <ScheduleEventSettings DataSource="@DataSource" EnableMaxHeight="true" EnableIndicator="true"></ScheduleEventSettings>
</SfSchedule>

@code{
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData { Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 3, 11, 9, 30, 0) , EndTime = new DateTime(2020, 3, 11, 11, 0, 0) },
        new AppointmentData { Id = 2, Subject = "Conference", StartTime = new DateTime(2020, 3, 11, 9, 30, 0) , EndTime = new DateTime(2020, 3, 11, 11, 0, 0) }
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

> The `EnableIndicator` property will work, Only when the `EnableMaxHeight` property value is set to true.

## Display tooltip for appointments

The tooltip shows the Scheduler appointment's information in a formatted style by making use of the tooltip related options.

### Show or hide built-in tooltip

The tooltip can be displayed for appointments by setting `true` to the `EnableTooltip` option within the `ScheduleEventSettings` tag helper.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="550px" @bind-SelectedDate="@CurrentDate">
    <ScheduleEventSettings DataSource="@DataSource" EnableTooltip="true"></ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>

@code{
    DateTime CurrentDate = new DateTime(2020, 1, 10);
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData { Id = 1, Subject = "Paris", StartTime = new DateTime(2020, 1, 8, 10, 0, 0) , EndTime = new DateTime(2020, 1, 8, 12, 0, 0),
        IsReadonly = true },
        new AppointmentData { Id = 2, Subject = "Germany", StartTime = new DateTime(2020, 1, 10, 10, 0, 0) , EndTime = new DateTime(2020, 1, 10, 12, 0, 0) }
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
        public bool IsReadonly { get; set; }
        public string RecurrenceRule { get; set; }
        public string RecurrenceException { get; set; }
        public Nullable<int> RecurrenceID { get; set; }
    }
}
```

### Customizing event tooltip using template

After enabling the default tooltip, it is possible to customize the display of needed event information on tooltip by making use of the `TooltipTemplate` option within the `ScheduleEventSettings`.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="550px" @bind-SelectedDate="@CurrentDate">
    <ScheduleEventSettings DataSource="@DataSource" EnableTooltip="true">
        <TooltipTemplate>
            <div class="tooltip-wrap">
                <div>@((context as AppointmentData).Subject)</div>
                <div>From&nbsp;:&nbsp;@((context as AppointmentData).StartTime)</div>
                <div>To&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;@((context as AppointmentData).EndTime) </div>
            </div>
        </TooltipTemplate>
    </ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>

@code{
    DateTime CurrentDate = new DateTime(2020, 1, 13);
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData { Id = 1, Subject = "Paris", StartTime = new DateTime(2020, 1, 14, 10, 0, 0) , EndTime = new DateTime(2020, 1, 14, 12, 0, 0) },
        new AppointmentData { Id = 2, Subject = "Germany", StartTime = new DateTime(2020, 1, 15, 10, 0, 0) , EndTime = new DateTime(2020, 1, 15, 12, 0, 0) }
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

> All the field names that are mapped from the Scheduler dataSource to the appropriate field properties such as subject, description, location, startTime and endTime within the `ScheduleEventSettings` can be accessed within the template.

## Appointment filtering

The appointments can be filtered by passing the predicate value to `Query` option in `ScheduleEventSettings`. The following code example shows how to filter and render the selected appointments alone in the Scheduler.

```cshtml
@using Syncfusion.Blazor.Schedule
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Buttons

<SfCheckBox TChecked="bool" @bind-Checked="MargretChecked" Value="@MargretId" ValueChange="@OnChange" Label="Margaret" CssClass="margaret"></SfCheckBox>
<SfCheckBox TChecked="bool" @bind-Checked="RobertChecked" Value="@RobertId" ValueChange="@OnChange" Label="Robert" CssClass="robert"></SfCheckBox>
<SfCheckBox TChecked="bool" @bind-Checked="LauraChecked" Value="@LauraId" ValueChange="@OnChange" Label="Laura" CssClass="laura"></SfCheckBox>

<SfSchedule TValue="AppointmentData" CssClass='schedule-resource' Width="100%" Height="650px" @bind-SelectedDate="@CurrentDate">
    <ScheduleResources>
        <ScheduleResource TValue="int[]" TItem="ResourceData" DataSource="@OwnersData" Field="OwnerId" Title="Owners" Name="Owners" TextField="OwnerText" IdField="OwnerId" ColorField="Color" AllowMultiple="true"></ScheduleResource>
    </ScheduleResources>
    <ScheduleEventSettings DataSource="@DataSource" Query="@ScheduleQuery"></ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>

@code{
    public DateTime CurrentDate { get; set; } = new DateTime(2020, 6, 5);
    public bool MargretChecked { get; set; } = true;
    public bool RobertChecked { get; set; } = true;
    public bool LauraChecked { get; set; } = true;

    public string MargretId { get; set; } = "1";
    public string RobertId { get; set; } = "2";
    public string LauraId { get; set; } = "3";

    public dynamic predicate;
    public Query ScheduleQuery { get; set; } = null;

    List<AppointmentData> DataSource = new List<AppointmentData>
{
        new AppointmentData {
            Id = 1,
            Subject = "Burning Man",
            StartTime = new DateTime(2020, 5, 29, 15, 0, 0),
            EndTime = new DateTime(2020, 5, 29, 17, 0, 0),
            OwnerId = 1},
        new AppointmentData{
            Id = 2,
            Subject = "Marketing Forum",
            StartTime = new DateTime(2020, 5, 31, 10, 0, 0),
            EndTime = new DateTime(2020, 5, 31, 11, 30, 0),
            OwnerId = 2},
        new AppointmentData{
            Id = 3,
            Subject = "Business Factory",
            StartTime = new DateTime(2020, 5, 31, 13, 30, 0),
            EndTime = new DateTime(2020, 5, 31, 15, 0, 0),
            OwnerId = 3},
        new AppointmentData{
            Id = 4,
            Subject = "Burning Man",
            StartTime = new DateTime(2020, 6, 1, 11, 30, 0),
            EndTime = new DateTime(2020, 6, 1, 13, 0, 0),
            OwnerId = 1},
        new AppointmentData{
            Id = 5,
            Subject = "Funnel Hacking",
            StartTime = new DateTime(2020, 6, 2, 9, 30, 0),
            EndTime = new DateTime(2020, 6, 2, 11, 0, 0),
            OwnerId = 3},
        new AppointmentData{
            Id = 6,
            Subject = "The human gathering",
            StartTime = new DateTime(2020, 6, 2, 13, 0, 0),
            EndTime = new DateTime(2020, 6, 2, 14, 30, 0),
            OwnerId = 2},
        new AppointmentData{
            Id = 7,
            Subject = "Techweek",
            StartTime = new DateTime(2020, 6, 3, 11, 0, 0),
            EndTime = new DateTime(2020, 6, 3, 12, 30, 0),
            OwnerId = 2},
        new AppointmentData{
            Id = 8,
            Subject = "Grow Conference",
            StartTime = new DateTime(2020, 6, 4, 10, 0, 0),
            EndTime = new DateTime(2020, 6, 4, 11, 30, 0),
            OwnerId = 1},
        new AppointmentData{
            Id = 9,
            Subject = "Data Science Conference",
            StartTime = new DateTime(2020, 6, 4, 13, 30, 0),
            EndTime = new DateTime(2020, 6, 4, 15, 0, 0),
            OwnerId = 1},
        new AppointmentData{
            Id = 10,
            Subject = "Blogcademy",
            StartTime = new DateTime(2020, 6, 5, 12, 0, 0),
            EndTime = new DateTime(2020, 6, 5, 13, 30, 0),
            OwnerId = 3},
        new AppointmentData{
            Id = 11,
            Subject = "World Domination Summit",
            StartTime = new DateTime(2020, 6, 6, 9, 30, 0),
            EndTime = new DateTime(2020, 6, 6, 11, 0, 0),
            OwnerId = 2},
        new AppointmentData{
            Id = 12,
            Subject = "Content Marketing",
            StartTime = new DateTime(2020, 6, 6, 13, 0, 0),
            EndTime = new DateTime(2020, 6, 6, 14, 30, 0),
            OwnerId = 1},
        new AppointmentData{
            Id = 13,
            Subject = "Mobile World Conference",
            StartTime = new DateTime(2020, 6, 12, 18, 0, 0),
            EndTime = new DateTime(2020, 6, 12, 20, 0, 0),
            OwnerId = 1}
    };

    public void OnChange(ChangeEventArgs<bool> args)
    {
        predicate = null;
        if (MargretChecked)
        {
            if (predicate != null)
            {
                predicate = predicate.Or("OwnerId", "equal", Convert.ToInt32(MargretId));
            }
            else
            {
                predicate = new WhereFilter() { Field = "OwnerId", Operator = "equal", value = Convert.ToInt32(MargretId) };
            }
        }
        if (RobertChecked)
        {
            if (predicate != null)
            {
                predicate = predicate.Or("OwnerId", "equal", Convert.ToInt32(RobertId));
            }
            else
            {
                predicate = new WhereFilter() { Field = "OwnerId", Operator = "equal", value = Convert.ToInt32(RobertId) };
            }
        }
        if (LauraChecked)
        {
            if (predicate != null)
            {
                predicate = predicate.Or("OwnerId", "equal", Convert.ToInt32(LauraId));
            }
            else
            {
                predicate = new WhereFilter() { Field = "OwnerId", Operator = "equal", value = Convert.ToInt32(LauraId) };
            }
        }
        if (predicate == null)
        {
            predicate = new WhereFilter() { Field = "OwnerId", Operator = "notequal", value = Convert.ToInt32(MargretId) }.And("OwnerId", "notequal", Convert.ToInt32(RobertId)).And("OwnerId", "notequal", Convert.ToInt32(LauraId));
        }
        ScheduleQuery = new Query().Where(predicate);
    }
    public List<ResourceData> OwnersData { get; set; } = new List<ResourceData>
{
    new ResourceData { OwnerText = "Margaret", OwnerId = 1, Color = "#ea7a57" },
    new ResourceData { OwnerText = "Robert", OwnerId = 2, Color = "#df5286" },
    new ResourceData { OwnerText = "Laura", OwnerId = 3, Color = "#865fcf" }
};
    public class ResourceData
    {
        public int OwnerId { get; set; }
        public string OwnerText { get; set; }
        public string Color { get; set; }
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
        public Nullable<int> RecurrenceID { get; set; }
        public int OwnerId { get; set; }
    }
}
<style>
    .e-checkbox-wrapper.margaret .e-frame {
        background-color: #ea7a57;
        border-color: transparent;
    }

   .e-checkbox-wrapper.robert .e-frame {
        background-color: #df5286;
        border-color: transparent;
    }

   .e-checkbox-wrapper.laura .e-frame {
        background-color: #865fcf;
        border-color: transparent;
    }
</style>
```

## Appointment selection

Appointment selection can be done either through mouse or keyboard actions. The selected events in UI will have a box shadow effect around to differentiate it from other appointments.

| Action | Description |
|-------|---------|
| Mouse click or Single tap on appointments | Selects single appointment. |
| Ctrl + [Mouse click] or [Single tap] on appointments | Selects multiple appointments.|

## Deleting multiple appointments

With the options available to select multiple appointments, it is also possible to delete the multiple selected appointments simply by pressing the `delete` key. In case of deleting multiple selected occurrences of an event series, only those occurrences will be deleted and not the entire series.

## Retrieve event details from the UI of an event

It is possible to access the information about the event fields of an appointment based on the X and Y co-ordinates. This can be achieved by passing an X and Y co-ordinates to the public method `GetTargetEventAsync`. You can also get the selected appointment details using `GetSelectedEventsAsync` method.

## Get the current view appointments

To retrieve the appointments present in the current view of the Scheduler, you can make use of the `GetCurrentViewEvents` public method. In the following example, current view appointment collection rendered has been traced in `DataBound` event.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" @ref="ScheduleRef" Width="100%" Height="550px" @bind-SelectedDate="@CurrentDate">
    <ScheduleEvents TValue="AppointmentData" DataBound="OnDataBound"></ScheduleEvents>
    <ScheduleEventSettings DataSource="@DataSource"></ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>

@code{
    DateTime CurrentDate = new DateTime(2020, 1, 10);
    SfSchedule<AppointmentData> ScheduleRef;
    public void OnDataBound(DataBoundEventArgs<AppointmentData> args)
    {
        List<AppointmentData> eventCollection = ScheduleRef.GetCurrentViewEvents();
        //You can get the current view appointment collections in the EventCollection variable
    }
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData { Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 1, 10, 9, 30, 0) , EndTime = new DateTime(2020, 1, 10, 11, 30, 0) },
        new AppointmentData { Id = 1, Subject = "Conference", StartTime = new DateTime(2020, 1, 9, 11, 30, 0) , EndTime = new DateTime(2020, 1, 9, 13, 0, 0) }
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

## Get the entire appointment collections

The entire collection of appointments rendered on the Scheduler can be accessed using the `GetEventsAsync` public method. In the following example, entire appointment collection rendered on the Scheduler has been traced in `DataBound` event.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" @ref="ScheduleRef" Width="100%" Height="550px" SelectedDate="@(new DateTime(2020,1,10))">
    <ScheduleEvents TValue="AppointmentData" DataBound="OnDataBound"></ScheduleEvents>
    <ScheduleEventSettings DataSource="@DataSource"></ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>

@code{
    SfSchedule<AppointmentData> ScheduleRef;
    public async void OnDataBound(DataBoundEventArgs<AppointmentData> args)
    {
        List<AppointmentData> EventCollection = await ScheduleRef.GetEventsAsync();
        //You can get the entire appointment collections in the EventCollection variable
    }
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData { Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 1, 10, 9, 30, 0) , EndTime = new DateTime(2020, 1, 10, 11, 30, 0) },
        new AppointmentData { Id = 1, Subject = "Conference", StartTime = new DateTime(2020, 2, 9, 11, 30, 0) , EndTime = new DateTime(2020, 2, 9, 13, 0, 0) }
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

> You can also get the specific range of appointments by passing the start and end time in the `GetEventsAsync` method. To get the block events, you can make use of the method `GetBlockEventsAsync`.

## Refresh appointments

If your requirement is to simply refresh the appointments instead of refreshing the entire Scheduler elements from your application end, make use of the `RefreshEventsAsync` public method.

```csharp
ScheduleRef.RefreshEventsAsync();
```