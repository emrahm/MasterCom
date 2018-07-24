// Decompiled with JetBrains decompiler
// Type: MasterCard.Core.ApiConfig
// Assembly: MasterCard-Core, Version=1.4.0.26200, Culture=neutral, PublicKeyToken=null
// MVID: FBF9ACCE-839B-46D3-83A0-494225AC75CB
// Assembly location: D:\Sources\Mastercom\MasterComTest\packages\MasterCard-Core.1.4.0\lib\MasterCard-Core.dll

using MasterCard.Core.Model;
using MasterCard.Core.Security;
using System.Collections.Generic;

namespace MasterCard.Core
{
  public static class ApiConfig
  {
    private static Constants.Environment environment = Constants.Environment.SANDBOX;
    private static bool DEBUG = false;
    private static Dictionary<string, object> cryptographyMap = new Dictionary<string, object>();
    private static Dictionary<string, ResourceConfigInterface> registeredInstances = new Dictionary<string, ResourceConfigInterface>();
    private static AuthenticationInterface authentication;

    public static void SetEnvironment(Constants.Environment environment)
    {
      foreach (ResourceConfigInterface resourceConfigInterface in ApiConfig.registeredInstances.Values)
        resourceConfigInterface.SetEnvironment(environment);
      ApiConfig.environment = environment;
    }

    public static Constants.Environment GetEnvironment()
    {
      return ApiConfig.environment;
    }

    public static void SetDebug(bool debug)
    {
      ApiConfig.DEBUG = debug;
    }

    public static bool IsDebug()
    {
      return ApiConfig.DEBUG;
    }

    public static void SetSandbox(bool sandbox)
    {
      if (sandbox)
        ApiConfig.environment = Constants.Environment.SANDBOX;
      else
        ApiConfig.environment = Constants.Environment.PRODUCTION;
    }

    public static bool IsSandbox()
    {
      int num = (int) ApiConfig.environment;
      return ApiConfig.environment == Constants.Environment.SANDBOX;
    }

    public static AuthenticationInterface GetAuthentication()
    {
      return ApiConfig.authentication;
    }

    public static void SetAuthentication(AuthenticationInterface authentication)
    {
      ApiConfig.authentication = authentication;
    }

    public static void AddCryptographyInterceptor(CryptographyInterceptor cryptographyInterceptor)
    {
      if (ApiConfig.cryptographyMap.ContainsKey(cryptographyInterceptor.GetTriggeringPath()))
        return;
      ApiConfig.cryptographyMap.Add(cryptographyInterceptor.GetTriggeringPath(), (object) cryptographyInterceptor);
    }

    public static CryptographyInterceptor GetCryptographyInterceptor(string basePath)
    {
      foreach (KeyValuePair<string, object> cryptography in ApiConfig.cryptographyMap)
      {
        if (cryptography.Key.Contains(basePath) || basePath.Contains(cryptography.Key))
          return (CryptographyInterceptor) cryptography.Value;
      }
      return (CryptographyInterceptor) null;
    }

    public static void RegisterResourceConfig(ResourceConfigInterface instance)
    {
      string fullName = instance.GetType().FullName;
      if (ApiConfig.registeredInstances.ContainsKey(fullName))
        return;
      ApiConfig.registeredInstances.Add(fullName, instance);
    }
  }
}
