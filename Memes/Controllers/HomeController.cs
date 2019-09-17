using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Memes.Models;
using Memes.Data;
using System.Collections;


namespace Memes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int id)
        {

            Meme meme = new Meme();
            try
            {
                meme.pageIndex = id;
                var memesCount = _context.Meme.Count<Meme>();
                if ((id + 1) * 10 < memesCount)
                {
                    meme.nextPageExists = true;
                }
                int i;
                if (memesCount % 10 == 0) i = 0; else i = 1;            //Troche kombinacji z racji tego, że memy zapisywane są w kolejce FIFO, a ściągać
                meme.lastPage = (memesCount / 10) + i;                  //musimy je jako LIFO, obliczenia to jedynie wyznaczenie indeksów odkąd zaczać pobieranie
                int j = memesCount - (meme.pageIndex * 10) - 10;        //nie są to skomplikowane obliczenia, więc nie ma to wpływu na szybkość pobierania memów z serwera
                int take = j >= 0 ? 10 : 10 + j;
                j = take < 10 ? 0 : j;            
                var list = _context.Meme.Skip(j).Take((take));
                meme.displayMemes = list.ToList<Meme>();
                meme.displayMemes.Reverse();            //Odwracamy, bo elementy pobrały sie prawidłowo od końca, ale nadal ostatni dodany jest ostatni a ma być pierwszy
            }
            catch
            {
                meme.displayMemes = new List<Meme>();
            }

            return View(meme);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
