---
layout: post
title: Customize the Spinner in Blazor Spinner Component | Syncfusion
description: Check out and learn how to customize the Spinner in the Syncfusion Blazor Spinner component, including appearance, label, type, size, and dynamic updates.
platform: Blazor
control: Spinner
documentation: ug
---

# Customize the Spinner in Blazor Spinner Component

The Spinner component can be customized during initialization or after it is rendered.

## Customize when initializing the Spinner component

Change the default Spinner appearance at initialization using the following properties:

* CssClass
* Label
* Type
* Size

### CssClass

Add a custom class name to the Spinner root element to modify the UI styles. The following example shows how to initialize a Spinner with a custom class in a Blazor Razor page.

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

![Blazor Spinner with Custom Class](./images/blazor-spinner-custom-class.png)

#### Modal Spinner

Create a modal (overlay) spinner by adding the `e-spin-overlay` class to the `CssClass` property.

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

![Blazor Modal Spinner](./images/blazor-modal-spinner.png)

### Label

Display a custom label text below the Spinner by setting the `Label` property.

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

![Blazor Spinner with Label](./images/blazor-spinner-with-label.png)

### Type

By default, `Type` is `None`, which renders a theme-based Spinner. Customize the visual style explicitly by setting the `Type` property. Available types:

* None
* Material
* Fabric
* Bootstrap
* HighContrast
* Bootstrap4

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

![Blazor Bootstrap Spinner](./images/blazor-bootstrap-spinner.png)

### Size

The default Spinner size is `30px`. Change the size using the `Size` property.

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

![Changing Blazor Spinner Width](./images/blazor-spinner-width.png)

## Customize after creating the Spinner component

Customize the Spinner dynamically after initialization using the following properties:

* Type
* CssClass

### Type

Change the Spinner type dynamically by updating the `Type` property.

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
    }
}

```

![Blazor Material Spinner](./images/blazor-material-spinner.png)

### CssClass

Add or change a custom class on the Spinner after it is rendered by updating the `CssClass` property.

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

![Blazor Spinner with Custom Class](./images/blazor-spinner-with-custom-class.png)