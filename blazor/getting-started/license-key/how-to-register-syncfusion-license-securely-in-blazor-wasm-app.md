---
layout: post
title: How to Register Syncfusion License Key Securely in Blazor WASM App?
description: Learn how to securely register a Syncfusion license key in your Blazor WebAssembly (WASM) application.
platform: Blazor
component: Common
documentation: ug
---

# Secure Registration of Syncfusion License Keys in Blazor Wasm App

Registering a license key directly in the Program.cs file of a Blazor WebAssembly Client project can expose it through the compiled assemblies, making it accessible in the browser, creating security risks.

## Recommended Solution: Use Licensed NuGet Packages

Syncfusion recommends using licensed NuGet packages, distributed with the licensed Blazor Product in Volume and Service Pack (SP) releases. These packages eliminate the need to register the license key in the application code.

### Benefits of Using Licensed NuGet Packages

- **Enhanced Security:** Prevents license key exposure in the browser.
- **Simplified Deployment:** Removes the need for manual license key registration.

## Reference: Syncfusion Blazor Web Installer User Guide

Refer to the Syncfusion documentation to download and install the licensed Blazor Product:

- [Download Instructions](https://blazor.syncfusion.com/documentation/installation/web-installer/how-to-download)
- [Installation Guide](https://blazor.syncfusion.com/documentation/installation/web-installer/how-to-install)

These steps ensure secure and compliant Blazor WASM applications, preventing license key exposure.

## Using Licensed NuGet Packages

Build your Blazor WASM application using licensed NuGet packages from these sources:

- **Local Folder:** Store packages locally and configure your project for restoration.
- **Private Repository Manager:** Host and manage packages using a private NuGet repository manager like Nexus, Azure DevOps artifact feed.


>**Important Note:**  
> When referencing both a local folder or private repository and `nuget.org` in your `NuGet.config`, and if both sources contain the same version of Syncfusion packages, the build may default to restoring from `nuget.org` (trial versions). This fallback can result in **license popup issues**.

### Use Package Source Mapping
To ensure your project always restores Syncfusion packages from the licensed source, configure [Package Source Mapping](https://learn.microsoft.com/en-us/nuget/consume-packages/package-source-mapping) in your `NuGet.config`:

```xml
<configuration>
  <packageSources>
    <add key="licensed-nuget" value="path/to/your/nuget-source" />
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" />
  </packageSources>
  <packageSourceMapping>
    <packageSource key="licensed-nuget">
      <package pattern="Syncfusion.*" />
    </packageSource>
  </packageSourceMapping>
</configuration>
```

### Verifying Assembly Licensing

To confirm whether your application is referencing licensed or trial assemblies:

* Navigate to your build output directory and Locate the Syncfusion assemblies.

* Right-click on each assemblies → Select Properties → Go to the Details tab.

* Check the File Description:

    * If it includes “LR”, it’s a trial version.

        ![trail dll preview](images/trial.png)

    * If it does not include “LR”, it’s a licensed version.

        ![licensed dll](images/licensed.png)


If trial assemblies are detected in your application, follow these steps to ensure a clean and licensed setup:

Clear the NuGet cache to remove any previously downloaded trial packages:
```bash
dotnet nuget locals all --clear
```


Delete the **bin and obj**  folders from your project directories to remove any cached build artifacts.

Uninstall and reinstall the Syncfusion packages, making sure they are restored only from your licensed NuGet source.

## Securely manage Syncfusion license keys using Azure Key Vault

You can integrate Azure Key Vault into your application to retrieve the license key at runtime, ensuring it is never exposed in the browser or stored in the client-side code.

For enhanced security, especially in cloud-hosted environments, store and access license keys securely using Azure Key Vault. This method keeps sensitive information out of your source code and configuration files.

Integrate Azure Key Vault to retrieve the license key at runtime, preventing browser exposure or storage in client-side code.

For detailed steps, refer to:
[Securely Store and Use Syncfusion License Keys in Azure Key Vault](https://help.syncfusion.com/common/essential-studio/licensing/licensing-faq/how-to-securely-store-and-use-syncfusion-license-keys-in-azure-key-vault)