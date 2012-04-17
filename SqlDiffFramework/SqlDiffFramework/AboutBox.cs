using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using CleanCode.IO;

/*
 * ==============================================================
 * @ID       $Id: AboutBox.cs 971 2010-09-30 16:09:30Z ww $
 * @created  2008-07-31
 * ==============================================================
 *
 * The official license for this file is shown next.
 * Unofficially, consider this e-postcardware as well:
 * if you find this module useful, let us know via e-mail, along with
 * where in the world you are and (if applicable) your website address.
 */

/* ***** BEGIN LICENSE BLOCK *****
 * Version: MIT License
 *
 * Copyright (c) 2010 Michael Sorens
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 *
 * ***** END LICENSE BLOCK *****
 */

namespace SqlDiffFramework
{
	partial class AboutBox : Form
	{
		private string nl = Environment.NewLine;
        private const int MAX_LINK_LENGTH = 53; // this is the limit that will fit for the current form width
        private const string ABBEREVIATION_INDICATOR = "...";

		public AboutBox()
		{
			InitializeComponent();

			//  Initialize the AboutBox to display the product information from the assembly information.
			//  Change assembly information settings for your application through either:
			//  - Project->Properties->Application->Assembly Information
			//  - AssemblyInfo.cs
			this.Text = String.Format("About {0}", AssemblyTitle);
			this.labelProductName.Text = AssemblyProduct;
			this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
			this.labelCopyright.Text = AssemblyCopyright;

            CreateAbbreviatedLinkText(labelWebsiteURL, "http://SqlDiffFramework.codeplex.com/");
            CreateAbbreviatedLinkText(labelDocumentationURL, "http://SqlDiffFramework.codeplex.com/documentation");
            CreateAbbreviatedLinkText(labelAppDataDirPath, ResourceMgr.ApplicationSpecificApplicationData());
            CreateAbbreviatedLinkText(labelExePath, Path.GetDirectoryName(Application.ExecutablePath));

            this.textBoxDescription.Text = 
                string.Format("{0}; version {1}", AssemblyDescription, AssemblyVersion) + nl + nl
                + "========= Regional Settings =========" + nl
                + "Input Language: " + InputLanguage.CurrentInputLanguage.Culture.Name + nl
                + "Current Culture: " + CultureInfo.CurrentCulture.Name + nl
                + "Current UI Culture: " + CultureInfo.CurrentUICulture.Name + nl + nl
                + "========= Assemblies loaded (so far) =========" + nl
                + string.Join(nl, InstalledAssemblies.Assemblies.ToArray());
		}

        private void CreateAbbreviatedLinkText(LinkLabel linkLabel, string targetLink)
        {
            if (targetLink.Length > MAX_LINK_LENGTH)
            {
                linkLabel.Tag = targetLink;
                linkLabel.Text = targetLink.Substring(0, MAX_LINK_LENGTH - ABBEREVIATION_INDICATOR.Length - 1) + ABBEREVIATION_INDICATOR;
            }
            else
            {
                linkLabel.Text = targetLink;
            }
            toolTip.SetToolTip(linkLabel, targetLink);
        }

		#region Assembly Attribute Accessors

		public string AssemblyTitle
		{
			get
			{
				// Get all Title attributes on this assembly
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
				// If there is at least one Title attribute
				if (attributes.Length > 0)
				{
					// Select the first one
					AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
					// If it is not an empty string, return it
					if (titleAttribute.Title != "")
						return titleAttribute.Title;
				}
				// If there was no Title attribute, or if the Title attribute was the empty string, return the .exe name
				return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
			}
		}

		public string AssemblyVersion
		{
			get
			{
				return Assembly.GetExecutingAssembly().GetName().Version.ToString();
			}
		}

		public string AssemblyDescription
		{
			get
			{
				// Get all Description attributes on this assembly
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
				// If there aren't any Description attributes, return an empty string
				if (attributes.Length == 0)
					return "";
				// If there is a Description attribute, return its value
				return ((AssemblyDescriptionAttribute)attributes[0]).Description;
			}
		}

		public string AssemblyProduct
		{
			get
			{
				// Get all Product attributes on this assembly
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
				// If there aren't any Product attributes, return an empty string
				if (attributes.Length == 0)
					return "";
				// If there is a Product attribute, return its value
				return ((AssemblyProductAttribute)attributes[0]).Product;
			}
		}

		public string AssemblyCopyright
		{
			get
			{
				// Get all Copyright attributes on this assembly
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
				// If there aren't any Copyright attributes, return an empty string
				if (attributes.Length == 0)
					return "";
				// If there is a Copyright attribute, return its value
				return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
			}
		}

		public string AssemblyCompany
		{
			get
			{
				// Get all Company attributes on this assembly
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
				// If there aren't any Company attributes, return an empty string
				if (attributes.Length == 0)
					return "";
				// If there is a Company attribute, return its value
				return ((AssemblyCompanyAttribute)attributes[0]).Company;
			}
		}
		#endregion

		private void okButton_Click(object sender, EventArgs e)
		{
			Close();
		}

        private void label_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string candidateLink = ((LinkLabel)sender).Text;
            // if the link has the "abbreviation" indicator, get the full URL from the Tag.
            string link = candidateLink.EndsWith(ABBEREVIATION_INDICATOR) ? ((LinkLabel)sender).Tag.ToString() : candidateLink;
            try
            { Process.Start(link); }
            catch (FileNotFoundException) // probably should never occur here
            { MessageBox.Show("Unable to open: " + nl + link, "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (ArgumentException) // probably should never occur here
            { MessageBox.Show("No link specified", "Unable to open link", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (Win32Exception ex) // occurs if e.g. AppDir has not yet been created
            { MessageBox.Show(link + nl + "Error: " + ex.Message, "Unable to open link", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

	}
}
