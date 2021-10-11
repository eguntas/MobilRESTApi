using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobilApi.Data;
using MobilApi.Models;

namespace MobilApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirmaController : ControllerBase
    {
        private IAppRepository _appRepository;
        public FirmaController(IAppRepository appRepository)
        {
            _appRepository = appRepository;
        }
        [HttpPost]
        public ActionResult Add([FromBody]FirmaTbl firma)
        {
            if (firma == null)
            {
                return BadRequest();
            }

            _appRepository.Add(firma);
            _appRepository.SaveAll();
            return Ok(firma);
        }
        [Route("Findall")]
        [HttpGet]
        public ActionResult Get()
        {
            var firma = _appRepository.GetFirma().ToList();
            if(firma != null)
                return Ok(firma);
            else
                return NotFound();
        }
        [Route("Find/{id}")]
        public ActionResult GetFirmaById(int id)
        {
            var firma = _appRepository.GetFirmaById(id);
            if(firma!=null)
                return Ok(firma);
            else
                return NotFound();
        }
        [HttpGet]
        [Route("Findname/{FirmaAdi}")]
        public ActionResult GetFirmaByAdi(String FirmaAdi)
        {
            var firma = _appRepository.GetFirmaByFirmaAdi(FirmaAdi);
            if(firma!=null)
                return Ok(firma);
            else    
                return NotFound();    
        }
    }
}
