using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Processing;

namespace AngularApp1.Server.Service
{
    public class ProcessImagService : IProcessImagService
    {
        public async Task<byte[]> ResizePictureAsync(byte[] imageBytes, double percentage = 0.5)
        {
            using var stream = new MemoryStream(imageBytes);
            using (var image = await Image.LoadAsync(stream))
            {
                // Calculamos el nuevo tamaño basado en el porcentaje
                int newWidth = (int)(image.Width * percentage);
                int newHeight = (int)(image.Height * percentage);

                image.Mutate(x => x.Resize(newWidth, newHeight));

                IImageFormat? format = Image.DetectFormat(imageBytes);
                using var outputStream = new MemoryStream();
                
                await image.SaveAsync(outputStream, format);
                return outputStream.ToArray();
            }
        }

        /// <summary>
        /// Convierte Base64 puro o data URI (data:image/jpeg;base64,...) a byte[].
        /// </summary>
        public byte[] DecodeBase64ToBytes(string base64)
        {
            var base64Data = base64.Trim();
            var commaIndex = base64Data.IndexOf(',');
            if (commaIndex >= 0)
                base64Data = base64Data[(commaIndex + 1)..];

            return Convert.FromBase64String(base64Data);
        }
    }
}
