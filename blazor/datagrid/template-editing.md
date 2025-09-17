---
layout: post
title: Template Editing in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Template Editing in Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Template Editing in Blazor DataGrid Component

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid component supports template editing, providing a powerful and flexible way to customize the appearance and behavior of cells during editing. This feature allows you to use templates to define the structure and content of the cells within the grid.

> Before implementing Template Editing, it is recommended to review the [Template](https://blazor.syncfusion.com/documentation/datagrid/templates) section to understand the configuration of templates in the grid.

## Inline template editing

The inline template editing feature in Syncfusion<sup style="font-size:70%">&reg;</sup> DataGrid allows customization of the default inline editing behavior by enabling individuals to define their custom editors for grid rows. This is achieved by setting the [GridEditSettings.Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_Mode) property to **Normal** and wrapping the desired editor elements inside the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_Template) property of the [GridEditSettings](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Grids.GridEditSettings.html). This feature is particularly useful when there is a need to include additional fields not present in the column model or to render highly customized editors.

> Custom HTML elements or components can be used as editors, and two-way data binding (**@bind-Value**) must be implemented to ensure synchronization with the grid's data.

In some cases, you want to add new field editors in the dialog which are not present in the column model. In that situation the dialog template will help us to customize the default edit dialog.

In the following sample, grid enabled with inline template editing.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Calendars
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Inputs

<SfGrid DataSource="@OrderData" Toolbar="@(new string[] { "Add", "Edit", "Delete", "Update", "Cancel" })">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Normal">
        <Template>
            @{
                var Order = (context as OrderDetails);
                <table class="e-table e-inline-edit" cellspacing="0.25">
                    <colgroup>
                        <col style="width: 140px;">
                        <col style="width: 150px;">
                        <col style="width: 140px;">
                        <col style="width: 160px;">
                        <col style="width: 150px;">
                        <col style="width: 150px;">
                        <col style="width: 150px;">
                    </colgroup>
                    <tbody>
                        <tr>
                            <td style="text-align: center">
                                <SfNumericTextBox ID="OrderID" @bind-Value="@(Order.OrderID)" ShowSpinButton="false" Enabled="@((Order.OrderID == 0)? true: false)" TValue="int"></SfNumericTextBox>
                            </td>
                            <td>
                                <SfAutoComplete ID="CustomerID" TItem="OrderDetails" FloatLabelType="FloatLabelType.Auto" @bind-Value="@(Order.CustomerID)" TValue="string" DataSource="@OrderData">
                                    <AutoCompleteFieldSettings Value="CustomerID"></AutoCompleteFieldSettings>
                                </SfAutoComplete>
                            </td>
                            <td style="text-align: right">
                                <SfNumericTextBox ID="Freight" @bind-Value="@(Order.Freight)" TValue="double"></SfNumericTextBox>
                            </td>
                            <td>
                                <SfDatePicker ID="OrderDate" @bind-Value="@(Order.OrderDate)"></SfDatePicker>
                            </td>
                            <td>
                                <SfDropDownList ID="ShipCountry" TItem="Country" @bind-Value="@(Order.ShipCountry)" TValue="string" DataSource="@CountryName">
                                    <DropDownListFieldSettings Value="ShipCountry" Text="ShipCountry"></DropDownListFieldSettings>
                                </SfDropDownList>
                            </td>
                            <td>
                                <SfDropDownList ID="ShipCity" TItem="City" @bind-Value="@(Order.ShipCity)" TValue="string" DataSource="@CityName">
                                    <DropDownListFieldSettings Value="ShipCity" Text="ShipCity"></DropDownListFieldSettings>
                                </SfDropDownList>
                            </td>
                            <td>
                                <SfTextBox ID="ShipAddress" @bind-Value="@(Order.ShipAddress)" Multiline=true></SfTextBox>
                            </td>
                        </tr>
                    </tbody>
                </table>
            }
        </Template>
    </GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required=true})"  Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" ValidationRules="@(new ValidationRules{ Required=true, Min=1})" Format="C2" Width="140" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.OrderDate) HeaderText="Order Date" ValidationRules="@(new ValidationRules{ Required=true})" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="160"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipAddress) HeaderText="Ship Address" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
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
    public OrderDetails(int OrderID, string CustomerId, double Freight, string ShipCountry, string ShipCity, string ShipAddress, DateTime OrderDate)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.Freight = Freight;
        this.ShipCountry = ShipCountry;
        this.ShipCity = ShipCity;
        this.ShipAddress = ShipAddress;
        this.OrderDate = OrderDate;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (Order.Count == 0)
        {
            Order.Add(new OrderDetails(10248, "VINET", 32.38, "France", "Reims", "59 rue de l Abbaye", new DateTime(1996, 7, 4)));
            Order.Add(new OrderDetails(10249, "TOMSP", 11.61, "Germany", "Münster", "Luisenstr. 48", new DateTime(1996, 7, 5)));
            Order.Add(new OrderDetails(10250, "HANAR", 65.83, "Brazil", "Rio de Janeiro", "Rua do Paço, 67", new DateTime(1996, 7, 8)));
            Order.Add(new OrderDetails(10251, "VICTE", 41.34, "France", "Lyon", "2, rue du Commerce", new DateTime(1996, 7, 8)));
            Order.Add(new OrderDetails(10252, "SUPRD", 51.3, "Belgium", "Charleroi", "Boulevard Tirou, 255", new DateTime(1996, 7, 9)));
            Order.Add(new OrderDetails(10253, "HANAR", 58.17, "Brazil", "Rio de Janeiro", "Rua do Paço, 67", new DateTime(1996, 7, 10)));
            Order.Add(new OrderDetails(10254, "CHOPS", 22.98, "Switzerland", "Bern", "Hauptstr. 31", new DateTime(1996, 7, 11)));
            Order.Add(new OrderDetails(10255, "RICSU", 148.33, "Switzerland", "Genève", "Starenweg 5", new DateTime(1996, 7, 12)));
            Order.Add(new OrderDetails(10256, "WELLI", 13.97, "Brazil", "Resende", "Rua do Mercado, 12", new DateTime(1996, 7, 15)));
            Order.Add(new OrderDetails(10257, "HILAA", 81.91, "Venezuela", "San Cristóbal", "Carrera 22 con Ave. Carlos Soublette #8-35", new DateTime(1996, 7, 16)));
            Order.Add(new OrderDetails(10258, "ERNSH", 140.51, "Austria", "Graz", "Kirchgasse 6", new DateTime(1996, 7, 17)));
            Order.Add(new OrderDetails(10259, "CENTC", 3.25, "Mexico", "México D.F.", "Sierras de Granada 9993", new DateTime(1996, 7, 18)));
            Order.Add(new OrderDetails(10260, "OTTIK", 55.09, "Germany", "Köln", "Mehrheimerstr. 369", new DateTime(1996, 7, 19)));
            Order.Add(new OrderDetails(10261, "QUEDE", 3.05, "Brazil", "Rio de Janeiro", "Rua da Panificadora, 12", new DateTime(1996, 7, 19)));
            Order.Add(new OrderDetails(10262, "RATTC", 48.29, "USA", "Albuquerque", "2817 Milton Dr.", new DateTime(1996, 7, 22)));
        }
        return Order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCountry { get; set; }
    public string ShipCity { get; set; }
    public string ShipAddress { get; set; }
    public DateTime OrderDate { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rDLIDCZkVpxqbOjj?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %} 

