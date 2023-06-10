using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Note.Unity.DbModels;

/// <summary>
/// 卡片的配置信息
/// </summary>
[Table("card_config")]
public class CardConfig
{
    [Key]
    public string Id { get; set; }
    
    /// <summary>
    /// 卡片名称
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// 卡片创建时间
    /// </summary>
    public DateTime CreateTime { get; set; } = DateTime.Now;
    
    /// <summary>
    /// 软删除标识符号
    /// </summary>
    public bool IsDelete { get; set; }
}