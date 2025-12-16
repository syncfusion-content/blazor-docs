---
layout: post
title: Customization in Blazor Chip Component | Syncfusion
description: Checkout and learn here all about Customization in the Syncfusion Blazor Chip component and much more.
platform: Blazor
control: Chip
documentation: ug
---

# Customization in Blazor Chip Component

This section explains the customization of styles, leading icons, avatar, and trailing icons in Chip control.

## Styles

The Chip control has the following predefined styles that can be defined using the [`CssClass`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfChip.html#Syncfusion_Blazor_Buttons_SfChip_CssClass) property.

| Class | Description |
| -------- | -------- |
| e-primary | Represents a primary chip. |
| e-success | Represents a positive chip. |
| e-info |  Represents an informative chip. |
| e-warning | Represents a chip with caution. |
| e-danger | Represents a negative chip. |

```cshtml
@using Syncfusion.Blazor.Buttons
<SfChip>
    <ChipItems>
        <ChipItem Text="Default"></ChipItem>
        <ChipItem Text="Primary" CssClass="e-primary"></ChipItem>
        <ChipItem Text="Success" CssClass="e-success"></ChipItem>
        <ChipItem Text="Info" CssClass="e-info"></ChipItem>
        <ChipItem Text="Warning" CssClass="e-warning"></ChipItem>
        <ChipItem Text="Danger" CssClass="e-danger"></ChipItem>
    </ChipItems>
</SfChip>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXLKsrBcBIwnwbXs?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Customizing Blazor Chip Styles](./images/blazor-chip-style.png)" %}

## Leading icon

You can add and customize the leading icon of chip using the [`LeadingIconCss`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChipItem.html#Syncfusion_Blazor_Buttons_ChipItem_LeadingIconCss) property.

```cshtml
@using Syncfusion.Blazor.Buttons
<SfChip ID="chip-avatar" EnableDelete="true">
    <ChipItems>
        <ChipItem Text="Anne" LeadingIconCss="anne"></ChipItem>
        <ChipItem Text="Janet" LeadingIconCss="janet"></ChipItem>
        <ChipItem Text="Laura" LeadingIconCss="laura"></ChipItem>
        <ChipItem Text="Margaret" LeadingIconCss="margaret"></ChipItem>
    </ChipItems>
</SfChip>

<style>
    #chip-avatar .anne {
        background-image: url('https://ej2.syncfusion.com/demos/src/chips/images/anne.png')
    }

    #chip-avatar .margaret {
        background-image: url('https://ej2.syncfusion.com/demos/src/chips/images/margaret.png')
    }

    #chip-avatar .laura {
        background-image: url('https://ej2.syncfusion.com/demos/src/chips/images/laura.png')
    }

    #chip-avatar .janet {
        background-image: url('https://ej2.syncfusion.com/demos/src/chips/images/janet.png')
    }
</style>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZLeDksEzbMVhnKc?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Customizing LeadingIcon of Blazor Chip](./images/blazor-chip-leading-icon.gif)" %}

## Avatar

You can add and customize the avatar of chip using the [`LeadingIconCss`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChipItem.html#Syncfusion_Blazor_Buttons_ChipItem_LeadingIconCss) property.

```csharp

<SfChip EnableDelete="true" CssClass="e-leading-avatar">
    <ChipItems>
        <ChipItem Text="Andrew" LeadingIconCss="andrew"></ChipItem>
        <ChipItem Text="Janet" LeadingIconCss="janet"></ChipItem>
        <ChipItem Text="Laura" LeadingIconCss="laura"></ChipItem>
        <ChipItem Text="Margaret" LeadingIconCss="margaret"></ChipItem>
    </ChipItems>
</SfChip>

<style>
    .e-chip-avatar.andrew {
        background-image: url('https://ej2.syncfusion.com/demos/src/chips/images/andrew.png')
    }

    .e-chip-avatar.margaret {
        background-image: url('https://ej2.syncfusion.com/demos/src/chips/images/margaret.png')
    }

    .e-chip-avatar.laura {
        background-image: url('https://ej2.syncfusion.com/demos/src/chips/images/laura.png')
    }

    .e-chip-avatar.janet {
        background-image: url('https://ej2.syncfusion.com/demos/src/chips/images/janet.png')
    }
</style>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZrItusapbhiLdgI?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}



## Leading content

You can add and customize the avatar content of chip using the [`LeadingText`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChipItem.html#Syncfusion_Blazor_Buttons_ChipItem_LeadingText) property.

```cshtml
@using Syncfusion.Blazor.Buttons
<SfChip EnableDelete="true" CssClass="e-leading-avatar">
    <ChipItems>
        <ChipItem Text="Andrew" LeadingText="A"></ChipItem>
        <ChipItem Text="Janet" LeadingText="J"></ChipItem>
        <ChipItem Text="Laura" LeadingText="L"></ChipItem>
        <ChipItem Text="Margaret" LeadingText="M"></ChipItem>
    </ChipItems>
</SfChip>

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VXrqCLrQrovxnFxf?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Customizing Avatar Text of Blazor Chip](./images/blazor-chip-avatar-content.gif)" %}

## Trailing icon

