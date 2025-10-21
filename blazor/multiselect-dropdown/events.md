---
layout: post
title: Events in Blazor MultiSelect Component | Syncfusion
description: Checkout and learn here all about events in Syncfusion Blazor MultiSelect component and much more details.
platform: Blazor
control: MultiSelect
documentation: ug
---

# Events in Blazor MultiSelect Component

This section lists the events available in the Blazor MultiSelect Dropdown component and when they are triggered during user interactions.

## Blur

The `Blur` event is triggered when the input loses focus. Typical uses include validation and committing changes.

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

The `ValueChange` event is triggered when the MultiSelect value changes due to selection or removal actions.

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

The `Closed` event is triggered after the popup is closed and is useful for post-close logic.

```cshtml

```

## Created

The `Created` event is triggered after the component has been initialized. Use it for one-time setup.

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

The `Destroyed` event is triggered when the component is disposed. Use it for cleanup logic.

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

The `Focus` event is triggered when the input gains focus. Use it to customize focus behavior.

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

The `OnOpen` event is triggered before the popup opens. This event is cancelable; cancel it to keep the popup closed.

```cshtml

```

## OnClose

The `OnClose` event is triggered before the popup closes. This event is cancelable; cancel it to keep the popup open.

```cshtml


```

## DataBound

The `DataBound` event is triggered when the data source has been populated in the popup list.

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

The `Filtering` event is triggered while typing in the filter bar when `AllowFiltering` is enabled. Use it to customize filtering logic.

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

The `OnActionBegin` event is triggered before a remote data request is sent. Use it to modify queries or parameters.

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

The `OnActionFailure` event is triggered when a remote data request fails. Use it for error handling and logging.

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

The `OnValueSelect` event is triggered when a user selects an item in the popup using the mouse or keyboard.

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

The `Opened` event is triggered after the popup has opened. Use it to run logic that requires rendered popup content.

```cshtml

```

## ChipSelected

The `ChipSelected` event is triggered when a value chip is selected in the input area (chip mode).

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

The `Cleared` event is triggered after clearing all selected items using the clear icon.

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

The `OnChipTag` event is triggered before the selected item is displayed as a chip in the input area. Use it to customize tagging behavior.

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

The `OnValueRemove` event is triggered before a selected item is removed from the component. Use it to intercept and optionally prevent removal.

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

The `ValueRemoved` event is triggered after a selected item is removed from the component.

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

The `CustomValueSpecifier` event is triggered when a custom value is selected while `AllowCustomValue` is enabled. Use it to provide custom item data.

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

The `SelectedAll` event is triggered after the select-all operation completes (CheckBox mode with ShowSelectAll).

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

N> The MultiSelect currently provides the events listed above. Additional events may be added in future releases based on user requests. If a required event is missing, submit a request using the Syncfusion Blazor feedback portal: [Request a feature](https://www.syncfusion.com/feedback/blazor-components).