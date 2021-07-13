---
layout: post
title: How to Create Collapsible Tabs in Blazor Tabs Component | Syncfusion
description: Checkout and learn about Create Collapsible Tabs in Blazor Tabs component of Syncfusion, and more details.
platform: Blazor
control: Tabs
documentation: ug
---

# Create collapsible Tabs

You can achieve collapse and expand functionality in Tab by adding/removing a custom CSS class in the click event handler for each tab.

* Define a CSS class to set the style property display as none. Here 'collapse' class is added to the content element for hiding it.
* Bind the `select`  event for Tab to collapse the initially selected Tab item and bind custom click handler for the Tab headers.
* In the event handler, add and remove 'collapse' class to hide and show the corresponding Tab content.

```csharp

@using Syncfusion.Blazor.Navigations

<div class="info">
    Collapsible Tabs
</div>
<span style="margin: 10px;">
    <i>The active tab can be toggled to expand and collapse its content.</i>
</span>

<SfTab id="BlazorTab" cssClass="e-background" Selected="@tabSelected">
    <TabItems>
        <TabItem Header="header0" Content="@content0"></TabItem>
        <TabItem Header="header1" Content="@content1"></TabItem>
        <TabItem Header="header2" Content="@content2"></TabItem>
    </TabItems>
</SfTab>

<style>
    #container {
        visibility: hidden;
    }

    #loader {
        color: #008cff;
        height: 40px;
        left: 45%;
        position: absolute;
        top: 45%;
        width: 30%;
    }

    .e-content .e-item {
        font-size: 12px;
        margin: 10px;
        text-align: justify;
    }

    .container {
        min-width: 350px;
        margin: 0 10px;
    }

    .info {
        margin: 10px;
        font-weight: bold;
    }

    #BlazorTab.e-tab .e-content > .e-item.e-active.collapse {
        display: none;
    }

    #BlazorTab.e-tab .e-tab-header .e-indicator.collapse {
        display: none;
    }
</style>


@code {
    public object header0 = new { text = "Twitter" };
    public object header1 = new { text = "Facebook" };
    public object header2 = new { text = "Whatsapp" };

    public string content0 = "Twitter is an online social networking service that enables users to send and read short 140-character " +
            "messages called 'tweets'. Registered users can read and post tweets, but those who are unregistered can only read " +
            "them. Users access Twitter through the website interface, SMS or mobile device app Twitter Inc. is based in San " +
            "Francisco and has more than 25 offices around the world. Twitter was created in March 2006 by Jack Dorsey, " +
            "Evan Williams, Biz Stone, and Noah Glass and launched in July 2006. The service rapidly gained worldwide popularity, " +
            "with more than 100 million users posting 340 million tweets a day in 2012.The service also handled 1.6 billion " +
            "search queries per day.";
    public string content1 = "Facebook is an online social networking service headquartered in Menlo Park, California. Its website was " +
            "launched on February 4, 2004, by Mark Zuckerberg with his Harvard College roommates and fellow students Eduardo " +
            "Saverin, Andrew McCollum, Dustin Moskovitz and Chris Hughes.The founders had initially limited the website  " +
            "membership to Harvard students, but later expanded it to colleges in the Boston area, the Ivy League, and Stanford " +
            "University. It gradually added support for students at various other universities and later to high-school students.";
    public string content2 = "WhatsApp Messenger is a proprietary cross-platform instant messaging client for smartphones that operates " +
            "under a subscription business model. It uses the Internet to send text messages, images, video, user location and " +
            "audio media messages to other users using standard cellular mobile numbers. As of February 2016, WhatsApp had a user  " +
            "base of up to one billion,[10] making it the most globally popular messaging application. WhatsApp Inc., based in " +
            "Mountain View, California, was acquired by Facebook Inc. on February 19, 2014, for approximately US$19.3 billion.";
    public void tabSelected(SelectEventArgs args)
    {

    }

}
```