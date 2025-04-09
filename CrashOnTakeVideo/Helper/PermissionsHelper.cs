using static Microsoft.Maui.ApplicationModel.Permissions;

namespace CrashOnTakeVideo.Helper
{
    public static class PermissionsHelper
    {
        public static async Task<PermissionStatus> CheckAndRequestPermission<T>() where T : BasePermission, new()
        {
            PermissionStatus status = await Permissions.CheckStatusAsync<T>();

            if (status == PermissionStatus.Granted)
                return status;

            if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
            {
                return status;
            }

            if (Permissions.ShouldShowRationale<T>())
            {
                //skip
            }

            status = await Permissions.RequestAsync<T>();

            if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.Android)
            {
            }

            return status;
        }
    }
}
