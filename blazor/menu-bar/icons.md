---
layout: post
title: Icons and submenu Items in Blazor Menu Bar Component | Syncfusion
description: Checkout and learn here all about icons and submenu items in Syncfusion Blazor Menu Bar component and more.
platform: Blazor
control: Menu Bar 
documentation: ug
---

# Icons and submenu Items in Blazor Menu Bar Component

## Icons

The menu item contains an icon/image in it to provide a visual representation of an action. To place the icon on a menu item, set the [IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.MenuItem.html#Syncfusion_Blazor_Navigations_MenuItem_IconCss) property with the required icon CSS. By default, the icon is positioned at the left of the menu item. In the following sample, the icons of `File` and `Edit` menu items and `Open`, `Save`, `Cut`, `Copy`,and `Paste` sub menu items are added using the [IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.MenuItem.html#Syncfusion_Blazor_Navigations_MenuItem_IconCss) property.

```cshtml
<SfMenu TValue="MenuItem">
    <MenuItems>
        <MenuItem Text="File" IconCss="e-icons e-file">
            <MenuItems>
                <MenuItem Text="Open" IconCss="e-icons e-open"></MenuItem>
                <MenuItem Text="Save" IconCss="e-icons e-save"></MenuItem>
                <MenuItem Separator="true"></MenuItem>
                <MenuItem Text="Exit"></MenuItem>
            </MenuItems>
        </MenuItem>
        <MenuItem Text="Edit" IconCss="e-icons e-edit">
            <MenuItems>
                <MenuItem Text="Cut" IconCss="e-icons e-cut"></MenuItem>
                <MenuItem Text="Copy" IconCss="e-icons e-copy"></MenuItem>
                <MenuItem Text="Paste" IconCss="e-icons e-paste"></MenuItem>
            </MenuItems>
        </MenuItem>
        <MenuItem Text="View">
            <MenuItems>
                <MenuItem Text="Toolbars">
                    <MenuItems>
                        <MenuItem Text="Menu Bar"></MenuItem>
                        <MenuItem Text="Bookmarks Toolbar"></MenuItem>
                        <MenuItem Text="Customize"></MenuItem>
                    </MenuItems>
                </MenuItem>
            </MenuItems>
        </MenuItem>
        <MenuItem Text="Zoom">
            <MenuItems>
                <MenuItem Text="Zoom In"></MenuItem>
                <MenuItem Text="Zoom Out"></MenuItem>
                <MenuItem Text="Reset"></MenuItem>
            </MenuItems>
        </MenuItem>
        <MenuItem Text="Tools">
            <MenuItems>
                <MenuItem Text="Spelling & Grammar"></MenuItem>
                <MenuItem Text="Customize"></MenuItem>
                <MenuItem Separator="true"></MenuItem>
                <MenuItem Text="Options"></MenuItem>
            </MenuItems>
        </MenuItem>
        <MenuItem Text="Help"></MenuItem>
    </MenuItems>
</SfMenu>

<style>
    .e-file::before {
        content: '\e7cb';
    }

    .e-edit::before {
        content: '\e78f';
    }

    .e-open::before {
        content: '\e70f';
    }

    .e-save::before {
        content: '\e74d';
    }

    .e-cut::before {
        content: '\e73f';
    }

    .e-copy::before {
        content: '\e77b';
    }

    .e-paste::before {
        content: '\e739';
    }
</style>
```

![Blazor MenuBar with Icons](./images/blazor-menubar-icons.png)

## Navigation

Navigation in Menu Bar is used to navigate to the other web page when a Menu Bar item is clicked. It can be achieved by providing a link to the Menu Bar item using the [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.MenuItem.html#Syncfusion_Blazor_Navigations_MenuItem_Url) property. In the following sample, the Navigation URL is added to sub menu Bar items using the [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.MenuItem.html#Syncfusion_Blazor_Navigations_MenuItem_Url) property.

```cshtml

@using Syncfusion.Blazor.Navigations

<SfMenu TValue="MenuItem">
    <MenuItems>
        <MenuItem Text="Appliances">
            <MenuItems>
                <MenuItem Text="Washing Machine" Url="https://www.google.com/search?q=washing+machine"></MenuItem>
                <MenuItem Text="Air Conditioners" Url="https://www.google.com/search?q=air+conditioners"></MenuItem>
            </MenuItems>
        </MenuItem>
        <MenuItem Text="Mobile">
            <MenuItems>
                <MenuItem Text="Headphones" Url="https://www.google.com/search?q=headphones"></MenuItem>
                <MenuItem Text="Memory Cards" Url="https://www.google.com/search?q=memory+cards"></MenuItem>
                <MenuItem Text="Power Banks" Url="https://www.google.com/search?q=power+banks"></MenuItem>
            </MenuItems>
        </MenuItem>
        <MenuItem Text="Entertainment">
            <MenuItems>
                <MenuItem Text="Televisions" Url="https://www.google.com/search?q=televisions"></MenuItem>
                <MenuItem Text="Home Theatres" Url="https://www.google.com/search?q=home+theatres"></MenuItem>
                <MenuItem Text="Gaming Laptops" Url="https://www.google.com/search?q=gaming+laptops"></MenuItem>
            </MenuItems>
        </MenuItem>
        <MenuItem Text="Fashion" Url="https://www.google.com/search?q=fashion"></MenuItem>
        <MenuItem Text="Offers" Url="https://www.google.com/search?q=offers"></MenuItem>

    </MenuItems>
</SfMenu>
```

![Navigation in Blazor MenuBar](./images/blazor-menubar-navigation.png)

## Multilevel nesting

The Menu Bar supports multiple level nesting, and it can be achieved by mapping the [Items](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.MenuItem.html#Syncfusion_Blazor_Navigations_MenuItem_Items) property inside the parent `MenuItems`.

```cshtml

@using Syncfusion.Blazor.Navigations

<SfMenu TValue="MenuItem">
    <MenuItems>
        <MenuItem Text="Fashion">
            <MenuItems>
                <MenuItem Text="Men Fashion">
                    <MenuItems>
                        <MenuItem Text="Personal Care">
                            <MenuItems>
                                <MenuItem Text="Trimmers"></MenuItem>
                                <MenuItem Text="Shavers"></MenuItem>
                            </MenuItems>
                        </MenuItem>
                        <MenuItem Text="Clothing">
                            <MenuItems>
                                <MenuItem Text="shirts"></MenuItem>
                                <MenuItem Text="Jackets"></MenuItem>
                                <MenuItem Text="TrackSuits"></MenuItem>
                            </MenuItems>
                        </MenuItem>
                    </MenuItems>
                </MenuItem>
                <MenuItem Text="Women Fashion">
                    <MenuItems>
                        <MenuItem Text="Clothing">
                            <MenuItems>
                                <MenuItem Text="Salwars"></MenuItem>
                                <MenuItem Text="Kurtas"></MenuItem>
                                <MenuItem Text="Sarees"></MenuItem>
                            </MenuItems>
                        </MenuItem>
                        <MenuItem Text="Jewellery">
                            <MenuItems>
                                <MenuItem Text="Nosepin"></MenuItem>
                                <MenuItem Text="Anklets"></MenuItem>
                            </MenuItems>
                        </MenuItem>
                    </MenuItems>
                </MenuItem>
            </MenuItems>
        </MenuItem>
        <MenuItem Text="Home & Living">
            <MenuItems>
                <MenuItem Text="Washing Machine">
                    <MenuItems>
                        <MenuItem Text="Fully Automatic"></MenuItem>
                        <MenuItem Text="Semi Automatic"></MenuItem>
                    </MenuItems>
                </MenuItem>
                <MenuItem Text="Air Conditioners">
                    <MenuItems>
                        <MenuItem Text="Inverter AC"></MenuItem>
                        <MenuItem Text="Split AC"></MenuItem>
                    </MenuItems>
                </MenuItem>
            </MenuItems>
        </MenuItem>
        <MenuItem Text="Accessories"></MenuItem>
        <MenuItem Text="Sports"></MenuItem>
        <MenuItem Text="Gaming"></MenuItem>
    </MenuItems>
</SfMenu>
```

![Blazor MenuBar with Multilevel Nesting](./images/blazor-menubar-multilevel-nesting.png)