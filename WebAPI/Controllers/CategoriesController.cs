using Busines.Abstract;
using Core.Utilities.Helpers.Concrete.ForFile;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.IO;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Category entity)
        {
            var result = await _categoryService.AddAsync(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _categoryService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getwhere")]

        public IActionResult GetWhere(string ifade)
        {
            var result = _categoryService.GetWhere(p => p.name == ifade);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getsingleasync")]

        public async Task<IActionResult> GetSingleAsync()
        {
            var result = await _categoryService.GetSingleAsync(p => p.id == 1);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getbyidasync")]

        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _categoryService.GetByIdAsync(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }


        [HttpGet("searchcategorywithfile")]
        public async Task<IActionResult> SearchCategoryWithFile(string imagePath)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://127.0.0.1:5000");

            string filePath = "C:\\Users\\Metohanhan\\source\\repos\\BitirmeProjesi\\WebAPI\\wwwroot\\images\\"+imagePath;


            using var content = new MultipartFormDataContent();

            // Correcting the FileStream constructor
            using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            content.Add(new StreamContent(fileStream), "file", Path.GetFileName(filePath));

            var response = await httpClient.PostAsync("/predict", content);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return Ok(result);
            }
            else
            {
                return BadRequest("Zort");
            }
        }

        [HttpPost("addrangeasync")]

        public async Task<IActionResult> AddRange(List<Category> entities)
        {
            var result = await _categoryService.AddRangeAsync(entities);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update(Category entity)
        {

            var result = await _categoryService.Update(entity);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("delete")]

        public async Task<IActionResult> Delete(Category entity)
        {
            var result = await _categoryService.Delete(entity);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete("deleteid")]

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.DeleteAsync(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("deleterange")]
        public async Task<IActionResult> DeleteRange(List<Category> entities)
        {
            var result = await _categoryService.DeleteRange(entities);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
