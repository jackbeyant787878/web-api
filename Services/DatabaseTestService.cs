using MySql.Data.MySqlClient;

namespace asp.net_core_8._0_web_api.Services
{
    public class DatabaseTestService : IDatabaseTestService
    {
        private readonly IConfiguration _configuration;

        public DatabaseTestService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<(bool Success, string Message)> TestConnectionAsync()
        {
            var connStr = _configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrWhiteSpace(connStr))
            {
                return (false, "未找到连接字符串 'DefaultConnection'。");
            }

            try
            {
                await using var conn = new MySqlConnection(connStr);
                // 设置较短的超时以便快速反馈（可根据需要调整）
                //conn.ConnectionTimeout = 5;
                await conn.OpenAsync();
                // 简单执行一个轻量查询确认可以交互
                await using var cmd = new MySqlCommand("SELECT 1;", conn);
                var result = await cmd.ExecuteScalarAsync();
                return (true, $"连接成功，测试查询返回: {result}");
            }
            catch (Exception ex)
            {
                // 不要在生产环境中泄露敏感信息，这里用于测试反馈
                return (false, $"连接失败: {ex.Message}");
            }
        }
    }
}
