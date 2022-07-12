using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NET_PS_9.DAL;
using NET_PS_9.Models;

namespace NET_PS_9.Pages
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Product product { get; set; }
        private XmlDocument doc = new XmlDocument();
        IProductDB productDB;

        public DeleteModel(IProductDB _productDB)
        {
            productDB = _productDB;
        }
        public IActionResult OnGet(int _id)
        {
            productDB.Delete(_id);
            //ProductUpdate(product);
            return RedirectToPage("Index");
            //product = ProductGet(_id);
        }
        //private Product ProductGet(int _id)
        //{
        //    Product p = new Product();
        //    OpenXmlBase();
        //    XmlNode node = XmlNodeProductGet(_id);
        //    return XmlNodeProduct2Product(node);
        //}
        //private XmlNode XmlNodeProductGet(int _id)
        //{
        //    XmlNode node = null;
        //    XmlNodeList list = doc.SelectNodes("/store/product[@id=" + _id.ToString() + "]");
        //    node = list[0];
        //    return node;
        //}
        //private Product XmlNodeProduct2Product(XmlNode node)
        //{
        //    Product p = new Product();
        //    p.id = int.Parse(node.Attributes["id"].Value);
        //    p.name = node["name"].InnerText;
        //    p.price = decimal.Parse(node["price"].InnerText);
        //    return p;
        //}
        //public IActionResult OnPost()
        //{
        //    productDB.Delete(idProduct);
        //    //ProductUpdate(product);
        //    return RedirectToPage("Index");
        //}
        //private void OpenXmlBase()
        //{
        //    doc.Load("DATA/store.xml");
        //}
    }
}
