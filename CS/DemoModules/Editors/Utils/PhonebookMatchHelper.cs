using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace DemoCenter.Maui.Views {
    public class PhonebookMatchHelper {
        static string[] phoneLetters = new[] {
                "", "", "[abcABC]", "[defDEF]", "[ghiGHI]", "[jklJKL]", "[mnoMNO]", "[pqrsPQRS]", "[tuvTUV]", "[wxyzWXYZ]"
        };

        public static PhoneBookEntryMatch MatchPhoneNumber(string phoneNumber, string input) {
            if (String.IsNullOrEmpty(input))
                return null;
            List<char> digits = new List<char>();
            List<int> indexes = new List<int>();
            int nextIndex = 0;
            foreach (char c in phoneNumber) {
                if (Char.IsDigit(c)) {
                    digits.Add(c);
                    indexes.Add(nextIndex);
                }
                nextIndex++;
            }
            if (digits.Count == 0)
                return null;
            string phoneNumberDigits = new String(digits.ToArray());
            string inputDigits = new String(input.Where(c => Char.IsDigit(c)).ToArray());
            if (String.IsNullOrEmpty(inputDigits))
                return null;
            int inputIndex = phoneNumberDigits.IndexOf(inputDigits);
            if (inputIndex == -1)
                return null;
            int startIndex = indexes[inputIndex];
            int endIndex = indexes[inputIndex + inputDigits.Length - 1];
            return new PhoneBookEntryMatch(phoneNumber, startIndex, endIndex - startIndex + 1);
        }

        public static PhoneBookEntryMatch MatchPhoneLetters(string fullName, string input) {
            if (String.IsNullOrEmpty(input))
                return null;
            StringBuilder builder = new StringBuilder();
            foreach (char c in input) {
                if (!Char.IsDigit(c))
                    continue;
                builder.Append(phoneLetters[c - '0']);
            }
            string inputString = builder.ToString();
            if (inputString.Length == 0) {
                int startIndex = fullName.IndexOf(input);
                if (startIndex == -1)
                    return null;
                return new PhoneBookEntryMatch(fullName, startIndex, input.Length);
            }
            Regex phoneLettersRegex = new Regex(builder.ToString());
            Match match = phoneLettersRegex.Match(fullName);
            if (!match.Success)
                return null;
            return new PhoneBookEntryMatch(fullName, match.Index, match.Length);
        }
    }

    public class PhoneBookEntryMatch {
        internal PhoneBookEntryMatch(string entryField, int index, int length) {
            EntryField = entryField;
            Index = index;
            Length = length;
        }

        public string EntryField { get; }
        public int Index { get; }
        public int Length { get; }

        public FormattedString AsFormattedString(Color matchHighlightColor) {
            FormattedString formattedString = new FormattedString();
            if (Index != 0)
                formattedString.Spans.Add(new Span() { Text = EntryField.Substring(0, Index) });
            formattedString.Spans.Add(new Span() { Text = EntryField.Substring(Index, Length), TextColor = matchHighlightColor });
            int endIndex = Index + Length;
            if (endIndex != EntryField.Length)
                formattedString.Spans.Add(new Span() { Text = EntryField.Substring(endIndex) });
            return formattedString;
        }
    }
}
