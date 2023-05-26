using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PLMVC.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Materia materia = new ML.Materia();
            materia.Materias = new List<object>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:59361/api/");

                var responseTask = client.GetAsync("Materia/GetAll");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Materia resultMateriaList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(resultItem.ToString());
                        materia.Materias.Add(resultMateriaList);
                    }
                }
            }
            return View(materia);
        }

        [HttpGet]
        public ActionResult Form(int? idMateria)
        {
            ML.Materia materia = new ML.Materia();

            if (idMateria == null)
            {
                return View(materia);
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:59361/api/");

                var responseTask = client.GetAsync("Materia/GetById/" + idMateria);
                responseTask.Wait();

                var resultApi = responseTask.Result;
                if (resultApi.IsSuccessStatusCode)
                {
                    var readTask = resultApi.Content.ReadAsAsync<ML.Result>();

                    ML.Materia resultItem = new ML.Materia();
                    resultItem = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(readTask.Result.Object.ToString());
                    materia = resultItem;
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al realizar la consulta de las materias";
                    return View("Modal");
                }
            }
            return View(materia);
        }
        [HttpPost]
        public ActionResult Form(ML.Materia materia)
        {
            if (materia.IdMateria == 0 || materia.IdMateria == null)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:59361/api/");

                    var responseTask = client.PostAsJsonAsync<ML.Materia>("Materia/Add", materia);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Se a insertado correctamente la Materia";
                        return View("Modal");
                    }
                }
                return View("GetAll");
            }
            else
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:59361/api/");

                    var responseTask = client.PutAsJsonAsync<ML.Materia>("Materia/Update", materia);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Se a actualizado correctamente la Materia";
                        return View("Modal");
                    }
                }
                return View();
            }
        }

        public ActionResult Delete(int idMateria)
        {
            ML.Materia materia = new ML.Materia();
            materia.IdMateria = idMateria;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:59361/api/");

                var responseTask = client.PostAsJsonAsync("Materia/Delete", materia);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Se a eliminado correctamente la Materia";
                    return View("Modal");
                }
            }
            return View("GetAll");
        }
    }
}