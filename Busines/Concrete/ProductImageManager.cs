using Busines.Constan;
using Business;
using Core.Utilities.Helpers.Abstract.ForFile;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Busines.Concrete
{
    public class ProductImageManager : IProductImageService
    {
        IProductImageReadRepository _productImageReadRepository;
        IProductImageWriteRepository _productImageWriteRepository;
        IFileHelper _fileHelper;

        public ProductImageManager(IProductImageReadRepository productImageReadRepository,IProductImageWriteRepository productImageWriteRepository,IFileHelper fileHelper)
        {
            _productImageReadRepository = productImageReadRepository;
            _fileHelper = fileHelper;
            _productImageWriteRepository = productImageWriteRepository;
        }
        public Task<IResult> AddAsync(ProductImage entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> AddImageAsync(ProductImage image, int productId, IFormFile file)
        {
            string guid = _fileHelper.Add(file);
            image.ImagePath = guid;
            image.createTime = DateTime.Now;
            image.ProductId = productId;
           await _productImageWriteRepository.AddAsync(image);
           await _productImageWriteRepository.SaveAsync();
            return new SuccessResult(Messages.AddedSuccesfully);
        }

        public Task<IResult> AddRangeAsync(List<ProductImage> entities)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Delete(ProductImage entity)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> DeleteRange(List<ProductImage> entities)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ProductImage>> GetAll()
        {
            var result = _productImageReadRepository.GetAll().ToList();
            return new SuccessDataResult<List<ProductImage>>(result);
        }

        public async Task<IDataResult<ProductImage>> GetByIdAsync(int id)
        {
            var result = await _productImageReadRepository.GetByIdAsync(id);
            return new SuccessDataResult<ProductImage>(result);
        }

        public async Task<IDataResult<ProductImage>> GetSingleAsync(Expression<Func<ProductImage, bool>> method)
        {
            var result = await _productImageReadRepository.GetSingleAsync(method);
            return new SuccessDataResult<ProductImage>( result );
        }

        public IDataResult<List<ProductImage>> GetWhere(Expression<Func<ProductImage, bool>> method)
        {
            var result = _productImageReadRepository.GetWhere(method).ToList();
            return new SuccessDataResult<List<ProductImage>>(result);
        }

        public Task<IResult> Update(ProductImage entity)
        {
            throw new NotImplementedException();
        }
    }
}
