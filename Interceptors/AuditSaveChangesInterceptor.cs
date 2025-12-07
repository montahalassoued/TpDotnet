using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WebApplication1.Models;
public class AuditSaveChangesInterceptor : SaveChangesInterceptor
{
    public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
    {
        var context = eventData.Context;
        if (context == null) return result;

        var auditEntries = new List<AuditLog>();

        foreach (var entry in context.ChangeTracker.Entries())
        {
            if (entry.Entity is AuditLog || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                continue;

            var audit = new AuditLog
            {
                TableName = entry.Entity.GetType().Name,
                Action = entry.State.ToString(),
                EntityKey = entry.Properties.First(p => p.Metadata.IsPrimaryKey()).CurrentValue?.ToString() ?? "",
                Changes = string.Join(", ", entry.Properties
                    .Where(p => p.IsModified)
                    .Select(p => $"{p.Metadata.Name}: {p.OriginalValue} -> {p.CurrentValue}"))
            };

            auditEntries.Add(audit);
        }

        if (auditEntries.Any())
        {
            context.Set<AuditLog>().AddRange(auditEntries);
            context.SaveChanges();
        }

        return result;
    }
}
