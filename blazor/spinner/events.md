---
layout: post
title: Events in Blazor Spinner Component | Syncfusion
description: Checkout and learn here all about events in Syncfusion Blazor Spinner component and much more details.
platform: Blazor
control: Spinner
documentation: ug
---

# Events in Blazor Spinner Component

This section explains the list of events of the [Blazor Spinner component](https://www.syncfusion.com/blazor-components/blazor-spinner) which will be triggered for appropriate Spinner actions.

## Created

`Created` event triggers after the Spinner is created.

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

`OnBeforeOpen` event triggers before the Spinner is opened.

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

`OnBeforeClose` event triggers before the Spinner is closed.

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

`Destroyed` event triggers after the Spinner is destroyed.

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
N> You can also explore our [Blazor Spinner Example](https://blazor.syncfusion.com/demos/spinner/overview) that shows you how to render and configure the Spinner.