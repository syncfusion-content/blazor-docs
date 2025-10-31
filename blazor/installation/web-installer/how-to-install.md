---
layout: post
title: Install the Syncfusion Blazor web installer | Syncfusion
description: Learn here about how to install the Syncfusion Blazor web installer, configure products, and manage the uninstall options. Explore here to more details.
platform: Blazor
control: Common
documentation: ug
---

# Install the Syncfusion® Blazor web installer

## Installation

The steps below show how to install the Essential Studio<sup style="font-size:70%">&reg;</sup> Blazor web installer.

1. Open the Syncfusion<sup style="font-size:70%">&reg;</sup> Essential Studio<sup style="font-size:70%">&reg;</sup> Blazor web installer (.exe) from the download location by double‑clicking it. The installer wizard opens and extracts the package.

   ![Web installer setup extracting package](images/webinstaller-1.png)

   N> The installer extracts syncfusionessentialblazorwebinstaller_{version}.exe and displays the extraction progress.

2. The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Web Installer’s ***welcome wizard*** will be displayed. Click **Next** button.

   ![Web Installer welcome wizard](images/webinstaller-2.png)

3. The ***Platform selection wizard*** appears. On the **Available** tab, select the products to install. To install all products, click **Install All**.

   ***Available***

   ![Platform selection wizard Available tab](images/webinstaller-3.png)

   If multiple products are already installed for the same version, they are listed under the **Installed** tab. You can also select products to uninstall from that version. Click **Next**.

   ***Installed***

   ![Platform selection wizard Installed tab](images/webinstaller-4.png)

   I> If required software for a selected product is missing, an **Additional Software Required** alert appears. You can, however, continue the installation and install the necessary software later.

   ***Required Software***

   ![Web Installer Required Software Alert](images/webinstaller-5.png)

4. If previous versions of selected products are detected, the Uninstall previous versions wizard is displayed. Review the list and select **Uninstall All** to remove all prior versions. Click **Next**.

   ![Web Installer Uninstall Previous Wizard](images/webinstaller-6.png)

   N> From the 2021 Volume 1 release, Syncfusion<sup style="font-size:70%">&reg;</sup> has provided option to uninstall the previous versions from 18.1 while installing the new version.

5. A confirmation dialog is shown to uninstall the selected previous versions.

   ![Web Installer Uninstall Previous confirmation](images/webinstaller-7.png)

6. The ***Confirmation wizard*** lists products to be installed or uninstalled. Review and modify the list as needed.

   ![Web Installer Product install/uninstall list](images/webinstaller-8.png)

   N> Click the **Download size** and **Installation size** links to view approximate sizes.

7. The ***Configuration Wizard*** will appear. You can change the Download, Install, and Demos locations from here. You can also change the Additional settings on a product-by-product basis. Click **Next** to install with the default settings.

   ![Web Installer Configuration Wizard](images/webinstaller-9.png)

   ***Additional settings***

   * Select **Install demos** to install Syncfusion samples, or clear it to skip sample installation.

   * Select **Configure Syncfusion extensions in Visual Studio** to configure extensions, or clear it to skip configuration.

   * Select **Create Desktop Shortcut** to add a shortcut for Syncfusion<sup style="font-size:70%">&reg;</sup> Control Panel.

   * Select **Create Start Menu Shortcut** to add a shortcut to the Start menu entry for Syncfusion<sup style="font-size:70%">&reg;</sup> Control Panel.

8. Read the License Terms and Privacy Policy, then select **I agree to the License Terms and Privacy Policy**. Click **Next**.

9. The Login wizard appears. Enter the Syncfusion account email and password. To create an account, select **Create an account**. To reset a password, select **Forgot password**. Click **Install**.

   ![Web Installer Login Wizard](images/webinstaller-10.png)

   I> Products are installed based on your syncfusion<sup style="font-size:70%">&reg;</sup> license (trial or licensed).

10. The download, installation, and uninstallation progress is displayed.
   ![Installation progress showing download and install status](images/webinstaller-11.png)
   To open the Syncfusion<sup style="font-size:70%">&reg;</sup> Control Panel, click **Launch Control Panel**.

11. When the installation is finished, the ***Summary wizard*** will appear. Here you can see the list of products that have been installed successfully and those that have failed. To close the Summary wizard, click **Finish**.

   ![Web Installer Installation Summary](images/webinstaller-12.png)

12. After installation, there will be two Syncfusion<sup style="font-size:70%">&reg;</sup> control panel entries, as shown below. The Essential Studio<sup style="font-size:70%">&reg;</sup> entry will manage all Syncfusion<sup style="font-size:70%">&reg;</sup> products installed in the same version, while the Product entry will only uninstall the specific product setup.

   ![Control Panel Installation entries](images/webinstaller-13.png)

