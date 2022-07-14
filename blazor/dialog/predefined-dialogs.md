---
layout: post
title: Predefined dialog in Blazor Dialog Component | Syncfusion
description: Checkout and learn here all about Predefined dialog in Syncfusion Blazor Dialog component and much more.
platform: Blazor
control: Dialog
documentation: ug
---

# Predefined dialogs in Blazor Dialog componen

The dialog component is used to render the `Alert`, `Confirm` and `Prompt` dialogs with the minimal code. The alert, confirm and prompt dialogs are shown using [DialogServices](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfDialogService.html).

## Configuration

### Blazor Server App

* For **.NET 6** app, open the **~/Program.cs** file and import Syncfusion.Blazor.Popups.

* For **.NET 5 and .NET 3.X** app, open the **~/Startup.cs** file and import Syncfusion.Blazor.Popups.

{% tabs %}
{% highlight c# tabtitle=".NET 6 (~/Program.cs)" hl_lines="3 10" %}

@using Syncfusion.Blazor.Popups

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<SfDialogService>();
builder.Services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; });

var app = builder.Build();
....

{% endhighlight %}

{% highlight c# tabtitle=".NET 5 and .NET 3.X (~/Startup.cs)" hl_lines="1 12" %}

@using Syncfusion.Blazor.Popups

namespace BlazorApplication
{
    public class Startup
    {
        ...
        public void ConfigureServices(IServiceCollection services)
        {
         	services.AddRazorPages();
    		services.AddServerSideBlazor();
    		services.AddScoped<SfDialogService>();
            services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; });
    		services.AddServerSideBlazor().AddCircuitOptions(options => { options.DetailedErrors = true; });
    		services.AddServerSideBlazor().AddHubOptions(o =>
        }
        ...
    }
}

{% endhighlight %}
{% endtabs %}

### Blazor WebAssembly App

Open **~/Program.cs** file and register the Syncfusion Blazor Service in the client web app.

{% tabs %}
{% highlight C# tabtitle=".NET 6 (~/Program.cs)" hl_lines="3 11" %}

@using Syncfusion.Blazor.Popups

// Add services to the container.

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<SfDialogService>();
builder.Services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; });
await builder.Build().RunAsync();
....

{% endhighlight %}

{% highlight c# tabtitle=".NET 5 and .NET 3.X (~/Program.cs)" hl_lines="1 10" %}

@using Syncfusion.Blazor.Popups

namespace WebApplication1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            ....
            builder.Services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; });
            builder.Services.AddScoped<SfDialogService>();
            await builder.Build().RunAsync();
        }
    }
}

{% endhighlight %}
{% endtabs %}

open  **~/_MainLayout.razor** file and add SfDialogProvider

{% tabs %}
{% highlight razor tabtitle="~/_MainLayout.razor" %}

<Syncfusion.Blazor.Popups.SfDialogProvider/>

{% endhighlight %}
{% endtabs %}

## Available Predefined dialogs

There are three available predefined dialogs:

        * Alert
        * Confirm
        * Prompt

### Alert

An [Alert](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfDialogService.html#Syncfusion_Blazor_Popups_SfDialogService_AlertAsync_System_String_System_String_Syncfusion_Blazor_Popups_DialogOptions_) dialog box is used to display errors, warnings, and information that needs user awareness.

Use the following code to render a simple alert dialog in an application.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/alert-dialog.razor %}

{% endhighlight %}
{% endtabs %}

![Alert Dialog](./images/blazor-alert-dialog.png)

### Confirm

A [Confirm](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfDialogService.html#Syncfusion_Blazor_Popups_SfDialogService_ConfirmAsync_System_String_System_String_Syncfusion_Blazor_Popups_DialogOptions_) dialog displays a specified message along with ‘OK’ and ‘Cancel’ button. Used to get approval from user that appears before any critical action.

Use the following code to render a simple confirm dialog in an application.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/confirm-dialog.razor %}

{% endhighlight %}
{% endtabs %}

![Confirm Dialog](./images/blazor-confirm-dialog.png)

### Prompt

A [Prompt](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfDialogService.html#Syncfusion_Blazor_Popups_SfDialogService_PromptAsync_System_String_System_String_Syncfusion_Blazor_Popups_DialogOptions_) dialog is used to get input from the user. When the user enters "OK", the input value is returned. When they click "Cancel", the null value  returned.

Use the following code to render a simple prompt dialog in an application.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/prompt-dialog.razor %}

{% endhighlight %}
{% endtabs %}

![Prompt Dialog](./images/blazor-prompt-dialog.png)

## Dragging

