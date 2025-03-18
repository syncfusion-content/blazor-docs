---
layout: post
title: Accessibility in Blazor Markdown Editor Component | Syncfusion
description: Checkout and learn here all about accessibility in Syncfusion Blazor Markdown Editor component and more.
platform: Blazor
control: MarkdownEditor
documentation: ug
---

# Accessibility in Blazor Markdown Editor Component

The [Blazor Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-wysiwyg-rich-text-editor) component has been designed, keeping in mind the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/) specifications, and applies the WAI-ARIA roles, states, and properties. This component is characterized by complete ARIA accessibility support that makes it easy for people who use assistive technologies (AT) or those who completely rely on keyboard navigation.

The Blazor Markdown Editor component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor Markdown Editor component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2](https://www.w3.org/TR/WCAG22/) Support | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Section 508 Support](../common/accessibility#section-508) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| Screen Reader Support | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| Right-To-Left Support | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| Color Contrast | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> |
| Mobile Device Support | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Keyboard Navigation](../common/accessibility#keyboard-navigation) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) Accessibility Validation | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> - All features of the component meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> - Some features of the component do not meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/not-supported.png" alt="No"> - The component does not meet the requirement.</div>

## WAI-ARIA attributes

* The toolbar of Blazor Markdown Editor, assigned the role of `Toolbar` and has the following list of [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/) attribute.

| **Property** | **Functionalities** |
| --- | --- |
| role="toolbar" | This attribute added to the ToolBar element describes the actual role of the element. |
| aria-orientation     | Indicates the ToolBar orientation. Default value is `horizontal`. |
| aria-haspopup       | Indicates the popup mode of the Toolbar. Default value is false. When popup mode is enabled,  attribute value has to be changed to `true`. | |
| aria-disabled       | Indicates the disabled state of the ToolBar. |
| aria-owns | Identifies an element to define a visual, functional, or contextual parent/child relationship between DOM elements when the DOM hierarchy cannot represent the relationship. In the Markdown Editor, the attribute contains the ID of the Markdown Editor to indicate the popup as a child element. |

For further details of Toolbar ARIA attributes, refer the  [`accessibility of Toolbar`](../../toolbar/accessibility) documentation.

The Blazor Markdown Editor element is assigned the role of `application`.

| **Property** | **Functionalities** |
| --- | --- |
| role="application" | This attribute added to the Markdown Editor element describes the actual role of the element. |
| aria-disabled       | Indicates the disabled state of the ToolBar. |

{% tabs %}
{% highlight cshtml %}

{% include_relative code-snippet/markdown-aria-attribute.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor Markdown Editor with accessibility](./images/blazor-markdowneditor-accessibility.png)

## Keyboard interaction

The Blazor Markdown Editor component followed the [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/alert/#keyboardinteraction) guideline, making it easy for people who use assistive technologies (AT) and those who completely rely on keyboard navigation. The following keyboard shortcuts are supported by the Markdown Editor component. 

For more details on keyboard navigation, refer to the [Keyboard support](https://blazor.syncfusion.com/documentation/markdown-editor/keyboard-support) documentation.

## Ensuring accessibility

The Blazor Markdown Editor component's accessibility levels are ensured through an [axe-core](https://www.npmjs.com/package/axe-core) software tool during automated testing.

The accessibility compliance of the Markdown Editor component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/rich-text-editor) in a new window to evaluate the accessibility of the Markdown Editor component with accessibility tools.

### Custom key configuration

Customize the key configuration for the keyboard interaction of the Markdown Editor using the [KeyConfigure](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_KeyConfigure) property.

In the following code block, customize the bold and italic, toolbar actions with **ctrl+1**, **ctrl+2** respectively.

{% tabs %}
{% highlight cshtml %}

{% include_relative code-snippet/markdown-custom-key-config.razor%}

{% endhighlight %}
{% endtabs %}


N> You can refer to our [Blazor Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-wysiwyg-rich-text-editor) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Markdown Editor](https://blazor.syncfusion.com/demos/rich-text-editor/overview?theme=bootstrap5) example to knows how to render and configure the Markdown Editor tools.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](../common/accessibility)