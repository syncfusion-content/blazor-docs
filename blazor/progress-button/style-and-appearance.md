---
layout: post
title: Styles and Appearances in Blazor ProgressButton Component | Syncfusion
description: Checkout and learn here all about Styles and Appearances in Syncfusion Blazor ProgressButton component and more.
platform: Blazor
control: Progress Button
documentation: ug
---

# Styles and Appearances in Blazor ProgressButton Component

Customize the appearance of the ProgressButton by overriding the built-in CSS selectors of the component. Use scoped styles (for example, by adding a custom class via the CssClass parameter) to limit changes to specific instances. To create a consistent look-and-feel across the application, consider using built-in themes or generating a custom theme with the [Theme Studio](https://blazor.syncfusion.com/themestudio/?theme=material).

| CSS Class | Purpose of Class |
| ----- | ----- |
| .e-progress-btn | Customize the ProgressButton root element. |
| .e-progress-btn:hover | Customize the ProgressButton on hover. |
| .e-progress-btn:focus | Customize the ProgressButton when focused (keyboard or programmatic focus). |
| .e-progress-btn .e-spinner-pane .e-spinner-inner svg .e-path-circle | Customize the spinner visuals within the ProgressButton. |


## Change text content and styles of the Blazor ProgressButton

Change the button text and styles during the progress state by updating the Content and the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfProgressButton.html#Syncfusion_Blazor_SplitButtons_SfProgressButton_CssClass) parameters in the [OnBegin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.ProgressButtonEvents.html#Syncfusion_Blazor_SplitButtons_ProgressButtonEvents_OnBegin) and [OnEnd](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.ProgressButtonEvents.html#Syncfusion_Blazor_SplitButtons_ProgressButtonEvents_OnEnd) event handlers.

```cshtml

@using Syncfusion.Blazor.SplitButtons

<SfProgressButton Content="@Content" EnableProgress="true" CssClass="@CssClass" Duration="4000">
    <ProgressButtonEvents OnBegin="Begin" OnEnd="End"></ProgressButtonEvents>
</SfProgressButton>

@code {
    public string Content = "Upload";
    public string CssClass = "e-hide-spinner";
    public void Begin(Syncfusion.Blazor.SplitButtons.ProgressEventArgs args)
    {
        Content = "Uploading...";
        CssClass = "e-hide-spinner e-info";
    }
    public async Task End(Syncfusion.Blazor.SplitButtons.ProgressEventArgs args)
    {
        Content = "Success";
        CssClass = "e-hide-spinner e-success";
        await Task.Delay(1000);
        Content = "Upload";
        CssClass = "e-hide-spinner";
    }
}

```

![Changing Text Content and Style of Blazor ProgressButton](./images/blazor-progressbutton-change-text.webp)

## Customize progress using cssClass in Blazor ProgressButton

Customize the progress indicator (filler) by using the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfProgressButton.html#Syncfusion_Blazor_SplitButtons_SfProgressButton_CssClass) property.

* Adding `e-vertical` to `CssClass` displays vertical progress.
* Adding `e-progress-top` to `CssClass` places the progress at the top of the button.

Reverse progress can also be shown by adding a custom class through the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfProgressButton.html#Syncfusion_Blazor_SplitButtons_SfProgressButton_CssClass) property.

```cshtml

@using Syncfusion.Blazor.SplitButtons

<SfProgressButton EnableProgress="true" CssClass="e-hide-spinner e-vertical" Duration="4000" Content="Vertical Progress"></SfProgressButton>
<SfProgressButton EnableProgress="true" CssClass="e-hide-spinner e-progress-top" Duration="4000" Content="Progress Top"></SfProgressButton>
<SfProgressButton EnableProgress="true" CssClass="e-hide-spinner e-reverse-progress" Duration="4000" Content="Reverse Progress"></SfProgressButton>

<style>
    .e-reverse-progress .e-progress {
        right: 0;
        left: auto;
    }
</style>

```

![Customizing Progress in Blazor ProgressButton](./images/blazor-progressbutton-customization.webp)


## Stop Progress Indicator in Blazor ProgressButton

Stop the active progress programmatically by calling the [EndProgressAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfProgressButton.html#Syncfusion_Blazor_SplitButtons_SfProgressButton_EndProgressAsync) method on the ProgressButton instance obtained via @ref. In the following example, clicking the Stop button invokes the handler that awaits EndProgressAsync to halt the current progress.

```cshtml
@using Syncfusion.Blazor.SplitButtons
@using Syncfusion.Blazor.Buttons

<SfProgressButton Content="Spin Left" IsPrimary="true" @ref="ProgressBtnObj"></SfProgressButton>
<SfButton Content="Stop" OnClick="clicked"></SfButton>

@code {
    SfProgressButton ProgressBtnObj;
    private async Task clicked()
    {
      await ProgressBtnObj.EndProgressAsync();
    }
}
```

![Stop Progress Indicator in ProgressButton](./images/blazor-progressbutton-stop-indicator.webp)

## Hide Spinner in Blazor ProgressButton

Hide the spinner in the ProgressButton by applying the built-in e-hide-spinner CSS class to the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfProgressButton.html#Syncfusion_Blazor_SplitButtons_SfProgressButton_CssClass) parameter. This hides only the spinner while keeping the progress fill visible. Multiple CSS classes can be combined in CssClass as needed.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfProgressButton EnableProgress="true" CssClass="e-hide-spinner" Content="Progress"></SfProgressButton>

```

![Hide Spinner in Blazor ProgressButton](./images/blazor-progressbutton-hide-spinner.webp)