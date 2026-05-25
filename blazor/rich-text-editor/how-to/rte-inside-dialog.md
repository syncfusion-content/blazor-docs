---
layout: post
title: RichTextEditor inside the Dialog Component | Blazor | Syncfusion
description: This section explains about rendering the Blazor RichTextEditor component inside the Dialog component.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Rich Text Editor inside the Dialog Component

While rendering the Rich Text Editor inside the [Dialog](https://blazor.syncfusion.com/documentation/dialog/getting-started-with-web-app) component, the dialog container and its wrapper elements are styled with display as none, so the editor’s toolbar does not get proper offset width and will render above the edit area container. To resolve this issue, you can call the [RefreshUIAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_RefreshUIAsync) method of RichTextEditor in the [Dialog Opened](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogEvents.html#Syncfusion_Blazor_Popups_DialogEvents_Opened) event.

{% highlight cshtml %}

@using Syncfusion.Blazor.RichTextEditor
@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Buttons

<SfButton @onclick="@OpenDialog">Open Dialog</SfButton>
<SfDialog @ref="DialogObj" Width="450px" ShowCloseIcon="true">
    <DialogEvents Opened="@DialogOpen"></DialogEvents>
    <DialogTemplates>
        <Header>
            <div>Dialog Header</div>
        </Header>
        <Content>
            <SfRichTextEditor @ref="RteObj">
            </SfRichTextEditor>
        </Content>
    </DialogTemplates>
</SfDialog>

@code {
    SfDialog DialogObj;
    SfRichTextEditor RteObj;
    private void OpenDialog()
    {
        this.DialogObj.ShowAsync();
    }
    private void DialogOpen()
    {
        this.RteObj.RefreshUIAsync();
    }
} 

{% endhighlight %}

![Blazor RichTextEditor with Dialog Component](../images/blazor-richtexteditor-dialog-component.webp)