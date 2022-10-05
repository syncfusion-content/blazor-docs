---
layout: post
title: Styles in Blazor FloatingActionButton Component | Syncfusion
description: Checkout and learn here all about Styles in Syncfusion Blazor FloatingActionButton component and much more.
platform: Blazor
control: FloatingActionButton
documentation: ug
---

# Styles in Blazor Floating Action Button Component

This section explains the different styles of Floating Action Button.

## Floating Action Button styles

The Blazor Floating Action Button has the following predefined styles that can be defined using the [CssClass]property for represent primary action we have IsPrimary property(https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfFab.html#Syncfusion_Blazor_Buttons_SfFab_IsPrimary).

| Class | Description |
| -------- | -------- |
| e-success | Used to represent a positive action. |
| e-info |  Used to represent an informative action. |
| e-warning | Used to represent an action with caution. |
| e-danger | Used to represent a negative action. |
| e-link |  Changes the appearance of the Button like a hyperlink. |

```csharp

@using Syncfusion.Blazor.Buttons

<SfFab IsPrimary=true Content="Primary"></SfFab>
<SfFab CssClass="e-success" Content="Success"></SfFab>
<SfFab CssClass="e-info" Content="Info"></SfFab>
<SfFab CssClass="e-warning" Content="Warning"></SfFab>
<SfFab CssClass="e-danger" Content="Danger"></SfFab>
<SfFab CssClass="e-link" Content="Link"></SfFab>

```


![Blazor Button Component with different Styles]()
