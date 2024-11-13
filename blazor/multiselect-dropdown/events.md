---
layout: post
title: Events in Blazor MultiSelect Component | Syncfusion
description: Checkout and learn here all about events in Syncfusion Blazor MultiSelect component and much more details.
platform: Blazor
control: MultiSelect
documentation: ug
---

# Events in Blazor MultiSelect Component

This section explains the list of events of the MultiSelect component which will be triggered for appropriate MultiSelect actions.

## Blur

`Blur` event triggers when the input loses focus.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfMultiSelect TItem="GameFields" TValue="string[]"  DataSource="@Games">
    <MultiSelectEvents TItem="GameFields" TValue="string[]" Blur="@BlurHandler"></MultiSelectEvents>
    <MultiSelectFieldSettings Text="Text" Value="ID"></MultiSelectFieldSettings>
</SfMultiSelect>

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
        // Here you can customize your code
    }
}
```

## ValueChange

`ValueChange` event triggers when the MultiSelect value is changed.

```cshtml

@using Syncfusion.Blazor.DropDowns

<SfMultiSelect TItem="GameFields" TValue="string[]" DataSource="@Games">
    <MultiSelectEvents TItem="GameFields" TValue="string[]" ValueChange="@ValueChangeHandler"></MultiSelectEvents>
    <MultiSelectFieldSettings Text="Text" Value="ID"></MultiSelectFieldSettings>
</SfMultiSelect>

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

    private void ValueChangeHandler(MultiSelectChangeEventArgs<string[]> args)
    {
        // Here you can customize your code
    }
}

```

## Closed

`Closed` event triggers after the popup has been closed.

```cshtml

```

## Created

`Created` event triggers when the component is created.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfMultiSelect TItem="GameFields" TValue="string[]" DataSource="@Games">
    <MultiSelectEvents TItem="GameFields" TValue="string[]" Created="@CreatedHandler"></MultiSelectEvents>
    <MultiSelectFieldSettings Text="Text" Value="ID"></MultiSelectFieldSettings>
</SfMultiSelect>

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
        // Here you can customize your code
    }
}
```

## Destroyed

`Destroyed` event triggers when the component is destroyed.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfMultiSelect TItem="GameFields" TValue="string[]" DataSource="@Games">
    <MultiSelectEvents TItem="GameFields" TValue="string[]" Destroyed="@DestroyedHandler"></MultiSelectEvents>
    <MultiSelectFieldSettings Text="Text" Value="ID"></MultiSelectFieldSettings>
</SfMultiSelect>

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
        // Here you can customize your code
    }
}
```

## Focus

`Focus` event triggers when the input gets focus.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfMultiSelect TItem="GameFields" TValue="string[]" DataSource="@Games">
    <MultiSelectEvents TItem="GameFields" TValue="string[]" Focus="@FocusHandler"></MultiSelectEvents>
    <MultiSelectFieldSettings Text="Text" Value="ID"></MultiSelectFieldSettings>
</SfMultiSelect>

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
        // Here you can customize your code
    }
}
```

## OnOpen

`OnOpen` event triggers when the popup is opened. If you cancel this event, the popup remains closed.

```cshtml

```

## OnClose

`OnClose` event triggers before the popup is closed. If you cancel this event, the popup will remain open.

```cshtml


```

## DataBound

`DataBound` event triggers when the data source is populated in the popup list.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfMultiSelect TItem="GameFields" TValue="string[]" DataSource="@Games">
    <MultiSelectEvents TItem="GameFields" TValue="string[]" DataBound="@DataBoundHandler"></MultiSelectEvents>
    <MultiSelectFieldSettings Text="Text" Value="ID"></MultiSelectFieldSettings>
</SfMultiSelect>

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
        // Here you can customize your code
    }
}
```

## Filtering

`Filtering` event triggers on typing a character in the filter bar when the AllowFiltering is enabled.

```cshtml

@using Syncfusion.Blazor.DropDowns

<SfMultiSelect TItem="GameFields" TValue="string[]" AllowFiltering="true" DataSource="@Games">
    <MultiSelectEvents TItem="GameFields" TValue="string[]" Filtering="@Filteringhandler"></MultiSelectEvents>
    <MultiSelectFieldSettings Text="Text" Value="ID"></MultiSelectFieldSettings>
</SfMultiSelect>

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
        // Here you can customize your code
    }
}

```

## OnActionBegin

`OnActionBegin` event triggers before fetching data from the remote server.

```cshtml
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Data

<SfMultiSelect TValue="string" TItem="OrderDetails" Query="@RemoteDataQuery">
        <SfDataManager Url="https://js.syncfusion.com/demos/ejServices/Wcf/Northwind.svc/Orders" CrossDomain="true" Adaptor="Syncfusion.Blazor.Adaptors.ODataAdaptor"></SfDataManager>
        <MultiSelectEvents TValue="string" TItem="OrderDetails" OnActionBegin="@OnActionBeginhandler"></MultiSelectEvents>
        <MultiSelectFieldSettings Text="CustomerID" Value="CustomerID"></MultiSelectFieldSettings>
