namespace asp.net_core_8._0_web_api.Services
{
    public interface IDatabaseTestService
    {
        /// <summary>
        /// 测试数据库连接并返回 (是否成功, 说明信息)
        /// </summary>
        Task<(bool Success, string Message)> TestConnectionAsync();
    }
}
