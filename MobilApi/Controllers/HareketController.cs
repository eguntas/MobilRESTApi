using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobilApi.Data;
using MobilApi.Dtos;
using MobilApi.Models;

namespace MobilApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HareketController : ControllerBase
    {
        private IAppRepository _appRepository;
        public HareketController(IAppRepository appRepository)
        {
            _appRepository = appRepository;
        }
        [HttpGet]
        [Route("Findall")]
        public ActionResult GetHareket()
        {
            var hareket = _appRepository.GetHareket().Select(a => new HareketDtos
            {
                hareketId = a.HareketId,
                kayitId = a.KayitIds,
                ambarId = a.AmbarIds,
                sicilno = a.SicilNo,
                bolumId = a.BolumIds
            }).ToList();
            return Ok(hareket);
        }
        [Route("Find/{id}")]
        public ActionResult GetHareketById(int id)
        {
            var hareket = _appRepository.GetHareketById(id);
            if(hareket!=null)
                return Ok(hareket);
            else 
                return NotFound();

        }
        [Route("Add")]
        [HttpPost]
        public ActionResult Add([FromBody]HareketTbl hareket)
        {
            if (hareket == null)
            {
                return BadRequest();
            }

            _appRepository.Add(hareket);
            _appRepository.SaveAll();
            return Ok(hareket);
        }
        [Route("Bolumrapor/{BolumId}/{HareketTipi}")]
        [HttpGet]
        public ActionResult GetBolumrapor(int BolumId, String HareketTipi)
        {
            var rapor = _appRepository.GetBolumRapor(BolumId, HareketTipi);
            if(rapor!=null)
                return Ok(rapor);
            else
                return NotFound();
        }
    }
}
