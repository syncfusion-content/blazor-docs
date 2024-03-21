# Customize color picker in ##Blazor## Document editor control 
Document editor provides an options to customize the color picker using [`ColorPickerSettings`]in the document editor settings. The color picker offers customization options for default appearance, by allowing selection between Picker or Palette mode, for font and border colors." 

The following example code illustrates how to Customize the color picker in Document editor container. 

```csharp
@using Syncfusion.Blazor.DocumentEditor
@inject Microsoft.AspNetCore.Components.NavigationManager UriHelper
@inject IJSRuntime JSRuntime;

<SfDocumentEditorContainer @ref="container" Height="590px">
    <DocumentEditorContainerEvents Created="OnCreated" DocumentEditorSettings="settings"></DocumentEditorContainerEvents> 
</SfDocumentEditorContainer> 

@code {
    SfDocumentEditorContainer container; 
    DocumentEditorSettingsModel settings = new DocumentEditorSettingsModel() { ColorPickerSettings = { Mode = ColorPickerMode.Palette , ShowButtons = true , ModeSwitcher = true}};
} 
```

The following table illustrates all the possible properties for the color picker. 
| Property | Behaviour | 

|---|---| 

| Columns | It is used to render the ColorPicker palette with specified columns. Defaults to 10 | 
| Disabled | It is used to enable / disable ColorPicker component. If it is disabled the ColorPicker popup won’t open. Defaults to false | 
| Mode | It is used to render the ColorPicker with the specified mode. Defaults to ‘Picker’ | 
| ModeSwitcher | It is used to show / hide the mode switcher button of ColorPicker component. Defaults to true | 
| ShowButtons | It is used to show / hide the control buttons (apply / cancel) of ColorPicker component. Defaults to true |