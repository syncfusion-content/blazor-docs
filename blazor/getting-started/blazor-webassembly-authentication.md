---
layout: post
title: Getting Started with Syncfusion Blazor WASM Standalone App with Authentication Library
description: Check out the documentation for getting started with Blazor WebAssembly App and Syncfusion Blazor Components with Authentication Library.
platform: Blazor
component: Common
documentation: ug
---

# Getting Started with Blazor WASM Standalone App with Authentication Library

This article provides a step-by-step instructions for building and securing Blazor WebAssembly Standalone App with Blazor WebAssembly Authentication library using [Visual Studio](https://visualstudio.microsoft.com/vs/).

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor WebAssembly Standalone App in Visual Studio

You can create a **Blazor WebAssembly Standalone App** using Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=windows) or the [Syncfusion Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio) by setting the `Authentication type` to `Individual Accounts`. This selection adds authentication support and doesn't result in storing users in a database.

## Configure the application with Google Auth 2.0 OIDC

* Set up `Google OAuth 2.0` authentication. For more information, refer [here](https://support.google.com/cloud/answer/6158849?hl=en)

* Now, replace the `appsettings.json` with the following code which contains code to configure the application with `Google OAuth 2.0`.

{% tabs %}
{% highlight cshtml tabtitle="appsettings.json" %}

{
  "Local": {
    "Authority": "https://accounts.google.com/",
    "ClientId": "2...7-e...q.apps.googleusercontent.com",
    "PostLogoutRedirectUri": "https://localhost:5001/authentication/logout-callback",
    "RedirectUri": "https://localhost:5001/authentication/login-callback",
    "ResponseType": "id_token"
  }
}

{% endhighlight %}
{% endtabs %}

* Replace the `ClientId` with the OAuth 2.0 client ID of your created project.

![OAuth 2.0 client ID](images/oauth-client-id.png)

* The `RedirectUri` (https://localhost:5001/authentication/login-callback) should be registered in the Google APIs console as mentioned below.

![OAuth RedirectUri](images/oauth-rediredt-uri.png)

## Install Syncfusion Blazor Calendars and Themes NuGet in the App in the App

Here's an example of how to add **Blazor Calendar** component in the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search and install [Syncfusion.Blazor.Calendars](https://www.nuget.org/packages/Syncfusion.Blazor.Calendars/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/). Alternatively, you can utilize the following package manager command to achieve the same.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Calendars -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

## Register Syncfusion Blazor Service

Open **~/_Imports.razor** file and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Calendars` namespace.

```cshtml

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Calendars

```

Now, register the Syncfusion Blazor Service in the **~/Program.cs** file of your Blazor WebAssembly Standalone App.

```cshtml

....
using Syncfusion.Blazor;
....
builder.Services.AddSyncfusionBlazor();
....

```

## Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Reference the stylesheet reference in the `<head>` section and the script reference at the end of the `<body>` as follows:

* For **.NET 8** Blazor WebAssembly Standalone app, include it in the **~/Components/App.razor** file.

```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>

<body>
    ....
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>

```
N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in your Blazor application. Also, check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in your Blazor application.

## Add Syncfusion Blazor component

Add the Syncfusion Blazor Calendar component in the **~/Pages/Home.razor** file under `AuthorizeView`.

{% tabs %}
{% highlight razor %}

<AuthorizeView>
    <Authorized>
        <SfCalendar TValue="DateTime" />
    </Authorized>
    <NotAuthorized>
        <h1>Authentication Failure!</h1>
        <p>You're not signed in.</p>
    </NotAuthorized>
</AuthorizeView>

{% endhighlight %}
{% endtabs %}

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. This will render the Syncfusion Blazor Calendar component in your default web browser.


![Blazor Calendar Component](images/output-calendar-using-blazor-webassembly.png)


## See Also

* [Secure an ASP.NET Core Blazor WebAssembly standalone app with the Authentication library](https://learn.microsoft.com/en-us/aspnet/core/blazor/security/webassembly/standalone-with-authentication-library?view=aspnetcore-8.0&tabs=visual-studio)
