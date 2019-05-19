﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AppStarter
{
    public class FileProperties : System.Collections.Hashtable
    {

        private String filename = string.Empty;

        public FileProperties(String filename)
        {

            this.SetFileName(filename);
            Load(filename);
        }

        public FileProperties()
        {
        }

        private void SetFileName(string filename)
        {
            this.filename = filename;
        }

        public override void Add(object key, object value)
        {
            if (base.ContainsKey(key))
            {
                base.Remove(key);
            }
            base.Add(key, value);
        }

        public override ICollection Keys
        {
            get
            {
                return base.Keys;
            }
        }

        public void Load(string filename)
        {
            char[] convertBuf = new char[1024];

            int limit;
            int keyLen;
            int valueStart;
            char c;
            string bufLine = string.Empty;
            bool hasSep;
            bool precedingBackslash;

            using (StreamReader sr = new StreamReader(filename))
            {
                while (sr.Peek() >= 0)
                {
                    bufLine = sr.ReadLine();
                    limit = bufLine.Length;
                    keyLen = 0;
                    valueStart = limit;
                    hasSep = false;

                    precedingBackslash = false;
                    if (bufLine.StartsWith("#"))
                        keyLen = bufLine.Length;

                    while (keyLen < limit)
                    {
                        c = bufLine[keyLen];
                        if ((c == '=' || c == ':') & !precedingBackslash)
                        {
                            valueStart = keyLen + 1;
                            hasSep = true;
                            break;
                        }
                        else if ((c == ' ' || c == '\t' || c == '\f') & !precedingBackslash)
                        {
                            valueStart = keyLen + 1;
                            break;
                        }
                        if (c == '\\')
                        {
                            precedingBackslash = !precedingBackslash;
                        }
                        else
                        {
                            precedingBackslash = false;
                        }
                        keyLen++;
                    }

                    while (valueStart < limit)
                    {
                        c = bufLine[valueStart];
                        if (c != ' ' && c != '\t' && c != '\f')
                        {
                            if (!hasSep && (c == '=' || c == ':'))
                            {
                                hasSep = true;
                            }
                            else
                            {
                                break;
                            }
                        }
                        valueStart++;
                    }

                    string key = bufLine.Substring(0, keyLen);

                    string values = bufLine.Substring(valueStart, limit - valueStart);

                    if (key == "")
                        key += "#";
                    while (key.StartsWith("#") & this.Contains(key))
                    {
                        key += "#";
                    }

                    this.Add(key, values);
                }
            }
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="filePath">要保存的Properties文件</param>
        /// <returns></returns>
        public void Save(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            FileStream fileStream = File.Create(filePath);
            StreamWriter sw = new StreamWriter(fileStream);
            foreach (object item in base.Keys)
            {
                String key = (String)item;
                String val = (String)this[key];
                if (key.StartsWith("#"))
                {
                    if (val == "")
                    {
                        sw.WriteLine(key);
                    }
                    else
                    {
                        sw.WriteLine(val);
                    }
                }
                else
                {
                    sw.WriteLine(key + "=" + val);
                }
            }
            sw.Close();
            fileStream.Close();
        }
    }
}
