---
layout: post
title: Content Render Modes in Blazor Tabs | Syncfusion
description: Choose dynamic, on-demand, or initial render modes to control how Blazor Tabs content loads in the DOM.
platform: Blazor
control: Tabs
documentation: ug
---

# Content Render Modes in Blazor Tabs

In [Blazor Tabs](https://www.syncfusion.com/blazor-components/blazor-tabs), the content of the Tabs can be rendered based on the scenario. The content rendering of tabs can be done by the following three different ways.

* [Dynamic rendering](#dynamic-rendering)
* [On Demand rendering or lazy loading](#on-demand-rendering-or-lazy-loading)
* [On initial rendering](#on-initial-rendering)

## Dynamic rendering

This mode is the default one in which the content of the selected tab alone will be loaded and available in DOM initially and it will be replaced with corresponding content if you select the tab dynamically. Since in this mode, the browser maintains the DOM with current active tab content alone, page loading performance is increased with rendering DOM. But the Tabs doesn't maintain its current state since every time tab loaded with fresh content.

In the following code example, there are two tabs. The first tab shows a login page and the second tab shows the Grid component. The second tab (Grid) is rendered in the DOM only after the login is completed. Because this mode replaces the previous tab's content, the first tab is removed from the DOM when the second tab is activated.

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Grids

<SfTab LoadOn="ContentLoad.Dynamic" @bind-SelectedItem="@SelectedTab">
    <TabItems>
        <TabItem Disabled="@Disabled">
            <HeaderTemplate>Login</HeaderTemplate>
            <ContentTemplate>
                <div class="login-form">
                    <div class='wrap'>
                        <div id="heading">Sign in to view the Grid</div>
                        <div id="input-container">
                            <div class="e-float-input e-input-group">
                                <input type="text" @bind-value="@UserName" required />
                                <span class="e-float-line"></span>
                                <label class="e-float-text">Username</label>
                            </div>
                            <div class="e-float-input e-input-group">
                                <input type="password" @bind-value="@Password" required />
                                <span class="e-float-line"></span>
                                <label class="e-float-text">Password</label>
                            </div>
                        </div>
                        <div class="button-contain">
                            <SfButton @onclick="@OnClicked">Log in</SfButton>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </TabItem>
        <TabItem Disabled="@DisableTab">
            <HeaderTemplate>Grid</HeaderTemplate>
            <ContentTemplate>
                <SfGrid DataSource="@Orders">
                    <GridPageSettings></GridPageSettings>
                    <GridColumns>
                        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
                        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="130"></GridColumn>
                        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="yMd" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="150"></GridColumn>
                        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
                    </GridColumns>
                </SfGrid>
            </ContentTemplate>
        </TabItem>
    </TabItems>
</SfTab>

@code {
    private string UserName { get; set; } = "";
    private string Password { get; set; } = "";
    private Boolean DisableTab { get; set; } = true;
    private Boolean Disabled { get; set; } = false;
    private int SelectedTab { get; set; } = 0;
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 6).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }

    private void OnClicked()
    {
        if (this.UserName == "" && this.Password == "")
        {
            Console.WriteLine("clicked");
        }
        else if (this.UserName == "")
        {
            Console.WriteLine("Enter the username");
        }
        else if (this.Password == "")
        {
            Console.WriteLine("Enter the password");
        }
        else if (this.UserName.Length < 4)
        {
            Console.WriteLine("Username must be minimum 4 characters");
        }
        else
        {
            this.UserName = "";
            this.Password = "";
            this.DisableTab = false;
            this.Disabled = true;
            this.SelectedTab = 1;
        }
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

N> In this mode, the Tab does not maintain its own state when it is replaced. If you need to preserve state, you must manage it in your application code.

## On Demand rendering or lazy loading

You can enable this mode by setting `ContentLoad.Demand` on the [LoadOn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfTab.html#Syncfusion_Blazor_Navigations_SfTab_LoadOn) property of `SfTab`. In this mode, only the content of the initially selected tab is loaded. The content of any other tab is rendered only when that tab is selected. Once a tab's content is rendered, it is kept in the DOM. This preserves state such as the scroller position, form values, and other UI state for tabs that have been visited.

In the following code example, the Calendar is rendered in the first tab and the Scheduler in the second tab. Initially, the Scheduler is not available; once the second tab is selected, the Scheduler is rendered. Both the Calendar and the Scheduler are then maintained in the DOM, and changing the date in either component updates the other.

```cshtml
@using Syncfusion.Blazor.Calendars
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Schedule

<SfTab LoadOn="ContentLoad.Demand">
    <TabItems>
        <TabItem>
            <HeaderTemplate>Calendar</HeaderTemplate>
            <ContentTemplate>
                <SfCalendar TValue="DateTime" @bind-Value="@SelectedDate"></SfCalendar>
            </ContentTemplate>
        </TabItem>
        <TabItem>
            <HeaderTemplate>Scheduler</HeaderTemplate>
            <ContentTemplate>
                <SfSchedule TValue="AppointmentData" Height="450px" @bind-SelectedDate="@SelectedDate">
                    <ScheduleViews>
                        <ScheduleView Option="View.Day"></ScheduleView>
                    </ScheduleViews>
                </SfSchedule>
            </ContentTemplate>
        </TabItem>
    </TabItems>
</SfTab>

@code {
    private DateTime SelectedDate { get; set; } = new DateTime(2020, 1, 10);
    public class AppointmentData
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
```

## On initial rendering

This mode can be enabled by setting `ContentLoad.Init` on the `LoadOn` property of `SfTab`. In this mode, the content of all the tabs is rendered on initial load and maintained in the DOM. Use this mode when you have a small number of tabs and you need to maintain the state of the components in each tab. In this mode, you can also access the references of components rendered in other tabs.

In the following example, all three tabs are rendered on initial load. The data entered in the first tab is preserved even when the second or third tab is the active tab.

 ```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons

<SfTab LoadOn="ContentLoad.Init" @bind-SelectedItem="@SelectedTab">
    <TabItems>
        <TabItem>
            <HeaderTemplate>Sign in</HeaderTemplate>
            <ContentTemplate>
                <div id="User details" style="padding:10px">
                    <form id="formId">
                        <div class="form-group">
                            <div class="e-float-input">
                                <SfTextBox Placeholder="Enter name" @bind-Value="UserName"></SfTextBox>
                            </div>
                            <div class="e-float-input">
                                <SfTextBox Placeholder="Email" @bind-Value="MailAddress" Type="InputType.Email"></SfTextBox>
                            </div>
                        </div>
                    </form>
                    <div style="text-align: center">
                        <SfButton @onclick="@OnSignin">Sign in</SfButton>
                        <SfButton @onclick="@OnSkip">Skip</SfButton>
                        @if (EmptyField)
                        {
                            <div class="Error">* Please fill all fields</div>
                        }
                    </div>
                </div>
            </ContentTemplate>
        </TabItem>
        <TabItem>
            <HeaderTemplate>Blazor</HeaderTemplate>
            <ContentTemplate>
                <p>You can check out our Blazor demo here - https://blazor.syncfusion.com/demos/ </p>
                <br />
                <p>Also user guide will be avail here - https://blazor.syncfusion.com/documentation/introduction</p>
            </ContentTemplate>
        </TabItem>
        <TabItem>
            <HeaderTemplate>Feedback</HeaderTemplate>
            <ContentTemplate>
                <div id="Feedback_Form" style="padding:10px">
                    <form id="formId">
                        <div class="form-group">
                            <div class="e-float-input">
                                <SfTextBox Placeholder="Enetr name" @bind-Value="UserName"></SfTextBox>
                            </div>
                            <div class="e-float-input">
                                <SfTextBox @bind-Value="MailAddress" Placeholder="Email" Type="InputType.Email"></SfTextBox>
                            </div>
                            <div class="e-float-input">
                                <SfTextBox @bind-Value="Comments" Placeholder="Share your comments"></SfTextBox>
                            </div>
                        </div>
                    </form>
                    <div style="text-align: center">
                        <SfButton @onclick="@OnSubmit">Submit</SfButton>
                        @if (EmptyField)
                        {
                            <div class="Error">* Please fill all fields</div>
                        }
                    </div>
                </div>
            </ContentTemplate>
        </TabItem>
    </TabItems>
</SfTab>

@code {
    private string UserName = string.Empty;
    private string MailAddress = string.Empty;
    private string Comments = string.Empty;
    private int SelectedTab = 0;
    public Boolean EmptyField { get; set; } = false;
    private void OnSignin()
    {
        if (string.IsNullOrWhiteSpace(this.UserName) || string.IsNullOrWhiteSpace(this.MailAddress))
        {
            EmptyField = true;
        }
        else
        {
            EmptyField = false;
            this.SelectedTab = 1;
        }
    }
    private void OnSkip()
    {
        this.SelectedTab = 1;
    }
    public void OnSubmit()
    {
        if (string.IsNullOrWhiteSpace(this.UserName) || string.IsNullOrWhiteSpace(this.MailAddress) || string.IsNullOrWhiteSpace(this.Comments))
        {
            EmptyField = true;
        }
        else
        {
            EmptyField = false;
            this.UserName = string.Empty;
            this.MailAddress = string.Empty;
            this.Comments = string.Empty;
        }
    }
}
```