> In the above sample, the textbox rendered for **OrderID** column inside the inline editing template is disabled using its `Enabled` property to prevent editing of the primary key column.

## Dialog template editing

To know about customizing the **Dialog Template** in Blazor DataGrid Component, you can check this video.

{% youtube
"youtube:https://www.youtube.com/watch?v=Cfj476xT2ao"%}

The Dialog template editing feature in Syncfusion<sup style="font-size:70%">&reg;</sup> DataGrid allows customization of the default dialog editing behavior, enabling individuals to define custom editors for grid rows within a dialog. To implement this, set the [GridEditSettings.Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_Mode) property as **Dialog** and wrap the desired HTML editor elements inside the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_Template) property of the [GridEditSettings](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Grids.GridEditSettings.html). This feature is particularly useful for designing highly customized edit dialogs or including additional fields that are not part of the column model.

> Custom components used within the dialog template must be bound with two-way data binding (**@bind-Value**) to ensure synchronization with the grid's data.

In some cases, you want to add new field editors in the dialog which are not present in the column model. In that situation the dialog template will help us to customize the default edit dialog.

In the following sample, grid enabled with dialog template editing.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Calendars
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Inputs

<SfGrid DataSource="@OrderData" Toolbar="@(new string[] { "Add", "Edit", "Delete", "Update", "Cancel" })">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Dialog="DialogParams" Mode="EditMode.Dialog">
        <Template>
            @{
                var Order = (context as OrderDetails);
                <div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <SfNumericTextBox ID="OrderID" @bind-Value="@(Order.OrderID)" Enabled="@((Order.OrderID == 0) ? true : false)" FloatLabelType="FloatLabelType.Always" Placeholder="Order ID"></SfNumericTextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <SfTextBox ID="CustomerID" @bind-Value="@(Order.CustomerID)" TValue="string" FloatLabelType="FloatLabelType.Always" Placeholder="Customer Name">
                            </SfTextBox>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <SfNumericTextBox ID="Freight" @bind-Value="@(Order.Freight)" TValue="double" FloatLabelType="FloatLabelType.Always" Placeholder="Freight"></SfNumericTextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <SfDatePicker ID="OrderDate" @bind-Value="@(Order.OrderDate)" FloatLabelType="FloatLabelType.Always" Placeholder="Order Date">
                            </SfDatePicker>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <SfDropDownList ID="ShipCountry" TItem="Country" @bind-Value="@(Order.ShipCountry)" TValue="string" DataSource="@CountryName" FloatLabelType="FloatLabelType.Always" Placeholder="Ship Country">
                                <DropDownListFieldSettings Value="ShipCountry" Text="ShipCountry"></DropDownListFieldSettings>
                            </SfDropDownList>
                        </div>
                        <div class="form-group col-md-6">
                            <SfDropDownList ID="ShipCity" TItem="City" @bind-Value="@(Order.ShipCity)" TValue="string" DataSource="@CityName" FloatLabelType="FloatLabelType.Always" Placeholder="Ship City">
                                <DropDownListFieldSettings Value="ShipCity" Text="ShipCity"></DropDownListFieldSettings>
                            </SfDropDownList>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-12">
                            <SfTextBox ID="ShipAddress" Multiline="true" @bind-Value="@(Order.ShipAddress)" FloatLabelType="FloatLabelType.Always" Placeholder="Ship Address"></SfTextBox>
                        </div>
                    </div>
                </div>
            }
        </Template>        
    </GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required=true})"  Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" ValidationRules="@(new ValidationRules{ Required=true, Min=1})" Format="C2" Width="140" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.OrderDate) HeaderText="Order Date" ValidationRules="@(new ValidationRules{ Required=true})" Format="d" TextAlign="TextAlign.Right" Type="ColumnType.Date" Width="160"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private DialogSettings DialogParams = new DialogSettings { MinHeight = "400px", Width = "450px" };
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
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
    public OrderDetails(int OrderID, string CustomerId, double Freight, string ShipCountry, string ShipCity, string ShipAddress, DateTime OrderDate)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.Freight = Freight;
        this.ShipCountry = ShipCountry;
        this.ShipCity = ShipCity;
        this.ShipAddress = ShipAddress;
        this.OrderDate = OrderDate;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (Order.Count == 0)
        {
            Order.Add(new OrderDetails(10248, "VINET", 32.38, "France", "Reims", "59 rue de l Abbaye", new DateTime(1996, 7, 4)));
            Order.Add(new OrderDetails(10249, "TOMSP", 11.61, "Germany", "Münster", "Luisenstr. 48", new DateTime(1996, 7, 5)));
            Order.Add(new OrderDetails(10250, "HANAR", 65.83, "Brazil", "Rio de Janeiro", "Rua do Paço, 67", new DateTime(1996, 7, 8)));
            Order.Add(new OrderDetails(10251, "VICTE", 41.34, "France", "Lyon", "2, rue du Commerce", new DateTime(1996, 7, 8)));
            Order.Add(new OrderDetails(10252, "SUPRD", 51.3, "Belgium", "Charleroi", "Boulevard Tirou, 255", new DateTime(1996, 7, 9)));
            Order.Add(new OrderDetails(10253, "HANAR", 58.17, "Brazil", "Rio de Janeiro", "Rua do Paço, 67", new DateTime(1996, 7, 10)));
            Order.Add(new OrderDetails(10254, "CHOPS", 22.98, "Switzerland", "Bern", "Hauptstr. 31", new DateTime(1996, 7, 11)));
            Order.Add(new OrderDetails(10255, "RICSU", 148.33, "Switzerland", "Genève", "Starenweg 5", new DateTime(1996, 7, 12)));
            Order.Add(new OrderDetails(10256, "WELLI", 13.97, "Brazil", "Resende", "Rua do Mercado, 12", new DateTime(1996, 7, 15)));
            Order.Add(new OrderDetails(10257, "HILAA", 81.91, "Venezuela", "San Cristóbal", "Carrera 22 con Ave. Carlos Soublette #8-35", new DateTime(1996, 7, 16)));
            Order.Add(new OrderDetails(10258, "ERNSH", 140.51, "Austria", "Graz", "Kirchgasse 6", new DateTime(1996, 7, 17)));
            Order.Add(new OrderDetails(10259, "CENTC", 3.25, "Mexico", "México D.F.", "Sierras de Granada 9993", new DateTime(1996, 7, 18)));
            Order.Add(new OrderDetails(10260, "OTTIK", 55.09, "Germany", "Köln", "Mehrheimerstr. 369", new DateTime(1996, 7, 19)));
            Order.Add(new OrderDetails(10261, "QUEDE", 3.05, "Brazil", "Rio de Janeiro", "Rua da Panificadora, 12", new DateTime(1996, 7, 19)));
            Order.Add(new OrderDetails(10262, "RATTC", 48.29, "USA", "Albuquerque", "2817 Milton Dr.", new DateTime(1996, 7, 22)));
        }
        return Order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCountry { get; set; }
    public string ShipCity { get; set; }
    public string ShipAddress { get; set; }
    public DateTime OrderDate { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZLIjCXEfrNMUTiV?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %} 

