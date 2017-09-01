using System.Xml;
using System.IO;
using System;
using System.Diagnostics;

public abstract class SAXParser
{
    public virtual bool Read(string url)
    {
        bool ret = false;
        try
        {
            XmlTextReader reader = new XmlTextReader(url);
            ret = Read_Internal(reader);
        }
        catch (Exception ex)
        {
            Debug.Assert(false, ex.Message);
            System.Console.WriteLine(ex);
        }

        return ret;
    }

    public virtual bool Read(StringReader stringReader)
    {
        bool ret = false;
        try
        {
            XmlTextReader reader = new XmlTextReader(stringReader);
            ret = Read_Internal(reader);
        }
        catch (Exception ex)
        {
            Debug.Assert(false, ex.Message);
            System.Console.WriteLine(ex);
        }

        return ret;
    }

    protected abstract bool Read_Internal(XmlTextReader reader);
}