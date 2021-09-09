---
layout: post
title: Component Size Modes in Blazor - Syncfusion
description: Check out and learn here all about component size mode for Syncfusion Blazor Components and much more. 
platform: Blazor
component: Appearance
documentation: ug
---

# Size Mode for Blazor Components

Syncfusion blazor components supports touch (bigger theme) and normal size modes. Below topics explains how to enable the same in your application.

## Size mode for application

You can enable touch mode (bigger theme) for an application by adding `.e-bigger` class in `~/wwwroot/css/site.css` file.

```css
.e-bigger {
    font-size: x-large;
}
```

## Size mode for a control

You can enable touch mode (bigger theme) for a control by adding `.e-bigger` class and assign to the `div` which contains the control. 

```cshtml

@page "/"

@using Syncfusion.Blazor.Calendars;
@using Syncfusion.Blazor.Buttons;
@using Syncfusion.Blazor.Popups;

<div class="e-bigger">
    <SfCalendar TValue="DateTime?" Value="@DateValue"></SfCalendar>
</div>

<div class="e-bigger">
    <SfButton> Button </SfButton>
</div>

<div class="e-bigger">
    <SfCheckBox Label="checked" @bind-Checked="isChecked"></SfCheckBox>
</div>

<style>
    .e-bigger {
        font-size: x-large;
    }
</style>

@code {
    private bool isChecked = true;
    public DateTime? DateValue { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 28);
}
```

## Change size mode for application at runtime

You can change the size mode of an application between touch and normal (mouse) mode at runtime by adding and removing `.e-bigger` using `JavaScriptInterop`. 

Follow below steps to change the size mode for an application at runtime.

1. Add the `e-bigger` CSS class in the `~/wwwroot/css/site.css` file.

    ```css
    .e-bigger {
        font-size: x-large;
    }
    ```

2. Add the following JavaScript methods inside the script tag of `wwwroot/index.html` (Blazor WebAssembly App) or `Pages/_Host.cshtml` (Blazor Server App) to switch between touch and mouse mode using `e-bigger` class.

    ```cshtml
    <script>
        function onTouch() {
            document.body.classList.add('e-bigger');
        }
        
        function onMouse() {
            document.body.classList.remove('e-bigger');
        }
     </script>
    ```

2. To call JavaScript method from .NET, inject the `IJSRuntime` abstraction and call `InvokeAsync` method as given in the below code,
    
    ```cshtml
    @page "/"
    
    @using Syncfusion.Blazor.Calendars;
    @using Syncfusion.Blazor.Buttons;
    @using Syncfusion.Blazor.Popups
    @inject IJSRuntime jsRuntime;
    
    <p> Size-modes for application </p>
    <p> This demo shows the Size-Modes applied for an entire application </p>
    
    <button @onclick="callOnTouch">Touch Mode</button>
    <button @onclick="callOnMouse">Mouse Mode</button>
    <div>
        <SfCalendar TValue="DateTime?" Value="@DateValue"></SfCalendar>
    </div>
    
    <div>
        <SfButton> Button </SfButton>
    </div>
    
    <div>
        <SfCheckBox Label="checked" @bind-Checked="isChecked"></SfCheckBox>
     </div>
    
    @code {
        private bool isChecked = true;
        private async void callOnTouch(MouseEventArgs args)
        {
           await jsRuntime.InvokeAsync<string>("onTouch");
        }
        private async void callOnMouse(MouseEventArgs args)
        {
            await jsRuntime.InvokeAsync<string>("onMouse");
        }
    }
    ```
    
    ![change-size-mode-for-application-at-runtime](images/change-size-mode-for-application-at-runtime.gif)
    
    > [View sample in GitHub](https://github.com/SyncfusionExamples/size-mode-in-blazor-application)

## Change size mode for a control at runtime

You can change the size mode of a control between touch and normal (mouse) mode at runtime by setting `.e-bigger` CSS class.  

Refer to the following code, in which the `e-bigger` class is added for enabling touch mode using the `check` variable.

```cshtml

@page "/"

@using Syncfusion.Blazor.Calendars;
@using Syncfusion.Blazor.Buttons;
@using Syncfusion.Blazor.Popups;

<h2>Syncfusion Component Size-Modes</h2>

<button @onclick="OnTouch">Touch Mode</button> 
<button @onclick="OnMouse">Mouse Mode</button>

<div class="@touchCSS">
    <SfCalendar TValue="DateTime?" Value="@DateValue"></SfCalendar>
</div>

<div class="@touchCSS">
    <SfButton> Button </SfButton>
</div>

<div class="@touchCSS">
    <SfCheckBox Label="checked" @bind-Checked="isChecked"></SfCheckBox>
</div>

<style>
    .e-bigger {
        font-size: x-large;
    }
</style>

@code {
    private bool isChecked = true;

    public DateTime? DateValue { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 28);

    public string touchCSS { get; set; }

    public void OnTouch()
    {
        touchCSS = "e-bigger";
    }

    public void OnMouse()
    {
        touchCSS = "";
    }
}
```

![change-size-mode-for-a-control-at-runtime](images/change-size-mode-for-a-control-at-runtime.gif)

> [View sample in GitHub](https://github.com/SyncfusionExamples/size-mode-in-blazor-application)


## See Also

Refer below topics to learn about responsiveness components based on available size in Syncfusion Blazor Components.

* [Sidebar Responsiveness](https://blazor.syncfusion.com/documentation/sidebar/auto-close)
* [DataGrid Responsiveness](https://blazor.syncfusion.com/documentation/datagrid/columns#responsive-columns)
* [TreeGrid Responsiveness](https://blazor.syncfusion.com/documentation/treegrid/scrolling#responsive-with-parent-container)
* [Dashboard Layout Responsiveness](https://blazor.syncfusion.com/documentation/dashboard-layout/responsive-adaptive)
* [Kanban Responsiveness](https://blazor.syncfusion.com/documentation/kanban/responsive-mode)
* [Toolbar Responsiveness](https://blazor.syncfusion.com/documentation/toolbar/responsive-mode)
* [Tab Responsiveness](https://blazor.syncfusion.com/documentation/tabs/responsive-modes)
