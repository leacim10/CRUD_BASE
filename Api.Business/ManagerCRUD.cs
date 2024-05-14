using Api.Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Business
{
    public interface IManagerCRUD
    {
        Response<bool> insertPeople(EntityPeople people);
        Response<EntityPeople> getPeople(int idPeople);
        Response<List<EntityPeople>> getListPeople();
    }
    public class ManagerCRUD: IManagerCRUD
    {
        private IRepositoryCRUD _repository;
        private readonly SettingsDataAccess _dataBase;
        private readonly string _sectionDataBase = "DataBase";

        public ManagerCRUD(IConfiguration configuration)
        {
            _dataBase = new SettingsDataAccess();
            configuration.GetSection(_sectionDataBase).Bind(_dataBase);

            _repository = new RepositoryCRUD(_dataBase);
        }

        public Response<bool> insertPeople(EntityPeople people)
        {
            try
            {
                var response = _repository.insertPeople(people);
                return Response<bool>.Completed(response);
            }
            catch (Exception ex)
            {
                return Response<bool>.Error(ex.Message);
            }
        }
        public Response<EntityPeople> getPeople(int idPeople)
        {
            try
            {
                var response = _repository.getPeople(idPeople);
                return Response<EntityPeople>.Completed(response);
            }
            catch (Exception ex)
            {
                return Response<EntityPeople>.Error(ex.Message);
            }
        }

        public Response<List<EntityPeople>> getListPeople()
        {
            try
            {
                var response = _repository.getListPeople();
                return Response<List<EntityPeople>>.Completed(response);
            }
            catch (Exception ex)
            {
                return Response<List<EntityPeople>>.Error(ex.Message);
            }
        }
    }
}
