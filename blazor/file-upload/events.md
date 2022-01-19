---
layout: post
title: Events in Blazor File Upload Component | Syncfusion
description: Checkout and learn here all about Events in Syncfusion Blazor File Upload component and much more details.
platform: Blazor
control: File Upload
documentation: ug
---

# Events in Blazor File Upload Component

This section explains the list of events of the File Upload component which will be triggered for appropriate File Upload actions.

## BeforeRemove

`BeforeRemove` event triggers when the uploaded file is removed. The event is used to get confirmation before removing the file from the server.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfUploader>
    <UploaderEvents BeforeRemove="@BeforeRemovehandler"></UploaderEvents>
</SfUploader>

@code {
    private void BeforeRemovehandler(BeforeRemoveEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

## BeforeUpload

`BeforeUpload` event triggers when the upload process before. This event is used to add additional parameter with upload request.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfUploader>
    <UploaderEvents BeforeUpload="@BeforeUploadHandler"></UploaderEvents>
</SfUploader>

@code {
    private void BeforeUploadHandler(BeforeUploadEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

## Created

`Created` event triggers when the component is created.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfUploader>
    <UploaderEvents Created="@CreatedHandler"></UploaderEvents>
</SfUploader>

@code {
    private void CreatedHandler(Object args)
    {
        // Here, you can customize your code.
    }
}
```

## FileSelected

`FileSelected` event triggers after selecting or dropping the files by adding the files in upload queue.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfUploader>
    <UploaderEvents FileSelected="@FileSelectedHandler"></UploaderEvents>
</SfUploader>

@code {
    private void FileSelectedHandler(SelectedEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

## OnActionComplete

`OnActionComplete` event triggers after all the selected files have been processed to upload successfully or failed to server.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfUploader>
    <UploaderEvents OnActionComplete="@OnActionCompleteHandler"></UploaderEvents>
</SfUploader>

@code {
    private void OnActionCompleteHandler(ActionCompleteEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

## OnCancel

`OnCancel` event fires if the chunk file upload is canceled.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfUploader>
    <UploaderEvents OnCancel="@OnCancelHandler"></UploaderEvents>
</SfUploader>

@code {
    private void OnCancelHandler(CancelEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

## OnChunkFailure

`OnChunkFailure` event fires if the chunk file failed to upload.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfUploader>
    <UploaderEvents OnChunkFailure="@OnChunkFailureHandler"></UploaderEvents>
</SfUploader>

@code {
    private void OnChunkFailureHandler(FailureEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

## OnChunkFailured

`OnChunkFailured` event fires if the chunk file failed to upload.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfUploader>
    <UploaderEvents OnChunkFailured="@OnChunkFailuredHandler"></UploaderEvents>
</SfUploader>

@code {
    private void OnChunkFailuredHandler(FailureEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

## OnChunkSuccess

`OnChunkSuccess` event fires when the chunk file is uploaded successfully.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfUploader>
    <UploaderEvents OnChunkSuccess="@OnChunkSuccessHandler"></UploaderEvents>
</SfUploader>

@code {
    private void OnChunkSuccessHandler(SuccessEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

## OnChunkUploadStart

`OnChunkUploadStart` event fires when every chunk upload process gets started. This event is used to add additional parameter with upload request.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfUploader>
    <UploaderEvents OnChunkUploadStart="@OnChunkUploadStartHandler"></UploaderEvents>
</SfUploader>

@code {
    private void OnChunkUploadStartHandler(UploadingEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

## OnClear

`OnClear` event triggers before clearing the items in file list when clicking "clear".

```cshtml
@using Syncfusion.Blazor.Inputs

<SfUploader>
    <UploaderEvents OnClear="@OnClearHandler"></UploaderEvents>
</SfUploader>

@code {
    private void OnClearHandler(ClearingEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

## OnFailure

`OnFailure` event triggers when the AJAX request fails on uploading or removing files.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfUploader>
    <UploaderEvents OnFailure="@OnFailureHandler"></UploaderEvents>
</SfUploader>

@code {
    private void OnFailureHandler(FailureEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

## OnFailured

`OnFailured` event triggers when the AJAX request fails on uploading or removing files.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfUploader>
    <UploaderEvents OnFailured="@OnFailuredHandler"></UploaderEvents>
</SfUploader>

@code {
    private void OnFailuredHandler(FailureEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

## OnFileListRender

`OnFileListRender` event triggers before rendering each file item from the file list in a page. It helps to customize specific file item structure.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfUploader>
    <UploaderEvents OnFileListRender="@OnFileListRenderHandler"></UploaderEvents>
</SfUploader>

@code {
    private void OnFileListRenderHandler(FileListRenderingEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

## OnRemove

`OnRemove` event triggers on removing the uploaded file. The event is used to get confirmation before removing the file from the server.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfUploader>
    <UploaderEvents OnRemove="@OnRemoveHandler"></UploaderEvents>
</SfUploader>

@code {
    private void OnRemoveHandler(RemovingEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

## OnResume

`OnResume` event fires if the paused chunk file upload is resumed.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfUploader>
    <UploaderEvents OnResume="@OnResumeHandler"></UploaderEvents>
</SfUploader>

@code {
    private void OnResumeHandler(PauseResumeEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

## OnUploadStart

`OnUploadStart` event triggers when the upload process gets started. This event is used to add additional parameter with upload request.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfUploader>
    <UploaderEvents OnUploadStart="@OnUploadStartHandler"></UploaderEvents>
</SfUploader>

@code {
    private void OnUploadStartHandler(UploadingEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

## Paused

`Paused` event fires if the chunk file upload is paused.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfUploader>
    <UploaderEvents Paused="@PausedHandler"></UploaderEvents>
</SfUploader>

@code {
    private void PausedHandler(PauseResumeEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

## Progressing

`Progressing` event triggers when uploading a file to the server using the AJAX request.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfUploader>
    <UploaderEvents Progressing="@ProgressingHandler"></UploaderEvents>
</SfUploader>

@code {
    private void ProgressingHandler(Syncfusion.Blazor.Inputs.ProgressEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

## Success

`Success` event triggers when the AJAX request gets success on uploading files or removing files.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfUploader>
    <UploaderEvents Success="@SuccessHandler"></UploaderEvents>
</SfUploader>

@code {
    private void SuccessHandler(SuccessEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

## ValueChange

`ValueChange` event triggers when changes occur in uploaded file list by selecting or dropping files.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfUploader>
    <UploaderEvents ValueChange="@ValueChangeHandler"></UploaderEvents>
</SfUploader>

@code {
    private void ValueChangeHandler(UploadChangeEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

> File Upload is limited with these events and new events will be added in the future based on the user requests. If the event you are looking for is not on the list, then please request [here](https://www.syncfusion.com/feedback/blazor-components).