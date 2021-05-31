---
layout: post
title: Customize the Blazor Components in Blazor - Syncfusion
description: Check out the documentation for Customize the Blazor Components in Blazor
platform: Blazor
component: Common
documentation: ug
---

# How to customize the font size and color in Syncfusion Blazor components

## Install Web Compiler

Install the Web Compiler to compile the `scss` files in the Blazor Applications.

## Steps to install the Web Compiler in Visual Studio 2019**

1. Open the Visual Studio 2019 and click the **Extensions** in the visual studio toolbar.

    ![Extension](../images/extensions.png)

2. Download and install the **Web Compiler** in the visual studio 2019.

    ![WebCompiler](../images/webcompiler.png)

## Create a Blazor Server Application in Visual Studio 2019

1. Create a Blazor server application by referring [Blazor Server](../../getting-started/blazor-server-side-visual-studio-2019/) documentation.

2. Install the Syncfusion `node_modules` in this application using this command.

{% tabs %}

{% highlight bash %}

    npm install @syncfusion/ej2

{% endhighlight %}

{% endtabs %}

3. Create a `scss` file as `~/wwwroot/styles/custom.scss` and provide the variables to override as shown below.

{% tabs %}

{% highlight scss %}

    $calendar-normal-max-width: 362px !default;
    $calendar-normal-min-width: 256px !default;
    $primary: green !default;

    @import 'ej2-base/styles/bootstrap4.scss';
    @import 'ej2-buttons/styles/bootstrap4.scss';
    @import 'ej2-calendars/styles/bootstrap4.scss';

{% endhighlight %}

{% endtabs %}

4. Right-click the `scss` file and click the Web Compiler to compile the file.

    ![compile](../images/compile.png)

5. The **compilerconfig.json** file is created. Then provide the location of the compiled CSS file and include path like the following code snippet.

{% tabs %}

{% highlight JSON %}

        [
            {
                "outputFile": "wwwroot/styles/custom.css",
                "inputFile": "wwwroot/styles/custom.scss",
                "options": {
                    "includePath": "node_modules/@syncfusion"
                }
            }
        ]

{% endhighlight %}

{% endtabs %}

6. The `scss` file has been compiled to the CSS file. Then, add this CSS file to the `<head>` element of the **~/Pages/_Host.cshtml** page.

{% tabs %}

{% highlight html %}

    <head>

    .....
    .....

    <link href="~/styles/custom.css" rel="stylesheet" />
    <head>

{% endhighlight %}

{% endtabs %}

    > **Note:** Syncfusion provides an option to generate custom styles of selective components by using the ThemeStudio web application for the production environment. Refer to this [link](http://ej2.syncfusion.com/themestudio/) for further details.

7. Run the application. The styles are applied in our Blazor component.

    ![sample](../images/sample.png)