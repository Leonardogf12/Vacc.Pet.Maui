namespace VaccPet.Helpers.Image
{
    public class ImageContainerHelper
    {
        private async Task<byte[]> ReadImageBytes(string imagePath)
        {
            try
            {
                using (FileStream stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    byte[] imageData = new byte[stream.Length];
                    await stream.ReadAsync(imageData, 0, (int)stream.Length);

                    return imageData;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async static Task<byte[]> GetImageDefault(string type)
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("noimage.png");
            return await StreamToByteArrayAsync(stream);
        }

        public static async Task<byte[]> StreamToByteArrayAsync(Stream stream)
        {
            using MemoryStream memoryStream = new MemoryStream();
            await stream.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
