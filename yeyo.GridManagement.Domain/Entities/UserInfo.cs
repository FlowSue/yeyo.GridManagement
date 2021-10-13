using System;
using SqlSugar;
using yeyo.GridManagement.Domain.Models;

namespace yeyo.GridManagement.Domain.Entities
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("UserInfo")]
    public class UserInfo : EntityBaseModel
    {
        /// <summary>
        /// 
        ///</summary>
        [SugarColumn(ColumnName = "Id", IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        /// <summary>
        /// 用户名
        ///</summary>
        [SugarColumn(ColumnName = "UserName")]
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        ///</summary>
        [SugarColumn(ColumnName = "Password")]
        public string Password { get; set; }
        /// <summary>
        /// 姓名
        ///</summary>
        [SugarColumn(ColumnName = "Name")]
        public string Name { get; set; }
        /// <summary>
        /// 部门Id
        ///</summary>
        [SugarColumn(ColumnName = "DepartmentId")]
        public int? DepartmentId { get; set; }
        /// <summary>
        /// 职能部门
        ///</summary>
        [SugarColumn(ColumnName = "FunctionalDeptId")]
        public int FunctionalDeptId { get; set; }
        /// <summary>
        /// 职务Id
        ///</summary>
        [SugarColumn(ColumnName = "UserZWType")]
        public int UserZwType { get; set; }
        /// <summary>
        /// 电话号码
        ///</summary>
        [SugarColumn(ColumnName = "TelePhone")]
        public string TelePhone { get; set; }
        /// <summary>
        /// 用户级别：1市级，2区级，3街道，4社区，5网格
        ///</summary>
        [SugarColumn(ColumnName = "UserLevel")]
        public int UserLevel { get; set; }
        /// <summary>
        /// 角色Id
        ///</summary>
        [SugarColumn(ColumnName = "RoleId")]
        public int RoleId { get; set; }
        /// <summary>
        /// 排序
        ///</summary>
        [SugarColumn(ColumnName = "Sort")]
        public int Sort { get; set; }
        /// <summary>
        /// 工作内容
        ///</summary>
        [SugarColumn(ColumnName = "WorkContent")]
        public string WorkContent { get; set; }
        /// <summary>
        /// 手机串号
        ///</summary>
        [SugarColumn(ColumnName = "SerialNumber")]
        public string SerialNumber { get; set; }
        /// <summary>
        /// 加密狗编号
        ///</summary>
        [SugarColumn(ColumnName = "UkeyNo")]
        public string UkeyNo { get; set; }
        /// <summary>
        /// 加密狗
        ///</summary>
        [SugarColumn(ColumnName = "UKey")]
        public string UKey { get; set; }
        /// <summary>
        /// 是否启用，0否，1是
        ///</summary>
        [SugarColumn(ColumnName = "IsEnable")]
        public int IsEnable { get; set; }
        /// <summary>
        /// 引导
        ///</summary>
        [SugarColumn(ColumnName = "IsYinDao")]
        public int IsYinDao { get; set; }
        /// <summary>
        /// 党员
        ///</summary>
        [SugarColumn(ColumnName = "IsDangYuan")]
        public int IsDangYuan { get; set; }
        /// <summary>
        /// openid
        ///</summary>
        [SugarColumn(ColumnName = "OpenId")]
        public string OpenId { get; set; }
        /// <summary>
        /// 创建时间
        ///</summary>
        [SugarColumn(ColumnName = "Createdate")]
        public DateTime Createdate { get; set; }
        /// <summary>
        /// 是否删除：0否，1是
        ///</summary>
        [SugarColumn(ColumnName = "IsDeleted")]
        public int IsDeleted { get; set; }
        /// <summary>
        /// 民警
        ///</summary>
        [SugarColumn(ColumnName = "IsMinJing")]
        public int IsMinJing { get; set; }
        /// <summary>
        /// 纬度
        ///</summary>
        [SugarColumn(ColumnName = "Lat")]
        public decimal? Lat { get; set; }
        /// <summary>
        /// 经度
        ///</summary>
        [SugarColumn(ColumnName = "Lng")]
        public decimal? Lng { get; set; }
        /// <summary>
        /// 更新时间
        ///</summary>
        [SugarColumn(ColumnName = "UpdateTime")]
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// 是否部门主任
        ///</summary>
        [SugarColumn(ColumnName = "LingDaoLevel")]
        public int? LingDaoLevel { get; set; }
        /// <summary>
        /// 生日
        ///</summary>
        [SugarColumn(ColumnName = "Birthday")]
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// 学历
        ///</summary>
        [SugarColumn(ColumnName = "XLType")]
        public int? XlType { get; set; }
        /// <summary>
        /// 协同
        ///</summary>
        [SugarColumn(ColumnName = "IsXT")]
        public int IsXt { get; set; }
        /// <summary>
        /// 机关
        ///</summary>
        [SugarColumn(ColumnName = "IsJG")]
        public int IsJg { get; set; }
        /// <summary>
        /// 平台id
        ///</summary>
        [SugarColumn(ColumnName = "PlatformId")]
        public int? PlatformId { get; set; }
        /// <summary>
        /// 平台编码
        ///</summary>
        [SugarColumn(ColumnName = "PlatformCode")]
        public string PlatformCode { get; set; }
        /// <summary>
        /// 上次修改密码时间
        ///</summary>
        [SugarColumn(ColumnName = "LastModifyPasswordTime")]
        public DateTime? LastModifyPasswordTime { get; set; }
        /// <summary>
        /// 密码掩码
        ///</summary>
        [SugarColumn(ColumnName = "Mask")]
        public string Mask { get; set; }
        /// <summary>
        /// 
        ///</summary>
        [SugarColumn(ColumnName = "UUID")]
        public Guid Uuid { get; set; }
        /// <summary>
        /// 
        ///</summary>
        [SugarColumn(ColumnName = "IsUpdate_1")]
        public int IsUpdate1 { get; set; }
        /// <summary>
        /// 
        ///</summary>
        [SugarColumn(ColumnName = "IsUpdate_2")]
        public int IsUpdate2 { get; set; }
    }
}
