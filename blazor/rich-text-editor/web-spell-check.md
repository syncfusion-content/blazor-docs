---
layout: post
title: Spell Checker in Blazor RichTextEditor Component | Syncfusion
description: Learn how to integrate WProofreader spell-checking support into the Syncfusion Blazor Rich Text Editor, including setup steps, package installation, and usage.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Integrate Spell Checker into the Blazor Rich Text Editor Component

WProofreader enables real-time spelling, grammar, and style checks inside the Rich Text Editor editable area. The SDK attaches to the editor content element and provides suggestions without changing the editor workflow.

## Key features

- Real-time spelling and grammar suggestions.
- Multilingual support and custom dictionaries.
- Cloud and on-premise deployment options.

## Prerequisites

Before proceeding, ensure you have completed the basic Rich Text Editor setup as outlined in the Getting Started guide. This includes configuring the Blazor project, installing the required packages, importing the necessary CSS files, injecting the modules, and adding the basic editor markup.

Refer to the guide here: [Getting Started with Blazor Rich Text Editor](https://blazor.syncfusion.com/documentation/rich-text-editor/getting-started-with-server-app).

## Key features
- Real-time spelling and grammar suggestions.
- Multilingual support and custom dictionaries.
- Cloud and on-premise deployment options.

## Step 1: Set up the WProofreader sdk

For integrating the Spell Checker you need to install the `@webspellchecker/wproofreader-sdk-js` package using NPM:

```bash
npm install @webspellchecker/wproofreader-sdk-js
```

> **Note:** Register for a [Web Spell Checker](https://wproofreader.com/sdk) cloud service key and ensure that the `serviceId` is available.
> For self‑hosted deployments, make sure the service endpoint settings are properly configured.

## Step 2: Add the JavaScript Interop File
 
Create the JavaScript interop module to handle communication between Blazor and Spell Checker.
 
### 2.1 Create the interop file
 
In your Blazor project, create a new folder named `wwwroot/scripts/` and add a file called `spell-checker.js` to include the code shown below.

{% tabs %}
{% highlight javascript %}

{% include_relative code-snippet/spell-checker.js %}

{% endhighlight %}
{% endtabs %}

### 2.2 Verify file placement
 
Ensure the file is located at:
 
```
YourProject/
└── wwwroot/
    └── scripts/
        └── spell-checker.js
```

## Step 3: Add Script Reference in Host Page

Add the script references in your host page before the closing `</body>` tag:

```html
<body>
    ....
    <!-- Syncfusion CSS and Script references -->
    <script src="https://svc.webspellchecker.net/spellcheck31/wscbundle/wscbundle.js"></script>
    <script src="/scripts/spell-checker.js"></script>
</body>
```

> The host page location varies by project type. Refer to the [RichTextEditor Getting Started](https://blazor.syncfusion.com/documentation/rich-text-editor/getting-started) guide for the correct host page file path.
>
> **Note:** The Spell Checker script must be loaded before the custom interop file to ensure proper functionality.

## Step 4: Create the Razor Component

Create a new Razor component file named **`RichTextEditorWithSpellChecker.razor`** in your **Pages** directory:

{% tabs %}
{% highlight cshtml %}

{% include_relative code-snippet/spell-checker.razor %}

{% endhighlight %}
{% endtabs %}

## Additional resources

- WProofreader SDK: https://www.npmjs.com/package/@webspellchecker/wproofreader-sdk-js
