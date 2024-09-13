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
    SfImageEditor ImageEditor; 
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
        RedactSettings[] redacts = ImageEditor.GetRedactsAsync();
        if (redacts.length > 0) {
            redacts[redacts.length - 1].blurIntensity = 100;
            ImageEditor.UpdateRedactAsync(redacts[redacts.length - 1]);
        }
    }
    private async void selectRedact()
    {
        RedactSettings[] redacts = ImageEditor.GetRedactsAsync();
        if (redacts.length > 0) {
            ImageEditor.SelectRedactAsync(redacts[redacts.length - 1].id);
        }
    }
    private async void deleteRedact()
    {
        RedactSettings[] redacts = ImageEditor.GetRedactsAsync();
        if (redacts.length > 0) {
            ImageEditor.DeleteRedactAsync(redacts[redacts.length - 1].id);
        }
    }
}
```