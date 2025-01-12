using Busines.Abstract;
using Busines.Constan;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Busines.Concrete
{
    public class CartManager : ICartService
    {
        private readonly ICartReadRepository _cartReadRepository;
        private readonly ICartWriteRepository _cartWriteRepository;

        public CartManager(ICartReadRepository cartReadRepository, ICartWriteRepository cartWriteRepository)
        {
            _cartReadRepository = cartReadRepository;
            _cartWriteRepository = cartWriteRepository;
        }

        public async Task<IResult> AddAsync(Cart entity)
        {
            var result = await _cartWriteRepository.AddAsync(entity);
            await _cartWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult(Messages.AddedSuccesfully);
            return new ErrorResult(Messages.Error);
        }

        public async Task<IResult> AddProductToCart(int cartId, Product product)
        {
            var cartToUpdate = _cartWriteRepository.AddProductToCartAsync(cartId);
            if (cartToUpdate != null)
            {
                cartToUpdate.products.Add(product);
                cartToUpdate.totalAmount += product.price;
                _cartWriteRepository.Update(cartToUpdate);
                await _cartWriteRepository.SaveAsync();
                return new SuccessResult(Messages.ProductSuccessfullyAddedToCart);
            }
            return new ErrorResult(Messages.Error);
        }


        public async Task<IResult> AddRangeAsync(List<Cart> entities)
        {
            var result = await _cartWriteRepository.AddRangeAsync(entities);
            await _cartWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult(Messages.AddedSuccesfully);
            return new ErrorResult(Messages.Error);
        }

        public async Task<IResult> Delete(Cart entity)
        {
            var result = _cartWriteRepository.Delete(entity);
            await _cartWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult(Messages.DeletedSuccessfully);
            return new ErrorResult(Messages.Error);
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            var result = await _cartWriteRepository.Delete(id);
            await _cartWriteRepository.SaveAsync();
            if (result) 
                return new SuccessResult(Messages.DeletedSuccessfully);
            return new ErrorResult(Messages.Error);
        }

        public async Task<IResult> DeleteProductFromCart(int cartId, Product product)
        {
            var cartToUpdate = _cartWriteRepository.DeleteProductFromCartAsync(cartId,product.id);
            if (cartToUpdate != null)
            {
                cartToUpdate.products.Remove(product);    
                _cartWriteRepository.Update(cartToUpdate);
                await _cartWriteRepository.SaveAsync();
                return new SuccessResult(Messages.ProductSuccessfullyRemovedFromCart);
            }
            return new ErrorResult(Messages.Error);
        }

        public async Task<IResult> DeleteRange(List<Cart> entities)
        {
            var result = _cartWriteRepository.DeleteRange(entities);
            await _cartWriteRepository.SaveAsync();
            if (result) 
                return new SuccessResult(Messages.DeletedSuccessfully);
            return new ErrorResult(Messages.Error);
        }

        public IDataResult<List<Cart>> GetAll()
        {
            var result = _cartReadRepository.GetAll();
            return new SuccessDataResult<List<Cart>>(result.ToList());
        }

        public async Task<IDataResult<Cart>> GetByIdAsync(int id)
        {
            var result = await _cartReadRepository.GetByIdAsync(id);
            return new SuccessDataResult<Cart>(result);
        }

        public async Task<IDataResult<Cart>> GetSingleAsync(Expression<Func<Cart, bool>> method)
        {
            var result = await _cartReadRepository.GetSingleAsync(method);
            return new SuccessDataResult<Cart>(result);
        }

        public IDataResult<List<Cart>> GetWhere(Expression<Func<Cart, bool>> method)
        {
            var result = _cartReadRepository.GetWhere(method).ToList();
            if(result.Count > 0)
            {
                List<Cart> newResult = new List<Cart> { _cartReadRepository.GetCartWithProductsAsync(result[0].id).Result };
                return new SuccessDataResult<List<Cart>>(newResult);
            }
            return new SuccessDataResult<List<Cart>>(result,"Hiç sonuç bulunamadı.");
        }

        public Task<IResult> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> Update(Cart entity)
        {
            var result = _cartWriteRepository.Update(entity);
            await _cartWriteRepository.SaveAsync();
            if(result)
                return new SuccessResult(Messages.UpdatedSuccessfully);
            return new ErrorResult(Messages.Error);

        }
    }
}
