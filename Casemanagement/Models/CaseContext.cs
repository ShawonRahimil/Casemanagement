using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Casemanagement.Models
{
    public class CaseContext:DbContext
    {
        public CaseContext():base("connectdb") { 
        
        }
        public DbSet<Adalot> Adalot { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<CaseSource> CaseSources { get; set; }
        public DbSet<Caseinfo> CaseInfo { get; set; }
        public DbSet<CaseDetail> CaseDetail { get; set; }

    }
    public class Adalot
    {
        public int Id { get; set; }
        [Required]
        
        public string Name { get; set; }
        public string Description { get; set; }
        public string logoPath { get; set; }
        [NotMapped]
        public HttpPostedFileBase Picture { get; set; }
    }
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class CaseSource
    {
        public int Id { get; set; }
        public string  Divition { get; set; }

        public string Name { get; set; }
    }
    public class Caseinfo
    {
        public int Id { get; set; }
        [Required]
        public int Casenumber { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Discription { get; set; }
        [ForeignKey("Adalot")]
        public int AdalotId {  get; set; }
        public Adalot Adalot { get; set; }
        [ForeignKey("Section")]
        public int SectionId { get; set; }
        public Section Section { get; set; }

        [ForeignKey("CaseSource")]
        public int CaseSourceId {  get; set; }
        public CaseSource CaseSource { get; set; }




            


    }
    public class CaseDetail
    {
        public int Id { get; set; }
        public DateTime HairingDate { get; set; }
        [Display(Name ="Next HairingDate")]
        public int nextHairingDate { get; set; }
        public string Hairing {  get; set; }
        public string Comments {  get; set; }
        [ForeignKey("Caseinfo")]
        public int CaseinfoId {  get; set; }
        public Caseinfo Caseinfo { get; set; }



    }
}