---
layout: post
title: Themes in Blazor and How to Use? - Syncfusion
description: Check out the documentation for built-in-themes in Blazor and learn here about how to use it in Blazor
platform: Blazor
component: Appearance
documentation: ug
---

# Blazor Themes in Syncfusion Components 

The following list of themes are included in the Syncfusion Blazor components library.

|Theme	|Style Sheet Name| 
|--------|--------|
|Bootstrap	| bootstrap.css | 
|Bootstrap Dark	| bootstrap-dark.css | 
|Bootstrap4	| bootstrap4.css |
|Microsoft Office Fabric | fabric.css |
|Microsoft Office Fabric Dark | fabric-dark.css |
|Google’s Material | material.css |
|Google’s Material-Dark | material-dark.css |
|High Contrast | highcontrast.css |
|Tailwind CSS | tailwind.css |
|TailwindDark CSS | tailwind-dark.css |

The Syncfusion Blazor Bootstrap Theme is designed based on Bootstrap v3, whereas the Bootsrap4 theme is designed based on Bootstrap v4.

## Reference themes in Blazor application

To reference the above themes in your Blazor application, its style sheet must be referred in the `<head>` of your main `index` file.

For a server-side Blazor application refer it in `~/Pages/_Host.cshtml` file and for a client-side Blazor application refer it in `wwwroot/index.html` file.

Using the below approaches the themes can be referenced in the Blazor application,

1. Static Web assets
2. CDN
3. NPM packages
4. LibMan

Instead of using **Static Web assets** or a **CDN reference**, you can reference the stylesheet into your projects to customize the theme or bundle it with the other stylesheets using **NPM packages** or **LibMan**. 

### Static Web assets

