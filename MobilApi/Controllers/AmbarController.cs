using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobilApi.Data;

namespace MobilApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmbarController : ControllerBase
    {
        private IAppRepository _appRepository;
        public AmbarController(IAppRepository appRepository)
        {
            _appRepository = appRepository;
        }
        [HttpGet]
        [Route("Findall")]
        public ActionResult GetAmbar()
        {
            var ambar = _appRepository.GetAmbar();
            if(ambar!=null)
                return Ok(ambar);
            else
                return Notfound();
        }
        [HttpGet]
        [Route("Find/{id}")]
        public ActionResult GetAmbarById(int id)
        {
            var ambar = _appRepository.GetAmbarById(id);
            if(ambar!= null)
                return Ok(ambar);
            else
                return NotFound();
        }
        [HttpGet]
        [Route("Findname/{AmbarAdi}")]
        public ActionResult GetAmbarByAd(string AmbarAdi)
        {
            var ambar = _appRepository.GetAmbarByAd(AmbarAdi);
            if(ambar!= null)
                return Ok(ambar);
            else
                return NotFound();
        }

    }
}
