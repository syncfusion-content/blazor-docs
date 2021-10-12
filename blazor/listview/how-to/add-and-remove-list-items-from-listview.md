---
layout: post
title: Add and remove list items in Blazor ListView Component | Syncfusion
description: Learn here all about adding and removing list items in Syncfusion Blazor ListView component and more.
platform: Blazor
control: Listview
documentation: ug
---

# Add and remove list items in Blazor ListView Component

You can add or remove list items from the ListView control using the `ObservableCollection`.

Refer to the following steps to add or remove a list item.

* Bind the `onclick` handler to the delete icon created in step 1. Within the click event, remove the list item by passing the
delete icon list item to `OnDelete` method.

```cshtml
@using Syncfusion.Blazor.Lists
@using System.Collections.ObjectModel

<div class="flex">
    <div class="margin">
        <SfListView ID="sample-list-flat" DataSource="@DataSource">
            <ListViewFieldSettings TValue="ListDataModel" Id="Id" Text="Text"></ListViewFieldSettings>
            <ListViewTemplates TValue="ListDataModel">
                <Template>
                    @{
                        ListDataModel item = context as ListDataModel;
                        <div class="text-content">
                            @item.Text
                            <span class="delete-icon" @onclick="@(() => { OnDelete(item); })"></span>
                        </div>
                    }
                </Template>
            </ListViewTemplates>
        </SfListView>
    </div>
</div>

<div class="flex">
    <button class="e-btn" @onclick="@AddItem">Add item</button>
</div>

@code
{

    ObservableCollection<ListDataModel> DataSource = new ObservableCollection<ListDataModel>()
    {
        new ListDataModel{ Id = "1", Text = "Artwork"},
        new ListDataModel{ Id = "2", Text = "Abstract"},
        new ListDataModel{ Id = "3", Text = "Modern Painting"},
        new ListDataModel{ Id = "4", Text = "Ceramics"},
        new ListDataModel{ Id = "5", Text = "Animation Art"},
        new ListDataModel{ Id = "6", Text = "Oil Painting"},
    };

    void OnDelete(ListDataModel listDataModel)
    {
        DataSource.RemoveAt(DataSource.ToList<ListDataModel>().FindIndex(e => e.Id == listDataModel.Id));
    }

    void AddItem()
    {
        var random = new Random();
        DataSource.Add(new ListDataModel
        {
            Id = random.Next(100, 300).ToString(),
            Text = "Item " + random.Next(100, 300).ToString(),
        });
    }

    public class ListDataModel
    {
        public string Id { get; set; }
        public string Text { get; set; }
    }

}

<style>
    .flex {
        display: flex;
        justify-content: center;
    }

    .margin {
        margin: 10px;
        width: 300px;
    }

    #sample-list-flat.e-listview .e-content .delete-icon::after {
        font-family: "e-icon";
        content: "\e700";
        float: right;
        cursor: pointer;
    }

    @@font-face {
        font-family: "e-icon";
        src: url(data:application/x-font-ttf;charset=utf-8;base64,AAEAAAAKAIAAAwAgT1MvMj1tSfIAAAEoAAAAVmNtYXDnEOdVAAABiAAAADZnbHlmXOniGAAAAcgAAAFAaGVhZBC1AhkAAADQAAAANmhoZWEIUQQDAAAArAAAACRobXR4CAAAAAAAAYAAAAAIbG9jYQCgAAAAAAHAAAAABm1heHABDgCYAAABCAAAACBuYW1lv4Bt4QAAAwgAAAIZcG9zdJx8QW4AAAUkAAAAOwABAAAEAAAAAFwEAAAAAAAD9AABAAAAAAAAAAAAAAAAAAAAAgABAAAAAQAApWcDV18PPPUACwQAAAAAANbRXpQAAAAA1tFelAAAAAAD9AP0AAAACAACAAAAAAAAAAEAAAACAIwAAgAAAAAAAgAAAAoACgAAAP8AAAAAAAAAAQQAAZAABQAAAokCzAAAAI8CiQLMAAAB6wAyAQgAAAIABQMAAAAAAAAAAAAAAAAAAAAAAAAAAAAAUGZFZABA5wDnAAQAAAAAXAQAAAAAAAABAAAAAAAABAAAAAQAAAAAAAACAAAAAwAAABQAAwABAAAAFAAEACIAAAAEAAQAAQAA5wD//wAA5wD//wAAAAEABAAAAAEAAAAAAAAAoAAAAAIAAAAAA/QD9AALAIsAAAEHFwcnByc3JzcXNwUfHz8fLx8PHgLuhIRrg4NrhIRrg4P9iQECAwQGBwcJCwsMDQ4PDxEREhMUFBUWFhcXFxkYGRkaGhkZGBkXFxcWFhUUFBMSEREPDw4NDAsLCQcHBgQDAgEBAgMEBgcHCQsLDA0ODw8RERITFBQVFhYXFxcZGBkZGhoZGRgZFxcXFhYVFBQTEhERDw8ODQwLCwkHBwYEAwICg4OGa4SEa4ODaoCE7hoZGRgZFxcXFhYVFBQTEhERDw8ODQwLCwkHBwYEAwIBAQIDBAYHBwkLCwwNDg8PERESExQUFRYWFxcXGRgZGRoaGRkYGRcXFxYWFRQUExIREQ8PDg0MCwsJBwcGBAMCAQECAwQGBwcJCwsMDQ4PDxEREhMUFBUWFhcXFxkYGRkAAAASAN4AAQAAAAAAAAABAAAAAQAAAAAAAQAGAAEAAQAAAAAAAgAHAAcAAQAAAAAAAwAGAA4AAQAAAAAABAAGABQAAQAAAAAABQALABoAAQAAAAAABgAGACUAAQAAAAAACgAsACsAAQAAAAAACwASAFcAAwABBAkAAAACAGkAAwABBAkAAQAMAGsAAwABBAkAAgAOAHcAAwABBAkAAwAMAIUAAwABBAkABAAMAJEAAwABBAkABQAWAJ0AAwABBAkABgAMALMAAwABBAkACgBYAL8AAwABBAkACwAkARcgZGVsZXRlUmVndWxhcmRlbGV0ZWRlbGV0ZVZlcnNpb24gMS4wZGVsZXRlRm9udCBnZW5lcmF0ZWQgdXNpbmcgU3luY2Z1c2lvbiBNZXRybyBTdHVkaW93d3cuc3luY2Z1c2lvbi5jb20AIABkAGUAbABlAHQAZQBSAGUAZwB1AGwAYQByAGQAZQBsAGUAdABlAGQAZQBsAGUAdABlAFYAZQByAHMAaQBvAG4AIAAxAC4AMABkAGUAbABlAHQAZQBGAG8AbgB0ACAAZwBlAG4AZQByAGEAdABlAGQAIAB1AHMAaQBuAGcAIABTAHkAbgBjAGYAdQBzAGkAbwBuACAATQBlAHQAcgBvACAAUwB0AHUAZABpAG8AdwB3AHcALgBzAHkAbgBjAGYAdQBzAGkAbwBuAC4AYwBvAG0AAAAAAgAAAAAAAAAKAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAQIBAwARY2lyY2xlLWNsb3NlLS0tMDIAAAA=) format("truetype");
        font-weight: normal;
        font-style: normal;
    }
</style>
```

![Add or Remove List Items in Blazor ListView](../images/list/blazor-listview-add-and-remove-list-items.png)
