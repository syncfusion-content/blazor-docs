---
layout: post
title: Events in Blazor ComboBox Component | Syncfusion
description: Checkout and learn here all about Events in Syncfusion Blazor ComboBox component and much more details.
platform: Blazor
control: ComboBox
documentation: ug
---

# Events in Blazor ComboBox Component

This section lists the events available in the ComboBox component and when they are triggered during typical interactions.

## Blur

The `Blur` event triggers when the input loses focus. Use it to validate, format, or commit values when users leave the control.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfComboBox TItem="GameFields" TValue="string" DataSource="@Games">
    <ComboBoxEvents TItem="GameFields" TValue="string" Blur="@BlurHandler"></ComboBoxEvents>
    <ComboBoxFieldSettings Text="Text" Value="ID"></ComboBoxFieldSettings>
</SfComboBox>

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

## ValueChange

The `ValueChange` event triggers when the ComboBox value is changed and committed.
```cshtml

@using Syncfusion.Blazor.DropDowns

<SfComboBox TItem="GameFields" TValue="string" DataSource="@Games">
    <ComboBoxEvents TItem="GameFields" TValue="string" ValueChange="@ValueChangeHandler"></ComboBoxEvents>
    <ComboBoxFieldSettings Text="Text" Value="ID"></ComboBoxFieldSettings>
</SfComboBox>

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

## Closed

The `Closed` event triggers after the popup has been closed and the UI has updated. Use it to perform actions that depend on the popup being fully hidden.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfComboBox TItem="GameFields" TValue="string" DataSource="@Games">
    <ComboBoxEvents TItem="GameFields" TValue="string" Closed="@CloseHandler"></ComboBoxEvents>
    <ComboBoxFieldSettings Text="Text" Value="ID"></ComboBoxFieldSettings>
</SfComboBox>

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

## Created

The `Created` event triggers when the component is created and its initial rendering is complete. Use it for one-time initialization logic.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfComboBox TItem="GameFields" TValue="string" DataSource="@Games">
    <ComboBoxEvents TItem="GameFields" TValue="string" Created="@CreatedHandler"></ComboBoxEvents>
    <ComboBoxFieldSettings Text="Text" Value="ID"></ComboBoxFieldSettings>
</SfComboBox>

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

## Destroyed

The `Destroyed` event triggers when the component is disposed. Use it to release resources and unsubscribe from external services.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfComboBox TItem="GameFields" TValue="string" DataSource="@Games">
    <ComboBoxEvents TItem="GameFields" TValue="string" Destroyed="@DestroyedHandler"></ComboBoxEvents>
    <ComboBoxFieldSettings Text="Text" Value="ID"></ComboBoxFieldSettings>
</SfComboBox>

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

## Focus

The `Focus` event triggers when the input gains focus. Use it to show context hints or to adjust UI state when the control is focused.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfComboBox TItem="GameFields" TValue="string" DataSource="@Games">
    <ComboBoxEvents TItem="GameFields" TValue="string" Focus="@FocusHandler"></ComboBoxEvents>
    <ComboBoxFieldSettings Text="Text" Value="ID"></ComboBoxFieldSettings>
</SfComboBox>

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

## OnOpen

The `OnOpen` event triggers before the popup opens. This event is cancelable; prevent opening by setting the event argument’s cancel option when available. Use it to customize popup content or apply conditions before showing the list.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfComboBox TItem="GameFields" TValue="string" DataSource="@Games">
    <ComboBoxEvents TItem="GameFields" TValue="string" OnOpen="@OnOpenHandler"></ComboBoxEvents>
    <ComboBoxFieldSettings Text="Text" Value="ID"></ComboBoxFieldSettings>
</SfComboBox>

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

## OnClose

The `OnClose` event triggers before the popup closes. This event is cancelable; prevent closing by setting the event argument’s cancel option when available. Use it to validate the current value or maintain popup state.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfComboBox TItem="GameFields" TValue="string" DataSource="@Games">
    <ComboBoxEvents TItem="GameFields" TValue="string" OnClose="@OnCloseHandler"></ComboBoxEvents>
    <ComboBoxFieldSettings Text="Text" Value="ID"></ComboBoxFieldSettings>
</SfComboBox>

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

## DataBound

The `DataBound` event triggers when the data source is bound and the popup list is populated. Use it to perform post-binding tasks such as selecting a default item or measuring list size.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfComboBox TItem="GameFields" TValue="string" DataSource="@Games">
    <ComboBoxEvents TItem="GameFields" TValue="string" DataBound="@DataBoundHandler"></ComboBoxEvents>
    <ComboBoxFieldSettings Text="Text" Value="ID"></ComboBoxFieldSettings>
</SfComboBox>

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

## Filtering

The `Filtering` event triggers while typing in the input when `AllowFiltering` is enabled. Use it to customize the filtering logic, modify the query, or provide remote filtering based on the typed text.

```cshtml

