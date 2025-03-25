---
layout: post
title: Build your first Blazor app with our blocks | Syncfusion
description: Learn all about building your first Blazor app using our blocks from the Essential Blazor UI Kit in Syncfusion Essential Studio and more.
platform: Blazor
control: UI Kit
documentation: ug
---

# Build your first Blazor Web App with our blocks

## Create a new Blazor Web App
A Blazor Web App is used for this example. To create a new app, follow the official setup guide [here](https://learn.microsoft.com/en-us/training/modules/build-your-first-blazor-web-app/3-exercise-configure-environment?pivots=vscode). This tutorial then walks through the step-by-step process of adding a simple sign-in block to the newly created app, named MyBlazorApp.

> This tutorial focuses on using Blazor Server rendering mode rather than Blazor WebAssembly.

**Steps to create the Blazor Web App:**

1. Open Visual Studio Code.

2. Open the Terminal (Ctrl + ~ on Windows/Linux or Cmd + ~ on Mac).

3. Run the following command to create a new Blazor Web App:

    ```bash
    dotnet new blazor -o MyBlazorApp
    ```

    * blazor → Creates a Blazor Web App.

    * -o MyBlazorApp → Creates a folder named MyBlazorApp for the project.

4. Navigate into the project folder and opent the project in Visual Studio Code:
    ```bash
    cd MyBlazorApp
    code .
    ```
![New Blazor App](images/new-blazor-app.png)

## Setting up Tailwind or Bootstrap 5.3 theme in the app

### Tailwind configuration

If you choose **Tailwind** theme, follow these steps to configure it.

1. In **Components -> App.razor** file, add the following code for light mode (`class="light"`) and dark mode (`class="dark"`) in the `<html>` tag.

    - For **light mode**:

    ```html
    <html lang="en" class="light">
    ```

    - For **dark mode**:

    ```html
    <html lang="en" class="dark">
    ```

2. In **Components -> App.razor** file, add the following scripts in the `<head>` tag.

    ```html
    <script src="https://cdn.tailwindcss.com"></script>
    <script>
      tailwind.config = {
        darkMode: "class",
        theme: {
          extend: {
            colors: {
              // NOTE: In this demo, different shades of "Indigo" are used as primary colors.
              primary: {
                "50": "#eef2ff",
                "100": "#e0e7ff",
                "200": "#c7d2fe",
                "300": "#a5b4fc",
                "400": "#818cf8",
                "500": "#6366f1",
                "600": "#4f46e5",
                "700": "#4338ca",
                "800": "#3730a3",
                "900": "#312e81",
                "950": "#1e1b4b"
              }
            }
          }
        }
      }
    </script>
    ```
    > The Syncfusion Blazor components uses **Indigo** for light mode and **Cyan** for dark mode. So, please change the primary color accordingly to maintain a uniform appearance.


3. In **Components -> App.razor** file, add the style oriented CDN link for Syncfusion Blazor components in the `<head>` tag.

   - For **light mode**:

     ```html
     <link href="_content/Syncfusion.Blazor.Themes/tailwind.css" rel="stylesheet" />
     ```

   - For **dark mode**:

     ```html
     <link href="_content/Syncfusion.Blazor.Themes/tailwind-dark.css" rel="stylesheet" />
     ```

4. **OPTIONAL**: If you wish to use our font icons prepared for **Tailwind**, you can include the following CDN link:

    ```html
    <link href="https://cdn.syncfusion.com/blazor/ui-kit/font-icons/tailwind-icons.css" rel="stylesheet" />
    ```
     
You can refer to the consolidated screenshot below for more details.

![Tailwind configuration](images/tailwind-configuration.png)

Now that the **Tailwind** theme is configured for either light or dark mode of your choice, the app is ready for the next set of processes.

### Bootstrap 5.3 configuration

If you choose **Bootstrap 5.3** theme, follow these steps to configure it.

1. In **Components -> App.razor** file, add the following code for light mode (`data-bs-theme="light"`) and dark mode (`data-bs-theme="dark"`) in the `<html>` tag.

    - For **light mode**:

    ```html
    <html lang="en" data-bs-theme="light">
    ```

    - For **dark mode**:

    ```html
    <html lang="en" data-bs-theme="dark">
    ```

2. In **Components -> App.razor**  file, add the style oriented CDN link for **Bootstrap 5.3** theme in the `<head>` tag.

     ```html
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
     ```

3. In **Components -> App.razor**  file, add the style oriented CDN link for Syncfusion Blazor components in the `<head>` tag.

   - For **light mode**:

     ```html
     <link href="https://cdn.syncfusion.com/ej2/27.1.48/bootstrap5.3.css" rel="stylesheet">
     ```

   - For **dark mode**:

     ```html
     <link href="https://cdn.syncfusion.com/ej2/27.1.48/bootstrap5.3-dark.css" rel="stylesheet" />
     ```

4. **OPTIONAL**: If you wish to use our font icons prepared for **Bootstrap 5.3**, you can include the following CDN link:

    ```html
    <link href="https://cdn.syncfusion.com/blazor/ui-kit/font-icons/bootstrap5.3-icons.css" rel="stylesheet" />
    ```

You can refer to the consolidated screenshot below for more details.

![Bootstrap 5.3 configuration](images/bootstrap-5.3-configuration.png)

Now that the **Bootstrap 5.3** theme is configured for either light or dark mode of your choice, the app is ready for the next set of processes.

## Steps to explore and copy block code snippets

Now that **MyBlazorApp** is set up with the desired theme configuration, the next step is to copy and paste the pre-built simple sign-in block code into the app for quick development. Here are a couple of ways to achieve this.

### Steps to explore and copy block code snippets from the online demo

1. In the [online demo](https://blazor.syncfusion.com/essential-ui-kit/blocks), navigate to the **Authentication** category and select the **Sign In** block. This will direct you to the appropriate demo page.

    ![Navigate to the sign-in block demo](images/navigate-to-the-sign-in-block-demo.png)

2. On the demo page, go to the first demo, which showcases a simple sign-in block. Choose the desired theme, then switch from the **Preview** tab to the **Code** tab.

    ![Choose Tailwind or Bootstrap theme](images/choose-tailwind-or-bootstrap-theme.png)

3. In the **Code** tab, copy the Razor (HTML) code using the **Copy to Clipboard** option and paste it into the **Components -> Pages -> Home.razor** file.

    ![Copy HTML code snippet to clipboard](images/copy-HTML-code-snippet-to-clipboard.png)

4. If CSS is provided, copy the CSS code, create a new file **Components -> Pages -> Home.razor.css**, and paste the code into it. Otherwise, you can ignore this step.

### Steps to explore and copy block code snippets from the GitHub source

1. On [downloading](https://github.com/syncfusion/essential-ui-kit-for-blazor) and opening the GitHub source in Visual Studio Code, navigate to the following folder: **Components -> Pages -> BlocksSection**.

    ![Downloaded GitHub app in Visual Studio Code](images/downloaded-github-app-in-visual-studio-code.png)

2. Inside, you'll find a list of folders, each corresponding to a specific block. Open the **SignIn** block folder, where you'll see the demo arranged sequentially.

3. Go to the first folder, **Components/Pages/BlocksSection/SignIn/SignIn1**, where you'll find the Razor (HTML) and CSS files of the simple sign-in block. You can copy the code directly from these files.

    ![View the sign-in block demo files](images/view-the-sign-in-block-demo-files.png)

> **Note:**
> 
> 1. In the Razor file, the **Tailwind** and **Bootstrap 5.3** design code is placed in their respective switch case statements. You can copy and paste as per your requirement.
> 2. Ignore the code within the **"SB Code - Start"** and **"SB Code - End"** comments, as it is intended solely for sample browser purposes.

## Steps to install and configure Syncfusion Blazor components

While copying and pasting the Razr (HTML) code, you'll notice that Syncfusion Blazor components are used. To incorporate them into **MyBlazorApp**, install the necessary packages and import the corresponding namespaces to the **Components -> _Imports.razor** file for the app to run.

In the simple sign-in block, components such as textbox, checkbox and button are used. After copying and pasting HTML code into the Razor file, open the **MyBlazorApp.csproj** file and add the required nuget packages: `Syncfusion.Blazor.Buttons` and `Syncfusion.Blazor.Inputs`. For more details about other Syncfusion Blazor component packages, refer to this [link](https://www.nuget.org/packages?q=Syncfusion.Blazor)

![Adding required packages for Syncfusion components](images/adding-required-packages-for-syncfusion-components.png)

Once the necessary packages are added, run the follwing command via the terminal to install those packages.

    ```bash
    dotnet restore
    ```

Finally, again check the [online demo](https://blazor.syncfusion.com/essential-ui-kit/blocks) or the [GitHub repository](https://github.com/syncfusion/essential-ui-kit-for-blazor) and copy the required HTML, and CSS code for the simple sign-in block into your app as outlined in the previous topic.

## Steps to download and add assets to the app

If you want to view and experience the images used in our design, you can download the **assets** folder from the following [GitHub repository](https://github.com/syncfusion/essential-ui-kit-for-blazor/tree/master/UI-Blocks/wwwroot), place it inside the **wwwroot** folder of **MyBlazorApp**, and modify the image URLs in the HTML if necessary.

## Steps to run the app

Now that everything is set up in **MyBlazorApp** — including the Razor (HTML), CSS (if applicable), and assets (optional) — you are ready to build and launch the app. Type the following command in the terminal, and you will see a localhost URL provided by the Blazor development server.

    ```bash
    dotnet run
    ```

![Build and launch the app](images/build-and-launch-the-app.png)

To view the app in your browser, simply **Ctrl + Click** (or **Cmd + Click** on macOS) on the localhost URL displayed in the terminal. This will open the app in your default browser, allowing you to view and experience the simple sign-in block.

![View the app in the browser using the localhost URL](images/view-the-app-in-the-browser-using-the-localhost-URL.png)
