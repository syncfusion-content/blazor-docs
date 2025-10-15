---
layout: post
title: Deploy a Blazor Web App to Azure App Service | Syncfusion
description: Learn here all about deploying the Blazor application with Syncfusion Blazor Components to Azure App Service.
platform: Blazor
component: Common
documentation: ug
---

# Deploy Blazor Web App to Azure App Service

This section provides information about deploying a Blazor Web applications with the Syncfusion Blazor components to Azure App Service.

Refer to [Host and deploy ASP.NET Core Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy/?view=aspnetcore-7.0&tabs=visual-studio) topic for more information.

## Deployment procedure

If you don’t have a login for Azure, [sign up](https://azure.microsoft.com/en-in/free/) to access the Azure Portal.

### Create a resource in Azure

* Click **Create a resource** in Azure Portal to create a resource group.

![Create new resource](../images/create-new-resource.png)

* Select **Web App** Azure application service.

![Select web app](../images/web-app.png)

* After selecting Web App option, choose an appropriate resource group name and instance details.

* Once this is done, click **Review + create**.

![Create resource](../images/create-resource.png)

* After configuring the Web App service. Select the created web app service (blazor-web-publish).

![Created resource](../images/created-resource.png)

* Now, select the **overview** section, click on **Download publish profile**, and save the profile locally.

![Download publish profile](../images/download-publish-profile.png)

### Publish the Application in Azure

#### Using Azure account login

* To publish the project, right-click on it and choose **Publish** from the context menu.

![Publish menu](../images/publish-menu.png)

* Select **Azure** as the target and **Azure App Service (Windows)**  as the specific target.

![Publish target](../images/publish-target.png)

![Publish specific target](../images/publish-specific-target.png)

* You need to log into your Azure account and choose the web app service (blazor-web-publish) that you have created. Then, click **Publish**.

![Created azure app service](../images/created-azure-resource.png)

![Publish App](../images/publish-azure.png)

#### Using Import Profile option

* To publish the project, right-click on it and choose **Publish** from the context menu.

![Publish menu](../images/publish-menu.png)

* Select **Import Profile** as the target and browse the downloaded publish folder. Then, click **Publish**

![Publish target](../images/target-import-profile.png)

![Publish App](../images/publish-azure.png)

* Now, the application will be deployed and will be available in the specified URL: https://blazor-web-publish.azurewebsites.net/.

![Output-Azure](../images/output-azure.png)

## See also

Refer [here](https://learn.microsoft.com/en-us/azure/app-service/quickstart-dotnetcore?tabs=net70&pivots=development-environment-vs#publish-your-web-app) for publishing the application to Azure App Service using Visual Studio.