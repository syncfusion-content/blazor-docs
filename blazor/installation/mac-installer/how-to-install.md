---
layout: post
title: Install the Blazor Mac installer | Syncfusion®
description: Learn here about how to install the Blazor Mac installer (DMG), handle macOS Gatekeeper prompts, and register license keys in sample projects.
platform: Blazor
control: Common
documentation: ug
---

# Install the Syncfusion® Blazor Mac installer

The Essential Studio<sup style="font-size:70%">&reg;</sup> Blazor Mac installer installs the Blazor product on macOS (DMG) and integrates with Visual Studio for Mac. The steps below cover Gatekeeper prompts, installation, and license key registration for sample projects.

## Prerequisites

Before you begin, confirm the following:

* A supported version of macOS is installed. See the [.NET supported OS list](https://learn.microsoft.com/en-us/dotnet/core/install/macos) for details.
* The .NET SDK that matches the target Syncfusion Blazor version is installed and available on `PATH`. Verify with `dotnet --version`.
* You have administrator rights on the Mac to install applications and modify security settings.
* The downloaded Blazor Mac installer DMG is available locally. If you have not downloaded it yet, see [Download the Blazor Mac installer](https://blazor.syncfusion.com/documentation/installation/mac-installer/how-to-download).
* Visual Studio for Mac is installed if you intend to open the included sample projects. See [Install Visual Studio for Mac](https://learn.microsoft.com/en-us/visualstudio/mac/installation) for details.

## Resolve the Gatekeeper warning on macOS Catalina or later

When running the installer on macOS Catalina or later, a Gatekeeper alert may appear.

![macOS Gatekeeper alert for the DMG](images/Mac_Catalina_MacOS_Alert1.webp)

If this appears, follow these steps:

1. Right‑click the downloaded DMG file.
2. Select **Open** and choose **DiskImageMounter (Default)**. The following prompt appears.

   ![macOS prompt to open the DMG with DiskImageMounter](images/Mac_Catalina_MacOS_Alert2.webp)

3. Select **Open** to mount the DMG and continue.

## Install on macOS

1. Locate the downloaded DMG file and double‑click it to open.

   ![Open the downloaded Blazor DMG](images/Mac_Installer1.webp)

2. The disk image mounts and a virtual drive appears on the desktop or in the Finder sidebar.

   ![Mounted DMG drive visible in Finder](images/Mac_Installer2.webp)

3. Copy the Syncfusion Blazor (version) folder from the mounted disk.

   ![Drag the app to Applications](images/Mac_Installer3.webp)

   N> An unlock key is not required to install the Essential Studio<sup style="font-size:70%">&reg;</sup> Blazor Mac installer.

4. Paste the copied folder into the **Applications** folder.
5. Navigate to **Applications** > **Syncfusion** > {{ site.releaseversion }} > **Blazor**, and launch the installer app.

   ![Launch the Blazor installer app from Applications](images/Mac_Installer5.webp)

6. Eject the mounted DMG by right‑clicking the virtual drive (on the desktop or in the Finder sidebar) and selecting **Eject**. If you no longer need the downloaded DMG file, move it to the Trash.

   ![Eject the mounted DMG from Finder](images/Mac_Installer6.webp)

## Register the license key in sample projects

After installation, a license key is required to register the demo source included in the Mac installer. The license key is applied in the entry point of your Blazor application.

* **Blazor Server App**: Register the license key in the `Program.cs` file. For more information, refer to the [Blazor Server App](https://blazor.syncfusion.com/documentation/getting-started/license-key/how-to-register-in-an-application#blazor-web-app-interactive-server) section.
* **Blazor WebAssembly App**: Register the license key in the `Program.cs` file. For more information, refer to the [Blazor WebAssembly App](https://blazor.syncfusion.com/documentation/getting-started/license-key/how-to-register-in-an-application#blazor-web-app-interactive-webassembly) section.
* **Blazor Web App**: Register the license key in the `Program.cs` file based on the configured interactive render mode (`Server`, `WebAssembly`, or `Auto`). For more information, refer to the [Blazor Web App](https://blazor.syncfusion.com/documentation/getting-started/license-key/how-to-register-in-an-application#blazor-web-app-interactive-auto) section.

For the complete registration steps, see [Register the license key in an application](https://blazor.syncfusion.com/documentation/getting-started/license-key/how-to-register-in-an-application).

## Getting Started

To learn how to use the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components in your application on macOS, refer to the following getting started topics:

* Getting started with [Blazor Server App](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio).
* Getting started with [Blazor WebAssembly App](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app).
* Getting started with [Blazor Web App](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app).
