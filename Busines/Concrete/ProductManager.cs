using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
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

        public async Task<IResult> AddAsync(Product entity)
        {
            var result = await _productWriteRepository.AddAsync(entity);
            await _productWriteRepository.SaveAsync();
            if(result)
                return new SuccessResult("Başarıyla eklendi.");
            else
                return new ErrorResult("Eklenme sırasında hata.");
            
            
        }

        public async Task<IResult> AddRangeAsync(List<Product> entities)
        {
            var result = await _productWriteRepository.AddRangeAsync(entities);
            await _productWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult("Dizi başarıyla eklendi");
            else
                return new ErrorResult("Eklenme sırasında hata.");
        }

        public IResult Delete(Product entity)
        {
            var result = _productWriteRepository.Delete(entity);
            _productWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult("Başarıyla silindi.");
            return new ErrorResult("Silme sırasında hata.");
        }

        public async Task<IResult> Delete(int id)
        {
            var result = await _productWriteRepository.Delete(id);
            await _productWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult("Başarıyla silindi.");
            return new ErrorResult("Silme sırasında hata.");
        }

        public IResult DeleteRange(List<Product> entities)
        {
            var result = _productWriteRepository.DeleteRange(entities);
            _productWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult("Dizi başarıyla silindi.");
            return new ErrorResult("Silme sırasında hata.");
        }

        public IDataResult<List<Product>> GetAll()
        {
            List<Product> result =_productReadRepository.GetAll().ToList();
            return new SuccessDataResult<List<Product>>(result);
        }

        public async Task<IDataResult<Product>> GetByIdAsync(int id)
        {
            var result = await _productReadRepository.GetByIdAsync(id);
            return new SuccessDataResult<Product>(result);
        }

        public async Task<IDataResult<Product>> GetSingleAsync(Expression<Func<Product, bool>> method)
        {
            var result = await _productReadRepository.GetSingleAsync(method);
            return new SuccessDataResult<Product>(result);
        }

        public IDataResult<List<Product>> GetWhere(Expression<Func<Product, bool>> method)
        {
            var result = _productReadRepository.GetWhere(method);
            return new SuccessDataResult<List<Product>>(result.ToList());
        }
        public async Task<IResult> Update(Product entity)
        {
            var result = _productWriteRepository.Update(entity);
            await _productWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult("Başarıyla güncellendi");
            return new ErrorResult("Güncelleme sırasında hata");
        }

    }
}
