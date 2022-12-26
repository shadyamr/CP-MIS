using System.Text.RegularExpressions;

namespace projectMIS
{
    public class functions
    {
        public string RemoveLeadingZeros(string s)
        {
            int i = 0;
            while (i < s.Length && s[i] == '0')
            {
                i++;
            }
            return s.Substring(i);
        }

        public string Title(string status)
        {
            int title = int.Parse(status);

            if (title == 0)
            {
                return "Ex Employee";
            }
            else if (title == 1)
            {
                return "Employee Level 1";
            }
            else if (title == 2)
            {
                return "Employee Level 2";
            }
            else if (title == 3)
            {
                return "Employee Level 3";
            }
            else if (title == 4)
            {
                return "Employee Level 4";
            }
            else
            {
                return "undefined";
            }
        }

        public string ExtractNumbers(string input)
        {
            var regex = new Regex(@"\d+");
            var match = regex.Match(input);

            return match.Value;
        }
    }

}
