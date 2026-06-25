---
layout: post
title: Methods in Blazor Sparkline Component | Syncfusion
description: Learn about available methods in the Syncfusion Blazor Sparkline component, including how to refresh the chart.
platform: Blazor
control: Sparkline Charts
documentation: ug
---

# Methods in Blazor Sparkline Component


The Syncfusion Blazor Sparkline component provides several methods that allow developers to interact with and control the chart programmatically. These methods can be accessed by creating a reference to the Sparkline component using the `@ref` property. This enables you to refresh the chart, update its data, or perform other actions directly from your C# code, making your applications more dynamic and responsive.

## Using the `@ref` Property

The `@ref` property in Blazor is a powerful feature that allows you to obtain a reference to a component instance. By assigning a variable to the `@ref` attribute of the Sparkline component, you can call its public methods from your code-behind or inline `@code` block. This is especially useful for scenarios where you need to update the chart in response to user actions, data changes, or other events.

### Example: Creating a Reference

```cshtml
<SfSparkline @ref="@Sparkline" ... ></SfSparkline>
```

In your `@code` block, declare a variable of type `SfSparkline<T>` (where `T` is the data type used in your chart):

```csharp
public SfSparkline<int> Sparkline { get; set; }
```

## Available Methods

Currently, the primary method exposed by the Sparkline component is `RefreshAsync`, which allows you to re-render the chart. This can be useful when the underlying data changes or when you want to update the chart's appearance dynamically.

### RefreshAsync Method

The `RefreshAsync` method triggers a re-render of the Sparkline component. This is particularly helpful when you update the data source or modify chart properties at runtime. By calling this method, you ensure that the latest data and settings are reflected in the chart.

#### Syntax

```csharp
await Sparkline.RefreshAsync();
```

### Complete Example: Refreshing the Sparkline

Below is a complete example demonstrating how to use the `@ref` property and the `RefreshAsync` method to refresh the Sparkline chart when a button is clicked:

```cshtml
@using Syncfusion.Blazor.Charts

<button @onclick="RefreshCall">Refresh</button>
<SfSparkline @ref="@Sparkline" DataSource="new int[]{ 3, 6, 4, 1, 3, 2, 5 }" Type="SparklineType.Area" Height="200px" Width="350px" Fill="#b2cfff" LineWidth="1">
</SfSparkline>

@code {
    public SfSparkline<int> Sparkline { get; set; }

    public async Task RefreshCall()
    {
        await Sparkline.RefreshAsync();
    }
}
```

## Step-by-Step Guide

1. **Add the Sparkline Component**: Place the `<SfSparkline>` component in your Razor file and assign it an `@ref` variable.
2. **Declare the Reference Variable**: In your `@code` block, declare a public property of type `SfSparkline<T>`.
3. **Create a Method to Call RefreshAsync**: Define a method that calls `RefreshAsync` on your Sparkline reference.
4. **Trigger the Method**: Use a button or another event to trigger the refresh method.

## Practical Scenarios

- **Dynamic Data Updates**: When your data source changes (e.g., after fetching new data from an API), call `RefreshAsync` to update the chart.
- **User Interactions**: Allow users to refresh the chart manually by clicking a button, as shown in the example.
- **Theme or Appearance Changes**: If you change the chart's appearance (such as colors or line width) at runtime, use `RefreshAsync` to apply the changes.

## Best Practices

- Always ensure that the reference variable (e.g., `Sparkline`) is not null before calling methods on it, especially if the component may not be rendered yet.
- Use `RefreshAsync` judiciously to avoid unnecessary re-renders, which can impact performance if called too frequently.
- Combine method calls with state management to ensure your UI remains consistent and responsive.

## Additional Resources

- [Blazor Sparkline Documentation](https://blazor.syncfusion.com/documentation/sparkline/getting-started)
- [Syncfusion Blazor API Reference](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfSparkline-1.html)
- [Blazor Component References (`@ref`)](https://docs.microsoft.com/en-us/aspnet/core/blazor/components/?view=aspnetcore-6.0#capture-references-to-components)

By leveraging the methods available in the Blazor Sparkline component, you can create interactive and dynamic data visualizations that respond to user actions and real-time data changes. This enhances the user experience and provides greater flexibility in how you present and manage your data within Blazor applications.