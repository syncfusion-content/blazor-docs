---
layout: post
title: Position the Blazor Dialog in center of the page | Syncfusion
description: Learn here all about positioning the Blazor Dialog in center of the page on scrolling and much more.
platform: Blazor
control: Dialog
documentation: ug
---

# Position the Blazor Dialog in center of the page on scrolling

By default, when you scroll the page/container, Dialog will also scroll along with the page/container. To display the Dialog in the same position without scrolling, refer to the following code sample. Here, the `e-fixed` class is added to the Dialog element by using the `CssClass` property to prevent scrolling.

```cshtml

@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Buttons

<div id="targetContainer" style="height: 900px;">
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

<SfDialog Width="250px" CssClass="@DialogClass" Target="#targetContainer">
    <DialogTemplates>
        <Header>Dialog</Header>
        <Content>
            <SfButton @onclick='@OnClicked'>Prevent Dialog Scroll</SfButton>
        </Content>
    </DialogTemplates>
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

    private void OnClicked()
    {
        this.DialogClass = "e-fixed";
    }
}

```