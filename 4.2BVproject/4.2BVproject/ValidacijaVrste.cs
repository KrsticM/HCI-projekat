using System;
using System.Linq;
using System.Windows.Controls;

namespace _4._2BVproject
{
    public class ValidacijaVrste : ValidationRule
    {
        public Type ValidationType { get; set; }
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            String ime = value as String;
            ime = ime.Trim();
            if ( ime.Equals("") )
            {
                return new ValidationResult(false, "Morate uneti ime.");
            }
            else
            {
                if (ime.Length < 3)
                {
                    return new ValidationResult(false, "Ime mora imati najmanje 3 karaktera.");
                }                    
            }
            return ValidationResult.ValidResult;
        }
    }
    public class ValidacijaOznakeVrste : ValidationRule
    {
        public Type ValidationType { get; set; }
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            String oznaka = value as String;
            oznaka = oznaka.Trim();
            if (oznaka.Equals(""))
            {
                return new ValidationResult(false, "Morate uneti oznaku.");
            }
            else
            {
                if (value.ToString().Length < 3)
                    return new ValidationResult(false, "Oznaka mora imati najmanje 3 karaktera.");
            }
            if (Window1.obradjivana != null)
            {
                //Console.WriteLine("Postoji obradjivana!");
                // Ako postoji obradjivana nju izuzmi iz provere

                foreach(UgrozenaVrsta uv in MainWindow.ugrozeneVrste)
                {
                    if(uv.Oznaka.Equals(oznaka))
                    {
                        if(!uv.Oznaka.Equals(Window1.obradjivana.Oznaka))
                        {
                            return new ValidationResult(false, "Oznaka mora biti jedinstvena.");
                        }
                    }
                }

            }
            else // Ako ne postoji obradjivana radi kao i do sada
            {
                //Console.WriteLine("Ne postoji obradjivana!");
                var postoji = MainWindow.ugrozeneVrste.Where(e => e.Oznaka == oznaka);

                if (postoji.ToList().Count != 0)
                {
                    return new ValidationResult(false, "Oznaka mora biti jedinstvena.");
                }

            }

            return ValidationResult.ValidResult;
        }
    }
    public class ValidacijaOznakeTipa : ValidationRule
    {
        public Type ValidationType { get; set; }
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            String oznaka = value as String;
            oznaka = oznaka.Trim();
            if (oznaka.Equals(""))
            {
                return new ValidationResult(false, "Morate uneti oznaku.");
            }
            else
            {
                if (value.ToString().Length < 3)
                    return new ValidationResult(false, "Oznaka mora imati najmanje 3 karaktera.");
            }
            
            if(Window2.obradjivaniTip != null)
            {
                foreach (TipVrste tv in MainWindow.TipoviVrsta)
                {
                    if (tv.Oznaka.Equals(oznaka))
                    {
                        if (!tv.Oznaka.Equals(Window2.obradjivaniTip.Oznaka))
                        {
                            return new ValidationResult(false, "Oznaka mora biti jedinstvena.");
                        }
                    }
                }
            }
            else
            {
                var postoji = MainWindow.TipoviVrsta.Where(e => e.Oznaka == oznaka);

                if (postoji.ToList().Count != 0)
                {
                    return new ValidationResult(false, "Oznaka mora biti jedinstvena.");
                }

            }

            return ValidationResult.ValidResult;
        }
    }
    public class ValidacijaOznakeEtikete : ValidationRule
    {
        public Type ValidationType { get; set; }
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            String oznaka = value as String;
            oznaka = oznaka.Trim();
            if (oznaka.Equals(""))
            {
                return new ValidationResult(false, "Morate uneti oznaku.");
            }
            else
            {
                if (value.ToString().Length < 3)
                    return new ValidationResult(false, "Oznaka mora imati najmanje 3 karaktera.");
            }

            if(Window3.obradjivanaEtiketa != null)
            {
                foreach (Etiketa uv in MainWindow.Etikete)
                {
                    if (uv.Oznaka.Equals(oznaka))
                    {
                        if (!uv.Oznaka.Equals(Window3.obradjivanaEtiketa.Oznaka))
                        {
                            return new ValidationResult(false, "Oznaka mora biti jedinstvena.");
                        }
                    }
                }
            }
            else
            {
                var postoji = MainWindow.Etikete.Where(e => e.Oznaka == oznaka);

                if (postoji.ToList().Count != 0)
                {
                    return new ValidationResult(false, "Oznaka mora biti jedinstvena.");
                }
            }

           

            return ValidationResult.ValidResult;
        }
    }

    public class ValidacijaPrihoda : ValidationRule
    {
        public Type ValidationType { get; set; }
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            String prihod = value as String;
            prihod = prihod.Trim();

            int n;
            bool isNumeric = int.TryParse(prihod, out n);

            if(!isNumeric)
            {
                return new ValidationResult(false, "Morate uneti broj.");
            }
            return ValidationResult.ValidResult;
        }
    }


}
