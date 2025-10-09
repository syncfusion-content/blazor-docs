---
layout: post
title:  Blazor Spinner Component Integration | Syncfusion
description: Check out and learn about integrating the Syncfusion Blazor Spinner component with other Blazor components, including usage within Tab and more.
platform: Blazor
control: Spinner
documentation: ug
---

# Blazor Spinner Component Integration

The Spinner component can be integrated with other Blazor components. The following example shows the Spinner rendered inside the Blazor Tab component. The Spinner is added as a child of the Tab and is shown while switching tabs and hidden after the tab content is loaded.

```cshtml

@using Syncfusion.Blazor.Spinner
@using Syncfusion.Blazor.Navigations

<div>
    <div id="tab_container">
        <SfTab ID="tab">
            <TabItems>
                <TabItem>
                    <ChildContent>
                        <TabHeader Text="Twitter"></TabHeader>
                    </ChildContent>
                    <ContentTemplate>
                        <p>Twitter is an online social networking service that enables users to send and read short 140-character messages called tweets. Registered users can read and post tweets, but those who are unregistered can only read them. Users access Twitter through the website interface, SMS or mobile device app Twitter Inc. is based in SanFrancisco and has more than 25 offices around the world. Twitter was created in March 2006 by Jack Dorsey, Evan Williams, Biz Stone, and Noah Glass and launched in July 2006.  The service rapidly gained worldwide popularity, with more than 100 million users posting 340 million tweets a day in 2012.  The service also handled 1.6 billionsearch queries per day.</p>
                    </ContentTemplate>
                </TabItem>
                <TabItem>
                    <ChildContent>
                        <TabHeader Text="Facebook"></TabHeader>
                    </ChildContent>
                    <ContentTemplate>
                        <p>
                            Facebook is an online social networking service headquartered in Menlo Park, California. Its website was launched on February 4, 2004, by Mark Zuckerberg with his Harvard College roommates and fellow students EduardoSaverin, Andrew McCollum, Dustin Moskovitz and Chris Hughes.  The founders had initially limited the website membership to Harvard students, but later expanded it to colleges in the Boston area, the Ivy League, and Stanford University. It gradually added support for students at various other universities and later to high-school students.
                        </p>
                    </ContentTemplate>
                </TabItem>
                <TabItem>
                    <ChildContent>
                        <TabHeader Text="Whatsapp"></TabHeader>
                    </ChildContent>
                    <ContentTemplate>
                        <p>WhatsApp Messenger is a proprietary cross-platform instant messaging client for smartphones that operates under a subscription business model.  It uses the Internet to send text messages, images, video, user location andaudio media messages to other users using standard cellular mobile numbers.  As of February 2016, WhatsApp had a userbase of up to one billion,[10] making it the most globally popular messaging application WhatsApp Inc., based inMountain View, California, was acquired by Facebook Inc. on February 19, 2014, for approximately US $19.3 billion.</p>
                    </ContentTemplate>
                </TabItem>
            </TabItems>
            <TabEvents Selecting="@Selecting" Selected="@Selected"></TabEvents>
            <SfSpinner @bind-Visible="@VisibleProperty">
            </SfSpinner>
        </SfTab>
    </div>
</div>

@code{
    private bool VisibleProperty { get; set; } = false;

    private async Task Selected(SelectEventArgs args)
    {
        await Task.Delay(2000);
        this.VisibleProperty = false;
    }

    private void Selecting(SelectingEventArgs args)
    {
        this.VisibleProperty = true;
    }
}
<style>
    .e-content .e-item {
        font-size: 12px;
        padding: 10px;
        text-align: justify;
    }

    .e-tab .e-tab-icon {
        font-family: 'Socialicons' !important;
    }

    .e-tab .e-icons.e-tab-icon {
        position: relative;
        top: 1px;
    }
</style>

```

![Blazor Tab showing a Spinner during tab content load](./images/blazor-tab-spinner.png)

## See also
* [How to prevent focus on the controls beneath the overlay of the Blazor spinner?](https://support.syncfusion.com/kb/article/11568/how-to-prevent-focus-on-the-controls-beneath-the-overlay-of-the-blazor-spinner-)