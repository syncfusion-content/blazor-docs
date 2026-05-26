---
layout: post
title: AssistViewSettings Properties in Syncfusion Smart Rich Text Editor
description: AssistViewSettings reference with concise definitions and examples for configuring AI commands, popup sizing, placeholders, prompts, toolbars and history.
platform: Blazor
control: Smart Rich Text Editor
documentation: ug
---

# AssistViewSettings Properties

## Commands
**Type:** `List<AICommands>`

Predefined AI actions displayed in the Smart Action dropdown.
Use the `Commands` property to configure each `AICommands` entry, including its display text, prompt template, and any nested options. By default, the AI Assistant prompt includes contextual information from the editor, such as the selected text or the entire document content.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.SmartRichTextEditor

<SfSmartRichTextEditor>
    <p>The <strong>AssistViewSettings</strong> properties in the Syncfusion Smart Rich Text Editor enable you to configure and customize the behavior and features of the AssistView. These settings allow you to control toolbar actions, manage user interactions, and tailor the overall assistance experience within the editor.</p>
    <AssistViewSettings Commands="@MyCommands" />
</SfSmartRichTextEditor>

@code {
    private List<AICommands> MyCommands = new()
    {
        new AICommands { Text = "Shorten", Prompt = "Make this shorter" },
        new AICommands { Text = "Expand", Prompt = "Add more details" },
        new AICommands
        {
            Text = "Translate",
            Prompt = "Translate the text",
            Items = new List<AICommands>
            {
                new AICommands { Text = "To French", Prompt = "Translate to French" },
                new AICommands { Text = "To Spanish", Prompt = "Translate to Spanish" }
            }
        }
    };
}

{% endhighlight %}
{% endtabs %}

![Blazor Smart Rich Text Editor AssistViewSettings Command Property](./images/smart-rich-text-editor-command-property.png)

---

## PopupMaxHeight
**Type:** `string` | **Default:** `"400"`

Sets the maximum height of the AI Assistant popup. Accepts CSS height values or numbers (treated as pixels).

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.SmartRichTextEditor

<SfSmartRichTextEditor>
    <p>Specifies the maximum height of the AssistView popup. This property helps control the vertical size of the popup to ensure optimal display and usability within the editor layout.</p>
    <AssistViewSettings PopupMaxHeight="80vh" />
</SfSmartRichTextEditor>

{% endhighlight %}
{% endtabs %}

![Blazor Smart Rich Text Editor AssistViewSettings PopupMaxHeight Property](./images/smart-rich-text-editor-popupmaxheight-property.png)

---

## PopupWidth
**Type:** `string` | **Default:** `"600"`

Sets the width of the AI Assistant popup. Accepts CSS width values or numbers (treated as pixels).

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.SmartRichTextEditor

<SfSmartRichTextEditor>
    <p>Specifies the width of the AssistView popup. This property allows you to control the horizontal size of the popup to ensure it fits well within the editor layout and provides an optimal user experience.</p>
    <AssistViewSettings PopupWidth="550px" />
</SfSmartRichTextEditor>

{% endhighlight %}
{% endtabs %}

![Blazor Smart Rich Text Editor AssistViewSettings PopupWidth Property](./images/smart-rich-text-editor-popupwidth-property.png)

---

## Placeholder
**Type:** `string` | **Default:** `"Ask AI to rewrite or generate content."`

Specifies the placeholder text shown in the AI Assistant prompt textarea.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.SmartRichTextEditor

<SfSmartRichTextEditor>
    <p>Specifies the placeholder text displayed in the AssistView input area when no content is entered.</p>
    <AssistViewSettings Placeholder="How can I improve this document?" />
</SfSmartRichTextEditor>

{% endhighlight %}
{% endtabs %}

![Blazor Smart Rich Text Editor AssistViewSettings Placeholder Property](./images/smart-rich-text-editor-placeholder-property.png)

---

## Prompts
**Type:** `List<AssistViewPrompt>`

Defines a collection of predefined prompts and their corresponding responses. These prompt/response templates can be loaded into the AI Assistant to provide starter prompts or predefined workflows.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.SmartRichTextEditor
@using Syncfusion.Blazor.InteractiveChat

<SfSmartRichTextEditor>
    <p>Specifies the collection of predefined prompts available in the AssistView. These prompts help guide users by providing ready-to-use suggestions, enabling quicker interactions and improving the overall assistance experience within the editor.</p>
    <AssistViewSettings Prompts="@TemplatePrompts" />
</SfSmartRichTextEditor>

@code {
    private const string ApiDocResponse = @"### GET /users
Retrieves a list of users.

**Request**: GET /api/users

**Response Example**:
``json
{
  ""users"": []
}
``";

    private List<AssistViewPrompt> TemplatePrompts = new()
    {
        new AssistViewPrompt
        {
            Prompt = "Draft a professional email",
            Response = @"Subject: Hello Team Dear Team, I hope this message finds you well. Best regards"
        },
        new AssistViewPrompt
        {
            Prompt = "Create API documentation",
            Response = ApiDocResponse
        }
    };
}

{% endhighlight %}
{% endtabs %}

![Blazor Smart Rich Text Editor AssistViewSettings Prompts Property](./images/smart-rich-text-editor-prompts-property.png)

---

## Suggestions
**Type:** `List<string>`

Defines suggestion prompts displayed in the AI Assistant popup.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.SmartRichTextEditor

<SfSmartRichTextEditor>
    <p>Specifies the list of suggested prompts displayed in the AssistView. These suggestions help users quickly choose common actions or queries, improving efficiency and guiding interactions within the editor.</p>
    <AssistViewSettings Suggestions="@QuickSuggestions" />
</SfSmartRichTextEditor>

