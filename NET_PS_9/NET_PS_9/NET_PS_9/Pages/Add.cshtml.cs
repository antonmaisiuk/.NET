using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NET_PS_9.Models;
using NET_PS_9.DAL;

namespace NET_PS_9.Pages
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public Product newProduct { get; set; }
        IProductDB productDB;

        //private XmlDocument doc = new XmlDocument();
        //private XDocument xdoc = XDocument.Load("DATA/store.xml");
        public AddModel(IProductDB _productDB)
        {
            productDB = _productDB;
        }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            productDB.Add(newProduct);
            //ProductAdd(newProduct);
            return RedirectToPage("Index");
        }

        //private Product ProductGet(int _id)
        //{
        //    Product p = new Product();
        //    OpenXmlBase();
        //    XmlNode node = XmlNodeProductGet(_id);
        //    return XmlNodeProduct2Product(node);
        //}
        //private void OpenXmlBase()
        //{
        //    xdoc.        
        //}
        //private void SaveXmlBase()
        //{
        //    doc.Save("DATA/store.xml");
        //}
        //private XmlNode XmlNodeProductGet(int _id)
        //{
        //    XmlNode node = null;
        //    XmlNodeList list = doc.SelectNodes("/store/product[@id=" + _id.ToString() + "]");
        //    node = list[0];
        //    return node;
        //}
        //private string GetId()
        //{
        //    decimal id = Decimal.Parse(XDocument.Load("DATA/store.xml")
        //              .Descendants("product")
        //              .Last()
        //              .Attribute("id").Value);


        //    //XmlDocument doc = new XmlDocument();
        //    //doc.Load("store.xml");

        //    //// Get and display all the book titles.
        //    //XmlElement root = doc.DocumentElement;
        //    //XmlNodeList elemList = root.GetElementsByTagName("name");
        //    //return elemList.Count+1;
        //    return (id+1).ToString();
        //}
        //private void ProductAdd(Product p)
        //{
        //    //OpenXmlBase();
        //    XDocument xdoc = XDocument.Load("DATA/store.xml");
        //    XElement? root = xdoc.Element("store");

        //    if (root != null)
        //    {
        //        // добавляем новый элемент
        //        root.Add(new XElement("product",
        //                    new XAttribute("id", GetId()),
        //                    new XElement("name", newProduct.name),
        //                    new XElement("price", newProduct.price)));

        //        xdoc.Save("DATA/store.xml");
        //    }

        //    //XDocument xdoc = new XDocument();
        //    //// создаем первый элемент person
        //    //XElement product = new XElement("product");
        //    //// создаем атрибут name
        //    //XAttribute productNameAttr = new XAttribute("id", GetId());
        //    //// создаем два элемента company и age 
        //    //XElement productNameElem = new XElement("name", newProduct.name);
        //    //XElement productPriceElem = new XElement("price", newProduct.price);
        //    //// добавляем атрибут и элементы в первый элемент person
        //    //product.Add(productNameAttr);
        //    //product.Add(productNameElem);
        //    //product.Add(productPriceElem);

        //    //xdoc.Save("DATA/store.xml");

        //    //doc.Load("DATA/store.xml");
        //    //XmlNode node = doc.CreateNode("element","product", null);
        //    //XmlAttribute attribute = doc.CreateAttribute("id");
        //    //attribute.Value = GetId();
        //    //node.Attributes.Append(attribute);



        //    //SaveXmlBase();
        //}
        //private Product XmlNodeProduct2Product(XmlNode node)
        //{
        //    Product p = new Product();
        //    p.id = int.Parse(node.Attributes["id"].Value);
        //    p.name = node["name"].InnerText;
        //    p.price = decimal.Parse(node["price"].InnerText);
        //    return p;
        //}
    }
}
