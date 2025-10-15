---
layout: post
title: Accessibility in Blazor Dialog Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor Dialog component and much more.
platform: Blazor
control: Dialog
documentation: ug
---

# Accessibility in Blazor Dialog Component

The [Blazor Dialog](https://www.syncfusion.com/blazor-components/blazor-modal-dialog) provides complete WAI-ARIA accessibility support, enabling compatibility with screen readers and other assistive technologies. This component is designed in accordance with guidance from the [WAI-ARIA Authoring Practices for modal dialogs](https://www.w3.org/WAI/ARIA/apg/#dialog_modal).

The Blazor Dialog component follows accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/), and [WAI-ARIA roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor Dialog component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Section 508 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Right-To-Left Support](../common/accessibility#right-to-left-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Color Contrast](../common/accessibility#color-contrast) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Mobile Device Support](../common/accessibility#mobile-device-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Keyboard Navigation Support](../common/accessibility#keyboard-navigation-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Axe-core Accessibility Validation](../common/accessibility#ensuring-accessibility) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>
<div><img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> - All features of the component meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> - Some features of the component do not meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/not-supported.png" alt="No"> - The component does not meet the requirement.</div>

## WAI-ARIA attributes

The Blazor Dialog component uses the `Dialog` role and following ARIA properties to its element based on its state.

| **Property** | **Functionalities** |
| --- | --- |
| aria-describedby | Identifies the element that provides a description for the dialog content to assistive technologies. |
| aria-labelledby | Identifies the element that provides the dialog title announced by assistive technologies. |
| aria-modal | Indicates whether the dialog is modal. For a modal dialog, the value is true; for a non-modal dialog, the value is false. |

## Keyboard interaction

Keyboard interaction for the Blazor Dialog component aligns with the [WAI-ARIA Practices](https://www.w3.org/WAI/ARIA/apg/#dialog_modal) for dialogs. Users can use the following shortcut keys to interact with the dialog. For modal dialogs, keyboard focus is trapped within the dialog while it is open, and the initial focus moves to the first focusable element (or a designated element).

<!-- markdownlint-disable MD033 -->
<table>
<tr>
<td><b>Windows</b></td>
<td><b>Mac</b</td>
<td><b>Actions</b></td></tr>
<tr>
<td>
<kbd>Esc</kbd></td>
<td><kbd>Esc</kbd></td>
<td>Closes the Dialog. This functionality can be controlled by using <b>closeOnEscape</b></td></tr>
<tr>
<td>
<kbd>Enter</kbd></td>
<td><kbd>Enter</kbd></td>
<td>When the Dialog button or any input (except text area) is in focus state, when
pressing the Enter key, the click event associated with the primary button or button will
trigger. Enter key does not work when the Dialog content contains any text area with
initial focus</td></tr>
<tr>
<td>
<kbd>Ctrl</kbd> + <kbd>Enter</kbd></td>
<td><kbd>⌘</kbd> + <kbd>Enter</kbd></td>
<td>When the Dialog content contains text area and it is in focus state, press the Ctrl + Enter
key to call the click event
function associated with primary button</td></tr>
<tr>
<td>
<kbd>Tab</kbd></td>
<td><kbd>Tab</kbd></td>
<td>
Focus will be changed within the Dialog elements</td></tr>
<tr>
<td>
<kbd>Shift</kbd> + <kbd>Tab</kbd></td>
<td><kbd>⇧</kbd> + <kbd>Tab</kbd></td>
<td>
The Focus will be changed previous focusable element within the Dialog elements. When focusing a
first focusable element in the Dialog, then press the shift + tab key, it will change the focus
to last focusable element</td></tr>
</table>

```cshtml

@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Buttons

<SfButton @onclick="@OpenDialog">Open Dialog</SfButton>

<SfDialog Width="400px" Height="358px" ShowCloseIcon="true" @bind-Visible="@IsVisible">
    <DialogTemplates>
        <Header>
            <div>Feedback</div>
        </Header>
        <Content>
            <form>
                <div class='form-group'>
                    <label for='email'>Email:</label>
                    <input type='email' class='form-control' id='email'>
                </div>
                <div class='form-group'></div>
                <div class='form-group'>
                    <label for='comment'>Comments:</label>
                    <textarea style='resize: none;' class='form-control' rows='4' id='comment'></textarea>
                </div>
            </form>
        </Content>
    </DialogTemplates>
    <DialogButtons>
        <DialogButton Content="Submit" IsPrimary="true" OnClick="@CloseDialog" />
    </DialogButtons>
</SfDialog>

@code {
    private bool IsVisible { get; set; } = true;

    private void OpenDialog()
    {
        this.IsVisible = true;
    }

    private void CloseDialog()
    {
        this.IsVisible = false;
    }
}

```



![Accessibility in Blazor Dialog](./images/blazor-dialog-accessibility.png)

## See also

* [Show dialog with fullscreen](./how-to/show-dialog-with-fullscreen)

## Ensuring accessibility

The Blazor Dialog component’s accessibility is validated using the [axe-core](https://www.npmjs.com/package/axe-core) tool during automated testing.

The accessibility compliance of the Dialog component is demonstrated in the following sample. Open the [Dialog accessibility sample](https://blazor.syncfusion.com/accessibility/dialog) in a new window to evaluate the component with accessibility tools.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> components](../common/accessibility)