---
layout: post
title: Events in Blazor AutoComplete Component | Syncfusion
description: Learn about events in the Syncfusion Blazor AutoComplete component, including ValueChange, OnOpen, OnClose, DataBound, Filtering, selection events, and more.
platform: Blazor
control: AutoComplete
documentation: ug
---

# Events in Blazor AutoComplete Component

This section lists and describes the events raised by the AutoComplete component for common user interactions and lifecycle actions.

## Blur

The `Blur` event is triggered when the input loses focus.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfAutoComplete TItem="GameFields" TValue="string"  DataSource="@Games">
    <AutoCompleteEvents TItem="GameFields" TValue="string" Blur="@BlurHandler"></AutoCompleteEvents>
    <AutoCompleteFieldSettings Text="Text" Value="ID"></AutoCompleteFieldSettings>
</SfAutoComplete>

@code {
    public class GameFields
    {
        public string ID { get; set; }
        public string Text { get; set; }
    }

    private List<GameFields> Games = new List<GameFields>() {
        new GameFields(){ ID= "Game1", Text= "American Football" },
        new GameFields(){ ID= "Game2", Text= "Badminton" },
        new GameFields(){ ID= "Game3", Text= "Basketball" },
        new GameFields(){ ID= "Game4", Text= "Cricket" },
     };

    private void BlurHandler(Object args)
    {
        // Here, you can customize your code.
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BDLUWBifAHaoYZgv?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## ValueChange

The `ValueChange` event is triggered when the AutoComplete value changes.

```cshtml

@using Syncfusion.Blazor.DropDowns

<SfAutoComplete TItem="GameFields" TValue="string" DataSource="@Games">
    <AutoCompleteEvents TItem="GameFields" TValue="string" ValueChange="@ValueChangeHandler"></AutoCompleteEvents>
    <AutoCompleteFieldSettings Text="Text" Value="ID"></AutoCompleteFieldSettings>
</SfAutoComplete>

@code {
    public class GameFields
    {
        public string ID { get; set; }
        public string Text { get; set; }
    }

    private List<GameFields> Games = new List<GameFields>() {
        new GameFields(){ ID= "Game1", Text= "American Football" },
        new GameFields(){ ID= "Game2", Text= "Badminton" },
        new GameFields(){ ID= "Game3", Text= "Basketball" },
        new GameFields(){ ID= "Game4", Text= "Cricket" },
     };

    private void ValueChangeHandler(ChangeEventArgs<string, GameFields> args)
    {
        // Here, you can customize your code.
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VDhUMrszKHuvYJof?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Closed

The `Closed` event is triggered after the popup has been closed.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfAutoComplete TItem="GameFields" TValue="string" DataSource="@Games">
    <AutoCompleteEvents TItem="GameFields" TValue="string" Closed="@CloseHandler"></AutoCompleteEvents>
    <AutoCompleteFieldSettings Text="Text" Value="ID"></AutoCompleteFieldSettings>
</SfAutoComplete>

@code {
    public class GameFields
    {
        public string ID { get; set; }
        public string Text { get; set; }
    }

    private List<GameFields> Games = new List<GameFields>() {
        new GameFields(){ ID= "Game1", Text= "American Football" },
        new GameFields(){ ID= "Game2", Text= "Badminton" },
        new GameFields(){ ID= "Game3", Text= "Basketball" },
        new GameFields(){ ID= "Game4", Text= "Cricket" },
     };

    private void CloseHandler(ClosedEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VthKWVipUQZCbocB?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Created

The `Created` event is triggered when the component is created.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfAutoComplete TItem="GameFields" TValue="string" DataSource="@Games">
    <AutoCompleteEvents TItem="GameFields" TValue="string" Created="@CreatedHandler"></AutoCompleteEvents>
    <AutoCompleteFieldSettings Text="Text" Value="ID"></AutoCompleteFieldSettings>
</SfAutoComplete>

@code {
    public class GameFields
    {
        public string ID { get; set; }
        public string Text { get; set; }
    }

    private List<GameFields> Games = new List<GameFields>() {
        new GameFields(){ ID= "Game1", Text= "American Football" },
        new GameFields(){ ID= "Game2", Text= "Badminton" },
        new GameFields(){ ID= "Game3", Text= "Basketball" },
        new GameFields(){ ID= "Game4", Text= "Cricket" },
     };

    private void CreatedHandler(Object args)
    {
        // Here, you can customize your code.
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VDrgCVWzgwZSNwtx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Destroyed

The `Destroyed` event is triggered when the component is destroyed.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfAutoComplete TItem="GameFields" TValue="string" DataSource="@Games">
    <AutoCompleteEvents TItem="GameFields" TValue="string" Destroyed="@DestroyedHandler"></AutoCompleteEvents>
    <AutoCompleteFieldSettings Text="Text" Value="ID"></AutoCompleteFieldSettings>
</SfAutoComplete>

@code {
    public class GameFields
    {
        public string ID { get; set; }
        public string Text { get; set; }
    }

    private List<GameFields> Games = new List<GameFields>() {
        new GameFields(){ ID= "Game1", Text= "American Football" },
        new GameFields(){ ID= "Game2", Text= "Badminton" },
        new GameFields(){ ID= "Game3", Text= "Basketball" },
        new GameFields(){ ID= "Game4", Text= "Cricket" },
     };

    private void DestroyedHandler(Object args)
    {
        // Here, you can customize your code.
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VZrKWrCJAwMMVCHn?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Focus

The `Focus` event is triggered when the input gains focus.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfAutoComplete TItem="GameFields" TValue="string" DataSource="@Games">
    <AutoCompleteEvents TItem="GameFields" TValue="string" Focus="@FocusHandler"></AutoCompleteEvents>
    <AutoCompleteFieldSettings Text="Text" Value="ID"></AutoCompleteFieldSettings>
</SfAutoComplete>

@code {
    public class GameFields
    {
        public string ID { get; set; }
        public string Text { get; set; }
    }

    private List<GameFields> Games = new List<GameFields>() {
        new GameFields(){ ID= "Game1", Text= "American Football" },
        new GameFields(){ ID= "Game2", Text= "Badminton" },
        new GameFields(){ ID= "Game3", Text= "Basketball" },
        new GameFields(){ ID= "Game4", Text= "Cricket" },
     };

    private void FocusHandler(Object args)
    {
        // Here, you can customize your code.
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VDLUsVMTUQsUbNIt?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## OnOpen

The `OnOpen` event is triggered when the popup is opened. If this event is canceled, the popup remains closed.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfAutoComplete TItem="GameFields" TValue="string" DataSource="@Games">
    <AutoCompleteEvents TItem="GameFields" TValue="string" OnOpen="@OnOpenHandler"></AutoCompleteEvents>
    <AutoCompleteFieldSettings Text="Text" Value="ID"></AutoCompleteFieldSettings>
</SfAutoComplete>

@code {
    public class GameFields
    {
        public string ID { get; set; }
        public string Text { get; set; }
    }

    private List<GameFields> Games = new List<GameFields>() {
        new GameFields(){ ID= "Game1", Text= "American Football" },
        new GameFields(){ ID= "Game2", Text= "Badminton" },
        new GameFields(){ ID= "Game3", Text= "Basketball" },
        new GameFields(){ ID= "Game4", Text= "Cricket" },
     };

    private void OnOpenHandler(BeforeOpenEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LtrUWVWJUcsHKlSD?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## OnClose

The `OnClose` event is triggered before the popup is closed. If this event is canceled, the popup remains open.

```cshtml

@using Syncfusion.Blazor.DropDowns

<SfAutoComplete TItem="GameFields" TValue="string" DataSource="@Games">
    <AutoCompleteEvents TItem="GameFields" TValue="string" OnClose="@OnCloseHandler"></AutoCompleteEvents>
    <AutoCompleteFieldSettings Text="Text" Value="ID"></AutoCompleteFieldSettings>
</SfAutoComplete>

@code {
    public class GameFields
    {
        public string ID { get; set; }
        public string Text { get; set; }
    }

    private List<GameFields> Games = new List<GameFields>() {
        new GameFields(){ ID= "Game1", Text= "American Football" },
        new GameFields(){ ID= "Game2", Text= "Badminton" },
        new GameFields(){ ID= "Game3", Text= "Basketball" },
        new GameFields(){ ID= "Game4", Text= "Cricket" },
     };

    private void OnCloseHandler(PopupEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hNLAiriTAGsaheaU?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## DataBound

The `DataBound` event is triggered after the data source is populated in the popup list.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfAutoComplete TItem="GameFields" TValue="string" DataSource="@Games">
    <AutoCompleteEvents TItem="GameFields" TValue="string" DataBound="@DataBoundHandler"></AutoCompleteEvents>
    <AutoCompleteFieldSettings Text="Text" Value="ID"></AutoCompleteFieldSettings>
</SfAutoComplete>

@code {
    public class GameFields
    {
        public string ID { get; set; }
        public string Text { get; set; }
    }

    private List<GameFields> Games = new List<GameFields>() {
        new GameFields(){ ID= "Game1", Text= "American Football" },
        new GameFields(){ ID= "Game2", Text= "Badminton" },
        new GameFields(){ ID= "Game3", Text= "Basketball" },
        new GameFields(){ ID= "Game4", Text= "Cricket" },
     };

    private void DataBoundHandler(DataBoundEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hDVUihMTqmLVLGDY?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Filtering

The `Filtering` event is triggered while typing in the input when `AllowFiltering` is enabled.

```cshtml

@using Syncfusion.Blazor.DropDowns

<SfAutoComplete TItem="GameFields" TValue="string" AllowFiltering="true" DataSource="@Games">
    <AutoCompleteEvents TItem="GameFields" TValue="string" Filtering="@Filteringhandler"></AutoCompleteEvents>
    <AutoCompleteFieldSettings Text="Text" Value="ID"></AutoCompleteFieldSettings>
</SfAutoComplete>


@code {
    public class GameFields
    {
        public string ID { get; set; }
        public string Text { get; set; }
    }

    private List<GameFields> Games = new List<GameFields>() {
        new GameFields(){ ID= "Game1", Text= "American Football" },
        new GameFields(){ ID= "Game2", Text= "Badminton" },
        new GameFields(){ ID= "Game3", Text= "Basketball" },
        new GameFields(){ ID= "Game4", Text= "Cricket" },
     };

    private void Filteringhandler(FilteringEventArgs args)
    {
        // Here, you can customize your code.
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rZBAMhMJqwrTexBF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## OnActionBegin

The `OnActionBegin` event is triggered before fetching data from the remote server.

```cshtml
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Data

<SfAutoComplete TValue="string" TItem="OrderDetails" Query="@RemoteDataQuery">
        <SfDataManager Url="https://js.syncfusion.com/demos/ejServices/Wcf/Northwind.svc/Orders" CrossDomain="true" Adaptor="Syncfusion.Blazor.Adaptors.ODataAdaptor"></SfDataManager>
        <AutoCompleteEvents TValue="string" TItem="OrderDetails" OnActionBegin="@OnActionBeginhandler"></AutoCompleteEvents>
        <AutoCompleteFieldSettings Text="CustomerID" Value="CustomerID"></AutoCompleteFieldSettings>
    </SfAutoComplete>

@code {
    public Query RemoteDataQuery = new Query().Select(new List<string> { "CustomerID" }).Take(6).RequiresCount();
    public class OrderDetails
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public int? EmployeeID { get; set; }
        public double? Freight { get; set; }
        public string ShipCity { get; set; }
        public bool Verified { get; set; }
        public DateTime? OrderDate { get; set; }
        public string ShipName { get; set; }
        public string ShipCountry { get; set; }
        public DateTime? ShippedDate { get; set; }
        public string ShipAddress { get; set; }
    }

    private void OnActionBeginhandler(ActionBeginEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VtrKiBsTKmrEVfKV?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## OnActionFailure

The `OnActionFailure` event is triggered when the data fetch request from the remote server fails.

```cshtml
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Data

<SfAutoComplete TValue="string" TItem="OrderDetails" Query="@RemoteDataQuery">
        <SfDataManager Url="https://js.syncfusion.com/demos/ejServices/Wcf/Northwind.svc/Orders" CrossDomain="true" Adaptor="Syncfusion.Blazor.Adaptors.ODataAdaptor"></SfDataManager>
        <AutoCompleteEvents TValue="string" TItem="OrderDetails" OnActionFailure="@OnActionFailurehandler"></AutoCompleteEvents>
        <AutoCompleteFieldSettings Text="CustomerID" Value="CustomerID"></AutoCompleteFieldSettings>
    </SfAutoComplete>

@code {
    public Query RemoteDataQuery = new Query().Select(new List<string> { "CustomerID" }).Take(6).RequiresCount();
    public class OrderDetails
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public int? EmployeeID { get; set; }
        public double? Freight { get; set; }
        public string ShipCity { get; set; }
        public bool Verified { get; set; }
        public DateTime? OrderDate { get; set; }
        public string ShipName { get; set; }
        public string ShipCountry { get; set; }
        public DateTime? ShippedDate { get; set; }
        public string ShipAddress { get; set; }
    }

    private void OnActionFailurehandler(Exception args)
    {
        // Here, you can customize your code.
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LjLAiVszKGArhgsH?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## OnValueSelect

The `OnValueSelect` event is triggered when a user selects an item in the popup using mouse/tap or keyboard navigation.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfAutoComplete TItem="GameFields" TValue="string" AllowFiltering="true" DataSource="@Games">
    <AutoCompleteEvents TItem="GameFields" TValue="string" OnValueSelect="@OnValueSelecthandler"></AutoCompleteEvents>
    <AutoCompleteFieldSettings Text="Text" Value="ID"></AutoCompleteFieldSettings>
</SfAutoComplete>

@code {
    public class GameFields
    {
        public string ID { get; set; }
        public string Text { get; set; }
    }

    private List<GameFields> Games = new List<GameFields>() {
        new GameFields(){ ID= "Game1", Text= "American Football" },
        new GameFields(){ ID= "Game2", Text= "Badminton" },
        new GameFields(){ ID= "Game3", Text= "Basketball" },
        new GameFields(){ ID= "Game4", Text= "Cricket" },
     };

    private void OnValueSelecthandler(SelectEventArgs<GameFields> args)
    {
        // Here, you can customize your code.
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VNhqsrMJAGqIsOVh?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Opened

The `Opened` event is triggered when the popup opens.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfAutoComplete TItem="GameFields" TValue="string" AllowFiltering="true" DataSource="@Games">
    <AutoCompleteEvents TItem="GameFields" TValue="string" Opened="@Openedhandler"></AutoCompleteEvents>
    <AutoCompleteFieldSettings Text="Text" Value="ID"></AutoCompleteFieldSettings>
</SfAutoComplete>

@code {
    public class GameFields
    {
        public string ID { get; set; }
        public string Text { get; set; }
    }

    private List<GameFields> Games = new List<GameFields>() {
        new GameFields(){ ID= "Game1", Text= "American Football" },
        new GameFields(){ ID= "Game2", Text= "Badminton" },
        new GameFields(){ ID= "Game3", Text= "Basketball" },
        new GameFields(){ ID= "Game4", Text= "Cricket" },
     };

    private void Openedhandler(PopupEventArgs args)
    {
        // Here, you can customize your code.
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LtVqsBCTAcAbJVPK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

N> The AutoComplete currently supports the events listed above. Additional events may be introduced in future releases based on user requests. If the required event is not listed, submit a request on the [Syncfusion Feedback](https://www.syncfusion.com/feedback/blazor-components) portal.