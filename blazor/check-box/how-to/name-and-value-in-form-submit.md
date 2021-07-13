# Name and Value in form submit

The name attribute of the CheckBox is used to group Checkboxes. When the Checkboxes are grouped in form, the checked items value attribute
will post to the server on form submit that can be retrieved through the name. The disabled and unchecked CheckBox
value will not be sent to the server on form submit.

In the following code snippet, Cricket and Hockey are in the checked state, Tennis is in disabled state and Basketball is in unchecked state.
Now, the value that is in checked state only be sent on form submit.

`Index.razor`

```csharp

<form>
    <ul>
        <li>
            <EjsCheckBox ID="cbox2" Name="Sport" Value="Cricket" Label="Cricket" Checked="true"></EjsCheckBox>
        </li>
        <li>
            <EjsCheckBox ID="cbox3" Name="Sport" Value="Hockey" Label="Hockey" Checked="true"></EjsCheckBox>
        </li>
        <li>
            <EjsCheckBox ID="cbox4" Name="Sport" Value="Tennis" Label="Tennis"></EjsCheckBox>
        </li>
        <li>
            <EjsCheckBox ID="cbox1" Name="Sport" Value="Basketball" Label="Basketball"></EjsCheckBox>
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
        .e-checkbox-wrapper {
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