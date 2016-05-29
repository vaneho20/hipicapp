using System;
using System.Text.RegularExpressions;

namespace Hipicapp.Utils.Util
{
    public class ValidationUtils
    {
        private ValidationUtils()
        {
            // non instanceable
        }

        public const int MAX_LENGTH_DEFAULT = 255;
        public const int MAX_LENGTH_DESCRIPTION = 1024;
        public const int LENGTH_PROVINCE_ID = 2;
        public const int LENGTH_PROVINCE_PHONE_PREFIX = 3;
        public const int MAX_LENGTH_HEX_COLOR = 7;
        public const int LENGTH_ZIPCODE = 5;
        public const int MIN_LENGTH_TELEPHONE = 9;
        public const int MAX_LENGTH_TELEPHONE = 25;
        public const int MAX_LENGTH_REDEMPTION_CODE = 255;
        public const int MAX_LENGTH_URL = 1024;
        public const int MAX_LENGTH_IP_ADDRESS = 15;
        public const int LENGTH_SESSION_ID = 32;
        public const int MIN_PASSWORD_LENGTH = 6;

        public const int MIN_PRICE = 0;
        public const int MAX_PRICE = 999999999;
        public const int MIN_LATITUDE = -90;
        public const int MAX_LATITUDE = 90;
        public const int MIN_LONGITUDE = -180;
        public const int MAX_LONGITUDE = 180;

        public const int MIN_DISCOUNT = 1;
        public const int MAX_DISCOUNT = 100;

        //public const  Pattern IMAGE_MIME_TYPE_PATTERN = Pattern.compile("image/(gif|jpe?g|png)");
        public const int MAX_FILE_SIZE = 250000; // 250KB

        public static Regex IMAGE_MIME_TYPE_PATTERN = new Regex("image/(gif|jpe?g|png)", RegexOptions.Compiled);

        public static Regex PDF_MIME_TYPE_PATTERN = new Regex("application/pdf", RegexOptions.Compiled);

        public static bool IsValidPdfMimeType(string mimeType)
        {
            return PDF_MIME_TYPE_PATTERN.IsMatch(mimeType);
        }

        public static bool IsValidImageMimeType(string mimeType)
        {
            return IMAGE_MIME_TYPE_PATTERN.IsMatch(mimeType);
        }

        public static bool IsValidFileSize(long size)
        {
            return (size > 0) && (size <= MAX_FILE_SIZE);
        }

        public static bool IsValidNIF(string value)
        {
            bool salida = true;
            string nif = value;
            if (nif.Length > 9)
            {
                salida = false;
            }
            else
            {
                if (nif.Length < 9)
                {
                    int tamanio = nif.Length;
                    int faltan = 9 - tamanio;
                    for (int i = 0; i < faltan; i++)
                    {
                        nif = "0" + nif;
                    }
                }
                string dni = nif.Substring(0, nif.Length - 1);
                string letraActual = nif.Substring(nif.Length - 1, nif.Length - (nif.Length - 1));
                string caracterInicial = nif.Substring(0, 1);
                string regla = "[0-9]";

                if (Regex.IsMatch(letraActual, regla) || !Regex.IsMatch(caracterInicial, regla))
                {
                    salida = false;
                }
                else
                {
                    string cadena = "TRWAGMYFPDXBNJZSQVHLCKET";
                    try
                    {
                        int dniint = int.Parse(dni);
                        int posicion = dniint % 23;
                        string letraCorrecta = cadena.Substring(posicion, 1);
                        if (letraCorrecta.Equals(letraActual.ToUpper()))
                        {
                            salida = true;
                        }
                        else
                        {
                            salida = false;
                        }
                    }
                    catch (Exception e)
                    {
                        salida = false;
                    }
                }
            }
            return salida;
        }

