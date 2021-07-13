# Enable ripple

The following example illustrates how to enable ripple for ButtonGroup.

`Index.razor`

```csharp
@using Syncfusion.EJ2.RazorComponents;
@using Microsoft.JSInterop;

  <div class='e-btn-group'>
    <EjsButton ID="html" Content="HTML"></EjsButton>
    <EjsButton ID="css" Content="CSS"></EjsButton>
    <EjsButton ID="javascript" Content="Javascript"></EjsButton>
</div>

@functions {

    [Inject]
    protected IJSRuntime JSRuntime { get; set; }

    protected override void OnAfterRender()
    {
        this.JSRuntime.Ejs().EnableRipple(true);
    }
}
  ```
