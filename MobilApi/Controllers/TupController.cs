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
            return Ok(tup);
        }

        [Route("find/{id}")]
        public ActionResult GetTupTanimById(int id)
        {
            var tup = _appRepository.GetTupTanimById(id);
            return Ok(tup);

        }
        [Route("tupkayit")]
        public ActionResult GetTupKayit()
        {
            var tup = _appRepository.GetTupKayit().ToList();
            return Ok(tup);
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
            return Ok(tup);
        }
        [HttpGet]
        [Route("findname/{TupAdi}")]
        public ActionResult GetTupByAd(String TupAdi)
        {
            var tup = _appRepository.GetTupTanimByAd(TupAdi);
            return Ok(tup);
        }
    }
}