---
layout: post
title: Appearance in Blazor Chat UI Component | Syncfusion
description: Checkout and learn here all about Appearance with Syncfusion Blazor Chat UI component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Chat UI
documentation: ug
---

# Appearance in Blazor Chat UI component

## Setting placeholder

You can use the `Placeholder` property to set the placeholder text for the textarea. The default value is `Type your message…`.

```cshtml

@using Syncfusion.Blazor.InteractiveChat

<div style="height: 400px; width: 400px;">
    <SfChatUI Placeholder="Start typing..."></SfChatUI>
</div>

```

![Blazor Chat UI Placeholder](./images/placeholder.png)

## Setting width

You can use the `Width` property to set the width of the Chat UI. The default value is `100%`.

```cshtml

@using Syncfusion.Blazor.InteractiveChat

<div style="height: 400px;">
    <SfChatUI Width="400px"></SfChatUI>
</div>

```

![Blazor Chat UI Width](./images/width.png)

## Setting height

You can use the `Height` property to set the height of the Chat UI. The default value is `100%`.

```cshtml

@using Syncfusion.Blazor.InteractiveChat

<div style="width: 400px;">
    <SfChatUI Height="400px"></SfChatUI>
</div>

```

![Blazor Chat UI Height](./images/width.png)

## Setting CSS class

You can customize the appearance of the Chat UI component by using the `CssClass` property.

```cshtml

@using Syncfusion.Blazor.InteractiveChat

<div style="height: 400px; width: 400px;">
    <SfChatUI CssClass="custom-container"></SfChatUI>
</div>

<style>
    .custom-container {
        border-color: #e0e0e0;
        background-color: #f4f4f4;
        box-shadow: 3px 3px 10px 0px rgba(0, 0, 0, 0.2);
    }

    .custom-container .e-chat-header {
        background: #0c888e;
    }

    .custom-container .e-footer .e-input-group {
        border: 3px solid #bde0e2;
    }
</style>

```

![Blazor Chat UI CssClass](./images/cssclass.png)
