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

The `Localization` library allows you to localize default text content of the Dropdown Tree. The Dropdown Tree component has static text for select all checkbox, no records element and action failure element that can be changed to other cultures (Arabic, Deutsch, French, etc.) by defining the locale value and translation object. You can refer [How to enable Localization in Blazor application](https://blazor.syncfusion.com/documentation/common/localization/#how-to-enable-localization-in-blazor-application) page for the introduction and configuring the localization.

You can modify the default value in `.res` file added to Resource folder. Enter the key value (Locale Keywords) in the `Name` column and the translated string in the `Value` column. The following list of keys and their values are used in the Dropdown Tree.

| **Locale key** | **en-US (default culture)** | **de (Deutsch culture)** |
| ------------ | ----------------------- | --------------------|
| `DropDownTree_SelectAll`  | `Select All` | `Wählen Sie Alle` |
| `DropDownTree_UnSelectAll`  | `Unselect All` | `Alles wiederufen` |
| `DropDownTree_NoRecords` | `No records found` | `Keine Einträge vorhanden` |
| `DropDownTree_RequestFailed` | `Request failed` | `Die Anfrage ist fehlgeschlagen` |

## RTL

Dropdown Tree component has `RTL` support. It helps to render the Dropdown Tree from right-to-left direction. Refer to the [Right-To-Left Support](https://blazor.syncfusion.com/documentation/common/right-to-left) topic to enable the `RTL` in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components
