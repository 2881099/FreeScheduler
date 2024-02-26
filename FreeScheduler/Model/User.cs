using FreeSql.DataAnnotations;

namespace FreeScheduler.Model
{
    /// <summary>
    /// 用户
    /// </summary>
    public class User
    {
        /// <summary>
        /// UserName
        /// </summary>
        [Column(IsPrimary = true)]
        public string UserName { get; set; }

        /// <summary>
        /// Pwd
        /// </summary>
        public string Pwd { get; set; }
    }
}