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
        // nome sem números ou caracteres especiais.

        [GeneratedRegex(@"^\(?\d{2}\)?[\s-]?[\s9]?\d{4}-?\d{4}$")]
        public static partial Regex MyRegexTelefone();
        // formatos: (11) 91234-5678, 11 91234-5678, 1191234-5678, 91234-5678.

        [GeneratedRegex(@"^\d{3}\.?\d{3}\.?\d{3}-?\d{2}$")]
        public static partial Regex MyRegexCpf();
        // formatos: 123.456.789-09, 12345678909

        [GeneratedRegex(@"^\d{2}\.?\d{3}\.?\d{3}/?\d{4}-?\d{2}$")]
        public static partial Regex MyRegexCnpj();
        // formatos: 12.345.678/0001-95, 12345678000195.
    }
}