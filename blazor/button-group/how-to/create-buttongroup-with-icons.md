# Create ButtonGroup with icons

ButtonGroup with icons can be achieved by `IconCss` property of the Button component.

The following example illustrates how to create ButtonGroup with icons.

`Index.razor`

```csharp

<div class='e-btn-group'>
    <EjsButton ID="left" Content="Left" IconCss="e-icons e-left-icon"></EjsButton>
    <EjsButton ID="mIddle" Content="Center" IconCss="e-icons e-mIddle-icon"></EjsButton>
    <EjsButton ID="right" Content="Right" IconCss="e-icons e-right-icon"></EjsButton>
</div>

  ```

  `_Host.cshtml`

   ```html

     <style>
        .e-btn-group {
            margin: 25px 5px 20px 20px;
        }

        .e-left-icon::before {
            content: '\e33a';
        }

        .e-right-icon::before {
            content: '\e34d';
        }

        .e-middle-icon::before {
            content: '\e35e';
        }
    </style>

  ```  
