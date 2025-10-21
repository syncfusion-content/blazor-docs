---
layout: post
title: Hide Spinner in Blazor ProgressButton Component | Syncfusion
description: Checkout and learn here all about how to hide spinner in Syncfusion Blazor ProgressButton component and more.
platform: Blazor
control: Progress Button
documentation: ug
---

# Hide Spinner in Blazor ProgressButton Component

Hide the spinner in the ProgressButton by applying the built-in e-hide-spinner CSS class to the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfProgressButton.html#Syncfusion_Blazor_SplitButtons_SfProgressButton_CssClass) parameter. This hides only the spinner while keeping the progress fill visible. Multiple CSS classes can be combined in CssClass as needed.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfProgressButton EnableProgress="true" CssClass="e-hide-spinner" Content="Progress"></SfProgressButton>

```

![Hide Spinner in Blazor ProgressButton](./../images/blazor-progressbutton-hide-spinner.png)