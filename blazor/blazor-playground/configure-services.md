---
layout: post
title: Configuration and new services in Blazor Playground | Syncfusion
description: Blazor Playground supports configuration and new services, making it easier to develop and maintain complex Blazor components.
platform: Blazor
component: Common
documentation: ug
---
# Update configuration and add new services

To add new services or modify the existing ones in your program, you can access the Services button located in the app bar.
Then, go to the ConfigureServices method in the Program.cs file, where you can add new injectable services or override the existing service configuration to suit your requirements.

For example, you can add the [C# file](#how-to-addremove-classes) and then click the "Services" button to configure the created class in the program.cs file.

![Add new services](images/Configuring_Services.png)

Then, register the services in ConfigureServices method.

![Configuring Services](images/Services_Program.png)

In this example, dependency injection is applied within the index.razor. You have the flexibility to inject the required dependencies according to your specific needs.

![Injecting services](images/Inject_Services.png)
