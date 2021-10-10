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
    public class KayitController : ControllerBase
    {

        private IAppRepository _appRepository;
        public KayitController(IAppRepository appRepository)
        {
            _appRepository = appRepository;
        }
        [HttpGet]
        [Route("Findall")]
        public ActionResult GetKayit()
        {
            var kayit = _appRepository.GetKayitTbls().Select(e => new KayitDtos
            {
                KayitId = e.KayitId,
                TupId = e.TupIds,
                TupSeriNo = e.TupSeriNos,
                TupDurum = e.TupDurums,
                UserId = e.UserIds,
                GirisTarih = e.GirisTarih,
                CikisTarih = e.CikisTarih,
                IrsaliyeGirisNo = e.IrsaliyeGirisNo,
                IrsaliyeCikisNo = e.IrsaliyeCikisNo,
                FirmaId = e.FirmaIds,
                CikisYapan = e.CikisYapanKisi


            }).ToList();
            return Ok(kayit);
        }
        [Route("Find/{id}")]
        public ActionResult GetKayitById(int id)
        {
            var kayit = _appRepository.GetKayitById(id);
            return Ok(kayit);

        }

        [HttpPost]
        [Route("Add")]
        public ActionResult Add([FromBody]KayitTbl kayit)
        {
            if (kayit == null)
            {
                return BadRequest();
            }

            _appRepository.Add(kayit);
            _appRepository.SaveAll();
            return Ok(kayit);
        }


        [HttpGet]
        [Route("TupKayit")]
        public ActionResult GetTupKayit()
        {
            var tup = _appRepository.GetTupKayit().ToList();
            return Ok(tup);
        }

        [Route("TupKayitById/{id}")]
        public ActionResult GetTupKayitById(int id)
        {
            var tup = _appRepository.GetTupKayitById(id);
            return Ok(tup);
        }

        /*public ActionResult AddTupKayit([FromBody] TupTanimTbl TupKayit)
        {
            if(TupKayit == null)
            {
                return BadRequest();
            }
            _appRepository.Add(TupKayit);
            _appRepository.SaveAll();
            return Ok(TupKayit);

        }*/
        [HttpGet]
        [Route("KayitHareket")]
        public ActionResult GetKayitHareket()
        {
            var kayit = _appRepository.GetKayitHareket().ToList();
            return Ok(kayit);
        }
        [HttpGet]
        [Route("Kayitlar")]
        public ActionResult GetKayits()
        {
            var kayit = _appRepository.GetKayitTbls();
            return Ok(kayit);
        }
        [HttpGet]
        [Route("KayitTarih/{GirisTarih}/{CikisTarih}")]
        public ActionResult GetKayitTarih(DateTime GirisTarih, DateTime CikisTarih)
        {
            var kayit = _appRepository.GetKayitTarih(GirisTarih, CikisTarih);
            return Ok(kayit);
        }
        [HttpGet]
        [Route("KayitStok/{TupDurums}/{GirisTarihi}")]
        public ActionResult GetStokDurum(int TupDurums, DateTime GirisTarihi)
        {
            var kayit = _appRepository.GetKayitTupStok(GirisTarihi, TupDurums);
            return Ok(kayit);
        }
        [HttpGet]
        [Route("findseri/{TupSeriNo}")]
        public ActionResult GetSeriBul(int TupSeriNo)
        {
            var kayit = _appRepository.GetKayitBySeri(TupSeriNo);
            return Ok(kayit);
        }
       
        
        
        
    }
}