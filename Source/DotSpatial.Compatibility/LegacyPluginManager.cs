// Copyright (c) DotSpatial Team. All rights reserved.
// Licensed under the MIT license. See License.txt file in the project root for full license information.

using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using DotSpatial.Controls;

namespace DotSpatial.Compatibility
{
    /// <summary>
    /// PluginManager for dealing with additional plugins.
    /// </summary>
    [ToolboxItem(false)]
    public partial class LegacyPluginManager : Component
    {
        #region Fields

        private MenuStrip _mapMenuStrip;

        private bool _pluginMenuIsVisible;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="LegacyPluginManager"/> class.
        /// </summary>
        public LegacyPluginManager()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LegacyPluginManager"/> class.
        /// </summary>
        /// <param name="container">A Container.</param>
        public LegacyPluginManager(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #region Properties

        /// <summary>
        /// Gets or sets the Legend associated with this plugin manager.
        /// </summary>
        public ILegend Legend { get; set; }

        /// <summary>
        /// Gets or sets the Map associated with this plugin manager.
        /// </summary>
        public IBasicMap Map { get; set; }

        /// <summary>
        /// Gets or sets the MapMenuStrip associated with this plugin manager.
        /// </summary>
        public MenuStrip MapMenuStrip
        {
            get
            {
                return _mapMenuStrip;
            }

            set
            {
                if (_pluginMenuIsVisible)
                {
                    AddPluginMenu();
                }

                if (_pluginMenuIsVisible == false)
                {
                    RemovePluginMenu();
                }

                _mapMenuStrip = value;
            }
        }

        /// <summary>
        /// Gets or sets the MapToolStrip associated with this plugin manager.
        /// </summary>
        public ToolStrip MapToolstrip { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not a Plugin menu will be added to the MapMenuStrip
        /// specified by this Plugin Manager.
        /// </summary>
        public bool PluginMenuIsVisible
        {
            get
            {
                return _pluginMenuIsVisible;
            }

            set
            {
                if (_pluginMenuIsVisible == false)
                {
                    if (value)
                    {
                        AddPluginMenu();
                    }
                }
                else
                {
                    if (value == false)
                    {
                        RemovePluginMenu();
                    }
                }

                _pluginMenuIsVisible = value;
            }
        }

        /// <summary>
        /// Gets or sets the Preview Map associated with this plugin manager.
        /// </summary>
        public IBasicMap PreviewMap { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Checks the dlls in the Plugins folder or any subfolder and
        /// adds a new checked menu item for each one that it finds.
        /// This can also be controlled using the PluginMenuIsVisible property.
        /// </summary>
        public void AddPluginMenu()
        {
            if (_mapMenuStrip == null) return;
            if (_pluginMenuIsVisible) return;
            _pluginMenuIsVisible = true;
        }

        /// <summary>
        /// Looks for a menu named Plug-ins and removes it.
        /// Control this through the PluginMenuIsVisible property.
        /// This can also be controlled using the PluginMenuIsVisible property.
        /// </summary>
        public void RemovePluginMenu()
        {
            if (_mapMenuStrip == null) return;
            if (_pluginMenuIsVisible == false) return;

            // The Find method is not supported by Mono 2.0
            // ToolStripItem[] tsList = _mapMenuStrip.Items.Find(MessageStrings.Plugins, false);
            List<ToolStripItem> tsList = new List<ToolStripItem>();
            foreach (ToolStripItem item in _mapMenuStrip.Items)
            {
                if (item.Text == @"Apps")
                {
                    tsList.Add(item);
                }
            }

            foreach (ToolStripItem item in tsList)
            {
                _mapMenuStrip.Items.Remove(item);
            }

            _pluginMenuIsVisible = false;
        }

        #endregion
    }
}