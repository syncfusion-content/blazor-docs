---
layout: post
title: Style Customization for active item in Blazor Tabs | Syncfusion
description: Learn here all about style customization for active item in Syncfusion Blazor Tabs component, it's elements and more.
platform: Blazor
control: Tabs
documentation: ug
---

# Style Customization for active Item in Blazor Tabs Component

The style of tabs can be customized by overriding its header and active tab CSS classes. Define HTML string for adding animation and customizing the tab header and pass it to [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.TabHeader.html#Syncfusion_Blazor_Navigations_TabHeader_Text) property. Now you can override the style using custom CSS classes added to the tab elements.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfTab CssClass="e-tab-custom-class">
    <TabItems>
        <TabItem Content="Andrew received his BTS commercial in 1974 and a Ph.D. in international marketing from the University of Dallas in 1981.He is fluent in French and Italian and reads German.He joined the company as a sales representative, was promoted to sales manager in January 1992 and to vice president of sales in March 1993.Andrew is a member of the Sales Management Roundtable, the Seattle Chamber of Commerce, and the Pacific Rim Importers Association.">
            <HeaderTemplate>
                <img class="emp" src="https://ej2.syncfusion.com/aspnetcore/css/tab/8.png"/>
                <div class="e-title fade-in">Andrew</div>
            </HeaderTemplate>
        </TabItem>
        <TabItem Content="Margaret holds a BA in English literature from Concordia College (1958) and an MA from the American Institute of Culinary Arts (1966).She was assigned to the London office temporarily from July through November 1992.">
            <HeaderTemplate>
                <img class="emp" src="https://ej2.syncfusion.com/aspnetcore/css/tab/1.png"/>
                <div class="e-title fade-in">Margaret</div>
            </HeaderTemplate>
        </TabItem>
        <TabItem Content="Janet has a BS degree in chemistry from Boston College (1984).She has also completed a certificate program in food retailing management.Janet was hired as a sales associate in 1991 and promoted to sales representative in February 1992.">
            <HeaderTemplate>
                <img class="emp" src="https://ej2.syncfusion.com/aspnetcore/css/tab/2.png"/>
                <div class="e-title fade-in">Janet</div>
            </HeaderTemplate>
        </TabItem>
    </TabItems>
</SfTab>

<style>
    .e-toolbar-item.e-active .e-tab-wrap .emp {
        display: none;
    }

    .e-content .e-item {
        font-size: 12px;
        margin: 10px;
        text-align: justify;
    }

    .e-image {
        background-size: 33px;
        width: 33px;
        height: 30px;
        margin: 0 auto;
    }

    .e-tab .e-toolbar-item .e-title {
        display: none;
    }

    .e-toolbar .e-toolbar-items .e-toolbar-item:not(.e-separator),
    .e-toolbar .e-toolbar-items .e-toolbar-item .e-tab-wrap {
        width: 105px;
        height: 50px;
    }

    .e-tab .e-tab-header .e-toolbar-items .e-active .e-tab-wrap {
        background-color: #08c;
    }
    .e-tab .e-tab-header {
        background-color: #e6e6e6;
    }
    .e-tab .e-tab-header .e-toolbar-item:not(.e-active) .e-tab-wrap:hover {
    background-color: #f2f2f2;
    color:#000;
    }
    .e-tab .e-toolbar .e-toolbar-items .e-toolbar-item .e-text-wrap {
        height: 50px;
    }

    .e-tab .e-toolbar-items .e-active .e-image {
        display: none;
    }

    .e-tab .e-toolbar-items .e-active .e-title {
        display: block;
        color: white;
    }

    .e-tab .e-toolbar-item .e-text-wrap,
    .e-tab .e-toolbar-item .e-tab-text {
        width:  inherit;
        text-align: center;
    }

    .fade-in {
        opacity: 1;
        animation-name: fadeInOpacity;
        animation-iteration-count: 1;
        animation-timing-function: ease-in;
        animation-duration: 0.5s;
    }

    @@keyframes fadeInOpacity {
        0% {
            opacity: 0;
        }
        100% {
            opacity: 1;
        }
    }
</style>
```

![Customizing active tabitem in Blazor Tabs](../images/blazor-tabs-custom-active-tabitem.png)