using CoreTest.App.Customers;
using CoreTest.App.Customers.Dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTest.Controllers
{
    [Route("api/[controller]/[action]")]
    public class FilesController : CoreTestControllerBase
    {
        private readonly ICustomerFileAppService iCustomerFileAppService;
        private readonly IHostingEnvironment ihostingEnvironment;

        public FilesController(
            ICustomerFileAppService iCustomerFileAppService,
            IHostingEnvironment ihostingEnvironment
            )
        {
            this.iCustomerFileAppService = iCustomerFileAppService;
            this.ihostingEnvironment = ihostingEnvironment;
        }

        [HttpPost]
        public async void CreateCustomerFile()
        {
            int customerId = Convert.ToInt32(Request.Form["CustomerId"]);

            var files = Request.Form.Files;

            long size = files.Sum(f => f.Length);

            string webRootPath = ihostingEnvironment.WebRootPath;

            string contentRootPath = ihostingEnvironment.ContentRootPath;

            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    string fileExt = Path.GetExtension(file.FileName); //文件扩展名，不含“.”
                    long fileSize = file.Length; //获得文件大小，以字节为单位
                    string newFileName = Guid.NewGuid().ToString() + fileExt; //随机生成新的文件名
                    var filePath ="/upload/" + newFileName;

                    using (var stream = new FileStream(webRootPath + filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    await iCustomerFileAppService.Create(new CreateCustomerFileDto()
                    {
                        CustomerId = customerId,
                        FileName = newFileName,
                        FilePath = filePath
                    });
                }
            }
        }
    }
}
