---
layout: post
title: Groups in Blazor TextBox Component | Syncfusion
description: Checkout and learn here all about groups in Syncfusion Blazor TextBox component and much more details.
platform: Blazor
control: TextBox
documentation: ug
---

# Groups in Blazor TextBox Component

The following section describes how to configure the TextBox component with icons, floating labels, clear buttons, and multiline input by combining the relevant APIs.

**TextBox**

Create a basic TextBox component.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextBox Placeholder="Enter your name"></SfTextBox>
```

**Floating label**

Create a floating label TextBox by enabling the [FloatLabelType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextBox.html#Syncfusion_Blazor_Inputs_SfTextBox_FloatLabelType) API.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextBox Placeholder="Enter your name" FloatLabelType="@FloatLabelType.Auto"></SfTextBox>
```

Refer to the following sections to add the icons to the TextBox.

## TextBox with icon and floating label

Create a TextBox with icons so users can display the icon on either side of the input. Use the AddIconAsync method to append or prepend the icon. The argument value (`append` or `prepend`) determines whether the icon appears as a suffix or prefix. When invoking AddIconAsync inside lifecycle events, await the method within an asynchronous handler.

```cshtml
@using Syncfusion.Blazor.Inputs

<div id="wrapper">
    <label>TextBox with icon</label>
    <SfTextBox @ref="TextBoxDateObj" Placeholder="Enter date" Created="@OnCreateDate"></SfTextBox>
    <SfTextBox @ref="TextBoxSearchObj" Placeholder="Search here" Created="@OnCreateSearch"></SfTextBox>

    <label>Floating TextBox with icon</label>
    <SfTextBox @ref="FloatTextBoxDateObj" Placeholder="Enter date" FloatLabelType="@FloatLabelType.Auto" Created="@OnFloatCreateDate"></SfTextBox>
    <SfTextBox @ref="FloatTextBoxSearchObj" Placeholder="Search here" FloatLabelType="@FloatLabelType.Auto" Created="@OnFloatCreateSearch"></SfTextBox>
</div>

@code{
    SfTextBox TextBoxDateObj;
    SfTextBox TextBoxSearchObj;
    SfTextBox FloatTextBoxDateObj;
    SfTextBox FloatTextBoxSearchObj;
    public void OnCreateDate()
    {
        this.TextBoxDateObj.AddIconAsync("append", "e-date-icon");
    }
    public void OnCreateSearch()
    {
        this.TextBoxSearchObj.AddIconAsync("prepand", "e-search");
    }
    public void OnFloatCreateDate()
    {
        this.FloatTextBoxDateObj.AddIconAsync("append", "e-date-icon");
    }
    public void OnFloatCreateSearch()
    {
        this.FloatTextBoxSearchObj.AddIconAsync("prepand", "e-search");
    }
}
<style>
    .e-search::before {
        content: '\e993';
        font-family: e-icons;
    }
    #wrapper {
        width: 30%;
    }
</style>
```

![Blazor TextBox with icon and floating label](./images/blazor-textbox-float-label-and-icons.png)

### Binding events to icons

Bind events to icons by passing event attributes as a parameter to the AddIconAsync method. Multiple event handlers can be associated with the icon by providing a dictionary of event names and callbacks. Ensure the callbacks are created with EventCallback to maintain component lifecycle integrity.

```cshtml
@using Syncfusion.Blazor.Inputs

<label>Single Event</label>
<SfTextBox @ref="@TextBoxSearchObj" Created="@OnCreateSearch"></SfTextBox>

<label>Multiple Events</label>
<SfTextBox @ref="@TextBoxDateObj" Created="@OnCreateDate"></SfTextBox>

@code {

	SfTextBox TextBoxSearchObj;
	SfTextBox TextBoxDateObj;

	public async Task OnCreateSearch()
	{
		// Event creation with event handler
		var Click = EventCallback.Factory.Create<MouseEventArgs>(this, SearchClick);
		await TextBoxSearchObj.AddIcon("append", "e-search-icon", new Dictionary<string, object>() { { "onclick", Click } });
	}

	public void SearchClick()
	{
		// Icon Click event triggered
	}

	public async Task OnCreateDate()
	{
		// Event creation with event handler
		var MouseDown = EventCallback.Factory.Create<MouseEventArgs>(this, DateMouseDown);
		var MouseUp = EventCallback.Factory.Create<MouseEventArgs>(this, DateMouseUp);
		await TextBoxDateObj.AddIcon("prepend", "e-date-icon", new Dictionary<string, object>() { { "onmouseup", MouseUp }, { "onmousedown", MouseDown } });
	}

	public void DateMouseDown()
	{
		// Icon mouse down event triggered
	}
	public void DateMouseUp()
	{
		// Icon mouse up event triggered
	}

}

<style>
	.e-search-icon::before {
		content: '\e724';
		font-family: e-icons;
	}

    .e-date-icon::before {
		content: '\e901';
		font-family: e-icons;
	}
</style>
```

## TextBox with clear button and floating label

Add a clear button to remove the current value from the TextBox. The button is visible only when the input contains text. Enable the [ShowClearButton](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextBox.html#Syncfusion_Blazor_Inputs_SfTextBox_ShowClearButton) API to display the clear icon, and combine it with FloatLabelType for floating label support.

```cshtml
@using Syncfusion.Blazor.Inputs

<label> TextBox with clear button </label>
<SfTextBox Placeholder="FirstName" ShowClearButton=true></SfTextBox>
<label> Floating TextBox with clear button </label>
<SfTextBox Placeholder="FirstName" ShowClearButton=true FloatLabelType="@FloatLabelType.Auto"></SfTextBox>
```

![Blazor TextBox with clear button and floating label](./images/blazor-textbox-clear-icon.png)

## Multiline input with floating label

Enable [Multiline](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextBox.html#Syncfusion_Blazor_Inputs_SfTextBox_Multiline) to transform the TextBox into a multi-line editor. Combine Multiline with FloatLabelType to keep the floating label behavior for longer text input.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextBox Placeholder="Enter text" Multiline=true FloatLabelType="@FloatLabelType.Auto"></SfTextBox>
```

![Blazor multiline TextBox with floating label](./images/blazor-multiline-textbox-with-floating-label.png)