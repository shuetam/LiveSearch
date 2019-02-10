using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Live.Repositories;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Live.Mapper;

namespace Live.Controllers
{
    [Route("api/[controller]")]
    public class SongController : Controller
    {
    
        private readonly  ISongsRepository _songRepository;
        
        public SongController (ISongsRepository songRepository)
        {
            this._songRepository = songRepository;
        }

        [HttpPost("update")]
        public async Task Post()
        {
           await  _songRepository.UpdateAsync();
        }

        [HttpGet("allarchive")]
        public async Task <IActionResult> GetAllSongs()
        {
            var songs = await _songRepository.GetAllFromArchive();
            return Json(songs);
        }

        [HttpGet("archive/{i}/{j}")]
        public async Task <IActionResult> GetArchiveSongs(int i, int j)
        {
            var songs = await _songRepository.GetFromArchiveByIndex(i, j);
            return Json(songs);
        }

        [HttpDelete("delete/{id}")]
        public async Task <IActionResult> DeleteSong(string id)
        {
             await _songRepository.DeleteByYouTubeId(id);
             return NoContent();
        }

        [HttpPut("change/{Id}/{toId}")]
        public async Task <IActionResult> ChangeYouTubeId(string Id, string toId)
        {
             await _songRepository.ChangeYouTubeId(Id, toId);
             return NoContent();
        }

        [HttpPost("changename/{Id}")]
        public async Task <IActionResult> ChangeName(string Id, [FromBody] NameSetter Name)
        {
             await _songRepository.ChangeName(Id, Name.name);
             return NoContent();
        }

        [HttpGet("allradiosongs/{stations}")]
        public async Task <IActionResult> GetAllActualSongs(string stations)
        {
            var radio_list= stations.Split('_').ToList();
            var songs = await _songRepository.GetActualByRadioAsync(radio_list);
            return Json(songs);
        }

        [HttpGet("random")]
        public async Task <IActionResult> GetAllRandomSongs()
        {
        
            var songs = await _songRepository.GetActualRandomSongs();
            return Json(songs);
        }
    }
}