using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GLib.Options;

namespace SqlDiffFramework
{
    public partial class SDFOptionsForm : GLib.Options.OptionsForm
    {
        public SDFOptionsForm()
            : base(Properties.Settings.Default)
        {
            InitializeComponent();

            OptionsNoDescription = "";
            CategoryTreeDescription = "Select a category to see its options.";
            OptionDescrDescription = "Mouse-over an item for further information displayed here.";

            // This allows the SDF Restore-settings-to-app-launch to work.
            AutomaticSaveSettings = false;

            Panels.Add(new OptionsPanels.GeneralPanel());
            Panels.Add(new OptionsPanels.DifferencePanel());
        }
    }
}
