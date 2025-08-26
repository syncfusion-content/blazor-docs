---
layout: post
title: Events in Blazor Colorpicker Component | Syncfusion
description: Checkout and learn here all about Events in Syncfusion Blazor Colorpicker component and much more details.
platform: Blazor
control: Colorpicker
documentation: ug
---

# Events in Blazor ColorPicker Component

This section explains the list of events of the Colorpicker component which will be triggered for appropriate Colorpicker actions.

## Closed

`Closed` Gets or sets an event callback that is raised when the SfColorPicker popup is Closed.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfColorPicker PopupClosed="@OnPopupClosed"></SfColorPicker>

@code
{
    private void OnPopupClosed()
    {
         // Write your code here. 
    }
}
```