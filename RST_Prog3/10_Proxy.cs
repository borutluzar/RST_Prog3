using System;
using System.Collections.Generic;
using System.Text;

namespace RST_Prog3
{
    #region Varnostni proxy
    public interface IInternet
    {
        void ConnectTo(string url);
    }

    public class InternetConnector : IInternet
    {
        public void ConnectTo(string url)
        {
            Console.WriteLine($"Povezava na {url} je vzpostavljena!");
        }
    }

    // Primer "varnostnega" proxy-ja
    public class OfficeInternetProxy : IInternet
    {
        private readonly InternetConnector connector = new InternetConnector();

        private static readonly List<string> BannedSites = new List<string>() { "facebook.com", "gamble.com", "reddit.com" };

        public void ConnectTo(string url)
        {
            // Preverimo URL
            if (BannedSites.Contains(url.ToLower()))
            {
                Console.WriteLine($"Dostop je zavrnjen. " +
                    $"Obiska strani na {url} podjetje ne dovoli. " +
                    $"Direktor je o vašem poskusu že obveščen!");
                return;
            }

            // Zabeležimo dogodek
            Console.WriteLine($"LOG: Uporabnik se poskuša povezati na {url} ob {DateTime.Now:HH:mm:ss}.");

            // Povežemo
            this.connector.ConnectTo(url);
        }
    }
    #endregion


    #region Virtualni proxy

    public interface IPost
    {
        void ShowPost();
    }

    public class RealPost : IPost 
    {
        private string imageUrl;

        public RealPost(string imageUrl)
        {
            this.imageUrl = imageUrl;
            DownloadImage();
        }

        private void DownloadImage()
        {
            Console.WriteLine($"Prenašam 50 MB podatkov iz {this.imageUrl}...");
            // Simulacija počasnega omrežja
            Thread.Sleep(2000);
        }

        public void ShowPost()
        {
            Console.WriteLine($"Prikazujem fotografijo iz {this.imageUrl}!");
        }
    }

    // Primer razreda virtualnega proxy-ja
    public class PostProxy : IPost 
    {
        private RealPost realPost;
        private string imageUrl;

        public PostProxy(string imageUrl)
        {
            this.imageUrl = imageUrl;
            // Naložimo samo thumbnail...
        }

        public void ShowPost()
        {
            // Lazy loading: zgodi se šele, ko uporabnik vidi objavo na zaslonu
            if(this.realPost == null)
            {
                this.realPost = new RealPost(this.imageUrl);
            }

            this.realPost.ShowPost();
        }
    }

    #endregion
}
