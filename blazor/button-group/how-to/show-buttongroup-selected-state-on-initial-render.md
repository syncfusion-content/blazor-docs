# Show ButtonGroup selected state on initial render

To show selected state on initial render, `checked` property should to added to the corresponding
input element.

The following example illustrates how to show selected state on initial render.

`Index.razor`

```csharp

<div class='e-btn-group'>
    <input type="checkbox" id="checkbold" name="font" value="bold" checked/>
    <label class="e-btn" for="checkbold">Bold</label>
    <input type="checkbox" id="checkitalic" name="font" value="italic" />
    <label class="e-btn" for="checkitalic">Italic</label>
    <input type="checkbox" id="checkline" name="font" value="underline"/>
    <label class="e-btn" for="checkline">Underline</label>
</div>

  ```