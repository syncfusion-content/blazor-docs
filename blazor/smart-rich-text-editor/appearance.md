---
layout: post
title: Customizing AI Assistant Popup | Syncfusion Blazor Smart Rich Text Editor
description: Learn how to customize the AI Assistant popup styling with CSS animations and processing states.
platform: Blazor
control: Smart Rich Text Editor
documentation: ug
---

# Customizing the AI Assistant Popup

## Styling the Popup

The AI Assistant Popup can be styled using the following CSS class:

```css
.e-rte-aiquery-dialog.e-dlg-modal.e-popup {
    color: white;
    background: white;
    z-index: 1;
}
```
---

## Example: Custom Popup Styling

In this example, we customize the AI Assistant popup appearance by targeting the `.e-rte-aiquery-dialog.e-aiassistview` selector.

```razor
@using Syncfusion.Blazor.SmartRichTextEditor

<SfSmartRichTextEditor Height="300"></SfSmartRichTextEditor>

<style>
    .e-rte-aiquery-dialog .e-aiassistview {
        border-color: #e0e0e0;
        background-color: #f4f4f4;
        box-shadow: 3px 3px 10px 0px rgba(0, 0, 0, 0.2);
    }

    .e-rte-aiquery-dialog .e-aiassistview .e-view-header .e-toolbar,
    .e-rte-aiquery-dialog .e-aiassistview .e-view-header .e-toolbar-items {
        background: #d5d5d5;
    }
    
    .e-rte-aiquery-dialog .e-aiassistview .e-view-content .e-toolbar,
    .e-rte-aiquery-dialog .e-aiassistview .e-view-content .e-toolbar .e-toolbar-items,
    .e-rte-aiquery-dialog .e-aiassistview .e-view-content .e-toolbar .e-toolbar-item {
        background: #f4f4f4;
    }

    .e-rte-aiquery-dialog .e-aiassistview .e-view-content .e-footer {
        border: 3px solid #e0e0e0;
    }
</style>
```

![Blazor Smart Rich Text Editor AI AssistView Custom Class](./images/ai-assistview-custom-class.png)


This shows how to customize the assistant by targeting the `.e-rte-aiquery-dialog.e-aiassistview` selector for fine-grained control over the popup's appearance.
---

## See Also

* [Properties](property.md)
* [Methods](method.md)
* [Events](events.md)
