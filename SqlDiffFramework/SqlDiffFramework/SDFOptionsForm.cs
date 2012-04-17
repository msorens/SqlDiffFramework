using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GLib.Options;

/*
 * ==============================================================
 * @ID       $Id: SDFOptionsForm.cs 971 2010-09-30 16:09:30Z ww $
 * @created  2009-09-01
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
