using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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

        /// <summary>
        /// Initializes a new instance of the <see cref="Data"/> class.
        /// </summary>
        /// <param name="NameOfDocument">The name of document.</param>
        public Data(string NameOfDocument)
        {
            _nameOfDocument = NameOfDocument;
            _xmlDocument = new XmlDocument();
            _xmlDocument.Load("./../../../../../data/"+NameOfDocument + ".xml");
            _userNodes = _xmlDocument.SelectNodes("//users/user");
        }

        /// <summary>
        /// Creates the data document.
        /// </summary>
        /// <param name="NameOfDocument">The name of document.</param>
        /// <returns></returns>
        public bool CreateDataDocument(string NameOfDocument)
        {
            _rootNode = _xmlDocument.CreateElement("users");
            _xmlDocument.AppendChild(_rootNode);
            _userNode = _xmlDocument.CreateElement("user");
            _xmlDocument.Save("./../../../../../data/" + NameOfDocument+".xml");
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
        public bool AddDataInDocument(string NameOfDocument, string Attribute, string AttributeValue, string Value)
        {
            _xmlDocument.Load("./../../../../../data/" + NameOfDocument + ".xml");
            _userNode = _xmlDocument.CreateElement("user");
            _attribute = _xmlDocument.CreateAttribute(Attribute);
            _attribute.Value = AttributeValue;
            _userNode.Attributes.Append(_attribute);
            _userNode.InnerText = Value;
            _xmlDocument.Save("./../../../../../data/" + NameOfDocument + ".xml");
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
            _xmlDocument.Load("./../../../../../data/" + NameOfDocument + ".xml");
            _userNodes = _xmlDocument.SelectNodes("//users/user");
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
            _xmlDocument.Load("./../../../../../data/" + NameOfDocument+".xml");
            _userNodes = _xmlDocument.SelectNodes("//users/user");
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
            _xmlDocument.Load("./../../../../../data/" + NameOfDocument + ".xml");
            XmlNodeList userNodes = _xmlDocument.SelectNodes("//users/user");
            userNodes.Item(index).FirstChild.Value = Value;
            _xmlDocument.Save("./../../../../../data/" + NameOfDocument + ".xml");
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
            _xmlDocument.Load("./../../../../../data/" + NameOfDocument + ".xml");
            XmlNodeList userNodes = _xmlDocument.SelectNodes("//users/user");

            int Attribute = int.Parse(_userNodes.Item(index).Attributes["age"].Value);
            _userNodes.Item(index).Attributes["age"].Value = Value.ToString();

            _xmlDocument.Save("./../../../../../data/" + NameOfDocument + ".xml");
            return userNodes;
        }
    }
}
