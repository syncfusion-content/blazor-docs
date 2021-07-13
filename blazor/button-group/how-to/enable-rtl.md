---
layout: post
title: How to Enable Rtl in Blazor ButtonGroup Component | Syncfusion
description: Checkout and learn about Enable Rtl in Blazor ButtonGroup component of Syncfusion, and more details.
platform: Blazor
control: ButtonGroup
documentation: ug
---

# Enable RTL

ButtonGroup supports RTL functionality. This can be achieved by adding `e-rtl` class to the target element.

The following example illustrates how to create ButtonGroup with RTL support.

`Index.razor`

```csharp

  <div class='e-btn-group e-rtl'>
    <EjsButton ID="html" Content="HTML"></EjsButton>
    <EjsButton ID="css" Content="CSS"></EjsButton>
    <EjsButton ID="javascript" Content="Javascript"></EjsButton>
</div>

  ```