---
layout: post
title: Templates in Blazor Rating Component | Syncfusion
description: Checkout and learn here all about Templates with Syncfusion Blazor Rating component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Rating
documentation: ug
---

# Templates in Blazor Rating Component

The Blazor Rating component supports to customize the appearance of the rating item by using Templates.

The Template types of Rating are as follows:

* Empty Template
* Full Template

## EmptyTemplate
You can access information about the un-rated item by setting [EmptyTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_EmptyTemplate) property. 

Below example demonstrates the Empty Template of Rating.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating>
    <EmptyTemplate>
        <span class='custom-font sf-rating-heart'></span>
    </EmptyTemplate>
</SfRating>

<style>
    .e-rating-container .custom-font {
        background: linear-gradient(to right, rgb(254,87,133,255) var(--rating-value), transparent var(--rating-value));
        background-clip: text;
        -webkit-background-clip: text;
        -webkit-text-fill-color: transparent;
        -webkit-text-stroke: 1px rgb(254,87,133,255);
    }

    @@font-face {
        font-family: 'rating';
        src: url(data:application/x-font-ttf;charset=utf-8;base64,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) format('truetype');
        font-weight: normal;
        font-style: normal;
    }

    [class^="sf-rating-"], [class*=" sf-rating-"] {
        font-family: 'rating' !important;
        speak: none;
        font-style: normal;
        font-weight: normal;
        font-variant: normal;
        text-transform: none;
        line-height: 1;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
    }

    .sf-rating-heart:before {
        content: "\e702";
    }
</style>

```

![Blazor Rating Component with EmptyTemplate](./images/blazor-rating-empty-template.png)

## FullTemplate

You can access information about the rated item by setting [FullTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfRating.html#Syncfusion_Blazor_Inputs_SfRating_FullTemplate) property.

Below example demonstrates the Full Template of Rating.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating>
    <FullTemplate>
        <span class='custom-font sf-icon-fill-star'></span>
    </FullTemplate>
    <EmptyTemplate>
        <span class='custom-font sf-icon-empty-star'></span>
    </EmptyTemplate>
</SfRating>

<style>

    .e-rating-container .custom-font {
        background: linear-gradient(to right, rgb(255,215,0) var(--rating-value), transparent var(--rating-value));
        background-clip: text;
        -webkit-background-clip: text;
        -webkit-text-fill-color: transparent;
        -webkit-text-stroke: 1px rgb(255,215,0);
    }

    @@font-face {
        font-family: 'rating-template';
        src: url(data:application/x-font-ttf;charset=utf-8;base64,AAEAAAAKAIAAAwAgT1MvMj1tSfMAAAEoAAAAVmNtYXDnEOdaAAABjAAAADhnbHlm+icDjQAAAcwAAAE0aGVhZCK49ucAAADQAAAANmhoZWEIUQQEAAAArAAAACRobXR4DAAAAAAAAYAAAAAMbG9jYQAcAJoAAAHEAAAACG1heHABDwBkAAABCAAAACBuYW1lmYExxgAAAwAAAAKFcG9zdCH169QAAAWIAAAAQAABAAAEAAAAAFwEAAAAAAAD9AABAAAAAAAAAAAAAAAAAAAAAwABAAAAAQAAgPX4jF8PPPUACwQAAAAAAN/TWPsAAAAA39NY+wAAAAAD9AP0AAAACAACAAAAAAAAAAEAAAADAFgAAgAAAAAAAgAAAAoACgAAAP8AAAAAAAAAAQQAAZAABQAAAokCzAAAAI8CiQLMAAAB6wAyAQgAAAIABQMAAAAAAAAAAAAAAAAAAAAAAAAAAAAAUGZFZABA5wDnAQQAAAAAXAQAAAAAAAABAAAAAAAABAAAAAQAAAAEAAAAAAAAAgAAAAMAAAAUAAMAAQAAABQABAAkAAAABAAEAAEAAOcB//8AAOcA//8AAAABAAQAAAABAAIAAAAAABwAmgABAAAAAAP0A/QACQAAAQUTAyUFAxMlAwFn/qX6OwE1ATU7+v6lmQKsNf7//pasrAFqAQE1AUgAAAIAAAAAA/QD5AAdAFcAAAEfBAUPAxUTLwEjDwETNS8DJT8EJwMFDwQVHwIDBx8EMzclBRczPwU1Az8CNS8DJQMvBisBDwUCYAICBgMHASCwBAMCGuoHCAjpGgIDBLEBHgcGBgJiHXb+uQgHBgQBAgTUHgECBAUHCAkIAQ4BDgcJBAQEBwQDHdMEAgMFBgf+tHYDAgMEBAQEBQUEBAQEAwICnwMDBgIDNbAGBgYE/uCBAgKBAR0HBgYGsDQCBAYD3Fr+9jwDBAcHBQgIB9T+twUIBwcEAwKVlQIBAgIFBwgJAUnUBwgJCAcFBD0BCgQDBAICAgEBAgICBAMAAAAAEgDeAAEAAAAAAAAAAQAAAAEAAAAAAAEADwABAAEAAAAAAAIABwAQAAEAAAAAAAMADwAXAAEAAAAAAAQADwAmAAEAAAAAAAUACwA1AAEAAAAAAAYADwBAAAEAAAAAAAoALABPAAEAAAAAAAsAEgB7AAMAAQQJAAAAAgCNAAMAAQQJAAEAHgCPAAMAAQQJAAIADgCtAAMAAQQJAAMAHgC7AAMAAQQJAAQAHgDZAAMAAQQJAAUAFgD3AAMAAQQJAAYAHgENAAMAAQQJAAoAWAErAAMAAQQJAAsAJAGDIHJhdGluZy10ZW1wbGF0ZVJlZ3VsYXJyYXRpbmctdGVtcGxhdGVyYXRpbmctdGVtcGxhdGVWZXJzaW9uIDEuMHJhdGluZy10ZW1wbGF0ZUZvbnQgZ2VuZXJhdGVkIHVzaW5nIFN5bmNmdXNpb24gTWV0cm8gU3R1ZGlvd3d3LnN5bmNmdXNpb24uY29tACAAcgBhAHQAaQBuAGcALQB0AGUAbQBwAGwAYQB0AGUAUgBlAGcAdQBsAGEAcgByAGEAdABpAG4AZwAtAHQAZQBtAHAAbABhAHQAZQByAGEAdABpAG4AZwAtAHQAZQBtAHAAbABhAHQAZQBWAGUAcgBzAGkAbwBuACAAMQAuADAAcgBhAHQAaQBuAGcALQB0AGUAbQBwAGwAYQB0AGUARgBvAG4AdAAgAGcAZQBuAGUAcgBhAHQAZQBkACAAdQBzAGkAbgBnACAAUwB5AG4AYwBmAHUAcwBpAG8AbgAgAE0AZQB0AHIAbwAgAFMAdAB1AGQAaQBvAHcAdwB3AC4AcwB5AG4AYwBmAHUAcwBpAG8AbgAuAGMAbwBtAAAAAAIAAAAAAAAACgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAwECAQMBBAAJZmlsbC1zdGFyCmVtcHR5LXN0YXIAAA==) format('truetype');
        font-weight: normal;
        font-style: normal;
    }

    [class^="sf-icon-"], [class*=" sf-icon-"] {
        font-family: 'rating-template' !important;
        speak: none;
        font-style: normal;
        font-weight: normal;
        font-variant: normal;
        text-transform: none;
        line-height: 1;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
    }

    .sf-icon-fill-star:before {
        content: "\e700";
    }

    .sf-icon-empty-star:before {
        content: "\e701";
    }

</style>

```

