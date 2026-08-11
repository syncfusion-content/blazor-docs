---
layout: post
title: Events in Blazor Toast | Syncfusion
description: Handle Blazor Toast events including Created, OnOpen, OnClose, Destroyed, and Clicked.
platform: Blazor
control: Toast
documentation: ug
---

# Events in Blazor Toast

This section explains the list of events of the Toast component which will be triggered for appropriate Toast actions.

## Created

`Created` event triggers after the Toast gets created.

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

`Destroyed` event triggers after the Toast gets destroyed.

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

`Opened` event triggers after the Toast is shown on the target container.

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

`OnOpen` event triggers before the Toast is shown.

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

`Closed` event triggers after the Toast hides.

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

`OnClick` event triggers while clicking on the Toast.

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