You can add and customize the trailing icon of chip using the [`TrailingIconCss`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChipItem.html#Syncfusion_Blazor_Buttons_ChipItem_TrailingIconCss) property.

```cshtml
@using Syncfusion.Blazor.Buttons
<SfChip>
    <ChipItems>
        <ChipItem Text="Andrew" TrailingIconCss="e-dlt-btn"></ChipItem>
        <ChipItem Text="Janet" TrailingIconCss="e-dlt-btn"></ChipItem>
        <ChipItem Text="Laura" TrailingIconCss="e-dlt-btn"></ChipItem>
        <ChipItem Text="Margaret" TrailingIconCss="e-dlt-btn"></ChipItem>
    </ChipItems>
</SfChip>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZVUiBhwBekjUuOz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Customizing Blazor Chip TrailingIcon](./images/blazor-chip-trailing-icon.png)" %}

## Outline chip

Outline chip has the border with the background transparent. It can be set using the [`CssClass`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfChip.html#Syncfusion_Blazor_Buttons_SfChip_CssClass) property.

```cshtml
@using Syncfusion.Blazor.Buttons
<SfChip EnableDelete="true">
    <ChipItems>
        <ChipItem CssClass="e-outline" Text="Andrew"></ChipItem>
        <ChipItem CssClass="e-outline" Text="Janet"></ChipItem>
        <ChipItem CssClass="e-outline" Text="Laura"></ChipItem>
        <ChipItem CssClass="e-outline" Text="Margaret"></ChipItem>
    </ChipItems>
</SfChip>

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VtVgshrQrokgrCJD?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Outline Chip with Transparent Background](./images/blazor-outline-chip-transparent-background.gif)" %}

## Template

The Chips Template property allows users to customize the layout and design of each chip. Users can include any custom HTML elements, icons, links, or additional content by specifying them in the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChipItem.html#Syncfusion_Blazor_Buttons_ChipItem_Template) or as direct child content inside the [ChipItem](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChipItem.html#Syncfusion_Blazor_Buttons_ChipItem) of the SfChip component.

The following code example demonstrates how to customize the layout and design of chips by adding direct child content inside the `ChipItem`.

```cshtml

@using Syncfusion.Blazor.Buttons

<SfChip id="customTemplate">
    <ChipItems>
        <ChipItem LeadingIconCss="trendingIcon">
            <a href="https://timesofindia.indiatimes.com/news" target="_blank" class="anchorElement">#BreakingNews</a>
            <span class="textElement">125k posts</span>
        </ChipItem>
        <ChipItem LeadingIconCss="cameraIcon">
            <a href="https://blog.google/products/photos/" target="_blank" class="anchorElement">#PhotoOfTheDay</a>
        </ChipItem>
        <ChipItem LeadingIconCss="trendingIcon">
            <a href="https://indianexpress.com/section/technology/" target="_blank" class="anchorElement">#TechNews</a>
            <span class="textElement">107k posts</span>
        </ChipItem>
    </ChipItems>
</SfChip>

<style>

    #customTemplate .e-chip .trendingIcon {
        margin: 4px 0 4px 6px;
        width: 16px;
        height: 16px;
        background-image: url("data:image/svg+xml;utf8;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIGhlaWdodD0iNDgiIHdpZHRoPSI0OCI+PHBhdGggZD0ibTMyIDEyIDQuNTkgNC41OS05Ljc2IDkuNzUtOC04TDQgMzMuMTcgNi44MyAzNmwxMi0xMiA4IDggMTIuNTgtMTIuNTlMNDQgMjRWMTJ6Ii8+PHBhdGggZD0iTTAgMGg0OHY0OEgweiIgZmlsbD0ibm9uZSIvPjwvc3ZnPg==");
    }

    #customTemplate .e-chip .cameraIcon {
        margin: 4px 0 4px 6px;
        width: 16px;
        height: 16px;
        background-image: url("data:image/svg+xml;utf8;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCAyNCAyNCI+PHBhdGggZD0iTTE5LDYuNUgxNy43MmwtLjMyLTFhMywzLDAsMCwwLTIuODQtMkg5LjQ0QTMsMywwLDAsMCw2LjYsNS41NWwtLjMyLDFINWEzLDMsMCwwLDAtMywzdjhhMywzLDAsMCwwLDMsM0gxOWEzLDMsMCwwLDAsMy0zdi04QTMsMywwLDAsMCwxOSw2LjVabTEsMTFhMSwxLDAsMCwxLTEsMUg1YTEsMSwwLDAsMS0xLTF2LThhMSwxLDAsMCwxLDEtMUg3YTEsMSwwLDAsMCwxLS42OGwuNTQtMS42NGExLDEsMCwwLDEsLjk1LS42OGg1LjEyYTEsMSwwLDAsMSwuOTUuNjhsLjU0LDEuNjRBMSwxLDAsMCwwLDE3LDguNWgyYTEsMSwwLDAsMSwxLDFabS04LTlhNCw0LDAsMSwwLDQsNEE0LDQsMCwwLDAsMTIsOC41Wm0wLDZhMiwyLDAsMSwxLDItMkEyLDIsMCwwLDEsMTIsMTQuNVoiLz48L3N2Zz4=");
    }

    #customTemplate .e-chip .anchorElement {
        margin: 0 4px;
        font-weight:600;
        height: 16px;
        line-height:16px;
        font-size: 12px;
        color: #0F6CBD;
        text-decoration: none;
    }

    #customTemplate .e-chip .textElement {
        font-weight: 400;
        height: 14px;
        line-height: 14px;
        font-size: 10px;
        margin-right: 6px;
    }
</style>

```

![Template in Blazor Chip component](./images/blazor-chip-template.png)