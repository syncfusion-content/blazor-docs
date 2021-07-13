# HTML Attribute Support

HTML attribute support is given for button using [`HtmlAttributes`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html) property.

```csharp

@using Syncfusion.Blazor.Buttons

<SfButton Content="@Content" HtmlAttributes="@submit"></SfButton>

@code {
    public string Content = "Submit";
    private Dictionary<string, object> submit = new Dictionary<string, object>()
     {
        { "type", "submit"}
    };
}

```

Output be like

![Button Sample](./../images/html.png)