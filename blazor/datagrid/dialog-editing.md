---
layout: post
title: Dialog Editing in Blazor DataGrid | Syncfusion
description: Checkout and learn here all about Dialog Editing in Syncfusion Blazor DataGrid and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Dialog editing in Blazor DataGrid

Dialog editing is a feature in the Syncfusion Blazor DataGrid that allows you to edit the data of the currently selected row using a dialog window. With dialog editing, you can easily modify cell values and save the changes back to the data source. This feature is particularly beneficial in scenarios where you need to quickly modify data without navigating to a separate page or view, and it streamlines the process of editing multiple cells.

To enable dialog editing in the Grid, you need to set the [GridEditSettings.Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_Mode) property to **Dialog**. This property determines the editing mode for the Grid, and when set to **Dialog**, it enables the dialog editing feature.

Here's an example of how to enable dialog editing in the Grid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@OrderData" Toolbar="@(new List<string>() { "Add", "Edit","Delete", "Update", "Cancel" })" Height="315">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Dialog" ></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true })" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" ValidationRules="@(new ValidationRules{ Required=true, MinLength=5 })" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" ValidationRules="@(new ValidationRules{ Required=true, Min=1, Max=1000 })" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> Order = new List<OrderDetails>();
    public OrderDetails(int OrderID, string CustomerId, double Freight, string ShipCountry)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.Freight = Freight;
        this.ShipCountry = ShipCountry;    
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (Order.Count == 0)
        {
            Order.Add(new OrderDetails(10248, "VINET", 32.38, "France"));
            Order.Add(new OrderDetails(10249, "TOMSP", 11.61, "Germany"));
            Order.Add(new OrderDetails(10250, "HANAR", 65.83, "Brazil"));
            Order.Add(new OrderDetails(10251, "VICTE", 41.34, "France"));
            Order.Add(new OrderDetails(10252, "SUPRD", 51.3, "Belgium"));
            Order.Add(new OrderDetails(10253, "HANAR", 58.17, "Brazil"));
            Order.Add(new OrderDetails(10254, "CHOPS", 22.98, "Switzerland"));
            Order.Add(new OrderDetails(10255, "RICSU", 148.33, "Switzerland"));
            Order.Add(new OrderDetails(10256, "WELLI", 13.97, "Brazil"));
            Order.Add(new OrderDetails(10257, "HILAA", 81.91, "Venezuela"));
            Order.Add(new OrderDetails(10258, "ERNSH", 140.51, "Austria"));
            Order.Add(new OrderDetails(10259, "CENTC", 3.25, "Mexico"));
            Order.Add(new OrderDetails(10260, "OTTIK", 55.09, "Germany"));
            Order.Add(new OrderDetails(10261, "QUEDE", 3.05, "Brazil"));
            Order.Add(new OrderDetails(10262, "RATTC", 48.29, "USA"));
        }
        return Order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCountry { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/htBTihBtqxaHFdKg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customize the edit dialog

The edit dialog in the Syncfusion Blazor DataGrid allows you to customize its appearance and behavior based on the type of action being performed, such as editing or adding a record. You can modify properties like header text, showCloseIcon, and height to tailor the edit dialog to your specific requirements.

To customize the edit dialog, use the [HeaderTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_HeaderTemplate) and [FooterTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_FooterTemplate) properties of [GridEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html) to modify the appearance of the edit dialog.

The following example demonstrates how to customize the edit dialog.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfGrid @ref="Grid" DataSource="@OrderData" Toolbar="@(new List<string>() { "Add", "Edit","Delete", "Update", "Cancel" })" Height="315">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Dialog="DialogParams" Mode="EditMode.Dialog">
        <HeaderTemplate>
            @{
                var DialogHeader = GetHeader((context as OrderDetails));
                <span>@DialogHeader</span>
            }
        </HeaderTemplate>
        <FooterTemplate>
            <SfButton OnClick="@SaveEdit" IsPrimary="true">Submit</SfButton>
            <SfButton OnClick="@CancelEdit">Discard</SfButton>
        </FooterTemplate>
    </GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true })" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" ValidationRules="@(new ValidationRules{ Required=true, MinLength=5 })" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" ValidationRules="@(new ValidationRules{ Required=true, Min=1, Max=1000 })" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public SfGrid<OrderDetails> Grid { get; set; }
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
    public DialogSettings DialogParams { get; set; } = new DialogSettings { Height= "300px", Width="300px" }; 
    public string GetHeader(OrderDetails value)
    {
        return value.OrderID == 0 
            ? "New Customer" 
            : "Edit Record of " + value.CustomerID;
    }
    public async Task CancelEdit()
    {
        await Grid.CloseEditAsync();     //Cancel editing action.
    }
    public async Task SaveEdit()
    {
        await Grid.EndEditAsync();       //Save the edited/added data to Grid.
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> Order = new List<OrderDetails>();
    public OrderDetails(int OrderID, string CustomerId, double Freight, string ShipCountry)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.Freight = Freight;
        this.ShipCountry = ShipCountry;    
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (Order.Count == 0)
        {
            Order.Add(new OrderDetails(10248, "VINET", 32.38, "France"));
            Order.Add(new OrderDetails(10249, "TOMSP", 11.61, "Germany"));
            Order.Add(new OrderDetails(10250, "HANAR", 65.83, "Brazil"));
            Order.Add(new OrderDetails(10251, "VICTE", 41.34, "France"));
            Order.Add(new OrderDetails(10252, "SUPRD", 51.3, "Belgium"));
            Order.Add(new OrderDetails(10253, "HANAR", 58.17, "Brazil"));
            Order.Add(new OrderDetails(10254, "CHOPS", 22.98, "Switzerland"));
            Order.Add(new OrderDetails(10255, "RICSU", 148.33, "Switzerland"));
            Order.Add(new OrderDetails(10256, "WELLI", 13.97, "Brazil"));
            Order.Add(new OrderDetails(10257, "HILAA", 81.91, "Venezuela"));
            Order.Add(new OrderDetails(10258, "ERNSH", 140.51, "Austria"));
            Order.Add(new OrderDetails(10259, "CENTC", 3.25, "Mexico"));
            Order.Add(new OrderDetails(10260, "OTTIK", 55.09, "Germany"));
            Order.Add(new OrderDetails(10261, "QUEDE", 3.05, "Brazil"));
            Order.Add(new OrderDetails(10262, "RATTC", 48.29, "USA"));
        }
        return Order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCountry { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDVyZWjvKbTMIaIU?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * The Grid add or edit dialog element has a max-height property, which is calculated based on the available window height. In a standard window (1920 x 1080), you can set the dialog's height up to 658px.
> * Refer to our [Grid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour page for an overview of its features. You can also explore our [Grid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap4) to see how to present and manipulate data.

## Show or hide columns in dialog editing

The show or hide columns in dialog editing feature in the Syncfusion Blazor DataGrid allows you to dynamically control the visibility of columns while editing in dialog edit mode. This feature is useful when you want to display specific columns based on the type of action being performed, such as editing an existing record or adding a new record. To achieve this, you can utilize the following Grid events:

1. [RowCreating](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowCreating): Triggered before an add action is executed in the Grid.
2. [RowEditing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowEditing): Triggered before an edit action is executed in the Grid.
3. [RowUpdating](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowUpdating): Triggered before an update action is executed in the Grid.
4. [EditCanceling](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_EditCanceling): Triggered before a cancel action is executed in the Grid.

The `RowCreating` and `RowEditing` events are triggered whenever an action such as adding or editing a record is initiated in the Grid. Within the event handlers, you can modify the visibility of columns using the [Column.Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Visible) property. This property determines whether a column should be displayed or hidden.

Additionally, you can reset the column visibility to its initial state using the `Column.Visible` property in the `RowUpdating` and `EditCanceling` events of the Grid.

In the following example, the **CustomerID** column is initially hidden, and the **ShipCountry** column is visible. In edit mode, the **CustomerID** column is shown, and the **ShipCountry** column is hidden.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@OrderData" Toolbar="@(new List<string>() { "Add", "Edit","Delete", "Update", "Cancel" })" Height="315">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Dialog"></GridEditSettings>
    <GridEvents TValue="OrderDetails" EditCanceling="RowCancelingHandler" RowEditing="RowEditingHandler" RowCreating="RowAddingHandler" RowUpdating="RowUpdatingHandler"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required=true, MinLength=5})" Visible="false" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" ValidationRules="@(new ValidationRules{ Required=true, Min=1, Max=1000})" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public SfGrid<OrderDetails> Grid { get; set; }
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
    public void RowAddingHandler(RowCreatingEventArgs<OrderDetails> args)
    {
        var columns = Grid.Columns;
        foreach (var column in columns)
        {
            if (column.Field == "CustomerID")
            {
                column.Visible = true; 
            }
        }
    }
    public void RowEditingHandler(RowEditingEventArgs<OrderDetails> args)
    {
        var columns = Grid.Columns;
        foreach (var column in columns)
        {
            if (column.Field == "CustomerID")
            {
                column.Visible = true; 
            }
            else if (column.Field == "ShipCountry")
            {
                column.Visible = false; 
            }
        }
    }
    public void RowUpdatingHandler(RowUpdatingEventArgs<OrderDetails> args)
    {
        var columns = Grid.Columns;
        foreach (var column in columns)
        {
            if (column.Field == "CustomerID")
            {
                column.Visible = false; 
            }
            else if (column.Field == "ShipCountry")
            {
                column.Visible = true; 
            }            
        }
    }
    public void RowCancelingHandler(EditCancelingEventArgs<OrderDetails> args)
    {
        var columns = Grid.Columns;
        foreach (var column in columns)
        {
            if (column.Field == "CustomerID")
            {
                column.Visible = false; 
        }
            else if (column.Field == "ShipCountry")
            {
                column.Visible = true; 
            }
        }
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> Order = new List<OrderDetails>();
    public OrderDetails(int OrderID, string CustomerId, double Freight, string ShipCountry)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.Freight = Freight;
        this.ShipCountry = ShipCountry;    
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (Order.Count == 0)
        {
            Order.Add(new OrderDetails(10248, "VINET", 32.38, "France"));
            Order.Add(new OrderDetails(10249, "TOMSP", 11.61, "Germany"));
            Order.Add(new OrderDetails(10250, "HANAR", 65.83, "Brazil"));
            Order.Add(new OrderDetails(10251, "VICTE", 41.34, "France"));
            Order.Add(new OrderDetails(10252, "SUPRD", 51.3, "Belgium"));
            Order.Add(new OrderDetails(10253, "HANAR", 58.17, "Brazil"));
            Order.Add(new OrderDetails(10254, "CHOPS", 22.98, "Switzerland"));
            Order.Add(new OrderDetails(10255, "RICSU", 148.33, "Switzerland"));
            Order.Add(new OrderDetails(10256, "WELLI", 13.97, "Brazil"));
            Order.Add(new OrderDetails(10257, "HILAA", 81.91, "Venezuela"));
            Order.Add(new OrderDetails(10258, "ERNSH", 140.51, "Austria"));
            Order.Add(new OrderDetails(10259, "CENTC", 3.25, "Mexico"));
            Order.Add(new OrderDetails(10260, "OTTIK", 55.09, "Germany"));
            Order.Add(new OrderDetails(10261, "QUEDE", 3.05, "Brazil"));
            Order.Add(new OrderDetails(10262, "RATTC", 48.29, "USA"));
        }
        return Order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCountry { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXrzWVLAqtMKVgod?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Use wizard-like dialog editing

Wizard-like dialog editing is a powerful feature in the Syncfusion Blazor DataGrid that enables the creation of intuitive, step-by-step forms. This approach provides a structured way to complete forms or enter data by breaking the process into manageable steps. It is especially useful for complex forms that need to be divided into smaller sections, guiding users through the data entry process.

To implement wizard-like dialog editing in the Grid, use the template feature. This allows you to define a custom editing template by setting the [GridEditSettings.Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_Mode) property to **Dialog** and specifying the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_Template) property of [GridEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html). The template defines the editors for each step of the wizard.

The following example demonstrates wizard-like editing in the Grid with unobtrusive validation.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.DropDowns

<SfGrid @ref="Grid" DataSource="@OrderData" AllowPaging="true" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel" })" Height="315">
    <GridEvents TValue="OrderDetails" RowCreating="RowCreating" OnBeginEdit="OnBeginEdit"></GridEvents>
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="Syncfusion.Blazor.Grids.EditMode.Dialog">
        <Template>
            @{
                var Order = (context as OrderDetails);
                <div>
                    @if (CurrentTab == 0)
                    {
                        <div id="tab0" class='tab'>
                            <div class="form-row">
                                <div class="form-group col-md-6">
                                    <SfNumericTextBox ID="OrderID" @bind-Value="@(Order.OrderID)" Enabled="@Check" FloatLabelType="FloatLabelType.Always" Placeholder="Order ID"></SfNumericTextBox>
                                </div>
                                <div class="form-group col-md-6">
                                    <SfTextBox ID="CustomerID" @bind-Value="@(Order.CustomerID)" Placeholder="Customer Name" FloatLabelType="@FloatLabelType.Auto"></SfTextBox>
                                </div>
                            </div>
                        </div>
                    }
                    else if (CurrentTab == 1)
                    {
                        <div id="tab1" class='tab'>
                            <div class="form-row">
                                <div class="form-group col-md-6">
                                    <SfNumericTextBox ID="Freight" @bind-Value="@(Order.Freight)" TValue="double" Placeholder="Freight" FloatLabelType="FloatLabelType.Always">
                                    </SfNumericTextBox>
                                </div>
                                <div class="form-group col-md-6">
                                    <SfDropDownList ID="ShipCity" TItem="City" @bind-Value="@(Order.ShipCity)" TValue="string" DataSource="@CityName" FloatLabelType="FloatLabelType.Always" Placeholder="Ship City">
                                        <DropDownListFieldSettings Value="ShipCity" Text="ShipCity"></DropDownListFieldSettings>
                                    </SfDropDownList>
                                </div>
                            </div>
                        </div>
                    }
                    else if (CurrentTab == 2)
                    {
                        <div id="tab2" class='tab'>
                            <div class="form-row">
                                <div class="form-group col-md-6">
                                    <SfDropDownList ID="ShipCountry" TItem="Country" @bind-Value="@(Order.ShipCountry)" TValue="string" DataSource="@CountryName" FloatLabelType="FloatLabelType.Always" Placeholder="Ship Country">
                                        <DropDownListFieldSettings Value="ShipCountry" Text="ShipCountry"></DropDownListFieldSettings>
                                    </SfDropDownList>
                                </div>
                                <div class="form-group col-md-6">
                                    <SfCheckBox @bind-Checked="@(Order.Verified)" Label="Verified"></SfCheckBox>
                                </div>
                            </div>
                        </div>
                    }
                </div>
            }
        </Template>
        <FooterTemplate>
            <div style="float: left;">
                @if (CurrentTab != 0)
                {
                    <SfButton CssClass="e-info"  OnClick="@PreviousDialog" IsPrimary="true">Previous</SfButton>
                }
            </div>
            <div style="float: right;">
                <SfButton CssClass="e-info" OnClick="@SaveDialog">Save</SfButton>
                @if (CurrentTab != 2)
                {
                    <SfButton CssClass="e-info" OnClick="@NextDialog" IsPrimary="true">Next</SfButton>
                }
            </div>
        </FooterTemplate>
    </GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required=true})" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" ValidationRules="@(new ValidationRules{ Required=true, Min=1,})" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Verified) HeaderText="Verified" Type="ColumnType.Boolean" DisplayAsCheckBox="true" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderDetails> Grid;
    private Boolean Check = false;
    private OrderDetails CurrentEditingRecord { get; set; }
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
    private bool IsCurrentTabValid()
    {
        if (CurrentEditingRecord == null) return false;
        if (CurrentTab == 0)
        {
            return CurrentEditingRecord.OrderID != 0 && !string.IsNullOrWhiteSpace(CurrentEditingRecord.CustomerID);
        }
        else if (CurrentTab == 1)
        {
            return CurrentEditingRecord.Freight > 0;
        }
        return true;
    }
    private int CurrentTab { get; set; } = 0;    
    public void PreviousDialog()
    {
        if (IsCurrentTabValid() && CurrentTab > 0)
        {
            CurrentTab--;
            Grid.PreventRender(false);
        }
    }
    public void NextDialog()
    {
        if (IsCurrentTabValid() && CurrentTab < 2)
        {
            CurrentTab++;
            Grid.PreventRender(false);
        }
    }
    public void SaveDialog()
    {
        Grid.EndEditAsync();
    }  
    public void RowCreating(RowCreatingEventArgs<OrderDetails> args)
    {
        Check = true;
        CurrentTab = 0;
        CurrentEditingRecord = args.Data;
    }
    public void OnBeginEdit(BeginEditArgs<OrderDetails> args)
    {
        Check = false;
        CurrentTab = 0;
        CurrentEditingRecord = args.RowData;
    }
    public class City
    {
        public string ShipCity { get; set; }
    }
    List<City> CityName = new List<City>
    {
        new City() { ShipCity= "Reims" },
        new City() { ShipCity= "Münster" },
        new City() { ShipCity = "Rio de Janeiro" },
        new City() { ShipCity = "Lyon" },
        new City() { ShipCity = "Charleroi" },
        new City() { ShipCity = "Genève" },
        new City() { ShipCity = "Resende" },
        new City() { ShipCity = "San Cristóbal" },
        new City() { ShipCity = "Graz" },
        new City() { ShipCity = "México D.F." },
        new City() { ShipCity = "Köln" },
        new City() { ShipCity = "Albuquerque" },
    };
    public class Country
    {
        public string ShipCountry { get; set; }
    }
    List<Country> CountryName = new List<Country>
    {
        new Country() { ShipCountry= "France"},
        new Country() { ShipCountry= "Brazil"},
        new Country() { ShipCountry= "Germany"},
        new Country() { ShipCountry= "Belgium"},
        new Country() { ShipCountry= "Austria"},
        new Country() { ShipCountry= "Switzerland"},
        new Country() { ShipCountry= "Venezuela"},        
        new Country() { ShipCountry= "Mexico"},
        new Country() { ShipCountry= "USA"},
    };
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> Order = new List<OrderDetails>();
    public OrderDetails(int OrderID, string CustomerId, double Freight, string ShipCountry, string ShipCity, bool Verified)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.Freight = Freight;
        this.ShipCountry = ShipCountry;
        this.ShipCity = ShipCity;
        this.Verified = Verified;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (Order.Count == 0)
        {
            Order.Add(new OrderDetails(10248, "VINET", 32.38, "France", "Reims", true));
            Order.Add(new OrderDetails(10249, "TOMSP", 11.61, "Germany", "Münster", false));
            Order.Add(new OrderDetails(10250, "HANAR", 65.83, "Brazil", "Rio de Janeiro", true));
            Order.Add(new OrderDetails(10251, "VICTE", 41.34, "France", "Lyon", true));
            Order.Add(new OrderDetails(10252, "SUPRD", 51.3, "Belgium", "Charleroi", true));
            Order.Add(new OrderDetails(10253, "HANAR", 58.17, "Brazil", "Rio de Janeiro", true));
            Order.Add(new OrderDetails(10254, "CHOPS", 22.98, "Switzerland", "Bern", false));
            Order.Add(new OrderDetails(10255, "RICSU", 148.33, "Switzerland", "Genève", true));
            Order.Add(new OrderDetails(10256, "WELLI", 13.97, "Brazil", "Resende", false));
            Order.Add(new OrderDetails(10257, "HILAA", 81.91, "Venezuela", "San Cristóbal", true));
            Order.Add(new OrderDetails(10258, "ERNSH", 140.51, "Austria", "Graz", true));
            Order.Add(new OrderDetails(10259, "CENTC", 3.25, "Mexico", "México D.F.", false));
            Order.Add(new OrderDetails(10260, "OTTIK", 55.09, "Germany", "Köln", true));
            Order.Add(new OrderDetails(10261, "QUEDE", 3.05, "Brazil", "Rio de Janeiro", false));
            Order.Add(new OrderDetails(10262, "RATTC", 48.29, "USA", "Albuquerque", true));
        }
        return Order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCountry { get; set; }
    public string ShipCity { get; set; }
    public bool Verified { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDLyZMjvJXWZYAiP?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customize add/edit dialog footer

The customize add/edit dialog footer feature in the Syncfusion Blazor DataGrid allows you to modify the footer section of the dialog that appears when editing the currently selected row or adding a new row. By default, the dialog displays two buttons in the footer section: Save and Cancel, which let you save or discard the changes made in the dialog. This feature is particularly helpful when you want to add custom buttons to the dialog's footer, implement specific actions, or customize the appearance of the buttons, such as changing their color or size. You can achieve this using the [FooterTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_FooterTemplate) property of the [GridEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html).

In the following sample, the action for the custom button is defined using the `FooterTemplate` property of the `GridEditSettings`.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfGrid @ref="Grid" DataSource="@OrderData" Toolbar="@(new List<string>() { "Add", "Edit","Delete", "Update", "Cancel" })" Height="315">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Dialog">
        <FooterTemplate>
            <SfButton OnClick="@CancelEdit" IsPrimary="true">Discard</SfButton>
            <SfButton OnClick="@SaveEdit" CssClass="e-success">Submit</SfButton>
        </FooterTemplate>
    </GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true })" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" ValidationRules="@(new ValidationRules{ Required=true, MinLength=5 })" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" ValidationRules="@(new ValidationRules{ Required=true, Min=1, Max=1000 })" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public SfGrid<OrderDetails> Grid { get; set; }
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
    public async Task CancelEdit()
    {
        await Grid.CloseEditAsync();     
    }
    public async Task SaveEdit()
    {
        await Grid.EndEditAsync();      
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> Order = new List<OrderDetails>();
    public OrderDetails(int OrderID, string CustomerId, double Freight, string ShipCountry)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.Freight = Freight;
        this.ShipCountry = ShipCountry;    
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (Order.Count == 0)
        {
            Order.Add(new OrderDetails(10248, "VINET", 32.38, "France"));
            Order.Add(new OrderDetails(10249, "TOMSP", 11.61, "Germany"));
            Order.Add(new OrderDetails(10250, "HANAR", 65.83, "Brazil"));
            Order.Add(new OrderDetails(10251, "VICTE", 41.34, "France"));
            Order.Add(new OrderDetails(10252, "SUPRD", 51.3, "Belgium"));
            Order.Add(new OrderDetails(10253, "HANAR", 58.17, "Brazil"));
            Order.Add(new OrderDetails(10254, "CHOPS", 22.98, "Switzerland"));
            Order.Add(new OrderDetails(10255, "RICSU", 148.33, "Switzerland"));
            Order.Add(new OrderDetails(10256, "WELLI", 13.97, "Brazil"));
            Order.Add(new OrderDetails(10257, "HILAA", 81.91, "Venezuela"));
            Order.Add(new OrderDetails(10258, "ERNSH", 140.51, "Austria"));
            Order.Add(new OrderDetails(10259, "CENTC", 3.25, "Mexico"));
            Order.Add(new OrderDetails(10260, "OTTIK", 55.09, "Germany"));
            Order.Add(new OrderDetails(10261, "QUEDE", 3.05, "Brazil"));
            Order.Add(new OrderDetails(10262, "RATTC", 48.29, "USA"));
        }
        return Order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCountry { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LZLSZyKtglluvsMB?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Implement calculated column inside Blazor DataGrid dialog editing

You can automatically update the value of a column based on the edited value of another column using the Cell Edit Template feature. This feature is useful when you want to dynamically calculate and update a column's value in real time based on changes made to another related column.

In the following sample, the `SfNumericTextBox` is rendered inside the dialog edit form. The **Total** column value is updated based on the **Price** and **Quantity** columns using the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.NumericTextBoxEvents-1.html#Syncfusion_Blazor_Inputs_NumericTextBoxEvents_1_ValueChange) event. This is achieved in combination with the [RowUpdating](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowUpdating), [RowCreating](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowCreating), and [RowEdited](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowEdited) events, along with the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_Template) property of the [GridEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html).

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.DropDowns

<SfGrid @ref="Grid" DataSource="@ProductData" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel" })">
    <GridEvents RowCreating="AddHandler" RowEdited="EditHandler" RowUpdating="UpdateHandler" TValue="ProductDetails"></GridEvents>
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Dialog">
        <Template>
            @{
                var Product = (context as ProductDetails);
                <div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <SfNumericTextBox ID="ProductID" @bind-Value="@(Product.ProductID)" Enabled="@Check" FloatLabelType="FloatLabelType.Always" Placeholder="Product ID"></SfNumericTextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <SfAutoComplete TItem="Product" ID="ProductName" @bind-Value="@(Product.ProductName)" DataSource="@ProductNameData" TValue="string" FloatLabelType="FloatLabelType.Always" Placeholder="Product Name">
                                <AutoCompleteFieldSettings Value="ProductName"></AutoCompleteFieldSettings>
                            </SfAutoComplete>
                        </div>
                        <div class="form-group col-md-6">
                            <SfNumericTextBox ID="Price" @ref="PriceReference" @bind-Value="@(Product.Price)" TValue="double" Placeholder="Price" FloatLabelType="FloatLabelType.Always">
                                <NumericTextBoxEvents ValueChange="ValueChangeHandler" TValue="double"></NumericTextBoxEvents>
                            </SfNumericTextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <SfNumericTextBox ID="Quantity" @ref="QuantityReference" @bind-Value="@(Product.Quantity)" TValue="int" Placeholder="Quantity" FloatLabelType="FloatLabelType.Always">
                                <NumericTextBoxEvents ValueChange="ValueChangeHandler" TValue="int"></NumericTextBoxEvents>
                            </SfNumericTextBox>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <SfNumericTextBox ID="Total" Value="@TotalValue" Enabled="false" TValue="double" Placeholder="Total" FloatLabelType="FloatLabelType.Always"></SfNumericTextBox>
                        </div>
                    </div>
                </div>
            }
        </Template>
    </GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(ProductDetails.ProductID) HeaderText="Product ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(ProductDetails.ProductName) HeaderText="Product Name" ValidationRules="@(new ValidationRules{ Required=true})" Width="100"></GridColumn>
        <GridColumn Field=@nameof(ProductDetails.Price) HeaderText="Price" Format="C2" ValidationRules="@(new ValidationRules{ Required=true})" Width="90" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(ProductDetails.Quantity) HeaderText="Quantity" ValidationRules="@(new Syncfusion.Blazor.Grids.ValidationRules{ Required=true})" Width="90" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(ProductDetails.Total) HeaderText="Total" AllowEditing="false" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="90"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<ProductDetails> Grid;
    SfNumericTextBox<double> PriceReference;
    SfNumericTextBox<int> QuantityReference;
    private Boolean Check = false;
    public double TotalValue { get; set; }
    public List<ProductDetails> ProductData { get; set; }
    protected override void OnInitialized()
    {
        ProductData = ProductDetails.GetAllRecords();
    }
    public void UpdateHandler(RowUpdatingEventArgs<ProductDetails> args)
    {
        args.Data.Total = TotalValue;
    }
    public void AddHandler(RowCreatingEventArgs<ProductDetails> args)
    {
        Check = true;
        TotalValue = args.Data.Total;
    }
    public void EditHandler(RowEditedEventArgs<ProductDetails> args)
    {
        Check = false;
        TotalValue = args.Data.Total;
    }
    private void ValueChangeHandler()
    {
        TotalValue = Convert.ToDouble(PriceReference.Value * QuantityReference.Value);
        Grid.PreventRender(false);
    }
    public class Product
    {
        public string ProductName { get; set; }
    }
    List<Product> ProductNameData = new List<Product>
    {
        new Product() { ProductName= "Chai" },
        new Product() { ProductName= "Chang"},
        new Product() { ProductName= "Aniseed Syrup"},
        new Product() { ProductName= "Chef Anton's Cajun Seasoning" },
        new Product() { ProductName= "Chef Anton's Gumbo Mix" },
        new Product() { ProductName= "Chef Anton's Gumbo" },
        new Product() { ProductName= "Chef Anton's Mix" },
        new Product() { ProductName= "Coca-Cola"},
    };
}
{% endhighlight %}
{% highlight c# tabtitle="ProductDetails.cs" %}
public class ProductDetails
{
    public static List<ProductDetails> Products = new List<ProductDetails>();
    public ProductDetails(int productID, string productName, double price, int quantity, double total)
    {
        this.ProductID = productID;
        this.ProductName = productName;
        this.Price = price;
        this.Quantity = quantity;
        this.Total = total;
    }
    public static List<ProductDetails> GetAllRecords()
    {
        if (Products.Count == 0)
        {
            Products.Add(new ProductDetails(1, "Chai", 18.0, 39, 702));
            Products.Add(new ProductDetails(2, "Chang", 19.0, 17, 323));
            Products.Add(new ProductDetails(3, "Aniseed Syrup", 10.0, 13, 130));
            Products.Add(new ProductDetails(4, "Chef Anton's Cajun Seasoning", 22.0, 53, 1166));
            Products.Add(new ProductDetails(5, "Chef Anton's Gumbo Mix", 21.35, 22, 469.7));
            Products.Add(new ProductDetails(6, "Chef Anton's Gumbo", 23.35, 5, 116.75));
            Products.Add(new ProductDetails(7, "Chef Anton's Mix", 25.35, 47, 1191.45));
            Products.Add(new ProductDetails(8, "Coca-Cola", 27.39, 0, 0));
        }
        return Products;
    }
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public double Total { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDLyXsZxfZTvqDJz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> For information about the events triggered during `Dialog` editing, please refer to this [documentation](https://blazor.syncfusion.com/documentation/datagrid/in-line-editing#supported-events-for-inline-and-dialog-editing).