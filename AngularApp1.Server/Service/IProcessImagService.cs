namespace AngularApp1.Server.Service
{
    public interface IProcessImagService
    {
        Task<byte[]> ResizePictureAsync(byte[] imageBytes, double percentage = 0.5);


        /// <summary>
        /// Convierte Base64 puro o data URI (data:image/jpeg;base64,...) a byte[].
        /// </summary>
        byte[] DecodeBase64ToBytes(string base64);
    }
}
