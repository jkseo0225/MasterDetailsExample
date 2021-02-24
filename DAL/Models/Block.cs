using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Block
    {
        public int Id { get; set; }
        public string BlockName { get; set; }

        public int TargetSmallGen { get; set; }
        public int TargetSmallSun { get; set; }
        public int TargetBigGen { get; set; }
        public int TargetBigSun { get; set; }

        public int TargetTotalSum
        {
            get
            {
                return (this.TargetSmallGen + this.TargetSmallSun + this.TargetBigGen + this.TargetBigSun);
            }
        }
        public int RestedTotalSum
        {
            get
            {
                return this.TargetTotalSum - (this.ProductGenSum + this.ProductSunSum);

            }
        }
        public int Percent
        {
            get
            {
                return (this.TargetTotalSum - this.RestedTotalSum) / this.TargetTotalSum;
            }
        }

        public int ProductGenSmall { get; set; }
        public int ProductGenBig { get; set; }
        public int ProductGenSum
        {
            get
            {
                return this.ProductGenSmall + this.ProductGenBig;
            }
        }
        public int ProductGenRested
        {
            get
            {
                return (this.TargetSmallGen + this.TargetBigGen) - this.ProductGenSum;
            }
        }

        public int ProductSunSmall { get; set; }
        public int ProductSunBig { get; set; }
        public int ProductSunSum
        {
            get
            {
                return this.ProductSunSmall + this.ProductSunBig;
            }
        }
        public int ProductSunRested
        {
            get
            {
                return (this.TargetSmallSun + this.TargetBigSun) - this.ProductSunSum;
            }
        }

        public DateTime TargetDate { get; set; }

        [Required]
        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

    }
}