The Dialog supports to drag within its target container by grabbing the Dialog header, which allows the user to reposition the Dialog dynamically by using [AllowDragging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfDialog.html#Syncfusion_Blazor_Popups_SfDialog_AllowDragging) property.

{% tabs %}

{% highlight tabtitle="alert.razor" %}
{% include_relative code-snippet/alert-drag.razor %}
{% endhighlight %}

{% highlight tabtitle="confirm.razor" %}
{% include_relative code-snippet/confirm-drag.razor %}
{% endhighlight %}

{% highlight tabtitle="prompt.razor" %}
{% include_relative code-snippet/prompt-drag.razor %}
{% endhighlight %}

{% endtabs %}

## Animations

The predefined ialog can be animated during the open and close actions. Also, users can customize animation’s [DialogAnimationSettings.Delay](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogAnimationSettings.html#Syncfusion_Blazor_Popups_DialogAnimationSettings_Delay), [DialogAnimationSettings.Duration](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogAnimationSettings.html#Syncfusion_Blazor_Popups_DialogAnimationSettings_Duration) and [DialogAnimationSettings.Effect](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogAnimationSettings.html#Syncfusion_Blazor_Popups_DialogAnimationSettings_Effect) by using the `DialogAnimationSettings` property.

In the following sample, `Zoom` effect is enabled. So, The Dialog will open with `ZoomIn` and close with `ZoomOut` effects.

{% tabs %}

{% highlight tabtitle="alert.razor" %}
{% include_relative code-snippet/alert-animation.razor %}
{% endhighlight %}

{% highlight tabtitle="confirm.razor" %}
{% include_relative code-snippet/confirm-animation.razor %}
{% endhighlight %}

{% highlight tabtitle="prompt.razor" %}
{% include_relative code-snippet/prompt-animation.razor %}
{% endhighlight %}

{% endtabs %}

## Position

You can customize the dialog position by using [Position](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.Position.html#fields) property. Use the following code to customize the dialog position.

{% tabs %}

{% highlight tabtitle="alert.razor" %}
{% include_relative code-snippet/alert-position.razor %}
{% endhighlight %}

{% highlight tabtitle="confirm.razor" %}
{% include_relative code-snippet/confirm-position.razor %}
{% endhighlight %}

{% highlight tabtitle="prompt.razor" %}
{% include_relative code-snippet/prompt-position.razor %}
{% endhighlight %}

{% endtabs %}

![Alert position Dialog](./images/blazor-alert-position.png)

![Confirm position Dialog](./images/blazor-confirm-position.png)

![Prompt position Dialog](./images/blazor-prompt-position.png)

## Dimension

You can customize the dialog dimensions using [DialogDimension.Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogDimension.html#Syncfusion_Blazor_Popups_DialogDimension_Height) and [DialogDimension.Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogDimension.html#Syncfusion_Blazor_Popups_DialogDimension_Width) properties. Use the following code to customize the dialog dimensions.

{% tabs %}

{% highlight tabtitle="alert.razor" %}
{% include_relative code-snippet/alert-dimension.razor %}
{% endhighlight %}

{% highlight tabtitle="confirm.razor" %}
{% include_relative code-snippet/confirm-dimension.razor %}
{% endhighlight %}

{% highlight tabtitle="prompt.razor" %}
{% include_relative code-snippet/prompt-dimension.razor %}
{% endhighlight %}

{% endtabs %}

![Alert dimension Dialog](./images/blazor-alert-dimension.png)

![confirm dimension Dialog](./images/blazor-confirm-dimension.png)

![prompt dimension Dialog](./images/blazor-prompt-dimension.png)

## Close Button Dialog

You can customize the close icon using [ShowCloseIcon](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfDialog.html#Syncfusion_Blazor_Popups_SfDialog_ShowCloseIcon) property. If the `ShowCloseIcon` property is set to `true` then the close icon will appear. Use the following code to enable the `ShowCloseIcon`.

{% tabs %}

{% highlight tabtitle="alert.razor" %}
{% include_relative code-snippet/alert-close-button.razor %}
{% endhighlight %}

{% highlight tabtitle="confirm.razor" %}
{% include_relative code-snippet/confirm-close-button.razor %}
{% endhighlight %}

{% highlight tabtitle="prompt.razor" %}
{% include_relative code-snippet/prompt-close-button.razor %}
{% endhighlight %}

{% endtabs %}

![Alert close icon Dialog](./images/blazor-alert-close-button.png)

![Confirm close icon Dialog](./images/blazor-confirm-close-button.png)

![Prompt close icon Dialog](./images/blazor-prompt-close-button.png)

## Customization of Action Buttons

You can customize the predefined dialog buttons by using [PrimaryButtonOptions](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogButton.html#Syncfusion_Blazor_Popups_DialogButton_IsPrimary) property. Use the following code to customize the predefined dialog buttons.

{% tabs %}

{% highlight tabtitle="alert.razor" %}
{% include_relative code-snippet/alert-action-button.razor %}
{% endhighlight %}

{% highlight tabtitle="confirm.razor" %}
{% include_relative code-snippet/confirm-action-button.razor %}
{% endhighlight %}

{% highlight tabtitle="prompt.razor" %}
{% include_relative code-snippet/prompt-action-button.razor %}
{% endhighlight %}

{% endtabs %}

![Alert action buttons Dialog](./images/blazor-alert-action-button.png)

![Confirm action buttons Dialog](./images/blazor-confirm-action-button.png)

![Prompt action buttons Dialog](./images/blazor-prompt-action-button.png)

## Customization of Dialog Content

You can customize the predefined dialogs using [DialogTemplates.childContent](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogTemplates.html#Syncfusion_Blazor_Popups_DialogTemplates_Content) property. Use the following code, to render the textbox component inside `Prompt` dialog.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/customize-dialog.razor %}

{% endhighlight %}
{% endtabs %}

![Customize Prompt Dialog](./images/blazor-customize-dialog.png)











