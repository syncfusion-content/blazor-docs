---
layout: post
title: HTML Attribute Support in Blazor ListView Component | Syncfusion
description: Checkout and learn here all about HTML Attribute Support in Syncfusion Blazor ListView component and more.
platform: Blazor
control: ListView
documentation: ug
---

# HTML Attribute Support in Blazor ListView Component

HTML attribute support is given for ListView using [HtmlAttributes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Lists.SfListView-1.html#Syncfusion_Blazor_Lists_SfListView_1_HtmlAttributes) property. 

In the below code, we set the particular list item height in the ListView to be larger than the other items using the [HtmlAttributes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Lists.SfListView-1.html#Syncfusion_Blazor_Lists_SfListView_1_HtmlAttributes) property.

```csharp

@using Syncfusion.Blazor.Lists

<SfListView DataSource="@Data">
    <ListViewFieldSettings TValue="DataModel" Id="Id" HtmlAttributes="HtmlAttributes" Text="Text"></ListViewFieldSettings>
</SfListView>

@code
{
    private DataModel[] Data =
     {
        new DataModel { Text = "ArtWork", Id = "list-01" ,
        HtmlAttributes = new Dictionary<string, object>(){  { "class", "firstItem" } } },
        new DataModel { Text = "Abstract", Id = "list-02" },
        new DataModel { Text = "Modern Painting", Id = "list-03" },
        new DataModel { Text = "Ceramics", Id = "list-04" },
        new DataModel { Text = "Animation Art", Id = "list-05" },
        new DataModel { Text = "Oil Painting", Id = "list-06" }
    };
    public class DataModel
    {
        public string Text { get; set; }
        public string Id { get; set; }
        public Dictionary<string, object> HtmlAttributes { get; set; }
    }
}
<style>
    .firstItem{
        height:70px !important;
    }
</style>

```