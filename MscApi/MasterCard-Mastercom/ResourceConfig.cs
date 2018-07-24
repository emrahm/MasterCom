// Decompiled with JetBrains decompiler
// Type: MasterCard.Api.Mastercom.ResourceConfig
// Assembly: MasterCard-Mastercom, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4D794006-EF28-4DBF-97FC-7640E5AF009E
// Assembly location: D:\Sources\Mastercom\MasterComTest\packages\MasterCard-Mastercom.0.0.5\lib\MasterCard-Mastercom.dll

using MasterCard.Core;
using MasterCard.Core.Model;
using System.Collections.Generic;

namespace MasterCard.Api.Mastercom
{
  public class ResourceConfig : ResourceConfigInterface
  {
    private string hostOverride;
    private string host;
    private string context;
    private static ResourceConfig instance;

    public static ResourceConfig Instance
    {
      get
      {
        if (ResourceConfig.instance == null)
        {
          ResourceConfig.instance = new ResourceConfig();
          ApiConfig.RegisterResourceConfig((ResourceConfigInterface) ResourceConfig.instance);
          ResourceConfig.instance.SetEnvironment(ApiConfig.GetEnvironment());
        }
        return ResourceConfig.instance;
      }
    }

    private ResourceConfig()
    {
    }

    public string GetHost()
    {
      if (this.hostOverride == null)
        return this.host;
      return this.hostOverride;
    }

    public string GetContext()
    {
      return this.context;
    }

    public string GetVersion()
    {
      return "MasterCard-Mastercom:0.0.5";
    }

    public bool GetJsonNative()
    {
      return true;
    }

    public string GetContentTypeOverride()
    {
      return (string) null;
    }

    public void SetEnvironment(Constants.Environment environment)
    {
      if (!Constants.MAPPINGS.ContainsKey(environment))
        return;
      List<string> stringList = Constants.MAPPINGS[environment];
      this.host = stringList[0];
      this.context = stringList[1];
    }

    public void SetEnvironment(string host, string context)
    {
      this.host = host;
      this.context = context;
    }
  }
}
