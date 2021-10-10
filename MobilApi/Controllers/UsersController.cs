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
    [Route("api/User")]
    [ApiController]
    public class UsersController : Controller
    {

        private IAppRepository _appRepository;
        public UsersController(IAppRepository appRepository)
        {
            _appRepository = appRepository;
        }

        [HttpGet]
        [Route("FindAll")]
        public ActionResult GetKullanici()
        {

            var user = _appRepository.GetKullaniciTbls().Select(e => new UserDtos
            {
                Username = e.Username,
                Password = e.Password,
                BolumId = e.BolumIds,
                UserId = e.UserId

            }).ToList();
            return Ok(user);
        }
        [Route("find/{id}/{password}")]
        public ActionResult GetKullaniciById(string id, string password)
        {
            var user = _appRepository.GetKullaniciById(id, password);
            return Ok(user);
        }
        [HttpPost]
        [Route("Add")]
        public ActionResult Add([FromBody]KullaniciTbl User)
        {
            _appRepository.Add(User);
            _appRepository.SaveAll();
            return Ok(User);
        }

    }
}