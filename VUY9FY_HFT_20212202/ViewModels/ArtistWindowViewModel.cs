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
using VUY9FY_HFT_2021221.Models;

namespace VUY9FY_HFT_20212202.WPF.ViewModels
{
    class ArtistWindowViewModel : ObservableRecipient
    {
        public ICommand OpenCommand { get; set; }
        public ICommand CreateCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public RestCollection<artist> Artists { get; set; }

        private song selectedSong;

        public song SelectedSong
        {
            get { return selectedSong; }
            set
            {
                OnPropertyChanged();
                SetProperty(ref selectedSong, value);
            }
        }

        public void Setup(song song)
        {
            SelectedSong = song;
        }

        private artist selectedArtist;

        public artist SelectedArtist
        {
            get { return selectedArtist; }
            set
            {
                if (value != null)
                {
                    selectedArtist = new artist()
                    {
                        Id = value.Id,
                        IsBand = value.IsBand,
                        Name = value.Name,
                        Songs = value.Songs
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

        public ArtistWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Artists = new RestCollection<artist>("http://localhost:13442/", "artist");

                CreateCommand = new RelayCommand(
                    () => Artists.Add(new artist()
                    {
                        Name = SelectedArtist.Name,
                        Songs = SelectedArtist.Songs,
                        Id = SelectedSong.ArtistId
                    }));

                UpdateCommand = new RelayCommand(
                    () => Artists.Update(SelectedArtist)
                    );

                DeleteCommand = new RelayCommand(
                    () => Artists.Delete(SelectedArtist.Id),
                    () => SelectedArtist != null
                    );

                SelectedArtist = new artist();
            }
        }
    }
}
