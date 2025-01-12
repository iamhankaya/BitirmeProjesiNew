using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IProductImageService:IBaseBusinessService<ProductImage>
    {
        Task<IResult> AddImageAsync(ProductImage image,int productId,IFormFile file);
    }
}
