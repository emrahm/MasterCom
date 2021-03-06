﻿using Clearing.Msc.Business.MasterCom.ModelData;
using Clearing.Msc.Business.MasterCom.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.Model
{

    /// <summary>
    /// "/mastercom/v1/chargebacks/acknowledge", "update" 
    /// "/mastercom/v1/claims/{claim-id}/chargebacks", "create" 
    /// "/mastercom/v1/claims/{claim-id}/chargebacks/{chargeback-id}/reversal", "create" 
    /// "/mastercom/v1/claims/{claim-id}/chargebacks/{chargeback-id}/documents", "query"
    /// "/mastercom/v1/claims/{claim-id}/chargebacks/loaddataforchargebacks", "query",  gerekli degil. 
    /// "/mastercom/v1/chargebacks/status", "update"
    /// "/mastercom/v1/claims/{claim-id}/chargebacks/{chargeback-id}", "update"
    /// </summary>
    public class Chargebacks : IChargebacks
    {
        IApiController _apiController = null;
        public Chargebacks(IApiController apiController)
        {
            _apiController = apiController;
        }
        /// <summary>
        /// Chargeback create
        /// </summary>
        /// <param name="claimId">Claim id</param>
        /// <param name="chargebackRequest">chargeback data</param>
        /// <returns>chargebackId</returns>
        public String Create(long refKey, String claimId, ChargebackFillRequest chargebackRequest)
        {
            var result = _apiController.Create<ChargebackResponse>(refKey, String.Format("claims/{0}/chargebacks", claimId), chargebackRequest);
            return result.chargebackId;
        }
        /// <summary>
        /// Chargeback update
        /// </summary>
        /// <param name="claimId">Claim id</param>
        /// <param name="chargebackRequest">chargeback data</param>
        /// <returns>chargebackId</returns>
        public String Update(long refKey, ChargebackRequest chargebackRequest, ChargebackFillRequest chargebackFillRequest)
        {
            String restUrl = String.Format("claims/{0}/chargebacks/{1}", chargebackRequest.claimId, chargebackRequest.chargebackId);
            var result = _apiController.Update<ChargebackResponse>(refKey, restUrl, null, chargebackFillRequest);
            return result.chargebackId;
        }
        /// <summary>
        /// Reversal of related chargeback
        /// </summary>
        /// <param name="claimId"></param>
        /// <param name="chargebackId"></param>
        /// <returns>return chargeback id of reversal record.</returns>
        public String CreateReversal(long refKey, ChargebackRequest chargebackRequest)
        {
            String restUrl = String.Format("claims/{0}/chargebacks/{1}/reversal", chargebackRequest.claimId, chargebackRequest.chargebackId);
            var result = _apiController.Create<ChargebackResponse>(refKey, restUrl, null);
            return result.chargebackId;
        }
        /// <summary>
        /// Retrieve Documentation
        /// </summary>
        /// <param name="claimId">Claim Id</param>
        /// <param name="chargebackId">Chargeback Id</param>
        /// <returns>File converted to a base64 encoded string. File Format is ZIP Note: ZIP file may contain these formats...JPG, TIFF, PDF</returns>
        public FileAttachment RetrieveDocumentation(long refKey, ChargebackRequest chargebackRequest)
        {
            Dictionary<String, String> parameters = new Dictionary<string, string>();
            parameters.Add("format", "ORIGINAL");
            String restUrl = String.Format("claims/{0}/chargebacks/{1}/documents", chargebackRequest.claimId, chargebackRequest.chargebackId);
            return _apiController.Get<FileAttachment>(refKey, restUrl, parameters);
        }

        public List<ChargebackResponse> AcknowledgeReceivedChargebacks(long refKey, List<ChargebackRequest> chargebackRequestList)
        {
            var result = _apiController.Update<ChargebackAcknowledgeResponse>(refKey, 
                                                                    "chargebacks/acknowledge",
                                                                    null,
                                                                    new ChargebackAcknowledgeRequest() { chargebackList = chargebackRequestList });
            return result.chargebackResponseList;
        }


        public List<ChargebackStatusResponse> ChargebacksStatus(long refKey, List<ChargebackRequest> chargebackRequestList)
        {
            var result = _apiController.Update<ChargebackStatusResponseList>(refKey, "chargebacks/status",
                                                                    null,
                                                                    new ChargebackStatusRequest() { chargebackList = chargebackRequestList });
            return result.chargebackResponseList;
        }

    }
}
