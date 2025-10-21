---
layout: post
title: Set the disabled state in Blazor SplitButton Component | Syncfusion
description: Checkout and learn here all about how to set the disabled state in Syncfusion Blazor SplitButton component and more.
platform: Blazor
control: Split Button
documentation: ug
---

# Set the disabled state in Blazor SplitButton Component

Use the [Disabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfSplitButton.html#Syncfusion_Blazor_SplitButtons_SfSplitButton_Disabled) property to disable the SplitButton. When set to `true`.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfSplitButton Content="Paste" Disabled="true">
    <DropDownMenuItems>
        <DropDownMenuItem Text="Cut" ></DropDownMenuItem>
        <DropDownMenuItem Text="Copy" ></DropDownMenuItem>
        <DropDownMenuItem Text="Paste"></DropDownMenuItem>
    </DropDownMenuItems>
</SfSplitButton>
  
```

![Blazor SplitButton in Disabled State](./../images/blazor-splitbutton-disabled-state.png)