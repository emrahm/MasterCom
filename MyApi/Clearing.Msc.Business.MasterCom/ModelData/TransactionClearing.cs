using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.ModelData
{
    public class TransactionClearing
    {
        public string accountLevelManagementAccountCategoryCode { get; set; }
        public string acquirerReferenceData { get; set; }
        public string acquiringInstitutionIdCode { get; set; }
        public string approvalCode { get; set; }
        public string businessCycle { get; set; }
        public string businessServiceArrangementTypeCode { get; set; }
        public string businessServiceIdCode { get; set; }
        public string cardAcceptorBusinessCode { get; set; }
        public string cardAcceptorCity { get; set; }
        public string cardAcceptorClassificationOverrideIndicator { get; set; }
        public string cardAcceptorCountry { get; set; }
        public string cardAcceptorIdCode { get; set; }
        public string cardAcceptorName { get; set; }
        public string cardAcceptorPostalCode { get; set; }
        public string cardAcceptorState { get; set; }
        public string cardAcceptorStreetAddress { get; set; }
        public string cardAcceptorTerminalId { get; set; }
        public string cardAcceptorUrl { get; set; }
        public string cardCaptureCapability { get; set; }
        public string cardDataInputCapability { get; set; }
        public string cardDataInputMode { get; set; }
        public string cardDataOutputCapability { get; set; }
        public string cardholderAuthenticationCapability { get; set; }
        public string cardholderAuthenticationEntity { get; set; }
        public string cardholderAuthenticationMethod { get; set; }
        public string cardholderBillingAmount { get; set; }
        public string cardholderBillingCurrencyCode { get; set; }
        public string cardholderFromAccountCode { get; set; }
        public string cardholderPresentData { get; set; }
        public string cardholderToAccountCode { get; set; }
        public string cardIssuerReferenceData { get; set; }
        public string cardPresentData { get; set; }
        public string cardProgramIdentifier { get; set; }
        public string centralSiteBusinessDate { get; set; }
        public string centralSiteProcessingDateOriginalMessage { get; set; }
        public string currencyCodeCardholderBilling { get; set; }
        public string currencyCodeReconciliation { get; set; }
        public string currencyCodeTransaction { get; set; }
        public string currencyExponentCardholderBilling { get; set; }
        public string currencyExponentReconciliation { get; set; }
        public string currencyExponentTransaction { get; set; }
        public string dataRecord { get; set; }
        public string electronicCommerceCardAuth { get; set; }
        public string electronicCommerceSecurityLevelIndicator { get; set; }
        public string electronicCommerceUcafCollectionIndicator { get; set; }
        public string forwardingInstitutionIdCode { get; set; }
        public string functionCode { get; set; }
        public string gcmsProductIndentifier { get; set; }
        public string installmentPaymentData { get; set; }
        public string installmentPaymentDataAnnualPercentageRate { get; set; }
        public string installmentPaymentDataFirstInstallmentAmount { get; set; }
        public string installmentPaymentDataInstallmentFee { get; set; }
        public string installmentPaymentDataInterestRate { get; set; }
        public string installmentPaymentDataNumberInstallments { get; set; }
        public string installmentPaymentDataSubsequentInstallmentAmount { get; set; }
        public string integratedCircuitCardRelatedData { get; set; }
        public string interchangeRateDesignator { get; set; }
        public string licensedProductIndentifier { get; set; }
        public string legalCorporateName { get; set; }
        public string localTransactionDateTime { get; set; }
        public string mastercardAssignedId { get; set; }
        public string mastercardAssignedIdOverrideIndicator { get; set; }
        public string mastercardMappingServiceAccountNumber { get; set; }
        public string masterPassIncentiveIndicator { get; set; }
        public string messageReasonCode { get; set; }
        public string messageReversalIndicator { get; set; }
        public string originatingMessageFormat { get; set; }
        public string partnerIdCode { get; set; }
        public string pinCaptureCapability { get; set; }
        public string primaryAccountNumber { get; set; }
        public string processingCode { get; set; }
        public string productOverrideIndicator { get; set; }
        public string programRegistrationId { get; set; }
        public string qpsPaypassEligibilityIndicator { get; set; }
        public string rateIndicator { get; set; }
        public string receivingInstitutionIdCode { get; set; }
        public string reconciliationAmount { get; set; }
        public string reconciliationCurrencyCode { get; set; }
        public string remotePaymentsProgramData { get; set; }
        public string serviceCode { get; set; }
        public string settlementData { get; set; }
        public string settlementIndicator { get; set; }
        public string specialConditionsIndicator { get; set; }
        public string terminalDataOutputCapability { get; set; }
        public string terminalOperatingEnvironment { get; set; }
        public string terminalType { get; set; }
        public string tokenRequestorId { get; set; }
        public string transactionAmountLocal { get; set; }
        public string transactionCategoryIndicator { get; set; }
        public string transactionCurrencyCode { get; set; }
        public string transactionDestinationInstitutionIdCode { get; set; }
        public string transactionLifeCycleId { get; set; }
        public string transactionOriginatorInstitutionIdCode { get; set; }
        public string transactionType { get; set; }
        public string transitProgramCode { get; set; }
        public string walletIdentifierMdes { get; set; }
    }
}
