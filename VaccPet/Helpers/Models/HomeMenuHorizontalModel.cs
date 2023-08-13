namespace VaccPet.Helpers.Models
{
    public class HomeMenuHorizontalModel
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


        public List<HomeMenuHorizontalModel> GetListMenuHorizontalItems()
        {
            var list = new List<HomeMenuHorizontalModel>();

            var a = GetHomeMenuHorizontalObject(1, "Dieta", 0.0f, 1.1f, Color.FromHex("#F3D39C"), 0.0f, Color.FromHex("#E1AF51"), 0.25f, "pet_menu_4",70);
            var b = GetHomeMenuHorizontalObject(2, "Filhotes", 0.0f, 1.1f, Color.FromHex("#655D59"), 0.0f, Color.FromHex("#BFA894"), 0.25f, "pet_menu_5");
            var c = GetHomeMenuHorizontalObject(3, "Felinos", 0.0f, 1.1f, Color.FromHex("#E6DFEC"), 0.0f, Color.FromHex("#BBA3E2"), 0.25f, "pet_menu_6",60);

            list.Add(a);
            list.Add(b);
            list.Add(c);

            return list;
        }

        private HomeMenuHorizontalModel GetHomeMenuHorizontalObject(int id, string name,
                                                                    float numberStartPoint, float numberEndPoint,
                                                                    Color firstColor, float firstOffset,
                                                                    Color secondaryColor, float secondaryOffset,
                                                                    string imageButton,
                                                                    int heightRequestImage = 60)
        {
            return new HomeMenuHorizontalModel
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
                HeightRequestImage = heightRequestImage
            };
        }
    }
}
