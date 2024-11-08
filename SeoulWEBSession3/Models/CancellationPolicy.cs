using System;
using System.Collections.Generic;

namespace SeoulWEBSession3.Models;

public partial class CancellationPolicy
{
    public long Id { get; set; }

    public Guid Guid { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<CancellationRefundFee> CancellationRefundFees { get; set; } = new List<CancellationRefundFee>();

    public virtual ICollection<ItemPrice> ItemPrices { get; set; } = new List<ItemPrice>();
}
