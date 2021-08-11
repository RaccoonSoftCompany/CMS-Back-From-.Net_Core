# CMS-Back-From-.Net_Core
主要使用.Net Core WebApi编写的CMS内容管理系统的后端代码
# 还原项目
* dotnet restore
# 迁移数据库
* dotnet ef database update
# 运行
* dotnet run
# 接口测试
* 可在text.http文件中进行测试
# token验证
* 在需要验证的地方加上[Authorize]即可使用token


Article.CMS.Api

发布
dotnet publish -c Release