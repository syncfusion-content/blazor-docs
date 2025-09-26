---
layout: post
title: Localization and RTL in Blazor Dropdown Tree Component | Syncfusion
description: Checkout and learn here all about Localization and RTL in Syncfusion Blazor Dropdown Tree component and more.
platform: Blazor
control: Dropdown Tree
documentation: ug
---


# Localization and RTL in Blazor Dropdown Tree Component

## Localization

The Blazor Dropdown Tree component supports `localization`, allowing default text content to be adapted for different languages (e.g., Arabic, German, French). This involves defining a `Locale` value and a corresponding translation object. For an in-depth introduction and guide on configuring localization in a Blazor application, refer to the [How to enable Localization in Blazor application](https://blazor.syncfusion.com/documentation/common/localization/#how-to-enable-localization-in-blazor-application) page.

To localize the Dropdown Tree, modify the default values in `.res` files located in your project's `Resource` folder. Enter the locale key (from the table below) in the `Name` column and the translated string in the `Value` column.

The following table lists the locale keys and their default English (`en-US`) and German (`de`) translations used in the Dropdown Tree:

| **Locale key** | **en-US (default culture)** | **de (Deutsch culture)** |
| ------------ | ----------------------- | --------------------|
| `DropDownTree_SelectAll`  | `Select All` | `Wählen Sie Alle` |
| `DropDownTree_UnSelectAll`  | `Unselect All` | `Alles wiederufen` |
| `DropDownTree_NoRecords` | `No records found` | `Keine Einträge vorhanden` |
| `DropDownTree_RequestFailed` | `Request failed` | `Die Anfrage ist fehlgeschlagen` |

## RTL

The Blazor Dropdown Tree component provides full support for Right-To-Left (RTL) rendering. This feature helps to render the Dropdown Tree UI from right to left, which is essential for languages such as Arabic, Hebrew, and Persian. For detailed instructions on enabling RTL in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components, refer to the general [Right-To-Left Support](https://blazor.syncfusion.com/documentation/common/right-to-left) topic.