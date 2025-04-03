---
layout: post
title: Events in Blazor AutoComplete Component | Syncfusion
description: Checkout and learn here all about Events in Syncfusion Blazor AutoComplete component and much more details.
platform: Blazor
control: AutoComplete
documentation: ug
---

# Events in Blazor AutoComplete Component

This section explains the list of events of the AutoComplete component which will be triggered for appropriate AutoComplete actions.

## Blur

`Blur` event triggers when the input loses focus.

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

`ValueChange` event triggers when the AutoComplete value is changed.

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

`Closed` event triggers after the popup has been closed.

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

`Created` event triggers when the component is created.

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

`Destroyed` event triggers when the component is destroyed.

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

`Focus` event triggers when the input gets focus.

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

`OnOpen` event triggers when the popup is opened. If you cancel this event, the popup remains closed.

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

`OnClose` event triggers before the popup is closed. If you cancel this event, the popup will remain open.

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

`DataBound` event triggers when the data source is populated in the popup list.

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

`Filtering` event triggers on typing a character in the filter bar when the AllowFiltering is enabled.

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

`OnActionBegin` event triggers before fetching data from the remote server.

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

`OnActionFailure` event triggers when the data fetch request from the remote server fails.

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

`OnValueSelect` event triggers when a user selects an item in the popup using the mouse/tap or keyboard navigation.

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

`Opened` event triggers when the popup opens.

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

N> AutoComplete is limited with these events and new events will be added in the future based on the user requests. If the event you are looking for is not on the list, then request [here](https://www.syncfusion.com/feedback/blazor-components).