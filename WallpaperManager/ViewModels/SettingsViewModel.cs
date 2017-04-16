﻿using GalaSoft.MvvmLight.Command;
using Killerrin_Studios_Toolkit;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WallpaperManager.Models.Settings;

namespace WallpaperManager.ViewModels
{
    public class SettingsViewModel : WallpaperManagerViewModelBase
    {
        public static SettingsViewModel Instance { get { return ServiceLocator.Current.GetInstance<SettingsViewModel>(); } }

        public FileDiscoveryEnableSetting FileDiscoveryEnabled { get; } = new FileDiscoveryEnableSetting();
        public FileDiscoveryFrequencySetting FileDiscoveryFrequency { get; } = new FileDiscoveryFrequencySetting();
        public FileDiscoveryLastRunSetting FileDiscoveryLastRun { get; } = new FileDiscoveryLastRunSetting();

        public List<int> DaysList { get; } = new List<int>();
        private int m_frequencyDays = 0;
        public int FrequencyDays
        {
            get { return m_frequencyDays; }
            set
            {
                m_frequencyDays = value;
                RaisePropertyChanged(nameof(FrequencyDays));
            }
        }

        public List<int> HoursList { get; } = new List<int>();
        private int m_frequencyHours = 0;
        public int FrequencyHours
        {
            get { return m_frequencyHours; }
            set
            {
                m_frequencyHours = value;
                RaisePropertyChanged(nameof(FrequencyHours));
            }
        }

        public List<int> MinutesList { get; } = new List<int>();
        private int m_frequencyMinutes = 0;
        public int FrequencyMinutes
        {
            get { return m_frequencyMinutes; }
            set
            {
                m_frequencyMinutes = value;
                RaisePropertyChanged(nameof(FrequencyMinutes));
            }
        }


        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public SettingsViewModel()
        {
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                // Code runs "for real"
            }

            // Populate the Timespan Selector Lists
            DaysList = new List<int>();
            for (int i = 0; i <= 7; i++)
                DaysList.Add(i);

            HoursList = new List<int>();
            for (int i = 0; i < 24; i++)
                HoursList.Add(i);

            MinutesList = new List<int>();
            for (int i = 0; i < 60; i++)
                MinutesList.Add(i);

            ResetViewModel();
        }

        public override void Loaded()
        {
        }

        public override void OnNavigatedTo()
        {
            // Set the Defaults
            RevertFileDiscoveryFrequency.Execute(null);
        }

        public override void OnNavigatedFrom()
        {

        }

        public override void ResetViewModel()
        {

        }

        public RelayCommand SaveFileDiscoveryFrequency
        {
            get
            {
                return new RelayCommand(() =>
                {
                    FileDiscoveryFrequency.Value = new TimeSpan(FrequencyDays, FrequencyHours, FrequencyMinutes, 0);
                });
            }
        }
        public RelayCommand RevertFileDiscoveryFrequency
        {
            get
            {
                return new RelayCommand(() =>
                {
                    FrequencyDays = FileDiscoveryFrequency.Value.Days;
                    FrequencyHours = FileDiscoveryFrequency.Value.Hours;
                    FrequencyMinutes = FileDiscoveryFrequency.Value.Minutes;
                });
            }
        }
    }
}