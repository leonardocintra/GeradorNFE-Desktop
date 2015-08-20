using GeradorNFE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorNFE.DAO
{
    public abstract class AbstractCrud
    {

        public static void Add<E>(E entity) where E : class
        {
            using (GeradorEntities db = new GeradorEntities())
            {
                db.Entry(entity).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
            }
        }

        public static void Update<E>(E entity) where E : class
        {
            using (GeradorEntities db = new GeradorEntities())
            {
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void Delete<E>(E entity) where E : class
        {
            using (GeradorEntities db = new GeradorEntities())
            {
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
