using HtmlAgilityPack;

namespace WebScraperConsoleApp;

public class BentonAloe
{
    public static void ViewPrices()
    {
        HttpClient client = new HttpClient();
        string websiteURL = "https://www.amazon.com/s?k=benton+aloe+toner&ref=nb_sb_noss";
        string response = client.GetStringAsync(websiteURL).Result;

        HtmlDocument htmlDocument = new HtmlDocument();

        htmlDocument.LoadHtml(response);

        HtmlNodeCollection titleNodes = htmlDocument.DocumentNode.SelectNodes("//span[contains(text(), 'Aloe Skin Toner')]");

        string[] titles = new string[titleNodes.Count];

        for (int i = 0; i < titleNodes.Count; i++)
        {
            titles[i] = titleNodes[i].InnerText.Trim();
        }

        foreach (var title in titleNodes)
        {
            Console.WriteLine(title);
        }
    }
}