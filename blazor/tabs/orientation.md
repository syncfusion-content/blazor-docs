---
layout: post
title: Orientation in Blazor Tabs Component | Syncfusion
description: Checkout and learn here all about orientation in Syncfusion Blazor Tabs component and much more details.
platform: Blazor
control: Tabs
documentation: ug
---

# Orientation in Blazor Tabs Component

This section explains how to modify the position and overflow modes of the Tab header.

It allows placing the header section inside the Tabs component at different positions by using the [HeaderPlacement](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfTab.html#Syncfusion_Blazor_Navigations_SfTab_HeaderPlacement) property. The available positions are as follows:

* **Top**: Tab header items can be arranged horizontally, and their content can be placed after the header.
* **Bottom**: Tab header items can be arranged horizontally, and their content can be placed before the header.
* **Left**: Tab header items can be arranged vertically, and their content can be placed after the header.
* **Right**: Tab header items can be arranged vertically, and their content can be placed before the header.

It is also adaptable to the available space when the tab items exceed the view space. The modes can be customized by using [OverflowMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfTab.html#Syncfusion_Blazor_Navigations_SfTab_OverflowMode) property. The available modes are as follows:

*   **Scrollable**: When tab items exceed the available space, a scrollbar appears, allowing horizontal or vertical scrolling depending on the `HeaderPlacement`.
*   **Popup**: When tab items exceed the available space, a "more" button appears (typically at the end of the header). Clicking this button opens a dropdown or popup displaying the hidden tab items.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.DropDowns

<SfTab ShowCloseButton="true" HeaderPlacement="@Header" OverflowMode="@Mode" Width="500px" Height="250px">
    <TabItems>
        <TabItem Content="@Content0">
            <ChildContent>
                <TabHeader Text="HTML"></TabHeader>
            </ChildContent>
        </TabItem>
        <TabItem Content="@Content1">
            <ChildContent>
                <TabHeader Text="C Sharp(C#)"></TabHeader>
            </ChildContent>
        </TabItem>
        <TabItem Content="@Content2">
            <ChildContent>
                <TabHeader Text="Java"></TabHeader>
            </ChildContent>
        </TabItem>
        <TabItem Content="@Content3">
            <ChildContent>
                <TabHeader Text="VB.Net"></TabHeader>
            </ChildContent>
        </TabItem>
        <TabItem Content="@Content4">
            <ChildContent>
                <TabHeader Text="Xamarin"></TabHeader>
            </ChildContent>
        </TabItem>
        <TabItem Content="@Content5">
            <ChildContent>
                <TabHeader Text="ASP.NET"></TabHeader>
            </ChildContent>
        </TabItem>
        <TabItem Content="@Content6">
            <ChildContent>
                <TabHeader Text="ASP.NET MVC"></TabHeader>
            </ChildContent>
        </TabItem>
        <TabItem Content="@Content7">
            <ChildContent>
                <TabHeader Text="JavaScript"></TabHeader>
            </ChildContent>
        </TabItem>
    </TabItems>
</SfTab>
<div class="col-md-4 property-section">
    <div class="property-panel-section">
        <div class="property-panel-header">Properties</div>
        <div class="property-panel-content">
            <table id="property" title="Properties" style="width: 100%" class="property-panel-table">
                <tbody>
                    <tr>
                        <td style="width: 50%;">
                            <div>Header Placement</div>
                        </td>
                        <td style="width: 50%;">
                            <div>
                                <SfDropDownList DataSource="@OrientationData" @bind-Value="@HeaderValue" TValue="string" TItem="DropdownFields">
                                    <DropDownListEvents ValueChange="OnHeaderPositionChange" TValue="string" TItem="DropdownFields"></DropDownListEvents>
                                    <DropDownListFieldSettings Value="Value" Text="Text"></DropDownListFieldSettings>
                                </SfDropDownList>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 50%;">
                            <div>Header Styles</div>
                        </td>
                        <td style="width: 50%;">
                            <div>
                                <SfDropDownList TValue="string" TItem="DropdownFields" DataSource="@TabModeData" @bind-Value="@ModeValue">
                                    <DropDownListEvents ValueChange="OnChangeMode" TValue="string" TItem="DropdownFields"></DropDownListEvents>
                                    <DropDownListFieldSettings Value="Value" Text="Text"></DropDownListFieldSettings>
                                </SfDropDownList>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</div>

@code {
    public string HeaderValue { get; set; } = "Top";
    public HeaderPosition Header { get; set; } = HeaderPosition.Top;
    public OverflowMode Mode { get; set; } = OverflowMode.Scrollable;
    public string ModeValue { get; set; } = "Scrollable";
    public string Content0 = "HyperText Markup Language, commonly referred to as HTML, is the standard markup language used to create webpages.Along with CSS, and JavaScript, HTML is a cornerstone technology, used by most websites to create visuallyengaging web pages, user interfaces for web applications, and user interfaces for many mobile applications.[1] Webbrowsers can read HTML files and render them into visible or audible web pages.HTML describes the structure of awebsite semantically along with cues for presentation, making it a markup language, rather than a programming language.";
    public string Content1 = "C# is intended to be a simple, modern, general-purpose, object-oriented programming language. Its developmentteam is led by Anders Hejlsberg.The most recent version is C# 5.0, which was released on August 15, 2012.";
    public string Content2 = "Java is a set of computer software and specifications developed by Sun Microsystems, later acquired by OracleCorporation, that provides a system for developing application software and deploying it in a cross - platform computingenvironment.Java is used in a wide variety of computing platforms from embedded devices and mobile phones toenterprise servers and supercomputers.While less common, Java applets run in secure, sandboxed environments toprovide many features of native applications and can be embedded in HTML pages.";
    public string Content3 = "The command-line compiler, VBC.EXE, is installed as part of the freeware .NET Framework SDK. Mono alsoincludes a command - line VB.NET compiler.The most recent version is VB 2012, which was released on August 15, 2012.";
    public string Content4 = "Xamarin is a San Francisco, California based software company created in May 2011[3] by the engineers that created Mono,[4] Monofor Android and MonoTouch that are cross-platform implementations of the Common Language Infrastructure (CLI) and Common LanguageSpecifications (often called Microsoft .NET). With a C#-shared codebase, developers can use Xamarin tools to write native Android,iOS, and Windows apps with native user interfaces and share code across multiple platforms.[5] Xamarin has over 1 million developersin more than 120 countries around the World as of May 2015.";
    public string Content5 = "ASP.NET is an open-source server-side web application framework designed for web development to producedynamic web pages.It was developed by Microsoft to allow programmers to build dynamic web sites, web applicationsand web services.It was first released in January 2002 with version 1.0 of the.NET Framework, and is the successorto Microsoft Active Server Pages(ASP) technology.ASP.NET is built on the Common Language Runtime(CLR), allowingprogrammers to write ASP.NET code using any supported .NET language. The ASP.NET SOAP extension framework allowsASP.NET components to process SOAP messages.";
    public string Content6 = "The ASP.NET MVC is a web application framework developed by Microsoft, which implements themodel–view–controller(MVC) pattern.It is open - source software, apart from the ASP.NET Web Forms component which isproprietary.In the later versions of ASP.NET, ASP.NET MVC, ASP.NET Web API, and ASP.NET Web Pages(a platform usingonly Razor pages) will merge into a unified MVC 6.The project is called ASP.NET Next.";
    public string Content7 = "JavaScript (JS) is an interpreted computer programming language. It was originally implemented as part ofweb browsers so that client - side scripts could interact with the user, control the browser, communicateasynchronously, and alter the document content that was displayed.[5] More recently, however, it has become common inboth game development and the creation of desktop applications.";
    List<DropdownFields> OrientationData = new List<DropdownFields>()
    {
        new DropdownFields() { Value= "Top", Text= "Top" },
        new DropdownFields() { Value= "Bottom", Text= "Bottom" },
        new DropdownFields() { Value= "Left", Text= "Left" },
        new DropdownFields() { Value= "Right", Text= "Right" }
    };
    List<DropdownFields> TabModeData = new List<DropdownFields>()
    {
        new DropdownFields() { Value= "Scrollable", Text= "Scrollable" },
        new DropdownFields() { Value= "Popup", Text= "Popup" }
    };
    public void OnHeaderPositionChange(Syncfusion.Blazor.DropDowns.ChangeEventArgs<string, DropdownFields> args)
    {
        Header = (HeaderPosition)Enum.Parse(typeof(HeaderPosition), (args.Value as string));
    }
    public void OnChangeMode(Syncfusion.Blazor.DropDowns.ChangeEventArgs<string, DropdownFields> args)
    {
        Mode = (OverflowMode)Enum.Parse(typeof(OverflowMode), (args.Value as string));
    }
    public class DropdownFields
    {
        public string Value { get; set; }
        public string Text { get; set; }
    }
}

<style>
    .e-content .e-item {
        font-size: 12px;
        padding: 10px;
        text-align: justify;
    }
</style>
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXBSWDMNWwjfHxnt?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Tabs with Horizontal Orientation](./images/blazor-tabs-orientation.gif)