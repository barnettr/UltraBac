using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ZNode.Libraries.Integrator
{
    /// <summary>
    /// Collection of various encode-related static methods.
    /// </summary>
    public class EncodeHelper
    {
        /// <summary>
        /// Makes XML out of an object.
        /// </summary>
        /// <param name="ObjectToSerialize">The object to serialize.</param>
        /// <returns>An XML string representing the object.</returns>        
        public static byte[] Serialize(object ObjectToSerialize)
        {
            System.Xml.Serialization.XmlSerializer Ser = new System.Xml.Serialization.XmlSerializer(ObjectToSerialize.GetType());
            using (MemoryStream MS = new MemoryStream())
            {
                System.Xml.XmlTextWriter W = new System.Xml.XmlTextWriter(MS, new UTF8Encoding(false));
                W.Formatting = System.Xml.Formatting.Indented;
                Ser.Serialize(W, ObjectToSerialize);
                W.Flush();
                W.Close();
                return MS.ToArray();
            }
        }


        /// <summary>
        /// Generic Deserialize method that will attempt to deserialize any class
        /// in the GCheckout.AutoGen namespace.
        /// </summary>
        /// <param name="Xml">The XML that should be made into an object.</param>
        /// <returns>The reconstituted object.</returns>
        public static object Deserialize(string Xml, Type ThisType)
        {
            XmlSerializer myDeserializer = new XmlSerializer(ThisType);
            using (StringReader myReader = new StringReader(Xml))
            {
                return myDeserializer.Deserialize(myReader);
            }
        }
        /// <summary>
        /// Generic Deserialize method that will attempt to deserialize any class
        /// in the GCheckout.AutoGen namespace.
        /// </summary>
        /// <param name="Xml">The XML that should be made into an object.</param>
        /// <returns>The reconstituted object.</returns>
        public static object Deserialize(Stream Xml)
        {

            //get the name of the node, this is what we will use for the lookup.
            string nodeName = GetTopElement(Xml);

            //ok here is where the fun starts.
            string nameSpace = typeof(Google.Hello).Namespace;
            Type[] types
              = System.Reflection.Assembly.GetExecutingAssembly().GetTypes();

            Type reflectedType = null;

            foreach (Type t in types)
            {
                if (t.Namespace == nameSpace && t.IsClass)
                {
                    //Console.WriteLine(t.Name);
                    XmlRootAttribute[] att
                      = t.GetCustomAttributes(typeof(XmlRootAttribute), true)
                      as XmlRootAttribute[];
                    //if we found the custom attribute, then we need to see
                    //if the element name is correct.
                    if (att != null && att.Length > 0)
                    {
                        if (att[0].ElementName == nodeName)
                        {
                            reflectedType = t;
                            break;
                        }
                    }
                }
            }

            //ok either the type is supported or it is not
            //if we could not find the correct type then we must have either
            //an incorrect dll for the message, or the message
            //is not a Google Checkout message. Return null if the type
            //can't be deserialized.
            if (reflectedType != null)
            {
                XmlSerializer myDeserializer = new XmlSerializer(reflectedType);
                return myDeserializer.Deserialize(Xml);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Deserialize was not able" +
                  "To locate a message of type:" + nodeName + "");
                return null;
            }
        }
        /// <summary>
        /// Converts a string to bytes in UTF-8 encoding.
        /// </summary>
        /// <param name="InString">The string to convert.</param>
        /// <returns>The UTF-8 bytes.</returns>
        public static byte[] StringToUtf8Bytes(string InString)
        {
            UTF8Encoding utf8encoder = new UTF8Encoding(false, true);
            return utf8encoder.GetBytes(InString);
        }

        /// <summary>
        /// Converts bytes in UTF-8 encoding to a regular string.
        /// </summary>
        /// <param name="InBytes">The UTF-8 bytes.</param>
        /// <returns>The input bytes as a string.</returns>
        public static string Utf8BytesToString(byte[] InBytes)
        {
            UTF8Encoding utf8encoder = new UTF8Encoding(false, true);
            return utf8encoder.GetString(InBytes);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Xml"></param>
        /// <returns></returns>
        public static string GetTopElement(string Xml)
        {
            return GetTopElement(StringToUtf8Bytes(Xml));
        }

        public static string GetTopElement(byte[] Xml)
        {
            using (MemoryStream ms = new MemoryStream(Xml))
            {
                return GetTopElement(ms);
            }
        }
        /// <summary>
        /// Returns the top element of the xml
        /// </summary>
        /// <param name="Xml"></param>
        /// <returns></returns>
        public static string GetTopElement(Stream Xml)
        {
            //set the begin postion so we can set the stream back when we are done.
            long beginPos = Xml.Position;
            XmlTextReader XReader = new XmlTextReader(Xml);
            XReader.WhitespaceHandling = WhitespaceHandling.None;            
            XReader.Read();
            XReader.Read();
            string RetVal = XReader.Name;
            //Do not close the stream, we will still need it for additional
            //operations.
            //XReader.Close();
            //reposition the stream to where it started
            Xml.Position = beginPos;
            return RetVal;
        }
    }
}
