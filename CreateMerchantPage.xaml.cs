using Plugin.Media;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF_GoldenStore.Model;
using XF_GoldenStore.ModelServices;

namespace XF_GoldenStore
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateMerchantPage : ContentPage
    {

        List<City> myList;
        MyRegion myRegion = new MyRegion();
        public string CurrentImageBase64 { get; set; }
        Users user = new Users();
        public CreateMerchantPage()
        {
            InitializeComponent();

            Cancel.Clicked += (s, e) => Navigation.PopAsync();
            pickerZone.ItemsSource = myRegion.GetZone();
        }


        private async void Create_Clicked(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(Username.Text)) && (!string.IsNullOrEmpty(Password.Text)))
            {

                user.Username = Username.Text;
                user.Password = Password.Text;
                user.Email = Email.Text;
                user.Mobile = Mobile.Text;
                user.ShopName = ShopName.Text;

                await App.DBSQLite.SaveUserAsync(user);
                //DisplayAlert("Done", "Username is added", "Ok");
                await  Navigation.PopAsync();
            }
            else
                await DisplayAlert("Error", "Username is empty Or Username is already existe", "Ok");
        }
        private async void BtnTakePhoto_Clicked(object sender, EventArgs e)
        {

            var current = CrossMedia.Current;

            var choice = await DisplayAlert("Choose", "Indecate The Source:", "Camera", "File");
            if (choice)
            {
                try
                {
                    if (current.IsCameraAvailable && current.IsTakePhotoSupported)
                    {
                        var photo = await current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                        {
                            CompressionQuality = 70
                        });

                        img1.Source = ImageSource.FromStream(() =>
                        {
                            var stream = photo.GetStream();
                            CurrentImageBase64 = GetBase64(photo.GetStream());
                            user.Url1 = CurrentImageBase64;
                            photo.Dispose();
                            return stream;
                        });
                    }
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error Take Photo", ex.Message, "Ok");
                }
            }
            else
            {
                try
                {
                    if (current.IsPickPhotoSupported)
                    {
                        var photo = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new
                                        Plugin.Media.Abstractions.PickMediaOptions
                        {
                            PhotoSize = Plugin.Media.Abstractions.PhotoSize.Small
                        });
                        if (photo == null)
                            return;
                        img1.Source = ImageSource.FromStream(() =>
                        {
                            var stream = photo.GetStream();
                            CurrentImageBase64 = GetBase64(photo.GetStream());
                            user.Url1 = CurrentImageBase64;
                            photo.Dispose();
                            return stream;
                        });

                    }
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error Take Photo", ex.Message, "Ok");
                }
            }



        }

        private string GetBase64(Stream stream)
        {
            byte[] array;
            using (MemoryStream memory = new MemoryStream())
            {
                stream.CopyTo(memory);
                array = memory.ToArray();
            }

            return Convert.ToBase64String(array);
        }

     private void pickerZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (pickerZone.SelectedIndex == -1)
        {
            DisplayAlert("Zone", "Please select", "Ok");
            return;
        }
        var zone = pickerZone.SelectedItem as Zone;
        user.Zone = zone.Name;

        var list = myRegion.GetCity();
        myList = list.Where(i => i.ZId == zone.Id).ToList();
        pickerCity.ItemsSource = myList;
    }


    private void pickerCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (pickerZone.SelectedIndex == -1)
        {
            DisplayAlert("City", "Please select", "Ok");
            return;
        }
        City city = pickerCity.SelectedItem as City;
        user.City = city.Name;

        }
    }
}