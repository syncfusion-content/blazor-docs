---
layout: post
title: Positioning in Blazor Dialog Component | Syncfusion
description: Checkout and learn here all about Positioning in Syncfusion Blazor Dialog component and much more details.
platform: Blazor
control: Dialog
documentation: ug
---

# Positioning in Blazor Dialog Component

The [Blazor Dialog](https://www.syncfusion.com/blazor-components/blazor-modal-dialog) can be positioned using the `DialogPositionData` property by providing the X and Y coordinates. It can be positioned inside the target of the `container` or `<body>` of the element based on the given X and Y values.

## DialogPositionData Properties

The DialogPositionData class sets the dialog's X and Y coordinates within a coordinate system where the top-left corner serves as the origin point (0,0). The position is calculated relative to a specified Target container or the page body if no target is defined.

X-axis positioning options:
* Named positions: left, center, right
* Offset values: Numeric values in pixels (e.g., "100px", "50")

Y-axis positioning options:
* Named positions: top, center, bottom
* Offset values: Numeric values in pixels (e.g., "100px", "50")

When using offset values, positive numbers move the dialog away from the top-left origin, while the dialog remains constrained within the target container boundaries.

```cshtml

@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Buttons

<div id="target">
    <div>
        <SfButton Content="Open Dialog" @onclick="@OpenDialog"></SfButton>
    </div>
    <SfDialog ID="defaultDialog" Target="#target" Width="445px" ShowCloseIcon="true" @bind-Visible="@Visibility" Header="Dialog Position" Content="Dialog positioned on top and Right">
        <DialogPositionData X="right" Y="top"></DialogPositionData>
    </SfDialog>
</div>

<style>
    #target {
        height: 500px;
    }
</style>

@code {
    private bool Visibility { get; set; } = false;

    private void OpenDialog()
    {
        this.Visibility = true;
    }
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VjhStvikfNHgUxWv?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Dialog with Dialog Position Data](./images/blazor-dialog-position-data.gif)" %}

## RefreshPositionAsync Method

The [RefreshPositionAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfDialog.html#Syncfusion_Blazor_Popups_SfDialog_RefreshPositionAsync) method programmatically recalculates and updates the dialog's position. This method is particularly useful when the dialog's positioning properties are modified dynamically or when the target container's dimensions change, ensuring the dialog maintains proper positioning relative to its container.

```cshtml

@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Buttons

<div id="target">
    <div>
        <SfButton Content="Open Dialog" @onclick="@OpenDialog"></SfButton>
    </div>
    <SfDialog @ref="@DialogObj" ID="defaultDialog" Target="#target" Width="445px" ShowCloseIcon="true" @bind-Visible="@Visibility" Header="Dialog Position">
        <DialogTemplates>
            <Content>
                <SfButton Content="Change Dialog Position to Bottom Right" @onclick="@ChangePosition"></SfButton>
            </Content>
        </DialogTemplates>
        <DialogPositionData X="@XPosition" Y="@YPosition"></DialogPositionData>
    </SfDialog>
</div>

<style>
    #target {
    height: 500px;
    }
</style>

@code {
    private SfDialog DialogObj;
    private string XPosition = "left";
    private string YPosition = "top";
    private bool Visibility { get; set; } = false;

    private void OpenDialog()
    {
        this.Visibility = true;
    }

    private async void ChangePosition()
    {
        XPosition = "right";
        YPosition = "bottom";
        await DialogObj.RefreshPositionAsync();
    }
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXVoDviafDQdSdeA?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Dialog position with RefreshPositionAsync method](./images/blazor-dialog-position-refresh-method.gif)" %}

## Position the Blazor Dialog in center of the page on scrolling

By default, when scrolling the page or container, the Dialog scrolls along with the content. To display the Dialog in a fixed position that remains stationary during scrolling, the following implementation uses the `e-fixed` CSS class applied through the `CssClass` property. This approach ensures the dialog maintains its position relative to the viewport rather than the scrollable content.

```cshtml

@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Buttons

<div id="targetContainer" style="height: 900px;">
    <SfButton @onclick='@OnClicked'>Open Dialog</SfButton>
    <hr />
    <b>JavaScript:</b><br />
    JavaScript is a high-level, dynamic, untyped, and interpreted programming language. It has been standardized in the ECMAScript
    language specification. Alongside HTML and CSS, it is one of the three essential technologies of World Wide Web
    content production; the majority of websites employ it and it is supported by all modern Web browsers without
    plug-ins. JavaScript is prototype-based with first-class functions, making it a multi-paradigm language, supporting
    object - oriented , imperative, and functional programming styles.
    <br /><br /><br />
    <b>MVC:</b><br />
    Model–view–controller (MVC) is a software architecture pattern which separates the representation of information from the user's interaction with it. The model consists of application data, business rules, logic, and functions. A view can be any output representation of data, such as a chart or a diagram. Multiple views of the same data are possible, such as a bar chart for management and a tabular view for accountants. The controller mediates input, converting it to commands for the model or view. The central ideas behind MVC are code reusability and in addition to dividing the application into three kinds of components, the MVC design defines the interactions between them.
    A controller can send commands to its associated view to change the view's presentation of the model (e.g., by scrolling through a document). It can also send commands to the model to update the model's state (e.g., editing a document).
    A model notifies its associated views and controllers when there has been a change in its state. This notification allows the views to produce updated output, and the controllers to change the available set of commands. A passive implementation of MVC omits these notifications, because the application does not require them or the software platform does not support them.
    A view requests from the model the information that it needs to generate an output representation to the user.
</div>

<SfDialog Width="250px" CssClass="e-fixed" Target="#targetContainer" @bind-Visible="@Visibility" Header="Dialog" Content="Dialog position fixed while scrolling" ShowCloseIcon="true">
    <DialogPositionData X="center" Y="top"></DialogPositionData>
</SfDialog>

<style>
    body {
        overflow-y: scroll;
    }

    .e-fixed {
        position: fixed;
    }
</style>

@code {
    private string DialogClass { get; set; }
    private bool Visibility { get; set; } = false;

    private void OnClicked()
    {
        Visibility = true;
    }
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXVoXlMEpViDbZCj?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Dialog position center with scrollable area](./images/blazor-dialog-position-center-scrollable.gif)" %}

## See also

* [Positioning in Blazor Dialog Component](https://blazor.syncfusion.com/demos/dialog/positioning)
