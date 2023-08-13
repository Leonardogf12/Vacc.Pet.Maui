
using VaccPet.MVVM.ViewModels;

namespace VaccPet.Helpers.Models
{
    public class HomeMenuCardsHorizontalModel : BaseViewModel
    {       
        public int Id { get; set; }
        public string Name { get; set; }
        public float NumberStartPoint { get; set; }
        public float NumberEndPoint { get; set; }
        public Color FirstColor { get; set; }
        public float FirstOffset { get; set; }
        public Color SecondaryColor { get; set; }
        public float SecondaryOffset { get; set; }
        public string ImageButton { get; set; }
        public int HeightRequestImage { get; set; }
        public string TextCardMiddleMenuHorizontal { get; set; }

        public async Task<List<HomeMenuCardsHorizontalModel>> GetListTopMenuCardsHorizontal()
        {           
            var list = new List<HomeMenuCardsHorizontalModel>();
          
            var cardA = SetContentForCard(1, "Dieta", 0.0f, 1.1f, Color.FromRgba("#E1AF51"), 0.0f, Color.FromRgba("#F3D39C"), 0.25f, "pet_menu_4",70);
            var cardB = SetContentForCard(2, "Filhotes", 0.0f, 1.1f, Color.FromRgba("#655D59"), 0.0f, Color.FromRgba("#BFA894"), 0.25f, "pet_menu_5");
            var cardC = SetContentForCard(3, "Felinos", 0.0f, 1.1f, Color.FromRgba("#E6DFEC"), 0.0f, Color.FromRgba("#BBA3E2"), 0.25f, "pet_menu_6",60);

            list.Add(cardA);
            list.Add(cardB);
            list.Add(cardC);

            return list;
        }

        public List<HomeMenuCardsHorizontalModel> GetListMiddleMenuCardsHorizontal()
        {
            var textCardA = "Conheça algumas raças diferentes de cães e gatos.";
            var textCardB = "Algumas lojas recomendadas pela comunidade.";

            var list = new List<HomeMenuCardsHorizontalModel>();

            var cardA = SetContentForCard(4, "Curiosidade", 0.0f, 1.1f, Color.FromRgba("#E598AF"), 0.0f, Color.FromRgba("#865A92"), 0.25f, "pet_menu_8", 120, textCardA);
            var cardB = SetContentForCard(5, "Lojas", 0.0f, 1.1f, Color.FromRgba("#CE9E83"), 0.0f, Color.FromRgba("#FF957D"), 0.25f, "pet_menu_7", 140, textCardB);

            list.Add(cardA);
            list.Add(cardB);

            return list;
        }

        private HomeMenuCardsHorizontalModel SetContentForCard(int id, string name,
                                                               float numberStartPoint, float numberEndPoint,
                                                               Color firstColor, float firstOffset,
                                                               Color secondaryColor, float secondaryOffset,
                                                               string imageButton,
                                                               int heightRequestImage = 60,
                                                               string textCardMiddleMenuHorizontal = "")
        {
            return new HomeMenuCardsHorizontalModel
            {
                Id = id,
                Name = name,
                NumberStartPoint = numberStartPoint,
                NumberEndPoint = numberEndPoint,
                FirstColor = firstColor,
                FirstOffset = firstOffset,
                SecondaryColor = secondaryColor,
                SecondaryOffset = secondaryOffset,
                ImageButton = imageButton,
                HeightRequestImage = heightRequestImage,
                TextCardMiddleMenuHorizontal = textCardMiddleMenuHorizontal
            };
        }
    }
}
