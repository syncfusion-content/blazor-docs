---
layout: post
title: Add and remove list items in Blazor ListView Component | Syncfusion
description: Learn here all about adding and removing list items in Syncfusion Blazor ListView component and more.
platform: Blazor
control: Listview
documentation: ug
---

# Add and Remove List Items in Blazor ListView Component

The ListView component supports dynamic addition and removal of list items by utilizing an `ObservableCollection` as its data source. Changes made to the `ObservableCollection` are automatically reflected in the ListView UI.

Follow these steps to add or remove a list item:

*   **Configure ListView**: Render the ListView with an `ObservableCollection` as its `DataSource`. Use [`ListViewTemplates`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Lists.ListViewTemplates-1.html) to include a delete icon for each list item. Bind a click event to this delete icon.
*   **Add Item Functionality**: Render an "Add Item" button and bind its click event. In the handler, generate new data (e.g., with a random ID and text) and add it to the `DataSource` using the `Add` method.
*   **Remove Item Functionality**: Bind the `onclick` handler of the delete icon (created in step 1) to a method that removes the corresponding list item from the `DataSource` using the `Remove` method.

```cshtml
@using Syncfusion.Blazor.Lists
@using System.Collections.ObjectModel

<div class="flex">
    <div class="margin">
        <SfListView ID="sample-list" DataSource="@DataSource">
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

    #sample-list .delete-icon::after {
        content: "\e878";
        float: right;
        cursor: pointer;
    }

</style>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VZroMtNCKBISeOlj?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}
![Add or Remove List Items in Blazor ListView](../images/list/blazor-listview-add-and-remove-list-items.png)
