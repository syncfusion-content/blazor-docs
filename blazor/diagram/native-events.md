# Native events

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

```csharp
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