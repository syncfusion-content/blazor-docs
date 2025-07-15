---
layout: post
title: Suggestion Customization in Blazor Smart PdfViewer | Syncfusion
description: Checkout and learn here all about Suggestion Customization in Syncfusion Blazor Smart PdfViewer component and more.
platform: Blazor
control: Smart PdfViewer
documentation: ug
---

# Customizing API

The Syncfusion <sup style="font-size:70%">&reg;</sup> Blazor Smart PdfViewer allows API support using the `AssistViewSettings`. The following API's and attributtes are belongs to `AssistViewSettings`
```cshtml
 <SfSmartPdfViewer>
  <AssistViewSettings />
</SfSmartPdfViewer>
```

The `ShowPromptSuggestions` attribute in `AssistViewSettings` allows you to indicating whether prompt suggestions are shown.

* If `ShowPromptSuggestions` is `true`, suggestions will be  displayed

```cshtml
 <SfSmartPdfViewer>
 <AssistViewSettings ShowPromptSuggestions="true" />
 </SfSmartPdfViewer>
```

The `prompt` attribute in `AssistViewSettings` allows you to gets or sets the current prompt text.

```cshtml
 <SfSmartPdfViewer>
  <AssistViewSettings Prompt = "Search this document."/>
 </SfSmartPdfViewer>
```

The `PlaceholderText` attribute in `AssistViewSettings` allows you to gets or sets the placeholder text for the input field.

```cshtml
<SfSmartPdfViewer>
<AssistViewSettings PlaceholderText="Enter your query..." />
</SfSmartPdfViewer>
```

The `BannerTemplate` in  `AssistViewSettings` allows you to gets or sets the template for the banner displayed within the viewer.It is a type of
`RenderFragment` used to customize the banner.

```cshtml
<SfSmartPdfViewer>
<AssistViewSettings>
 <BannerTemplate>
  @{
     <div>Welcome to Smart PDF Viewer!</div>
    }
     </BannerTemplate>
     </AssistViewSettings>
     </SfSmartPdfViewer>
```

The `PromptToolbarTemplate` in `AssistViewSettings` allows you to gets or sets the template for the toolbar that appears within the prompt view of the viewer and It is a type of `RenderFragment` it's used to customize the prompt toolbar UI.

```cshtml
<SfSmartPdfViewer>
<AssistViewSettings PromptToolbarTemplate ="@PromptToolbarTemplate">
</AssistViewSettings>
</SfSmartPdfViewer>
@code {
private RenderFragment PromptToolbarTemplate()
{
return __builder =>
{
<PromptToolbar>
 <PromptToolbarItem IconCss="e-icons e-assist-edit"></PromptToolbarItem>
 <PromptToolbarItem IconCss="e-icons e-assist-copy"></PromptToolbarItem>
 </PromptToolbar>;
  };
 }
}
```
The `ResponseToolbarTemplate` in `AssistViewSettings` allows you to gets or sets the template for the toolbar that appears in the response section of the viewer and It is a type of `RenderFragment` it's used to customize the prompt toolbar UI.

```cshtml
<SfSmartPdfViewer>
<AssistViewSettings ResponseToolbarTemplate="@ResponseToolbarTemplate">
 </AssistViewSettings>
 </SfSmartPdfViewer>
@code {
private RenderFragment ResponseToolbarTemplate()
{
 return __builder =>
 {
  <ResponseToolbar>
  <ResponseToolbarItem IconCss="e-icons e-assist-copy" /> 
   </ResponseToolbar>
    };
    }
  }
```

The `OverviewPageStart` attribute in `AssistViewSettings` allows you to gets or sets the starting page number for the document overview.An integer representing the starting page number, starting from one.This property works in the initial overview alone for better performance.

```cshtml
<SfSmartPdfViewer>
   <AssistViewSettings OverviewPageStart="1"/>
</SfSmartPdfViewer>
```

The `OverviewPageEnd` attribute in `AssistViewSettings` allows you to gets or sets the ending page number for the document overview.An integer representing the ending page number. The default value is 10.This property works in the initial overview alone for better performance.Based on the document text,the AI token limit can be exceeded. 

```cshtml
<SfSmartPdfViewer>
   <AssistViewSettings OverviewPageEnd="10"/>
</SfSmartPdfViewer>
```

The `MinimumTextLength` attribute in `AssistViewSettings` allows you to gets or sets the minimum text length required to activate AI processing.An integer setting the minimum number of characters needed. The dafault value is 100.This property ensures that input text is sufficiently long to enable effective AI processing.

```cshtml
<SfSmartPdfViewer>
    <AssistViewSettings MinimumTextLength="100"/>
</SfSmartPdfViewer>
```

The `GetPrompts()` method in `AssistViewSettings` allows you to gets a value indicating whether the response toolbar icons are shown.

```cshtml
<SfSmartPdfViewer >
<AssistViewSettings @ref="settings"/>
</SfSmartPdfViewer>
  @code {
  private List<AssistViewPrompt> prompts = new List<AssistViewPrompt>();
  
  protected override void OnAfterRender(bool firstRender)
  {
     prompts = settings.GetPrompts();
  }
     }
```

The `PromptChanged` event is used to gets or sets the callback that is triggered when the prompt content is modified by the user.This event allows developers to track user input in real time or take action whenever the prompt changes. 

```cshtml
<SfSmartPdfViewer PromptChanged="@OnPromptChanged">
  </SfSmartPdfViewer>
    @code {
      private void OnPromptChanged(string newPrompt)
      {
         Console.WriteLine($"Prompt changed: {newPrompt}");
        }
      }
```

