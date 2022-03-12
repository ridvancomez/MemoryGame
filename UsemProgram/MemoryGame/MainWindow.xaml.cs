using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MemoryGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        static int seviye = 1;
        int IComponentConnector;

        
        List<string> emoji = new List<string>();


        public MainWindow()
        {
            InitializeComponent();
            Setup();
            
        }

        private void Setup()
        {
            List<string> emojiList = new List<string>();
            emojiList.Add("🎶");
            emojiList.Add("🎶");
            emojiList.Add("😊");
            emojiList.Add("😊");
            emojiList.Add("👍");
            emojiList.Add("👍");
            emojiList.Add("👌");
            emojiList.Add("👌");
            emojiList.Add("😒");
            emojiList.Add("😒");
            emojiList.Add("😍");
            emojiList.Add("😍");
            emojiList.Add("❤️");
            emojiList.Add("❤️");
            emojiList.Add("🤣");
            emojiList.Add("🤣");



            foreach (var emoji in main.Children.OfType<TextBlock>())
            {
                Random random = new Random();
                int rastgeleSayi = random.Next(0, emojiList.Count);
                emoji.Text = emojiList[rastgeleSayi];
                emoji.Foreground = Brushes.White;
                emojiList.RemoveAt(rastgeleSayi);
            }
        }

        TextBlock ikinciTiklama = new TextBlock();
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bool bayrak = false;
            var ilkTiklama = (TextBlock)sender;

            if (ikinciTiklama.Text == "")
            {
            ilkTiklama.Foreground = Brushes.Black;
                ikinciTiklama = ilkTiklama;
            }
            else if(ikinciTiklama.Text == ilkTiklama.Text)
            {

                ilkTiklama.Foreground = Brushes.Black;
                ilkTiklama.IsEnabled = false;
                ikinciTiklama.IsEnabled = false
                    ;
                ikinciTiklama = new TextBlock();

            }
            else
            {
                ikinciTiklama.Foreground = Brushes.White;
                ikinciTiklama = new TextBlock();

            }
            foreach (var renkKontrol in main.Children.OfType<TextBlock>())
            {
                if(renkKontrol.Foreground == Brushes.Black)
                {
                    bayrak = true;
                }
                else
                {
                    bayrak = false;
                    break;
                }
            }
            if(bayrak)
            {
                foreach (var sifirla in main.Children.OfType<TextBlock>())
                {
                    sifirla.IsEnabled = true;

                }
                seviye++;
                MessageBox.Show("Tebrikler", "Kazandınız");
                MessageBox.Show($"{seviye}. seviyeye geçiliyor", "Seviye");
                Thread.Sleep(1000);
                Setup();
                

            }

        }
    }
}
