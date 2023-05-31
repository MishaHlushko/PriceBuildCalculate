using Microsoft.EntityFrameworkCore;
using PriceBuildCalculate.DAL.Interfaces;
using PriceBuildCalculate.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceBuildCalculate.DAL.Repositories
{
    public class MaterialsRepository : IMaterialsRepository
    {
        private readonly ApplicationDbContext _db;

        public MaterialsRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Material> Get(int id)
        {
            return await _db.Material.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Material>> Select()
        {
            return await _db.Material.ToListAsync();
        }

        public async Task<bool> Create(Material entity)
        {
            await _db.Material.AddAsync(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(Material entity)
        {
            _db.Material.Remove(entity);
            _db.SaveChangesAsync();

            return true;
        }

        public async Task<Material> GetByName(string name)
        {
            return await _db.Material.FirstOrDefaultAsync(x => x.Name == name);
        }
        public async Task<Material> Update(Material entity)
        {
            _db.Material.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
