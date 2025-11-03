---
layout: post
title: Breakpoints in Blazor Media Query Component | Syncfusion
description: Checkout and learn here all about Breakpoints in Syncfusion Blazor Media Query component and much more details.
platform: Blazor
control: Media Query
documentation: ug
---

# Breakpoints in Blazor Media Query Component

The Blazor Media Query breakpoints are used to create responsive and adaptive layouts for your web applications by referring to specific points in a device's screen size where the layout and styling of the web application need to be adjusted for the best user experience. 

## Built-in breakpoints

You can customize the appearance of the applications based on screen size by using the built-in breakpoints. The [ActiveBreakpoint](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfMediaQuery.html#Syncfusion_Blazor_SfMediaQuery_ActiveBreakpoint) gives the breakpoint that is currently matching the media query.

The built-in breakpoint values of Media Query component are as follows:

* Small - browser width <= 768 pixels
* Medium - browser width between 768 and 1024 pixels
* Large - browser width >= 1024 pixels

### Modifying built-in breakpoints

You can modify the query for built-in breakpoints by using the [MediaQuery](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MediaBreakpoint.html#Syncfusion_Blazor_MediaBreakpoint_MediaQuery) property of the [MediaBreakpoint](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MediaBreakpoint.html) in `SfMediaQuery`.

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

The Blazor Media Query component allows you to define custom media breakpoints by using the [MediaBreakpoints](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfMediaQuery.html#Syncfusion_Blazor_SfMediaQuery_MediaBreakpoints) property to customize the appearance of the web application depending on your unique needs.

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
