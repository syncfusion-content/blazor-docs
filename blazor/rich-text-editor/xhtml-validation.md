---
layout: post
title: Xhtml validation in Blazor Rich Text Editor Component | Syncfusion
description: Checkout and learn here all about Xhtml validation in Syncfusion Blazor Rich Text Editor component and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Xhtml Validation

The Rich Text Editor includes an `EnableXhtml` property that allows for continuous validation of the Rich Text Editor’s source content against the XHTML standard. When content is entered or modified in the editor, this feature ensures ongoing compliance by automatically removing invalid elements and attributes.

The Rich Text Editor checks the following settings on validation:

## Validating attributes

* Case Sensitivity: All attributes must be in lowercase.
* Quotation Marks: Proper use of quotation marks around attribute values is enforced.
* Validity: Only valid attributes for corresponding HTML elements are allowed.
* Required Attributes: All required attributes for HTML elements must be included.

## Validating html elements

* Case Sensitivity: All HTML tags must be in lowercase.
* Proper Closing: All opening tags must have corresponding closing tags.
* Element Validity: Only valid HTML elements are permitted.
* Nesting: Elements must be properly nested to maintain structure.
* Root Element: The content must have a single root element.
* Element Hierarchy: Inline elements cannot contain block elements.

{% tabs %}
{% highlight cshtml %}

{% include_relative code-snippet/xhtml-validation.razor %}

{% endhighlight %}
{% endtabs %}

N> You can refer to our [Blazor Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-wysiwyg-rich-text-editor) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Rich Text Editor](https://blazor.syncfusion.com/demos/rich-text-editor/overview?theme=bootstrap5) example to know how to render and configure the rich text editor tools.