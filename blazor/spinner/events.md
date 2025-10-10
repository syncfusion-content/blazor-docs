---
layout: post
title: Events in Blazor Spinner Component | Syncfusion
description: Checkout and learn here all about events in Syncfusion Blazor Spinner component and much more details.
platform: Blazor
control: Spinner
documentation: ug
---

# Events in Blazor Spinner Component

This section lists the events triggered by the Spinner component and when they occur during Spinner actions.

## Created

The `Created` event is triggered after the Spinner is created.

```cshtml

@using Syncfusion.Blazor.Spinner

<SfSpinner>
   <SpinnerEvents Created="@CreatedHandler" ></SpinnerEvents>
</SfSpinner>
@code{

    public void CreatedHandler(Object args)
    {
        // Here you can customize your code
    }
}

```

## OnBeforeOpen

The `OnBeforeOpen` event is triggered before the Spinner is opened.

```cshtml

@using Syncfusion.Blazor.Spinner

<SfSpinner>
   <SpinnerEvents OnBeforeOpen="@OnBeforeOpenHandler" ></SpinnerEvents>
</SfSpinner>
@code{

    public void OnBeforeOpenHandler(SpinnerEventArgs args)
    {
        // Here you can customize your code
    }
}

```

## OnBeforeClose

The `OnBeforeClose` event is triggered before the Spinner is closed.

```cshtml

@using Syncfusion.Blazor.Spinner

<SfSpinner>
   <SpinnerEvents OnBeforeClose="@OnBeforeCloseHandler" ></SpinnerEvents>
</SfSpinner>
@code{

    public void OnBeforeCloseHandler(SpinnerEventArgs args)
    {
        // Here you can customize your code
    }
}

```

## Destroyed

The `Destroyed` event is triggered after the Spinner is destroyed.

```cshtml

@using Syncfusion.Blazor.Spinner

<SfSpinner>
   <SpinnerEvents Destroyed="@DestroyedHandler" ></SpinnerEvents>
</SfSpinner>
@code{

    public void DestroyedHandler(Object args)
    {
        // Here you can customize your code
    }
}

```