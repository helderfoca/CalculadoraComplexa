using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalculadoraCompleta.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet] //facultativo, usado por defeito
        public ActionResult Index()
        {
            return View();
        }

        // POST: Home
        [HttpPost]
        public ActionResult Index(string bt, string display)
        {
            int pos;
            float num1, num2, resultado;
            if (bt == "C")
            {
                display = "";
            }
            else if (bt == "+/-")
            {
                num1 = (float)Convert.ToDecimal(display);
                resultado = num1 * -1;
                display = resultado.ToString();
            }
            else if (bt == "=")
            {
                if (display.Contains('+'))
                {
                    pos = display.IndexOf('+');
                    num1 = (float)Convert.ToDecimal(display.Substring(0, pos));
                    num2 = (float)Convert.ToDecimal(display.Substring(pos + 1));
                    resultado = num1 + num2;
                }
                else if (display.Contains('-'))
                {
                    pos = display.IndexOf('-');
                    num1 = (float)Convert.ToDecimal(display.Substring(0, pos));
                    num2 = (float)Convert.ToDecimal(display.Substring(pos + 1));
                    resultado = num1 - num2;
                }
                else if (display.Contains('x'))
                {
                    pos = display.IndexOf('x');
                    num1 = (float)Convert.ToDecimal(display.Substring(0, pos));
                    num2 = (float)Convert.ToDecimal(display.Substring(pos + 1));
                    resultado = num1 * num2;
                }
                else if (display.Contains(':'))
                {
                    pos = display.IndexOf(':');
                    num1 = (float)Convert.ToDecimal(display.Substring(0, pos));
                    num2 = (float)Convert.ToDecimal(display.Substring(pos + 1));
                    resultado = num1 / num2;
                }
                else
                {
                    resultado = (float)Convert.ToDecimal(display);
                }
                display = resultado.ToString();
            }
            else
            {
                display += bt;
            }
            ViewBag.Display = display;
            return View();
        }
    }
}