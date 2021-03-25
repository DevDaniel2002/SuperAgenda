﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SuperAgenda.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SuperAgenda.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly dbContactosContext _db;

        public HomeController(ILogger<HomeController> logger, dbContactosContext db)
        {
            _logger = logger;
            _db = db;
        }
        public IActionResult Index()
        {
            var contactos = _db.Contactos;
            return View(contactos);
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Contacts input)
        {
            if (ModelState.IsValid)
            {
                _db.Contactos.Add(input);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(input);
        }

        public IActionResult Detalle(int id)
        {
            var output = _db.Contactos.Find(id);
            return View(output);
        }


        public IActionResult Modificar(int id)
        {
            var output = _db.Contactos.Find(id);
            return View(output);
        }

        [HttpPost]
        public IActionResult Modificar(Contacts input)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(input).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _db.SaveChanges();

                return RedirectToAction("Index");

            }
            return View(input);
        }



        public IActionResult Eliminar(int id)
        {
            var output = _db.Contactos.Find(id);
            return View(output);
        }

        [HttpPost]
        public IActionResult Eliminar(Contacts input)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(input).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _db.SaveChanges();

                return RedirectToAction("Index");

            }
            return View(input);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
