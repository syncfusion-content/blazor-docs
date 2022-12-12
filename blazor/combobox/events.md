---
layout: post
title: Events in Blazor ComboBox Component | Syncfusion
description: Checkout and learn here all about Events in Syncfusion Blazor ComboBox component and much more details.
platform: Blazor
control: ComboBox
documentation: ug
---

# Events in Blazor ComboBox Component

This section explains the list of events of the ComboBox component which will be triggered for appropriate ComboBox actions.

## Blur

`Blur` event triggers when the input loses focus.

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

`ValueChange` event triggers when the ComboBox value is changed.

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

`Closed` event triggers after the popup has been closed.

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

`Created` event triggers when the component is created.

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

`Destroyed` event triggers when the component is destroyed.

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

`Focus` event triggers when the input gets focus.

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

`OnOpen` event triggers when the popup is opened. If you cancel this event, the popup remains closed.

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

`OnClose` event triggers before the popup is closed. If you cancel this event, the popup will remain open.

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

`DataBound` event triggers when the data source is populated in the popup list.

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

`Filtering` event triggers on typing a character in the filter bar when the AllowFiltering is enabled.

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

`OnActionBegin` event triggers before fetching data from the remote server.

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

`OnActionComplete` event triggers after data is fetched successfully from the remote server.

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

`OnActionFailure` event triggers when the data fetch request from the remote server fails.

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

`OnValueSelect` event triggers when a user selects an item in the popup using the mouse/tap or keyboard navigation.

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

`Opened` event triggers when the popup opens.

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

