/*using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication2.Models;
using WebApplication2.Models.Data;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static ApplicationContext DataBase = null!;

        public HomeController(ILogger<HomeController> logger, ApplicationContext context)
        {
            _logger = logger;
            DataBase = context;
        }
        
        // Прочее
        public IActionResult Index() => View("Other/Index");

        public IActionResult Privacy() => View("Other/Privacy");




        // Всё что связано с Альбомами
        public IActionResult Albums()
        {
            ViewBag.Albums = DataBase.Albums.ToList();

            return View("Model View/Albums");
        }

        public IActionResult CreateAlbum()
        {
            ViewBag.Model = new CreateAlbum();

            return View("Create Model View/Create Album");
        }

        [HttpPost]
        public async Task<IActionResult> CreateAlbum(CreateAlbum model)
        {
            if (ModelState.IsValid)
            {
                int NextPosition = (DataBase.Albums.Any()) ? DataBase.Albums.Max(a => a.Id) + 1 : 1;
                using (var transaction = DataBase.Database.BeginTransaction())
                {
                    try
                    {
                        DataBase.Albums.Add(new Album(NextPosition, model.Title, DateOnly.Parse(model.ReleaseDate)));
                        await DataBase.SaveChangesAsync();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }
                return RedirectToAction("Albums");
            }
            return View("Create Model View/Create Album");
        }

        public async Task<IActionResult> DeleteAlbum(int Id)
        {
            DataBase.Albums.Remove(DataBase.Albums.Where(a => a.Id == Id).First());
            await DataBase.SaveChangesAsync();
            return RedirectToAction("Albums");
        }

        public IActionResult UpdateAlbum(int id)
        {
            ViewBag.Model = new UpdateAlbum(id);
            ViewBag.Album = DataBase.Albums.FirstOrDefault(a => a.Id == id);

            return View("Update Model View/Update Album");
        }

        [HttpPost]
        public IActionResult UpdateAlbum(UpdateAlbum model)
        {
            if (ModelState.IsValid)
            {
                using (var transaction = DataBase.Database.BeginTransaction())
                {
                    try
                    {
                        Album temp = DataBase.Albums.FirstOrDefault(a => a.Id == model.Id)!;
                        temp.Title = model.Title;
                        temp.ReleaseDate = DateOnly.Parse(model.ReleaseDate);
                        DataBase.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }
                return RedirectToAction("Albums");
            }
            ViewBag.Model = model;
            ViewBag.Album = DataBase.Albums.FirstOrDefault(a => a.Id == model.Id);
            return View("Create Model View/Update Album");
        }




        // Всё что связано с Песнями
        public IActionResult Songs()
        {
            ViewBag.Albums = DataBase.Albums.ToList();
            ViewBag.Songs = DataBase.Songs.ToList();

            return View("Model View/Songs");
        }

        public IActionResult CreateSong()
        {
            ViewBag.Model = new CreateSong();
            ViewBag.Albums = DataBase.Albums.ToList();

            return View("Create Model View/Create Song");
        }

        [HttpPost]
        public async Task<IActionResult> CreateSong(CreateSong model)
        {
            if (ModelState.IsValid)
            {
                int NextPosition = (DataBase.Songs.Any()) ? DataBase.Songs.Max(a => a.Id) + 1 : 1;
                using (var transaction = DataBase.Database.BeginTransaction())
                {
                    //transaction.CreateSavepoint("start");
                    try
                    {
                        DataBase.Songs.Add(new Song(NextPosition, model.Title, model.Duration, 0, model.Explicit != "Нет", model.IdAlbum));
                        await DataBase.SaveChangesAsync();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        //transaction.RollbackToSavepoint("start");
                    }
                }
                return RedirectToAction("Songs");
            }
            return View("Create Model View/Create Song");
        }

        public async Task<IActionResult> DeleteAllRowsInSong(int id)
        {
            DataBase.Songs.RemoveRange(DataBase.Songs.Where(p => p.AlbumId == id).Select(p => p));
            await DataBase.SaveChangesAsync();
            return RedirectToAction("Songs");
        }
        // ??????????????
        public async Task<IActionResult> DeleteOneRowInSong(int Id)
        {
            DataBase.Songs.Remove(DataBase.Songs.Where(s => s.Id == Id).First());
            await DataBase.SaveChangesAsync();
            return RedirectToAction("Songs");
        }

        public IActionResult UpdateSong(int id)
        {
            ViewBag.Model = new UpdateSong(id);
            ViewBag.Song = DataBase.Songs.FirstOrDefault(a => a.Id == id);
            ViewBag.Albums = DataBase.Albums.ToList();

            return View("Update Model View/Update Song");
        }

        [HttpPost]
        public IActionResult UpdateSong(UpdateSong model)
        {
            if (ModelState.IsValid)
            {
                using (var transaction = DataBase.Database.BeginTransaction())
                {
                    try
                    {
                        //transaction.CreateSavepoint("start");
                        Song temp = DataBase.Songs.FirstOrDefault(a => a.Id == model.IdSong)!;
                        //transaction.CreateSavepoint("start");
                        temp.AlbumId = model.IdAlbum;
                        temp.Duration = model.Duration;
                        temp.Auditions = model.Auditions;
                        temp.Explicit = model.Explicit == "Да";
                        temp.Title = model.Title;
                        DataBase.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        //transaction.RollbackToSavepoint("start");
                    }
                }
                return RedirectToAction("Songs");
            }
            ViewBag.Model = model;
            ViewBag.Song = DataBase.Songs.FirstOrDefault(a => a.Id == model.IdSong);
            ViewBag.Albums = DataBase.Albums.ToList();
            return View("Update Model View/Update Song");
        }




        // Всё что связано с Авторами
        public IActionResult Authors()
        {
            ViewBag.Authors = DataBase.Authors.ToList();

            return View("Model View/Authors");
        }

        public IActionResult CreateAuthor()
        {
            ViewBag.Model = new CreateAuthor();

            return View("Create Model View/Create Author");
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthor model)
        {
            if (ModelState.IsValid)
            {
                int NextPosition = (DataBase.Authors.Any()) ? DataBase.Authors.Max(a => a.Id) + 1 : 0;
                using (var transaction = DataBase.Database.BeginTransaction())
                {
                    try
                    {
                        DataBase.Authors.Add(new Author(NextPosition, model.Name, 0, model.Description));
                        await DataBase.SaveChangesAsync();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }
                return RedirectToAction("Authors");
            }
            return View("Create Model View/Create Author");
        }

        public async Task<IActionResult> DeleteAuthor(int Id)
        {
            DataBase.Authors.Remove(DataBase.Authors.Where(a => a.Id == Id).First());
            await DataBase.SaveChangesAsync();
            return RedirectToAction("Authors");
        }

        public IActionResult UpdateAuthor(int id)
        {
            ViewBag.Model = new UpdateAuthor(id);
            ViewBag.Author = DataBase.Authors.FirstOrDefault(a => a.Id == id);

            return View("Update Model View/Update Author");
        }

        [HttpPost]
        public IActionResult UpdateAuthor(UpdateAuthor model)
        {
            if (ModelState.IsValid)
            {
                using (var transaction = DataBase.Database.BeginTransaction())
                {
                    try
                    {
                        Author temp = DataBase.Authors.FirstOrDefault(a => a.Id == model.Id)!;
                        temp.Name = model.Name;
                        temp.Description = model.Description;
                        temp.Listeners = model.Listners;
                        DataBase.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }
                return RedirectToAction("Authors");
            }
            ViewBag.Model = model;
            ViewBag.Author = DataBase.Authors.FirstOrDefault(a => a.Id == model.Id);
            return View("Update Model View/Update Author");
        }




        // Всё что связано с Плейлистом
        public IActionResult PlaylistSong()
        {
            ViewBag.Authors = DataBase.Authors.ToList();
            ViewBag.AuthorsSongs = DataBase.Playlist.ToList();
            ViewBag.Songs = DataBase.Songs.ToList();

            return View("Model View/PlaylistSong");
        }

        public IActionResult PlaylistAuthor()
        {
            ViewBag.Authors = DataBase.Authors.ToList();
            ViewBag.AuthorsSongs = DataBase.Playlist.ToList();
            ViewBag.Songs = DataBase.Songs.ToList();

            return View("Model View/PlaylistAuthor");
        }

        public IActionResult CreatePlaylist()
        {
            ViewBag.Model = new CreatePlaylist();
            ViewBag.Authors = DataBase.Authors.ToList();
            ViewBag.Songs = DataBase.Songs.ToList();

            return View("Create Model View/Create Playlist");
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlaylist(CreatePlaylist model)
        {
            using (var transaction = DataBase.Database.BeginTransaction())
            {
                try
                {
                    DataBase.Playlist.Add(new Playlist(model.IdSong, model.IdAuthor));
                    await DataBase.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
            return RedirectToAction("PlaylistSong");
        }

        public async Task<IActionResult> DeleteAllRowsInPlaylist(int Id, char choice)
        {
            if (choice == 'S')
                DataBase.Playlist.RemoveRange(DataBase.Playlist.Where(p => p.IdSong == Id));
            else
                DataBase.Playlist.RemoveRange(DataBase.Playlist.Where(p => p.IdAuthor == Id));

            await DataBase.SaveChangesAsync();
            return (choice == 'S') ? RedirectToAction("PlaylistSong") : RedirectToAction("PlaylistAuthor");
        }

        public async Task<IActionResult> DeleteOneRowInPlaylist(int IdSong, int IdAuthor, char choice)
        {
            DataBase.Playlist.Remove(DataBase.Playlist.Where(p => p.IdSong == IdSong && p.IdAuthor == IdAuthor).First());

            await DataBase.SaveChangesAsync();
            return (choice == 'S') ? RedirectToAction("PlaylistSong") : RedirectToAction("PlaylistAuthor");
        }

        public IActionResult UpdatePlaylist(int IdSong, int IdAuthor, char choice)
        {
            ViewBag.Model = new UpdatePlaylist(IdSong, IdAuthor);
            ViewBag.Playlist = DataBase.Playlist.ToList();
            if (choice == 'S')
                ViewBag.Songs = DataBase.Songs.ToList();
            else
                ViewBag.Authors = DataBase.Authors.ToList();

            return (choice == 'S') ? View("Update Model View/Update PlaylistSong") : View("Update Model View/Update PlaylistAuthor");
        }

        [HttpPost]
        public IActionResult UpdatePlaylistAuthor(UpdatePlaylist model)
        {
            using (var transaction = DataBase.Database.BeginTransaction())
            {
                try
                {
                    Playlist song = DataBase.Playlist.Where(p => p.IdSong == model.IdSong && p.IdAuthor == model.IdAuthor).FirstOrDefault()!;

                    DataBase.Playlist.Remove(song);
                    DataBase.Playlist.Add(new Playlist(model.IdSong, model.NewId));
                    DataBase.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
            return RedirectToAction("PlaylistAuthor");
        }

        [HttpPost]
        public IActionResult UpdatePlaylistSong(UpdatePlaylist model)
        {
            using (var transaction = DataBase.Database.BeginTransaction())
            {
                try
                {
                    Playlist song = DataBase.Playlist.Where(p => p.IdSong == model.IdSong && p.IdAuthor == model.IdAuthor).FirstOrDefault()!;

                    DataBase.Playlist.Remove(song);
                    DataBase.Playlist.Add(new Playlist(model.NewId, model.IdAuthor));
                    DataBase.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
            return RedirectToAction("PlaylistSong");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
*/