> In the above sample code, the textbox rendered for **OrderID** column inside the dialog template is disabled using its `Enabled` property to prevent editing of the primary key column.

### Disable components in dialog template

In the Syncfusion<sup style="font-size:70%">&reg;</sup> DataGrid, you can disable specific components rendered inside the dialog template based on the data source values. This is achieved by setting the `Enabled` property of the components, which controls whether the component is enabled or disabled.

To dynamically modify the `Enabled` property of components within the dialog template, you can use the [RowCreating](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowCreating) and [OnBeginEdit](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnBeginEdit) events of the grid. These events are triggered before adding a new record or editing an existing record, respectively, allowing you to conditionally disable components based on your requirements.

In the following sample, the `Enabled` property of the **OrderID** textbox is toggled based on the operation type (add or edit) using the `RowCreating` and `OnBeginEdit` events.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Calendars
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Inputs

<SfGrid DataSource="@OrderData" Toolbar="@(new string[] { "Add", "Edit", "Delete", "Update", "Cancel" })">
    <GridEvents OnBeginEdit="OnBeginEdit" RowCreating="RowCreating" TValue="OrderDetails"></GridEvents>
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Dialog">
        <Template>
            @{
                var Order = (context as OrderDetails);
                <div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <SfNumericTextBox ID="OrderID" @bind-Value="@(Order.OrderID)" Enabled="IdEnabled" FloatLabelType="FloatLabelType.Always" Placeholder="Order ID"></SfNumericTextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <SfTextBox ID="CustomerID" @bind-Value="@(Order.CustomerID)" TValue="string" FloatLabelType="FloatLabelType.Always" Placeholder="Customer Name">
                            </SfTextBox>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <SfNumericTextBox ID="Freight" @bind-Value="@(Order.Freight)" TValue="double" FloatLabelType="FloatLabelType.Always" Placeholder="Freight"></SfNumericTextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <SfDatePicker ID="OrderDate" @bind-Value="@(Order.OrderDate)" FloatLabelType="FloatLabelType.Always" Placeholder="Order Date">
                            </SfDatePicker>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <SfDropDownList ID="ShipCountry" TItem="Country" @bind-Value="@(Order.ShipCountry)" TValue="string" DataSource="@CountryName" FloatLabelType="FloatLabelType.Always" Placeholder="Ship Country">
                                <DropDownListFieldSettings Value="ShipCountry" Text="ShipCountry"></DropDownListFieldSettings>
                            </SfDropDownList>
                        </div>
                        <div class="form-group col-md-6">
                            <SfDropDownList ID="ShipCity" TItem="City" @bind-Value="@(Order.ShipCity)" TValue="string" DataSource="@CityName" FloatLabelType="FloatLabelType.Always" Placeholder="Ship City">
                                <DropDownListFieldSettings Value="ShipCity" Text="ShipCity"></DropDownListFieldSettings>
                            </SfDropDownList>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-12">
                            <SfTextBox ID="ShipAddress" Multiline="true" @bind-Value="@(Order.ShipAddress)" FloatLabelType="FloatLabelType.Always" Placeholder="Ship Address"></SfTextBox>
                        </div>
                    </div>
                </div>
            }
        </Template>        
    </GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required=true})"  Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" ValidationRules="@(new ValidationRules{ Required=true, Min=1})" Format="C2" Width="140" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.OrderDate) HeaderText="Order Date" ValidationRules="@(new ValidationRules{ Required=true})" Format="d" TextAlign="TextAlign.Right" Type="ColumnType.Date" Width="160"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public bool IdEnabled = true;
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
    public void OnBeginEdit(BeginEditArgs<OrderDetails> args)
    {
        IdEnabled = false;
    }
    public void RowCreating(RowCreatingEventArgs<OrderDetails> args)
    {
        IdEnabled = true;
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
    public OrderDetails(int OrderID, string CustomerId, double Freight, string ShipCountry, string ShipCity, string ShipAddress, DateTime OrderDate)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.Freight = Freight;
        this.ShipCountry = ShipCountry;
        this.ShipCity = ShipCity;
        this.ShipAddress = ShipAddress;
        this.OrderDate = OrderDate;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (Order.Count == 0)
        {
            Order.Add(new OrderDetails(10248, "VINET", 32.38, "France", "Reims", "59 rue de l Abbaye", new DateTime(1996, 7, 4)));
            Order.Add(new OrderDetails(10249, "TOMSP", 11.61, "Germany", "Münster", "Luisenstr. 48", new DateTime(1996, 7, 5)));
            Order.Add(new OrderDetails(10250, "HANAR", 65.83, "Brazil", "Rio de Janeiro", "Rua do Paço, 67", new DateTime(1996, 7, 8)));
            Order.Add(new OrderDetails(10251, "VICTE", 41.34, "France", "Lyon", "2, rue du Commerce", new DateTime(1996, 7, 8)));
            Order.Add(new OrderDetails(10252, "SUPRD", 51.3, "Belgium", "Charleroi", "Boulevard Tirou, 255", new DateTime(1996, 7, 9)));
            Order.Add(new OrderDetails(10253, "HANAR", 58.17, "Brazil", "Rio de Janeiro", "Rua do Paço, 67", new DateTime(1996, 7, 10)));
            Order.Add(new OrderDetails(10254, "CHOPS", 22.98, "Switzerland", "Bern", "Hauptstr. 31", new DateTime(1996, 7, 11)));
            Order.Add(new OrderDetails(10255, "RICSU", 148.33, "Switzerland", "Genève", "Starenweg 5", new DateTime(1996, 7, 12)));
            Order.Add(new OrderDetails(10256, "WELLI", 13.97, "Brazil", "Resende", "Rua do Mercado, 12", new DateTime(1996, 7, 15)));
            Order.Add(new OrderDetails(10257, "HILAA", 81.91, "Venezuela", "San Cristóbal", "Carrera 22 con Ave. Carlos Soublette #8-35", new DateTime(1996, 7, 16)));
            Order.Add(new OrderDetails(10258, "ERNSH", 140.51, "Austria", "Graz", "Kirchgasse 6", new DateTime(1996, 7, 17)));
            Order.Add(new OrderDetails(10259, "CENTC", 3.25, "Mexico", "México D.F.", "Sierras de Granada 9993", new DateTime(1996, 7, 18)));
            Order.Add(new OrderDetails(10260, "OTTIK", 55.09, "Germany", "Köln", "Mehrheimerstr. 369", new DateTime(1996, 7, 19)));
            Order.Add(new OrderDetails(10261, "QUEDE", 3.05, "Brazil", "Rio de Janeiro", "Rua da Panificadora, 12", new DateTime(1996, 7, 19)));
            Order.Add(new OrderDetails(10262, "RATTC", 48.29, "USA", "Albuquerque", "2817 Milton Dr.", new DateTime(1996, 7, 22)));
        }
        return Order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCountry { get; set; }
    public string ShipCity { get; set; }
    public string ShipAddress { get; set; }
    public DateTime OrderDate { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDLSDiXETysiUAfk?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %} 

### Get value from editor

The get value from editor feature in the Syncfusion<sup style="font-size:70%">&reg;</sup> Grid allows you to read, format, and update the current editor value before it is saved. This feature is particularly valuable when you need to perform specific actions on the data, such as formatting before it is committed to the underlying data source. 

To achieve this feature, you can utilize the [RowUpdating](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowUpdating) event, which is triggered before the save action is performed in the grid.

In the following sample, the freight value has been formatted and updated using `RowUpdating`.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Calendars
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Inputs

<SfGrid DataSource="@OrderData" Toolbar="@(new string[] { "Add", "Edit", "Delete", "Update", "Cancel" })">
    <GridEvents RowUpdating="RowUpdating" TValue="OrderDetails"></GridEvents>
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Dialog">
        <Template>
            @{
                var Order = (context as OrderDetails);
                <div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <SfNumericTextBox ID="OrderID" @bind-Value="@(Order.OrderID)" Enabled="@((Order.OrderID == 0) ? true : false)" FloatLabelType="FloatLabelType.Always" Placeholder="Order ID"></SfNumericTextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <SfTextBox ID="CustomerID" @bind-Value="@(Order.CustomerID)" TValue="string" FloatLabelType="FloatLabelType.Always" Placeholder="Customer Name">
                            </SfTextBox>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <SfNumericTextBox ID="Freight" @bind-Value="@(Order.Freight)" TValue="double" FloatLabelType="FloatLabelType.Always" Placeholder="Freight"></SfNumericTextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <SfDatePicker ID="OrderDate" @bind-Value="@(Order.OrderDate)" FloatLabelType="FloatLabelType.Always" Placeholder="Order Date">
                            </SfDatePicker>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <SfDropDownList ID="ShipCountry" TItem="Country" @bind-Value="@(Order.ShipCountry)" TValue="string" DataSource="@CountryName" FloatLabelType="FloatLabelType.Always" Placeholder="Ship Country">
                                <DropDownListFieldSettings Value="ShipCountry" Text="ShipCountry"></DropDownListFieldSettings>
                            </SfDropDownList>
                        </div>
                        <div class="form-group col-md-6">
                            <SfDropDownList ID="ShipCity" TItem="City" @bind-Value="@(Order.ShipCity)" TValue="string" DataSource="@CityName" FloatLabelType="FloatLabelType.Always" Placeholder="Ship City">
                                <DropDownListFieldSettings Value="ShipCity" Text="ShipCity"></DropDownListFieldSettings>
                            </SfDropDownList>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-12">
                            <SfTextBox ID="ShipAddress" Multiline="true" @bind-Value="@(Order.ShipAddress)" FloatLabelType="FloatLabelType.Always" Placeholder="Ship Address"></SfTextBox>
                        </div>
                    </div>
                </div>
            }
        </Template>        
    </GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required=true})"  Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" ValidationRules="@(new ValidationRules{ Required=true, Min=1})" Format="C2" Width="140" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.OrderDate) HeaderText="Order Date" ValidationRules="@(new ValidationRules{ Required=true})" Format="d" TextAlign="TextAlign.Right" Type="ColumnType.Date" Width="160"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
    public void RowUpdating(RowUpdatingEventArgs<OrderDetails> args)
    {
        args.Data.Freight = Convert.ToInt32(args.Data.Freight);
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
    public OrderDetails(int OrderID, string CustomerId, double Freight, string ShipCountry, string ShipCity, string ShipAddress, DateTime OrderDate)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.Freight = Freight;
        this.ShipCountry = ShipCountry;
        this.ShipCity = ShipCity;
        this.ShipAddress = ShipAddress;
        this.OrderDate = OrderDate;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (Order.Count == 0)
        {
            Order.Add(new OrderDetails(10248, "VINET", 32.38, "France", "Reims", "59 rue de l Abbaye", new DateTime(1996, 7, 4)));
            Order.Add(new OrderDetails(10249, "TOMSP", 11.61, "Germany", "Münster", "Luisenstr. 48", new DateTime(1996, 7, 5)));
            Order.Add(new OrderDetails(10250, "HANAR", 65.83, "Brazil", "Rio de Janeiro", "Rua do Paço, 67", new DateTime(1996, 7, 8)));
            Order.Add(new OrderDetails(10251, "VICTE", 41.34, "France", "Lyon", "2, rue du Commerce", new DateTime(1996, 7, 8)));
            Order.Add(new OrderDetails(10252, "SUPRD", 51.3, "Belgium", "Charleroi", "Boulevard Tirou, 255", new DateTime(1996, 7, 9)));
            Order.Add(new OrderDetails(10253, "HANAR", 58.17, "Brazil", "Rio de Janeiro", "Rua do Paço, 67", new DateTime(1996, 7, 10)));
            Order.Add(new OrderDetails(10254, "CHOPS", 22.98, "Switzerland", "Bern", "Hauptstr. 31", new DateTime(1996, 7, 11)));
            Order.Add(new OrderDetails(10255, "RICSU", 148.33, "Switzerland", "Genève", "Starenweg 5", new DateTime(1996, 7, 12)));
            Order.Add(new OrderDetails(10256, "WELLI", 13.97, "Brazil", "Resende", "Rua do Mercado, 12", new DateTime(1996, 7, 15)));
            Order.Add(new OrderDetails(10257, "HILAA", 81.91, "Venezuela", "San Cristóbal", "Carrera 22 con Ave. Carlos Soublette #8-35", new DateTime(1996, 7, 16)));
            Order.Add(new OrderDetails(10258, "ERNSH", 140.51, "Austria", "Graz", "Kirchgasse 6", new DateTime(1996, 7, 17)));
            Order.Add(new OrderDetails(10259, "CENTC", 3.25, "Mexico", "México D.F.", "Sierras de Granada 9993", new DateTime(1996, 7, 18)));
            Order.Add(new OrderDetails(10260, "OTTIK", 55.09, "Germany", "Köln", "Mehrheimerstr. 369", new DateTime(1996, 7, 19)));
            Order.Add(new OrderDetails(10261, "QUEDE", 3.05, "Brazil", "Rio de Janeiro", "Rua da Panificadora, 12", new DateTime(1996, 7, 19)));
            Order.Add(new OrderDetails(10262, "RATTC", 48.29, "USA", "Albuquerque", "2817 Milton Dr.", new DateTime(1996, 7, 22)));
        }
        return Order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCountry { get; set; }
    public string ShipCity { get; set; }
    public string ShipAddress { get; set; }
    public DateTime OrderDate { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rDVSDiMXgcVQdJxD?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %} 

### Set focus to particular column editor

The Syncfusion<sup style="font-size:70%">&reg;</sup> Grid allows you to control the focus behavior of input elements in edit forms. By default, the first input element in the dialog receives focus when the dialog is opened. However, in scenarios where the first input element is disabled or hidden, you can specify which valid input element should receive focus. This can be achieved using the `Created` or `DataBound` event of the corresponding components.

In the following sample, the **CustomerID** column is focused by invoking its [FocusAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_FocusAsync) method within the AutoComplete's [DataBound](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.AutoCompleteEvents-2.html#Syncfusion_Blazor_DropDowns_AutoCompleteEvents_2_DataBound) event.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Calendars
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Inputs

<SfGrid DataSource="@OrderData" Toolbar="@(new string[] { "Add", "Edit", "Delete", "Update", "Cancel" })">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Dialog">
        <Template>
            @{
                var Order = (context as OrderDetails);
                <div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <SfNumericTextBox ID="OrderID" @bind-Value="@(Order.OrderID)" Enabled="@((Order.OrderID == 0) ? true : false)" FloatLabelType="FloatLabelType.Always" Placeholder="Order ID"></SfNumericTextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <SfAutoComplete ID="CustomerID" @ref="AutoComplete" TItem="OrderDetails" @bind-Value="@(Order.CustomerID)" TValue="string" DataSource="@OrderData" FloatLabelType="FloatLabelType.Always" Placeholder="Customer Name">
                                <AutoCompleteFieldSettings Value="CustomerID"></AutoCompleteFieldSettings>
                                <AutoCompleteEvents TValue="string" TItem="OrderDetails" DataBound="FocusCustomerColumn"></AutoCompleteEvents>
                            </SfAutoComplete>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <SfNumericTextBox ID="Freight" @bind-Value="@(Order.Freight)" TValue="double" FloatLabelType="FloatLabelType.Always" Placeholder="Freight"></SfNumericTextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <SfDatePicker ID="OrderDate" @bind-Value="@(Order.OrderDate)" FloatLabelType="FloatLabelType.Always" Placeholder="Order Date">
                            </SfDatePicker>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <SfDropDownList ID="ShipCountry" TItem="Country" @bind-Value="@(Order.ShipCountry)" TValue="string" DataSource="@CountryName" FloatLabelType="FloatLabelType.Always" Placeholder="Ship Country">
                                <DropDownListFieldSettings Value="ShipCountry" Text="ShipCountry"></DropDownListFieldSettings>
                            </SfDropDownList>
                        </div>
                        <div class="form-group col-md-6">
                            <SfDropDownList ID="ShipCity" TItem="City" @bind-Value="@(Order.ShipCity)" TValue="string" DataSource="@CityName" FloatLabelType="FloatLabelType.Always" Placeholder="Ship City">
                                <DropDownListFieldSettings Value="ShipCity" Text="ShipCity"></DropDownListFieldSettings>
                            </SfDropDownList>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-12">
                            <SfTextBox ID="ShipAddress" Multiline="true" @bind-Value="@(Order.ShipAddress)" FloatLabelType="FloatLabelType.Always" Placeholder="Ship Address"></SfTextBox>
                        </div>
                    </div>
                </div>
            }
        </Template>        
    </GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required=true})"  Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" ValidationRules="@(new ValidationRules{ Required=true, Min=1})" Format="C2" Width="140" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.OrderDate) HeaderText="Order Date" ValidationRules="@(new ValidationRules{ Required=true})" Format="d" TextAlign="TextAlign.Right" Type="ColumnType.Date" Width="160"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public SfAutoComplete<string, OrderDetails> AutoComplete { get; set; }
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
    public async Task FocusCustomerColumn()
    {
        await AutoComplete.FocusAsync();
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
    public OrderDetails(int OrderID, string CustomerId, double Freight, string ShipCountry, string ShipCity, string ShipAddress, DateTime OrderDate)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.Freight = Freight;
        this.ShipCountry = ShipCountry;
        this.ShipCity = ShipCity;
        this.ShipAddress = ShipAddress;
        this.OrderDate = OrderDate;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (Order.Count == 0)
        {
            Order.Add(new OrderDetails(10248, "VINET", 32.38, "France", "Reims", "59 rue de l Abbaye", new DateTime(1996, 7, 4)));
            Order.Add(new OrderDetails(10249, "TOMSP", 11.61, "Germany", "Münster", "Luisenstr. 48", new DateTime(1996, 7, 5)));
            Order.Add(new OrderDetails(10250, "HANAR", 65.83, "Brazil", "Rio de Janeiro", "Rua do Paço, 67", new DateTime(1996, 7, 8)));
            Order.Add(new OrderDetails(10251, "VICTE", 41.34, "France", "Lyon", "2, rue du Commerce", new DateTime(1996, 7, 8)));
            Order.Add(new OrderDetails(10252, "SUPRD", 51.3, "Belgium", "Charleroi", "Boulevard Tirou, 255", new DateTime(1996, 7, 9)));
            Order.Add(new OrderDetails(10253, "HANAR", 58.17, "Brazil", "Rio de Janeiro", "Rua do Paço, 67", new DateTime(1996, 7, 10)));
            Order.Add(new OrderDetails(10254, "CHOPS", 22.98, "Switzerland", "Bern", "Hauptstr. 31", new DateTime(1996, 7, 11)));
            Order.Add(new OrderDetails(10255, "RICSU", 148.33, "Switzerland", "Genève", "Starenweg 5", new DateTime(1996, 7, 12)));
            Order.Add(new OrderDetails(10256, "WELLI", 13.97, "Brazil", "Resende", "Rua do Mercado, 12", new DateTime(1996, 7, 15)));
            Order.Add(new OrderDetails(10257, "HILAA", 81.91, "Venezuela", "San Cristóbal", "Carrera 22 con Ave. Carlos Soublette #8-35", new DateTime(1996, 7, 16)));
            Order.Add(new OrderDetails(10258, "ERNSH", 140.51, "Austria", "Graz", "Kirchgasse 6", new DateTime(1996, 7, 17)));
            Order.Add(new OrderDetails(10259, "CENTC", 3.25, "Mexico", "México D.F.", "Sierras de Granada 9993", new DateTime(1996, 7, 18)));
            Order.Add(new OrderDetails(10260, "OTTIK", 55.09, "Germany", "Köln", "Mehrheimerstr. 369", new DateTime(1996, 7, 19)));
            Order.Add(new OrderDetails(10261, "QUEDE", 3.05, "Brazil", "Rio de Janeiro", "Rua da Panificadora, 12", new DateTime(1996, 7, 19)));
            Order.Add(new OrderDetails(10262, "RATTC", 48.29, "USA", "Albuquerque", "2817 Milton Dr.", new DateTime(1996, 7, 22)));
        }
        return Order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCountry { get; set; }
    public string ShipCity { get; set; }
    public string ShipAddress { get; set; }
    public DateTime OrderDate { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNhSNCsjpMQvVsVT?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %} 

## Render tab component inside the dialog template

You can enhance the editing experience in the Grid by rendering a [Tab](https://blazor.syncfusion.com/documentation/tabs/getting-started-webapp) component inside the dialog template. This feature is especially useful when you want to present multiple editing sections or categories in a tabbed layout, ensuring a more intuitive and easily navigable interface for data editing.

To enable this functionality, you need to set the [GridEditSettings.Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_Mode) property of the Grid to **Dialog**. This configures the Grid to use the dialog editing mode. Additionally, you can use the [GridEditSettings.Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_Template) property to define a template variable that contains the `Tab` component and its corresponding content.

The following example renders a tab component inside the edit dialog. The tab component has two tabs, and once you fill in the first tab and navigate to the second one, the validation for the first tab is performed before navigating to the second.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<SfGrid @ref="Grid" DataSource="@OrderData" Toolbar="@(new string[] { "Add", "Edit", "Delete", "Update", "Cancel" })">
    <GridEvents TValue="OrderDetails" RowCreating="RowCreating" OnBeginEdit="OnBeginEdit"></GridEvents>
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Dialog">
        <Template>
            @{
                var Order = (context as OrderDetails);
                <SfTab @ref="Tab">
                    <TabItems>
                       <TabEvents Selecting="OnTabSelecting"></TabEvents>
                        <TabItem>
                            <ChildContent>
                                <TabHeader Text="Details"></TabHeader>
                            </ChildContent>
                            <ContentTemplate>
                                <div id="tab1">
                                    <div class="form-row">
                                        <div class="form-group col-md-6">
                                            <SfNumericTextBox ID="OrderID" @bind-Value="@(Order.OrderID)" Enabled="@((Order.OrderID == 0) ? true : false)" FloatLabelType="FloatLabelType.Always" Placeholder="Order ID"></SfNumericTextBox>
                                        </div>
                                        <div class="form-group col-md-6">
                                            <SfTextBox ID="CustomerID" @bind-Value="@(Order.CustomerID)" TValue="string" FloatLabelType="FloatLabelType.Always" Placeholder="Customer Name">
                                            </SfTextBox>
                                        </div>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <SfDropDownList ID="ShipCountry" TItem="Country" @bind-Value="@(Order.ShipCountry)" TValue="string" DataSource="@CountryName" FloatLabelType="FloatLabelType.Always" Placeholder="Ship Country">
                                            <DropDownListFieldSettings Value="ShipCountry" Text="ShipCountry"></DropDownListFieldSettings>
                                        </SfDropDownList>
                                    </div>
                                    <div style="float: right; margin-top:5px">
                                        <SfButton CssClass="e-info" Content="Next" OnClick="MoveNext"></SfButton>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </TabItem>
                        <TabItem>
                            <ChildContent>
                                <TabHeader Text="Verify"></TabHeader>
                            </ChildContent>
                            <ContentTemplate>
                                <div class="form-row">
                                    <div class="form-group col-md-6">
                                        <SfNumericTextBox ID="Freight" @bind-Value="@(Order.Freight)" TValue="double" FloatLabelType="FloatLabelType.Always" Placeholder="Freight">
                                        </SfNumericTextBox>
                                    </div>
                                    <div class="form-group col-md-12">
                                        <SfTextBox ID="ShipAddress" Multiline="true" @bind-Value="@(Order.ShipAddress)" FloatLabelType="FloatLabelType.Always" Placeholder="Ship Address"></SfTextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <SfCheckBox @bind-Checked="@(Order.Verified)" Label="Verified"></SfCheckBox>
                                    </div>
                                </div>
                                <div style="float: right;">
                                    <SfButton CssClass="e-info" Content="Submit" OnClick="Submit"></SfButton>
                                </div>
                            </ContentTemplate>
                        </TabItem>
                    </TabItems>
                </SfTab>
            }
        </Template>
        <FooterTemplate>
        </FooterTemplate>
    </GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required=true})" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" ValidationRules="@(new ValidationRules{ Required=true, Min=1})" Format="C2" Width="140" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipAddress) HeaderText="Ship Address" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Verified) HeaderText="Verified" Type="ColumnType.Boolean" DisplayAsCheckBox="true" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public SfGrid<OrderDetails> Grid;
    private SfTab Tab;
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
    private OrderDetails CurrentEditingRecord { get; set; }
    private void MoveNext()
    {
        if (CurrentEditingRecord.OrderID == 0 || string.IsNullOrWhiteSpace(CurrentEditingRecord.CustomerID))
        {
            Tab.PreventRender(false);
        }
        else{
            Tab.SelectAsync(1);
        }
    }
    private void Submit()
    {
        Grid.EndEditAsync();
    }
    public void OnTabSelecting(SelectingEventArgs args)
    {
        if (CurrentEditingRecord.OrderID == 0 || string.IsNullOrWhiteSpace(CurrentEditingRecord.CustomerID) || CurrentEditingRecord.Freight <= 0)
        {
            args.Cancel = true;
        }
    }
    public void RowCreating(RowCreatingEventArgs<OrderDetails> args)
    {
        CurrentEditingRecord = args.Data;
    }
    public void OnBeginEdit(BeginEditArgs<OrderDetails> args)
    {
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
        new City() { ShipCity = "Bern" },
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
    public OrderDetails(int OrderID, string CustomerId, double Freight, string ShipCountry, string ShipAddress, bool Verified)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.Freight = Freight;
        this.ShipCountry = ShipCountry;
        this.ShipAddress = ShipAddress;
        this.Verified = Verified;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (Order.Count == 0)
        {
            Order.Add(new OrderDetails(10248, "VINET", 32.38, "France", "59 rue de l Abbaye", true));
            Order.Add(new OrderDetails(10249, "TOMSP", 11.61, "Germany", "Luisenstr. 48", false));
            Order.Add(new OrderDetails(10250, "HANAR", 65.83, "Brazil", "Rua do Paço, 67", true));
            Order.Add(new OrderDetails(10251, "VICTE", 41.34, "France", "2, rue du Commerce", true));
            Order.Add(new OrderDetails(10252, "SUPRD", 51.3, "Belgium", "Boulevard Tirou, 255", true));
            Order.Add(new OrderDetails(10253, "HANAR", 58.17, "Brazil", "Rua do Paço, 67", true));
            Order.Add(new OrderDetails(10254, "CHOPS", 22.98, "Switzerland", "Hauptstr. 31", false));
            Order.Add(new OrderDetails(10255, "RICSU", 148.33, "Switzerland", "Starenweg 5", true));
            Order.Add(new OrderDetails(10256, "WELLI", 13.97, "Brazil", "Rua do Mercado, 12", false));
            Order.Add(new OrderDetails(10257, "HILAA", 81.91, "Venezuela", "Carrera 22 con Ave. Carlos Soublette #8-35", true));
            Order.Add(new OrderDetails(10258, "ERNSH", 140.51, "Austria", "Kirchgasse 6", true));
            Order.Add(new OrderDetails(10259, "CENTC", 3.25, "Mexico", "Sierras de Granada 9993", false));
            Order.Add(new OrderDetails(10260, "OTTIK", 55.09, "Germany", "Mehrheimerstr. 369", true));
            Order.Add(new OrderDetails(10261, "QUEDE", 3.05, "Brazil", "Rua da Panificadora, 12", false));
            Order.Add(new OrderDetails(10262, "RATTC", 48.29, "USA", "2817 Milton Dr.", true));
        }
        return Order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCountry { get; set; }
    public string ShipAddress { get; set; }
    public bool Verified { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjroDWiAVWieIsqG?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %} 

### Complex data binding with dialog template

The Syncfusion<sup style="font-size:70%">&reg;</sup> DataGrid allows editing of complex objects in the [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) by utilizing a dialog template. This feature provides flexibility for managing hierarchical or nested data structures.

To bind and edit complex objects, you can render desired HTML editor elements or components such as `SfNumericTextBox` inside the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_Template) property of the [GridEditSettings](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Grids.GridEditSettings.html). The values of these components can be dynamically updated in the `GridColumn` using two-way (**@bind-Value**) data binding, ensuring real-time updates to the data.

