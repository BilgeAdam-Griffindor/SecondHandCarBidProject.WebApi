using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.Common.DTOs.BidResult
{
    public record BidResultListPageDTO(
        List<BidResultListTableRowsDTO> TableRows,
        int maxPages
        );
}
