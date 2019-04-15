using Programmeringsuppgift.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Xml;

namespace Programmeringsuppgift.XmlHelper
{
    public static class XmlDocumentHandler
    {
        public static List<Book> GetBooksFromDocument(XmlDocument xmlDocument)
        {
            List<Book> books = new List<Book>();

            foreach (XmlNode node in xmlDocument.SelectNodes("/catalog/book"))
            {
                books.Add(new Book
                {
                    id = node.Attributes["id"].InnerText,
                    title = node["title"].InnerText,
                    author = node["author"].InnerText,
                    genre = node["genre"].InnerText,
                    price = decimal.Parse(node["price"].InnerText, CultureInfo.InvariantCulture),
                    publish_date = DateTime.Parse(node["publish_date"].InnerText),
                    description = node["description"].InnerText
                });
            }

            return books;
        }

    }
}
