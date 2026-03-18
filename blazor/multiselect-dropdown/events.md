---
layout: post
title: Events in Blazor MultiSelect Dropdown Component | Syncfusion
description: Learn about events in the Syncfusion Blazor MultiSelect Dropdown component for data actions, popup control, selection, filtering, and chip management.
platform: Blazor
control: MultiSelect Dropdown
documentation: ug
---

# Events in Blazor MultiSelect Dropdown Component

The Syncfusion Blazor [MultiSelect Dropdown](https://blazor.syncfusion.com/documentation/multiselect-dropdown/getting-started) component exposes a rich set of events that allow developers to interact with and respond to various lifecycle moments — from data loading and popup open/close, to item selection, chip tagging, custom values, filtering, and clearing. All events are defined through the [`MultiSelectEvents`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectEvents-2.html) child component, which is added inside [`SfMultiSelect`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html).

N> All event handlers must be registered inside the `<MultiSelectEvents>` tag within `<SfMultiSelect>`. Both `TValue` and `TItem` type parameters must match the parent `SfMultiSelect`.

## Registering events

Events are registered by adding `<MultiSelectEvents>` as a child of `<SfMultiSelect>` and assigning handler methods to the appropriate event parameters.

```razor
@using Syncfusion.Blazor.DropDowns;

<SfMultiSelect TValue="string[]" TItem="GameData" DataSource="@Games" Placeholder="Select games">
    <MultiSelectFieldSettings Text="Name" Value="Code" />
    <MultiSelectEvents TValue="string[]" TItem="GameData"
        ValueChange="OnValueChange"
        Created="OnCreated"
        Destroyed="OnDestroyed" />
</SfMultiSelect>

@code {
    public class GameData
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }

    private List<GameData> Games = new List<GameData>
    {
        new GameData { Name = "Cricket", Code = "CKT" },
        new GameData { Name = "Football", Code = "FBL" },
        new GameData { Name = "Basketball", Code = "BBL" }
    };

    private void OnValueChange(MultiSelectChangeEventArgs<string[]> args)
    {
        Console.WriteLine($"New values: {string.Join(", ", args.Value ?? Array.Empty<string>())}");
    }

    private void OnCreated(object args) => Console.WriteLine("MultiSelect created.");
    private void OnDestroyed(object args) => Console.WriteLine("MultiSelect destroyed.");
}
```

---

## Component lifecycle events

### Created

The [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectEvents-2.html#Syncfusion_Blazor_DropDowns_MultiSelectEvents_2_Created) event fires once when the MultiSelect component has finished initializing. Use it to perform post-initialization logic such as loading additional data or setting external state.

```razor
@using Syncfusion.Blazor.DropDowns;

<SfMultiSelect TValue="string[]" TItem="string" DataSource="@Colors" Placeholder="Pick colors">
    <MultiSelectEvents TValue="string[]" TItem="string" Created="OnCreated" />
</SfMultiSelect>

@code {
    private List<string> Colors = new() { "Red", "Green", "Blue", "Yellow" };

    private void OnCreated(object args)
    {
        Console.WriteLine("MultiSelect component is ready.");
    }
}
```

### Destroyed

The [Destroyed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectEvents-2.html#Syncfusion_Blazor_DropDowns_MultiSelectEvents_2_Destroyed) event fires when the component is torn down (disposed). Use it to release resources, unsubscribe from services, or log analytics.

```razor
@using Syncfusion.Blazor.DropDowns;

<SfMultiSelect TValue="string[]" TItem="string" DataSource="@Colors" Placeholder="Pick colors">
    <MultiSelectEvents TValue="string[]" TItem="string" Destroyed="OnDestroyed" />
</SfMultiSelect>

@code {
    private List<string> Colors = new() { "Red", "Green", "Blue" };

    private void OnDestroyed(object args)
    {
        Console.WriteLine("MultiSelect component has been destroyed.");
    }
}
```

---

## Focus events

### Focus

The [Focus](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectEvents-2.html#Syncfusion_Blazor_DropDowns_MultiSelectEvents_2_Focus) event triggers when the MultiSelect component receives focus, either through user interaction (tab/click) or programmatically via [`FocusAsync()`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_FocusAsync). Use it to display hints, enable validation feedback, or update UI state.

```razor
@using Syncfusion.Blazor.DropDowns;

<SfMultiSelect TValue="string[]" TItem="string" DataSource="@Skills" Placeholder="Select skills">
    <MultiSelectEvents TValue="string[]" TItem="string" Focus="OnFocus" />
</SfMultiSelect>

@code {
    private List<string> Skills = new() { "C#", "Blazor", "SQL", "Docker" };

    private void OnFocus(object args)
    {
        Console.WriteLine("MultiSelect is focused. Start selecting skills.");
    }
}
```

### Blur

The [Blur](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectEvents-2.html#Syncfusion_Blazor_DropDowns_MultiSelectEvents_2_Blur) event triggers when focus moves away from the MultiSelect component. This is commonly used to trigger form validation or persist intermediate state.

```razor
@using Syncfusion.Blazor.DropDowns;

<SfMultiSelect TValue="string[]" TItem="string" DataSource="@Skills" Placeholder="Select skills">
    <MultiSelectEvents TValue="string[]" TItem="string" Blur="OnBlur" />
</SfMultiSelect>

@code {
    private List<string> Skills = new() { "C#", "Blazor", "SQL" };

    private void OnBlur(object args)
    {
        Console.WriteLine("MultiSelect lost focus. Triggering validation.");
    }
}
```

---

## Data action events

These events track the lifecycle of remote or local data operations — when a fetch begins, completes, or fails.

### OnActionBegin

The [OnActionBegin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectEvents-2.html#Syncfusion_Blazor_DropDowns_MultiSelectEvents_2_OnActionBegin) event fires before a data fetch operation starts (for example, when binding remote data). Use it to modify or cancel the outgoing query, or to show a loading indicator.

**Event argument:** [`ActionBeginEventArgs`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.ActionBeginEventArgs.html)

| Property | Type | Description |
|---|---|---|
| `Cancel` | `bool` | Set to `true` to cancel the data fetch. |
| `EventName` | `string` | Name of the triggering event (e.g., `"load"`, `"filtering"`). |
| `Query` | `Query` | The data query to be executed; can be modified. |

```razor
@using Syncfusion.Blazor.DropDowns;
@using Syncfusion.Blazor.Data;

<SfMultiSelect TValue="string[]" TItem="Country" Placeholder="Select countries">
    <SfDataManager Url="https://services.odata.org/V4/Northwind/Northwind.svc/Customers"
                   Adaptor="Adaptors.ODataV4Adaptor" />
    <MultiSelectFieldSettings Text="ContactName" Value="CustomerID" />
    <MultiSelectEvents TValue="string[]" TItem="Country" OnActionBegin="OnActionBegin" />
</SfMultiSelect>

@code {
    public class Country { public string CustomerID { get; set; } public string ContactName { get; set; } }

    private void OnActionBegin(ActionBeginEventArgs args)
    {
        if (args.EventName == "filtering" && args.Query != null)
        {
            // Add extra filter for active records only
            args.Query.AddParams("onlyActive", true);
        }
    }
}
```

### OnActionComplete

The [OnActionComplete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectEvents-2.html#Syncfusion_Blazor_DropDowns_MultiSelectEvents_2_OnActionComplete) event fires after data has been successfully fetched and is ready to bind. Use it for post-processing, such as logging record counts or updating dependent UI.

**Event argument:** [`ActionCompleteEventArgs<TItem>`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.ActionCompleteEventArgs-1.html)

| Property | Type | Description |
|---|---|---|
| `Cancel` | `bool` | Set to `true` to cancel binding the fetched data. |
| `Count` | `double` | Total number of fetched records. |
| `EventName` | `string` | Name of the triggering action. |
| `Result` | `IEnumerable<TItem>` | The collection of fetched items. |

```razor
@using Syncfusion.Blazor.DropDowns;

<SfMultiSelect TValue="string[]" TItem="Employee" DataSource="@Employees" Placeholder="Select employees">
    <MultiSelectFieldSettings Text="Name" Value="ID" />
    <MultiSelectEvents TValue="string[]" TItem="Employee" OnActionComplete="OnActionComplete" />
</SfMultiSelect>

@code {
    public class Employee { public int ID { get; set; } public string Name { get; set; } }

    private List<Employee> Employees = new()
    {
        new() { ID = 1, Name = "Alice" },
        new() { ID = 2, Name = "Bob" },
        new() { ID = 3, Name = "Carol" }
    };

    private void OnActionComplete(ActionCompleteEventArgs<Employee> args)
    {
        Console.WriteLine($"Data loaded: {args.Count} records.");
    }
}
```

### OnActionFailure

The [OnActionFailure](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectEvents-2.html#Syncfusion_Blazor_DropDowns_MultiSelectEvents_2_OnActionFailure) event fires when a remote data fetch operation fails (for example, due to a network error or server exception). Use it to display error messages or implement retry logic.

**Event argument:** [`Exception`](https://learn.microsoft.com/en-us/dotnet/api/system.exception?view=net-10.0)

```razor
@using Syncfusion.Blazor.DropDowns;
@using Syncfusion.Blazor.Data;

<SfMultiSelect TValue="string[]" TItem="Product" Placeholder="Select products">
    <SfDataManager Url="https://invalid.api/products" Adaptor="Adaptors.WebApiAdaptor" />
    <MultiSelectFieldSettings Text="ProductName" Value="ProductID" />
    <MultiSelectEvents TValue="string[]" TItem="Product" OnActionFailure="OnActionFailure" />
</SfMultiSelect>

@code {
    public class Product { public int ProductID { get; set; } public string ProductName { get; set; } }

    private string errorMessage = "";

    private void OnActionFailure(Exception ex)
    {
        errorMessage = $"Failed to load data: {ex.Message}";
        Console.WriteLine(errorMessage);
    }
}
```

### DataBound

The [DataBound](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectEvents-2.html#Syncfusion_Blazor_DropDowns_MultiSelectEvents_2_DataBound) event fires after the data source has been fully loaded and bound to the popup list. Use it for post-load operations, such as pre-selecting items or displaying record summaries.

**Event argument:** [`DataBoundEventArgs`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DataBoundEventArgs.html)

```razor
@using Syncfusion.Blazor.DropDowns;

<SfMultiSelect TValue="string[]" TItem="Department" DataSource="@Departments" Placeholder="Select departments">
    <MultiSelectFieldSettings Text="DeptName" Value="DeptID" />
    <MultiSelectEvents TValue="string[]" TItem="Department" DataBound="OnDataBound" />
</SfMultiSelect>

@code {
    public class Department { public string DeptID { get; set; } public string DeptName { get; set; } }

    private List<Department> Departments = new()
    {
        new() { DeptID = "HR", DeptName = "Human Resources" },
        new() { DeptID = "IT", DeptName = "Information Technology" },
        new() { DeptID = "FIN", DeptName = "Finance" }
    };

    private void OnDataBound(DataBoundEventArgs args)
    {
        Console.WriteLine("All department data has been bound to the popup.");
    }
}
```

---

## Popup events

### OnOpen

The [OnOpen](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectEvents-2.html#Syncfusion_Blazor_DropDowns_MultiSelectEvents_2_OnOpen) event fires before the dropdown popup opens. Setting `args.Cancel = true` prevents the popup from opening.

**Event argument:** [`BeforeOpenEventArgs`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.BeforeOpenEventArgs.html)

| Property | Type | Description |
|---|---|---|
| `Cancel` | `bool` | Set to `true` to prevent the popup from opening. |

```razor
@using Syncfusion.Blazor.DropDowns;

<SfMultiSelect TValue="string[]" TItem="string" DataSource="@Fruits" Placeholder="Select fruits">
    <MultiSelectEvents TValue="string[]" TItem="string" OnOpen="OnOpen" />
</SfMultiSelect>

@code {
    private List<string> Fruits = new() { "Apple", "Banana", "Mango", "Orange" };
    private bool isReadOnly = false;

    private void OnOpen(BeforeOpenEventArgs args)
    {
        // Prevent popup from opening if the field is in read-only mode
        if (isReadOnly)
        {
            args.Cancel = true;
        }
    }
}
```

### Opened

The [Opened](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectEvents-2.html#Syncfusion_Blazor_DropDowns_MultiSelectEvents_2_Opened) event fires after the dropdown popup has opened (after the open animation completes). Use it for analytics, lazy loading, or additional UI setup once the popup is visible.

**Event argument:** [`PopupEventArgs`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.PopupEventArgs.html)

```razor
@using Syncfusion.Blazor.DropDowns;

<SfMultiSelect TValue="string[]" TItem="string" DataSource="@Fruits" Placeholder="Select fruits">
    <MultiSelectEvents TValue="string[]" TItem="string" Opened="OnOpened" />
</SfMultiSelect>

@code {
    private List<string> Fruits = new() { "Apple", "Banana", "Mango" };

    private void OnOpened(PopupEventArgs args)
    {
        Console.WriteLine("Dropdown popup is now open.");
    }
}
```

### OnClose

The [OnClose](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectEvents-2.html#Syncfusion_Blazor_DropDowns_MultiSelectEvents_2_OnClose) event fires before the dropdown popup closes. Setting `args.Cancel = true` keeps the popup open.

**Event argument:** [`PopupEventArgs`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.PopupEventArgs.html)

| Property | Type | Description |
|---|---|---|
| `Cancel` | `bool` | Set to `true` to prevent the popup from closing. |
| `Popup` | `PopupModel` | Reference to the popup model for advanced access. |

```razor
@using Syncfusion.Blazor.DropDowns;

<SfMultiSelect TValue="string[]" TItem="string" DataSource="@Tags" Placeholder="Select tags">
    <MultiSelectEvents TValue="string[]" TItem="string" OnClose="OnClose" />
</SfMultiSelect>

@code {
    private List<string> Tags = new() { "Urgent", "Review", "Blocked", "Done" };
    private bool requiresConfirmation = false;

    private void OnClose(PopupEventArgs args)
    {
        if (requiresConfirmation)
        {
            args.Cancel = true; // Keep popup open until user confirms
        }
    }
}
```

### Closed

The [Closed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectEvents-2.html#Syncfusion_Blazor_DropDowns_MultiSelectEvents_2_Closed) event fires after the dropdown popup has fully closed (after the close animation completes). Use it to clean up UI elements or run post-close logic.

**Event argument:** [`ClosedEventArgs`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.ClosedEventArgs.html)

```razor
@using Syncfusion.Blazor.DropDowns;

<SfMultiSelect TValue="string[]" TItem="string" DataSource="@Tags" Placeholder="Select tags">
    <MultiSelectEvents TValue="string[]" TItem="string" Closed="OnClosed" />
</SfMultiSelect>

@code {
    private List<string> Tags = new() { "Urgent", "Review", "Blocked" };

    private void OnClosed(ClosedEventArgs args)
    {
        Console.WriteLine("Dropdown popup is fully closed.");
    }
}
```

---

## Value change event

### ValueChange

The [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectEvents-2.html#Syncfusion_Blazor_DropDowns_MultiSelectEvents_2_ValueChange) event fires when the selected value(s) of the MultiSelect change — either through user selection in the popup, chip removal, or programmatic model updates.

**Event argument:** [`MultiSelectChangeEventArgs<TValue>`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectChangeEventArgs-1.html)

| Property | Type | Description |
|---|---|---|
| `Value` | `TValue` | The updated selected value(s). |
| `OldValue` | `TValue` | The previous selected value(s) before the change. |
| `IsInteracted` | `bool` | `true` if the change was triggered by user interaction. |

N> By default, `ValueChange` is fired after changing the value selections and when the component loses focus, since [EnableChangeOnBlur](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_EnableChangeOnBlur) is `true` by default. Set `EnableChangeOnBlur` to `false` to fire `ValueChange` immediately upon selection change.

```razor
@using Syncfusion.Blazor.DropDowns;

<SfMultiSelect TValue="string[]" TItem="Priority" @bind-Value="@selectedValues" DataSource="@Priorities" Placeholder="Select priorities">
    <MultiSelectFieldSettings Text="Label" Value="Code" />
    <MultiSelectEvents TValue="string[]" TItem="Priority" ValueChange="OnValueChange" />
</SfMultiSelect>

<p>Selected: @(selectedValues != null ? string.Join(", ", selectedValues) : "None")</p>

@code {
    public class Priority 
    { 
        public string Code { get; set; } 
        public string Label { get; set; } 
    }

    private List<Priority> Priorities = new()
    {
        new() { Code = "HIGH", Label = "High" },
        new() { Code = "MED",  Label = "Medium" },
        new() { Code = "LOW",  Label = "Low" }
    };

    private string[] selectedValues;

    private void OnValueChange(MultiSelectChangeEventArgs<string[]> args)
    {
        Console.WriteLine($"Changed from [{string.Join(",", args.OldValue ?? Array.Empty<string>())}] to [{string.Join(",", args.Value ?? Array.Empty<string>())}]");
    }
}
```

---

## Item selection events

### OnValueSelect

The [OnValueSelect](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectEvents-2.html#Syncfusion_Blazor_DropDowns_MultiSelectEvents_2_OnValueSelect) event fires when a user selects an item from the dropdown popup. Setting `args.Cancel = true` prevents the item from being added to the selection.

**Event argument:** [`SelectEventArgs<TItem>`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SelectEventArgs-1.html)

| Property | Type | Description |
|---|---|---|
| `ItemData` | `TItem` | The data object of the selected item. |
| `IsInteracted` | `bool` | `true` if triggered by user action. |
| `Cancel` | `bool` | Set to `true` to prevent the item from being selected. |

```razor
@using Syncfusion.Blazor.DropDowns;

<SfMultiSelect TValue="string[]" TItem="Product" DataSource="@Products" Placeholder="Select products"
               MaximumSelectionLength="3">
    <MultiSelectFieldSettings Text="ProductName" Value="ProductID" />
    <MultiSelectEvents TValue="string[]" TItem="Product" OnValueSelect="OnValueSelect" />
</SfMultiSelect>

@code {
    public class Product 
    { 
        public string ProductID { get; set; } 
        public string ProductName { get; set; } 
        public bool IsDiscontinued { get; set; } 
    }

    private List<Product> Products = new()
    {
        new() { ProductID = "P1", ProductName = "Laptop",  IsDiscontinued = false },
        new() { ProductID = "P2", ProductName = "Keyboard", IsDiscontinued = true  },
        new() { ProductID = "P3", ProductName = "Mouse",   IsDiscontinued = false }
    };

    private void OnValueSelect(SelectEventArgs<Product> args)
    {
        // Prevent selection of discontinued products
        if (args.ItemData?.IsDiscontinued == true)
        {
            args.Cancel = true;
            Console.WriteLine($"{args.ItemData.ProductName} is discontinued and cannot be selected.");
        }
    }
}
```

---

## Item removal events

### OnValueRemove

The [OnValueRemove](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectEvents-2.html#Syncfusion_Blazor_DropDowns_MultiSelectEvents_2_OnValueRemove) event fires before a selected value/chip is removed from the MultiSelect. Setting `args.Cancel = true` prevents the removal.

**Event argument:** [`RemoveEventArgs<TItem>`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.RemoveEventArgs-1.html)

| Property | Type | Description |
|---|---|---|
| `ItemData` | `TItem` | The data object of the item being removed. |
| `IsInteracted` | `bool` | `true` if the removal was triggered by user action. |
| `Cancel` | `bool` | Set to `true` to cancel the removal. |

```razor
@using Syncfusion.Blazor.DropDowns;

<SfMultiSelect TValue="string[]" TItem="Role" DataSource="@Roles" Placeholder="Select roles">
    <MultiSelectFieldSettings Text="RoleName" Value="RoleID" />
    <MultiSelectEvents TValue="string[]" TItem="Role" OnValueRemove="OnValueRemove" />
</SfMultiSelect>

@code {
    public class Role 
    { 
        public string RoleID { get; set; } 
        public string RoleName { get; set; } 
        public bool IsRequired { get; set; } 
    }

    private List<Role> Roles = new()
    {
        new() { RoleID = "ADMIN", RoleName = "Administrator", IsRequired = true  },
        new() { RoleID = "USER",  RoleName = "Standard User",  IsRequired = false },
        new() { RoleID = "AUDIT", RoleName = "Auditor",         IsRequired = false }
    };

    private void OnValueRemove(RemoveEventArgs<Role> args)
    {
        // Prevent removal of required roles
        if (args.ItemData?.IsRequired == true)
        {
            args.Cancel = true;
            Console.WriteLine($"Role '{args.ItemData.RoleName}' is required and cannot be removed.");
        }
    }
}
```

### ValueRemoved

The [ValueRemoved](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectEvents-2.html#Syncfusion_Blazor_DropDowns_MultiSelectEvents_2_ValueRemoved) event fires after a value has been successfully removed from the selection. Use it to update counters, sync external lists, or log the removed item.

**Event argument:** [`RemoveEventArgs<TItem>`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.RemoveEventArgs-1.html)

```razor
@using Syncfusion.Blazor.DropDowns;

<SfMultiSelect TValue="string[]" TItem="Tag" DataSource="@Tags" Placeholder="Select tags">
    <MultiSelectFieldSettings Text="TagName" Value="TagID" />
    <MultiSelectEvents TValue="string[]" TItem="Tag" ValueRemoved="OnValueRemoved" />
</SfMultiSelect>

@code {
    public class Tag 
    { 
        public string TagID { get; set; } 
        public string TagName { get; set; } 
    }
    private List<Tag> Tags = new()
    {
        new() { TagID = "BUG",  TagName = "Bug"  },
        new() { TagID = "FEAT", TagName = "Feature" },
        new() { TagID = "DOC",  TagName = "Documentation" }
    };

    private void OnValueRemoved(RemoveEventArgs<Tag> args)
    {
        Console.WriteLine($"Tag '{args.ItemData?.TagName}' was removed.");
    }
}
```

---

## Select all events

### SelectingAll

The [SelectingAll](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectEvents-2.html#Syncfusion_Blazor_DropDowns_MultiSelectEvents_2_SelectingAll) event fires before the select-all or deselect-all operation starts (available in `CheckBox` mode). Setting `args.Cancel = true` prevents the operation. Setting `args.SuppressItemEvents = true` suppresses the individual [`OnValueSelect`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectEvents-2.html#Syncfusion_Blazor_DropDowns_MultiSelectEvents_2_OnValueSelect), [`OnValueRemove`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectEvents-2.html#Syncfusion_Blazor_DropDowns_MultiSelectEvents_2_OnValueRemove), and [`ValueRemoved`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectEvents-2.html#Syncfusion_Blazor_DropDowns_MultiSelectEvents_2_ValueRemoved) events that would otherwise fire for each item.

> **Performance Tip:** Use `SuppressItemEvents = true` when selecting/deselecting large lists to avoid firing thousands of item-level events, which can significantly impact UI responsiveness.

**Event argument:** [`SelectingAllEventArgs<TItem>`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SelectingAllEventArgs-1.html)

| Property | Type | Description |
|---|---|---|
| `Cancel` | `bool` | Set to `true` to cancel the select-all/deselect-all action. |
| `SuppressItemEvents` | `bool` | Set to `true` to suppress individual item select/remove events. |
| `IsChecked` | `bool` | `true` when selecting all; `false` when deselecting all. |
| `IsInteracted` | `bool` | `true` if triggered by user action. |

```razor
@using Syncfusion.Blazor.DropDowns;

<SfMultiSelect TValue="string[]" TItem="string" DataSource="@Regions" Placeholder="Select regions"
               Mode="VisualMode.CheckBox" ShowSelectAll="true">
    <MultiSelectEvents TValue="string[]" TItem="string"
        SelectingAll="OnSelectingAll" />
</SfMultiSelect>

@code {
    private List<string> Regions = new() { "North", "South", "East", "West", "Central" };
    private bool allowSelectAll = true;

    private void OnSelectingAll(SelectingAllEventArgs<string> args)
    {
        if (!allowSelectAll)
        {
            args.Cancel = true;
            Console.WriteLine("Select All is currently disabled.");
        }

        // Suppress individual item events for performance with large lists
        args.SuppressItemEvents = true;
    }
}
```

### SelectedAll

The [SelectedAll](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectEvents-2.html#Syncfusion_Blazor_DropDowns_MultiSelectEvents_2_SelectedAll) event fires after the select-all or deselect-all operation completes. Use it to update external UI or log the final state.

**Event argument:** [`SelectAllEventArgs<TItem>`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SelectAllEventArgs-1.html)

| Property | Type | Description |
|---|---|---|
| `IsChecked` | `bool` | `true` after a select-all; `false` after a deselect-all. |
| `IsInteracted` | `bool` | `true` if triggered by user action. |
| `ItemData` | `IEnumerable<TItem>` | Collection of all items after the operation. |

```razor
@using Syncfusion.Blazor.DropDowns;

<SfMultiSelect TValue="string[]" TItem="string" DataSource="@Regions" Placeholder="Select regions"
               Mode="VisualMode.CheckBox" ShowSelectAll="true">
    <MultiSelectEvents TValue="string[]" TItem="string" SelectedAll="OnSelectedAll" />
</SfMultiSelect>

@code {
    private List<string> Regions = new() { "North", "South", "East", "West" };

    private void OnSelectedAll(SelectAllEventArgs<string> args)
    {
        string action = args.IsChecked ? "selected all" : "deselected all";
        Console.WriteLine($"User {action} regions. Total: {args.ItemData?.Count() ?? 0}");
    }
}
```

---

## Chip (tag) events

### OnChipTag

The [OnChipTag](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectEvents-2.html#Syncfusion_Blazor_DropDowns_MultiSelectEvents_2_OnChipTag) event fires before a selected item is rendered as a chip (tag) in the input box. Use it to apply custom CSS classes, cancel the chip creation, or modify chip appearance.

**Event argument:** [`TaggingEventArgs<TItem>`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.TaggingEventArgs-1.html)

| Property | Type | Description |
|---|---|---|
| `ItemData` | `TItem` | The data object being tagged as a chip. |
| `SetClass` | `string` | CSS class to apply to the chip element. |
| `Cancel` | `bool` | Set to `true` to prevent the chip from being created. |
| `IsInteracted` | `bool` | `true` if triggered by user interaction. |

```razor
@using Syncfusion.Blazor.DropDowns;

<SfMultiSelect TValue="string[]" TItem="Task" DataSource="@Tasks" Placeholder="Select tasks"
               Mode="VisualMode.Box">
    <MultiSelectFieldSettings Text="Title" Value="ID" />
    <MultiSelectEvents TValue="string[]" TItem="Task" OnChipTag="OnChipTag" />
</SfMultiSelect>

@code {
    public class Task 
    { 
        public string ID { get; set; } 
        public string Title { get; set; } 
        public string Priority { get; set; } 
    }

    private List<Task> Tasks = new()
    {
        new() { ID = "T1", Title = "Fix login bug",    Priority = "High"   },
        new() { ID = "T2", Title = "Update README",    Priority = "Low"    },
        new() { ID = "T3", Title = "Deploy to staging", Priority = "High"  }
    };

    private void OnChipTag(TaggingEventArgs<Task> args)
    {
        // Apply different chip color based on priority
        args.SetClass = args.ItemData?.Priority == "High" ? "e-chip-high-priority" : "e-chip-low-priority";
    }
}
```

### ChipSelected

The [ChipSelected](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectEvents-2.html#Syncfusion_Blazor_DropDowns_MultiSelectEvents_2_ChipSelected) event fires when a chip in the input area is clicked/selected by the user. Use it to identify which chip is active and trigger contextual actions.

**Event argument:** [`ChipSelectedEventArgs<TItem>`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.ChipSelectedEventArgs-1.html)

| Property | Type | Description |
|---|---|---|
| `ChipData` | `TItem` | The data object of the selected chip. |

```razor
@using Syncfusion.Blazor.DropDowns;

<SfMultiSelect TValue="string[]" TItem="Employee" DataSource="@Team" Placeholder="Select team members"
               Mode="VisualMode.Box">
    <MultiSelectFieldSettings Text="Name" Value="EmpID" />
    <MultiSelectEvents TValue="string[]" TItem="Employee" ChipSelected="OnChipSelected" />
</SfMultiSelect>

<p>Active chip: @activeChipName</p>

@code {
    public class Employee 
    { 
        public string EmpID { get; set; } 
        public string Name { get; set; } 
    }

    private List<Employee> Team = new()
    {
        new() { EmpID = "E1", Name = "Alice" },
        new() { EmpID = "E2", Name = "Bob"   },
        new() { EmpID = "E3", Name = "Carol" }
    };

    private string activeChipName = "";

    private void OnChipSelected(ChipSelectedEventArgs<Employee> args)
    {
        activeChipName = args.ChipData?.Name;
    }
}
```

---

## Clear event

### Cleared

The [Cleared](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectEvents-2.html#Syncfusion_Blazor_DropDowns_MultiSelectEvents_2_Cleared) event fires after all selected values are cleared — either by clicking the clear icon or programmatically via [`ClearAsync()`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_ClearAsync). Use it for post-clear operations such as resetting dependent controls.

**Event argument:** `MouseEventArgs`

```razor
@using Syncfusion.Blazor.DropDowns;

<SfMultiSelect TValue="string[]" TItem="string" DataSource="@Colors" Placeholder="Select colors"
               ShowClearButton="true">
    <MultiSelectEvents TValue="string[]" TItem="string" Cleared="OnCleared" />
</SfMultiSelect>

@code {
    private List<string> Colors = new() { "Red", "Green", "Blue", "Yellow" };

    private void OnCleared(Microsoft.AspNetCore.Components.Web.MouseEventArgs args)
    {
        Console.WriteLine("All selections have been cleared.");
        // Reset dependent dropdowns or form state here
    }
}
```

---

## Filtering event

### Filtering

The [Filtering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectEvents-2.html#Syncfusion_Blazor_DropDowns_MultiSelectEvents_2_Filtering) event fires on every keystroke when [AllowFiltering](https://blazor.syncfusion.com/documentation/multiselect-dropdown/filtering) is enabled. It enables both built-in filtering and fully custom filtering logic against local or remote data sources.

**Event argument:** [`FilteringEventArgs`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.FilteringEventArgs.html)

| Property | Type | Description |
|---|---|---|
| `Text` | `string` | The current filter input text typed by the user. |
| `PreventDefaultAction` | `bool` | Set to `true` to disable the default built-in filtering and apply custom logic instead. |
| `Cancel` | `bool` | Set to `true` to cancel the filter operation entirely. |

N> When implementing custom filtering, set `args.PreventDefaultAction = true` and then call `await multiSelectRef.FilterAsync(filteredData, query)` to apply your own filter result.

**Built-in filtering:**

```razor
@using Syncfusion.Blazor.DropDowns;

<SfMultiSelect TValue="string[]" TItem="string" DataSource="@Languages"
               Placeholder="Select languages" AllowFiltering="true">
    <MultiSelectEvents TValue="string[]" TItem="string" Filtering="OnFiltering" />
</SfMultiSelect>

@code {
    private List<string> Languages = new() { "C#", "JavaScript", "Python", "Rust", "Go", "TypeScript" };

    private void OnFiltering(FilteringEventArgs args)
    {
        // Minimum 2 characters before filtering (performance optimization)
        if (args.Text.Length < 2)
            args.Cancel = true;
    }
}
```

**Custom filtering with [`FilterAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_FilterAsync_System_Collections_Generic_IEnumerable__1__Syncfusion_Blazor_Data_Query_Syncfusion_Blazor_DropDowns_FieldSettingsModel_):**

```razor
@using Syncfusion.Blazor.DropDowns;
@using Syncfusion.Blazor.Data;

<SfMultiSelect @ref="MultiSelectRef" TValue="string[]" TItem="City" DataSource="@Cities"
               Placeholder="Search cities" AllowFiltering="true">
    <MultiSelectFieldSettings Text="CityName" Value="CityCode" />
    <MultiSelectEvents TValue="string[]" TItem="City" Filtering="OnCustomFiltering" />
</SfMultiSelect>

@code {
    private SfMultiSelect<string[], City> MultiSelectRef;

    public class City 
    {
        public string CityCode { get; set; } 
        public string CityName { get; set; } 
    }

    private List<City> Cities = new()
    {
        new() { CityCode = "NYC", CityName = "New York"    },
        new() { CityCode = "LAX", CityName = "Los Angeles" },
        new() { CityCode = "CHI", CityName = "Chicago"     },
        new() { CityCode = "HOU", CityName = "Houston"     }
    };

    private async Task OnCustomFiltering(FilteringEventArgs args)
    {
        args.PreventDefaultAction = true;

        var query = new Syncfusion.Blazor.Data.Query()
            .Where(new Syncfusion.Blazor.Data.WhereFilter()
            {
                Field = "CityName",
                Operator = "contains",
                value = args.Text,
                IgnoreCase = true
            });

        await MultiSelectRef.FilterAsync(Cities, query);
    }
}
```

---

## Custom value event

### CustomValueSpecifier

The [CustomValueSpecifier](https://blazor.syncfusion.com/documentation/multiselect-dropdown/custom-value) event fires when a user types a value that does not exist in the data source and [AllowCustomValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_AllowCustomValue) is enabled. Use it to create and return a new data object for the custom entry.

**Event argument:** [`CustomValueEventArgs<TItem>`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.CustomValueEventArgs-1.html)

| Property | Type | Description |
|---|---|---|
| `Text` | `string` | The custom text typed by the user. |
| `NewData` | `TItem` | Set this to the newly created data object to add to the list. |
| `Cancel` | `bool` | Set to `true` to reject the custom value. |

```razor
@using Syncfusion.Blazor.DropDowns;

<SfMultiSelect TValue="string[]" TItem="Label" DataSource="@Labels"
               Placeholder="Select or create labels" AllowCustomValue="true">
    <MultiSelectFieldSettings Text="Name" Value="Code" />
    <MultiSelectEvents TValue="string[]" TItem="Label" CustomValueSpecifier="OnCustomValue" />
</SfMultiSelect>

@code {
    public class Label 
    {
        public string Code { get; set; } 
        public string Name { get; set; } 
    }

    private List<Label> Labels = new()
    {
        new() { Code = "BUG",  Name = "Bug"         },
        new() { Code = "FEAT", Name = "Feature"     },
        new() { Code = "PERF", Name = "Performance" }
    };

    private void OnCustomValue(CustomValueEventArgs<Label> args)
    {
        // Create a new Label from the user-typed text
        args.NewData = new Label
        {
            Code = args.Text.ToUpper().Replace(" ", "_"),
            Name = args.Text
        };
    }
}
```

---

## Popup resize events

When the [AllowResize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_AllowResize) property is set to `true`, users can drag the bottom-right corner of the dropdown popup to resize it. Two events track this interaction.

### OnResizeStart

The [OnResizeStart](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectEvents-2.html#Syncfusion_Blazor_DropDowns_MultiSelectEvents_2_OnResizeStart) event fires when the user begins resizing the popup. Use it to log, restrict, or set initial resize state.

**Event argument:** `object`

### OnResizeStop

The [OnResizeStop](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectEvents-2.html#Syncfusion_Blazor_DropDowns_MultiSelectEvents_2_OnResizeStop) event fires when the user finishes resizing the popup. Use it to save the final popup dimensions or update layout state.

**Event argument:** `object`

```razor
@using Syncfusion.Blazor.DropDowns;

<SfMultiSelect TValue="string[]" TItem="string" DataSource="@Options"
               Placeholder="Select options" AllowResize="true" Width="300px">
    <MultiSelectEvents TValue="string[]" TItem="string"
        OnResizeStart="OnResizeStart"
        OnResizeStop="OnResizeStop" />
</SfMultiSelect>

<p>@resizeStatus</p>

@code {
    private List<string> Options = new() { "Option A", "Option B", "Option C", "Option D" };
    private string resizeStatus = "";

    private void OnResizeStart(object args)
    {
        resizeStatus = "Popup is being resized...";
    }

    private void OnResizeStop(object args)
    {
        resizeStatus = "Popup resize complete.";
    }
}
```

N> The `OnResizeStart` and `OnResizeStop` events are only triggered when `AllowResize="true"` is set on the `SfMultiSelect` component.

---

## Events summary

The following table summarizes all available events in the [`MultiSelectEvents`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectEvents-2.html) component:

| Event | Event Argument | Description |
|---|---|---|
| [`Created`](#created) | `object` | Fires once when the component finishes initialization. |
| [`Destroyed`](#destroyed) | `object` | Fires when the component is torn down. |
| [`Focus`](#focus) | `object` | Fires when the component receives focus. |
| [`Blur`](#blur) | `object` | Fires when the component loses focus. |
| [`OnActionBegin`](#onactionbegin) | `ActionBeginEventArgs` | Fires before a data fetch operation starts. |
| [`OnActionComplete`](#onactioncomplete) | `ActionCompleteEventArgs<TItem>` | Fires after data fetch completes successfully. |
| [`OnActionFailure`](#onactionfailure) | `Exception` | Fires when a remote data fetch fails. |
| [`DataBound`](#databound) | `DataBoundEventArgs` | Fires after the data source is fully bound to the popup list. |
| [`OnOpen`](#onopen) | `BeforeOpenEventArgs` | Fires before the popup opens; supports cancellation. |
| [`Opened`](#opened) | `PopupEventArgs` | Fires after the popup has fully opened. |
| [`OnClose`](#onclose) | `PopupEventArgs` | Fires before the popup closes; supports cancellation. |
| [`Closed`](#closed) | `ClosedEventArgs` | Fires after the popup has fully closed. |
| [`ValueChange`](#valuechange) | `MultiSelectChangeEventArgs<TValue>` | Fires when the selected value changes. |
| [`OnValueSelect`](#onvalueselect) | `SelectEventArgs<TItem>` | Fires when an item is selected; supports cancellation. |
| [`OnValueRemove`](#onvalueremove) | `RemoveEventArgs<TItem>` | Fires before a selected value is removed; supports cancellation. |
| [`ValueRemoved`](#valueremoved) | `RemoveEventArgs<TItem>` | Fires after a selected value is removed. |
| [`SelectingAll`](#selectingall) | `SelectingAllEventArgs<TItem>` | Fires before select-all or deselect-all; supports cancellation. |
| [`SelectedAll`](#selectedall) | `SelectAllEventArgs<TItem>` | Fires after select-all or deselect-all completes. |
| [`OnChipTag`](#onchiptag) | `TaggingEventArgs<TItem>` | Fires before an item is rendered as a chip; supports CSS customization. |
| [`ChipSelected`](#chipselected) | `ChipSelectedEventArgs<TItem>` | Fires when a chip is clicked/selected. |
| [`Cleared`](#cleared) | `MouseEventArgs` | Fires after all selected values are cleared. |
| [`Filtering`](#filtering) | `FilteringEventArgs` | Fires on every keystroke in the filter box. |
| [`CustomValueSpecifier`](#customvaluespecifier) | `CustomValueEventArgs<TItem>` | Fires when a user enters a custom value not present in the data source. |
| [`OnResizeStart`](#onresizestart) | `object` | Fires when popup resize begins (requires `AllowResize="true"`). |
| [`OnResizeStop`](#onresizestop) | `object` | Fires when popup resize ends (requires `AllowResize="true"`). |

---

## See also

- [Getting started with Blazor MultiSelect Dropdown](https://blazor.syncfusion.com/documentation/multiselect-dropdown/getting-started)
- [MultiSelect Dropdown filtering](https://blazor.syncfusion.com/documentation/multiselect-dropdown/filtering)
- [MultiSelect Dropdown custom value](https://blazor.syncfusion.com/documentation/multiselect-dropdown/custom-value)
- [MultiSelect Dropdown virtualization](https://blazor.syncfusion.com/documentation/multiselect-dropdown/virtualization)
- [Live demo: Blazor MultiSelect Dropdown](https://blazor.syncfusion.com/demos/multiselect-dropdown/default-functionalities)
