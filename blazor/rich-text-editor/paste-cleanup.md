---
layout: post
title: Paste Clean-up in Blazor RichTextEditor | Syncfusion
description: Checkout and learn here all about Paste from MS Word in Syncfusion Blazor RichTextEditor component and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Paste Clean-up in Blazor RichTextEditor

The Blazor Rich Text Editor offers a built-in option to paste content from Microsoft Word, Microsoft Outlook, Microsoft Excel, and other websites by filtering out tags, attributes, and styles. Copy content from Microsoft Office or other websites and paste it into the editor, where it is cleaned up and pasted based on the settings in the [PasteCleanupSettings]((https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorPasteCleanupSettings.html))property values. 

## Paste settings

You can control the formatting and styles on pasting the content to the editor using the [pasteCleanup settings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorPasteCleanupSettings.html) property. The following settings are available to clean up the content:

| API | Description | Default Value | Type |
|:----------------:|:---------:|:-----------------------------:|:---------:|
| [Prompt](#prompt-dialog) | To invoke prompt dialog with paste options on pasting the content in editor. | false | boolean |
| [PlainText](#paste-as-plain-text) | To paste the content as plain text. | false | boolean |
| [KeepFormat](#keep-format) | To keep the same format with copied content. | true | boolean |
| [DeniedTags](#denied-tags) | To ignore the tags when pasting HTML content. | null | string[] |
| [DeniedAttributes](#denied-attributes) | To paste the content by filtering out these attributes from the content. | null | string[] |
| [AllowedStyleProperties](#allowed-style-properties) | To paste the content by accepting these style attributes and removing other style attributes. | [background, background-color, border, border-bottom, border-left, border-radius, border-right, border-style, border-top, border-width, clear, color, cursor, direction, display, float, font, font-family, font-size, font-weight, font-style, height, left, line-height, margin, margin-top, margin-left, margin-right, margin-bottom, max-height, max-width, min-height, min-width, overflow, overflow-x, overflow-y, padding, padding-bottom, padding-left, padding-right, padding-top, position, right, table-layout, text-align, text-decoration, text-indent, top, vertical-align, visibility, white-space, width] | string[] |

## Paste options in prompt dialog

When [Prompt](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorPasteCleanupSettings.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorPasteCleanupSettings_Prompt) is set to true, pasting the content in the editor will open a dialog box that contains three options keep, clean, and plain text as radio buttons:
1. **Keep**: Radio button to keep the same format with copied content.
2. **Clean**: Radio button to clear all the style formats with copied content.
3. **Plain Text**: Radio button to paste the copied content as plain text without any formatting or style (including the removal of all tags).

> When `Prompt` value is set true, the API properties [PlainText](#paste-as-plain-text) and [KeepFormat](#keep-format) will not be considered for processing when pasting the content.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/prompt-paste-cleanup.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor RichTextEditor with Prompt Paste CleanUp](./images/blazor-richtexteditor-paste-prompt.gif)

## Paste as plain text

When [PlainText](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorPasteCleanupSettings.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorPasteCleanupSettings_PlainText) is set to true, the copied content will be converted as plain text by removing all the HTML tags and styles applied to it and only the plain text is pasted in the editor.

> When `PlainText` value is set true, the API property [Prompt](#prompt-dialog) should be set to false, and [KeepFormat](#keep-format) will not be considered for processing when pasting the content.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/plain-text-paste-cleanup.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor RichTextEditor with Plain text Paste CleanUp](./images/blazor-richtexteditor-paste-plain-text.gif)

## Keep format

When [KeepFormat](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorPasteCleanupSettings.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorPasteCleanupSettings_KeepFormat) is set to true, the copied content will maintain all the style formatting allowed in the [AllowedStyleProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorPasteCleanupSettings.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorPasteCleanupSettings_AllowedStyleProperties) on pasting the content in the editor.

When `KeepFormat` is set to false, the style in the copied content will be removed without considering the allowed styles in the `AllowedStyleProperties` when pasting the content in the editor.

> When `KeepFormat` value is set true, the API property [Prompt](#prompt-dialog) and [PlainText](#paste-as-plain-text) should be set to false.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/keep-format-paste-cleanup.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor RichTextEditor with Keep Format Paste CleanUp](./images/blazor-richtexteditor-paste-keep-format.gif)

## Denied tags

The [DeniedTags](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorPasteCleanupSettings.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorPasteCleanupSettings_DeniedTags) property tags value are removed with their content when pasting the content into the Rich Text Editor. For Example, 

1. **a**: Paste the content by filtering out anchor tags.
2. **a[!href]**: Paste the content by filtering out anchor tags that do not have the ‘href’ attribute.
3. **a[href, target]**: Paste the content by filtering out anchor tags that have the ‘href’ and ‘target’ attributes.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/denied-tag-paste-cleanup.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor RichTextEditor with Denied Tag Paste CleanUp](./images/blazor-richtexteditor-paste-denied-tag.gif)

## Denied attributes

The [DeniedAttributes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorPasteCleanupSettings.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorPasteCleanupSettings_DeniedAttributes) property attributes are removed with their content when pasting the content into the Rich Text Editor. For Example, 

'id', 'title' attributes will remove from all paste content. 

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/denied-attribute-paste-cleanup.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor RichTextEditor with Denied Attribute Paste CleanUp](./images/blazor-richtexteditor-paste-denied-attribute.png)

## Allowed style properties

By default, the following basic styles are allowed on pasting the content to the editor.

[background, background-color, border, border-bottom, border-left, border-radius, border-right, border-style, border-top, border-width, clear, color, cursor, direction, display, float, font, font-family, font-size, font-weight, font-style, height, left, line-height, margin, margin-top, margin-left, margin-right, margin-bottom, max-height, max-width, min-height, min-width, overflow, overflow-x, overflow-y, padding, padding-bottom, padding-left, padding-right, padding-top, position, right, table-layout, text-align, text-decoration, text-indent, top, vertical-align, visibility, white-space, width]

When you configure `AllowedStyleProperties`, the styles which matches the 'allowed style properties' list are allowed, all other style properties will be removed on pasting the content in the editor.

For Example, **public string[] AllowedStyles = new string[] { "color", "margin" };** This will allow only the style properties 'color' and 'margin' in each pasted element.

In the following example, the paste cleanup related settings are explained with configuration.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/allowed-style-paste-cleanup.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor RichTextEditor with Allowed Styles Paste CleanUp](./images/blazor-richtexteditor-paste-allowed-style.png)


## Pasting large text content

When pasting a large text into the editor it displays "Attempting to reconnect" and then the text gets inserted. To archieve this, you can increase the SignalR size in application level by adding the ‘signalR’ method with larger buffer size(’1024000000’).

### Blazor Server App

* For **.NET 6** app, open the **~/Program.cs** file and register the Syncfusion Blazor Service.

* For **.NET 5 and .NET 3.X** app, open the **~/Startup.cs** file and register the Syncfusion Blazor Service.

{% tabs %}
{% highlight c# tabtitle=".NET 6 (~/Program.cs)" hl_lines="11" %}

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor();
services.AddSignalR(e => { e.MaximumReceiveMessageSize = 1024000000; });

var app = builder.Build();
....

{% endhighlight %}

{% highlight c# tabtitle=".NET 5 and .NET 3.X (~/Startup.cs)" hl_lines="13" %}

using Syncfusion.Blazor;

namespace BlazorApplication
{
    public class Startup
    {
        ...
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSyncfusionBlazor();
            services.AddSignalR(e => { e.MaximumReceiveMessageSize = 1024000000; });
        }
        ...
    }
}

{% endhighlight %}
{% endtabs %}

### Blazor WebAssembly App

Open **~/Program.cs** file and register the Syncfusion Blazor Service in the client web app.

{% tabs %}
{% highlight C# tabtitle=".NET 6 (~/Program.cs)" hl_lines="13" %}

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; });
builder.Services.AddSignalR(e => { e.MaximumReceiveMessageSize = 1024000000; });
await builder.Build().RunAsync();
....

{% endhighlight %}

{% highlight c# tabtitle=".NET 5 and .NET 3.X (~/Program.cs)" hl_lines="11" %}

using Syncfusion.Blazor;

namespace WebApplication1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            ....
            builder.Services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; });
            builder.Services.AddSignalR(e => { e.MaximumReceiveMessageSize = 1024000000; });
            await builder.Build().RunAsync();
        }
    }
}

{% endhighlight %}
{% endtabs %}

## Get pasted content

You can get the pasted Text as a HTML text using the [AfterPasteCleanup](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorEvents.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorEvents_AfterPasteCleanup) event argument value.

{% tabs %}
{% highlight razor %}

<SfRichTextEditor @ref="RteObj" @bind-Value="htmlText" EditorMode="EditorMode.HTML">
    <RichTextEditorEvents AfterPasteCleanup="@AfterPasteCleanupHandler" />
</SfRichTextEditor>

@code {
    public void AfterPasteCleanupHandler(PasteCleanupArgs args)
    {
        // Here you can get the pasted Html string using args.Value
    }
}

{% endhighlight %}
{% endtabs %}


> You can refer to our [Blazor Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-wysiwyg-rich-text-editor) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Rich Text Editor](https://blazor.syncfusion.com/demos/rich-text-editor/overview?theme=bootstrap4) example to know how to render and configure the rich text editor tools.