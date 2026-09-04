---
layout: post
title: Popup Settings in Blazor InPlace Editor | Syncfusion®
description: Learn how to use the AppendTo property in Blazor InPlace Editor to control popup placement and ensure correct display in custom containers.
platform: Blazor
control: InPlace Editor
documentation: ug
---

# Popup Settings in Blazor InPlace Editor

## Render popup in a custom container

Use the `AppendTo` property to render the InPlace Editor popup inside a specific container instead of the default `document.body`. This is useful when the component is placed inside dialogs, side panels, containers with overflow restrictions, or custom stacking contexts.

Specify a valid CSS selector in the `AppendTo` property. When the selector matches an element, the popup is appended to that element. If the selector is null, empty, or no matching element is found, the popup is rendered in the default location.

{% highlight cshtml %}

@using Syncfusion.Blazor.InPlaceEditor
@using Syncfusion.Blazor.Inputs

<div id="popupHost">
<table>
    <tr>
        <td>
            <label class="control-label" style="text-align: left;font-size: 14px;font-weight: 400">
                TextBox
            </label>
        </td>
        <td>
            <SfInPlaceEditor @bind-Value="@TextValue" TValue="string" AppendTo="@AppendTarget">
                <EditorComponent>
                    <SfTextBox @bind-Value="@TextValue" Placeholder="Enter employee name"></SfTextBox>
                </EditorComponent>
            </SfInPlaceEditor>
        </td>
    </tr>
</table>
</div>

@code {
    private string AppendTarget = "#popupHost";
    public string TextValue = "Andrew";
}

{% endhighlight %}

> The `AppendTo` property accepts a CSS selector such as `#elementId` or `.container`. If the specified element is not found, the popup element will be appended to `document.body`.
