---
layout: post
title: Breakpoints in Blazor Media Query | Syncfusion
description: Configure built-in or custom breakpoints in Blazor Media Query to adapt layouts for small, medium, and large screens.
platform: Blazor
control: Media Query
documentation: ug
---

# Breakpoints in Blazor Media Query

Blazor Media Query breakpoints let you build responsive and adaptive layouts by defining screen-size thresholds at which the layout and styling of the web application adjust for the best user experience.

## Built-in breakpoints

You can customize the appearance of the application based on the screen size using the built-in breakpoints. The [ActiveBreakPoint](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfMediaQuery.html#Syncfusion_Blazor_SfMediaQuery_ActiveBreakPoint) property gives the breakpoint that is currently matching the media query.

The built-in breakpoint values for the Media Query component are:

* **Small** — browser width ≤ 768 pixels
* **Medium** — browser width between 768 and 1024 pixels
* **Large** — browser width ≥ 1024 pixels

### Modifying built-in breakpoints

You can modify the media query for a built-in breakpoint by setting the [MediaQuery](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MediaBreakpoint.html#Syncfusion_Blazor_MediaBreakpoint_MediaQuery) property of the corresponding [MediaBreakpoint](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MediaBreakpoint.html) on `SfMediaQuery` (for example, `SfMediaQuery.Small`, `SfMediaQuery.Medium`, and `SfMediaQuery.Large`).

```cshtml

@using Syncfusion.Blazor

<SfMediaQuery @bind-ActiveBreakpoint="@activeBreakpoint"></SfMediaQuery>

<h3>The active breakpoint is @activeBreakpoint</h3>

@code {
    private string activeBreakpoint;

    protected override void OnInitialized()
    {
        SfMediaQuery.Small.MediaQuery = "(max-width: 500px)";
        SfMediaQuery.Medium.MediaQuery = "(min-width: 500px)";
        SfMediaQuery.Large.MediaQuery = "(min-width: 1600px)";
        base.OnInitialized();
    }
}

```

## Custom media breakpoints

The Blazor Media Query component allows you to define custom media breakpoints by setting the [MediaBreakpoints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfMediaQuery.html#Syncfusion_Blazor_SfMediaQuery_MediaBreakpoints) property to a list of [MediaBreakpoint](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MediaBreakpoint.html) instances. Each `MediaBreakpoint` defines a `Breakpoint` label (the value reported through `ActiveBreakPoint` when matched) and a `MediaQuery` string. Make sure the custom ranges do not overlap so that exactly one breakpoint is active at any time.

```cshtml

@using Syncfusion.Blazor

<SfMediaQuery MediaBreakpoints="@mediaBreakPoint" @bind-ActiveBreakpoint="@activeBreakpoint"></SfMediaQuery>

<h3>The active breakpoint is @activeBreakpoint</h3>

@code {
    private string activeBreakpoint;
    private List<MediaBreakpoint> mediaBreakPoint = new List<MediaBreakpoint>();
    protected override void OnInitialized()
    {
        mediaBreakPoint = new List<MediaBreakpoint>() 
        {
            new MediaBreakpoint() { Breakpoint = "Mobile", MediaQuery = "(max-width: 600px)" },
            new MediaBreakpoint() { Breakpoint = "Tablet", MediaQuery = "(min-width: 600px) and (max-width: 999px)" },
            new MediaBreakpoint() { Breakpoint = "Laptop", MediaQuery = "(min-width: 1000px) and (max-width: 1199px)" },
            new MediaBreakpoint() { Breakpoint = "Desktop", MediaQuery = "(min-width: 1200px)" }
        };
        base.OnInitialized();
    }
}

```
