using MAPProje.Models;

using MAPProje.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MAPProje.Views
{
    public partial class LessonPage : ContentPage
    {
        double startX, startY;
        double currentScale = 1, startScale = 1;
        double xOffset = 0, yOffset = 0;

        // New fields for double-tap zooming
        double defaultScale = 1, zoomedScale = 2;
        bool isZoomed = false;

        private List<string> allItems = new List<string> { "CB53", "CB55", "CB56", "CB57", "CB58", "CB59", "CB62 - Okuma Salonu", "CB63", "CB66 - Optisyenlik Labaratuarı", "CB67 - Patoloji Mikrobioloji Laboratuarı", "CB68 - Elektronorofizyoloji Laboratuarı", "CB69 - Mikroskop Geliştirme Laboratuarı", "Masjid-W", "Masjid-M", "CZ05", "CZ09", "CZ10", "CZ11", "CZ12", "CZ18", "CZ19", "CZ20", "CZ21", "Baby Room", "C101", "C102", "C103", "C104", "C105", "C106 - SABİTA Müdürü", "C107", "C108", "C109", "C110", "C113", "C114 - Sağlık Hizmetleri MYO Müdürü", "C112", "C117", "C119 - Sosal Bilimler MYO Müdürü", "C120 - SBMYO İdari Personel", "Senate Room", "C123", "C124 - Sağlık Hizmetleri MYO", "C125 - Prof. D. Türkan Yiğitbaşı", "C126 - MYO Müdürü", "C127 - SBMYO Müdürlüğü", "C128 - MYO Sekreterliği", "C129", "C130", "C131 - Sosyal Bilimler MYO Sekreteri Demet Şengül", "C132 - Doç. Dr. Sibel Erdem", "C133 - Dr. Öğr. Üyesi Serkan Başlayıcı", "C134", "C135 - Dr. Öğr. Üyesi Derya Tuğlu", "C136", "C137 - Öğretim ve Araştırma Görevlileri", "C138", "C139", "C140 - Doç Dr. Faik Tanrıkulu", "C141", "C142 - Prof. Dr. Mehmet Koçak", "C143", "C144 - Prof. Dr. Esra Çağavi", "C145", "C146 - Prof. Süleyman Yıldırım", "C147", "C148 - MYO Mimari Restorasyon", "C149", "C150", "C151", "C152", "C153", "C201", "C202", "C203", "C204", "C205", "C206", "C207 - Circuits Laboratuarı", "C209", "C210", "C211", "C212", "C213", "C219", "C220", "C221", "C222", "C223", "C224 - Laboratuar", "C225 - Laboratuar", "C226 - Laboratuar", "C227 - Prof. Dr. Yasemin Yüksel Durmaz", "C228", "C229 - Prof. Dr. Afgan Aslan", "C230 - Prof. Dr. Bahadır Kürşat", "C231 - Dr. Öğr. Üyesi Hüseyin Şerif Savcı", "C232", "C233 - Dr. Öğr. Üyesi Cihan Bilge Gürbüz", "C234 - Doç. Dr. Muhammed Fatih Toy", "C235 - Prof. Dr. Talip Yaşar Alp", "C236 - Prof. Dr. Hakan Tozan", "C237 - Dr. Öğr. Üyesi Mehmet Kocatürk", "C238", "C239 - Prof. Dr. Mehmet Kemal Özdemir", "C240", "C241", "C301 - Dr. Emrah EROĞLU", "C302", "C303", "C304", "C305 - İlk Yardım Eğitim Merkezi", "C306", "C307", "C308", "C309", "C310", "C311", "C312", "C313", "C314", "C315", "C316 - Elektronörofizyoloji Laboratuarı", "C317 - Elektronörofizyoloji Laboratuarı", "C318", "C319 - Server Odası", "C320 - Prof. Dr. Selim Akyokuş", "C321 - Etik Kurrulu Sekreterliği", "C322", "C323", "C324 - Doç. Dr. Sundus Tarıq", "C325", "C326", "C327", "C328", "C329", "C330 - Doç. Dr. Sema Akboğa Demir", "C331 - Prof. Dr. Reda Alhajj", "C332", "C333", "C334", "C335 - Dr. Öğr. Üyesi İrfan Ersin", "C336", "C337", "C338 - Dr. Öğr. Üyesi Hande Yılmaz", "C339 - Yrd. Doç. Dr. Elif Zeynep Yılmaz / Dr. Öğr. Üyesi Bilgesu Onur Sucu", "C340 - Dr. Öğr. Üyesi Vefa Okumuş", "C341 - Doç. Dr. Nihal Karakaş", "C342 - Yrd. Doç. Dr. Özlem Güven", "C343", "C344", "C401", "C402", "C403", "C404", "C405", "C407", "C408", "C409", "C410", "C411", "C412", "C415", "C428", "C429", "C430", "C431", "C432", "C433", "C434", "C435", "C436", "C437", "C438", "C439", "C440", "C441", "C442", "C443", "C444", "C445", "C446", "C447", "C448", "C449", "C450", "C451", "C452" };

        Dictionary<string, string> itemToImageMap = new Dictionary<string, string>
        {
            { "C207 - Circuits Laboratuarı", "C207L.png" }, // Replace with actual image names
            { "C209", "C209L.png" },
            { "C211", "C211L.png" },
            { "C302", "C302L.png" },
            { "C314", "C314L.png" },
            { "C327", "C327L.png" },
            { "C415", "C415L.png" },
            { "CB53", "CB53L.png" },
            { "CB55", "CB55L.png" },
            { "CZ12", "CZ12L.png" }
            

            // Add more mappings as necessary
        };

       
        public LessonPage()
        {
            InitializeComponent();

           
        }

        private void OnImageDoubleTapped(object sender, EventArgs e)
        {
            if (isZoomed)
            {
                // Zoom out
                currentScale = defaultScale;
                xOffset = 0;
                yOffset = 0;
            }
            else
            {
                // Zoom in
                currentScale = zoomedScale;

                // Optionally, you can set xOffset and yOffset to center the zoom on the double-tap location
                // This requires calculating the position of the tap relative to the image
            }

            // Animate the scale and translation
            var scaleTask = lessonImage.ScaleTo(currentScale, 250, Easing.CubicInOut);
            var translateTask = lessonImage.TranslateTo(xOffset, yOffset, 250, Easing.CubicInOut);

            // Toggle the zoom state
            isZoomed = !isZoomed;

            
        }

        void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            if (e.StatusType == GestureStatus.Started)
            {
                // Store the initial translation
                startX = lessonImage.TranslationX;
                startY = lessonImage.TranslationY;
            }
            if (e.StatusType == GestureStatus.Running)
            {
                // Calculate the new translation
                double newX = startX + e.TotalX;
                double newY = startY + e.TotalY;

                // Define bounds for translation
                double minX = -lessonImage.Width * (currentScale - 1); // This ensures the image does not move beyond the left and top bounds
                double minY = -lessonImage.Height * (currentScale - 1) + 600; // Adjust this value if you have a UI element at the top like a search bar or a button

                double maxX = 250; // Assuming the top-left corner of the image aligns with the top-left corner of the view when not translated
                double maxY = 0; // Adjust this value if you have a UI element at the bottom

                // Apply bounds to the translation
                lessonImage.TranslationX = Math.Max(Math.Min(newX, maxX), minX);
                lessonImage.TranslationY = Math.Max(Math.Min(newY, maxY), minY);
            }
            if (e.StatusType == GestureStatus.Completed)
            {
                // Store the final translation
                xOffset = lessonImage.TranslationX;
                yOffset = lessonImage.TranslationY;
            }

            
        }

        private void OnSearchButtonPressed(object sender, EventArgs e)
        {
            var searchBar = (SearchBar)sender;
            var query = searchBar.Text.ToLower(); // Convert the search query to lower case for comparison

            
        }

        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = e.NewTextValue?.ToLower() ?? "";

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var suggestions = allItems.Where(item => item.ToLower().StartsWith(searchText)).ToList();
                suggestionListView.ItemsSource = suggestions;
                suggestionListView.IsVisible = suggestions.Any();
            }
            else
            {
                suggestionListView.IsVisible = false;
            }
        }

        private void OnSuggestionSelected(object sender, SelectedItemChangedEventArgs e)
        {
            string selectedItem = (string)e.SelectedItem;

            if (e.SelectedItem != null)
            {
                imageContainer.Margin = new Thickness(5, 50, 5, 0);
                searchBar.Text = selectedItem;
                suggestionListView.IsVisible = false;
            }

            // Change the image based on the selected item
            if (itemToImageMap.TryGetValue(selectedItem, out string imageName))
            {
                lessonImage.Source = imageName;
            }
        }

    }
}