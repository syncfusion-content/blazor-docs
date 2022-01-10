---
layout: post
title: RichTextEditor inside the Dialog Component | Syncfusion
description: Checkout and learn here all about rendering RichTextEditor component inside the Dialog component and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# RichTextEditor inside the Dialog Component

While rendering the Rich Text Editor inside the Dialog component, the dialog container and its wrapper elements are styled with display as none, so the editor’s toolbar does not get proper offset width and will render above the edit area container. To resolve this issue, you can call the RefreshUI method of RichTextEditor in the Dialog Opened event.

{% highlight razor %}

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
        this.RteObj.RefreshUI();
    }
} 

{% endhighlight %}