Syncfusion Blazor themes are available as Static web assets in the [Syncfusion.Blazor](https://www.nuget.org/packages/Syncfusion.Blazor/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet Packages.

* In Blazor Server Application, inside the `<head>` element of the `~/Pages/_Host.cshtml` file add the following link reference to use the static assets.

* In the Blazor WebAssembly Application, inside the `<head>` element of the `~/wwwroot/index.html` file add the following link reference to use the static assets.

When using Individual NuGet Packages in your Application,

 ```html
<head>
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap4.css" rel="stylesheet" />
</head>
```

When using [Syncfusion.Blazor](https://www.nuget.org/packages/Syncfusion.Blazor/) NuGet package,

 ```html
<head>
    <link href="_content/Syncfusion.Blazor/styles/bootstrap4.css" rel="stylesheet" />
</head>
```

### CDN Reference

Instead of using a local resource on your server, you can use a cloud CDN to reference the theme style sheets. CDN Stands for "Content Delivery Network". A CDN is a group of servers distributed in different locations. While CDNs are often used to host websites, they are commonly used to provide other types of downloadable data as well. Examples include software programs, images, videos, and streaming media.

Syncfusion Blazor Themes are available in the CDN. Make sure that the version in the URLs matches the version of the Syncfusion UI for Blazor package.

 ```html
<head>
    <link href="https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/styles/bootstrap.css" rel="stylesheet"/>
</head>
```

| Theme Name | CDN Reference |
|--- | --- |
| Bootstrap | https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/styles/bootstrap.css |
| Bootstrap Dark| https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/styles/bootstrap-dark.css |
| Bootstrap4 | https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/styles/bootstrap4.css |
| Microsoft Office Fabric  | https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/styles/fabric.css |
| Microsoft Office Fabric Dark | https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/styles/fabric-dark.css |
| Google’s Material | https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/styles/material.css |
| Google’s Material Dark | https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/styles/material-dark.css |
| High Contrast  | https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/styles/highcontrast.css |
| Tailwind CSS | https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/styles/tailwind.css |
| Tailwind Dark CSS | https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/styles/tailwind-dark.css |


### NPM Packages

NPM is a node package manager. It is basically used for managing dependencies of various server-side dependencies. You can manage server-side dependencies manually. It is a command-line program for dealing with said repository that aids in package installation, version management, and dependency management. It is an online repository for the publishing of open-source `Node.js` projects.

You can add the theme for the Blazor applications through **npm packages** using the **SCSS** files by following the below process.

1. Install Web Compiler to use `SCSS` files in Blazor applications.

2. To install Web Compiler, open Visual Studio and click the **Extensions** in the toolbar.

 ![Themes-npm-package-extension](images/Themes-npm-package-extension.png)

 ![Themes-npm-package-webcompiler](images/Themes-npm-package-webcompiler.png)
 
3. Install the Syncfusion `node_modules` in this application using this command.

```
npm install @syncfusion/ej2
```

4. Create a `SCSS` file as `~/wwwroot/styles/custom.scss` and provide the variables to override as shown below.

``` scss
$primary: blue !default;
@import 'ej2/fabric.scss';
```

5. Right-click the `SCSS` file and click the Web Compiler to compile the file.

 ![Themes-npm-packages-compile](images/Themes-npm-packages-compile.png) 

6. The `compiler config.json` file is created. Then, provide the location of the compiled CSS file and include a path as shown in the following code snippet.

```json
[
  {
    "outputFile": "wwwroot/styles/customstyle.css",
    "inputFile": "wwwroot/styles/customstyle.scss",
    "options": {
      "includePath": "node_modules/@syncfusion"
    }
  }
]
```

7. The `SCSS` file has been compiled to the CSS file. Then, add this CSS file to the `<head>` element of the `~/Pages/_Host.cshtml` page.

8. Run the application and see the fabric themes from installed npm packages was applied.

### LibMan

Library Manager (LibMan) is a client-side library acquisition tool that is simple to use. LibMan is a program that downloads popular libraries and frameworks from a file system or a content delivery network (CDN).

LibMan offers the following advantages,

1. Only the library files you need are downloaded.
2. Additional tooling, such as Node.js, npm, and WebPack, isn't necessary to acquire a subset of files in a library.
3. Files can be placed in a specific location without resorting to build tasks or manual file copying.

In the server application root, add the `lib man.json` file with the following content:

```json
{
  "version": "1.0",
  "defaultProvider": "unpkg",
  "libraries": [
    {
      "library": "@progress/Syncfusion-Blazor-bootstrap@latest",
      "destination": "wwwroot/css/Syncfusion-Blazor/bootstrap",
      "files": [
        "dist/all.css"
      ]
    },
    {
      "library": "@progress/Syncfusion-Blazor-fabric@latest",
      "destination": "wwwroot/css/Syncfusion-Blazor/fabric",
      "files": [
        "dist/all.css"
      ]
    },
    {
      "library": "@progress/Syncfusion-Blazor-material@latest",
      "destination": "wwwroot/css/Syncfusion-Blazor/material",
      "files": [
        "dist/all.css"
      ]
    }
  ]
}
```

In the client Blazor application, go to the `wwwroot/index.html` file and replace the CDN link with the following one. For a server-side Blazor project, do that in the `~/Pages/_Host.cshtml` file.

```html
<!DOCTYPE html>
<html lang="en">
<head>
    <link href="/css/Syncfusion-Blazor/fabric/dist/all.css" rel="stylesheet" />
</head>
</html>
```

### How to change theme dynamically

In the Blazor application, the application theme can be changed dynamically by changing its style sheet reference in code.

The following example demonstrates how to change a theme dynamically in Blazor application using Syncfusion Blazor themes.

1. Create a Blazor server application by referring [Blazor Server](../../getting-started/blazor-server-side-visual-studio-2019/) documentation.

2. Install Syncfusion NuGet packages in the created Blazor application to utilize Syncfusion products.
Right-click on Dependencies folder -> Manage NuGet Packages -> Browse -> select the package and click to install latest or select the specified version from the list and then install it.

 ![Themes-install-nuget](images/Themes-install-nuget.png)

3. Add the following code to the `_Host.cshtml` file.

The themeName variable is assigned for theme switch result, in which its value is applied to the Syncfusion theme link reference where the specified theme is applied directly to the entire product.

```html
@page "/"
@namespace BlazorThemeSwitcher.Pages
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers

@{
    Layout = null;

   QueryHelpers.ParseQuery(Request.QueryString.Value).TryGetValue("theme", out var themeName);
    themeName = themeName.Count > 0 ? themeName.First() : "bootstrap";
}

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>BlazorThemeSwitcher</title>
    <base href="~/" />
    <link rel="stylesheet" href="css/bootstrap/bootstrap.min.css" />
    <link href="css/site.css" rel="stylesheet" />
    <link href="BlazorThemeSwitcher.styles.css" rel="stylesheet" />
    <link href=@("_content/Syncfusion.Blazor/styles/" + themeName + ".css")rel="stylesheet" />
</head>

<body>
    <script src="_framework/blazor.server.js"></script>
</ </body>
</html>
```

4. Modify the `MainLayout.razor page` to process theme changing in application.

```cshtml
@inherits LayoutComponentBase
@inject NavigationManager UrlHelper;
@using Syncfusion.Blazor.DropDowns;
@using Syncfusion.Blazor.Buttons;
   ....

    <div class="main @darkClass">
        <div class="top-row px-4 @darkClass">
            <div class="theme-switcher">
                @*Theme switcher*@
                <SfDropDownList TItem="ThemeDetails" TValue="string" @bind-Value="themeName" DataSource="@Themes">
                    <DropDownListFieldSettings Text="Text" Value="ID"></DropDownListFieldSettings>
                    <DropDownListEvents TItem="ThemeDetails" TValue="string" ValueChange="OnThemeChange"></DropDownListEvents>
                </SfDropDownList>
            </div>
            <div>
                @*Theme mode switcher*@
                <SfButton @ref="ThemeMode" IsToggle="true" IsPrimary="true" Content="@themeMode" @onclick="OnThemeModeChange"></SfButton>
            </div>
            <a href="https://docs.microsoft.com/aspnet/" target="_blank">About</a>
        </div>
    ....
</div>

<style>
.theme-switcher {
    margin-right: 24px;
}
/*page background theme*/
.dark-bg,
.top-row.dark-bg {
    background: #000000;
}
</style>

@code {
    private string darkClass;
    private string themeName;
    private string themeMode;
    protected SfButton ThemeMode { get; set; }

    public class ThemeDetails
    {
        public string ID { get; set; }
        public string Text { get; set; }
    }

    @*Theme switcher datasource*@
    private List<ThemeDetails> Themes = new List<ThemeDetails>() {
        new ThemeDetails(){ ID = "material", Text = "Material" },
        new ThemeDetails(){ ID = "bootstrap", Text = "Bootstrap" },
    };    
 
    public void OnThemeChange(ChangeEventArgs<string, ThemeDetails> args)
    {
        var theme = GetThemeName();
        if (theme != args.ItemData.ID)
        {
            var themeMode = theme.Contains("-dark") ? "-dark" : string.Empty;
            UrlHelper.NavigateTo(GetUri(args.ItemData.ID + themeMode), true);
        }
    }

    public void OnThemeModeChange()
   {
       var theme = GetThemeName().Replace("-dark", string.Empty);
        theme += (ThemeMode.Content == "Dark" ? "-dark" : string.Empty);
              UrlHelper.NavigateTo(GetUri(theme), true);
    }

    private string GetThemeName()
    {
        var uri = UrlHelper.ToAbsoluteUri(UrlHelper.Uri);
        QueryHelpers.ParseQuery(uri.Query).TryGetValue("theme", out var theme);
        theme = theme.Count > 0 ? theme.First() : "bootstrap";
        return theme;
    }

    private string GetUri(string themeName)
    {
        var uri = UrlHelper.ToAbsoluteUri(UrlHelper.Uri);
        return uri.AbsolutePath + "?theme=" + themeName;
    }

    protected override void OnInitialized()
    {
        var theme = GetThemeName();
        darkClass = theme.Contains("dark") ? "dark-bg" : string.Empty;
        themeMode = theme.Contains("dark") ? "Light" : "Dark";
               themeName = theme.Contains("bootstrap") ? "bootstrap" :"material";
    }
}
```

5. Add the following code in `Index.razor` page to render the DataGrid in Blazor output.

```cshtml
@page "/"
@inject NavigationManager Urlhelper
@using Syncfusion.Blazor.Grids

<div>
    <h2>Theme Switcher Example</h2>
    <SfGrid DataSource="@Orders" AllowPaging="true">
      ....
    </SfGrid>
    <br /><br />
  
</div>

@*h2 tag font color for dark theme*@
<style>
    .dark-bg h2 {
        color: #ffffff;
    }
</style>

@code{
    ....
}
```

In the following demo, **Bootstrap** and **Material** theme from the Syncfusion packages are used and the background theme of the `Index` page are from normal CSS style. This will helps to change theme between Bootstrap and Material themes , as well as light and dark modes dynamically as shown below.

 ![Themes-dynamically-change-theme-output-demo](images/Themes-dynamically-change-theme-output-demo.gif) 
 



