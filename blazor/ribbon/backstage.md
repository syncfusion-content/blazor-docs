---
layout: post
title: Backstage in Blazor Ribbon Component | Syncfusion
description: Checkout and learn about Backstage in Blazor Ribbon component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Ribbon
documentation: ug
---

# Ribbon Backstage

The Ribbon component supports a backstage view as an enhancement to the traditional file menu. Backstage view can be used to display options like application settings, user details, and more. It can be configured using the `<RibbonBackstageMenuSettings>` directive.

Backstage menu options are displayed on the left panel, and the corresponding content is shown on the right panel.

## Visibility

You can make the backstage view visible by setting the `Visible` property of the `<RibbonBackstageMenuSettings>` directive to `true`. By default, the backstage view is hidden.

## Adding backstage items

You can add menu items to the backstage view using the `<BackstageMenuItems>` directive. Each menu item can be defined with properties such as `ID`, `Text`, `IconCss`, and content templates.

## Adding footer items

You can add the footer items in the backstage view by setting the `IsFooter` property in the `<BackstageMenuItem>` directive to `true`. These items are displayed at the bottom of the menu. By default, the value is `false`.

## Adding separator

The separators are horizontal lines used to visually divide backstage menu items. You can use the `Separator` property to split the menu items.

## Back button

You can use the `BackButtonSettings` property in the `<RibbonBackstageMenuSettings>` directive to customize the text and icon of the close button using the `Text` and `IconCss` property. You can show the back button by setting the `Visible` property to `true`.

## Template

You can customize the backstage menu items and their content using the `Template` property in the `<RibbonBackstageMenuSettings>` directive.

## Setting width and height

The height and width of the backstage view can be customized using the `Height` and `Width` properties. By default, the dimensions are adjusted to fit the content.
