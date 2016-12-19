using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Kepler_22_B.API.Data
{
    public class Data
    {
        XmlDocument _xmlDocument;
        XmlNode _userNode;
        XmlNode _rootNode;
        XmlNodeList _userNodes;
        XmlAttribute _attribute;
        string _nameOfDocument;
        string _contentElement;
        string _element;
        string _nameAttribute;
        string _path;

        /// <summary>
        /// Initializes a new instance of the <see cref="Data"/> class.
        /// </summary>
        /// <param name="NameOfDocument">The name of document.</param>
        public Data(string NameOfDocument)
        {
            _nameOfDocument = NameOfDocument;
            _xmlDocument = new XmlDocument();
            _xmlDocument.Load(@"..\..\..\..\..\data\"+NameOfDocument + ".xml");
            _userNodes = _xmlDocument.SelectNodes("//users/user");
            _contentElement = "users";
            _element = "user";
            _nameAttribute = "attribute";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Data"/> class.
        /// </summary>
        /// <param name="NameOfDocument">The name of document.</param>
        public Data(string NameOfDocument, string firstElement, string path = @"..\..\..\..\..\data\")
        {
            _path = path;
            _nameOfDocument = NameOfDocument;
            new XDocument(new XElement(firstElement)).Save(path + _nameOfDocument);
        }

        /// <summary>
        /// Gets or sets the name of the content element.
        /// </summary>
        /// <value>
        /// The name of the get content element.
        /// </value>
        public string GetContentElementName { get { return _contentElement; } set { _contentElement = value; } }

        /// <summary>
        /// Gets or sets the name of the element.
        /// </summary>
        /// <value>
        /// The name of the get element.
        /// </value>
        public string GetElementName { get { return _element; } set { _element = value; } }

        /// <summary>
        /// Gets or sets the name of the  attribute.
        /// </summary>
        /// <value>
        /// The name of the get attribute.
        /// </value>
        public string GetAttributeName { get { return _nameAttribute; } set { _nameAttribute = value; } }

        /// <summary>
        /// Creates the data document.
        /// </summary>
        /// <param name="NameOfDocument">The name of document.</param>
        /// <returns></returns>
        public bool CreateDataDocument(string NameOfDocument)
        {
            _rootNode = _xmlDocument.CreateElement(_contentElement);
            _xmlDocument.AppendChild(_rootNode);
            _userNode = _xmlDocument.CreateElement(_element);
            _xmlDocument.Save("./../../../data/" + NameOfDocument+".xml");
            return true;
        }

        /// <summary>
        /// Adds the data in document.
        /// </summary>
        /// <param name="NameOfDocument">The name of document.</param>
        /// <param name="Attribute">The attribute.</param>
        /// <param name="AttributeValue">The attribute value.</param>
        /// <param name="Value">The value.</param>
        /// <returns></returns>
        public bool AddDataInDocument(string NameOfDocument, string AttributeValue, string Value)
        {
            _xmlDocument.Load("./../../../data/" + NameOfDocument + ".xml");
            _userNode = _xmlDocument.CreateElement(_element);
            _attribute = _xmlDocument.CreateAttribute(_nameAttribute);
            _attribute.Value = AttributeValue;
            _userNode.Attributes.Append(_attribute);
            _userNode.InnerText = Value;
            _xmlDocument.Save("./../../../data/" + NameOfDocument + ".xml");
            return true;
        }

        /// <summary>
        /// Deletes the data in document.
        /// </summary>
        /// <param name="NameOfDocument">The name of document.</param>
        /// <param name="Value">The value.</param>
        /// <returns></returns>
        public bool DeleteDataInDocument(string NameOfDocument, string Value)
        {
            _xmlDocument.Load("./../../../data/" + NameOfDocument + ".xml");
            _userNodes = _xmlDocument.SelectNodes("//"+_contentElement+"/"+_element);
            foreach (XmlNode userNodee in _userNodes)
            {
                if (userNodee.Value == Value) userNodee.RemoveChild(userNodee);
            }
            return true;
        }

        /// <summary>
        /// Gets the data in tab.
        /// </summary>
        /// <param name="NameOfDocument">The name of document.</param>
        /// <returns></returns>
        public XmlNodeList GetDataInTab(string NameOfDocument)
        {
            _xmlDocument.Load(@"..\..\..\..\..\data\" + NameOfDocument+".xml");
            _userNodes = _xmlDocument.SelectNodes("//"+ _contentElement + "/"+_element);
            return _userNodes;
        }

        /// <summary>
        /// Replaces the data in tab.
        /// </summary>
        /// <param name="NameOfDocument">The name of document.</param>
        /// <param name="Value">The value.</param>
        /// <returns></returns>
        public XmlNodeList ReplaceDataInTab(string NameOfDocument, int index, string Value)
        {
            _xmlDocument.Load("./../../../data/" + NameOfDocument + ".xml");
            XmlNodeList userNodes = _xmlDocument.SelectNodes("//" + _contentElement + "/" + _element);
            userNodes.Item(index).FirstChild.Value = Value;
            _xmlDocument.Save("./../../../data/" + NameOfDocument + ".xml");
            return userNodes;
        }

        /// <summary>
        /// Replaces the attribute in tab.
        /// </summary>
        /// <param name="NameOfDocument">The name of document.</param>
        /// <param name="index">The index.</param>
        /// <param name="Value">The value.</param>
        /// <returns></returns>
        public XmlNodeList ReplaceAttributeInTab(string NameOfDocument, int index, string Value)
        {
            _xmlDocument.Load("./../../../data/" + NameOfDocument + ".xml");
            XmlNodeList userNodes = _xmlDocument.SelectNodes("//" + _contentElement + "/" + _element);

            int Attribute = int.Parse(_userNodes.Item(index).Attributes[_nameAttribute].Value);
            _userNodes.Item(index).Attributes[_nameAttribute].Value = Value.ToString();

            _xmlDocument.Save("./../../../data/" + NameOfDocument + ".xml");
            return userNodes;
        }

        public int SearchIndex()
        {
            return 1;
        }
    }
}
