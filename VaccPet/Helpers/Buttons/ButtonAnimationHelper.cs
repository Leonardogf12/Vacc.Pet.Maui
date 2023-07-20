namespace VaccPet.Helpers.Buttons
{
    /// <summary>
    /// this is an animation class for common buttons, its function 
    /// is to change the scale of the button.
    /// </summary>  
    public class ButtonAnimationHelper
    {              
        public static void AddButtonAnimation(Button button)
        {
            button.Pressed += OnButtonPressed;
            button.Released += OnButtonReleased;
        }
        private static async void OnButtonPressed(object sender, EventArgs e)
        {
            await AnimateButton(sender as Button, true);
        }
        private static async void OnButtonReleased(object sender, EventArgs e)
        {
            await AnimateButton(sender as Button, false);
        }
        private static async Task AnimateButton(Button button, bool isPressed)
        {
            const double scale = 0.9;
            const uint animationDuration = 100;

            if (isPressed)
                await button.ScaleTo(scale, animationDuration, Easing.Linear);
            else
                await button.ScaleTo(1, animationDuration, Easing.Linear);
        }
    }
}
