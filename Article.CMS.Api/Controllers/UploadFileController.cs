using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Article.CMS.Api.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Article.CMS.Api.Repository;
using Microsoft.Net.Http.Headers;
using Article.CMS.Api.Entity;
using System.Linq;

namespace Article.CMS.Api.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UploadFileController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IRepository<ImagesUrl> _fileInfoRepository;

        public UploadFileController(IConfiguration configuration, IRepository<ImagesUrl> fileInfoRepository)
        {
            _configuration = configuration;
            _fileInfoRepository = fileInfoRepository;
        }

        /// <summary>
        /// 多文件上传接口
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, Route("uploadfiles")]
        public string UploadFiles(IFormCollection model)
        {
            // 获得当前应用所在的完整路径（绝对地址）
            var filePath = Directory.GetCurrentDirectory();

            // 通过配置文件获得存放文件的相对路径
            string path = _configuration["UploadFilesPath"];

            // 最终存放文件的完整路径
            var preFullPath = Path.Combine(filePath, path);
            // 如果路径不存在，则创建
            if (!Directory.Exists(preFullPath))
            {
                Directory.CreateDirectory(preFullPath);
            }

            var resultPath = new List<string>();
            // var uploadfiles = new List<ImagesUrl>();
            foreach (IFormFile file in model.Files)
            {
                if (file.Length > 0)
                {
                    var fileName = file.FileName;
                    var extName = fileName.Substring(fileName.LastIndexOf("."));//extName包含了“.”
                    var rndName = Guid.NewGuid().ToString("N") + extName;
                    var tempPath = Path.Combine(path, rndName).Replace("\\", "/");
                    using (var stream = new FileStream(Path.Combine(filePath, tempPath), FileMode.CreateNew))//Path.Combine(_env.WebRootPath, fileName)
                    {
                        file.CopyTo(stream);
                    }

                    var tmpFile = new ImagesUrl
                    {
                        OriginName = fileName,
                        CurrentName = rndName,
                        ATImageUrl = tempPath
                    };

                    // uploadfiles.Add(tmpFile);

                    // 此处地址可能带有两个反斜杠，虽然也能用，比较奇怪，统一转换成斜杠，这样在任何平台都有一样的表现
                    resultPath.Add(tempPath.Replace("\\", "/"));
                }
            }



            var res = new
            {
                Code = 1000,
                Data = resultPath,
                Msg = "上传成功"
            };

            return JsonHelper.Serialize(res);
        }
    }
}