using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace CoreTest.Entities.Contract
{
    [Table("SCM_SalesContract")]
    public class SalesContract : FullAuditedEntity
    {

        //public SalesContract()
        //{
        //    SalesOrders = new List<SalesOrder>();
        //}

        [Key]
        [Column("ContractId",Order =1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Key]
        [Column("CountryCode",Order = 2)]
        [MaxLength(20, ErrorMessage = "MaxLength 20")]
        public virtual string CountryCode { get; set; }

        [MaxLength(20, ErrorMessage = "MaxLength 20")]
        public virtual string ContractNo { get; set; }

        [MaxLength(20, ErrorMessage = "MaxLength 20")]
        public virtual string MainContractNo { get; set; }

        public virtual int? SignCustId { get; set; }

        public virtual int? TagCustId { get; set; }

        public virtual int? Brand { get; set; }

        public virtual int? SignerId { get; set; }

        public virtual int? SignLeaderId { get; set; }

        public virtual int? VindicatorId { get; set; }

        [MaxLength(20, ErrorMessage = "MaxLength 20")]
        public virtual string SignDeptId { get; set; }

        public virtual DateTime? SignDate { get; set; }

        public virtual int? SignCity { get; set; }

        public virtual int? FPrefix { get; set; }

        public virtual int? SignAName { get; set; }

        public virtual int? SaleType { get; set; }

        public virtual DateTime? PbBeginDate { get; set; }

        public virtual DateTime? PbEndDate { get; set; }

        [Column("PbAmount", TypeName = "MONEY")]
        public virtual decimal? PbAmount { get; set; }

        [Column("OtAmount", TypeName = "MONEY")]
        public virtual decimal? OtAmount { get; set; }

        [Column("FactureAmount", TypeName = "MONEY")]
        public virtual decimal? FactureAmount { get; set; }

        [Column("Amount", TypeName = "MONEY")]
        public virtual decimal? Amount { get; set; }

        public virtual decimal? DiscountRate { get; set; }

        public virtual decimal? SalesDiscount { get; set; }

        public virtual int? ContTypeId { get; set; }

        public virtual DateTime? ProBeginDate { get; set; }

        public virtual DateTime? ProEndDate { get; set; }

        [Column("ProAmount", TypeName = "MONEY")]
        public virtual decimal? ProAmount { get; set; }

        public virtual int? ContReturnId { get; set; }

        public virtual DateTime? ContReturnDate { get; set; }

        [MaxLength(2000, ErrorMessage = "MaxLength 2000")]
        public virtual string Remark { get; set; }

        public virtual int? ChangeQuantity { get; set; }

        public virtual int? State { get; set; }

        public virtual bool? IsCalcAI { get; set; }

        public virtual int? ContLevel { get; set; }

        public virtual decimal? AchieveRate { get; set; }

        [Column("AchieveAmount", TypeName = "MONEY")]
        public virtual decimal? AchieveAmount { get; set; }

        public virtual DateTime? CalcDate { get; set; }

        public virtual decimal? CalcCashRate { get; set; }

        [Column("CalcCashAmount", TypeName = "MONEY")]
        public virtual decimal? CalcCashAmount { get; set; }

        [Column("RepAmount", TypeName = "MONEY")]
        public virtual decimal? RepAmount { get; set; }

        public virtual decimal? RepDiscountRate { get; set; }

        [MaxLength(120, ErrorMessage = "MaxLength 120")]
        public virtual string RepRes { get; set; }

        [MaxLength(2000, ErrorMessage = "MaxLength 2000")]
        public virtual string RepDescription { get; set; }

        public virtual decimal? RepRateOfAchieve { get; set; }

        public virtual decimal? RepAmountOfAchieve { get; set; }

        public virtual decimal? RepRateOfCash { get; set; }

        public virtual decimal? RepAmountOfCash { get; set; }

        public virtual bool? RepInvoice { get; set; }

        public virtual bool? IsPublic { get; set; }

        public virtual bool? IsAgent { get; set; }

        public virtual bool? IsReciprocal { get; set; }

        public virtual bool? IsInternal { get; set; }

        public virtual decimal? KickBackRate { get; set; }

        [Column("KickBackAmount", TypeName = "MONEY")]
        public virtual decimal? KickBackAmount { get; set; }

        public virtual int ExecuteState { get; set; }

        public virtual bool? IsExecutionOver { get; set; }

        public virtual int SubmitBy { get; set; }

        public virtual DateTime? SubmitOn { get; set; }

        public virtual int? FAuditBy { get; set; }

        public virtual DateTime? FAuditOn { get; set; }

        public virtual int? SAuditBy { get; set; }

        public virtual DateTime? SAuditOn { get; set; }

        public virtual int? TAuditBy { get; set; }

        public virtual DateTime? TAuditOn { get; set; }

        //[ForeignKey("CountryCode")]
        //public virtual Country Country { get; set; }

        //public virtual List<SalesOrder> SalesOrders { get; set; }


    }
}
