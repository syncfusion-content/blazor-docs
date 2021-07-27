---
layout: post
title: Set the disabled state in Blazor SplitButton Component | Syncfusion
description: Learn here all about Set the disabled state in Syncfusion Blazor SplitButton component and more.
platform: Blazor
control: Split Button
documentation: ug
---

# Set the disabled state in Blazor SplitButton Component

Split Button component can be enabled or disabled by disabled property. To disable Split Button component, set the [`Disabled`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfSplitButton.html#Syncfusion_Blazor_SplitButtons_SfSplitButton_Disabled) property as true.

The following example illustrates how to set the disable state in Split Button component.

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

Output be like

![Split Button Sample](./../images/sb-disabled.png)