@code {
    private List<string> QuickSuggestions = new()
    {
        "Make shorter",
        "Improve clarity",
        "Fix grammar",
        "Add examples",
        "More formal",
        "Simplify"
    };
}

{% endhighlight %}
{% endtabs %}

![Blazor Smart Rich Text Editor AssistViewSettings Suggestions Property](./images/smart-rich-text-editor-suggestions-property.png)

---

## MaxPromptHistory
**Type:** `int` | **Default:** `20`

Defines the maximum number of conversation entries retained in the editor's history. When this limit is exceeded, the oldest entries are automatically removed.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.SmartRichTextEditor

<SfSmartRichTextEditor>
    <!-- Store only 5 recent conversations -->
    <AssistViewSettings MaxPromptHistory="5" />
</SfSmartRichTextEditor>

{% endhighlight %}
{% endtabs %}

---

## BannerTemplate

Specifies the template for the banner in the AI Assistant popup, useful for branding, status, or short instructions.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.SmartRichTextEditor

<SfSmartRichTextEditor>
    <p>Specifies a custom template for the banner section in the AssistView. This property allows you to define personalized content or UI elements to be displayed, enhancing the visual appearance and user experience.</p>   
    <AssistViewSettings>
        <BannerTemplate>
            <div style="padding: 16px; background: linear-gradient(135deg, #667eea 0%, #764ba2 100%); color: white;">
                <h3 style="margin: 0;">Smart AI Assistant</h3>
                <span style="font-size: 12px;">Real-time AI assistance</span>
            </div>
        </BannerTemplate>
    </AssistViewSettings>
</SfSmartRichTextEditor>

{% endhighlight %}
{% endtabs %}

![Blazor Smart Rich Text Editor AssistViewSettings BannerTemplate Property](./images/smart-rich-text-editor-bannertemplate-property.png)

---

## HeaderToolbarSettings
**Type:** `RenderFragment?`

Configures the toolbar in the header section of the AI Assistant interface.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.SmartRichTextEditor
@using Syncfusion.Blazor.InteractiveChat
@using Syncfusion.Blazor.Navigations

<SfSmartRichTextEditor>
    <p>Specifies the toolbar settings for the header section of the AssistView. This property allows you to configure the available toolbar items and control their appearance and behavior, enabling customized interactions within the AssistView.</p>    
    <AssistViewSettings>
        <HeaderToolbarSettings>
            <AssistViewToolbarItem Type="ItemType.Spacer" />
            <AssistViewToolbarItem Text="Close" IconCss="e-icons e-close" />
            <AssistViewToolbarItem Text="AI Commands" />
        </HeaderToolbarSettings>
    </AssistViewSettings>
</SfSmartRichTextEditor>

{% endhighlight %}
{% endtabs %}

![Blazor Smart Rich Text Editor AssistViewSettings HeaderToolbarSettings Property](./images/smart-rich-text-editor-header-toolbasettings-property.png)

---

## PromptToolbarSettings
**Type:** `RenderFragment?`

Configures the toolbar below of the prompt input area section.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.SmartRichTextEditor
@using Syncfusion.Blazor.InteractiveChat
@using Syncfusion.Blazor.Navigations

<SfSmartRichTextEditor>
    <p>Specifies the toolbar settings for the prompt input area in the AssistView. This property allows you to customize the available toolbar actions and control how users interact with prompts, enhancing the overall assistance workflow.</p>
    <AssistViewSettings>
        <PromptToolbarSettings>
            <PromptToolbarItem Text="Edit" IconCss="e-icons e-assist-edit" Tooltip="Edit prompt" />
            <PromptToolbarItem Text="Copy" IconCss="e-icons e-assist-copy" Tooltip="Copy to clipboard" />
            <PromptToolbarItem Type="ItemType.Separator" />
            <PromptToolbarItem Text="Save" IconCss="e-icons e-save" />
        </PromptToolbarSettings>
    </AssistViewSettings>
</SfSmartRichTextEditor>

{% endhighlight %}
{% endtabs %}

![Blazor Smart Rich Text Editor AssistViewSettings PromptToolbarSettings Property](./images/smart-rich-text-editor-prompt-toolbasettings-property.png)

---

## ResponseToolbarSettings
**Type:** `RenderFragment?`

Configures the toolbar in the AI response viewer section.


{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.SmartRichTextEditor
@using Syncfusion.Blazor.InteractiveChat
@using Syncfusion.Blazor.Navigations

<SfSmartRichTextEditor>
    <p>Specifies the toolbar settings for the response section in the AssistView. This property allows you to configure the available actions and control how users interact with generated responses, enabling a more flexible and interactive experience.</p>
    <AssistViewSettings>
        <ResponseToolbarSettings>
            <ResponseToolbarItem Text="Regenerate" IconCss="e-icons e-refresh" />
            <ResponseToolbarItem Text="Copy" IconCss="e-icons e-copy" />
            <ResponseToolbarItem Type="ItemType.Separator" />
            <ResponseToolbarItem Text="Insert" IconCss="e-icons e-check" />
            <ResponseToolbarItem>
                <Template>
                    <button onclick="alert('Feedback saved')">👍 Helpful</button>
                </Template>
            </ResponseToolbarItem>
        </ResponseToolbarSettings>
    </AssistViewSettings>
</SfSmartRichTextEditor>

{% endhighlight %}
{% endtabs %}

![Blazor Smart Rich Text Editor AssistViewSettings ResponseToolbarSettings Property](./images/smart-rich-text-editor-response-toolbasettings-property.png)

---

## See also

* [Methods](https://blazor.syncfusion.com/documentation/smart-rich-text-editor/method)
* [Appearance](https://blazor.syncfusion.com/documentation/smart-rich-text-editor/appearance)
* [Events](https://blazor.syncfusion.com/documentation/smart-rich-text-editor/events)