using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class Model1 : DbContext
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'STAS.MODELS.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        public Model1()
            : base("name=STAS")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Photo> Photoes { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }

    public class Message
    {
        public int MessageId { get; set; }
        public virtual User UserFrom { get; set; }
        public virtual User UserTo { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

    }

    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }

    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public DateTime? UserBirthDate { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public int UserPhotoId { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        public virtual ICollection<User> Friends { get; set; }

        public virtual ICollection<User> InFriends { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }
    }
    public class Photo
    {
        public int PhotoId { get; set; }

        public byte[] Data { get; set; }

        public string MimeType { get; set; }

        public DateTime Date { get; set; }

        public virtual User User { get; set; }
    }
}