using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using WebAPICRUD.Models;

namespace WebAPICRUD.Controllers
{
    /*           [URI]                                 [Method]                   [처리]
        /api/products                              GET                  모든 제품의 목록을 조회                                 >>  GetAllProduct()
       /api/products/id                         GET                   id를 조회해서 한 제품을 조회                        >>  GetProduct(int id)
       /api/products?category=           GET                   category를 기준으로 한 제품을 조회             >>  GetProductsByCategory(string category)
       /api/products                              POST                새로운 제품을 생산 (new, insert)                     >>  PostProduct(Product item)
       /api/products/id                         PUT                   제품을 갱신 (update ... where id ...)                 >>  PutProduct(int id, Product product)
       /api/products/id                         DELETE             제품을 삭제                                                      >>  DeleteProduct(int id)
   */
    public class ProductsController : ApiController
    {
        static readonly IProductRepository repository = new ProductRepository();

        public IEnumerable<Product> GetAllProduct() // 함수의 이름이 중요. Get으로 시작
        {
            return repository.GetAll();
        }

        public Product GetProduct(int id)
        {
            Product item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }
        public IEnumerable<Product> GetProductsByCategory(string category) { // 인터페이스 함수 추가 하셔도 됩니다..
            return repository.GetAll().Where(x => string.Equals(x.Category, category, StringComparison.OrdinalIgnoreCase));
        }
        public Product PostProduct(Product item)
        {
            return repository.Add(item);
        }

        public void PutProduct(int id, Product product)
        {
            product.Id = id;
            if (!repository.Update(product))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
        public void DeleteProduct(int id)
        {
            Product item = repository.Get(id);
            if(item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            repository.Remove(id);
        }
    }
}
