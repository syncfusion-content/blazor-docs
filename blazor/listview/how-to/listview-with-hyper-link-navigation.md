---
layout: post
title: Blazor ListView Component with hyper-link navigation | Syncfusion
description: Checkout and learn here all about Blazor ListView Component with hyper-link navigation and much more.
platform: Blazor
control: Listview
documentation: ug
---

# Blazor ListView Component with hyper-link navigation

The `anchor` tag can be used along with `href` attribute in the ListView [`Template`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Lists.ListViewTemplates-1.html#Syncfusion_Blazor_Lists_ListViewTemplates_1_Template) property for navigation.

```cshtml
@using Syncfusion.Blazor.Lists

<div id="container">
    <div id="sample">
        <SfListView ID="list" DataSource="@DataSource">
            <ListViewFieldSettings TValue="ListDataModel" Id="Id" Text="Name"></ListViewFieldSettings>
            <ListViewTemplates TValue="ListDataModel">
                <Template>
                    <a target='_blank' href="@((context as ListDataModel).Url)">
                        @((context as ListDataModel).Name)
                    </a>
                </Template>
            </ListViewTemplates>
        </SfListView>
    </div>
</div>

@code
{
    List<ListDataModel> DataSource = new List<ListDataModel>() {
        new ListDataModel {
            Id = "1",
            Name = "Google",
            Url = "https://www.google.com"
        },
        new ListDataModel {
            Id = "2",
            Name = "Bing",
            Url = "https://www.bing.com"
        },
        new ListDataModel {
            Id = "3",
            Name = "Yahoo",
            Url = "https://www.yahoo.com"
        },
        new ListDataModel {
            Id = "4",
            Name = "Ask.com",
            Url = "https://www.ask.com"
        },
        new ListDataModel {
            Id = "5",
            Name = "AOL.com",
            Url = "https://www.aol.com"
        }
    };

    public class ListDataModel
    {
        public string Id
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public string Url
        {
            get;
            set;
        }
    }
}

<style>
    #list {
        box-shadow: 0 1px 4px #ddd;
        border-bottom: 1px solid #ddd;
    }

    #sample {
        height: 220px;
        margin: 0 auto;
        display: block;
        max-width: 350px;
    }
</style>
```

![Blazor ListView with Hyperlink](../images/list/blazor-listview-with-hyperlink.png)
