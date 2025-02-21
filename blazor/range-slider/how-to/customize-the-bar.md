---
layout: post
title: Customize the bar in Blazor Range Slider Component | Syncfusion
description: Checkout and learn here all about customize the bar in Syncfusion Blazor Range Slider component and more.
platform: Blazor
control: Range Slider
documentation: ug
---

# Customize the bar in Blazor Range Slider Component

Slider appearance can be customized through CSS. By overriding the slider CSS classes, you can customize the slider bar. The slider bar can be customized with different themes. By default, slider have class name `e-slider-track` for bar. The class can be overridden with our own color values like the following code snippet.

```css
#gradient_slider.e-control.e-slider .e-range {
    height: 6px;
    top: calc(50% - 3px);
    border-radius: 5px;
    background: -webkit-linear-gradient(left, #e1451d 0, #fdff47 17%, #86f9fe 50%, #2900f8 65%, #6e00f8 74%, #e33df9 83%, #e14423 100%);
    background: linear-gradient(left, #e1451d 0, #fdff47 17%, #86f9fe 50%, #2900f8 65%, #6e00f8 74%, #e33df9 83%, #e14423 100%);
    background: -moz-linear-gradient(left, #e1451d 0, #fdff47 17%, #86f9fe 50%, #2900f8 65%, #6e00f8 74%, #e33df9 83%, #e14423 100%);
    background: url(data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiA/Pgo8c3ZnIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgd2lkdGg9IjEwMCUiIGhlaWdodD0iMTAwJSIgdmlld0JveD0iMCAwIDEgMSIgcHJlc2VydmVBc3BlY3RSYXRpbz0ibm9uZSI+CiAgPGxpbmVhckdyYWRpZW50IGlkPSJncmFkLXVjZ2ctZ2VuZXJhdGVkIiBncmFkaWVudFVuaXRzPSJ1c2VyU3BhY2VPblVzZSIgeDE9IjAlIiB5MT0iMCUiIHgyPSIxMDAlIiB5Mj0iMCUiPgogICAgPHN0b3Agb2Zmc2V0PSIwIiBzdG9wLWNvbG9yPSIjZTE0NTFkIiBzdG9wLW9wYWNpdHk9IjEiLz4KICAgIDxzdG9wIG9mZnNldD0iMTclIiBzdG9wLWNvbG9yPSIjZmRmZjQ3IiBzdG9wLW9wYWNpdHk9IjEiLz4KICAgIDxzdG9wIG9mZnNldD0iNTAlIiBzdG9wLWNvbG9yPSIjODZmOWZlIiBzdG9wLW9wYWNpdHk9IjEiLz4KICAgIDxzdG9wIG9mZnNldD0iNjUlIiBzdG9wLWNvbG9yPSIjMjkwMGY4IiBzdG9wLW9wYWNpdHk9IjEiLz4KICAgIDxzdG9wIG9mZnNldD0iNzQlIiBzdG9wLWNvbG9yPSIjNmUwMGY4IiBzdG9wLW9wYWNpdHk9IjEiLz4KICAgIDxzdG9wIG9mZnNldD0iODMlIiBzdG9wLWNvbG9yPSIjZTMzZGY5IiBzdG9wLW9wYWNpdHk9IjEiLz4KICAgIDxzdG9wIG9mZnNldD0iMTAwJSIgc3RvcC1jb2xvcj0iI2UxNDQyMyIgc3RvcC1vcGFjaXR5PSIxIi8+CiAgPC9saW5lYXJHcmFkaWVudD4KICA8cmVjdCB4PSIwIiB5PSIwIiB3aWR0aD0iMSIgaGVpZ2h0PSIxIiBmaWxsPSJ1cmwoI2dyYWQtdWNnZy1nZW5lcmF0ZWQpIiAvPgo8L3N2Zz4=);
}
```

In this code snippet, it can be seen that the dynamic color of the slider is being changed.

```cshtml
<SfSlider @bind-Value="@Value" ID="dynamic_color_slider" Type="SliderType.MinRange">
    <SliderEvents TValue="int" ValueChange="@(e => { OnChange(e.Value); })"></SliderEvents>
</SfSlider>
```

Color bar can be customized in quite a number of ways.

