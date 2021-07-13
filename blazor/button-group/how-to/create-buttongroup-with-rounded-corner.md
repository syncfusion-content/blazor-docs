---
layout: post
title: How to Create Buttongroup With Rounded Corner in Blazor ButtonGroup Component | Syncfusion
description: Checkout and learn about Create Buttongroup With Rounded Corner in Blazor ButtonGroup component of Syncfusion, and more details.
platform: Blazor
control: ButtonGroup
documentation: ug
---

# Create ButtonGroup with rounded corner

The ButtonGroup with rounded corner has round edges on both sided. To ButtonGroup with rounded corner, `e-round-corner` class is to be
added to the target element.

The following example illustrates how to create ButtonGroup with rounded corner.

`Index.razor`

```csharp

<div class='e-btn-group e-round-corner'>
    <EjsButton ID="html" Content="HTML"></EjsButton>
    <EjsButton ID="css" Content="CSS"></EjsButton>
    <EjsButton ID="javascript" Content="Javascript"></EjsButton>
</div>

  ```