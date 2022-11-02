using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.Common.DTOs.CarBuy
{
    public record CarBuyListPageDTO(
        List<IdNameListDTO> BrandList,
        List<IdNameListDTO> ModelList,
        List<IdNameListDTO> StatusList,
        List<CarBuyListTableRowDTO> TableRows,
        int maxPages
        );
}
