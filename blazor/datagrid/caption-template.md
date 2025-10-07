---
layout: post
title: Caption template in Blazor DataGrid | Syncfusion
description: Learn how to customize group caption rows in Syncfusion Blazor DataGrid using CaptionTemplate and CaptionTemplateContext.
platform: Blazor
control: DataGrid
documentation: ug
---

# Caption template in Blazor DataGrid

The caption template feature in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid customizes the content of group caption rows. It can display additional information about grouped data (such as the grouped value and record count) and render custom content including images, icons, or other Razor components. This enables clear, informative, and visually rich group captions in the DataGrid.

Use the [CaptionTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html#Syncfusion_Blazor_Grids_GridGroupSettings_CaptionTemplate) property to define the template. Cast the context to [CaptionTemplateContext](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.CaptionTemplateContext.html) to access properties for the current group:
- **Field**: grouped column field name
- **HeaderText**: grouped column header text
- **Key**: grouped value
- **Count**: number of records in the group

The following example demonstrates customizing the group caption using `CaptionTemplate`. It displays the `HeaderText`, `Key`, and `Count` of the grouped column:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid  DataSource="@GridData" AllowGrouping="true" Height="315px">
    <GridGroupSettings ShowDropArea="false" Columns="@Initial">
        <CaptionTemplate>
            @{
                var data = (context as CaptionTemplateContext);
                <span>@data.HeaderText - @data.Key : @data.Count Items </span>
            }
        </CaptionTemplate>
    </GridGroupSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; }
    public string[] Initial = (new string[] { "CustomerID", "ShipCity" });

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>(); 
    public OrderData() {}
    public OrderData(int? OrderID,string CustomerID,string ShipCity, string ShipName)
    {
        this.OrderID = OrderID;    
        this.CustomerID = CustomerID;
        this.ShipCity = ShipCity;
        this.ShipName = ShipName;             
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count() == 0)
        {
            int code = 10;
            for (int i = 1; i < 2; i++)
            {
                    Orders.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcools Chevali"));
                    Orders.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
                    Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
                    Orders.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock"));
                    Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
                    Orders.Add(new OrderData(10253, "HANAR", "Lyon", "Hanari Carnes"));
                    Orders.Add(new OrderData(10254, "CHOPS", "Rio de Janeiro", "Chop-suey Chinese"));
                    Orders.Add(new OrderData(10255, "RICSU", "Münster", "Richter Supermarkt"));
                    Orders.Add(new OrderData(10256, "WELLI", "Reims", "Wellington Import"));
                    code += 5;
            }
        }
        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtBzXMjlgozlWLsz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Adding custom text in group caption

