using System.Xml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NET_PS_9.Models;
using NET_PS_9.DAL;

namespace NET_PS_9.Pages
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Product product { get; set; }
        private XmlDocument doc = new XmlDocument();
        IProductDB productDB;

        public EditModel(IProductDB _productDB)
        {
            productDB = _productDB;
        }
        public void OnGet(int _id)
        {
            product = ProductGet(_id);
        }
        public IActionResult OnPost()
        {
            productDB.Update(product);
            //ProductUpdate(product);
            return RedirectToPage("Index");
        }
        private Product ProductGet(int _id)
        {
            Product p = new Product();
            OpenXmlBase();
            XmlNode node = XmlNodeProductGet(_id);
            return XmlNodeProduct2Product(node);
        }
        private XmlNode XmlNodeProductGet(int _id)
        {
            XmlNode node = null;
            XmlNodeList list = doc.SelectNodes("/store/product[@id=" + _id.ToString() + "]");
            node = list[0];
            return node;
        }
        private Product XmlNodeProduct2Product(XmlNode node)
        {
            Product p = new Product();
            p.id = int.Parse(node.Attributes["id"].Value);
            p.name = node["name"].InnerText;
            p.price = decimal.Parse(node["price"].InnerText);
            return p;
        }
        
        private void OpenXmlBase()
        {
            doc.Load("DATA/store.xml");
        }
        //private void SaveXmlBase()
        //{
        //    doc.Save("DATA/store.xml");
        //}
        //private void ProductUpdate(Product p)
        //{
        //    OpenXmlBase();
        //    XmlNode node = XmlNodeProductGet(product.id);
        //    node["name"].InnerText = p.name;
        //    node["price"].InnerText = p.price.ToString();
        //    SaveXmlBase();
        //}
    }
}
