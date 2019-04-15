using Programmeringsuppgift.Models;
using Programmeringsuppgift.XmlHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace Programmeringsuppgift.Controllers
{
    public class HomeController : Controller
    {
        private readonly XmlDocument _xmlDocument = new XmlDocument();
        public HomeController()
        {
            _xmlDocument.Load("C:\\Users\\Abbe\\Desktop\\books.xml" ?? throw new ArgumentNullException());
        }
        //public ActionResult Index()
        //{
        //    var books = XmlDocumentHandler.GetBooksFromDocument(_xmlDocument);
        //    ViewBag.Title = "Home Page";

        //    return View(books);
        //}
        //XXX Tar bort denna och låter det enbart vara en metod

        public ActionResult Index(string searchByOperator, string searchParameter)
        {
            var books = XmlDocumentHandler.GetBooksFromDocument(_xmlDocument);
            ViewBag.Title = "Book Search";

            if (!String.IsNullOrEmpty(searchByOperator) || !String.IsNullOrEmpty(searchParameter))
            {
                if (searchByOperator == "Title")
                {
                    return View(books.Where(x => x.title.Contains(searchParameter) || searchParameter == null).ToList());
                }
                if(searchByOperator == "Id")
                {
                    return View(books.Where(x => x.id == searchParameter.ToUpper() || searchParameter == null).ToList());
                }
            }
            else
            {
                return View(books);
                // throw new ArgumentNullException("Input parameter missing!"); XXX-Behöver kasta nytt exception mer, right? 
            }
            //Borde returna något form av meddelande eller liknande XXX - Behöver inte denna heller mer, right?
            return null;

        }
    }
}
