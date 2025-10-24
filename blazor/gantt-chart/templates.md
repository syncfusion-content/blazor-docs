---
layout: post
title: Templates in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about templates in Syncfusion Blazor Gantt Chart component and much more details.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Templates in Blazor Gantt Chart component

Blazor supports templated components that accept one or more UI segments as input, which are rendered as part of the component during execution. The Gantt Chart is a templated Razor component that allows customization of various UI elements using template parameters. This allows rendering of custom content or components based on application logic.

The Gantt Chart provides several template options for customization, such as:

- [Column template](https://blazor.syncfusion.com/documentation/gantt-chart/column-template) – Used to customize the content of individual cells.
- [Header template](https://blazor.syncfusion.com/documentation/gantt-chart/columns#header-template) – Used to customize the content of header cells.

## Template Context

Most templates used in the Gantt Chart are of type `RenderFragment<T>` and are passed with parameters. These parameters can be accessed within the template using an implicit parameter named `context`. The name of this implicit parameter can also be customized using the `Context` attribute.

For example, the data in a column template can be accessed using `context` as shown below:

```razor
<GanttColumn Field="TaskName" HeaderText="Task">
    <Template Context="context">
        @context.TaskName
    </Template>
</GanttColumn>
```

## GanttChartTemplates component

In Blazor, when a component includes a `RenderFragment` property, it restricts the use of other child components outside that fragment. This is a framework-defined behavior [by design in Blazor](https://github.com/dotnet/aspnetcore/issues/10836), which prevents placing additional child components directly within the parent component.

Due to this limitation, templates such as `TaskbarTemplate` and `MilestoneTemplate` cannot be declared directly under the Gantt Chart component. Instead, they must be wrapped inside a `GanttTemplates` component to ensure proper structure and rendering.