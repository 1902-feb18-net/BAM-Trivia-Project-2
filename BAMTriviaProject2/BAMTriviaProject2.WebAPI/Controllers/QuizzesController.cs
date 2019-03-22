using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Library.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BAMTriviaProject2.WebAPI.Controllers
{
    public class QuizzesController : Controller
    {
        private readonly ILogger<QuizzesController> _logger;


        public QuizzesController(IQuizRepo _quizRepo, ILogger<QuizzesController> logger)
        {
            quizRepo = _quizRepo;
            _logger = logger;
        }

        public IQuizRepo quizRepo { get; set; }

        // GET: Quizzes
        public ActionResult Index()
        {
            return View();
        }

        // GET: Quizzes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Quizzes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Quizzes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Quizzes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Quizzes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Quizzes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Quizzes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}