---
layout: post
title: Events in Blazor RichTextEditor Component | Syncfusion
description: Checkout and learn here all about Events in Syncfusion Blazor RichTextEditor component and much more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Events in Blazor RichTextEditor Component

This section explains the list of events of the RichTextEditor component which will be triggered for an appropriate RichTextEditor actions.

## OnActionBegin

`OnActionBegin` event triggers before command execution using the toolbar items.

```cshtml

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor>
   <RichTextEditorEvents OnActionBegin="@OnActionBeginHandler" ></RichTextEditorEvents>
</SfRichTextEditor>
@code{

    public void OnActionBeginHandler(ActionBeginEventArgs args)
    {
        // Here you can customize your code
    }
}

```

## OnActionComplete

`OnActionComplete` event triggers after command execution using the toolbar items.

```cshtml

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor>
    <RichTextEditorEvents OnActionComplete="@OnActionCompleteHandler" ></RichTextEditorEvents>
</SfRichTextEditor>

@code{

    public void OnActionCompleteHandler(ActionCompleteEventArgs args)
    {
        // Here you can customize your code
    }
}

```

## OnDialogOpen

`OnDialogOpen` event triggers when the dialog is being opened.

```cshtml

@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor>
    <RichTextEditorEvents OnDialogOpen="@OnDialogOpenHandler"></RichTextEditorEvents>
</SfRichTextEditor>
@code{

    public void OnDialogOpenHandler(BeforeOpenEventArgs args)
    {
        // Here you can customize your code
    }
}

```

## DialogOpened

`DialogOpened` event triggers when a dialog is opened.

```cshtml

@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor>
   <RichTextEditorEvents DialogOpened="@DialogOpenedHandler"></RichTextEditorEvents>
</SfRichTextEditor>
@code{

    public void DialogOpenedHandler(DialogOpenEventArgs args)
    {
        // Here you can customize your code
    }
}

```

## OnDialogClose

`OnDialogClose` event triggers when the dialog is being closed.

```cshtml

@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor>
   <RichTextEditorEvents OnDialogClose="@OnDialogCloseHandler"></RichTextEditorEvents>
</SfRichTextEditor>
@code{

    public void OnDialogCloseHandler(BeforeCloseEventArgs args)
    {
        // Here you can customize your code
    }
}

```

## DialogClosed

`DialogClosed` event triggers after the dialog has been closed.

```cshtml

@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor>
   <RichTextEditorEvents DialogClosed="@DialogClosedHandler"></RichTextEditorEvents>
</SfRichTextEditor>
@code{

    public void DialogClosedHandler(DialogCloseEventArgs args)
    {
        // Here you can customize your code
    }
}

```

## OnQuickToolbarOpen

`OnQuickToolbarOpen` event triggers when the quick toolbar is being opened.

```cshtml

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor>
   <RichTextEditorEvents OnQuickToolbarOpen="@OnQuickToolbarOpenHandler"></RichTextEditorEvents>
</SfRichTextEditor>
@code{

    public void OnQuickToolbarOpenHandler(BeforeQuickToolbarOpenArgs args)
    {
        // Here you can customize your code
    }
}

```

## QuickToolbarOpened

`QuickToolbarOpened` event triggers when a quick toolbar is opened.

```cshtml

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor>
   <RichTextEditorEvents QuickToolbarOpened="@QuickToolbarOpenedHandler"></RichTextEditorEvents>
</SfRichTextEditor>
@code{

    public void QuickToolbarOpenedHandler(QuickToolbarEventArgs args)
    {
        // Here you can customize your code
    }
}

```

## QuickToolbarClosed

`QuickToolbarClosed` event triggers after the quick toolbar has been closed.

```cshtml

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor>
   <RichTextEditorEvents QuickToolbarClosed="@QuickToolbarClosedHandler"></RichTextEditorEvents>
</SfRichTextEditor>
@code{

    public void QuickToolbarClosedHandler(QuickToolbarEventArgs args)
    {
        // Here you can customize your code
    }
}

```

## OnImageSelected

`OnImageSelected` event triggers when the image is selected or dragged into the insert image dialog.

```cshtml

@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor>
   <RichTextEditorEvents OnImageSelected="@OnImageSelectedHandler"></RichTextEditorEvents>
</SfRichTextEditor>
@code{

    public void OnImageSelectedHandler(SelectedEventArgs args)
    {
        // Here you can customize your code
    }
}

```

## BeforeUploadImage

`BeforeUploadImage` event triggers before the image upload process.

```cshtml

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor>
   <RichTextEditorEvents BeforeUploadImage ="@BeforeUploadImageHandler"></RichTextEditorEvents>
</SfRichTextEditor>
@code{

    public void BeforeUploadImageHandler(ImageUploadingEventArgs args)
    {
        // Here you can customize your code
    }
}

```

## OnImageUploadSuccess

`OnImageUploadSuccess` event triggers when the image is successfully uploaded to the server side.

```cshtml

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor>
   <RichTextEditorEvents OnImageUploadSuccess="@OnImageUploadSuccessHandler"></RichTextEditorEvents>
</SfRichTextEditor>
@code{

    public void OnImageUploadSuccessHandler(ImageSuccessEventArgs args)
    {
        // Here you can customize your code
    }
}

```

