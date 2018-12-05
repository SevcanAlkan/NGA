using AutoMapper;
using AutoMapper.QueryableExtensions;
using NGA.Core;
using NGA.Core.EntityFramework;
using NGA.Core.Helper;
using NGA.Core.Model;
using NGA.Core.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NGA.Data.SubStructure
{
    public interface ICRUDService<A, U, G>
   where A : AddVM, IAddVM, new()
   where U : UpdateVM, IUpdateVM, new()
   where G : BaseVM, IBaseVM, new()
    {
        Task<G> GetByID(Guid id);
        IList<G> GetAll();

        Task<APIResultVM> Add(A model, Guid? userId = null, bool isCommit = true);
        Task<APIResultVM> Update(Guid id, U model, Guid? userId = null, bool isCommit = true);
        Task<APIResultVM> Delete(Guid id, Guid? userId = null, bool isCommit = true);
        Task<APIResultVM> ReverseDelete(Guid id, Guid? userId, bool isCommit = true);
        G GetById(Guid id);
        Task<APIResultVM> Commit();
    }

    public interface IBaseService<A, U, G, D> : ICRUDService<A, U, G>
        where A : AddVM, IAddVM, new()
        where D : Base, IBase, new()
        where U : UpdateVM, IUpdateVM, new()
        where G : BaseVM, IBaseVM, new()
    {
        IRepository<D> Repository { get; }
        IList<G> GetAll(Expression<Func<D, bool>> expr);
    }

    public abstract class BaseService<A, U, G, D> : IBaseService<A, U, G, D>
        where A : AddVM, IAddVM, new()
        where D : Base, IBase, new()
        where U : UpdateVM, IUpdateVM, new()
        where G : BaseVM, IBaseVM, new()
    {
        protected UnitOfWork uow;
        private readonly IMapper mapper;

        public BaseService(UnitOfWork _uow, IMapper _mapper)
        {
            uow = _uow;
            mapper = _mapper;
        }

        public IRepository<D> Repository
        {
            get
            {
                return uow.Repository<D>();
            }
        }

        public virtual async Task<G> GetByID(Guid id)
        {
            if (Validation.IsNullOrEmpty(id))
                return null;

            return Mapper.Map<G>(await uow.Repository<D>().GetByID(id));
        }
        public virtual IList<G> GetAll()
        {
            return uow.Repository<D>().Query().ProjectTo<G>().ToList();
        }
        public virtual IList<G> GetAll(Expression<Func<D, bool>> expr)
        {
            return uow.Repository<D>().Query().Where(expr).ProjectTo<G>().ToList();
        }

        public virtual async Task<APIResultVM> Add(A model, Guid? userId = null, bool isCommit = true)
        {
            try
            {
                Guid _userId = userId == null ? Guid.Empty : userId.Value;
                if (model.Id == null || model.Id == Guid.Empty)
                    model.Id = Guid.NewGuid();

                D entity = mapper.Map<A, D>(model);

                if (entity is ITable)
                {
                    (entity as ITable).CreateBy = _userId;
                    (entity as ITable).CreateDT = DateTime.Now;
                }                

                uow.Repository<D>().Add(entity);

                if (isCommit)
                    await Commit();

                return API.CreateVMWithRec(entity, true, entity.Id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public virtual async Task<APIResultVM> Update(Guid id, U model, Guid? userId = null, bool isCommit = true)
        {
            try
            {
                Guid _userId = userId == null ? Guid.Empty : userId.Value;
                if (model.Id == null || model.Id == Guid.Empty)
                    model.Id = Guid.NewGuid();

                D entity = await uow.Repository<D>().GetByID(model.Id);
                if (Validation.IsNull(entity))
                    API.CreateVM(false, id, AppStatusCode.WRG01001);

                entity = mapper.Map<U, D>(model, entity);

                if (entity is ITable)
                {
                    (entity as ITable).UpdateBy = _userId;
                    (entity as ITable).UpdateDT = DateTime.Now;
                }

                uow.Repository<D>().Update(entity);

                if (isCommit)
                    await Commit();

                return API.CreateVMWithRec(entity, true, entity.Id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public virtual async Task<APIResultVM> Delete(Guid id, Guid? userId = null, bool isCommit = true)
        {
            try
            {
                Guid _userId = userId == null ? Guid.Empty : userId.Value;

                D entity = await uow.Repository<D>().GetByID(id);
                if (Validation.IsNull(entity))
                    API.CreateVM(false, id, AppStatusCode.WRG01001);

                if (entity is ITable)
                {
                    (entity as ITable).UpdateBy = _userId;
                    (entity as ITable).UpdateDT = DateTime.Now;
                }

                entity.IsDeleted = true;
                uow.Repository<D>().Update(entity);

                if (isCommit)
                    await Commit();

                return API.CreateVMWithRec(entity, true, entity.Id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public virtual async Task<APIResultVM> ReverseDelete(Guid id, Guid? userId, bool isCommit = true)
        {
            try
            {
                Guid _userId = userId == null ? Guid.Empty : userId.Value;

                D entity = await uow.Repository<D>().GetByID(id);
                if (Validation.IsNull(entity))
                    API.CreateVM(false, id, AppStatusCode.WRG01001);

                if (entity is ITable)
                {
                    (entity as ITable).UpdateBy = _userId;
                    (entity as ITable).UpdateDT = DateTime.Now;
                }

                entity.IsDeleted = false;
                uow.Repository<D>().Update(entity);

                if (isCommit)
                    await Commit();

                return API.CreateVMWithRec(entity, true, entity.Id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual G GetById(Guid id)
        {
            D dm = uow.Repository<D>().Query().Where(x => x.Id == id).FirstOrDefault();
            if (Validation.IsNull(dm))
                return null;

            G vm = mapper.Map<D, G>(dm);

            return vm;
        }

        public virtual async Task<APIResultVM> Commit()
        {
            try
            {
                await uow.SaveChanges();

                return API.CreateVM(true);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
