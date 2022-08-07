﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EfCoreToolsTest.Models
{
    public partial class Users
    {
        public Users()
        {
            UserRoleAssignment = new HashSet<UserRoleAssignment>();
        }

        public int AutoSeq { get; set; }
        [Key]
        public Guid UserId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string UserFullName { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string UserName { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string Password { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<UserRoleAssignment> UserRoleAssignment { get; set; }
    }
}