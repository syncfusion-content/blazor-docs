---
layout: post
title: Templates in Blazor Inline AI Assist | Syncfusion®
description: Customize Blazor Inline AI Assist appearance using EditorTemplate and ResponseTemplate to design custom footer and response layouts.
platform: Blazor
control: Inline AI Assist
documentation: ug
---

# Templates in Blazor Inline AI Assist

The Inline AI Assist provides several template options to customize the response and footer items.

## Editor template

You can use the `EditorTemplate` tag to customize the default footer area and manage prompt request actions in the Inline AI Assist. This allows users to create unique footers that meet their specific needs.

{% tabs %}
{% highlight razor tabtitle=".razor" %}

{% include_relative code-snippet/templates/editor-template.razor %}

{% endhighlight %}
{% endtabs %}

![EditorTemplate](images/editor-template.webp)

## Response template

You can use the `<Responsetemplate></ResponseTemplate>` tag to customize response items within the Inline AI Assist. The template context includes the `Response` and `ToolbarItems` values.

{% tabs %}
{% highlight razor tabtitle=".razor" %}

{% include_relative code-snippet/templates/response-template.razor %}

{% endhighlight %}
{% endtabs %}

![ResponeTemplate](images/response-template.webp)