// Decompiled with JetBrains decompiler
// Type: MasterCard.Core.Model.SmartMap
// Assembly: MasterCard-Core, Version=1.4.0.26200, Culture=neutral, PublicKeyToken=null
// MVID: FBF9ACCE-839B-46D3-83A0-494225AC75CB
// Assembly location: D:\Sources\Mastercom\MasterComTest\packages\MasterCard-Core.1.4.0\lib\MasterCard-Core.dll

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MasterCard.Core.Model
{
  public class SmartMap : IDictionary<string, object>, ICollection<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable
  {
    private static readonly Regex arrayIndexPattern = new Regex("(.*)\\[(.*)\\]");
    private Dictionary<string, object> __storage;
    private bool caseInsensitive;

    public int Count
    {
      get
      {
        return this.__storage.Count;
      }
    }

    public object this[string key]
    {
      get
      {
        return this.Get(key);
      }
      set
      {
        this.Add(key, value);
      }
    }

    ICollection<string> IDictionary<string, object>.Keys
    {
      get
      {
        return (ICollection<string>) this.__storage.Keys;
      }
    }

    ICollection<object> IDictionary<string, object>.Values
    {
      get
      {
        return (ICollection<object>) this.__storage.Values;
      }
    }

    bool ICollection<KeyValuePair<string, object>>.IsReadOnly
    {
      get
      {
        return ((ICollection<KeyValuePair<string, object>>) this.__storage).IsReadOnly;
      }
    }

    public SmartMap(bool caseInsensitive = false)
    {
      this.caseInsensitive = caseInsensitive;
      this.__storage = SmartMap.createNewInstance(caseInsensitive);
    }

    public SmartMap(SmartMap bm)
    {
      this.__storage = bm.__storage;
    }

    public SmartMap(IDictionary<string, object> map, bool caseInsensitive = false)
    {
      this.caseInsensitive = caseInsensitive;
      this.__storage = SmartMap.createNewInstance(caseInsensitive);
      if (caseInsensitive)
        this.AddAll((IDictionary<string, object>) SmartMap.ParseDictionary(map, true));
      else
        this.AddAll(map);
    }

    public SmartMap(string jsonMapString, bool caseInsensitive = false)
    {
      this.caseInsensitive = caseInsensitive;
      this.__storage = SmartMap.createNewInstance(caseInsensitive);
      this.AddAll(SmartMap.AsDictionary(jsonMapString));
    }

    public SmartMap(string key, object value)
    {
      this.__storage = new Dictionary<string, object>();
      this.__storage.Add(key, value);
    }

    protected internal void UpdateFromBaseMap(SmartMap baseMapToSet)
    {
      this.__storage = baseMapToSet.__storage;
    }

    public SmartMap Clone()
    {
      return new SmartMap((IDictionary<string, object>) this.__storage, false);
    }

    public void Clear()
    {
      this.__storage.Clear();
    }

    private static Dictionary<string, object> createNewInstance(bool caseInsensitive)
    {
      if (caseInsensitive)
        return new Dictionary<string, object>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
      return new Dictionary<string, object>();
    }

    public void AddAll(IDictionary<string, object> data)
    {
      foreach (string key in (IEnumerable<string>) data.Keys)
        this.Add(key, data[key]);
    }

    private bool IsListKey(string key)
    {
      return key.Contains("[");
    }

    private string ExtractKeyName(string key)
    {
      return key.Substring(0, key.IndexOf("["));
    }

    private int ExtractKeyIndex(string key)
    {
      Match match = SmartMap.arrayIndexPattern.Match(key);
      if (match.Success && !"".Equals(match.Groups[2].ToString()))
        return int.Parse(match.Groups[2].ToString());
      return -1;
    }

    public void Add(string keyPath, object value)
    {
      string[] strArray = keyPath.Split('.');
      Dictionary<string, object> dictionary = this.__storage;
      for (int index1 = 0; index1 < strArray.Length; ++index1)
      {
        bool flag = index1 + 1 == strArray.Length;
        string key = strArray[index1];
        if (this.IsListKey(key))
        {
          string keyName = this.ExtractKeyName(key);
          int keyIndex = this.ExtractKeyIndex(key);
          if (dictionary.ContainsKey(keyName))
          {
            if (flag)
            {
              List<object> objectList = (List<object>) dictionary[keyName];
              if (keyIndex > -1 && keyIndex < objectList.Count)
              {
                objectList[keyIndex] = value;
                break;
              }
              objectList.Add(value);
              break;
            }
            List<Dictionary<string, object>> dictionaryList1 = (List<Dictionary<string, object>>) dictionary[keyName];
            if (keyIndex > -1 && keyIndex < dictionaryList1.Count)
            {
              dictionary = dictionaryList1[keyIndex];
            }
            else
            {
              dictionaryList1.Add(SmartMap.createNewInstance(this.caseInsensitive));
              List<Dictionary<string, object>> dictionaryList2 = dictionaryList1;
              int index2 = dictionaryList2.Count - 1;
              dictionary = dictionaryList2[index2];
            }
          }
          else
          {
            if (flag)
            {
              dictionary[keyName] = (object) new List<object>();
              ((List<object>) dictionary[keyName]).Add(value);
              break;
            }
            dictionary[keyName] = (object) new List<Dictionary<string, object>>();
            List<Dictionary<string, object>> dictionaryList = (List<Dictionary<string, object>>) dictionary[keyName];
            Dictionary<string, object> newInstance = SmartMap.createNewInstance(this.caseInsensitive);
            dictionaryList.Add(newInstance);
            int index2 = dictionaryList.Count - 1;
            dictionary = dictionaryList[index2];
          }
        }
        else if (dictionary.ContainsKey(key))
        {
          if (flag)
          {
            dictionary[key] = value;
            break;
          }
          dictionary = (Dictionary<string, object>) dictionary[key];
        }
        else
        {
          if (flag)
          {
            dictionary[key] = value;
            break;
          }
          dictionary[key] = (object) SmartMap.createNewInstance(this.caseInsensitive);
          dictionary = (Dictionary<string, object>) dictionary[key];
        }
      }
    }

    public virtual SmartMap Set(string key, object value)
    {
      this.Add(key, value);
      return this;
    }

    public object Get(string keyPath)
    {
      string[] strArray1 = keyPath.Split('.');
      if (strArray1.Length <= 1)
      {
        Match match = SmartMap.arrayIndexPattern.Match(strArray1[0]);
        if (!match.Success)
        {
          object obj;
          this.__storage.TryGetValue(strArray1[0], out obj);
          return obj;
        }
        string @string = match.Groups[1].ToString();
        object obj1;
        this.__storage.TryGetValue(@string, out obj1);
        if (!(obj1 is IList))
          throw new ArgumentException("Property '" + @string + "' is not an array");
        IList list = (IList) obj1;
        int? nullable = new int?(list.Count - 1);
        if (!"".Equals(match.Groups[2].ToString()))
          nullable = new int?(int.Parse(match.Groups[2].ToString()));
        return list[nullable ?? 0];
      }
      IDictionary<string, object> lastMapInKeyPath = this.FindLastMapInKeyPath(keyPath);
      string[] strArray2 = strArray1;
      int index = strArray2.Length - 1;
      string input = strArray2[index];
      Match match1 = SmartMap.arrayIndexPattern.Match(input);
      if (!match1.Success)
        return lastMapInKeyPath[input];
      string string1 = match1.Groups[1].ToString();
      object obj2;
      lastMapInKeyPath.TryGetValue(string1, out obj2);
      if (!(obj2 is IList))
        throw new ArgumentException("Property '" + string1 + "' is not an array");
      IList list1 = (IList) obj2;
      int? nullable1 = new int?(list1.Count - 1);
      if (!"".Equals(match1.Groups[2].ToString()))
        nullable1 = new int?(int.Parse(match1.Groups[2].ToString()));
      return list1[nullable1 ?? 0];
    }

    public bool ContainsKey(string keyPath)
    {
      string[] strArray1 = keyPath.Split('.');
      if (strArray1.Length <= 1)
      {
        Match match = SmartMap.arrayIndexPattern.Match(strArray1[0]);
        if (!match.Success)
          return this.__storage.ContainsKey(strArray1[0]);
        string @string = match.Groups[1].ToString();
        object obj;
        this.__storage.TryGetValue(@string, out obj);
        if (!(obj is IList))
          throw new ArgumentException("Property '" + @string + "' is not an array");
        List<Dictionary<string, object>> dictionaryList = (List<Dictionary<string, object>>) obj;
        int? nullable1 = new int?(dictionaryList.Count - 1);
        if (!"".Equals(match.Groups[2].ToString()))
          nullable1 = new int?(int.Parse(match.Groups[2].ToString()));
        int? nullable2 = nullable1;
        int num = 0;
        if ((nullable2.GetValueOrDefault() >= num ? (nullable2.HasValue ? 1 : 0) : 0) == 0)
          return false;
        nullable2 = nullable1;
        int count = dictionaryList.Count;
        if (nullable2.GetValueOrDefault() >= count)
          return false;
        return nullable2.HasValue;
      }
      IDictionary<string, object> lastMapInKeyPath = this.FindLastMapInKeyPath(keyPath);
      if (lastMapInKeyPath == null)
        return false;
      IDictionary<string, object> dictionary = lastMapInKeyPath;
      string[] strArray2 = strArray1;
      int index = strArray2.Length - 1;
      string key = strArray2[index];
      return dictionary.ContainsKey(key);
    }

    public bool Remove(string keyPath)
    {
      string[] strArray1 = keyPath.Split('.');
      if (strArray1.Length <= 1)
      {
        Match match = SmartMap.arrayIndexPattern.Match(strArray1[0]);
        if (!match.Success)
          return this.__storage.Remove(strArray1[0]);
        string @string = match.Groups[1].ToString();
        object obj;
        this.__storage.TryGetValue(@string, out obj);
        if (!(obj is IList))
          throw new ArgumentException("Property '" + @string + "' is not an array");
        List<Dictionary<string, object>> dictionaryList = (List<Dictionary<string, object>>) obj;
        int? nullable = new int?(dictionaryList.Count - 1);
        if (!"".Equals(match.Groups[2].ToString()))
          nullable = new int?(int.Parse(match.Groups[2].ToString()));
        if (nullable.HasValue)
          dictionaryList.RemoveAt(nullable ?? 0);
      }
      IDictionary<string, object> lastMapInKeyPath = this.FindLastMapInKeyPath(keyPath);
      string[] strArray2 = strArray1;
      int index = strArray2.Length - 1;
      string key = strArray2[index];
      return lastMapInKeyPath.Remove(key);
    }

    private IDictionary<string, object> FindLastMapInKeyPath(string keyPath)
    {
      string[] strArray = keyPath.Split('.');
      IDictionary<string, object> dictionary = (IDictionary<string, object>) null;
      for (int index1 = 0; index1 <= strArray.Length - 2; ++index1)
      {
        Match match = SmartMap.arrayIndexPattern.Match(strArray[index1]);
        string index2 = strArray[index1];
        if (match.Success)
        {
          string @string = match.Groups[1].ToString();
          object obj = (object) null;
          if (dictionary == null)
            this.__storage.TryGetValue(@string, out obj);
          else
            obj = dictionary[@string];
          if (!(obj is IList))
            throw new ArgumentException("Property '" + @string + "' is not an array");
          IList list = (IList) obj;
          int? nullable = new int?(list.Count - 1);
          if (!"".Equals(match.Groups[2].ToString()))
            nullable = new int?(int.Parse(match.Groups[2].ToString()));
          dictionary = (IDictionary<string, object>) list[nullable ?? 0];
        }
        else if (dictionary == null)
        {
          try
          {
            dictionary = (IDictionary<string, object>) this.__storage[index2];
          }
          catch
          {
            return (IDictionary<string, object>) null;
          }
        }
        else
          dictionary = (IDictionary<string, object>) dictionary[index2];
      }
      return dictionary;
    }

    public static IDictionary<string, object> AsDictionary(string json)
    {
      try
      {
        return (IDictionary<string, object>) SmartMap.ParseDictionary(JsonConvert.DeserializeObject<IDictionary<string, object>>(json), false);
      }
      catch (Exception ex)
      {
        return (IDictionary<string, object>) new Dictionary<string, object>()
        {
          {
            "list",
            (object) SmartMap.ParseListOfDictionary((IList<object>) JsonConvert.DeserializeObject<List<object>>(json), false)
          }
        };
      }
    }

    private static List<object> ParseListOfObjects(IList<object> input, bool caseInsensitive = false)
    {
      List<object> objectList = new List<object>();
      foreach (object obj1 in (IEnumerable<object>) input)
      {
        object obj2 = !(obj1 is IDictionary) ? (!(obj1 is JObject) ? obj1 : (object) SmartMap.ParseDictionary((IDictionary<string, object>) ((JToken) obj1).ToObject<Dictionary<string, object>>(), caseInsensitive)) : (object) SmartMap.ParseDictionary((IDictionary<string, object>) obj1, caseInsensitive);
        objectList.Add(obj2);
      }
      return objectList;
    }

    private static List<Dictionary<string, object>> ParseListOfDictionary(IList<object> input, bool caseInsensitive = false)
    {
      List<Dictionary<string, object>> dictionaryList = new List<Dictionary<string, object>>();
      foreach (object obj in (IEnumerable<object>) input)
      {
        Dictionary<string, object> dictionary = (Dictionary<string, object>) null;
        if (obj is IDictionary)
          dictionary = SmartMap.ParseDictionary((IDictionary<string, object>) obj, caseInsensitive);
        else if (obj is JObject)
          dictionary = SmartMap.ParseDictionary((IDictionary<string, object>) ((JToken) obj).ToObject<Dictionary<string, object>>(), caseInsensitive);
        dictionaryList.Add(dictionary);
      }
      return dictionaryList;
    }

    private static Dictionary<string, object> ParseDictionary(IDictionary<string, object> input, bool caseInsensitive = false)
    {
      Dictionary<string, object> newInstance = SmartMap.createNewInstance(caseInsensitive);
      foreach (KeyValuePair<string, object> keyValuePair in (IEnumerable<KeyValuePair<string, object>>) input)
      {
        object obj;
        if (keyValuePair.Value is IDictionary)
          obj = (object) SmartMap.ParseDictionary((IDictionary<string, object>) keyValuePair.Value, caseInsensitive);
        else if (keyValuePair.Value is JObject)
          obj = (object) SmartMap.ParseDictionary(((JToken) keyValuePair.Value).ToObject<IDictionary<string, object>>(), caseInsensitive);
        else if (keyValuePair.Value is JArray)
        {
          JToken jtoken = ((JArray) keyValuePair.Value)[0];
          obj = jtoken is JObject || jtoken is IDictionary ? (object) SmartMap.ParseListOfDictionary((IList<object>) ((JToken) keyValuePair.Value).ToObject<List<object>>(), caseInsensitive) : (object) SmartMap.ParseListOfObjects((IList<object>) ((JToken) keyValuePair.Value).ToObject<List<object>>(), caseInsensitive);
        }
        else
          obj = keyValuePair.Value;
        newInstance.Add(keyValuePair.Key, obj);
      }
      return newInstance;
    }

    IEnumerator<KeyValuePair<string, object>> IEnumerable<KeyValuePair<string, object>>.GetEnumerator()
    {
      return (IEnumerator<KeyValuePair<string, object>>) this.__storage.GetEnumerator();
    }

    public IEnumerator GetEnumerator()
    {
      return this.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return (IEnumerator) this.__storage.GetEnumerator();
    }

    bool IDictionary<string, object>.TryGetValue(string key, out object value)
    {
      value = this.Get(key);
      return true;
    }

    void ICollection<KeyValuePair<string, object>>.Add(KeyValuePair<string, object> item)
    {
      this.Add(item.Key, item.Value);
    }

    void ICollection<KeyValuePair<string, object>>.Clear()
    {
      this.__storage.Clear();
    }

    bool ICollection<KeyValuePair<string, object>>.Contains(KeyValuePair<string, object> item)
    {
      return this.__storage.ContainsKey(item.Key);
    }

    void ICollection<KeyValuePair<string, object>>.CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
    {
      ((ICollection<KeyValuePair<string, object>>) this.__storage).CopyTo(array, arrayIndex);
    }

    bool ICollection<KeyValuePair<string, object>>.Remove(KeyValuePair<string, object> item)
    {
      return ((ICollection<KeyValuePair<string, object>>) this.__storage).Remove(item);
    }
  }
}