![Blazor Rating Component with FullTemplate](./images/blazor-rating-full-template.png)

## Emoji icon

You can also use Emoji icon as a rating item.

Below example demonstrates the Emoji Icon of Rating.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating Value=4 EnableSingleSelection=true EnableAnimation=false>
    <EmptyTemplate>
        @{
            if (context.Index == 0)
            {
                <span class='angry emoji'>😡</span>
            }
            else if (context.Index == 1)
            {
                <span class='disagree emoji'>🙁</span>
            }
            else if (context.Index == 2)
            {
                <span class='neutral emoji'>😐</span>
            }
            else if (context.Index == 3)
            {
                <span class='agree emoji'>🙂</span>
            }
            else
            {
                <span class='happy emoji'>😀</span>
            }
        }
    </EmptyTemplate>
</SfRating>

<style>
    .e-rating-item-container:not(.e-rating-selected) .emoji {
        filter: grayscale(1);
    }
</style>

```

![Blazor Rating Component with Emoji Icon](./images/blazor-rating-emoji-icon.png)

## SVG icon

You can also use SVG icon as a rating item.

Below example demonstrates the SVG Icon of Rating.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating EnableAnimation=false>
    <EmptyTemplate>
        <svg width="35" height="25" class="e-rating-svg-icon">
            <rect width="35" height="25" fill="transparent" style="stroke-width:2;stroke:rgb(173,181,189)" />
        </svg>
    </EmptyTemplate>
    <FullTemplate>
        <svg width="35" height="25" class="e-rating-svg-icon">
            <defs>
                <linearGradient id=@("grad"+context.Index.ToString()) x1="0%" y1="0%" x2="100%" y2="0%">
                    <stop class="start" offset="0%" />
                    <stop class="end" offset="100%" />
                </linearGradient>
            </defs>
            <rect width="35" height="25" fill=@("url(#grad"+context.Index.ToString()+")") style="stroke-width:2;stroke:rgb(173,181,189)" />
        </svg>
    </FullTemplate>
</SfRating>

<style>
    .e-rating-svg-icon #grad0 .start {
        stop-color: #FF0000;
    }

    .e-rating-svg-icon #grad0 .end,
    .e-rating-svg-icon #grad1 .start {
        stop-color: #ff5101;
    }

    .e-rating-svg-icon #grad1 .end,
    .e-rating-svg-icon #grad2 .start {
        stop-color: #ffc801;
    }

    .e-rating-svg-icon #grad2 .end,
    .e-rating-svg-icon #grad3 .start {
        stop-color: #dbe300;
    }

    .e-rating-svg-icon #grad3 .end,
    .e-rating-svg-icon #grad4 .start {
        stop-color: #8bc301;
    }

    .e-rating-svg-icon #grad4 .end {
        stop-color: #4eaa01;
    }
</style>

```

![Blazor Rating Component with SVG Icon](./images/blazor-rating-svg-icon.png)

## PNG image

You can also use PNG image as a rating item.

Below example demonstrates the PNG image of Rating.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfRating>
    <FullTemplate>        
        <img src="images/FillStar.png" width="25" height="25" />
    </FullTemplate>
    <EmptyTemplate>
        <img src="images/EmptyStar.png" width="25" height="25" />
    </EmptyTemplate>
</SfRating>

```

![Blazor Rating Component with PNG Icon](./images/blazor-rating-png.png)