﻿//using EserMarioKart.Services;
//using Microsoft.AspNetCore.Mvc;

//namespace EserMarioKart.Controllers
//{
//        [ApiController]
//        [Route("[controller]")]
//        public class PersonaggioController : Controller
//        {
//            private readonly PersonaggioService _service;

//            public PersonaggioController(PersonaggioService service)
//            {
//                _service = service;
//            }

//            [HttpGet("filtrati")]
//            public ActionResult<Risposta> ElencoProdottiFiltrati()
//            {
//                return Ok(new Risposta()
//                {
//                    Status = "SUCCESS",
//                    Data = _service.RestituisciProdottiFiltrati()
//                });
//            }

//            [HttpGet("nonfiltrati")]
//            public ActionResult<Risposta> ElencoProdottiNonFiltrati()
//            {
//                return Ok(new Risposta()
//                {
//                    Status = "SUCCESS",
//                    Data = _service.RestituisciTutti()
//                });
//            }

//            [HttpPost("inserisci")]
//            public ActionResult<Risposta> InserisciProdotto(ProdottoDto objProd)
//            {
//                List<string> listaErrori = new List<string>();

//                if (objProd.Nom is null || objProd.Nom.Trim().Equals(""))
//                    listaErrori.Add("Nome vuoto");

//                if (objProd.Cat is null || objProd.Cat.Trim().Equals(""))
//                    listaErrori.Add("Categoria vuota");

//                if (objProd.Pre < 0)
//                    listaErrori.Add("Prezzo errato");

//                if (_service.InserisciProdotto(objProd))
//                {
//                    return Ok(new Risposta()
//                    {
//                        Status = "SUCCESS"
//                    });
//                }
//                else
//                {
//                    listaErrori.Add("Inserimento fallito");
//                }

//                return Ok(new Risposta()
//                {
//                    Status = "ERROR",
//                    Data = listaErrori
//                });
//            }

//            [HttpDelete("elimina/{varCod}")]
//            public ActionResult Delete(string varCod)
//            {
//                if (_service.EliminaProdotto(new ProdottoDto() { Cod = varCod }))
//                    return Ok(new Risposta()
//                    {
//                        Status = "SUCCESS"
//                    });

//                return Ok(new Risposta()
//                {
//                    Status = "ERROR",
//                    Data = "Eliminazione non effettuata"
//                });
//            }

//            [HttpGet("quantita/{varCod}/{varTipo}")]
//            public ActionResult ModificaQuantita(string varCod, string varTipo)
//            {
//                bool risultato = false;

//                switch (varTipo)
//                {
//                    case "incremento":
//                        risultato = _service.Incrementa(new ProdottoDto() { Cod = varCod });
//                        break;
//                    case "decremento":
//                        risultato = _service.Decrementa(new ProdottoDto() { Cod = varCod });
//                        break;
//                    default:
//                        return BadRequest();
//                        break;
//                }

//                if (risultato)
//                    return Ok(new Risposta()
//                    {
//                        Status = "SUCCESS"
//                    });

//                return Ok(new Risposta()
//                {
//                    Status = "ERROR",
//                    Data = "Modifica non effettuata"
//                });
//            }

//            [HttpPost("ricerca")]
//            public ActionResult EffetuaRicerca(QueryDto oQue)
//            {
//                return Ok(new Risposta() { Status = "SUCCESS", Data = _service.Ricerca(oQue) });
//            }
//        }
//}
