
namespace Article.CMS.Api.Entity
{
    /// <summary>
    /// 二维码实体
    /// </summary>
    public class QRCode : BaseEntity
    {
        //站点Id
        public int WebSideId { get; set; }
        public virtual WebSide WebSid { get; set; }

        //QR
        public string QRUrl { get; set; }

    }
}