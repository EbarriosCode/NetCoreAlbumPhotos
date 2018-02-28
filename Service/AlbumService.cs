using Microsoft.EntityFrameworkCore;
using Models;
using Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public interface IAlbumService
    {
        bool Create(Album model);
        IEnumerable<Album> GetAll();
        Album Get(int AlbumId);
    }

    public class AlbumService : IAlbumService
    {
        private readonly AlbumDbContext _context;
        public AlbumService(AlbumDbContext context)
        {
            _context = context;
        }

        public bool Create(Album model)
        {
            try
            {
                model.CreatedAt = DateTime.Now;
                _context.Entry(model).State = EntityState.Added;
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                return false;
            }

            return true;
        }        

        public IEnumerable<Album> GetAll()
        {
            var listado = new List<Album>();
            try
            {
                listado = _context.Album.OrderByDescending(x => x.CreatedAt).ToList();                
            }
            catch(Exception e)
            {

            }
            return listado;
        }

        public Album Get(int AlbumId)
        {
            var result = new Album();
            try
            {
                result = _context.Album.Include(x => x.Photos).Single(x => x.Id == AlbumId);
            }
            catch (Exception)
            {

            }
            return result;
        }
    }
}
