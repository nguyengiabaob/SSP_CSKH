using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSKH_SSP.DataModels;
using Microsoft.EntityFrameworkCore;

namespace CSKH_SSP.Helpers {
    public class DataContext : DbContext {
        public DataContext (DbContextOptions<DataContext> options) : base (options) { }
        public DbSet<RequestIncident> RequestIncident { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<BlockUserTemp> BlockUserTemp { get; set; }
        public DbSet<Requestinfo> Request { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<CountNewMessageForUser> CountNewMessageForUser { get; set; }
        public DbSet<CategoryPermission> CategoryPermission { get; set; }
        public DbSet<RequestContent> RequestContent { get; set; }
        public DbSet<AttachFile> AttachFile { get; set; }
        public DbSet<Advice> Advice { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<DepartmentManager> DepartmentManager { get; set; }
        public DbSet<RequestPermission> RequestPermission { get; set; }
        public DbSet<GroupUserPermission> GroupUserPermission { get; set; }
        public DbSet<Priority> Priority { get; set; }
        public DbSet<RequestAutoID> RequestAutoID { get; set; }
        public DbSet<DeadlineConfig> DeadlineConfig { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<EmailConfig> EmailConfig { get; set; }
        public DbSet<Reason> Reason { get; set; }
        public DbSet<RequestPinned> RequestPinned { get; set; }
        
    }
}