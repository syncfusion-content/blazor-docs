---
layout: post
title: Integration in Blazor RichTextEditor | Syncfusion
description: Learn how to integrate and customize the Mention in the Syncfusion Blazor Rich Text Editor component and use inline suggestions to tag users and objects.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Integrate Mention component into the Blazor Rich Text Editor

The Mention component enables tagging within the Rich Text Editor by linking its suggestion list to the editor's editable area. It leverages the Syncfusion Mention component to offer inline suggestions and insert the chosen tags.

## Prerequisites

Before proceeding, complete the base Rich Text Editor setup described in the Getting Started guide. The guide covers Blazor project configuration, package installation, CSS imports, module registration, and basic editor markup: [Getting Started with Blazor Rich Text Editor](https://blazor.syncfusion.com/documentation/rich-text-editor/getting-started-with-server-app).

## Key features

- Inline mention suggestions bound to the editor editable container
- Support for local and remote data sources
- Custom item and display templates
- Configurable `MinLength`, `SuggestionCount`, and `AllowSpaces`

## Set up the Mention component

The Mention package is included with the Syncfusion Blazor installation. If not already installed, add the required package:

```bash
dotnet add package Syncfusion.Blazor.Dropdowns
```

## Using mentions

Typing the `@` symbol followed by a character displays a list of suggestions for selection. Users can select an item by clicking or typing its name.

## Customizing the suggestion list

### Set minimum input length for Mention suggestions

You can control when the suggestion list appears by setting the [MinLength](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMention-1.html#Syncfusion_Blazor_DropDowns_SfMention_1_MinLength) property in the Mention control. This property defines the minimum number of characters a user must type after the mention character (@) to trigger the search action. This is especially useful when working with large datasets, as it helps reduce unnecessary queries and improves performance.

By default, `MinLength` is set to 0, which means the suggestion list appears immediately after the mention character is entered. However, you can increase this value to delay the search until the user has typed a specific number of characters.

In the following example, the `MinLength` is set to 3, so the suggestion list appears only once the user types three or more characters after the @ symbol.

{% highlight cshtml %}

{% include_relative code-snippet/mention-min-length.razor %}

{% endhighlight %}

![Blazor RichTextEditor mention minimum length](./images/blazor-richtexteditor-mention-min-length.png)

### Customizing suggestion list count

You can control the number of items displayed in the Mention suggestion list using the [SuggestionCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMention-1.html#Syncfusion_Blazor_DropDowns_SfMention_1_SuggestionCount) property. This is particularly useful when working with large datasets, allowing you to limit the number of suggestions shown to the user.

By default, the suggestion list displays 25 items. You can customize this value to show fewer or more items based on your application's needs.

In the example below, the `SuggestionCount` is set to 5, so only 5 items display in the suggestion list when the user types the mention character (@).

{% highlight cshtml %}

{% include_relative code-snippet/mention-suggestion-count.razor %}

{% endhighlight %}

![Blazor RichTextEditor mention minimum length](./images/blazor-richtexteditor-mention-suggestion-count.png)

### Customizing suggestion list using templates

#### Item template

You can customize how each item appears in the suggestion list using the [ItemTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_ItemTemplate) property. This allows you to display additional details such as email, role, or profile image alongside the mention name.

#### Display template

Use the [DisplayTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMention-1.html#Syncfusion_Blazor_DropDowns_SfMention_1_DisplayTemplate) property to define how the selected mention appears in the editor content.

For example, by default, the mention chip renders as:

```html
<span contenteditable="false" class="e-mention-chip">@Selma Rose</span>
```

Using the `DisplayTemplate` property, you can customize it to render as a clickable link:

```html
<a href="mailto:selma@gmail.com" title="selma@gmail.com">@Selma Rose</a>
```

This allows you to create more interactive and informative mentions within the editor.

In the following sample, we configured the following properties:

* [ItemTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_ItemTemplate) - Displays customized appearance in the suggestion list
* [DisplayTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMention-1.html#Syncfusion_Blazor_DropDowns_SfMention_1_DisplayTemplate) - Customizes how the selected mention appears in the editor content
* [AllowSpaces](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMention-1.html#Syncfusion_Blazor_DropDowns_SfMention_1_AllowSpaces) - Allows search to continue if the user enters a space after the mention character
* [SuggestionCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMention-1.html#Syncfusion_Blazor_DropDowns_SfMention_1_SuggestionCount) - Sets the maximum number of items displayed in the suggestion list

{% highlight cshtml %}

{% include_relative code-snippet/mention-integration.razor %}

{% endhighlight %}

![Blazor RichTextEditor mention integration](./images/blazor-richtexteditor-mention-integration.png)

## Using Remote Data with Mention in the Rich Text Editor

The Mention component supports loading data from remote services using the [DataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html) along with an appropriate adaptor such as WebApiAdaptor. The DataManager enables you to retrieve data from a remote endpoint and bind it directly to the Mention component inside the Rich Text Editor.

### Example: Integrating Remote Data with Syncfusion Rich Text Editor

{% highlight cshtml %}

{% include_relative code-snippet/mention-integration-remotedata.razor %}

{% endhighlight %}

N> **Note:** Ensure that Syncfusion.Blazor.Data is imported in your component or page to enable remote data binding with DataManager.

> [View Sample](https://blazor.syncfusion.com/demos/rich-text-editor/mention-integration?theme=bootstrap5)

## See also

* [Mention](https://blazor.syncfusion.com/documentation/mention/getting-started)