## OnImageUploadFailed

`OnImageUploadFailed` event triggers when there is an error in the image upload.

```cshtml

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor>
   <RichTextEditorEvents OnImageUploadFailed="@OnImageUploadFailedHandler"></RichTextEditorEvents>
</SfRichTextEditor>
@code{

    public void OnImageUploadFailedHandler(ImageFailedEventArgs args)
    {
        // Here you can customize your code
    }
}

```

## OnImageRemoving

`OnImageRemoving` event triggers when the selected image is cleared from the insert image dialog.

```cshtml

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor>
   <RichTextEditorEvents OnImageRemoving="@OnImageRemovingHandler"></RichTextEditorEvents>
</SfRichTextEditor>
@code{

    public void OnImageRemovingHandler(RemovingEventArgs args)
    {
        // Here you can customize your code
    }
}

```

## ImageDelete

`ImageDelete` event triggers when the selected image is cleared from the Rich Text Editor Content.

```cshtml

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor>
   <RichTextEditorEvents ImageDelete="@OnImageDeleteHandler"></RichTextEditorEvents>
</SfRichTextEditor>
@code{

    public void OnImageDeleteHandler(AfterImageDeleteEventArgs args)
    {
        // Here you can customize your code
    }
}

```

## Created

`Created` event triggers when the Rich Text Editor is rendered.

```cshtml

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor>
   <RichTextEditorEvents Created="@CreatedHandler"></RichTextEditorEvents>
</SfRichTextEditor>
@code{

    public void CreatedHandler(Object args)
    {
        // Here you can customize your code
    }
}

```

## Destroyed

`Destroyed` event triggers when the Rich Text Editor is destroyed.

```cshtml

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor>
   <RichTextEditorEvents Destroyed="@DestroyedHandler"></RichTextEditorEvents>
</SfRichTextEditor>
@code{

    public void DestroyedHandler(DestroyedEventArgs args)
    {
        // Here you can customize your code
    }
}

```

## Blur

`Blur` event triggers when Rich Text Editor is focused out.

```cshtml

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor>
   <RichTextEditorEvents Blur="@BlurHandler"></RichTextEditorEvents>
</SfRichTextEditor>
@code{

    public void BlurHandler(BlurEventArgs args)
    {
        // Here you can customize your code
    }
}

```

## OnToolbarClick

`OnToolbarClick` event triggers when Rich Text Editor Toolbar items is clicked.

```cshtml

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor>
   <RichTextEditorEvents OnToolbarClick="@OnToolbarClickHandler"></RichTextEditorEvents>
</SfRichTextEditor>
@code{

    public void OnToolbarClickHandler(ToolbarClickEventArgs args)
    {
        // Here you can customize your code
    }
}

```

## Focus

`Focus` event triggers when Rich Text Editor is focused in.

```cshtml

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor>
   <RichTextEditorEvents Focus="@FocusHandler"></RichTextEditorEvents>
</SfRichTextEditor>
@code{

    public void FocusHandler(Syncfusion.Blazor.RichTextEditor.FocusEventArgs args)
    {
        // Here you can customize your code
    }
}

```

## ValueChange

`ValueChange` event triggers only when Rich Text Editor is blurred and changes are done to the content.

```cshtml

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor>
   <RichTextEditorEvents ValueChange="@ValueChangeHandler"></RichTextEditorEvents>
</SfRichTextEditor>
@code{

    public void ValueChangeHandler(Syncfusion.Blazor.RichTextEditor.ChangeEventArgs args)
    {
        // Here you can customize your code
    }
}

```

## SelectionChanged

`SelectionChanged` event triggers whenever the selection is modified within the Rich Text Editor.

N> This event does not trigger when the selection range is collapsed (i.e., when only the cursor is placed without any content being selected).

```cshtml

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor>
    <RichTextEditorEvents SelectionChanged="@SelectionChangedHandler"></RichTextEditorEvents>
</SfRichTextEditor>

@code {
    public void SelectionChangedHandler(Syncfusion.Blazor.RichTextEditor.SelectionChangedEventArgs args)
    {
        // Here you can customize your code
    }
}

```

## OnResizeStart

`OnResizeStart` event triggers only when resizing the image is started.

```cshtml

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor>
   <RichTextEditorEvents OnResizeStart="@OnResizeStartHandler"></RichTextEditorEvents>
</SfRichTextEditor>
@code{

    public void OnResizeStartHandler(ResizeArgs args)
    {
        // Here you can customize your code
    }
}

```

## OnResizeStop

`OnResizeStop` event triggers only when resizing the image is stopped.

```cshtml

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor>
   <RichTextEditorEvents OnResizeStop="@OnResizeStopHandler"></RichTextEditorEvents>
</SfRichTextEditor>
@code{

    public void OnResizeStopHandler(ResizeArgs args)
    {
        // Here you can customize your code
    }
}

```

## AfterPasteCleanup

`AfterPasteCleanup` event triggers after cleaning up the copied content.

```cshtml

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor>
   <RichTextEditorEvents AfterPasteCleanup="@AfterPasteCleanupHandler"></RichTextEditorEvents>
</SfRichTextEditor>
@code{

    public void AfterPasteCleanupHandler(PasteCleanupArgs args)
    {
        // Here you can customize your code
    }
}

```