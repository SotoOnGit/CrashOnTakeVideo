using CrashOnTakeVideo.Helper;

namespace CrashOnTakeVideo
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            var devicePlatform = DeviceInfo.Current.Platform;
            var deviceVersion = DeviceInfo.Current.Version;

            if (devicePlatform == DevicePlatform.Android && deviceVersion.Major <= 12)
            {
                var storageStatus = await PermissionsHelper.CheckAndRequestPermission<Permissions.StorageWrite>();
                if (storageStatus == PermissionStatus.Denied)
                {
                    return;
                }
            }

            var status = await PermissionsHelper.CheckAndRequestPermission<Permissions.Camera>();
            if (status == PermissionStatus.Denied || status == PermissionStatus.Unknown)
            {
                return;
            }

            var result = await MediaPicker.Default.CaptureVideoAsync();
            //upload
            if (result == null)
                return;
        }
    }

}
