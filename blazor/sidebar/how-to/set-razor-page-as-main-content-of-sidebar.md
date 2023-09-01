---
layout: post
title: Configuring Razor Pages as Main Content in Blazor Sidebar Component | Syncfusion
description: Checkout and learn here all about how to open and close the Sidebar in Syncfusion Blazor Sidebar component and more.
platform: Blazor
control: Sidebar
documentation: ug
---

# Configuring Razor Pages as Main Content in the Blazor Sidebar Component

In the Blazor Sidebar component, you can seamlessly integrate additional Razor page content into the main content area. This feature allows you to dynamically display content based on user interactions with the Sidebar component. To implement this functionality effectively, it is necessary to position the Sidebar within the **MainLayout** page and utilize the **@Body** directive to render the primary content of the Sidebar within the **MainLayout.razor** page in your application.

```cshtml

@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Lists
@inject NavigationManager NavigationManager

<div id="wrapper">
 <div id="header" style="width: 100%">
        <span style="float: left">
            <SfButton CssClass="custom-button" IconCss="e-icons e-menu" @onclick="MenuButtonClick"> 
            </SfButton>
        </span>
        <span style="float: left; font-size: 20px; padding-left: 10px"></span>
        <span style="font-size: 25px">@HeaderText</span>
    </div>
    <SfSidebar Width="250px" ShowBackdrop="true" Target=".e-main-content" Position="SidebarPosition.Left" @bind-IsOpen="ToggleSidebar"
               MediaQuery="(min-width: 600px)" Type="SidebarType.Auto">
        <ChildContent>
            <SfListView DataSource="@ListViewData">
                <ListViewFieldSettings TValue="ListViewDataModel" Id="Id" Text="Text">
                </ListViewFieldSettings>
                <ListViewEvents TValue="ListViewDataModel" Clicked="OnSelect"></ListViewEvents>
            </SfListView>
        </ChildContent>
    </SfSidebar>
    @*main content declaration*@
    <div class="main-text-content">@Body</div>
</div>

@code {

    public void OnSelect(ClickEventArgs<ListViewDataModel> args)
    {
        NavigationManager.NavigateTo(args.ItemData.Link);
    }

    public class ListViewDataModel
    {

        public string Id { get; set; }
        public string Text { get; set; }
        public string Link { get; set; }
    }
    List<ListViewDataModel> ListViewData = new List<ListViewDataModel>
    {
        new ListViewDataModel {Id="1", Text = "Index Page", Link = "/" },
        new ListViewDataModel {Id="2", Text = "Counter Page", Link = "/counter" },
        new ListViewDataModel {Id="3", Text = "FetchData Page", Link = "/fetchdata" }
    };

    public bool ToggleSidebar = true;
    public void MenuButtonClick()
    {

        ToggleSidebar = !ToggleSidebar;
    }

    public string HeaderText = "Header";

}

<style>

    .custom-button {
        color: white !important;
        font-size: 20px !important;
        background-color: midnightblue !important;
        border-color: midnightblue !important;
    }

    #header {
        text-align: center;
        color: white;
        background-color: midnightblue;
        line-height: 51px;
    }

    .main-text-content {
        font-size: 18px;
        text-align: left;
        padding-top: 50px;
        padding-left: 30px;
        height: 600px !important;
    }
    .e-sidebar {
        background-color: #f8f8f8;
        color: black;
    }

    .e-sidebar.e-left {
        top: 55px;
    }

    .e-sidebar.e-right {
        top: 55px;
    }

    .main > div {
        padding: 0px !important;
    }
</style>

```