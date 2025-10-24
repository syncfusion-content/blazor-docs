---
layout: post
title: Build a Blazor stay reservation app - Syncfusion
description: Learn here about step-by-step tutorial to build a Blazor stay reservation application using Syncfusion Blazor components like Scheduler, Sidebar, and Toast.
platform: Blazor
control: Tutorials
documentation: ug
---

# Build a Blazor stay reservation app with Syncfusion® Blazor components

This tutorial explains how to build a stay reservation application. It demonstrates how to use the **Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Scheduler** component as the centerpiece of a booking system, with filtering, a booking form, and a responsive layout.

By the end of this tutorial, the reader will be able to:
* Set up a Blazor project with Syncfusion<sup style="font-size:70%">&reg;</sup> components.
* Configure the Blazor Scheduler for a reservation system.
* Manage application state using a dependency-injected service.
* Build a filterable sidebar with checkboxes and accordions.
* Combine multiple components to create a polished application.



## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create the Blazor Web App

Create a new Blazor Web App.

```bash
dotnet new blazor -o StayReservation
cd StayReservation
```

Choose the "Blazor Web App" template. For this project, use the **Interactive Server** render mode for simplicity.

## Add and configure Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components

Next, add the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor libraries to the project. Packages are required for the Scheduler, navigation elements (such as Sidebar and Accordion), and input components.

Install the essential Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet packages:

```bash
dotnet add package Syncfusion.Blazor.Schedule
dotnet add package Syncfusion.Blazor.Notifications
dotnet add package Syncfusion.Blazor.Themes
```

Configure the app to recognize and style the Syncfusion<sup style="font-size:70%">&reg;</sup> components.

1.  **Register Syncfusion<sup style="font-size:70%">&reg;</sup> services**

    In `Program.cs`, register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service.

    ```csharp
    // Add the following line before builder.Build()
    builder.Services.AddSyncfusionBlazor();
    ```

2.  **Add theme and script references**

    Open `Components/App.razor`. Add the Syncfusion<sup style="font-size:70%">&reg;</sup> theme stylesheet and the script reference for component interactivity. The example uses the `tailwind.css` theme.

    ```html
    <!DOCTYPE html>
    <html lang="en">
    
    <head>
        <meta charset="utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <title>Stay Reservation</title>
        <base href="/" />
        <link rel="stylesheet" href="css/bootstrap/bootstrap.min.css" />
        <link href="css/site.css" rel="stylesheet" />
        <link href="StayReservation.styles.css" rel="stylesheet" />
        <link href="_content/Syncfusion.Blazor.Themes/tailwind.css" rel="stylesheet" />
        <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
        <HeadOutlet @rendermode="@InteractiveServer" />
    </head>
    
    <body>
        <Routes @rendermode="@InteractiveServer" />
        ...
    </body>
    </html>
    ```

3.  **Add namespace imports**

    To avoid adding `@using` directives in each component, add the commonly used Syncfusion<sup style="font-size:70%">&reg;</sup> namespaces to the `_Imports.razor` file.

    ```csharp
    @using StayReservation
    @using StayReservation.Components
    @using Syncfusion.Blazor.Schedule
    @using Syncfusion.Blazor.Navigations
    @using Syncfusion.Blazor.Buttons
    @using Syncfusion.Blazor.Calendars
    @using Syncfusion.Blazor.Inputs
    @using Syncfusion.Blazor.DropDowns
    ```

## Define the data and state management service

A real-world app needs a way to manage its data and state. Create an `AppointmentService` to act as a central hub for reservation data and UI state. Inject this service into components that need to share information.

A real-world app needs a way to manage its data and state. For this, we'll create an `AppointmentService` to act as a central hub for our reservation data and UI state. This service will be injected into the components that need to share information.

First, define your data model in `Data/AppointmentData.cs`:

```csharp
public class AppointmentData
{
    public int Id { get; set; }
    [Required]
    public string Subject { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsAllDay { get; set; } = false;
    public string RecurrenceRule { get; set; }
    public string RecurrenceException { get; set; }
    public Nullable<int> RecurrenceID { get; set; }
    public int FloorId { get; set; } // Represents the resource
    public int RoomId { get; set; }
    public string Price { get; set; }
    public int Nights { get; set; }
    public int Adults { get; set; }
    public int Children { get; set; }
    [Required]
    public string Purpose { get; set; }
    [Required]
    public int Proof { get; set; }
    [Required]
    public string ProofNumber { get; set; }
    [Required]
    [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Invalid email address")]
    public string Email { get; set; }
    [Required]
    [RegularExpression("^[0-9]{10}$", ErrorMessage = "Invalid Phone Number")]
    public string Phone { get; set; }
    public string BorderColor { get; set; }
}
```

Create `AppointmentService.cs` in the `Data` folder. This service holds the appointment list and references to components.

The complete code for `AppointmentService.cs` is available in the GitHub repository at the following link: [`AppointmentService.cs`](https://github.com/syncfusion/blazor-showcase-stay-reservation/blob/master/webapp/Stay-Reservation/Data/AppointmentService.cs). You may reuse the full code as needed.

```csharp
public class AppointmentService
{
    // Holds all reservation data
    public List<AppointmentData> appointmentData { get; set; } = new List<AppointmentData>();

    // References to UI components to allow interaction
    public SfSchedule<AppointmentData> ScheduleRef { get; set; }
    public SfSidebar SidebarRef { get; set; }

    // State for filters
    public DateTime CurrentDate { get; set; } = DateTime.Now;
    public bool SelectAllChecked { get; set; } = true;
    public bool GroundFloorChecked { get; set; } = true;
    // ... add bools for other floors
}
```

Register this service as a singleton in `Program.cs`:

```csharp
builder.Services.AddSingleton<AppointmentService>();
```

## Build the UI components

The application has three main UI parts: the sidebar for calendar date navigation and filtering rooms (`Sidebar.razor`), the scheduler view (`Schedule.razor`), and the main page (`Index.razor`) that assembles them.

### The Filtering Sidebar (`Sidebar.razor`)

This component uses an `<SfSidebar>` to contain the calendar and filters. An `<SfCalendar>` allows the user to select the desired date in the scheduler. An `<SfAccordion>` organizes the filters, `<SfCheckBox>` component which floors are displayed. `<SfSlider>` filters the price range.

```html
@using StayReservation.Data
@inject AppointmentService Service

<SfSidebar id="default-sidebar" class="app-sidebar" @ref="Service.SidebarRef">
    <ChildContent>
        <div class="sidebar-header">
            <div class="sidebar-title">Filter By</div>
            <SfButton CssClass="sidebar-close e-flat e-small e-round" IconCss="e-icons e-close"
                OnClick="SidebarClose" />
        </div>
        <Calendar></Calendar>
        <div class="filter-container">
            <SfAccordion class="app-filters">
                <AccordionItems>
                    <AccordionItem Header="Floors">
                        <ContentTemplate>
                            <div class="checkbox-filter-container">
                                <div class="floor-filter">
                                    <SfCheckBox Label="Select All" @bind-Checked="Service.SelectAllChecked"></SfCheckBox>
                                </div>
                                <div class="floor-filter">
                                    <SfCheckBox Label="Ground Floor" @bind-Checked="Service.GroundFloorChecked"></SfCheckBox>
                                </div>
                                <!-- Repeat for other floors -->
                            </div>
                        </ContentTemplate>
                    </AccordionItem>
                    <AccordionItem Header="Price">
                        <ContentTemplate>
                            <div class="price-filter-container">
                            <SfSlider Type=SliderType.Range Value="Service.Range" CssClass="app-slider" Min="0" Max="500" @ref="Service.RangeSliderRef">
                            <SliderEvents TValue="int[]" OnTooltipChange="@OnSliderValueChanged" Created="OnSliderCreated "></SliderEvents>
                             <SliderTooltip IsVisible="true" Placement="TooltipPlacement.Before" ShowOn="TooltipShowOn.Always"></SliderTooltip>
                            </SfSlider>
                                <div class="slider-price">
                                    <span class="slider-label-start">$0</span>
                                    <span class="slider-label-end">$500</span>
                                </div>
                            </div>
                            </ContentTemplate>
                        </AccordionItem>
                        <AccordionItem Header="Features">
                            <ContentTemplate>
                                <div class="checkbox-filter-container">
                                    <div class="filter-checkbox">
                                    <SfCheckBox TChecked="bool" Label="Television" @bind-Checked="Service.TelevisionChecked" Value="@Service.TelevisionId" ValueChange="@((Syncfusion.Blazor.Buttons.ChangeEventArgs<bool> args) => onFeaturesChecked(args))"></SfCheckBox>
                                    </div>
                                    <!-- Repeat for other features in room -->
                                </div>
                            </ContentTemplate>
                        </AccordionItem>
                </AccordionItems>
            </SfAccordion>
        </div>
    </ChildContent>
</SfSidebar>

```

When a checkbox is clicked, its state is updated in the `AppointmentService`. We'll use this shared state in our main page to filter the floor resources shown in the scheduler.

### The Scheduler View (`Schedule.razor`)

This is the core of the application. Configure the `<SfSchedule>` component to display reservations grouped by floor.

Create a new file: `Components/Pages/Schedule.razor`.

The Scheduler needs two main pieces of data:
1.  A list of **resources**—in our case, the hotel floors.
2.  A list of **events** (or appointments)—the actual reservations.

The appointment and resource data come from `AppointmentService`.

The complete code for `Schedule.razor` is available in the GitHub repository at the following link: [`Schedule.razor`](https://github.com/syncfusion/blazor-showcase-stay-reservation/blob/master/webapp/Stay-Reservation/Components/Pages/Schedule.razor). You may reuse the full code as needed.

```html
@inject AppointmentService Service

<div class="schedule-container">
    <SfSchedule TValue="AppointmentData" Height="507px" @bind-SelectedDate="Service.CurrentDate" CssClass="@cssClass" @ref="Service.ScheduleRef" ShowHeaderBar="false" ShowQuickInfo="Service.Mobile ? true : false" EnableAutoRowHeight="true" AllowDragAndDrop="false" AllowResizing="false">
            <ScheduleTimeScale Enable="false"></ScheduleTimeScale>
            <ScheduleEvents TValue="AppointmentData" EventRendered="OnEventRendered" ActionCompleted="OnActionCompleted" OnActionBegin="OnActionBegin" OnRenderCell="OnCellRendered" OnPopupOpen="OnPopupOpen" Created="OnCreated" OnCellDoubleClick="CellDoubleClick" OnCellClick="CellClick" OnEventDoubleClick="EventDoubleClick"></ScheduleEvents>
            <ScheduleGroup Resources="Service.Resources" EnableCompactView="false"></ScheduleGroup>
            <ScheduleResources>
                <ScheduleResource TItem="ResourceData" TValue="int" Query="@Service.ResourceQuery" DataSource="Service.FloorData" Field="FloorId" Title="Floors" Name="Floors" TextField="FloorText" IdField="Id" ColorField="FloorColor" AllowMultiple="false"></ScheduleResource>
                <ScheduleResource TItem="ResourceData" TValue="int[]" Query="@Service.FilterQuery" DataSource="Service.RoomData" Field="RoomId" Title="Rooms" Name="Rooms" TextField="RoomText" IdField="Id" GroupIDField="RoomsId" ColorField="RoomColor" AllowMultiple="true"></ScheduleResource>
            </ScheduleResources>
            <ScheduleEventSettings DataSource=@Service.appointmentData IgnoreWhitespace="true">
            </ScheduleEventSettings>
            <ScheduleViews>
                <ScheduleView Option="View.TimelineMonth"></ScheduleView>
            </ScheduleViews>
            <ScheduleTemplates>
                <DateHeaderTemplate>
                    <div class="date-header">
                        <div class="date-header-text" style="display:flex; justify-content: center">
                            @context.Date.ToString("dd",CultureInfo.InvariantCulture)
                        </div>
                        <div class="date-header-text" style="display:flex; justify-content: center">
                            @context.Date.ToString("ddd",CultureInfo.InvariantCulture)
                        </div>
                    </div>
                </DateHeaderTemplate>
                <CellTemplate>
                    @if ((ElementType)(context as TemplateContext).Type == ElementType.MonthCells)
                    {
                        <div class="template-wrap">
                            <span class="price-tag">$@GetRoomPrice((context as TemplateContext)?.GroupIndex ?? 0)</span>
                        </div>
                    }
                </CellTemplate>
                <ResourceHeaderTemplate>
                    @{
                        var resourceData = (context as TemplateContext).ResourceData as ResourceData;
                        <div class='template-wrap'>
                            <div class="resource-details">
                                <div class="resource-name">@(resourceData.FloorText)</div>
                            </div>
                            <div class="room-details">
                                <div class="resource-room">@(resourceData.RoomText)</div>
                                <div class="resource-description">@(resourceData.Description)</div>
                            </div>
                        </div>
                    }
                </ResourceHeaderTemplate>
            </ScheduleTemplates>
        </SfSchedule>
</div>

```

Key configuration points:
* `<ScheduleEventSettings>`: Binds the scheduler's events to the list in `AppointmentService`.
* `<ScheduleGroup>`: Groups by the resource named "Floors".
* `<ScheduleResource>`: Defines the "Floors" resource. This maps the `FloorId` field in `AppointmentData` to the `FloorId` in the `floorData` list, assigning colors and text to resource group headers.
* `<ScheduleTemplates>`: Uses templates to customize the date header, cell, and resource header.

## Assemble the Main Page

Bring it together in the main `Index.razor` page. This component hosts the sidebar and the schedule, along with a header to control the UI.

Update `Components/Pages/Index.razor` with the following code:

```html
@page "/"

<div class="app-main-container" style="visibility:@(Service.Visible); opacity:@(Service.Opacity)">
    <SfAppBar cssClass="app-header">
        <h1 class="header-title">BookmyRooms</h1>
        <AppBarSpacer></AppBarSpacer>
         <div class="avatar-container">
        <img class="avatar-image" src="images/user.svg" alt="avatar" />
            <span class="avatar-name">Hi, John David</span>
        </div>
    </SfAppBar>
    <main class="main-container"> 
        <div class="sidebar-container">
            <Sidebar></Sidebar>
        </div>
         <div class="content-container"> 
            <Header></Header>
            <Schedule></Schedule>
        </div>
    </main>
 </div>
```

## Implement the filtering logic

Connect the checkboxes in the sidebar to the data displayed in the scheduler. Since `AppointmentService` holds the state, detect changes to the checkbox and slider values, form the filter query, and update the resource data.

Use the following code to implement the filtering logic in `Components/Pages/Sidebar.razor`:

The complete code for `Sidebar.razor` is available in the GitHub repository at the following link: [`Sidebar.razor`](https://github.com/syncfusion/blazor-showcase-stay-reservation/blob/master/webapp/Stay-Reservation/Components/Pages/Sidebar.razor). You may reuse the full code as needed.

```csharp
@code {
    // ... existing code ...

     public void FloorHandler()
    {
        dynamic predicate = null;
        if (Service.GroundFloorChecked)
        {
            if (predicate != null)
            {
                predicate = predicate.Or("Id", "equal", Convert.ToInt32(Service.GroundFloorId));
            }
            else
            {
                predicate = new WhereFilter() { Field = "Id", Operator = "equal", value = Convert.ToInt32(Service.GroundFloorId) };
            }
        }
        if (Service.FirstFloorChecked)
        {
            if (predicate != null)
            {
                predicate = predicate.Or("Id", "equal", Convert.ToInt32(Service.FirstFloorId));
            }
            else
            {
                predicate = new WhereFilter() { Field = "Id", Operator = "equal", value = Convert.ToInt32(Service.FirstFloorId) };
            }
        }
        if (Service.SecondFloorChecked)
        {
            if (predicate != null)
            {
                predicate = predicate.Or("Id", "equal", Convert.ToInt32(Service.SecondFloorId));
            }
            else
            {
                predicate = new WhereFilter() { Field = "Id", Operator = "equal", value = Convert.ToInt32(Service.SecondFloorId) };
            }
        }
        if (Service.ThirdFloorChecked)
        {
            if (predicate != null)
            {
                predicate = predicate.Or("Id", "equal", Convert.ToInt32(Service.ThirdFloorId));
            }
            else
            {
                predicate = new WhereFilter() { Field = "Id", Operator = "equal", value = Convert.ToInt32(Service.ThirdFloorId) };
            }
        }
        if (Service.FourthFloorChecked)
        {
            if (predicate != null)
            {
                predicate = predicate.Or("Id", "equal", Convert.ToInt32(Service.FourthFloorId));
            }
            else
            {
                predicate = new WhereFilter() { Field = "Id", Operator = "equal", value = Convert.ToInt32(Service.FourthFloorId) };
            }
        }
        if (predicate == null)
        {
            predicate = new WhereFilter() { Field = "Id", Operator = "notequal", value = Convert.ToInt32(Service.GroundFloorId) }.And("Id", "notequal", Convert.ToInt32(Service.FirstFloorId)).And("Id", "notequal", Convert.ToInt32(Service.SecondFloorId)).And("Id", "notequal", Convert.ToInt32(Service.ThirdFloorId)).And("Id", "notequal", Convert.ToInt32(Service.FourthFloorId));
        }
        Service.ResourceQuery = new Query().Where(predicate);
        Service.SchedulerPageRef?.StateChanged();
    }
```

When a user clicks a checkbox, it triggers the `OnChange` event, which calls the `FloorHandler` method. This method updates the `ResourceQuery` property on the `Service` object to filter resources in the scheduler. The `StateChanged` method refreshes the scheduler with the new resource data.

Build and run the app by executing the `dotnet watch run` command in the command shell from the `StayReservation` folder.

## Implement the appointment booking form
Bind the Scheduler's Editor Template to a custom form for creating and editing appointments. This form includes fields for the appointment subject, start and end times, and a drop-down list for selecting the room. The form is displayed when a user double-clicks an empty cell in the scheduler or an existing appointment, in a popup window.

Validate the form fields using the `ValidationMessage` component. The `ValidationMessage` component displays an error message when validation fails. It is bound to the `Subject` property of the `AppointmentData` object, which is required, so an error message appears when the `Subject` property is empty.

Apply the following code to the `Schedule.razor` file to create the custom form.

```html
<SfSchedule>
    <ScheduleTemplates>
    <EditorTemplate>
        <div class="custom-event-editor @((Service.Mobile) ? "e-device" : "")">
            <div class="flex-prop">
                <SfTextBox ID="guestName" FloatLabelType="FloatLabelType.Always" Placeholder="Guest Name *" @bind-Value="@((context as AppointmentData).Subject)"></SfTextBox>
                <ValidationMessage For="()=>((context as AppointmentData).Subject)" />
            </div>
            <div class="flex-prop">
                @{
                    if (UpdateStartTime)
                    {
                        (context as AppointmentData).StartTime = (context as AppointmentData).StartTime.AddHours(12);
                        (context as AppointmentData).EndTime = (context as AppointmentData).EndTime.AddHours(12);
                        UpdateStartTime = false;
                    }
                }
                <SfDateTimePicker ID="checkIn" TValue="DateTime" Placeholder="Check In *" FloatLabelType="FloatLabelType.Always" @bind-Value="@((context as AppointmentData).StartTime)">
                    <DateTimePickerEvents TValue="DateTime" OnRenderDayCell="@DisableDate" ValueChange="@OnStartTimeValueChanged"></DateTimePickerEvents>
                </SfDateTimePicker>
            </div>
            <div class="flex-prop">
                <SfDropDownList TValue="int" TItem="ResourceData" Placeholder="Floors" DataSource="Service.FloorData" Query="@Service.ResourceQuery" FloatLabelType="FloatLabelType.Always" @bind-Value="@((context as AppointmentData).FloorId)">
                    <DropDownListEvents TItem="ResourceData" TValue="int" ValueChange="FloorDropDownChanged" />
                    <DropDownListFieldSettings Value="Id" Text="FloorText"></DropDownListFieldSettings>
                </SfDropDownList>
            </div>
            <div class="flex-prop">
                @{
                    if (IsFloorDropDownChanged)
                    {
                        (context as AppointmentData).RoomId = Service.RoomsDdlValue;
                        IsFloorDropDownChanged = false;
                    }
                }
                <SfDropDownList TValue="int" TItem="ResourceData" Placeholder="Select Room" DataSource="Service.RoomData" Query="@Service.DropDownQuery" FloatLabelType="FloatLabelType.Always" @bind-Value="@((context as AppointmentData).RoomId)" @ref="Service.DropDownRef">
                    <DropDownListEvents TItem="ResourceData" TValue="int" ValueChange="RoomDropDownChanged" />
                    <DropDownListFieldSettings Value="Id" Text="RoomText"></DropDownListFieldSettings>
                </SfDropDownList>
            </div>
            <div class="flex-prop">
                @{
                    TimeSpan differenceInDays = (context as AppointmentData).EndTime.Subtract((context as AppointmentData).StartTime);
                    int noOfDays = Convert.ToInt32(differenceInDays.TotalDays);
                    (context as AppointmentData).Price = (Service.RoomPrice * noOfDays).ToString();
                }
                <SfTextBox ID="roomPrice" FloatLabelType="FloatLabelType.Always" Placeholder="Price per night (USD) *" Enabled="false" @bind-Value="@((context as AppointmentData).Price)"></SfTextBox>
            </div>
            <div class="flex-prop">
                @{
                    TimeSpan difference = (context as AppointmentData).EndTime.Subtract((context as AppointmentData).StartTime);
                    int totalDays = Convert.ToInt32(difference.TotalDays);
                    (context as AppointmentData).Nights = totalDays;
                }
                <SfNumericTextBox TValue="int" ID="nights" Placeholder="Nights *" FloatLabelType="FloatLabelType.Always"
                              Enabled="false" Min="1" Max="9" @bind-Value="@((context as AppointmentData).Nights)"></SfNumericTextBox>
            </div>
            <div class="flex-prop">
                <SfNumericTextBox TValue="int" ID="adults" Placeholder="Adults *" FloatLabelType="FloatLabelType.Always"
                              Min="1" Max="30" @bind-Value="@((context as AppointmentData).Adults)"></SfNumericTextBox>
            </div>
            <div class="flex-prop">
                <SfNumericTextBox TValue="int" ID="children" Placeholder="Children *" FloatLabelType="FloatLabelType.Always"
                              Min="1" Max="10" @bind-Value="@((context as AppointmentData).Children)"></SfNumericTextBox>
            </div>
            <div class="flex-prop">
                @{
                    if (IsStartTimeUpdated || IsintialLoad)
                    {
                        if((context as AppointmentData).Id < 1)
                        {
                            (context as AppointmentData).EndTime = (context as AppointmentData).StartTime.AddDays(1);
                            IsStartTimeUpdated = false;
                            IsintialLoad = false;
                        } 
                        
                    }
                }
                <SfDateTimePicker ID="checkOut" Placeholder="Check Out *" FloatLabelType="FloatLabelType.Always" @bind-Value="@((context as AppointmentData).EndTime)">
                    <DateTimePickerEvents TValue="DateTime" OnRenderDayCell="@EndTimeDisableDate" ValueChange="@OnEndTimeValueChanged"></DateTimePickerEvents>
                </SfDateTimePicker>
            </div>
            <div class="flex-prop">
                <SfTextBox ID="purpose" FloatLabelType="FloatLabelType.Always" Placeholder="Purpose" @bind-Value="@((context as AppointmentData).Purpose)"></SfTextBox>
                <ValidationMessage For="()=>((context as AppointmentData).Purpose)" />
            </div>
            <div class="flex-prop">
                @{
                    if (IsProofDropDownChanged)
                    {
                        (context as AppointmentData).Proof = Service.ProofDdlValue;
                        IsProofDropDownChanged = false;
                    }

                }
                <SfDropDownList TValue="int" TItem="Proof" Placeholder="Select Proof" DataSource="@Proofs" FloatLabelType="FloatLabelType.Always" @bind-Value="@((context as AppointmentData).Proof)">
                    <DropDownListFieldSettings Value="ID" Text="Text"></DropDownListFieldSettings>
                    <DropDownListEvents TItem="Proof" TValue="int" ValueChange="ProofDropDownChanged" />
                </SfDropDownList>
                <ValidationMessage For="()=>((context as AppointmentData).Proof)" />
            </div>
            <div class="flex-prop">
                <SfTextBox ID="proofNumber" FloatLabelType="FloatLabelType.Always" Placeholder="Proof Number" @bind-Value="@((context as AppointmentData).ProofNumber)"></SfTextBox>
                <ValidationMessage For="()=>((context as AppointmentData).ProofNumber)" />
            </div>
            <div class="flex-prop">
                <SfTextBox ID="email" FloatLabelType="FloatLabelType.Always" Placeholder="Email" @bind-Value="@((context as AppointmentData).Email)"></SfTextBox>
                <ValidationMessage For="()=>((context as AppointmentData).Email)" />
            </div>
            <div class="flex-prop">
                <SfTextBox ID="contactNumber" FloatLabelType="FloatLabelType.Always" Placeholder="Contact Number" @bind-Value="@((context as AppointmentData).Phone)"></SfTextBox>
                <ValidationMessage For="()=>((context as AppointmentData).Phone)" />
            </div>
        </div>
    </EditorTemplate>
    </ScheduleTemplates>
</SfSchedule>
```
More details about the editor template are available in the [Editor Template](https://blazor.syncfusion.com/documentation/scheduler/editor-template#customizing-event-editor-using-template) documentation.

## Add toast notifications

Integrate `SfToast` for user notifications throughout the application. When a user creates or deletes a reservation, a toast notification appears.

```csharp
    <SfToast ID="toast_default" @ref="Service.ToastObj" Content="@Service.ToastContent" Timeout="5000" Icon="e-meeting" ShowCloseButton="true" Height="70px" Width="400px">
        <ToastPosition X="@Service.ToastPositionXValue" Y="@Service.ToastPositionYValue"></ToastPosition>
    </SfToast>
```

Bind the `OnActionBegin` event of the `SfSchedule` component to a method that handles toast notifications.

```csharp
    public async Task OnActionBegin(ActionEventArgs<AppointmentData> args)
    {
        bool availability = true;
        if (args.ActionType == ActionType.EventCreate || args.ActionType == ActionType.EventChange || args.ActionType == ActionType.EventRemove)
        {
            var records = args.AddedRecords ?? args.ChangedRecords ?? args.DeletedRecords;
            if (records == null)
            {
                return;
            }
            availability = await Service.ScheduleRef.IsSlotAvailableAsync(records.First());
            if (availability)
            {
                if (args.ActionType == ActionType.EventCreate)
                {
                    Service.ToastContent = "Reservation booked successfully";
                    Service.ToastObj.CssClass = "e-toast-success";
                    StateChanged();
                    await Service.ToastObj.ShowAsync();
                }
                else if (args.ActionType == ActionType.EventChange)
                {
                    Service.ToastContent = "Reservation updated successfully";
                    Service.ToastObj.CssClass = "e-toast-success";
                    StateChanged();
                    await Service.ToastObj.ShowAsync();
                }
                else if (args.ActionType == ActionType.EventRemove)
                {
                    Service.ToastContent = "Reservation removed successfully";
                    Service.ToastObj.Content= "Reservation removed successfully";
                    Service.ToastObj.CssClass = "e-toast-success";
                    StateChanged();
                    await Service.ToastObj.ShowAsync();
                }
            }
            else
            {
                Service.ToastContent = "Room not available for reservation on the selected Dates.";
                Service.ToastObj.CssClass = "e-toast-warning";
                StateChanged();
                await Service.ToastObj.ShowAsync();
            }
        }
        args.Cancel = !availability;
    }
```

## GitHub and demo references

The complete code for this example is available in the GitHub repository: https://github.com/syncfusion/blazor-showcase-stay-reservation

Try the live demo: https://blazor.syncfusion.com/showcase/stay-reservation

## Summary

This guide demonstrates how to build a functional and interactive stay reservation application. It shows how to compose a complex UI by combining Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components such as **Scheduler**, **Sidebar**, **AppBar**, **Accordion**, **Inputs**, and **DropDowns**.

A clean state management pattern is implemented using a singleton service, allowing the components to communicate and share data seamlessly. This architecture is scalable and makes the application easier to maintain and extend with new features.
