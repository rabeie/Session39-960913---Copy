namespace RabieiMoeini
{
    using SessionModel;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SessionDB : DbContext
    {

        public SessionDB()
            : base("name=SessionDB")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Organ> Organs { get; set; }
        public DbSet<Indicator> Indicators { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        //   public DbSet<MeetingGuest> MeetingGuests { get; set; }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<Person>()
        //    //    .Property(p => p.Name)
        //    //    .HasColumnName("FirstName");

        //    modelBuilder.Entity<Meeting>()
        //        .HasMany(tp => tp.Guests)
        //        .WithMany(p => p.Meetings)
        //        .Map(m => m.ToTable("Meetings_Guests","Meeting"));
        //}

    }
    
}
   

        


   