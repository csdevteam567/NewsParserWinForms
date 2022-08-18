using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using NewsParserWinForms.Model;
using System.Linq;
using NewsParserWinForms.Messenger;

namespace NewsParserWinForms
{
    public partial class MainForm : Form
    {
        private static System.Windows.Forms.WebBrowser webBrowser;

        private static AppConfiguration config;
        private static DatabaseAccess dbAccess;
        private static Object obj = new Object();
        private static List<ParserConfig> parserConfigs;
        private static TelegramSender tlg;

        private static bool isParserWorking;


        public MainForm()
        {
            InitializeComponent();

            config = new AppConfiguration();
            dbAccess = new DatabaseAccess(config.ConnectionString);

            webBrowser = new System.Windows.Forms.WebBrowser();
            webBrowser.Visible = false;
            webBrowser.ScriptErrorsSuppressed = true;
            webBrowser.DocumentCompleted += webBrowser_DocumentCompleted;

            parserConfigs = new List<ParserConfig>();
            parserConfigs.Add(new ParserConfig()
            {
                BaseUrl = "https://www.ukr.net/news/main.html",
                TitleTag = "//main[@id='main']/div/h2",
                //ContentTag = "//main[@id='main']/div/article/section/div/div/a"
                ContentTag = "//a[@class='im-tl_a']"
            });
            tlg = new TelegramSender(config.TelegramToken, config.TelegramChatId);

            parserInfoLabel.Visible = false;
            parserInfoLabel.Text = "Parser started, it will parse pages every " + config.ParseInterval / 1000 + " seconds"; 
        }

        private void MainForm_Load(object sender, EventArgs e)
        { 
            
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string url = e.Url.Host;
            System.Windows.Forms.HtmlDocument elCollection = webBrowser.Document;
            string str = elCollection.Body.InnerHtml;
            Task.Run(() => ParseWebPage(url, str));
        }

        private static void ParseWebPage(string urlHost, string html)
        {
            lock (obj)
            {

                ParserConfig config = parserConfigs.Where(cf => cf.BaseUrl.Contains(urlHost)).First();
                News newsRecord = null;
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);

                string title = doc.DocumentNode.SelectSingleNode(config.TitleTag).InnerText;
                var contentNodes = doc.DocumentNode.SelectNodes(config.ContentTag);

                foreach (var el in contentNodes)
                {
                    dbAccess.AddNewsRecord(new News()
                    {
                        Title = title,
                        Content = el.InnerText
                    });

                    tlg.SendMessage(new Messenger.Message()
                    {
                        Title = title,
                        Body = el.InnerText
                    });
                }
            }
        }

        private void startParserBtn_Click(object sender, EventArgs e)
        {
            if (!isParserWorking)
            {
                Thread parserLauncherThread;
                parserLauncherThread = new Thread(ParserWorkerLauncher);
                parserLauncherThread.IsBackground = true;
                parserLauncherThread.Start();
                isParserWorking = true;
                parserInfoLabel.Visible = true;
            }
        }

        private void stopParserBtn_Click(object sender, EventArgs e)
        {
            isParserWorking = false;
            parserInfoLabel.Visible = false;
        } 

        private static void ParserWorkerLauncher()
        {
            while (true)
            {
                if (!isParserWorking)
                    break;
                foreach (var pc in parserConfigs)
                {
                    //Task.Run(() => ParserWorkerFunc(pc));
                    // webBrowser.Navigate(new Uri(pc.BaseUrl));
                    Task.Run(() => webBrowser.Navigate(new Uri(pc.BaseUrl)));
                }

                Thread.Sleep(config.ParseInterval);
            }
        }
    }
}
