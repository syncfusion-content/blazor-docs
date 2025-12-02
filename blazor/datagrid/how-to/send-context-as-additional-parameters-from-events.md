---
layout: post
title: Send Context as Parameters in Blazor DataGrid | Syncfusion
description: Learn how to Pass current row context from Blazor DataGrid events using edit templates to update bound fields instantly.
platform: Blazor
control: DataGrid
documentation: ug
---

# Sending context as additional parameters in Blazor DataGrid events

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports passing the current row context to event handlers. This approach is useful for updating Grid fields based on interactions inside the edit dialog, enabling immediate, in-place updates to the bound data.

To implement this, follow these steps:

   1. Place the [ComboBox](https://blazor.syncfusion.com/documentation/combobox/getting-started-with-web-app) inside the Grid's `GridEditSettings.Template` to customize the edit form.

   2. Bind the ComboBox’s `ValueChange` event to a handler method.

   3. The handler receives:
      * args: Event arguments that include the new ComboBox value and the selected item.
      * context: The template context cast to the row type (Order) and stored in a local variable (order).

   4. Inside the handler, update properties of the current row (for example, ShipCity and ShipCountry) based on the selected ComboBox value. Because the Grid is bound to the same data object instance, changes are reflected immediately in the Grid UI.

The following example demonstrates this approach:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Inputs
@using System.Collections.Generic

<SfGrid ID="Grid" TValue="Order" DataSource="@Orders"
Toolbar="@(new List<string>{ "Add", "Edit", "Delete", "Update" })"
Height="600" @ref="Grid">
  <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="Syncfusion.Blazor.Grids.EditMode.Dialog">
    <Template Context="context">
      @{
        var order = context as Order;
      }
      <div class="row">
        <div class="col-6">
          <SfNumericTextBox TValue="int" @bind-Value="order.OrderID" Placeholder="Order ID" FloatLabelType="FloatLabelType.Always" />
        </div>
        <div class="col-6">
          <SfComboBox TValue="string" TItem="Customer" DataSource="@Customers" @bind-Value="order.CustomerID"
          Placeholder="Select Customer" FloatLabelType="FloatLabelType.Always" AllowFiltering="true">
            <ComboBoxFieldSettings Value="CustomerID" Text="CustomerName"></ComboBoxFieldSettings>
           <ComboBoxEvents TValue="string" TItem="Customer" ValueChange="args => OnCustomerChange(args, order)"></ComboBoxEvents>
          </SfComboBox>
        </div>
      </div>
      <div class="row mt-3">
        <div class="col-6">
          <SfTextBox @bind-Value="order.ShipCity" Placeholder="Ship City" FloatLabelType="FloatLabelType.Always" />
        </div>
        <div class="col-6">
          <SfTextBox @bind-Value="order.ShipCountry" Placeholder="Ship Country" FloatLabelType="FloatLabelType.Always" />
        </div>
      </div>
      <div class="row mt-3">
        <div class="col-6">
          <SfNumericTextBox TValue="int" @bind-Value="order.EmployeeID" Placeholder="Employee ID" FloatLabelType="FloatLabelType.Always" />
        </div>
      </div>
    </Template>
  </GridEditSettings>
  <GridColumns>
    <GridColumn Field="OrderID" HeaderText="Order ID" IsPrimaryKey="true" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120" />
    <GridColumn Field="CustomerID" HeaderText="Customer Name" Width="200" />
    <GridColumn Field="ShipCity" HeaderText="Ship City" Width="150" />
    <GridColumn Field="ShipCountry" HeaderText="Ship Country" Width="150" />
    <GridColumn Field="EmployeeID" HeaderText="Employee ID" Width="120" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" />
  </GridColumns>
</SfGrid>

@code {
  private SfGrid<Order> Grid;

  public List<Customer> Customers = new()
  {
    new Customer { CustomerID = "ALFKI", CustomerName = "Alfreds Futterkiste" },
    new Customer { CustomerID = "ANATR", CustomerName = "Ana Trujillo Emparedados" },
    new Customer { CustomerID = "ANTON", CustomerName = "Antonio Moreno" },
    new Customer { CustomerID = "AROUT", CustomerName = "Around the Horn" },
    new Customer { CustomerID = "BERGS", CustomerName = "Berglunds snabbköp" }
  };

  public List<Order> Orders { get; set; } = new()
  {
    new Order { OrderID = 1001, CustomerID = "ALFKI", EmployeeID = 1, ShipCity = "Berlin", ShipCountry = "Germany" },
    new Order { OrderID = 1002, CustomerID = "ANATR", EmployeeID = 2, ShipCity = "Mexico D.F.", ShipCountry = "Mexico" },
    new Order { OrderID = 1003, CustomerID = "ANTON", EmployeeID = 3, ShipCity = "Madrid", ShipCountry = "Spain" },
    new Order { OrderID = 1004, CustomerID = "AROUT", EmployeeID = 4, ShipCity = "London", ShipCountry = "UK" },
    new Order { OrderID = 1005, CustomerID = "ALFKI", EmployeeID = 1, ShipCity = "Berlin", ShipCountry = "Germany" },
    new Order { OrderID = 1006, CustomerID = "ANATR", EmployeeID = 2, ShipCity = "Mexico D.F.", ShipCountry = "Mexico" },
    new Order { OrderID = 1007, CustomerID = "ANTON", EmployeeID = 3, ShipCity = "Madrid", ShipCountry = "Spain" },
    new Order { OrderID = 1008, CustomerID = "AROUT", EmployeeID = 4, ShipCity = "London", ShipCountry = "UK" },
    new Order { OrderID = 1009, CustomerID = "ALFKI", EmployeeID = 1, ShipCity = "Berlin", ShipCountry = "Germany" },
    new Order { OrderID = 1010, CustomerID = "ANATR", EmployeeID = 2, ShipCity = "Mexico D.F.", ShipCountry = "Mexico" },
    new Order { OrderID = 1011, CustomerID = "ANTON", EmployeeID = 3, ShipCity = "Madrid", ShipCountry = "Spain" },
    new Order { OrderID = 1012, CustomerID = "AROUT", EmployeeID = 4, ShipCity = "London", ShipCountry = "UK" },
    new Order { OrderID = 1013, CustomerID = "ALFKI", EmployeeID = 1, ShipCity = "Berlin", ShipCountry = "Germany" },
    new Order { OrderID = 1014, CustomerID = "ANATR", EmployeeID = 2, ShipCity = "Mexico D.F.", ShipCountry = "Mexico" },
    new Order { OrderID = 1015, CustomerID = "ANTON", EmployeeID = 3, ShipCity = "Madrid", ShipCountry = "Spain" }
  };

  private void OnCustomerChange(ChangeEventArgs<string, Customer> args, Order order)
  {
    if (args.ItemData != null)
    {
      Grid.PreventRender(false);
      switch (args.ItemData.CustomerID)
      {
        case "ALFKI":
          order.ShipCity = "Berlin";
          order.ShipCountry = "Germany";
          break;
        case "ANATR":
          order.ShipCity = "Mexico D.F.";
          order.ShipCountry = "Mexico";
          break;
        case "ANTON":
          order.ShipCity = "Madrid";
          order.ShipCountry = "Spain";
          break;
        default:
          break;
      }
    }
  }

  public class Order
  {
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public int EmployeeID { get; set; }
    public string ShipCity { get; set; }
    public string ShipCountry { get; set; }
  }

  public class Customer
  {
    public string CustomerID { get; set; }
    public string CustomerName { get; set; }
  }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZhIXYrfAswqgaHD?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}
