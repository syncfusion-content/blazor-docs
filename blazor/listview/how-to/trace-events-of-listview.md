---
layout: post
title: Trace events of listview in Blazor ListView Component | Syncfusion
description: Checkout and learn here all about trace events of listview in Syncfusion Blazor ListView component and more.
platform: Blazor
control: Listview
documentation: ug
---

# Trace events of listview in Blazor ListView Component

The ListView control triggers events based on its actions. The events can be used as extension points to perform custom operations. Refer to the following steps to trace the ListView events:

1. Render the ListView with `DataSource`, and bind the `OnActionBegin`, `OnActionComplete`, and `Selected` events.

2. Perform custom operations in `OnActionBegin`, `OnActionComplete`, and `Selected` events.

3. Provide event log details for `OnActionBegin` and `OnActionComplete` events, and they will be displayed in the event trace panel when the ListView action starts and the dataSource bound successfully.

4. Get the selected item details from the `SelectEventArgs` in the select event, and display the selected list item text in the event trace panel while selecting list items.

5. Use clear button to remove event trace information.

```cshtml
@using Syncfusion.Blazor.Lists

<div id="container">
    <div class="flex vertical-center">
        <div class="sample padding">
            <SfListView DataSource="@DataSource">
                <ListViewFieldSettings TValue="ListDataModel" Id="Id" Text="Text"></ListViewFieldSettings>
                <ListViewEvents TValue="ListDataModel"
                                Clicked="@(e => Events.Add(e.Text +" is selected"))"
                                OnActionBegin="@(e => Events.Add("OnActionBegin is triggered"))"
                                OnActionComplete="@(e => Events.Add("OnActionComplete is triggered"))">
                </ListViewEvents>
            </SfListView>
        </div>
        <div class="sample padding tracker">
            <ul style="list-style: none">
                @for (var i = Events.Count - 1; i >= 0; i--)
                {
                    <li>@Events[i]</li>
                }
            </ul>
        </div>
    </div>
</div>

@code
{
    List<string> Events = new List<string>();

    List<ListDataModel> DataSource = new List<ListDataModel>() {
        new ListDataModel { Id = "1", Text = "Text 1" },
        new ListDataModel { Id = "2", Text = "Text 2" },
        new ListDataModel { Id = "3", Text = "Text 3" },
        new ListDataModel { Id = "4", Text = "Text 4" },
        new ListDataModel { Id = "5", Text = "Text 5" },
        new ListDataModel { Id = "6", Text = "Text 6" },
        new ListDataModel { Id = "7", Text = "Text 7" },
    };

    public class ListDataModel
    {
        public string Id
        {
            get;
            set;
        }
        public string Text
        {
            get;
            set;
        }
    }
}
<style>
    #container .e-listview {
        box-shadow: 0 1px 4px #ddd;
        border-bottom: 1px solid #ddd;
    }

    .tracker {
        max-height: 250px;
        overflow: auto;
    }

    .sample {
        justify-content: center;
        min-height: 280px;
        width: 350px;
    }

    .vertical-center {
        align-items: center;
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

![Displaying Event Action in Blazor ListView](../images/list/blazor-listview-trace-events.png)
