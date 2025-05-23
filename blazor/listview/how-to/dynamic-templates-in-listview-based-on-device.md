---
layout: post
title: Use dynamic templates in Blazor ListView based on device | Syncfusion
description: Learn here all about using dynamic templates in syncfusion blazor listview based on device and more.
platform: Blazor
control: Listview
documentation: ug
---

# Use dynamic templates in Blazor ListView based on device

The Syncfusion<sup style="font-size:70%">&reg;</sup> Essential Blazor controls are desktop and mobile-friendly. So, you can use Syncfusion<sup style="font-size:70%">&reg;</sup> controls in both modes. The component templates are not always fixed. Applications may need to load various templates depending upon the device.

## Integration

In the ListView component, [`template`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Lists.ListViewTemplates-1.html) support is being used. In some cases, the component wrapper is always responsive across all devices, but the template contents are dynamically changed with unspecified (sample side) dimensions. CSS customization is also needed in sample-side to align template content responsively in both mobile and desktop modes. Here, two templates have been loaded for mobile and desktop modes. To check the device mode, use the **Microsoft.AspNetCore.Http** package and check for the **UserAgent** to detect mobile or desktop.

```cshtml
@using Syncfusion.Blazor.Lists
@using Microsoft.AspNetCore.Http
@inject IHttpContextAccessor httpContextAccessor

<div class="flex flex__center">
    <div class="margin">
        <SfListView DataSource="@DataSource"
                     ShowHeader="true"
                     HeaderTitle="Syncfusion Blog"
                     CssClass="e-list-template">
            <ListViewFieldSettings TValue="ListDataModel" Id="Id" Text="Name"></ListViewFieldSettings>
            <ListViewTemplates TValue="ListDataModel">
                <Template>
                    @{
                        ListDataModel item = context as ListDataModel;
                        <div class="post flex e-list-wrapper e-list-multi-line">
                            <div class="flex image vertical__center flex__1">
                                <img class="e-avatar" src="@item.Image" />
                            </div>
                            <div class="flex vertical flex__center flex__4">
                                <div class="flex">
                                    <div class="bold flex__1">@item.Name</div>
                                    @if (IsMobile)
                                    {
                                        <div id="list-logo">
                                            <span class="bookmark" title="We can customize this element to perform our own action"></span>
                                            <span class="comments" title="We can customize this element to perform our own action"></span>
                                            <span class="share" title="We can customize this element to perform our own action"></span>
                                        </div>
                                    }
                                </div>
                                <div class="small__font">@item.Content</div>
                                <div class="flex">
                                    <div class="timeStamp flex__1">@item.TimeStamp</div>
                                    @if (!IsMobile)
                                    {
                                        <div id="list-logo flex__2">
                                            <span class="bookmark" title="We can customize this element to perform our own action"></span>
                                            <span class="comments" title="We can customize this element to perform our own action"></span>
                                            <span class="share" title="We can customize this element to perform our own action"></span>
                                        </div>
                                    }
                                </div>
                            </div>
                        </div>
                    }
                </Template>
            </ListViewTemplates>
        </SfListView>
    </div>
</div>


@code
{
    bool IsMobile;
    List<ListDataModel> DataSource = new List<ListDataModel>()
    {
        new ListDataModel{ Name = "IBM Open-Sources Web Sphere Liberty Code", Content =  "In September, IBM announced that it would be open-sourcing the code for WebSphere...", Id =  "1", Image =  "https://ej2.syncfusion.com/demos/src/listview/images/1.png", TimeStamp =  "Syncfusion Blog - October 19, 2017" },
        new ListDataModel{ Name =  "Must Reads: 5 Big Data E-books to upend your development", Content =  "Our first e-book was published in May 2012-jQuery Succinctly was the start of over...", Id =  "2", Image =  "https://ej2.syncfusion.com/demos/src/listview/images/2.png", TimeStamp =  "Syncfusion Blog - October 18, 2017" },
        new ListDataModel{ Name =  "The Syncfusion Global License: Your Questions, Answered ", Content =  "Syncfusion recently hosted a webinar to cover the ins and outs of the Syncfusion global...", Id =  "4", Image =  "https://ej2.syncfusion.com/demos/src/listview/images/3.png", TimeStamp =  "Syncfusion Blog - October 18, 2017" },
        new ListDataModel{ Name =  "Know =  What is Coming from Microsoft this Fall ", Content =  "On October 17, Microsoft will release its Fall Creators Update for the Windows 10 platform...", Id =  "5", Image =  "https://ej2.syncfusion.com/demos/src/listview/images/6.png", TimeStamp =  "Syncfusion Blog - October 17, 2017"},
    };

    protected override void OnInitialized()
    {
        var userAgent = httpContextAccessor.HttpContext.Request.Headers["User-Agent"];
        IsMobile = (userAgent[0] as string).ToLower().Contains("mobile");
    }

    public class ListDataModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string TimeStamp { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
    }
}

<style>
    .flex {
        display: flex;
    }

    .flex__center {
        justify-content: center;
    }

    .vertical__center {
        align-items: center;
    }

    .vertical {
        flex-direction: column;
    }

    .flex__1 {
        flex: 1;
    }

    .flex__2 {
        flex: 2;
    }

    .flex__4 {
        flex: 4;
    }

    .bold {
        font-weight: 500;
    }

    .margin {
        margin: 10px;
        width: 350px;
    }

    .timeStamp {
        font-size: 10px;
        padding: 4px 0;
    }

    .small__font {
        font-size: 13px;
        margin: 2px 0;
    }

    .e-listview .bookmark::before {
        content: "\e700";
        font-size: 14px;
    }

    .e-listview .share::before {
        content: "\e701";
        font-size: 14px;
    }

    .e-listview .comments::before {
        content: "\e703";
        font-size: 14px;
    }

    .e-listview .bookmark::before,
    .e-listview .share::before,
    .e-listview .comments::before {
        color: grey;
        font-family: 'Bookmarks';
        margin-left: 3px;
        cursor: pointer;
    }

    @@font-face {
        font-family: 'Bookmarks';
        src: url(data:application/x-font-ttf;charset=utf-8;base64,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) format('truetype');
        font-weight: normal;
        font-style: normal;
    }
</style>

```

![Blazor ListView with Dynamic Layout](../images/list/blazor-listview-with-dynamic-layout.png)

N> Make sure to register the **builder.Services.AddHttpContextAccessor();** service in the **Program.cs** file. This is required to access the current HTTP context in your application.