using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ProjetoCondominioSmart.Others
{
    public class Repository<TRealmObject> where TRealmObject : RealmObject
    {
        private readonly Realms.Realm _currentRealm;

        public Repository()
        {
            _currentRealm = Realm.GetInstance();
        }

        public void Insert(TRealmObject item)
        {
            using (var transaction = _currentRealm.BeginWrite())
            {
                try
                {
                    _currentRealm.Add(item);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }

        public TRealmObject Update(TRealmObject item)
        {
            return _currentRealm.Add(item, true);
        }

        public TRealmObject GetById(long id)
        {
            return _currentRealm.Find<TRealmObject>(id);
        }

        public TRealmObject GetById(string id)
        {
            return _currentRealm.Find<TRealmObject>(id);
        }

        public List<TRealmObject> GetAll()
        {
            return _currentRealm.All<TRealmObject>().ToList();
        }

        public List<TRealmObject> GetAll(Expression<Func<TRealmObject, bool>> predicate)
        {
            return _currentRealm.All<TRealmObject>().Where(predicate).ToList();
        }

        public void Remove(long id)
        {
            var realmItem = GetById(id);
            using (var transaction = _currentRealm.BeginWrite())
            {
                try
                {
                    _currentRealm.Remove(realmItem);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }

        public void Remove(string id)
        {
            var realmItem = GetById(id);
            using (var transaction = _currentRealm.BeginWrite())
            {
                try
                {
                    _currentRealm.Remove(realmItem);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }
    }
}