```cshtml
@using Syncfusion.Blazor.Inputs;
@using Syncfusion.Blazor.Buttons;
<div class="col-lg-12 control-section">
    <div class="control-wrapper">
        <div class="slider-content-wrapper">
            <div class="slider_container">
                <div class="slider-labeltext slider_userselect">Height</div>
                <SfSlider Value="30" ID="height_slider">
                </SfSlider>
            </div>
            <div class="slider_container">
                <div class="slider-labeltext slider_userselect">Gradient color</div>
                <SfSlider Value="50" ID="gradient_slider" Type="SliderType.MinRange">
                </SfSlider>
            </div>
            <div class="slider_container">
                <div class="slider-labeltext slider_userselect">Dynamic thumb and selection bar color</div>
                <SfSlider @bind-Value="@Value" ID="dynamic_color_slider" Type="SliderType.MinRange" CssClass="@DynamicColor">
                    <SliderEvents TValue="int" ValueChange="@(e => { OnChange(e.Value); })"></SliderEvents>
                </SfSlider>
            </div>
        </div>
    </div>
</div>
@code {
    string DynamicColor = "e-slider-green";
    int Value = 20;
    void OnChange(int value)
    {
        if (value > 0 && value <= 25)
        {
            DynamicColor = "e-slider-green";
        }
        else if (value > 25 && value <= 50)
        {
            DynamicColor = "e-slider-royalblue";
        }
        else if (value > 50 && value <= 75)
        {
            DynamicColor = "e-slider-darkorange";
        }
        else if (value > 75 && value <= 100)
        {
            DynamicColor = "e-slider-red";
        }
    }
}
<style>
    #dynamic_color_slider.e-slider-royalblue .e-range {
        background-color: royalblue;
    }

    #dynamic_color_slider.e-slider-green .e-range {
        background-color: green;
    }

    #dynamic_color_slider.e-slider-darkorange .e-range {
        background-color: darkorange;
    }

    #dynamic_color_slider.e-slider-red .e-range {
        background-color: red;
    }

    #dynamic_color_slider.e-slider-royalblue .e-handle {
        background-color: royalblue;
    }

    #dynamic_color_slider.e-slider-green .e-handle {
        background-color: green;
    }

    #dynamic_color_slider.e-slider-darkorange .e-handle {
        background-color: darkorange;
    }

    #dynamic_color_slider.e-slider-red .e-handle {
        background-color: red;
    }

    .slider-content-wrapper {
        width: 40%;
        margin: 0 auto;
        min-width: 185px;
    }

    .slider-userselect {
        -webkit-user-select: none;
        /* Safari 3.1+ */
        -moz-user-select: none;
        /* Firefox 2+ */
        -ms-user-select: none;
        /* IE 10+ */
        user-select: none;
        /* Standard syntax */
    }

    .slider-labeltext {
        text-align: -webkit-left;
        font-weight: 500;
        font-size: 13px;
        padding-bottom: 10px;
    }

    .e-slider-container #height_slider.e-slider .e-handle,
    .e-slider-container #gradient_slider.e-slider .e-handle {
        height: 20px;
        width: 20px;
    }

    .e-slider-container.e-horizontal #height_slider .e-handle,
    .e-slider-container.e-horizontal #gradient_slider .e-handle {
        margin-left: -10px;
        top: calc(50% - 10px);
    }

    .slider_container {
        margin-top: 40px;
    }

    #height_slider .e-tab-handle::after {
        background-color: #f9920b;
    }

    #height_slider.e-control.e-slider .e-slider-track {
        height: 8px;
        top: calc(50% - 4px);
        border-radius: 0;
    }


    #gradient_slider.e-control.e-slider .e-range {
        height: 6px;
        top: calc(50% - 3px);
        border-radius: 5px;
        background: -webkit-linear-gradient(left, #e1451d 0, #fdff47 17%, #86f9fe 50%, #2900f8 65%, #6e00f8 74%, #e33df9 83%, #e14423 100%);
        background: linear-gradient(left, #e1451d 0, #fdff47 17%, #86f9fe 50%, #2900f8 65%, #6e00f8 74%, #e33df9 83%, #e14423 100%);
        background: -moz-linear-gradient(left, #e1451d 0, #fdff47 17%, #86f9fe 50%, #2900f8 65%, #6e00f8 74%, #e33df9 83%, #e14423 100%);
        background: url(data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiA/Pgo8c3ZnIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgd2lkdGg9IjEwMCUiIGhlaWdodD0iMTAwJSIgdmlld0JveD0iMCAwIDEgMSIgcHJlc2VydmVBc3BlY3RSYXRpbz0ibm9uZSI+CiAgPGxpbmVhckdyYWRpZW50IGlkPSJncmFkLXVjZ2ctZ2VuZXJhdGVkIiBncmFkaWVudFVuaXRzPSJ1c2VyU3BhY2VPblVzZSIgeDE9IjAlIiB5MT0iMCUiIHgyPSIxMDAlIiB5Mj0iMCUiPgogICAgPHN0b3Agb2Zmc2V0PSIwIiBzdG9wLWNvbG9yPSIjZTE0NTFkIiBzdG9wLW9wYWNpdHk9IjEiLz4KICAgIDxzdG9wIG9mZnNldD0iMTclIiBzdG9wLWNvbG9yPSIjZmRmZjQ3IiBzdG9wLW9wYWNpdHk9IjEiLz4KICAgIDxzdG9wIG9mZnNldD0iNTAlIiBzdG9wLWNvbG9yPSIjODZmOWZlIiBzdG9wLW9wYWNpdHk9IjEiLz4KICAgIDxzdG9wIG9mZnNldD0iNjUlIiBzdG9wLWNvbG9yPSIjMjkwMGY4IiBzdG9wLW9wYWNpdHk9IjEiLz4KICAgIDxzdG9wIG9mZnNldD0iNzQlIiBzdG9wLWNvbG9yPSIjNmUwMGY4IiBzdG9wLW9wYWNpdHk9IjEiLz4KICAgIDxzdG9wIG9mZnNldD0iODMlIiBzdG9wLWNvbG9yPSIjZTMzZGY5IiBzdG9wLW9wYWNpdHk9IjEiLz4KICAgIDxzdG9wIG9mZnNldD0iMTAwJSIgc3RvcC1jb2xvcj0iI2UxNDQyMyIgc3RvcC1vcGFjaXR5PSIxIi8+CiAgPC9saW5lYXJHcmFkaWVudD4KICA8cmVjdCB4PSIwIiB5PSIwIiB3aWR0aD0iMSIgaGVpZ2h0PSIxIiBmaWxsPSJ1cmwoI2dyYWQtdWNnZy1nZW5lcmF0ZWQpIiAvPgo8L3N2Zz4=);
    }

    #gradient_slider.e-control.e-slider .e-slider-track {
        height: 8px;
        top: calc(50% - 4px);
        border-radius: 5px;
    }
</style>

```

