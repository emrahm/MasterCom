// Decompiled with JetBrains decompiler
// Type: MasterCard.Core.Exceptions.ApiException
// Assembly: MasterCard-Core, Version=1.4.0.26200, Culture=neutral, PublicKeyToken=null
// MVID: FBF9ACCE-839B-46D3-83A0-494225AC75CB
// Assembly location: D:\Sources\Mastercom\MasterComTest\packages\MasterCard-Core.1.4.0\lib\MasterCard-Core.dll

using MasterCard.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasterCard.Core.Exceptions
{
  public class ApiException : Exception
  {
    protected string source;
    protected string reasonCode;
    protected bool recoverable;
    protected string description;
    protected int httpStatus;
    private SmartMap rawErrorData;

    public virtual SmartMap RawErrorData
    {
      get
      {
        return this.rawErrorData;
      }
    }

    public override string Source
    {
      get
      {
        return this.source;
      }
    }

    public virtual string ReasonCode
    {
      get
      {
        return this.reasonCode;
      }
    }

    public virtual int HttpStatus
    {
      get
      {
        return this.httpStatus;
      }
    }

    public virtual bool Recoverable
    {
      get
      {
        return this.recoverable;
      }
    }

    public override string Message
    {
      get
      {
        if (this.description == null)
          return base.Message;
        return this.description;
      }
    }

    public ApiException()
    {
    }

    public ApiException(string message)
      : base(message)
    {
    }

    public ApiException(string message, string description)
      : base(message)
    {
      this.description = description;
    }

    public ApiException(string message, Exception cause)
      : base(message, cause)
    {
    }

    public ApiException(Exception cause)
      : base(cause.Message, cause)
    {
    }

    public ApiException(int status, IDictionary<string, object> errorData)
    {
      this.httpStatus = status;
      this.rawErrorData = new SmartMap(errorData, true);
      if (!this.rawErrorData.ContainsKey("Errors.Error"))
        return;
      SmartMap smartMap = new SmartMap(!(this.rawErrorData["Errors.Error"].GetType() == typeof (List<Dictionary<string, object>>)) ? (IDictionary<string, object>) this.rawErrorData["Errors.Error"] : (IDictionary<string, object>) this.rawErrorData["Errors.Error[0]"], true);
      if (smartMap.ContainsKey("Source"))
        this.source = smartMap.Get("Source").ToString();
      if (smartMap.ContainsKey("ReasonCode"))
        this.reasonCode = smartMap.Get("ReasonCode").ToString();
      if (smartMap.ContainsKey("Description"))
        this.description = smartMap.Get("Description").ToString();
      if (!smartMap.ContainsKey("Recoverable"))
        return;
      this.recoverable = bool.Parse(smartMap.Get("Recoverable").ToString());
    }

    public virtual string Describe()
    {
      return new StringBuilder().Append(this.GetType().Name).Append(": \"").Append(this.Message).Append("\" (Source: ").Append(this.Source).Append(", ReasonCode: ").Append(this.ReasonCode).Append(", Recoverable: ").Append(this.Recoverable).Append(")").ToString();
    }
  }
}
