---
layout: post
title: HTML Attribute Support in Blazor ListView Component | Syncfusion
description: Checkout and learn here all about HTML Attribute Support in Syncfusion Blazor ListView component and more.
platform: Blazor
control: Button
documentation: ug
---

# HTML Attribute Support in Blazor ListView Component

The Blazor ListView component allows you to apply standard HTML attributes such as **id**, **style**, **title**, and more. These attributes can be set in two ways:

* Directly on the component tag – by specifying the attributes as part of the ListView element.

* Using the [HtmlAttributes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Lists.SfListView-1.html#Syncfusion_Blazor_Lists_SfListView_1_HtmlAttributes) property – by assigning a dictionary of attribute name-value pairs.

## Using the HtmlAttributes Property

You can assign one or more HTML attributes by using the [HtmlAttributes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Lists.SfListView-1.html#Syncfusion_Blazor_Lists_SfListView_1_HtmlAttributes) property, which accepts a Dictionary<string, object>.

```csharp

@using Syncfusion.Blazor.Lists

<SfListView DataSource="@Data"
            HtmlAttributes="@(new Dictionary<string, object> 
            {
                { "id", "ListView" }, 
                { "style", "background:#f1e30a; width:350px" },
                { "title", "List of Items" } 
            })">
    <ListViewFieldSettings TValue="DataModel" Id="Id" Text="Text"></ListViewFieldSettings>
</SfListView>

@code {
    private DataModel[] Data =
    {
        new DataModel { Text = "ArtWork", Id = "list-01" },
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
    }
}

```

## Directly Setting HTML Attributes in the Component Tag

HTML attributes can also be added directly to the SfListView tag, similar to standard HTML elements.

```csharp

@using Syncfusion.Blazor.Lists

<SfListView DataSource="@Data" id="ListView" style="background:#f1e30a; width:350px" title="List of Items">
    <ListViewFieldSettings TValue="DataModel" Id="Id" Text="Text"></ListViewFieldSettings>
</SfListView>

@code {
    private DataModel[] Data =
    {
        new DataModel { Text = "ArtWork", Id = "list-01" },
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
    }
}

```

![Blazor ListView with HTML Attribute](./../images/blazor-listview-with-html.png)