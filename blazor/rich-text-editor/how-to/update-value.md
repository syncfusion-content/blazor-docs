---
layout: post
title: How to Update Value in Blazor RichTextEditor Component | Syncfusion
description: Checkout and learn about how to update value in Blazor RichTextEditor component of Syncfusion, and more details.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Capture ctrl+s to update the value

To achieve this, the `keydown` event has to be bound to the Rich Text Editor content and the `ctrl + s` key press is captured using its `keyCode`. In the `keydown` event handler, the `updateValue` method is called to update the `value` property and then the content is saved in the required database using the same.

```cshtml

@using Syncfusion.Blazor.RichTextEditor
@inject IJSRuntime JSRuntime


<div class="control-section"> 
    <SfRichTextEditor ID="richTextEditor" ref="editor" onkeydown="@onKeydown" @bind-Value="@RteValue">
        <RichTextEditorToolbarSettings Items="@Tools"></RichTextEditorToolbarSettings>
    </SfRichTextEditor>
</div>
<script>
    window.preventSaveAction = function (elementId) {
        var contentEditableElement = document.getElementById(elementId);
        if (contentEditableElement) {
            contentEditableElement.addEventListener("keydown", function (e) {
                if (e.ctrlKey && e.key === 's') {
                    e.preventDefault();  // Prevent default Ctrl+S save behavior
                }
            });
        } 
    };
</script>

@code {
    SfRichTextEditor editor;
    private string contentEditableId = "richTextEditor_rte-editable";

    public String RteValue { get; set; } = "<p>The Rich Text Editor component is WYSIWYG ('what you see is what you get') editor that provides the best user experience to create and update the content. Users can format their content using standard toolbar commands.</p><p><b>Key features:</b></p><ul><li><p>Provides <b>IFRAME</b> and <b>DIV</b> modes</p></li><li><p>Capable of handling markdown editing.</p></li><li><p>Contains a modular library to load the necessary functionality on demand.</p></li><li><p>Provides a fully customizable toolbar.</p></li><li><p>Provides HTML view to edit the source directly for developers.</p></li><li><p>Supports third-party library integration.</p></li><li><p>Allows preview of modified content before saving it.</p></li></ul>";

    private List<ToolbarItemModel> Tools = new List<ToolbarItemModel>()
    {
        new ToolbarItemModel() { Command = ToolbarCommand.Undo },
        new ToolbarItemModel() { Command = ToolbarCommand.Redo },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.Bold },
        new ToolbarItemModel() { Command = ToolbarCommand.Italic },
        new ToolbarItemModel() { Command = ToolbarCommand.Underline },
        new ToolbarItemModel() { Command = ToolbarCommand.StrikeThrough },
        new ToolbarItemModel() { Command = ToolbarCommand.SuperScript },
        new ToolbarItemModel() { Command = ToolbarCommand.SubScript },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.FontName },
        new ToolbarItemModel() { Command = ToolbarCommand.FontSize },
        new ToolbarItemModel() { Command = ToolbarCommand.FontColor },
        new ToolbarItemModel() { Command = ToolbarCommand.BackgroundColor },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.LowerCase },
        new ToolbarItemModel() { Command = ToolbarCommand.UpperCase },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.Formats },
        new ToolbarItemModel() { Command = ToolbarCommand.Alignments },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.OrderedList },
        new ToolbarItemModel() { Command = ToolbarCommand.UnorderedList },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.Outdent },
        new ToolbarItemModel() { Command = ToolbarCommand.Indent },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.CreateLink },
        new ToolbarItemModel() { Command = ToolbarCommand.Image },
        new ToolbarItemModel() { Command = ToolbarCommand.CreateTable },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.ClearFormat },
        new ToolbarItemModel() { Command = ToolbarCommand.Print },
        new ToolbarItemModel() { Command = ToolbarCommand.SourceCode },
        new ToolbarItemModel() { Command = ToolbarCommand.FullScreen },
    };
    public void onKeydown(KeyboardEventArgs arg)
    {
        if (arg.Key == "s" && arg.CtrlKey == true)
        {
            this.RteValue = this.editor.Value;
        }
    }
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await JSRuntime.InvokeVoidAsync("preventSaveAction", contentEditableId);
        }
    }
}

```