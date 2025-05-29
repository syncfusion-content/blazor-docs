---
layout: post
title: Customize Blazor ListView Component to Grid Layout | Syncfusion
description: Learn here all about customizing listview as grid layout in Syncfusion Blazor ListView component and more.
platform: Blazor
control: Listview
documentation: ug
---

# Customize Blazor ListView Component to Grid Layout

In ListView, list items can be rendered in grid layout with the following data manipulations.

* Add Item
* Remove Item
* Sort Items
* Filter Items

## Grid Layout

In this section, rendering of list items in grid layout has been discussed.

* Initialize and render ListView with dataSource which will render list items in list layout.
* Now, add the below CSS to list item. This will make list items to render in grid layout

```css

#container .e-listview .e-list-item {
    height: 100px;
    width: 100px;
    float: left;
}

```

In the below sample, we have rendered List items in grid layout.

```C#

<div id="container">
    <div class="sample flex">
        <div class="flex">
            <div class="padding">
                <SfListView DataSource="@ListItems"></SfListView>
            </div>
        </div>
    </div>
</div>

@code
{
    List<int> ListItems = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
}

<style>
    #container .e-listview {
        box-shadow: 0 1px 4px #ddd;
        border-bottom: 1px solid #ddd;
        width: 400px;
    }

    #container .e-listview .e-list-item {
        height: 100px;
        width: 100px;
        float: left;
    }

    #container .e-listview .e-list-item .e-text-content {
        display: flex;
        align-items: center;
        justify-content: center;
        cursor: pointer;
    }

    #container .e-listview .e-list-text {
        width: unset;
    }

    .sample {
        justify-content: center;
        min-height: 280px;
    }

    .padding {
        padding: 4px;
    }

    .flex {
        display: flex;
    }

    .flex__center {
        justify-content: center;
    }

    .margin {
        margin: 10px;
    }
</style>
```

## Data manipulation

This section covers the functionalities available for manipulating data within a ListView, specifically adding, removing, and sorting items. The interactive features implemented provide users with a seamless data management experience.

### Add Item

To add a new item to the ListView, the code uses a dialog box that allows users to enter the item details. When the `Add` button is clicked, the dialog opens, letting the user input text. Then, upon clicking the `Add` button within the dialog, the new item is added to the list.

```cshtml

<button id="add"
        class="e-btn e-small e-round e-primary e-icon-btn"
        title="Add"
        @onclick="@(e => DialogObj.ShowAsync())">
    <span class="e-btn-icon e-icons e-add-icon"></span>
</button>
<SfDialog @ref="DialogObj"
          Target="#container"
          ShowCloseIcon="true"
          Header="@("Add item")"
          @bind-Visible="@Visible"
          Width="300px"
          Height="230px">
    <DialogTemplates>
        <Content>
            <div id="listDialog">
                <div class="input_name">
                    <label for="name">Item text: </label>
                    <input id="name" class="e-input" type="text" placeholder="Enter text" @bind-value="@Value" />
                </div>
            </div>
        </Content>
    </DialogTemplates>
    <DialogButtons>
        <DialogButton OnClick="@(e => Add())" Content = "Add" IsPrimary = "true" CssClass = "e-flat"></DialogButton>
    </DialogButtons>
</SfDialog>

@code
{
    async void Add()
    {
        await DialogObj.HideAsync();
        DataSourceOG.Add(new ListDataModel { Id = Guid.NewGuid().ToString(), Text = Value });
        DataSource = new List<ListDataModel>(DataSourceOG);
        Value = "";
    }
}

```

### Remove item

To effectively manage item removal, a delete button is introduced, which becomes visible upon hovering over a list item. Clicking this button will immediately remove the selected item from the list.

