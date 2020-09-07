using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BDSA2019.Assignment01
{
    public static class RegExpr
    {
        public static IEnumerable<string> SplitLine(IEnumerable<string> lines)
        {
            List<string> strings = new List<string>();

            foreach (var s in lines)
            {
                var pattern = @"(.+?) | (\w ? (\s+? $))";
                string[] splittedString = Regex.Split(s, pattern);
                foreach (var i in splittedString)
                {
                    if (!i.Equals("") && Regex.IsMatch(i + " ", pattern)) strings.Add(i);
                }
            }

            return strings;

        }

        public static IEnumerable<(int width, int height)> Resolution(string resolutions)
        {
            var pattern = @"^(?'first_number'[0-9].*)x(?'second_number'[0-9].*\S)$";
            int firstNumber = 0;
            int secondNumber = 0;
            var list = new List<(int width, int height)>();

            foreach (Match m in Regex.Matches(resolutions, pattern))
            {
                var _firstNumber = m.Groups[1].ToString();
                var _secondNumber = m.Groups[2].ToString();

                int.TryParse(_firstNumber, out firstNumber);
                int.TryParse(_secondNumber, out secondNumber);

                var pair = (firstNumber, secondNumber);
                list.Add(pair);

            }
            return list;
        }

        public static IEnumerable<string> InnerText(string html, string tag)
        {
            var pattern = @"([^<>]*?)(<\/?[-:\w]+)(?:>|\s[^<>]*?>)|$";
            var list = new List<string>();
            string prevTag = null;

            foreach (Match m in Regex.Matches(html, pattern))
            {
                var tags = m.Groups[0].ToString();
                var innerText = m.Groups[1].ToString();

                if (!tags.Equals("") && !innerText.Equals(""))
                {
                    if (tag.Equals(tags) || tag.Equals(prevTag))
                    {
                        list.Add(innerText);
                    }
                }
                prevTag = tags;
            }
            return list;
        }
    }
}
