---
layout: post
title: Events in Blazor Color Picker | Syncfusion®
description: Handle Blazor Color Picker events for value changes, selection, opening, and closing of the popup to react to user color selection.
platform: Blazor
control: Color Picker
documentation: ug
---

# Events in Blazor Color Picker

This section lists the events raised by the Blazor Color Picker component and when they are triggered during user interaction. Events are grouped by the part of the component lifecycle they belong to: popup lifecycle, value change, mode switching, tile rendering, and component lifecycle.

## Popup lifecycle events

The Color Picker raises paired events around the popup open and close actions: a *before* event (`OnOpen`, `OnClose`) that you can use to cancel or modify the action, and an *after* event (`Opened`, `Closed`) for post-action tasks. The before events use [`BeforeOpenCloseEventArgs`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.BeforeOpenCloseEventArgs.html), and the after events use [`OpenEventArgs`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.OpenEventArgs.html).

## Opened

`Opened` event is raised after the popup has finished opening. Use this event to perform post-open actions such as setting focus or refreshing dependent UI.

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

## OnOpen

`OnOpen` event is raised before the popup opens. You can use this event to cancel the open action or to modify the popup before it is displayed.

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

## Closed

`Closed` event is raised after the popup has been closed.

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

## OnClose

`OnClose` event is raised before the popup is closed. You can use this event to cancel the close action.

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

## Value change event

`ValueChange` event is raised every time the color value changes while the user interacts with the picker (for example, moving the handler, selecting a tile, or editing the hex input). Use the [`ColorPickerEventArgs`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.ColorPickerEventArgs.html) `CurrentValue` and `PreviousValue` properties to read the new and previous colors.

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

## Mode switching events

The Color Picker raises paired events around mode switching: `OnModeSwitch` fires before the mode changes, and `ModeSwitched` fires after. Use the [`ModeSwitchEventArgs`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.ModeSwitchEventArgs.html) `Current` and `Previous` properties to identify the modes involved.

## OnModeSwitch

`OnModeSwitch` event is raised before the mode is switched in the component.

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

`ModeSwitched` event is raised after the mode is switched.

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

## Tile render event

`OnTileRender` event is raised after each color tile in the palette is rendered. Use the [`PaletteTileEventArgs`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.PaletteTileEventArgs.html) properties to customize individual tiles.

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

## See also

* [Blazor Color Picker Getting Started](https://blazor.syncfusion.com/documentation/color-picker/getting-started)
* [Blazor Color Picker API Reference](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfColorPicker.html)


