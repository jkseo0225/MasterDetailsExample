using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Block
    {
        public int Id { get; set; }
        [Display(Name = "블럭명")]
        public string BlockName { get; set; }

        [Display(Name = "일반관(소형물량)")]
        public int TargetSmallGen { get; set; }
        [Display(Name = "선급관(소형물량)")]
        public int TargetSmallSun { get; set; }
        [Display(Name = "일반관(대형물량)")]
        public int TargetBigGen { get; set; }
        [Display(Name = "선급관(대형물량)")]
        public int TargetBigSun { get; set; }

        [Display(Name = "소계(물량)")]
        public int TargetTotalSum
        {
            get
            {
                return (this.TargetSmallGen + this.TargetSmallSun + this.TargetBigGen + this.TargetBigSun);
            }
        }
        [Display(Name = "총 잔량")]
        public int RestedTotalSum
        {
            get
            {
                return (this.TargetTotalSum - (this.ProductGenSum + this.ProductSunSum));

            }
        }

        [Display(Name = "공정율(%)")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N1}")]
        public decimal Percent
        {
            get
            {                
                return (decimal)(((this.TargetTotalSum - this.RestedTotalSum) / this.TargetTotalSum) * 100);
            }
        }

        [Display(Name = "소형(일반관생산)")]
        public int ProductGenSmall { get; set; }
        [Display(Name = "대형(일반관생산)")]
        public int ProductGenBig { get; set; }
        [Display(Name = "소계(일반관생산)")]
        public int ProductGenSum
        {
            get
            {
                return (this.ProductGenSmall + this.ProductGenBig);
            }
        }
        [Display(Name = "잔량(일반관생산)")]
        public int ProductGenRested
        {
            get
            {
                return ((this.TargetSmallGen + this.TargetBigGen) - this.ProductGenSum);
            }
        }

        [Display(Name = "소형(선급관생산)")]
        public int ProductSunSmall { get; set; }
        [Display(Name = "대형(선급관생산)")]
        public int ProductSunBig { get; set; }
        [Display(Name = "소계(선급관생산)")]
        public int ProductSunSum
        {
            get
            {
                return (this.ProductSunSmall + this.ProductSunBig);
            }
        }
        [Display(Name = "잔량(선급관생산)")]
        public int ProductSunRested
        {
            get
            {
                return ((this.TargetSmallSun + this.TargetBigSun) - this.ProductSunSum);
            }
        }

        [Display(Name = "납기예정일")]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}")]
        public DateTime TargetDate { get; set; }

        [Display(Name = "프로젝트Id")]
        [Required]
        public int ProjectId { get; set; }
        [Display(Name = "프로젝트")]
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

    }
}