> When working with complex columns, ensure that the **ID** property for the complex column is defined appropriately. Replace the dot operator (.) in the field value with ___ to maintain proper mapping and prevent runtime issues.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Inputs

<SfGrid DataSource="@EmployeeData" Toolbar="@(new string[] { "Add", "Edit", "Delete", "Update", "Cancel" })">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Dialog">
        <Template>
            @{
                var Employee = (context as EmployeeDetails);
            }
            <div class="form-row">
                <div class="form-group col-md-6">
                    <SfNumericTextBox TValue="int" ID="EmployeeID" Enabled="@((Employee.EmployeeID == 0) ? true : false)" @bind-Value="Employee.EmployeeID" FloatLabelType="FloatLabelType.Always" Placeholder="Employee ID"></SfNumericTextBox>
                </div>
                <div class="form-group col-md-6">
                    <SfTextBox ID="EmpDetails.FirstName" @bind-Value="@(Employee.EmpDetails.FirstName)" TValue="string" FloatLabelType="FloatLabelType.Always" Placeholder="First Name">
                    </SfTextBox>
                </div>
                <div class="form-group col-md-6">
                    <SfTextBox ID="EmpDetails.LastName" @bind-Value="@(Employee.EmpDetails.LastName)" TValue="string" FloatLabelType="FloatLabelType.Always" Placeholder="Last Name">
                    </SfTextBox>
                </div>
                <div class="form-group col-md-6">
                    <SfNumericTextBox TValue="int" ID="EmpDetails__SalaryDetails__Salary" @bind-Value="Employee.EmpDetails.SalaryDetails.Salary" Step=50 FloatLabelType="FloatLabelType.Always" Placeholder="Salary"></SfNumericTextBox>
                </div>
                 <div class="form-group col-md-6">
                    <SfTextBox ID="Title" @bind-Value="@(Employee.Title)" TValue="string" FloatLabelType="FloatLabelType.Always" Placeholder="Title">
                    </SfTextBox>
                </div>
            </div>
        </Template>
    </GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeDetails.EmployeeID) HeaderText="EmployeeID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true })" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field="EmpDetails.FirstName" HeaderText="First Name" ValidationRules="@(new ValidationRules{ Required=true })" Width="150"></GridColumn>
        <GridColumn Field="EmpDetails.LastName" HeaderText="Last Name" Width="130"></GridColumn>
        <GridColumn Field="EmpDetails.SalaryDetails.Salary" HeaderText="Salary" ValidationRules="@(new ValidationRules{ Required=true })" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.Title) HeaderText="Job Title" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<EmployeeDetails> EmployeeData { get; set; }
    protected override void OnInitialized()
    {
        EmployeeData = EmployeeDetails.GetAllRecords();
    }
}
{% endhighlight %}
{% highlight c# tabtitle="EmployeeDetails.cs" %}
public class EmployeeDetails
{
    public static List<EmployeeDetails> Employees = new List<EmployeeDetails>();
    public EmployeeDetails(int employeeID, string firstName, string lastName, string title, int salary)
    {
        EmployeeID = employeeID;
        EmpDetails = new EmployeeInfo
        {
            FirstName = firstName,
            LastName = lastName,
            SalaryDetails = new SalaryDetails { Salary = salary }
        };
        Title = title;
    }
    public static List<EmployeeDetails> GetAllRecords()
    {
        if (Employees.Count == 0)
        {
            Employees.Add(new EmployeeDetails(1, "Nancy", "Davolio", "Sales Representative", 60000));
            Employees.Add(new EmployeeDetails(2, "Andrew", "Fuller", "Vice President, Sales", 120000));
            Employees.Add(new EmployeeDetails(3, "Janet", "Leverling", "Sales Representative", 70000));
            Employees.Add(new EmployeeDetails(4, "Margaret", "Peacock", "Sales Representative", 68000));
            Employees.Add(new EmployeeDetails(5, "Steven", "Buchanan", "Sales Manager", 95000));
            Employees.Add(new EmployeeDetails(6, "Michael", "Suyama", "Sales Representative", 62000));
            Employees.Add(new EmployeeDetails(7, "Robert", "King", "Sales Representative", 65000));
            Employees.Add(new EmployeeDetails(8, "Laura", "Callahan", "Inside Sales Coordinator", 72000));
            Employees.Add(new EmployeeDetails(9, "Anne", "Dodsworth", "Sales Representative", 60000));
        }
        return Employees;
    }
    public int EmployeeID { get; set; }
    public EmployeeInfo EmpDetails { get; set; }
    public string Title { get; set; }
}
public class EmployeeInfo
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public SalaryDetails salarydetails { get; set; }
}
public class SalaryDetails
{
    public int Salary { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hDLetiCKJZroywnF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Use FileUploader in Grid dialog edit template

You can upload an image while adding or editing the column and show that image in the grid column using the Column Template and Dialog Template features of the grid. The Column Template feature is used to display the image in a grid column, and the Dialog Template feature is used to render the `SfUploader` component for uploading the image while performing dialog editing.

In the following sample, the add, edit and save operations of dialog editing are performed using the [RowCreating](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowCreating), [RowEditing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowEditing) and [RowUpdating](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowUpdating) events of the grid. The image file selecting and uploading actions are performed using the [FileSelected](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_FileSelected) and [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_ValueChange) events of the `SfUploader`.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Inputs
@using System.IO

<SfGrid AllowPaging="true" @ref="Grid" DataSource="@EmployeeData" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })">
    <GridEvents TValue="@EmployeeDetails" RowEditing="RowEditingHandler" RowCreating="RowAddingHandler" RowUpdating="RowUpdatingHandler"></GridEvents>
    <GridEditSettings AllowEditing="true" AllowDeleting="true" AllowAdding="true" Mode="EditMode.Dialog">
        <Template>
            @{
                var Employee = (context as EmployeeDetails);
            }
            <div>
                <table>
                    <tbody>
                        <tr>
                            <td>
                                <SfNumericTextBox ID="EmployeeID" @bind-Value="@(Employee.EmployeeID)" Enabled="@((Employee.EmployeeID == 0) ? true : false)" FloatLabelType="FloatLabelType.Always" Placeholder="Employee ID"></SfNumericTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <SfTextBox ID="EmployeeName" @bind-Value="@(Employee.EmployeeName)" TValue="string" FloatLabelType="FloatLabelType.Always" Placeholder="Employee Name">
                                </SfTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span>Employee Image</span>
                            </td>
                            <td>
                                <div class="image"><img class="upload-image" style="margin-top: 10px;margin-left: -50px;" src="@Employee.ImageUrl" /></div>
                            </td>
                        </tr>
                        <tr>
                            <div class="image" style="margin-top: 10px; width: 300px">
                                <SfUploader ID="uploadFiles" AllowedExtensions=".jpg,.png,.jpeg">
                                    <UploaderEvents ValueChange="OnChange" FileSelected="Selected"></UploaderEvents>
                                    <UploaderTemplates>
                                        <Template Context="HttpContext">
                                            @{
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <span>Updated Employee Image</span>
                                                        </td>
                                                        <td>
                                                            <img class="upload-image" style="margin-left:10px;" src="@(files.Count >0 ? files.Where(item=>item.Name == HttpContext.Name)?.FirstOrDefault()?.Path : string.Empty)">
                                                        </td>
                                                    </tr>
                                                </table>
                                            }
                                        </Template>
                                    </UploaderTemplates>
                                </SfUploader>
                            </div>
                        </tr>
                    </tbody>
                </table>
            </div>
        </Template>
    </GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeDetails.EmployeeID) HeaderText="Employee ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="@TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.EmployeeName) HeaderText="Employee Name" Width="140"></GridColumn>
        <GridColumn Field="ImageUrl" HeaderText="Employee Image" Width="200">
            <Template>
                @{
                    var imageUrl = (context as EmployeeDetails).ImageUrl;
                    <div class="image">
                        <img src="@imageUrl" />
                    </div>
                }
            </Template>
        </GridColumn>
    </GridColumns>
