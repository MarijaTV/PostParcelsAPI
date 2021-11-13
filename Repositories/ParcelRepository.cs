using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PostParcelsAPI.Data;
using PostParcelsAPI.Models;

namespace PostParcelsAPI.Repositories
{
    public class ParcelRepository
    {
        private readonly DataContext _dataContext;

        public ParcelRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<Parcel>> GetAllAsync()
        {
            return await _dataContext.Parcels.OrderBy(p => p.Weight).ToListAsync();
        }
        public async Task<Parcel> CreateAsync(Parcel parcel)
        {
            _dataContext.Add(parcel);
            await _dataContext.SaveChangesAsync();
            return parcel;
        }
        public async Task<Parcel> GetById(int id)
        {
            return await _dataContext.Parcels.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task DeleteAsync(Parcel parcel)
        {
            _dataContext.Remove(parcel);
            await _dataContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Parcel parcel)
        {
            _dataContext.Update(parcel);
            await _dataContext.SaveChangesAsync();
        }
        public async Task<List<Parcel>> GetByPostIdAsync(int postId)
        {
            return await _dataContext.Parcels.Where(p => p.PostId == postId).ToListAsync();
        }
        public async Task<bool> DoesExistAsync(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                return false;
            }
            return true;
        }
        public async Task<int> PostCapacity(int postId)
        {
            var posts = await _dataContext.Parcels.Where(p => p.PostId == postId).ToListAsync();
            var count = 0;
            for (int i = 0; i < posts.Count; i++)
            {
                count = i;
            }
            return count;
        }
    }
}
