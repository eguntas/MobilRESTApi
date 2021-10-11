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
            if(kayit!=null)
                return Ok(kayit);
            else
                return NotFound();
        }
        [Route("Find/{id}")]
        public ActionResult GetKayitById(int id)
        {
            var kayit = _appRepository.GetKayitById(id);
            if(kayit!=null)
                return Ok(kayit);
            else
                return NotFound();

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
            if(tup!= null)
                return Ok(tup);
            else
                return NotFound();
        }

        [Route("TupKayitById/{id}")]
        public ActionResult GetTupKayitById(int id)
        {
            var tup = _appRepository.GetTupKayitById(id);
            if(tup!=null)
                return Ok(tup);
            else
                return NotFound();
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
            if(kayit!=null)
                return Ok(kayit);
            else
                return NotFound();
        }
        [HttpGet]
        [Route("Kayitlar")]
        public ActionResult GetKayits()
        {
            var kayit = _appRepository.GetKayitTbls();
            if(kayit!=null)
                return Ok(kayit);
            else    
                return NotFound();
        }
        [HttpGet]
        [Route("KayitTarih/{GirisTarih}/{CikisTarih}")]
        public ActionResult GetKayitTarih(DateTime GirisTarih, DateTime CikisTarih)
        {
            var kayit = _appRepository.GetKayitTarih(GirisTarih, CikisTarih);
            if(kayit!=null)
                return Ok(kayit);
            else
                return NotFound();
        }
        [HttpGet]
        [Route("KayitStok/{TupDurums}/{GirisTarihi}")]
        public ActionResult GetStokDurum(int TupDurums, DateTime GirisTarihi)
        {
            var kayit = _appRepository.GetKayitTupStok(GirisTarihi, TupDurums);
            if(kayit!=null)
                return Ok(kayit);
            else
                return NotFound();
        }
        [HttpGet]
        [Route("findseri/{TupSeriNo}")]
        public ActionResult GetSeriBul(int TupSeriNo)
        {
            var kayit = _appRepository.GetKayitBySeri(TupSeriNo);
            if(kayit!=null)
                return Ok(kayit);
            else
                return NotFound();
        }
       
        
        
        
    }
}
