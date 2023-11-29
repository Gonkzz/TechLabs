﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHLABS_DATA_ACESS.DAO;
using TECHLABS_DATA_ACESS.Mapper;
using TECHLABS_DTO;

namespace TECHLABS_DATA_ACESS.CRUD
{
    public class TestCrudFactory : CrudFactory
    {
        private TestMapper mapper;

        public TestCrudFactory() : base()
        {
            mapper = new TestMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entityDTO)
        {
            var test = (Test)entityDTO;
            var sqlOperation = mapper.GetCreateStatement(test);

            dao.ExecuteStoredProcedure(sqlOperation);
        }

        public override void Update(BaseEntity entityDTO)
        {
            var test = (Test)entityDTO;
            var sqlOperation = mapper.GetUpdateStatement(test);

            dao.ExecuteStoredProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entityDTO)
        {
            var test = (Test)entityDTO;
            var sqlOperation = mapper.DeleteStatement(test);

            dao.ExecuteStoredProcedure(sqlOperation);
        }

        public List<T> RetrieveByAdminUser<T>(string user)
        {
            var list = new List<T>();

            var listResult = dao.ExecuteStoredProcedureWithQuery(mapper.GetRetrieveByAdminUser(user));

            var dicc = new Dictionary<string, object>();

            if (listResult.Count > 0)
            {
                var objsPedido = mapper.BuildObjects(listResult);

                foreach (var c in objsPedido)
                {
                    list.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return list;
        }




        ///
        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveById<T>(int id)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveByStringId<T>(string id)
        {
            throw new NotImplementedException();
        }


    }
}
