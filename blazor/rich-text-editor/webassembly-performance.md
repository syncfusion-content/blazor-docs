---
layout: post
title: WebAssembly Performance in Blazor Rich Text Editor | Syncfusion
description: This topic helps improve performance of Web Assembly Application when using Syncfusion Blazor RichTextEditor components with some tips.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# WebAssembly Performance in Blazor RichTextEditor Component

This section outlines performance best practices for using Syncfusion<sup style="font-size:70%">&reg;</sup> RichTextEditor component efficiently in Blazor WebAssembly application. The best practice or guidelines for general framework Blazor WebAssembly performance can be found [here](https://learn.microsoft.com/en-us/aspnet/core/blazor/performance?view=aspnetcore-7.0).

N> You can refer to our Getting Started with [Blazor Server-Side RichTextEditor](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio) and [Blazor WebAssembly RichTextEditor](https://blazor.syncfusion.com/documentation/rich-text-editor/how-to/blazor-web-assembly) documentation pages for configuration specifications.

## Avoid unnecessary component renders

During the Blazor Diffing Algorithm, every view of the RichTextEditor component and its child component will be checked for re-rendering. For instance, having an **EventCallBack** on the application or RichTextEditor will check every child component once the event callback is completed.

You can have fine-grained control over the RichTextEditor component rendering. **PreventRender** method helps to avoid unnecessary re-rendering of the RichTextEditor component. This method internally overrides the **ShouldRender** method of the RichTextEditor to prevent rendering.

In the following example:

* **PreventRender** method is called in the **IncrementCount** method which is a click callback.
* Now, the RichTextEditor component will not be a part of the rendering, which happens as a result of the click event, and **currentCount** alone will get updated.

```cshtml
@using Syncfusion.Blazor.RichTextEditor

<p>Current count: @currentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

<SfRichTextEditor @ref="rteObj"> 
    <p>The Rich Text Editor component is WYSIWYG ('what you see is what you get') editor that provides the best user experience to create and update the content. Users can format their content using standard toolbar commands.</p> 
</SfRichTextEditor> 
@code {
    SfRichTextEditor rteObj;
    private int currentCount = 0;
    private void IncrementCount()
    {
        rteObj.PreventRender();
        currentCount++;
    }
}
```

N> **PreventRender** method accepts the boolean argument that accepts true or false to disable or enable rendering, respectively.
<br/> **PreventRender** method can be used only after the RichTextEditor component completes initial rendering. Calling this method during initial rendering has no effect.

## Avoid unnecessary component renders after RichTextEditor events

When a callback method is assigned to the RichTextEditor events, then the **StateHasChanged** will be called in the parent component of the RichTextEditor automatically once the event is completed.

To prevent unnecessary re-rendering of the RichTextEditor component by calling the **PreventRender** method.

In the following example:

* **OnToolbarClick** event is bound to a callback method, when the editor content gets changed by toolbar action the event is completed, the **StateHasChanged** will be invoked for the parent component.

```cshtml
@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor @ref="rteObj">
    <RichTextEditorEvents OnToolbarClick="@ToolbarClick"/>
</SfRichTextEditor>
<div>
    <span>@((MarkupString)Output)</span>
</div>
    
@code {
    SfRichTextEditor rteObj;
    private string Output = "";
    private void ToolbarClick(ToolbarClickEventArgs args)
    {
        rteObj.PreventRender();
        this.Output = this.Output + "<span><b>OnToolbarClick</b> event called<hr></span>";
    };
}
```

N> **PreventRender** method internally overrides the **ShouldRender** method of the RichTextEditor to prevent rendering.  
<<<<<<< HEAD
<br/> It is recommended to use the **PreventRender** method for user-interactive events such as `OnToolbarClick`, `UpdatedToolbarStatus`, etc., for better performance.
=======
<br/> It is recommended to use the **PreventRender** method for user-interactive events such as `OnToolbarClick`, `UpdatedToolbarStatus`, etc., for better performance.
>>>>>>> 32c27d577704390b597a361089e564504af90b58
