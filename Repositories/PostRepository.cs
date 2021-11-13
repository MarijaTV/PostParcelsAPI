using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PostParcelsAPI.Data;
using PostParcelsAPI.Models;

namespace PostParcelsAPI.Repositories
{
    public class PostRepository
    {
        private readonly DataContext _dataContext;

        public PostRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Post>> GetAllAsync()
        {
            return await _dataContext.Posts.Include(x => x.Parcels).OrderBy(p => p.Code).ToListAsync();
        }
        public async Task<Post> CreateAsync(Post post)
        {
            _dataContext.Add(post);
            await _dataContext.SaveChangesAsync();
            return post;
        }
        public async Task<Post> GetById(int id)
        {
            return await _dataContext.Posts.FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task DeleteAsync(Post post)
        {
            _dataContext.Remove(post);
            await _dataContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Post post)
        {
            _dataContext.Update(post);
            await _dataContext.SaveChangesAsync();
        }
    }
}
