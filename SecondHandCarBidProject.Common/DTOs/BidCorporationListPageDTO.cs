using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.Common.DTOs
{
    public record BidCorporationListPageDTO(
        List<BidCorporationListTableRowsDTO> TableRows,
        int maxPages
        );
}
