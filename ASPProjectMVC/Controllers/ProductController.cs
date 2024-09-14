using ASPProjectMVC.Models;

using eShopSolution.Application.IService;

using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using System.Linq;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ASPProjectMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _httpClient = new HttpClient();
            _productService = productService;
        }

        //// Gọi API GetAllProducts từ Web API và lấy dữ liệu
        //public async Task<IActionResult> GetAllProducts()
        //{
        //    var response = await _httpClient.GetAsync("https://localhost:44336/api/Product/GetAllProducts");

        //    // Kiểm tra nếu API trả về thành công
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var apiData = await response.Content.ReadAsStringAsync();

        //        // Chuyển đổi từ JSON sang danh sách sản phẩm
        //        var products = JsonConvert.DeserializeObject<List<Product>>(apiData);

        //        // Truyền dữ liệu cho View
        //        return View(products);
        //    }

        //    return View(new List<Product>());
        //}
        public async Task<IActionResult> GetAllProduct()
        {
            var products = _productService.GetAllProducts();
            var productViewModels = products.Select(p => new ProductViewModel
            {
                ID = p.ID,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock
            });

            return View(productViewModels);
        }

        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                var jsonProduct = JsonConvert.SerializeObject(product);
                var content = new StringContent(jsonProduct, System.Text.Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("https://localhost:44336/api/Product/CreateProduct", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetAllProducts");
                }
                else
                {

                    ModelState.AddModelError("", "Không thể tạo sản phẩm. Vui lòng thử lại.");
                }
            }


            return View(product);
        }
        // Hiển thị form sửa sản phẩm
        public async Task<IActionResult> EditProduct(int id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:44336/api/Product/GetProductById/{id}");

            if (response.IsSuccessStatusCode)
            {
                var apiData = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<ProductViewModel>(apiData);
                return View(product);
            }

            return NotFound();
        }




        // Xử lý form sửa sản phẩm
        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                var jsonProduct = JsonConvert.SerializeObject(product);
                var content = new StringContent(jsonProduct, System.Text.Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"https://localhost:44336/api/Product/EditProduct/{product.ID}", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetAllProducts");
                }
                else
                {
                    ModelState.AddModelError("", "Không thể cập nhật sản phẩm. Vui lòng thử lại.");
                }
            }

            return View(product);
        }
    }
}
