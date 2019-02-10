using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Live.Core;
using Microsoft.AspNetCore.Mvc;

namespace Live.Repositories
{
    public interface ISongsRepository
    {   
        
    Task<List<Song>> GetAllActuall();
    Task<List<FrontSong>> GetActualByRadioAsync(List<string> stations);
    Task<ArchiveSong> GetByYouTubeFromArchive(string id);
    Task<ArchiveSong> GetByNameFromArchive(string name);
    Task<DateTime> GetLastDate();
    Task UpdateAsync();
    Task AddToArchiveAsync(Song song);
    Task UpdateArchiveAsync(Song actualSong);
    Task<List<SongDto>> GetAllFromArchive();
    Task<List<SongDto>> GetFromArchiveByIndex(int i, int j);
    Task DeleteByYouTubeId(string id);
    Task ChangeYouTubeId(string Id, string toId);
    Task ChangeName(string Id, string name);
    Task<List<FrontSong>> GetActualRandomSongs();

    }

}