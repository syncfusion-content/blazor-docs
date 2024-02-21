---
layout: post
title: Exploring Themes and Code Editor in Blazor Playground | Syncfusion
description: Blazor Playground offers theme customization and a feature-rich code editor to simplify the development and testing of Blazor components.
platform: Blazor
component: Common
documentation: ug
---

# End-user Capabilities

## Switching the Themes

Blazor Playground lets you customize the appearance of Syncfusion Blazor components by choosing from various themes using the dropdown accessible through the **Output Theme** button.

![Syncfusion Blazor Playground with theme](images/Output_Theme.gif)

## Explore the Code Editor 

* Type, copy, cut, paste, and edit your code within the editor.
* Create and manage .razor and .cs files alongside the default index.razor.
* Enhance readability with syntax highlighting for keywords, variables, strings, and comments.

## Compiling and Running Code

* Execute your code by pressing the Run button or using the Ctrl+R keyboard shortcut.
* Visualize the compiled code's output in the result view.

## Preview Code Output

* Click the Run button to compile your code.
* If there are no errors, the result view displays the output for your code.

## Error and warning handling

During compilation, any errors or warnings are displayed with their corresponding line numbers for efficient identification and resolution.

![Syncfusion Blazor Playground with error console](images/ErrorConsole.png)

## Sharing Code
You can share your code snippets with unique URLs easily for collaboration and discussion by clicking the `Share` button, which presents two sections: **Shared Link** and **Embed Link**.

![Syncfusion Blazor Playground with save code snippet](images/Save_Snippet.png)

## Embedding Code

The embed links are useful for sharing the code snippet that provides various customization options:
* **Display Code Editor:** Enables the code editor for the end user.
* **Display Result View:** Disables the code editor and shows only the result.
* **Display Error Console:** Shows the warnings and errors console.
* **Display App Bar:** Enables the app bar with the run button.

For example, enabled all the options on embed a link. 

![Syncfusion Blazor Playground with all embed options](images/Embed_enableall.png)

For example, show the result view and disabled all other options.

![Syncfusion Blazor Playground with result view](images/Embed_Result.png)

## Handling Static Assets

You can manage CSS and JavaScript files for styling and scripting your application in Blazor Playground.
* Add CDN links for static assets through the **Static Assets** tab in the **NuGet Asset Manager**.
* Include the CDN link in your code files (**__Index.razor** in this example) to apply the styles or scripts.

![Syncfusion Blazor Playground with static assets](images/static_assets.gif)