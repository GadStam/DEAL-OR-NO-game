using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MALETINES.Models;

namespace MALETINES.Controllers
{
    public class JuegoController : Controller
    {
        private readonly ILogger<JuegoController> _logger;

        public JuegoController(ILogger<JuegoController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Importes = DealOrNo.ListaImportes();
            return View();
        }


        public IActionResult elegirPrimerMaletin(int maletin){
            DealOrNo.IniciarJuego(maletin);
            ViewBag.Maletines = DealOrNo.DevolverListaMaletines();
            ViewBag.Importes = DealOrNo.ListaImportes();
            ViewBag.maletinElegido = DealOrNo._maletinElegido;
            ViewBag.CantidadJugadas = DealOrNo.JugadasRestantes();
            ViewBag.ImportesDescartados = DealOrNo.ImportesDescartados;
            return View("Juego");
        }

        public IActionResult eleccionMaletin(int maletin){
            ViewBag.ImporteAbierto=DealOrNo.AbrirMaletin(maletin);
            DealOrNo.AbrirMaletin(maletin);
            ViewBag.CantidadJugadas = DealOrNo.JugadasRestantes();
            ViewBag.Maletines = DealOrNo.DevolverListaMaletines();
            ViewBag.Importes = DealOrNo.ListaImportes();
            ViewBag.ImportesDescartados = DealOrNo.ImportesDescartados;
            if(ViewBag.CantidadJugadas==0){
                ViewBag.Banca=DealOrNo.OfertaBanca();              
                return View("Decisicion");
            }else{
                return View("Juego");
            }
        }

        public IActionResult decision(string decision){
            ViewBag.Decision=DealOrNo.DecisionOferta(decision);
            ViewBag.Importes = DealOrNo.ListaImportes();
            ViewBag.Maletines = DealOrNo.DevolverListaMaletines();
            ViewBag.Of=DealOrNo.DevolverOf();
            if(ViewBag.Decision==-1){
                ViewBag.CantidadJugadas = DealOrNo.JugadasRestantes();
                if(ViewBag.Of==9){
                    ViewBag.Banca=DealOrNo.DevolverImporteMaletinEle();
                    return View("Final");  
                }else{
                    ViewBag.ImportesDescartados = DealOrNo.ImportesDescartados;
                    return View("Juego");
                }
            }else{
                ViewBag.Banca=DealOrNo.OfertaBanca();
                return View("Final");
            }    
        }
    }
}
