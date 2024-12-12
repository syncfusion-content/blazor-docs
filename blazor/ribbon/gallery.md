---
layout: post
title: Gallery in Blazor Ribbon Component | Syncfusion
description: Checkout and learn about Gallery in Blazor Ribbon component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Ribbon
documentation: ug
---

# Gallery Items in Blazor Ribbon component

The Ribbon supports a gallery view, allowing users to interact with a collection of related items such as icons, text, or images. You can render gallery items by setting the `Type` property of a Ribbon item to `RibbonItemType.Gallery` and customize it using the `<RibbonGallerySettings>` tag directive. The settings provide options like `Groups`, `ItemCount`, `PopupHeight`, `PopupWidth`, and more.

## Groups

You can render groups inside the gallery using the `Groups` property of the `<RibbonGallerySettings>` tag directive. Groups can be customized using `<GalleryGroup>` tag directive with properties like `Items`, `CssClass`, `Header`, etc.

### Adding items

Gallery items can be added using `<GalleryItem>` tag directive within the `Items` property of a group. Items are customizable with properties such as `Content`, `IconCss`, `Disabled`, and more.

#### Adding content

You can use the `Content` property to define the text content for the gallery item.

#### Adding icons

You can use the `IconCss` property to define the icons for the gallery item.

#### Adding html attributes

You can use the `HtmlAttributes` property to add custom HTML attributes to the Ribbon gallery item.

#### Css class

You can use the `CssClass` property to customize the gallery item.

#### Disabled

You can use the `Disabled` property to disable a particular gallery item which prevents the user interaction when set to `true`. By default, the value is `false`.

### Custom header

You can use the `Header` property to set header for the groups in the Ribbon gallery popup.

### Setting item dimensions

You can specify the width and height of gallery items using the `ItemWidth` and `ItemHeight` properties within a `<GalleryGroup>`. If the `ItemHeight` of the gallery item is smaller, then the remaining gallery items are aligned based on the `ItemCount` specified.

### Group styling

You can use the `CssClass` property within the `<GalleryGroup>` to customize the appearance of gallery groups.

## Setting item count

You can customize the number of items to be displayed in Ribbon gallery by using the `ItemCount` property. By default, the `ItemCount` is set to `3`.

## Setting selected item

You can use the `SelectedItemIndex` property to define the currently selected item in the Ribbon gallery items.

## Setting popup dimensions

You can specify the width and height of the gallery popup by using the `PopupWidth` and `PopupHeight` properties within the `<RibbonGallerySettings>`.

## Template

You can customize the default appearance and content of Ribbon gallery items by using the `Template` property.

### Popup Template

You can customize the appearance of Ribbon gallery popup by using the `PopupTemplate` property.

## Events

The following events are available in the Ribbon Gallery.

* `PopupOpening` - GalleryPopupOpenEventArgs
* `PopupClosing` - GalleryPopupCloseEventArgs
* `ItemHover` - GalleryItemHoverEventArgs
* `ItemRendering` - GalleryItemRenderEventArgs
* `Selecting` - GallerySelectEventArgs
* `Selected` - GallerySelectedEventArgs