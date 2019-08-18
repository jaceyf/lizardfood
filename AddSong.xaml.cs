using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MusicLibrary
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddSong : Page
    {
        Song song = new Song();
        public AddSong()
        {
            this.InitializeComponent();
        }
        
        // Pic MP3 Button Function
        private void ButtonPickMP3_Click(object sender, RoutedEventArgs e)
        {
            PickMusicFileAsync();
        }

        //Pic Image Button Function
        private void ButtonPickImage_Click(object sender, RoutedEventArgs e)
        {
            PickImageAsync();
        }



        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            // Save into file
           
            //?????????????????????????
            song.Title = musicTitle.Text;
                
            Song.WriteSong(song);
            this.Frame.Navigate(typeof(MainPage));

        }

        private async System.Threading.Tasks.Task PickImageAsync()
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".png");

            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                await file.CopyAsync(ApplicationData.Current.LocalFolder);
                song.MusicImage = file.Name;
                //Save the file name in file
            }
            else
            {
                // OutputTextBlock.Text = "Operation cancelled.";
            }
        }


        private async System.Threading.Tasks.Task PickMusicFileAsync()
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.Desktop;
            openPicker.FileTypeFilter.Add(".MP3");
            openPicker.FileTypeFilter.Add(".MPEG");
            openPicker.FileTypeFilter.Add(".MP4");

            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                await file.CopyAsync(ApplicationData.Current.LocalFolder);
                song.MusicFile = file.Name;
            }
            else
            {
                // OutputTextBlock.Text = "Operation cancelled.";
            }
        }

      
        
    }
}
