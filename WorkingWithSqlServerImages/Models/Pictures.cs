﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkingWithSqlServerImages.Models;

[Table("Pictures1")]
public partial class Pictures
{
    [Key]
    public int Id { get; set; }

    public byte[] Photo { get; set; }
}