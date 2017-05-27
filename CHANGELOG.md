
----
## 1.0.3.0 (2012.04.17)

IMPROVEMENTS:
  - Swapped in enhanced ComboBox for file selectors that now shows the full file paths in a tooltip for each item in the dropdown history list (CleanCode library).
  - Added support for binary field types in a DB result set, overcoming an inherent weakness in the .NET DataGridView control (CleanCode library).
  - Updated from Visual Studio 2008 to 2010.
  - Switched from .NET 2.0 to .NET 3.5 obviating the need for LinqBridge library.

----
## 1.0.2.0 (2010.06.04)

Maintenance Release

Defect Fixes:
  - Issue # 3: _Database dropdown for connection editor may be empty depending upon DB permissions_
  - Issue # 4: _Cannot resolve work item macro, invalid id._

IMPROVEMENTS:
  - About Box now displays regional and language settings in effect.
  - SDF now notices if user locale changes from the system control panel. The only visible manifestation of this currently is if you right-click the header row of a result grid to open its context menu, then view the submenu with date formatting choices.
  - Changed database dropdown for connection editor to display non-system DBs only by default but with the shift key to also include system DBs.
  - Fixed Connection Editor to retain correct details of currently selected connection after saving the connection set.
  - In meta-query library (SQL Server only), deleted DatabaseName column from several queries because their domain is always the current database.
  - In meta-query library (SQL Server only), standardized field names in several queries.
  - In meta-query library (SQL Server only), added/modified ORDER BY clauses in several queries to eliminate warning messages when TurboSort is enabled at the time a meta-query is executed.
  - Installer now includes a shortcut for the user guide as a stub, directing user where to download the actual user guide.
  - Help menu now includes a menu item to open the user guide. If the user has already downloaded the separate user guide, it just opens. If not, SDF prompts the user to download it.

_Very minor updates to the user manual are pending._

----
## 1.0.1.0 (2010.05.12)

Maintenance Release

An embedded user control inadvertently assumed US regional and language settings; with non-US settings the application crashed during startup.
_The user manuals are unchanged from the previous release._

----
## 1.0.0.0 (2010.04.30)

Initial Public Release

  - Requirements: .NET Framework 2.0

  - SqlDiffFramework is designed for the enterprise! Check with your system administrator (or see the user guide) for how to:
	* Point to the SqlDiffFramework repository (if any) so you will be notified of updates (user guide, section 2.2.2).
	* Load a set of of default database connections for your environment  (user guide, section 2.2.1).

  - If you are running Windows XP and selected the large-address-space install, be sure your machine is configured to boot with the /3GB option--see [boot.ini options](http://support.microsoft.com/kb/833721).
