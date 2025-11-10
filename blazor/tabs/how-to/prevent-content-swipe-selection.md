---
layout: post
title: Prevent content swipe selection in Blazor Tabs Component | Syncfusion
description: Checkout and learn here all about how to prevent content swipe selection in Syncfusion Blazor Tabs component and more.
platform: Blazor
control: Tabs
documentation: ug
---


# Prevent content swipe selection in Blazor Tabs Component

The [`SwipeMode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfTab.html#Syncfusion_Blazor_Navigations_SfTab_SwipeMode)  property in the Tab component allows users to navigate between tabs using swipe gestures, improving the overall navigation experience. It supports both touch and mouse inputs, enabling intuitive tab switching.

However, in certain cases, such as when a tab contains critical elements like a form, accidental swipes can disrupt the user's workflow. For example, if a user is filling out a form and mistakenly swipes, the tab might change unexpectedly, potentially leading to unsaved data or interruptions.

To address this, you can customize the [`SwipeMode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfTab.html#Syncfusion_Blazor_Navigations_SfTab_SwipeMode) property based on the needs of the application. By adjusting this setting, you can balance smooth, intuitive navigation with protecting the user experience and safeguarding against accidental tab switches.

The following are the available [`SwipeMode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfTab.html#Syncfusion_Blazor_Navigations_SfTab_SwipeMode) options for the Tab component:

* [`TabSwipeMode.Touch & TabSwipeMode.Mouse`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.TabSwipeMode.html) - By default, this option allows the user to swipe between tabs using both touch and mouse actions.
* [`TabSwipeMode.Touch`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.TabSwipeMode.html) - This option allows users to swipe between tabs using touch gestures only.
* [`TabSwipeMode.Mouse`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.TabSwipeMode.html) - This option allows users to swipe between tabs using mouse gestures only.
* [`~TabSwipeMode.Touch & ~TabSwipeMode.Mouse`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.TabSwipeMode.html) - This disables both touch and mouse swipe actions, preventing any unintended tab switches.

```cshtml
<SfTab SwipeMode="~TabSwipeMode.Touch & ~TabSwipeMode.Mouse">
    <TabItems>
        <TabItem>
            <HeaderTemplate>India</HeaderTemplate>
            <ContentTemplate>
                <div>
                    India officially the Republic of India, is a country in South Asia. It is the seventh-largest country by area, the second-most populous country with over 1.2 billion people, and the most populous democracy in the world. Bounded by the Indian Ocean on the south, the Arabian Sea on the south-west, and the Bay of Bengal on the south-east, it shares land borders with Pakistan to the west;China, Nepal, and Bhutan to the north-east; and Burma and Bangladesh to the east. In the Indian Ocean, India is in the vicinity of Sri Lanka and the Maldives; in addition, India Andaman and Nicobar Islands share a maritime border with Thailand and Indonesia.
                </div>
            </ContentTemplate>
        </TabItem>        
        <TabItem>
            <HeaderTemplate>Australia</HeaderTemplate>
            <ContentTemplate>
                <div>
                    Australia, officially the Commonwealth of Australia, is a country comprising the mainland of the Australian continent, the island of Tasmania and numerous smaller islands. It is the world sixth-largest country by total area. Neighboring countries include Indonesia, East Timor and Papua New Guinea to the north; the Solomon Islands, Vanuatu and New Caledonia to the north-east; and New Zealand to the south-east.
                </div>
            </ContentTemplate>
        </TabItem>        
        <TabItem>
            <HeaderTemplate>USA</HeaderTemplate>
            <ContentTemplate>
                <div>
                    The United States of America (USA or U.S.A.), commonly called the United States (US or U.S.) and America, is a federal republic consisting of fifty states and a federal district. The 48 contiguous states and the federal district of Washington, D.C. are in central North America between Canada and Mexico. The state of Alaska is west of Canada and east of Russia across the Bering Strait, and the state of Hawaii is in the mid-North Pacific. The country also has five populated and nine unpopulated territories in the Pacific and the Caribbean.
                </div>
            </ContentTemplate>
        </TabItem>       
        <TabItem>
            <HeaderTemplate>France</HeaderTemplate>
            <ContentTemplate>
                <div>
                    France, officially the French Republic is a sovereign state comprising territory in western Europe and several overseas regions and territories. The European part of France, called Metropolitan France, extends from the Mediterranean Sea to the English Channel and the North Sea, and from the Rhine to the Atlantic Ocean; France covers 640,679 square kilo metres and as of August 2015 has a population of 67 million, counting all the overseas departments and territories.
                </div>
            </ContentTemplate>
        </TabItem>
    </TabItems>
</SfTab>
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjLzsrsrTlqFIhjX?appbar=true&editor=true&result=true&errorlist=true&theme=bootstrap5" %}