```cshtml

<ListViewTemplates TValue="ListDataModel">
    <Template>
        @{
            ListDataModel currentData = (ListDataModel)context;
            <div>
                @currentData.Text
                <button class="delete e-control e-btn e-small e-round e-delete-btn e-primary e-icon-btn"
                      @onclick="@(e => Remove(currentData))">
                    <span class="e-btn-icon e-icons delete-icon"></span>
                </button>
            </div>
        }
    </Template>
</ListViewTemplates>

@code
{
    void Remove(ListDataModel data)
    {
        DataSourceOG.RemoveAt(DataSourceOG.FindIndex(e => e.Id == data.Id));
        DataSource = new List<ListDataModel>(DataSourceOG);
    }
}

```

### Sort Items

ListView items can be sorted in either `Ascending` or `Descending` order. To activate sorting, set the [`SortOrder`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Lists.SfListView-1.html#Syncfusion_Blazor_Lists_SfListView_1_SortOrder) property accordingly. Users can toggle the sort order interactively by clicking the sort icon.

The below code explains adding, removing, searching and sorting within a list of items.

```cshtml

@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Lists
@using ListviewSort = Syncfusion.Blazor.Lists.SortOrder

<div id="container">
    <div class="sample flex">
        <div class="flex">
            <div>
                <div class="headerContainer">
                    <div class="e-input-group">
                        <input id="search" class="e-input" placeholder="Search" @bind-value="@SearchValue" @oninput="@(e => Search(e.Value.ToString()))" />
                    </div>
                    <button id="sort"
                            class="e-btn e-small e-round e-primary e-icon-btn"
                            title="Sort"
                            @onclick="@(e => ListSortOrder = (ListSortOrder == ListviewSort.Ascending) ? ListviewSort.Descending : ListviewSort.Ascending)">
                        <span class="e-btn-icon e-icons @(ListSortOrder == ListviewSort.Ascending ? "e-sort-icon-ascending" : "e-sort-icon-descending")"></span>
                    </button>
                    <button id="add"
                            class="e-btn e-small e-round e-primary e-icon-btn"
                            title="Add"
                            @onclick="@(e => DialogObj.ShowAsync())">
                        <span class="e-btn-icon e-icons e-add-icon"></span>
                    </button>
                    <SfDialog @ref="DialogObj"
                              Target="#container"
                              ShowCloseIcon="true"
                              Header="@("Add item")"
                              @bind-Visible="@Visible"
                              Width="300px"
                              Height="230px">
                        <DialogTemplates>
                            <Content>
                                <div id="listDialog">
                                    <div class="input_name">
                                        <label for="name">Item text: </label>
                                        <input id="name" class="e-input" type="text" placeholder="Enter text" @bind-value="@Value" />
                                    </div>
                                </div>
                            </Content>
                        </DialogTemplates>
                        <DialogButtons>
                            <DialogButton OnClick="@(e => Add())" Content = "Add" IsPrimary = "true" CssClass = "e-flat"></DialogButton>
                        </DialogButtons>
                    </SfDialog>
                </div>
            </div>
            <div>
                <div class="listview-container">
                    <SfListView ID="element" DataSource="@DataSource" SortOrder="@ListSortOrder">
                        <ListViewFieldSettings TValue="ListDataModel" Id="Id" Text="Text"></ListViewFieldSettings>
                        <ListViewTemplates TValue="ListDataModel">
                            <Template>
                                @{
                                    ListDataModel currentData = (ListDataModel)context;
                                    <div>
                                        @currentData.Text
                                        <button class="delete e-control e-btn e-small e-round e-delete-btn e-primary e-icon-btn"
                                              @onclick="@(e => Remove(currentData))">
                                            <span class="e-btn-icon e-icons delete-icon"></span>
                                        </button>
                                    </div>
                                }
                            </Template>
                        </ListViewTemplates>
                    </SfListView>
                </div>
            </div>
        </div>
    </div>
</div>

@code
{
    SfDialog DialogObj;

    ListviewSort ListSortOrder = ListviewSort.Ascending;

    string Value = "";

    string SearchValue = "";

    bool Visible = false;
    List<ListDataModel> DataSourceOG = new List<ListDataModel>(
        Enumerable.Range(10, 22)
            .Select(
            index => new ListDataModel
                {
                    Id = index.ToString(),
                    Text = "Item " + index.ToString(),
                }
        ).ToList()
    );

    List<ListDataModel> DataSource;

    protected override void OnInitialized()
    {
        DataSource = new List<ListDataModel>(DataSourceOG);
    }

    private void Search(string value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            DataSource = new List<ListDataModel>(DataSourceOG.Where(e => e.Text.ToLower().Contains(value.ToLower())));
        }
        else
        {
            DataSource = new List<ListDataModel>(DataSourceOG);
        }
    }

    void Remove(ListDataModel data)
    {
        DataSourceOG.RemoveAt(DataSourceOG.FindIndex(e => e.Id == data.Id));
        DataSource = new List<ListDataModel>(DataSourceOG);
    }

    async void Add()
    {
        await DialogObj.HideAsync();
        DataSourceOG.Add(new ListDataModel { Id = Guid.NewGuid().ToString(), Text = Value });
        DataSource = new List<ListDataModel>(DataSourceOG);
        Value = "";
    }

    public class ListDataModel
    {
        public string Id { get; set; }
        public string Text { get; set; }
    }
}
<style>
    .headerContainer {
        height: 48px;
        line-height: 48px;
        background: rgb(2, 120, 215);
        color: white;
        margin-bottom: 3px;
    }

    #container .e-listview .e-content {
        overflow: visible;
    }

    #container .e-listview {
        overflow: visible;
    }

    #container .listview-container {
        display: inline-block;
        height: 300px;
    }

    .headerContainer .e-input-group {
        margin-left: 20px;
        width: 200px;
        background: white;
        height: 31px;
    }

    .headerContainer #search {
        height: 21px;
        margin-left: 10px;
    }

    #listDialog .input_name {
        margin-bottom: 20px;
    }

    .headerContainer #add,
    .headerContainer #sort {
        float: right;
        margin-right: 15px;
        margin-top: 7px;
        background: white;
        color: black
    }

    .headerContainer .e-input-search::before {
        
        content: '\e754';
        margin-top: 3px;
    }

    .headerContainer .e-input-group .e-input-search {
        padding: 0 10px 0 10px;
    }

    .headerContainer .e-sort-icon-ascending::before {
        content: '\e7d8';
    }

    .headerContainer .e-sort-icon-descending::before {
        content: '\e7df';
    }

    .headerContainer .e-add-icon::before {
        content: '\e805';
    }

    #container .e-listview {
        box-shadow: 0 1px 4px #ddd;
        border-bottom: 1px solid #ddd;
    }

    #container .flex {
        display: flex;
        flex-direction: column;
        width: 400px;
        margin: auto;
    }

    #container .e-listview .e-list-item {
        height: 100px;
        width: 100px;
        float: left;
        padding: 0;
    }

    #container .e-listview .e-list-item .e-blazor-template {
        display: flex;
        align-items: center;
        justify-content: center;
        cursor: pointer;
        height: 100%;
    }

    #container .e-listview .e-list-item .delete-icon {
        font-size: 9px;
            
    }

    #element .e-delete-btn {
        float: right;
        visibility: hidden;
        margin-top: -10px;
    }

    #element .e-delete-btn.e-btn.e-small.e-round {
        width: 2em;
        height: 2em;
    }

    #element .e-btn.e-small.e-round .e-btn-icon.delete-icon {
        font-size: 9px;
    }

    #element .e-list-item:hover .e-delete-btn {
        visibility: visible;
        background: red;
        border-radius: 50%;
    }

    #container .e-listview .e-list-item .delete-icon::before {
        content: '\e7e7';
        color: white;
    }

    .sample {
        justify-content: center;
        min-height: 280px;
    }

    .padding {
        padding: 4px;
    }

    .flex {
        display: flex;
    }

    .flex__center {
        justify-content: center;
    }

    .margin {
        margin: 10px;
    }
</style>
```

![Blazor ListView with Grid Layout](../images/list/blazor-listview-with-grid-layout.png)
