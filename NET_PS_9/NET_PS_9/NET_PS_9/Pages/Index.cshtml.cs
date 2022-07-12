using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using NET_PS_9.DAL;
using NET_PS_9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace NET_PS_9.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> productList;
        IProductDB productDB;
        public IndexModel(IProductDB _productDB)
        {
            productDB = _productDB;
            productList = productDB.List();
        }
        public void OnGet()
        {
            

            //XmlDocument doc = new XmlDocument();
            //doc.Load("DATA/store.xml");
            //XmlNodeList xnList = doc.SelectNodes("/store/product");
            //foreach (XmlNode xn in xnList)
            //{
            //    productList.Add(XmlNode2Product(xn));
            //}
        }
        //private Product XmlNode2Product(XmlNode node)
        //{
        //    Product p = new Product();
        //    p.id = int.Parse(node.Attributes["id"].Value);
        //    p.name = node["name"].InnerText;
        //    p.price = decimal.Parse(node["price"].InnerText);
        //    return p;
        //}
    }
}
