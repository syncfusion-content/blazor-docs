---
layout: post
title: Events in Blazor Toast Component | Syncfusion
description: Checkout and learn here all about events in Syncfusion Blazor Toast component and much more details.
platform: Blazor
control: Toast
documentation: ug
---

# Events in Blazor Toast Component

This section explains the list of events of the Toast component which will be triggered for appropriate Toast actions.

## Created

The Created event occurs after the Toast component is initialized. This is suitable for one-time setup or initial configuration. Refer to the ToastEvents.Created API for details.

```cshtml

@using Syncfusion.Blazor.Notifications

<SfToast>
   <ToastEvents Created="@CreatedHandler" ></ToastEvents>
</SfToast>
@code{

    public void CreatedHandler(Object args)
    {
        // Here you can customize your code
    }
}

```

## Destroyed

The Destroyed event occurs when the Toast component is disposed. Use this event to release resources or unsubscribe from external services. Refer to the ToastEvents.Destroyed API for details.

```cshtml

@using Syncfusion.Blazor.Notifications

<SfToast>
   <ToastEvents Destroyed="@DestroyedHandler" ></ToastEvents>
</SfToast>
@code{

    public void DestroyedHandler(Object args)
    {
        // Here you can customize your code
    }
}

```

## Opened

The Opened event occurs after the toast is displayed in the target container. It is useful for post-render actions, such as focusing elements or starting animations. See ToastOpenArgs for available data.

```cshtml

@using Syncfusion.Blazor.Notifications

<SfToast>
   <ToastEvents Opened="@OpenedHandler" ></ToastEvents>
</SfToast>
@code{

    public void OpenedHandler(ToastOpenArgs args)
    {
        // Here you can customize your code
    }
}

```

## OnOpen

The OnOpen event occurs before the toast is displayed. Use it to modify content or settings just before render. See ToastBeforeOpenArgs for properties available during this phase.

```cshtml

@using Syncfusion.Blazor.Notifications

<SfToast>
   <ToastEvents OnOpen="@OnOpenHandler" ></ToastEvents>
</SfToast>
@code{

    public void OnOpenHandler(ToastBeforeOpenArgs args)
    {
        // Here you can customize your code
    }
}

```

## Closed

The Closed event occurs after the toast is hidden. This event is useful for cleanup tasks or logging. See ToastCloseArgs for additional context.

```cshtml

@using Syncfusion.Blazor.Notifications

<SfToast>
   <ToastEvents Closed="@ClosedHandler" ></ToastEvents>
</SfToast>
@code{

    public void ClosedHandler(ToastCloseArgs args)
    {
        // Here you can customize your code
    }
}

```

## OnClick

The OnClick event occurs when the toast is clicked. Handle this event to perform actions such as navigation, analytics, or dismissing a toast. See ToastClickEventArgs for click details.

```cshtml

@using Syncfusion.Blazor.Notifications

<SfToast>
   <ToastEvents OnClick="@OnClickHandler" ></ToastEvents>
</SfToast>
@code{

    public void OnClickHandler(ToastClickEventArgs args)
    {
        // Here you can customize your code
    }
}

```