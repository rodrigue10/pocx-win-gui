using System;
using NBitcoin.DataEncoders;

namespace PoCX.Common
{
    /// <summary>
    /// Address format types
    /// </summary>
    public enum AddressFormat
    {
        Unknown,
        Base58,
        Bech32
    }

    /// <summary>
    /// Address validation result
    /// </summary>
    public class AddressValidationResult
    {
        public bool IsValid { get; set; }
        public string AddressType { get; set; }
        public string ErrorMessage { get; set; }

        public AddressValidationResult(bool isValid, string addressType, string errorMessage = null)
        {
            IsValid = isValid;
            AddressType = addressType;
            ErrorMessage = errorMessage;
        }
    }

    /// <summary>
    /// Validates and detects address formats (Base58Check and Bech32)
    /// </summary>
    public static class AddressValidator
    {
        /// <summary>
        /// Detects the format of an address string
        /// </summary>
        public static AddressFormat DetectFormat(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                return AddressFormat.Unknown;

            if (IsValidBase58(address))
                return AddressFormat.Base58;

            if (IsValidBech32(address))
                return AddressFormat.Bech32;

            return AddressFormat.Unknown;
        }

        /// <summary>
        /// Validates an address (Base58Check or Bech32)
        /// </summary>
        public static bool IsValidAddress(string address)
        {
            return DetectFormat(address) != AddressFormat.Unknown;
        }

        /// <summary>
        /// Validates an address and returns detailed result
        /// </summary>
        public static AddressValidationResult ValidateAddress(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                return new AddressValidationResult(false, "Unknown", "Address is empty");

            var format = DetectFormat(address);

            switch (format)
            {
                case AddressFormat.Base58:
                    return new AddressValidationResult(true, "Base58Check");
                case AddressFormat.Bech32:
                    return new AddressValidationResult(true, "Bech32");
                default:
                    return new AddressValidationResult(false, "Unknown", "Invalid address format");
            }
        }

        /// <summary>
        /// Gets a human-readable validation message
        /// </summary>
        public static string GetValidationMessage(string address)
        {
            var result = ValidateAddress(address);
            return result.IsValid
                ? $"Valid {result.AddressType} address"
                : result.ErrorMessage;
        }

        /// <summary>
        /// Checks if address is valid Base58Check format
        /// </summary>
        public static bool IsValidBase58(string address)
        {
            try
            {
                Encoders.Base58Check.DecodeData(address);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if address is valid Bech32 format
        /// </summary>
        public static bool IsValidBech32(string address)
        {
            try
            {
                string hrp = GetBech32Hrp(address);
                if (string.IsNullOrEmpty(hrp))
                    return false;

                var encoder = Encoders.Bech32(hrp);
                byte[] decoded = encoder.Decode(address, out byte witnessVersion);
                return decoded != null && decoded.Length > 0;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the Human Readable Part from a Bech32 address
        /// </summary>
        public static string GetBech32Hrp(string address)
        {
            try
            {
                int separatorIndex = address.LastIndexOf('1');
                if (separatorIndex > 0 && separatorIndex < address.Length - 1)
                {
                    return address.Substring(0, separatorIndex).ToLowerInvariant();
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
