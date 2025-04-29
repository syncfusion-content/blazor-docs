---
layout: post
title: Access public methods in Blazor DataGrid | Syncfusion
description: Learn here all about Access public methods in Grid in Syncfusion Blazor DataGrid and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Access public methods in Blazor DataGrid

The Syncfusion Blazor DataGrid allows you to access its public methods by using a component reference defined during initialization.

This is demonstrated in the following sample code where the [Print](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Print) method of the Grid is invoked on button click using the Grid reference.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids

<SfButton OnClick="Print" CssClass="e-primary" IsPrimary="true" Content="Print data"></SfButton>

<SfGrid @ref="DefaultGrid" DataSource="@Employees">
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeData.EmployeeID) TextAlign="TextAlign.Center" HeaderText="Employee ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.FirstName) HeaderText="First Name" ShowInColumnChooser="false" Width="130"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.LastName) HeaderText="Last Name" Width="130"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Title) HeaderText="Title" Width="120"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.HireDate) HeaderText="Hire Date" Format="d" TextAlign="TextAlign.Right" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<EmployeeData> DefaultGrid;

    public List<EmployeeData> Employees { get; set; }

    protected override void OnInitialized()
    {
        Employees = EmployeeData.GetAllRecords();
    }

    public async Task Print()
    {
        await this.DefaultGrid.Print();
    }
}

{% endhighlight %}
{% highlight c# tabtitle="EmployeeData.cs" %}

public class EmployeeData
{
    public static List<EmployeeData> Employees = new List<EmployeeData>();

    public EmployeeData() { }

    public EmployeeData(int EmployeeID, string FirstName, string LastName, string Title, string Country, string City, DateTime HireDate)
    {
        this.EmployeeID = EmployeeID;
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.Title = Title;
        this.Country = Country;
        this.City = City;
        this.HireDate = HireDate;
    }

    public static List<EmployeeData> GetAllRecords()
    {
        if (Employees.Count == 0)
        {
            var firstNames = new string[] { "Nancy", "Andrew", "Janet", "Margaret", "Steven" };
            var lastNames = new string[] { "Davolio", "Fuller", "Leverling", "Peacock", "Buchanan" };
            var titles = new string[] { "Sales Representative", "Vice President, Sales", "Sales Manager", "Inside Sales Coordinator" };
            var countries = new string[] { "USA", "UK", "UAE", "NED", "BER" };
            var cities = new string[] { "New York", "London", "Dubai", "Amsterdam", "Berlin" };

            Random random = new Random();
            for (int i = 1; i <= 5; i++)
            {
                Employees.Add(new EmployeeData(
                    i,
                    firstNames[random.Next(firstNames.Length)],
                    lastNames[random.Next(lastNames.Length)],
                    titles[random.Next(titles.Length)],
                    countries[random.Next(countries.Length)],
                    cities[random.Next(cities.Length)],
                    DateTime.Now.AddDays(-random.Next(1000, 5000))
                ));
            }
        }
        return Employees;
    }

    public int EmployeeID { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Title { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
    public DateTime HireDate { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZLSNfrFpzrqCjzn?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

N> Similarly all the public methods of the Grid can be invoked. The available public methods can be found in this [link](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html).
