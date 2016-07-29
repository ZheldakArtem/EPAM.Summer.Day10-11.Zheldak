namespace WebApplication1.codeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Message
    {
        public int MessageId { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public int? User_UserId { get; set; }

        public int? UserFrom_UserId { get; set; }

        public int? UserTo_UserId { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }

        public virtual User User2 { get; set; }
    }
}
