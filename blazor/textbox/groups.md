---
layout: post
title: Groups in Blazor TextBox Component | Syncfusion
description: Checkout and learn here all about groups in Syncfusion Blazor TextBox component and much more details.
platform: Blazor
control: TextBox
documentation: ug
---

# Groups in Blazor TextBox Component

The following section explains the steps required to create TextBox with `icon` and `floating label`.

**TextBox:**

Create a TextBox component.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextBox Placeholder="Enter your name"></SfTextBox>
```

**Floating label:**

Create a Floating label TextBox using [FloatLabelType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextBox.html#Syncfusion_Blazor_Inputs_SfTextBox_FloatLabelType) API.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextBox Placeholder="Enter your name" FloatLabelType="@FloatLabelType.Auto"></SfTextBox>
```

Refer to the following sections to add the icons to the TextBox.

## With icon and floating label

Create a TextBox with icon and the users can place the icon in either side of the TextBox by using `AddIcon` method append the icon before or after the input. Based on the argument prepend or append, it will act as prefix or suffix icon.

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

![Blazor TextBox with Icon and Floating Label](./images/blazor-textbox-float-label-and-icons.png)

## Binding events to icons

**Add the Icon with single Event in Blazor TextBox Component**

Add the icon to TextBox by `addicon` public method. Using public method we can add the events to the component by adding the third parameter value. 

In the following example, the addicon method is called with single `touchstart` event binding on textbox `e-icon-pan` icon.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextBox @ref="@TouchIcon" Created="@onCreateTouchIcon"></SfTextBox>
@code {
    SfTextBox TouchIcon;
    public async Task onCreateTouchIcon()
	{
        // Event creation with event handler
		var touchStart = EventCallback.Factory.Create<TouchEventArgs>(this, touchIconStart);

        // Touchstart event binding with addicon public method third argument 
		await TouchIcon.AddIcon("prepend", "e-icon-pan", new Dictionary<string, object>() { { "ontouchstart", touchStart } });
	}

    public void touchIconStart()
	{
		// Icon touch start Event triggered
	}
}
```

**Add the Icon with multiple Event in Blazor TextBox Component**

We can add the single icon with multiple event and multiple icons with multiple event support to the textbox component.

In the following example, the addicon method is called with multiple `touchstart`, `mouseover` and `mouseleave` event binding on textbox `e-icon-pan` icon.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextBox @ref="@TouchIcon" Created="@onCreateTouchIcon"></SfTextBox>
@code {
    SfTextBox TouchIcon;
    public async Task onCreateTouchIcon()
	{
        // Event creation with event handler
		var touchStart = EventCallback.Factory.Create<TouchEventArgs>(this, touchIconStart);
        var touchHover = EventCallback.Factory.Create<MouseEventArgs>(this, touchIconMouseHover);
		var touchLeave = EventCallback.Factory.Create<MouseEventArgs>(this, touchIconLeave);\

        // Event binding with addicon public method third argument 
		await TouchIcon.AddIcon("prepend", "e-icon-pan", new Dictionary<string, object>() { { "ontouchstart", touchStart }, { "onmouseover", touchHover }, { "onmouseleave", touchLeave }, });
	}

    public void touchIconStart()
	{
		// Icon touch start Event triggered
	}

    public void touchIconMouseHover()
	{
		// Icon mouse hover Event triggered
	}

	public void touchIconLeave()
	{
		// Icon mouse leave Event triggered
	}
}
```

## With clear button and floating label

The clear button is added to the input for clearing the value given in the TextBox. It is shown only when the input field has a value, otherwise not shown.

The clear button can be added to the TextBox by enabling the [ShowClearButton](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextBox.html#Syncfusion_Blazor_Inputs_SfTextBox_ShowClearButton) API.

```cshtml
@using Syncfusion.Blazor.Inputs

<label> TextBox with clear button </label>
<SfTextBox Placeholder="FirstName" ShowClearButton=true></SfTextBox>
<label> Floating TextBox with clear button </label>
<SfTextBox Placeholder="FirstName" ShowClearButton=true FloatLabelType="@FloatLabelType.Auto"></SfTextBox>
```

![Blazor TextBox with Clear Icon](./images/blazor-textbox-clear-icon.png)

## Multi-line input with floating label

The following example demonstrates how to set [Multiline](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextBox.html#Syncfusion_Blazor_Inputs_SfTextBox_Multiline) in the `TextBox` component with the float label structure.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextBox Placeholder="Enter text" Multiline=true FloatLabelType="@FloatLabelType.Auto"></SfTextBox>
```

![Blazor Multiline TextBox with Floating Label](./images/blazor-multiline-textbox-with-floating-label.png)