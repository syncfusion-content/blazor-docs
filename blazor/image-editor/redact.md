
```cshtml
@using Syncfusion.Blazor.ImageEditor
@using Syncfusion.Blazor.Buttons

<div style="padding-bottom: 15px">
    <SfButton OnClick="addRedact">Add Redact</SfButton>
    <SfButton OnClick="updateRedact">Update Redact</SfButton>
    <SfButton OnClick="selectRedact">Select Redact</SfButton>
    <SfButton OnClick="deleteRedact">Delete Redact</SfButton>
</div>

<SfImageEditor @ref="ImageEditor" Toolbar="customToolbarItem" Height="400">
<ImageEditorEvents Created="OpenAsync"></ImageEditorEvents>
</SfImageEditor>
@code {
    private SfImageEditor ImageEditor;
    private List<ImageEditorToolbarItemModel> customToolbarItem = new List<ImageEditorToolbarItemModel>() { };
    private async void OpenAsync()
    {
        await ImageEditor.OpenAsync("nature.png");
    }
    private async void addRedact()
    {
        ImageDimension Dimension = await ImageEditor.GetImageDimensionAsync();
        await ImageEditor.DrawRedactAsync(RedactType.Blur, Dimension.X.Value + 100, Dimension.Y.Value + 100, 200, 300);
    }
    private async void updateRedact()
    {
        RedactSettings[] redacts = await ImageEditor.GetRedactsAsync();
        if (redacts.Length > 0) {
            redacts[redacts.Length - 1].BlurIntensity = 100;
           await  ImageEditor.UpdateRedactAsync(redacts[redacts.Length - 1]);
        }
    }
    private async void selectRedact()
    {
        RedactSettings[] redacts = await ImageEditor.GetRedactsAsync();
        if (redacts.Length > 0) {
            await ImageEditor.SelectRedactAsync(redacts[redacts.Length - 1].ID);
        }
    }
    private async void deleteRedact()
    {
        RedactSettings[] redacts = await ImageEditor.GetRedactsAsync();
        if (redacts.Length > 0) {
            await ImageEditor.DeleteRedactAsync(redacts[redacts.Length - 1].ID);
        }
    }
}
```