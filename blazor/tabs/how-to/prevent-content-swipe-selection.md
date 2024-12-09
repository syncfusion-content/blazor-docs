---
layout: post
title: Prevent content swipe selection in Blazor Tabs Component | Syncfusion
description: Checkout and learn here all about how to prevent content swipe selection in Syncfusion Blazor Tabs component and more.
platform: Blazor
control: Tabs
documentation: ug
---

# Prevent content swipe selection in Blazor Tabs Component

The tab selection can be prevented on touch swipe action by using the Tab [Selecting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.TabEvents.html#Syncfusion_Blazor_Navigations_TabEvents_Selecting) event.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfTab>
    <TabEvents Selecting="Select">
    </TabEvents>
    <TabItems>
        <TabItem Content="Twitter is an online social networking service that enables users to send and read short 140-charactermessages called tweets.Registered users can read and post tweets, but those who are unregistered can only readthem.Users access Twitter through the website interface, SMS or mobile device app Twitter Inc. is based in SanFrancisco and has more than 25 offices around the world.Twitter was created in March 2006 by Jack Dorsey,Evan Williams, Biz Stone, and Noah Glass and launched in July 2006. The service rapidly gained worldwide popularity,with more than 100 million users posting 340 million tweets a day in 2012.The service also handled 1.6 billionsearch queries per day.">
            <ChildContent>
                <TabHeader Text="Twitter">
                </TabHeader>
            </ChildContent>
        </TabItem>
        <TabItem Content="Facebook is an online social networking service headquartered in Menlo Park, California. Its website waslaunched on February 4, 2004, by Mark Zuckerberg with his Harvard College roommates and fellow students EduardoSaverin, Andrew McCollum, Dustin Moskovitz and Chris Hughes.">
            <ChildContent>
                <TabHeader Text="Facebook">
                </TabHeader>
            </ChildContent>
        </TabItem>
        <TabItem Content="WhatsApp Messenger is a proprietary cross-platform instant messaging client for smartphones that operatesunder a subscription business model.It uses the Internet to send text messages, images, video, user location andaudio media messages to other users using standard cellular mobile numbers. As of February 2016, WhatsApp had a userbase of up to one billion,[10] making it the most globally popular messaging application.WhatsApp Inc., based inMountain View, California, was acquired by Facebook Inc.on February 19, 2014, for approximately US$19.3 billion.">
            <ChildContent>
                <TabHeader Text="WhatsApp">
                </TabHeader>
            </ChildContent>
        </TabItem>
    </TabItems>
</SfTab>

@code {
    public void Select(SelectingEventArgs args)
    {
        if(args.IsSwiped)
        {
            args.Cancel = true;
        }
    }
}
```


## Swipe modes

In the tab, the [`SwipeMode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfTab.html#Syncfusion_Blazor_Navigations_SfTab_SwipeMode) property allows specifying whether the tab transition should occur while performing swiping via touch or mouse. The tab swiping is enabled or disabled using the bitwise operator.

The following are the different swipe modes available in the tab:

* [`TabSwipeMode.Touch`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.TabSwipeMode.html) - Allows the user to swipe the tabs using touch actions.
* [`TabSwipeMode.Mouse`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.TabSwipeMode.html) - Allows the user to swipe the tabs using mouse actions.
* [`TabSwipeMode.Touch & TabSwipeMode.Mouse`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.TabSwipeMode.html) - Allows the user to swipe the tabs using both touch and mouse actions.
* [`~TabSwipeMode.Touch & ~TabSwipeMode.Mouse`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.TabSwipeMode.html) - Disables both touch and mouse actions.

```cshtml
<SfTab SwipeMode="TabSwipeMode.Touch">
    <TabItems>
        <TabItem Content="India officially the Republic of India, is a country in South Asia. It is the seventh-largest country by area, the second-most populous country with over 1.2 billion people, and the most populous democracy in the world. Bounded by the Indian Ocean on the south, the Arabian Sea on the south-west, and the Bay of Bengal on the south-east, it shares land borders with Pakistan to the west;China, Nepal, and Bhutan to the north-east; and Burma and Bangladesh to the east. In the Indian Ocean, India is in the vicinity of Sri Lanka and the Maldives; in addition, India Andaman and Nicobar Islands share a maritime border with Thailand and Indonesia.">
            <ChildContent>
                <TabHeader Text="India"></TabHeader>
            </ChildContent>
        </TabItem>
        <TabItem Content="Australia, officially the Commonwealth of Australia, is a country comprising the mainland of the Australian continent, the island of Tasmania and numerous smaller islands. It is the world sixth-largest country by total area. Neighboring countries include Indonesia, East Timor and Papua New Guinea to the north; the Solomon Islands, Vanuatu and New Caledonia to the north-east; and New Zealand to the south-east.">
            <ChildContent>
                <TabHeader Text="Australia"></TabHeader>
            </ChildContent>
        </TabItem>
        <TabItem Content="The United States of America (USA or U.S.A.), commonly called the United States (US or U.S.) and America, is a federal republic consisting of fifty states and a federal district. The 48 contiguous states and the federal district of Washington, D.C. are in central North America between Canada and Mexico. The state of Alaska is west of Canada and east of Russia across the Bering Strait, and the state of Hawaii is in the mid-North Pacific. The country also has five populated and nine unpopulated territories in the Pacific and the Caribbean.">
            <ChildContent>
                <TabHeader Text="USA"></TabHeader>
            </ChildContent>
        </TabItem>
    </TabItems>
</SfTab>
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/LXhJWBXRTkcUTrZj?appbar=true&editor=true&result=true&errorlist=true&theme=bootstrap5" %}