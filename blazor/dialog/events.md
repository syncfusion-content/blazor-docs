---
layout: post
title: Events in Blazor Dialog Component | Syncfusion 
description: Learn about Events in Blazor Dialog component of Syncfusion, and more details.
platform: Blazor
control: Dialog
documentation: ug
---

# Events

This section explains the list of events of the Dialog component which will be triggered for appropriate Dialog actions.

## Created

`Created` event triggers when the dialog is created.

```csharp

@using Syncfusion.Blazor.Popups

<SfDialog>
   <DialogEvents Created="@CreatedHandler" ></DialogEvents>
</SfDialog>
@code{

    public void CreatedHandler(Object args)
    {
        // Here you can customize your code
    }
}

```

## Opened

`Opened` event triggers when a dialog is opened.

```csharp

@using Syncfusion.Blazor.Popups

<SfDialog>
   <DialogEvents Opened="@OpenedHandler" ></DialogEvents>
</SfDialog>
@code{

    public void OpenedHandler(OpenEventArgs args)
    {
        // Here you can customize your code
    }
}

```

## OnOpen

`OnOpen` event triggers when the dialog is being opened.

```csharp

@using Syncfusion.Blazor.Popups

<SfDialog>
   <DialogEvents OnOpen="@OnOpenHandler" ></DialogEvents>
</SfDialog>
@code{

    public void OnOpenHandler(BeforeOpenEventArgs args)
    {
        // Here you can customize your code
    }
}

```

## Closed

`Closed` event triggers after the dialog has been closed.

```csharp

@using Syncfusion.Blazor.Popups

<SfDialog>
   <DialogEvents Closed="@ClosedHandler" ></DialogEvents>
</SfDialog>
@code{

    public void ClosedHandler(CloseEventArgs args)
    {
        // Here you can customize your code
    }
}

```

## OnClose

`OnClose` event triggers before the dialog is closed.

```csharp

@using Syncfusion.Blazor.Popups

<SfDialog>
   <DialogEvents OnClose="@OnCloseHandler" ></DialogEvents>
</SfDialog>
@code{

    public void OnCloseHandler(BeforeCloseEventArgs args)
    {
        // Here you can customize your code
    }
}

```

## OnDragStart

`OnDragStart` event triggers when the user begins dragging the dialog.

```csharp

@using Syncfusion.Blazor.Popups

<SfDialog>
   <DialogEvents OnDragStart="@OnDragStartHandler" ></DialogEvents>
</SfDialog>
@code{

    public void OnDragStartHandler(DragStartEventArgs args)
    {
        // Here you can customize your code
    }
}

```

## OnDragStop

`OnDragStop` event triggers when the user stop dragging the dialog.

```csharp

@using Syncfusion.Blazor.Popups

<SfDialog>
   <DialogEvents OnDragStop="@OnDragStopHandler" ></DialogEvents>
</SfDialog>
@code{

    public void OnDragStopHandler(DragStopEventArgs args)
    {
        // Here you can customize your code
    }
}

```

## OnDrag

`OnDrag` event triggers when the user drags the dialog.

```csharp

@using Syncfusion.Blazor.Popups

<SfDialog>
   <DialogEvents OnDrag="@OnDragHandler" ></DialogEvents>
</SfDialog>
@code{

    public void OnDragHandler(DragEventArgs args)
    {
        // Here you can customize your code
    }
}

```

## OnOverlayModalClick

`OnOverlayModalClick` event triggers when the overlay of dialog is clicked.

```csharp

@using Syncfusion.Blazor.Popups

<SfDialog>
   <DialogEvents OnOverlayModalClick ="@OnOverlayModalClickHandler" ></DialogEvents>
</SfDialog>
@code{

    public void OnOverlayModalClickHandler(OverlayModalClickEventArgs args)
    {
        // Here you can customize your code
    }
}

```

## OnResizeStart

`OnResizeStart` event triggers when the user begins to resize a dialog.

```csharp

@using Syncfusion.Blazor.Popups

<SfDialog>
   <DialogEvents OnResizeStart="@OnResizeStartHandler" ></DialogEvents>
</SfDialog>
@code{

    public void OnResizeStartHandler(MouseEventArgs args)
    {
        // Here you can customize your code
    }
}

```

## Resizing

`Resizing` event triggers when the user resize the dialog.

```csharp

@using Syncfusion.Blazor.Popups

<SfDialog>
   <DialogEvents Resizing="@ResizingHandler" ></DialogEvents>
</SfDialog>
@code{

    public void ResizingHandler(MouseEventArgs args)
    {
        // Here you can customize your code
    }
}

```

## OnResizeStop

`OnResizeStop` event triggers when the user stop to resize a dialog.

```csharp

@using Syncfusion.Blazor.Popups

<SfDialog>
   <DialogEvents OnResizeStop="@OnResizeStopHandler" ></DialogEvents>
</SfDialog>
@code{

    public void OnResizeStopHandler(MouseEventArgs args)
    {
        // Here you can customize your code
    }
}

```

## Destroyed

`Destroyed` event triggers when the dialog is destroyed.

```csharp

@using Syncfusion.Blazor.Popups

<SfDialog>
   <DialogEvents Destroyed="@DestroyedHandler" ></DialogEvents>
</SfDialog>
@code{

    public void DestroyedHandler(Object args)
    {
        // Here you can customize your code
    }
}

```