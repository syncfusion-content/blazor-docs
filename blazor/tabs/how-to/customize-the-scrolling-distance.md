---
layout: post
title: Customize the Scrolling Distance in Blazor Tabs Component | Syncfusion
description: Checkout and learn here all about how to customize the scrolling distance in Syncfusion Blazor Tabs component and more.
platform: Blazor
control: Tabs
documentation: ug
---

# Customize the Scrolling Distance in Blazor Tabs Component

The [`ScrollStep`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfTab.html#Syncfusion_Blazor_Navigations_SfTab_ScrollStep) property customizes the scrolling distance when the left and right navigation icons are clicked. A desired value can be assigned to the `ScrollStep` property to fine-tune tab scrolling behavior.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfTab Width="400px" OverflowMode="OverflowMode.Scrollable" ScrollStep="150">
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

@code{
    public string Content0 = "HyperText Markup Language, commonly referred to as HTML, is the standard markup language used to create webpages.Along with CSS, and JavaScript, HTML is a cornerstone technology, used by most websites to create visuallyengaging web pages, user interfaces for web applications, and user interfaces for many mobile applications.[1] Webbrowsers can read HTML files and render them into visible or audible web pages.HTML describes the structure of awebsite semantically along with cues for presentation, making it a markup language, rather than a programming language.";

    public string Content1 = "C# is intended to be a simple, modern, general-purpose, object-oriented programming language. Its developmentteam is led by Anders Hejlsberg.The most recent version is C# 5.0, which was released on August 15, 2012.";

    public string Content2 = "Java is a set of computer software and specifications developed by Sun Microsystems, later acquired by OracleCorporation, that provides a system for developing application software and deploying it in a cross - platform computingenvironment.Java is used in a wide variety of computing platforms from embedded devices and mobile phones toenterprise servers and supercomputers.While less common, Java applets run in secure, sandboxed environments toprovide many features of native applications and can be embedded in HTML pages.";

    public string Content3 = "The command-line compiler, VBC.EXE, is installed as part of the freeware .NET Framework SDK. Mono alsoincludes a command - line VB.NET compiler.The most recent version is VB 2012, which was released on August 15, 2012.";

    public string Content4 = "Xamarin is a San Francisco, California based software company created in May 2011[3] by the engineers that created Mono,[4] Monofor Android and MonoTouch that are cross-platform implementations of the Common Language Infrastructure (CLI) and Common LanguageSpecifications (often called Microsoft .NET). With a C#-shared codebase, developers can use Xamarin tools to write native Android,iOS, and Windows apps with native user interfaces and share code across multiple platforms.[5] Xamarin has over 1 million developersin more than 120 countries around the World as of May 2015.";

    public string Content5 = "ASP.NET is an open-source server-side web application framework designed for web development to producedynamic web pages.It was developed by Microsoft to allow programmers to build dynamic web sites, web applicationsand web services.It was first released in January 2002 with version 1.0 of the.NET Framework, and is the successorto Microsoft Active Server Pages(ASP) technology.ASP.NET is built on the Common Language Runtime(CLR), allowingprogrammers to write ASP.NET code using any supported .NET language. The ASP.NET SOAP extension framework allowsASP.NET components to process SOAP messages.";

    public string Content6 = "The ASP.NET MVC is a web application framework developed by Microsoft, which implements themodel–view–controller(MVC) pattern.It is open - source software, apart from the ASP.NET Web Forms component which isproprietary.In the later versions of ASP.NET, ASP.NET MVC, ASP.NET Web API, and ASP.NET Web Pages(a platform usingonly Razor pages) will merge into a unified MVC 6.The project is called ASP.NET Next.";
    
    public string Content7 = "JavaScript (JS) is an interpreted computer programming language. It was originally implemented as part ofweb browsers so that client - side scripts could interact with the user, control the browser, communicateasynchronously, and alter the document content that was displayed.[5] More recently, however, it has become common inboth game development and the creation of desktop applications.";
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNBSitjufndwEitI?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Customizing Scrolling TabItems in Blazor Tabs](../images/blazor-tabs-custom-scroll.gif)