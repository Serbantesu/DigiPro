using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace SLWebApi.Controllers
{
    public class MateriasController : ApiController
    {
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Materia/GetAll")]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Materia.MateriaGetAll();

            if (result.Correct)
            {
                return Content(System.Net.HttpStatusCode.OK, result);
            }
            else
            {
                return Content(System.Net.HttpStatusCode.NotFound, result);
            }
            
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Materia/GetById/{idMateria}")]
        public IHttpActionResult GetById(int idMateria)
        {
            ML.Result result = BL.Materia.MateriaGetById(idMateria);

            if (result.Correct)
            {
                return Content(System.Net.HttpStatusCode.OK, result);
            }
            else
            {
                return Content(System.Net.HttpStatusCode.NotFound, result);
            }

        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Materia/Add")]
        public IHttpActionResult Add([FromBody]ML.Materia materia)
        {
            ML.Result result = BL.Materia.MateriaAdd(materia);

            if (result.Correct)
            {
                return Content(System.Net.HttpStatusCode.OK, result);
            }
            else
            {
                return Content(System.Net.HttpStatusCode.NotFound, result);
            }

        }

        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/Materia/Update")]
        public IHttpActionResult Update([FromBody] ML.Materia materia)
        {
            ML.Result result = BL.Materia.MateriaUpdate(materia);
            if (result.Correct)
            {
                return Content(System.Net.HttpStatusCode.OK, result);
            }
            else
            {
                return Content(System.Net.HttpStatusCode.NotFound, result);
            }

        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Materia/Delete")]
        public IHttpActionResult Delete([FromBody] ML.Materia materia)
        {
            ML.Result result = BL.Materia.MateriaDelete(materia);
            if (result.Correct)
            {
                return Content(System.Net.HttpStatusCode.OK, result);
            }
            else
            {
                return Content(System.Net.HttpStatusCode.NotFound, result);
            }
        }


    }
}