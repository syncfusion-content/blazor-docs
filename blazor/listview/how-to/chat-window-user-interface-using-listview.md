---
layout: post
title: Chat window user interface using Blazor ListView | Syncfusion
description: Learn here all about creating chat window user interface using Syncfusion Blazor ListView component and more.
platform: Blazor
control: ListView
documentation: ug
---

# Chat Window User Interface using Blazor ListView Component

ListView can be customized as chat window. To achieve that, use the ListView [`Template`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Lists.ListViewTemplates-1.html).

* The ListView template is used to showcase the ListView as chat window.
* Avatar component is used to design the image of contact person.

```cshtml
<div class="flex item__container">
    <div class="flex flex__1 vertical__center flex__center @(currentData.Chat == "sender" ? "flex__order__2" : "")">
        @if (currentData.Avatar != "")
        {
            <span class="e-avatar e-avatar-circle">@currentData.Avatar</span>
        }
        else
        {
            <span class="@currentData.Pic e-avatar e-avatar-circle"></span>
        }
    </div>
    <div class="flex content__container flex__8 vertical padding @(currentData.Chat == "sender" ? "right__align" : "left__align")">
        <div class="bold">@currentData.Text</div>
        <div class="small__font">@currentData.Contact</div>
    </div>
</div>
```

## Chat order in template

In ListView template, the list items are rendered based on the receiver and sender information from the dataSource of listview.

## Adding Messages to the Chat Window

*   Use an `SfTextBox` component to capture messages from the user.
*   Add the captured message to the ListView's `DataSource` (an `ObservableCollection`) using its `Add` method. This will automatically update the ListView.

```c#
void OnSend()
{
    if (SfTextBox.Value != "")
    {
        DataSource.Add(new ListDataModel
        {
            Text = "Amenda",
            Contact = SfTextBox.Value,
            Id = new Random().Next(300, 900).ToString(),
            Avatar = "A",
            Pic = "",
            Chat = "receiver"
        });
    }

}
```

```cshtml
@using Syncfusion.Blazor.Inputs
@using System.Collections.ObjectModel

<div id="container">
    <div id="sample">
        <SfListView ID="list"
                     DataSource="@DataSource"
                     ShowHeader="true"
                     Height="420px"
                     HeaderTitle="Chat">
            <ListViewFieldSettings TValue="ListDataModel" Id="Id" Text="Text"></ListViewFieldSettings>
            <ListViewTemplates TValue="ListDataModel">
                <Template>
                    @{
                        ListDataModel currentData = context as ListDataModel;

                        <div class="flex item__container">
                            <div class="flex flex__1 vertical__center flex__center @(currentData.Chat == "sender" ? "flex__order__2" : "")">
                                @if (currentData.Avatar != "")
                                {
                                    <span class="e-avatar e-avatar-circle">@currentData.Avatar</span>
                                }
                                else
                                {
                                    <span class="@currentData.Pic e-avatar e-avatar-circle"></span>
                                }
                            </div>
                            <div class="flex content__container flex__8 vertical padding @(currentData.Chat == "sender" ? "right__align" : "left__align")">
                                <div class="bold">@currentData.Text</div>
                                <div class="small__font">@currentData.Contact</div>
                            </div>
                        </div>
                    }
                </Template>
            </ListViewTemplates>
        </SfListView>
        <div class="flex">
            <div class="flex__8 padding">
                <SfTextBox Placeholder="Type your message"
                            @ref="@SfTextBox"
                            ></SfTextBox>
            </div>
            <div class="flex__1">
                <button class="e-btn" @onclick="@OnSend">Send</button>
            </div>
        </div>
    </div>
</div>

@code
{
    SfTextBox SfTextBox;
    ObservableCollection<ListDataModel> DataSource = new ObservableCollection<ListDataModel>() {
        new ListDataModel {
            Text = "Jenifer",
            Contact = "Hi",
            Id = "1",
            Avatar = "",
            Pic = "pic01",
            Chat = "sender"
        },
        new ListDataModel {
            Text = "Amenda",
            Contact = "Hello",
            Id = "2",
            Avatar = "A",
            Pic = "",
            Chat = "receiver"
        },
        new ListDataModel {
            Text = "Jenifer",
            Contact = "What kind of application going to launch",
            Id = "4",
            Avatar = "",
            Pic = "pic02",
            Chat = "sender"
        },
        new ListDataModel {
            Text = "Amenda ",
            Contact = "A kind of Emergency broadcast App",
            Id = "5",
            Avatar = "A",
            Pic = "",
            Chat = "receiver"
        },
        new ListDataModel {
            Text = "Jacob",
            Contact = "Can you please elaborate",
            Id = "6",
            Avatar = "",
            Pic = "pic04",
            Chat = "sender"
        },
    };

    void OnSend()
    {
        if (SfTextBox.Value != "")
        {
            DataSource.Add(new ListDataModel
            {
                Text = "Amenda",
                Contact = SfTextBox.Value,
                Id = new Random().Next(300, 900).ToString(),
                Avatar = "A",
                Pic = "",
                Chat = "receiver"
            });
        }

    }

    public class ListDataModel
    {
        public string? Id { get; set; }
        public string? Chat { get; set; }
        public string? Pic { get; set; }
        public string? Avatar { get; set; }
        public string? Text { get; set; }
        public string? Contact { get; set; }
    }
}

<style>
    
    #list {
        box-shadow: 0 1px 4px #ddd;
        border: 1px solid #ddd;
        margin: 0 auto;
    }

    .e-list-item {
        height: auto;
        cursor: pointer;
        line-height: 22px;
        padding: 8px;
    }

    #list.e-listview .e-list-header {
        background-color: #0278d7;
        color: white;
    }

    #list .e-list-item.e-active,
    #list .e-list-item.e-hover {
        background-color: transparent;
    }

    .padding {
        padding: 4px;
    }

    .right__align {
        text-align: right;
        margin-right: 8px;
        padding-right: 8px;
    }

    .left__align {
        margin-left: 8px;
        padding-left: 8px;
    }

    .content__container {
        background-color: aliceblue;
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

    .bold {
        font-weight: 500;
    }

    .margin {
        margin: 10px;
        width: 350px;
    }

    .small__font {
        font-size: 13px;
        margin: 2px 0;
    }

    .pic01 { background-image: url("https://ej2.syncfusion.com/demos/src/grid/images/1.png"); }
    .pic02 { background-image: url("https://ej2.syncfusion.com/demos/src/grid/images/3.png"); }
    .pic03 { background-image: url("https://ej2.syncfusion.com/demos/src/grid/images/5.png"); }
    .pic04 { background-image: url("https://ej2.syncfusion.com/demos/src/grid/images/2.png"); }

    .flex__order__1 { order: 1; }
    .flex__order__2 { order: 2; }
    .flex__1 { flex: 1; }
    .flex__2 { flex: 2; }
    .flex__3 { flex: 3; }
    .flex__5 { flex: 5; }
    .flex__8 { flex: 8; }
</style>

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VXLSWDtWgAZHwGDA?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap4" %}
![Blazor ListView with Chat Window](../images/list/blazor-listview-with-chat-window.png)
