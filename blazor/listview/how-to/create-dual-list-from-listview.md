---
layout: post
title: Create dual list using Blazor ListView Component | Syncfusion
description: Check out and learn here all about creating dual list using Syncfusion Blazor ListView component and much more.
platform: Blazor
control: ListView
documentation: ug
---

# Create dual list using Blazor ListView Component

The dual list implementation consists of two ListView components that enable moving items between lists using client-side events. This guide explains how to integrate the ListView component to create a dual list.

## Use cases

* Stock exchanges of two different countries
* Job applications (skill set management)

## Integration of Dual List

This setup involves using two ListView components to display items. A Blazor Button facilitates data transfer between ListViews, while a textbox provides a UI for filtering items.

The dual list supports:

* Move all items from one list to another.
* Move only the selected items between lists.
* Filtering the list by using a client-side typed character.

In the ListView component, sorting is enabled using the [`SortOrder`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Lists.SfListView-1.html#Syncfusion_Blazor_Lists_SfListView_1_SortOrder) property, and the [`Clicked`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Lists.ListViewEvents-1.html#Syncfusion_Blazor_Lists_ListViewEvents_1_Clicked) event allows for enabling and disabling button states through item selection.

## Manipulating data

### Moving All Items from First to Second List (>>)

By clicking the first button, all items from the first ListView are transferred to the second, and the first list is cleared. The button activates when the first ListView contains items.

### Moving All Items from Second to First List (<<)

Similarly, the second button moves all items from the second ListView to the first. It is enabled when the second ListView has items.

### Moving Selected Items (>) and (<)

When an item is clicked in a ListView, the [`Clicked`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Lists.ListViewEvents-1.html#Syncfusion_Blazor_Lists_ListViewEvents_1_Clicked) event activates the corresponding button to move selected items between lists.

The following example demonstrates how to manipulate data between two ListView components:

```cshtml
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Lists

<div id="container">
    <div class="sample flex">
        <div class="flex">
            <div class="padding">
                <SfTextBox Placeholder="Filter" Input="@(e => OnInput(e, 1))"></SfTextBox>
                <SfListView DataSource="@FirstData">
                    <ListViewFieldSettings TValue="ListDataModel" Id="Id" Text="Text"></ListViewFieldSettings>
                    <ListViewEvents TValue="ListDataModel" Clicked="@(e => OnSelected(e, 1))"></ListViewEvents>
                </SfListView>
            </div>
            <div class="flex vertical vertical__center flex__center padding">
                <div class="padding">
                    <button disabled="@(!FirstListData.Any())" class="e-btn" @onclick="@(e => OnButtonClick(1))">@(">>")</button>
                </div>
                <div class="padding">
                    <button disabled="@(FirstSelected == null)" class="e-btn" @onclick="@(e => OnButtonClick(2))">@(">")</button>
                </div>
                <div class="padding">
                    <button disabled="@(SecondSelected == null)" class="e-btn" @onclick="@(e => OnButtonClick(3))">@("<")</button>
                </div>
                <div class="padding">
                    <button disabled="@(!SecondListData.Any())" class="e-btn" @onclick="@(e => OnButtonClick(4))">@("<<")</button>
                </div>
            </div>
            <div class="padding">
                <SfTextBox Placeholder="Filter" Input="@(e => OnInput(e, 2))"></SfTextBox>
                <SfListView DataSource="@SecondData">
                    <ListViewFieldSettings Id="Id" Text="Text" TValue="ListDataModel"></ListViewFieldSettings>
                    <ListViewEvents TValue="ListDataModel" Clicked="@(e => OnSelected(e, 2))"></ListViewEvents>
                </SfListView>
            </div>
        </div>
    </div>
</div>

@code
{
    List<ListDataModel> FirstData;

    List<ListDataModel> SecondData;

    ListDataModel FirstSelected;

    ListDataModel SecondSelected;

    protected override void OnInitialized()
    {
        FirstData = new List<ListDataModel>(FirstListData);
        SecondData = new List<ListDataModel>(SecondListData);
    }

    void OnButtonClick(int buttonIndex)
    {
        switch (buttonIndex)
        {
            case 1:
                FirstListData.ForEach(e => SecondListData.Add(e));
                FirstListData.Clear();
                FirstData.Clear();
                FirstData = new List<ListDataModel>(FirstListData);
                SecondData = new List<ListDataModel>(SecondListData);
                break;
            case 2:
                if (FirstSelected != null)
                {
                    SecondListData.Add(FirstSelected);
                    FirstListData.RemoveAt(FirstListData.FindIndex(e => e.Id == FirstSelected.Id));
                    FirstData = new List<ListDataModel>(FirstListData);
                    SecondData = new List<ListDataModel>(SecondListData);
                    FirstSelected = null;
                }
                break;
            case 3:
                if (SecondSelected != null)
                {
                    FirstListData.Add(SecondSelected);
                    SecondListData.RemoveAt(SecondListData.FindIndex(e => e.Id == SecondSelected.Id));
                    FirstData = new List<ListDataModel>(FirstListData);
                    SecondData = new List<ListDataModel>(SecondListData);
                    SecondSelected = null;
                }
                break;
            case 4:
                SecondListData.ForEach(e => FirstListData.Add(e));
                SecondData.Clear();
                SecondListData.Clear();
                SecondData = new List<ListDataModel>(SecondListData);
                FirstData = new List<ListDataModel>(FirstListData);
                break;
            default:
                break;
        }
    }

    void OnSelected(ClickEventArgs<ListDataModel> eventArgs, int listviewIndex)
    {
        if (listviewIndex == 1)
        {
            FirstSelected = eventArgs.ItemData;
        }
        else
        {
            SecondSelected = eventArgs.ItemData;
        }
    }

    void OnInput(InputEventArgs eventArgs, int listviewIndex)
    {
        if (listviewIndex == 1)
        {
            FirstData = FirstListData.FindAll(e => e.Text.ToLower().Contains(eventArgs.Value.ToLower()));
        }
        else
        {
            SecondData = SecondListData.FindAll(e => e.Text.ToLower().Contains(eventArgs.Value.ToLower()));
        }
    }

    List<ListDataModel> SecondListData = new List<ListDataModel>() {
        new ListDataModel {
            Text = "Aston Martin One- 77",
            Id = "07"
        },
        new ListDataModel {
            Text = "Jaguar XJ220",
            Id = "08"
        },
        new ListDataModel {
            Text = "McLaren P1",
            Id = "09"
        },
        new ListDataModel {
            Text = "Ferrari LaFerrari",
            Id = "14"
        },
    };

    List<ListDataModel> FirstListData = new List<ListDataModel>() {
        new ListDataModel {
            Text = "Hennessey Venom",
            Id = "01"
        },
        new ListDataModel {
            Text = "Bugatti Chiron",
            Id = "02"
        },
        new ListDataModel {
            Text = "Bugatti Veyron Super Sport",
            Id = "03"
        },
        new ListDataModel {
            Text = "SSC Ultimate Aero",
            Id = "04"
        },
        new ListDataModel {
            Text = "Koenigsegg CCR",
            Id = "05"
        },
        new ListDataModel {
            Text = "McLaren F1",
            Id = "06"
        }
    };

    public class ListDataModel
    {
        public string Id { get; set; }
        public string Text { get; set; }
    }
}

<style>
    .e-listview.e-lib {
        box-shadow: 0 1px 4px #ddd;
        border-bottom: 1px solid #ddd;
        width: 250px;
    }

    .sample {
        justify-content: center;
        min-height: 280px;
    }

    .padding {
        padding: 4px;
    }

    .left__align {
        margin-left: 8px;
        padding-left: 8px;
    }

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
</style>
```

![Displaying Dual List in Blazor ListView](../images/list/blazor-listview-with-dual-list.png)
