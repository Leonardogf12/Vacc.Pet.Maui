namespace VaccPet.Helpers.Image
{
    public static class ImageMediaPicker
    {
        public static async Task<string> GetImageFromGallery()
        {
            var result = await MediaPicker.PickPhotoAsync();

            if (result != null)
                return result.FullPath;

            return null;
        }
    }
}
