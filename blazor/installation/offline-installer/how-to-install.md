---
layout: post
title: Installing Syncfusion Blazor installer - Syncfusion
description: Learn here about the how to install Syncfusion Blazor offline installer.
platform: Blazor
component: Common
documentation: ug
---

# Installing Syncfusion Blazor offline installer

## Installing with UI

The steps below show how to install the Essential Studio Blazor installer.

1. Open the Syncfusion Blazor offline installer file from downloaded location by double-clicking it. The Installer Wizard automatically opens and extracts the package

   ![Web Offline Installer Setup wizard](images/webofflineinstaller-1.png)

   > **Note** <br /> The Installer wizard extracts the syncfusionessentialblazor_(version).exe dialog, which displays the package’s unzip operation.

2. To unlock the Syncfusion offline installer, you have two options:

   * *Login To Install*
   * *Use Unlock Key*

   **Login To Install:**

   You must enter your Syncfusion email address and password. If you don’t already have a Syncfusion account, you can sign up for one by clicking "**Create an account**". If you have forgotten your password, click on "**Forgot Password**" to create a new one. Once you’ve entered your Syncfusion email and password, click Next.

   ![Web Offline Installer LoginToInstall Wizard](images/webofflineinstaller-2.png)

   **Use Unlock Key:**

   Unlock keys are used to unlock the Syncfusion offline installer, and they are platform and version specific. You should use either Syncfusion licensed or trial Unlock key to unlock Syncfusion Blazor installer.

   The trial unlock key is only valid for 30 days, and the installer will not accept an expired trial key.

   To learn how to generate an unlock key for both trial and licensed products, see [this](https://www.syncfusion.com/kb/2326) Knowledge Base article.

   ![Web Offline Installer UseUnlockKey Wizard](images/webofflineinstaller-3.png)

3. After reading the License Terms and Privacy Policy, check the "**I agree to the License Terms and Privacy Policy**" check box. Click the Next button.

4. Change the install and sample locations here. You can also change the Additional settings. Click Next\Install to install with the default settings.

   ![Web Offline Installer Settings Wizard](images/webofflineinstaller-4.png)

   ***Additional Settings***

   * Select the **Install Demos** check box to install Syncfusion samples, or leave the check box unchecked, if you do not want to install Syncfusion samples.

   * Select the **Configure Syncfusion Extensions controls in Visual Studio** checkbox to configure the Syncfusion Extensions in Visual Studio or clear this check box when you do not want to configure the Syncfusion Extensions in Visual Studio.

   * Check the **Create Desktop Shortcut** checkbox to add a desktop shortcut for Syncfusion Control Panel.

   * Check the **Create Start Menu Shortcut** checkbox to add a shortcut to the start menu for Syncfusion Control Panel.

5. If any previous versions of the current product is installed, the Uninstall Previous Version(s) wizard will be opened. Select **Uninstall** checkbox to uninstall the previous versions and then click the Proceed button.

   ![Web Offline Installer Uninstall Previous Wizard](images/webofflineinstaller-5.png)

   > **Note** <br /> From the 2021 Volume 1 release, Syncfusion has added the option to uninstall previous versions from 18.1 while installing the new version. <br /> <br /> If any version is selected to uninstall, a confirmation screen will appear; if continue is selected, the Progress screen will display the uninstall and install progress, respectively. If none of the versions are chosen to be uninstalled, only the installation progress will be displayed.

   **Confirmation Alert:**

   ![Web Offline Installer Confirmation Alert](images/webofflineinstaller-6.png)

   **Uninstall Progress:**

   ![Web Offline Installer Uninstall Progress Wizard](images/webofflineinstaller-7.png)

   ***Install Progress***

   ![Web Offline Installer Progress Wizard](images/webofflineinstaller-8.png)

   > **Note** <br /> The Completed screen is displayed once the Blazor product is installed. If any version is selected to uninstall, The completed screen will display both install and uninstall status.

   ![Web Offline Installer Summary Wizard](images/webofflineinstaller-9.png)

6. After installing, click the **Launch Control Panel** link to open the Syncfusion Control Panel.

7. Click the Finish button. Your system has been installed with the Syncfusion Essential Studio Blazor product.

## Installing in Silent Mode

The Syncfusion Essential Studio Blazor Installer supports installation and uninstallation via the command line.

***Command Line Installation***

To install through the Command Line in Silent mode, follow the steps below.

1. Run the Syncfusion Blazor installer by double-clicking it. The Installer Wizard automatically opens and extracts the package.

2. The file syncfusionessentialblazor_(version).exe file will be extracted into the Temp directory.

3. Run %temp%. The Temp folder will be opened. The syncfusionessentialblazor_(version).exe file will be located in one of the folders.

4. Copy the extracted syncfusionessentialblazor_(version).exe file in local drive.

5. Exit the Wizard.

6. Run Command Prompt in administrator mode and enter the following arguments.

   **Arguments:** "installer file path\SyncfusionEssentialStudio(product)_(version).exe" /Install silent /UNLOCKKEY:"(product unlock key)" [/   log "{Log file path}"] [/InstallPath:{Location to install}] [/InstallSamples:{true/false}] [/CreateShortcut:{true/false}] [/   CreateStartMenuShortcut:{true/false}]

   > **Note** <br /> [..] – Arguments inside the square brackets are optional.

   **Example:** "D:\Temp\syncfusionessentialblazor_x.x.x.x.exe" /Install silent /UNLOCKKEY:"product unlock key" /log    "C:\Temp\EssentialStudio_Product.log" /InstallPath:C:\Syncfusion\x.x.x.x /InstallSamples:true /CreateShortcut:true /   CreateStartMenuShortcut:true

7. Essential Studio for Blazor is installed.

> **Note** <br /> x.x.x.x should be replaced with the Essential Studio version and the Product Unlock Key needs to be replaced with the Unlock Key for that version.

## Command Line Uninstallation

Syncfusion Essential Blazor can be uninstalled silently using the Command Line.

1. Run the Syncfusion Blazor installer by double-clicking it. The Installer Wizard automatically opens and extracts the package.

2. The file syncfusionessentialblazor_(version).exe file will be extracted into the Temp directory.

3. Run %temp%. The Temp folder will be opened. The syncfusionessentialblazor_(version).exe file will be located in one of the folders.

4. Copy the extracted syncfusionessentialblazor_(version).exe file in local drive.

5. Exit the Wizard.

6. Run Command Prompt in administrator mode and enter the following arguments.<br /> <br />
**Arguments:** "Copied installer file path\syncfusionessentialblazor_(version).exe" /uninstall silent <br /> <br />
**Example:** "D:\Temp\syncfusionessentialblazor_x.x.x.x.exe" /uninstall silent

7. Essential Studio for Blazor is uninstalled.
