using WebApplication1.Models;
using System.Collections.Generic;

namespace WebApplication1.Services
{
    public interface IAuditService
    {
        IEnumerable<AuditLog> GetAllLogs();
        IEnumerable<AuditLog> GetLogsByTable(string tableName);
        IEnumerable<AuditLog> GetLogsByAction(string action); 
    }
}
