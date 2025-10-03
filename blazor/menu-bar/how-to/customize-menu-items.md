---
layout: post
title: Customize Menu Bar Items in Blazor Menu Bar Component | Syncfusion
description: Checkout and learn here all about how to customize menu bar items in Syncfusion Blazor Menu Bar component and more.
platform: Blazor
control: Menu Bar 
documentation: ug
---

# Customize Menu Bar Items in Blazor Menu Bar Component

## Add or Remove Menu Items

Menu items can be dynamically added or removed from the Menu Bar by directly manipulating the `Items` collection bound to the `SfMenu` component. If the `Items` collection is an `ObservableCollection<T>`, changes will be automatically reflected.

In the following example, the `Corporate` menu items are added and the `Company` items are removed from menu.

```cshtml

@using Syncfusion.Blazor.Navigations

<SfMenu Items="@MenuItems" @ref="MenuObj">
    <MenuEvents TValue="DataList" Created="Created"></MenuEvents>
    <MenuFieldSettings Text="@nameof(DataList.Data)" Children="@nameof(DataList.SubDatas)"></MenuFieldSettings>
</SfMenu>

@code{
    SfMenu<DataList> MenuObj;

    public List<DataList> MenuItems = new List<DataList>
    {
        new DataList{ Data = "Company", SubDatas = new List<DataList>{
            new DataList{ Data= "Overview" },
            new DataList{ Data= "About" },
            new DataList{ Data= "Careers" }}
    },
        new DataList{ Data = "Services", SubDatas = new List<DataList>{
            new DataList{ Data= "Consulting" },
            new DataList{ Data= "Education" },
            new DataList{ Data= "Health" }}
    },
        new DataList{ Data = "Products", SubDatas = new List<DataList>{
            new DataList{ Data = "Hardware" },
            new DataList{ Data = "Software" }}
    },
        new DataList{ Data = "Contact Us" }
    };

    public class DataList
    {
        public string Data { get; set; }
        public List<DataList> SubDatas { get; set; }
    }

    public void Created()
    {
        this.MenuObj.Items.Add(new DataList
        {
            Data = "Corporate",
            SubDatas = new List<DataList>
            {
                new DataList{ Data = "Leadership"},
                new DataList{ Data = "Vision"}
            }
        });
        var item = this.MenuObj.Items.First(x => x.Data == "Company");
        this.MenuObj.Items.Remove(item);
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BjVSsNtArMJKzvqj?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}
![Add or Remove Items in Blazor MenuBar](./../images/blazor-menubar-add-remove-items.png)

## Enable or Disable Menu Items

Menu items can be enabled or disabled by setting the [`Disabled`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.MenuItem.html#Syncfusion_Blazor_Navigations_MenuItem_Disabled) property to `true` or `false` respectively for the individual `MenuItem` component.

In the following example, the Directory header item, Conferences, and Music sub menu items are disabled.

```cshtml

@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<SfMenu TValue="MenuItem">
    <MenuEvents TValue="MenuItem" Created="@Created"></MenuEvents>
    <MenuItems>
        <MenuItem Text="Events">
            <MenuItems>
                <MenuItem Text="Conferences" Disabled="@disableItem"></MenuItem>
                <MenuItem Text="Music" Disabled="@disableItem"></MenuItem>
                <MenuItem Text="Workshops"></MenuItem>
            </MenuItems>
        </MenuItem>
        <MenuItem Text="Movies">
            <MenuItems>
                <MenuItem Text="Now Showing"></MenuItem>
                <MenuItem Text="Coming Soon"></MenuItem>
            </MenuItems>
        </MenuItem>
        <MenuItem Text="Directory" Disabled="@disableItem">
            <MenuItems>
                <MenuItem Text="Newsletter"></MenuItem>
                <MenuItem Text="Media Gallery"></MenuItem>
            </MenuItems>
        </MenuItem>
        <MenuItem Text="Queries">
            <MenuItems>
                <MenuItem Text="Our Policy"></MenuItem>
                <MenuItem Text="Site Map"></MenuItem>
            </MenuItems>
        </MenuItem>
        <MenuItem Text="Services"></MenuItem>
    </MenuItems>
</SfMenu>
<SfButton @onclick="EnableItems">Enable all items</SfButton>

@code {
    private bool disableItem;
    public void Created()
    {
        disableItem = true;
    }

    public void EnableItems()
    {
        disableItem = false;
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LNVSCDjgBiyZzCar?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}
![Disabling Menu Items in Blazor MenuBar](./../images/blazor-menubar-disable-item.png)

## Show or Hide Menu Items

Menu items can be shown or hidden by setting the [`Hidden`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.MenuItem.html#Syncfusion_Blazor_Navigations_MenuItem_Hidden) property to `true` or `false` respectively for the individual `MenuItem` component.

In the following example, the Movies header item, Workshops, and Music sub menu items are hidden in menu.

```cshtml

@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<SfMenu TValue="MenuItem">
    <MenuEvents TValue="MenuItem" Created="@Created"></MenuEvents>
    <MenuItems>
        <MenuItem Text="Events">
            <MenuItems>
                <MenuItem Text="Conferences"></MenuItem>
                <MenuItem Text="Music" Hidden="@hideItem"></MenuItem>
                <MenuItem Text="Workshops" Hidden="@hideItem"></MenuItem>
            </MenuItems>
        </MenuItem>
        <MenuItem Text="Movies" Hidden="@hideItem">
            <MenuItems>
                <MenuItem Text="Now Showing"></MenuItem>
                <MenuItem Text="Coming Soon"></MenuItem>
            </MenuItems>
        </MenuItem>
        <MenuItem Text="Directory">
            <MenuItems>
                <MenuItem Text="Newsletter"></MenuItem>
                <MenuItem Text="Media Gallery"></MenuItem>
            </MenuItems>
        </MenuItem>
        <MenuItem Text="Queries">
            <MenuItems>
                <MenuItem Text="Our Policy"></MenuItem>
                <MenuItem Text="Site Map"></MenuItem>
            </MenuItems>
        </MenuItem>
        <MenuItem Text="Services"></MenuItem>
    </MenuItems>
</SfMenu>
<SfButton @onclick="ShowItems">Show all items</SfButton>

@code {
    private bool hideItem;

    public void Created()
    {
        hideItem = true;
    }

    public void ShowItems()
    {
        hideItem = false;
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VZVesNDqriFJYazL?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}
![Disaplying Menu Items in Blazor MenuBar](./../images/blazor-menubar-show-menu-item.png)