---
layout: post
title: Events in Blazor Chat UI Component | Syncfusion
description: Checkout and learn here all about Events with Syncfusion Blazor Chat UI component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Chat UI
documentation: ug
---

# Events in Blazor Chat UI component

This section describes the Chat UI events that will be triggered when appropriate actions are performed. The following events are available in the Chat UI component.

## Created

The Chat UI component triggers the [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InteractiveChat.SfChatUI.html#Syncfusion_Blazor_InteractiveChat_SfChatUI_Created) event when the component rendering is completed.

```cshtml

@using Syncfusion.Blazor.InteractiveChat

<div style="height: 400px; width: 400px;">
    <SfChatUI Created="Created"></SfChatUI>
</div>

@code {
    private void Created()
    {
        // Your required action here
    }
}

```

## Sending message

The [MessageSend](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InteractiveChat.SfChatUI.html#Syncfusion_Blazor_InteractiveChat_SfChatUI_MessageSend) event is triggered when the message is being sent in the Chat UI component.

```cshtml

@using Syncfusion.Blazor.InteractiveChat

<div style="height: 400px; width: 400px;">
    <SfChatUI MessageSend="MessageSend"></SfChatUI>
</div>

@code {
    private void MessageSend(ChatMessageSendEventArgs args)
    {
        // Your required action here
    }
}

```

## User typing

The [UserTyping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InteractiveChat.SfChatUI.html#Syncfusion_Blazor_InteractiveChat_SfChatUI_UserTyping) event is triggered when the user is typing a message in the Chat UI component.

```cshtml

@using Syncfusion.Blazor.InteractiveChat

<div style="height: 400px; width: 400px;">
    <SfChatUI UserTyping="UserTyping"></SfChatUI>
</div>

@code {
    private void UserTyping(ChatUserTypingEventArgs args)
    {
        // Your required action here
    }
}

```

## OnAttachmentUploadReady

The [OnAttachmentUploadReady](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InteractiveChat.SfChatUI.html#Syncfusion_Blazor_InteractiveChat_SfChatUI_OnAttachmentUploadReady) event is triggered before the attached files upload begins in the Chat UI component.

```cshtml

@using Syncfusion.Blazor.InteractiveChat

<div style="height: 400px; width: 400px;">
    <SfChatUI OnAttachmentUploadReady="OnAttachmentUploadReady">
        <ChatUIAttachment Enable SaveUrl="@SaveUrl" RemoveUrl="@RemoveUrl"></ChatUIAttachment>
    </SfChatUI>
</div>

@code {

    private string SaveUrl = "https://blazor.syncfusion.com/services/production/api/FileUploader/Save";
    private string RemoveUrl = "https://blazor.syncfusion.com/services/production/api/FileUploader/Remove";

    private void OnAttachmentUploadReady(AttachmentUploadReadyEventArgs args)
    {
        // Your required action here
    }
}
```

## AttachmentUploadSuccess

The [AttachmentUploadSuccess](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InteractiveChat.SfChatUI.html#Syncfusion_Blazor_InteractiveChat_SfChatUI_AttachmentUploadSuccess) event is triggered when the attached file is successfully uploaded in the Chat UI component.

```cshtml

@using Syncfusion.Blazor.InteractiveChat
@using Syncfusion.Blazor.Inputs

<div style="height: 400px; width: 400px;">
    <SfChatUI AttachmentUploadSuccess="AttachmentUploadSuccess">
        <ChatUIAttachment Enable SaveUrl="@SaveUrl" RemoveUrl="@RemoveUrl"></ChatUIAttachment>
    </SfChatUI>
</div>

@code {

    private string SaveUrl = "https://blazor.syncfusion.com/services/production/api/FileUploader/Save";
    private string RemoveUrl = "https://blazor.syncfusion.com/services/production/api/FileUploader/Remove";

    private void AttachmentUploadSuccess(SuccessEventArgs args)
    {
        // Your required action here
    }
}

```

## AttachmentUploadFailed

The [AttachmentUploadFailed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InteractiveChat.SfChatUI.html#Syncfusion_Blazor_InteractiveChat_SfChatUI_AttachmentUploadFailed) event is triggered when the attached file upload fails in the Chat UI component.

```cshtml

@using Syncfusion.Blazor.InteractiveChat
@using Syncfusion.Blazor.Inputs

<div style="height: 400px; width: 400px;">
    <SfChatUI AttachmentUploadFailed="AttachmentUploadFailed">
        <ChatUIAttachment Enable SaveUrl="@SaveUrl" RemoveUrl="@RemoveUrl"></ChatUIAttachment>
    </SfChatUI>
</div>

@code {

    private string SaveUrl = "https://blazor.syncfusion.com/services/production/api/FileUploader/Save";
    private string RemoveUrl = "https://blazor.syncfusion.com/services/production/api/FileUploader/Remove";

    private void AttachmentUploadFailed(FailureEventArgs args)
    {
        // Your required action here
    }
}

```

## AttachmentRemoved

The [AttachmentUploadRemoved](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InteractiveChat.SfChatUI.html#Syncfusion_Blazor_InteractiveChat_SfChatUI_AttachmentUploadRemoved) event is triggered when an attached file is removed in the Chat UI component.

```cshtml

@using Syncfusion.Blazor.InteractiveChat
@using Syncfusion.Blazor.Inputs

<div style="height: 400px; width: 400px;">
    <SfChatUI AttachmentRemoved="AttachmentRemoved">
        <ChatUIAttachment Enable SaveUrl="@SaveUrl" RemoveUrl="@RemoveUrl"></ChatUIAttachment>
    </SfChatUI>
</div>

@code {

    private string SaveUrl = "https://blazor.syncfusion.com/services/production/api/FileUploader/Save";
    private string RemoveUrl = "https://blazor.syncfusion.com/services/production/api/FileUploader/Remove";

    private void AttachmentRemoved(RemovingEventArgs args)
    {
        // Your required action here
    }
}

```

## AttachmentClick

The [AttachmentClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InteractiveChat.SfChatUI.html#Syncfusion_Blazor_InteractiveChat_SfChatUI_AttachmentClick) event is triggered when an attached file is clicked in the Chat UI component.

```cshtml

@using Syncfusion.Blazor.InteractiveChat

<div style="height: 400px; width: 400px;">
    <SfChatUI AttachmentClick="AttachmentClick">
        <ChatUIAttachment Enable SaveUrl="@SaveUrl" RemoveUrl="@RemoveUrl"></ChatUIAttachment>
    </SfChatUI>
</div>

@code {

    private string SaveUrl = "https://blazor.syncfusion.com/services/production/api/FileUploader/Save";
    private string RemoveUrl = "https://blazor.syncfusion.com/services/production/api/FileUploader/Remove";

    private void AttachmentClick(ChatAttachmentClickEventArgs args)
    {
        // Your required action here
    }
}

```
