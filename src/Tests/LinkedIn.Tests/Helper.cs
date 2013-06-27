//-----------------------------------------------------------------------
// <copyright file="Constants.cs" company="Beemway">
//     Copyright (c) Beemway. All rights reserved.
// </copyright>
// <license>
//     Microsoft Public License (Ms-PL http://opensource.org/licenses/ms-pl.html).
//     Contributors may add their own copyright notice above.
// </license>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace LinkedIn.Tests
{
  /// <summary>
  /// A helper class.
  /// </summary>
  internal static class Utility
  {
    public static string WriteXml(IXmlSerializable target)
    {
      StringBuilder sb = new StringBuilder();
      XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
      xmlWriterSettings.ConformanceLevel = ConformanceLevel.Fragment;
      using (XmlWriter writer = XmlTextWriter.Create(sb, xmlWriterSettings))
      {
        XmlRootAttribute[] xmlRootAttribute = target.GetType().GetCustomAttributes(typeof(XmlRootAttribute), false) as XmlRootAttribute[];
        writer.WriteStartElement(xmlRootAttribute[0].ElementName);
        target.WriteXml(writer);
        writer.WriteEndElement();
      }

      return sb.ToString();
    }

    public static string EscapeXml(string value)
    {
      if (string.IsNullOrEmpty(value))
      {
        return value;
      }

      string returnValue = value;
      returnValue = returnValue.Replace("&", "&amp;");
      returnValue = returnValue.Replace(">", "&gt;");
      returnValue = returnValue.Replace("<", "&lt;");

      return returnValue;
    }

    public static string UnescapeXml(string value)
    {
      if (string.IsNullOrEmpty(value))
      {
        return value;
      }

      string returnValue = value;
      returnValue = returnValue.Replace("&apos;", "'");
      returnValue = returnValue.Replace("&quot;", "\"");
      returnValue = returnValue.Replace("&gt;", ">");
      returnValue = returnValue.Replace("&lt;", "<");
      returnValue = returnValue.Replace("&amp;", "&");

      return returnValue;
    }
  }
}
