---
layout: post
title: How to customize menu bar items in Blazor Menu Bar | Syncfusion
description: Add or remove Blazor Menu Bar items dynamically using built-in methods and field settings.
platform: Blazor
control: Menu Bar 
documentation: ug
---

# How to customize menu bar items in Blazor Menu Bar

## Add or Remove Menu Items

Menu items can be added or removed by using the [`Add`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfMenu-1.html#Syncfusion_Blazor_Navigations_SfMenu_1_Add__1) and [`Remove`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfMenu-1.html#Syncfusion_Blazor_Navigations_SfMenu_1_Remove__1) methods on the `SfMenu` instance. The following example uses a typed model (`TValue="DataList"`) and binds the items through the `Items` parameter along with `MenuFieldSettings` to map the model fields.

In the following example, the `Corporate` menu item is added and the `Company` item is removed from the menu.

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

![Add or Remove Items in Blazor MenuBar](./../images/blazor-menubar-add-remove-items.webp)

## Enable or Disable Menu Items

You can enable and disable the menu items using the [Disabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.MenuItem.html#Syncfusion_Blazor_Navigations_MenuItem_Disabled) property. To disable a menu item, set the `Disabled` property to `true`; to re-enable it, set the property to `false`. This example also references `Syncfusion.Blazor.Buttons` for the `SfButton` component.

In the following example, the Directory header item, Conferences, and Music submenu items are disabled.

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

![Disabling Menu Items in Blazor MenuBar](./../images/blazor-menubar-disable-item.webp)

## Show or Hide Menu Items

You can show or hide the menu items using the [Hidden](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.MenuItem.html#Syncfusion_Blazor_Navigations_MenuItem_Hidden) property. To hide a menu item, set the `Hidden` property to `true`; to show it again, set the property to `false`.

In the following example, the Movies header item, Workshops, and Music submenu items are hidden.

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

![Displaying Menu Items in Blazor MenuBar](./../images/blazor-menubar-show-menu-item.webp)