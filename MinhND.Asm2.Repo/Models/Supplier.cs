﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MinhND.Asm2.Repo.Models;

public partial class Supplier
{
    [Key]
    public int SupplierID { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string CompanyName { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Address { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Phone { get; set; }

    [InverseProperty("Supplier")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}