---
layout: post
title: WebAssembly Performance in Blazor RichTextEditor Component | Syncfusion
description: This topic helps you to improve the performance of Web Assembly Application when using Syncfusion Blazor RichTextEditor components with some tips.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# WebAssembly Performance in Blazor RichTextEditor Component

This section provides performance guidelines for using Syncfusion RichTextEditor component efficiently in Blazor WebAssembly application. The best practice or guidelines for general framework Blazor WebAssembly performance can be found [here](https://docs.microsoft.com/en-us/aspnet/core/blazor/webassembly-performance-best-practices).

N> You can refer to our Getting Started with [Blazor Server-Side RichTextEditor](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio) and [Blazor WebAssembly RichTextEditor](./how-to/blazor-web-assembly) documentation pages for configuration specifications.

## Avoid unnecessary component renders

During Blazor Diffing Algorithm, every views of the RichTextEditor component and its child component will be checked for re-rendering. For instance, having **EventCallBack** on the application or RichTextEditor will check every child component, once event callback is completed.

You can have fine-grained control over RichTextEditor component rendering. **PreventRender** method helps to avoid unnecessary re-rendering of the RichTextEditor component. This method internally overrides the **ShouldRender** method of the RichTextEditor to prevent rendering.

In the following example:

* **PreventRender** method is called in the **IncrementCount** method which is a click callback.
* Now, RichTextEditor component will not be a part of the rendering which happens as result of the click event and **currentCount** alone will get updated.

```cshtml
@using Syncfusion.Blazor.RichTextEditor

<p>Current count: @currentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

<SfRichTextEditor @ref="rteObj"> 
    <RichTextEditorToolbarSettings Items="@Tools" Type="ToolbarType.Expand" />
    <p>The Rich Text Editor component is WYSIWYG ('what you see is what you get') editor that provides the best user experience to create and update the content. Users can format their content using standard toolbar commands.</p> 
</SfRichTextEditor> 
@code {
    SfRichTextEditor rteObj;
    private int currentCount = 0;
    private void IncrementCount()
    {
        rteObj.PreventRender();
        currentCount++;
    };
    private List<ToolbarItemModel> Tools = new List<ToolbarItemModel>() 
    { 
        new ToolbarItemModel() { Command = ToolbarCommand.Bold }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Italic }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Underline }, 
        new ToolbarItemModel() { Command = ToolbarCommand.StrikeThrough }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Separator }, 
        new ToolbarItemModel() { Command = ToolbarCommand.FontColor }, 
        new ToolbarItemModel() { Command = ToolbarCommand.BackgroundColor }, 
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
        new ToolbarItemModel() { Command = ToolbarCommand.Undo }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Redo } 
    };
}
```

N> * **PreventRender** method accepts boolean argument that accepts true or false to disable or enable rendering respectively.
<br/> * **PreventRender** method can be used only after RichTextEditor component completed initial rendering. Calling this method during initial rendering will not have any effect.

## Avoid unnecessary component renders after RichTextEditor events

When a callback method is assigned to the RichTextEditor events, then the **StateHasChanged** will be called in parent component of the RichTextEditor automatically once the event is completed.

You can prevent this re-rendering of the RichTextEditor component by calling the **PreventRender** method.

In the following example:

* **ValueChange** event is bound with a callback method, when the editor content gets changed on every time the event is completed the **StateHasChanged** will be invoked for the parent component.

```cshtml
@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor @ref="rteObj">
    <RichTextEditorToolbarSettings Items="@Tools" Type="ToolbarType.Expand" />
    <RichTextEditorEvents ValueChange="OnValueChange"/>
</SfRichTextEditor>

@code {
    SfRichTextEditor rteObj
    public void OnValueChange(Syncfusion.Blazor.RichTextEditor.ChangeEventArgs args) {
        rteObj.PreventRender();
    };
    private List<ToolbarItemModel> Tools = new List<ToolbarItemModel>() 
    { 
        new ToolbarItemModel() { Command = ToolbarCommand.Bold }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Italic }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Underline }, 
        new ToolbarItemModel() { Command = ToolbarCommand.StrikeThrough }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Separator }, 
        new ToolbarItemModel() { Command = ToolbarCommand.FontColor }, 
        new ToolbarItemModel() { Command = ToolbarCommand.BackgroundColor }, 
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
        new ToolbarItemModel() { Command = ToolbarCommand.Undo }, 
        new ToolbarItemModel() { Command = ToolbarCommand.Redo } 
    }; 
}
```

N> * **PreventRender** method internally overrides the **ShouldRender** method of the RichTextEditor to prevent rendering.
<br/> * It is recommended to use **PreventRender** method for user interactive events such as OnCellClick, OnEventClick etc. for better performance.
<br/> * For events without any argument such as **DataBound**, you can use **PreventRender** method of the RichTextEditor to disable rendering.