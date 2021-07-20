---
layout: post
title: Configure Syncfusion Blazor Client Resources in Production Environment in Blazor - Syncfusion
description: Check out the documentation for Configure Syncfusion Blazor Client Resources in Production Environment in Blazor
platform: Blazor
component: Common
documentation: ug
---

# How to Use Syncfusion Blazor Component in Oqtane Framework

This section explains how to use Syncfusion Blazor component in Oqtane framework.

## Prerequisites

* [.NET 5.0 SDK](https://dotnet.microsoft.com/download/dotnet/5.0) or later.
* [Visual Studio 2019 (v16.8 or later)](https://visualstudio.microsoft.com/vs/)

> Make sure to install the `ASP.NET and web development` and `.NET desktop development` workload installed on the Visual Studio 2019.

## Create Oqtane Module in Visual Studio 2019

1. Open Visual Studio 2019 and select `Clone a repository`.

    ![Clone a repository in VS 2019](images/oqtane/clone-project.png)

2. Specify the below repository location and click the `Clone` button.

    ```bash
    https://github.com/oqtane/oqtane.framework.git
    ```

    ![Clone Oqtane GitHub repository](images/oqtane/clone-oqtane.png)

3. Once cloning completed, checkout the master branch in the `Git Changes` settings.

    ![Checkout master branch from dev](images/oqtane/master-checkout.png)

4. Switch the solution explorer and open `Oqtane.sln`.

    ![Open Oqtane solution](images/oqtane/open-oqtane-sln.png)

5. Run the application by pressing `F5` key. It will open the Oqtane app in the web browser.

    ![Oqtane app open in the browser](images/oqtane/oqtane-in-browser.png)

6. Setup the required Database configuration and create credentials and click `Install Now` button. It will open the default Oqtane page.

    ![Oqtane default page](images/oqtane/default-page.png)

7. Click `Login` button and fill-up the credentials you entered earlier and click `Login` button.

    ![Oqtane login page](images/oqtane/login-page.png)

8. Open `Administration` settings in the top right corner.

    ![Open administration settings](images/oqtane/admin-settings.png)

9. Create a new Module  configuration and click `Add Module To Page` button.

    ![Oqtane module configuration](images/oqtane/module-settings.png)
