---
layout: post
title: Style and appearance in Blazor TextArea Component | Syncfusion
description: Learn here all about Style and appearance of the Syncfusion Blazor Textarea component and much more.
platform: Blazor
control: TextArea
documentation: ug
---

# Sizing in Blazor TextArea Component

The size of the TextArea can be adjusted by applying the following classes:

| Property  | Description |
| -- | -- |
| Small  | Add the `e-small` class to the input element or its container to render a smaller-sized TextArea. |
| Bigger | Add the `e-bigger` class to the input element or its container to render a larger-sized TextArea. |

Applying these classes helps align the TextArea with the overall density and visual scale of the application’s design.

{% tabs %}
{% highlight razor tabtitle="Razor"  %}

<div id='container'>
    <div class='wrap'>
        <div id="input-container">
            <h4> Small Size </h4>
            <div class="e-small">
                <SfTextArea Placeholder="Enter your comments"></SfTextArea>
            </div>
            <h4> Bigger Size </h4>
            <div class="e-bigger">
                <SfTextArea Placeholder="Enter your comments"></SfTextArea>
            </div>
        </div>
    </div>
</div>

{% endhighlight %}
{% highlight cshtml tabtitle="Css"  %}

#loader {
  color: #008cff;
  font-family: 'Helvetica Neue','calibiri';
  font-size: 14px;
  height: 40px;
  left: 45%;
  position: absolute;
  top: 45%;
  width: 30%;
}

.wrap {
  box-sizing: border-box;
  margin: 0 auto;
  padding: 20px 10px;
  width: 340px;
}

.e-input-group-icon:before {
  font-family: e-icons;
}

#input-container .e-input-group { /* csslint allow: adjoining-classes */
  margin: 30px 0;
}

#input-container .e-float-input { /* csslint allow: adjoining-classes */
  margin: 30px 0;
}

{% endhighlight %}
{% endtabs %}

![Blazor TextArea with Sizing](./images/blazor-textarea-sizing.png)

## Filled and outline mode

