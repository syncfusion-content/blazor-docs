---
layout: post
title: Overview of Syncfusion license and unlock keys - Syncfusion
description: Learn here about the Syncfusion license and unlock keys and difference between license and unlock keys.
platform: Blazor
component: Common
documentation: ug
---

# Syncfusion&reg; Licensing Overview

Syncfusion&reg; license key registration is applicable for all evaluators and only to paid customers who use NuGet packages from [NuGet.org](https://www.nuget.org/packages?q=syncfusion). So, if you use the evaluation installer or the NuGet feed to reference Syncfusion&reg; assemblies, you must also include the corresponding platform and version license key in your projects

Following licensing error will be shown if the license key is not registered in your projects while using assemblies from evaluation installer or from the [nuget.org](https://www.nuget.org/packages?q=syncfusion).

N> This application was built using a trial version of Syncfusion&reg; Essential Studio&reg;. Include a valid license to permanently remove this license validation message. You can also obtain a free 30 day evaluation license to temporarily remove this message during the evaluation period. Refer to this [help topic](https://blazor.syncfusion.com/documentation/getting-started/license-key/licensing-errors#license-key-not-registered) for more information.

## Difference between unlock key and license key

Note that this license key is different from the installer unlock key that you might have used in the past and needs to be separately generated from Syncfusion&reg; website.

* **Unlock Key** - Syncfusion&reg; Unlock Key is used to unlock the Syncfusion&reg; installers alone.

* **License Key** - Syncfusion&reg; License Key is just a string that needs to be registered in your project to avoid licensing warning.

N> Refer to [this](https://support.syncfusion.com/kb/article/7863/difference-between-the-unlock-key-and-licensing-key) KB article to know more about difference between the Syncfusion&reg; Unlock Key and the Syncfusion&reg; License Key.

## Registering Syncfusion&reg; license keys in Build server

| Source of Syncfusion&reg; assemblies | Details | License Key needs to be registered? | Where to get license key from |
| ------------- | ------------- | ------------- | ------------- |
| **NuGet package** | If the Syncfusion&reg; assemblies used in Build Server were from the Syncfusion&reg; NuGet packages, then no need to install any Syncfusion&reg; installer. We can directly use the required Syncfusion&reg; NuGet packages at [nuget.org](https://www.nuget.org/). <br><br>But, if using NuGet packages from the [nuget.org](https://www.nuget.org/packages?q=syncfusion), then we should register the Syncfusion&reg; license key in the application.| Yes | Use any developer license to [generate](https://blazor.syncfusion.com/documentation/getting-started/license-key/how-to-generate) keys for Build Environments as well. |
| **Trial installer** | If the Syncfusion&reg; assemblies used in Build Server were from Trial Installer, we should register the license key in the application for the corresponding version and platforms, to avoid trial license warning. | Yes | Use any developer trial license to [generate](https://blazor.syncfusion.com/documentation/getting-started/license-key/how-to-generate) keys for Build Environments as well. |
| **Licensed installer** |If the Syncfusion&reg; assemblies used in Build Server were from Licensed Installer, then there is no need to register the license keys.<br><br>You can [download](https://blazor.syncfusion.com/documentation/installation/web-installer/how-to-download#download-the-licensed-version) and [install](https://blazor.syncfusion.com/documentation/installation/web-installer/how-to-install) the licensed version of our installer. | No | Not applicable |

You can [download](https://blazor.syncfusion.com/documentation/installation/web-installer/how-to-download#download-the-licensed-version) and [install](https://blazor.syncfusion.com/documentation/installation/web-installer/how-to-install) the licensed version of our installer.

## See Also

* [How to Generate Syncfusion&reg; Blazor License Key?](https://blazor.syncfusion.com/documentation/getting-started/license-key/how-to-generate)
* [How to Register Syncfusion&reg; License Key in Blazor Application?](https://blazor.syncfusion.com/documentation/getting-started/license-key/how-to-register-in-an-application)
* [How to Register Syncfusion&reg; License Key in Razor Class Library Application?](https://blazor.syncfusion.com/documentation/getting-started/license-key/how-to-register-in-a-razor-class-library)
