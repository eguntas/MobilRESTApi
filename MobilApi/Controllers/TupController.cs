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
    public class TupController : ControllerBase
    {
        private IAppRepository _appRepository;
        public TupController(IAppRepository appRepository)
        {
            _appRepository = appRepository;
        }
        [HttpGet]
        [Route("findall")]
        public ActionResult GetTupTanim()
        {
            var tup = _appRepository.GetTupTanim().ToList();
            if(tup!=null)
                return Ok(tup);
            else
                return NotFound();
        }

        [Route("find/{id}")]
        public ActionResult GetTupTanimById(int id)
        {
            var tup = _appRepository.GetTupTanimById(id);
            if(tup!=null)
                return Ok(tup);
             else
                return NotFound();

        }
        [Route("tupkayit")]
        public ActionResult GetTupKayit()
        {
            var tup = _appRepository.GetTupKayit().ToList();
            if(tup!= null)
                return Ok(tup);
            else   
                return NotFound();
        }
        [HttpPost]
        [Route("Add")]
        public ActionResult Add([FromBody]TupTanimTbl tup)
        {
            if (tup == null)
            {
                return BadRequest();
            }
            _appRepository.Add(tup);
            _appRepository.SaveAll();
            return Ok(tup);
        }
        [HttpGet]
        [Route("findseri/{TupSeriNo}")]
        public ActionResult GetTupByTupAdi(int TupSeriNo)
        {
            var tup = _appRepository.GetTupBySeriNo(TupSeriNo);
            if(tup!=null)
                return Ok(tup);
            else
                return NotFound();
        }
        [HttpGet]
        [Route("findname/{TupAdi}")]
        public ActionResult GetTupByAd(String TupAdi)
        {
            var tup = _appRepository.GetTupTanimByAd(TupAdi);
            if(tup!=null)
                return Ok(tup);
            else
                return NotFound();
        }
    }
}
