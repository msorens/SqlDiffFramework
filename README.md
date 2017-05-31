For an overview, see the [SqlDiffFramework wiki](https://github.com/msorens/SqlDiffFramework/wiki).

# Download and Installation
Go to the [Releases](https://github.com/msorens/SqlDiffFramework/releases) tab to find the installer for the latest release.
After downloading, run the wizard to tailor the installation to your particular needs, including:
* installation location; 
* whether to add a shortcut to your Start menu or desktop;
* additional considerations for enterprise installation are detailed
in Chapter 2 (_Getting Started_) of the [SqlDiffFramework User Guide](https://github.com/msorens/SqlDiffFramework/wiki/UserGuide).

# Usage
Launching the application reveals two empty, side-by-side SQL editors.
SqlDiffFramework is easy and intuitive to use, with a plethora of tooltips to guide you.
However, by its nature of being a framework it does have a small learning curve so first time users
are _**strongly encouraged**_ to read the **SqlDiffFramework User Guide**.
The user guide was also designed to be easy and intuitive to use, providing a variety of resources
for users from novice to expert, including:
* the single-page **Quick Start** (section 5.1);
* the master function reference (section 5.3) that lists _every_ operation with its associated keys, menus, or on-screen controls, where applicable;
* screenshots of the on-screen reference sheets for the major components of the application (section 5.4);
* a detailed discussion of using the application starting with walk-through scenarios (chapter 3); and
* an exhaustive description of every menu, control, and feature (chapter 4).

# Development
To work with the source and compile SqlDiffFramework, 
simply download the latest source and compile the single Visual Studio solution. 
All required external libraries are included in two separate directories in the source code tree,
one for my own generic [CleanCode libraries](http://cleancode.sourceforge.net/api/csharp/)
and one for all others. 
The major building blocks used from my CleanCode libraries are detailed in the **SqlDiffFramework User Guide** (section 5.6).
