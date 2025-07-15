
# Secure Registration of Syncfusion License Keys in Blazor WebAssembly Applications

Securely managing license keys in Blazor WebAssembly (WASM) applications is essential to prevent unauthorized access and ensure compliance. Registering a license key in the `Program.cs` file exposes it in the browser through DLLs, creating security risks.

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
- **Private Repository Manager:** Host and manage packages using a private NuGet repository manager like Nexus.

## Securely manage Syncfusion license keys using Azure Key Vault

You can integrate Azure Key Vault into your application to retrieve the license key at runtime, ensuring it is never exposed in the browser or stored in the client-side code.

For enhanced security, especially in cloud-hosted environments, store and access license keys securely using Azure Key Vault. This method keeps sensitive information out of your source code and configuration files.

Integrate Azure Key Vault to retrieve the license key at runtime, preventing browser exposure or storage in client-side code.

For detailed steps, refer to:
[Securely Store and Use Syncfusion License Keys in Azure Key Vault](https://help.syncfusion.com/common/essential-studio/licensing/licensing-faq/how-to-securely-store-and-use-syncfusion-license-keys-in-azure-key-vault)
