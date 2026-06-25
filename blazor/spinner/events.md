---
layout: post
title: Events in Blazor Spinner Component | Syncfusion®
description: Checkout and learn here all about events in Blazor Spinner component and much more details.
platform: Blazor
control: Spinner
documentation: ug
---

# Events in Blazor Spinner Component

The Blazor Spinner component exposes a set of lifecycle events that hook into key moments of the Spinner's existence — from its initial creation to its final destruction, as well as before it is shown or hidden. These events provide full control over the Spinner's behavior, enabling custom logic execution, application state updates, operation cancellation, or integration with logging and monitoring systems.

All Spinner events are configured through the [SpinnerEvents](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spinner.SpinnerEventArgs.html#properties) child component, which must be nested inside the Spinner component. The `SpinnerEvents` tag accepts event callback attributes for each supported event.

## List of events

The following table lists all the events available in the Spinner component:

| Event | Trigger Point | Event Args |
| --- | --- | --- |
| `Created` | After the Spinner is created and rendered | `Object` |
| `OnBeforeOpen` | Before the Spinner becomes visible | `SpinnerEventArgs` |
| `OnBeforeClose` | Before the Spinner is hidden | `SpinnerEventArgs` |
| `Destroyed` | After the Spinner is destroyed and removed | `Object` |

## Created

The [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spinner.SpinnerEvents.html#Syncfusion_Blazor_Spinner_SpinnerEvents_Created) event is triggered after the Spinner component has been fully initialized and rendered in the DOM. This event is fired only once during the component's lifecycle — at the time of creation.

Since the Spinner has already been rendered when this event fires, its properties can be accessed and its methods can be safely invoked from within the handler.

```cshtml
@using Syncfusion.Blazor.Spinner

<SfSpinner>
    <SpinnerEvents Created="@CreatedHandler"></SpinnerEvents>
</SfSpinner>

@code {
    public void CreatedHandler(Object args)
    {
        // Spinner has been successfully created and is ready to use.
        // Initialize related state or log the creation event here.
        Console.WriteLine("Spinner component has been created.");
    }
}
```

## OnBeforeOpen

The [OnBeforeOpen](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spinner.SpinnerEvents.html#Syncfusion_Blazor_Spinner_SpinnerEvents_OnBeforeOpen) event is triggered just before the Spinner transitions from a hidden state to a visible state. This event receives a `SpinnerEventArgs` parameter, which provides the ability to cancel the open operation by setting `args.Cancel = true`. This is particularly useful in scenarios where the Spinner display must be conditionally prevented, such as when a prerequisite condition has not been met or when a specific workflow step should bypass the loading indicator.

```cshtml
@using Syncfusion.Blazor.Spinner

<SfSpinner @ref="SpinnerRef" Visible="@IsVisible">
    <SpinnerEvents OnBeforeOpen="@OnBeforeOpenHandler"></SpinnerEvents>
</SfSpinner>

@code {
    SfSpinner SpinnerRef;
    public bool IsVisible { get; set; } = false;

    public void OnBeforeOpenHandler(SpinnerEventArgs args)
    {
        // Optionally cancel the open operation.
        // args.Cancel = true;

        // Log or update application state before the Spinner appears.
        Console.WriteLine("Spinner is about to open.");
    }
}
```

## OnBeforeClose

The [OnBeforeClose](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spinner.SpinnerEvents.html#Syncfusion_Blazor_Spinner_SpinnerEvents_OnBeforeClose) event is triggered just before the Spinner transitions from a visible state to a hidden state. Like `OnBeforeOpen`, this event also receives a `SpinnerEventArgs` parameter and supports cancellation via `args.Cancel = true`, which keeps the Spinner visible if the underlying operation has not yet completed.

```cshtml
@using Syncfusion.Blazor.Spinner

<SfSpinner @ref="SpinnerRef" Visible="@IsVisible">
    <SpinnerEvents OnBeforeClose="@OnBeforeCloseHandler"></SpinnerEvents>
</SfSpinner>

@code {
    SfSpinner SpinnerRef;
    public bool IsVisible { get; set; } = true;

    public void OnBeforeCloseHandler(SpinnerEventArgs args)
    {
        // Optionally prevent the Spinner from closing.
        // args.Cancel = true;

        // Perform cleanup or application state update before the Spinner hides.
        Console.WriteLine("Spinner is about to close.");
    }
}
```

## Destroyed

The [Destroyed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spinner.SpinnerEvents.html#Syncfusion_Blazor_Spinner_SpinnerEvents_Destroyed) event is triggered after the Spinner component has been completely removed from the DOM and all its internal resources have been released. This event fires once during the component's lifecycle, symmetrically opposite to the `Created` event. It is the appropriate place to perform final cleanup tasks — such as releasing object references held for the Spinner, removing event subscriptions that were set up during creation, or logging that the component has been torn down.

Since the component no longer exists in the DOM when this event fires, invoking Spinner methods or accessing its properties within the handler should be avoided.

```cshtml
@using Syncfusion.Blazor.Spinner

<SfSpinner>
    <SpinnerEvents Destroyed="@DestroyedHandler"></SpinnerEvents>
</SfSpinner>

@code {
    public void DestroyedHandler(Object args)
    {
        // Spinner has been destroyed and removed from the DOM.
        // Release references or perform final cleanup at this point.
        Console.WriteLine("Spinner component has been destroyed.");
    }
}
```

## Handling all events together

The following example demonstrates how to bind all four Spinner events simultaneously. Each event handler updates a shared status message, providing a real-time view of the Spinner's lifecycle as it progresses from creation through open/close cycles to final destruction.

```cshtml
@using Syncfusion.Blazor.Spinner

<SfSpinner @ref="SpinnerRef" Visible="@IsVisible">
    <SpinnerEvents Created="@OnCreated"
                   OnBeforeOpen="@OnBeforeOpen"
                   OnBeforeClose="@OnBeforeClose"
                   Destroyed="@OnDestroyed">
    </SpinnerEvents>
</SfSpinner>

<div style="margin-top: 16px;">
    <button @onclick="ShowSpinner">Show Spinner</button>
    <button @onclick="HideSpinner" style="margin-left: 8px;">Hide Spinner</button>
</div>

<p style="margin-top: 12px; font-style: italic; color: #555;">Status: @StatusMessage</p>

@code {
    SfSpinner SpinnerRef;
    public bool IsVisible { get; set; } = false;
    public string StatusMessage { get; set; } = "Waiting for interaction...";

    private async Task ShowSpinner()
    {
        IsVisible = true;
        await Task.Delay(2000); // Simulate an async operation.
        IsVisible = false;
    }

    private void HideSpinner()
    {
        IsVisible = false;
    }

    public void OnCreated(Object args)
    {
        StatusMessage = "Spinner created and ready.";
    }

    public void OnBeforeOpen(SpinnerEventArgs args)
    {
        StatusMessage = "Spinner is opening...";
    }

    public void OnBeforeClose(SpinnerEventArgs args)
    {
        StatusMessage = "Spinner is closing...";
    }

    public void OnDestroyed(Object args)
    {
        StatusMessage = "Spinner has been destroyed.";
    }
}
```
