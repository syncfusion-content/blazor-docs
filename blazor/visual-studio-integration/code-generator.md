---
layout: post
title: Code Generator in Blazor | Syncfusion
description: Learn here about adding the Blazor Component using Code Generator of Syncfusion Blazor Extension for Visual Studio.
platform: Blazor
component: Common
documentation: ug
---

# Add Syncfusion Blazor component code

Syncfusion provides the component Code Generator for the Blazor platform, which allows you to quickly add component code to the application at the required place in the razor file. The Syncfusion extension adds the required Syncfusion component to render the code with namespaces, styles, and NuGet references. The Code Generator is a simple wizard that interacts with data models and adds Syncfusion components with the required features to your application.

The steps below will assist you to add the Syncfusion components code in your Blazor application through **Visual Studio 2022**:

N> Before using the Syncfusion Blazor Code Generator, check whether the Syncfusion Blazor Extension is installed or not in Visual Studio Extension Manager by clicking on the Extensions -> Manage Extensions -> Installed. If this extension not installed, install the extension by follow the steps from the [download and installation](download-and-installation) help topic.

1. Open your existing Blazor application or create a new Blazor application in the Visual Studio 2022 or Visual Studio 2022.

2. To open the Syncfusion Blazor Code Generator Wizard, select one of the options below in the Razor file, and then add Syncfusion components:

    **Option 1:**

    To generate a specific component code, right-click on the editor of the Razor file at the required line and Select the **Syncfusion Blazor Code Generator...**

    ![CodeGeneratorCommand](images/Code-Generator-Command.PNG)

    **Option 2:**

    Open the .razor file and place the cursor at the required line then choose **Extension -> Syncfusion -> Essential Studio® for Blazor -> Syncfusion Blazor Code Generator…** from the Visual Studio menu.

    ![CodeGeneratorMenu](images/Code-Generator-Menu.PNG)

3. The wizard for the Syncfusion Blazor Code Generator will appear. Choose a required control.

    ![CodeGeneratorWizard](images/Code-Generator-MainWizard.png)

    **Data Binding:** Data operation fields will be visible if the selected component has data. The data will be listed from your application. It interacts with data models and reduces the amount of time spent developing your application. You can choose the required Data Model Class, Data Source, Id, and more from your application.

    **Feature:** Selected component features are listed. You can select the required features.

    **Control requirements:** Contains the required user input fields for the selected component. You can provide the required value for those fields to add the component code.

    Click **Insert**. It generates the selected component render code and inserts it wherever the cursor is positioned.

    ![ComponentRenderCode](images/Code-Generator-ComponentRenderCode.PNG)

4. In the Output window, select the **Syncfusion Blazor Code Generator** from the **“Show output from”** drop-down to see the changes made to your application.

    ![OutputWindow](images/Code-Generator-OutputWindow.PNG)

5. The selected Syncfusion Blazor component code is inserted in selected active razor file and application configured with most recent selected Syncfusion Blazor component NuGet package, styles, namespaces for selected components.

6. If you have installed the trial setup or NuGet packages from nuget.org, you must register the Syncfusion license key to your application as Syncfusion has introduced the licensing system from 2018 Volume 2 (v16.2.0.41) Essential Studio® release. Navigate to the [help topic](https://help.syncfusion.com/common/essential-studio/licensing/overview#how-to-generate-syncfusion-license-key) to generate and register the Syncfusion license key to your application. Refer to this [blog](https://www.syncfusion.com/blogs/post/whats-new-in-2018-volume-2.aspx?_ga=2.11237684.1233358434.1587355730-230058891.1567654773) post to know more about the licensing changes introduced in Essential Studio®.
