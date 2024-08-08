﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Management.Domain.Entities
{
    public class UserAddress : BaseEntity
    {
        [Required]
        [StringLength(500)]
        public string? Fullname { get; set; }
        [Required]
        [StringLength(15)]
        public string? PhoneNumber { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(1000)]
        public string? Address { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public string? UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser? ApplicationUser { get; set; }
    }
}
