---
layout: post
title: Enable/Disable Tab item in Blazor Tabs Component | Syncfusion
description: Checkout and learn here all about how to enable/disable tab item in Syncfusion Blazor Tabs component and more.
platform: Blazor
control: Tabs
documentation: ug
---

# Enable/Disable Tab Item in Blazor Tabs Component

The [`Disabled`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.TabItem.html#Syncfusion_Blazor_Navigations_TabItem_Disabled) property of a `TabItem` is used to enable or disable the item. Setting it to `true` disables the item, while setting it to `false` enables it.

In the following demo, the first tab item is dynamically enabled and disabled when the **Enable/Disable First Item** button is clicked.

```cshtml

@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<SfButton IsPrimary="true" @onclick="EnableItemClick" Content="Enable/Disable First Item"></SfButton>
<br />
<br />

<SfTab>
    <TabItems>
        <TabItem Disabled=@IsEnable Content="Twitter is an online social networking service that enables users to send and read short 140-charactermessages called tweets.Registered users can read and post tweets, but those who are unregistered can only readthem.Users access Twitter through the website interface, SMS or mobile device app Twitter Inc. is based in SanFrancisco and has more than 25 offices around the world.Twitter was created in March 2006 by Jack Dorsey,Evan Williams, Biz Stone, and Noah Glass and launched in July 2006. The service rapidly gained worldwide popularity,with more than 100 million users posting 340 million tweets a day in 2012.The service also handled 1.6 billionsearch queries per day.">
            <ChildContent>
                <TabHeader Text="Twitter"></TabHeader>
            </ChildContent>
        </TabItem>
        <TabItem Content="Facebook is an online social networking service headquartered in Menlo Park, California. Its website waslaunched on February 4, 2004, by Mark Zuckerberg with his Harvard College roommates and fellow students EduardoSaverin, Andrew McCollum, Dustin Moskovitz and Chris Hughes.">
            <ChildContent>
                <TabHeader Text="Facebook"></TabHeader>
            </ChildContent>
        </TabItem>
        <TabItem Content="WhatsApp Messenger is a proprietary cross-platform instant messaging client for smartphones that operatesunder a subscription business model.It uses the Internet to send text messages, images, video, user location andaudio media messages to other users using standard cellular mobile numbers. As of February 2016, WhatsApp had a userbase of up to one billion,[10] making it the most globally popular messaging application.WhatsApp Inc., based inMountain View, California, was acquired by Facebook Inc.on February 19, 2014, for approximately US$19.3 billion.">
            <ChildContent>
                <TabHeader Text="Whatsapp"></TabHeader>
            </ChildContent>
        </TabItem>
    </TabItems>
</SfTab>

@code {
    public bool IsEnable { get; set; } = false;
    public void EnableItemClick()
    {
        IsEnable = !IsEnable;
    }
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hNLSitjufnGereTQ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Enabling or Disabling TabItem in Blazor Tabs](../images/blazor-tabs-enable-disable-tabitem.gif)