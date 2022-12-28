---
layout: post
title: Appearance in Blazor Rating Component | Syncfusion
description: Checkout and learn here all about Appearance with Syncfusion Blazor Rating component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Rating
documentation: ug
---

# Appearance in Blazor Rating Component

You can also customize the appearance of rating control.

## Items count

You can specify the number of rating items using the [ItemsCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_ItemsCount) property.

Below example demonstrates the Items Count of Rating.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating ItemsCount="8"></SfRating>

```

![Blazor Rating Component with Items Count](images/blazor-rating-itemscount.png)

## Disabled

You can disabled the rating component by using the [Disabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_Disabled) property. The user will not be able to interact with it.

Below example demonstrates the Disabled of Rating.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating Disabled=true></SfRating>

```

![Blazor Rating Component with Disabled](images/blazor-rating-disabled.png)

## Visible

By using the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_Visible) property. You can customize the visibility of the Rating. If the value of Visible is true, then the rating component is in a visible state.

Below example demonstrates the Visible of Rating.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating Visible=true></SfRating>

```

![Blazor Rating Component with Visible](images/blazor-rating-full-precision.png)

## Read Only

By using the [ReadOnly](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_ReadOnly) property, The user will not be able to interact with the rating item and change the rating value. 

Below example demonstrates the Read Only of Rating.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating ReadOnly=true></SfRating>

```

![Blazor Rating Component with Visible](images/blazor-rating-full-precision.png)

## Css Class

You can customize the appearance of the rating component, such as by changing its colors, fonts, sizes, or other visual aspects by using the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_CssClass) property. 

Below example demonstrates Css Class of Rating.

```cshtml

<SfRating>
    <FullTemplate>
        <span class='custom-font sf-icon-star'></span>
    </FullTemplate>
    <EmptyTemplate>
        <span class='custom-font sf-icon-star'></span>
    </EmptyTemplate>
</SfRating>

<style>

    .e-rating-container .e-rating-selected .custom-font,
    .e-rating-container .e-rating-intermediate .custom-font {
        background: linear-gradient(to right, rgb(235,246,6) var(--rating-value), transparent var(--rating-value));
        background-clip: text;
        -webkit-background-clip: text;
        -webkit-text-fill-color: transparent;
        -webkit-text-stroke: 1px rgb(255,172,0);
    }

    .e-rating-container .custom-font {
        color:#b39c5b;
        -webkit-text-stroke: 1px rgb(255,172,0);
    }    

    @@font-face {
        font-family: 'RatingIcon';
        src: url(data:application/x-font-ttf;charset=utf-8;base64,AAEAAAAKAIAAAwAgT1MvMj1tSfIAAAEoAAAAVmNtYXDnEOdVAAABiAAAADZnbHlm9cEZjAAAAcgAAAA4aGVhZCK0htcAAADQAAAANmhoZWEIUQQDAAAArAAAACRobXR4CAAAAAAAAYAAAAAIbG9jYQAcAAAAAAHAAAAABm1heHABDQAWAAABCAAAACBuYW1lOGHbkgAAAgAAAAJJcG9zdHSFYngAAARMAAAALgABAAAEAAAAAFwEAAAAAAAD9AABAAAAAAAAAAAAAAAAAAAAAgABAAAAAQAAru5xRl8PPPUACwQAAAAAAN/RIPMAAAAA39Eg8wAAAAAD9AP0AAAACAACAAAAAAAAAAEAAAACAAoAAQAAAAAAAgAAAAoACgAAAP8AAAAAAAAAAQQAAZAABQAAAokCzAAAAI8CiQLMAAAB6wAyAQgAAAIABQMAAAAAAAAAAAAAAAAAAAAAAAAAAAAAUGZFZABA5wDnAAQAAAAAXAQAAAAAAAABAAAAAAAABAAAAAQAAAAAAAACAAAAAwAAABQAAwABAAAAFAAEACIAAAAEAAQAAQAA5wD//wAA5wD//wAAAAEABAAAAAEAAAAAAAAAHAAAAAEAAAAAA/QD9AAJAAABBRMDJQUDEyUDAWb+pvo7ATUBNTv6/qaaAqs1/wD+lqurAWoBADUBSQAAAAASAN4AAQAAAAAAAAABAAAAAQAAAAAAAQAKAAEAAQAAAAAAAgAHAAsAAQAAAAAAAwAKABIAAQAAAAAABAAKABwAAQAAAAAABQALACYAAQAAAAAABgAKADEAAQAAAAAACgAsADsAAQAAAAAACwASAGcAAwABBAkAAAACAHkAAwABBAkAAQAUAHsAAwABBAkAAgAOAI8AAwABBAkAAwAUAJ0AAwABBAkABAAUALEAAwABBAkABQAWAMUAAwABBAkABgAUANsAAwABBAkACgBYAO8AAwABBAkACwAkAUcgUmF0aW5nSWNvblJlZ3VsYXJSYXRpbmdJY29uUmF0aW5nSWNvblZlcnNpb24gMS4wUmF0aW5nSWNvbkZvbnQgZ2VuZXJhdGVkIHVzaW5nIFN5bmNmdXNpb24gTWV0cm8gU3R1ZGlvd3d3LnN5bmNmdXNpb24uY29tACAAUgBhAHQAaQBuAGcASQBjAG8AbgBSAGUAZwB1AGwAYQByAFIAYQB0AGkAbgBnAEkAYwBvAG4AUgBhAHQAaQBuAGcASQBjAG8AbgBWAGUAcgBzAGkAbwBuACAAMQAuADAAUgBhAHQAaQBuAGcASQBjAG8AbgBGAG8AbgB0ACAAZwBlAG4AZQByAGEAdABlAGQAIAB1AHMAaQBuAGcAIABTAHkAbgBjAGYAdQBzAGkAbwBuACAATQBlAHQAcgBvACAAUwB0AHUAZABpAG8AdwB3AHcALgBzAHkAbgBjAGYAdQBzAGkAbwBuAC4AYwBvAG0AAAAAAgAAAAAAAAAKAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAQIBAwAEc3RhcgAAAAA=) format('truetype');
        font-weight: normal;
        font-style: normal;
    }

    [class^="sf-icon-"], [class*=" sf-icon-"] {
        font-family: 'RatingIcon' !important;
        speak: none;
        font-style: normal;
        font-weight: normal;
        font-variant: normal;
        text-transform: none;
        line-height: 1;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
    }

    .sf-icon-star:before {
        content: "\e700";
    }

</style>

```

![Blazor Rating Component with Css Class](images/blazor-rating-css-class.png)

## Change Icon Using Css Class

By using the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_CssClass) property, You can customize your rating icon for your rating item. 

Below example demonstrates the Change Icon Using Css Class of Rating.

```cshtml

<SfRating CssClass="custom-icon"></SfRating>

<style>
    .custom-icon .e-icons.e-star-filled:before {
        content: "\e700";
    }

    @@font-face {
        font-family: 'custom-icon';
        src: url(data:application/x-font-ttf;charset=utf-8;base64,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) format('truetype');
        font-weight: normal;
        font-style: normal;
    }

    .custom-icon .e-icons.e-star-filled {
        font-family: 'custom-icon' !important;
        speak: none;
        font-style: normal;
        font-weight: normal;
        font-variant: normal;
        text-transform: none;
        line-height: 1;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
    }
</style>

```

![Blazor Rating Component with Change Icon Using Css Class](images/blazor-rating-cssclass-icon.png)