using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace WpfWikipediaAPI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                textBox2.Clear();
                if(!string.IsNullOrEmpty(textBox1.Text))
                {
                    string srs = textBox1.Text;
                    srs.Replace(" ", "%20");
                    string url = $"https://en.wikipedia.org/w/api.php?action=query&list=search&srsearch= {srs} &utf8=&format=json".Replace(" ","");

                    string result = VratiJson(url);

                    Query ms = JsonConvert.DeserializeObject<Query>(result);

                    //textBox2.Text = ms.query.Search.Count.ToString();
                    //textBox2.Text = ms.query.Search[0].PageId.ToString() + "\n" + ms.query.Search[0].Title
                    //    + "\n" + ms.query.Search[0].Snippet;

                    for (int i = 0; i < ms.query.Search.Count; i++)
                    {
                        string s = $"Snippet:\n\t {ms.query.Search[i].Snippet}\n";
                        textBox2.AppendText($"\nPageID: {ms.query.Search[i].PageId}\n");
                        textBox2.AppendText($"Title:\n\t {ms.query.Search[i].Title}\n");
                        textBox2.AppendText(StripHTML(s));
                    }
                }            
            }
        }  
        
        //this will replave all html tags
        public static string StripHTML(string input)
        {
            return Regex.Replace(input, "<[a-zA-Z/]*?>", String.Empty);
        }

        public string VratiJson(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    string errorText = reader.ReadToEnd();
                }
                throw;
            }
        }


    }
     
}
