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
    public class BolumController : ControllerBase
    {
        private IAppRepository _appRepository;
        public BolumController(IAppRepository appRepository)
        {
            _appRepository = appRepository;
        }
        [HttpGet]
        [Route("FindAll")]
        public ActionResult GetBolum()
        {
            var bolum = _appRepository.GetBolum().ToList();
            return Ok(bolum);
        }
        [HttpGet]
        [Route("Find/{id}")]
        public ActionResult GetBolumById(int id)
        {
            var bolum = _appRepository.GetBolumById(id);
            return Ok(bolum);
        }
        [HttpGet]
        [Route("Findname/{BolumAdi}")]
        public ActionResult GetBolumByAd(string BolumAdi)
        {
            var bolum = _appRepository.GetBolumByAd(BolumAdi);
            return Ok(bolum);
        }

    }
}