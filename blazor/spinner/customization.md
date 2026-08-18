---
layout: post
title: Customization in Blazor Spinner | Syncfusion
description: Customize Blazor Spinner label, type, size, and color using CssClass, Label, Type, and spinner CSS variables.
platform: Blazor
control: Spinner
documentation: ug
---

# Customization in Blazor Spinner

The Blazor Spinner component can be customized when initializing it or after it is rendered.

## Customize when initializing the Spinner component

Provided support to change the default Spinner appearance when initializing Spinner component using the following properties.

* [CssClass](#cssclass)
* [Label](#label)
* [Type](#type)
* [Size](#size)

### CssClass

Add a customized CSS class name to the Spinner root element to customize the Blazor Spinner component's UI styles. The following example shows how to initialize a Spinner with a custom class name in a Blazor Razor page.

```cshtml

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Spinner

<div>
    <SfButton @onclick="@ClickHandler">Show/Hide Spinner</SfButton>

    <div id="container">
        <SfSpinner @bind-Visible="@VisibleProperty" CssClass="e-customClass">
        </SfSpinner>
    </div>
</div>


@code{
    private bool VisibleProperty { get; set; } = false;

    private async Task ClickHandler()
    {
        this.VisibleProperty = true;
        await Task.Delay(2000);
        this.VisibleProperty = false;
    }
}

<style>
    .e-spinner-pane.e-customClass .e-spinner-inner .e-spin-material {
        stroke: #808080;
    }
</style>

```

![Blazor Spinner with Custom Class](./images/blazor-spinner-custom-class.webp)

#### Modal Spinner

A modal spinner can be initialized by adding the class `e-spin-overlay` to the `CssClass` property of the spinner.

```cshtml

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Spinner

<SfButton @onclick="@ClickHandler">Show/Hide Spinner</SfButton>

<div id="container">
    <SfSpinner @bind-Visible="@VisibleProperty" CssClass="e-spin-overlay" />
</div>

<style>
    #container {
        position: relative;
        height: 550px;
    }
</style>

@code{
    private bool VisibleProperty { get; set; } = false;

    private async Task ClickHandler()
    {
        this.VisibleProperty = true;
        await Task.Delay(10000);
        this.VisibleProperty = false;
    }
}

```

![Blazor Modal Spinner](./images/blazor-modal-spinner.webp)

### Label

Add a customized label text at the bottom of the Blazor Spinner component. The label is rendered beneath the spinner indicator.

The following example shows how to set the `Label` on the Spinner in a Blazor Razor page.

```cshtml

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Spinner

<div>
    <SfButton @onclick="@ClickHandler">Show/Hide Spinner</SfButton>

    <div id="container">
        <SfSpinner @bind-Visible="@VisibleProperty" Label="Loading....">
        </SfSpinner>
    </div>
</div>

@code{
    private bool VisibleProperty { get; set; } = false;

    private async Task ClickHandler()
    {
        this.VisibleProperty = true;
        await Task.Delay(2000);
        this.VisibleProperty = false;
    }
}

```

![Blazor Spinner with Label](./images/blazor-spinner-with-label.webp)

### Type

By default, the `Type` is `None` where the Blazor Spinner is loaded based on the theme used in the application. The type can also be customized and shown on Spinner using the `Type` property. The available types are:

* None
* Material
* Fabric
* Bootstrap
* HighContrast
* Bootstrap4

The following example shows how to use the `Type` property when initializing the Spinner in a Blazor Razor page.

```cshtml

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Spinner

<div>
    <SfButton @onclick="@ClickHandler">Show/Hide Spinner</SfButton>

    <div id="container">
        <SfSpinner @bind-Visible="@VisibleProperty" Type="@SpinnerType.Bootstrap">
        </SfSpinner>
    </div>
</div>

@code{
    private bool VisibleProperty { get; set; } = false;

    private async Task ClickHandler()
    {
        this.VisibleProperty = true;
        await Task.Delay(2000);
        this.VisibleProperty = false;
    }
}

```

![Blazor Bootstrap Spinner](./images/blazor-bootstrap-spinner.webp)

### Size

By default, the Spinner size is `30px`. The size of the Spinner can be changed based on the application using the `Size` property.

The following example shows how to use the `Size` property when initializing the Spinner in a Blazor Razor page.

```cshtml

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Spinner

<div>
    <SfButton @onclick="@ClickHandler">Show/Hide Spinner</SfButton>

    <div id="container">
        <SfSpinner @bind-Visible="@VisibleProperty" Size="50">
        </SfSpinner>
    </div>
</div>

@code{
    private bool VisibleProperty { get; set; } = false;

    private async Task ClickHandler()
    {
        this.VisibleProperty = true;
        await Task.Delay(2000);
        this.VisibleProperty = false;
    }
}

```

![Changing Blazor Spinner Width](./images/blazor-spinner-width.webp)

## Customize after creating the Spinner component

The Spinner component can be customized dynamically after it has been initialized by using the following properties:

* Type
* CssClass

### Type

The type of the Spinner can be changed dynamically using the `Type` property.

The following example shows how to use the `Type` property after creating the Spinner in a Blazor Razor page.

```cshtml

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Spinner

<div>
    <SfButton @onclick="@ClickHandler">Show/Hide Spinner</SfButton>
    <SfButton @onclick="@ChangeType">Change Type</SfButton>

    <div id="container">
        <SfSpinner @bind-Visible="@VisibleProperty" Type="@SpinnerType">
        </SfSpinner>
    </div>
</div>

@code{
    private SpinnerType SpinnerType = SpinnerType.Fabric;
    private bool VisibleProperty { get; set; } = false;

    private async Task ClickHandler()
    {
        this.VisibleProperty = true;
        await Task.Delay(2000);
        this.VisibleProperty = false;
    }

    private async Task ChangeType()
    {
        SpinnerType = SpinnerType.Material;
        await Task.Delay(100);
        StateHasChanged();
    }
}

```

![Blazor Material Spinner](./images/blazor-material-spinner.webp)

### CssClass

Add a custom CSS class name to the Spinner after the component is created.

The following example shows how to dynamically set the `CssClass` property after creating the Spinner in a Blazor Razor page.

```cshtml

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Spinner

<div>
    <SfButton @onclick="@ClickHandler">Show/Hide Spinner</SfButton>
    <SfButton @onclick="@ChangeClass">Change CSS Class</SfButton>

    <div id="container">
        <SfSpinner @bind-Visible="@VisibleProperty" CssClass="@CssClassName">
        </SfSpinner>
    </div>
</div>

@code{
    private string CssClassName { get; set; } = "";
    private bool VisibleProperty { get; set; } = false;

    private async Task ClickHandler()
    {
        this.VisibleProperty = true;
        await Task.Delay(2000);
        this.VisibleProperty = false;
    }

    private async Task ChangeClass()
    {
        this.CssClassName = "e-customClass";
        StateHasChanged();
    }
}

<style>
    .e-spinner-pane.e-customClass .e-spinner-inner .e-spin-material {
        stroke: #808080;
    }
</style>

```

![Blazor Spinner with Custom Class](./images/blazor-spinner-with-custom-class.webp)