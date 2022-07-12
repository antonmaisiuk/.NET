using Microsoft.Extensions.Configuration;
using NET_PS_9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace NET_PS_9.DAL
{
    public class ProductXmlDB : IProductDB
    {
        XmlDocument db = new XmlDocument();
        string xmlDB_path;
        public ProductXmlDB(IConfiguration _configuration)
        {
            xmlDB_path = _configuration.GetValue<string>("AppSettings:XmlDB_path");
            LoadDB();
        }
        private void LoadDB()
        {
            db.Load(xmlDB_path);
        }
        private void SaveDB()
        {
            db.Save(xmlDB_path);
        }
        public List<Product> List()
        {
            List<Product> productList = new List<Product>();
            XmlNodeList productXmlNodeList = db.SelectNodes("/store/product");
            foreach (XmlNode productXmlNode in productXmlNodeList)
            {
                productList.Add(XmlNodeProduct2Product(productXmlNode));
            }
            return productList;
        }
        private Product XmlNodeProduct2Product(XmlNode node)
        {
            Product p = new Product();
            p.id = int.Parse(node.Attributes["id"].Value);
            p.name = node["name"].InnerText;
            p.price = decimal.Parse(node["price"].InnerText);
            return p;
        }
        private XmlNode XmlNodeProductGet(int _id)
        {
            XmlNode node = null;
            XmlNodeList list = db.SelectNodes("/store/product[@id=" + _id.ToString() + "]");
            node = list[0];
            return node;
        }

        private string GetId()
        {
            decimal id = Decimal.Parse(XDocument.Load("DATA/store.xml")
                      .Descendants("product")
                      .Last()
                      .Attribute("id").Value);

            return (id + 1).ToString();
        }

        public Product Get(int _id)
        { return null; }


        public void Update(Product _product)
        {
            XmlNode node = XmlNodeProductGet(_product.id);
            node["name"].InnerText = _product.name;
            node["price"].InnerText = _product.price.ToString();
            SaveDB();
        }

        public void Delete(int _id)
        {
            //XmlDocument xmlDoc = new XmlDocument();
            //db.Load("Parties.xml");
            XmlNode t = db.SelectSingleNode("/store/product[@id='" + _id + "']");
            t.ParentNode.RemoveChild(t);
            SaveDB();
        }        

        public void Add(Product _product)
        {
            
            //XmlDocument xdoc = XDocument.LoadDB();
            XmlElement root = db.DocumentElement;

            XmlElement productElem = db.CreateElement("product");
            // создаем атрибут name
            XmlAttribute idAttr = db.CreateAttribute("id");

            // создаем элементы company и age
            XmlElement nameElem = db.CreateElement("name");
            XmlElement priceElem = db.CreateElement("price");

            // создаем текстовые значения для элементов и атрибута
            XmlText idText = db.CreateTextNode(GetId());
            XmlText nameText = db.CreateTextNode(_product.name);
            XmlText priceText = db.CreateTextNode(_product.price.ToString());

            //добавляем узлы
            idAttr.AppendChild(idText);
            nameElem.AppendChild(nameText);
            priceElem.AppendChild(priceText);

            // добавляем атрибут name
            productElem.Attributes.Append(idAttr);
            // добавляем элементы company и age
            productElem.AppendChild(nameElem);
            productElem.AppendChild(priceElem);
            root.AppendChild(productElem);

            //if (root != null)
            //{
            //    foreach (XmlElement node in root)
            //    {
            //        Product product = new Product();
            //        XmlNode attr = node.Attributes.GetNamedItem("id");
            //        product.id = Int32.Parse(attr?.Value);

            //        foreach (XmlNode childnode in node.ChildNodes)
            //        {
            //            if (childnode.Name == "name")
            //                product.name = childnode.InnerText;

            //            if (childnode.Name == "price")
            //                product.price = Decimal.Parse(childnode.InnerText);
            //        }
            //        productsAdd.Add(product);
            //    }

            // добавляем новый элемент
            //root.Add(new XElement("product",
            //            new XAttribute("id", GetId()),
            //            new XElement("name", _product.name),
            //            new XElement("price", _product.price)));

            SaveDB();
            
        }
    }
}
