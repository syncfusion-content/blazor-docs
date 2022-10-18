---
layout: post
title: Filtering in Blazor ComboBox Component | Syncfusion
description: Checkout and learn here all about Filtering in the Syncfusion Blazor ComboBox component and much more.
platform: Blazor
control: ComboBox
documentation: ug
---

# Filtering in Blazor ComboBox Component

The ComboBox has built-in support to filter data items when [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfComboBox-2.html) is enabled. The filter operation starts as soon as you start typing characters in the component.

```cshtml
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.DropDowns

<SfComboBox TValue="string" TItem="EmployeeData" Placeholder="Select a customer" Query="@Query" AllowFiltering=true>
    <SfDataManager Url="https://ej2services.syncfusion.com/production/web-services/api/Employees" Adaptor="Adaptors.WebApiAdaptor" CrossDomain=true></SfDataManager>
    <ComboBoxFieldSettings Text="FirstName" Value="EmployeeID"></ComboBoxFieldSettings>
</SfComboBox>

@code {
    public Query Query = new Query();

    public class EmployeeData
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string Designation { get; set; }
        public string Country { get; set; }
    }
}
```


![Filtering in Blazor ComboBox](./images/blazor-combobox-filtering.png)

## Custom Filtering

The ComboBox component filter queries can be customized. You can also use your own filter libraries to filter data like Fuzzy search.

```cshtml
@using Syncfusion.Blazor.Data

<SfComboBox TValue="string" @ref="comboObj" TItem="Country" Placeholder="e.g. Australia" DataSource="@Countries" AllowFiltering="true">
    <ComboBoxFieldSettings Text="Name" Value="Code"></ComboBoxFieldSettings>
    <ComboBoxEvents TValue="string" TItem="Country" Filtering="OnFilter"></ComboBoxEvents>
</SfComboBox>

@code {

    SfComboBox<string, Country> comboObj { get; set; }

    public class Country
    {
        public string Name { get; set; }

        public string Code { get; set; }
    }

    List<Country> Countries = new List<Country>
    {
        new Country() { Name = "Australia", Code = "AU" },
        new Country() { Name = "Bermuda", Code = "BM" },
        new Country() { Name = "Canada", Code = "CA" },
        new Country() { Name = "Cameroon", Code = "CM" },
        new Country() { Name = "Denmark", Code = "DK" }
    };

    List<Country> CountriesFiltered = new List<Country>
    {
        new Country() { Name = "France", Code = "FR" },
        new Country() { Name = "Finland", Code = "FI" },
        new Country() { Name = "Germany", Code = "DE" },
        new Country() { Name = "Greenland", Code = "GL" }
    };

    private async Task OnFilter(FilteringEventArgs args)
    {
        args.PreventDefaultAction = true;
        var query = new Query().Where(new WhereFilter() { Field = "Name", Operator = "contains", value = args.Text, IgnoreCase = true });

        query = !string.IsNullOrEmpty(args.Text) ? query : new Query();

        await comboObj.FilterAsync(CountriesFiltered, query);
    }
}
```

## Cascading with filtering 

The Cascading ComboBox is the series of ComboBox, where the value of one ComboBox depends on the another ComboBox value. In the [ValueChange](https://blazor.syncfusion.com/documentation/combobox/events#valuechange) event handler of 1st ComboBox, should load the data for the 2nd ComboBox based on the selected value of 1st ComboBox. The same has to be configured between 2nd and 3rd ComboBoxes.In the below code, if a country is chosen, then corresponding states for the chosen county is loaded in the next combobox with the support of TValue as int.

```cshtml
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Inputs
@using System.ComponentModel.DataAnnotations;

<EditForm Model="@Model">
    <div class="form-group">
        <SfComboBox TValue="int" TItem="State" @bind-Value="@StateValue" Placeholder="Select a state" AllowCustom="false" PopupHeight="auto" DataSource="@States" AllowFiltering="true">
            <ComboBoxEvents TValue="int" TItem="State" ValueChange="ChangeState"></ComboBoxEvents>
            <ComboBoxFieldSettings Text="StateName" Value="StateId"></ComboBoxFieldSettings>
        </SfComboBox>
    </div>
    <div class="form-group">
        Country ID:
        <SfTextBox @bind-Value="@CountryID"></SfTextBox>
    </div>
    <div class="form-group">
        State ID:
        <SfTextBox @bind-Value="@StateID"></SfTextBox>
    </div>
    <div class="form-group">
        Capital:
        <SfTextBox @bind-Value="@Capital"></SfTextBox>
    </div>

</EditForm>
<style>
    .control-wrapper {
        margin: 0 auto;
        width: 250px;
    }

    .control-section .padding-top {
        padding-top: 35px
    }
</style>
@code {
    public int StateValue { get; set; }
    public string Capital { get; set; }
    public string CountryID { get; set; }
    public string StateID { get; set; }
    public State Model = new State();
    public void ChangeState(Syncfusion.Blazor.DropDowns.ChangeEventArgs<int, State> args)
    {
        this.Capital = this.States.Where(state => state.StateId == args.Value).First().Capital;
        this.CountryID = this.States.Where(state => state.StateId == args.Value).First().CountryId;
        this.StateID = this.States.Where(state => state.StateId == args.Value).First().StateId.ToString();
    }
    public class State
    {
        public string StateName { get; set; }
        public string CountryId { get; set; }
        [Key]
        public int StateId { get; set; }
        public string Capital { get; set; }
    }


    public List<State> States = new List<State>() {
        new State() { StateName= "New York", CountryId= "1", StateId= 101, Capital="Albany" },
        new State() { StateName= "Queensland", CountryId= "2", StateId= 104, Capital="Brisbane" },
        new State() { StateName= "Tasmania ", CountryId= "2", StateId= 105, Capital="Hobart " },
        new State() { StateName= "Victoria", CountryId= "2", StateId= 106, Capital="Melbourne" },
        new State() { StateName= "Virginia", CountryId= "1", StateId= 102, Capital="Richmond" },
        new State() { StateName= "Washington", CountryId= "1", StateId= 103, Capital="Olympia" }
    };
}
```


![Cascading with Filtering in Blazor ComboBox](./images/blazor_combobox_cascading-with-filtering.png)