---
layout: post
title: Template in Blazor Toast Component | Syncfusion
description: Checkout and learn here all about template in Syncfusion Blazor Toast component and much more details.
platform: Blazor
control: Toast
documentation: ug
---

# Template in Blazor Toast Component

This section explains how to customize the layout and content of the Syncfusion Blazor Toast using templates. Two approaches are covered:
- Defining a full markup template using ToastTemplates and Template for static layouts.
- Providing a programmatic template via the ContentTemplate property at runtime.

For component and API details, see:
- Component overview: Blazor Toast (https://blazor.syncfusion.com/documentation/toast/overview)
- API reference: SfToast (https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.SfToast.html), ToastTemplates (https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.ToastTemplates.html), Template (https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.ToastTemplates.html#syncfusionblazornotificationstoasttemplates-template), ToastPosition (https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.ToastPosition.html), ToastModel (https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.ToastModel.html), ShowAsync (https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.SfToast.html#Syncfusion_Blazor_Notifications_SfToast_ShowAsync_Syncfusion_Blazor_Notifications_ToastModel_), ContentTemplate (https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.ToastModel.html#Syncfusion_Blazor_Notifications_ToastModel_ContentTemplate)


## Full template using ToastTemplates/Template

A full-toast template can be defined by placing markup inside ToastTemplates and specifying Template. This approach suits static or markup-defined layouts where the content does not change per notification.

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Notifications

<SfButton CssClass="e-primary" @onclick="ShowToast">Show Toast</SfButton>

<SfToast ID="template_toast" @ref="ToastObj" Width="320px" Timeout="5000">
    <ToastPosition X="Right" Y="Bottom"></ToastPosition>
    <ToastTemplates>
        <Template>
            <div class="e-toast-template">
                <div class="e-toast-message">
                    <div class="e-toast-title">Order Updated</div>
                    <div class="e-toast-content">Order #10248 has been updated successfully.</div>
                </div>
            </div>
        </Template>
    </ToastTemplates>
</SfToast>

@code {
    private SfToast ToastObj;

    private async Task ShowToast()
    {
        await ToastObj.ShowAsync();
    }
}
```

Preview
- A toast appears at the bottom-right with the title “Order Updated” and the message “Order #10248 has been updated successfully.”
- The toast auto-hides after 5 seconds.

## Programmatic template using ContentTemplate

For dynamic scenarios, a RenderFragment can be assigned to the ContentTemplate property when showing the toast programmatically. This approach is suitable when the template content is constructed at runtime based on application state.

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Notifications

<SfButton CssClass="e-primary" @onclick="ShowToastWithTemplate">Show Programmatic Toast</SfButton>

<SfToast @ref="ToastObj2" Width="320px" Timeout="5000">
    <ToastPosition X="Right" Y="Bottom"></ToastPosition>
</SfToast>

@code {
    private SfToast ToastObj2;

    // Programmatic template (RenderFragment) created in code
    private RenderFragment DynamicTemplate(string title, string message) => @<div class="e-toast-template">
        <div class="e-toast-message">
            <div class="e-toast-title">@title</div>
            <div class="e-toast-content">@message</div>
        </div>
    </div>;

    private async Task ShowToastWithTemplate()
    {
        var model = new ToastModel
        {
            ContentTemplate = DynamicTemplate("New Message", "A new message has arrived in the inbox.")
        };
        await ToastObj2.ShowAsync(model);
    }
}
```

Preview
- A toast appears at the bottom-right with the title “New Message” and the message “A new message has arrived in the inbox.”
- The template is provided at runtime via ContentTemplate.