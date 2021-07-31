namespace Article.CMS.Api.Params
{
    /// <summary>
    /// token刷新实体
    /// </summary>
    public class RefreshTokenDTO
    {
        public string Token { get; set; } 
        public string RefreshToken { get; set; }
    }
}