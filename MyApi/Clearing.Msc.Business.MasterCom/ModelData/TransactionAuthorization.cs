using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.ModelData
{
    public class TransactionAuthorization
    {
        public string accountNumber { get; set; }
        public string accountNumberIndicator { get; set; }
        public string acquirer { get; set; }
        public string acquiringInstitutionCountryCode { get; set; }
        public string acquiringInstitutionId { get; set; }
        public string addressVerificationServiceResponse { get; set; }
        public string adviceReasonCode { get; set; }
        public string atcDiscrepancyIndicator { get; set; }
        public string atcDiscrepancyValue { get; set; }
        public string atcValue { get; set; }
        public string authenticationIndicator { get; set; }
        public string authorizationIdResponse { get; set; }
        public string banknetDate { get; set; }
        public string banknetReferenceNumber { get; set; }
        public string billingCurrencyCode { get; set; }
        public string cardAcceptorCity { get; set; }
        public string cardAcceptorId { get; set; }
        public string cardAcceptorName { get; set; }
        public string cardAcceptorState { get; set; }
        public string cardAcceptorTerminalId { get; set; }
        public string cardholderActivatedTerminalLevel { get; set; }
        public string cardholderBillingActualAmount { get; set; }
        public string cardholderBillingAmount { get; set; }
        public string cardAuthenticationMethodValidationCode { get; set; }
        public string conversionDate { get; set; }
        public string conversionRate { get; set; }
        public string electronicCommerceIndicators { get; set; }
        public string electronicCommerceSecurityLevelIndicatorAndUcafCollectionIndicator { get; set; }
        public object expirationDatePresenceInd { get; set; }
        public string finalAuthorizationIndicator { get; set; }
        public string financialNetworkCode { get; set; }
        public string forwardingInstitutionId { get; set; }
        public string infData { get; set; }
        public string integratedCircuitCardRelatedData { get; set; }
        public string issuer { get; set; }
        public string mastercardPromotionCode { get; set; }
        public string mccMessageId { get; set; }
        public string merchantAdviceCode { get; set; }
        public object merchantCategoryCode { get; set; }
        public object mobilePhoneNumber { get; set; }
        public object mobilePhoneServiceProviderName { get; set; }
        public string originalAcquiringInstitutionIdCode { get; set; }
        public string originalElectronicCommerceSecurityLevelIndicatorAndUcafCollectionIndicator { get; set; }
        public string originalIssuerForwardingInstitutionIdCode { get; set; }
        public string originalMessageTypeIdentifier { get; set; }
        public string pinServiceCode { get; set; }
        public string realTimeSubstantiationIndicator { get; set; }
        public string reasonForUcafCollectionIndicatorDowngrade { get; set; }
        public string posCardDataTerminalInputCapability { get; set; }
        public string posCardholderPresence { get; set; }
        public string posCardPresence { get; set; }
        public string posEntryModePan { get; set; }
        public string posEntryModePin { get; set; }
        public string posTerminalAttendance { get; set; }
        public string posTerminalLocation { get; set; }
        public string posTransactionStatus { get; set; }
        public string primaryAccountNumber { get; set; }
        public string primaryAccountNumberAccountRange { get; set; }
        public string privateData { get; set; }
        public string processingCode { get; set; }
        public string recordDataPresenceIndicator { get; set; }
        public string responseCode { get; set; }
        public string retrievalReferenceNumber { get; set; }
        public string settlementActualAmount { get; set; }
        public string settlementDate { get; set; }
        public string stan { get; set; }
        public string storageTechnology { get; set; }
        public string systemsTraceAuditNumber { get; set; }
        public string tokenAssuranceLevel { get; set; }
        public string tokenRequestorId { get; set; }
        public string track1 { get; set; }
        public string track2 { get; set; }
        public string transactionActualAmount { get; set; }
        public string transactionAmountLocal { get; set; }
        public string transactionCategoryCode { get; set; }
        public string transactionCurrencyCode { get; set; }
        public string transactionType { get; set; }
        public object transmissionDateAndTime { get; set; }
        public string universalCardholderAuthenticationFieldUcaf { get; set; }
        public string vcnProductCode { get; set; }
        public string walletIdentifier { get; set; }
    }
}
