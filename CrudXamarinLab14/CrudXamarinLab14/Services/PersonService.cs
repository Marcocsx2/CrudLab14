using CrudXamarinLab14.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CrudXamarinLab14.Services
{
    public class PersonService
    {
        private DatabaseContext getContext()
        {
            return new DatabaseContext();
        }

        public async Task<List<PersonModel>> GetAllPerson()
        {
            var _dbContext = getContext();
            var res = await _dbContext.People.ToListAsync();
            return res;
        }

        public async Task<int> UpdatePerson(PersonModel obj)
        {
            var _dbContext = getContext();
            _dbContext.People.Update(obj);
            int c = await _dbContext.SaveChangesAsync();
            return c;
        }
        public int InsertPerson(PersonModel obj)
        {
            var _dbContext = getContext();
            _dbContext.People.Add(obj);
            int c = _dbContext.SaveChanges();
            return c;
        }

        public int DeletePerson(PersonModel obj)
        {
            var _dbContext = getContext();
            _dbContext.People.Remove(obj);
            int c = _dbContext.SaveChanges();
            return c;
        }
    }
}
