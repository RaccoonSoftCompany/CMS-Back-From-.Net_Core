namespace Article.CMS.Api.Params
{
    /// <summary>
    /// token获取实体
    /// </summary>
    public class TokenParameter
    {
        //生成token的所需要的密钥，一定不能泄漏
        public string Secret { get; set; }

        // 发行token的发行人（可以是个人或者组织）
        public string Issuer { get; set; }

        // token的有效分钟数
        public int AccessExpiration { get; set; }

        // RefreshExpiration的有效分钟数
        public int RefreshExpiration { get; set; }
    }
}