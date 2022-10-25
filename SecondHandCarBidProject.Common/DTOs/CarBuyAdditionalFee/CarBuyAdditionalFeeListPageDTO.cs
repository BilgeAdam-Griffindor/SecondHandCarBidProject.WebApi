using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.Common.DTOs.CarBuyAdditionalFee
{
    public record CarBuyAdditionalFeeListPageDTO(
        List<CarBuyAdditionalFeeTableRowDTO> TableRows,
        int maxPages
        );
}
