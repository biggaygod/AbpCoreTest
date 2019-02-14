using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreTest.Web.Host.Controllers
{
    public class xmlOptionController : Controller
    {
        public void Get(string file)
        {
            string filename = file;
            file = "upload/" + file;
            if (System.IO.File.Exists(file))
            {
                string filePath = file;//路径
                FileInfo fileInfo = new FileInfo(filePath);
                HttpContext.Response.Clear();
                HttpContext.Response.Headers.Add("Content-Disposition", "attachment;filename=" + filename);
                HttpContext.Response.Headers.Add("Content-Length", fileInfo.Length.ToString());
                HttpContext.Response.Headers.Add("Content-Transfer-Encoding", "binary");
                HttpContext.Response.ContentType = "application/octet-stream";
                Task t = HttpContext.Response.SendFileAsync(file, 0, fileInfo.Length);
                t.Wait();
            }
            else
            {
                HttpContext.Response.Headers.Add("Content-type", "text/html;charset=UTF-8");
                HttpContext.Response.WriteAsync("文件不存在");
            }
        }
    }
}