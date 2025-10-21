---
layout: post
title: Events in Blazor Toast Component | Syncfusion
description: Checkout and learn here all about events in Syncfusion Blazor Toast component and much more details.
platform: Blazor
control: Toast
documentation: ug
---

# Events in Blazor Toast Component

This section explains the list of events of the **Toast** component that are triggered for corresponding Toast actions in a Blazor application.

## Created

The **Created** event occurs after the **Toast** component is initialized. This is suitable for one-time setup or initial configuration. Refer to the [ToastEvents.Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.ToastEvents.html#Syncfusion_Blazor_Notifications_ToastEvents_Created) API for details.

```cshtml
@using Syncfusion.Blazor.Notifications

<SfToast>
    <ToastEvents Created="@CreatedHandler"></ToastEvents>
</SfToast>

@code {
    public void CreatedHandler(object args)
    {
        // Example customization point: runs once after component initialization.
    }
}
```

Preview of the code snippet: After the Toast component initializes, the CreatedHandler method executes once. No visual change is produced by the handler itself unless additional logic is included.

## Destroyed

The **Destroyed** event occurs when the **Toast** component is disposed. Use this event to release resources or unsubscribe from external services. Refer to the [ToastEvents.Destroyed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.ToastEvents.html#Syncfusion_Blazor_Notifications_ToastEvents_Destroyed) API for details.

```cshtml
@using Syncfusion.Blazor.Notifications

<SfToast>
    <ToastEvents Destroyed="@DestroyedHandler"></ToastEvents>
</SfToast>

@code {
    public void DestroyedHandler(object args)
    {
        // Example cleanup point: release resources, unsubscribe handlers.
    }
}
```

Preview of the code snippet: When the Toast component is disposed (for example, navigation away or component removal), DestroyedHandler executes to perform cleanup. No visual output is produced.

## Opened

The **Opened** event occurs after the Toast is displayed in the target container. It is useful for post-render actions, such as focusing elements or starting animations. See [ToastOpenArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.ToastOpenArgs.html) for available data.

```cshtml
@using Syncfusion.Blazor.Notifications

<SfToast>
    <ToastEvents Opened="@OpenedHandler"></ToastEvents>
</SfToast>

@code {
    public void OpenedHandler(ToastOpenArgs args)
    {
        // Runs after the toast becomes visible; safe for post-render logic.
    }
}
```

Preview of the code snippet: After a toast appears, OpenedHandler is invoked. The UI shows the toast; any additional actions (focus, animation) occur post-render.

## OnOpen

The **OnOpen** event occurs before the Toast is displayed. Use it to modify content or settings just before render. See [ToastBeforeOpenArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.ToastBeforeOpenArgs.html) for properties available during this phase.

```cshtml
@using Syncfusion.Blazor.Notifications

<SfToast>
    <ToastEvents OnOpen="@OnOpenHandler"></ToastEvents>
</SfToast>

@code {
    public void OnOpenHandler(ToastBeforeOpenArgs args)
    {
        // Runs before the toast is shown; suitable for last-moment adjustments.
    }
}
```

Preview of the code snippet: Before the toast is shown, OnOpenHandler executes, allowing configuration changes. The toast then renders with any applied adjustments.

## Closed

The **Closed** event occurs after the Toast is hidden. This event is useful for cleanup tasks or logging. See [ToastCloseArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.ToastCloseArgs.html) for additional context.

```cshtml
@using Syncfusion.Blazor.Notifications

<SfToast>
    <ToastEvents Closed="@ClosedHandler"></ToastEvents>
</SfToast>

@code {
    public void ClosedHandler(ToastCloseArgs args)
    {
        // Runs after the toast is hidden; suitable for cleanup or logging.
    }
}
```

Preview of the code snippet: After the toast is dismissed (auto or manual), ClosedHandler runs. No visual output is produced by the handler itself.

## OnClick

The **OnClick** event occurs when the Toast is clicked. Handle this event to perform actions such as navigation, analytics, or dismissing a toast. See [ToastClickEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.ToastClickEventArgs.html) for click details.

```cshtml
@using Syncfusion.Blazor.Notifications

<SfToast>
    <ToastEvents OnClick="@OnClickHandler"></ToastEvents>
</SfToast>

@code {
    public void OnClickHandler(ToastClickEventArgs args)
    {
        // Runs on toast click; handle navigation, analytics, or dismissal.
    }
}
```

Preview of the code snippet: When the visible toast is clicked, OnClickHandler executes. The UI reflects any actions implemented in the handler (for example, dismissing the toast).
