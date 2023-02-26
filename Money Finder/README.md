# Development setup process
### Step 1: Having a new virtual machine on a cloud platform such as Azure, AWS, or Google Cloud.

### Step 2: Install the latest version of the .NET 6 Framework and IIS on the virtual machine.
#### Steps to install .NET Framework 6
1. Download the .NET 6 Framework installer from the Microsoft [website](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).
1. Follow the on-screen instructions to complete the installation.
1. Restart your computer if prompted.

#### Steps to configure IIS
1. Open the Control Panel and select "Programs and Features."
1. Click on "Turn Windows features on or off."
1. Scroll down the list and find "Internet Information Services."
1. Select the checkbox next to "Internet Information Services" and all the sub-components you want to install, such as "Web Management Tools" and "World Wide Web Services."
1. Click "OK" to begin the installation process.
1. Wait for the installation to complete.
1. Once the installation is complete, open the IIS Manager from the start menu or by typing "inetmgr" in the run prompt.
1. Confirm that IIS is installed correctly by creating a new website and browsing to it via the IP address of the VM.

### Step 3: Build and publish your ASP.NET MVC application using Visual Studio.
        
1. Open your ASP.NET MVC project in Visual Studio.
1. Select "Build" from the top menu and then select "Publish."
1. In the "Publish" dialog box, select the appropriate publish target. For example, "File System," "FTP," "Azure Web Apps," etc.
1. Provide the necessary connection information for the selected publish target, such as the server address and credentials.
1. Select the configuration as "Release".
1. Click "Publish" to begin the publishing process.
1. Wait for the publishing process to complete.
1. Once the publishing process is complete, your application will be deployed to the specified location.   
        
### Step 4: Use FileZila to transfer the published files to the virtual machine.
        
1. Download and install FileZilla on your local machine from [here](https://filezilla-project.org/download.php?type=client).
1. Open FileZilla and click on "File" and then "Site Manager."
1. In the "Site Manager" dialog box, click on "New Site" and enter a name for the site.
1. Under "Protocol," select "FTP."
1. Under "Server," enter the IP address or hostname of the virtual machine.
1. Under "Username" and "Password," enter the credentials for an account on the virtual machine that has permission to access the IIS files.
1. Click "Connect" to connect to the virtual machine.
1. Once connected, navigate to the folder where you want to upload the published files on the local machine, and the folder on the virtual machine where you want to put the files.
1. Drag and drop or use the upload button to transfer the files from the local machine to the virtual machine.
1. Once the upload is complete, you should now be able to access the application by browsing to the virtual machine's IP address or hostname.

### Step 5: Configure IIS to host the application, by creating a new website and setting the physical path to the location of the published files.
        
#### How to add new website in IIS</h4>
        
1. Open the IIS Manager by searching for "IIS Manager" in the Start menu or by typing "inetmgr" in the Run prompt.
1. In the IIS Manager, expand the local server and click on "Sites."
1. In the "Sites" section, click on "Add Website" in the right-hand pane.
1. In the "Add Website" dialog box, enter a "Site name" and choose a physical path for the website. This is the location on the server where the website files are stored.
1. Under "Binding," specify the IP address, port, and host name to be used by the website.
1. Click "OK" to create the new website.

#### Setting physical path in IIS</h4>

1. In the IIS Manager, expand the local server and click on "Sites."
1. Select the website for which you want to set the physical path.
1. In the right-hand pane, under "IIS," double-click on "Basic Settings."
1. In the "Edit Site" dialog box, under "Physical path," click on the browse button and navigate to the folder where the published files are located.
1. Click "OK" to save the changes.

### Step 6: Configure any necessary bindings or host headers for the website.
    
> In IIS (Internet Information Services), bindings are used to associate a specific IP address, port, and host name with a website. They determine how clients can access the website and what URL they should use.

#### There are two types of bindings in IIS:

* IP Address and Port bindings: These bindings specify the IP address and port number that the website should listen on. For example, you could specify that a website should listen on IP address "192.168.1.100" and port "80."

* Host Name bindings: These bindings specify the host name that should be used to access the website. For example, you could specify that a website should be accessed using the host name "www.example.com."    

### Step 7: Test the application by accessing it via the virtual machine's IP address or hostname.