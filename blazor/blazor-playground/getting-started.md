---
layout: post
title: Getting Started with Blazor Playground | Syncfusion
description: Explore real-time Blazor component development with Syncfusion Blazor Playground. Write, edit, compile, and share effortlessly in your browser!
platform: Blazor
component: Common
documentation: ug
---

Syncfusion provides [Blazor Playground](https://blazorplayground.syncfusion.com/) that helps to write, visualize, and experiment with Blazor components using C# and Razor syntax. The code compilation utilizes WebAssembly which gives a performance that closely resembles native execution.

# Getting Started with Blazor playground

The Blazor playground allows you to develop and test any Blazor component, including both general components and pre-built Syncfusion Blazor components.

## Blazor Component

You can create a Blazor component in Blazor playground by following the given steps below:

1. Open the [Blazor Playground](https://blazorplayground.syncfusion.com/) URL in your browser. 
2. Add the code in __Index.razor,

```cshtml
<!-- ColorPicker.razor -->

@page "/colorpicker"

<h3>Color Picker</h3>

<div class="color-palette">
    @foreach (var color in ColorPalette)
    {
        <div class="color" style="background-color: @color" @onclick="() => SelectColor(color)"></div>
    }
</div>

<p>Selected Color: @selectedColor</p>

@code {
    private List<string> ColorPalette = new List<string>
    {
        "#ff0000", "#00ff00", "#0000ff", "#ffff00", "#ff00ff", "#00ffff"
    };

    private string selectedColor = "#ff0000";

    private void SelectColor(string color)
    {
        selectedColor = color;
    }
}
<style>

    .color-palette {
        display: flex;
        flex-wrap: wrap;
    }

    .color {
        width: 50px;
        height: 50px;
        margin: 5px;
        cursor: pointer;
        border: 2px solid #fff;
    }

    .color:hover {
        border: 2px solid #000;
    }
    
</style>
```
3. Press the `run` button or <kbd>Ctrl</kbd>+<kbd>R</kbd> to execute the code. The output of the executed code will appear in the result view.

![Syncfusion Blazor Playground](images/blazor_component.png)

## Syncfusion Blazor component

As Syncfusion Blazor playground comes pre-configured with `Syncfusion.Blazor` package, stylesheet, script, and namespace are included with the application. To render Syncfusion components in Blazor playground, follow the steps given below:

1. Import the Syncfusion.Blazor and Syncfusion.Blazor.Calendars namespace on top of the code editor.


```cshtml

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Calendars

```

2. Add the Blazor Calendar component in the code editor.

```cshtml

<SfCalendar TValue="DateTime"></SfCalendar>

```

3. Press the `run` button or <kbd>Ctrl</kbd>+<kbd>R</kbd> to execute the code. The output of the executed code will appear in the result view.

![Syncfusion Blazor Playground with Calendar component](images/syncfusion_component.png)