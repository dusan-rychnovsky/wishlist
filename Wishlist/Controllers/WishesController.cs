using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Wishlist.Models;

namespace Wishlist.Controllers
{
    public sealed class WishesController : Controller
    {
        public IActionResult Index()
        {
            return View(new[]
            {
                new WishViewModel
                {
                    Title = "Joe Abercrombie - Ostre konce",
                    SubTitle = "Kniha",
                    Description = "Sbirka povidek. Muze byt tistena kniha nebo e-book ve formatu pro Kindle (.mobi, .pdf).",
                    Image = "ostre-konce",
                    Links = new[]
                    {
                       new WishViewModel.Link
                       {
                           Text = "Amazon",
                           Url = "https://www.amazon.com/Sharp-Ends-Stories-World-First/dp/0316390828"
                       },
                       new WishViewModel.Link
                       {
                           Text = "Luxor",
                           Url = "https://luxor.cz/beletrie/ostre-konce--295088"
                       }
                    },
                    Price = "$ 7.32 / 314 Kc"
                },
                new WishViewModel
                {
                    Title = "Dr Rangan Chatterjee - Feel Better in 5",
                    SubTitle = "Kniha",
                    Description = "Popularne naucna kniha. Muze byt tistena nebo e-book ve formatu pro Kindle (.mobi, .pdf).",
                    Image = "feel-better-in-5",
                    Links = new[]
                    {
                        new WishViewModel.Link
                        {
                            Text = "Amazon",
                            Url = "https://www.amazon.co.uk/Feel-Better-daily-supercharge-health/dp/0241397804"
                        }
                    },
                    Price = "£ 9.99 / £ 13.99"
                },
                new WishViewModel
                {
                    Title = "Xiaomi Mi In-Ear cerna",
                    SubTitle = "Klasicka sluchatka",
                    Image = "sluchatka-xiaomi",
                    Links = new[]
                    {
                        new WishViewModel.Link
                        {
                            Text = "Alza",
                            Url = "https://www.alza.cz/xiaomi-mi-in-ear-headphones-basic-black-d5261089.htm"
                        }
                    },
                    Price = "249 Kc"
                },
                new WishViewModel
                {
                    Title = "QCY T1C cerna",
                    SubTitle = "Bezdratova sluchatka",
                    Image = "bezdratova-sluchatka-qcy",
                    Links = new[]
                    {
                        new WishViewModel.Link
                        {
                            Text = "Alza",
                            Url = "https://www.alza.cz/qcy-t1c-cerna-d5505954.htm"
                        }
                    },
                    Price = "990 Kc"
                },
                new WishViewModel
                {
                    Title = "ScreenShield pro Samsung Galaxy A5",
                    SubTitle = "Ochranna folie",
                    Description = "Ochrana folie na telefon. Mozno sehnat i skrz AliExpress.",
                    Image = "screen-shield-a5",
                    Links = new[]
                    {
                        new WishViewModel.Link
                        {
                            Text = "Alza",
                            Url = "https://www.alza.cz/screenshield-pro-samsung-galaxy-a5-na-displej-telefonu-d2357397.htm"
                        }
                    },
                    Price = "299 Kc"
                },
                new WishViewModel
                {
                    Title = "Hario Mini Mill Slim",
                    SubTitle = "Mlynek na kavu",
                    Description = "Malicky rucni mlynek na kavu s keramickymi kameny.",
                    Image = "mlynek-na-kavu",
                    Links = new []
                    {
                        new WishViewModel.Link
                        {
                            Text = "Cerstva kava",
                            Url = "https://www.cerstvakava.cz/1075-rucni-mlynek-na-kavu-hario-mini-mill-slim-mss-1b/"
                        }
                    },
                    Price = "899 Kc"
                },
                new WishViewModel
                {
                    Title = "Tescoma DELLA CASA 5000 ml",
                    SubTitle = "Souprava pro kvaseni",
                    Description = "Souprava pro kvaseni obsahujici 5l sklenici, vzduchotesne vicko a zavazi. Zavazi je treba koupit samostatne.",
                    Image = "souprava-pro-kvaseni-tescoma",
                    Links = new []
                    {
                        new WishViewModel.Link
                        {
                            Text = "Tescoma (sklenice)",
                            Url = "https://eshop.tescoma.cz/souprava-pro-kvaseni-della-casa-5000-ml"
                        },
                        new WishViewModel.Link
                        {
                            Text = "Tescoma (zavazi)",
                            Url = "https://eshop.tescoma.cz/zavazi-pro-kvaseni-della-casa-3-ks"
                        }
                    },
                    Price = "399 + 299 Kc"
                }
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
