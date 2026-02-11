---
layout: post
title: Tab component in Blazor RichTextEditor | Syncfusion
description: Learn about tab integration in the Syncfusion Blazor RichTextEditor component and much more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Integrate Tab component into the Blazor Rich Text Editor

Integrating the Syncfusion Tab component with the Rich Text Editor provides a powerful solution for advanced content management scenarios. Users can leverage this combination for multi-document editing where different tabs contain separate Rich Text Editor instances, allowing simultaneous work on multiple content pieces without context switching.

## Prerequisites

Before proceeding, complete the base Rich Text Editor setup described in the Getting Started guide. The guide covers Blazor project configuration, package installation, CSS imports, module registration, and basic editor markup: [Getting Started with Blazor Rich Text Editor](https://blazor.syncfusion.com/documentation/rich-text-editor/getting-started-with-server-app).

## Key features

- **Organized content display:** Tabs group different editor sections (e.g., formatting tools, media insertion, code view), reducing UI clutter.
- **Scalability:** Easily add new features or plugins as separate tabs without changing the existing layout.
- **Consistent UI:** Tabs provide a familiar navigation experience aligned with modern UI/UX practices.

## Set up the Tab component

The Tab package is included with the Syncfusion Blazor installation. If not already installed, add the required package:

```bash
dotnet add package Syncfusion.Blazor.Navigations
```
## Configure Tab component for the Rich Text Editor

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/tab-intergration.razor %}

{% endhighlight %}
{% endtabs %}

## See also

* [Rich Text Editor documentation](https://blazor.syncfusion.com/documentation/rich-text-editor/getting-started)
* [Rich Text Editor events](https://blazor.syncfusion.com/documentation/rich-text-editor/events)
* [Tab Documentation](https://blazor.syncfusion.com/documentation/tabs/getting-started-webapp)