</SfMultiSelect>

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
        // Here you can customize your code
    }
}
```

## OnActionFailure

`OnActionFailure` event triggers when the data fetch request from the remote server fails.

```cshtml
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Data

 <SfMultiSelect TValue="string" TItem="OrderDetails" Query="@RemoteDataQuery">
        <SfDataManager Url="https://js.syncfusion.com/demos/ejServices/Wcf/Northwind.svc/Orders" CrossDomain="true" Adaptor="Syncfusion.Blazor.Adaptors.ODataAdaptor"></SfDataManager>
        <MultiSelectEvents TValue="string" TItem="OrderDetails" OnActionFailure="@OnActionFailurehandler"></MultiSelectEvents>
        <MultiSelectFieldSettings Text="CustomerID" Value="CustomerID"></MultiSelectFieldSettings>
 </SfMultiSelect>

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
        // Here you can customize your code
    }
}
```

## OnValueSelect

`OnValueSelect` event triggers when a user selects an item in the popup using the mouse or keyboard navigation.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfMultiSelect TItem="GameFields" TValue="string[]" AllowFiltering="true" DataSource="@Games">
    <MultiSelectEvents TItem="GameFields" TValue="string[]" OnValueSelect="@OnValueSelecthandler"></MultiSelectEvents>
    <MultiSelectFieldSettings Text="Text" Value="ID"></MultiSelectFieldSettings>
</SfMultiSelect>

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
        // Here you can customize your code
    }
}
```

## Opened

`Opened` event triggers when the popup opens.

```cshtml

```

## ChipSelected

`ChipSelected` event triggers when the chip is selected.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfMultiSelect TItem="GameFields" TValue="string[]" AllowFiltering="true" DataSource="@Games">
    <MultiSelectEvents TItem="GameFields" TValue="string[]" ChipSelected="@ChipSelectedhandler"></MultiSelectEvents>
    <MultiSelectFieldSettings Text="Text" Value="ID"></MultiSelectFieldSettings>
</SfMultiSelect>

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

    private void ChipSelectedhandler(ChipSelectedEventArgs<GameFields> args)
    {
        // Here you can customize your code
    }
}

```

## Cleared

`Cleared` event triggers after clearing all items using the clear icon.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfMultiSelect TItem="GameFields" TValue="string[]" AllowFiltering="true" DataSource="@Games">
    <MultiSelectEvents TItem="GameFields" TValue="string[]" Cleared="@Clearedhandler"></MultiSelectEvents>
    <MultiSelectFieldSettings Text="Text" Value="ID"></MultiSelectFieldSettings>
</SfMultiSelect>

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

    private void Clearedhandler(MouseEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## OnChipTag

`OnChipTag` event triggers before setting the selected item as chip in the component.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfMultiSelect TItem="GameFields" TValue="string[]" AllowFiltering="true" DataSource="@Games">
    <MultiSelectEvents TItem="GameFields" TValue="string[]" OnChipTag="@ChipTagHandler"></MultiSelectEvents>
    <MultiSelectFieldSettings Text="Text" Value="ID"></MultiSelectFieldSettings>
</SfMultiSelect>

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

    private void ChipTagHandler(TaggingEventArgs<GameFields> args)
    {
        // Here you can customize your code
    }
}
```

## OnValueRemove

`OnValueRemove` event triggers before the selected item is removed from the widget.

```cshtml

@using Syncfusion.Blazor.DropDowns

<SfMultiSelect TItem="GameFields" TValue="string[]" AllowFiltering="true" DataSource="@Games">
    <MultiSelectEvents TItem="GameFields" TValue="string[]" OnValueRemove="@OnValueRemovehandler"></MultiSelectEvents>
    <MultiSelectFieldSettings Text="Text" Value="ID"></MultiSelectFieldSettings>
</SfMultiSelect>

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

    private void OnValueRemovehandler(RemoveEventArgs<GameFields> args)
    {
        // Here you can customize your code
    }
}
```

## ValueRemoved

`ValueRemoved` event triggers after the selected item is removed from the widget.

```cshtml

@using Syncfusion.Blazor.DropDowns

<SfMultiSelect TItem="GameFields" TValue="string[]" AllowFiltering="true" DataSource="@Games">
    <MultiSelectEvents TItem="GameFields" TValue="string[]" ValueRemoved="@ValueRemovedhandler"></MultiSelectEvents>
    <MultiSelectFieldSettings Text="Text" Value="ID"></MultiSelectFieldSettings>
</SfMultiSelect>

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

    private void ValueRemovedhandler(RemoveEventArgs<GameFields> args)
    {
        // Here you can customize your code
    }
}
```

## CustomValueSpecifier

`CustomValueSpecifier` event triggers when the CustomValue is selected.

```cshtml

@using Syncfusion.Blazor.DropDowns

<SfMultiSelect TItem="GameFields" TValue="string[]"  AllowCustomValue="true" DataSource="@Games">
    <MultiSelectEvents TItem="GameFields" TValue="string[]" CustomValueSpecifier="@CustomValueSpecifierhandler"></MultiSelectEvents>
    <MultiSelectFieldSettings Text="Text" Value="ID"></MultiSelectFieldSettings>
</SfMultiSelect>

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

    private void CustomValueSpecifierhandler(CustomValueEventArgs<GameFields> args)
    {
        // Here you can customize your code
    }
}
```

## SelectedAll

`SelectedAll` event triggers after the select all process is completed.

```cshtml

@using Syncfusion.Blazor.DropDowns

<SfMultiSelect TItem="GameFields" TValue="string[]" Mode="@VisualMode.CheckBox"  ShowSelectAll="true" DataSource="@Games">
    <MultiSelectEvents TItem="GameFields" TValue="string[]" SelectedAll="@SelectedAllhandler"></MultiSelectEvents>
    <MultiSelectFieldSettings Text="Text" Value="ID"></MultiSelectFieldSettings>
</SfMultiSelect>

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

    private void SelectedAllhandler(SelectAllEventArgs<GameFields> args)
    {
        // Here you can customize your code
    }
}
```

N> MultiSelect is limited with these events and new events will be added in the future based on the user requests. If the event you are looking for is not on the list, then request [here](https://www.syncfusion.com/feedback/blazor-components).