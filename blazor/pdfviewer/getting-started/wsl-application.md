---
layout: post
title: Getting Started with PDF Viewer in Blazor WSL mode | Syncfusion
description: Learn how to getting started with PDF Viewer control in Blazor WSL (Windows Subsystem for Linux) mode. 
platform: Blazor
control: PDF Viewer
documentation: ug
---

# Getting Started with Blazor PDF Viewer Component in WSL mode

To run the Syncfusion Blazor PDF Viewer in WSL (Windows Subsystem for Linux) mode, you will need to take the following steps:

**Step 1:** Enable the Windows Subsystem for Linux.

![Create-new-blazor-wsl-app](GettingStarted_images/enable-wsl-mode.png)

To enable the Windows Subsystem for Linux (WSL) on Windows, follow these steps:

Open the Start menu and search for `Control Panel`.Click on `Programs` now click on `Turn Windows features on or off`scroll down and check the box next to `Windows Subsystem for Linux`. Click `OK` and restart your machine

After your computer restarts, you will be able to install a Linux distribution from the Microsoft Store, such as ubuntu, and run Linux commands directly in Windows.

**Step 2:** Install the `ubuntu`

![Create-new-blazor-wsl-app](GettingStarted_images/ubuntu-install.png)

ubuntu can be installed on a Windows 10 machine through the Microsoft Store. Here are the steps to do so:

Open the Microsoft Store on your Windows 10 machine, Search for `ubuntu` in the store. Select `ubuntu` from the search results and click `Get` to begin the installation.

Once the installation is complete, open the Windows Terminal application. In the terminal, type `ubuntu` and press enter. This will launch the `ubuntu terminal inside of Windows.

And create a new user with a username and password on ubuntu

**Step 3:** Install the dotnet framework for running the WSL (Windows Subsystem for Linux) in the project use the following code one by one to install the net6.0 dotnet sdk.

```
    wget https://packages.microsoft.com/config/ubuntu/22.10/packages-microsoft-prod.deb -O packages-microsoft-prod.deb

    sudo dpkg -i packages-microsoft-prod.deb

    rm packages-microsoft-prod.deb

    sudo apt-get update && \
    sudo apt-get install -y dotnet-sdk-6.0

```

Check the comment dotnet –info and it should come like below

![Create-new-blazor-wsl-app](dotnet-info.png)

If the above result is not shown, Please run the comments below or follow the steps in the link below to uninstall and reinstall dotnet. 
```
    sudo apt remove dotnet*
    sudo apt remove aspnetcore*
    sudo apt remove netstandard*
    sudo apt-get remove dotnet-host
    sudo apt autoremove
    sudo apt autoremove -y dotnet-sdk-6.0
    sudo apt-get update
    dotnet
    sudo apt-get install -y dotnet-sdk-6.0
    dotnet
    dotnet --info

```
**Step 4:** Run the sample in WSL mode and it will run our Blazor PDF Viewer.

N> Facing any issue while running in WSL mode use the following instruction to resolve the issue.

Sample does not load the PDF file and throws an exception like below in console window. 

Use the following codes to install the dependence need for our Blazor PDF Viewer run to fix the issue.

Open the ubuntu comment window and type the following comments.

```
    sudo cp -u /lib/x86_64-linux-gnu/libdl.so.2 /lib/x86_64-linux-gnu/libdl.so
```
In Blazor PDF Viewer uses libdl.so. It’s a different name in different WSL Linux versions. Need to check its presence in the 
\wsl.localhost\Ubuntu\usr\lib\x86_64-linux-gnu location like below.

If it’s in different name like libdl.so.4 then change the comment like below.

```
sudo cp -u /lib/x86_64-linux-gnu/libdl.so.4 /lib/x86_64-linux-gnu/libdl.so
```

Then run the following comment one by one in the ubuntu command window to install all necessary Blazor PDF Viewer dependencies for a run in Linux.

```

    sudo apt-get install libfontconfig1
    sudo apt-get update && apt-get install -y --allow-unauthenticated libgdiplus libc6-dev libx11-dev
    sudo apt-get update
    sudo apt install libgdiplus

```
Close the project, reopen and run in WSL mode. It will run properly.