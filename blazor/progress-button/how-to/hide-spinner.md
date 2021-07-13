---
layout: post
title: How to Hide Spinner in Blazor Progress Button Component | Syncfusion
description: Checkout and learn about Hide Spinner in Blazor Progress Button component of Syncfusion, and more details.
platform: Blazor
control: Progress Button
documentation: ug
---

# Hide spinner

You can hide spinner in the Progress Button by setting the `e-hide-spinner` property to [`CssClass`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfProgressButton.html#Syncfusion_Blazor_SplitButtons_SfProgressButton_CssClass).

```csharp
@using Syncfusion.Blazor.SplitButtons

<SfProgressButton EnableProgress="true" CssClass="e-hide-spinner" Content="Progress"></SfProgressButton>

```

Output be like

![Progress Button Sample](./../images/pb-hide.png)