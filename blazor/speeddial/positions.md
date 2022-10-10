---
layout: post
title: Position with Blazor SpeedDial Component | Syncfusion
description: Checkout and learn about Position with Blazor SpeedDial component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: SpeedDial
documentation: ug
---

# Positions

## OpensOnHover

[OpensOnHover]() property indicates whether to open the popup when the button of SpeedDial is hovered. By default, SpeedDial opens popup on click action. By default the OpensOnHover is false. Opens popup on mouse hover action is achieved by [OpensOnHover]() property when the value is true.

```cshtml

@using Syncfusion.Blazor.Buttons

<div id="target" style="height:200px; position:relative; width:300px; border:1px solid;">
    <SfSpeedDial Target="#target" Position="FabPosition.BottomLeft" OpensOnHover=true OpenIconCss="e-icons e-edit" CloseIconCss="e-icons e-close">
        <SpeedDialItems>
            <SpeedDialItem IconCss="e-icons e-cut"/>
            <SpeedDialItem IconCss="e-icons e-copy"/>
            <SpeedDialItem IconCss="e-icons e-paste"/>
        </SpeedDialItems>
    </SfSpeedDial>
</div>

```

