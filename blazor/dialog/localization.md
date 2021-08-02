---
layout: post
title: Localization in Blazor Dialog Component | Syncfusion
description: Checkout and learn here all about Localization in Syncfusion Blazor Dialog component and much more details.
platform: Blazor
control: Dialog
documentation: ug
---

# Localization in Blazor Dialog Component

Localization library allows you to localize the default text content of Dialog. In Dialog, the close button's tooltip text alone will be localized based on the culture.

> Use `Resource` file to translate the static text of the Dialog. The Resource file is an XML file which contains the strings(key and value pairs) that you want to translate into different language. You can also refer [`Localization`](../../common/localization/) link to know more about how to configure and use localization in the Blazor Server and WebAssembly project for Syncfusion Blazor components.

By using `Locale` property, you can set the culture dynamically in dialog component.

| Locale key | en-US (default) |
|------|------|
| Dialog_Close | Close |

In the following sample, `French` culture is set to Dialog and change the close button's tooltip text.

```cshtml

@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Buttons

<SfButton @onclick="@OpenDialog">Open Dialog</SfButton>

<SfDialog Width="250px" ShowCloseIcon="true" Locale="fr-CH" @bind-Visible="@IsVisible">
    <DialogTemplates>
        <Header> Dialogue </Header>
        <Content> Dialogue avec la culture française </Content>
    </DialogTemplates>
</SfDialog>

@code {
    private bool IsVisible { get; set; } = true;

    private void OpenDialog()
    {
        this.IsVisible = true;
    }
}

```

The output will be as follows.

![dialog](./images/dialog-locale.png)