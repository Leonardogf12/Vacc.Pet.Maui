using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccPet.MVVM.Views.Components
{
    public static class CaroucelFramePhoto
    {
        public static IEnumerable<ContentView> PopulateCarouselFrames()
        {
            List<ContentView> contentViewList = new List<ContentView>();

            var frame1 = new Frame
            {
                CornerRadius = 100,
                HeightRequest = 100,
                WidthRequest = 100,
                BackgroundColor = Colors.White,
            };
            contentViewList.Add(frame1);

            var frame2 = new Frame
            {
                CornerRadius = 100,
                HeightRequest = 100,
                WidthRequest = 100,
                BackgroundColor = Colors.White,
            };
            contentViewList.Add(frame2);

            var frame3 = new Frame
            {
                CornerRadius = 100,
                HeightRequest = 100,
                WidthRequest = 100,
                BackgroundColor = Colors.White,
            };
            contentViewList.Add(frame3);

            return contentViewList;
        }
    }
}
