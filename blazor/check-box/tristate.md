---
layout: post
title: TriState in Blazor CheckBox Component | Syncfusion
description: Checkout and learn here all about the TriState in Syncfusion Blazor CheckBox component and much more.
platform: Blazor
control: Checkbox
documentation: ug
---

# TriState in Blazor CheckBox Component

The Syncfusion Blazor CheckBox component supports a TriState mode that allows the CheckBox to represent three distinct states: Checked, Indeterminate, and Unchecked. This feature is enabled by setting the [EnableTriState](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfCheckBox-1.html#Syncfusion_Blazor_Buttons_SfCheckBox_1_EnableTriState) property to true. 
To properly handle all three states, the bound property must be of type bool? (nullable boolean).

When EnableTriState="true", the checkbox cycles through the following states:
* Checked: Checked = true, Indeterminate = false
* Indeterminate: Checked = null, Indeterminate = true
* Unchecked: Checked = false, Indeterminate = false

This design ensures that the checkbox can represent an indeterminate state in addition to the standard checked and unchecked states.

## Implementation Details
To enable TriState functionality, ensure that the bound property is declared as a nullable boolean (bool?). 
This allows the component to correctly represent all three states.

```cshtml
<SfCheckBox
    @bind-Checked="isChecked"
    Label="Default"
    EnableTriState="true">
</SfCheckBox>

@code {
    private bool? isChecked = true;
}
```
