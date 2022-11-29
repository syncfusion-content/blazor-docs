---
layout: post
title: Installing Syncfusion Blazor web installer - Syncfusion
description: Learn here about how to install Syncfusion Blazor web installer after downloading from our Syncfusion website.
platform: Blazor
component: Common
documentation: ug
---

# Installing Syncfusion Blazor Web Installer

I> Starting with 2022 Volume 1 v20.1.0.47, all Syncfusion customers (evaluators and paid customers) who use Syncfusion installers or nuget packages from [nuget.org](https://www.nuget.org/packages?q=Syncfusion) must generate and register the corresponding platform and version license key in your projects.<br>
For more information, please see [this](https://blazor.syncfusion.com/documentation/getting-started/license-key/overview) help topic.

## Installation

The steps below show how to install Essential Studio Blazor Web Installer.

1. Open the Syncfusion Essential Studio Blazor Web Installer file from downloaded location by double-clicking it. The Installer Wizard automatically opens and extracts the package.

   ![Web Installer Setup](images/webinstaller-1.png)

   > **Note** <br /> The installer wizard extracts the syncfusionessentialblazorwebinstaller_{version}.exe dialog, which displays the package’s unzip operation.

2. The Syncfusion Blazor Web Installer’s ***welcome wizard*** will be displayed. Click the Next button.

   ![Web Installer welcome wizard](images/webinstaller-2.png)

3. The ***Platform Selection Wizard*** will appear. From the **Available** tab, select the products to be installed. Select the **Install All** checkbox to install all products.

   ***Available***

   ![Web Installer Available Tab](images/webinstaller-3.png)

   If you have multiple products installed in the same version, they will be listed under the **Installed** tab. You can also select which products to uninstall from the same version. Click the Next button.

   ***Installed***

   ![Web Installer Installed Tab](images/webinstaller-4.png)

   > **IMPORTANT** <br /> If the required software for the selected product isn’t already installed, the **Additional Software Required** alert will appear. However, You can continue the installation and install the necessary software later.

   ***Required Software***

   ![Web Installer Required Software Alert](images/webinstaller-5.png)

4. If previous version(s) for the selected products are installed, the ***Uninstall previous version wizard*** will be displayed. You can see the list of previously installed versions for the products you’ve chosen here. To remove all versions, check the **Uninstall All** checkbox. Click the Next button.

   ![Web Installer Uninstall Previous Wizard](images/webinstaller-6.png)

   > **Note** <br /> From the 2021 Volume 1 release, Syncfusion has provided option to uninstall the previous versions from 18.1 while installing the new version.

5. Pop up screen will be displayed to get the confirmation to uninstall selected previous versions.

   ![Web Installer Uninstall Previous confirmation](images/webinstaller-7.png)

6. The ***Confirmation Wizard*** will appear with the list of products to be installed/uninstalled. You can view and modify the list of products that will be installed and uninstalled from this page.

   ![Web Installer Product install/uninstall list](images/webinstaller-8.png)

   > **Note** <br /> By clicking the **Download Size and Installation** Size links, you can determine the approximate size of the download and installation

7. The ***Configuration Wizard*** will appear. You can change the Download, Install, and Demos locations from here. You can also change the Additional settings on a product-by-product basis. Click Next to install with the default settings.

   ![Web Installer Configuration Wizard](images/webinstaller-9.png)

   ***Additional settings***

   * Select the **Install Demos** check box to install Syncfusion samples, or leave the check box unchecked, if you do not want to install Syncfusion samples.

   * Select the **Configure Syncfusion Extensions controls in Visual Studio** checkbox to configure the Syncfusion Extensions in Visual Studio or clear this check box when you do not want to configure the Syncfusion Extensions in Visual Studio.

   * Check the **Create Desktop Shortcut** checkbox to add a desktop shortcut for Syncfusion Control Panel.

   * Check the **Create Start Menu Shortcut** checkbox to add a shortcut to the start menu for Syncfusion Control Panel.

8. After reading the License Terms and Conditions, check the **I agree to the License Terms and Privacy Policy** check box. Click the Next button.

9. The login wizard will appear. You must enter your Syncfusion email address and password. If you do not already have a Syncfusion account, you can create one by clicking on **Create an Account**. If you have forgotten your password, click **Forgot Password** to create a new one. Click the Install button.

   ![Web Installer Login Wizard](images/webinstaller-10.png)   

10. The download and installation/uninstallation progress will be displayed as shown below.
   ![Web Installer Installation Wizard](images/webinstaller-11.png)
   To open the Syncfusion Control Panel, click **Launch Control Panel**.

11. When the installation is finished, the ***Summary wizard*** will appear. Here you can see the list of products that have been installed successfully and those that have failed. To close the Summary wizard, click Finish.

   ![Web Installer Installation Summary](images/webinstaller-12.png)
12. After installation, there will be two Syncfusion control panel entries, as shown below. The Essential Studio entry will manage all Syncfusion products installed in the same version, while the Product entry will only uninstall the specific product setup.

   ![Control Panel Installation entries](images/webinstaller-13.png)

## Uninstallation

Syncfusion Blazor installer can be uninstalled in two ways.

* Uninstall the Blazor using the Syncfusion Blazor web installer

* Uninstall the Blazor from Windows Control Panel

Follow either one of the option below to uninstall Syncfusion Essential Studio Blazor installer,

**Option 1:** ***Uninstall the Blazor using the Syncfusion Blazor web installer***

Syncfusion provides the option to uninstall products of the same version directly from the Web Installer application. Open the Syncfusion Essential Studio Blazor Online Installer file from downloaded location by double-clicking it. Select the products to be uninstalled from the list, and Web Installer will uninstall them one by one.

![Web Installer Installed Products Uninstall](images/webinstaller-uninstall-2.png)

**Option 2:** ***Uninstall the Blazor from Windows Control Panel***

You can uninstall all the installed products by selecting the **Syncfusion Essential Studio {version}** entry (element 1 in the below screenshot) from the Windows control panel, or you can uninstall Blazor alone by selecting the **Syncfusion Essential Studio for Blazor {version}** entry (element 2 in the below screenshot) from the Windows control panel.

![Control Panel Uninstallation entries](images/webinstaller-uninstall-1.png)

> **Note** <br /> If the **Syncfusion Essential Studio for Blazor {version}** entry is selected from the Windows control panel, the Syncfusion Essential Studio Blazor alone will be removed and the below default MSI uninstallation window will be displayed.

1. The Syncfusion Blazor Web Installer’s ***welcome wizard*** will be displayed. Click the Next button

   ![Web Installer welcome wizard](images/webinstaller-2.png)

2. The ***Platform Selection Wizard*** will appear. From the **Installed** tab, select the products to be uninstalled. To select all products, check the **Uninstall All** checkbox. Click the Next button.

   ***Installed***

   ![Web Installer Installed Products Uninstall](images/webinstaller-uninstall-2.png)

   You can also select the products to be installed from the **Available** tab. Click the Next button.

   ***Available***

   ![Web Installer Uninstall Available Tab](images/webinstaller-uninstall-3.png)

3. If any other products are selected for installation, ***Uninstall previous version wizard*** will be displayed with previous version(s) installed for the selected products. Here you can view the list of installed previous versions for the selected products. Select **Uninstall All** checkbox to select all the versions. Click Next.

   ![Web Installer Uninstall Previous version Wizard](images/webinstaller-uninstall-4.png)

4. Pop up screen will be displayed to get the confirmation to uninstall selected previous versions.

   ![Web Installer Uninstall Previous confirmation](images/webinstaller-7.png)

5. The ***Confirmation Wizard*** will appear with the list of products to be installed/uninstalled. Here you can view and modify the list of products that will be installed/uninstalled.

   ![Web Installer Product Install/Uninstall Wizard](images/webinstaller-uninstall-5.png)

   > **Note** <br /> By clicking the **Download Size and Installation** Size links, you can determine the approximate size of the download and installation.

6. The ***Configuration Wizard*** will appear. You can change the Download, Install, and Demos locations from here. You can also change the Additional settings on a product-by-product basis. Click Next to install with the default settings.

   ![Web Installer Uninstall Configuration Wizard](images/webinstaller-uninstall-6.png)

7. After reading the License Terms and Conditions, check the **I agree to the License Terms and Privacy Policy** check box. Click the Next button.

8. The ***login wizard*** will appear. You must enter your Syncfusion email address and password. If you do not already have a Syncfusion account, you can create one by clicking on **Create an Account**. If you have forgotten your password, click **Forgot Password** to create a new one. Click the Install button.

   ![Web Installer Login Wizard](images/webinstaller-10.png)   

9. The download, installation, and uninstallation processes will be shown.

   ![Web Installer Uninstallation Wizard](images/webinstaller-uninstall-7.png)

10. When the installation is finished, the ***Summary wizard*** will appear. Here you can see the list of products that have been successfully and unsuccessfully installed/uninstalled. To close the Summary wizard, click Finish.

   ![Web Installer Uninstallation Summary](images/webinstaller-uninstall-8.png)

* To open the Syncfusion Control Panel, click **Launch Control Panel**.