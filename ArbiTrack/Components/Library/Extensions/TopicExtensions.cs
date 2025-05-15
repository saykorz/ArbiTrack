using Nethereum.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbiTrack.Components.Library.Extensions
{
    public static class TopicExtensions
    {
        public static DateTime ToDateTimeFromHexTimestamp(this string hexTimestamp)
        {
            if (string.IsNullOrWhiteSpace(hexTimestamp))
                return DateTime.MinValue;

            // Премахваме "0x" ако го има
            if (hexTimestamp.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
                hexTimestamp = hexTimestamp[2..];

            // Преобразуваме hex към long
            var secondsSinceEpoch = Convert.ToInt64(hexTimestamp, 16);

            // UNIX епохата започва от 1970-01-01 UTC
            var dateTime = DateTimeOffset.FromUnixTimeSeconds(secondsSinceEpoch).UtcDateTime;

            return dateTime;
        }

        public static string ToEthereumAddress(this string topic)
        {
            if (string.IsNullOrWhiteSpace(topic) || topic.Length != 66 || !topic.StartsWith("0x"))
                throw new ArgumentException("Invalid topic format. Must be 66-character hex string starting with '0x'.");

            var rawAddress = topic.Substring(26); // премахваме водещите нули: 2 за "0x" + 24 за 12 байта (защото адресът е последните 20 байта)
            return $"0x{rawAddress}".ToChecksumAddress();
        }

        public static string ToAppId(this string hex)
        {
            if (string.IsNullOrWhiteSpace(hex) || !hex.StartsWith("0x"))
                throw new ArgumentException("Hex string must start with '0x'.");

            return hex.Substring(2).ToUpperInvariant();
        }

        public static int ToVotes(this string hex)
        {
            if (string.IsNullOrWhiteSpace(hex) || !hex.StartsWith("0x"))
                throw new ArgumentException("Hex string must start with '0x'.");

            var number = System.Numerics.BigInteger.Parse(hex[2..], System.Globalization.NumberStyles.HexNumber);
            var ether = number / System.Numerics.BigInteger.Pow(10, 18);

            if (ether > int.MaxValue)
                throw new OverflowException("Value is too large for an int.");

            return (int)ether;
        }

        public static string ToChecksumAddress(this string address)
        {
            if (!address.StartsWith("0x"))
                throw new ArgumentException("Address must start with 0x");

            address = address.Substring(2).ToLowerInvariant();
            var hash = Sha3Keccack.Current.CalculateHash(address);
            var result = "0x";

            for (int i = 0; i < address.Length; i++)
            {
                result += int.Parse(hash[i].ToString(), System.Globalization.NumberStyles.HexNumber) >= 8
                    ? char.ToUpper(address[i])
                    : address[i];
            }

            return result;
        }


    }

}
