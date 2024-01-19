---
layout: post
title: Getting Started with Blazor Playground | Syncfusion
description: Explore real-time Blazor component development with Syncfusion Blazor Playground. Write, edit, compile, and share effortlessly in your browser!
platform: Blazor
component: Common
documentation: ug
---

Syncfusion provides an option to render a blazor components using [Blazor Playground](https://blazorplayground.syncfusion.com/). Playground offers a platform where developers can write, visualize, and experiment with Blazor components using C# and Razor syntax. The code compilation utilizes WebAssembly technology which gives a performance that closely resembles native execution.

# Getting Started with Blazor playground

This section briefly explains about how to use the blazor playground.
1. Open the [Blazor Playground](https://blazorplayground.syncfusion.com/) in your browser. 
2. Use the code editor to create your desired  .razor format code. 
3. Once you are done writing your code, press the run button or <kbd>Ctrl</kbd>+<kbd>R</kbd> to execute the code. The output of the executed code will appear in the result view.

# Blazor Component

You can create a blazor component in blazor playground by following the given steps below:

1. Add the code in __Index.razor,

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
2. Press the run button or <kbd>Ctrl</kbd>+<kbd>R</kbd> to execute the code. The output of the executed code will appear in the result view.

![blazor_component](images/blazor_component.png)

# Syncfusion Blazor component

To render syncfusion components in blazor playground follow the steps given below:

1. Import the Syncfusion.Blazor and Syncfusion.Blazor.Calendars namespace.


```cshtml

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Calendars

```

N>Since the latest `Syncfusion.Blazor` package is readily available in the Blazor playground, external installation is unnecessary. All necessary theme assets, including the stylesheet and scripts, are linked with the application.

2. Add the Syncfusion Calendar component in the code editor.

```cshtml

<SfCalendar TValue="DateTime"></SfCalendar>

```

Press the run button or <kbd>Ctrl</kbd>+<kbd>R</kbd> to execute the code. The output of the executed code will appear in the result view.

![syncfusion_component](images/syncfusion_component.png)
