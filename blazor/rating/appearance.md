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

![Blazor Rating Component with ItemsCount](images/blazor-rating-itemscount.png)

## Disabled

You can disabled the rating component by using the [Disabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_Disabled) property. The user will not be able to interact with it.

Below example demonstrates Disabled of Rating.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating Value="3" Disabled=true></SfRating>

```

![Blazor Rating Component with Disabled](images/blazor-rating-disabled.png)

## Visible

By using the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_Visible) property. You can customize the visibility of the Rating. If the value of Visible is true, then the rating component is in a visible state.

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
    .e-rating-container.custom-font .e-list-item .e-rating-item-container .e-rating-icon {
        -webkit-text-stroke: 2px #ea8d57;
        background: linear-gradient(to right, #FFAD29 var(--rating-value), #eed3a6 var(--rating-value));
        background-clip: text;
        -webkit-background-clip: text;
    }

</style>

```

![Blazor Rating Component with CssClass](images/blazor-rating-css-class.png)

## Change icon using CssClass

By using the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_CssClass) property, You can customize your rating icon for your rating item. 

Below example demonstrates the Change Icon Using Css Class of Rating.

```cshtml

<SfRating Value="3" CssClass="custom-icon"></SfRating>

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

![Blazor Rating Component with change icon using CssClass](images/blazor-rating-cssclass-icon.png)