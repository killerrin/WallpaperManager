﻿using Killerrin_Studios_Toolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WallpaperManager.Killerrin_Studios_Toolkit.Settings;
using Windows.Foundation.Collections;
using Windows.Storage;

namespace WallpaperManager.Models.Settings
{
    public class FileDiscoveryEnableSetting : ApplicationSettingBase<bool>
    {
        public FileDiscoveryEnableSetting()
            :base(StorageTask.LocalSettings, "FileDiscoveryEnable", false)
        {
        }
    }
}
