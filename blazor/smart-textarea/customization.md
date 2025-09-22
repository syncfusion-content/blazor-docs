---
layout: post
title: Customize Suggestions in Blazor Smart TextArea | Syncfusion
description: Learn how to customize suggestion display in the Syncfusion Blazor Smart TextArea component for enhanced user interaction.
platform: Blazor
control: Smart TextArea
documentation: ug
---

# Customize Suggestions in Blazor Smart TextArea

The Syncfusion Blazor Smart TextArea component provides AI-powered autocompletion for context-aware text input, with customizable suggestion display options. This section explains how to configure the appearance and behavior of suggestions to enhance user experience in applications like issue trackers or customer support systems.

## Configure Suggestion Display

The `ShowSuggestionOnPopup` attribute controls how AI-generated suggestions are presented to users in the Smart TextArea component. Suggestions are based on the `UserRole` and optional `UserPhrases` attributes, which define the context and predefined phrases for autocompletion.

### Pop-up Suggestions

Set `ShowSuggestionOnPopup="true"` to display suggestions in a pop-up window above the text area, ideal for scenarios where users need to select from multiple suggestions without cluttering the input area.

Add the following code to a Razor file (e.g., `~/Pages/Index.razor`):

```razor
@using Syncfusion.Blazor.SmartComponents

<SfSmartTextArea UserRole="@userRole" UserPhrases="@userPhrases" Placeholder="Enter your queries here" @bind-Value="prompt" Width="75%" RowCount="5" ShowSuggestionOnPopup="true">
</SfSmartTextArea>

@code {
    private string? prompt;
    // Defines the context for AI autocompletion
    public string userRole = "Maintainer of an open-source project replying to GitHub issues";
    // Predefined phrases for AI to suggest during typing
    public string[] userPhrases = [
        "Thank you for contacting us.",
        "To investigate, we will need a reproducible example as a public Git repository.",
        "Could you please post a screenshot of the issue?"
    ];
}
```

![Suggestion on Popup](images/smart-textarea-suggestion-popup.gif)
*Alt text: Animation showing pop-up suggestions in the Syncfusion Blazor Smart TextArea component.*

### Inline Suggestions

Set `ShowSuggestionOnPopup="false"` (default) to display suggestions inline within the text area, suitable for seamless text entry where users can accept suggestions by continuing to type or pressing a key (e.g., Tab).

Add the following code to a Razor file (e.g., `~/Pages/Index.razor`):

```razor
@using Syncfusion.Blazor.SmartComponents

<SfSmartTextArea UserRole="@userRole" UserPhrases="@userPhrases" Placeholder="Enter your queries here" @bind-Value="prompt" Width="75%" RowCount="5" ShowSuggestionOnPopup="false">
</SfSmartTextArea>

@code {
    private string? prompt;
    // Defines the context for AI autocompletion
    public string userRole = "Maintainer of an open-source project replying to GitHub issues";
    // Predefined phrases for AI to suggest during typing
    public string[] userPhrases = [
        "Thank you for contacting us.",
        "To investigate, we will need a reproducible example as a public Git repository.",
        "Could you please post a screenshot of the issue?"
    ];
}
```

![Suggestion Inline](images/smart-textarea-suggestion-inline.gif)
*Alt text: Animation showing inline suggestions in the Syncfusion Blazor Smart TextArea component.*

## Test Suggestion Customization

1. Add the Smart TextArea component to your Blazor Web App or Server App as shown above.
2. Run the application using <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS).
3. Type phrases like "Thank you" or "To investigate" to trigger suggestions.
4. For pop-up mode, verify that suggestions appear in a pop-up window and can be selected. For inline mode, confirm that suggestions appear in the text area and can be accepted by typing or keypress.

## Troubleshooting

If suggestions do not appear, try the following:
- **AI Configuration Errors**: Verify that the API key, endpoint, and model name are correctly configured in **Program.cs**. Check for typos or invalid credentials.
- **Missing Dependencies**: Ensure all required NuGet packages (`Syncfusion.Blazor.SmartComponents`, `Microsoft.Extensions.AI`, etc.) are installed. Run `dotnet restore` to resolve dependencies.
- **Incorrect Setup**: Confirm that the Syncfusion Blazor service is registered in **Program.cs** and the stylesheet/script references are added in **App.razor**.

## See Also

- [Getting Started with Syncfusion Blazor Smart TextArea in Blazor Web App](https://blazor.syncfusion.com/documentation/smart-textarea/getting-started-webapp)
- [Getting Started with Syncfusion Blazor Smart TextArea in Blazor Server App](https://blazor.syncfusion.com/documentation/smart-textarea/getting-started)
- [Syncfusion Blazor Smart TextArea API Documentation](https://blazor.syncfusion.com/documentation/api/smart-textarea)
- [Syncfusion Blazor Smart Components Release Notes](https://blazor.syncfusion.com/documentation/release-notes)
- [Troubleshooting Blazor Components](https://blazor.syncfusion.com/documentation/troubleshooting)