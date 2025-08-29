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

`Closed` event triggers after the popup has been closed.

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

## Opened

`Opened` event triggers when the popup Open.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfColorPicker Opened="@Opened"></SfColorPicker>

@code
{
    private void Opened(OpenEventArgs args)
    {
         // Write your code here. 
    }
}
```

## OnClose

`OnClose` event triggers before the popup closed.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfColorPicker OnClose="@OnCloseHandler"></SfColorPicker>

@code
{
    private void OnCloseHandler(BeforeOpenCloseEventArgs args)
    {
         // Write your code here. 
    }
}
```

## OnOpen

`OnOpen` event triggers when the popup is Opened.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfColorPicker OnOpen="@OnOpenHandler"></SfColorPicker>

@code
{
    private void OnOpenHandler(BeforeOpenCloseEventArgs args)
    {
         // Write your code here. 
    }
}
```

## ValueChange

`ValueChange` event triggers when changing the colors.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfColorPicker ValueChange="@ValueChangeHandler"></SfColorPicker>

@code
{
    private void ValueChangeHandler(ColorPickerEventArgs args)
    {
         // Write your code here. 
    }
}
```

## Created

`Created` event triggers when the component is created.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfColorPicker Created="@CreatedHandler"></SfColorPicker>

@code
{
    private void CreatedHandler(Object args)
    {
         // Write your code here. 
    }
}
```

## OnModeSwitch

`OnModeSwitch` event trigerred before the mode switching is performed in the component.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfColorPicker OnModeSwitch="@HandleModeSwitch"></SfColorPicker>

@code
{
    private void HandleModeSwitch(ModeSwitchEventArgs args)
    {
         // Write your code here. 
    }
}
```

## ModeSwitched

`ModeSwitched` event trigerred after the mode switching is performed in the component.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfColorPicker ModeSwitched="@ModeSwitchedHandler"></SfColorPicker>

@code
{
    private void ModeSwitchedHandler(ModeSwitchEventArgs args)
    {
         // Write your code here. 
    }
}
```

## OnTileRender

`OnTileRender` event trigerred after the rendering of each color tile in the component is completed.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfColorPicker OnTileRender="@HandleTileRender"></SfColorPicker>

@code
{
    private void HandleTileRender(PaletteTileEventArgs args)
    {
         // Write your code here. 
    }
}
```


