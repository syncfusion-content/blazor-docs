---
layout: post
title: How to set the disabled state of Blazor Split Button | Syncfusion
description: Disable the Blazor Split Button by setting the Disabled property to true, preventing user interaction with the whole component.
platform: Blazor
control: Split Button
documentation: ug
---

# How to set the disabled state of Blazor Split Button

Use the [Disabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfSplitButton.html#Syncfusion_Blazor_SplitButtons_SfSplitButton_Disabled) property to disable the Blazor Split Button. When set to `true`.

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

![Blazor Split Button in Disabled State](./../images/blazor-splitbutton-disabled-state.webp)