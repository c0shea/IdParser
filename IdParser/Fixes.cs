using System;

namespace IdParser
{
    internal static class Fixes
    {
        internal static string Apply(string input)
        {
            return input.RemoveInvalidCharactersFromHeader()
                        .FixIncorrectHeader()
                        .RemoveIncorrectCarriageReturns();
        }

        /// <summary>
        /// HID keyboard emulation, especially entered via a web browser, tends to mutilate the header.
        /// As long as part of the header is correct, this will fix the rest of it to make it parse-able.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string FixIncorrectHeader(this string input)
        {
            if (input[0] == '@' &&
                input[1] == Barcode.ExpectedSegmentTerminator &&
                input[2] == Barcode.ExpectedDataElementSeparator &&
                input[3] == Barcode.ExpectedRecordSeparator &&
                input[4] == 'A')
            {
                return input.Insert(4, Barcode.ExpectedSegmentTerminator.ToString() + Barcode.ExpectedDataElementSeparator);
            }

            return input;
        }

        /// <summary>
        /// Sometimes bad characters (e.g. @a ANSI) get into the header (usually through HID keyboard emulation).
        /// Replace the header with what we are expecting.
        /// </summary>
        private static string RemoveInvalidCharactersFromHeader(this string input)
        {
            input = input.TrimStart();

            if (input[0] != '@' || input.StartsWith(Barcode.ExpectedHeader))
            {
                return input;
            }

            // AAMVA 2003+
            var ansiPosition = input.IndexOf(Barcode.ExpectedFileType, StringComparison.Ordinal);

            if (ansiPosition >= 0)
            {
                return Barcode.ExpectedHeader + input.Substring(ansiPosition + Barcode.ExpectedFileType.Length);
            }

            // AAMVA 2000 and earlier
            var aamvaPosition = input.IndexOf("AAMVA", StringComparison.Ordinal);

            if (aamvaPosition >= 0)
            {
                return Barcode.ExpectedHeader + input.Substring(aamvaPosition + Barcode.ExpectedFileType.Length);
            }

            return input;
        }

        /// <summary>
        /// HID keyboard emulation (and some other methods) tend to replace the \r with \r\n
        /// which is invalid and doesn't conform to the AAMVA standard. This fixes it before attempting to parse the fields.
        /// </summary>
        private static string RemoveIncorrectCarriageReturns(this string input)
        {
            var crLf = Barcode.ExpectedSegmentTerminator.ToString() + Barcode.ExpectedDataElementSeparator;
            var doesInputContainCrLf = input.IndexOf(crLf, StringComparison.Ordinal) >= 0;

            if (doesInputContainCrLf)
            {
                var replacedString = input.Replace(Barcode.ExpectedSegmentTerminator.ToString(), string.Empty);

                return replacedString.Substring(0, 3) + Barcode.ExpectedSegmentTerminator + replacedString.Substring(4);
            }

            return input;
        }
    }
}
