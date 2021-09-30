---
layout: post
title: Get selected items from Blazor ListView Component | Syncfusion
description: Learn here all about getting the selected items in Syncfusion Blazor ListView component and much more.
platform: Blazor
control: Listview
documentation: ug
---

# Get selected items from Blazor ListView Component

Single or many items can be selected by users in the ListView control. An API is used to get selected items from the list items. This is called as the `GetCheckedItemsAsync` method.

**`GetCheckedItemsAsync` method**

| Return type | Purpose |
|------------|-------------------|
| Data | Returns the collections of list items data |
| Index | Returns the index of the selected item (applicable only in Virtualization) |
| ParentId | Returns the currently selected item's Parent Id (applicable only in Nested List) |
| Text | Returns array of text of selected item lists |

```cshtml
@using Syncfusion.Blazor.Lists

<div style="display: flex">
    <div class="margin">
        <SfListView @ref="@SfList"

                     DataSource="@DataSource"
                     ShowCheckBox="true">
            <ListViewFieldSettings TValue="ListDataModel" Id="Id" Text="Text"></ListViewFieldSettings>
        </SfListView>
    </div>
    <div class="margin">
        <div class="padding">
            <button class="e-btn" @onclick="@OnSelect">Get Selected Items</button>
        </div>
        <div class="padding">
            <table>
                <tr>
                    <th>Text</th>
                    <th>Id</th>
                </tr>
                @foreach (var item in SelectedItems)
                {
                    <tr>
                        <td>@item.Text</td>
                        <td>@item.Id</td>
                    </tr>
                }
            </table>
        </div>
    </div>
</div>

@code
{
    SfListView<ListDataModel> SfList;

    List<ListDataModel> SelectedItems = new List<ListDataModel>();

    List<ListDataModel> DataSource = new List<ListDataModel>()
    {
        new ListDataModel{ Id = "1", Text = "Artwork"},
        new ListDataModel{ Id = "2", Text = "Abstract"},
        new ListDataModel{ Id = "3", Text = "Modern Painting"},
        new ListDataModel{ Id = "4", Text = "Ceramics"},
        new ListDataModel{ Id = "5", Text = "Animation Art"},
        new ListDataModel{ Id = "6", Text = "Oil Painting"},
    };

    async void OnSelect()
    {
        var items = await SfList.GetCheckedItemsAsync();
        if (items.Data != null)
        {
            SelectedItems = items.Data;
            this.StateHasChanged();
        }
    }

    public class ListDataModel
    {
        public string Id { get; set; }
        public string Text { get; set; }
    }

}

<style>
    .margin {
        margin: 10px;
        width: 300px;
    }

    .padding {
        padding: 10px 0;
    }

    table {
        width: 100%;
    }
</style>
```

![Getting Selected Item in Blazor ListView](../images/list/get-selected-items-from-listview.png)
