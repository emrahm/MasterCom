// Decompiled with JetBrains decompiler
// Type: MasterCard.Core.Model.BaseObject
// Assembly: MasterCard-Core, Version=1.4.0.26200, Culture=neutral, PublicKeyToken=null
// MVID: FBF9ACCE-839B-46D3-83A0-494225AC75CB
// Assembly location: D:\Sources\Mastercom\MasterComTest\packages\MasterCard-Core.1.4.0\lib\MasterCard-Core.dll

using System;
using System.Collections.Generic;

namespace MasterCard.Core.Model
{
    public abstract class BaseObject : RequestMap
    {
        protected BaseObject()
            : base(false)
        {
        }

        protected BaseObject(RequestMap bm)
            : base(bm)
        {
        }

        protected BaseObject(IDictionary<string, object> map)
            : base(map, false)
        {
        }

        protected abstract OperationConfig GetOperationConfig(string operationUUID);

        protected abstract OperationMetadata GetOperationMetadata();

        protected static ResourceList<T> ExecuteForList<T>(string operationUUID, T inputObject) where T : BaseObject
        {
            return new ResourceList<T>((IDictionary<string, object>)BaseObject.Execute<T>(operationUUID, inputObject));
        }

        protected static T Execute<T>(string operationUUID, T inputObject) where T : BaseObject
        {
            OperationConfig operationConfig = inputObject.GetOperationConfig(operationUUID);
            OperationMetadata operationMetadata = new OperationMetadata("MasterCard-Mastercom:0.0.5", "https://sandbox.api.mastercard.com");// inputObject.GetOperationMetadata();

            IDictionary<string, object> data = new ApiController().Execute(operationConfig, operationMetadata, inputObject);
            if (data != null)
            {
                inputObject.Clear();
                inputObject.AddAll(data);
            }
            else
            {
                inputObject = (T)Activator.CreateInstance(inputObject.GetType());
                inputObject.AddAll(data);
            }
            return inputObject;
        }
    }
}
