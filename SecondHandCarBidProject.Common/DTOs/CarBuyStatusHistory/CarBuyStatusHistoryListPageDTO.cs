using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.Common.DTOs.CarBuyStatusHistory
{
    public record CarBuyStatusHistoryListPageDTO(
        List<CarBuyStatusHistoryTableRow> TableRows,
        int maxPages);
}