        public static bool IsValidCIF(string cif)
        {
            bool salida = true;
            if (cif.Length != 9)
            {
                salida = false;
            }
            else
            {
                string letras = "ABCDEFGHJKLMNPQRSUVW";
                int par = 0;
                int impar = 0;
                string primerCaracter = cif.Substring(0, 1);
                string ultimoCaracter = cif.Substring(8, 9);
                string regla = "[0-9]";
                if (!Regex.IsMatch(cif, "[A-Z][0-9]{8}"))
                {
                    salida = false;
                    // if (primerCaracter.matches(regla)) {
                    // return false;
                }
                else
                {
                    // Es una letra
                    if (letras.IndexOf(primerCaracter.ToUpper()) != -1)
                    {
                        // Es una de las letras permitidas
                        for (int i = 2; i < 8; i += 2)
                        {
                            int digito = int.Parse(cif.Substring(i, i + 1));
                            par = par + digito;
                        }
                        for (int i = 1; i < 9; i += 2)
                        {
                            int digito = int.Parse(cif.Substring(i, i + 1));
                            int aux = 2 * digito;
                            if (aux > 9)
                            {
                                aux = 1 + (aux - 10);
                            }
                            impar = impar + aux;
                        }
                        int parcial = par + impar;
                        int control = (10 - (parcial % 10));
                        // Compruebo si es correcto
                        if (Regex.IsMatch(ultimoCaracter, regla))
                        {
                            // Es un numero
                            // si el dígito E( parcial % 10) es 0 y si el dígito de
                            // control ha de ser numérico entonces D=0 y no hacemos
                            // resta.
                            if (control == 10)
                            {
                                control = 0;
                            }
                            int ultimoDigito = int.Parse(ultimoCaracter);
                            if (control != ultimoDigito)
                            {
                                salida = false;
                            }
                        }
                        else
                        {
                            // Es una letra
                            string[] letras2 = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
                            if (!ultimoCaracter.Equals(letras2[control - 1]))
                            {
                                salida = false;
                            }
                        }
                    }
                    else
                    {
                        salida = false;
                    }
                }
            }
            return salida;
        }

        public static bool IsValidCIF2(string cif)
        {
            bool salida = true;
            if (cif.Length != 9)
            {
                salida = false;
            }
            else
            {
                string letras = "ABCDEFGHJKLMNPQRSUVW";
                int par = 0;
                int impar = 0;
                string primerCaracter = cif.Substring(0, 1); // letra del CIF
                string ultimoCaracter = cif.Substring(8, 9); // CIF menos primera

                if (!Regex.IsMatch(cif, "[A-Z][0-9]{7}[A-Z]"))
                {
                    salida = false;
                }
                else
                {
                    if (letras.IndexOf(primerCaracter.ToUpper()) != -1)
                    {
                        char[] codigos = { 'J', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
                        int[] calculo = { 0, 2, 4, 6, 8, 1, 3, 5, 7, 9 };
                        int i = 0;
                        for (i = 2; i < 7; i += 2)
                        {
                            par = par + int.Parse(Convert.ToString(cif[i]));
                            impar = impar + calculo[int.Parse(Convert.ToString(cif[i - 1]))];
                        }
                        impar = impar + calculo[int.Parse(Convert.ToString(cif[i - 1]))];
                        int parcial = par + impar;
                        int control = (10 - (parcial % 10));
                        if (ultimoCaracter.Equals(Convert.ToString(codigos[control])))
                        {
                            salida = true;
                        }
                        else
                        {
                            salida = false;
                        }
                    }
                    else
                    {
                        salida = false;
                    }
                }
            }
            return salida;
        }

        public static bool IsValidNIE(string nie)
        {
            bool salida = false;
            if (nie.Length != 9)
            {
                salida = false;
            }
            else
            {
                string primerCaracter = nie.Substring(0, 1);
                string resto = nie.Substring(1, nie.Length);
                if (!primerCaracter.Equals("X", StringComparison.OrdinalIgnoreCase) && !primerCaracter.Equals("Y", StringComparison.OrdinalIgnoreCase)
                        && !primerCaracter.Equals("Z", StringComparison.OrdinalIgnoreCase))
                {
                    salida = false;
                }
                string dni = resto.Substring(0, resto.Length - 1);
                string letraActual = resto.Substring(resto.Length - 1, resto.Length - (resto.Length - 1));
                string regla = "[0-9]";
                if (Regex.IsMatch(letraActual, regla) || Regex.IsMatch(primerCaracter, regla))
                {
                    salida = false;
                }
                else
                {
                    string cadena = "TRWAGMYFPDXBNJZSQVHLCKET";
                    if (primerCaracter.Equals("Y", StringComparison.OrdinalIgnoreCase))
                    {
                        dni = string.Concat("1", dni);
                    }
                    else if (primerCaracter.Equals("Z", StringComparison.OrdinalIgnoreCase))
                    {
                        dni = string.Concat("2", dni);
                    }
                    try
                    {
                        int dniint = int.Parse(dni);
                        int posicion = dniint % 23;
                        string letraCorrecta = cadena.Substring(posicion, 1);
                        if (letraCorrecta.Equals(letraActual.ToUpper()))
                        {
                            salida = true;
                        }
                        else
                        {
                            salida = false;
                        }
                    }
                    catch (FormatException e)
                    {
                        salida = false;
                    }
                }
            }
            return salida;
        }
    }
}