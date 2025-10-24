---
layout: post
title: License and unlock keys overview | Syncfusion
description: Understand Syncfusion license keys versus installer unlock keys, when license registration is required for NuGet, evaluation scenarios, build server guidance.
platform: Blazor
control: Common
documentation: ug
---

# Syncfusion<sup style="font-size:70%">&reg;</sup> licensing overview

Syncfusion<sup style="font-size:70%">&reg;</sup> license key registration applies to all evaluators and to paid customers who use Syncfusion<sup style="font-size:70%">&reg;</sup> packages from [NuGet.org](https://www.nuget.org/packages?q=syncfusion). When referencing Syncfusion<sup style="font-size:70%">&reg;</sup> assemblies via the evaluation installer or the NuGet feed, register the corresponding platform and version-specific license key in each project.

The following validation message appears if the license key is not registered when using assemblies from the evaluation installer or from [NuGet.org](https://www.nuget.org/packages?q=syncfusion).

N> This application was built using a trial version of Syncfusion<sup style="font-size:70%">&reg;</sup> Essential Studio<sup style="font-size:70%">&reg;</sup>. Include a valid license to permanently remove this license validation message. You can also obtain a free 30‑day evaluation license to temporarily remove this message during the evaluation period. See Licensing errors: [license key not registered](https://blazor.syncfusion.com/documentation/getting-started/license-key/licensing-errors#license-key-not-registered).

## Difference between unlock key and license key

The license key is different from the installer unlock key and must be generated separately from the Syncfusion<sup style="font-size:70%">&reg;</sup> website.

* **Unlock key** - Used only to unlock Syncfusion<sup style="font-size:70%">&reg;</sup> installers.

* **License key** - A string registered in your project to avoid licensing warnings.

N> See difference between the [unlock key and licensing key](https://support.syncfusion.com/kb/article/7863/difference-between-the-unlock-key-and-licensing-key).

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> license keys on build servers

| Source of Syncfusion<sup style="font-size:70%">&reg;</sup> assemblies | Details | License Key needs to be registered? | Where to get license key from |
| ------------- | ------------- | ------------- | ------------- |
| **NuGet package** | If the Syncfusion<sup style="font-size:70%">&reg;</sup> assemblies used in Build Server were from the Syncfusion<sup style="font-size:70%">&reg;</sup> NuGet packages, then no need to install any Syncfusion<sup style="font-size:70%">&reg;</sup> installer. We can directly use the required Syncfusion<sup style="font-size:70%">&reg;</sup> NuGet packages at [nuget.org](https://www.nuget.org/). <br><br>But, if using NuGet packages from the [nuget.org](https://www.nuget.org/packages?q=syncfusion), then we should register the Syncfusion<sup style="font-size:70%">&reg;</sup> license key in the application.| Yes | Use any developer license to [generate](https://blazor.syncfusion.com/documentation/getting-started/license-key/how-to-generate) keys for Build Environments as well. |
| **Trial installer** | If the Syncfusion<sup style="font-size:70%">&reg;</sup> assemblies used in Build Server were from Trial Installer, we should register the license key in the application for the corresponding version and platforms, to avoid trial license warning. | Yes | Use any developer trial license to [generate](https://blazor.syncfusion.com/documentation/getting-started/license-key/how-to-generate) keys for Build Environments as well. |
| **Licensed installer** |If the Syncfusion<sup style="font-size:70%">&reg;</sup> assemblies used in Build Server were from Licensed Installer, then there is no need to register the license keys.<br><br>You can [download](https://blazor.syncfusion.com/documentation/installation/web-installer/how-to-download#download-the-licensed-version) and [install](https://blazor.syncfusion.com/documentation/installation/web-installer/how-to-install) the licensed version of our installer. | No | Not applicable |

You can [download](https://blazor.syncfusion.com/documentation/installation/web-installer/how-to-download#download-the-licensed-version) and [install](https://blazor.syncfusion.com/documentation/installation/web-installer/how-to-install) the licensed version of our installer.

## See also

* [Generate a Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor license key](https://blazor.syncfusion.com/documentation/getting-started/license-key/how-to-generate)
* [Register a Syncfusion<sup style="font-size:70%">&reg;</sup> license key in a Blazor application](https://blazor.syncfusion.com/documentation/getting-started/license-key/how-to-register-in-an-application)
* [Register a Syncfusion<sup style="font-size:70%">&reg;</sup> license key in a Razor Class Library](https://blazor.syncfusion.com/documentation/getting-started/license-key/how-to-register-in-a-razor-class-library)
