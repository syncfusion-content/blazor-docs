# Disable

## Particular button

To disable a particular button in a ButtonGroup, `disabled` attribute should be added to corresponding button element.

## Whole ButtonGroup

To disable whole ButtonGroup, `disabled` attribute should be added to all the button elements.

The following example illustrates how to disable the particular and the whole ButtonGroup.

`Index.razor`

```csharp
<div class='e-btn-group'>
    <EjsButton ID="html" Content="HTML"></EjsButton>
    <EjsButton ID="css" Content="CSS" disabled="true"></EjsButton>
    <EjsButton ID="javascript" Content="Javascript"></EjsButton>
</div>

<div class='e-btn-group'>
    <EjsButton ID="html_1" Content="HTML" disabled="true"></EjsButton>
    <EjsButton ID="css_1" Content="CSS" disabled="true"></EjsButton>
    <EjsButton ID="javascript_1" Content="Javascript" disabled="true"></EjsButton>
</div>

  ```

> To disable radio/checkbox type ButtonGroup, the `disabled` attribute should be added to the particular input element.