![Blazor RangeSlider with Bar](./../images/blazor-rangeslider-with-bar.gif)

## Customizing the Range Slider Track with Color Segments

You can enhance the Blazor Range Slider by defining different track colors for specific value ranges. This is done using the `ColorRange` child elements within the [`SliderColorRanges`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SliderColorRanges.html) tag.

How It Works:

* ``Start``: Defines where the color segment begins.
* ``End``: Defines where the color segment stops.
* ``Color``: Specifies the color for the segment.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfSlider ID="sliderTracks" TValue="int[]" Value=@RangeValue Type="SliderType.Range" Width="400px">
    <SliderTicks Placement="Placement.Both" ShowSmallTicks="true" LargeStep="20" SmallStep="5"></SliderTicks>
    <SliderTooltip IsVisible="true" Placement="TooltipPlacement.Before" ShowOn="TooltipShowOn.Always"></SliderTooltip>
    <SliderColorRanges>
        <ColorRange Start="0" End="50" Color="green"></ColorRange>
        <ColorRange Start="51" End="100" Color="red"></ColorRange>
    </SliderColorRanges>
</SfSlider>

@code {
    public int[] RangeValue = { 30, 70 };
}

<style>
    #sliderTracks.e-slider .e-range, #sliderTracks.e-slider .e-handle {
        background-color: #FF9800;
    }

    #sliderTracks.e-slider .e-handle {
        border-radius: 50%;
        border: 0;
    }

</style>

```

![Blazor RangeSlider with track color](images/blazor-rangeslider-track.png)
