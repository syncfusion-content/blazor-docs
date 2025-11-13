---
layout: post
title: Mail merge in Blazor RichTextEditor | Syncfusion
description: Checkout and learn here all about Mail merge in Syncfusion Blazor RichTextEditor control and much more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Mail Merge in Syncfusion Blazor RichTextEditor

The Mail Merge feature in Syncfusion Blazor RichTextEditor enables developers to create dynamic, personalized documents by inserting placeholders (merge fields) into the editor content. These placeholders are later replaced with actual data at runtime, making it ideal for generating letters, invoices, and bulk communication templates.

## Key Outcomes:

- Render custom toolbar items for mail merge actions.
- Insert merge fields dynamically using dropdown or Mention control.
- Replace placeholders with real data using a single click.

## Rendering Custom Toolbar Items

Custom toolbar items are added using the [RichTextEditorCustomToolbarItems](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorCustomToolbarItems.html) tag. Each item is defined with:

- **Name**: Identifier for the toolbar item.
- **Template**: Razor markup for rendering UI elements such as buttons or dropdowns.

{% tabs %}
{% highlight razor %}

<RichTextEditorCustomToolbarItems>
    <RichTextEditorCustomToolbarItem Name="MergeData">
        <Template>
            <SfButton OnClick="MergeData">Merge Data</SfButton>
        </Template>
    </RichTextEditorCustomToolbarItem>
    <RichTextEditorCustomToolbarItem Name="InsertField">
        <Template>
            <SfDropDownButton Items="@items">
                <ChildContent>Insert Field</ChildContent>
                <DropDownButtonEvents ItemSelected="InsertField" />
            </SfDropDownButton>
        </Template>
    </RichTextEditorCustomToolbarItem>
</RichTextEditorCustomToolbarItems>

{% endhighlight %}
{% endtabs %}

## Executing Merge Data Action

When the `Merge Data` button is clicked:

1. The editor’s current content (rte.Value) is retrieved.
2. A regex-based function scans for placeholders in the format {{FieldName}}.
3. Each placeholder is replaced with its corresponding value from a dictionary.

```csharp

    public void OnClickHandler()
    {
        if (this._mailMergeEditor != null)
        {
            var editorContent = this._mailMergeEditor.Value;
            var mergedContent = ReplacePlaceholders(editorContent, this._placeholderData);
            _rteValue = mergedContent;
        }
    }
     public static string ReplacePlaceholders(string template, Dictionary<string, string> data)
    {
        return Regex.Replace(template, @"{{\s*(\w+)\s*}}", match =>
        {
            string key = match.Groups[1].Value.Trim();
            return data.TryGetValue(key, out var value) ? value : match.Value;
        });
    }

```
This ensures all placeholders are dynamically replaced without manual editing.

## Populating and Using Insert Field Dropdown

The `Insert Field` dropdown is populated from a predefined list of merge fields (items). When a user selects an item:

- The `InsertField()` method retrieves the corresponding field value.
- It constructs an HTML snippet with a non-editable span containing the placeholder.
- The snippet is inserted at the current cursor position using [ExecuteCommandAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_ExecuteCommandAsync_Syncfusion_Blazor_RichTextEditor_CommandName_System_String_Syncfusion_Blazor_RichTextEditor_ExecuteCommandOption_).

```csharp
    public async Task OnItemSelect(MenuEventArgs args)
    {
        if (args.Item.Text != null)
        {
            var value = _mergeData.FirstOrDefault(md => md.Text == args.Item.Text)?.Value;
            string htmlContent = $"<span contenteditable=\"false\" class=\"e-mention-chip\"><span>{{{{{value}}}}}</span></span> ";
            var undoOption = new ExecuteCommandOption { Undo = true };
            this._mailMergeEditor.ExecuteCommandAsync(CommandName.InsertHTML, htmlContent, undoOption);
            await this._mailMergeEditor.SaveSelectionAsync();
        }
    }
```
## Role of Mention Control in Mail Merge

Mention control enhances usability by enabling inline field suggestions:

- Activated when the user types `{` inside the editor.
- Displays a popup list of available merge fields from DataSource.
- On selection, inserts the placeholder using the same logic as the dropdown.

{% tabs %}
{% highlight razor %}

<SfMention DataSource="_mergeData" TItem="MergeData" Target="#_mailMergeEditor" MentionChar="_mentionChar" AllowSpaces="true" PopupWidth='250px' PopupHeight='200px' @ref="mentionObj">
    <DisplayTemplate>
        <span>{{@((context as MergeData).Value)}}</span>
    </DisplayTemplate>
    <ChildContent>
        <MentionFieldSettings Text="Text"></MentionFieldSettings>
    </ChildContent>
</SfMention>

{% endhighlight %}
{% endtabs %}

This feature is ideal for users who prefer keyboard-driven workflows.

## Maintaining Cursor Position During Dropdown Operations

When the `Insert Field` dropdown opens, the editor loses its current selection because focus shifts to the popup. To ensure the placeholder is inserted at the correct position:

- **SaveSelectionAsync()** is called when the dropdown opens. This stores the current cursor position in the editor before focus changes.
- **RestoreSelectionAsync()** is called when the dropdown closes. This restores the saved cursor position so that the next insertion happens exactly where the user intended.

**Why is this important?** Without saving and restoring the selection, placeholders might be inserted at the wrong location (e.g., at the end of the content), breaking the user experience.

```csharp
    public async Task OnDropDownOpen()
    {
        if (this._mailMergeEditor != null)
        {
            await this._mailMergeEditor.SaveSelectionAsync();
        }
    }
    public async Task OnDropDownClose()
    {
        if (this._mailMergeEditor != null)
        {
            await this._mailMergeEditor.RestoreSelectionAsync();
        }
    }
```


## Handling Editor Mode Changes with OnActionComplete

The [OnActionComplete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorEvents.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorEvents_OnActionComplete) event fires after specific actions in the RichTextEditor, such as switching between Source Code and Preview modes.

- When entering **Source Code mode**, custom toolbar buttons (Merge Data, Insert Field) should be disabled because HTML editing is manual in this mode.
- When returning to **Preview mode**, these buttons are re-enabled for normal usage.

```csharp
 private void OnActionCompleteHandler(Syncfusion.Blazor.RichTextEditor.ActionCompleteEventArgs args)
    {
        if (args.RequestType == "SourceCode")
        {
            this._buttonClass = "e-tbar-btn e-tbar-btn-text e-overlay";
            this._dropDownButtonClass = "e-rte-elements e-rte-dropdown-menu e-overlay";
            this._sourceCodeEnabled = true;
        }
        if (args.RequestType == "Preview")
        {
            this._buttonClass = "e-tbar-btn e-tbar-btn-text";
            this._dropDownButtonClass = "e-rte-elements e-rte-dropdown-menu";
            this._sourceCodeEnabled = false;
        }
    }
```

**Why is this important?** This prevents users from triggering merge operations or inserting fields while editing raw HTML, which could cause unexpected behavior.

{% highlight cshtml %}

{% include_relative code-snippet/mail-merge.razor %}

{% endhighlight %}

![Blazor RichTextEditor Mail Merge](./images/blazor-richtexteditor-mail-merge.png)

## Related Resources

[Mention Control Guide](https://blazor.syncfusion.com/documentation/mention/getting-started-webapp)