The DataGrid supports adding custom text to group captions for clearer context. Use the [CaptionTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html#Syncfusion_Blazor_Grids_GridGroupSettings_CaptionTemplate) property to output any text or markup, combined with values from [CaptionTemplateContext](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.CaptionTemplateContext.html) such as `Key`, `Count`, and `HeaderText`.

The following example adds a custom string along with the group key, record count, and header text:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid  DataSource="@GridData" AllowGrouping="true" Height="315px">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Name" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="value" Width="80"></GridColumn>
    </GridColumns>
    <GridGroupSettings>
        <CaptionTemplate>
            @{
                var order = (context as CaptionTemplateContext);
                <span>@order.Key - @order.Count Records : @order.HeaderText</span>
            }
        </CaptionTemplate>
    </GridGroupSettings>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; }
   
    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();
    public OrderData() {}
    public OrderData(int? OrderID,string CustomerID,string ShipCity, double? Freight)
    {
        this.OrderID = OrderID;    
        this.CustomerID = CustomerID;
        this.ShipCity = ShipCity;
        this.Freight = Freight;              
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count() == 0)
        {
            int code = 10;
            for (int i = 1; i < 2; i++)
            {
                Orders.Add(new OrderData(10248, "VINET", "Reims", 3.25));
                Orders.Add(new OrderData(10249, "TOMSP", "Münster", 22.98));
                Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", 140.51));
                Orders.Add(new OrderData(10251, "VICTE", "Lyon", 65.83));
                Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", 58.17));
                Orders.Add(new OrderData(10253, "HANAR", "Lyon", 81.91));
                Orders.Add(new OrderData(10254, "CHOPS", "Rio de Janeiro", 3.05));
                Orders.Add(new OrderData(10255, "RICSU", "Münster", 55.09));
                Orders.Add(new OrderData(10256, "WELLI", "Reims", 48.29));
                code += 5;
            }
        }
        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public double? Freight { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXVzjiXvgoxRzKIb?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customize group caption text using locale

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports customization of group caption text based on locale settings. This feature enables the display of localized or translated content in group captions, allowing the DataGrid to adapt to different languages and regional formats.

The following example demonstrates customizing group caption text for the **ar** locale:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowGrouping="true" AllowPaging="true" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.Country) HeaderText="Country" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.City) HeaderText="City" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<Order> Orders { get; set; }
    protected override void OnInitialized()
    {
        var countries = new[] { "USA", "UK", "Germany", "Canada", "France" };
        var cities = new[] { "New York", "London", "Berlin", "Toronto", "Paris" };
        var random = new Random();
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[random.Next(5)],
            Country = countries[random.Next(countries.Length)],
            City = cities[random.Next(cities.Length)]
        }).ToList();
    }
    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
{% endhighlight %}
{% highlight c# tabtitle="SyncfusionLocalizer.cs" %}

using Syncfusion.Blazor;
namespace LocalizationSample.Client
{
    public class SyncfusionLocalizer : ISyncfusionStringLocalizer
    {
        public string GetText ( string key )
        {
            return this.ResourceManager.GetString(key);
        }
        public System.Resources.ResourceManager ResourceManager
        {
            get
            {
                // Replace the ApplicationNamespace with your application name.
                return LocalizationSample.Client.Resources.SfResources.ResourceManager;
            }
        }
    }
}

{% endhighlight %}
{% highlight c# tabtitle="SfResources.ar.resx" %}

<?xml version="1.0" encoding="utf-8"?>
<root>
  <xsd:schema id="root" xmlns="" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">
    <xsd:import namespace="http://www.w3.org/XML/1998/namespace" />
    <xsd:element name="root" msdata:IsDataSet="true">
      <xsd:complexType>
        <xsd:choice maxOccurs="unbounded">
          <xsd:element name="metadata">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" />
              </xsd:sequence>
              <xsd:attribute name="name" use="required" type="xsd:string" />
              <xsd:attribute name="type" type="xsd:string" />
              <xsd:attribute name="mimetype" type="xsd:string" />
              <xsd:attribute ref="xml:space" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="assembly">
            <xsd:complexType>
              <xsd:attribute name="alias" type="xsd:string" />
              <xsd:attribute name="name" type="xsd:string" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="data">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" msdata:Ordinal="1" />
                <xsd:element name="comment" type="xsd:string" minOccurs="0" msdata:Ordinal="2" />
              </xsd:sequence>
              <xsd:attribute name="name" type="xsd:string" use="required" msdata:Ordinal="1" />
              <xsd:attribute name="type" type="xsd:string" msdata:Ordinal="3" />
              <xsd:attribute name="mimetype" type="xsd:string" msdata:Ordinal="4" />
              <xsd:attribute ref="xml:space" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="resheader">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" msdata:Ordinal="1" />
              </xsd:sequence>
              <xsd:attribute name="name" type="xsd:string" use="required" />
            </xsd:complexType>
          </xsd:element>
        </xsd:choice>
      </xsd:complexType>
    </xsd:element>
  </xsd:schema>
  <resheader name="resmimetype">
    <value>text/microsoft-resx</value>
  </resheader>
  <resheader name="version">
    <value>2.0</value>
  </resheader>
  <resheader name="reader">
    <value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
  <resheader name="writer">
    <value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
  <data name="Grid_GroupDropArea" xml:space="preserve">
    <value>اسحب رأس العمود هنا لتجميع العمود</value>
  </data>
  <data name="Grid_UnGroupButton" xml:space="preserve">
    <value>انقر هنا لإلغاء التجميع</value>
  </data>
  <data name="Grid_GroupDisable" xml:space="preserve">
    <value>تم تعطيل التجميع لهذا العمود</value>
  </data>
  <data name="Grid_Item" xml:space="preserve">
    <value>بند</value>
  </data>
  <data name="Grid_Items" xml:space="preserve">
    <value>العناصر</value>
  </data>
  <data name="Grid_Group" xml:space="preserve">
    <value>تجميع حسب هذا العمود</value>
  </data>
  <data name="Grid_Ungroup" xml:space="preserve">
    <value>فك تجميع بواسطة هذا العمود</value>
  </data>
</root>

{% endhighlight %}
{% highlight razor tabtitle="App.razor" %}

<body>
    ...
    <script src="_framework/blazor.web.js" autostart="false"></script>
    <script>
        Blazor.start({
            webAssembly: {
                applicationCulture: 'ar'
            }
        });
    </script>
    ...
</body>

{% endhighlight %}
{% endtabs %}

![Customize group caption text using locale](./images/blazor-datagrid-customize-group-caption-text-locale.png)

## Render custom component in group caption

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid offers flexibility to render custom components within the group caption row, enabling advanced or interactive functionality. This feature supports the display of custom UI elements such as buttons, icons, or dropdowns, and allows user interactions to be handled directly within the group caption.

Define the custom UI in the [CaptionTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html#Syncfusion_Blazor_Grids_GridGroupSettings_CaptionTemplate) and use `CaptionTemplateContext` to access the current group’s details. This feature enables the replacement of plain text with a custom component in the group caption, enhancing both customization and interactivity.

The following example shows rendering a chip with the group key using the Syncfusion Blazor [Chips](https://blazor.syncfusion.com/documentation/chips/getting-started) component:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfGrid  DataSource="@GridData" AllowGrouping="true" Height="315px">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Name" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="value" Width="80"></GridColumn>
    </GridColumns>
   <GridGroupSettings>
        <CaptionTemplate>
            @{
                var data = (context as CaptionTemplateContext);
                var text = data.Key;
                <SfChip>
                    <ChipItems>
                        <ChipItem Text="@text"></ChipItem>
                    </ChipItems>
                </SfChip>
            }
        </CaptionTemplate>
    </GridGroupSettings>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; }
   
    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }
}
{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();
    public OrderData() {}
    public OrderData(int? OrderID,string CustomerID,string ShipCity, double? Freight)
    {
        this.OrderID = OrderID;    
        this.CustomerID = CustomerID;
        this.ShipCity = ShipCity;
        this.Freight = Freight;              
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count() == 0)
        {
            int code = 10;
            for (int i = 1; i < 2; i++)
            {
                Orders.Add(new OrderData(10248, "VINET", "Reims", 3.25));
                Orders.Add(new OrderData(10249, "TOMSP", "Münster", 22.98));
                Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", 140.51));
                Orders.Add(new OrderData(10251, "VICTE", "Lyon", 65.83));
                Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", 58.17));
                Orders.Add(new OrderData(10253, "HANAR", "Lyon", 81.91));
                Orders.Add(new OrderData(10254, "CHOPS", "Rio de Janeiro", 3.05));
                Orders.Add(new OrderData(10255, "RICSU", "Münster", 55.09));
                Orders.Add(new OrderData(10256, "WELLI", "Reims", 48.29));
                code += 5;
            }
        }
        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public double? Freight { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXVqCsjEtWGsGdKj?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}