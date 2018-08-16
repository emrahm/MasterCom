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
        /// Presentment data alınır. transaction search yapılır.
        /// </summary>
        /// <param name="mscMcomPool"></param>
        /// <returns></returns>
        MscTransactionData GetPresentmentData(MscMcomPool mscMcomPool);
        /// <summary>
        /// Ekrandan girilen chargeback datasını verir.
        /// </summary>
        /// <param name="clrNo"></param>
        /// <returns></returns>
        ChargebackFillRequest GetChargebackData(long clrNo);
        /// <summary>
        /// Transaction id database'e kaydedilir.
        /// </summary>
        /// <param name="provGuid"></param>
        /// <returns></returns>
        MscMcomTransactionId GetTransactionId(long provGuid);
        /// <summary>
        /// Transaction id sisteme kaydedilir.
        /// </summary>
        /// <param name="mscMcomTransactionId"></param>
        /// <returns></returns>
        Boolean CreateTransactionId(MscMcomTransactionId mscMcomTransactionId);
        /// <summary>
        /// Sistem mastercard'daki claim yazılır.
        /// </summary>
        /// <param name="mscMcomPool"></param>
        /// <returns></returns>
        MscMcomClaim CreateClaim(MscMcomPool mscMcomPool);
        /// <summary>
        /// Claim bilgisini verir.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        MscMcomClaim GetClaim(string claimId);
        /// <summary>
        /// Gelen claim'i sisteme yazar.
        /// </summary>
        /// <param name="mscMcomClaim"></param>
        void CreateClaim(MscMcomClaim mscMcomClaim);
        /// <summary>
        /// Üretilen son claim id'si update edilir.
        /// </summary>
        /// <param name="mscMcomTransactionId"></param>
        void UpdateClaimId(MscMcomTransactionId mscMcomTransactionId);

        IEnumerable<MscMcomPool> GetPool();

        void UpdatePoolItem(MscMcomPool item);
    }
}
