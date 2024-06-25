using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPSGERewrite.Software.Converters
{
    public class Base64ToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string base64Image)
            {
                byte[] imageBytes = System.Convert.FromBase64String(base64Image);
                return ImageSource.FromStream(() => new MemoryStream(imageBytes));
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ImageSource imageSource)
            {
                StreamImageSource streamImageSource = imageSource as StreamImageSource;
                var cancellationToken = System.Threading.CancellationToken.None;

                var streamTask = streamImageSource.Stream(cancellationToken);
                streamTask.Wait();
                var stream = streamTask.Result;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    byte[] imageBytes = memoryStream.ToArray();
                    return System.Convert.ToBase64String(imageBytes);
                }
            }
            return null;
        }
    }
}
