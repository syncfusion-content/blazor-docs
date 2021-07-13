---
layout: post
title: How to Name And Value In Form Submit in Blazor Radio Button Component | Syncfusion
description: Checkout and learn about Name And Value In Form Submit in Blazor Radio Button component of Syncfusion, and more details.
platform: Blazor
control: Radio Button
documentation: ug
---

# Name and Value in form submit

The name attribute of the RadioButton is used to group RadioButton. When the RadioButton are grouped in form, the checked items value attribute
will be post to server on form submit that can be retrieved through the name. The disabled RadioButton
value will not be sent to the server on form submit.

In the following code snippet, Credit and Debit card is in checked state.
Now, the value that is in checked state will be sent on form submit.

`Index.razor`

```csharp

<form>
    <ul>
        <li>
            <EjsRadioButton ID="radio1" Value="credit" Label="Credit/Debit Card" Name="payment" Checked="true"></EjsRadioButton>
        </li>
        <li>
            <EjsRadioButton ID="radio2" Value="netbanking" Label="Net Banking" Name="payment"></EjsRadioButton>
        </li>
        <li>
            <EjsRadioButton ID="radio3" Value="cash" Label="Cash on Delivery" Name="payment"></EjsRadioButton>
        </li>
        <li>
            <EjsRadioButton ID="radio4" Value="others" Label="Others" Name="payment"></EjsRadioButton>
        </li>
        <li>
            <EjsButton ID="primarybtn" Content="Submit" IsPrimary="true"></EjsButton>
        </li>
    </ul>
</form>

  ```

  `_Host.cshtml`

   ```html

   <style>
    .e-radio-wrapper {
        margin-top: 18px;
    }

    button {
        margin: 20px 0 0 5px;
    }

    li {
        list-style: none;
    }
</style>

  ```