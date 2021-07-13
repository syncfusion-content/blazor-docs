---
layout: post
title: How to Customize Menu Items in Blazor Menu Bar  Component | Syncfusion
description: Checkout and learn about Customize Menu Items in Blazor Menu Bar  component of Syncfusion, and more details.
platform: Blazor
control: Menu Bar 
documentation: ug
---

# Customize Menu Items

## Add or Remove Menu Items

Menu items can be added or removed using the [`InsertAfter`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.Navigations.SfContextMenu~InsertAfter.html), [`InsertBefore`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.Navigations.SfContextMenu~InsertBefore.html) and [`RemoveItems`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.Navigations.SfContextMenu~RemoveItems.html) methods.

In the following example, the `Europe` menu items are added before the Oceania item, the `Africa` menu items are added after the Asia, and the South America and Mexico items are removed from menu.

```csharp

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

    private List<DataList> industries = new List<DataList>()
    {
        new DataList() { Data = "Industries", SubDatas = new List<DataList>()
        {
            new DataList() { Data = "Logistics"},
            new DataList() { Data = "Insurance" }
        }}
    };

    private List<DataList> addedItems = new List<DataList>()
    {
        new DataList() { Data = "Industries", SubDatas = new List<DataList>()
        {
            new DataList() { Data = "Logistics"},
            new DataList() { Data = "Insurance" }
        }}
    };

    private List<DataList> newItems = new List<DataList>
    {
        new DataList{ Data = "Corporate", SubDatas = new List<DataList>
        {
            new DataList{ Data = "Leadership"},
            new DataList{ Data = "Vision"}
        }
    }
    };

    private List<string> removedItems = new List<string>()
    {
        "Education", "Hardware"
    };

    public void Created()
    {
        this.MenuObj.InsertBefore(addedItems, "Contact Us", false);
        this.MenuObj.InsertAfter(newItems, "Products", false);
        this.MenuObj.RemoveItems(removedItems);
    }
}

```

Output be like

![Menu Sample](./../images/menu-insertbefore.png)

## Enable or Disable Menu Items

You can enable and disable the menu items using the [`Disabled`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.MenuItem.html#Syncfusion_Blazor_Navigations_MenuItem_Disabled) property in Menu items. To disable menuItems, set the `Disabled` property to true and vice-versa.

In the following example, the Directory header item, Conferences, and Music sub menu items are disabled.

```csharp

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

Output be like

![Menu Sample](./../images/menu-enable.png)

## Show or Hide Menu Items

You can show or hide the menu items using the [`Hidden`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.MenuItem.html#Syncfusion_Blazor_Navigations_MenuItem_Hidden) property in Menu items. To hide the menuItems, set the `Hidden` property to true and vice-versa.

In the following example, the Movies header item, Workshops, and Music sub menu items are hidden in menu.

```csharp

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

Output be like

![Menu Sample](./../images/menu-show.png)