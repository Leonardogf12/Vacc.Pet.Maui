namespace VaccPet.Helpers.Buttons
{
    /// <summary>
    /// this is an animation class for buttons with Icons, its function is to
    /// change the scale of the button and changed old icon for a new icon.
    /// </summary>
    public class ImageButtonAnimationHelper
    {
        const double scale = 0.95;
        const uint animationDuration = 100;

        public string OldIcon { get; set; } = string.Empty;
        public string NewIcon { get; set; } = string.Empty;

        public void AddButtonAnimation(ImageButton button, string oldIcon, string newIcon)
        {
            OldIcon = oldIcon;
            NewIcon = newIcon;

            button.Pressed += OnButtonPressed;
            button.Released += OnButtonReleased;
        }

        private async void OnButtonPressed(object sender, EventArgs e)
        {
            await AnimateButton(sender as ImageButton, true, OldIcon, NewIcon);
        }

        private async void OnButtonReleased(object sender, EventArgs e)
        {
            await AnimateButton(sender as ImageButton, false, OldIcon, NewIcon);
        }

        private async Task AnimateButton(ImageButton button, bool isPressed, string oldIcon, string newIcon)
        {
         
            if (isPressed)
            {
                button.Source = ImageSource.FromFile(newIcon);
                await button.ScaleTo(scale, animationDuration, Easing.Linear);
            }
            else
            {
                button.Source = ImageSource.FromFile(oldIcon);
                await button.ScaleTo(1, animationDuration, Easing.Linear);
            }
        }

        public async Task AnimateScaleViewElement(View element, double scale = scale, uint animationDuration = animationDuration)
        {           
            await element.ScaleTo(scale, animationDuration, Easing.Linear);
            await element.ScaleTo(1, animationDuration, Easing.Linear);
        }
    }
}
