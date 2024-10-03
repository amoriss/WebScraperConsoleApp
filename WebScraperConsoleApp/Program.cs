

using HtmlAgilityPack;

HttpClient client = new HttpClient();
string websiteURL = $"https://developer.mozilla.org/en-US/docs/WebAssembly";

string response = client.GetStringAsync(websiteURL).Result;

HtmlDocument htmlDocument = new HtmlDocument();

htmlDocument.LoadHtml(response);

var titleNodes = htmlDocument.DocumentNode.SelectNodes("//h2");

string[] titles = new string[titleNodes.Count];

for (int i = 0; i < titleNodes.Count; i++)
{
    titles[i] = titleNodes[i].InnerText.Trim();
}

foreach (var title in titles)
{
    Console.WriteLine(title);
}
