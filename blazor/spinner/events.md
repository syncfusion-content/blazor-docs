---
layout: post
title: Events in Blazor Spinner Component | Syncfusion 
description: Learn about Events in Blazor Spinner component of Syncfusion, and more details.
platform: Blazor
control: Spinner
documentation: ug
---

# Events

This section explains the list of events of the Spinner component which will be triggered for appropriate Spinner actions.

## Created

`Created` event triggers after the Spinner is created.

```csharp

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

```csharp

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

```csharp

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

```csharp

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
