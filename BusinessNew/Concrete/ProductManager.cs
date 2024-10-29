using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessNew.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public ProductManager(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        public IResult AddAsync(Product entity)
        {
            _productWriteRepository.AddAsync(entity);
            return new SuccessResult();
        }

        public IResult AddRangeAsync(List<Product> entities)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IResult DeleteRange(List<Product> entities)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Product> GetSingleAsync()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Product> GetWhere()
        {
            throw new NotImplementedException();
        }

        public IResult SaveAsync()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
