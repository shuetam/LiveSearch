using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Live.Repositories;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Live.Mapper;
using System.Diagnostics;
using System.Web.Http.Cors;
using Newtonsoft.Json.Linq;
using Live.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Live.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    [Route("api/[controller]")]
   /* [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  [Authorize(Roles = "ADMIN")] */
    public class SongController : LiveController
    {
        private readonly  ISongsRepository _songRepository;

        //private readonly ILogger _logger;
        
        public SongController (ISongsRepository songRepository)
        {
            this._songRepository = songRepository;
           // _logger = logger;

       
        }

/*         [HttpPost("editsong")]
        public async Task <IActionResult> EditSong([FromBody]EditSong editSong)
        {
            Debug.Print("EDITSONG");
            if(editSong.newYouTubeId != editSong.youTubeId)
            {
                await _songRepository.ChangeYouTubeId(editSong.youTubeId, editSong.newYouTubeId);
            }
            if(editSong.newName != editSong.name)
            {
                await _songRepository.ChangeName(editSong.youTubeId, editSong.newName);
            }
           return Json(editSong);
        } */

        [HttpPost("update")]
        public async Task Post()
        {
           await  _songRepository.UpdateAsync();
        }

/*         [HttpGet("allarchive")]
        public async Task <IActionResult> GetAllSongs()
        {
            var songs = await _songRepository.GetAllFromArchive();
            return Json(songs);
        } */

/*         [HttpGet("archive/{i}/{j}")]
        public async Task <IActionResult> GetArchiveSongs(int i, int j)
        {
            var songs = await _songRepository.GetFromArchiveByIndex(i, j);
            return Json(songs);
        } */

/*         [HttpDelete("delete/{id}")]
        public async Task <IActionResult> DeleteSong(string id)
        {
             await _songRepository.DeleteByYouTubeId(id);
             return NoContent();
        } */
/* 
        [HttpPut("change/{Id}/{toId}")]
        public async Task <IActionResult> ChangeYouTubeId(string Id, string toId)
        {
             await _songRepository.ChangeYouTubeId(Id, toId);
             return NoContent();
        } */

/*         [HttpPost("changename/{Id}")]
        public async Task <IActionResult> ChangeName(string Id, [FromBody] NameSetter Name)
        {
             await _songRepository.ChangeName(Id, Name.name);
             return NoContent();
        } */

        [HttpGet("allradiosongs/{stations}")]
        public async Task <IActionResult> GetAllActualSongs(string stations)
        {
            var radio_list= stations.Split('_').ToList();
            var songs = await _songRepository.GetActualByRadioAsync(radio_list);
            return Json(songs);
        }

        [HttpGet("radiorandom")]
        public async Task <IActionResult> GetAllRandomSongs()
        {
            //Log.Information("Hello, from random songs!!");
        /* _logger.LogInformation("RANDOMMM INFORMATION");
         _logger.LogCritical("RANDOMMM CRITICAL");
         _logger.LogError("RANDOMMM ERROR");
          _logger.LogWarning("RANDOMMM WARNING"); */
            var songs = await _songRepository.GetActualRandomSongs();
            return Json(songs);
        }
    }
}
