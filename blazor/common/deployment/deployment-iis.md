---
layout: post
title: Deploy a Blazor Web App to IIS | Syncfusion
description: Learn here all about deploying the Blazor application with Syncfusion Blazor Components to IIS server.
platform: Blazor
component: Common
documentation: ug
---

# Deploy Blazor Web App to IIS server

This section provides information about deploying a Blazor Web applications with the Syncfusion Blazor components to IIS server.

Refer to [Host and deploy ASP.NET Core Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy/?view=aspnetcore-7.0&tabs=visual-studio) topic for more information.

## Create an IIS Site

* [Enable IIS](https://learn.microsoft.com/en-us/previous-versions/dynamicsnav-2018-developer/How-to--Install-and-Configure-Internet-Information-Services-for-Microsoft-Dynamics-NAV-Web-Client)in Windows Features.

* [Enable WebSockets](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/websockets?view=aspnetcore-7.0#enabling-websockets-on-iis) in IIS.

* Now, publish the application for deployment in Release configuration by referring to [this](https://blazor.syncfusion.com/documentation/common/deployment).

* Open Internet Information Services (IIS) Manager and then right-click on "Sites," followed by selecting "Add Website."

![Add site in IIS](./images/add-site.png)

* In the Add Website dialog, fill in the required field values such as site name, physical patha and customized port value and then click OK.

Set the physical path to the location where your sample application is developed.

![Add Website in IIS](./images/add-website.png)

## Run the Published Application

* Open Internet Information Services (IIS) Manager. Expand the `Sites` node to verify that the published application is running. Click `Browse` to open the application in your browser.

![Browse application](./images/browser-website.png)

* Now, application runs in the specified browser port(8080).

![Output-IIS](./images/iis-output.png)

## See also

Refer [here](https://learn.microsoft.com/en-us/aspnet/core/tutorials/publish-to-iis?view=aspnetcore-7.0&tabs=visual-studio) for publishing the application to IIS Service using Visual Studio.