</SfGrid>
<style>
    .image img {
        height: 55px;
        width: 55px;
        border-radius: 50px;
        box-shadow: inset 0 0 1px #e0e0e0, inset 0 0 14px rgba(0, 0, 0, 0.2);
    }
</style>
@code {
    public List<fileInfo> files = new List<fileInfo>();
    public SfGrid<EmployeeDetails> Grid { get; set; }
    public string UploadedFile { get; set; }
    public List<EmployeeDetails> EmployeeData { get; set; }
   
    public void RowAddingHandler(RowCreatingEventArgs<EmployeeDetails> args)
    {
        Grid.PreventRender(false);
    }
    public void RowEditingHandler(RowEditingEventArgs<EmployeeDetails> args)
    {
         Grid.PreventRender(false);
    }
    public void RowUpdatingHandler(RowUpdatingEventArgs<EmployeeDetails> args)
    {
       args.Data.ImageUrl = "scripts/Images/Employees/" + UploadedFile;
    }
    public void OnChange(UploadChangeEventArgs args)
    {
        files = new List<fileInfo>();
        foreach (var file in args.Files)
        {
            var path = Path.GetFullPath("wwwroot\\scripts\\Images\\Employees\\") + file.FileInfo.Name;
            FileStream filestream = new FileStream(path, FileMode.Create, FileAccess.Write);
            file.Stream.WriteTo(filestream);
            filestream.Close();
            file.Stream.Close();
            files.Add(new fileInfo() { Path = "scripts/Images/Employees/" + file.FileInfo.Name, Name = file.FileInfo.Name, Size = file.FileInfo.Size });
        }
    }
    public void Selected(SelectedEventArgs Args)
    {
        UploadedFile = Args.FilesData[0].Name;
    }
    protected override void OnInitialized()
    {
        EmployeeData = Enumerable.Range(1, 9).Select(x => new EmployeeDetails()
            {
                EmployeeID = x,
                EmployeeName = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
                ImageUrl = "scripts/Images/Employees/" + x + ".png",
            }).ToList();
    }
    public class EmployeeDetails
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string ImageUrl { get; set; }
    }
    public class fileInfo
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public double Size { get; set; }
    }
}
{% endhighlight %}
{% endtabs %}

> You can find the fully working sample [here](https://github.com/SyncfusionExamples/blazor-datagrid-crud-dialog-fileuploader)

## See Also

* [Display validation message in dialog template](https://blazor.syncfusion.com/documentation/datagrid/column-validation#display-validation-message-in-dialog-template)