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

## ItemsCount

You can specify the number of rating items using the [ItemsCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_ItemsCount) property.

Below example demonstrates ItemsCount of Rating.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating Value="3" ItemsCount="8"></SfRating>

```

![Blazor Rating Component with ItemsCount](images/blazor-rating-items-count.png)

## Disabled

You can disabled the rating component by using the [Disabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_Disabled) property. The user will not be able to interact with it.

Below example demonstrates Disabled of Rating.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating Value="3" Disabled=true></SfRating>

```

![Blazor Rating Component with Disabled](images/blazor-rating-disabled.png)

## Visible

By using the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_Visible) property, You can customize the visibility of the Rating. If the value of Visible is true, then the rating component is in a visible state.

Below example demonstrates Visible of Rating.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating Value="3" Visible=true></SfRating>

```

![Blazor Rating Component with Visible](images/blazor-rating-full-precision.png)

## ReadOnly

By using the [ReadOnly](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_ReadOnly) property, The user will not be able to interact with the rating item and change the rating value. 

Below example demonstrates ReadOnly of Rating.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating Value="3" ReadOnly=true></SfRating>

```

![Blazor Rating Component with ReadOnly](images/blazor-rating-full-precision.png)

## CssClass

You can customize the appearance of the rating component, such as by changing its colors, fonts, sizes, or other visual aspects by using the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_CssClass) property. 

Below example demonstrates CssClass of Rating.

```cshtml

<SfRating Value="3" CssClass="custom-font"></SfRating>

<style>

    .e-rating-container.custom-font .e-rating-item-list:hover .e-rating-item-container .e-rating-icon,
    .e-rating-container.custom-font .e-rating-item-container .e-rating-icon {
        /*To change rating symbol border color*/
        -webkit-text-stroke: 2px #FFA012;
        /*To change rated symbol fill color and un-rated symbol fill color*/
        background: linear-gradient(to right, #FFE814 var(--rating-value), #d8d7d4 var(--rating-value));
        background-clip: text;
        -webkit-background-clip: text;
    }

</style>

```

![Blazor Rating Component with CssClass](images/blazor-rating-css-class.png)

## Change icon using CssClass

By using the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_CssClass) property, You can customize your rating icon for your rating item. 

Below example demonstrates the Change Icon Using CssClass of Rating.

```cshtml

<SfRating Value="3" CssClass="custom-icon"></SfRating>

<style>

    .custom-icon .e-icons.e-star-filled:before {
        content: "\e702";
    }

    @@font-face {
        font-family: 'custom-icon';
        src: url(data:application/x-font-ttf;charset=utf-8;base64,AAEAAAAKAIAAAwAgT1MvMj1vSfQAAAEoAAAAVmNtYXDnEudXAAABiAAAADZnbHlmVIZrowAAAcgAAAEYaGVhZCK6KOUAAADQAAAANmhoZWEIUAQDAAAArAAAACRobXR4CAAAAAAAAYAAAAAIbG9jYQCMAAAAAAHAAAAABm1heHABDQCJAAABCAAAACBuYW1lv3dY+QAAAuAAAAJVcG9zdN12YnkAAAU4AAAALwABAAAEAAAAAFwEAAAAAAAD8wABAAAAAAAAAAAAAAAAAAAAAgABAAAAAQAAEGWKhV8PPPUACwQAAAAAAN/UcgcAAAAA39RyBwAAAAAD8wPaAAAACAACAAAAAAAAAAEAAAACAH0AAQAAAAAAAgAAAAoACgAAAP8AAAAAAAAAAQQAAZAABQAAAokCzAAAAI8CiQLMAAAB6wAyAQgAAAIABQMAAAAAAAAAAAAAAAAAAAAAAAAAAAAAUGZFZABA5wLnAgQAAAAAXAQAAAAAAAABAAAAAAAABAAAAAQAAAAAAAACAAAAAwAAABQAAwABAAAAFAAEACIAAAAEAAQAAQAA5wL//wAA5wL//wAAAAEABAAAAAEAAAAAAAAAjAAAAAEAAAAAA/MD2gB8AAATDxYVHw8/DjUvHiMPDC8PDwaoDAwMCwoKCgkICAgHBgYFBQQEAwICAQEBAQIDAwQFBQsVIyE5UmWI7FM5IR0WDQgFBAMDAgEBAQECAgMEBAUFBgYHCAgICQoKCgsMDAwMDAwNDAwNDBkYGBgXFRUUEhEICAYHCQsLDA0ODg8QEBARERESEQ4ODg4ODg0DwgYHBwgICQkKCgoLCwwLDA0MDQwNDQ4NDQ4NDQ4NDQ0NFSIwK0Rfbo/9XkUrJyMWFA0NDQ4NDQ4NDQ0ODA0NDA0LDAwLCgsKCgkICQgHBwYFBQQDAwIBAQIFBgkLDg8REwoKCwwRDw8NDQsLCggIBgUEAwIBAQECAgQEBQAAABIA3gABAAAAAAAAAAEAAAABAAAAAAABAAsAAQABAAAAAAACAAcADAABAAAAAAADAAsAEwABAAAAAAAEAAsAHgABAAAAAAAFAAsAKQABAAAAAAAGAAsANAABAAAAAAAKACwAPwABAAAAAAALABIAawADAAEECQAAAAIAfQADAAEECQABABYAfwADAAEECQACAA4AlQADAAEECQADABYAowADAAEECQAEABYAuQADAAEECQAFABYAzwADAAEECQAGABYA5QADAAEECQAKAFgA+wADAAEECQALACQBUyBjdXN0b20taWNvblJlZ3VsYXJjdXN0b20taWNvbmN1c3RvbS1pY29uVmVyc2lvbiAxLjBjdXN0b20taWNvbkZvbnQgZ2VuZXJhdGVkIHVzaW5nIFN5bmNmdXNpb24gTWV0cm8gU3R1ZGlvd3d3LnN5bmNmdXNpb24uY29tACAAYwB1AHMAdABvAG0ALQBpAGMAbwBuAFIAZQBnAHUAbABhAHIAYwB1AHMAdABvAG0ALQBpAGMAbwBuAGMAdQBzAHQAbwBtAC0AaQBjAG8AbgBWAGUAcgBzAGkAbwBuACAAMQAuADAAYwB1AHMAdABvAG0ALQBpAGMAbwBuAEYAbwBuAHQAIABnAGUAbgBlAHIAYQB0AGUAZAAgAHUAcwBpAG4AZwAgAFMAeQBuAGMAZgB1AHMAaQBvAG4AIABNAGUAdAByAG8AIABTAHQAdQBkAGkAbwB3AHcAdwAuAHMAeQBuAGMAZgB1AHMAaQBvAG4ALgBjAG8AbQAAAAACAAAAAAAAAAoAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIBAgEDAAVoZWFydAAAAA==) format('truetype');
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

![Blazor Rating Component with change icon using CssClass](images/blazor-rating-cssclass-icon.png)