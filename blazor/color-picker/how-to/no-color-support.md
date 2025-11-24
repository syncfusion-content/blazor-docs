---
layout: post
title: Handle No Color Support in Blazor Color Picker Component | Syncfusion
description: Checkout and learn here all about Handle No Color Support in Syncfusion Blazor Color Picker component and more.
platform: Blazor
control: Color Picker
documentation: ug
---

# Handle No Color Support in Blazor Color Picker Component

The Color Picker component supports no color functionality. By clicking the no color tile from palette, the selected color becomes `empty` and considered as no color has been selected from Color Picker.

## Default no color

To achieve this, set [NoColor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfColorPicker.html#Syncfusion_Blazor_Inputs_SfColorPicker_NoColor) property as true. In the following sample, the first tile of the color palette represents the no color tile. By clicking the no color tile, you can achieve the above functionalities.

```cshtml

@using Syncfusion.Blazor.Inputs

<div id="preview" style="@colorValue"></div>
<SfColorPicker NoColor="true" Mode="ColorPickerMode.Palette" ShowButtons="false" ModeSwitcher="false" ValueChange="@Changed"></SfColorPicker>

@code {
    private string colorValue = "background-color: #008000";
    private void Changed(ColorPickerEventArgs args)
    {
        colorValue = "background-color:" + args.CurrentValue.Hex;
    }
}

<style>
    #preview {
        border: 1px solid;
        height: 40px;
        margin-bottom: 10px;
        width: 300px;
    }
</style>

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VDVUsLLGKoIFoxSv?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor ColorPicker with Default No Color](./../images/blazor-colorpicker-nocolor.png)" %}

>If the [NoColor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfColorPicker.html#Syncfusion_Blazor_Inputs_SfColorPicker_NoColor) property is enabled, make sure to disable the [ModeSwitcher](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfColorPicker.html#Syncfusion_Blazor_Inputs_SfColorPicker_ModeSwitcher) property.

## Custom no color

The following sample shows the color palette with custom no color option.

```cshtml

@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.SplitButtons

<div id="preview" style="@colorValue"></div>
<SfSplitButton @ref="splitBtn" CssClass="color-picker">
    <ChildContent>
        @{
            var spanStyle = colorValue + "; display: block; height: 2px";
        }
        <span class="e-icons e-picker"></span>
        <span style="@spanStyle"></span>
    </ChildContent>
    <PopupContent>
        <ul class="e-dropdown-menu" tabindex="0">
            <li class="e-item e-palette-item">
                <SfColorPicker Columns="4" Inline="true" Mode="ColorPickerMode.Palette" PresetColors="@customColors" ShowButtons="false" ModeSwitcher="false" ValueChange="@Changed"></SfColorPicker>
            </li>
            <li class="e-item e-separator"></li>
            <li class="e-item" @onclick="@NoColorHandler" id="no-color" tabindex="-1">
                <span class="e-menu-icon e-nocolor"></span>
                No color
            </li>
        </ul>
    </PopupContent>
</SfSplitButton>

@code {
    private SfSplitButton splitBtn;
    private string colorValue = "background-color: #008000";
    private Dictionary<string, string[]> customColors = new Dictionary<string, string[]> {
        {
            "Custom", new string[] {"#f44336", "#e91e63", "#9c27b0", "#673ab7", "#2196f3", "#03a9f4", "#00bcd4", "#009688", "#8bc34a", "#cddc39", "#ffeb3b", "#ffc107"}
        }
    };
    private void Changed(ColorPickerEventArgs args)
    {
        colorValue = "background-color:" + args.CurrentValue.Hex;
        splitBtn.Toggle();
    }
    private void NoColorHandler()
    {
        colorValue = "background-color: transparent";
        splitBtn.Toggle();
    }
}

<style>
    .e-picker::before {
        content: '\e35c'
    }
    #preview {
        border: 1px solid;
        height: 40px;
        width: 300px;
        margin-bottom: 10px;
    }
    .color-picker.e-dropdown-popup ul {
        padding: 0;
    }
    .color-picker.e-dropdown-popup ul .e-container {
        box-shadow: none;
    }
    .color-picker.e-dropdown-popup .e-container .e-custom-palette .e-palette {
        padding-bottom: 2px;
    }
    .color-picker.e-dropdown-popup ul .e-item.e-palette-item {
        height: auto;
        padding: 0;
    }
    .color-picker.e-dropdown-popup ul .e-item .e-menu-icon.e-nocolor {
        height: 22px;
        margin-top: 8px;
        width: 22px;
        background: transparent url('data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiPz4KPHN2ZyB3aWR0aD0iNnB4IiBoZWlnaHQ9IjZweCIgdmlld0JveD0iMCAwIDYgNiIgdmVyc2lvbj0iMS4xIiB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHhtbG5zOnhsaW5rPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5L3hsaW5rIj4KICAgIDwhLS0gR2VuZXJhdG9yOiBTa2V0Y2ggNTAgKDU0OTgzKSAtIGh0dHA6Ly93d3cuYm9oZW1pYW5jb2RpbmcuY29tL3NrZXRjaCAtLT4KICAgIDx0aXRsZT5Hcm91cCA5PC90aXRsZT4KICAgIDxkZXNjPkNyZWF0ZWQgd2l0aCBTa2V0Y2guPC9kZXNjPgogICAgPGRlZnM+PC9kZWZzPgogICAgPGcgaWQ9IlBhZ2UtMSIgc3Ryb2tlPSJub25lIiBzdHJva2Utd2lkdGg9IjEiIGZpbGw9Im5vbmUiIGZpbGwtcnVsZT0iZXZlbm9kZCI+CiAgICAgICAgPGcgaWQ9Ikdyb3VwLTkiPgogICAgICAgICAgICA8cmVjdCBpZD0iUmVjdGFuZ2xlLTExIiBmaWxsPSIjRTBFMEUwIiB4PSIwIiB5PSIwIiB3aWR0aD0iMyIgaGVpZ2h0PSIzIj48L3JlY3Q+CiAgICAgICAgICAgIDxyZWN0IGlkPSJSZWN0YW5nbGUtMTEtQ29weS0yIiBmaWxsPSIjRkZGRkZGIiB4PSIwIiB5PSIzIiB3aWR0aD0iMyIgaGVpZ2h0PSIzIj48L3JlY3Q+CiAgICAgICAgICAgIDxyZWN0IGlkPSJSZWN0YW5nbGUtMTEtQ29weSIgZmlsbD0iI0ZGRkZGRiIgeD0iMyIgeT0iMCIgd2lkdGg9IjMiIGhlaWdodD0iMyI+PC9yZWN0PgogICAgICAgICAgICA8cmVjdCBpZD0iUmVjdGFuZ2xlLTExLUNvcHktMyIgZmlsbD0iI0UwRTBFMCIgeD0iMyIgeT0iMyIgd2lkdGg9IjMiIGhlaWdodD0iMyI+PC9yZWN0PgogICAgICAgIDwvZz4KICAgIDwvZz4KPC9zdmc+');
    }
</style>

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VthAsLLwAyxsVKHl?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor ColorPicker with Custom No Color](./../images/blazor-colorpicker-custom-nocolor.png)" %}
