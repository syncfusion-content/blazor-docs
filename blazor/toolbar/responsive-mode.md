---
layout: post
title: Responsive Mode in Blazor Toolbar Component | Syncfusion
description: Checkout and learn here all about responsive mode in Syncfusion Blazor Toolbar component and much more.
platform: Blazor
control: Toolbar
documentation: ug
---

# Responsive Mode in Blazor Toolbar Component

This section explains the supported display modes of the Toolbar when the content exceeds the viewing area. Possible modes are:

* Scrollable
* Popup
* MultiRow
* Extended

## Scrollable

The default [`OverflowMode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfToolbar.html#Syncfusion_Blazor_Navigations_SfToolbar_OverflowMode) of the Toolbar is `Scrollable`. This mode displays toolbar items in a single line with horizontal scrolling enabled when items overflow the available space.

*   Right and left navigation arrows are added to the start and end of the Toolbar to navigate to hidden items.
*   Hidden items are also viewable using touch swipe actions.
*   By default, the left navigation icon is disabled. View hidden items by moving to the `right`.
*   Clicking an arrow or holding it continuously makes hidden items visible.
*   On devices, if navigation icons are not available, utilize touch swipe gestures to view hidden Toolbar items.
*   Once the Toolbar reaches the last or first item, the corresponding navigation icon is disabled, restricting further movement in that direction.

![Blazor Toolbar with Touch Scroll](images/blazor-toolbar-scrolling-touch.gif)

* The Toolbar content can be continuously scrolled by holding the navigation icon.

![Blazor Toolbar with Long Press Scroll](images/blazor-toolbar-long-press-scrolling.gif)

```cshtml

@using Syncfusion.Blazor.Navigations

<SfToolbar Width="600">
    <ToolbarItems>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-cut" Text="Cut"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-copy" Text="Copy"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-paste" Text="Paste"></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-bold" Text="Bold"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-underline" Text="Underline"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-italic" Text="Italic"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-paint-bucket" Text="Color-Picker"></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-list-unordered" Text="Bullets"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-list-ordered" Text="Numbering"></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-sort-ascending" Text="Sort A - Z"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-sort-descending" Text="Sort Z - A"></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-upload-1" Text="Upload"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-download" Text="Download"></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-increase-indent" Text="Text Indent"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-decrease-indent" Text="Text Outdent"></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-erase" Text="Clear"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-refresh" Text="Reload"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-export" Text="Export"></ToolbarItem>
    </ToolbarItems>
</SfToolbar>
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXhoitCZzVqTpUBZ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Scrolling in Blazor Toolbar](./images/blazor-toolbar-scrolling.png)" %}

## Popup

`Popup` is another [`OverflowMode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfToolbar.html#Syncfusion_Blazor_Navigations_SfToolbar_OverflowMode) where the Toolbar container holds items that fit in the available space. The remaining overflowing items, which do not fit within the viewing area, are moved to an overflow popup container.

Items within the popup can be viewed by opening the popup via the dropdown icon located at the end of the Toolbar.

![Blazor Toolbar with Overflow Dropdown Popup](./images/blazor-toolbar-with-overflow-dropdown-popup.png)

N> If the popup content exceeds the height of the page, overflowing items will not be visible.

```cshtml

@using Syncfusion.Blazor.Navigations

<SfToolbar Width="380" OverflowMode="OverflowMode.Popup">
    <ToolbarItems>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-cut" Text="Cut"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-copy" Text="Copy"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-paste" Text="Paste"></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-bold" Text="Bold"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-underline" Text="Underline"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-italic" Text="Italic"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-paint-bucket" Text="Color-Picker"></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-erase" Text="Clear"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-refresh" Text="Reload"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-export" Text="Export"></ToolbarItem>
    </ToolbarItems>
</SfToolbar>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BNVoijsXzLKbvuYU?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Toolbar Item in Popup Mode](./images/blazor-toolbar-item-popup-mode.png)" %}

### Priority of Items

Default popup priority is `None`. When Toolbar items overflow, those listed last are moved to the popup.

The priority of items for display on the Toolbar and in the popup can be customized using the `Overflow` property.

Property     | Description
------------ | -------------
  Show       | Always shows items on the `Toolbar with primary` priority.
  Hide       | Always shows items in the `popup with secondary` priority.
  None       | No priority display, and as per the `normal order` Items are moved to popup when content exceeds viewing area.

If primary priority Items also exceed the available space, they are moved to the popup container at the top order position and placed before the secondary priority Items.

