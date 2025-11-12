---
layout: post
title: Mail merge in Blazor RichTextEditor | Syncfusion
description: Checkout and learn here all about Mail merge in Syncfusion Blazor RichTextEditor control and much more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Mail merge in Blazor Rich Text Editor Control

The **Mail Merge** feature in Syncfusion Blazor Rich Text Editor enables you to create dynamic, personalized documents by inserting placeholders (merge fields) into the editor content. These placeholders are later replaced with actual data at runtime, making it ideal for generating letters, invoices, and bulk communication templates. Instead of manually editing each document, you can design a single template and populate it with user-specific data automatically.

To achieve this, the Rich Text Editor is customized with **custom toolbar items** and integrated with the **Mention control**. The toolbar provides two key options:
- **Insert Field**: A dropdown menu that allows users to insert predefined merge fields like `{{FirstName}}` or `{{Email}}` into the editor.
- **Merge Data**: A button that triggers the process of replacing all placeholders in the editor with actual values from a data source (e.g., a dictionary or database).

The Mention control enhances usability by enabling users to type a special character (like `{`) and select merge fields from a popup list. This combination of toolbar customization and mention functionality makes the editor highly interactive and suitable for mail merge scenarios.

## How Custom Toolbar Items Work

Custom toolbar items are added using the `RichTextEditorCustomToolbarItems` tag inside the editor. Each item is defined with a **Name** and a **Template**. The template can include any Blazor control, such as a button or dropdown. Event handlers like `OnClickHandler` and `OnItemSelect` are used to perform actions when these items are clicked or selected.

- **Merge Data Button**: Executes the `OnClickHandler` method, which retrieves the editor content and replaces placeholders using a regex-based function.
- **Insert Field Dropdown**: Displays a list of merge fields. When a field is selected, the `OnItemSelect` method inserts the corresponding placeholder into the editor at the current cursor position.

{% highlight cshtml %}

{% include_relative code-snippet/mail-merge.razor %}

{% endhighlight %}

![Blazor RichTextEditor Mail Merge](../images/blazor-richtexteditor-mail-merge.png)