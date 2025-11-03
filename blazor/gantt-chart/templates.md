---
layout: post
title: Templates in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about templates in Syncfusion Blazor Gantt Chart component and much more details.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Templates in Blazor Gantt Chart Component

Blazor has templated components thats accepts one or more UI segments as input that can be rendered as part of the component during component rendering. Gantt Chart is a templated razor component, that allows customizing various part of the UI using template parameters. It allows rendering custom components or content based on its logic.

The available template options in Gantt Chart are as follows,
* [Column template](https://blazor.syncfusion.com/documentation/gantt-chart/column-template) - Used to customize cell content.
* [Header template](https://blazor.syncfusion.com/documentation/gantt-chart/columns#header-template) - Used to customize header cell content.

## Template context

Most of the templates used by the Gantt Chart are of type `RenderFragment<T>` and they will be passed with parameters. The parameters passed can be accessed to the templates using implicit parameter named `context`. This implicit parameter name can also be changed using the `Context` attribute.

For example, the data of the column template can be accessed using `context` as follows.


## GanttChartTemplates component

If a component contains any `RenderFragment` type property then it does not allow any child components other than the render fragment property, which is [by design in Blazor](https://github.com/dotnet/aspnetcore/issues/10836).

This prevents from directly specifying templates such as `TaskbarTemplate` and `MilestoneTemplate` as descendant of the Gantt Chart component. Hence the templates such as `TaskbarTemplate` and `MilestoneTemplate` should be wrapped around a component named `GanttTemplates` as follows.


