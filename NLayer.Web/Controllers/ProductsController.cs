using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;
using NLayer.Web.Filters;
using NLayer.Web.Services;

namespace NLayer.Web.Controllers
{
    public class ProductsController : Controller
    {
        //private readonly IProductService _productService;
        //private readonly ICategoryService _categoryService;
        //private readonly IMapper _mapper;

        //public ProductsController(IProductService productService, ICategoryService categoryService, IMapper mapper)
        //{
        //    _productService = productService;
        //    _categoryService = categoryService;
        //    _mapper = mapper;
        //}

        private readonly ProductApıService _productApıService;
        private readonly CategoryApıService _categoryApıService;

        public ProductsController(ProductApıService productApıService, CategoryApıService categoryApıService)
        {
            _productApıService = productApıService;
            _categoryApıService = categoryApıService;
        }

        public async Task<IActionResult> Index()
        {
            //var customRes = await _productService.GetProductsWithCategory();

            //return View(customRes.Data);


            return View(await _productApıService.GetProductsWithCategoryAsync());
        }




        [HttpGet]

        public async Task<IActionResult> Create()
        {
            //var categories = await _categoryService.GetAllAsync();
            var categoriesDto = await _categoryApıService.GetAllAsync();

            //var categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());
            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name");
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDto productDto)
        {



            if (ModelState.IsValid)
            {

                await _productApıService.CreateAsync(productDto);


                //await _productService.AddAsync(_mapper.Map<Product>(productDto));
                return RedirectToAction(nameof(Index));
            }

            //var categories = await _categoryService.GetAllAsync();
            var categoriesDto = await _categoryApıService.GetAllAsync();

            //var categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());
            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name");
            return View();

        }

        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        public async Task<IActionResult> Update(int id)
        {


            //var product = await _productService.GetByIdAsync(id);
            var product = await _productApıService.GetByIdAsync(id);


            //var categories = await _categoryService.GetAllAsync();
            var categoriesDto = await _categoryApıService.GetAllAsync();

            //var categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());
            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name", product.CategoryId);




            //return View(_mapper.Map<ProductDto>(product));
            return View(product);

        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductDto productDto)
        {

            if (ModelState.IsValid)
            {
                await _productApıService.UpdateAsync(productDto);

                /*await _productService.UpdateAsync(_mapper.Map<Product>(productDto));*/
                return RedirectToAction(nameof(Index));



            }



            //var categoriesDto = await _categoryService.GetAllAsync();
            var categoriesDto = await _categoryApıService.GetAllAsync();

            //var categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());
            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name", productDto.CategoryId);
            return View(productDto); 


        }

        public async Task<IActionResult> Remove (int id )
        {

            //var product= await _productService.GetByIdAsync(id);
            //await _productService.RemoveAsync(product);
            await _productApıService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));

        }




    }
}