The Filled and Outline modes can be enabled in the TextArea component by adding the `e-outline` or `e-filled` class to the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextArea.html#Syncfusion_Blazor_Inputs_SfTextArea_CssClass) API.
By adding these classes, users can choose between a filled or outline appearance for the TextArea control, aligning with the design aesthetics of their application. Please find the demo link [here](https://blazor.syncfusion.com/demos/textarea/default-functionalities?theme=material3).

{% tabs %}
{% highlight razor %}

<SfTextArea Placeholder='Enter your comments' CssClass= "e-filled" ></SfTextArea>
<SfTextArea Placeholder='Enter your comments' CssClass= "e-outline" ></SfTextArea>

{% endhighlight %}
{% endtabs %}

>Note: Filled and Outline appearances are available only with the Material and Material3 themes.

## Custom styling with CssClass property

The `CssClass` property provides a way to apply custom CSS classes to the TextArea container, enabling customization of color, padding, margins, borders, and other styles to meet design requirements.

By applying custom classes, the component’s appearance can be tailored while preserving built-in theme behavior.

{% tabs %}
{% highlight razor %}

<SfTextArea Placeholder='Enter your comments' CssClass="custom-textarea" ></SfTextArea>

{% endhighlight %}
{% endtabs %}

## Setting the disabled state

Disable the TextArea by using the [Disabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextArea.html#Syncfusion_Blazor_Inputs_SfTextArea_Disabled) property. When set to `true`, the TextArea becomes disabled, preventing user interaction. Please find the demo link [here](https://blazor.syncfusion.com/demos/textarea/api?theme=fluent).

{% tabs %}
{% highlight razor %}

<SfTextArea Placeholder='Enter your comments' Disabled="true" ></SfTextArea>

{% endhighlight %}
{% endtabs %}


## Set the ReadOnly property

To make the TextArea read-only , you can use the [ReadOnly](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextArea.html#Syncfusion_Blazor_Inputs_SfTextArea_Readonly) property. When set to `true`, it prevents users from editing the content of the TextArea. Please find the demo link [here](https://blazor.syncfusion.com/demos/textarea/api?theme=fluent).

{% tabs %}
{% highlight razor %}

<SfTextArea Placeholder='Enter your comments' ReadOnly="true" ></SfTextArea>

{% endhighlight %}
{% endtabs %}


## Set the rounded corner

Render the TextArea with rounded corners by adding the `e-corner` class to the input’s parent element. This style applies to the boxed input wrapper.

>This rounded corner is visible only in the box model input component.

{% tabs %}
{% highlight razor %}

<SfTextArea Placeholder='Enter your comments'  CssClass="e-corner"></SfTextArea>

{% endhighlight %}
{% highlight cshtml tabtitle="Css"  %}

.e-input-group.e-corner {
    border-radius: 4px;
}

{% endhighlight %}
{% endtabs %}

![Blazor TextArea with Rounded Corner](./images/blazor-textarea-rounded-corner.png)

## Static Clear Button

To display a static clear button in the TextArea component, you can add the `e-static-clear` class to the `CssClass` property. This class ensures that the clear button remains visible at all times, providing users with the ability to easily clear the TextArea content without needing to focus on the control. Please find the demo link [here](https://blazor.syncfusion.com/demos/textarea/api?theme=fluent).

{% tabs %}
{% highlight razor %}

<SfTextArea Placeholder='Enter your comments' CssClass="e-static-clear" ShowClearButton="true" ></SfTextArea>

{% endhighlight %}
{% endtabs %}

## Customize the TextArea background color and text color

Customize background color, text color, and border color by overriding the default wrapper styles. Target the appropriate wrapper classes to ensure consistent appearance across themes.

{% tabs %}
{% highlight razor tabtitle="Razor"  %}

<div id='container'>
    <div class='wrap'>
        <div id="input-container">
            <SfTextArea Placeholder="Enter your comments" ></SfTextArea>
        </div>
    </div>
</div>

{% endhighlight %}
{% highlight cshtml tabtitle="Css"  %}

#loader {
  color: #008cff;
  font-family: 'Helvetica Neue','calibiri';
  font-size: 14px;
  height: 40px;
  left: 45%;
  position: absolute;
  top: 45%;
  width: 30%;
}

.wrap {
  box-sizing: border-box;
  margin: 0 auto;
  padding: 20px 10px;
  width: 340px;
}

/* To change the background-color and text-color for textarea */ 
.e-input-group,
.e-input-group.e-multi-line-input { /* csslint allow: adjoining-classes */
  background : lightgray;
  color: green;
}

/* To change the border-color of the textarea */ 
.e-input-group:not(.e-success):not(.e-warning):not(.e-error):not(.e-float-icon-left),
.e-input-group:hover:not(.e-success):not(.e-warning):not(.e-error):not(.e-float-icon-left) { /* csslint allow: adjoining-classes */
  border-color: #0800ff;
}

{% endhighlight %}
{% endtabs %}

## Change the floating label color

You can change the floating label color of the TextArea for both `success` and `warning` validation states by applying the following CSS styles. Please find the demo link [here](https://blazor.syncfusion.com/demos/textarea/default-functionalities?theme=fluent).

```css

    /* For Success state */
    .e-float-input.e-success textarea ~ label.e-float-text,
    .e-float-input.e-success textarea:focus ~ label.e-float-text,
    .e-float-input.e-success textarea:valid ~ label.e-float-text {
      color: #22b24b;
    }

    /* For Warning state */
    .e-float-input.e-warning textarea ~ label.e-float-text,
    .e-float-input.e-warning textarea:focus ~ label.e-float-text,
    .e-float-input.e-warning textarea:valid ~ label.e-float-text {
      color: #ffca1c;
    }

```

{% tabs %}
{% highlight razor tabtitle="Razor"  %}
<div id='container'>
    <div class='wrap'>
        <div id="input-container">
            <div>
                <SfTextArea id="default1" Placeholder="Success" CssClass="e-success" FloatLabelType="@FloatLabelType.Auto"></SfTextArea>
            </div>
            <div>
                <SfTextArea id="default2" Placeholder ="Warning" CssClass="e-warning" FloatLabelType="@FloatLabelType.Auto"></SfTextArea>
            </div>
        </div>
    </div>
</div>

{% endhighlight %}
{% highlight cshtml tabtitle="Css"  %}

#loader {
  color: #008cff;
  font-family: 'Helvetica Neue','calibiri';
  font-size: 14px;
  height: 40px;
  left: 45%;
  position: absolute;
  top: 45%;
  width: 30%;
}

.wrap {
  box-sizing: border-box;
  margin: 0 auto;
  padding: 20px 10px;
  width: 340px;
}

/* For Success state */
#input-container .e-float-input.e-success textarea ~ label.e-float-text,
#input-container .e-float-input.e-success textarea:focus ~ label.e-float-text,
#input-container .e-float-input.e-success textarea:valid ~ label.e-float-text {
    color: #22b24b;
}

/* For Warning state */
#input-container .e-float-input.e-warning textarea ~ label.e-float-text,
#input-container .e-float-input.e-warning textarea:focus ~ label.e-float-text,
#input-container .e-float-input.e-warning textarea:valid ~ label.e-float-text {
    color: red;
}

{% endhighlight %}
{% endtabs %}

## Adding mandatory asterisk to placeholder

Add a mandatory asterisk (*) to the floating label using CSS to append the symbol after the label text.

```css

/* To add asterick to float label in textarea */ 
.e-float-input.e-control-wrapper .e-float-text::after {
  content: '*'; /* Add asterisk after the placeholder */
  color: red; /* Customize asterisk color */
}

```

{% tabs %}
{% highlight razor tabtitle="Razor"  %}
<div id='container'>
    <div class='wrap'>
        <div id="input-container">
            <SfTextArea id="default" Placeholder="Enter your comments" FloatLabelType="@FloatLabelType.Auto"></SfTextArea>
        </div>
    </div>
</div>

{% endhighlight %}
{% highlight cshtml tabtitle="Css"  %}

#loader {
  color: #008cff;
  font-family: 'Helvetica Neue','calibiri';
  font-size: 14px;
  height: 40px;
  left: 45%;
  position: absolute;
  top: 45%;
  width: 30%;
}

.wrap {
  box-sizing: border-box;
  margin: 0 auto;
  padding: 20px 10px;
  width: 340px;
}

/* To add asterick to float label in textarea */ 
.e-float-input.e-control-wrapper .e-float-text::after {
  content: '*';
  color: red;
}

{% endhighlight %}
{% endtabs %}

![Blazor TextArea with Sizing](./images/blazor-textarea-asterisk.png)