N> The toolbar item can be maintained on popup always by using the [ShowAlwaysInPopup](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ToolbarItem.html#Syncfusion_Blazor_Navigations_ToolbarItem_ShowAlwaysInPopup) property, and this behavior is not applicable for toolbar items with [Overflow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ToolbarItem.html#Syncfusion_Blazor_Navigations_ToolbarItem_Overflow) property as 'Show'.

### Text mode for buttons

The `ShowTextOn` property is used to decide button text display area on the Toolbar, popup, or both. This is useful for customization of both text and image representation of Items.

For example, display icon-only buttons on the Toolbar, and in the popup container, display more information about the items, including both icon and text.

Possible values are,

  Property   | Description
------------ | -------------
  Both     | Button text is visible in both `Toolbar` and `Popup`.
  Overflow | Button text is only visible in `Popup`.
  Toolbar  | Button text is only visible on the `Toolbar`.

In the following code sample, text is only visible in the popup container and not in the Toolbar container.

```cshtml

@using Syncfusion.Blazor.Navigations

<SfToolbar Width="300" OverflowMode="OverflowMode.Popup">
    <ToolbarItems>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-cut" Text="Cut" ShowTextOn="DisplayMode.Overflow" Overflow="OverflowOption.Show"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-copy" Text="Copy" ShowTextOn="DisplayMode.Overflow" Overflow="OverflowOption.Show"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-paste" Text="Paste" ShowTextOn="DisplayMode.Overflow" Overflow="OverflowOption.Show"></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-bold" Text="Bold" ShowTextOn="DisplayMode.Overflow" Overflow="OverflowOption.Show"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-underline" Text="Underline" ShowTextOn="DisplayMode.Overflow" Overflow="OverflowOption.Show"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-italic" Text="Italic" ShowTextOn="DisplayMode.Overflow" Overflow="OverflowOption.Show"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-paint-bucket" Text="Color-Picker" ShowTextOn="DisplayMode.Overflow" Overflow="OverflowOption.Show"></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-erase" Text="Clear" ShowTextOn="DisplayMode.Overflow" Overflow="OverflowOption.Show"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-refresh" Text="Reload" ShowTextOn="DisplayMode.Overflow" Overflow="OverflowOption.Show"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-export" Text="Export" ShowTextOn="DisplayMode.Overflow" Overflow="OverflowOption.Show"></ToolbarItem>
    </ToolbarItems>
</SfToolbar>
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZLeCXijTVTcokhS?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Displaying Blazor Toolbar Item in Overflow](./images/blazor-toolbar-item-in-overflow.png)" %}

## MultiRow

`MultiRow` is another [`OverflowMode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfToolbar.html#Syncfusion_Blazor_Navigations_SfToolbar_OverflowMode) where the Toolbar container holds items that fit in the available space. The remaining overflowing items, which do not fit within the viewing area, are displayed as an inline row within the toolbar itself.

```cshtml

@using Syncfusion.Blazor.Navigations

<SfToolbar Width="380" OverflowMode="OverflowMode.MultiRow">
    <ToolbarItems>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-cut" Text="Cut"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-copy" Text="Copy"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-paste" Text="Paste"></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-bold" Text="Bold"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-underline" Text="Underline"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-italic" Text="Italic"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-paint-bucket" Text="Color-Picker"></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-erase" Text="Clear"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-refresh" Text="Reload"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-export" Text="Export"></ToolbarItem>
    </ToolbarItems>
</SfToolbar>
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/htLSijMXTVoswbPi?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Toolbar Item with MultiRow](./images/blazor-toolbar-item-with-multirow.png)" %}

## Extended

`Extended` is another [`OverflowMode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfToolbar.html#Syncfusion_Blazor_Navigations_SfToolbar_OverflowMode) where the Toolbar container holds items that fit in the available space. The remaining overflowing items, which do not fit within the viewing area, are displayed in the next row.

```cshtml

@using Syncfusion.Blazor.Navigations

<SfToolbar Width="380" OverflowMode="OverflowMode.Extended">
    <ToolbarItems>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-cut" Text="Cut"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-copy" Text="Copy"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-paste" Text="Paste"></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-bold" Text="Bold"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-underline" Text="Underline"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-italic" Text="Italic"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-paint-bucket" Text="Color-Picker"></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-erase" Text="Clear"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-refresh" Text="Reload"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" PrefixIcon="e-icons e-export" Text="Export"></ToolbarItem>
    </ToolbarItems>
</SfToolbar>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hNroCNiZJhSGdfxr?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Toolbar Item with Extended Mode](./images/blazor-toolbar-item-extended-mode.gif)" %}