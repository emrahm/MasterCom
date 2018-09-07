using Clearing.Msc.Business.MasterCom.DbObjects;
using Clearing.Msc.Business.MasterCom.ModelData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.Repository
{
    /// <summary>
    /// data bilgilerini bu class'dan alınacak
    /// </summary>
    public interface ITransactionRepository
    {
        /// <summary>
        /// issuer data alınır. transaction search yapılır.
        /// </summary>
        /// <param name="mscMcomPool"></param>
        /// <returns></returns>
        MscTransaction GetIssuerData(MscMcomPool mscMcomPool);
        /// <summary>
        /// acquirer data alınır.
        /// </summary>
        /// <param name="mscMcomPool"></param>
        /// <returns></returns>
        MscTransaction GetAcquirerData(MscMcomPool mscMcomPool);
        /// <summary>
        /// Transaction id database'e kaydedilir.
        /// </summary>
        /// <param name="provGuid"></param>
        /// <returns></returns>
        MscMcomTransaction GetTransactionId(long provGuid);
        /// <summary>
        /// Transaction id sisteme kaydedilir.
        /// </summary>
        /// <param name="mscMcomTransactionId"></param> 
        void CreateTransactionId(MscMcomTransaction mscMcomTransactionId);
        /// <summary>
        /// Claim bilgisini verir.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        MscMcomClaim GetClaim(string claimId);
        /// <summary>
        /// Get claim data with transaction info
        /// </summary>
        /// <param name="mscTransactionData"></param>
        /// <returns></returns>
        MscMcomClaim GetClaim(Int64 provGuid);
        /// <summary>
        /// Gelen claim'i sisteme yazar.
        /// </summary>
        /// <param name="mscMcomClaim"></param>
        void CreateClaim(MscMcomClaim mscMcomClaim);
        /// <summary>
        /// Üretilen son claim id'si update edilir.
        /// </summary>
        /// <param name="mscMcomTransactionId"></param>
        void UpdateClaimId(MscMcomTransaction mscMcomTransactionId);
        /// <summary>
        /// Pool a atılan kayıtları process eder
        /// </summary>
        /// <returns></returns>
        List<MscMcomPool> GetPool();
        /// <summary>
        /// Pool statu update yapar
        /// </summary>
        /// <param name="mscMcomPool"></param>
        void UpdatePoolItem(MscMcomPool mscMcomPool);
        /// <summary>
        /// Tqr datası sisteme kadedilir.
        /// </summary>
        /// <param name="mscMcomTqr4List"></param>
        void InsertTqr4Data(List<MscMcomTqr4> mscMcomTqr4List);
        /// <summary>
        /// Pool datası bulunur
        /// </summary>
        /// <param name="clearingNo"></param>
        /// <param name="actionType"></param>
        /// <returns></returns>
        MscMcomPool GetMscMcomPoolClearingNo(long clearingNo, String actionType);
        /// <summary>
        /// Attachment datası elde edilir
        /// </summary>
        /// <param name="guid">cb işleminin guid si. döküman clr_document_info tablosunda pguid alanına döküman eklenen işlemin guid'si atılmalıdır.</param>
        /// <param name="documentType">döküman tipine göre dökümanı bulur. attach edilen işlemin guid si gelir. 
        /// döküman tipi işlem tipi sonuna DOC yazılaraka atılması tavsiye edilir. örn : CBDOC</param>
        /// <returns></returns>
        FileAttachment GetAttachment(ClrDocumentInfo clrDocumentInfo);
        ClrDocumentInfo GetDocumentInfo(long pGuid, String actionType);

        MscMcomQueue GetQueueData(MscMcomQueue mscMcomQueueResponse);

        void CreateQueueData(List<MscMcomQueue> mscMcomQueueList);


        void UpdatePoolData(List<MscMcomPool> updateStatuList);

        IEnumerable<MscMcomPool> GetPoolPendingStatu();
    }
}
