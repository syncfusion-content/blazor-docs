---
layout: post
title: Getting Started with Blazor Chip Component | Syncfusion
description: Checkout and learn here all about template in Syncfusion Blazor Chip component and much more details.
platform: Blazor
control: Chip
documentation: ug
---

# Template in Blazor Chip Component

The Chips Template property allows users to customize the layout and design of each chip. Users can include any custom HTML elements, icons, links, or additional content by specifying them in the `<Template>` tag or as direct child content inside the `<ChipItem>` tag of the SfChip component.

The following code example demonstrates how to customize the layout and design of chips by adding direct child content inside the `<ChipItem>` tag.

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