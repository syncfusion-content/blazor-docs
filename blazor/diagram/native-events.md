---
layout: post
title: Native Events in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Native Events in Syncfusion Blazor Diagram component and much more.
platform: Blazor
control: Diagram
documentation: ug
---

# Native Events in Blazor Diagram Component

The Diagram control provides event support, which triggers while interacting with the diagram. Also, Syncfusion provides native event support in blazor for the following events

| Event Name | Event Type |
| -------- | -------- |
| onfocus | FocusEventArgs |
| onclick | MouseEventArgs |
| onmousemove | MouseEventArgs |
| onmouseover | MouseEventArgs |
| onmouseout | MouseEventArgs |
| onmousedown | MouseEventArgs |
| onmouseup | MouseEventArgs |
| ondblclick | MouseEventArgs |
| onkeydown | KeyboardEventArgs |
| onkeyup | KeyboardEventArgs |
| ondrop | DragEventArgs |

The native events can be defined as mentioned below. For example, the onmousedown event in diagram.

```cshtml
@using Syncfusion.Blazor.Diagrams
<SfDiagram @onmousedown="@OnMouseDown" Height="600px"/>

@code
{
    public void OnMouseDown(MouseEventArgs args)
    {
        //Action to be performed
    }
}
```