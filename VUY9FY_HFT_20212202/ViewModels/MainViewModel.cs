using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VUY9FY_HFT_2021221.Models;
using VUY9FY_HFT_20212202.WPF.Windows;

namespace VUY9FY_HFT_20212202.WPF.ViewModels
{
    public class MainViewModel : ObservableRecipient
    {
        public ICommand OpenCommand { get; set; }
        public ICommand CreateCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        //public ICommand DeleteCommand { get; set; }

        public RestCollection<list> songList { get; set; }

        private list selectedList;
        public list SelectedList
        {
            get { return selectedList; }
            set
            {
                if (value != null)
                {
                    selectedList = new list()
                    {
                        Year = value.Year,
                        Score = value.Score,
                        Song = value.Song,
                        SongId = value.SongId
                    };
                    OnPropertyChanged();
                    //(DeleteCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }

        }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainViewModel()
        {
            if (!IsInDesignMode)
            {
                songList = new RestCollection<list>("http://localhost:13442/", "list");

                OpenCommand = new RelayCommand(
                    () => new SongWindow(SelectedList).ShowDialog(),
                    () => selectedList != null
                    );

                CreateCommand = new RelayCommand(
                    () => songList.Add(new list()
                    { SongId = SelectedList.SongId, Year = SelectedList.Year }));

                //DeleteCommand = new RelayCommand(
                //    () => songList.Delete(SelectedList.SongId, SelectedList.Year),
                //    () => SelectedList != null
                //    );

                SelectedList = new list();
            }
        }
    }
}
