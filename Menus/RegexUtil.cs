using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hortifruti.Menus
{
    public partial class RegexUtil
    {
        [GeneratedRegex(@"^[a-zA-Z\s]+$")]
        public static partial Regex MyRegexNome();

        [GeneratedRegex(@"^\(?\d{2}\)?[\s-]?[\s9]?\d{4}-?\d{4}$")]
        public static partial Regex MyRegexTelefone();

        [GeneratedRegex(@"^\d{3}\.?\d{3}\.?\d{3}-?\d{2}$")]
        public static partial Regex MyRegexCpf();

        [GeneratedRegex(@"^\d{2}\.?\d{3}\.?\d{3}/?\d{4}-?\d{2}$")]
        public static partial Regex MyRegexCnpj();
    }
}