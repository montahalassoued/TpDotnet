using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WebApplication1.Models;
public class AuditSaveChangesInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        var context = eventData.Context;
        if (context == null) return base.SavingChanges(eventData, result);

        var auditEntries = new List<AuditLog>();

        foreach (var entry in context.ChangeTracker.Entries())
        {
            if (entry.Entity is AuditLog || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                continue;

            var changes = string.Join(", ", entry.Properties
                .Where(p => p.IsModified)
                .Select(p => $"{p.Metadata.Name}: {p.OriginalValue} -> {p.CurrentValue}"));

            if (entry.State == EntityState.Modified && string.IsNullOrEmpty(changes))
                continue; 

            var audit = new AuditLog
            {
                TableName = entry.Entity.GetType().Name,
                Action = entry.State.ToString(),
                EntityKey = entry.Properties.First(p => p.Metadata.IsPrimaryKey()).CurrentValue?.ToString() ?? "",
                Changes = changes,
                Date = DateTime.UtcNow
            };

            auditEntries.Add(audit);
        }

        if (auditEntries.Any())
        {
            context.AddRange(auditEntries);
            
        }

        return base.SavingChanges(eventData, result);
    }
}
