---
layout: post
title: Native Events in Blazor Radio Button | Syncfusion
description: Attach native DOM events such as change, click, and focus to Blazor Radio Button with event argument types.
platform: Blazor
control: Radio Button
documentation: ug
---

# Native Events in Blazor Radio Button

Attach native DOM events to the Blazor Radio Button component using the `@on{event}` attribute (for example, `@onchange`, `@onclick`). The attribute value is an event handler method, and the event-specific data is provided via the event argument parameter.

The different event argument types for each event category are:

* Focus Events — `Microsoft.AspNetCore.Components.Web.FocusEventArgs`
* Mouse Events — `Microsoft.AspNetCore.Components.Web.MouseEventArgs`
* Keyboard Events — `Microsoft.AspNetCore.Components.Web.KeyboardEventArgs`
* Touch Events — `Microsoft.AspNetCore.Components.Web.TouchEventArgs`

## List of Native Events Supported

The following native event support has been provided to the Blazor Radio Button component:

| Event | Description |
| --- | --- |
| `onchange` | Raised when the checked state changes. |
| `oninput` | Raised on every value change while the user interacts with the input. |
| `onblur` | Raised when the Blazor Radio Button component loses focus. |
| `onfocus` | Raised when the Blazor Radio Button component gains focus. |
| `onfocusin` | Raised when focus moves into the Blazor Radio Button component (bubbles). |
| `onfocusout` | Raised when focus moves out of the Blazor Radio Button component (bubbles). |
| `onclick` | Raised when the Blazor Radio Button component is clicked. |
| `onkeydown` | Raised when a key is pressed while the Blazor Radio Button component has focus. |
| `onkeyup` | Raised when a key is released while the Blazor Radio Button component has focus. |
| `onkeypress` | Raised when a key that produces a character is pressed. |

## How to Bind `onchange` to the Blazor Radio Button

Use the `onchange` attribute to bind the change event for a Blazor Radio Button. The following example shows how to access the event arguments in the handler. The `TChecked` generic parameter is set explicitly to `string` so the event handler can read the new value via `args.Value`.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfRadioButton Label="Credit/Debit Card" Name="payment" Value="credit/debit" TChecked="string" @onchange="OnChange" @bind-Checked="stringChecked"></SfRadioButton>
<br />
<SfRadioButton Label="Net Banking" Name="payment" Value="netbanking" TChecked="string" @onchange="OnChange" @bind-Checked="stringChecked"></SfRadioButton>

@code {
    private string stringChecked = "netbanking";
    private void OnChange(Microsoft.AspNetCore.Components.ChangeEventArgs args)
    {
        // The new value is available in args.Value
        var selected = args.Value?.ToString();
        // Handle the change here, for example, update UI or trigger validation
    }
}
```

![Blazor Radio Button with Native Event](./images/blazor-radiobutton-native-event.webp)

## How to Bind `onclick` and Keyboard Events

The following example shows how to attach mouse and keyboard native events to capture user interaction. The `MouseEventArgs` types are imported from `Microsoft.AspNetCore.Components.Web` so the handler signatures are explicit.

```cshtml
@using Syncfusion.Blazor.Buttons
@using Microsoft.AspNetCore.Components.Web

<SfRadioButton Label="Option A" Name="group" Value="A" TChecked="string"
               @onclick="OnClick" @bind-Checked="stringChecked"></SfRadioButton>
<br />
<SfRadioButton Label="Option B" Name="group" Value="B" TChecked="string"
               @onclick="OnClick" @bind-Checked="stringChecked"></SfRadioButton>

@code {
    private string stringChecked = "A";

    private void OnClick(MouseEventArgs args)
    {
        // Handle the click event
    }
}
```

## See Also

* [Blazor Radio Button API reference](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfRadioButton-1.html)