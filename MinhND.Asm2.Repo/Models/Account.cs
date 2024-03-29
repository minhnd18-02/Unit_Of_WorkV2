﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MinhND.Asm2.Repo.Models;

[Table("Account")]
public partial class Account
{
    [Key]
    public int AccountID { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string UserName { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Password { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string FullName { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Type { get; set; }
}