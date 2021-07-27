---
layout: post
title: Events in Blazor Toast Component | Syncfusion
description: Learn here all about Events in Syncfusion Blazor Toast component and more.
platform: Blazor
control: Toast
documentation: ug
---

# Events in Blazor Toast Component

This section explains the list of events of the Toast component which will be triggered for appropriate Toast actions.

## Created

`Created` event triggers after the Toast gets created.

```csharp

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

```csharp

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

`Opened` event triggers after the Toast shown on the target container.

```csharp

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

`OnOpen` event triggers before the toast shown.

```csharp

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

```csharp

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

```csharp

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