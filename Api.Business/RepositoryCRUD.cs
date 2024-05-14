﻿using Api.DataAccess;
using Api.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Business
{
    public interface IRepositoryCRUD
    {
        bool insertPeople(EntityPeople people);
        EntityPeople getPeople(int idPeople);
        List<EntityPeople> getListPeople();
    }
    public class RepositoryCRUD: IRepositoryCRUD
    {
                private IDataAccess _dataAccess;
        private SettingsDataAccess _dataBase;
        public RepositoryCRUD(SettingsDataAccess dataBase)
        {
            _dataBase = dataBase;
            _dataAccess = new Api.DataAccess.DataAccess(dataBase);
        }

        public bool insertPeople(EntityPeople people) =>
            _dataAccess.ExecuteStoredProcedure("DB_PRUEBA_CRUD", "dbo.PERSONAS_insert",
                new List<SqlParameter>
                {
                    new SqlParameter("@nombre_VC", people.name),
                    new SqlParameter("@apellidos_VC", people.lastName),
                    new SqlParameter("@edad_IN", people.age)
                });
        
        public EntityPeople getPeople(int idPeople)=>
            _dataAccess.SelectStoredProcedure("DB_PRUEBA_CRUD", "dbo.PERSONAS_getId",
                new List<SqlParameter>
                {
                    new SqlParameter("@idPersona_IN", idPeople)
                })
                .Rows
                .Cast<DataRow>()
                .Select(x => new EntityPeople(
                    idPeople: int.Parse(x["idPersona_IN"].ToString()),
                    name: x["nombre_VC"].ToString(),
                    lastName: x["apellidos_VC"].ToString(),
                    age: int.Parse(x["edad_IN"].ToString())
                    ))
                .FirstOrDefault();
        

        public List<EntityPeople> getListPeople() =>
            _dataAccess.SelectStoredProcedure("DB_PRUEBA_CRUD", "dbo.PERSONAS_getList", null)
                .Rows
                .Cast<DataRow>()
                .Select(x => new EntityPeople(
                    idPeople: int.Parse(x["idPersona_IN"].ToString()),
                    name: x["nombre_VC"].ToString(),
                    lastName: x["apellidos_VC"].ToString(),
                    age: int.Parse(x["edad_IN"].ToString())
                    ))
                .ToList();
    }
}