@using Syncfusion.Blazor.DropDowns

<SfComboBox TItem="GameFields" TValue="string" AllowFiltering="true" DataSource="@Games">
    <ComboBoxEvents TItem="GameFields" TValue="string" Filtering="@Filteringhandler"></ComboBoxEvents>
    <ComboBoxFieldSettings Text="Text" Value="ID"></ComboBoxFieldSettings>
</SfComboBox>


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

## OnActionBegin

The `OnActionBegin` event triggers before fetching data from a remote server when using `SfDataManager`. Use it to modify the query or show a loading indicator.

```cshtml
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Data

<SfComboBox TValue="string" TItem="OrderDetails" Query="@RemoteDataQuery">
    <SfDataManager Url="https://js.syncfusion.com/demos/ejServices/Wcf/Northwind.svc/Orders" CrossDomain="true" Adaptor="Syncfusion.Blazor.Adaptors.ODataAdaptor"></SfDataManager>
    <ComboBoxEvents TValue="string" TItem="OrderDetails" OnActionBegin="@OnActionBeginhandler"></ComboBoxEvents>
    <ComboBoxFieldSettings Text="CustomerID" Value="CustomerID"></ComboBoxFieldSettings>
</SfComboBox>

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

## OnActionComplete

The `OnActionComplete` event triggers after data is fetched successfully from a remote server.

```cshtml
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Data

<SfComboBox TValue="string" TItem="OrderDetails" Query="@RemoteDataQuery">
    <SfDataManager Url="https://js.syncfusion.com/demos/ejServices/Wcf/Northwind.svc/Orders" CrossDomain="true" Adaptor="Syncfusion.Blazor.Adaptors.ODataAdaptor"></SfDataManager>
    <ComboBoxEvents TValue="string" TItem="OrderDetails" OnActionBegin="@OnActionBeginhandler"></ComboBoxEvents>
    <ComboBoxFieldSettings Text="CustomerID" Value="CustomerID"></ComboBoxFieldSettings>
</SfComboBox>

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

## OnActionFailure

The `OnActionFailure` event triggers when a remote data fetch fails.

```cshtml
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Data

<SfComboBox TValue="string" TItem="OrderDetails" Query="@RemoteDataQuery">
    <SfDataManager Url="https://js.syncfusion.com/demos/ejServices/Wcf/Northwind.svc/Orders" CrossDomain="true" Adaptor="Syncfusion.Blazor.Adaptors.ODataAdaptor"></SfDataManager>
    <ComboBoxEvents TValue="string" TItem="OrderDetails" OnActionFailure="@OnActionFailurehandler"></ComboBoxEvents>
    <ComboBoxFieldSettings Text="CustomerID" Value="CustomerID"></ComboBoxFieldSettings>
</SfComboBox>

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

## OnValueSelect

The `OnValueSelect` event triggers when a user selects an item from the popup using the mouse, touch, or keyboard navigation. 

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfComboBox TItem="GameFields" TValue="string" DataSource="@Games">
    <ComboBoxEvents TItem="GameFields" TValue="string" OnValueSelect="@OnValueSelecthandler"></ComboBoxEvents>
    <ComboBoxFieldSettings Text="Text" Value="ID"></ComboBoxFieldSettings>
</SfComboBox>

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

## Opened

The `Opened` event triggers when the popup opens and is visible. 

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfComboBox TItem="GameFields" TValue="string" DataSource="@Games">
    <ComboBoxEvents TItem="GameFields" TValue="string" Opened="@Openedhandler"></ComboBoxEvents>
    <ComboBoxFieldSettings Text="Text" Value="ID"></ComboBoxFieldSettings>
</SfComboBox>

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

## See also
* [How to pass an extra parameter to Blazor ComboBox ValueChange handler?](https://www.syncfusion.com/kb/13138/how-to-pass-an-extra-parameter-to-blazor-combobox-valuechange-handler)

N> ComboBox is limited with these events and new events will be added in the future based on the user requests. If the event you are looking for is not on the list, then request [here](https://www.syncfusion.com/feedback/blazor-components).