using WebApplication1.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Services
{
    public class AuditService : IAuditService
    {
        private readonly ApplicationDbContext _db;

        public AuditService(ApplicationDbContext db)
        {
            _db = db;
        }

        // Récupère tous les logs, triés par date décroissante
        public IEnumerable<AuditLog> GetAllLogs()
        {
            return _db.AuditLogs
                      .OrderByDescending(a => a.Date)
                      .ToList();
        }

        // Récupère les logs filtrés par nom de table
        public IEnumerable<AuditLog> GetLogsByTable(string tableName)
        {
            return _db.AuditLogs
                      .Where(a => a.TableName == tableName)
                      .OrderByDescending(a => a.Date)
                      .ToList();
        }

        // Récupère les logs filtrés par action (Added, Modified, Deleted)
        public IEnumerable<AuditLog> GetLogsByAction(string action)
        {
            return _db.AuditLogs
                      .Where(a => a.Action == action)
                      .OrderByDescending(a => a.Date)
                      .ToList();
        }
    }
}
