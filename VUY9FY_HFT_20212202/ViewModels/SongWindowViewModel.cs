using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VUY9FY_HFT_20212202.WPF.Windows;
using VUY9FY_HFT_2021221.Models;

namespace VUY9FY_HFT_20212202.WPF.ViewModels
{
    public class SongWindowViewModel : ObservableRecipient
    {
        public ICommand OpenCommand { get; set; }
        public ICommand CreateCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public RestCollection<song> Songs { get; set; }

        private list selectedList;

        public list SelectedList
        {
            get { return selectedList; }
            set
            {
                OnPropertyChanged();
                SetProperty(ref selectedList, value);
            }
        }

        public void Setup(list yTContentCreator)
        {
            SelectedList = yTContentCreator;
        }

        private song selectedSong;
        public song SelectedSong
        {
            get { return selectedSong; }
            set
            {
                if (value != null)
                {
                    selectedSong = new song()
                    {
                        Title = value.Title,
                        Artist = value.Artist,
                        ArtistId = value.ArtistId,
                        Score = value.Score,
                        Release = value.Release,
                        SongId = value.SongId
                    };
                    OnPropertyChanged();
                    (DeleteCommand as RelayCommand).NotifyCanExecuteChanged();
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



        public SongWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Songs = new RestCollection<song>("http://localhost:13442/", "song");

                OpenCommand = new RelayCommand(
                    () => new ArtistWindow(SelectedSong).ShowDialog(),
                    () => SelectedSong != null
                    );

                CreateCommand = new RelayCommand(
                    () => Songs.Add(new song()
                    {
                        Title = SelectedSong.Title,
                        ArtistId = 1,
                        //SongId = SelectedList.SongId,
                        Artist = new artist(),
                        Score = SelectedList
                    }));

                UpdateCommand = new RelayCommand(
                    () => Songs.Update(SelectedSong)
                    );

                DeleteCommand = new RelayCommand(
                    () => Songs.Delete(SelectedSong.SongId),
                    () => SelectedSong != null
                    );

                SelectedSong = new song();
                SelectedList = new list();
            }
        }
    }
}
