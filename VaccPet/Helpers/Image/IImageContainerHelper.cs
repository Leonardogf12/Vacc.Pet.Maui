using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccPet.Helpers.Image
{
    public interface IImageContainerHelper
    {
        Task<byte[]> ReadImageBytes(string imagePath);
        Task<byte[]> GetImageDefault(string type);               
    }
}
