using WebApplication2.Models;
using WebApplication2.Repository.interfaces;
using WebApplication2.Service.Interfaces;

namespace WebApplication2.Service
{
    public class SongService : ISongService
    {
        private readonly ISongRepository songRepository;
        public SongService(ISongRepository songRepository)
        {
            this.songRepository = songRepository;
        }
        public async Task<List<Song>> GetAllSongsWithAlbumAsync()
        {
            return await songRepository.GetAllSongsWithAlbumAsync();
        }
        public async Task AddSongAsync(Song song)
        {
            await songRepository.AddSongAsync(song);
        }
        public async Task<int> DeleteSongAsync(int id)
        {
            return await songRepository.DeleteSongAsync(id);
        }
        public async Task UpdateSongAsync(Song song)
        {
            await songRepository.UpdateSongAsync(song);
        }
    }
}
