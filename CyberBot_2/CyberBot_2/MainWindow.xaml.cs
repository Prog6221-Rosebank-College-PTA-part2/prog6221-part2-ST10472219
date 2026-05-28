using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
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








namespace CyberBot_2
{
    public partial class MainWindow : Window
    {
        ChatbotEngine bot = new ChatbotEngine();

        bool askedName = true;

        // GLOBAL MEDIA PLAYER
        MediaPlayer player = new MediaPlayer();

        public MainWindow()
        {
            InitializeComponent();

            // PLAY GREETING SOUND AFTER WINDOW LOADS
            this.Loaded += (s, e) =>
            {
                try
                {
                    string soundPath =
                        @"C:\Users\Student\source\repos\CyberBot_2\CyberBot_2\greeting.wav";

                    if (File.Exists(soundPath))
                    {
                        
                        // PLAY SOUND
                        player.Open(new Uri(soundPath));

                        player.Volume = 1.0;

                        player.Play();

                        
                    }
                    else
                    {
                        rtbChat.Document.Blocks.Add(
                            new Paragraph(
                                new Run("[" + DateTime.Now.ToString("HH:mm:ss") + "] System: greeting.wav NOT FOUND")));
                    }
                }
                catch (Exception ex)
                {
                    rtbChat.Document.Blocks.Add(
                        new Paragraph(
                            new Run("ERROR: " + ex.Message)));
                }
            };

            // BOT TITLE + WELCOME
            rtbChat.Document.Blocks.Add(
                new Paragraph(
                    new Run(
@"========================
   NSUKU CYBERSAFE BOT
========================

[" + DateTime.Now.ToString("HH:mm:ss") + @"] Bot: Hello! Welcome to CyberSafe Bot.
[" + DateTime.Now.ToString("HH:mm:ss") + @"] Bot: What is your name?")));
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            string input = txtInput.Text.Trim();

            // EMPTY INPUT
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Please enter a message.");
                return;
            }

            // SHOW USER MESSAGE
            rtbChat.Document.Blocks.Add(
                new Paragraph(
                    new Run("[" + DateTime.Now.ToString("HH:mm:ss") + "] User: " + input)));

            // FIRST INPUT = USER NAME
            if (askedName)
            {
                askedName = false;

                rtbChat.Document.Blocks.Add(
                    new Paragraph(
                        new Run(
@"[" + DateTime.Now.ToString("HH:mm:ss") + @"] Bot: Nice to meet you " + input + @"!

How can I help you today?

You can ask me about:
• Passwords
• Phishing
• Privacy
• Scams
• Viruses
• Hackers")));

                txtInput.Clear();
                rtbChat.ScrollToEnd();
                return;
            }

            // BOT RESPONSE
            string response = bot.GetResponse(input);

            rtbChat.Document.Blocks.Add(
                new Paragraph(
                    new Run("[" + DateTime.Now.ToString("HH:mm:ss") + "] Bot: " + response)));

            txtInput.Clear();
            rtbChat.ScrollToEnd();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            rtbChat.Document.Blocks.Clear();

            // RESET CHAT
            rtbChat.Document.Blocks.Add(
                new Paragraph(
                    new Run(
@"========================
   NSUKU CYBERSAFE BOT
========================

[" + DateTime.Now.ToString("HH:mm:ss") + @"] Bot: Hello! Welcome to CyberSafe Bot.
[" + DateTime.Now.ToString("HH:mm:ss") + @"] Bot: What is your name?")));

            askedName = true;
        }

        // ENTER KEY SUPPORT
        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnSend_Click(sender, e);
            }
        }
    }
}