## Uninstallation

Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor can be uninstalled in two ways.

* Uninstall using the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor web installer

* Uninstall from Windows Control Panel

Follow one of the options below to uninstall the Syncfusion<sup style="font-size:70%">&reg;</sup> Essential Studio<sup style="font-size:70%">&reg;</sup> Blazor installer.

**Option 1:** Uninstall using the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor web installer

Syncfusion<sup style="font-size:70%">&reg;</sup> provides the option to uninstall products of the same version directly from the Web Installer application. Open the Syncfusion<sup style="font-size:70%">&reg;</sup> Essential Studio<sup style="font-size:70%">&reg;</sup> Blazor Online Installer file from downloaded location by double-clicking it. Select the products to be uninstalled from the list, and Web Installer will uninstall them one by one.

![Web Installer Installed Products Uninstall](images/webinstaller-uninstall-2.png)

**Option 2:** Uninstall from Windows Control Panel

You can uninstall all the installed products by selecting the **Syncfusion<sup style="font-size:70%">&reg;</sup> Essential Studio<sup style="font-size:70%">&reg;</sup> {version}** entry (element 1 in the below screenshot) from the Windows control panel, or you can uninstall Blazor alone by selecting the **Syncfusion<sup style="font-size:70%">&reg;</sup> Essential Studio<sup style="font-size:70%">&reg;</sup> for Blazor {version}** entry (element 2 in the below screenshot) from the Windows control panel.

![Control Panel Uninstallation entries](images/webinstaller-uninstall-1.png)

N> If the **Syncfusion<sup style="font-size:70%">&reg;</sup> Essential Studio<sup style="font-size:70%">&reg;</sup> for Blazor {version}** entry is selected from the Windows control panel, the Syncfusion<sup style="font-size:70%">&reg;</sup> Essential Studio<sup style="font-size:70%">&reg;</sup> Blazor alone will be removed and the below default MSI uninstallation window will be displayed.

1. The Blazor web installer **Welcome wizard** is displayed. Click **Next**.

   ![Web Installer welcome wizard](images/webinstaller-2.png)

2. The **Platform selection wizard** appears. On the **Installed** tab, select products to uninstall. To uninstall all, select **Uninstall All**. Click **Next**.

   ***Installed***

   ![Web Installer Installed Products Uninstall](images/webinstaller-uninstall-2.png)

   You can also select products to install from the **Available** tab. Click **Next**.

   ***Available***

   ![Web Installer Uninstall Available Tab](images/webinstaller-uninstall-3.png)

3. If other products are selected for installation, the ***Uninstall previous versions wizard*** shows any installed previous versions for those products. Select **Uninstall All** to remove all versions. Click **Next**.

   ![Web Installer Uninstall Previous version Wizard](images/webinstaller-uninstall-4.png)

4. A confirmation dialog is shown to uninstall the selected previous versions.

   ![Web Installer Uninstall Previous confirmation](images/webinstaller-7.png)

5. The **Confirmation Wizard** lists products to be installed or uninstalled. Review and modify as needed.

   ![Web Installer Product Install/Uninstall Wizard](images/webinstaller-uninstall-5.png)

   N> By clicking the **Download Size and Installation** Size links, you can determine the approximate size of the download and installation.

6. The ***Configuration Wizard*** will appear. You can change the Download, Install, and Demos locations from here. You can also change the Additional settings on a product-by-product basis. Click **Next** to install with the default settings.

   ![Web Installer Uninstall Configuration Wizard](images/webinstaller-uninstall-6.png)

7. Read the License Terms and Privacy Policy, then select **I agree to the License Terms and Privacy Policy**. Select **Next**.

8. The **Login Wizard** appears. Enter the Syncfusion<sup style="font-size:70%">&reg;</sup> account email and password, or select **Create an account** or **Forgot password**. Click **Install**.

   ![Web Installer Login Wizard](images/webinstaller-10.png)

   I> The products you have chosen will be installed based on your Syncfusion<sup style="font-size:70%">&reg;</sup> License (Trial or Licensed).

9. The download, installation, and uninstallation progress is shown.

   ![Web Installer Uninstallation Wizard](images/webinstaller-uninstall-7.png)

10. When the installation is finished, the ***Summary wizard*** will appear. Here you can see the list of products that have been successfully and unsuccessfully installed/uninstalled. To close the Summary wizard, click **Finish**.

   ![Web Installer Uninstallation Summary](images/webinstaller-uninstall-8.png)

* To open the Syncfusion<sup style="font-size:70%">&reg;</sup> Control Panel, click **Launch Control Panel**.
