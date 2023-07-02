﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using webapi.Context;
using webapi.DbLink;
using webapi.Models.Repository.Token;
using webapi.Models.Repository.Tournament.Types;

namespace webapi.Controllers
{
    [ApiController]
    [Route("Api/Tournament/")]
    public class TournoisController : Controller
    {
        private readonly UserRoleContext _roleContext;
        private readonly IConfiguration _configuration;

        public TournoisController(UserRoleContext roleContext, IConfiguration configuration)
        {
            _roleContext = roleContext;
            _configuration = configuration;
        }

        [Route("Type/AllTypes")]
        public ActionResult GetAllTypes(TokenCheck tokenCheck)
        {
            return Ok(JsonConvert.SerializeObject(new Tournament(_roleContext, _configuration).GetAllTypes(tokenCheck)));
        }
        [Route("Type/Add")]
        public ActionResult TournamentTypeAdd(TournamentTypeAddRead type)
        {
            return Ok(new Tournament(_roleContext, _configuration).TournamentTypeAdd(type));
        }
        [Route("Type/Delete")]
        public ActionResult TournamentTypeDelete()
        {
            return Ok();
        }
        [Route("Type/Modify")]
        public ActionResult TournamentTypeModify(TournamentTypeModify modify)
        {
            return Ok(new Tournament(_roleContext, _configuration).TournamenetTypeModify(modify));
        }
        [Route("Type/Read")]
        public ActionResult TournamentTypeRead()
        {
            return Ok();
        }
    }
}
