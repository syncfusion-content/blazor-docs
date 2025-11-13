---
layout: post
title: Position in Blazor SpeedDial Component | Syncfusion
description: Checkout and learn here all about different built in positions in Blazor SpeedDial component and much more.
platform: Blazor
control: SpeedDial
documentation: ug
---

# Positions in Blazor Speed Dial Component

The SpeedDial component can be positioned anywhere within the specified [Target](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_Target) using the [Position](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_Position) property. If no `Target` is defined, the SpeedDial is positioned relative to the browser viewport.

The available position values for the SpeedDial are:
* TopLeft
* TopCenter
* TopRight
* MiddleLeft
* MiddleCenter
* MiddleRight
* BottomLeft
* BottomCenter
* BottomRight

```cshtml

@using Syncfusion.Blazor.Buttons

<SfSpeedDial Content="Add" Position="FabPosition.BottomLeft">
    <SpeedDialItems>
        <SpeedDialItem Text="Cut"/>
        <SpeedDialItem Text="Copy"/>
        <SpeedDialItem Text="Paste"/>
    </SpeedDialItems>
</SfSpeedDial>

```

![Blazor Speed Dial Position](./images/Blazor-SpeedDial-Position.png)

## Opens on hover

Open the SpeedDial action items on mouse hover by setting the [OpensOnHover](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_OpensOnHover) property to `true`.

```cshtml

@using Syncfusion.Blazor.Buttons

<SfSpeedDial OpensOnHover=true OpenIconCss="e-icons e-edit" CloseIconCss="e-icons e-close">
    <SpeedDialItems>
        <SpeedDialItem IconCss="e-icons e-cut"/>
        <SpeedDialItem IconCss="e-icons e-copy"/>
        <SpeedDialItem IconCss="e-icons e-paste"/>
    </SpeedDialItems>
</SfSpeedDial>

```

![Blazor Speed Dial OpensOnHover](./images/Blazor-SpeedDial-Icon.png)

## Programmatically show/hide

Open or close the SpeedDial action items programmatically using the [ShowAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_ShowAsync) and [HideAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_HideAsync) methods. These are asynchronous methods and should be awaited when invoked in an async context.

Below example demonstrates open/close action items on button click.

```cshtml

@using Syncfusion.Blazor.Buttons

<div id="target" style="height:200px; position:relative; width:300px; border:1px solid;">
    <SfButton OnClick="Show">Show</SfButton>
    <SfButton style="float:right"  OnClick="Hide">Hide</SfButton>
    <SfSpeedDial @ref="speeddial" Target="#target" Position="FabPosition.BottomCenter" OpenIconCss="e-icons e-edit" CloseIconCss="e-icons e-close">
        <SpeedDialItems>
            <SpeedDialItem IconCss="e-icons e-cut"/>
            <SpeedDialItem IconCss="e-icons e-copy"/>
            <SpeedDialItem IconCss="e-icons e-paste"/>
        </SpeedDialItems>
    </SfSpeedDial>
</div>

@code{
    SfSpeedDial speeddial;
    public void Show()
    {
        speeddial.ShowAsync();
    }
    public void Hide()
    {
        speeddial.HideAsync();
    }
}

```

![Blazor Speed Dial Show Items](./images/Blazor-SpeedDial-ShowItem.png)
![Blazor Speed Dial Hide Items](./images/Blazor-SpeedDial-HideItem.png)

## Programmatically refresh the position

Refresh the position of the SpeedDial using the [RefreshPositionAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_RefreshPositionAsync) method when the `Target` position changes. This asynchronous method should be awaited in an async context.

```cshtml

@using Syncfusion.Blazor.Buttons

<div id="target" style="min-height:350px; position:relative; border:1px solid;">
    <SfButton OnClick="RefreshPosition">Refresh</SfButton>
    <SfSpeedDial @ref="speeddial" Target="#target" Position="FabPosition.MiddleRight" OpenIconCss="e-icons e-edit" CloseIconCss="e-icons e-close">
        <SpeedDialItems>
            <SpeedDialItem IconCss="e-icons e-cut"/>
            <SpeedDialItem IconCss="e-icons e-copy"/>
            <SpeedDialItem IconCss="e-icons e-paste"/>
        </SpeedDialItems>
    </SfSpeedDial>
</div>

@code{
    SfSpeedDial speeddial;

    public void RefreshPosition()   
    {
        speeddial.RefreshPositionAsync();
    }
}

```