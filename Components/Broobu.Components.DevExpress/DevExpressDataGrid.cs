using System;
using System.Windows.Controls;
using System.Windows.Markup;
using System.IO;
using System.ComponentModel;
using DevExpress.Utils;
using DevExpress.Xpf.Grid;

namespace Broobu.Components.DevExpress
{
    /// <summary>
    /// Wrapper around dev express datagrid to facilitate saving/loading the datagrid layout to disk.
    /// IMPORTANT:
    /// - Each column should have its x:Name defined or loading settings will not work completely. See http://www.devexpress.com/Support/Center/p/Q269676.aspx.
    /// - Unlike xceed, we cannot reset the layout to default at runtime. The user will need to restart the application after clicking 'Reset to factory defaults' to see the effect.
    /// </summary>
    [ContentProperty("DataGridControl")]
    public class DevExpressDataGrid : ContentControl
    {
        private GridControl _gridControl;

        private bool _loaded;
        private bool _saveSettings = true;
		
    	private string _resetToFactoryDefaultsLabel;



        /// <summary>
        /// Label to be shown in context menu to reset layout to its default. If not set it will use a default label in English.
        /// </summary>
    	public string ResetToFactoryDefaultsLabel
    	{
    		get
    		{
				if (string.IsNullOrEmpty(_resetToFactoryDefaultsLabel))
					return "Reset columns to default configuration";
				else
					return _resetToFactoryDefaultsLabel;
    		}
			set
			{
				_resetToFactoryDefaultsLabel = value;
			}
    	}

		public bool DisableResetToFactoryDefaults { get; set; }

        /// <summary>
        /// Wrapped control
        /// </summary>
        public GridControl DataGridControl
        {
            get
            {
               return _gridControl;
            }
            set
            {
                if (value == null) return;
                _gridControl = value;
                _gridControl.GotFocus += (snd, e) => SaveUserSettings();
                ////_gridControl.LostFocus += (snd, e) => SaveUserSettings();
                //_listViewChecked = false;
                Content = _gridControl;

				if (!DisableResetToFactoryDefaults)
				{
					//reset to factory defaults context menu
					MenuItem menuItem = new MenuItem();
					menuItem.Click += (snd, e) =>
					                  	{
					                  		ResetUserSettings();
					                  		LoadUserSettings();
					                  	};
					menuItem.Header = ResetToFactoryDefaultsLabel;

					
					if (_gridControl.ContextMenu == null)
					{
						ContextMenu menu = new ContextMenu();
						menu.Items.Add(menuItem);
						_gridControl.ContextMenu = menu;
					}
					else
					{
						//if there is already a context menu we'll add it to the bottom of it, pretty nice of us
						_gridControl.ContextMenu.Items.Add(new Separator());
						_gridControl.ContextMenu.Items.Add(menuItem);
					}
				}

            }
        }


        

     


       
        /// <summary>
        /// Initializes a new instance of the <see cref="DevExpressDataGrid"/> class.
        /// </summary>
        public DevExpressDataGrid()
        {
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                Loaded += (snd, e) => FirstTimeLoadUserSettings();
            }
        }



        /// <summary>
        /// Save grid's layout to disk
        /// </summary>
        /// <param name="path"></param>
        public void SaveUserSettings(string path)
        {
            if (_saveSettings)
            {

                if (File.Exists(path))
                    File.Delete(path);
                using (var fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    try
                    {
                        _gridControl.SaveLayoutToStream(fs);
                    }
                    finally
                    {
                        fs.Close();
                    }
                }
            }
        }


        /// <summary>
        /// Saves the user settings.
        /// </summary>
        public void SaveUserSettings()
        {
            var path = GetControlSettingsPath();
            SaveUserSettings(path);
        }

		/// <summary>
		/// Resets the user settings to factory defaults
		/// </summary>
		public void ResetUserSettings()
		{
			var path = GetControlSettingsPath();
			ResetUserSettings(path);
		}

		/// <summary>
		/// Resets the user settings to factory defaults
		/// </summary>
		/// <param name="path"></param>
		public void ResetUserSettings(string path)
		{

            if (File.Exists(path)) 
                File.Delete(path);

		    _saveSettings = false; // disable saving of settings, upon restart the defaults will be used again because there is no more settings file.
		}

    	/// <summary>
        /// Gets the control settings path.
        /// </summary>
        /// <returns></returns>
        private string GetControlSettingsPath()
        {
            return String.Format("{0}\\{1}.xml", LocalApplicationDataDir(), _gridControl.Name);
        }

        /// <summary>
        /// Local application data dir.
        /// </summary>
        /// <returns></returns>
        private static string LocalApplicationDataDir()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        }


        private void FirstTimeLoadUserSettings()
        {
            if (!_loaded)
            {
                _loaded = true;
                LoadUserSettings();
            }
        }

        /// <summary>
        /// Loads the user settings.
        /// </summary>
        public void LoadUserSettings()
        {
            var path = GetControlSettingsPath();
            if (File.Exists(path))
                LoadUserSettings(path);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public void LoadUserSettings(string path)
        {
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                using (var fs = new FileStream(path, FileMode.Open))
                {
                    try
                    {
                       _gridControl.RestoreLayoutFromStream(fs);
                    }
                    catch(Exception)
                    {
                        //Silently catch any excpetion found during deserialization - can happen because content of file is garbage
                    }
                    finally
                    {
                        fs.Close();
                    }
                }
            }
        }


    }
}
