using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {


        [HttpGet]
        public string Get()
        {
            return "Urunler buraya gelicek";
        }
        [HttpGet("{id}")]
        public string GetId(int id)
        {
            return "id li ürün bulma";
        }
        [HttpPost]
        public string Post()
        {
            return "Urun Ekleme";
        }
        [HttpPut]
        public string Put()
        {
            return "Urun guncelleme";
        }
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return "Urun silme";
        }

    }
}

